﻿using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace MCFishingBot
{
	public partial class MCMacro
	{
		const uint WM_KEYDOWN = 0x100;
		//const uint WM_SYSCOMMAND = 0x018;
		//const uint WM_KEYUP = 0x0101;
		//const uint SC_CLOSE = 0x053;
		//const uint WM_ACTIVE = 0x0006;
		const uint WM_RBUTTONDOWN = 0x0204;
		const uint WM_RBUTTONUP = 0x0205;
		//const int VK_F5 = 0x74;

		// 프로그램이 최소화 처리 되면 매크로 작동안됨 ShowWindow함수를 이용하면 강제로 활성화 할수 있지만 함수 실행이 완료되기전까지 Task.Delay를 줘야해서 반복문 작업이 느려짐
		// https://www.codeproject.com/Articles/20651/Capturing-Minimized-Window-A-Kid-s-Trick

		//[DllImport("user32.dll")]
		//static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

		/// <summary>
		/// 키 이벤트 제어
		/// </summary>
		/// <param name="hWnd"></param>
		/// <param name="Msg"></param>
		/// <param name="wParam"></param>
		/// <param name="lParam"></param>
		/// <returns></returns>
		[DllImport("user32.dll", SetLastError = true)]
		static extern IntPtr PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);


		/// <summary>
		/// 이미지 처리 제어
		/// </summary>
		/// <param name="hwnd"></param>
		/// <param name="hDC"></param>
		/// <param name="nFlags"></param>
		/// <returns></returns>
		[DllImport("user32.dll", SetLastError = true)]
		static extern bool PrintWindow(IntPtr hwnd, IntPtr hDC, uint nFlags);
		[DllImport("user32.dll", SetLastError = true)]
		static extern int GetWindowRgn(IntPtr hWnd, IntPtr hRgn);
		[DllImport("gdi32.dll", SetLastError = true)]
		static extern IntPtr CreateRectRgn(int left, int top, int right, int bottom);

		/// <summary>
		/// 윈도우 창 핸들 얻는 함수
		/// </summary>
		/// <param name="processId"></param>
		/// <returns></returns>
		private IntPtr GetWindowHandle(int processId)
		{
			Process process = Process.GetProcessById(processId);

			return process.MainWindowHandle;
		}
	}
}
