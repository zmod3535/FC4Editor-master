using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace TD.SandDock
{
	// Token: 0x0200002A RID: 42
	internal class x60f3af502af1d663
	{
		// Token: 0x0600039F RID: 927
		[DllImport("uxtheme.dll", CharSet = CharSet.Auto)]
		private static extern int GetCurrentThemeName(StringBuilder pszThemeFileName, int dwMaxNameChars, StringBuilder pszColorBuff, int dwMaxColorChars, StringBuilder pszSizeBuff, int cchMaxSizeChars);

		// Token: 0x060003A0 RID: 928 RVA: 0x0001CA74 File Offset: 0x0001BA74
		private x60f3af502af1d663()
		{
		}

		// Token: 0x170000EA RID: 234
		// (get) Token: 0x060003A1 RID: 929 RVA: 0x0001CA7C File Offset: 0x0001BA7C
		public static bool x2e20a402b77c44dc
		{
			get
			{
				string text = x60f3af502af1d663.x43a4294aa97fcbd9;
				text = Path.GetFileName(text).ToLower();
				return text == "luna.msstyles";
			}
		}

		// Token: 0x170000EB RID: 235
		// (get) Token: 0x060003A2 RID: 930 RVA: 0x0001CAA8 File Offset: 0x0001BAA8
		public static string x43a4294aa97fcbd9
		{
			get
			{
				StringBuilder stringBuilder = new StringBuilder(512);
				x60f3af502af1d663.GetCurrentThemeName(stringBuilder, stringBuilder.Capacity, null, 0, null, 0);
				return stringBuilder.ToString();
			}
		}

		// Token: 0x170000EC RID: 236
		// (get) Token: 0x060003A3 RID: 931 RVA: 0x0001CAD8 File Offset: 0x0001BAD8
		public static string x4f15c2ab6fab0941
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
