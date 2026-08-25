using System;
using System.Configuration;

namespace TD.SandDock
{
	// Token: 0x0200005D RID: 93
	internal partial class LayoutSettings : ApplicationSettingsBase
	{
		// Token: 0x0600052A RID: 1322 RVA: 0x00027CAC File Offset: 0x00026CAC
		public LayoutSettings(string key) : base(key)
		{
		}

		// Token: 0x0600052B RID: 1323 RVA: 0x00027CB8 File Offset: 0x00026CB8
		public override void Save()
		{
			this.IsDefault = false;
			base.Save();
		}

		// Token: 0x1700014A RID: 330
		// (get) Token: 0x0600052C RID: 1324 RVA: 0x00027CC8 File Offset: 0x00026CC8
		// (set) Token: 0x0600052D RID: 1325 RVA: 0x00027CDC File Offset: 0x00026CDC
		[UserScopedSetting]
		public string LayoutXml
		{
			get
			{
				return (string)this["LayoutXml"];
			}
			set
			{
				this["LayoutXml"] = value;
			}
		}
	}
}
