using System;
using System.Drawing;
using Divelements.SandGrid.Rendering;

namespace Divelements.SandGrid
{
	// Token: 0x02000034 RID: 52
	public class NestedGridRow : GridRow
	{
		// Token: 0x060004B4 RID: 1204 RVA: 0x0001A1F0 File Offset: 0x000191F0
		public NestedGridRow()
		{
			this.xeac23fcec638fed2 = new InnerGrid(this);
			this.xeac23fcec638fed2.ShowRowHeaders = true;
			base.Height = 0;
		}

		// Token: 0x060004B5 RID: 1205 RVA: 0x0001A22C File Offset: 0x0001922C
		protected internal override bool CanResize()
		{
			return false;
		}

		// Token: 0x060004B6 RID: 1206 RVA: 0x0001A230 File Offset: 0x00019230
		protected override GridElement GetChildElementAt(Point position)
		{
			if (base.x94975a4c4f1d71c4)
			{
				if (position.X <= this.x52e33554e09d64f3 && position.X > this.x52e33554e09d64f3 - this.xd3bc6541e91f9509.Width)
				{
					return this.NestedGrid;
				}
			}
			else if (position.X >= this.x52e33554e09d64f3 && position.X < this.x52e33554e09d64f3 + this.xd3bc6541e91f9509.Width)
			{
				return this.NestedGrid;
			}
			return null;
		}

		// Token: 0x060004B7 RID: 1207 RVA: 0x0001A2A8 File Offset: 0x000192A8
		protected internal override void DrawHeader(RenderingContext context, TextFormattingInformation textFormat)
		{
			DrawItemState drawItemState = DrawItemState.None;
			if (base.xf4e57d58ee4da85f)
			{
				drawItemState |= DrawItemState.Hot;
			}
			context.Renderer.DrawRowHeader(context.Graphics, this, base.HeaderBounds, textFormat, drawItemState);
		}

		// Token: 0x060004B8 RID: 1208 RVA: 0x0001A2E0 File Offset: 0x000192E0
		protected internal override bool AdvanceFocus(FocusAdvanceDirection direction, FocusAdvanceMethod method, int steps, bool loop)
		{
			if (direction != FocusAdvanceDirection.Right || steps != 1)
			{
				return base.AdvanceFocus(direction, method, steps, loop);
			}
			FocusableGridElement focusableGridElement = this.NestedGrid.x297751add55a1707(true);
			if (focusableGridElement != null)
			{
				focusableGridElement.Grid.SelectElement(focusableGridElement);
				return true;
			}
			return false;
		}

		// Token: 0x060004B9 RID: 1209 RVA: 0x0001A320 File Offset: 0x00019320
		public sealed override object GetCellValue(GridColumn column)
		{
			return string.Empty;
		}

		// Token: 0x060004BA RID: 1210 RVA: 0x0001A328 File Offset: 0x00019328
		internal override void xea1c0bc64ab77594(InnerGrid xf57b149cb3f9c03a)
		{
			base.xea1c0bc64ab77594(xf57b149cb3f9c03a);
			SandGridBase xbd37b7a1be4bbca = (xf57b149cb3f9c03a == null) ? null : xf57b149cb3f9c03a.SandGrid;
			this.xeac23fcec638fed2.x8575a139d5c8689b(xbd37b7a1be4bbca);
		}

		// Token: 0x060004BB RID: 1211 RVA: 0x0001A358 File Offset: 0x00019358
		internal override void x0b035f832721de35()
		{
			base.x0b035f832721de35();
			base.Grid.xf7115efe1c1b0dcf(this.NestedGrid);
			this.NestedGrid.x0b035f832721de35();
		}

		// Token: 0x060004BC RID: 1212 RVA: 0x0001A37C File Offset: 0x0001937C
		private int xe1d18bc34342b423()
		{
			int num = 0;
			if (base.Grid != null)
			{
				foreach (GridColumn gridColumn in base.Grid.Columns.DisplayColumns)
				{
					if (gridColumn == base.Grid.PrimaryColumn)
					{
						break;
					}
					num += gridColumn.Width;
				}
			}
			return num;
		}

