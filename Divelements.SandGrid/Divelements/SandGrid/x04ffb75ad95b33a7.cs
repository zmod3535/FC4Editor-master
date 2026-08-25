using System;
using System.Drawing;
using System.Windows.Forms;

namespace Divelements.SandGrid
{
	// Token: 0x02000054 RID: 84
	internal class x04ffb75ad95b33a7 : xeb9fc992b2fe99d0
	{
		// Token: 0x06000544 RID: 1348 RVA: 0x0001B7DC File Offset: 0x0001A7DC
		public x04ffb75ad95b33a7(GridColumn column, Point startPoint) : base(column, startPoint)
		{
			this.xe3e287548b3d01f5 = column;
			if (column.Grid.SandGrid.PrimaryGrid.Columns.Contains(column))
			{
				this.x5142973d45b32e92 = column.Grid.SandGrid.x5142973d45b32e92;
			}
			column.x52d5887fb276a6ba = true;
		}

		// Token: 0x06000545 RID: 1349 RVA: 0x0001B834 File Offset: 0x0001A834
		protected override bool DragStarted()
		{
			return this.xe3e287548b3d01f5.AllowReorder || this.x5142973d45b32e92 != null;
		}

		// Token: 0x06000546 RID: 1350 RVA: 0x0001B854 File Offset: 0x0001A854
		protected internal override void MouseMove(MouseEventArgs e)
		{
			base.MouseMove(e);
			if (base.x29d093358ada69ba)
			{
				if (this.xe3e287548b3d01f5.AllowReorder)
				{
					this.x9d0a0339f0f25b5b(new Point(e.X, e.Y), false);
				}
				if (this.x5142973d45b32e92 != null)
				{
					this.x5142973d45b32e92.x73e47da3b48300b2(this.xe3e287548b3d01f5, Cursor.Position);
				}
			}
		}

		// Token: 0x06000547 RID: 1351 RVA: 0x0001B8B4 File Offset: 0x0001A8B4
		private bool x9d0a0339f0f25b5b(Point xfbf34718e704c6bc, bool x4558a3d2274deccf)
		{
			bool flag = false;
			int num = xfbf34718e704c6bc.X;
			int y = this.xe3e287548b3d01f5.Bounds.Top + this.xe3e287548b3d01f5.Bounds.Height / 2;
			if (xfbf34718e704c6bc.Y < this.xe3e287548b3d01f5.Bounds.Top)
			{
				goto IL_B5;
			}
			if (xfbf34718e704c6bc.Y <= this.xe3e287548b3d01f5.Bounds.Bottom + 15)
			{
				goto IL_CD;
			}
			if ((flag ? 1U : 0U) + (x4558a3d2274deccf ? 1U : 0U) >= 0U)
			{
				goto IL_B5;
			}
			goto IL_130;
			IL_07:
			bool flag2;
			GridColumn gridColumn;
			if (x4558a3d2274deccf)
			{
				if (flag2)
				{
					this.xe3e287548b3d01f5.xac8b6c0bf0d842f9(gridColumn.DisplayIndex);
				}
				else
				{
					this.xe3e287548b3d01f5.xac8b6c0bf0d842f9(gridColumn.DisplayIndex + 1);
				}
			}
			else
			{
				base.x03bb6a33fcd217b4.VerticalMarkerPosition = num;
			}
			flag = true;
			IL_52:
			base.x03bb6a33fcd217b4.xf3a047092bd321fb();
			if (x4558a3d2274deccf)
			{
				base.x03bb6a33fcd217b4.SandGrid.OnColumnsReordered(EventArgs.Empty);
			}
			return flag;
			IL_B5:
			y = this.xe3e287548b3d01f5.Bounds.Top - 15;
			IL_CD:
			gridColumn = (base.x03bb6a33fcd217b4.HitTest(new Point(num, y)) as GridColumn);
			if (gridColumn == null)
			{
				base.x03bb6a33fcd217b4.VerticalMarkerPosition = -1;
				goto IL_52;
			}
			flag2 = (xfbf34718e704c6bc.X < gridColumn.Bounds.Left + gridColumn.Bounds.Width / 2);
			if (flag2)
			{
				num = gridColumn.Bounds.Left;
				goto IL_07;
			}
			IL_130:
			num = gridColumn.Bounds.Right;
			goto IL_07;
		}

		// Token: 0x06000548 RID: 1352 RVA: 0x0001BA64 File Offset: 0x0001AA64
		protected internal override void Finished(Point position, bool cancelled)
		{
			this.xe3e287548b3d01f5.x52d5887fb276a6ba = false;
			base.x03bb6a33fcd217b4.VerticalMarkerPosition = -1;
			if (!cancelled)
			{
				bool flag = false;
				if (base.x29d093358ada69ba && this.xe3e287548b3d01f5.AllowReorder)
				{
					flag = this.x9d0a0339f0f25b5b(position, !cancelled);
				}
				if (base.x29d093358ada69ba && this.x5142973d45b32e92 != null)
				{
					this.x5142973d45b32e92.xe28f535d61c67e4a(cancelled || flag);
					return;
				}
				if (this.xe3e287548b3d01f5.Bounds.Contains(position))
				{
					this.xe3e287548b3d01f5.OnClick(EventArgs.Empty);
					return;
				}
			}
			else if (this.x5142973d45b32e92 != null)
			{
				this.x5142973d45b32e92.xe28f535d61c67e4a(true);
			}
		}

		// Token: 0x040001E5 RID: 485
		private GridColumn xe3e287548b3d01f5;

		// Token: 0x040001E6 RID: 486
		private SortBox x5142973d45b32e92;
	}
}
