using System;
using System.ComponentModel;

namespace Divelements.SandGrid.Specialized
{
	// Token: 0x02000065 RID: 101
	public class GridBooleanCell : TypedGridCell
	{
		// Token: 0x060005F5 RID: 1525 RVA: 0x0001FD84 File Offset: 0x0001ED84
		public GridBooleanCell(bool value)
		{
			this.Value = value;
		}

		// Token: 0x060005F6 RID: 1526 RVA: 0x0001FD94 File Offset: 0x0001ED94
		public GridBooleanCell()
		{
		}

		// Token: 0x1700017F RID: 383
		// (get) Token: 0x060005F7 RID: 1527 RVA: 0x0001FD9C File Offset: 0x0001ED9C
		// (set) Token: 0x060005F8 RID: 1528 RVA: 0x0001FDA4 File Offset: 0x0001EDA4
		[DefaultValue(false)]
		[Category("Data")]
		public bool Value
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

		// Token: 0x060005F9 RID: 1529 RVA: 0x0001FDD4 File Offset: 0x0001EDD4
		protected override object GetValueCore()
		{
			return this.Value;
		}

		// Token: 0x060005FA RID: 1530 RVA: 0x0001FDE4 File Offset: 0x0001EDE4
		protected override void SetValueCore(object value)
		{
			if (value is bool)
			{
				this.Value = (bool)value;
				return;
			}
			throw new ArgumentException("The specified value was not of the correct type.", "value");
		}

		// Token: 0x04000248 RID: 584
		private bool x6dc4194e24ad939f;
	}
}
