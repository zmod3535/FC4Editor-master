using System;
using System.Drawing;
using System.Windows.Forms;

namespace Divelements.SandGrid
{
	// Token: 0x02000070 RID: 112
	internal class x3b1e2f322c5dd3fc : x59ac1f306ac0f29d
	{
		// Token: 0x06000622 RID: 1570 RVA: 0x00020370 File Offset: 0x0001F370
		public x3b1e2f322c5dd3fc(GridColumn baseColumn, Point startPoint) : base(baseColumn, startPoint)
		{
			this.xa7af9f855101dd73 = baseColumn;
			if ((Control.ModifierKeys & Keys.Control) != Keys.Control)
			{
				base.x03bb6a33fcd217b4.SelectedElements.Clear();
			}
			this.MouseMove(new MouseEventArgs(MouseButtons.Left, 0, startPoint.X, startPoint.Y, 0));
		}

		// Token: 0x06000623 RID: 1571 RVA: 0x000203D4 File Offset: 0x0001F3D4
		protected internal override void MouseMove(MouseEventArgs e)
		{
			if (this.xcd5695202deba00e == null)
			{
				this.xcd5695202deba00e = base.x03bb6a33fcd217b4.SelectedElements.ToArray();
			}
			base.x03bb6a33fcd217b4.x614e783eda4ed71f();
			try
			{
				GridElement gridElement = base.x03bb6a33fcd217b4.HitTest(new Point(e.X, this.xa7af9f855101dd73.Bounds.Y));
				GridColumn gridColumn = gridElement as GridColumn;
				if (gridColumn != null && gridColumn.Grid == base.x03bb6a33fcd217b4)
				{
					base.x03bb6a33fcd217b4.SelectedElements.x3522790e002e1ba4(this.xcd5695202deba00e);
					GridColumn[] x6e96c3657c96bbbe = GridColumn.x7fa2c2f1236c23b2(this.xa7af9f855101dd73, gridColumn);
					base.x03bb6a33fcd217b4.x12a83acc7c1ca827(x6e96c3657c96bbbe, true);
				}
			}
			finally
			{
				base.x03bb6a33fcd217b4.x06727b7d4fe7a302();
			}
		}

		// Token: 0x04000252 RID: 594
		private GridColumn xa7af9f855101dd73;

		// Token: 0x04000253 RID: 595
		private GridElement[] xcd5695202deba00e;
	}
}
