using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using Divelements.SandGrid.Rendering;

namespace Divelements.SandGrid
{
	// Token: 0x02000084 RID: 132
	internal class x29a0cbfd700e4b01 : x59ac1f306ac0f29d, x73d5582560af03ef
	{
		// Token: 0x0600064A RID: 1610 RVA: 0x00020DCC File Offset: 0x0001FDCC
		public x29a0cbfd700e4b01(GridElement element, Point startPoint) : base(element, startPoint)
		{
			this.xbd1a7bb3c9ba7cff = base.x03bb6a33fcd217b4.x699c923a60e155ff;
		}

		// Token: 0x0600064B RID: 1611 RVA: 0x00020DE8 File Offset: 0x0001FDE8
		protected internal override void MouseMove(MouseEventArgs e)
		{
			if (this.xbd1a7bb3c9ba7cff != null && !this.xbd1a7bb3c9ba7cff.IsExpansionVisible())
			{
				this.xda73fcb97c77d998 = Rectangle.Empty;
				base.x03bb6a33fcd217b4.x5e7a70d58e13247a();
				return;
			}
			if (this.xcd5695202deba00e == null)
			{
				this.xcd5695202deba00e = base.x03bb6a33fcd217b4.SelectedElements.ToArray();
			}
			int num = base.x03bb6a33fcd217b4.IsNested ? base.x03bb6a33fcd217b4.Bounds.Right : Math.Max(base.x03bb6a33fcd217b4.Bounds.Right, base.x03bb6a33fcd217b4.SandGrid.ClientRectangle.Width);
			int num2 = base.x03bb6a33fcd217b4.IsNested ? base.x03bb6a33fcd217b4.Bounds.Bottom : Math.Max(base.x03bb6a33fcd217b4.Bounds.Bottom, base.x03bb6a33fcd217b4.SandGrid.ClientRectangle.Height);
			int num3 = Math.Max(Math.Min(e.X, num - 1), base.x03bb6a33fcd217b4.Bounds.X);
			int num4 = Math.Max(Math.Min(e.Y, num2 - 1), base.x03bb6a33fcd217b4.Bounds.Y);
			this.xda73fcb97c77d998 = new Rectangle(Math.Min(base.xaf4e0fbe61814cf5.X, num3), Math.Min(base.xaf4e0fbe61814cf5.Y, num4), Math.Abs(base.xaf4e0fbe61814cf5.X - num3), Math.Abs(base.xaf4e0fbe61814cf5.Y - num4));
			base.x03bb6a33fcd217b4.x5e7a70d58e13247a();
			ArrayList arrayList = this.x1e9ab5d4aaefb7cd();
			base.x03bb6a33fcd217b4.x614e783eda4ed71f();
			try
			{
				base.x03bb6a33fcd217b4.SelectedElements.x3522790e002e1ba4(this.xcd5695202deba00e);
				bool flag = (Control.ModifierKeys & Keys.Control) == Keys.Control;
				foreach (object obj in arrayList)
				{
					GridElement gridElement = (GridElement)obj;
					if (flag)
					{
						gridElement.Selected = !gridElement.Selected;
					}
					else
					{
						gridElement.Selected = true;
					}
				}
			}
			finally
			{
				base.x03bb6a33fcd217b4.x06727b7d4fe7a302();
			}
		}

		// Token: 0x0600064C RID: 1612 RVA: 0x00021080 File Offset: 0x00020080
		private ArrayList x1e9ab5d4aaefb7cd()
		{
			ArrayList arrayList = new ArrayList();
			if (this.xbd1a7bb3c9ba7cff != null)
			{
				GridRow previousVisibleRow = this.xbd1a7bb3c9ba7cff;
				GridRow nextVisibleRow = this.xbd1a7bb3c9ba7cff;
				for (;;)
				{
					IL_B8:
					if (previousVisibleRow.Bounds.Y > this.xda73fcb97c77d998.Y)
					{
						if (previousVisibleRow.PreviousVisibleRow != null)
						{
							previousVisibleRow = previousVisibleRow.PreviousVisibleRow;
							continue;
						}
					}
					while (nextVisibleRow.Bounds.Bottom < this.xda73fcb97c77d998.Bottom && nextVisibleRow.NextVisibleRow != null)
					{
						nextVisibleRow = nextVisibleRow.NextVisibleRow;
					}
					if (previousVisibleRow == null || nextVisibleRow == null)
					{
						break;
					}
					GridRow gridRow = previousVisibleRow;
					for (;;)
					{
						if (gridRow.x93b1564fed45c05e().IntersectsWith(this.xda73fcb97c77d998))
						{
							if (base.x03bb6a33fcd217b4.SelectionGranularity == SelectionGranularity.Row)
							{
								arrayList.Add(gridRow);
							}
							else
							{
								foreach (GridColumn gridColumn in base.x03bb6a33fcd217b4.Columns.DisplayColumns)
								{
									if (gridRow.Cells.IsValidIndex(gridColumn.Index))
									{
										if (false)
										{
											goto IL_B8;
										}
										if (gridRow.Cells[gridColumn.Index].Bounds.IntersectsWith(this.xda73fcb97c77d998))
										{
											arrayList.Add(gridRow.Cells[gridColumn.Index]);
										}
									}
								}
							}
						}
						if (gridRow == nextVisibleRow)
						{
							return arrayList;
						}
						gridRow = gridRow.NextVisibleRow;
					}
				}
			}
			return arrayList;
		}

		// Token: 0x0600064D RID: 1613 RVA: 0x000211E8 File Offset: 0x000201E8
		public void x84b6f3c22477dacb(RenderingContext x0f7b23d1c393aed9)
		{
			x0f7b23d1c393aed9.Renderer.DrawRubberBandSelection(x0f7b23d1c393aed9.Graphics, this.xda73fcb97c77d998);
		}

		// Token: 0x0600064E RID: 1614 RVA: 0x00021204 File Offset: 0x00020204
		protected internal override void Finished(Point position, bool cancelled)
		{
			base.Finished(position, cancelled);
			if (base.x03bb6a33fcd217b4 != null)
			{
				base.x03bb6a33fcd217b4.x5e7a70d58e13247a();
			}
		}

		// Token: 0x0400028A RID: 650
		private Rectangle xda73fcb97c77d998;

		// Token: 0x0400028B RID: 651
		private GridRow xbd1a7bb3c9ba7cff;

		// Token: 0x0400028C RID: 652
		private GridElement[] xcd5695202deba00e;
	}
}
