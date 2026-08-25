using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using IGE.Helpers;
using IGE.Nomad;

namespace IGE.Views
{
	// Token: 0x020000D6 RID: 214
	public class OpenDialog : Window, IComponentConnector, IStyleConnector
	{
		// Token: 0x060007C8 RID: 1992 RVA: 0x0001B0B0 File Offset: 0x000192B0
		public OpenDialog()
		{
			this.InitializeComponent();
			OpenDialog.OpenDialogContext dataContext = new OpenDialog.OpenDialogContext();
			base.DataContext = dataContext;
		}

		// Token: 0x170001C2 RID: 450
		// (get) Token: 0x060007C9 RID: 1993 RVA: 0x0001B0D6 File Offset: 0x000192D6
		// (set) Token: 0x060007CA RID: 1994 RVA: 0x0001B0DE File Offset: 0x000192DE
		public string FileName { get; private set; }

		// Token: 0x170001C3 RID: 451
		// (get) Token: 0x060007CB RID: 1995 RVA: 0x0001B0E7 File Offset: 0x000192E7
		// (set) Token: 0x060007CC RID: 1996 RVA: 0x0001B0EF File Offset: 0x000192EF
		public bool IsDownloadedMap { get; private set; }

		// Token: 0x060007CD RID: 1997 RVA: 0x0001B0F8 File Offset: 0x000192F8
		private void CategoryListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			OpenDialog.OpenDialogContext openDialogContext = base.DataContext as OpenDialog.OpenDialogContext;
			if (openDialogContext != null)
			{
				openDialogContext.PopulateMaps(openDialogContext.Category);
				this.IsDownloadedMap = openDialogContext.IsDownloadedMap;
			}
			this.FileName = null;
			this.OkButton.IsEnabled = false;
		}

