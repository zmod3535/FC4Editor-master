using System;
using System.Drawing;
using System.Windows.Forms;

namespace Divelements.SandGrid
{
	// Token: 0x02000073 RID: 115
	internal class x28c049b557a495a3 : x59ac1f306ac0f29d
	{
		// Token: 0x06000626 RID: 1574 RVA: 0x000204D8 File Offset: 0x0001F4D8
		public x28c049b557a495a3(GridCell baseCell, Point startPoint) : base(baseCell, startPoint)
		{
			this.x71e60bebf0ded509 = baseCell;
		}

		// Token: 0x06000627 RID: 1575 RVA: 0x000204EC File Offset: 0x0001F4EC
		protected internal override void MouseMove(MouseEventArgs e)
		{
			if (this.xcd5695202deba00e == null)
			{
				this.xcd5695202deba00e = base.x03bb6a33fcd217b4.SelectedElements.ToArray();
			}
			base.x03bb6a33fcd217b4.x614e783eda4ed71f();
			try
			{
				GridElement gridElement = base.x03bb6a33fcd217b4.HitTest(new Point(e.X, e.Y));
				GridCell gridCell = gridElement as GridCell;
				if (gridCell != null && gridCell.Grid == base.x03bb6a33fcd217b4)
				{
					base.x03bb6a33fcd217b4.SelectedElements.x3522790e002e1ba4(this.xcd5695202deba00e);
					GridCell[] x6e96c3657c96bbbe = GridCell.x38deb49e9be2c379(this.x71e60bebf0ded509, gridCell);
					base.x03bb6a33fcd217b4.x12a83acc7c1ca827(x6e96c3657c96bbbe, true);
				}
			}
			finally
			{
				base.x03bb6a33fcd217b4.x06727b7d4fe7a302();
			}
		}

		// Token: 0x04000258 RID: 600
		private GridCell x71e60bebf0ded509;

		// Token: 0x04000259 RID: 601
		private GridElement[] xcd5695202deba00e;
	}
}
