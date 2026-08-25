using System;

namespace TD.SandDock
{
	// Token: 0x0200004B RID: 75
	public class DockControlClosingEventArgs : DockControlEventArgs
	{
		// Token: 0x060004F8 RID: 1272 RVA: 0x00026744 File Offset: 0x00025744
		internal DockControlClosingEventArgs(DockControl dockControl, bool cancel) : base(dockControl)
		{
			this.x57602a0a0d178a2e = cancel;
		}

		// Token: 0x17000143 RID: 323
		// (get) Token: 0x060004F9 RID: 1273 RVA: 0x00026754 File Offset: 0x00025754
		// (set) Token: 0x060004FA RID: 1274 RVA: 0x0002675C File Offset: 0x0002575C
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

		// Token: 0x040001CD RID: 461
		private bool x57602a0a0d178a2e;
	}
}
