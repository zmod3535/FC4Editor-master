using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace IGE.Views
{
	// Token: 0x0200000B RID: 11
	public class ParamObjectSelectionView : UserControl, IComponentConnector
	{
		// Token: 0x06000031 RID: 49 RVA: 0x00002445 File Offset: 0x00000645
		public ParamObjectSelectionView()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00002454 File Offset: 0x00000654
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/IGE.WPF.Core64;component/views/parameters/advanced/paramobjectselectionview.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00002484 File Offset: 0x00000684
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000010 RID: 16
		private bool _contentLoaded;
	}
}
