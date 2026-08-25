using System;

namespace Divelements.SandGrid
{
	// Token: 0x0200000E RID: 14
	public class GridEventArgs : EventArgs
	{
		// Token: 0x06000238 RID: 568 RVA: 0x0000EDC4 File Offset: 0x0000DDC4
		internal GridEventArgs(InnerGrid grid)
		{
			this.x3040c866fac95193 = grid;
		}

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x06000239 RID: 569 RVA: 0x0000EDD4 File Offset: 0x0000DDD4
		public InnerGrid Grid
		{
			get
			{
				return this.x3040c866fac95193;
			}
		}

		// Token: 0x04000090 RID: 144
		private InnerGrid x3040c866fac95193;
	}
}
