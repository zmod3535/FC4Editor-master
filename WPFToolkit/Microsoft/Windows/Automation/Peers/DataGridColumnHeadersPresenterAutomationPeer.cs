using System;
using System.Windows.Automation.Peers;
using Microsoft.Windows.Controls.Primitives;

namespace Microsoft.Windows.Automation.Peers
{
	// Token: 0x02000057 RID: 87
	public sealed class DataGridColumnHeadersPresenterAutomationPeer : FrameworkElementAutomationPeer
	{
		// Token: 0x060006D7 RID: 1751 RVA: 0x0001BEC5 File Offset: 0x0001A0C5
		public DataGridColumnHeadersPresenterAutomationPeer(DataGridColumnHeadersPresenter owner) : base(owner)
		{
		}

		// Token: 0x060006D8 RID: 1752 RVA: 0x0001BECE File Offset: 0x0001A0CE
		protected override AutomationControlType GetAutomationControlTypeCore()
		{
			return AutomationControlType.Header;
		}

		// Token: 0x060006D9 RID: 1753 RVA: 0x0001BED2 File Offset: 0x0001A0D2
		protected override string GetClassNameCore()
		{
			return base.Owner.GetType().Name;
		}

		// Token: 0x060006DA RID: 1754 RVA: 0x0001BEE4 File Offset: 0x0001A0E4
		protected override bool IsContentElementCore()
		{
			return false;
		}
	}
}
