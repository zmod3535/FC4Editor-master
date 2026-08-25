using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;

namespace IGE.Views
{
	// Token: 0x0200011F RID: 287
	public class ParamFloatView : UserControl, IComponentConnector
	{
		// Token: 0x06000A06 RID: 2566 RVA: 0x000211FD File Offset: 0x0001F3FD
		public ParamFloatView()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000A07 RID: 2567 RVA: 0x0002120C File Offset: 0x0001F40C
		private void ParamFloatView_OnKeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Return)
			{
				TextBox textBox = (TextBox)sender;
				BindingExpression bindingExpression = textBox.GetBindingExpression(TextBox.TextProperty);
				bindingExpression.UpdateSource();
				e.Handled = true;
			}
		}

		// Token: 0x06000A08 RID: 2568 RVA: 0x00021244 File Offset: 0x0001F444
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/IGE.WPF.Core64;component/views/parameters/base/paramfloatview.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000A09 RID: 2569 RVA: 0x00021274 File Offset: 0x0001F474
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				((TextBox)target).KeyDown += this.ParamFloatView_OnKeyDown;
				return;
			}
			this._contentLoaded = true;
		}

		// Token: 0x040004CC RID: 1228
		private bool _contentLoaded;
	}
}
