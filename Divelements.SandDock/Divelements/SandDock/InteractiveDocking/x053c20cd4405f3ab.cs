using System;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Animation;
using Divelements.SandDock.Primitives;
using Divelements.SandRibbon.Primitives;

namespace Divelements.SandDock.InteractiveDocking
{
	// Token: 0x02000042 RID: 66
	internal class x053c20cd4405f3ab
	{
		// Token: 0x0600039F RID: 927 RVA: 0x00040CD0 File Offset: 0x0003F0D0
		public x053c20cd4405f3ab(DockSite dockSite, DockingHintDisplayStrategy displayStrategy, DockingHintType dockingHintType, DockingRules rules, FrameworkElement justifyElement)
		{
			this.x7f72cb59f44fe44c = dockSite;
			this.xc1a936e965500407 = displayStrategy;
			this.xcaa4fa77be319dd8 = dockingHintType;
			this.x4460eabedccc2f49 = justifyElement;
			this.xeb487a5f2b63c3d8 = new DockingHint(dockSite, dockingHintType, rules);
			if (displayStrategy == DockingHintDisplayStrategy.Adorners)
			{
				this.x05eb1ed27333bc67 = new ControlHostAdorner(justifyElement);
				this.x05eb1ed27333bc67.HostedControl = this.xeb487a5f2b63c3d8;
				this.x05eb1ed27333bc67.Opacity = 0.0;
				return;
			}
			this.xd70b090e3181abff = new Popup();
			this.xd70b090e3181abff.Child = this.xeb487a5f2b63c3d8;
			this.xd70b090e3181abff.PopupAnimation = PopupAnimation.Fade;
			this.xd70b090e3181abff.AllowsTransparency = true;
			switch (dockingHintType)
			{
			case DockingHintType.LeftWindowEdge:
			case DockingHintType.RightWindowEdge:
			case DockingHintType.TopWindowEdge:
			case DockingHintType.BottomWindowEdge:
				this.xd70b090e3181abff.Placement = PlacementMode.Custom;
				this.xd70b090e3181abff.CustomPopupPlacementCallback = new CustomPopupPlacementCallback(this.xc4fc8c93279540ab);
				return;
			default:
				this.xd70b090e3181abff.Placement = PlacementMode.Center;
				return;
			}
		}

		// Token: 0x170000CD RID: 205
		// (get) Token: 0x060003A0 RID: 928 RVA: 0x00040DC8 File Offset: 0x0003F1C8
		// (set) Token: 0x060003A1 RID: 929 RVA: 0x00040DD8 File Offset: 0x0003F1D8
		public WindowGroup xba4e4c184d813a0d
		{
			get
			{
				return this.xeb487a5f2b63c3d8.WindowGroup;
			}
			set
			{
				this.xeb487a5f2b63c3d8.WindowGroup = value;
			}
		}

		// Token: 0x060003A2 RID: 930 RVA: 0x00040DE8 File Offset: 0x0003F1E8
		private CustomPopupPlacement[] xc4fc8c93279540ab(Size x5614e4ef0596c91d, Size x18083f4304fe7f89, Point x374ea4fe62468d0f)
		{
			switch (this.xcaa4fa77be319dd8)
			{
			case DockingHintType.LeftWindowEdge:
				return new CustomPopupPlacement[]
				{
					new CustomPopupPlacement(new Point(0.0, x18083f4304fe7f89.Height / 2.0 - x5614e4ef0596c91d.Height / 2.0), PopupPrimaryAxis.None)
				};
			case DockingHintType.RightWindowEdge:
				return new CustomPopupPlacement[]
				{
					new CustomPopupPlacement(new Point(x18083f4304fe7f89.Width - x5614e4ef0596c91d.Width - this.xeb487a5f2b63c3d8.Margin.Left - this.xeb487a5f2b63c3d8.Margin.Right, x18083f4304fe7f89.Height / 2.0 - x5614e4ef0596c91d.Height / 2.0), PopupPrimaryAxis.None)
				};
			case DockingHintType.TopWindowEdge:
				return new CustomPopupPlacement[]
				{
					new CustomPopupPlacement(new Point(x18083f4304fe7f89.Width / 2.0 - x5614e4ef0596c91d.Width / 2.0, 0.0), PopupPrimaryAxis.None)
				};
			case DockingHintType.BottomWindowEdge:
				return new CustomPopupPlacement[]
				{
					new CustomPopupPlacement(new Point(x18083f4304fe7f89.Width / 2.0 - x5614e4ef0596c91d.Width / 2.0, x18083f4304fe7f89.Height - x5614e4ef0596c91d.Height - this.xeb487a5f2b63c3d8.Margin.Top - this.xeb487a5f2b63c3d8.Margin.Bottom), PopupPrimaryAxis.None)
				};
			default:
				throw new NotImplementedException();
			}
		}

