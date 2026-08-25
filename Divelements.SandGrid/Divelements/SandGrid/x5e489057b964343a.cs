using System;
using System.Collections;

namespace Divelements.SandGrid
{
	// Token: 0x0200004C RID: 76
	internal class x5e489057b964343a : IEnumerator, IEnumerable
	{
		// Token: 0x06000517 RID: 1303 RVA: 0x0001AD20 File Offset: 0x00019D20
		public x5e489057b964343a(InnerGrid grid)
		{
			this.x3040c866fac95193 = grid;
		}

		// Token: 0x06000518 RID: 1304 RVA: 0x0001AD30 File Offset: 0x00019D30
		public IEnumerator GetEnumerator()
		{
			return this;
		}

		// Token: 0x17000149 RID: 329
		// (get) Token: 0x06000519 RID: 1305 RVA: 0x0001AD34 File Offset: 0x00019D34
		public object Current
		{
			get
			{
				return this.x7108a033166ea18e;
			}
		}

		// Token: 0x0600051A RID: 1306 RVA: 0x0001AD3C File Offset: 0x00019D3C
		public bool MoveNext()
		{
			if (this.x7108a033166ea18e == null)
			{
				this.x7108a033166ea18e = this.x3040c866fac95193.GetFirstVisibleRow();
			}
			else
			{
				this.x7108a033166ea18e = this.x7108a033166ea18e.NextVisibleRow;
			}
			return this.x7108a033166ea18e != null;
		}

		// Token: 0x0600051B RID: 1307 RVA: 0x0001AD78 File Offset: 0x00019D78
		public void Reset()
		{
			this.x7108a033166ea18e = null;
		}

		// Token: 0x040001C0 RID: 448
		private InnerGrid x3040c866fac95193;

		// Token: 0x040001C1 RID: 449
		private GridRow x7108a033166ea18e;
	}
}
