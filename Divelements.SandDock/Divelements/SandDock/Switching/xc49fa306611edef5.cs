using System;
using System.Windows.Documents;
using Divelements.SandRibbon.Primitives;

namespace Divelements.SandDock.Switching
{
	// Token: 0x02000061 RID: 97
	internal class xc49fa306611edef5 : PreviewWindowSwitcher
	{
		// Token: 0x06000498 RID: 1176 RVA: 0x00046974 File Offset: 0x00044D74
		public xc49fa306611edef5(DockSite dockSite) : base(dockSite)
		{
		}

		// Token: 0x06000499 RID: 1177 RVA: 0x00046980 File Offset: 0x00044D80
		protected override void OnStartedPreviewing()
		{
			this.x2d3f658f39475b2e = 0;
			this.x2327b783a47e3c7b = new QuickTabWindowSelector(this, base.WindowPreviews);
			this.x05eb1ed27333bc67 = new ControlHostAdorner(base.DockSite.DocumentContainer);
			this.x05eb1ed27333bc67.HostedControl = this.x2327b783a47e3c7b;
			AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(base.DockSite.DocumentContainer);
			adornerLayer.Add(this.x05eb1ed27333bc67);
			base.PreviewingWindow = base.WindowPreviews[0].Window;
			base.CaptureElement = this.x2327b783a47e3c7b;
			this.NextWindow();
		}

		// Token: 0x0600049A RID: 1178 RVA: 0x00046A10 File Offset: 0x00044E10
		protected override void OnStoppedPreviewing()
		{
			AdornerLayer adornerLayer = (AdornerLayer)this.x05eb1ed27333bc67.Parent;
			adornerLayer.Remove(this.x05eb1ed27333bc67);
			this.x2327b783a47e3c7b = null;
		}

		// Token: 0x0600049B RID: 1179 RVA: 0x00046A44 File Offset: 0x00044E44
		protected override void NextWindow()
		{
			this.x2d3f658f39475b2e++;
			if (this.x2d3f658f39475b2e >= base.WindowPreviews.Length)
			{
				this.x2d3f658f39475b2e = 0;
			}
			base.PreviewingWindow = base.WindowPreviews[this.x2d3f658f39475b2e].Window;
		}

		// Token: 0x0600049C RID: 1180 RVA: 0x00046A84 File Offset: 0x00044E84
		protected override void PreviousWindow()
		{
			this.x2d3f658f39475b2e--;
			if (this.x2d3f658f39475b2e < 0)
			{
				this.x2d3f658f39475b2e = base.WindowPreviews.Length - 1;
			}
			base.PreviewingWindow = base.WindowPreviews[this.x2d3f658f39475b2e].Window;
		}

		// Token: 0x04000202 RID: 514
		private QuickTabWindowSelector x2327b783a47e3c7b;

		// Token: 0x04000203 RID: 515
		private int x2d3f658f39475b2e;

		// Token: 0x04000204 RID: 516
		private ControlHostAdorner x05eb1ed27333bc67;
	}
}
