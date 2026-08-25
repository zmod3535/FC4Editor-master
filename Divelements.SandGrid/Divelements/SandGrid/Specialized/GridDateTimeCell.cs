using System;
using System.ComponentModel;

namespace Divelements.SandGrid.Specialized
{
	// Token: 0x0200008F RID: 143
	public class GridDateTimeCell : TypedGridCell
	{
		// Token: 0x0600068B RID: 1675 RVA: 0x0002221C File Offset: 0x0002121C
		public GridDateTimeCell(DateTime value)
		{
			this.Value = value;
		}

		// Token: 0x0600068C RID: 1676 RVA: 0x0002222C File Offset: 0x0002122C
		public GridDateTimeCell()
		{
		}

		// Token: 0x1700019C RID: 412
		// (get) Token: 0x0600068D RID: 1677 RVA: 0x00022234 File Offset: 0x00021234
		// (set) Token: 0x0600068E RID: 1678 RVA: 0x0002223C File Offset: 0x0002123C
		[Category("Data")]
		public DateTime Value
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

		// Token: 0x0600068F RID: 1679 RVA: 0x0002226C File Offset: 0x0002126C
		protected override object GetValueCore()
		{
			return this.Value;
		}

		// Token: 0x06000690 RID: 1680 RVA: 0x0002227C File Offset: 0x0002127C
		protected override void SetValueCore(object value)
		{
			if (value is DateTime)
			{
				this.Value = (DateTime)value;
				return;
			}
			throw new ArgumentException("The specified value was not of the correct type.", "value");
		}

		// Token: 0x04000299 RID: 665
		private DateTime x6dc4194e24ad939f;
	}
}
