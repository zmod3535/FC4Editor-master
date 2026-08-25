using System;
using System.Runtime.InteropServices;

namespace Divelements.SandDock
{
	// Token: 0x02000037 RID: 55
	internal static class x443cc432acaadb1d
	{
		// Token: 0x06000353 RID: 851
		[DllImport("user32.dll")]
		public static extern bool GetCursorPos(out x443cc432acaadb1d.POINT lpPoint);

		// Token: 0x06000354 RID: 852
		[DllImport("user32.dll")]
		public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

		// Token: 0x06000355 RID: 853 RVA: 0x0003EDFC File Offset: 0x0003D1FC
		public static IntPtr x1e5827247c1bc092(IntPtr x96e7d32425e52ebf, int x62d7c038e79af605)
		{
			if (IntPtr.Size == 8)
			{
				return x443cc432acaadb1d.GetWindowLongPtr64(x96e7d32425e52ebf, x62d7c038e79af605);
			}
			return new IntPtr(x443cc432acaadb1d.GetWindowLong32(x96e7d32425e52ebf, x62d7c038e79af605));
		}

		// Token: 0x06000356 RID: 854
		[DllImport("user32.dll", EntryPoint = "GetWindowLong")]
		private static extern int GetWindowLong32(IntPtr hWnd, int nIndex);

		// Token: 0x06000357 RID: 855
		[DllImport("user32.dll", EntryPoint = "GetWindowLongPtr")]
		private static extern IntPtr GetWindowLongPtr64(IntPtr hWnd, int nIndex);

		// Token: 0x06000358 RID: 856
		[DllImport("user32.dll")]
		public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

		// Token: 0x04000133 RID: 307
		public const int x4c4ed64783077b76 = 4;

		// Token: 0x04000134 RID: 308
		public const int xb20c8d8cc3050d4b = -20;

		// Token: 0x02000038 RID: 56
		public struct POINT
		{
			// Token: 0x06000359 RID: 857 RVA: 0x0003EE1C File Offset: 0x0003D21C
			public POINT(int x, int y)
			{
				this.X = x;
				this.Y = y;
			}

			// Token: 0x04000135 RID: 309
			public int X;

			// Token: 0x04000136 RID: 310
			public int Y;
		}
	}
}
