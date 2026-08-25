using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using IGE.Nomad;

namespace IGE.Views
{
	// Token: 0x020000A4 RID: 164
	public class TermsOfUse : Window, IComponentConnector
	{
		// Token: 0x060006B5 RID: 1717 RVA: 0x00018701 File Offset: 0x00016901
		public TermsOfUse(string termsText)
		{
			this.InitializeComponent();
			this.ebTerms.Text = termsText;
			base.Title = Localizer.Localize("PUBLISH_AGREETOTERMS_TITLE", "SystemMenu");
		}

		// Token: 0x060006B6 RID: 1718 RVA: 0x00018730 File Offset: 0x00016930
		private void btnCancel_Click(object sender, RoutedEventArgs e)
		{
			base.DialogResult = new bool?(false);
		}

		// Token: 0x060006B7 RID: 1719 RVA: 0x0001873E File Offset: 0x0001693E
		private void btnOk_Click(object sender, RoutedEventArgs e)
		{
			base.DialogResult = new bool?(true);
		}

		// Token: 0x060006B8 RID: 1720 RVA: 0x0001874C File Offset: 0x0001694C
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/IGE.WPF.Core64;component/views/windows/termsofuse.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060006B9 RID: 1721 RVA: 0x0001877C File Offset: 0x0001697C
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				this.btnCancel = (Button)target;
				this.btnCancel.Click += this.btnCancel_Click;
				return;
			case 2:
				this.btnOk = (Button)target;
				this.btnOk.Click += this.btnOk_Click;
				return;
			case 3:
				this.ebTerms = (TextBox)target;
				return;
			default:
				this._contentLoaded = true;
				return;
			}
		}

		// Token: 0x040002AB RID: 683
		internal Button btnCancel;

		// Token: 0x040002AC RID: 684
		internal Button btnOk;

		// Token: 0x040002AD RID: 685
		internal TextBox ebTerms;

		// Token: 0x040002AE RID: 686
		private bool _contentLoaded;
	}
}
