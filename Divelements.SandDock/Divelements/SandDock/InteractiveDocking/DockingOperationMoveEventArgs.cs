using System;

namespace Divelements.SandDock.InteractiveDocking
{
	// Token: 0x0200003D RID: 61
	public class DockingOperationMoveEventArgs : EventArgs
	{
		// Token: 0x06000384 RID: 900 RVA: 0x00040438 File Offset: 0x0003E838
		internal DockingOperationMoveEventArgs(int newIndex)
		{
			this.x873721d4383ca28a = newIndex;
		}

		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x06000385 RID: 901 RVA: 0x00040448 File Offset: 0x0003E848
		public int NewIndex
		{
			get
			{
				return this.x873721d4383ca28a;
			}
		}

		// Token: 0x0400015A RID: 346
		private int x873721d4383ca28a;
	}
}
