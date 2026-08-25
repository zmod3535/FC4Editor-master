using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Markup;

namespace IGE.Views
{
	// Token: 0x020000B6 RID: 182
	public class ParamEnumButtonItemView : UserControl, IComponentConnector
	{
		// Token: 0x06000708 RID: 1800 RVA: 0x000195CF File Offset: 0x000177CF
		public ParamEnumButtonItemView()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000709 RID: 1801 RVA: 0x000195E0 File Offset: 0x000177E0
		private void Button_OnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			if (((ToggleButton)sender).IsChecked == true)
			{
				e.Handled = true;
			}
		}

		// Token: 0x0600070A RID: 1802 RVA: 0x00019618 File Offset: 0x00017818
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/IGE.WPF.Core64;component/views/parameters/items/paramenumbuttonitemview.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600070B RID: 1803 RVA: 0x00019648 File Offset: 0x00017848
		[EditorBrowsable(EditorBrowsableState.Never)]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				((ToggleButton)target).PreviewMouseLeftButtonDown += this.Button_OnPreviewMouseLeftButtonDown;
				return;
			}
			this._contentLoaded = true;
		}

		// Token: 0x040002D7 RID: 727
		private bool _contentLoaded;
	}
}
