using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using IGE.Parameters;

namespace IGE.Views
{
	// Token: 0x02000025 RID: 37
	public class ParamEnumListView : UserControl, IComponentConnector
	{
		// Token: 0x0600010A RID: 266 RVA: 0x00003784 File Offset: 0x00001984
		public ParamEnumListView()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600010B RID: 267 RVA: 0x00003794 File Offset: 0x00001994
		private void ListBox_OnDoubleClick(object sender, RoutedEventArgs e)
		{
			ParamEnumList paramEnumList = base.DataContext as ParamEnumList;
			if (paramEnumList != null)
			{
				paramEnumList.SelectionDoubleClicked();
			}
		}

		// Token: 0x0600010C RID: 268 RVA: 0x000037B8 File Offset: 0x000019B8
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/IGE.WPF.Core64;component/views/parameters/base/paramenumlistview.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600010D RID: 269 RVA: 0x000037E8 File Offset: 0x000019E8
		[DebuggerNonUserCode]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				((ListBox)target).MouseDoubleClick += new MouseButtonEventHandler(this.ListBox_OnDoubleClick);
				return;
			}
			this._contentLoaded = true;
		}

		// Token: 0x04000054 RID: 84
		private bool _contentLoaded;
	}
}
