using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCFishingBot
{
	public partial class MCMacro : Form
	{
		/// <summary>
		/// 프로세스 ID
		/// </summary>
		private int ProcessID = 0;
		/// <summary>
		/// 낚시 한 횟수
		/// </summary>
		private int Fished = 0;
		/// <summary>
		/// 매크로 실행 여부
		/// </summary>
		private bool Active = false;
		/// <summary>
		/// 이미지 패턴 업로드 경로
		/// </summary>
		private string FilePath = string.Empty;
		/// <summary>
		/// 기본 이미지 사용 여부
		/// </summary>
		private bool UseDefaultImg = false;

		/// <summary>
		/// 매크로 시작딜레이
		/// </summary>
		private int BotStartDelay = 0;
		/// <summary>
		/// 매크로 횟수
		/// </summary>
		private int MacroTimes = 0;
		/// <summary>
		/// 매크로 실행한 횟수
		/// </summary>
		private int DoTimes = 0;
		/// <summary>
		/// 낚시대 던지기 딜레이
		/// </summary>
		private int FishingThrowDelay = 0;
		/// <summary>
		/// 낚시대 회수 딜레이
		/// </summary>
		private int FishingCollectDelay = 0;
		/// <summary>
		/// 이미지 패턴 정확도
		/// </summary>
		private double CurrectRate = 0.0;

		/// <summary>
		/// 쓰레드 작업 완료 여부
		/// </summary>
		private TaskCompletionSource<bool> TCS;

		public MCMacro()
		{
			InitializeComponent();
		}

		private void MCMacro_Load(object sender, EventArgs e)
		{
			GetProcessList();
		}

		private void cbProcessList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbProcessList.Items.Count > 0)
			{
				ProcessID = (cbProcessList.SelectedItem as dynamic).Value;
			}
		}

		/// <summary>
		/// 프로세스 새로고침 처리
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnProcessReload_Click(object sender, EventArgs e)
		{
			ProcessID = 0;
			cbProcessList.Items.Clear();

			GetProcessList();
		}

		/// <summary>
		/// 매크로 실행 버튼 처리
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnBotStart_Click(object sender, EventArgs e)
		{
			try
			{
				if (cbProcessList.Items.Count == 0 || ProcessID == 0)
				{
					ShowErrorMsg("마인크래프트가 실행되어있지 않습니다.");
					return;
				}
				if (String.IsNullOrEmpty(FilePath) && UseDefaultImg == false)
				{
					ShowErrorMsg("매크로 패턴이 업로드 되지 않았습니다.\n이미지를 업로드 해주십시오.");
					return;
				}

				UpdateLog("매크로를 실행합니다");
				Active = true;
				this.BotStartDelay = (int)numBotStartDelay.Value;
				this.MacroTimes = (int)numMacroTimes.Value;
				this.FishingThrowDelay = (int)numThrowDelay.Value;
				this.FishingCollectDelay = (int)numCollectDelay.Value;
				this.CurrectRate = (double)numCurrectRate.Value / 10;
				TCS = new TaskCompletionSource<bool>();

				// 버튼 비활성화
				ButtonHandler();
				// 라벨 제어
				UpdateMacroStatus();
				// 초기낚시대 던지기
				SendRightClick(ProcessID);
				// 매크로 실행
				_ = RunMacro();
			}
			catch (Exception)
			{
				UpdateLog("매크로 실행에 실패했습니다.");
			}
		}

		/// <summary>
		/// 매크로 정지 버튼 처리
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnBotStop_Click(object sender, EventArgs e)
		{
			StopMacro();
			// 가비지 컬렉터 수행
			GC.Collect(0);
		}

		/// <summary>
		/// 이미지 패턴 업로드 처리
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private async void btnImageUpload_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				// 다이얼로그 로드시 최초로 보여주는 저장위치(바탕화면)
				openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
				
				openFileDialog.Filter = "JPEG 파일 (*.jpeg;*.jpg)|*.jpeg;*.jpg";

				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					FilePath = openFileDialog.FileName;
					UpdateLog($"{Path.GetFileName(FilePath)} 의 이미지가 패턴에 등록되었습니다.");
				}
			}
		}

		/// <summary>
		/// 윈도우 창 이미지 저장 처리
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnImageDownload_Click(object sender, EventArgs e)
		{
			_ = CaptureImage();
		}

		/// <summary>
		/// 낚시 한 횟수 초기화 처리
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnFishingTimesReset_Click(object sender, EventArgs e)
		{
			this.Fished = 0;
			UpdateFishigTimes();
		}

		/// <summary>
		/// 설정 리셋 처리
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSettingReset_Click(object sender, EventArgs e)
		{
			numMacroTimes.Value = 0;
			numBotStartDelay.Value = 2000;
			numThrowDelay.Value = 1000;
			numCollectDelay.Value = 0;
			numCurrectRate.Value = 9;
		}

		/// <summary>
		/// 디폴트 이미지 패턴 사용 여부 체크
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cbDefaultImg_CheckedChanged(object sender, EventArgs e)
		{
			if(cbDefaultImg.Checked)
			{
				if (MessageBox.Show("프로그램 내부에 저장되어있는 기본 이미지 패턴을 사용합니다.\n이미지 패턴을 찾기위한 적정 게임 해상도를 찾는데 조금 시간이 걸릴 수 있습니다.\n또한 컴퓨터 성능에 따라 프로그램의 작동이 중지 될 수 있습니다, 정말로 사용하시겠습니까?", "MCFishingBot", MessageBoxButtons.YesNo) == DialogResult.No)
				{
					cbDefaultImg.Checked = false;
				}
				else
				{
					UseDefaultImg = true;
				}
			}
			else
			{
				UseDefaultImg = false;
			}
		}
	}
}