		// Token: 0x060003A3 RID: 931 RVA: 0x00040FB0 File Offset: 0x0003F3B0
		public DockingOperationBase xc5a140008c7e32aa(MouseEventArgs xfbf34718e704c6bc)
		{
			return this.xeb487a5f2b63c3d8.GetDockTargetFromMousePosition(xfbf34718e704c6bc);
		}

		// Token: 0x170000CE RID: 206
		// (get) Token: 0x060003A4 RID: 932 RVA: 0x00040FC0 File Offset: 0x0003F3C0
		// (set) Token: 0x060003A5 RID: 933 RVA: 0x00040FC8 File Offset: 0x0003F3C8
		public bool x3452082a8fecf97d
		{
			get
			{
				return this.xe24ae256293e16b6;
			}
			set
			{
				if (value != this.xe24ae256293e16b6)
				{
					if (this.xc1a936e965500407 == DockingHintDisplayStrategy.Adorners)
					{
						DoubleAnimation animation = value ? new DoubleAnimation(1.0, new Duration(TimeSpan.FromMilliseconds(200.0))) : new DoubleAnimation(0.0, new Duration(TimeSpan.FromMilliseconds(200.0)));
						this.x05eb1ed27333bc67.BeginAnimation(UIElement.OpacityProperty, animation);
					}
					else
					{
						this.xd70b090e3181abff.IsOpen = value;
					}
					this.xe24ae256293e16b6 = value;
				}
			}
		}

		// Token: 0x060003A6 RID: 934 RVA: 0x00041058 File Offset: 0x0003F458
		public void xd6b6ed77479ef68c()
		{
			if (this.xc1a936e965500407 == DockingHintDisplayStrategy.Adorners)
			{
				AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(this.x4460eabedccc2f49);
				if (adornerLayer != null)
				{
					adornerLayer.Add(this.x05eb1ed27333bc67);
					return;
				}
			}
			else
			{
				this.xd70b090e3181abff.PlacementTarget = this.x4460eabedccc2f49;
			}
		}

		// Token: 0x060003A7 RID: 935 RVA: 0x0004109C File Offset: 0x0003F49C
		public void x52b190e626f65140()
		{
			this.x3452082a8fecf97d = false;
			if (this.xc1a936e965500407 == DockingHintDisplayStrategy.Adorners)
			{
				AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(this.x4460eabedccc2f49);
				if (adornerLayer != null)
				{
					adornerLayer.Remove(this.x05eb1ed27333bc67);
					return;
				}
			}
			else
			{
				this.xd70b090e3181abff.PlacementTarget = null;
			}
		}

		// Token: 0x0400017F RID: 383
		private DockSite x7f72cb59f44fe44c;

		// Token: 0x04000180 RID: 384
		private DockingHintDisplayStrategy xc1a936e965500407;

		// Token: 0x04000181 RID: 385
		private DockingHintType xcaa4fa77be319dd8;

		// Token: 0x04000182 RID: 386
		private FrameworkElement x4460eabedccc2f49;

		// Token: 0x04000183 RID: 387
		private DockingHint xeb487a5f2b63c3d8;

		// Token: 0x04000184 RID: 388
		private ControlHostAdorner x05eb1ed27333bc67;

		// Token: 0x04000185 RID: 389
		private Popup xd70b090e3181abff;

		// Token: 0x04000186 RID: 390
		private bool xe24ae256293e16b6;
	}
}
