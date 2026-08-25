using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Divelements.SandGrid.Resources;

namespace Divelements.SandGrid
{
	// Token: 0x02000024 RID: 36
	public class GridRowCollection : CollectionBase, IComparer<GridRow>, IComparer
	{
		// Token: 0x060003E4 RID: 996 RVA: 0x000168A8 File Offset: 0x000158A8
		private GridRowCollection()
		{
			this.x47dc05f5ce8e6b37 = new Dictionary<int, GridRow>();
		}

		// Token: 0x060003E5 RID: 997 RVA: 0x000168BC File Offset: 0x000158BC
		internal GridRowCollection(InnerGrid parentHost) : this()
		{
			this.x7dcce66ec8470ecf = parentHost;
		}

		// Token: 0x060003E6 RID: 998 RVA: 0x000168CC File Offset: 0x000158CC
		internal GridRowCollection(GridRow parentRow) : this()
		{
			this.xfbf9d376a0c88d8d = parentRow;
		}

		// Token: 0x060003E7 RID: 999 RVA: 0x000168DC File Offset: 0x000158DC
		public bool IsValidIndex(int index)
		{
			if (this.x7755e9446fe86ee5)
			{
				return index >= 0 && index < this.x69488c3ffe7b8ad0;
			}
			return index >= 0 && index < this.Count;
		}

		// Token: 0x17000101 RID: 257
		// (get) Token: 0x060003E8 RID: 1000 RVA: 0x00016908 File Offset: 0x00015908
		internal bool x07f145bc17390dde
		{
			get
			{
				return this.x7dcce66ec8470ecf != null && this.x7dcce66ec8470ecf.GroupColumn != null;
			}
		}

		// Token: 0x17000102 RID: 258
		// (get) Token: 0x060003E9 RID: 1001 RVA: 0x00016928 File Offset: 0x00015928
		public bool IsSorted
		{
			get
			{
				return this.x94c6d9c743d62341 != null;
			}
		}

		// Token: 0x060003EA RID: 1002 RVA: 0x00016938 File Offset: 0x00015938
		public void SetSort(GridColumn[] columns, ListSortDirection[] directions)
		{
			if (columns != null && directions != null && columns.Length != directions.Length)
			{
				throw new ArgumentException("The specified arrays are of differing lengths.");
			}
			this.x94c6d9c743d62341 = columns;
			this.x30193a48d57c0a72 = directions;
			this.x392c4e6c2fa28c2b();
		}

		// Token: 0x060003EB RID: 1003 RVA: 0x00016968 File Offset: 0x00015968
		public void ClearSort()
		{
			this.x94c6d9c743d62341 = null;
			this.x30193a48d57c0a72 = null;
		}

