using System;

namespace Divelements.SandGrid
{
	// Token: 0x02000056 RID: 86
	public class GridColumnEventArgs : EventArgs
	{
		// Token: 0x0600054D RID: 1357 RVA: 0x0001BBAC File Offset: 0x0001ABAC
		internal GridColumnEventArgs(GridColumn gridColumn)
		{
			this.xcb753937f765a154 = gridColumn;
		}

		// Token: 0x17000150 RID: 336
		// (get) Token: 0x0600054E RID: 1358 RVA: 0x0001BBBC File Offset: 0x0001ABBC
		public GridColumn GridColumn
		{
			get
			{
				return this.xcb753937f765a154;
			}
		}

		// Token: 0x040001E9 RID: 489
		private GridColumn xcb753937f765a154;
	}
}
