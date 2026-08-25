using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace IGE.Views
{
	// Token: 0x020000B5 RID: 181
	public class ParamVectorView : UserControl, IComponentConnector
	{
		// Token: 0x06000704 RID: 1796 RVA: 0x0001957E File Offset: 0x0001777E
		public ParamVectorView()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000705 RID: 1797 RVA: 0x0001958C File Offset: 0x0001778C
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/IGE.WPF.Core64;component/views/parameters/base/paramvectorview.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000706 RID: 1798 RVA: 0x000195BC File Offset: 0x000177BC
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000707 RID: 1799 RVA: 0x000195C6 File Offset: 0x000177C6
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerNonUserCode]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040002D6 RID: 726
		private bool _contentLoaded;
	}
}
