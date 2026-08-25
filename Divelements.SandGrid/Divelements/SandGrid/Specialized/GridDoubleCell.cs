using System;
using System.ComponentModel;

namespace Divelements.SandGrid.Specialized
{
	// Token: 0x0200008C RID: 140
	public class GridDoubleCell : TypedGridCell
	{
		// Token: 0x06000672 RID: 1650 RVA: 0x00021CAC File Offset: 0x00020CAC
		public GridDoubleCell(double value)
		{
			this.Value = value;
			base.IsNull = false;
		}

		// Token: 0x06000673 RID: 1651 RVA: 0x00021CC4 File Offset: 0x00020CC4
		public GridDoubleCell()
		{
			base.IsNull = true;
		}

		// Token: 0x17000195 RID: 405
		// (get) Token: 0x06000674 RID: 1652 RVA: 0x00021CD4 File Offset: 0x00020CD4
		// (set) Token: 0x06000675 RID: 1653 RVA: 0x00021CDC File Offset: 0x00020CDC
		[DefaultValue(0)]
		[Category("Data")]
		public double Value
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

		// Token: 0x06000676 RID: 1654 RVA: 0x00021D0C File Offset: 0x00020D0C
		protected override object GetValueCore()
		{
			return this.Value;
		}

		// Token: 0x06000677 RID: 1655 RVA: 0x00021D1C File Offset: 0x00020D1C
		protected override void SetValueCore(object value)
		{
			if (value is double)
			{
				this.Value = (double)value;
				return;
			}
			throw new ArgumentException("The specified value was not of the correct type.", "value");
		}

		// Token: 0x04000293 RID: 659
		private double x6dc4194e24ad939f;
	}
}
