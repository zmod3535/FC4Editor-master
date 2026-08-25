using System;
using System.Globalization;
using IGE.Nomad;

namespace IGE.ViewModels
{
	// Token: 0x020000B3 RID: 179
	internal class CameraSpeedItem
	{
		// Token: 0x060006FE RID: 1790 RVA: 0x0001950F File Offset: 0x0001770F
		public CameraSpeedItem(float speed, bool custom = false)
		{
			this.Value = speed;
			this.Custom = custom;
		}

		// Token: 0x170001A0 RID: 416
		// (get) Token: 0x060006FF RID: 1791 RVA: 0x00019528 File Offset: 0x00017728
		public string Display
		{
			get
			{
				if (!this.Custom)
				{
					return this.Value.ToString(CultureInfo.InvariantCulture);
				}
				return Localizer.Localize("EDITOR_CAMERA_SPEED_CUSTOM", null);
			}
		}

		// Token: 0x170001A1 RID: 417
		// (get) Token: 0x06000700 RID: 1792 RVA: 0x0001955C File Offset: 0x0001775C
		// (set) Token: 0x06000701 RID: 1793 RVA: 0x00019564 File Offset: 0x00017764
		public float Value { get; set; }

		// Token: 0x170001A2 RID: 418
		// (get) Token: 0x06000702 RID: 1794 RVA: 0x0001956D File Offset: 0x0001776D
		// (set) Token: 0x06000703 RID: 1795 RVA: 0x00019575 File Offset: 0x00017775
		public bool Custom { get; private set; }
	}
}
