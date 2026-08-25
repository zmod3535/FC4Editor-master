using System;

namespace TD.SandDock
{
	// Token: 0x0200000C RID: 12
	public class DockControlEventArgs : EventArgs
	{
		// Token: 0x060000FA RID: 250 RVA: 0x0000BD14 File Offset: 0x0000AD14
		internal DockControlEventArgs(DockControl dockControl)
		{
			this.xdeac46e41e0fbcf5 = dockControl;
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x060000FB RID: 251 RVA: 0x0000BD24 File Offset: 0x0000AD24
		public DockControl DockControl
		{
			get
			{
				return this.xdeac46e41e0fbcf5;
			}
		}

		// Token: 0x0400004A RID: 74
		private DockControl xdeac46e41e0fbcf5;
	}
}
