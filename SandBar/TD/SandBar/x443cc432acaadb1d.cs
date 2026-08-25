using System;
using System.Runtime.InteropServices;

namespace TD.SandBar
{
	// Token: 0x02000040 RID: 64
	internal class x443cc432acaadb1d
	{
		// Token: 0x06000386 RID: 902
		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool PeekMessage(out x443cc432acaadb1d.MSG lpMsg, IntPtr hWnd, uint wMsgFilterMin, uint wMsgFilterMax, uint wRemoveMsg);

		// Token: 0x06000387 RID: 903
		[DllImport("user32.dll")]
		public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

		// Token: 0x06000388 RID: 904
		[DllImport("user32.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
		public static extern int GetMessageA(out x443cc432acaadb1d.MSG msg, IntPtr hWnd, int uMsgFilterMin, int uMsgFilterMax);

		// Token: 0x06000389 RID: 905
		[DllImport("user32.dll")]
		public static extern bool TranslateMessage(out x443cc432acaadb1d.MSG msg);

		// Token: 0x0600038A RID: 906
		[DllImport("user32.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
		public static extern IntPtr DispatchMessageA(ref x443cc432acaadb1d.MSG msg);

		// Token: 0x0600038B RID: 907
		[DllImport("user32.dll")]
		public static extern IntPtr SetTimer(IntPtr hWnd, int nIDEvent, int uElapse, x443cc432acaadb1d.TimerProc lpTimerFunc);

		// Token: 0x0600038C RID: 908
		[DllImport("user32.dll")]
		public static extern bool KillTimer(IntPtr hwnd, int idEvent);

		// Token: 0x0600038D RID: 909
		[DllImport("user32.dll")]
		public static extern int ClientToScreen(IntPtr hWnd, out x443cc432acaadb1d.POINTAPI pt);

		// Token: 0x0600038E RID: 910
		[DllImport("user32.dll")]
		public static extern bool SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int y, int cx, int cy, int flags);

		// Token: 0x0600038F RID: 911
		[DllImport("user32.dll")]
		public static extern bool ShowCaret(IntPtr hwnd);

		// Token: 0x06000390 RID: 912
		[DllImport("user32.dll")]
		public static extern bool HideCaret(IntPtr hwnd);

		// Token: 0x06000391 RID: 913
		[DllImport("user32.dll")]
		public static extern IntPtr SetParent(IntPtr hWnd, IntPtr hWndParent);

		// Token: 0x06000392 RID: 914
		[DllImport("user32.dll")]
		public static extern bool SystemParametersInfo(int nAction, int nParam, ref int i, int nUpdate);

		// Token: 0x06000393 RID: 915
		[DllImport("user32.dll")]
		public static extern bool ReleaseCapture();

		// Token: 0x06000394 RID: 916
		[DllImport("user32.dll")]
		public static extern IntPtr GetForegroundWindow();

		// Token: 0x06000395 RID: 917
		[DllImport("user32.dll")]
		public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

		// Token: 0x06000396 RID: 918
		[DllImport("user32")]
		public static extern bool AnimateWindow(IntPtr hwnd, int time, x443cc432acaadb1d.AnimateWindowFlags flags);

		// Token: 0x06000397 RID: 919
		[DllImport("user32", CharSet = CharSet.Unicode, SetLastError = true)]
		public static extern int SetForegroundWindow(IntPtr hWnd);

		// Token: 0x06000398 RID: 920
		[DllImport("gdi32.dll")]
		public static extern bool BitBlt(IntPtr hdc, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, uint dwRop);

		// Token: 0x06000399 RID: 921
		[DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
		public static extern bool UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref x443cc432acaadb1d.POINTAPI pptDst, ref x443cc432acaadb1d.Size psize, IntPtr hdcSrc, ref x443cc432acaadb1d.POINTAPI pprSrc, int crKey, ref x443cc432acaadb1d.BLENDFUNCTION pblend, int dwFlags);

		// Token: 0x0600039A RID: 922
		[DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
		public static extern IntPtr GetDC(IntPtr hWnd);

		// Token: 0x0600039B RID: 923
		[DllImport("user32.dll", ExactSpelling = true)]
		public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

		// Token: 0x0600039C RID: 924
		[DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
		public static extern IntPtr CreateCompatibleDC(IntPtr hDC);

		// Token: 0x0600039D RID: 925
		[DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
		public static extern bool DeleteDC(IntPtr hdc);

		// Token: 0x0600039E RID: 926
		[DllImport("gdi32.dll", ExactSpelling = true)]
		public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);

		// Token: 0x0600039F RID: 927
		[DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
		public static extern bool DeleteObject(IntPtr hObject);

		// Token: 0x060003A0 RID: 928 RVA: 0x00011DD4 File Offset: 0x00010DD4
		public static int xefc704ff04352756(int x57e9faf3ffdc07cc)
		{
			return x57e9faf3ffdc07cc >> 16 & 65535;
		}

		// Token: 0x060003A1 RID: 929 RVA: 0x00011DE0 File Offset: 0x00010DE0
		public static int x0fcc9d0a21bd41f3(int x57e9faf3ffdc07cc)
		{
			return x57e9faf3ffdc07cc & 65535;
		}

		// Token: 0x0400014D RID: 333
		public const int xe7a8078ad50bd781 = 4114;

		// Token: 0x0400014E RID: 334
		public const int x34608ae4faf2d468 = 106;

		// Token: 0x0400014F RID: 335
		public const int x3358e4000de9a021 = 4098;

		// Token: 0x04000150 RID: 336
		public const int x77bf04ec211c4a37 = 16;

		// Token: 0x04000151 RID: 337
		public const int x339acab5bf3e83ae = 64;

		// Token: 0x04000152 RID: 338
		public const int xb8a822e576f3bf60 = 1;

		// Token: 0x04000153 RID: 339
		public const int xb644deafcaa222c4 = 2;

		// Token: 0x04000154 RID: 340
		public const int xe004119ec365f03a = 4;

		// Token: 0x04000155 RID: 341
		public const int x836e53e090609b16 = 4132;

		// Token: 0x04000156 RID: 342
		public const int x5369785684a974f4 = 1;

		// Token: 0x04000157 RID: 343
		public const int x93b283a033d1b54a = 2;

		// Token: 0x04000158 RID: 344
		public const int x11a0985503a2d2df = 4;

		// Token: 0x04000159 RID: 345
		public const byte xdd6043f42253ee15 = 0;

		// Token: 0x0400015A RID: 346
		public const byte xa34cc3e091661d7f = 1;

		// Token: 0x0400015B RID: 347
		public const int xcd390c5181df4669 = 15;

		// Token: 0x0400015C RID: 348
		public const int xdb37118a0c2118b6 = 274;

		// Token: 0x0400015D RID: 349
		public const int x5898cfc7c31e0ba4 = 161;

		// Token: 0x0400015E RID: 350
		public const int x07ac164555740e80 = 164;

		// Token: 0x0400015F RID: 351
		public const int x2c44651f5d97dfaa = 160;

		// Token: 0x04000160 RID: 352
		public const int x4f7e9be2fe2b973b = 512;

		// Token: 0x04000161 RID: 353
		public const int xfe06a623c25f2e64 = 521;

		// Token: 0x04000162 RID: 354
		public const int x72b6b1fc2d8fc5ed = 256;

		// Token: 0x04000163 RID: 355
		public const int x8ba81c0d3401280f = 264;

		// Token: 0x04000164 RID: 356
		public const int x26b815d506c8caa1 = 513;

		// Token: 0x04000165 RID: 357
		public const int xb18a64056e74ece9 = 516;

		// Token: 0x04000166 RID: 358
		public const int x5f1a29f0cf0d33c4 = 515;

		// Token: 0x04000167 RID: 359
		public const int x97810ed8402ea8f3 = 518;

		// Token: 0x04000168 RID: 360
		public const int x7632d73ff257d6ce = 512;

		// Token: 0x04000169 RID: 361
		public const int x23059b7a1a93ba73 = 275;

		// Token: 0x0400016A RID: 362
		public const int x71e360a3036a9ec0 = 514;

		// Token: 0x0400016B RID: 363
		public const int x1e9a24819d8351e3 = 517;

		// Token: 0x0400016C RID: 364
		public const int x3ab50d2ad9712e32 = 256;

		// Token: 0x0400016D RID: 365
		public const int x9e72e1fc89a4d09f = 260;

		// Token: 0x0400016E RID: 366
		public const int x59fb0ee4f1e6c31f = 258;

		// Token: 0x0400016F RID: 367
		public const int xeaa67d27b4965bbd = 33;

		// Token: 0x04000170 RID: 368
		public const int xa89597ae33358a88 = 78;

		// Token: 0x04000171 RID: 369
		public const int x1220ff5f885bef8d = 273;

		// Token: 0x04000172 RID: 370
		public const int x510aaa9af0268c45 = 533;

		// Token: 0x04000173 RID: 371
		public const int x281a211ed2ebb998 = 560;

		// Token: 0x04000174 RID: 372
		public const int x909f72538f52db3e = 2;

		// Token: 0x04000175 RID: 373
		public const int xe31f62304b866cc7 = 123;

		// Token: 0x04000176 RID: 374
		public const int x09556c5fd594c9e8 = 32;

		// Token: 0x04000177 RID: 375
		public const int xfe3dd2ebb91c29b3 = 31;

		// Token: 0x04000178 RID: 376
		public const int x4240fbbb4c651780 = 3;

		// Token: 0x04000179 RID: 377
		public const int x4c4ed64783077b76 = 4;

		// Token: 0x0400017A RID: 378
		public const int xe58ac556cc22a8ef = 61696;

		// Token: 0x0400017B RID: 379
		public const int x2b7f5d3ca7ec1edf = -2147483648;

		// Token: 0x0400017C RID: 380
		public const int x697ec4492146b403 = 1073741824;

		// Token: 0x0400017D RID: 381
		public const int x92803739688048a1 = 8;

		// Token: 0x0400017E RID: 382
		public const int xb615ddf284afbdf6 = 524288;

		// Token: 0x0400017F RID: 383
		public const int xf5ee4609a7a1f302 = 38;

		// Token: 0x04000180 RID: 384
		public const int x54f2d36286b74725 = 40;

		// Token: 0x04000181 RID: 385
		public const int x438d32ac45cf70fb = 37;

		// Token: 0x04000182 RID: 386
		public const int x04ba48f5a421349d = 39;

		// Token: 0x04000183 RID: 387
		public const int x4c7854d9b53d4e94 = 27;

		// Token: 0x04000184 RID: 388
		public const int xadefa335d9a11adf = 18;

		// Token: 0x02000041 RID: 65
		public struct MSG
		{
			// Token: 0x04000185 RID: 389
			public IntPtr hwnd;

			// Token: 0x04000186 RID: 390
			public int message;

			// Token: 0x04000187 RID: 391
			public IntPtr wParam;

			// Token: 0x04000188 RID: 392
			public IntPtr lParam;

			// Token: 0x04000189 RID: 393
			public int time;

			// Token: 0x0400018A RID: 394
			public int pt_x;

			// Token: 0x0400018B RID: 395
			public int pt_y;
		}

		// Token: 0x02000042 RID: 66
		// (Invoke) Token: 0x060003A4 RID: 932
		public delegate void TimerProc(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

		// Token: 0x02000043 RID: 67
		public struct POINTAPI
		{
			// Token: 0x060003A7 RID: 935 RVA: 0x00011DF4 File Offset: 0x00010DF4
			public POINTAPI(int x, int y)
			{
				this.x = x;
				this.y = y;
			}

			// Token: 0x0400018C RID: 396
			public int x;

			// Token: 0x0400018D RID: 397
			public int y;
		}

		// Token: 0x02000044 RID: 68
		public enum AnimateWindowFlags : uint
		{
			// Token: 0x0400018F RID: 399
			AW_HOR_POSITIVE = 1U,
			// Token: 0x04000190 RID: 400
			AW_HOR_NEGATIVE,
			// Token: 0x04000191 RID: 401
			AW_VER_POSITIVE = 4U,
			// Token: 0x04000192 RID: 402
			AW_VER_NEGATIVE = 8U,
			// Token: 0x04000193 RID: 403
			AW_CENTER = 16U,
			// Token: 0x04000194 RID: 404
			AW_HIDE = 65536U,
			// Token: 0x04000195 RID: 405
			AW_ACTIVATE = 131072U,
			// Token: 0x04000196 RID: 406
			AW_SLIDE = 262144U,
			// Token: 0x04000197 RID: 407
			AW_BLEND = 524288U
		}

		// Token: 0x02000045 RID: 69
		public struct Size
		{
			// Token: 0x060003A8 RID: 936 RVA: 0x00011E04 File Offset: 0x00010E04
			public Size(int cx, int cy)
			{
				this.cx = cx;
				this.cy = cy;
			}

			// Token: 0x04000198 RID: 408
			public int cx;

			// Token: 0x04000199 RID: 409
			public int cy;
		}

		// Token: 0x02000046 RID: 70
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		public struct BLENDFUNCTION
		{
			// Token: 0x0400019A RID: 410
			public byte BlendOp;

			// Token: 0x0400019B RID: 411
			public byte BlendFlags;

			// Token: 0x0400019C RID: 412
			public byte SourceConstantAlpha;

			// Token: 0x0400019D RID: 413
			public byte AlphaFormat;
		}
	}
}
