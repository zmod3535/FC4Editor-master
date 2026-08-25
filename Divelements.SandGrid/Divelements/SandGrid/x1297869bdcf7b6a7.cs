using System;
using System.Drawing;
using System.Windows.Forms;

namespace Divelements.SandGrid
{
	// Token: 0x02000079 RID: 121
	internal class x1297869bdcf7b6a7 : xeb9fc992b2fe99d0
	{
		// Token: 0x06000634 RID: 1588 RVA: 0x0002070C File Offset: 0x0001F70C
		public x1297869bdcf7b6a7(GridRow baseRow, Point startPoint) : base(baseRow, startPoint)
		{
			this.xbd1a7bb3c9ba7cff = baseRow;
		}

		// Token: 0x06000635 RID: 1589 RVA: 0x00020720 File Offset: 0x0001F720
		protected override bool DragStarted()
		{
			this.xcd5695202deba00e = base.x03bb6a33fcd217b4.SelectedElements.ToArray();
			return true;
		}

		// Token: 0x06000636 RID: 1590 RVA: 0x0002073C File Offset: 0x0001F73C
		protected internal override void MouseMove(MouseEventArgs e)
		{
			base.MouseMove(e);
			if (base.x29d093358ada69ba)
			{
				base.x03bb6a33fcd217b4.x614e783eda4ed71f();
				try
				{
					GridElement gridElement = base.x03bb6a33fcd217b4.HitTest(new Point(this.xbd1a7bb3c9ba7cff.Bounds.X, e.Y));
					GridRow gridRow = gridElement as GridRow;
					if (gridRow == null && gridElement is GridCell)
					{
						gridRow = ((GridCell)gridElement).ParentRow;
					}
					if (gridRow != null && gridRow.Grid == base.x03bb6a33fcd217b4)
					{
						base.x03bb6a33fcd217b4.SelectedElements.x3522790e002e1ba4(this.xcd5695202deba00e);
						GridRow[] x6e96c3657c96bbbe = GridRow.x0cec1fc9c22db728(this.xbd1a7bb3c9ba7cff, gridRow);
						base.x03bb6a33fcd217b4.x12a83acc7c1ca827(x6e96c3657c96bbbe, true);
					}
				}
				finally
				{
					base.x03bb6a33fcd217b4.x06727b7d4fe7a302();
				}
			}
		}

		// Token: 0x04000269 RID: 617
		private GridRow xbd1a7bb3c9ba7cff;

		// Token: 0x0400026A RID: 618
		private GridElement[] xcd5695202deba00e;
	}
}
