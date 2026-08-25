using System;
using System.ComponentModel;
using Divelements.SandGrid.Resources;

namespace Divelements.SandGrid
{
	// Token: 0x0200002F RID: 47
	public class SortColumnsEventArgs : GridEventArgs
	{
		// Token: 0x06000490 RID: 1168 RVA: 0x00019A44 File Offset: 0x00018A44
		internal SortColumnsEventArgs(InnerGrid grid, GridColumn[] sortColumns, ListSortDirection[] sortDirections) : base(grid)
		{
			this.x94c6d9c743d62341 = sortColumns;
			this.x30193a48d57c0a72 = sortDirections;
		}

		// Token: 0x17000124 RID: 292
		// (get) Token: 0x06000491 RID: 1169 RVA: 0x00019A5C File Offset: 0x00018A5C
		// (set) Token: 0x06000492 RID: 1170 RVA: 0x00019A64 File Offset: 0x00018A64
		public GridColumn[] SortColumns
		{
			get
			{
				return this.x94c6d9c743d62341;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				SortColumnsEventArgs.x57985c45e2ab96ca(value);
				this.x94c6d9c743d62341 = value;
			}
		}

		// Token: 0x06000493 RID: 1171 RVA: 0x00019A84 File Offset: 0x00018A84
		internal static void x57985c45e2ab96ca(GridColumn[] xbcea506a33cf9111)
		{
			for (int i = 0; i < xbcea506a33cf9111.Length; i++)
			{
				if (xbcea506a33cf9111[i] == null)
				{
					throw new InvalidOperationException(xf1a67b6a145d2603.x538d63a1354c16f2("ExceptionNoNullsInArray"));
				}
			}
		}

		// Token: 0x17000125 RID: 293
		// (get) Token: 0x06000494 RID: 1172 RVA: 0x00019AB8 File Offset: 0x00018AB8
		// (set) Token: 0x06000495 RID: 1173 RVA: 0x00019AC0 File Offset: 0x00018AC0
		public ListSortDirection[] SortDirections
		{
			get
			{
				return this.x30193a48d57c0a72;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				this.x30193a48d57c0a72 = value;
			}
		}

		// Token: 0x04000162 RID: 354
		private GridColumn[] x94c6d9c743d62341;

		// Token: 0x04000163 RID: 355
		private ListSortDirection[] x30193a48d57c0a72;
	}
}
