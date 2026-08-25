using System;
using System.Collections;

namespace Divelements.SandGrid
{
	// Token: 0x0200007F RID: 127
	internal class xef6ea4ade4525df4 : IEnumerator, IEnumerable
	{
		// Token: 0x0600063F RID: 1599 RVA: 0x00020C3C File Offset: 0x0001FC3C
		public xef6ea4ade4525df4(InnerGrid grid)
		{
			this.x3040c866fac95193 = grid;
		}

		// Token: 0x06000640 RID: 1600 RVA: 0x00020C4C File Offset: 0x0001FC4C
		public IEnumerator GetEnumerator()
		{
			return this;
		}

		// Token: 0x1700018D RID: 397
		// (get) Token: 0x06000641 RID: 1601 RVA: 0x00020C50 File Offset: 0x0001FC50
		public object Current
		{
			get
			{
				return this.x7108a033166ea18e;
			}
		}

		// Token: 0x06000642 RID: 1602 RVA: 0x00020C58 File Offset: 0x0001FC58
		public bool MoveNext()
		{
			if (this.x7108a033166ea18e == null)
			{
				this.x7108a033166ea18e = ((this.x3040c866fac95193.Rows.Count != 0) ? this.x3040c866fac95193.Rows[0] : null);
			}
			else
			{
				this.x7108a033166ea18e = this.x7108a033166ea18e.xa4c746a623bbf4f4(false);
			}
			return this.x7108a033166ea18e != null;
		}

		// Token: 0x06000643 RID: 1603 RVA: 0x00020CBC File Offset: 0x0001FCBC
		public void Reset()
		{
			this.x7108a033166ea18e = null;
		}

		// Token: 0x0400027B RID: 635
		private InnerGrid x3040c866fac95193;

		// Token: 0x0400027C RID: 636
		private GridRow x7108a033166ea18e;
	}
}