		// Token: 0x060004BD RID: 1213 RVA: 0x0001A3D0 File Offset: 0x000193D0
		protected override Size MeasureCore(Graphics graphics, TextFormattingInformation textFormat, bool rtl)
		{
			Size result;
			if (this.xeac23fcec638fed2.x4f5145fcade014f7)
			{
				result = (this.xd3bc6541e91f9509 = this.xeac23fcec638fed2.x2f9881556fe66cc1(graphics, rtl, Size.Empty));
			}
			else
			{
				result = this.xd3bc6541e91f9509;
			}
			result.Width += this.Margin * 2;
			result.Height += this.Margin * 2;
			result.Width += 2;
			result.Height += 2;
			if (this.xf9b06c19a78c9845.Length != 0)
			{
				result.Height += 18;
			}
			result.Width += base.IndentationLevel * base.Grid.IndentationSize;
			if (base.Grid.ShowTreeButtons)
			{
				result.Width += 17;
			}
			result.Width += this.xe1d18bc34342b423();
			return result;
		}

		// Token: 0x060004BE RID: 1214 RVA: 0x0001A4C8 File Offset: 0x000194C8
		protected internal override void LayoutCells(GridColumn[] allColumns, GridColumn[] displayColumns, GridColumn primaryColumn)
		{
			base.LayoutCells(allColumns, displayColumns, primaryColumn);
			Rectangle bounds = base.Bounds;
			int num = this.xe1d18bc34342b423();
			if (!base.x94975a4c4f1d71c4)
			{
				bounds.X += num;
			}
			bounds.Width -= num;
			int num2 = base.IndentationLevel * base.Grid.IndentationSize;
			if (base.Grid.ShowTreeButtons)
			{
				num2 += 17;
			}
			if (!base.x94975a4c4f1d71c4)
			{
				bounds.X += num2;
			}
			bounds.Width -= num2;
			if (this.xf9b06c19a78c9845.Length != 0)
			{
				bounds.Y += 18;
				bounds.Height -= 18;
			}
			bounds.Inflate(-this.Margin, -this.Margin);
			bounds.Inflate(-1, -1);
			if (base.x94975a4c4f1d71c4)
			{
				this.x52e33554e09d64f3 = bounds.Right;
			}
			else
			{
				this.x52e33554e09d64f3 = bounds.X;
			}
			this.xeac23fcec638fed2.xea337a435dab7e27(base.Grid.RightToLeft);
			this.xeac23fcec638fed2.xb7ae55095fddecd9(bounds);
		}

		// Token: 0x060004BF RID: 1215 RVA: 0x0001A5F0 File Offset: 0x000195F0
		protected internal override void DrawRowForeground(RenderingContext context, Rectangle bounds, GridColumn[] columns, TextFormattingInformation[] textFormats)
		{
			Graphics graphics = context.Graphics;
			if (base.Grid.ShowTreeLines && base.Grid.ShowTreeButtons)
			{
				base.DrawHierarchyLines(context);
			}
			if (this.xf9b06c19a78c9845.Length != 0)
			{
				Rectangle bounds2 = bounds;
				if (!base.x94975a4c4f1d71c4)
				{
					bounds2.X = this.x52e33554e09d64f3;
				}
				bounds2.Width = (base.x94975a4c4f1d71c4 ? (this.x52e33554e09d64f3 - bounds2.X) : (bounds.Right - bounds2.X));
				bounds2.Inflate(-this.Margin, -this.Margin);
				bounds2.Height = 18;
				using (Font font = new Font(base.Font, FontStyle.Bold))
				{
					IndependentText.DrawText(context.Graphics, this.xf9b06c19a78c9845, font, bounds2, textFormats[0], SystemColors.WindowText, SystemBrushes.WindowText);
				}
			}
			RenderingContext x0f7b23d1c393aed = this.xeac23fcec638fed2.xd916e3d12d2ec8e1(context.Graphics, context.Printing, context.x540a99e0b172a09e, context.xc59eabb55ae986f8);
			this.xeac23fcec638fed2.x7f63857195e5d213(x0f7b23d1c393aed);
			this.xeac23fcec638fed2.xa773e3fe39c24b95(x0f7b23d1c393aed);
			this.xeac23fcec638fed2.xe38b34b4ef5b24ed(x0f7b23d1c393aed);
			this.xeac23fcec638fed2.xa1c45a8b0a8e79d9(x0f7b23d1c393aed);
		}

