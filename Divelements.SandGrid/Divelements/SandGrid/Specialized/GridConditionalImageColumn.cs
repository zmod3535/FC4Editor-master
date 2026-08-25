using System;
using System.ComponentModel;
using System.Drawing;
using Divelements.SandGrid.Rendering;

namespace Divelements.SandGrid.Specialized
{
	// Token: 0x02000093 RID: 147
	public class GridConditionalImageColumn : GridColumn
	{
		// Token: 0x060006A1 RID: 1697 RVA: 0x00022418 File Offset: 0x00021418
		public GridConditionalImageColumn()
		{
			base.AllowEditing = false;
		}

		// Token: 0x060006A2 RID: 1698 RVA: 0x00022450 File Offset: 0x00021450
		protected internal override void DrawCell(RenderingContext context, GridRow row, object value, Font rowFont, Image cellImage, Rectangle bounds, bool selected, TextFormattingInformation textFormat, Color foreColor)
		{
			bool flag;
			try
			{
				flag = Convert.ToBoolean(value);
			}
			catch (Exception exception)
			{
				GridDataErrorEventArgs gridDataErrorEventArgs = new GridDataErrorEventArgs(row, this, value, DataErrorOperation.Format, exception);
				base.Grid.SandGrid.xb550175c839c05f5(gridDataErrorEventArgs);
				if (gridDataErrorEventArgs.ThrowException)
				{
					throw;
				}
				return;
			}
			if (this.x14647847ce0af088 != null && flag)
			{
				context.Graphics.DrawImage(this.x14647847ce0af088, new Rectangle(bounds.X + bounds.Width / 2 - this.x14647847ce0af088.Width / 2, bounds.Y + bounds.Height / 2 - this.x14647847ce0af088.Height / 2, this.x14647847ce0af088.Width, this.x14647847ce0af088.Height));
				return;
			}
			if (this.xb569c34fae5fe342 != null && !flag)
			{
				context.Graphics.DrawImage(this.xb569c34fae5fe342, new Rectangle(bounds.X + bounds.Width / 2 - this.xb569c34fae5fe342.Width / 2, bounds.Y + bounds.Height / 2 - this.xb569c34fae5fe342.Height / 2, this.xb569c34fae5fe342.Width, this.xb569c34fae5fe342.Height));
			}
		}

		// Token: 0x060006A3 RID: 1699 RVA: 0x0002259C File Offset: 0x0002159C
		protected internal override bool IsTextOverflowing(GridRow row)
		{
			return false;
		}

		// Token: 0x060006A4 RID: 1700 RVA: 0x000225A0 File Offset: 0x000215A0
		public override GridCell CreateCell()
		{
			return new GridBooleanCell();
		}

		// Token: 0x060006A5 RID: 1701 RVA: 0x000225A8 File Offset: 0x000215A8
		private void x20893413c214cbf8()
		{
			if (base.Grid != null && base.Grid.Rows.xa5dcc13c31b2d66e(this))
			{
				base.Grid.Rows.x392c4e6c2fa28c2b();
			}
		}

		// Token: 0x060006A6 RID: 1702 RVA: 0x000225D8 File Offset: 0x000215D8
		protected override string GetGroupHeadingText(GridRow row)
		{
			object cellValue = row.GetCellValue(this);
			bool flag;
			try
			{
				flag = Convert.ToBoolean(cellValue);
			}
			catch (Exception exception)
			{
				GridDataErrorEventArgs gridDataErrorEventArgs = new GridDataErrorEventArgs(row, this, cellValue, DataErrorOperation.Format, exception);
				base.Grid.SandGrid.xb550175c839c05f5(gridDataErrorEventArgs);
				if (gridDataErrorEventArgs.ThrowException)
				{
					throw;
				}
				return string.Empty;
			}
			if (!flag)
			{
				return this.x942525ee56e51d44;
			}
			return this.xb4a734c51446233d;
		}

		// Token: 0x170001A1 RID: 417
		// (get) Token: 0x060006A7 RID: 1703 RVA: 0x00022658 File Offset: 0x00021658
		// (set) Token: 0x060006A8 RID: 1704 RVA: 0x00022660 File Offset: 0x00021660
		[Description("The text to display for a true value when grouping rows by the column.")]
		[DefaultValue("True")]
		[Category("Appearance")]
		public string TrueGroupText
		{
			get
			{
				return this.xb4a734c51446233d;
			}
			set
			{
				this.xb4a734c51446233d = value;
				this.x20893413c214cbf8();
			}
		}

		// Token: 0x170001A2 RID: 418
		// (get) Token: 0x060006A9 RID: 1705 RVA: 0x00022670 File Offset: 0x00021670
		// (set) Token: 0x060006AA RID: 1706 RVA: 0x00022678 File Offset: 0x00021678
		[DefaultValue("False")]
		[Description("The text to display for a false value when grouping rows by the column.")]
		[Category("Appearance")]
		public string FalseGroupText
		{
			get
			{
				return this.x942525ee56e51d44;
			}
			set
			{
				this.x942525ee56e51d44 = value;
				this.x20893413c214cbf8();
			}
		}

		// Token: 0x170001A3 RID: 419
		// (get) Token: 0x060006AB RID: 1707 RVA: 0x00022688 File Offset: 0x00021688
		// (set) Token: 0x060006AC RID: 1708 RVA: 0x00022690 File Offset: 0x00021690
		[Category("Appearance")]
		[Description("The image to display when the condition is met.")]
		[AmbientValue(typeof(Image), null)]
		[DefaultValue(typeof(Image), null)]
		public virtual Image TrueImage
		{
			get
			{
				return this.x14647847ce0af088;
			}
			set
			{
				this.x14647847ce0af088 = value;
				base.MeasureNeeded();
			}
		}

		// Token: 0x170001A4 RID: 420
		// (get) Token: 0x060006AD RID: 1709 RVA: 0x000226A0 File Offset: 0x000216A0
		// (set) Token: 0x060006AE RID: 1710 RVA: 0x000226A8 File Offset: 0x000216A8
		[DefaultValue(typeof(Image), null)]
		[AmbientValue(typeof(Image), null)]
		[Category("Appearance")]
		[Description("The image to display when the condition is not met.")]
		public virtual Image FalseImage
		{
			get
			{
				return this.xb569c34fae5fe342;
			}
			set
			{
				this.xb569c34fae5fe342 = value;
				base.MeasureNeeded();
			}
		}

		// Token: 0x0400029D RID: 669
		private Image x14647847ce0af088;

		// Token: 0x0400029E RID: 670
		private Image xb569c34fae5fe342;

		// Token: 0x0400029F RID: 671
		private string xb4a734c51446233d = true.ToString();

		// Token: 0x040002A0 RID: 672
		private string x942525ee56e51d44 = false.ToString();
	}
}
