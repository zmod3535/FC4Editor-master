using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using IGE.Nomad;
using IGE.ViewModels;

namespace IGE.Views
{
	// Token: 0x020000F0 RID: 240
	public class PromptInventoryView : Window, IComponentConnector
	{
		// Token: 0x06000871 RID: 2161 RVA: 0x0001C9B7 File Offset: 0x0001ABB7
		public PromptInventoryView(Inventory.Entry root)
		{
			this.InitializeComponent();
			this._context = (PromptInventoryViewModel)base.DataContext;
			this._context.Root = root;
		}

		// Token: 0x06000872 RID: 2162 RVA: 0x0001C9E2 File Offset: 0x0001ABE2
		public PromptInventoryView()
		{
			throw new Exception();
		}

		// Token: 0x170001E6 RID: 486
		// (get) Token: 0x06000873 RID: 2163 RVA: 0x0001C9EF File Offset: 0x0001ABEF
		public Inventory.Entry Result
		{
			get
			{
				return this._context.Value;
			}
		}

		// Token: 0x06000874 RID: 2164 RVA: 0x0001C9FC File Offset: 0x0001ABFC
		private void ButtonOk_Click(object sender, RoutedEventArgs e)
		{
			base.DialogResult = new bool?(true);
			base.Close();
		}

		// Token: 0x06000875 RID: 2165 RVA: 0x0001CA10 File Offset: 0x0001AC10
		private void ButtonCancel_Click(object sender, RoutedEventArgs e)
		{
			base.DialogResult = new bool?(false);
			base.Close();
		}

		// Token: 0x06000876 RID: 2166 RVA: 0x0001CA24 File Offset: 0x0001AC24
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/IGE.WPF.Core64;component/views/windows/promptinventoryview.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000877 RID: 2167 RVA: 0x0001CA54 File Offset: 0x0001AC54
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				((Button)target).Click += this.ButtonOk_Click;
				return;
			case 2:
				((Button)target).Click += this.ButtonCancel_Click;
				return;
			default:
				this._contentLoaded = true;
				return;
			}
		}

		// Token: 0x0400041F RID: 1055
		private readonly PromptInventoryViewModel _context;

		// Token: 0x04000420 RID: 1056
		private bool _contentLoaded;
	}
}
