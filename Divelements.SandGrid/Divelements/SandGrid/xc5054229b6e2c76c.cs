using System;
using System.Collections;

namespace Divelements.SandGrid
{
	// Token: 0x02000080 RID: 128
	internal class xc5054229b6e2c76c : IEnumerator, IEnumerable
	{
		// Token: 0x06000644 RID: 1604 RVA: 0x00020CC8 File Offset: 0x0001FCC8
		public xc5054229b6e2c76c(InnerGrid grid, int scrollOffset, int viewportWidth)
		{
			this.x3040c866fac95193 = grid;
			this.x200b7f5a9d983ba4 = scrollOffset;
			this.xfe47d4a50ed9671c = viewportWidth;
		}

		// Token: 0x06000645 RID: 1605 RVA: 0x00020CE8 File Offset: 0x0001FCE8
		IEnumerator IEnumerable.x05b0b83b5e6c5de6()
		{
			return this;
		}

		// Token: 0x1700018E RID: 398
		// (get) Token: 0x06000646 RID: 1606 RVA: 0x00020CEC File Offset: 0x0001FCEC
		public object Current
		{
			get
			{
				return this.x3ed25201f92209a1;
			}
		}

		// Token: 0x06000647 RID: 1607 RVA: 0x00020CF4 File Offset: 0x0001FCF4
		public bool MoveNext()
		{
			if (this.x3ed25201f92209a1 == null && this.x3040c866fac95193.Columns.Count == 0)
			{
				return false;
			}
			GridColumn gridColumn = this.x3ed25201f92209a1;
			for (;;)
			{
				gridColumn = ((gridColumn == null) ? this.x3040c866fac95193.Columns[this.x3040c866fac95193.FirstVisibleColumn] : this.x607f382ce7ba50b2(this.x3ed25201f92209a1));
				if (gridColumn == null)
				{
					break;
				}
				if (gridColumn.Visible)
				{
					goto Block_5;
				}
			}
			return false;
			Block_5:
			if (gridColumn.Bounds.Left > this.x200b7f5a9d983ba4 + this.xfe47d4a50ed9671c)
			{
				return false;
			}
			this.x3ed25201f92209a1 = gridColumn;
			return true;
		}

		// Token: 0x06000648 RID: 1608 RVA: 0x00020D88 File Offset: 0x0001FD88
		private GridColumn x607f382ce7ba50b2(GridColumn x3b6fb98847c1b926)
		{
			if (x3b6fb98847c1b926.Index < this.x3040c866fac95193.Columns.Count - 1)
			{
				return this.x3040c866fac95193.Columns[x3b6fb98847c1b926.Index + 1];
			}
			return null;
		}

		// Token: 0x06000649 RID: 1609 RVA: 0x00020DC0 File Offset: 0x0001FDC0
		public void Reset()
		{
			this.x3ed25201f92209a1 = null;
		}

		// Token: 0x0400027D RID: 637
		private InnerGrid x3040c866fac95193;

		// Token: 0x0400027E RID: 638
		private int x200b7f5a9d983ba4;

		// Token: 0x0400027F RID: 639
		private int xfe47d4a50ed9671c;

		// Token: 0x04000280 RID: 640
		private GridColumn x3ed25201f92209a1;
	}
}
