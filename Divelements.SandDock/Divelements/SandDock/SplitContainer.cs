using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using Divelements.SandDock.Primitives;

namespace Divelements.SandDock
{
	// Token: 0x0200000C RID: 12
	[ContentProperty("Children")]
	public class SplitContainer : FrameworkElement
	{
		// Token: 0x14000008 RID: 8
		// (add) Token: 0x060000C1 RID: 193 RVA: 0x000335B4 File Offset: 0x000319B4
		// (remove) Token: 0x060000C2 RID: 194 RVA: 0x000335EC File Offset: 0x000319EC
		internal event EventHandler ChildrenChanged;

		// Token: 0x060000C3 RID: 195 RVA: 0x00033624 File Offset: 0x00031A24
		static SplitContainer()
		{
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(SplitContainer), new FrameworkPropertyMetadata(typeof(SplitContainer)));
			SplitContainer.SplitterOrientationProperty = DependencyProperty.Register("SplitterOrientation", typeof(Orientation), typeof(SplitContainer), new FrameworkPropertyMetadata(Orientation.Horizontal, FrameworkPropertyMetadataOptions.None, new PropertyChangedCallback(SplitContainer.OnSplitterOrientationChanged)));
			SplitContainer.WorkingSizeProperty = DependencyProperty.RegisterAttached("WorkingSize", typeof(Size), typeof(SplitContainer), new FrameworkPropertyMetadata(new Size(240.0, 180.0), FrameworkPropertyMetadataOptions.AffectsParentMeasure, new PropertyChangedCallback(SplitContainer.OnWorkingSizeChanged)));
			SplitContainer.IsRootPropertyKey = DependencyProperty.RegisterReadOnly("IsRoot", typeof(bool), typeof(SplitContainer), new FrameworkPropertyMetadata(false));
			SplitContainer.IsRootProperty = SplitContainer.IsRootPropertyKey.DependencyProperty;
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x00033720 File Offset: 0x00031B20
		public SplitContainer()
		{
			this.children = new FrameworkElementCollection(this);
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x0003374C File Offset: 0x00031B4C
		internal WindowGroup CreateWindowGroup()
		{
			return new WindowGroup();
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x00033754 File Offset: 0x00031B54
		internal WindowGroup CreateWindowGroup(DockableWindow[] windows)
		{
			return new WindowGroup(windows);
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x0003375C File Offset: 0x00031B5C
		internal virtual void OnChildrenChanged(EventArgs e)
		{
			if (this.ChildrenChanged != null)
			{
				this.ChildrenChanged(this, e);
			}
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x00033774 File Offset: 0x00031B74
		internal void NotifyChildrenChanging()
		{
			this.splittersDirty = true;
			base.InvalidateMeasure();
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x00033784 File Offset: 0x00031B84
		internal void NotifyChildrenChanged()
		{
			this.splittersDirty = true;
			base.InvalidateMeasure();
			this.OnChildrenChanged(EventArgs.Empty);
		}

		// Token: 0x060000CA RID: 202 RVA: 0x000337A0 File Offset: 0x00031BA0
		internal static void PropagateDockSituationChanged(SplitContainer container)
		{
			foreach (object obj in container.Children)
			{
				FrameworkElement frameworkElement = (FrameworkElement)obj;
				SplitContainer splitContainer = frameworkElement as SplitContainer;
				if (splitContainer != null)
				{
					SplitContainer.PropagateDockSituationChanged(splitContainer);
				}
				WindowGroup windowGroup = frameworkElement as WindowGroup;
				if (windowGroup != null)
				{
					WindowGroup.PropagateDockSituationChanged(windowGroup);
				}
			}
		}

		// Token: 0x060000CB RID: 203 RVA: 0x00033824 File Offset: 0x00031C24
		internal void AddVisualChildInternal(Visual child)
		{
			base.AddVisualChild(child);
		}

		// Token: 0x060000CC RID: 204 RVA: 0x00033830 File Offset: 0x00031C30
		internal void RemoveVisualChildInternal(Visual child)
		{
			base.RemoveVisualChild(child);
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x060000CD RID: 205 RVA: 0x0003383C File Offset: 0x00031C3C
		protected override IEnumerator LogicalChildren
		{
			get
			{
				return this.Children.GetEnumerator();
			}
		}

		// Token: 0x060000CE RID: 206 RVA: 0x0003384C File Offset: 0x00031C4C
		internal void OnDescendantPinnedChanged()
		{
			this.splittersDirty = true;
			base.InvalidateMeasure();
			SplitContainer splitContainer = base.VisualParent as SplitContainer;
			if (splitContainer != null)
			{
				splitContainer.OnDescendantPinnedChanged();
			}
		}

		// Token: 0x060000CF RID: 207 RVA: 0x0003387C File Offset: 0x00031C7C
		private static bool ShouldParticipateInLayout(UIElement element)
		{
			SplitContainer splitContainer = element as SplitContainer;
			if (splitContainer != null)
			{
				foreach (object obj in splitContainer.Children)
				{
					UIElement element2 = (UIElement)obj;
					if (SplitContainer.ShouldParticipateInLayout(element2))
					{
						return true;
					}
				}
				return false;
			}
			WindowGroup windowGroup = element as WindowGroup;
			return windowGroup == null || windowGroup.Pinned;
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x00033910 File Offset: 0x00031D10
		internal void RecordMetaData()
		{
			foreach (object obj in this.Children)
			{
				UIElement uielement = (UIElement)obj;
				WindowGroup windowGroup = uielement as WindowGroup;
				if (windowGroup != null)
				{
					windowGroup.RecordMetaData();
				}
				SplitContainer splitContainer = uielement as SplitContainer;
				if (splitContainer != null)
				{
					splitContainer.RecordMetaData();
				}
			}
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x00033994 File Offset: 0x00031D94
		private static void OnWorkingSizeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			UIElement uielement = d as UIElement;
			if (uielement != null)
			{
				WindowGroup windowGroup = uielement as WindowGroup;
				if (windowGroup != null)
				{
					switch (xd679d9fc970c8f10.xb666df934bf80a36(windowGroup))
					{
					case DockSituation.Docked:
					case DockSituation.Document:
						windowGroup.RecordMetaData();
						break;
					default:
						return;
					}
				}
			}
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x000339D4 File Offset: 0x00031DD4
		[AttachedPropertyBrowsableForChildren]
		public static Size GetWorkingSize(UIElement element)
		{
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			return (Size)element.GetValue(SplitContainer.WorkingSizeProperty);
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x000339F4 File Offset: 0x00031DF4
		public static void SetWorkingSize(UIElement element, Size size)
		{
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			element.SetValue(SplitContainer.WorkingSizeProperty, size);
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x060000D4 RID: 212 RVA: 0x00033A18 File Offset: 0x00031E18
		// (set) Token: 0x060000D5 RID: 213 RVA: 0x00033A2C File Offset: 0x00031E2C
		internal double ContentSize
		{
			get
			{
				return (double)base.GetValue(DockSite.ContentSizeProperty);
			}
			set
			{
				base.SetValue(DockSite.ContentSizeProperty, value);
			}
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x060000D6 RID: 214 RVA: 0x00033A40 File Offset: 0x00031E40
		// (set) Token: 0x060000D7 RID: 215 RVA: 0x00033A54 File Offset: 0x00031E54
		[Category("Common Properties")]
		public Orientation SplitterOrientation
		{
			get
			{
				return (Orientation)base.GetValue(SplitContainer.SplitterOrientationProperty);
			}
			set
			{
				base.SetValue(SplitContainer.SplitterOrientationProperty, value);
			}
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x060000D8 RID: 216 RVA: 0x00033A68 File Offset: 0x00031E68
		// (set) Token: 0x060000D9 RID: 217 RVA: 0x00033A7C File Offset: 0x00031E7C
		public bool IsRoot
		{
			get
			{
				return (bool)base.GetValue(SplitContainer.IsRootProperty);
			}
			internal set
			{
				base.SetValue(SplitContainer.IsRootPropertyKey, value);
			}
		}

		// Token: 0x060000DA RID: 218 RVA: 0x00033A90 File Offset: 0x00031E90
		private static void OnSplitterOrientationChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			SplitContainer splitContainer = (SplitContainer)d;
			splitContainer.OnSplitterOrientationChanged();
		}

		// Token: 0x060000DB RID: 219 RVA: 0x00033AAC File Offset: 0x00031EAC
		private void OnSplitterOrientationChanged()
		{
			this.splittersDirty = true;
			base.InvalidateMeasure();
		}

		// Token: 0x060000DC RID: 220 RVA: 0x00033ABC File Offset: 0x00031EBC
		internal void AddLogicalChild(FrameworkElement child)
		{
			base.AddLogicalChild(child);
		}

		// Token: 0x060000DD RID: 221 RVA: 0x00033AC8 File Offset: 0x00031EC8
		internal void RemoveLogicalChild(FrameworkElement child)
		{
			base.RemoveLogicalChild(child);
		}

		// Token: 0x060000DE RID: 222 RVA: 0x00033AD4 File Offset: 0x00031ED4
		protected override Size MeasureOverride(Size availableSize)
		{
			if (!this.splittersDirty)
			{
				goto IL_1A7;
			}
			double num;
			bool flag = (uint)num < 0U;
			if (!flag)
			{
				goto IL_1A1;
			}
			double num2;
			if ((uint)num2 > 4294967295U)
			{
				goto IL_1BA;
			}
			IL_35:
			Size size = new Size(availableSize.Width, num2);
			IL_48:
			if (size.Width == double.PositiveInfinity)
			{
				size.Width = 0.0;
			}
			if (size.Height == double.PositiveInfinity)
			{
				size.Height = 0.0;
			}
			foreach (SplitContainerSplitter splitContainerSplitter in this.splitters)
			{
				splitContainerSplitter.Measure(size);
			}
			double num3 = Math.Max((this.SplitterOrientation == Orientation.Horizontal) ? (size.Height - this.GetTotalSplitterExtent()) : (size.Width - this.GetTotalSplitterExtent()), 0.0);
			double totalDesiredExtent = this.GetTotalDesiredExtent();
			using (IEnumerator enumerator = this.Children.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					FrameworkElement frameworkElement = (FrameworkElement)obj;
					if (SplitContainer.ShouldParticipateInLayout(frameworkElement))
					{
						if (this.SplitterOrientation == Orientation.Horizontal)
						{
							num = SplitContainer.GetWorkingSize(frameworkElement).Height / totalDesiredExtent * num3;
							frameworkElement.Measure(new Size(size.Width, num));
						}
						else
						{
							double width = SplitContainer.GetWorkingSize(frameworkElement).Width / totalDesiredExtent * num3;
							frameworkElement.Measure(new Size(width, size.Height));
						}
					}
				}
				return size;
			}
			IL_1A1:
			this.RecreateSplitters();
			IL_1A7:
			if (!this.IsRoot)
			{
				size = availableSize;
				goto IL_48;
			}
			double num4;
			if (SplitContainer.ShouldParticipateInLayout(this))
			{
				num4 = this.ContentSize;
				goto IL_1CB;
			}
			IL_1BA:
			num4 = 0.0;
			IL_1CB:
			num2 = num4;
			if (DockSite.GetDock(this) == Dock.Left || DockSite.GetDock(this) == Dock.Right)
			{
				size = new Size(num2, availableSize.Height);
				goto IL_48;
			}
			goto IL_35;
		}

		// Token: 0x060000DF RID: 223 RVA: 0x00033CF4 File Offset: 0x000320F4
		private double GetTotalSplitterExtent()
		{
			double num = 0.0;
			foreach (SplitContainerSplitter splitContainerSplitter in this.splitters)
			{
				num += ((this.SplitterOrientation == Orientation.Horizontal) ? splitContainerSplitter.DesiredSize.Height : splitContainerSplitter.DesiredSize.Width);
			}
			return num;
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x00033D50 File Offset: 0x00032150
		private double GetTotalDesiredExtent()
		{
			double num = 0.0;
			foreach (object obj in this.Children)
			{
				UIElement element = (UIElement)obj;
				if (SplitContainer.ShouldParticipateInLayout(element))
				{
					Size workingSize = SplitContainer.GetWorkingSize(element);
					num += ((this.SplitterOrientation == Orientation.Horizontal) ? workingSize.Height : workingSize.Width);
				}
			}
			return num;
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x00033DE8 File Offset: 0x000321E8
		protected override Size ArrangeOverride(Size finalSize)
		{
			double num = (this.SplitterOrientation == Orientation.Horizontal) ? finalSize.Height : finalSize.Width;
			double num2 = Math.Max(num - this.GetTotalSplitterExtent(), 0.0);
			double totalDesiredExtent = this.GetTotalDesiredExtent();
			double num3 = 0.0;
			bool flag = true;
			int num4 = 0;
			foreach (object obj in this.Children)
			{
				UIElement uielement = (UIElement)obj;
				if (SplitContainer.ShouldParticipateInLayout(uielement))
				{
					if (!flag)
					{
						SplitContainerSplitter splitContainerSplitter = this.splitters[num4++];
						Rect finalRect = (this.SplitterOrientation == Orientation.Horizontal) ? new Rect(0.0, num3, finalSize.Width, splitContainerSplitter.DesiredSize.Height) : new Rect(num3, 0.0, splitContainerSplitter.DesiredSize.Width, finalSize.Height);
						splitContainerSplitter.Arrange(finalRect);
						num3 += ((this.SplitterOrientation == Orientation.Horizontal) ? splitContainerSplitter.DesiredSize.Height : splitContainerSplitter.DesiredSize.Width);
					}
					Size workingSize = SplitContainer.GetWorkingSize(uielement);
					double num5 = (this.SplitterOrientation == Orientation.Horizontal) ? workingSize.Height : workingSize.Width;
					num5 = num5 / totalDesiredExtent * num2;
					num5 = Math.Max(num5, 18.0);
					Rect finalRect2 = (this.SplitterOrientation == Orientation.Horizontal) ? new Rect(0.0, num3, finalSize.Width, num5) : new Rect(num3, 0.0, num5, finalSize.Height);
					uielement.Arrange(finalRect2);
					num3 += num5;
					flag = false;
				}
			}
			return finalSize;
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x00033FD8 File Offset: 0x000323D8
		private void RecreateSplitters()
		{
			this.recreatingSplitters = true;
			try
			{
				foreach (SplitContainerSplitter child in this.splitters)
				{
					base.RemoveVisualChild(child);
				}
				List<SplitContainerSplitter> list = new List<SplitContainerSplitter>();
				List<FrameworkElement> list2 = new List<FrameworkElement>();
				FrameworkElement frameworkElement = null;
				foreach (object obj in this.Children)
				{
					FrameworkElement frameworkElement2 = (FrameworkElement)obj;
					if (SplitContainer.ShouldParticipateInLayout(frameworkElement2))
					{
						if (frameworkElement != null)
						{
							SplitContainerSplitter splitContainerSplitter = new SplitContainerSplitter(frameworkElement, frameworkElement2, this.SplitterOrientation);
							base.AddVisualChild(splitContainerSplitter);
							list.Add(splitContainerSplitter);
						}
						frameworkElement = frameworkElement2;
						list2.Add(frameworkElement2);
					}
				}
				this.splitters = list.ToArray();
				this.presentedChildren = list2.ToArray();
				this.splittersDirty = false;
			}
			finally
			{
				this.recreatingSplitters = false;
			}
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x000340F4 File Offset: 0x000324F4
		protected override Visual GetVisualChild(int index)
		{
			if (this.splittersDirty && !this.recreatingSplitters)
			{
				this.RecreateSplitters();
			}
			if (index < this.presentedChildren.Length)
			{
				return this.presentedChildren[index];
			}
			return this.splitters[index - this.presentedChildren.Length];
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x060000E4 RID: 228 RVA: 0x00034134 File Offset: 0x00032534
		protected override int VisualChildrenCount
		{
			get
			{
				if (this.splittersDirty && !this.recreatingSplitters)
				{
					this.RecreateSplitters();
				}
				return this.presentedChildren.Length + this.splitters.Length;
			}
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x060000E5 RID: 229 RVA: 0x00034160 File Offset: 0x00032560
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public FrameworkElementCollection Children
		{
			get
			{
				return this.children;
			}
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x00034168 File Offset: 0x00032568
		protected override void OnVisualChildrenChanged(DependencyObject visualAdded, DependencyObject visualRemoved)
		{
			base.OnVisualChildrenChanged(visualAdded, visualRemoved);
			if (!this.recreatingSplitters)
			{
				this.splittersDirty = true;
			}
		}

		// Token: 0x04000041 RID: 65
		public static readonly DependencyProperty SplitterOrientationProperty;

		// Token: 0x04000042 RID: 66
		public static readonly DependencyProperty WorkingSizeProperty;

		// Token: 0x04000043 RID: 67
		public static readonly DependencyProperty IsRootProperty;

		// Token: 0x04000044 RID: 68
		private static readonly DependencyPropertyKey IsRootPropertyKey;

		// Token: 0x04000045 RID: 69
		private FrameworkElementCollection children;

		// Token: 0x04000046 RID: 70
		private bool recreatingSplitters;

		// Token: 0x04000047 RID: 71
		private bool splittersDirty;

		// Token: 0x04000048 RID: 72
		private SplitContainerSplitter[] splitters = new SplitContainerSplitter[0];

		// Token: 0x04000049 RID: 73
		private FrameworkElement[] presentedChildren = new FrameworkElement[0];
	}
}
