using System;
using System.Collections;

namespace Divelements.SandGrid
{
	// Token: 0x02000021 RID: 33
	public class GridCellCollection : CollectionBase
	{
		// Token: 0x060003B6 RID: 950 RVA: 0x00015F90 File Offset: 0x00014F90
		internal GridCellCollection(GridRow parent)
		{
			this.xb6a159a84cb992d6 = parent;
		}

		// Token: 0x060003B7 RID: 951 RVA: 0x00015FA0 File Offset: 0x00014FA0
		private void x54c65673061635c1()
		{
			for (int i = 0; i < base.Count; i++)
			{
				this[i].x87c7306436764333(i);
			}
			this.xb6a159a84cb992d6.MeasureNeeded();
		}

		// Token: 0x060003B8 RID: 952 RVA: 0x00015FD8 File Offset: 0x00014FD8
		public bool IsValidIndex(int index)
		{
			return index >= 0 && index < base.Count;
		}

		// Token: 0x060003B9 RID: 953 RVA: 0x00015FEC File Offset: 0x00014FEC
		protected override void OnClear()
		{
			base.OnClear();
			foreach (object obj in this)
			{
				GridCell gridCell = (GridCell)obj;
				gridCell.x973e390b09c57b95(null);
			}
		}

		// Token: 0x060003BA RID: 954 RVA: 0x00016054 File Offset: 0x00015054
		protected override void OnClearComplete()
		{
			base.OnClearComplete();
			this.x54c65673061635c1();
		}

		// Token: 0x060003BB RID: 955 RVA: 0x00016064 File Offset: 0x00015064
		protected override void OnInsertComplete(int index, object value)
		{
			base.OnInsertComplete(index, value);
			GridCell gridCell = (GridCell)value;
			gridCell.x973e390b09c57b95(this.xb6a159a84cb992d6);
			if (!this.x6278c23b2376c7c7)
			{
				this.x54c65673061635c1();
			}
		}

		// Token: 0x060003BC RID: 956 RVA: 0x0001609C File Offset: 0x0001509C
		protected override void OnRemoveComplete(int index, object value)
		{
			base.OnRemoveComplete(index, value);
			GridCell gridCell = (GridCell)value;
			gridCell.x973e390b09c57b95(null);
			this.x54c65673061635c1();
		}

		// Token: 0x060003BD RID: 957 RVA: 0x000160C8 File Offset: 0x000150C8
		public void AddRange(GridCell[] cells)
		{
			if (cells == null)
			{
				throw new ArgumentNullException("cells");
			}
			this.x6278c23b2376c7c7 = true;
			try
			{
				foreach (GridCell cell in cells)
				{
					this.Add(cell);
				}
			}
			finally
			{
				this.x6278c23b2376c7c7 = false;
			}
			this.x54c65673061635c1();
		}

		// Token: 0x060003BE RID: 958 RVA: 0x00016134 File Offset: 0x00015134
		public int Add(GridCell cell)
		{
			int count = base.Count;
			this.Insert(count, cell);
			return count;
		}

		// Token: 0x060003BF RID: 959 RVA: 0x00016154 File Offset: 0x00015154
		public void Insert(int index, GridCell cell)
		{
			if (cell == null)
			{
				throw new ArgumentNullException("cell");
			}
			if (cell.ParentRow != null)
			{
				cell.ParentRow.Cells.Remove(cell);
			}
			base.List.Insert(index, cell);
		}

		// Token: 0x170000F6 RID: 246
		public GridCell this[int index]
		{
			get
			{
				return (GridCell)base.List[index];
			}
		}

		// Token: 0x060003C1 RID: 961 RVA: 0x000161A0 File Offset: 0x000151A0
		public void Remove(GridCell cell)
		{
			if (cell == null)
			{
				throw new ArgumentNullException("cell");
			}
			base.List.Remove(cell);
		}

		// Token: 0x060003C2 RID: 962 RVA: 0x000161BC File Offset: 0x000151BC
		public bool Contains(GridCell cell)
		{
			return base.List.Contains(cell);
		}

		// Token: 0x060003C3 RID: 963 RVA: 0x000161CC File Offset: 0x000151CC
		public int IndexOf(GridCell cell)
		{
			return base.List.IndexOf(cell);
		}

		// Token: 0x060003C4 RID: 964 RVA: 0x000161DC File Offset: 0x000151DC
		public void CopyTo(GridCell[] array, int index)
		{
			base.List.CopyTo(array, index);
		}

		// Token: 0x04000118 RID: 280
		private GridRow xb6a159a84cb992d6;

		// Token: 0x04000119 RID: 281
		private bool x6278c23b2376c7c7;
	}
}
