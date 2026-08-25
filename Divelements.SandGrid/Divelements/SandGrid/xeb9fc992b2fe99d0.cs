using System;
using System.Drawing;
using System.Windows.Forms;

namespace Divelements.SandGrid
{
	// Token: 0x02000055 RID: 85
	internal abstract class xeb9fc992b2fe99d0 : x59ac1f306ac0f29d
	{
		// Token: 0x06000549 RID: 1353 RVA: 0x0001BB10 File Offset: 0x0001AB10
		protected xeb9fc992b2fe99d0(GridElement element, Point startPoint) : base(element, startPoint)
		{
		}

		// Token: 0x0600054A RID: 1354 RVA: 0x0001BB1C File Offset: 0x0001AB1C
		protected internal override void MouseMove(MouseEventArgs e)
		{
			if (!this.xc328ed5b6726ffb9)
			{
				Rectangle rectangle = new Rectangle(base.xaf4e0fbe61814cf5.X, base.xaf4e0fbe61814cf5.Y, 0, 0);
				rectangle.Inflate(SystemInformation.DragSize.Width, SystemInformation.DragSize.Height);
				if (!rectangle.Contains(e.X, e.Y))
				{
					if (this.DragStarted())
					{
						this.xaf03954a71e84895 = true;
					}
					this.xc328ed5b6726ffb9 = true;
				}
			}
		}

		// Token: 0x0600054B RID: 1355
		protected abstract bool DragStarted();

		// Token: 0x1700014F RID: 335
		// (get) Token: 0x0600054C RID: 1356 RVA: 0x0001BBA4 File Offset: 0x0001ABA4
		public bool x29d093358ada69ba
		{
			get
			{
				return this.xaf03954a71e84895;
			}
		}

		// Token: 0x040001E7 RID: 487
		private bool xaf03954a71e84895;

		// Token: 0x040001E8 RID: 488
		private bool xc328ed5b6726ffb9;
	}
}
