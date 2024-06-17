using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCFishingBot
{
	public partial class MCMacro
	{
		/// <summary>
		/// 프로세스 찾는 함수
		/// </summary>
		private void GetProcessList()
		{
			Process[] processlist = Process.GetProcesses();

			foreach (Process process in processlist)
			{
				if (process.MainWindowTitle != "")
				{
					var processInfo = String.Format("{0} - {1}", process.MainWindowTitle, process.ProcessName);

					if (processInfo.Contains("Minecraft") && !processInfo.Contains("Launcher"))
					{
						var pId = process.Id;
						cbProcessList.Items.Add(new { DisPlay = $"{processInfo} ({pId})", Value = pId });
						cbProcessList.DisplayMember = "DisPlay";
						cbProcessList.ValueMember = "Value";
					}

					if (cbProcessList.Items.Count > 0)
					{
						cbProcessList.SelectedIndex = 0;
					}
				}
			}
		}

		/// <summary>
		/// 키보드 이벤트 창에 전달 함수
		/// </summary>
		/// <param name="processId"></param>
		private void SendRightClick(int processId)
		{
			IntPtr windowHandle = GetWindowHandle(processId);

			PostMessage(windowHandle, WM_RBUTTONDOWN, ((IntPtr)0), (IntPtr)0);
			PostMessage(windowHandle, WM_RBUTTONUP, ((IntPtr)0), (IntPtr)0);
		}

		/// <summary>
		/// 매크로 실행 처리 함수
		/// </summary>
		/// <returns></returns>
		private async Task RunMacro()
		{
			try
			{
				using (Bitmap screenBitmap = await PrintWindowAsync(ProcessID))
				{
					using (Bitmap findBitmap = await GetFindBitMat())
					{
						await FindImageAsync(screenBitmap, findBitmap);

						//int imageWidth = screenBitmap.Width;
						//int imageHeight = screenBitmap.Height;
						//// 왼쪽을 80% 자르는 비율
						//double leftRatio = 0.2;
						//// 위쪽을 70% 자르는 비율
						//double topRatio = 0.3;

						//// 왼쪽 부분의 너비와 시작점 계산
						//int leftWidth = (int)(imageWidth * leftRatio);
						//int xStart = imageWidth - leftWidth;

						//// 위쪽 부분의 높이와 시작점 계산
						//int topHeight = (int)(imageHeight * topRatio);
						//int yStart = imageHeight - topHeight;

						//// 자를 영역의 크기 계산
						//int Width = leftWidth;
						//int Height = topHeight;

						//using (Bitmap sliceBitmap = await SliceImageAsync(xStart, yStart, Width, Height, screenBitmap))
						//{
						//	await FindImageAsync(screenBitmap, findBitmap);
						//}
					}
				}
			}
			catch (Exception)
			{
				Active = false;
				ButtonHandler();
				MacroTimer.Stop();
				UpdateMacroStatus();

				ShowErrorMsg("마인크래프트 창을 찾을 수 없습니다.");
				UpdateLog("매크로가 중지 되었습니다");
			}
		}

		/// <summary>
		/// 윈도우 창 캡쳐후 저장 함수
		/// </summary>
		/// <returns></returns>
		private async Task CaptureImage()
		{
			try
			{
				if(cbProcessList.Items.Count == 0 || ProcessID == 0) 
				{
					ShowErrorMsg("마인크래프트 창을 찾을 수 없습니다");
					return;
				}
				using (Bitmap screenBitmap = await PrintWindowAsync(ProcessID))
				{
					using (SaveFileDialog saveFileDialog = new SaveFileDialog())
					{
						// 다이얼로그 로드시 최초로 보여주는 저장위치(바탕화면)
						saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
						// 초기 저장이름
						saveFileDialog.FileName = "capture.jpg";
						// 파일 필터
						saveFileDialog.Filter = "JPEG 파일 (*.jpeg;*.jpg)|*.jpeg;*.jpg";

						if (saveFileDialog.ShowDialog() == DialogResult.OK)
						{
							if (File.Exists(saveFileDialog.FileName))
							{
								File.Delete(saveFileDialog.FileName);
							}
							screenBitmap.Save(saveFileDialog.FileName, ImageFormat.Jpeg);
							UpdateLog($"이미지가 {saveFileDialog.FileName}에 저장 되었습니다");
						}
					}
				}
			}
			catch (Exception ex)
			{
				ShowErrorMsg(ex.Message);
				UpdateLog("이미지 저장에 실패했습니다");
			}
		}

		/// <summary>
		/// 타이머 제어 정지 함수
		/// </summary>
		/// <param name="secounds"></param>
		/// <returns></returns>
		private async Task ControllTimerStopAsync(int secounds)
		{
			MacroTimer.Stop();
			await Task.Delay(secounds);
		}

		/// <summary>
		/// 타이머 제어 시작 함수
		/// </summary>
		/// <param name="secounds"></param>
		/// <returns></returns>
		private async Task ControllTimerStartAsync(int secounds)
		{
			await Task.Delay(secounds);
			MacroTimer.Start();
		}

		/// <summary>
		/// 패턴 비트맵 반환 함수
		/// </summary>
		/// <returns></returns>
		private async Task<Bitmap> GetFindBitMat()
		{
			Bitmap findBitmap;

			if (UseDefaultImg)
			{
				findBitmap = new Bitmap(Properties.Resources.capture);
			}
			else
			{
				findBitmap = new Bitmap(FilePath);
			}

			return findBitmap;
		}
	}
}
