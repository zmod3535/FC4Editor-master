using System;
using System.Windows;
using System.Windows.Documents;
using Divelements.SandRibbon.Primitives;

namespace Divelements.SandDock.InteractiveDocking
{
	// Token: 0x0200004B RID: 75
	internal class PositionPreviewAdorner : ControlHostAdorner
	{
		// Token: 0x060003D6 RID: 982 RVA: 0x00041F60 File Offset: 0x00040360
		static PositionPreviewAdorner()
		{
			UIElement.OpacityProperty.OverrideMetadata(typeof(PositionPreviewAdorner), new FrameworkPropertyMetadata(1.0));
		}

		// Token: 0x060003D7 RID: 983 RVA: 0x00041F8C File Offset: 0x0004038C
		public PositionPreviewAdorner(FrameworkElement elementToAdorn, PositionPreview preview) : base(elementToAdorn)
		{
			this.preview = preview;
		}

		// Token: 0x170000DE RID: 222
		// (get) Token: 0x060003D8 RID: 984 RVA: 0x00041F9C File Offset: 0x0004039C
		// (set) Token: 0x060003D9 RID: 985 RVA: 0x00041FA4 File Offset: 0x000403A4
		public Rect Bounds
		{
			get
			{
				return this.bounds;
			}
			set
			{
				this.bounds = value;
				base.InvalidateArrange();
			}
		}

		// Token: 0x060003DA RID: 986 RVA: 0x00041FB4 File Offset: 0x000403B4
		protected override Size ArrangeOverride(Size finalSize)
		{
			if (base.HostedControl != null)
			{
				base.HostedControl.Arrange(this.bounds);
			}
			return finalSize;
		}

		// Token: 0x060003DB RID: 987 RVA: 0x00041FD0 File Offset: 0x000403D0
		public void Add()
		{
			base.HostedControl = this.preview;
			AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(base.AdornedElement);
			if (adornerLayer != null)
			{
				adornerLayer.Add(this);
			}
		}

		// Token: 0x060003DC RID: 988 RVA: 0x00042000 File Offset: 0x00040400
		public void Remove()
		{
			AdornerLayer adornerLayer = base.VisualParent as AdornerLayer;
			if (adornerLayer != null)
			{
				adornerLayer.Remove(this);
			}
			base.HostedControl = null;
		}

		// Token: 0x040001A2 RID: 418
		private PositionPreview preview;

		// Token: 0x040001A3 RID: 419
		private Rect bounds;
	}
}