		// Token: 0x060004C0 RID: 1216 RVA: 0x0001A74C File Offset: 0x0001974C
		protected internal override void DrawRowBackground(RenderingContext context)
		{
			Rectangle bounds = this.xeac23fcec638fed2.Bounds;
			context.Graphics.FillRectangle(SystemBrushes.Window, bounds);
			context.Renderer.DrawNestedGridBorder(context.Graphics, this.NestedGrid, bounds);
			if (base.Selected && !context.HideSelection)
			{
				if (base.x94975a4c4f1d71c4)
				{
					bounds.X = bounds.Right + this.Margin;
				}
				else
				{
					bounds.X -= this.Margin + 5;
				}
				bounds.Width = 5;
				context.Renderer.DrawSelectionRectangle(context.Graphics, bounds, true, context.ContainsFocus, context.xf58ff9ce0e24a20c == this && context.FocusRectanglesEnabled);
			}
		}

		// Token: 0x060004C1 RID: 1217 RVA: 0x0001A808 File Offset: 0x00019808
		protected internal override string GetTooltipText(Point position)
		{
			if ((base.x94975a4c4f1d71c4 ? (position.X <= this.x52e33554e09d64f3) : (position.X >= this.x52e33554e09d64f3)) || this.xeac23fcec638fed2.xc82620afa11d4a41)
			{
				return this.xeac23fcec638fed2.x9b21ee8e7ceaada3(position);
			}
			return base.GetTooltipText(position);
		}

		// Token: 0x1700012B RID: 299
		// (get) Token: 0x060004C2 RID: 1218 RVA: 0x0001A868 File Offset: 0x00019868
		// (set) Token: 0x060004C3 RID: 1219 RVA: 0x0001A86C File Offset: 0x0001986C
		public sealed override bool AllowEditing
		{
			get
			{
				return false;
			}
			set
			{
				base.AllowEditing = value;
			}
		}

		// Token: 0x1700012C RID: 300
		// (get) Token: 0x060004C4 RID: 1220 RVA: 0x0001A878 File Offset: 0x00019878
		// (set) Token: 0x060004C5 RID: 1221 RVA: 0x0001A880 File Offset: 0x00019880
		public string Heading
		{
			get
			{
				return this.xf9b06c19a78c9845;
			}
			set
			{
				if (value == null)
				{
					value = string.Empty;
				}
				this.xf9b06c19a78c9845 = value;
				base.MeasureNeeded();
			}
		}

		// Token: 0x1700012D RID: 301
		// (get) Token: 0x060004C6 RID: 1222 RVA: 0x0001A89C File Offset: 0x0001989C
		public int Margin
		{
			get
			{
				return this.x13ebc58426767551;
			}
		}

		// Token: 0x1700012E RID: 302
		// (get) Token: 0x060004C7 RID: 1223 RVA: 0x0001A8A4 File Offset: 0x000198A4
		public InnerGrid NestedGrid
		{
			get
			{
				return this.xeac23fcec638fed2;
			}
		}

		// Token: 0x0400016D RID: 365
		private const int x92f9a31429bc4fea = 18;

		// Token: 0x0400016E RID: 366
		private InnerGrid xeac23fcec638fed2;

		// Token: 0x0400016F RID: 367
		private int x13ebc58426767551 = 3;

		// Token: 0x04000170 RID: 368
		private int x52e33554e09d64f3;

		// Token: 0x04000171 RID: 369
		private string xf9b06c19a78c9845 = string.Empty;

		// Token: 0x04000172 RID: 370
		private Size xd3bc6541e91f9509;
	}
}
