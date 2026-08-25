using System;
using System.ComponentModel;

namespace Divelements.SandGrid.Specialized
{
	// Token: 0x02000068 RID: 104
	public class GridCell<T> : TypedGridCell
	{
		// Token: 0x06000602 RID: 1538 RVA: 0x0001FE48 File Offset: 0x0001EE48
		public GridCell(T value)
		{
			this.Value = value;
			base.IsNull = false;
		}

		// Token: 0x06000603 RID: 1539 RVA: 0x0001FE60 File Offset: 0x0001EE60
		public GridCell()
		{
			base.IsNull = true;
		}

		// Token: 0x17000182 RID: 386
		// (get) Token: 0x06000604 RID: 1540 RVA: 0x0001FE70 File Offset: 0x0001EE70
		// (set) Token: 0x06000605 RID: 1541 RVA: 0x0001FE78 File Offset: 0x0001EE78
		[Category("Data")]
		public T Value
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

		// Token: 0x06000606 RID: 1542 RVA: 0x0001FEA8 File Offset: 0x0001EEA8
		private bool ShouldSerializeValue()
		{
			return !base.IsNull;
		}

		// Token: 0x06000607 RID: 1543 RVA: 0x0001FEB4 File Offset: 0x0001EEB4
		protected override object GetValueCore()
		{
			return this.Value;
		}

		// Token: 0x06000608 RID: 1544 RVA: 0x0001FEC4 File Offset: 0x0001EEC4
		protected override void SetValueCore(object value)
		{
			if (value is T)
			{
				this.Value = (T)((object)value);
				return;
			}
			throw new ArgumentException("The specified value was not of the correct type.", "value");
		}

		// Token: 0x04000249 RID: 585
		private T x6dc4194e24ad939f;
	}
}
