using System;
using System.ComponentModel;

namespace TD.SandBar
{
	// Token: 0x0200002C RID: 44
	public class SandBarLanguage
	{
		// Token: 0x1400000B RID: 11
		// (add) Token: 0x06000266 RID: 614 RVA: 0x0000BE78 File Offset: 0x0000AE78
		// (remove) Token: 0x06000267 RID: 615 RVA: 0x0000BE90 File Offset: 0x0000AE90
		internal static event EventHandler xecd56f675e8e00c4;

		// Token: 0x06000268 RID: 616 RVA: 0x0000BEA8 File Offset: 0x0000AEA8
		private SandBarLanguage()
		{
		}

		// Token: 0x06000269 RID: 617 RVA: 0x0000BEB0 File Offset: 0x0000AEB0
		private static void x04aedd2ce14fbd43(EventArgs xfbf34718e704c6bc)
		{
			if (SandBarLanguage.xecd56f675e8e00c4 != null)
			{
				SandBarLanguage.xecd56f675e8e00c4(null, xfbf34718e704c6bc);
			}
		}

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x0600026A RID: 618 RVA: 0x0000BEC8 File Offset: 0x0000AEC8
		// (set) Token: 0x0600026B RID: 619 RVA: 0x0000BED0 File Offset: 0x0000AED0
		[Localizable(true)]
		public static string RestoreMenuText
		{
			get
			{
				return SandBarLanguage.x782ea1a4e76f2cbe;
			}
			set
			{
				SandBarLanguage.x782ea1a4e76f2cbe = value;
				SandBarLanguage.x04aedd2ce14fbd43(EventArgs.Empty);
			}
		}

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x0600026C RID: 620 RVA: 0x0000BEE4 File Offset: 0x0000AEE4
		// (set) Token: 0x0600026D RID: 621 RVA: 0x0000BEEC File Offset: 0x0000AEEC
		[Localizable(true)]
		public static string MoveMenuText
		{
			get
			{
				return SandBarLanguage.x4ec1678e180d3e87;
			}
			set
			{
				SandBarLanguage.x4ec1678e180d3e87 = value;
				SandBarLanguage.x04aedd2ce14fbd43(EventArgs.Empty);
			}
		}

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x0600026E RID: 622 RVA: 0x0000BF00 File Offset: 0x0000AF00
		// (set) Token: 0x0600026F RID: 623 RVA: 0x0000BF08 File Offset: 0x0000AF08
		[Localizable(true)]
		public static string SizeMenuText
		{
			get
			{
				return SandBarLanguage.x89f7c2fd2cbfc6cb;
			}
			set
			{
				SandBarLanguage.x89f7c2fd2cbfc6cb = value;
				SandBarLanguage.x04aedd2ce14fbd43(EventArgs.Empty);
			}
		}

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x06000270 RID: 624 RVA: 0x0000BF1C File Offset: 0x0000AF1C
		// (set) Token: 0x06000271 RID: 625 RVA: 0x0000BF24 File Offset: 0x0000AF24
		[Localizable(true)]
		public static string MinimizeMenuText
		{
			get
			{
				return SandBarLanguage.xe639e2042ebaf162;
			}
			set
			{
				SandBarLanguage.xe639e2042ebaf162 = value;
				SandBarLanguage.x04aedd2ce14fbd43(EventArgs.Empty);
			}
		}

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x06000272 RID: 626 RVA: 0x0000BF38 File Offset: 0x0000AF38
		// (set) Token: 0x06000273 RID: 627 RVA: 0x0000BF40 File Offset: 0x0000AF40
		[Localizable(true)]
		public static string MaximizeMenuText
		{
			get
			{
				return SandBarLanguage.xe3338bb378eec941;
			}
			set
			{
				SandBarLanguage.xe3338bb378eec941 = value;
				SandBarLanguage.x04aedd2ce14fbd43(EventArgs.Empty);
			}
		}

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x06000274 RID: 628 RVA: 0x0000BF54 File Offset: 0x0000AF54
		// (set) Token: 0x06000275 RID: 629 RVA: 0x0000BF5C File Offset: 0x0000AF5C
		[Localizable(true)]
		public static string CloseMenuText
		{
			get
			{
				return SandBarLanguage.x0da7052c233b10a8;
			}
			set
			{
				SandBarLanguage.x0da7052c233b10a8 = value;
				SandBarLanguage.x04aedd2ce14fbd43(EventArgs.Empty);
			}
		}

