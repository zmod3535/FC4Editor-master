using System;
using System.Windows;
using System.Windows.Documents;
using Divelements.SandRibbon.Primitives;

namespace Divelements.SandDock.Switching
{
	// Token: 0x02000057 RID: 87
	internal class x5b48716de9a52566 : PreviewWindowSwitcher
	{
		// Token: 0x0600044E RID: 1102 RVA: 0x00044984 File Offset: 0x00042D84
		public x5b48716de9a52566(DockSite dockSite) : base(dockSite)
		{
		}

		// Token: 0x0600044F RID: 1103 RVA: 0x00044990 File Offset: 0x00042D90
		protected override void OnStartedPreviewing()
		{
			this.x2d3f658f39475b2e = 0;
			FrameworkElement frameworkElement = base.DockSite.DocumentContainer;
			if (!PreviewWindowSwitcher.DocumentsOnly)
			{
				frameworkElement = base.DockSite;
			}
			Point screenOrigin = frameworkElement.TransformToVisual(base.DockSite).Transform(new Point(0.0, frameworkElement.RenderSize.Height));
			this.x2327b783a47e3c7b = new Tab3DWindowSelector(this, base.WindowPreviews, frameworkElement.RenderSize, screenOrigin);
			this.x05eb1ed27333bc67 = new ControlHostAdorner(frameworkElement);
			this.x05eb1ed27333bc67.HostedControl = this.x2327b783a47e3c7b;
			AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(base.DockSite);
			adornerLayer.Add(this.x05eb1ed27333bc67);
			base.PreviewingWindow = base.WindowPreviews[0].Window;
			if (frameworkElement == base.DockSite.DocumentContainer)
			{
				frameworkElement.Opacity = 0.0;
			}
			base.CaptureElement = this.x2327b783a47e3c7b;
		}

		// Token: 0x06000450 RID: 1104 RVA: 0x00044A78 File Offset: 0x00042E78
		protected override void OnStoppedPreviewing()
		{
			this.x05eb1ed27333bc67.AdornedElement.Opacity = 1.0;
			this.x2327b783a47e3c7b.Stop();
		}

		// Token: 0x06000451 RID: 1105 RVA: 0x00044AA0 File Offset: 0x00042EA0
		internal void x06fe2f4431a29900()
		{
			AdornerLayer adornerLayer = (AdornerLayer)this.x05eb1ed27333bc67.Parent;
			adornerLayer.Remove(this.x05eb1ed27333bc67);
			this.x2327b783a47e3c7b = null;
			this.x05eb1ed27333bc67 = null;
		}

		// Token: 0x06000452 RID: 1106 RVA: 0x00044AD8 File Offset: 0x00042ED8
		protected override void NextWindow()
		{
			this.x2327b783a47e3c7b.BeginFlip(true);
			this.x2d3f658f39475b2e++;
			if (this.x2d3f658f39475b2e >= base.WindowPreviews.Length)
			{
				this.x2d3f658f39475b2e = 0;
			}
			base.PreviewingWindow = base.WindowPreviews[this.x2d3f658f39475b2e].Window;
		}

		// Token: 0x06000453 RID: 1107 RVA: 0x00044B30 File Offset: 0x00042F30
		protected override void PreviousWindow()
		{
			this.x2327b783a47e3c7b.BeginFlip(false);
			this.x2d3f658f39475b2e--;
			if (this.x2d3f658f39475b2e < 0)
			{
				this.x2d3f658f39475b2e = base.WindowPreviews.Length - 1;
			}
			base.PreviewingWindow = base.WindowPreviews[this.x2d3f658f39475b2e].Window;
		}

		// Token: 0x040001CB RID: 459
		private Tab3DWindowSelector x2327b783a47e3c7b;

		// Token: 0x040001CC RID: 460
		private int x2d3f658f39475b2e;

		// Token: 0x040001CD RID: 461
		private ControlHostAdorner x05eb1ed27333bc67;
	}
}
