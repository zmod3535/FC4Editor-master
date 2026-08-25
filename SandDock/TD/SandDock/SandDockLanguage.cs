using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;

namespace TD.SandDock
{
	// Token: 0x0200000F RID: 15
	public sealed class SandDockLanguage
	{
		// Token: 0x060001A0 RID: 416 RVA: 0x0000ECCC File Offset: 0x0000DCCC
		public static void ShowCachedAssemblyError(Assembly componentAssembly, Assembly designerAssembly)
		{
			string text = SandDockLanguage.x39981e4ce91f2127 + Environment.NewLine + Environment.NewLine;
			for (;;)
			{
				string text2 = text;
				if (false)
				{
					goto IL_4E;
				}
				text = string.Concat(new string[]
				{
					text2,
					"Component Assembly:",
					Environment.NewLine,
					componentAssembly.Location,
					Environment.NewLine,
					Environment.NewLine
				});
				string text3 = text;
				string[] array = new string[6];
				do
				{
					array[0] = text3;
					array[1] = "Designer Assembly:";
				}
				while (false);
				array[2] = Environment.NewLine;
				if (8 != 0)
				{
					goto IL_83;
				}
				IL_CE:
				if (false)
				{
					continue;
				}
				break;
				IL_4E:
				string[] array2;
				if (!false)
				{
					array2[3] = Environment.NewLine;
					array2[4] = SandDockLanguage.x72913f986fffe0b3;
					text = string.Concat(array2);
					MessageBox.Show(text, "Visual Studio Error Detected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					if (false)
					{
						goto IL_5F;
					}
					if (false)
					{
						goto IL_83;
					}
					goto IL_CE;
				}
				IL_78:
				string text4;
				array2[0] = text4;
				array2[1] = SandDockLanguage.x0c2979d11a5a497d;
				array2[2] = Environment.NewLine;
				goto IL_4E;
				IL_5F:
				text = string.Concat(array);
				text4 = text;
				array2 = new string[5];
				if (!false)
				{
					goto IL_78;
				}
				break;
				IL_83:
				array[3] = designerAssembly.Location;
				array[4] = Environment.NewLine;
				array[5] = Environment.NewLine;
				goto IL_5F;
			}
		}

		// Token: 0x060001A1 RID: 417 RVA: 0x0000EDF8 File Offset: 0x0000DDF8
		private SandDockLanguage()
		{
		}

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x060001A2 RID: 418 RVA: 0x0000EE00 File Offset: 0x0000DE00
		// (set) Token: 0x060001A3 RID: 419 RVA: 0x0000EE08 File Offset: 0x0000DE08
		[Localizable(true)]
		public static string ActiveFilesText
		{
			get
			{
				return SandDockLanguage.x5e3773048fa89dc1;
			}
			set
			{
				if (value == null)
				{
					value = string.Empty;
				}
				SandDockLanguage.x5e3773048fa89dc1 = value;
			}
		}

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x060001A4 RID: 420 RVA: 0x0000EE1C File Offset: 0x0000DE1C
		// (set) Token: 0x060001A5 RID: 421 RVA: 0x0000EE24 File Offset: 0x0000DE24
		[Localizable(true)]
		public static string WindowPositionText
		{
			get
			{
				return SandDockLanguage.x9956f53fadd73b87;
			}
			set
			{
				SandDockLanguage.x9956f53fadd73b87 = value;
			}
		}

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x060001A6 RID: 422 RVA: 0x0000EE2C File Offset: 0x0000DE2C
		// (set) Token: 0x060001A7 RID: 423 RVA: 0x0000EE34 File Offset: 0x0000DE34
		[Localizable(true)]
		public static string ScrollRightText
		{
			get
			{
				return SandDockLanguage.x9e94b420934211d6;
			}
			set
			{
				SandDockLanguage.x9e94b420934211d6 = value;
			}
		}

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x060001A8 RID: 424 RVA: 0x0000EE3C File Offset: 0x0000DE3C
		// (set) Token: 0x060001A9 RID: 425 RVA: 0x0000EE44 File Offset: 0x0000DE44
		[Localizable(true)]
		public static string ScrollLeftText
		{
			get
			{
				return SandDockLanguage.xd1710f20a2c171cd;
			}
			set
			{
				SandDockLanguage.xd1710f20a2c171cd = value;
			}
		}

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x060001AA RID: 426 RVA: 0x0000EE4C File Offset: 0x0000DE4C
		// (set) Token: 0x060001AB RID: 427 RVA: 0x0000EE54 File Offset: 0x0000DE54
		[Localizable(true)]
		public static string CloseText
		{
			get
			{
				return SandDockLanguage.x44b5349697df48ef;
			}
			set
			{
				SandDockLanguage.x44b5349697df48ef = value;
			}
		}

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x060001AC RID: 428 RVA: 0x0000EE5C File Offset: 0x0000DE5C
		// (set) Token: 0x060001AD RID: 429 RVA: 0x0000EE64 File Offset: 0x0000DE64
		[Localizable(true)]
		public static string AutoHideText
		{
			get
			{
				return SandDockLanguage.xa411173168232f87;
			}
			set
			{
				SandDockLanguage.xa411173168232f87 = value;
			}
		}

		// Token: 0x060001AE RID: 430 RVA: 0x0000EE6C File Offset: 0x0000DE6C
		// Note: this type is marked as 'beforefieldinit'.
		static SandDockLanguage()
		{
			if (!false)
			{
				SandDockLanguage.xa411173168232f87 = "Auto Hide";
				if (!false)
				{
					SandDockLanguage.xd1710f20a2c171cd = "Scroll Left";
					SandDockLanguage.x9e94b420934211d6 = "Scroll Right";
				}
				SandDockLanguage.x9956f53fadd73b87 = "Window  Position";
				SandDockLanguage.x5e3773048fa89dc1 = "Active Files";
				SandDockLanguage.x39981e4ce91f2127 = "Visual Studio is attempting to load designers from a different assembly than the one your components are being created with. This will result in failure to load your designed component. This message is being displayed because SandDock has detected this condition and will give you more information that will help you to correct the problem.";
				if (-1 == 0)
				{
					return;
				}
			}
			SandDockLanguage.x0c2979d11a5a497d = "The component in question should be installed in only one location, by default within the \"Program Files\\Divelements\" folder. Please close Visual Studio, remove the errant assembly and try loading your designer again.";
			SandDockLanguage.x72913f986fffe0b3 = "Ensure that you do not attempt to save any designer that opens with errors, as this can result in loss of work. Note that you may receive this message multiple times, once for each component instance in your designer.";
		}

		// Token: 0x04000074 RID: 116
		private static string x44b5349697df48ef = "Close";

		// Token: 0x04000075 RID: 117
		private static string xa411173168232f87;

		// Token: 0x04000076 RID: 118
		private static string xd1710f20a2c171cd;

		// Token: 0x04000077 RID: 119
		private static string x9e94b420934211d6;

		// Token: 0x04000078 RID: 120
		private static string x9956f53fadd73b87;

		// Token: 0x04000079 RID: 121
		private static string x5e3773048fa89dc1;

		// Token: 0x0400007A RID: 122
		private static string x39981e4ce91f2127;

		// Token: 0x0400007B RID: 123
		private static string x0c2979d11a5a497d;

		// Token: 0x0400007C RID: 124
		private static string x72913f986fffe0b3;
	}
}
