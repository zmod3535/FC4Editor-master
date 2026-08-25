using System;
using System.Drawing;
using System.Windows.Forms;
using Divelements.SandGrid.Rendering;

namespace Divelements.SandGrid.Specialized
{
	// Token: 0x0200009B RID: 155
	public class GridHyperlinkCell : GridButtonCell
	{
		// Token: 0x060006FD RID: 1789 RVA: 0x000232FC File Offset: 0x000222FC
		public GridHyperlinkCell()
		{
		}

		// Token: 0x060006FE RID: 1790 RVA: 0x00023304 File Offset: 0x00022304
		public GridHyperlinkCell(string text) : base(text)
		{
		}

		// Token: 0x060006FF RID: 1791 RVA: 0x00023310 File Offset: 0x00022310
		protected internal override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			if (base.DrawButton)
			{
				Cursor.Current = Cursors.Hand;
			}
		}

		// Token: 0x06000700 RID: 1792 RVA: 0x0002332C File Offset: 0x0002232C
		protected internal override void Draw(RenderingContext context, Font rowFont, bool rowSelected, TextFormattingInformation textFormat)
		{
			if (base.BackColor != Color.Transparent)
			{
				using (SolidBrush solidBrush = new SolidBrush(base.BackColor))
				{
					context.Graphics.FillRectangle(solidBrush, base.Bounds);
				}
			}
			if (base.DrawButton)
			{
				if (base.Selected)
				{
					rowSelected = true;
				}
				if (base.BackColor != Color.Transparent)
				{
					using (SolidBrush solidBrush2 = new SolidBrush(base.BackColor))
					{
						context.Graphics.FillRectangle(solidBrush2, base.Bounds);
					}
				}
				if ((base.Selected || base.Grid.SandGrid.FocusedElement == this) && !context.HideSelection)
				{
					context.Renderer.DrawSelectionRectangle(context.Graphics, base.SelectionBounds, base.Selected, context.ContainsFocus, base.Grid.SandGrid.FocusedElement == this && context.FocusRectanglesEnabled);
				}
				Color cellForeColor = base.ForeColor;
				GridHyperlinkColumn gridHyperlinkColumn = base.ParentColumn as GridHyperlinkColumn;
				if (gridHyperlinkColumn != null)
				{
					if (base.Hover)
					{
						cellForeColor = gridHyperlinkColumn.LinkHotColor;
					}
					else
					{
						cellForeColor = gridHyperlinkColumn.LinkNormalColor;
					}
				}
				base.ParentColumn.DrawCell(context, base.ParentRow, base.GetValue(), base.Font, this.Image, base.ContentBounds, rowSelected, textFormat, cellForeColor);
			}
		}
	}
}
