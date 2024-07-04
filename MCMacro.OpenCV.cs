using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace MCFishingBot
{
	public partial class MCMacro
	{
		/// <summary>
		/// 디폴트 이미지 너비 상수
		/// </summary>
		const int DefaultImgWidth = 854;
		/// <summary>
		/// 디폴트 이미지 높이 상수
		/// </summary>
		const int DefaultImgHeight = 480;
		/// <summary>
		/// 디폴트 이미지 최적 스케일 발견 여부
		/// </summary>
		private bool FoundDefaultScale = false;
		/// <summary>
		/// 디폴트 이미지 최적 스케일 찾기 위한 변수
		/// </summary>
		private double DefaultScale = 0.9;
		/// <summary>
		/// 디폴트 이미지 최적 스케일 저장 변수
		/// </summary>
		private double FoundScale = 0.0;
		/// <summary>
		/// 템플매칭 스케일 정보 저장 변수(첫번째 인자값 이미지스케일 퍼센트 두번째 인자값 OpenCV 매칭 결과값)
		/// </summary>
		private List<Tuple<double, double>> SaveScale;

		/// <summary>
		/// 윈도우 창에서 비트맵 가져오는 함수
		/// </summary>
		/// <param name="processId"></param>
		/// <returns></returns>
		private async Task<Bitmap> PrintWindowAsync(int processId)
		{
			// 프로세스 핸들 가져오기
			IntPtr hwnd = GetWindowHandle(processId);

			// 최소화 되어 있을 경우 강제 활성화
			if (IsIconic(hwnd))
			{
				UpdateLog("창이 최소화 되어있습니다. 창을 활성화합니다.");
				ShowWindow(hwnd, SW_RESTORE);

				POINT cursorPoint;
				bool result = GetCursorPos(out cursorPoint);

				if (result)
				{
					SetWindowPos(hwnd, HWND_BOTTOM, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW);

					// 게임 커서 고정 방지
					IntPtr WFhandle = this.Handle;
					ShowWindow(WFhandle, SW_MINIMIZE);
					ShowWindow(WFhandle, SW_RESTORE);
					// 커서 위치 복원
					SetCursorPos(cursorPoint.X, cursorPoint.Y);
				}
			}

			Graphics gfxWin = Graphics.FromHwnd(hwnd);

			Rectangle rc = Rectangle.Round(gfxWin.VisibleClipBounds);

			Bitmap bitmap = new Bitmap(rc.Width, rc.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

			using Graphics gfxBmp = Graphics.FromImage(bitmap);
			IntPtr hdcBitmap = gfxBmp.GetHdc();

			bool succeeded = PrintWindow(hwnd, hdcBitmap, 3);

			gfxBmp.ReleaseHdc(hdcBitmap);

			if (!succeeded)
			{
				gfxBmp.FillRectangle(new SolidBrush(Color.Gray), new Rectangle(System.Drawing.Point.Empty, bitmap.Size));
			}

			IntPtr hRgn = CreateRectRgn(0, 0, 0, 0);
			GetWindowRgn(hwnd, hRgn);
			using Region region = Region.FromHrgn(hRgn);
			if (!region.IsEmpty(gfxBmp))
			{
				gfxBmp.ExcludeClip(region);
				gfxBmp.Clear(Color.Transparent);
			}

			if (UseDefaultImg == true && bitmap.Width > DefaultImgWidth && bitmap.Height > DefaultImgHeight)
			{
				return await ResizeBitmapAsync(bitmap);
			}
			else
			{
				return bitmap;
			}
		}

		/// <summary>
		/// OpenCv의 인식률을 높이기 위해 이미지 자르는 함수
		/// </summary>
		/// <param name="xStart">x좌표 시작값</param>
		/// <param name="yStart">y좌표 시작값</param>
		/// <param name="width">너비</param>
		/// <param name="height">높이</param>
		/// <param name="screenBitmap">원본 비트맵</param>
		/// <returns></returns>
		private async Task<Bitmap> SliceImageAsync(int xStart, int yStart, int width, int height, Bitmap screenBitmap)
		{
			using Mat mat = BitmapConverter.ToMat(screenBitmap);

			OpenCvSharp.Rect roi = new OpenCvSharp.Rect(xStart, yStart, width, height);
			using Mat slice = new Mat(mat, roi);

			Bitmap bitmap = BitmapConverter.ToBitmap(slice);
			screenBitmap.Dispose();
			return bitmap;


		}

		/// <summary>
		/// 디폴트 이미지 패턴 사용시 게임 해상도에 따른 이미지 리스케일링
		/// </summary>
		/// <param name="screenBitmap"></param>
		/// <returns></returns>
		private async Task<Bitmap> ResizeBitmapAsync(Bitmap screenBitmap)
		{
			if (FoundDefaultScale == false)
			{
				UpdateLog("최적의 해상도를 찾고 있습니다. 잠시 기다려 주십시오...");

				// 객체 생성
				SaveScale = new List<Tuple<double, double>>();

				while (true)
				{
					// 해상도 검증 반복문 딜레이
					await Task.Delay(500);

					using Mat mat = new Mat();

					// 이미지 리사이징
					using Bitmap resultBitmap = await SetImageResizeSizeAsync(screenBitmap, DefaultScale);

					// 검증 결과값 반환
					double result = await FindDefaultImageScaleAsync(resultBitmap);

					// 결과값 변수에 저장
					SaveScale.Add(new Tuple<double, double>(DefaultScale, result));

					// 에러 방지
					if (resultBitmap.Width < DefaultImgWidth && resultBitmap.Height < DefaultImgHeight)
					{
						// 배열값중 가장 높은 정확도를 찾음
						double maxVal = SaveScale.Max(t => t.Item2);

						foreach (var value in SaveScale)
						{
							if(value.Item2 == maxVal)
							{
								UpdateLog("최적의 해상도를 찾았습니다!");
								FoundScale = (double)value.Item1;
								FoundDefaultScale = true;
								// 객체 초기화
								SaveScale = null;
								break;
							}
						}

						return await SetImageResizeSizeAsync(screenBitmap, FoundScale);
					}
					else
					{
						// 적정 해상도 찾을때까지 10%씩 이미지 줄여가며 리스케일링
						DefaultScale = DefaultScale - 0.1;
					}

				}
			}
			else
			{
				return await SetImageResizeSizeAsync(screenBitmap, FoundScale);
			}

		}


		/// <summary>
		/// 이미지 사이즈 재정의
		/// </summary>
		/// <param name="screenMat"></param>
		/// <returns></returns>
		private async Task<Bitmap> SetImageResizeSizeAsync(Bitmap screenBitmap, double percent)
		{
			using Mat screenMat = BitmapConverter.ToMat(screenBitmap);
			using Mat mat = new Mat();

			int newWidth;
			int newHeight;

			newWidth = (int)(screenMat.Width * percent);
			newHeight = (int)(screenMat.Height * percent);

			Cv2.Resize(screenMat, mat, new OpenCvSharp.Size(newWidth, newHeight));
			screenMat.Dispose();
			return BitmapConverter.ToBitmap(mat);

		}

		/// <summary>
		/// 이미지 매칭 검증 함수
		/// </summary>
		/// <param name="screenBitmap">원본 비트맵</param>
		/// <param name="findBitmap">찾을 패턴 비트맵</param>
		/// <returns></returns>
		private async Task FindImageAsync(Bitmap screenBitmap, Bitmap findBitmap)
		{
			try
			{
				using Mat screenMat = BitmapConverter.ToMat(screenBitmap);
				using Mat findMat = BitmapConverter.ToMat(findBitmap);
				using Mat result = new Mat();

				// 인식률 위해 흑백 지정
				Cv2.CvtColor(screenMat, screenMat, ColorConversionCodes.BGR2GRAY);
				Cv2.CvtColor(findMat, findMat, ColorConversionCodes.BGR2GRAY);

				// 이미지 비교 수행
				Cv2.MatchTemplate(screenMat, findMat, result, TemplateMatchModes.CCoeffNormed);

				// 이미지의 최소 최대 위치
				OpenCvSharp.Point minloc, maxloc;

				// 이미지의 최소 최대 정확도
				double minval, maxval;
				Cv2.MinMaxLoc(result, out minval, out maxval, out minloc, out maxloc);

				UpdateLog($"이미지 패턴 정확도 : {maxval.ToString()}");

				// 이미지의 유사 정도 1에 가까울 수록 같음
				var similarity = this.CurrectRate;

				// 이미지 찾았을시 키이벤트 전송 실행
				if (maxval >= similarity)
				{
					// 낚시줄 회수 딜레이
					await Task.Delay(FishingCollectDelay);
					SendRightClick(ProcessID);

					// 낚시 횟수 업데이트
					Fished++;
					UpdateFishigTimes();

					// 매크로 실행횟수 처리
					if (MacroTimes != 0)
					{
						DoTimes++;
						if (MacroTimes <= DoTimes)
						{
							Active = false;
							ButtonHandler();
							UpdateMacroStatus();
							this.DoTimes = 0;
							return;
						}
					}

					// 낚시찌 던지기 딜레기
					await Task.Delay(FishingThrowDelay);
					SendRightClick(ProcessID);

					// 매크로 재시작 딜레이
					await Task.Delay(BotStartDelay);
				}

				// 매크로 중지되었을시 Task 결과값 반환
				if (Active == false)
				{
					TCS.SetResult(true);
				}

			}
			catch
			{
				throw;
			}
			finally
			{
				screenBitmap.Dispose();
				findBitmap.Dispose();
				// Mat bitmap 객체들 소멸
				GC.Collect(0);
			}
		}

		/// <summary>
		/// 디폴트 이미지 패턴과 해상도 일치하는 스케일 찾는 함수
		/// </summary>
		/// <param name="screenBitmap"></param>
		/// <returns></returns>
		private async Task<double> FindDefaultImageScaleAsync(Bitmap screenBitmap)
		{
			try
			{
				using Bitmap bitmap = new Bitmap(Properties.Resources.capture);
				using Mat screenMat = BitmapConverter.ToMat(screenBitmap);
				using Mat findMat = BitmapConverter.ToMat(bitmap);
				using Mat result = new Mat();

				// 인식률 위해 흑백 지정
				Cv2.CvtColor(screenMat, screenMat, ColorConversionCodes.BGR2GRAY);
				Cv2.CvtColor(findMat, findMat, ColorConversionCodes.BGR2GRAY);

				// 이미지 비교 수행
				Cv2.MatchTemplate(screenMat, findMat, result, TemplateMatchModes.CCoeffNormed);

				// 이미지의 최소 최대 위치
				OpenCvSharp.Point minloc, maxloc;

				// 이미지의 최소 최대 정확도
				double minval, maxval;
				Cv2.MinMaxLoc(result, out minval, out maxval, out minloc, out maxloc);

				return maxval;
			}
			catch
			{
				throw;
			}
		}
	}
}
