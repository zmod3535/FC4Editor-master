using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace Divelements.SandDock.Primitives
{
	// Token: 0x02000019 RID: 25
	public class WindowHierarchyPresenter : FrameworkElement
	{
		// Token: 0x06000205 RID: 517 RVA: 0x00038200 File Offset: 0x00036600
		static WindowHierarchyPresenter()
		{
			UIElement.ClipToBoundsProperty.OverrideMetadata(typeof(WindowHierarchyPresenter), new FrameworkPropertyMetadata(true));
		}

		// Token: 0x06000206 RID: 518 RVA: 0x00038224 File Offset: 0x00036624
		internal WindowHierarchyPresenter(DockSite dockSite)
		{
			if (dockSite == null)
			{
				throw new ArgumentNullException("dockSite");
			}
			this.dockSite = dockSite;
			this.leftPopupContainer = new PopupContainer(dockSite);
			DockPanel.SetDock(this.leftPopupContainer, Dock.Left);
			this.rightPopupContainer = new PopupContainer(dockSite);
			DockPanel.SetDock(this.rightPopupContainer, Dock.Right);
			this.topPopupContainer = new PopupContainer(dockSite);
			DockPanel.SetDock(this.topPopupContainer, Dock.Top);
			this.bottomPopupContainer = new PopupContainer(dockSite);
			DockPanel.SetDock(this.bottomPopupContainer, Dock.Bottom);
			base.AddVisualChild(this.leftPopupContainer);
			base.AddVisualChild(this.rightPopupContainer);
			base.AddVisualChild(this.topPopupContainer);
			base.AddVisualChild(this.bottomPopupContainer);
		}

		// Token: 0x06000207 RID: 519 RVA: 0x000382E8 File Offset: 0x000366E8
		private void RecreateSplitters()
		{
			this.recreatingSplitters = true;
			try
			{
				foreach (ResizeControlSplitter resizeControlSplitter in this.splitters)
				{
					base.RemoveVisualChild(resizeControlSplitter);
				}
				this.splitters = new ResizeControlSplitter[this.dockSite.SplitContainers.Count];
				for (int j = 0; j < this.dockSite.SplitContainers.Count; j++)
				{
					this.splitters[j] = new ResizeControlSplitter(this.dockSite, this.dockSite.SplitContainers[j]);
					Binding binding = new Binding();
					binding.Source = this.dockSite.SplitContainers[j];
					binding.Path = new PropertyPath(DockSite.DockProperty);
					binding.Mode = BindingMode.OneWay;
					this.splitters[j].SetBinding(DockPanel.DockProperty, binding);
					base.AddVisualChild(this.splitters[j]);
				}
				this.splittersDirty = false;
			}
			finally
			{
				this.recreatingSplitters = false;
			}
		}

		// Token: 0x06000208 RID: 520 RVA: 0x00038404 File Offset: 0x00036804
		internal void InvalidateSplitters()
		{
			this.splittersDirty = true;
		}

		// Token: 0x06000209 RID: 521 RVA: 0x00038410 File Offset: 0x00036810
		protected override Size MeasureOverride(Size constraint)
		{
			Size result = new Size(0.0, 0.0);
			if (!this.splittersDirty)
			{
				goto IL_1E2;
			}
			int num;
			double num2;
			if ((uint)num + (uint)num2 >= 0U)
			{
				this.RecreateSplitters();
				goto IL_1E2;
			}
			goto IL_293;
			IL_145:
			if (num >= this.dockSite.SplitContainers.Count)
			{
				if (this.Child != null)
				{
					Size availableSize = new Size(Math.Max(constraint.Width - result.Width, 0.0), Math.Max(constraint.Height - result.Height, 0.0));
					this.Child.Measure(availableSize);
				}
				return result;
			}
			Dock dock = DockSite.GetDock(this.dockSite.SplitContainers[num]);
			Size availableSize2 = new Size(Math.Max(constraint.Width - result.Width, 0.0), Math.Max(constraint.Height - result.Height, 0.0));
			this.dockSite.SplitContainers[num].Measure(availableSize2);
			num2 = 0.0;
			goto IL_293;
			IL_1E2:
			this.leftPopupContainer.Measure(constraint);
			this.rightPopupContainer.Measure(constraint);
			this.topPopupContainer.Measure(constraint);
			this.bottomPopupContainer.Measure(constraint);
			num = 0;
			goto IL_145;
			IL_293:
			if (!this.dockSite.Fullscreen)
			{
				if (dock == Dock.Right || dock == Dock.Left)
				{
					result.Width += (num2 = this.dockSite.SplitContainers[num].DesiredSize.Width);
				}
				else
				{
					result.Height += (num2 = this.dockSite.SplitContainers[num].DesiredSize.Height);
				}
			}
			availableSize2 = new Size(Math.Max(constraint.Width - result.Width, 0.0), Math.Max(constraint.Height - result.Height, 0.0));
			this.splitters[num].Measure(availableSize2);
			if (!this.dockSite.Fullscreen && num2 > 0.0)
			{
				if (dock == Dock.Right || dock == Dock.Left)
				{
					result.Width += this.splitters[num].DesiredSize.Width;
				}
				else
				{
					result.Height += this.splitters[num].DesiredSize.Height;
				}
			}
			num++;
			goto IL_145;
		}

		// Token: 0x0600020A RID: 522 RVA: 0x000386C8 File Offset: 0x00036AC8
		protected override Size ArrangeOverride(Size arrangeBounds)
		{
			Rect finalRect = new Rect(0.0, 0.0, arrangeBounds.Width, arrangeBounds.Height);
			this.leftPopupContainer.Arrange(new Rect(finalRect.X, finalRect.Y, this.leftPopupContainer.DesiredSize.Width, finalRect.Height));
			this.rightPopupContainer.Arrange(new Rect(finalRect.Right - this.rightPopupContainer.DesiredSize.Width, finalRect.Y, this.rightPopupContainer.DesiredSize.Width, finalRect.Height));
			this.topPopupContainer.Arrange(new Rect(finalRect.X, finalRect.Y, finalRect.Width, this.topPopupContainer.DesiredSize.Height));
			this.bottomPopupContainer.Arrange(new Rect(finalRect.X, finalRect.Bottom - this.bottomPopupContainer.DesiredSize.Height, finalRect.Width, this.bottomPopupContainer.DesiredSize.Height));
			int num = 0;
			foreach (object obj in this.dockSite.SplitContainers)
			{
				SplitContainer splitContainer = (SplitContainer)obj;
				double num2;
				double num3;
				double num4;
				switch (DockSite.GetDock(splitContainer))
				{
				case Dock.Left:
					num2 = (this.dockSite.Fullscreen ? 0.0 : splitContainer.DesiredSize.Width);
					splitContainer.Arrange(new Rect(finalRect.X, finalRect.Y, num2, finalRect.Height));
					num3 = ((num2 != 0.0) ? this.splitters[num].DesiredSize.Width : 0.0);
					this.splitters[num].Arrange(new Rect(finalRect.X + num2, finalRect.Y, num3, finalRect.Height));
					finalRect.X += num2 + num3;
					finalRect.Width -= num2 + num3;
					break;
				case Dock.Top:
					if (this.dockSite.Fullscreen)
					{
						num4 = 0.0;
						goto IL_254;
					}
					if ((uint)num2 + (uint)num2 <= 4294967295U)
					{
						goto IL_23A;
					}
					goto IL_29C;
				case Dock.Right:
				{
					num2 = (this.dockSite.Fullscreen ? 0.0 : splitContainer.DesiredSize.Width);
					splitContainer.Arrange(new Rect(finalRect.Right - num2, finalRect.Y, num2, finalRect.Height));
					double num5;
					if (num2 == 0.0)
					{
						num5 = 0.0;
					}
					else
					{
						Size desiredSize = this.splitters[num].DesiredSize;
						if ((uint)num < 0U)
						{
							goto IL_23A;
						}
						num5 = desiredSize.Width;
					}
					num3 = num5;
					this.splitters[num].Arrange(new Rect(finalRect.Right - num2 - num3, finalRect.Y, num3, finalRect.Height));
					finalRect.Width -= num2 + num3;
					break;
				}
				case Dock.Bottom:
					num2 = (this.dockSite.Fullscreen ? 0.0 : splitContainer.DesiredSize.Height);
					splitContainer.Arrange(new Rect(finalRect.X, finalRect.Bottom - num2, finalRect.Width, num2));
					num3 = ((num2 != 0.0) ? this.splitters[num].DesiredSize.Height : 0.0);
					this.splitters[num].Arrange(new Rect(finalRect.X, finalRect.Bottom - num2 - num3, finalRect.Width, num3));
					finalRect.Height -= num2 + num3;
					break;
				}
				IL_20D:
				num++;
				continue;
				IL_2A3:
				double num6;
				num3 = num6;
				this.splitters[num].Arrange(new Rect(finalRect.X, finalRect.Y + num2, finalRect.Width, num3));
				finalRect.Y += num2 + num3;
				finalRect.Height -= num2 + num3;
				goto IL_20D;
				IL_29C:
				Size desiredSize2;
				num6 = desiredSize2.Height;
				goto IL_2A3;
				IL_254:
				num2 = num4;
				splitContainer.Arrange(new Rect(finalRect.X, finalRect.Y, finalRect.Width, num2));
				if (num2 == 0.0)
				{
					num6 = 0.0;
					goto IL_2A3;
				}
				desiredSize2 = this.splitters[num].DesiredSize;
				goto IL_29C;
				IL_23A:
				num4 = splitContainer.DesiredSize.Height;
				goto IL_254;
			}
			if (this.Child != null)
			{
				this.Child.Arrange(finalRect);
			}
			this.clientBounds = finalRect;
			return arrangeBounds;
		}

		// Token: 0x0600020B RID: 523 RVA: 0x00038C10 File Offset: 0x00037010
		protected override Visual GetVisualChild(int index)
		{
			if (this.splittersDirty && !this.recreatingSplitters)
			{
				this.RecreateSplitters();
			}
			if (index < this.dockSite.SplitContainers.Count)
			{
				return this.dockSite.SplitContainers[index];
			}
			index -= this.dockSite.SplitContainers.Count;
			if (index < this.splitters.Length)
			{
				return this.splitters[index];
			}
			index -= this.splitters.Length;
			if (this.Child != null)
			{
				if (index == 0)
				{
					return this.Child;
				}
				index--;
			}
			if (index == 0)
			{
				return this.topPopupContainer;
			}
			if (index == 1)
			{
				return this.bottomPopupContainer;
			}
			if (index == 2)
			{
				return this.leftPopupContainer;
			}
			if (index == 3)
			{
				return this.rightPopupContainer;
			}
			index -= 4;
			throw new ArgumentOutOfRangeException("index");
		}

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x0600020C RID: 524 RVA: 0x00038CE0 File Offset: 0x000370E0
		protected override int VisualChildrenCount
		{
			get
			{
				if (this.splittersDirty && !this.recreatingSplitters)
				{
					this.RecreateSplitters();
				}
				return 4 + ((this.Child != null) ? 1 : 0) + this.dockSite.SplitContainers.Count + this.splitters.Length;
			}
		}

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x0600020D RID: 525 RVA: 0x00038D20 File Offset: 0x00037120
		// (set) Token: 0x0600020E RID: 526 RVA: 0x00038D28 File Offset: 0x00037128
		internal UIElement Child
		{
			get
			{
				return this.child;
			}
			set
			{
				if (value != this.child)
				{
					if (this.child != null)
					{
						base.RemoveVisualChild(this.child);
					}
					this.child = value;
					if (this.child != null)
					{
						base.AddVisualChild(this.child);
					}
				}
			}
		}

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x0600020F RID: 527 RVA: 0x00038D64 File Offset: 0x00037164
		public Rect ClientBounds
		{
			get
			{
				return this.clientBounds;
			}
		}

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x06000210 RID: 528 RVA: 0x00038D6C File Offset: 0x0003716C
		internal PopupContainer LeftPopupContainer
		{
			get
			{
				return this.leftPopupContainer;
			}
		}

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x06000211 RID: 529 RVA: 0x00038D74 File Offset: 0x00037174
		internal PopupContainer RightPopupContainer
		{
			get
			{
				return this.rightPopupContainer;
			}
		}

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x06000212 RID: 530 RVA: 0x00038D7C File Offset: 0x0003717C
		internal PopupContainer TopPopupContainer
		{
			get
			{
				return this.topPopupContainer;
			}
		}

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x06000213 RID: 531 RVA: 0x00038D84 File Offset: 0x00037184
		internal PopupContainer BottomPopupContainer
		{
			get
			{
				return this.bottomPopupContainer;
			}
		}

		// Token: 0x040000A0 RID: 160
		private UIElement child;

		// Token: 0x040000A1 RID: 161
		private DockSite dockSite;

		// Token: 0x040000A2 RID: 162
		private PopupContainer leftPopupContainer;

		// Token: 0x040000A3 RID: 163
		private PopupContainer topPopupContainer;

		// Token: 0x040000A4 RID: 164
		private PopupContainer rightPopupContainer;

		// Token: 0x040000A5 RID: 165
		private PopupContainer bottomPopupContainer;

		// Token: 0x040000A6 RID: 166
		private bool recreatingSplitters;

		// Token: 0x040000A7 RID: 167
		private bool splittersDirty;

		// Token: 0x040000A8 RID: 168
		private ResizeControlSplitter[] splitters = new ResizeControlSplitter[0];

		// Token: 0x040000A9 RID: 169
		private Rect clientBounds;
	}
}
