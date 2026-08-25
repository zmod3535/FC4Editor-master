using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace IGE.Views
{
	// Token: 0x02000377 RID: 887
	public class ParamWaterMaterialView : UserControl, IComponentConnector
	{
		// Token: 0x060013A9 RID: 5033 RVA: 0x00028EFB File Offset: 0x000270FB
		public ParamWaterMaterialView()
		{
			this.InitializeComponent();
		}

		// Token: 0x060013AA RID: 5034 RVA: 0x00028F0C File Offset: 0x0002710C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/IGE.WPF.Core64;component/views/parameters/advanced/paramwatermatertialview.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060013AB RID: 5035 RVA: 0x00028F3C File Offset: 0x0002713C
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x0400073E RID: 1854
		private bool _contentLoaded;
	}
}
