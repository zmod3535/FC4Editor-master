using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace IGE.Properties
{
	// Token: 0x02000105 RID: 261
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		// Token: 0x17000214 RID: 532
		// (get) Token: 0x06000925 RID: 2341 RVA: 0x0001E724 File Offset: 0x0001C924
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		// Token: 0x04000472 RID: 1138
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
