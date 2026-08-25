using System;

namespace IGE.Parameters
{
	// Token: 0x0200001B RID: 27
	internal class ParamInt : ValueParameter<int>
	{
		// Token: 0x060000C1 RID: 193 RVA: 0x000030C8 File Offset: 0x000012C8
		public ParamInt(string display, int min, int max, ValueParameter<int>.ValueChangedDelegate evt) : base(display, evt)
		{
			this.MinValue = min;
			this.MaxValue = max;
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x000030E1 File Offset: 0x000012E1
		public ParamInt(string display, int value, int min, int max) : base(display, null)
		{
			this.MinValue = min;
			this.MaxValue = max;
			base.Value = value;
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x00003101 File Offset: 0x00001301
		protected override bool IsValid(int value)
		{
			return value >= this.MinValue && value <= this.MaxValue;
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x060000C4 RID: 196 RVA: 0x0000311A File Offset: 0x0000131A
		// (set) Token: 0x060000C5 RID: 197 RVA: 0x00003122 File Offset: 0x00001322
		public int MinValue
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

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x060000C6 RID: 198 RVA: 0x00003140 File Offset: 0x00001340
		// (set) Token: 0x060000C7 RID: 199 RVA: 0x00003148 File Offset: 0x00001348
		public int MaxValue
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

		// Token: 0x04000035 RID: 53
		private int _minValue;

		// Token: 0x04000036 RID: 54
		private int _maxValue;
	}
}
