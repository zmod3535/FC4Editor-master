using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using IGE.Parameters;

namespace IGE.Views
{
	// Token: 0x0200037D RID: 893
	public class ParamSlotListView : UserControl, IComponentConnector
	{
		// Token: 0x060013FC RID: 5116 RVA: 0x0002A002 File Offset: 0x00028202
		public ParamSlotListView()
		{
			this.InitializeComponent();
		}

		// Token: 0x060013FD RID: 5117 RVA: 0x0002A010 File Offset: 0x00028210
		private void ListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			ParamSlotListViewModel paramSlotListViewModel = base.DataContext as ParamSlotListViewModel;
			if (paramSlotListViewModel == null)
			{
				return;
			}
			paramSlotListViewModel.SelectedItem = ((e.AddedItems.Count == 0) ? null : (e.AddedItems[0] as ParamSlotItemViewModel));
		}

		// Token: 0x060013FE RID: 5118 RVA: 0x0002A054 File Offset: 0x00028254
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/IGE.WPF.Core64;component/views/parameters/advanced/paramslotlistview.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060013FF RID: 5119 RVA: 0x0002A084 File Offset: 0x00028284
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				((ListBox)target).SelectionChanged += this.ListBox_OnSelectionChanged;
				return;
			}
			this._contentLoaded = true;
		}

		// Token: 0x0400075F RID: 1887
		private bool _contentLoaded;
	}
}
