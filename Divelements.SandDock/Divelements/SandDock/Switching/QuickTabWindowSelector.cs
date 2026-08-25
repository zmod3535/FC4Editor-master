using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Divelements.SandDock.Switching
{
	// Token: 0x02000062 RID: 98
	[TemplatePart(Name = "PART_ItemsControl", Type = typeof(ItemsControl))]
	public class QuickTabWindowSelector : Control
	{
		// Token: 0x0600049D RID: 1181 RVA: 0x00046AD0 File Offset: 0x00044ED0
		static QuickTabWindowSelector()
		{
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(QuickTabWindowSelector), new FrameworkPropertyMetadata(typeof(QuickTabWindowSelector)));
			UIElement.FocusableProperty.OverrideMetadata(typeof(QuickTabWindowSelector), new FrameworkPropertyMetadata(false));
		}

		// Token: 0x0600049E RID: 1182 RVA: 0x00046B20 File Offset: 0x00044F20
		internal QuickTabWindowSelector(WindowSwitcher switcher, WindowPreview[] windows)
		{
			this.windowSwitcher = switcher;
			this.windows = windows;
			Array.Reverse(this.windows);
			DependencyPropertyDescriptor.FromProperty(WindowSwitcher.PreviewingWindowProperty, typeof(WindowSwitcher)).AddValueChanged(switcher, new EventHandler(this.OnPreviewingWindowChanged));
		}

		// Token: 0x0600049F RID: 1183 RVA: 0x00046B74 File Offset: 0x00044F74
		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			if (this.itemsControl != null)
			{
				this.itemsControl.PreviewMouseDown -= this.OnListBoxPreviewMouseDown;
			}
			this.itemsControl = (base.GetTemplateChild("PART_ItemsControl") as ItemsControl);
			if (this.itemsControl != null)
			{
				this.itemsControl.PreviewMouseDown += this.OnListBoxPreviewMouseDown;
			}
		}

		// Token: 0x060004A0 RID: 1184 RVA: 0x00046BDC File Offset: 0x00044FDC
		private void OnListBoxPreviewMouseDown(object sender, MouseButtonEventArgs e)
		{
			ListBox listBox = sender as ListBox;
			if (listBox != null)
			{
				ListBoxItem listBoxItem = ItemsControl.ContainerFromElement(listBox, (DependencyObject)e.OriginalSource) as ListBoxItem;
				if (listBoxItem != null)
				{
					WindowPreview windowPreview = listBoxItem.DataContext as WindowPreview;
					if (windowPreview != null)
					{
						this.WindowSwitcher.PreviewingWindow = windowPreview.Window;
						this.WindowSwitcher.Commit();
						e.Handled = true;
					}
				}
			}
		}

		// Token: 0x060004A1 RID: 1185 RVA: 0x00046C40 File Offset: 0x00045040
		private void OnPreviewingWindowChanged(object sender, EventArgs e)
		{
			if (this.WindowSwitcher.PreviewingWindow != null && this.itemsControl != null)
			{
				WindowPreview windowPreview = null;
				foreach (WindowPreview windowPreview2 in this.Windows)
				{
					if (windowPreview2.Window == this.WindowSwitcher.PreviewingWindow)
					{
						windowPreview = windowPreview2;
						break;
					}
				}
				if (windowPreview == null)
				{
					return;
				}
				ListBoxItem listBoxItem = this.itemsControl.ItemContainerGenerator.ContainerFromItem(windowPreview) as ListBoxItem;
				if (listBoxItem != null)
				{
					listBoxItem.BringIntoView();
				}
			}
		}

		// Token: 0x17000103 RID: 259
		// (get) Token: 0x060004A2 RID: 1186 RVA: 0x00046CC0 File Offset: 0x000450C0
		public WindowSwitcher WindowSwitcher
		{
			get
			{
				return this.windowSwitcher;
			}
		}

		// Token: 0x17000104 RID: 260
		// (get) Token: 0x060004A3 RID: 1187 RVA: 0x00046CC8 File Offset: 0x000450C8
		public WindowPreview[] Windows
		{
			get
			{
				return this.windows;
			}
		}

		// Token: 0x04000205 RID: 517
		private WindowSwitcher windowSwitcher;

		// Token: 0x04000206 RID: 518
		private WindowPreview[] windows;

		// Token: 0x04000207 RID: 519
		private ItemsControl itemsControl;
	}
}
