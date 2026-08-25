using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace IGE.Views
{
	// Token: 0x02000089 RID: 137
	public class ParamEnumButtonImageView : UserControl, IComponentConnector
	{
		// Token: 0x060005AB RID: 1451 RVA: 0x00015795 File Offset: 0x00013995
		public ParamEnumButtonImageView()
		{
			this.InitializeComponent();
		}

		// Token: 0x060005AC RID: 1452 RVA: 0x000157A4 File Offset: 0x000139A4
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/IGE.WPF.Core64;component/views/parameters/items/paramenumbuttonimageview.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060005AD RID: 1453 RVA: 0x000157D4 File Offset: 0x000139D4
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x0400026D RID: 621
		private bool _contentLoaded;
	}
}
