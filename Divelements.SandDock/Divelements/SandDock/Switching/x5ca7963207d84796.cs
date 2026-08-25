using System;
using System.Windows.Documents;
using System.Windows.Input;
using Divelements.SandRibbon.Primitives;

namespace Divelements.SandDock.Switching
{
	// Token: 0x0200005F RID: 95
	internal class x5ca7963207d84796 : WindowSwitcher
	{
		// Token: 0x0600048C RID: 1164 RVA: 0x0004650C File Offset: 0x0004490C
		public x5ca7963207d84796(DockSite dockSite) : base(dockSite)
		{
			this.x76b3d9d2638e5ecd = new WhidbeyWindowSelector(this);
			this.x05eb1ed27333bc67 = new ControlHostAdorner(base.DockSite);
			this.x05eb1ed27333bc67.HostedControl = this.x76b3d9d2638e5ecd;
		}

		// Token: 0x0600048D RID: 1165 RVA: 0x00046544 File Offset: 0x00044944
		protected override void OnStarted()
		{
			if (base.DocumentWindows.Length != 0)
			{
				base.PreviewingWindow = base.DocumentWindows[0];
			}
			else
			{
				if (base.ToolWindows.Length == 0)
				{
					base.Stop();
					return;
				}
				base.PreviewingWindow = base.ToolWindows[0];
				this.xfe083897d528875f = true;
			}
			AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(base.DockSite.DocumentContainer);
			adornerLayer.Add(this.x05eb1ed27333bc67);
			base.CaptureElement = this.x76b3d9d2638e5ecd;
			this.NextWindow();
		}

		// Token: 0x0600048E RID: 1166 RVA: 0x000465C4 File Offset: 0x000449C4
		protected override void OnStopped()
		{
			AdornerLayer adornerLayer = (AdornerLayer)this.x05eb1ed27333bc67.Parent;
			adornerLayer.Remove(this.x05eb1ed27333bc67);
		}

		// Token: 0x0600048F RID: 1167 RVA: 0x000465F0 File Offset: 0x000449F0
		protected override void ProcessKeyDownEvent(KeyEventArgs e)
		{
			if (e.Key == Key.Up)
			{
				this.PreviousWindow();
				return;
			}
			if (e.Key == Key.Down)
			{
				this.NextWindow();
				return;
			}
			if (e.Key == Key.Left || e.Key == Key.Right)
			{
				if (this.xfe083897d528875f && base.DocumentWindows.Length > 0)
				{
					this.xfe083897d528875f = false;
				}
				else if (!this.xfe083897d528875f && base.ToolWindows.Length > 0)
				{
					this.xfe083897d528875f = true;
				}
				this.xb7be0c441a7bed6e();
				base.PreviewingWindow = (this.xfe083897d528875f ? base.ToolWindows[this.x850c130a68453ca6] : base.DocumentWindows[this.x850c130a68453ca6]);
				return;
			}
			base.ProcessKeyDownEvent(e);
		}

		// Token: 0x06000490 RID: 1168 RVA: 0x000466A4 File Offset: 0x00044AA4
		protected override void NextWindow()
		{
			this.x850c130a68453ca6++;
			this.xb7be0c441a7bed6e();
			base.PreviewingWindow = (this.xfe083897d528875f ? base.ToolWindows[this.x850c130a68453ca6] : base.DocumentWindows[this.x850c130a68453ca6]);
		}

		// Token: 0x06000491 RID: 1169 RVA: 0x000466E4 File Offset: 0x00044AE4
		protected override void PreviousWindow()
		{
			this.x850c130a68453ca6--;
			this.xb7be0c441a7bed6e();
			base.PreviewingWindow = (this.xfe083897d528875f ? base.ToolWindows[this.x850c130a68453ca6] : base.DocumentWindows[this.x850c130a68453ca6]);
		}

		// Token: 0x06000492 RID: 1170 RVA: 0x00046724 File Offset: 0x00044B24
		private void xb7be0c441a7bed6e()
		{
			if (this.xfe083897d528875f && this.x850c130a68453ca6 >= base.ToolWindows.Length)
			{
				this.x850c130a68453ca6 = 0;
				return;
			}
			if (!this.xfe083897d528875f && this.x850c130a68453ca6 >= base.DocumentWindows.Length)
			{
				this.x850c130a68453ca6 = 0;
				return;
			}
			if (this.xfe083897d528875f && this.x850c130a68453ca6 < 0)
			{
				this.x850c130a68453ca6 = base.ToolWindows.Length - 1;
				return;
			}
			if (!this.xfe083897d528875f && this.x850c130a68453ca6 < 0)
			{
				this.x850c130a68453ca6 = base.DocumentWindows.Length - 1;
			}
		}

		// Token: 0x040001FB RID: 507
		private ControlHostAdorner x05eb1ed27333bc67;

		// Token: 0x040001FC RID: 508
		private WhidbeyWindowSelector x76b3d9d2638e5ecd;

		// Token: 0x040001FD RID: 509
		private bool xfe083897d528875f;

		// Token: 0x040001FE RID: 510
		private int x850c130a68453ca6;
	}
}
