using System;

namespace IGE.Parameters
{
	// Token: 0x0200003E RID: 62
	internal class ParamBudgetBar : ValueParameter<float>
	{
		// Token: 0x060002FC RID: 764 RVA: 0x000094C1 File Offset: 0x000076C1
		public ParamBudgetBar(string display, bool showText = true, bool showFPPrecision = false) : base(display, null)
		{
			this._showText = showText;
			this._showFPPrecision = showFPPrecision;
		}

		// Token: 0x060002FD RID: 765 RVA: 0x000094E4 File Offset: 0x000076E4
		public void OnResize(float newWidth)
		{
			this._maxWidth = newWidth;
			this.UpdateBar();
		}

		// Token: 0x060002FE RID: 766 RVA: 0x000094F4 File Offset: 0x000076F4
		public void SetInfo(float currValue, float maxValue, float ambientValue = 0f)
		{
			this._maxValue = maxValue;
			this._currentValue = currValue;
			this._ambientValue = ambientValue;
			this.UpdateBar();
			if (this._showFPPrecision)
			{
				this.BudgetString = string.Format("{0:F1} / {1}", this._currentValue, this._maxValue);
				return;
			}
			this.BudgetString = string.Format("{0:F0} / {1}", this._currentValue, this._maxValue);
		}

		// Token: 0x060002FF RID: 767 RVA: 0x00009574 File Offset: 0x00007774
		private void UpdateBar()
		{
			this.Width = 0.0001f;
			this.AmbientWidth = 0.0001f;
			if (this._ambientValue > 0f)
			{
				float num = this._ambientValue / this._maxValue * 100f;
				this.AmbientWidth = Math.Min(this._maxWidth * num / 100f, this._maxWidth);
			}
			float num2 = this._currentValue / this._maxValue * 100f;
			this.Width = Math.Min(this._maxWidth * num2 / 100f, this._maxWidth);
		}

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x06000300 RID: 768 RVA: 0x0000960A File Offset: 0x0000780A
		// (set) Token: 0x06000301 RID: 769 RVA: 0x00009612 File Offset: 0x00007812
		public float AmbientWidth
		{
			get
			{
				return this._ambwidth;
			}
			set
			{
				if (this._ambwidth == value)
				{
					return;
				}
				this._ambwidth = value;
				base.RaisePropertyChanged("AmbientWidth");
			}
		}

		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x06000302 RID: 770 RVA: 0x00009630 File Offset: 0x00007830
		// (set) Token: 0x06000303 RID: 771 RVA: 0x00009638 File Offset: 0x00007838
		public float Width
		{
			get
			{
				return this._width;
			}
			set
			{
				if (this._width == value)
				{
					return;
				}
				this._width = value;
				base.RaisePropertyChanged("Width");
			}
		}

		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x06000304 RID: 772 RVA: 0x00009656 File Offset: 0x00007856
		// (set) Token: 0x06000305 RID: 773 RVA: 0x0000965E File Offset: 0x0000785E
		public string BudgetString
		{
			get
			{
				return this._budgetString;
			}
			set
			{
				if (!this._showText)
				{
					return;
				}
				if (this._budgetString == value)
				{
					return;
				}
				this._budgetString = value;
				base.RaisePropertyChanged("BudgetString");
			}
		}

		// Token: 0x04000134 RID: 308
		private bool _showText;

		// Token: 0x04000135 RID: 309
		private bool _showFPPrecision;

		// Token: 0x04000136 RID: 310
		private float _maxWidth;

		// Token: 0x04000137 RID: 311
		private float _ambwidth;

		// Token: 0x04000138 RID: 312
		private float _width;

		// Token: 0x04000139 RID: 313
		private string _budgetString = " ";

		// Token: 0x0400013A RID: 314
		private float _currentValue;

		// Token: 0x0400013B RID: 315
		private float _maxValue;

		// Token: 0x0400013C RID: 316
		private float _ambientValue;
	}
}
