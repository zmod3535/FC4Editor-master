using System;

namespace IGE.Parameters
{
	// Token: 0x02000006 RID: 6
	internal class ParamFloat : ValueParameter<float>
	{
		// Token: 0x06000017 RID: 23 RVA: 0x0000221B File Offset: 0x0000041B
		public ParamFloat(string display, float min, float max, float resolution, ValueParameter<float>.ValueChangedDelegate evt) : base(display, evt)
		{
			this.MinValue = min;
			this.MaxValue = max;
			this.Resolution = resolution;
		}

		// Token: 0x06000018 RID: 24 RVA: 0x0000223C File Offset: 0x0000043C
		public ParamFloat(string display, float value, float min, float max, float resolution) : base(display, null)
		{
			this.MinValue = min;
			this.MaxValue = max;
			this.Resolution = resolution;
			base.Value = value;
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002264 File Offset: 0x00000464
		protected override bool IsValid(float value)
		{
			return value >= this.MinValue && value <= this.MaxValue;
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600001A RID: 26 RVA: 0x0000227D File Offset: 0x0000047D
		// (set) Token: 0x0600001B RID: 27 RVA: 0x00002285 File Offset: 0x00000485
		public float MinValue
		{
			get
			{
				return this._minValue;
			}
			set
			{
				if (this._minValue == value)
				{
					return;
				}
				this._minValue = value;
				base.RaisePropertyChanged("MinValue");
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600001C RID: 28 RVA: 0x000022A3 File Offset: 0x000004A3
		// (set) Token: 0x0600001D RID: 29 RVA: 0x000022AB File Offset: 0x000004AB
		public float MaxValue
		{
			get
			{
				return this._maxValue;
			}
			set
			{
				if (this._maxValue == value)
				{
					return;
				}
				this._maxValue = value;
				base.RaisePropertyChanged("MaxValue");
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600001E RID: 30 RVA: 0x000022C9 File Offset: 0x000004C9
		// (set) Token: 0x0600001F RID: 31 RVA: 0x000022D1 File Offset: 0x000004D1
		public float Resolution
		{
			get
			{
				return this._resolution;
			}
			set
			{
				if (this._resolution == value)
				{
					return;
				}
				this._resolution = value;
				base.RaisePropertyChanged("Resolution");
			}
		}

		// Token: 0x04000008 RID: 8
		private float _minValue;

		// Token: 0x04000009 RID: 9
		private float _maxValue;

		// Token: 0x0400000A RID: 10
		private float _resolution;
	}
}
