using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using Divelements.SandDock.Primitives;
using Divelements.SandDock.Resources;

namespace Divelements.SandDock
{
	// Token: 0x02000029 RID: 41
	public class DocumentContainer : ContentControl
	{
		// Token: 0x060002C2 RID: 706 RVA: 0x0003C6B8 File Offset: 0x0003AAB8
		static DocumentContainer()
		{
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(DocumentContainer), new FrameworkPropertyMetadata(typeof(DocumentContainer)));
			DocumentContainer.DockSiteProperty = DockSite.ManagerProperty.AddOwner(typeof(DocumentContainer), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits, new PropertyChangedCallback(DocumentContainer.OnDockSiteChanged)));
			ContentControl.ContentProperty.OverrideMetadata(typeof(DocumentContainer), new FrameworkPropertyMetadata(new PropertyChangedCallback(DocumentContainer.OnContentChanged)));
			Control.IsTabStopProperty.OverrideMetadata(typeof(DocumentContainer), new FrameworkPropertyMetadata(false));
		}

		// Token: 0x060002C3 RID: 707 RVA: 0x0003C788 File Offset: 0x0003AB88
		public DocumentContainer()
		{
			DockableWindow.SetDockSituation(this, DockSituation.Document);
		}

		// Token: 0x060002C4 RID: 708 RVA: 0x0003C7A0 File Offset: 0x0003ABA0
		internal void EnsureContent()
		{
			if (base.Content is SplitContainer || base.Content is MdiContainer)
			{
				return;
			}
			if (base.Content != null || this.lastContentType == xee4008b4c243e4a9.xf6c17f648b65c793)
			{
				throw new InvalidOperationException(Messages.ExceptionDocumentContainerUnrecognisedContent);
			}
			if (this.lastContentType == xee4008b4c243e4a9.xd301f1060b3751dc)
			{
				base.Content = new SplitContainer();
				return;
			}
			if (this.lastContentType == xee4008b4c243e4a9.xd8e8992926cad390)
			{
				base.Content = new MdiContainer();
			}
		}

		// Token: 0x060002C5 RID: 709 RVA: 0x0003C80C File Offset: 0x0003AC0C
		private static void OnContentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			DocumentContainer documentContainer = (DocumentContainer)d;
			if (e.NewValue != null)
			{
				if (e.NewValue is MdiContainer)
				{
					documentContainer.lastContentType = xee4008b4c243e4a9.xd8e8992926cad390;
				}
				else if (e.NewValue is SplitContainer)
				{
					documentContainer.lastContentType = xee4008b4c243e4a9.xd301f1060b3751dc;
				}
				else
				{
					documentContainer.lastContentType = xee4008b4c243e4a9.xf6c17f648b65c793;
				}
			}
			SplitContainer splitContainer = e.OldValue as SplitContainer;
			if (splitContainer != null)
			{
				SplitContainer.PropagateDockSituationChanged(splitContainer);
			}
			SplitContainer splitContainer2 = e.NewValue as SplitContainer;
			if (splitContainer2 != null)
			{
				SplitContainer.PropagateDockSituationChanged(splitContainer2);
			}
		}

		// Token: 0x060002C6 RID: 710 RVA: 0x0003C88C File Offset: 0x0003AC8C
		private static void OnDockSiteChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			DocumentContainer documentContainer = (DocumentContainer)d;
			DockSite dockSite = e.NewValue as DockSite;
			DockSite dockSite2 = e.OldValue as DockSite;
			if (dockSite != null && dockSite.DocumentContainer == null)
			{
				dockSite.DocumentContainer = documentContainer;
			}
			else if (dockSite == null && dockSite2 != null && dockSite2.DocumentContainer == documentContainer)
			{
				dockSite2.DocumentContainer = null;
			}
			if (dockSite != null)
			{
				SplitContainer splitContainer = documentContainer.Content as SplitContainer;
				if (splitContainer != null)
				{
					SplitContainer.PropagateDockSituationChanged(splitContainer);
				}
			}
		}

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x060002C7 RID: 711 RVA: 0x0003C8FC File Offset: 0x0003ACFC
		// (set) Token: 0x060002C8 RID: 712 RVA: 0x0003C910 File Offset: 0x0003AD10
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public DockSite DockSite
		{
			get
			{
				return (DockSite)base.GetValue(DocumentContainer.DockSiteProperty);
			}
			set
			{
				base.SetValue(DocumentContainer.DockSiteProperty, value);
			}
		}

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x060002C9 RID: 713 RVA: 0x0003C920 File Offset: 0x0003AD20
		// (set) Token: 0x060002CA RID: 714 RVA: 0x0003C934 File Offset: 0x0003AD34
		public DocumentContainerWindowOpenPosition WindowOpenPosition
		{
			get
			{
				return (DocumentContainerWindowOpenPosition)base.GetValue(DocumentContainer.WindowOpenPositionProperty);
			}
			set
			{
				base.SetValue(DocumentContainer.WindowOpenPositionProperty, value);
			}
		}

		// Token: 0x060002CB RID: 715 RVA: 0x0003C948 File Offset: 0x0003AD48
		public WindowGroup GetDefaultWindowGroup()
		{
			if (base.Content == null)
			{
				base.Content = new SplitContainer();
			}
			SplitContainer splitContainer = base.Content as SplitContainer;
			if (splitContainer == null)
			{
				return null;
			}
			WindowGroup defaultWindowGroupRecursive = this.GetDefaultWindowGroupRecursive(splitContainer);
			if (defaultWindowGroupRecursive != null)
			{
				return defaultWindowGroupRecursive;
			}
			WindowGroup windowGroup = splitContainer.CreateWindowGroup();
			splitContainer.Children.Add(windowGroup);
			return windowGroup;
		}

		// Token: 0x060002CC RID: 716 RVA: 0x0003C99C File Offset: 0x0003AD9C
		private WindowGroup GetDefaultWindowGroupRecursive(SplitContainer splitContainer)
		{
			foreach (object obj in splitContainer.Children)
			{
				FrameworkElement frameworkElement = (FrameworkElement)obj;
				SplitContainer splitContainer2 = frameworkElement as SplitContainer;
				if (splitContainer2 != null)
				{
					WindowGroup defaultWindowGroupRecursive = this.GetDefaultWindowGroupRecursive(splitContainer2);
					if (defaultWindowGroupRecursive != null)
					{
						return defaultWindowGroupRecursive;
					}
				}
				WindowGroup windowGroup = frameworkElement as WindowGroup;
				if (windowGroup != null)
				{
					return windowGroup;
				}
			}
			return null;
		}

		// Token: 0x060002CD RID: 717 RVA: 0x0003CA30 File Offset: 0x0003AE30
		public bool CloseAllDocuments()
		{
			if (this.DockSite != null)
			{
				foreach (DockableWindow dockableWindow in this.DockSite.GetAllWindows(DockSituation.Document))
				{
					dockableWindow.Close();
				}
				return this.DockSite.GetAllWindows(DockSituation.Document).Length == 0;
			}
			return false;
		}

		// Token: 0x060002CE RID: 718 RVA: 0x0003CA80 File Offset: 0x0003AE80
		private bool RemoveAllDocuments()
		{
			if (this.DockSite != null)
			{
				foreach (DockableWindow dockableWindow in this.DockSite.GetAllWindows(DockSituation.Document))
				{
					dockableWindow.Remove();
				}
				return this.DockSite.GetAllWindows(DockSituation.Document).Length == 0;
			}
			return false;
		}

		// Token: 0x060002CF RID: 719 RVA: 0x0003CAD0 File Offset: 0x0003AED0
		public void ApplyTabbedLayout()
		{
			if (this.DockSite == null)
			{
				throw new InvalidOperationException(Messages.ExceptionDockSiteRequired);
			}
			DockableWindow[] allWindows = this.DockSite.GetAllWindows(DockSituation.Document);
			if (!this.RemoveAllDocuments())
			{
				return;
			}
			SplitContainer splitContainer = new SplitContainer();
			if (allWindows.Length != 0)
			{
				WindowGroup windowGroup = new WindowGroup();
				splitContainer.Children.Add(windowGroup);
				foreach (DockableWindow item in allWindows)
				{
					windowGroup.Windows.Add(item);
				}
			}
			base.Content = splitContainer;
		}

		// Token: 0x060002D0 RID: 720 RVA: 0x0003CB54 File Offset: 0x0003AF54
		public void ApplyMdiLayout()
		{
			if (this.DockSite == null)
			{
				throw new InvalidOperationException(Messages.ExceptionDockSiteRequired);
			}
			DockableWindow[] allWindows = this.DockSite.GetAllWindows(DockSituation.Document);
			if (!this.RemoveAllDocuments())
			{
				return;
			}
			MdiContainer mdiContainer = new MdiContainer();
			foreach (DockableWindow newItem in allWindows)
			{
				mdiContainer.Items.Add(newItem);
			}
			base.Content = mdiContainer;
		}

		// Token: 0x060002D1 RID: 721 RVA: 0x0003CBC0 File Offset: 0x0003AFC0
		public void UseDockableWindowTemplate()
		{
			if (this.DockSite == null)
			{
				throw new InvalidOperationException(Messages.ExceptionDockSiteRequired);
			}
			Style style = this.DockSite.TryFindResource(typeof(WindowGroup)) as Style;
			if (style != null)
			{
				base.Resources.Add(typeof(WindowGroup), style);
			}
			style = (this.DockSite.TryFindResource(typeof(WindowTab)) as Style);
			if (style != null)
			{
				base.Resources.Add(typeof(WindowTab), style);
			}
		}

		// Token: 0x040000F4 RID: 244
		public static readonly DependencyProperty DockSiteProperty;

		// Token: 0x040000F5 RID: 245
		public static readonly DependencyProperty WindowOpenPositionProperty = DependencyProperty.Register("WindowOpenPosition", typeof(DocumentContainerWindowOpenPosition), typeof(DocumentContainer), new FrameworkPropertyMetadata(DocumentContainerWindowOpenPosition.First));

		// Token: 0x040000F6 RID: 246
		private xee4008b4c243e4a9 lastContentType = xee4008b4c243e4a9.xf6c17f648b65c793;
	}
}
