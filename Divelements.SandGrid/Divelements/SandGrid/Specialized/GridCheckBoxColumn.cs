using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Divelements.SandGrid.Specialized
{
	// Token: 0x0200009C RID: 156
	public class GridCheckBoxColumn : GridColumn
	{
		// Token: 0x06000701 RID: 1793 RVA: 0x000234BC File Offset: 0x000224BC
		public GridCheckBoxColumn(string text, int width) : base(text, width)
		{
			this.CellHorizontalAlignment = StringAlignment.Center;
		}

		// Token: 0x06000702 RID: 1794 RVA: 0x000234D0 File Offset: 0x000224D0
		public GridCheckBoxColumn()
		{
			this.CellHorizontalAlignment = StringAlignment.Center;
		}

		// Token: 0x170001BA RID: 442
		// (get) Token: 0x06000703 RID: 1795 RVA: 0x000234E0 File Offset: 0x000224E0
		public override Type DataType
		{
			get
			{
				return typeof(bool);
			}
		}

		// Token: 0x06000704 RID: 1796 RVA: 0x000234EC File Offset: 0x000224EC
		public override GridCell CreateCell()
		{
			return new GridCheckBoxCell();
		}

		// Token: 0x170001BB RID: 443
		// (get) Token: 0x06000705 RID: 1797 RVA: 0x000234F4 File Offset: 0x000224F4
		// (set) Token: 0x06000706 RID: 1798 RVA: 0x000234FC File Offset: 0x000224FC
		[DefaultValue(typeof(StringAlignment), "Center")]
		public override StringAlignment CellHorizontalAlignment
		{
			get
			{
				return base.CellHorizontalAlignment;
			}
			set
			{
				base.CellHorizontalAlignment = value;
			}
		}

		// Token: 0x170001BC RID: 444
		// (get) Token: 0x06000707 RID: 1799 RVA: 0x00023508 File Offset: 0x00022508
		internal override bool xea4c5fde728d3b8e
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170001BD RID: 445
		// (get) Token: 0x06000708 RID: 1800 RVA: 0x0002350C File Offset: 0x0002250C
		// (set) Token: 0x06000709 RID: 1801 RVA: 0x00023514 File Offset: 0x00022514
		[Description("Indicates whether the checkboxes allow selection of an indeterminate state.")]
		[DefaultValue(false)]
		public bool AllowIndeterminate
		{
			get
			{
				return this.x6278063cba56ded8;
			}
			set
			{
				this.x6278063cba56ded8 = value;
			}
		}

		// Token: 0x0600070A RID: 1802 RVA: 0x00023520 File Offset: 0x00022520
		protected override object ParseValue(GridRow row, object formattedValue, Type desiredType)
		{
			if (formattedValue is CheckState)
			{
				switch ((CheckState)formattedValue)
				{
				case CheckState.Unchecked:
					return false;
				case CheckState.Checked:
					return true;
				case CheckState.Indeterminate:
					if (this.AllowIndeterminate)
					{
						return null;
					}
					return false;
				}
			}
			return base.ParseValue(row, formattedValue, desiredType);
		}

		// Token: 0x0600070B RID: 1803 RVA: 0x00023588 File Offset: 0x00022588
		protected override object FormatValue(object originalValue, Type desiredType)
		{
			if (desiredType == typeof(CheckState))
			{
				if (originalValue is bool)
				{
					if ((bool)originalValue)
					{
						return CheckState.Checked;
					}
					return CheckState.Unchecked;
				}
				else if (originalValue is bool?)
				{
					bool? flag = (bool?)originalValue;
					if (flag == null)
					{
						return CheckState.Indeterminate;
					}
					if (flag.Value)
					{
						return CheckState.Checked;
					}
					return CheckState.Unchecked;
				}
			}
			return base.FormatValue(originalValue, desiredType);
		}

		// Token: 0x040002B5 RID: 693
		private bool x6278063cba56ded8;
	}
}
