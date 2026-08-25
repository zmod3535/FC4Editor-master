using System;
using System.Configuration;

namespace TD.SandDock
{
	// Token: 0x0200005D RID: 93
	internal partial class LayoutSettings : ApplicationSettingsBase
	{
		// Token: 0x1700014B RID: 331
		// (get) Token: 0x0600052E RID: 1326 RVA: 0x00027CEC File Offset: 0x00026CEC
		// (set) Token: 0x0600052F RID: 1327 RVA: 0x00027D00 File Offset: 0x00026D00
		[UserScopedSetting]
		[DefaultSettingValue("true")]
		public bool IsDefault
		{
			get
			{
				return (bool)this["IsDefault"];
			}
			set
			{
				this["IsDefault"] = value;
			}
		}
	}
}
