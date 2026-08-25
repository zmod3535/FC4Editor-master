using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;

namespace IGE.Views
{
	// Token: 0x020000E2 RID: 226
	public class ToolbarButton : ToggleButton, IComponentConnector
	{
		// Token: 0x06000819 RID: 2073 RVA: 0x0001BE39 File Offset: 0x0001A039
		public ToolbarButton()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600081A RID: 2074 RVA: 0x0001BE48 File Offset: 0x0001A048
		private void ToggleButton_Click(object sender, RoutedEventArgs e)
		{
			ToolbarButton toolbarButton = sender as ToolbarButton;
			if (toolbarButton.IsChecked == false)
			{
				toolbarButton.IsChecked = new bool?(true);
			}
		}

		// Token: 0x0600081B RID: 2075 RVA: 0x0001BE84 File Offset: 0x0001A084
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/IGE.WPF.Core64;component/views/toolbars/toolbarbutton.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600081C RID: 2076 RVA: 0x0001BEB4 File Offset: 0x0001A0B4
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				((ToolbarButton)target).Click += this.ToggleButton_Click;
				return;
			}
			this._contentLoaded = true;
		}

		// Token: 0x040003F0 RID: 1008
		private bool _contentLoaded;
	}
}
