using System;

namespace Divelements.SandGrid
{
	// Token: 0x02000074 RID: 116
	public class GridRowExpandCollapseEventArgs : GridRowEventArgs
	{
		// Token: 0x06000628 RID: 1576 RVA: 0x000205B4 File Offset: 0x0001F5B4
		internal GridRowExpandCollapseEventArgs(GridRow row, ExpandCollapseTrigger trigger) : base(row)
		{
			this.x195a4b0af9f9e88a = trigger;
		}

		// Token: 0x17000187 RID: 391
		// (get) Token: 0x06000629 RID: 1577 RVA: 0x000205C4 File Offset: 0x0001F5C4
		public ExpandCollapseTrigger Trigger
		{
			get
			{
				return this.x195a4b0af9f9e88a;
			}
		}

		// Token: 0x17000188 RID: 392
		// (get) Token: 0x0600062A RID: 1578 RVA: 0x000205CC File Offset: 0x0001F5CC
		// (set) Token: 0x0600062B RID: 1579 RVA: 0x000205D4 File Offset: 0x0001F5D4
		public bool Cancel
		{
			get
			{
				return this.x57602a0a0d178a2e;
			}
			set
			{
				this.x57602a0a0d178a2e = value;
			}
		}

		// Token: 0x0400025A RID: 602
		private ExpandCollapseTrigger x195a4b0af9f9e88a;

		// Token: 0x0400025B RID: 603
		private bool x57602a0a0d178a2e;
	}
}
