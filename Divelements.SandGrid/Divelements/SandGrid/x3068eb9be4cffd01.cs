using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace Divelements.SandGrid
{
	// Token: 0x0200007A RID: 122
	internal class x3068eb9be4cffd01 : xeb9fc992b2fe99d0
	{
		// Token: 0x06000637 RID: 1591 RVA: 0x0002081C File Offset: 0x0001F81C
		public x3068eb9be4cffd01(GridRow dragRow, Point startPoint) : base(dragRow, startPoint)
		{
			this.x3040c866fac95193 = dragRow.Grid;
			this.xbf6eab35f6427395 = (this.x3040c866fac95193.SelectedElements.Count != 0 && this.x3040c866fac95193.SelectedElements[0] is GridRow);
			if (this.xbf6eab35f6427395)
			{
				GridRow gridRow = (GridRow)this.x3040c866fac95193.SelectedElements[0];
				this.x2b2393de7979c3e0 = gridRow.ParentRow;
				foreach (object obj in this.x3040c866fac95193.SelectedElements)
				{
					GridElement gridElement = (GridElement)obj;
					GridRow gridRow2 = gridElement as GridRow;
					if (gridRow2 == null || gridRow2.ParentRow != this.x2b2393de7979c3e0)
					{
						this.xbf6eab35f6427395 = false;
						break;
					}
				}
			}
			GridRowCollection gridRowCollection = (dragRow.ParentRow != null) ? dragRow.ParentRow.NestedRows : dragRow.Grid.Rows;
			if (gridRowCollection.IsSorted)
			{
				this.xbf6eab35f6427395 = false;
			}
		}

		// Token: 0x06000638 RID: 1592 RVA: 0x00020950 File Offset: 0x0001F950
		protected override bool DragStarted()
		{
			return true;
		}

		// Token: 0x06000639 RID: 1593 RVA: 0x00020954 File Offset: 0x0001F954
		protected internal override void MouseMove(MouseEventArgs e)
		{
			base.MouseMove(e);
			if (base.x29d093358ada69ba && this.xbf6eab35f6427395)
			{
				this.xbf10baf7d7e0cf98(new Point(e.X, e.Y), false);
			}
		}

		// Token: 0x0600063A RID: 1594 RVA: 0x00020988 File Offset: 0x0001F988
		private void xbf10baf7d7e0cf98(Point xfbf34718e704c6bc, bool x4558a3d2274deccf)
		{
			int num;
			if (this.x3040c866fac95193.RowHighlightType == RowHighlightType.PrimaryColumnOnly)
			{
				num = xfbf34718e704c6bc.X;
				goto IL_177;
			}
			bool flag = (x4558a3d2274deccf ? 1U : 0U) > uint.MaxValue;
			if (!flag)
			{
				num = this.x3040c866fac95193.Bounds.Left;
				goto IL_177;
			}
			IL_26:
			GridRowCollection gridRowCollection = (this.x2b2393de7979c3e0 != null) ? this.x2b2393de7979c3e0.NestedRows : this.x3040c866fac95193.Rows;
			GridRow gridRow;
			int num2 = gridRow.Index;
			bool flag2;
			if (!flag2)
			{
				num2++;
			}
			ArrayList arrayList = new ArrayList();
			foreach (object obj in gridRowCollection)
			{
				GridRow gridRow2 = (GridRow)obj;
				if (gridRow2.Selected)
				{
					arrayList.Add(gridRow2);
				}
			}
			GridElement[] array = base.x03bb6a33fcd217b4.SelectedElements.ToArray();
			for (int i = arrayList.Count - 1; i >= 0; i--)
			{
				GridRow gridRow3 = (GridRow)arrayList[i];
				if (gridRow3.Index < num2)
				{
					num2--;
				}
				gridRowCollection.Remove(gridRow3);
				gridRowCollection.Insert(num2, gridRow3);
			}
			base.x03bb6a33fcd217b4.SelectedElements.x3522790e002e1ba4(array);
			base.x03bb6a33fcd217b4.SandGrid.OnRowsMoved(new ElementsMovedEventArgs(base.x03bb6a33fcd217b4, array));
			return;
			IL_177:
			int x = num;
			int num3 = xfbf34718e704c6bc.Y;
			GridElement gridElement = base.x03bb6a33fcd217b4.HitTest(new Point(x, num3));
			gridRow = (gridElement as GridRow);
			if (gridRow == null)
			{
				GridCell gridCell = gridElement as GridCell;
				if (gridCell != null)
				{
					gridRow = gridCell.ParentRow;
				}
			}
			if (gridRow != null && gridRow.ParentRow == this.x2b2393de7979c3e0)
			{
				flag2 = (xfbf34718e704c6bc.Y < gridRow.Bounds.Top + gridRow.Bounds.Height / 2);
				while (!flag2)
				{
					Rectangle bounds = gridRow.Bounds;
					if ((flag2 ? 1U : 0U) >= 0U)
					{
						num3 = bounds.Bottom;
						IL_229:
						if (x4558a3d2274deccf)
						{
							goto IL_26;
						}
						base.x03bb6a33fcd217b4.HorizontalMarkerPosition = num3;
						return;
					}
				}
				num3 = gridRow.Bounds.Top;
				goto IL_229;
			}
			base.x03bb6a33fcd217b4.HorizontalMarkerPosition = -1;
		}

		// Token: 0x0600063B RID: 1595 RVA: 0x00020BE8 File Offset: 0x0001FBE8
		protected internal override void Finished(Point position, bool cancelled)
		{
			base.x03bb6a33fcd217b4.HorizontalMarkerPosition = -1;
			if (!cancelled && this.xbf6eab35f6427395 && base.x29d093358ada69ba)
			{
				this.xbf10baf7d7e0cf98(position, !cancelled);
			}
		}

		// Token: 0x0400026B RID: 619
		private InnerGrid x3040c866fac95193;

		// Token: 0x0400026C RID: 620
		private bool xbf6eab35f6427395;

		// Token: 0x0400026D RID: 621
		private GridRow x2b2393de7979c3e0;
	}
}
