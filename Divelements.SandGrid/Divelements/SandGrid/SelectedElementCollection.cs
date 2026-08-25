using System;
using System.Collections;

namespace Divelements.SandGrid
{
	// Token: 0x02000020 RID: 32
	public class SelectedElementCollection : ReadOnlyCollectionBase
	{
		// Token: 0x060003AC RID: 940 RVA: 0x00015C70 File Offset: 0x00014C70
		internal SelectedElementCollection(InnerGrid grid)
		{
			this.x3040c866fac95193 = grid;
		}

		// Token: 0x060003AD RID: 941 RVA: 0x00015C80 File Offset: 0x00014C80
		public GridCell[] GetCells()
		{
			ArrayList arrayList = new ArrayList();
			foreach (object obj in this)
			{
				GridElement gridElement = (GridElement)obj;
				GridCell gridCell = gridElement as GridCell;
				if (gridCell != null)
				{
					arrayList.Add(gridCell);
				}
				GridRow gridRow = gridElement as GridRow;
				if (gridRow != null && gridRow.HasCells)
				{
					foreach (object obj2 in gridRow.Cells)
					{
						GridCell gridCell2 = (GridCell)obj2;
						if (!arrayList.Contains(gridCell2))
						{
							arrayList.Add(gridCell2);
						}
					}
				}
				GridColumn gridColumn = gridElement as GridColumn;
				if (gridColumn != null)
				{
					foreach (GridCell gridCell3 in gridColumn.GetCells())
					{
						if (!arrayList.Contains(gridCell3))
						{
							arrayList.Add(gridCell3);
						}
					}
				}
			}
			return (GridCell[])arrayList.ToArray(typeof(GridCell));
		}

		// Token: 0x060003AE RID: 942 RVA: 0x00015DD0 File Offset: 0x00014DD0
		public void Clear()
		{
			if (this.Count > 20)
			{
				foreach (object obj in base.InnerList)
				{
					GridElement gridElement = (GridElement)obj;
					gridElement.x213abd9ea5eb87d6 = false;
				}
				base.InnerList.Clear();
				base.InnerList.TrimToSize();
				this.x3040c866fac95193.x6d6f7a19a6e74243();
				this.x3040c866fac95193.x5e7a70d58e13247a();
				return;
			}
			this.x3040c866fac95193.x614e783eda4ed71f();
			foreach (GridElement gridElement2 in this.ToArray())
			{
				gridElement2.Selected = false;
			}
			this.x3040c866fac95193.x06727b7d4fe7a302();
		}

		// Token: 0x060003AF RID: 943 RVA: 0x00015EAC File Offset: 0x00014EAC
		internal void x3522790e002e1ba4(GridElement[] x6e96c3657c96bbbe)
		{
			this.x3040c866fac95193.x614e783eda4ed71f();
			this.Clear();
			base.InnerList.AddRange(x6e96c3657c96bbbe);
			foreach (GridElement gridElement in x6e96c3657c96bbbe)
			{
				gridElement.x213abd9ea5eb87d6 = true;
			}
			this.x3040c866fac95193.x6d6f7a19a6e74243();
			this.x3040c866fac95193.x06727b7d4fe7a302();
			this.x3040c866fac95193.x5e7a70d58e13247a();
		}

		// Token: 0x060003B0 RID: 944 RVA: 0x00015F14 File Offset: 0x00014F14
		internal void xd6b6ed77479ef68c(GridElement x4bbc2c453c470189)
		{
			base.InnerList.Add(x4bbc2c453c470189);
		}

		// Token: 0x060003B1 RID: 945 RVA: 0x00015F24 File Offset: 0x00014F24
		internal void x52b190e626f65140(GridElement x4bbc2c453c470189)
		{
			base.InnerList.Remove(x4bbc2c453c470189);
		}

		// Token: 0x060003B2 RID: 946 RVA: 0x00015F34 File Offset: 0x00014F34
		public bool Contains(GridElement element)
		{
			return base.InnerList.Contains(element);
		}

		// Token: 0x060003B3 RID: 947 RVA: 0x00015F44 File Offset: 0x00014F44
		public int IndexOf(GridElement element)
		{
			return base.InnerList.IndexOf(element);
		}

		// Token: 0x060003B4 RID: 948 RVA: 0x00015F54 File Offset: 0x00014F54
		public GridElement[] ToArray()
		{
			GridElement[] array = new GridElement[this.Count];
			base.InnerList.CopyTo(array);
			return array;
		}

		// Token: 0x170000F5 RID: 245
		public GridElement this[int index]
		{
			get
			{
				return (GridElement)base.InnerList[index];
			}
		}

		// Token: 0x04000117 RID: 279
		private InnerGrid x3040c866fac95193;
	}
}