		// Token: 0x060003EC RID: 1004 RVA: 0x00016978 File Offset: 0x00015978
		internal bool xa5dcc13c31b2d66e(GridColumn xe3e287548b3d01f5)
		{
			if (xe3e287548b3d01f5 == null)
			{
				throw new ArgumentNullException("column");
			}
			if (this.x94c6d9c743d62341 == null)
			{
				return false;
			}
			if (xe3e287548b3d01f5.IsDataBound)
			{
				return false;
			}
			foreach (GridColumn gridColumn in this.x94c6d9c743d62341)
			{
				if (gridColumn == xe3e287548b3d01f5)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060003ED RID: 1005 RVA: 0x000169CC File Offset: 0x000159CC
		public void GetSort(out GridColumn[] columns, out ListSortDirection[] directions)
		{
			int num = (this.x94c6d9c743d62341 == null) ? 0 : this.x94c6d9c743d62341.Length;
			columns = new GridColumn[num];
			directions = new ListSortDirection[num];
			if (num != 0)
			{
				Array.Copy(this.x94c6d9c743d62341, columns, num);
				Array.Copy(this.x30193a48d57c0a72, directions, num);
			}
		}

		// Token: 0x060003EE RID: 1006 RVA: 0x00016A1C File Offset: 0x00015A1C
		internal void x392c4e6c2fa28c2b()
		{
			if (this.IsSorted)
			{
				if (this.x584ba2e98f91dd4d)
				{
					throw new InvalidOperationException(xf1a67b6a145d2603.x538d63a1354c16f2("ExceptionVirtualMode"));
				}
				foreach (GridColumn gridColumn in this.x94c6d9c743d62341)
				{
					if (gridColumn.IsDataBound)
					{
						return;
					}
				}
				InnerGrid innerGrid = (this.x7dcce66ec8470ecf != null) ? this.x7dcce66ec8470ecf : this.xfbf9d376a0c88d8d.Grid;
				if (innerGrid != null)
				{
					base.InnerList.Sort(this);
					this.xfee8a4b19c67b865(0);
					this.x7f80f55d120d7028();
					this.x0a85a0778e92d09a();
				}
			}
		}

		// Token: 0x060003EF RID: 1007 RVA: 0x00016AB0 File Offset: 0x00015AB0
		internal void x7f80f55d120d7028()
		{
			foreach (object obj in this)
			{
				GridRow gridRow = (GridRow)obj;
				gridRow.x530a591976340ded();
				if (gridRow.HasRows)
				{
					gridRow.NestedRows.x7f80f55d120d7028();
				}
			}
		}

		// Token: 0x17000103 RID: 259
		// (get) Token: 0x060003F0 RID: 1008 RVA: 0x00016B24 File Offset: 0x00015B24
		private InnerGrid xf6f4ec6a12d754a2
		{
			get
			{
				if (this.x7dcce66ec8470ecf != null)
				{
					return this.x7dcce66ec8470ecf;
				}
				return this.xfbf9d376a0c88d8d.Grid;
			}
		}

		// Token: 0x060003F1 RID: 1009 RVA: 0x00016B40 File Offset: 0x00015B40
		protected override void OnClear()
		{
			base.OnClear();
			if (this.xf6f4ec6a12d754a2 != null)
			{
				this.xf6f4ec6a12d754a2.x614e783eda4ed71f();
			}
			for (int i = this.Count - 1; i >= 0; i--)
			{
				GridRow gridRow = this[i];
				gridRow.xea1c0bc64ab77594(null);
				gridRow.x973e390b09c57b95(null);
			}
		}

		// Token: 0x060003F2 RID: 1010 RVA: 0x00016B90 File Offset: 0x00015B90
		protected override void OnClearComplete()
		{
			base.OnClearComplete();
			this.xfee8a4b19c67b865(0);
			if (this.xf6f4ec6a12d754a2 != null)
			{
				this.xf6f4ec6a12d754a2.x06727b7d4fe7a302();
			}
			this.x874aae5aee2ba96c();
		}

		// Token: 0x060003F3 RID: 1011 RVA: 0x00016BB8 File Offset: 0x00015BB8
		protected override void OnInsert(int index, object value)
		{
			base.OnInsert(index, value);
			if (index == this.Count && this.Count != 0)
			{
				GridRow gridRow = this[this.Count - 1];
				if (gridRow.NestedRows.Count != 0)
				{
					int indentationLevel = gridRow.IndentationLevel;
					GridRow x9fcc739d9a = gridRow.x9fcc739d9a713387;
					while (x9fcc739d9a != null && x9fcc739d9a.IndentationLevel >= indentationLevel)
					{
						gridRow = x9fcc739d9a;
						x9fcc739d9a = x9fcc739d9a.x9fcc739d9a713387;
					}
					gridRow.x530a591976340ded();
					return;
				}
				this[this.Count - 1].x530a591976340ded();
				return;
			}
			else
			{
				if (index >= 0 && index < this.Count)
				{
					this[index].x530a591976340ded();
					return;
				}
				if (this.xfbf9d376a0c88d8d != null)
				{
					this.xfbf9d376a0c88d8d.x530a591976340ded();
				}
				return;
			}
		}

		// Token: 0x060003F4 RID: 1012 RVA: 0x00016C68 File Offset: 0x00015C68
		protected override void OnInsertComplete(int index, object value)
		{
			base.OnInsertComplete(index, value);
			GridRow gridRow = (GridRow)value;
			if (this.x7dcce66ec8470ecf != null)
			{
				gridRow.xea1c0bc64ab77594(this.x7dcce66ec8470ecf);
			}
			else
			{
				gridRow.x973e390b09c57b95(this.xfbf9d376a0c88d8d);
			}
			gridRow.x87c7306436764333(index);
			if (index < this.Count - 1)
			{
				this.xfee8a4b19c67b865(index + 1);
			}
			if (!this.x6278c23b2376c7c7)
			{
				this.x874aae5aee2ba96c();
			}
		}

		// Token: 0x060003F5 RID: 1013 RVA: 0x00016CD0 File Offset: 0x00015CD0
		private void xfee8a4b19c67b865(int x10aaa7cdfa38f254)
		{
			for (int i = x10aaa7cdfa38f254; i < this.Count; i++)
			{
				this[i].x87c7306436764333(i);
			}
		}

		// Token: 0x060003F6 RID: 1014 RVA: 0x00016CFC File Offset: 0x00015CFC
		private void x874aae5aee2ba96c()
		{
			if (this.x7dcce66ec8470ecf != null)
			{
				this.x7dcce66ec8470ecf.x12d82f2321e4235a(this.Count);
			}
			this.x0a85a0778e92d09a();
		}

		// Token: 0x060003F7 RID: 1015 RVA: 0x00016D20 File Offset: 0x00015D20
		private void x0a85a0778e92d09a()
		{
			if (this.x7dcce66ec8470ecf != null)
			{
				this.x7dcce66ec8470ecf.MeasureNeeded();
				return;
			}
			this.xfbf9d376a0c88d8d.MeasureNeeded();
		}

		// Token: 0x060003F8 RID: 1016 RVA: 0x00016D44 File Offset: 0x00015D44
		protected override void OnRemoveComplete(int index, object value)
		{
			base.OnRemoveComplete(index, value);
			GridRow gridRow = (GridRow)value;
			gridRow.xea1c0bc64ab77594(null);
			gridRow.x973e390b09c57b95(null);
			this.xfee8a4b19c67b865(index);
			this.x874aae5aee2ba96c();
		}

		// Token: 0x060003F9 RID: 1017 RVA: 0x00016D7C File Offset: 0x00015D7C
		protected override void OnRemove(int index, object value)
		{
			base.OnRemove(index, value);
			GridRow gridRow = (GridRow)value;
			if (gridRow.IsExpansionVisible())
			{
				GridRow nextVisibleRow = gridRow.NextVisibleRow;
				GridRow previousVisibleRow = gridRow.PreviousVisibleRow;
			}
		}

		// Token: 0x060003FA RID: 1018 RVA: 0x00016DB0 File Offset: 0x00015DB0
		public void AddRange(GridRow[] rows)
		{
			if (this.xc22134cf4aa6ad3d)
			{
				throw new InvalidOperationException(xf1a67b6a145d2603.x538d63a1354c16f2("ExceptionDataBound"));
			}
			this.xc1bf1c083077a548(rows);
		}

		// Token: 0x060003FB RID: 1019 RVA: 0x00016DD4 File Offset: 0x00015DD4
		internal void xc1bf1c083077a548(GridRow[] x2eb5785cf1641b8b)
		{
			if (x2eb5785cf1641b8b == null)
			{
				throw new ArgumentNullException("rows");
			}
			this.x6278c23b2376c7c7 = true;
			try
			{
				foreach (GridRow xa806b754814b9ae in x2eb5785cf1641b8b)
				{
					this.x2252c77099794fa9(xa806b754814b9ae);
				}
			}
			finally
			{
				this.x6278c23b2376c7c7 = false;
				this.x392c4e6c2fa28c2b();
			}
			this.x874aae5aee2ba96c();
		}

		// Token: 0x060003FC RID: 1020 RVA: 0x00016E44 File Offset: 0x00015E44
		public int Add(GridRow row)
		{
			if (this.xc22134cf4aa6ad3d)
			{
				throw new InvalidOperationException(xf1a67b6a145d2603.x538d63a1354c16f2("ExceptionDataBound"));
			}
			return this.x2252c77099794fa9(row);
		}

		// Token: 0x060003FD RID: 1021 RVA: 0x00016E68 File Offset: 0x00015E68
		internal int x2252c77099794fa9(GridRow xa806b754814b9ae0)
		{
			int num;
			if (!this.x6278c23b2376c7c7 && this.IsSorted)
			{
				InnerGrid innerGrid = (this.x7dcce66ec8470ecf != null) ? this.x7dcce66ec8470ecf : this.xfbf9d376a0c88d8d.Grid;
				if (innerGrid != null)
				{
					xa806b754814b9ae0.xea1c0bc64ab77594(innerGrid);
					num = base.InnerList.BinarySearch(xa806b754814b9ae0, this);
					xa806b754814b9ae0.xea1c0bc64ab77594(null);
					if (num < 0)
					{
						num = ~num;
					}
				}
				else
				{
					num = this.Count;
				}
			}
			else
			{
				num = this.Count;
			}
			this.xb062e1da35ea3cf6(num, xa806b754814b9ae0);
			return num;
		}

		// Token: 0x060003FE RID: 1022 RVA: 0x00016EE4 File Offset: 0x00015EE4
		internal void x2df8a9784bb2fcd6(GridRow xa806b754814b9ae0, int x873721d4383ca28a)
		{
			if (xa806b754814b9ae0 == null)
			{
				throw new ArgumentNullException("row");
			}
			if (!this.Contains(xa806b754814b9ae0))
			{
				throw new IndexOutOfRangeException("row");
			}
			if (this.x584ba2e98f91dd4d)
			{
				throw new InvalidOperationException(xf1a67b6a145d2603.x538d63a1354c16f2("ExceptionVirtualMode"));
			}
			int x10aaa7cdfa38f = Math.Min(x873721d4383ca28a, this.IndexOf(xa806b754814b9ae0));
			xa806b754814b9ae0.x530a591976340ded();
			base.InnerList.Remove(xa806b754814b9ae0);
			if (x873721d4383ca28a >= 0 && x873721d4383ca28a < this.Count)
			{
				this[x873721d4383ca28a].x530a591976340ded();
			}
			base.InnerList.Insert(x873721d4383ca28a, xa806b754814b9ae0);
			this.xfee8a4b19c67b865(x10aaa7cdfa38f);
			this.x874aae5aee2ba96c();
		}

		// Token: 0x060003FF RID: 1023 RVA: 0x00016F80 File Offset: 0x00015F80
		public void Insert(int index, GridRow row)
		{
			if (this.xc22134cf4aa6ad3d)
			{
				throw new InvalidOperationException(xf1a67b6a145d2603.x538d63a1354c16f2("ExceptionDataBound"));
			}
			if (this.IsSorted)
			{
				throw new InvalidOperationException(xf1a67b6a145d2603.x538d63a1354c16f2("ExceptionInsertOnSort"));
			}
			this.xb062e1da35ea3cf6(index, row);
		}

		// Token: 0x06000400 RID: 1024 RVA: 0x00016FBC File Offset: 0x00015FBC
		internal void xb062e1da35ea3cf6(int xc0c4c459c6ccbd00, GridRow xa806b754814b9ae0)
		{
			if (xa806b754814b9ae0 == null)
			{
				throw new ArgumentNullException("row");
			}
			if (this.x584ba2e98f91dd4d)
			{
				throw new InvalidOperationException(xf1a67b6a145d2603.x538d63a1354c16f2("ExceptionVirtualMode"));
			}
			if (xa806b754814b9ae0.Grid != null)
			{
				xa806b754814b9ae0.Grid.Rows.Remove(xa806b754814b9ae0);
			}
			if (xa806b754814b9ae0.ParentRow != null)
			{
				xa806b754814b9ae0.ParentRow.NestedRows.Remove(xa806b754814b9ae0);
			}
			base.List.Insert(xc0c4c459c6ccbd00, xa806b754814b9ae0);
		}

		// Token: 0x17000104 RID: 260
		public GridRow this[int index]
		{
			get
			{
				if (!this.x7755e9446fe86ee5)
				{
					return (GridRow)base.List[index];
				}
				if (index < 0 || index >= this.x69488c3ffe7b8ad0)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				this.xce4ff9761213a6cb++;
				if (this.xce4ff9761213a6cb > 10000)
				{
					if (!this.xce9d3f710eabccac && this.xf6f4ec6a12d754a2 != null && this.xf6f4ec6a12d754a2.SandGrid != null)
					{
						this.xce9d3f710eabccac = true;
						Control sandGrid = this.xf6f4ec6a12d754a2.SandGrid;
						Delegate method = new EventHandler(this.x6fabd5b3b6ffb380);
						object[] args = new object[2];
						sandGrid.BeginInvoke(method, args);
					}
					this.xce4ff9761213a6cb = 0;
				}
				GridRow gridRow;
				if (this.x47dc05f5ce8e6b37.TryGetValue(index, out gridRow))
				{
					return gridRow;
				}
				gridRow = this.x7dcce66ec8470ecf.NewRow();
				gridRow.xea1c0bc64ab77594(this.x7dcce66ec8470ecf);
				gridRow.x87c7306436764333(index);
				gridRow.xbd2f66a95763069d(index);
				this.x7dcce66ec8470ecf.xe6725d062dfbcd2c(new GridRowEventArgs(gridRow));
				this.x7dcce66ec8470ecf.xc78f81acf21786e9(gridRow);
				this.x47dc05f5ce8e6b37[index] = gridRow;
				return gridRow;
			}
		}

		// Token: 0x06000402 RID: 1026 RVA: 0x00017140 File Offset: 0x00016140
		public void Remove(GridRow row)
		{
			if (row == null)
			{
				throw new ArgumentNullException("row");
			}
			if (this.xc22134cf4aa6ad3d)
			{
				throw new InvalidOperationException(xf1a67b6a145d2603.x538d63a1354c16f2("ExceptionDataBound"));
			}
			if (this.x584ba2e98f91dd4d)
			{
				throw new InvalidOperationException(xf1a67b6a145d2603.x538d63a1354c16f2("ExceptionVirtualMode"));
			}
			base.List.Remove(row);
		}

		// Token: 0x17000105 RID: 261
		// (get) Token: 0x06000403 RID: 1027 RVA: 0x00017198 File Offset: 0x00016198
		private bool xc22134cf4aa6ad3d
		{
			get
			{
				if (this.xfbf9d376a0c88d8d != null)
				{
					return this.xfbf9d376a0c88d8d.Grid != null && this.xfbf9d376a0c88d8d.Grid.xc22134cf4aa6ad3d;
				}
				return this.x7dcce66ec8470ecf.xc22134cf4aa6ad3d;
			}
		}

		// Token: 0x06000404 RID: 1028 RVA: 0x000171D0 File Offset: 0x000161D0
		public bool Contains(GridRow row)
		{
			if (this.x584ba2e98f91dd4d)
			{
				throw new InvalidOperationException(xf1a67b6a145d2603.x538d63a1354c16f2("ExceptionVirtualMode"));
			}
			return base.List.Contains(row);
		}

		// Token: 0x06000405 RID: 1029 RVA: 0x000171F8 File Offset: 0x000161F8
		public int IndexOf(GridRow row)
		{
			if (this.x584ba2e98f91dd4d)
			{
				throw new InvalidOperationException(xf1a67b6a145d2603.x538d63a1354c16f2("ExceptionVirtualMode"));
			}
			return base.List.IndexOf(row);
		}

		// Token: 0x06000406 RID: 1030 RVA: 0x00017220 File Offset: 0x00016220
		public void CopyTo(GridRow[] array, int index)
		{
			if (this.x584ba2e98f91dd4d)
			{
				throw new InvalidOperationException(xf1a67b6a145d2603.x538d63a1354c16f2("ExceptionVirtualMode"));
			}
			base.List.CopyTo(array, index);
		}

		// Token: 0x06000407 RID: 1031 RVA: 0x00017248 File Offset: 0x00016248
		int IComparer.x91c86e0de828cc9f(object x08db3aeabb253cb1, object x1e218ceaee1bb583)
		{
			return this.Compare(x08db3aeabb253cb1 as GridRow, x1e218ceaee1bb583 as GridRow);
		}

		// Token: 0x06000408 RID: 1032 RVA: 0x0001725C File Offset: 0x0001625C
		int IComparer<GridRow>.xc59ec8ff36d273a1(GridRow x08db3aeabb253cb1, GridRow x1e218ceaee1bb583)
		{
			return this.Compare(x08db3aeabb253cb1, x1e218ceaee1bb583);
		}

		// Token: 0x06000409 RID: 1033 RVA: 0x00017268 File Offset: 0x00016268
		private int Compare(GridRow xRow, GridRow yRow)
		{
			if (xRow == null)
			{
				throw new ArgumentNullException("xRow");
			}
			if (yRow == null)
			{
				throw new ArgumentNullException("yRow");
			}
			int i = 0;
			while (i < this.x94c6d9c743d62341.Length)
			{
				IComparable comparable = xRow.GetCellValue(this.x94c6d9c743d62341[i]) as IComparable;
				IComparable comparable2 = yRow.GetCellValue(this.x94c6d9c743d62341[i]) as IComparable;
				int num;
				if (comparable == null && comparable2 == null)
				{
					num = 0;
				}
				else if (comparable == null)
				{
					num = -1;
				}
				else
				{
					if (comparable2 != null)
					{
						goto IL_14;
					}
					num = 1;
				}
				IL_5A:
				if (num == 0)
				{
					i++;
					continue;
				}
				if (this.x30193a48d57c0a72[i] == ListSortDirection.Ascending)
				{
					return num;
				}
				if ((uint)num - (uint)i >= 0U)
				{
					return -num;
				}
				IL_14:
				if (i == 0 && this.x7dcce66ec8470ecf != null && this.x7dcce66ec8470ecf.GroupColumn == this.x94c6d9c743d62341[i])
				{
					comparable = this.x94c6d9c743d62341[i].GetGroupedValueForSorting(comparable);
					comparable2 = this.x94c6d9c743d62341[i].GetGroupedValueForSorting(comparable2);
				}
				num = comparable.CompareTo(comparable2);
				goto IL_5A;
			}
			return 0;
		}

		// Token: 0x17000106 RID: 262
		// (get) Token: 0x0600040A RID: 1034 RVA: 0x00017374 File Offset: 0x00016374
		public new int Count
		{
			get
			{
				if (this.x7755e9446fe86ee5)
				{
					return this.x0d3ed93b62f2f248;
				}
				return base.Count;
			}
		}

		// Token: 0x17000107 RID: 263
		// (get) Token: 0x0600040B RID: 1035 RVA: 0x0001738C File Offset: 0x0001638C
		// (set) Token: 0x0600040C RID: 1036 RVA: 0x00017394 File Offset: 0x00016394
		internal bool x584ba2e98f91dd4d
		{
			get
			{
				return this.x7755e9446fe86ee5;
			}
			set
			{
				if (value != this.x7755e9446fe86ee5)
				{
					if (!this.x584ba2e98f91dd4d && base.List.Count != 0)
					{
						throw new InvalidOperationException(xf1a67b6a145d2603.x538d63a1354c16f2("ExceptionSwitchingVirtualMode"));
					}
					if (this.IsSorted)
					{
						throw new InvalidOperationException(xf1a67b6a145d2603.x538d63a1354c16f2("ExceptionSwitchingVirtualMode"));
					}
					this.x7755e9446fe86ee5 = value;
					this.x3c47abb3897d6b34();
					this.x0a85a0778e92d09a();
				}
			}
		}

		// Token: 0x17000108 RID: 264
		// (get) Token: 0x0600040D RID: 1037 RVA: 0x000173FC File Offset: 0x000163FC
		// (set) Token: 0x0600040E RID: 1038 RVA: 0x00017404 File Offset: 0x00016404
		internal int x0d3ed93b62f2f248
		{
			get
			{
				return this.x69488c3ffe7b8ad0;
			}
			set
			{
				if (value < 0)
				{
					throw new ArgumentException(xf1a67b6a145d2603.x538d63a1354c16f2("ExceptionNegative"), "value");
				}
				if (value > 1000000)
				{
					throw new ArgumentException(xf1a67b6a145d2603.x538d63a1354c16f2("ExceptionVirtualRowCap"), "value");
				}
				this.x69488c3ffe7b8ad0 = value;
				this.x0a85a0778e92d09a();
			}
		}

		// Token: 0x0600040F RID: 1039 RVA: 0x00017454 File Offset: 0x00016454
		public new void Clear()
		{
			if (this.x584ba2e98f91dd4d)
			{
				this.x3c47abb3897d6b34();
				this.x0a85a0778e92d09a();
				return;
			}
			base.Clear();
		}

		// Token: 0x06000410 RID: 1040 RVA: 0x00017474 File Offset: 0x00016474
		private void x3c47abb3897d6b34()
		{
			foreach (object obj in this.x4a7996023abdc9e3)
			{
				GridRow gridRow = (GridRow)obj;
				gridRow.xea1c0bc64ab77594(null);
			}
			this.x47dc05f5ce8e6b37.Clear();
		}

		// Token: 0x17000109 RID: 265
		// (get) Token: 0x06000411 RID: 1041 RVA: 0x000174E4 File Offset: 0x000164E4
		internal IEnumerable x4a7996023abdc9e3
		{
			get
			{
				return this.x47dc05f5ce8e6b37.Values;
			}
		}

		// Token: 0x06000412 RID: 1042 RVA: 0x000174F4 File Offset: 0x000164F4
		private void x6fabd5b3b6ffb380(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			if (this.xce9d3f710eabccac)
			{
				this.xe508a828c56d322e();
			}
			this.xce9d3f710eabccac = false;
		}

		// Token: 0x06000413 RID: 1043 RVA: 0x0001750C File Offset: 0x0001650C
		internal void xe508a828c56d322e()
		{
			if (this.x47dc05f5ce8e6b37.Count > 500)
			{
				int num = 0;
				int[] array = new int[this.x47dc05f5ce8e6b37.Count];
				this.x47dc05f5ce8e6b37.Keys.CopyTo(array, 0);
				foreach (int key in array)
				{
					GridRow gridRow = this.x47dc05f5ce8e6b37[key];
					if (this.x8646ce89393d15a5(gridRow))
					{
						gridRow.xea1c0bc64ab77594(null);
						this.x47dc05f5ce8e6b37.Remove(key);
						num++;
					}
				}
			}
			this.xce4ff9761213a6cb = 0;
		}

		// Token: 0x06000414 RID: 1044 RVA: 0x000175A4 File Offset: 0x000165A4
		private bool x8646ce89393d15a5(GridRow xa806b754814b9ae0)
		{
			if (xa806b754814b9ae0.Selected || this.xf6f4ec6a12d754a2.SandGrid.FocusedElement == xa806b754814b9ae0 || this.xf6f4ec6a12d754a2.x699c923a60e155ff == xa806b754814b9ae0 || this.xf6f4ec6a12d754a2.SandGrid.xf023f44afe4ba919 == xa806b754814b9ae0)
			{
				return false;
			}
			if (xa806b754814b9ae0.HasCells)
			{
				foreach (object obj in xa806b754814b9ae0.Cells)
				{
					GridCell gridCell = (GridCell)obj;
					if (gridCell.Selected || this.xf6f4ec6a12d754a2.SandGrid.FocusedElement == gridCell || this.xf6f4ec6a12d754a2.SandGrid.xf023f44afe4ba919 == gridCell)
					{
						return false;
					}
				}
				return true;
			}
			return true;
		}

		// Token: 0x04000126 RID: 294
		private InnerGrid x7dcce66ec8470ecf;

		// Token: 0x04000127 RID: 295
		private GridRow xfbf9d376a0c88d8d;

		// Token: 0x04000128 RID: 296
		private bool x6278c23b2376c7c7;

		// Token: 0x04000129 RID: 297
		private bool x7755e9446fe86ee5;

		// Token: 0x0400012A RID: 298
		private bool xce9d3f710eabccac;

		// Token: 0x0400012B RID: 299
		private int x69488c3ffe7b8ad0;

		// Token: 0x0400012C RID: 300
		private int xce4ff9761213a6cb;

		// Token: 0x0400012D RID: 301
		private Dictionary<int, GridRow> x47dc05f5ce8e6b37;

		// Token: 0x0400012E RID: 302
		private GridColumn[] x94c6d9c743d62341;

		// Token: 0x0400012F RID: 303
		private ListSortDirection[] x30193a48d57c0a72;
	}
}
