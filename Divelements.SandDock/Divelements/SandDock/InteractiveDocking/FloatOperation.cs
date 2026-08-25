using System;
using System.Windows;
using Divelements.SandDock.Primitives;

namespace Divelements.SandDock.InteractiveDocking
{
	// Token: 0x0200004E RID: 78
	public class FloatOperation : DockingOperationBase
	{
		// Token: 0x060003E9 RID: 1001 RVA: 0x00042618 File Offset: 0x00040A18
		internal FloatOperation(DockSite dockSite, Rect bounds, bool draggingEntireWindow)
		{
			this.x7f72cb59f44fe44c = dockSite;
			this.xda73fcb97c77d998 = bounds;
			this.x24b4f2eb5ae48e93 = draggingEntireWindow;
		}

		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x060003EA RID: 1002 RVA: 0x00042638 File Offset: 0x00040A38
		internal override DockSituation x279bb9926f160988
		{
			get
			{
				return DockSituation.Floating;
			}
		}

		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x060003EB RID: 1003 RVA: 0x0004263C File Offset: 0x00040A3C
		public Rect Bounds
		{
			get
			{
				return this.xda73fcb97c77d998;
			}
		}

		// Token: 0x060003EC RID: 1004 RVA: 0x00042644 File Offset: 0x00040A44
		internal override bool x07fc84161e9632ab(DockableWindow xa096e9bd1fdbb4eb, out FrameworkElement x4bbc2c453c470189, out Rect xda73fcb97c77d998, out x4025ca48d3c65c4e x520d41bf4dc059d1)
		{
			x4bbc2c453c470189 = null;
			xda73fcb97c77d998 = this.xda73fcb97c77d998;
			x520d41bf4dc059d1 = x4025ca48d3c65c4e.x0c60a6a0825c8336;
			if (xa096e9bd1fdbb4eb.DockSituation == DockSituation.Floating && this.x24b4f2eb5ae48e93 && this.x7f72cb59f44fe44c.FloatingWindowDisplayStrategy == FloatingWindowDisplayStrategy.WpfWindow)
			{
				FloatingWindowAdapter floatingWindowAdapter = xd679d9fc970c8f10.x94eafc5f4a9a0734(xa096e9bd1fdbb4eb);
				floatingWindowAdapter.FloatingLocation = new Point(xda73fcb97c77d998.X, xda73fcb97c77d998.Y);
				return false;
			}
			x4bbc2c453c470189 = this.x7f72cb59f44fe44c;
			return true;
		}

		// Token: 0x060003ED RID: 1005 RVA: 0x000426AC File Offset: 0x00040AAC
		internal override void xb82fe19b24eb0010(WindowGroup x45e7b4f4ed4ddeb2)
		{
			x45e7b4f4ed4ddeb2.Float(this.xda73fcb97c77d998, WindowOpenMethod.OpenSelectActivate);
		}

		// Token: 0x060003EE RID: 1006 RVA: 0x000426BC File Offset: 0x00040ABC
		internal override void x84795d7d5447dcfc(SplitContainer xb400351c70c4d6d6)
		{
		}

		// Token: 0x040001A8 RID: 424
		private DockSite x7f72cb59f44fe44c;

		// Token: 0x040001A9 RID: 425
		private Rect xda73fcb97c77d998;

		// Token: 0x040001AA RID: 426
		private bool x24b4f2eb5ae48e93;
	}
}
