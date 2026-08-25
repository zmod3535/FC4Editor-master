using System;

namespace Divelements.SandDock
{
	// Token: 0x02000017 RID: 23
	public class WindowEventArgs : EventArgs
	{
		// Token: 0x060001E9 RID: 489 RVA: 0x00037F70 File Offset: 0x00036370
		internal WindowEventArgs(DockableWindow window)
		{
			this.x76b3d9d2638e5ecd = window;
		}

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x060001EA RID: 490 RVA: 0x00037F80 File Offset: 0x00036380
		public DockableWindow Window
		{
			get
			{
				return this.x76b3d9d2638e5ecd;
			}
		}

		// Token: 0x0400009D RID: 157
		private DockableWindow x76b3d9d2638e5ecd;
	}
}
