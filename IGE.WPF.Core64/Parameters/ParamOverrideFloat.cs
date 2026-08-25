using System;

namespace IGE.Parameters
{
	// Token: 0x02000007 RID: 7
	internal class ParamOverrideFloat : ParamFloat
	{
		// Token: 0x06000020 RID: 32 RVA: 0x000022EF File Offset: 0x000004EF
		public ParamOverrideFloat(string display, float min, float max, float resolution, ValueParameter<float>.ValueChangedDelegate floatValueDelegate, ParamOverrideFloat.OverrideChangedDelegate boolValueDelegate) : base(display, min, max, resolution, floatValueDelegate)
		{
			this.OverrideChanged = boolValueDelegate;
			this._forceOverridePropertyChanged = true;
		}

		// Token: 0x06000021 RID: 33 RVA: 0x0000230D File Offset: 0x0000050D
		public ParamOverrideFloat(string display, bool paramOverride, float value, float min, float max, float resolution) : base(display, value, min, max, resolution)
		{
			this.Override = paramOverride;
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000022 RID: 34 RVA: 0x00002324 File Offset: 0x00000524
		// (set) Token: 0x06000023 RID: 35 RVA: 0x0000232C File Offset: 0x0000052C
		public ParamOverrideFloat.OverrideChangedDelegate OverrideChanged { get; set; }

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000024 RID: 36 RVA: 0x00002335 File Offset: 0x00000535
		// (set) Token: 0x06000025 RID: 37 RVA: 0x00002340 File Offset: 0x00000540
		public bool Override
		{
			get
			{
				return this._override;
			}
			set
			{
				if (this._override.Equals(value))
				{
					if (this._forceOverridePropertyChanged)
					{
						this.RaiseOverrideChanged();
						this._forceOverridePropertyChanged = false;
					}
					return;
				}
				this._forceOverridePropertyChanged = false;
				this._override = value;
				this.RaiseOverrideChanged();
				base.RaisePropertyChanged("Override");
			}
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00002390 File Offset: 0x00000590
		private void RaiseOverrideChanged()
		{
			ParamOverrideFloat.OverrideChangedDelegate overrideChanged = this.OverrideChanged;
			if (overrideChanged != null)
			{
				overrideChanged(this.Override);
			}
		}

		// Token: 0x0400000B RID: 11
		private bool _override;

		// Token: 0x0400000C RID: 12
		private bool _forceOverridePropertyChanged;

		// Token: 0x02000008 RID: 8
		// (Invoke) Token: 0x06000028 RID: 40
		public delegate void OverrideChangedDelegate(bool value);
	}
}
