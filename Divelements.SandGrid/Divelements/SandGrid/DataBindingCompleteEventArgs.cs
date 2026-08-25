using System;
using System.ComponentModel;

namespace Divelements.SandGrid
{
	// Token: 0x02000046 RID: 70
	public class DataBindingCompleteEventArgs : EventArgs
	{
		// Token: 0x06000506 RID: 1286 RVA: 0x0001AC1C File Offset: 0x00019C1C
		internal DataBindingCompleteEventArgs(InnerGrid grid, ListChangedEventArgs originalEvent)
		{
			this.x3040c866fac95193 = grid;
			this.x013ede522a558373 = originalEvent;
		}

		// Token: 0x17000145 RID: 325
		// (get) Token: 0x06000507 RID: 1287 RVA: 0x0001AC34 File Offset: 0x00019C34
		public InnerGrid Grid
		{
			get
			{
				return this.x3040c866fac95193;
			}
		}

		// Token: 0x17000146 RID: 326
		// (get) Token: 0x06000508 RID: 1288 RVA: 0x0001AC3C File Offset: 0x00019C3C
		public ListChangedType ListChangedType
		{
			get
			{
				return this.x013ede522a558373.ListChangedType;
			}
		}

		// Token: 0x17000147 RID: 327
		// (get) Token: 0x06000509 RID: 1289 RVA: 0x0001AC4C File Offset: 0x00019C4C
		public ListChangedEventArgs OriginalEvent
		{
			get
			{
				return this.x013ede522a558373;
			}
		}

		// Token: 0x040001B4 RID: 436
		private InnerGrid x3040c866fac95193;

		// Token: 0x040001B5 RID: 437
		private ListChangedEventArgs x013ede522a558373;
	}
}
