using System;
using System.Collections;

namespace Divelements.SandGrid
{
	// Token: 0x0200004B RID: 75
	internal class xcb78343a5ebfa7a3 : IEnumerator, IEnumerable
	{
		// Token: 0x06000512 RID: 1298 RVA: 0x0001AC54 File Offset: 0x00019C54
		public xcb78343a5ebfa7a3(InnerGrid grid, int scrollOffset, int viewportHeight)
		{
			this.x3040c866fac95193 = grid;
			this.x200b7f5a9d983ba4 = scrollOffset;
			this.xee67ff403e25c51f = viewportHeight;
		}

		// Token: 0x06000513 RID: 1299 RVA: 0x0001AC74 File Offset: 0x00019C74
		IEnumerator IEnumerable.x05b0b83b5e6c5de6()
		{
			return this;
		}

		// Token: 0x17000148 RID: 328
		// (get) Token: 0x06000514 RID: 1300 RVA: 0x0001AC78 File Offset: 0x00019C78
		public object Current
		{
			get
			{
				return this.xc0fdea7a43fe2912;
			}
		}

		// Token: 0x06000515 RID: 1301 RVA: 0x0001AC80 File Offset: 0x00019C80
		public bool MoveNext()
		{
			if (this.xc0fdea7a43fe2912 == null && this.x3040c866fac95193.Rows.Count == 0)
			{
				return false;
			}
			GridRow gridRow = this.xc0fdea7a43fe2912;
			for (;;)
			{
				gridRow = ((gridRow == null) ? this.x3040c866fac95193.x699c923a60e155ff : gridRow.NextVisibleRow);
				if (gridRow == null)
				{
					break;
				}
				if (this.xc0fdea7a43fe2912 != null || gridRow.Bounds.Bottom >= this.x200b7f5a9d983ba4)
				{
					goto IL_5D;
				}
			}
			return false;
			IL_5D:
			if (gridRow.Bounds.Top > this.x200b7f5a9d983ba4 + this.xee67ff403e25c51f)
			{
				return false;
			}
			this.xc0fdea7a43fe2912 = gridRow;
			return true;
		}

		// Token: 0x06000516 RID: 1302 RVA: 0x0001AD14 File Offset: 0x00019D14
		public void Reset()
		{
			this.xc0fdea7a43fe2912 = null;
		}

		// Token: 0x040001BC RID: 444
		private InnerGrid x3040c866fac95193;

		// Token: 0x040001BD RID: 445
		private int x200b7f5a9d983ba4;

		// Token: 0x040001BE RID: 446
		private int xee67ff403e25c51f;

		// Token: 0x040001BF RID: 447
		private GridRow xc0fdea7a43fe2912;
	}
}
