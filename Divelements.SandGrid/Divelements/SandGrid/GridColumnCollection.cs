using System;
using System.Collections;
using Divelements.SandGrid.Resources;

namespace Divelements.SandGrid
{
	// Token: 0x02000022 RID: 34
	public class GridColumnCollection : CollectionBase
	{
		// Token: 0x060003C5 RID: 965 RVA: 0x000161EC File Offset: 0x000151EC
		internal GridColumnCollection(InnerGrid parent)
		{
			this.xb6a159a84cb992d6 = parent;
		}

		// Token: 0x060003C6 RID: 966 RVA: 0x00016214 File Offset: 0x00015214
		public bool IsValidIndex(int index)
		{
			return index >= 0 && index < base.Count;
		}

		// Token: 0x060003C7 RID: 967 RVA: 0x00016228 File Offset: 0x00015228
		internal void xe3d225b642287874()
		{
			this.xba25a079bf34250f = false;
			int num;
			GridColumn[] array2;
			do
			{
				int[] array = new int[base.Count];
				num = 0;
				for (int i = 0; i < base.Count; i++)
				{
					this[i].x87c7306436764333(i);
					array[i] = this[i].DisplayIndex;
					if (this[i].Visible)
					{
						num++;
					}
					if (this[i].AutoSize == ColumnAutoSizeMode.Spring)
					{
						this.xba25a079bf34250f = true;
					}
				}
				array2 = this.ToArray();
				Array.Sort<int, GridColumn>(array, array2);
				this.xb2cfa94692dcec88 = new GridColumn[num];
				num = 0;
			}
			while (2 == 0);
			for (int j = 0; j < array2.Length; j++)
			{
				array2[j].xae43282491351f1d(j);
				if (array2[j].Visible)
				{
					this.xb2cfa94692dcec88[num++] = array2[j];
				}
			}
			this.x6b5d35ac2bbc76ff = this.ToArray();
			this.xb6a159a84cb992d6.x3d8b152ea76101f6(this.DisplayColumns.Length);
			this.xb6a159a84cb992d6.MeasureNeeded();
		}

		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x060003C8 RID: 968 RVA: 0x0001633C File Offset: 0x0001533C
		public GridColumn[] DisplayColumns
		{
			get
			{
				return this.xb2cfa94692dcec88;
			}
		}

		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x060003C9 RID: 969 RVA: 0x00016344 File Offset: 0x00015344
		internal GridColumn[] xe8ecae63c9eb7749
		{
			get
			{
				return this.x6b5d35ac2bbc76ff;
			}
		}

		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x060003CA RID: 970 RVA: 0x0001634C File Offset: 0x0001534C
		internal bool x4cc5a926eb940d8c
		{
			get
			{
				return this.xba25a079bf34250f;
			}
		}

		// Token: 0x060003CB RID: 971 RVA: 0x00016354 File Offset: 0x00015354
		public void SetDisplayIndices(int[] indices)
		{
			if (indices == null)
			{
				throw new ArgumentNullException("indices");
			}
			if (indices.Length != base.Count)
			{
				throw new ArgumentException(xf1a67b6a145d2603.x538d63a1354c16f2("ExceptionArrayWrongLength"), "indices");
			}
			for (int i = 0; i < indices.Length; i++)
			{
				this[i].xae43282491351f1d(indices[i]);
			}
			this.xe3d225b642287874();
		}

		// Token: 0x060003CC RID: 972 RVA: 0x000163B4 File Offset: 0x000153B4
		public GridColumn[] ToArray()
		{
			GridColumn[] array = new GridColumn[base.Count];
			this.CopyTo(array, 0);
			return array;
		}

