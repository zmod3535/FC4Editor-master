using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using Divelements.SandDock.Primitives;
using Divelements.SandDock.Rendering;

namespace Divelements.SandDock.InteractiveDocking
{
	// Token: 0x0200003F RID: 63
	internal class x702c550d0cd841b4
	{
		// Token: 0x06000390 RID: 912 RVA: 0x000407E8 File Offset: 0x0003EBE8
		private x702c550d0cd841b4()
		{
			this.xe51f872d9ba776f5 = new Border();
			this.x3db253e15383fe11 = new MdiWindowContainer();
			this.x3db253e15383fe11.CanMaximize = false;
			this.x3db253e15383fe11.CanMinimize = false;
			this.x3db253e15383fe11.WindowStyle = WindowStyle.ToolWindow;
			MdiPanel.SetRestoredSize(this.x3db253e15383fe11, new Size(double.NaN, double.NaN));
			this.x3db253e15383fe11.SetClientSize = false;
			ComponentResourceKey name = new ComponentResourceKey(typeof(GeneralElements), GeneralElements.DockSiteBackgroundBrush);
			this.x3db253e15383fe11.SetResourceReference(Control.BackgroundProperty, name);
			this.xe51f872d9ba776f5.SetResourceReference(Control.BackgroundProperty, name);
		}

		// Token: 0x06000391 RID: 913 RVA: 0x0004089C File Offset: 0x0003EC9C
		public x702c550d0cd841b4(WindowGroup windowGroup) : this()
		{
			WindowGroup x9effd75f06da97a = this.x6702e63665b37d85(windowGroup);
			this.xd284af71d3fd6322 = x9effd75f06da97a;
			this.x9effd75f06da97a1 = x9effd75f06da97a;
			if (windowGroup.SelectedWindow != null)
			{
				this.x3db253e15383fe11.Title = windowGroup.SelectedWindow.Title;
			}
		}

		// Token: 0x06000392 RID: 914 RVA: 0x000408E4 File Offset: 0x0003ECE4
		public x702c550d0cd841b4(DockableWindow window) : this()
		{
			WindowGroup windowGroup = new WindowGroup();
			windowGroup.Windows.Add(this.xbf5498fb2d331cf3(window));
			this.xd284af71d3fd6322 = windowGroup;
			this.x3db253e15383fe11.Title = window.Title;
			this.x9effd75f06da97a1 = windowGroup;
		}

		// Token: 0x06000393 RID: 915 RVA: 0x00040930 File Offset: 0x0003ED30
		public x702c550d0cd841b4(SplitContainer splitContainer) : this()
		{
			SplitContainer splitContainer2 = this.xef2c22b19beb17fe(splitContainer);
			this.x9effd75f06da97a1 = splitContainer2;
			if (splitContainer.Children.Count == 1)
			{
				WindowGroup windowGroup = splitContainer.Children[0] as WindowGroup;
				if (windowGroup != null)
				{
					this.xd284af71d3fd6322 = (WindowGroup)splitContainer2.Children[0];
					this.x3db253e15383fe11.Title = this.xd284af71d3fd6322.SelectedWindow.Title;
				}
			}
		}

		// Token: 0x06000394 RID: 916 RVA: 0x000409A8 File Offset: 0x0003EDA8
		private SplitContainer xef2c22b19beb17fe(SplitContainer x7ccf7ff558b320df)
		{
			SplitContainer splitContainer = new SplitContainer();
			BindingOperations.SetBinding(splitContainer, SplitContainer.SplitterOrientationProperty, this.xc521a63555bef759(x7ccf7ff558b320df, SplitContainer.SplitterOrientationProperty));
			BindingOperations.SetBinding(splitContainer, SplitContainer.WorkingSizeProperty, this.xc521a63555bef759(x7ccf7ff558b320df, SplitContainer.WorkingSizeProperty));
			foreach (object obj in x7ccf7ff558b320df.Children)
			{
				UIElement uielement = (UIElement)obj;
				WindowGroup windowGroup = uielement as WindowGroup;
				if (windowGroup != null)
				{
					splitContainer.Children.Add(this.x6702e63665b37d85(windowGroup));
				}
				SplitContainer splitContainer2 = uielement as SplitContainer;
				if (splitContainer2 != null)
				{
					splitContainer.Children.Add(this.xef2c22b19beb17fe(splitContainer2));
				}
			}
			return splitContainer;
		}

		// Token: 0x06000395 RID: 917 RVA: 0x00040A7C File Offset: 0x0003EE7C
		private WindowGroup x6702e63665b37d85(WindowGroup x3eac5ad685984f7a)
		{
			WindowGroup windowGroup = new WindowGroup();
			foreach (DockableWindow x49162b581c8a3d in x3eac5ad685984f7a.Windows)
			{
				windowGroup.Windows.Add(this.xbf5498fb2d331cf3(x49162b581c8a3d));
			}
			windowGroup.SelectedWindow = windowGroup.Windows[x3eac5ad685984f7a.Windows.IndexOf(x3eac5ad685984f7a.SelectedWindow)];
			BindingOperations.SetBinding(windowGroup, SplitContainer.WorkingSizeProperty, this.xc521a63555bef759(x3eac5ad685984f7a, SplitContainer.WorkingSizeProperty));
			return windowGroup;
		}

