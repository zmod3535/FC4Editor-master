using System;
using System.ComponentModel;
using System.Drawing;
using Divelements.SandGrid.Rendering;

namespace Divelements.SandGrid.Specialized
{
	// Token: 0x02000096 RID: 150
	public class GridProgressBarColumn : GridIntegerColumn
	{
		// Token: 0x060006CB RID: 1739 RVA: 0x00022D20 File Offset: 0x00021D20
		public GridProgressBarColumn(string text, int width) : base(text, width)
		{
		}

		// Token: 0x060006CC RID: 1740 RVA: 0x00022D3C File Offset: 0x00021D3C
		public GridProgressBarColumn()
		{
		}

		// Token: 0x060006CD RID: 1741 RVA: 0x00022D54 File Offset: 0x00021D54
		protected internal override void DrawCell(RenderingContext context, GridRow row, object value, Font rowFont, Image image, Rectangle bounds, bool selected, TextFormattingInformation textFormat, Color foreColor)
		{
			if (!(value is int))
			{
				return;
			}
			int num = (int)value;
			if (num < this.x0544ac0ec01356ec || num > this.xa298b143814a0d9e)
			{
				return;
			}
			bounds = new Rectangle(bounds.X + 2, bounds.Y + bounds.Height / 2 - this.BarSize / 2, bounds.Width - 4, this.BarSize);
			context.Renderer.DrawProgressBar(context.Graphics, bounds, this.x0544ac0ec01356ec, this.xa298b143814a0d9e, num);
		}

		// Token: 0x170001AD RID: 429
		// (get) Token: 0x060006CE RID: 1742 RVA: 0x00022DE0 File Offset: 0x00021DE0
		// (set) Token: 0x060006CF RID: 1743 RVA: 0x00022DE8 File Offset: 0x00021DE8
		[DefaultValue(13)]
		[Category("Appearance")]
		[Description("The size of the progress bar.")]
		public int BarSize
		{
			get
			{
				return this.x3cb52fc10855978e;
			}
			set
			{
				if (value < 2)
				{
					throw new ArgumentException("value");
				}
				this.x3cb52fc10855978e = value;
				base.RedrawNeeded(true);
			}
		}

		// Token: 0x170001AE RID: 430
		// (get) Token: 0x060006D0 RID: 1744 RVA: 0x00022E08 File Offset: 0x00021E08
		// (set) Token: 0x060006D1 RID: 1745 RVA: 0x00022E10 File Offset: 0x00021E10
		[DefaultValue(0)]
		[Description("The minimum that a value can be.")]
		[Category("Data")]
		public int Minimum
		{
			get
			{
				return this.x0544ac0ec01356ec;
			}
			set
			{
				this.x0544ac0ec01356ec = value;
				base.RedrawNeeded(true);
			}
		}

		// Token: 0x170001AF RID: 431
		// (get) Token: 0x060006D2 RID: 1746 RVA: 0x00022E20 File Offset: 0x00021E20
		// (set) Token: 0x060006D3 RID: 1747 RVA: 0x00022E28 File Offset: 0x00021E28
		[Category("Data")]
		[DefaultValue(100)]
		[Description("The maximum that a value can be.")]
		public int Maximum
		{
			get
			{
				return this.xa298b143814a0d9e;
			}
			set
			{
				this.xa298b143814a0d9e = value;
				base.RedrawNeeded(true);
			}
		}

		// Token: 0x040002AA RID: 682
		private int x0544ac0ec01356ec;

		// Token: 0x040002AB RID: 683
		private int xa298b143814a0d9e = 100;

		// Token: 0x040002AC RID: 684
		private int x3cb52fc10855978e = 13;
	}
}
