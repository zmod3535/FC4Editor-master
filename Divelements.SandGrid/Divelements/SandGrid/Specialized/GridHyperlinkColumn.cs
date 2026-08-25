using System;
using System.ComponentModel;
using System.Drawing;
using Divelements.SandGrid.Rendering;

namespace Divelements.SandGrid.Specialized
{
	// Token: 0x0200009A RID: 154
	public class GridHyperlinkColumn : GridButtonColumn
	{
		// Token: 0x060006F1 RID: 1777 RVA: 0x000231C0 File Offset: 0x000221C0
		public GridHyperlinkColumn(string text, int width) : base(text, width)
		{
			this.CellHorizontalAlignment = StringAlignment.Near;
			this.ForeColorSource = CellForeColorSource.RowCell;
		}

		// Token: 0x060006F2 RID: 1778 RVA: 0x000231F8 File Offset: 0x000221F8
		public GridHyperlinkColumn()
		{
			this.CellHorizontalAlignment = StringAlignment.Near;
			this.ForeColorSource = CellForeColorSource.RowCell;
		}

		// Token: 0x060006F3 RID: 1779 RVA: 0x0002322C File Offset: 0x0002222C
		public override GridCell CreateCell()
		{
			return new GridHyperlinkCell();
		}

		// Token: 0x060006F4 RID: 1780 RVA: 0x00023234 File Offset: 0x00022234
		protected internal override void DrawCell(RenderingContext context, GridRow row, object value, Font cellFont, Image image, Rectangle bounds, bool selected, TextFormattingInformation textFormat, Color cellForeColor)
		{
			if (this.x63261453f32f3624)
			{
				using (Font font = new Font(cellFont, FontStyle.Underline))
				{
					base.DrawCell(context, row, value, font, image, bounds, selected, textFormat, cellForeColor);
					return;
				}
			}
			base.DrawCell(context, row, value, cellFont, image, bounds, selected, textFormat, cellForeColor);
		}

		// Token: 0x170001B6 RID: 438
		// (get) Token: 0x060006F5 RID: 1781 RVA: 0x000232A4 File Offset: 0x000222A4
		// (set) Token: 0x060006F6 RID: 1782 RVA: 0x000232AC File Offset: 0x000222AC
		[Description("The color with which normal links are drawn.")]
		[DefaultValue(typeof(Color), "Blue")]
		[Category("Appearance")]
		public Color LinkNormalColor
		{
			get
			{
				return this.xd76ac127b67fe1ec;
			}
			set
			{
				this.xd76ac127b67fe1ec = value;
				base.RedrawNeeded(true);
			}
		}

		// Token: 0x170001B7 RID: 439
		// (get) Token: 0x060006F7 RID: 1783 RVA: 0x000232BC File Offset: 0x000222BC
		// (set) Token: 0x060006F8 RID: 1784 RVA: 0x000232C4 File Offset: 0x000222C4
		[Category("Appearance")]
		[Description("The color with which hot links are drawn.")]
		[DefaultValue(typeof(Color), "Red")]
		public Color LinkHotColor
		{
			get
			{
				return this.x3b1924d6fc2aa164;
			}
			set
			{
				this.x3b1924d6fc2aa164 = value;
				base.RedrawNeeded(true);
			}
		}

		// Token: 0x170001B8 RID: 440
		// (get) Token: 0x060006F9 RID: 1785 RVA: 0x000232D4 File Offset: 0x000222D4
		// (set) Token: 0x060006FA RID: 1786 RVA: 0x000232DC File Offset: 0x000222DC
		[DefaultValue(typeof(StringAlignment), "Near")]
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

		// Token: 0x170001B9 RID: 441
		// (get) Token: 0x060006FB RID: 1787 RVA: 0x000232E8 File Offset: 0x000222E8
		// (set) Token: 0x060006FC RID: 1788 RVA: 0x000232F0 File Offset: 0x000222F0
		[DefaultValue(typeof(CellForeColorSource), "RowCell")]
		public override CellForeColorSource ForeColorSource
		{
			get
			{
				return base.ForeColorSource;
			}
			set
			{
				base.ForeColorSource = value;
			}
		}

		// Token: 0x040002B2 RID: 690
		private bool x63261453f32f3624 = true;

		// Token: 0x040002B3 RID: 691
		private Color xd76ac127b67fe1ec = Color.Blue;

		// Token: 0x040002B4 RID: 692
		private Color x3b1924d6fc2aa164 = Color.Red;
	}
}