		// Token: 0x170000BA RID: 186
		// (get) Token: 0x06000276 RID: 630 RVA: 0x0000BF70 File Offset: 0x0000AF70
		// (set) Token: 0x06000277 RID: 631 RVA: 0x0000BF78 File Offset: 0x0000AF78
		[Localizable(true)]
		public static string MinimizeWindowText
		{
			get
			{
				return SandBarLanguage.x1c9cefc5212bc045;
			}
			set
			{
				SandBarLanguage.x1c9cefc5212bc045 = value;
				SandBarLanguage.x04aedd2ce14fbd43(EventArgs.Empty);
			}
		}

		// Token: 0x170000BB RID: 187
		// (get) Token: 0x06000278 RID: 632 RVA: 0x0000BF8C File Offset: 0x0000AF8C
		// (set) Token: 0x06000279 RID: 633 RVA: 0x0000BF94 File Offset: 0x0000AF94
		[Localizable(true)]
		public static string RestoreWindowText
		{
			get
			{
				return SandBarLanguage.x4e052824b147b994;
			}
			set
			{
				SandBarLanguage.x4e052824b147b994 = value;
				SandBarLanguage.x04aedd2ce14fbd43(EventArgs.Empty);
			}
		}

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x0600027A RID: 634 RVA: 0x0000BFA8 File Offset: 0x0000AFA8
		// (set) Token: 0x0600027B RID: 635 RVA: 0x0000BFB0 File Offset: 0x0000AFB0
		[Localizable(true)]
		public static string CloseWindowText
		{
			get
			{
				return SandBarLanguage.xcc181e89e9c1670d;
			}
			set
			{
				SandBarLanguage.xcc181e89e9c1670d = value;
				SandBarLanguage.x04aedd2ce14fbd43(EventArgs.Empty);
			}
		}

		// Token: 0x170000BD RID: 189
		// (get) Token: 0x0600027C RID: 636 RVA: 0x0000BFC4 File Offset: 0x0000AFC4
		// (set) Token: 0x0600027D RID: 637 RVA: 0x0000BFCC File Offset: 0x0000AFCC
		[Localizable(true)]
		public static string AddRemoveButtonsText
		{
			get
			{
				return SandBarLanguage.x675d14930e6f0ae4;
			}
			set
			{
				SandBarLanguage.x675d14930e6f0ae4 = value;
				SandBarLanguage.x04aedd2ce14fbd43(EventArgs.Empty);
			}
		}

		// Token: 0x170000BE RID: 190
		// (get) Token: 0x0600027E RID: 638 RVA: 0x0000BFE0 File Offset: 0x0000AFE0
		// (set) Token: 0x0600027F RID: 639 RVA: 0x0000BFE8 File Offset: 0x0000AFE8
		[Localizable(true)]
		public static string ToolbarOptionsText
		{
			get
			{
				return SandBarLanguage.xaa6e6f34018ab77a;
			}
			set
			{
				SandBarLanguage.xaa6e6f34018ab77a = value;
				SandBarLanguage.x04aedd2ce14fbd43(EventArgs.Empty);
			}
		}

		// Token: 0x040000E0 RID: 224
		private static string x675d14930e6f0ae4 = "&Add or Remove Buttons";

		// Token: 0x040000E1 RID: 225
		private static string xaa6e6f34018ab77a = "Toolbar Options";

		// Token: 0x040000E2 RID: 226
		private static string x1c9cefc5212bc045 = "Minimize Window";

		// Token: 0x040000E3 RID: 227
		private static string x4e052824b147b994 = "Restore Window";

		// Token: 0x040000E4 RID: 228
		private static string xcc181e89e9c1670d = "Close Window";

		// Token: 0x040000E5 RID: 229
		private static string x782ea1a4e76f2cbe = "&Restore";

		// Token: 0x040000E6 RID: 230
		private static string x4ec1678e180d3e87 = "&Move";

		// Token: 0x040000E7 RID: 231
		private static string x89f7c2fd2cbfc6cb = "&Size";

		// Token: 0x040000E8 RID: 232
		private static string xe639e2042ebaf162 = "Mi&nimize";

		// Token: 0x040000E9 RID: 233
		private static string xe3338bb378eec941 = "Ma&ximize";

		// Token: 0x040000EA RID: 234
		private static string x0da7052c233b10a8 = "&Close";
	}
}
