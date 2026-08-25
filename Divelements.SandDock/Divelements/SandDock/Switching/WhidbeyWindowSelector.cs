using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Divelements.SandDock.Switching
{
	// Token: 0x02000060 RID: 96
	public class WhidbeyWindowSelector : Control
	{
		// Token: 0x06000493 RID: 1171 RVA: 0x000467B4 File Offset: 0x00044BB4
		static WhidbeyWindowSelector()
		{
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(WhidbeyWindowSelector), new FrameworkPropertyMetadata(typeof(WhidbeyWindowSelector)));
			UIElement.FocusableProperty.OverrideMetadata(typeof(WhidbeyWindowSelector), new FrameworkPropertyMetadata(false));
			FrameworkElement.HorizontalAlignmentProperty.OverrideMetadata(typeof(WhidbeyWindowSelector), new FrameworkPropertyMetadata(HorizontalAlignment.Center));
			FrameworkElement.VerticalAlignmentProperty.OverrideMetadata(typeof(WhidbeyWindowSelector), new FrameworkPropertyMetadata(VerticalAlignment.Center));
		}

		// Token: 0x06000494 RID: 1172 RVA: 0x00046844 File Offset: 0x00044C44
		internal WhidbeyWindowSelector(WindowSwitcher switcher)
		{
			this.windowSwitcher = switcher;
		}

		// Token: 0x17000102 RID: 258
		// (get) Token: 0x06000495 RID: 1173 RVA: 0x00046854 File Offset: 0x00044C54
		public WindowSwitcher WindowSwitcher
		{
			get
			{
				return this.windowSwitcher;
			}
		}

		// Token: 0x06000496 RID: 1174 RVA: 0x0004685C File Offset: 0x00044C5C
		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			if (this.templateToolWindowListBox != null)
			{
				this.templateToolWindowListBox.PreviewMouseDown -= this.OnPreviewListBoxMouseDown;
			}
			if (this.templateDocumentWindowListBox != null)
			{
				this.templateDocumentWindowListBox.PreviewMouseDown -= this.OnPreviewListBoxMouseDown;
			}
			this.templateToolWindowListBox = (base.GetTemplateChild("PART_ToolWindowListBox") as ListBox);
			this.templateDocumentWindowListBox = (base.GetTemplateChild("PART_DocumentWindowListBox") as ListBox);
			if (this.templateToolWindowListBox != null)
			{
				this.templateToolWindowListBox.PreviewMouseDown += this.OnPreviewListBoxMouseDown;
			}
			if (this.templateDocumentWindowListBox != null)
			{
				this.templateDocumentWindowListBox.PreviewMouseDown += this.OnPreviewListBoxMouseDown;
			}
		}

		// Token: 0x06000497 RID: 1175 RVA: 0x00046918 File Offset: 0x00044D18
		private void OnPreviewListBoxMouseDown(object sender, MouseButtonEventArgs e)
		{
			ListBox itemsControl = (ListBox)sender;
			ListBoxItem listBoxItem = ItemsControl.ContainerFromElement(itemsControl, (DependencyObject)e.OriginalSource) as ListBoxItem;
			if (listBoxItem != null)
			{
				DockableWindow dockableWindow = listBoxItem.DataContext as DockableWindow;
				if (dockableWindow != null)
				{
					this.WindowSwitcher.PreviewingWindow = dockableWindow;
					this.WindowSwitcher.Commit();
					e.Handled = true;
				}
			}
		}

		// Token: 0x040001FF RID: 511
		private WindowSwitcher windowSwitcher;

		// Token: 0x04000200 RID: 512
		private ListBox templateToolWindowListBox;

		// Token: 0x04000201 RID: 513
		private ListBox templateDocumentWindowListBox;
	}
}
