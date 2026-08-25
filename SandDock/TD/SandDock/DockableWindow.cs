using System;
using System.Drawing;
using System.Windows.Forms;

namespace TD.SandDock
{
	// Token: 0x0200005F RID: 95
	public class DockableWindow : DockControl
	{
		// Token: 0x06000534 RID: 1332 RVA: 0x00027D14 File Offset: 0x00026D14
		public DockableWindow()
		{
			this.x84eb05aa1ce8e247();
		}

		// Token: 0x06000535 RID: 1333 RVA: 0x00027D24 File Offset: 0x00026D24
		public DockableWindow(SandDockManager manager, Control control, string text) : base(manager, control, text)
		{
			this.x84eb05aa1ce8e247();
		}

		// Token: 0x06000536 RID: 1334 RVA: 0x00027D38 File Offset: 0x00026D38
		protected override DockingRules CreateDockingRules()
		{
			return new DockingRules(true, false, true);
		}

		// Token: 0x06000537 RID: 1335 RVA: 0x00027D44 File Offset: 0x00026D44
		public override void Open()
		{
			base.Open(WindowOpenMethod.OnScreenSelect);
		}

		// Token: 0x06000538 RID: 1336 RVA: 0x00027D50 File Offset: 0x00026D50
		private void x84eb05aa1ce8e247()
		{
			if (this.Text.Length == 0)
			{
				this.Text = "Dockable Window";
			}
			base.SetPositionMetaData(DockSituation.Docked, ContainerDockLocation.Right);
		}

		// Token: 0x1700014C RID: 332
		// (get) Token: 0x06000539 RID: 1337 RVA: 0x00027D74 File Offset: 0x00026D74
		protected override Size DefaultSize
		{
			get
			{
				return new Size(250, 400);
			}
		}
	}
}
