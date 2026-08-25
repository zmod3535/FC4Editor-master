using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace Divelements.SandDock.Properties
{
	// Token: 0x02000079 RID: 121
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
	[CompilerGenerated]
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		// Token: 0x17000113 RID: 275
		// (get) Token: 0x060004E5 RID: 1253 RVA: 0x00048AEC File Offset: 0x00046EEC
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		// Token: 0x0400029B RID: 667
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
