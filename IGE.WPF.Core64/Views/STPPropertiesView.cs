using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace IGE.Views
{
	// Token: 0x02000129 RID: 297
	public class STPPropertiesView : UserControl, IComponentConnector
	{
		// Token: 0x06000A67 RID: 2663 RVA: 0x00022542 File Offset: 0x00020742
		public STPPropertiesView()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000A68 RID: 2664 RVA: 0x00022550 File Offset: 0x00020750
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/IGE.WPF.Core64;component/views/objectproperties/stppropertiesview.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000A69 RID: 2665 RVA: 0x00022580 File Offset: 0x00020780
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000A6A RID: 2666 RVA: 0x0002258A File Offset: 0x0002078A
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040004F8 RID: 1272
		private bool _contentLoaded;
	}
}