		// Token: 0x060007CE RID: 1998 RVA: 0x0001B140 File Offset: 0x00019340
		private void MapListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			this.FileName = null;
			OpenDialog.OpenDialogContext openDialogContext = base.DataContext as OpenDialog.OpenDialogContext;
			if (openDialogContext != null)
			{
				this.FileName = openDialogContext.MapName;
				this.IsDownloadedMap = openDialogContext.IsDownloadedMap;
			}
			this.OkButton.IsEnabled = !string.IsNullOrEmpty(this.FileName);
		}

		// Token: 0x060007CF RID: 1999 RVA: 0x0001B194 File Offset: 0x00019394
		private void OkButton_Click(object sender, RoutedEventArgs e)
		{
			this.CloseIfFileSelected();
		}

		// Token: 0x060007D0 RID: 2000 RVA: 0x0001B19C File Offset: 0x0001939C
		private void CancelButton_Click(object sender, RoutedEventArgs e)
		{
			base.DialogResult = new bool?(false);
		}

		// Token: 0x060007D1 RID: 2001 RVA: 0x0001B1AA File Offset: 0x000193AA
		private void MapListBoxItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			this.CloseIfFileSelected();
		}

		// Token: 0x060007D2 RID: 2002 RVA: 0x0001B1B2 File Offset: 0x000193B2
		private void CloseIfFileSelected()
		{
			if (!string.IsNullOrEmpty(this.FileName))
			{
				base.DialogResult = new bool?(true);
			}
		}

		// Token: 0x060007D3 RID: 2003 RVA: 0x0001B1D0 File Offset: 0x000193D0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/IGE.WPF.Core64;component/views/windows/opendialog.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060007D4 RID: 2004 RVA: 0x0001B200 File Offset: 0x00019400
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				this.CategoryListBox = (ListBox)target;
				this.CategoryListBox.SelectionChanged += this.CategoryListBox_SelectionChanged;
				return;
			case 2:
				this.MapListBox = (ListBox)target;
				this.MapListBox.SelectionChanged += this.MapListBox_SelectionChanged;
				return;
			case 4:
				this.OkButton = (Button)target;
				this.OkButton.Click += this.OkButton_Click;
				return;
			case 5:
				this.CancelButton = (Button)target;
				this.CancelButton.Click += this.CancelButton_Click;
				return;
			}
			this._contentLoaded = true;
		}

		// Token: 0x060007D5 RID: 2005 RVA: 0x0001B2C8 File Offset: 0x000194C8
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		void IStyleConnector.Connect(int connectionId, object target)
		{
			if (connectionId != 3)
			{
				return;
			}
			EventSetter eventSetter = new EventSetter();
			eventSetter.Event = Control.MouseDoubleClickEvent;
			eventSetter.Handler = new MouseButtonEventHandler(this.MapListBoxItem_MouseDoubleClick);
			((Style)target).Setters.Add(eventSetter);
		}

		// Token: 0x040003D4 RID: 980
		internal ListBox CategoryListBox;

		// Token: 0x040003D5 RID: 981
		internal ListBox MapListBox;

		// Token: 0x040003D6 RID: 982
		internal Button OkButton;

		// Token: 0x040003D7 RID: 983
		internal Button CancelButton;

		// Token: 0x040003D8 RID: 984
		private bool _contentLoaded;

		// Token: 0x020000D7 RID: 215
		private class OpenDialogContext : DependencyObject
		{
			// Token: 0x060007D6 RID: 2006 RVA: 0x0001B310 File Offset: 0x00019510
			public OpenDialogContext()
			{
				this.DialogTitle = Localizer.LocalizeCommon("DIALOG_OPEN");
				this.CategoryLabel = Localizer.Localize("DIALOG_OPEN_CATEGORY", null);
				this.MapLabel = Localizer.Localize("DIALOG_OPEN_MAPS", null);
				this.localMaps = Localizer.LocalizeCommon(273103U);
				this.downloadedMaps = Localizer.LocalizeCommon(273106U);
				this.CategoryList = new List<string>
				{
					this.localMaps,
					this.downloadedMaps
				};
				this.Category = this.localMaps;
			}

			// Token: 0x170001C4 RID: 452
			// (get) Token: 0x060007D7 RID: 2007 RVA: 0x0001B3A6 File Offset: 0x000195A6
			// (set) Token: 0x060007D8 RID: 2008 RVA: 0x0001B3AE File Offset: 0x000195AE
			public string DialogTitle { get; private set; }

			// Token: 0x170001C5 RID: 453
			// (get) Token: 0x060007D9 RID: 2009 RVA: 0x0001B3B7 File Offset: 0x000195B7
			// (set) Token: 0x060007DA RID: 2010 RVA: 0x0001B3BF File Offset: 0x000195BF
			public string CategoryLabel { get; private set; }

			// Token: 0x170001C6 RID: 454
			// (get) Token: 0x060007DB RID: 2011 RVA: 0x0001B3C8 File Offset: 0x000195C8
			// (set) Token: 0x060007DC RID: 2012 RVA: 0x0001B3D0 File Offset: 0x000195D0
			public string MapLabel { get; private set; }

			// Token: 0x170001C7 RID: 455
			// (get) Token: 0x060007DD RID: 2013 RVA: 0x0001B3D9 File Offset: 0x000195D9
			// (set) Token: 0x060007DE RID: 2014 RVA: 0x0001B3EB File Offset: 0x000195EB
			public string Category
			{
				get
				{
					return (string)base.GetValue(OpenDialog.OpenDialogContext.CategoryProperty);
				}
				set
				{
					base.SetValue(OpenDialog.OpenDialogContext.CategoryProperty, value);
				}
			}

			// Token: 0x170001C8 RID: 456
			// (get) Token: 0x060007DF RID: 2015 RVA: 0x0001B3F9 File Offset: 0x000195F9
			// (set) Token: 0x060007E0 RID: 2016 RVA: 0x0001B40B File Offset: 0x0001960B
			public string MapName
			{
				get
				{
					return (string)base.GetValue(OpenDialog.OpenDialogContext.MapNameProperty);
				}
				set
				{
					base.SetValue(OpenDialog.OpenDialogContext.MapNameProperty, value);
				}
			}

			// Token: 0x170001C9 RID: 457
			// (get) Token: 0x060007E1 RID: 2017 RVA: 0x0001B419 File Offset: 0x00019619
			// (set) Token: 0x060007E2 RID: 2018 RVA: 0x0001B421 File Offset: 0x00019621
			public bool IsDownloadedMap { get; private set; }

			// Token: 0x170001CA RID: 458
			// (get) Token: 0x060007E3 RID: 2019 RVA: 0x0001B42A File Offset: 0x0001962A
			// (set) Token: 0x060007E4 RID: 2020 RVA: 0x0001B432 File Offset: 0x00019632
			public List<string> CategoryList { get; private set; }

			// Token: 0x170001CB RID: 459
			// (get) Token: 0x060007E5 RID: 2021 RVA: 0x0001B43B File Offset: 0x0001963B
			// (set) Token: 0x060007E6 RID: 2022 RVA: 0x0001B44D File Offset: 0x0001964D
			public List<string> MapList
			{
				get
				{
					return (List<string>)base.GetValue(OpenDialog.OpenDialogContext.MapListProperty);
				}
				set
				{
					base.SetValue(OpenDialog.OpenDialogContext.MapListProperty, value);
				}
			}

			// Token: 0x060007E7 RID: 2023 RVA: 0x0001B45C File Offset: 0x0001965C
			public void PopulateMaps(string category)
			{
				List<string> list = new List<string>();
				if (category == this.localMaps)
				{
					if (Directory.Exists(StorageUtils.GetUserMapPath()))
					{
						string[] files = Directory.GetFiles(StorageUtils.GetUserMapPath(), StorageUtils.ExtensionFilter);
						foreach (string path in files)
						{
							list.Add(Path.GetFileName(path));
						}
					}
					this.IsDownloadedMap = false;
				}
				else if (category == this.downloadedMaps)
				{
					if (Directory.Exists(StorageUtils.GetDownloadMapPath()))
					{
						string[] files2 = Directory.GetFiles(StorageUtils.GetDownloadMapPath(), StorageUtils.ExtensionFilter);
						foreach (string path2 in files2)
						{
							list.Add(Path.GetFileName(path2));
						}
					}
					this.IsDownloadedMap = true;
				}
				this.MapList = list;
			}

			// Token: 0x040003DB RID: 987
			public static readonly DependencyProperty CategoryProperty = DependencyProperty.Register("Category", typeof(string), typeof(OpenDialog.OpenDialogContext), new UIPropertyMetadata(""));

			// Token: 0x040003DC RID: 988
			public static readonly DependencyProperty MapNameProperty = DependencyProperty.Register("MapName", typeof(string), typeof(OpenDialog.OpenDialogContext), new UIPropertyMetadata(""));

			// Token: 0x040003DD RID: 989
			private string localMaps;

			// Token: 0x040003DE RID: 990
			private string downloadedMaps;

			// Token: 0x040003DF RID: 991
			public static readonly DependencyProperty MapListProperty = DependencyProperty.Register("MapList", typeof(List<string>), typeof(OpenDialog.OpenDialogContext), new FrameworkPropertyMetadata(new List<string>()));
		}
	}
}
