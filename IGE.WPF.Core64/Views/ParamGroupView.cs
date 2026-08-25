using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

namespace IGE.Views
{
	// Token: 0x020000BA RID: 186
	public class ParamGroupView : UserControl, IComponentConnector
	{
		// Token: 0x0600071A RID: 1818 RVA: 0x000197CF File Offset: 0x000179CF
		public ParamGroupView()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600071B RID: 1819 RVA: 0x000197E0 File Offset: 0x000179E0
		private void ParamGroupView_OnPreviewMouseWheel(object sender, MouseWheelEventArgs e)
		{
			if (sender == this)
			{
				e.Handled = true;
				MouseWheelEventArgs e2 = new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta)
				{
					RoutedEvent = UIElement.MouseWheelEvent,
					Source = sender
				};
				UIElement uielement = ((ItemsControl)sender).Parent as UIElement;
				if (uielement != null)
				{
					uielement.RaiseEvent(e2);
					return;
				}
			}
			else
			{
				e.Handled = false;
			}
		}

		// Token: 0x0600071C RID: 1820 RVA: 0x00019848 File Offset: 0x00017A48
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/IGE.WPF.Core64;component/views/parameters/base/paramgroupview.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600071D RID: 1821 RVA: 0x00019878 File Offset: 0x00017A78
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.ScrollViewer = (ScrollViewer)target;
				this.ScrollViewer.PreviewMouseWheel += this.ParamGroupView_OnPreviewMouseWheel;
				return;
			}
			this._contentLoaded = true;
		}

		// Token: 0x040002DB RID: 731
		internal ScrollViewer ScrollViewer;

		// Token: 0x040002DC RID: 732
		private bool _contentLoaded;
	}
}
