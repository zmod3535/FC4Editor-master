using System;
using System.ComponentModel;
using System.Drawing;
using Divelements.SandGrid.Rendering;

namespace Divelements.SandGrid.Specialized
{
	// Token: 0x02000063 RID: 99
	public class GridBooleanColumn : TypedGridColumn
	{
		// Token: 0x060005E8 RID: 1512 RVA: 0x0001FB1C File Offset: 0x0001EB1C
		public GridBooleanColumn()
		{
		}

		// Token: 0x060005E9 RID: 1513 RVA: 0x0001FB3C File Offset: 0x0001EB3C
		public GridBooleanColumn(string text, int width) : base(text, width)
		{
		}

		// Token: 0x060005EA RID: 1514 RVA: 0x0001FB5C File Offset: 0x0001EB5C
		public override GridCell CreateCell()
		{
			return new GridBooleanCell();
		}

		// Token: 0x1700017B RID: 379
		// (get) Token: 0x060005EB RID: 1515 RVA: 0x0001FB64 File Offset: 0x0001EB64
		public override Type DataType
		{
			get
			{
				return typeof(bool);
			}
		}

		// Token: 0x060005EC RID: 1516 RVA: 0x0001FB70 File Offset: 0x0001EB70
		protected internal override void DrawCell(RenderingContext context, GridRow row, object value, Font rowFont, Image image, Rectangle bounds, bool selected, TextFormattingInformation textFormat, Color foreColor)
		{
			if (value is bool && this.DisplayType == BooleanDisplayType.CheckMark)
			{
				if ((bool)value)
				{
					base.GetEffectiveForeColor(foreColor);
					Pen pen;
					if (selected)
					{
						pen = new Pen(context.Renderer.GetSelectedTextColor(context.ContainsFocus));
					}
					else
					{
						pen = new Pen(SystemColors.WindowText);
					}
					int num = bounds.X + bounds.Width / 2 - 3;
					int num2 = bounds.Y + bounds.Height / 2 - 1;
					context.Graphics.DrawLine(pen, num - 3, num2, num - 1, num2 + 2);
					context.Graphics.DrawLine(pen, num - 3, num2 + 1, num - 1, num2 + 3);
					context.Graphics.DrawLine(pen, num - 3, num2 + 2, num - 1, num2 + 4);
					context.Graphics.DrawLine(pen, num - 1, num2 + 2, num + 4, num2 - 3);
					context.Graphics.DrawLine(pen, num - 1, num2 + 3, num + 4, num2 - 2);
					context.Graphics.DrawLine(pen, num - 1, num2 + 4, num + 4, num2 - 1);
					pen.Dispose();
					return;
				}
			}
			else
			{
				base.DrawCell(context, row, value, rowFont, image, bounds, selected, textFormat, foreColor);
			}
		}

		// Token: 0x060005ED RID: 1517 RVA: 0x0001FCA4 File Offset: 0x0001ECA4
		protected override object FormatValue(object value, Type desiredType)
		{
			if (!(value is bool) || this.DisplayType != BooleanDisplayType.YesNo)
			{
				return base.FormatValue(value, desiredType);
			}
			if (!(bool)value)
			{
				return this.NoText;
			}
			return this.YesText;
		}

		// Token: 0x060005EE RID: 1518 RVA: 0x0001FCD8 File Offset: 0x0001ECD8
		protected override object ParseValue(GridRow row, object formattedValue, Type desiredType)
		{
			if (this.DisplayType != BooleanDisplayType.YesNo || !(formattedValue is string))
			{
				return base.ParseValue(row, formattedValue, desiredType);
			}
			string strA = formattedValue as string;
			if (string.Compare(strA, this.YesText, true) == 0)
			{
				return true;
			}
			return false;
		}

		// Token: 0x1700017C RID: 380
		// (get) Token: 0x060005EF RID: 1519 RVA: 0x0001FD24 File Offset: 0x0001ED24
		// (set) Token: 0x060005F0 RID: 1520 RVA: 0x0001FD2C File Offset: 0x0001ED2C
		[DefaultValue("No")]
		[Description("Indicates the text displayed for a false value when DisplayType is set to YesNo.")]
		[Category("Appearance")]
		[Localizable(true)]
		public string NoText
		{
			get
			{
				return this.x4f5337694b3f6323;
			}
			set
			{
				if (value == null)
				{
					value = string.Empty;
				}
				this.x4f5337694b3f6323 = value;
				base.MeasureNeeded();
			}
		}

		// Token: 0x1700017D RID: 381
		// (get) Token: 0x060005F1 RID: 1521 RVA: 0x0001FD48 File Offset: 0x0001ED48
		// (set) Token: 0x060005F2 RID: 1522 RVA: 0x0001FD50 File Offset: 0x0001ED50
		[Category("Appearance")]
		[Description("Indicates the text displayed for a true value when DisplayType is set to YesNo.")]
		[Localizable(true)]
		[DefaultValue("Yes")]
		public string YesText
		{
			get
			{
				return this.x930534221fdc3681;
			}
			set
			{
				if (value == null)
				{
					value = string.Empty;
				}
				this.x930534221fdc3681 = value;
				base.MeasureNeeded();
			}
		}

		// Token: 0x1700017E RID: 382
		// (get) Token: 0x060005F3 RID: 1523 RVA: 0x0001FD6C File Offset: 0x0001ED6C
		// (set) Token: 0x060005F4 RID: 1524 RVA: 0x0001FD74 File Offset: 0x0001ED74
		[DefaultValue(typeof(BooleanDisplayType), "TrueFalse")]
		[Category("Appearance")]
		[Description("Indicates how the value will be displayed.")]
		public BooleanDisplayType DisplayType
		{
			get
			{
				return this.x2effd7514342bbac;
			}
			set
			{
				this.x2effd7514342bbac = value;
				base.MeasureNeeded();
			}
		}

		// Token: 0x04000241 RID: 577
		private BooleanDisplayType x2effd7514342bbac;

		// Token: 0x04000242 RID: 578
		private string x930534221fdc3681 = "Yes";

		// Token: 0x04000243 RID: 579
		private string x4f5337694b3f6323 = "No";
	}
}