		// Token: 0x060003CD RID: 973 RVA: 0x000163D8 File Offset: 0x000153D8
		protected override void OnClear()
		{
			base.OnClear();
			if (this.xb6a159a84cb992d6.SandGrid != null && this.xb6a159a84cb992d6.SandGrid.Site != null && this.xb6a159a84cb992d6.SandGrid.Site.DesignMode)
			{
				this.xd1abaacea4790ca5 = this.xacc79ca10cb86c1f;
				this.xdf2c5abf9039fcca = this.xb6a159a84cb992d6.SortColumn;
				this.xd82c185cb3c76b00 = this.xb6a159a84cb992d6.GroupColumn;
			}
			foreach (object obj in this)
			{
				GridColumn gridColumn = (GridColumn)obj;
				gridColumn.xea1c0bc64ab77594(null);
				if (this.xb6a159a84cb992d6.GroupColumn == gridColumn)
				{
					this.xb6a159a84cb992d6.GroupColumn = null;
				}
				if (this.xb6a159a84cb992d6.SortColumn == gridColumn)
				{
					this.xb6a159a84cb992d6.SortColumn = null;
				}
			}
		}

		// Token: 0x060003CE RID: 974 RVA: 0x000164D8 File Offset: 0x000154D8
		protected override void OnClearComplete()
		{
			base.OnClearComplete();
			this.xacc79ca10cb86c1f = null;
			this.xe3d225b642287874();
		}

		// Token: 0x060003CF RID: 975 RVA: 0x000164F0 File Offset: 0x000154F0
		protected override void OnInsertComplete(int index, object value)
		{
			base.OnInsertComplete(index, value);
			GridColumn gridColumn = (GridColumn)value;
			gridColumn.xea1c0bc64ab77594(this.xb6a159a84cb992d6);
			gridColumn.x87c7306436764333(index);
			if (gridColumn.DisplayIndex == 0)
			{
				gridColumn.xae43282491351f1d(index);
			}
			if (this.xacc79ca10cb86c1f == null)
			{
				this.xacc79ca10cb86c1f = gridColumn;
			}
			if (this.xd1abaacea4790ca5 == gridColumn)
			{
				this.xacc79ca10cb86c1f = this.xd1abaacea4790ca5;
				this.xd1abaacea4790ca5 = null;
			}
			if (this.xdf2c5abf9039fcca == gridColumn)
			{
				this.xb6a159a84cb992d6.SortColumn = this.xdf2c5abf9039fcca;
				this.xdf2c5abf9039fcca = null;
			}
			if (this.xd82c185cb3c76b00 == gridColumn)
			{
				this.xb6a159a84cb992d6.GroupColumn = this.xd82c185cb3c76b00;
				this.xd82c185cb3c76b00 = null;
			}
			if (!this.x6278c23b2376c7c7)
			{
				this.xe3d225b642287874();
			}
		}

		// Token: 0x060003D0 RID: 976 RVA: 0x000165AC File Offset: 0x000155AC
		protected override void OnRemoveComplete(int index, object value)
		{
			base.OnRemoveComplete(index, value);
			GridColumn gridColumn = (GridColumn)value;
			gridColumn.xea1c0bc64ab77594(null);
			if (this.xacc79ca10cb86c1f == gridColumn)
			{
				this.xacc79ca10cb86c1f = ((base.Count != 0) ? this[0] : null);
			}
			if (this.xb6a159a84cb992d6.GroupColumn == gridColumn)
			{
				this.xb6a159a84cb992d6.GroupColumn = null;
			}
			if (this.xb6a159a84cb992d6.SortColumn == gridColumn)
			{
				this.xb6a159a84cb992d6.SortColumn = null;
			}
			this.xe3d225b642287874();
		}

		// Token: 0x060003D1 RID: 977 RVA: 0x0001662C File Offset: 0x0001562C
		public void AddRange(GridColumn[] columns)
		{
			if (columns == null)
			{
				throw new ArgumentNullException("columns");
			}
			this.x6278c23b2376c7c7 = true;
			try
			{
				foreach (GridColumn column in columns)
				{
					this.Add(column);
				}
			}
			finally
			{
				this.x6278c23b2376c7c7 = false;
			}
			this.xe3d225b642287874();
		}

		// Token: 0x060003D2 RID: 978 RVA: 0x00016698 File Offset: 0x00015698
		public int Add(GridColumn column)
		{
			int count = base.Count;
			this.Insert(count, column);
			return count;
		}

