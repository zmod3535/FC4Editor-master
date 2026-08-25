using System;
using System.ComponentModel;

namespace Divelements.SandGrid.Specialized
{
	// Token: 0x02000092 RID: 146
	public class GridDecimalCell : TypedGridCell
	{
		// Token: 0x0600069B RID: 1691 RVA: 0x00022380 File Offset: 0x00021380
		public GridDecimalCell(decimal value)
		{
			this.Value = value;
			base.IsNull = false;
		}

		// Token: 0x0600069C RID: 1692 RVA: 0x00022398 File Offset: 0x00021398
		public GridDecimalCell()
		{
			base.IsNull = true;
		}

		// Token: 0x170001A0 RID: 416
		// (get) Token: 0x0600069D RID: 1693 RVA: 0x000223A8 File Offset: 0x000213A8
		// (set) Token: 0x0600069E RID: 1694 RVA: 0x000223B0 File Offset: 0x000213B0
		[DefaultValue(0)]
		[Category("Data")]
		public decimal Value
		{
			get
			{
				return this.x6dc4194e24ad939f;
			}
			set
			{
				this.x6dc4194e24ad939f = value;
				base.IsNull = false;
				if (base.OnValueChanged())
				{
					return;
				}
				if (this.ValueAffectsMeasurement())
				{
					base.MeasureNeeded();
					return;
				}
				base.RedrawNeeded();
			}
		}

		// Token: 0x0600069F RID: 1695 RVA: 0x000223E0 File Offset: 0x000213E0
		protected override object GetValueCore()
		{
			return this.Value;
		}

		// Token: 0x060006A0 RID: 1696 RVA: 0x000223F0 File Offset: 0x000213F0
		protected override void SetValueCore(object value)
		{
			if (value is decimal)
			{
				this.Value = (decimal)value;
				return;
			}
			throw new ArgumentException("The specified value was not of the correct type.", "value");
		}

		// Token: 0x0400029C RID: 668
		private decimal x6dc4194e24ad939f;
	}
}
