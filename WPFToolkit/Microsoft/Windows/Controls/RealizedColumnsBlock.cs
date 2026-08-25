using System;

namespace Microsoft.Windows.Controls
{
	// Token: 0x0200005B RID: 91
	internal struct RealizedColumnsBlock
	{
		// Token: 0x06000719 RID: 1817 RVA: 0x0001DFAD File Offset: 0x0001C1AD
		public RealizedColumnsBlock(int startIndex, int endIndex, int startIndexOffset)
		{
			this = default(RealizedColumnsBlock);
			this.StartIndex = startIndex;
			this.EndIndex = endIndex;
			this.StartIndexOffset = startIndexOffset;
		}

		// Token: 0x170001AC RID: 428
		// (get) Token: 0x0600071A RID: 1818 RVA: 0x0001DFCB File Offset: 0x0001C1CB
		// (set) Token: 0x0600071B RID: 1819 RVA: 0x0001DFD3 File Offset: 0x0001C1D3
		public int StartIndex { get; private set; }

		// Token: 0x170001AD RID: 429
		// (get) Token: 0x0600071C RID: 1820 RVA: 0x0001DFDC File Offset: 0x0001C1DC
		// (set) Token: 0x0600071D RID: 1821 RVA: 0x0001DFE4 File Offset: 0x0001C1E4
		public int EndIndex { get; private set; }

		// Token: 0x170001AE RID: 430
		// (get) Token: 0x0600071E RID: 1822 RVA: 0x0001DFED File Offset: 0x0001C1ED
		// (set) Token: 0x0600071F RID: 1823 RVA: 0x0001DFF5 File Offset: 0x0001C1F5
		public int StartIndexOffset { get; private set; }
	}
}
