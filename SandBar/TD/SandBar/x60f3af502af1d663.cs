using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace TD.SandBar
{
	// Token: 0x02000062 RID: 98
	internal class x60f3af502af1d663
	{
		// Token: 0x060004FA RID: 1274
		[DllImport("uxtheme.dll", CharSet = CharSet.Auto)]
		private static extern int GetCurrentThemeName(StringBuilder pszThemeFileName, int dwMaxNameChars, StringBuilder pszColorBuff, int dwMaxColorChars, StringBuilder pszSizeBuff, int cchMaxSizeChars);

		// Token: 0x17000139 RID: 313
		// (get) Token: 0x060004FC RID: 1276 RVA: 0x0001B50C File Offset: 0x0001A50C
		public bool x2e20a402b77c44dc
		{
			get
			{
				string x43a4294aa97fcbd = this.x43a4294aa97fcbd9;
				return string.Compare(Path.GetFileName(x43a4294aa97fcbd), "luna.msstyles", true) == 0;
			}
		}

		// Token: 0x1700013A RID: 314
		// (get) Token: 0x060004FD RID: 1277 RVA: 0x0001B534 File Offset: 0x0001A534
		public string x43a4294aa97fcbd9
		{
			get
			{
				StringBuilder stringBuilder = new StringBuilder(512);
				x60f3af502af1d663.GetCurrentThemeName(stringBuilder, stringBuilder.Capacity, null, 0, null, 0);
				return stringBuilder.ToString();
			}
		}

		// Token: 0x1700013B RID: 315
		// (get) Token: 0x060004FE RID: 1278 RVA: 0x0001B564 File Offset: 0x0001A564
		public string x4f15c2ab6fab0941
		{
			get
			{
				StringBuilder stringBuilder = new StringBuilder(512);
				x60f3af502af1d663.GetCurrentThemeName(null, 0, stringBuilder, stringBuilder.Capacity, null, 0);
				return stringBuilder.ToString();
			}
		}
	}
}
