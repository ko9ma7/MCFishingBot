﻿using System;
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

					if (processInfo.Contains("Minecraft") && !processInfo.Contains("Launcher") && !processInfo.Contains("Chrome"))
					{
						var pId = process.Id;
						cbProcessList.Items.Add(new { DisPlay = $"{processInfo} ({pId})", Value = pId });
						cbProcessList.DisplayMember = "DisPlay";
						cbProcessList.ValueMember = "Value";
					}
				}
			}

			if (cbProcessList.Items.Count > 0)
			{
				cbProcessList.SelectedIndex = 0;
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
				await Task.Run(async () =>
				{
					while (Active)
					{
						// 반복문 딜레이
						await Task.Delay(500);

						using Bitmap screenBitmap = await PrintWindowAsync(ProcessID);

						using Bitmap findBitmap = await GetFindBitmapAsync();

						MyVector oldVector = new MyVector(screenBitmap.Width, screenBitmap.Height);

						// 이미지 크기 50%
						MyVector endVector = oldVector * 0.5;

						MyVector startVector = oldVector - endVector;

						using Bitmap sliceBitmap = await SliceImageAsync(startVector.X, startVector.Y, endVector.X, endVector.Y, screenBitmap);

						// 에러 방지
						if (sliceBitmap.Width <= findBitmap.Width || sliceBitmap.Height <= findBitmap.Height)
						{
							await FindImageAsync(screenBitmap, findBitmap);
						}
						else
						{
							await FindImageAsync(sliceBitmap, findBitmap);
						}
					}
				});
			}
			catch (Exception ex)
			{
				Active = false;
				ButtonHandler();
				UpdateMacroStatus();
				this.DefaultScale = 0.9;
				this.DoTimes = 0;

				ShowErrorMsg("마인크래프트 창을 찾을 수 없습니다.");
				UpdateLog("매크로가 중지 되었습니다.");
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
				if (cbProcessList.Items.Count == 0 || ProcessID == 0)
				{
					ShowErrorMsg("마인크래프트 창을 찾을 수 없습니다.");
					return;
				}

				using Bitmap screenBitmap = await PrintWindowAsync(ProcessID);

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
						UpdateLog($"이미지가 {saveFileDialog.FileName}에 저장 되었습니다.");
					}
				}

			}
			catch (Exception)
			{
				ShowErrorMsg("마인크래프트 창을 찾을 수 없습니다.");
				UpdateLog("이미지 저장에 실패했습니다.");
			}
		}

		/// <summary>
		/// 패턴 비트맵 반환 함수
		/// </summary>
		/// <returns></returns>
		private async Task<Bitmap> GetFindBitmapAsync()
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

		/// <summary>
		/// 매크로 종료 처리
		/// </summary>
		private async void StopMacro()
		{
			Active = false;
			Invoke(new Action(() =>
			{
				btnBotStop.Enabled = false;
			}));

			UpdateLog("모든 작업이 완료된 후 매크로가 종료됩니다...");

			// 매크로 작업 쓰레드 완료 대기
			await TCS.Task;

			ButtonHandler();
			UpdateMacroStatus();
			this.DoTimes = 0;
			this.DefaultScale = 0.9;
			this.FoundDefaultScale = false;
			this.FoundScale = 0.0;

			UpdateLog("매크로가 종료 되었습니다.");
		}
	}
}
