using System;

namespace TD.SandBar
{
	// Token: 0x02000013 RID: 19
	public class ToolBarItemEventArgs : EventArgs
	{
		// Token: 0x06000138 RID: 312 RVA: 0x00006520 File Offset: 0x00005520
		public ToolBarItemEventArgs(ToolbarItemBase item)
		{
			this.xccb63ca5f63dc470 = item;
		}

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x06000139 RID: 313 RVA: 0x00006530 File Offset: 0x00005530
		public ToolbarItemBase Item
		{
			get
			{
				return this.xccb63ca5f63dc470;
			}
		}

		// Token: 0x04000079 RID: 121
		private ToolbarItemBase xccb63ca5f63dc470;
	}
}
