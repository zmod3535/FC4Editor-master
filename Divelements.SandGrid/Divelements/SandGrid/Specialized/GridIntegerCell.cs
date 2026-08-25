using System;
using System.ComponentModel;

namespace Divelements.SandGrid.Specialized
{
	// Token: 0x0200008A RID: 138
	public class GridIntegerCell : TypedGridCell
	{
		// Token: 0x06000668 RID: 1640 RVA: 0x00021BEC File Offset: 0x00020BEC
		public GridIntegerCell(int value)
		{
			this.Value = value;
			base.IsNull = false;
		}

		// Token: 0x06000669 RID: 1641 RVA: 0x00021C04 File Offset: 0x00020C04
		public GridIntegerCell()
		{
			base.IsNull = true;
		}

		// Token: 0x17000193 RID: 403
		// (get) Token: 0x0600066A RID: 1642 RVA: 0x00021C14 File Offset: 0x00020C14
		// (set) Token: 0x0600066B RID: 1643 RVA: 0x00021C1C File Offset: 0x00020C1C
		[DefaultValue(0)]
		[Category("Data")]
		public int Value
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

		// Token: 0x0600066C RID: 1644 RVA: 0x00021C4C File Offset: 0x00020C4C
		protected override object GetValueCore()
		{
			return this.Value;
		}

		// Token: 0x0600066D RID: 1645 RVA: 0x00021C5C File Offset: 0x00020C5C
		protected override void SetValueCore(object value)
		{
			if (value is int)
			{
				this.Value = (int)value;
				return;
			}
			throw new ArgumentException("The specified value was not of the correct type.", "value");
		}

		// Token: 0x04000292 RID: 658
		private int x6dc4194e24ad939f;
	}
}
