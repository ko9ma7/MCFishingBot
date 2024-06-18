using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Drawing;
using System.Threading.Tasks;

namespace MCFishingBot
{
	public partial class MCMacro
	{
		/// <summary>
		/// 윈도우 창에서 비트맵 가져오는 함수
		/// </summary>
		/// <param name="processId"></param>
		/// <returns></returns>
		private async Task<Bitmap> PrintWindowAsync(int processId)
		{
			// 프로세스 핸들 가져오기
			IntPtr hwnd = GetWindowHandle(processId);

			Graphics gfxWin = Graphics.FromHwnd(hwnd);

			Rectangle rc = Rectangle.Round(gfxWin.VisibleClipBounds);

			Bitmap bitmap = new Bitmap(rc.Width, rc.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

			Graphics gfxBmp = Graphics.FromImage(bitmap);
			IntPtr hdcBitmap = gfxBmp.GetHdc();

			bool succeeded = PrintWindow(hwnd, hdcBitmap, 3);

			gfxBmp.ReleaseHdc(hdcBitmap);

			if (!succeeded)
			{
				gfxBmp.FillRectangle(new SolidBrush(Color.Gray), new Rectangle(System.Drawing.Point.Empty, bitmap.Size));
			}

			IntPtr hRgn = CreateRectRgn(0, 0, 0, 0);
			GetWindowRgn(hwnd, hRgn);
			Region region = Region.FromHrgn(hRgn);
			if (!region.IsEmpty(gfxBmp))
			{
				gfxBmp.ExcludeClip(region);
				gfxBmp.Clear(Color.Transparent);
			}

			// 객체정리
			gfxBmp.Dispose();
			region.Dispose();

			return bitmap;
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
			using (Mat mat = BitmapConverter.ToMat(screenBitmap))
			{
				OpenCvSharp.Rect roi = new OpenCvSharp.Rect(xStart, yStart, width, height);
				using (Mat slice = new Mat(mat, roi))
				{
					Bitmap bitmap = BitmapConverter.ToBitmap(slice);
					return bitmap;
				}
			}
		}

		/// <summary>
		/// 이미지 매칭 검증 함수
		/// </summary>
		/// <param name="screenBitmap">원본 비트맵</param>
		/// <param name="findBitmap">찾을 패턴 비트맵</param>
		/// <returns></returns>
		private async Task FindImageAsync(Bitmap screenBitmap, Bitmap findBitmap)
		{
			using (Mat ScreenMat = BitmapConverter.ToMat(screenBitmap))
			using (Mat FindMat = BitmapConverter.ToMat(findBitmap))
			using (Mat result = new Mat())
			{
				// 인식률 위해 흑백 지정
				Cv2.CvtColor(ScreenMat, ScreenMat, ColorConversionCodes.BGR2GRAY);
				Cv2.CvtColor(FindMat, FindMat, ColorConversionCodes.BGR2GRAY);

				// 이미지 비교 수행
				Cv2.MatchTemplate(ScreenMat, FindMat, result, TemplateMatchModes.CCoeffNormed);

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
					await ControllTimerStopAsync(FishingCollectDelay);
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
							MacroTimer.Stop();
							UpdateMacroStatus();
							this.DoTimes = 0;
							return;
						}
					}

					// 낚시찌 던지기 딜레기
					await Task.Delay(FishingThrowDelay);
					SendRightClick(ProcessID);

					// 매크로 재시작 딜레이
					await ControllTimerStartAsync(BotStartDelay);
				}
			}
		}
	}
}
