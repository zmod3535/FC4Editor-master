using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace TD.SandDock
{
	// Token: 0x02000039 RID: 57
	internal class x443cc432acaadb1d
	{
		// Token: 0x06000460 RID: 1120
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern int GetSysColor(int nIndex);

		// Token: 0x06000461 RID: 1121
		[DllImport("user32.dll")]
		public static extern bool ReleaseCapture();

		// Token: 0x06000462 RID: 1122
		[DllImport("user32.dll")]
		public static extern int GetSystemMetrics(int smIndex);

		// Token: 0x1700011E RID: 286
		// (get) Token: 0x06000463 RID: 1123 RVA: 0x00022608 File Offset: 0x00021608
		public static Color x75cc9d2f9fd85f82
		{
			get
			{
				int sysColor = x443cc432acaadb1d.GetSysColor(27);
				return ColorTranslator.FromWin32(sysColor);
			}
		}

		// Token: 0x1700011F RID: 287
		// (get) Token: 0x06000464 RID: 1124 RVA: 0x00022624 File Offset: 0x00021624
		public static bool x641f26d1017e3571
		{
			get
			{
				return x443cc432acaadb1d.GetSystemMetrics(4096) != 0;
			}
		}

		// Token: 0x0400017D RID: 381
		public const int xe8adba66ee59f491 = -1;

		// Token: 0x0400017E RID: 382
		public const int x152a3652057f019c = 4096;

		// Token: 0x0400017F RID: 383
		public const int xeaa67d27b4965bbd = 33;
	}
}
