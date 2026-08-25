using System;
using System.Collections;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace Divelements.SandRibbon.Primitives
{
	// Token: 0x0200004A RID: 74
	internal class ControlHostAdorner : Adorner
	{
		// Token: 0x060003CE RID: 974 RVA: 0x00041DF0 File Offset: 0x000401F0
		public ControlHostAdorner(FrameworkElement adornedElement) : base(adornedElement)
		{
		}

		// Token: 0x170000DB RID: 219
		// (get) Token: 0x060003CF RID: 975 RVA: 0x00041DFC File Offset: 0x000401FC
		// (set) Token: 0x060003D0 RID: 976 RVA: 0x00041E04 File Offset: 0x00040204
		public UIElement HostedControl
		{
			get
			{
				return this.hostedControl;
			}
			set
			{
				if (value != this.hostedControl)
				{
					if (this.hostedControl != null)
					{
						base.RemoveVisualChild(this.hostedControl);
						base.RemoveLogicalChild(this.hostedControl);
					}
					this.hostedControl = value;
					if (this.hostedControl != null)
					{
						base.AddVisualChild(this.hostedControl);
						base.AddLogicalChild(this.hostedControl);
					}
					base.InvalidateMeasure();
				}
			}
		}

		// Token: 0x170000DC RID: 220
		// (get) Token: 0x060003D1 RID: 977 RVA: 0x00041E68 File Offset: 0x00040268
		protected override IEnumerator LogicalChildren
		{
			get
			{
				if (this.hostedControl != null)
				{
					UIElement[] array = new UIElement[]
					{
						this.hostedControl
					};
					return array.GetEnumerator();
				}
				return base.LogicalChildren;
			}
		}

		// Token: 0x060003D2 RID: 978 RVA: 0x00041E9C File Offset: 0x0004029C
		protected override Size MeasureOverride(Size constraint)
		{
			if (this.hostedControl != null)
			{
				constraint = base.AdornedElement.RenderSize;
				this.hostedControl.Measure(constraint);
				return this.hostedControl.DesiredSize;
			}
			return base.MeasureOverride(constraint);
		}

		// Token: 0x060003D3 RID: 979 RVA: 0x00041ED4 File Offset: 0x000402D4
		protected override Size ArrangeOverride(Size finalSize)
		{
			if (this.hostedControl != null)
			{
				this.hostedControl.Arrange(new Rect(0.0, 0.0, base.AdornedElement.RenderSize.Width, base.AdornedElement.RenderSize.Height));
			}
			return finalSize;
		}

		// Token: 0x060003D4 RID: 980 RVA: 0x00041F34 File Offset: 0x00040334
		protected override Visual GetVisualChild(int index)
		{
			if (index == 0 && this.hostedControl != null)
			{
				return this.hostedControl;
			}
			return base.GetVisualChild(index);
		}

		// Token: 0x170000DD RID: 221
		// (get) Token: 0x060003D5 RID: 981 RVA: 0x00041F50 File Offset: 0x00040350
		protected override int VisualChildrenCount
		{
			get
			{
				if (this.hostedControl == null)
				{
					return 0;
				}
				return 1;
			}
		}

		// Token: 0x040001A1 RID: 417
		private UIElement hostedControl;
	}
}
