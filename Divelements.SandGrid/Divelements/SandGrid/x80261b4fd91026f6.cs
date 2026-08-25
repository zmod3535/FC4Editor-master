using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace Divelements.SandGrid
{
	// Token: 0x0200006F RID: 111
	internal class x80261b4fd91026f6 : x59ac1f306ac0f29d
	{
		// Token: 0x0600061D RID: 1565 RVA: 0x0001FF9C File Offset: 0x0001EF9C
		public x80261b4fd91026f6(GridColumn column, Point startPoint) : base(column, startPoint)
		{
			this.xe3e287548b3d01f5 = column;
			this.x6afebf16b45c02e0 = startPoint;
			this.x8e80951f5e19e22d = (base.x03bb6a33fcd217b4.LiveResize && column.AutoSize != ColumnAutoSizeMode.Spring);
			this.x9c1820aac8bcb9d8 = (column.ResizeBehavior == ElementResizeBehavior.MaintainTotalWidth && column.AutoSize != ColumnAutoSizeMode.Spring);
			base.x7e153dc1ab2f9ad3 = false;
			this.xa6f49ba8ce5ae3db(startPoint, false);
			Cursor.Current = Cursors.VSplit;
		}

		// Token: 0x0600061E RID: 1566 RVA: 0x00020018 File Offset: 0x0001F018
		protected internal override void MouseMove(MouseEventArgs e)
		{
			this.xa6f49ba8ce5ae3db(new Point(e.X, e.Y), false);
			Cursor.Current = Cursors.VSplit;
		}

		// Token: 0x0600061F RID: 1567 RVA: 0x0002003C File Offset: 0x0001F03C
		private void xa6f49ba8ce5ae3db(Point x13d4cb8d1bd20347, bool x4877b29f469432c2)
		{
			ArrayList arrayList = new ArrayList();
			int num = x13d4cb8d1bd20347.X - this.x6afebf16b45c02e0.X;
			int num2 = 0;
			if (this.xe3e287548b3d01f5.Width + num < this.xe3e287548b3d01f5.MinimumWidth)
			{
				num2 = this.xe3e287548b3d01f5.MinimumWidth - this.xe3e287548b3d01f5.Width - num;
			}
			if (this.x9c1820aac8bcb9d8)
			{
				bool flag = ((uint)num2 & 0U) == 0U;
				if (!flag)
				{
					goto IL_10C;
				}
				if (this.xe3e287548b3d01f5.NextColumn != null && this.xe3e287548b3d01f5.NextColumn.Width - num < this.xe3e287548b3d01f5.NextColumn.MinimumWidth)
				{
					num2 = this.xe3e287548b3d01f5.NextColumn.Width - num - this.xe3e287548b3d01f5.NextColumn.MinimumWidth;
				}
			}
			num += num2;
			if (!this.x8e80951f5e19e22d && !x4877b29f469432c2)
			{
				base.x03bb6a33fcd217b4.VerticalMarkerPosition = x13d4cb8d1bd20347.X + num2;
				goto IL_17C;
			}
			this.xe3e287548b3d01f5.Width += num;
			arrayList.Add(this.xe3e287548b3d01f5);
			if (this.xe3e287548b3d01f5.AutoSize == ColumnAutoSizeMode.Spring)
			{
				this.x4c77aca2d74855f6(arrayList, num);
			}
			IL_10C:
			if (this.x9c1820aac8bcb9d8 && this.xe3e287548b3d01f5.NextColumn != null)
			{
				this.xe3e287548b3d01f5.NextColumn.Width -= num;
				arrayList.Add(this.xe3e287548b3d01f5.NextColumn);
			}
			this.x6afebf16b45c02e0 = new Point(x13d4cb8d1bd20347.X + num2, x13d4cb8d1bd20347.Y);
			IL_17C:
			foreach (object obj in arrayList)
			{
				GridColumn gridColumn = (GridColumn)obj;
				if (gridColumn.Grid != null && gridColumn.Grid.SandGrid != null)
				{
					gridColumn.Grid.SandGrid.OnColumnResized(new GridColumnEventArgs(gridColumn));
				}
			}
		}

		// Token: 0x06000620 RID: 1568 RVA: 0x00020244 File Offset: 0x0001F244
		private void x4c77aca2d74855f6(ArrayList xb709481aabc80e34, int xc6d8dd7bbbe22cf7)
		{
			ArrayList arrayList = new ArrayList();
			double num = 0.0;
			for (int i = this.xe3e287548b3d01f5.DisplayIndex + 1; i < base.x03bb6a33fcd217b4.Columns.DisplayColumns.Length; i++)
			{
				if (base.x03bb6a33fcd217b4.Columns.DisplayColumns[i].AutoSize == ColumnAutoSizeMode.Spring)
				{
					arrayList.Add(base.x03bb6a33fcd217b4.Columns.DisplayColumns[i]);
					num += base.x03bb6a33fcd217b4.Columns.DisplayColumns[i].x47ffa6f239bcee85;
				}
			}
			if ((double)xc6d8dd7bbbe22cf7 < num)
			{
				foreach (object obj in arrayList)
				{
					GridColumn gridColumn = (GridColumn)obj;
					double num2 = gridColumn.x47ffa6f239bcee85;
					num2 -= num2 / num * (double)xc6d8dd7bbbe22cf7;
					gridColumn.x339a6432324e0276(num2, false);
					xb709481aabc80e34.Add(gridColumn);
				}
			}
		}

		// Token: 0x06000621 RID: 1569 RVA: 0x00020354 File Offset: 0x0001F354
		protected internal override void Finished(Point position, bool cancelled)
		{
			base.x03bb6a33fcd217b4.VerticalMarkerPosition = -1;
			if (!cancelled)
			{
				this.xa6f49ba8ce5ae3db(position, true);
			}
		}

		// Token: 0x0400024E RID: 590
		private GridColumn xe3e287548b3d01f5;

		// Token: 0x0400024F RID: 591
		private Point x6afebf16b45c02e0;

		// Token: 0x04000250 RID: 592
		private bool x8e80951f5e19e22d;

		// Token: 0x04000251 RID: 593
		private bool x9c1820aac8bcb9d8;
	}
}
