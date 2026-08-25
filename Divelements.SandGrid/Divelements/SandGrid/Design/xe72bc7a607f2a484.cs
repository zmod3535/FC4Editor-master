using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms.Design;

namespace Divelements.SandGrid.Design
{
	// Token: 0x020000A7 RID: 167
	internal class xe72bc7a607f2a484 : ControlDesigner
	{
		// Token: 0x060007B9 RID: 1977 RVA: 0x000259D0 File Offset: 0x000249D0
		public override void Initialize(IComponent component)
		{
			base.Initialize(component);
		}

		// Token: 0x060007BA RID: 1978 RVA: 0x000259DC File Offset: 0x000249DC
		protected override bool GetHitTest(Point point)
		{
			int num = x443cc432acaadb1d.SendMessage(this.Control.Handle, 132, 0, x443cc432acaadb1d.xdc9f9b153aa69c51(point.X, point.Y));
			if (num == 6 || num == 7)
			{
				return true;
			}
			point = this.Control.PointToClient(point);
			if (this.xbd3e0f549461827f.PrimaryGrid.FixColumnHeaders && point.Y <= this.xbd3e0f549461827f.PrimaryGrid.x5d332e6bd470be29)
			{
				return true;
			}
			if (this.Control.Capture)
			{
				return true;
			}
			if (this.xbd3e0f549461827f.PrimaryGrid.ShowTreeButtons)
			{
				Point position = this.xbd3e0f549461827f.PointToGrid(point);
				GridRow gridRow = this.xbd3e0f549461827f.GetElementAt(position) as GridRow;
				if (gridRow != null && gridRow.x0d0b65ba2307e88a().Contains(position.X, position.Y))
				{
					return true;
				}
			}
			return base.GetHitTest(point);
		}

		// Token: 0x170001EF RID: 495
		// (get) Token: 0x060007BB RID: 1979 RVA: 0x00025AC4 File Offset: 0x00024AC4
		private SandGridBase xbd3e0f549461827f
		{
			get
			{
				return this.Control as SandGridBase;
			}
		}
	}
}
