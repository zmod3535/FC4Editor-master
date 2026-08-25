using System;
using System.Windows;
using System.Windows.Controls;

namespace Divelements.SandDock.Primitives
{
	// Token: 0x0200001A RID: 26
	public class PopupContainer : Control
	{
		// Token: 0x06000214 RID: 532 RVA: 0x00038D8C File Offset: 0x0003718C
		static PopupContainer()
		{
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(PopupContainer), new FrameworkPropertyMetadata(typeof(PopupContainer)));
			UIElement.VisibilityProperty.OverrideMetadata(typeof(PopupContainer), new FrameworkPropertyMetadata(Visibility.Collapsed));
			UIElement.FocusableProperty.OverrideMetadata(typeof(PopupContainer), new FrameworkPropertyMetadata(false));
			PopupContainer.WindowGroupProperty = DependencyProperty.Register("WindowGroup", typeof(WindowGroup), typeof(PopupContainer), new FrameworkPropertyMetadata(null));
		}

		// Token: 0x06000215 RID: 533 RVA: 0x00038E24 File Offset: 0x00037224
		internal PopupContainer(FrameworkElement parent)
		{
			this.parent = parent;
		}

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x06000216 RID: 534 RVA: 0x00038E34 File Offset: 0x00037234
		internal new FrameworkElement Parent
		{
			get
			{
				return this.parent;
			}
		}

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x06000217 RID: 535 RVA: 0x00038E3C File Offset: 0x0003723C
		// (set) Token: 0x06000218 RID: 536 RVA: 0x00038E50 File Offset: 0x00037250
		public WindowGroup WindowGroup
		{
			get
			{
				return (WindowGroup)base.GetValue(PopupContainer.WindowGroupProperty);
			}
			internal set
			{
				base.SetValue(PopupContainer.WindowGroupProperty, value);
			}
		}

		// Token: 0x040000AA RID: 170
		public static readonly DependencyProperty WindowGroupProperty;

		// Token: 0x040000AB RID: 171
		private FrameworkElement parent;
	}
}