		// Token: 0x06000396 RID: 918 RVA: 0x00040B24 File Offset: 0x0003EF24
		private DockableWindow xbf5498fb2d331cf3(DockableWindow x49162b581c8a3d69)
		{
			DockableWindow dockableWindow = new DockableWindow();
			BindingOperations.SetBinding(dockableWindow, DockableWindow.TitleProperty, this.xc521a63555bef759(x49162b581c8a3d69, DockableWindow.TitleProperty));
			BindingOperations.SetBinding(dockableWindow, DockableWindow.ImageProperty, this.xc521a63555bef759(x49162b581c8a3d69, DockableWindow.ImageProperty));
			return dockableWindow;
		}

		// Token: 0x06000397 RID: 919 RVA: 0x00040B68 File Offset: 0x0003EF68
		private Binding xc521a63555bef759(DependencyObject x864527beaa9c5468, DependencyProperty xa258e582bde470e6)
		{
			return new Binding
			{
				Mode = BindingMode.OneWay,
				Source = x864527beaa9c5468,
				Path = new PropertyPath(xa258e582bde470e6)
			};
		}

		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x06000398 RID: 920 RVA: 0x00040B98 File Offset: 0x0003EF98
		// (set) Token: 0x06000399 RID: 921 RVA: 0x00040BC0 File Offset: 0x0003EFC0
		private UIElement x9effd75f06da97a1
		{
			get
			{
				if (this.x6f6877b222ed4153)
				{
					return (UIElement)this.x3db253e15383fe11.Content;
				}
				return this.xe51f872d9ba776f5.Child;
			}
			set
			{
				if (this.x6f6877b222ed4153)
				{
					this.x3db253e15383fe11.Content = value;
					return;
				}
				this.xe51f872d9ba776f5.Child = value;
			}
		}

		// Token: 0x170000CA RID: 202
		// (get) Token: 0x0600039A RID: 922 RVA: 0x00040BE4 File Offset: 0x0003EFE4
		// (set) Token: 0x0600039B RID: 923 RVA: 0x00040BEC File Offset: 0x0003EFEC
		public bool x6f6877b222ed4153
		{
			get
			{
				return this.x75be8700ab94f982;
			}
			set
			{
				if (value != this.x75be8700ab94f982)
				{
					UIElement x9effd75f06da97a = this.x9effd75f06da97a1;
					this.xe51f872d9ba776f5.Child = null;
					this.x75be8700ab94f982 = value;
					if (value)
					{
						this.xe51f872d9ba776f5.Child = this.x3db253e15383fe11;
					}
					else
					{
						this.x3db253e15383fe11.Content = null;
					}
					this.x9effd75f06da97a1 = x9effd75f06da97a;
					if (this.xd284af71d3fd6322 != null)
					{
						this.xd284af71d3fd6322.ShowTitleBar = !this.x6f6877b222ed4153;
					}
				}
			}
		}

		// Token: 0x170000CB RID: 203
		// (get) Token: 0x0600039C RID: 924 RVA: 0x00040C64 File Offset: 0x0003F064
		public Brush x60465f602599d327
		{
			get
			{
				if (this.xd8f1949f8950238a == null)
				{
					this.xd8f1949f8950238a = new VisualBrush(this.xe51f872d9ba776f5);
				}
				return this.xd8f1949f8950238a;
			}
		}

		// Token: 0x170000CC RID: 204
		// (get) Token: 0x0600039D RID: 925 RVA: 0x00040C88 File Offset: 0x0003F088
		// (set) Token: 0x0600039E RID: 926 RVA: 0x00040CA8 File Offset: 0x0003F0A8
		public Size x437e3b626c0fdd43
		{
			get
			{
				return new Size(this.xe51f872d9ba776f5.Width, this.xe51f872d9ba776f5.Height);
			}
			set
			{
				this.xe51f872d9ba776f5.Width = value.Width;
				this.xe51f872d9ba776f5.Height = value.Height;
			}
		}

		// Token: 0x0400015D RID: 349
		private VisualBrush xd8f1949f8950238a;

		// Token: 0x0400015E RID: 350
		private Border xe51f872d9ba776f5;

		// Token: 0x0400015F RID: 351
		private MdiWindowContainer x3db253e15383fe11;

		// Token: 0x04000160 RID: 352
		private bool x75be8700ab94f982;

		// Token: 0x04000161 RID: 353
		private WindowGroup xd284af71d3fd6322;
	}
}
