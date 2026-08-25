using System;
using System.Windows.Automation.Peers;
using Microsoft.Windows.Controls.Primitives;

namespace Microsoft.Windows.Automation.Peers
{
	// Token: 0x02000041 RID: 65
	public sealed class DataGridDetailsPresenterAutomationPeer : FrameworkElementAutomationPeer
	{
		// Token: 0x060004D8 RID: 1240 RVA: 0x00013240 File Offset: 0x00011440
		public DataGridDetailsPresenterAutomationPeer(DataGridDetailsPresenter owner) : base(owner)
		{
		}

		// Token: 0x060004D9 RID: 1241 RVA: 0x00013249 File Offset: 0x00011449
		protected override string GetClassNameCore()
		{
			return base.Owner.GetType().Name;
		}

		// Token: 0x060004DA RID: 1242 RVA: 0x0001325B File Offset: 0x0001145B
		protected override bool IsContentElementCore()
		{
			return false;
		}
	}
}
