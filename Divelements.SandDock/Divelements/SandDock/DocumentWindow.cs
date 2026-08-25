using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Divelements.SandDock.Resources;

namespace Divelements.SandDock
{
	// Token: 0x0200007B RID: 123
	public class DocumentWindow : DockableWindow
	{
		// Token: 0x060004F8 RID: 1272 RVA: 0x00048E2C File Offset: 0x0004722C
		static DocumentWindow()
		{
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(DocumentWindow), new FrameworkPropertyMetadata(typeof(DocumentWindow)));
			DockableWindow.DockingRulesProperty.OverrideMetadata(typeof(DocumentWindow), new FrameworkPropertyMetadata(new DockingRules(false, true, false)));
			DockableWindow.FloatingSizeProperty.OverrideMetadata(typeof(DocumentWindow), new FrameworkPropertyMetadata(new Size(550.0, 380.0)));
			Control.BackgroundProperty.OverrideMetadata(typeof(DocumentWindow), new FrameworkPropertyMetadata(SystemColors.WindowBrush));
		}

		// Token: 0x060004F9 RID: 1273 RVA: 0x00048ED0 File Offset: 0x000472D0
		public DocumentWindow()
		{
			base.MetaData.LastOpenDockSituation = DockSituation.Document;
			base.MetaData.LastFixedDockSituation = DockSituation.Document;
		}

		// Token: 0x060004FA RID: 1274 RVA: 0x00048EF0 File Offset: 0x000472F0
		public DocumentWindow(DockSite dockSite, string title) : base(dockSite, title)
		{
			base.MetaData.LastOpenDockSituation = DockSituation.Document;
			base.MetaData.LastFixedDockSituation = DockSituation.Document;
		}

		// Token: 0x060004FB RID: 1275 RVA: 0x00048F14 File Offset: 0x00047314
		public DocumentWindow(DockSite dockSite, string title, FrameworkElement child) : this(dockSite, title)
		{
			if (child == null)
			{
				throw new ArgumentNullException("child");
			}
			base.Child = child;
		}

		// Token: 0x060004FC RID: 1276 RVA: 0x00048F34 File Offset: 0x00047334
		public DocumentWindow(DockSite dockSite, string title, Uri source) : this(dockSite, title)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			base.Child = new Frame
			{
				Source = source
			};
		}

		// Token: 0x060004FD RID: 1277 RVA: 0x00048F74 File Offset: 0x00047374
		public new static DocumentWindow FromWindow(DockSite dockSite, Window window)
		{
			if (window == null)
			{
				throw new ArgumentNullException("window");
			}
			UIElement uielement = window.Content as UIElement;
			if (uielement == null)
			{
				throw new InvalidOperationException(Messages.ExceptionWindowHasNoContent);
			}
			window.Content = null;
			DocumentWindow documentWindow = new DocumentWindow();
			documentWindow.DockSite = dockSite;
			documentWindow.Child = uielement;
			documentWindow.Close();
			Binding binding = new Binding();
			binding.Path = new PropertyPath(Window.TitleProperty);
			binding.Mode = BindingMode.OneWay;
			binding.Source = window;
			documentWindow.SetBinding(DockableWindow.TitleProperty, binding);
			return documentWindow;
		}
	}
}
