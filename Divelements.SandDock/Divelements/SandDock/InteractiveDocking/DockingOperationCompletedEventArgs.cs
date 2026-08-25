using System;

namespace Divelements.SandDock.InteractiveDocking
{
	// Token: 0x0200003A RID: 58
	public class DockingOperationCompletedEventArgs : EventArgs
	{
		// Token: 0x0600037D RID: 893 RVA: 0x00040400 File Offset: 0x0003E800
		internal DockingOperationCompletedEventArgs(DockingOperationBase operation)
		{
			this.x1437816edeb48c46 = operation;
		}

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x0600037E RID: 894 RVA: 0x00040410 File Offset: 0x0003E810
		public DockingOperationBase Operation
		{
			get
			{
				return this.x1437816edeb48c46;
			}
		}

		// Token: 0x04000154 RID: 340
		private DockingOperationBase x1437816edeb48c46;
	}
}
