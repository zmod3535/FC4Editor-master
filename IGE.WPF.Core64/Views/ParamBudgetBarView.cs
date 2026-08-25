using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Shapes;
using IGE.Parameters;

namespace IGE.Views
{
	// Token: 0x02000386 RID: 902
	public class ParamBudgetBarView : UserControl, IComponentConnector
	{
		// Token: 0x0600145B RID: 5211 RVA: 0x0002B366 File Offset: 0x00029566
		public ParamBudgetBarView()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600145C RID: 5212 RVA: 0x0002B374 File Offset: 0x00029574
		public void BarRectSizeChangedHandler(object sender, SizeChangedEventArgs e)
		{
			ParamBudgetBar paramBudgetBar = base.DataContext as ParamBudgetBar;
			if (paramBudgetBar != null)
			{
				paramBudgetBar.OnResize((float)e.NewSize.Width);
			}
		}

		// Token: 0x0600145D RID: 5213 RVA: 0x0002B3A8 File Offset: 0x000295A8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/IGE.WPF.Core64;component/views/parameters/base/parambudgetbarview.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600145E RID: 5214 RVA: 0x0002B3D8 File Offset: 0x000295D8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				this.LayoutRoot = (Grid)target;
				return;
			case 2:
				this.BarRect = (Grid)target;
				this.BarRect.SizeChanged += this.BarRectSizeChangedHandler;
				return;
			case 3:
				this.BudgetRect = (Rectangle)target;
				return;
			case 4:
				this.CurrentRect = (Rectangle)target;
				return;
			case 5:
				this.AmbientRect = (Rectangle)target;
				return;
			case 6:
				this.PercentageText = (Label)target;
				return;
			default:
				this._contentLoaded = true;
				return;
			}
		}

		// Token: 0x04000776 RID: 1910
		internal Grid LayoutRoot;

		// Token: 0x04000777 RID: 1911
		internal Grid BarRect;

		// Token: 0x04000778 RID: 1912
		internal Rectangle BudgetRect;

		// Token: 0x04000779 RID: 1913
		internal Rectangle CurrentRect;

		// Token: 0x0400077A RID: 1914
		internal Rectangle AmbientRect;

		// Token: 0x0400077B RID: 1915
		internal Label PercentageText;

		// Token: 0x0400077C RID: 1916
		private bool _contentLoaded;
	}
}
