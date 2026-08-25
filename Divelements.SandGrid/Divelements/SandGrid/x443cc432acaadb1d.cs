using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Divelements.SandGrid
{
	// Token: 0x02000043 RID: 67
	internal class x443cc432acaadb1d
	{
		// Token: 0x060004F3 RID: 1267 RVA: 0x0001AB90 File Offset: 0x00019B90
		private x443cc432acaadb1d()
		{
		}

		// Token: 0x060004F4 RID: 1268
		[DllImport("user32.dll")]
		public static extern IntPtr GetFocus();

		// Token: 0x060004F5 RID: 1269
		[DllImport("user32.dll")]
		public static extern int SetScrollInfo(IntPtr hwnd, int fnBar, [In] ref x443cc432acaadb1d.SCROLLINFO lpsi, bool fRedraw);

		// Token: 0x060004F6 RID: 1270
		[DllImport("user32.dll")]
		public static extern bool GetScrollInfo(IntPtr hwnd, int fnBar, ref x443cc432acaadb1d.SCROLLINFO lpsi);

		// Token: 0x060004F7 RID: 1271
		[DllImport("user32.dll")]
		public static extern int MessageBeep(uint n);

		// Token: 0x060004F8 RID: 1272
		[DllImport("User32.dll", EntryPoint = "SendMessageW")]
		public static extern int SendMessage(IntPtr hwnd, int wMsg, int wparam, int lparam);

		// Token: 0x060004F9 RID: 1273
		[DllImport("User32.dll", EntryPoint = "SendMessageW")]
		public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wparam, IntPtr lparam);

		// Token: 0x060004FA RID: 1274
		[DllImport("user32.dll")]
		public static extern IntPtr GetWindowDC(IntPtr hWnd);

		// Token: 0x060004FB RID: 1275
		[DllImport("user32.dll")]
		public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

		// Token: 0x060004FC RID: 1276
		[DllImport("user32.dll")]
		public static extern bool GetWindowRect(IntPtr hWnd, out x443cc432acaadb1d.RECT lpRect);

		// Token: 0x060004FD RID: 1277
		[DllImport("gdi32.dll")]
		public static extern int ExcludeClipRect(IntPtr hdc, int nLeftRect, int nTopRect, int nRightRect, int nBottomRect);

		// Token: 0x060004FE RID: 1278 RVA: 0x0001AB98 File Offset: 0x00019B98
		public static int xdc9f9b153aa69c51(int xd12d1dba8a023d95, int x628ea9b89457a2a9)
		{
			return x628ea9b89457a2a9 << 16 | (xd12d1dba8a023d95 & 65535);
		}

		// Token: 0x060004FF RID: 1279 RVA: 0x0001ABA8 File Offset: 0x00019BA8
		public static int x0fcc9d0a21bd41f3(int x57e9faf3ffdc07cc)
		{
			return x57e9faf3ffdc07cc & 65535;
		}

		// Token: 0x06000500 RID: 1280 RVA: 0x0001ABB4 File Offset: 0x00019BB4
		public static int xefc704ff04352756(int x57e9faf3ffdc07cc)
		{
			return x57e9faf3ffdc07cc >> 16 & 65535;
		}

		// Token: 0x06000501 RID: 1281
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern int GetSysColor(int nIndex);

		// Token: 0x17000142 RID: 322
		// (get) Token: 0x06000502 RID: 1282 RVA: 0x0001ABC0 File Offset: 0x00019BC0
		public static Color xdd5501c2b4985e92
		{
			get
			{
				int sysColor = x443cc432acaadb1d.GetSysColor(27);
				return ColorTranslator.FromWin32(sysColor);
			}
		}

		// Token: 0x040001A7 RID: 423
		public const int x0f5e12a3f39e3a5d = 132;

		// Token: 0x040001A8 RID: 424
		public const int x9c8a0456810e683a = 522;

		// Token: 0x02000044 RID: 68
		[Serializable]
		public struct SCROLLINFO
		{
			// Token: 0x040001A9 RID: 425
			public int cbSize;

			// Token: 0x040001AA RID: 426
			public int fMask;

			// Token: 0x040001AB RID: 427
			public int nMin;

			// Token: 0x040001AC RID: 428
			public int nMax;

			// Token: 0x040001AD RID: 429
			public int nPage;

			// Token: 0x040001AE RID: 430
			public int nPos;

			// Token: 0x040001AF RID: 431
			public int nTrackPos;
		}

		// Token: 0x02000045 RID: 69
		[Serializable]
		public struct RECT
		{
			// Token: 0x06000503 RID: 1283 RVA: 0x0001ABDC File Offset: 0x00019BDC
			public RECT(int left_, int top_, int right_, int bottom_)
			{
				this.Left = left_;
				this.Top = top_;
				this.Right = right_;
				this.Bottom = bottom_;
			}

			// Token: 0x17000143 RID: 323
			// (get) Token: 0x06000504 RID: 1284 RVA: 0x0001ABFC File Offset: 0x00019BFC
			public int Width
			{
				get
				{
					return this.Right - this.Left;
				}
			}

			// Token: 0x17000144 RID: 324
			// (get) Token: 0x06000505 RID: 1285 RVA: 0x0001AC0C File Offset: 0x00019C0C
			public int Height
			{
				get
				{
					return this.Bottom - this.Top;
				}
			}

			// Token: 0x040001B0 RID: 432
			public int Left;

			// Token: 0x040001B1 RID: 433
			public int Top;

			// Token: 0x040001B2 RID: 434
			public int Right;

			// Token: 0x040001B3 RID: 435
			public int Bottom;
		}

		// Token: 0x020000B6 RID: 182
		public enum ScrollBarCommands
		{
			// Token: 0x040002F5 RID: 757
			SB_LINEUP,
			// Token: 0x040002F6 RID: 758
			SB_LINEDOWN,
			// Token: 0x040002F7 RID: 759
			SB_PAGEUP,
			// Token: 0x040002F8 RID: 760
			SB_PAGEDOWN,
			// Token: 0x040002F9 RID: 761
			SB_THUMBPOSITION,
			// Token: 0x040002FA RID: 762
			SB_THUMBTRACK,
			// Token: 0x040002FB RID: 763
			SB_TOP,
			// Token: 0x040002FC RID: 764
			SB_BOTTOM,
			// Token: 0x040002FD RID: 765
			SB_ENDSCROLL
		}
	}
}
