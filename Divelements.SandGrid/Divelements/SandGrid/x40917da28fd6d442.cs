using System;
using System.Drawing;
using System.Windows.Forms;

namespace Divelements.SandGrid
{
	// Token: 0x02000071 RID: 113
	internal class x40917da28fd6d442 : xeb9fc992b2fe99d0
	{
		// Token: 0x06000624 RID: 1572 RVA: 0x000204A8 File Offset: 0x0001F4A8
		public x40917da28fd6d442(GridElement element, Point startPoint) : base(element, startPoint)
		{
		}

		// Token: 0x06000625 RID: 1573 RVA: 0x000204B4 File Offset: 0x0001F4B4
		protected override bool DragStarted()
		{
			base.x03bb6a33fcd217b4.SandGrid.OnItemDrag(new ItemDragEventArgs(Control.MouseButtons, base.x2dcc7207ee287dbb));
			return true;
		}
	}
}
