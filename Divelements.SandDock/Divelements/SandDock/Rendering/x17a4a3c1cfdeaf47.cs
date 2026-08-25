using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using System.Windows.Interop;

namespace Divelements.SandDock.Rendering
{
	// Token: 0x02000072 RID: 114
	internal class x17a4a3c1cfdeaf47
	{
		// Token: 0x060004B5 RID: 1205 RVA: 0x00047778 File Offset: 0x00045B78
		private x17a4a3c1cfdeaf47()
		{
			this.xf3a173fefd5763d9 = new List<ThemeDictionaryManager>();
		}

		// Token: 0x060004B6 RID: 1206 RVA: 0x00047794 File Offset: 0x00045B94
		public void xa354c277cf832fca(ThemeDictionaryManager xaf81af0633c4820d)
		{
			this.xf3a173fefd5763d9.Add(xaf81af0633c4820d);
		}

		// Token: 0x1700010A RID: 266
		// (get) Token: 0x060004B7 RID: 1207 RVA: 0x000477A4 File Offset: 0x00045BA4
		// (set) Token: 0x060004B8 RID: 1208 RVA: 0x000477AC File Offset: 0x00045BAC
		public StandardTheme x3dabda6865ed239d
		{
			get
			{
				return this.x8ad4cdceb54e447f;
			}
			set
			{
				if (value != this.x8ad4cdceb54e447f)
				{
					this.x8ad4cdceb54e447f = value;
					foreach (ThemeDictionaryManager themeDictionaryManager in this.xf3a173fefd5763d9)
					{
						themeDictionaryManager.Populate();
					}
					if (!BrowserInteropHelper.IsBrowserHosted)
					{
						x17a4a3c1cfdeaf47.x942c4444c54be84c();
					}
				}
			}
		}

		// Token: 0x060004B9 RID: 1209 RVA: 0x00047828 File Offset: 0x00045C28
		private static void x942c4444c54be84c()
		{
			Type type = typeof(SystemFonts).Assembly.GetType("System.Windows.SystemResources");
			type.GetMethod("OnThemeChanged", BindingFlags.Static | BindingFlags.NonPublic).Invoke(null, null);
			MethodInfo method = type.GetMethod("InvalidateResources", BindingFlags.Static | BindingFlags.NonPublic);
			method.Invoke(null, new object[]
			{
				false
			});
			method.Invoke(null, new object[]
			{
				true
			});
		}

		// Token: 0x04000289 RID: 649
		public static readonly x17a4a3c1cfdeaf47 x9834ddb0e0bd5996 = new x17a4a3c1cfdeaf47();

		// Token: 0x0400028A RID: 650
		private StandardTheme x8ad4cdceb54e447f = StandardTheme.VisualStudio2008;

		// Token: 0x0400028B RID: 651
		private List<ThemeDictionaryManager> xf3a173fefd5763d9;
	}
}
