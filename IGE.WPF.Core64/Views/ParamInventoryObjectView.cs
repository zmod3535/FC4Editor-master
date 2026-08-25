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
	// Token: 0x02000032 RID: 50
	public class ParamInventoryObjectView : UserControl, IComponentConnector
	{
		// Token: 0x06000279 RID: 633 RVA: 0x000078B7 File Offset: 0x00005AB7
		public ParamInventoryObjectView()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600027A RID: 634 RVA: 0x000078C5 File Offset: 0x00005AC5
		private void Search_OnPreviewKeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Return)
			{
				ParamInventoryObjectView.UpdateTextBoxBinding((TextBox)sender);
			}
		}

		// Token: 0x0600027B RID: 635 RVA: 0x000078DB File Offset: 0x00005ADB
		private void Search_OnLostFocus(object sender, RoutedEventArgs e)
		{
			ParamInventoryObjectView.UpdateTextBoxBinding((TextBox)sender);
		}

		// Token: 0x0600027C RID: 636 RVA: 0x000078E8 File Offset: 0x00005AE8
		private static void UpdateTextBoxBinding(TextBox tBox)
		{
			DependencyProperty textProperty = TextBox.TextProperty;
			BindingExpression bindingExpression = BindingOperations.GetBindingExpression(tBox, textProperty);
			if (bindingExpression != null)
			{
				bindingExpression.UpdateSource();
			}
		}

		// Token: 0x0600027D RID: 637 RVA: 0x0000790C File Offset: 0x00005B0C
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/IGE.WPF.Core64;component/views/parameters/advanced/paraminventoryobjectview.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600027E RID: 638 RVA: 0x0000793C File Offset: 0x00005B3C
		[EditorBrowsable(EditorBrowsableState.Never)]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				((TextBox)target).PreviewKeyDown += this.Search_OnPreviewKeyDown;
				((TextBox)target).LostFocus += this.Search_OnLostFocus;
				return;
			}
			this._contentLoaded = true;
		}

		// Token: 0x04000109 RID: 265
		private bool _contentLoaded;
	}
}
