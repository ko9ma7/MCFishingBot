using System;
using System.Drawing;
using MessageBox = System.Windows.Forms.MessageBox;

namespace MCFishingBot
{
	public partial class MCMacro
	{

		/// <summary>
		/// 버튼 활성화 처리
		/// </summary>
		private void ButtonHandler()
		{
			Invoke(new Action(() =>
			{
				btnBotStart.Enabled = !Active;
				btnBotStop.Enabled = Active;
				btnImageUpload.Enabled = !Active;
				btnImageDownload.Enabled = !Active;
				btnSettingReset.Enabled = !Active;
				btnFishingTimesReset.Enabled = !Active;

				numBotStartDelay.Enabled = !Active;
				numMacroTimes.Enabled = !Active;
				numThrowDelay.Enabled = !Active;
				numCollectDelay.Enabled = !Active;
				numCurrectRate.Enabled = !Active;

				cbDefaultImg.Enabled = !Active;
			}));
		}

		/// <summary>
		/// 로그 처리
		/// </summary>
		/// <param name="log"></param>
		private void ShowLog(string log)
		{
			Invoke(new Action(() =>
			{
				lbLog.Items.Add($"{DateTime.Now.ToString("HH:mm:ss")} : {log}");

				// 항상 최신 로그가 선택되게끔 함
				lbLog.SelectedIndex = lbLog.Items.Count != -1 ? lbLog.Items.Count - 1 : -1;
			}));
		}

		/// <summary>
		/// 로그 글자 수 계산
		/// </summary>
		/// <param name="log"></param>
		private void UpdateLog(string log)
		{
			int max_log_length = 20; // 글자 최대 길이 한글 기준 20자
			int max_byte_length = max_log_length * 3; // 한글 기준 3byte

			int byteCount = 0;
			int startIndex = 0;

			for (int i = 0; i < log.Length; i++)
			{
				char c = log[i];
				byteCount += GetUTFToByteSize(c); // 아스키 1byte 한글 3byte

				if (byteCount > max_byte_length)
				{
					ShowLog(log.Substring(startIndex, i - startIndex));
					byteCount = 0; // 바이트 계산 초기화
					startIndex = i; // 인덱스 재시작값 지정
				}
			}

			// 나머지 전체 문자열 출력
			if (startIndex < log.Length)
			{
				ShowLog(log.Substring(startIndex));
			}
		}

		/// <summary>
		/// UTF-8 에 따른 캐릭터 바이트 사이즈 반환
		/// </summary>
		/// <param name="c"></param>
		/// <returns></returns>
		private int GetUTFToByteSize(char c)
		{
			// https://www.ibm.com/docs/ko/aix/7.3?topic=8-utf-ucs-transformation-format
			// 0x0000007F(1byte) 0x000007FF(2byte) 0x0000FFFF(3byte) 0x001FFFFF(4byte)
			if (c < 0x80)
			{
				return 1;
			}
			else if (c < 0x800)
			{
				return 2;
			}
			else if (c < 0x10000)
			{
				return 3;
			}
			else if (c < 0x110000)
			{
				return 4;
			}
			else
			{
				return 0;
			}
		}

		/// <summary>
		/// 메시지 박스 에러메세지 처리
		/// </summary>
		/// <param name="errorMsg"></param>
		private void ShowErrorMsg(string errorMsg)
		{
			MessageBox.Show(errorMsg, "MCFishingBot");
		}

		/// <summary>
		/// 낚시 회수 처리
		/// </summary>
		private void UpdateFishigTimes()
		{
			Invoke(new Action(() =>
			{
				lbFishingTimes.Text = Fished.ToString();
			}));
		}

		/// <summary>
		/// 매크로 실행 상태 여부 라벨 세팅
		/// </summary>
		private void UpdateMacroStatus()
		{
			Invoke(new Action(() =>
			{
				if (!Active)
				{
					ssMacroStatus.Text = "정지중";
					ssMacroStatus.ForeColor = Color.Red;
				}
				else
				{
					ssMacroStatus.Text = "실행중";
					ssMacroStatus.ForeColor = Color.Green;
				}
			}));
		}

		// 설정 최소값 처리들
		private void numMacroTimes_ValueChanged(object sender, EventArgs e)
		{
			if (numMacroTimes.Value < numMacroTimes.Minimum)
			{
				numMacroTimes.Value = numMacroTimes.Minimum;
			}
		}

		private void numBotStartDelay_ValueChanged(object sender, EventArgs e)
		{
			if (numBotStartDelay.Value < numBotStartDelay.Minimum)
			{
				numBotStartDelay.Value = numBotStartDelay.Minimum;
			}
		}

		private void numThrowDelay_ValueChanged(object sender, EventArgs e)
		{
			if (numThrowDelay.Value < numThrowDelay.Minimum)
			{
				numThrowDelay.Value = numThrowDelay.Minimum;
			}
		}

		private void numCollectDelay_ValueChanged(object sender, EventArgs e)
		{
			if (numCollectDelay.Value < numCollectDelay.Minimum)
			{
				numCollectDelay.Value = numCollectDelay.Minimum;
			}
		}

		private void numCurrectRate_ValueChanged(object sender, EventArgs e)
		{
			if (numCurrectRate.Value < numCurrectRate.Minimum)
			{
				numCurrectRate.Value = numCurrectRate.Minimum;
			}
		}
	}

}
