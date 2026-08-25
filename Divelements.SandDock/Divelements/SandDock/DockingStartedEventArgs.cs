using System;

namespace Divelements.SandDock
{
	// Token: 0x02000014 RID: 20
	public class DockingStartedEventArgs : EventArgs
	{
		// Token: 0x060001E1 RID: 481 RVA: 0x00037F0C File Offset: 0x0003630C
		internal DockingStartedEventArgs(WindowDragSourceType dragSource)
		{
			this.x6e664442a9e05ea0 = dragSource;
		}

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x060001E2 RID: 482 RVA: 0x00037F1C File Offset: 0x0003631C
		public WindowDragSourceType DragSource
		{
			get
			{
				return this.x6e664442a9e05ea0;
			}
		}

		// Token: 0x04000094 RID: 148
		private WindowDragSourceType x6e664442a9e05ea0;
	}
}
