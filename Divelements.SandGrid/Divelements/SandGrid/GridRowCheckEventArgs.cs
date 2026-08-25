using System;

namespace Divelements.SandGrid
{
	// Token: 0x02000077 RID: 119
	public class GridRowCheckEventArgs : GridRowEventArgs
	{
		// Token: 0x06000630 RID: 1584 RVA: 0x000206E0 File Offset: 0x0001F6E0
		internal GridRowCheckEventArgs(GridRow row, CheckTrigger trigger) : base(row)
		{
			this.x195a4b0af9f9e88a = trigger;
		}

		// Token: 0x17000189 RID: 393
		// (get) Token: 0x06000631 RID: 1585 RVA: 0x000206F0 File Offset: 0x0001F6F0
		public CheckTrigger Trigger
		{
			get
			{
				return this.x195a4b0af9f9e88a;
			}
		}

		// Token: 0x1700018A RID: 394
		// (get) Token: 0x06000632 RID: 1586 RVA: 0x000206F8 File Offset: 0x0001F6F8
		// (set) Token: 0x06000633 RID: 1587 RVA: 0x00020700 File Offset: 0x0001F700
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

		// Token: 0x04000264 RID: 612
		private CheckTrigger x195a4b0af9f9e88a;

		// Token: 0x04000265 RID: 613
		private bool x57602a0a0d178a2e;
	}
}