		// Token: 0x060003D3 RID: 979 RVA: 0x000166B8 File Offset: 0x000156B8
		public void Insert(int index, GridColumn column)
		{
			if (column == null)
			{
				throw new ArgumentNullException("column");
			}
			if (column.Grid != null)
			{
				column.Grid.Columns.Remove(column);
			}
			base.List.Insert(index, column);
		}

		// Token: 0x170000FA RID: 250
		public GridColumn this[int index]
		{
			get
			{
				return (GridColumn)base.List[index];
			}
		}

		// Token: 0x170000FB RID: 251
		public GridColumn this[string dataPropertyName]
		{
			get
			{
				foreach (object obj in this)
				{
					GridColumn gridColumn = (GridColumn)obj;
					if (gridColumn.DataPropertyName == dataPropertyName)
					{
						return gridColumn;
					}
				}
				return null;
			}
		}

		// Token: 0x060003D6 RID: 982 RVA: 0x00016774 File Offset: 0x00015774
		public void Remove(GridColumn column)
		{
			if (column == null)
			{
				throw new ArgumentNullException("column");
			}
			base.List.Remove(column);
		}

		// Token: 0x060003D7 RID: 983 RVA: 0x00016790 File Offset: 0x00015790
		public bool Contains(GridColumn column)
		{
			return base.List.Contains(column);
		}

		// Token: 0x060003D8 RID: 984 RVA: 0x000167A0 File Offset: 0x000157A0
		public int IndexOf(GridColumn column)
		{
			return base.List.IndexOf(column);
		}

		// Token: 0x060003D9 RID: 985 RVA: 0x000167B0 File Offset: 0x000157B0
		public void CopyTo(GridColumn[] array, int index)
		{
			base.List.CopyTo(array, index);
		}

		// Token: 0x170000FC RID: 252
		// (get) Token: 0x060003DA RID: 986 RVA: 0x000167C0 File Offset: 0x000157C0
		// (set) Token: 0x060003DB RID: 987 RVA: 0x000167C8 File Offset: 0x000157C8
		internal GridColumn xacc79ca10cb86c1f
		{
			get
			{
				return this.x6c1b8fc817915a15;
			}
			set
			{
				if (value != null && !this.Contains(value))
				{
					throw new ArgumentException(xf1a67b6a145d2603.x538d63a1354c16f2("ExceptionObjectNotInGrid"), "value");
				}
				if (value == null && base.Count != 0)
				{
					throw new ArgumentNullException("value");
				}
				if (value != this.x6c1b8fc817915a15)
				{
					if (this.x6c1b8fc817915a15 != null)
					{
						this.x6c1b8fc817915a15.x826c61806b563083(false);
					}
					this.x6c1b8fc817915a15 = value;
					if (this.x6c1b8fc817915a15 != null)
					{
						this.x6c1b8fc817915a15.x826c61806b563083(true);
					}
					this.xb6a159a84cb992d6.MeasureNeeded();
				}
			}
		}

		// Token: 0x0400011A RID: 282
		private InnerGrid xb6a159a84cb992d6;

		// Token: 0x0400011B RID: 283
		private bool x6278c23b2376c7c7;

		// Token: 0x0400011C RID: 284
		private GridColumn[] x6b5d35ac2bbc76ff = new GridColumn[0];

		// Token: 0x0400011D RID: 285
		private GridColumn[] xb2cfa94692dcec88 = new GridColumn[0];

		// Token: 0x0400011E RID: 286
		private GridColumn x6c1b8fc817915a15;

		// Token: 0x0400011F RID: 287
		private bool xba25a079bf34250f;

		// Token: 0x04000120 RID: 288
		private GridColumn xd1abaacea4790ca5;

		// Token: 0x04000121 RID: 289
		private GridColumn xdf2c5abf9039fcca;

		// Token: 0x04000122 RID: 290
		private GridColumn xd82c185cb3c76b00;
	}
}
