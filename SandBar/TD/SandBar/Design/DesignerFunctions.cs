using System;
using System.Reflection;
using System.Windows.Forms;

namespace TD.SandBar.Design
{
	// Token: 0x02000010 RID: 16
	public class DesignerFunctions
	{
		// Token: 0x06000133 RID: 307 RVA: 0x000063DC File Offset: 0x000053DC
		private DesignerFunctions()
		{
		}

		// Token: 0x06000134 RID: 308 RVA: 0x000063E4 File Offset: 0x000053E4
		public static void ShowCachedAssemblyError(Assembly componentAssembly, Assembly designerAssembly)
		{
			string text = DesignerFunctions.x39981e4ce91f2127 + Environment.NewLine + Environment.NewLine;
			string text2 = text;
			string[] values = new string[]
			{
				text2,
				"Component Assembly:",
				Environment.NewLine,
				componentAssembly.Location,
				Environment.NewLine,
				Environment.NewLine
			};
			string[] values2;
			do
			{
				text = string.Concat(values);
				string text3 = text;
				values2 = new string[]
				{
					text3,
					"Designer Assembly:",
					Environment.NewLine,
					designerAssembly.Location,
					Environment.NewLine,
					Environment.NewLine
				};
			}
			while (-2 == 0);
			text = string.Concat(values2);
			string text4 = text;
			text = string.Concat(new string[]
			{
				text4,
				DesignerFunctions.x0c2979d11a5a497d,
				Environment.NewLine,
				Environment.NewLine,
				DesignerFunctions.x72913f986fffe0b3
			});
			MessageBox.Show(text, "Visual Studio Error Detected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x06000135 RID: 309 RVA: 0x000064E8 File Offset: 0x000054E8
		// (set) Token: 0x06000136 RID: 310 RVA: 0x000064F0 File Offset: 0x000054F0
		public static bool InsertingItem
		{
			get
			{
				return DesignerFunctions.x723186b9268a736e;
			}
			set
			{
				DesignerFunctions.x723186b9268a736e = value;
			}
		}

		// Token: 0x04000069 RID: 105
		private static bool x723186b9268a736e = false;

		// Token: 0x0400006A RID: 106
		private static string x39981e4ce91f2127 = "Visual Studio is attempting to load designers from a different assembly than the one your components are being created with. This will result in failure to load your designed component. This message is being displayed because SandBar has detected this condition and will give you more information that will help you to correct the problem.";

		// Token: 0x0400006B RID: 107
		private static string x0c2979d11a5a497d = "The component in question should be installed in only one location, by default within the \"Program Files\\Divelements\" folder. Please close Visual Studio, remove the errant assembly and try loading your designer again.";

		// Token: 0x0400006C RID: 108
		private static string x72913f986fffe0b3 = "Ensure that you do not attempt to save any designer that opens with errors, as this can result in loss of work. Note that you may receive this message multiple times, once for each component instance in your designer.";
	}
}
