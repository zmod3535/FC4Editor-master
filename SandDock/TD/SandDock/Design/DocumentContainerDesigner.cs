using System;
using System.ComponentModel;
using System.Drawing;

namespace TD.SandDock.Design
{
	// Token: 0x0200003C RID: 60
	internal class DocumentContainerDesigner : DockContainerDesigner
	{
		// Token: 0x0600048F RID: 1167 RVA: 0x00023890 File Offset: 0x00022890
		protected override bool GetHitTest(Point point)
		{
			point = this.x1f1a3b29d7ed7776.PointToClient(point);
			for (;;)
			{
				DocumentLayoutSystem documentLayoutSystem;
				Rectangle leftScrollButtonBounds;
				if (!false)
				{
					LayoutSystemBase layoutSystemAt = this.x1f1a3b29d7ed7776.GetLayoutSystemAt(point);
					if (!(layoutSystemAt is DocumentLayoutSystem))
					{
						goto IL_69;
					}
					documentLayoutSystem = (DocumentLayoutSystem)layoutSystemAt;
					leftScrollButtonBounds = documentLayoutSystem.LeftScrollButtonBounds;
					if (false)
					{
						goto IL_69;
					}
					goto IL_30;
				}
				IL_39:
				Rectangle rightScrollButtonBounds;
				if (rightScrollButtonBounds.Contains(point) || -2147483648 == 0)
				{
					break;
				}
				if (!false)
				{
					if (false)
					{
						continue;
					}
					goto IL_69;
				}
				IL_30:
				if (leftScrollButtonBounds.Contains(point))
				{
					break;
				}
				rightScrollButtonBounds = documentLayoutSystem.RightScrollButtonBounds;
				goto IL_39;
			}
			return true;
			IL_69:
			return base.GetHitTest(point);
		}

		// Token: 0x06000490 RID: 1168 RVA: 0x00023910 File Offset: 0x00022910
		public override void Initialize(IComponent component)
		{
			base.Initialize(component);
			this.x1f1a3b29d7ed7776 = (DockContainer)component;
		}

		// Token: 0x0400018B RID: 395
		private DockContainer x1f1a3b29d7ed7776;
	}
}
