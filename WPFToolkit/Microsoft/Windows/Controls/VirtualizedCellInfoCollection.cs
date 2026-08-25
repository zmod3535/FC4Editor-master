using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Windows.Controls;

namespace Microsoft.Windows.Controls
{
	// Token: 0x02000015 RID: 21
	internal class VirtualizedCellInfoCollection : IList<DataGridCellInfo>, ICollection<DataGridCellInfo>, IEnumerable<DataGridCellInfo>, IEnumerable
	{
		// Token: 0x06000147 RID: 327 RVA: 0x000056E0 File Offset: 0x000038E0
		internal VirtualizedCellInfoCollection(DataGrid owner)
		{
			this._owner = owner;
			this._regions = new List<VirtualizedCellInfoCollection.CellRegion>();
		}

		// Token: 0x06000148 RID: 328 RVA: 0x000056FA File Offset: 0x000038FA
		private VirtualizedCellInfoCollection(DataGrid owner, List<VirtualizedCellInfoCollection.CellRegion> regions)
		{
			this._owner = owner;
			this._regions = ((regions != null) ? new List<VirtualizedCellInfoCollection.CellRegion>(regions) : new List<VirtualizedCellInfoCollection.CellRegion>());
			this.IsReadOnly = true;
		}

		// Token: 0x06000149 RID: 329 RVA: 0x00005726 File Offset: 0x00003926
		internal static VirtualizedCellInfoCollection MakeEmptyCollection(DataGrid owner)
		{
			return new VirtualizedCellInfoCollection(owner, null);
		}

		// Token: 0x0600014A RID: 330 RVA: 0x00005730 File Offset: 0x00003930
		public void Add(DataGridCellInfo cell)
		{
			this._owner.Dispatcher.VerifyAccess();
			this.ValidateIsReadOnly();
			if (!this.IsValidPublicCell(cell))
			{
				throw new ArgumentException(SR.Get(SRID.SelectedCellsCollection_InvalidItem), "cell");
			}
			if (this.Contains(cell))
			{
				throw new ArgumentException(SR.Get(SRID.SelectedCellsCollection_DuplicateItem), "cell");
			}
			this.AddValidatedCell(cell);
		}

		// Token: 0x0600014B RID: 331 RVA: 0x00005798 File Offset: 0x00003998
		internal void AddValidatedCell(DataGridCellInfo cell)
		{
			int rowIndex;
			int columnIndex;
			this.ConvertCellInfoToIndexes(cell, out rowIndex, out columnIndex);
			this.AddRegion(rowIndex, columnIndex, 1, 1);
		}

		// Token: 0x0600014C RID: 332 RVA: 0x000057BC File Offset: 0x000039BC
		public void Clear()
		{
			this._owner.Dispatcher.VerifyAccess();
			this.ValidateIsReadOnly();
			if (!this.IsEmpty)
			{
				VirtualizedCellInfoCollection oldItems = new VirtualizedCellInfoCollection(this._owner, this._regions);
				this._regions.Clear();
				this.OnRemove(oldItems);
			}
		}

		// Token: 0x0600014D RID: 333 RVA: 0x0000580C File Offset: 0x00003A0C
		public bool Contains(DataGridCellInfo cell)
		{
			if (!this.IsValidPublicCell(cell))
			{
				throw new ArgumentException(SR.Get(SRID.SelectedCellsCollection_InvalidItem), "cell");
			}
			if (this.IsEmpty)
			{
				return false;
			}
			int rowIndex;
			int columnIndex;
			this.ConvertCellInfoToIndexes(cell, out rowIndex, out columnIndex);
			return this.Contains(rowIndex, columnIndex);
		}

		// Token: 0x0600014E RID: 334 RVA: 0x00005854 File Offset: 0x00003A54
		internal bool Contains(DataGridCell cell)
		{
			if (!this.IsEmpty)
			{
				object rowDataItem = cell.RowDataItem;
				int displayIndex = cell.Column.DisplayIndex;
				ItemCollection items = this._owner.Items;
				int count = items.Count;
				int count2 = this._regions.Count;
				for (int i = 0; i < count2; i++)
				{
					VirtualizedCellInfoCollection.CellRegion cellRegion = this._regions[i];
					if (cellRegion.Left <= displayIndex && displayIndex <= cellRegion.Right)
					{
						int bottom = cellRegion.Bottom;
						for (int j = cellRegion.Top; j <= bottom; j++)
						{
							if (j < count && items[j] == rowDataItem)
							{
								return true;
							}
						}
					}
				}
			}
			return false;
		}

		// Token: 0x0600014F RID: 335 RVA: 0x00005908 File Offset: 0x00003B08
		internal bool Contains(int rowIndex, int columnIndex)
		{
			int count = this._regions.Count;
			for (int i = 0; i < count; i++)
			{
				if (this._regions[i].Contains(columnIndex, rowIndex))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000150 RID: 336 RVA: 0x00005948 File Offset: 0x00003B48
		public void CopyTo(DataGridCellInfo[] array, int arrayIndex)
		{
			List<DataGridCellInfo> list = new List<DataGridCellInfo>();
			int count = this._regions.Count;
			for (int i = 0; i < count; i++)
			{
				this.AddRegionToList(this._regions[i], list);
			}
			list.CopyTo(array, arrayIndex);
		}

		// Token: 0x06000151 RID: 337 RVA: 0x0000598E File Offset: 0x00003B8E
		IEnumerator IEnumerable.GetEnumerator()
		{
			return new VirtualizedCellInfoCollection.VirtualizedCellInfoCollectionEnumerator(this._owner, this._regions, this);
		}

		// Token: 0x06000152 RID: 338 RVA: 0x000059A2 File Offset: 0x00003BA2
		public IEnumerator<DataGridCellInfo> GetEnumerator()
		{
			return new VirtualizedCellInfoCollection.VirtualizedCellInfoCollectionEnumerator(this._owner, this._regions, this);
		}

		// Token: 0x06000153 RID: 339 RVA: 0x000059B8 File Offset: 0x00003BB8
		public int IndexOf(DataGridCellInfo cell)
		{
			int num;
			int num2;
			this.ConvertCellInfoToIndexes(cell, out num, out num2);
			int count = this._regions.Count;
			int num3 = 0;
			for (int i = 0; i < count; i++)
			{
				VirtualizedCellInfoCollection.CellRegion cellRegion = this._regions[i];
				if (cellRegion.Contains(num2, num))
				{
					return num3 + ((num - cellRegion.Top) * cellRegion.Width + num2 - cellRegion.Left);
				}
				num3 += cellRegion.Size;
			}
			return -1;
		}

		// Token: 0x06000154 RID: 340 RVA: 0x00005A31 File Offset: 0x00003C31
		public void Insert(int index, DataGridCellInfo cell)
		{
			throw new NotSupportedException(SR.Get(SRID.VirtualizedCellInfoCollection_DoesNotSupportIndexChanges));
		}

		// Token: 0x06000155 RID: 341 RVA: 0x00005A44 File Offset: 0x00003C44
		public bool Remove(DataGridCellInfo cell)
		{
			this._owner.Dispatcher.VerifyAccess();
			this.ValidateIsReadOnly();
			if (!this.IsEmpty)
			{
				int rowIndex;
				int columnIndex;
				this.ConvertCellInfoToIndexes(cell, out rowIndex, out columnIndex);
				if (this.Contains(rowIndex, columnIndex))
				{
					this.RemoveRegion(rowIndex, columnIndex, 1, 1);
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000156 RID: 342 RVA: 0x00005A91 File Offset: 0x00003C91
		public void RemoveAt(int index)
		{
			throw new NotSupportedException(SR.Get(SRID.VirtualizedCellInfoCollection_DoesNotSupportIndexChanges));
		}

		// Token: 0x17000077 RID: 119
		public DataGridCellInfo this[int index]
		{
			get
			{
				if (index >= 0 && index < this.Count)
				{
					return this.GetCellInfoFromIndex(this._owner, this._regions, index);
				}
				throw new ArgumentOutOfRangeException("index");
			}
			set
			{
				throw new NotSupportedException(SR.Get(SRID.VirtualizedCellInfoCollection_DoesNotSupportIndexChanges));
			}
		}

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x06000159 RID: 345 RVA: 0x00005AE0 File Offset: 0x00003CE0
		public int Count
		{
			get
			{
				int num = 0;
				int count = this._regions.Count;
				for (int i = 0; i < count; i++)
				{
					num += this._regions[i].Size;
				}
				return num;
			}
		}

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x0600015A RID: 346 RVA: 0x00005B1F File Offset: 0x00003D1F
		// (set) Token: 0x0600015B RID: 347 RVA: 0x00005B27 File Offset: 0x00003D27
		public bool IsReadOnly
		{
			get
			{
				return this._isReadOnly;
			}
			private set
			{
				this._isReadOnly = value;
			}
		}

		// Token: 0x0600015C RID: 348 RVA: 0x00005B30 File Offset: 0x00003D30
		private void OnAdd(VirtualizedCellInfoCollection newItems)
		{
			this.OnCollectionChanged(NotifyCollectionChangedAction.Add, null, newItems);
		}

		// Token: 0x0600015D RID: 349 RVA: 0x00005B3B File Offset: 0x00003D3B
		private void OnRemove(VirtualizedCellInfoCollection oldItems)
		{
			this.OnCollectionChanged(NotifyCollectionChangedAction.Remove, oldItems, null);
		}

		// Token: 0x0600015E RID: 350 RVA: 0x00005B46 File Offset: 0x00003D46
		protected virtual void OnCollectionChanged(NotifyCollectionChangedAction action, VirtualizedCellInfoCollection oldItems, VirtualizedCellInfoCollection newItems)
		{
		}

		// Token: 0x0600015F RID: 351 RVA: 0x00005B48 File Offset: 0x00003D48
		private bool IsValidCell(DataGridCellInfo cell)
		{
			return cell.IsValidForDataGrid(this._owner);
		}

		// Token: 0x06000160 RID: 352 RVA: 0x00005B57 File Offset: 0x00003D57
		private bool IsValidPublicCell(DataGridCellInfo cell)
		{
			return cell.IsValidForDataGrid(this._owner) && cell.IsValid;
		}

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x06000161 RID: 353 RVA: 0x00005B74 File Offset: 0x00003D74
		protected bool IsEmpty
		{
			get
			{
				int count = this._regions.Count;
				for (int i = 0; i < count; i++)
				{
					if (!this._regions[i].IsEmpty)
					{
						return false;
					}
				}
				return true;
			}
		}

		// Token: 0x06000162 RID: 354 RVA: 0x00005BB4 File Offset: 0x00003DB4
		protected void GetBoundingRegion(out int left, out int top, out int right, out int bottom)
		{
			left = int.MaxValue;
			top = int.MaxValue;
			right = 0;
			bottom = 0;
			int count = this._regions.Count;
			for (int i = 0; i < count; i++)
			{
				VirtualizedCellInfoCollection.CellRegion cellRegion = this._regions[i];
				if (cellRegion.Left < left)
				{
					left = cellRegion.Left;
				}
				if (cellRegion.Top < top)
				{
					top = cellRegion.Top;
				}
				if (cellRegion.Right > right)
				{
					right = cellRegion.Right;
				}
				if (cellRegion.Bottom > bottom)
				{
					bottom = cellRegion.Bottom;
				}
			}
		}

		// Token: 0x06000163 RID: 355 RVA: 0x00005C4D File Offset: 0x00003E4D
		internal void AddRegion(int rowIndex, int columnIndex, int rowCount, int columnCount)
		{
			this.AddRegion(rowIndex, columnIndex, rowCount, columnCount, true);
		}

		// Token: 0x06000164 RID: 356 RVA: 0x00005C5C File Offset: 0x00003E5C
		private void AddRegion(int rowIndex, int columnIndex, int rowCount, int columnCount, bool notify)
		{
			List<VirtualizedCellInfoCollection.CellRegion> list = new List<VirtualizedCellInfoCollection.CellRegion>();
			list.Add(new VirtualizedCellInfoCollection.CellRegion(columnIndex, rowIndex, columnCount, rowCount));
			int count = this._regions.Count;
			for (int i = 0; i < count; i++)
			{
				VirtualizedCellInfoCollection.CellRegion region = this._regions[i];
				for (int j = 0; j < list.Count; j++)
				{
					List<VirtualizedCellInfoCollection.CellRegion> list2;
					if (list[j].Remainder(region, out list2))
					{
						list.RemoveAt(j);
						j--;
						if (list2 != null)
						{
							list.AddRange(list2);
						}
					}
				}
			}
			if (list.Count > 0)
			{
				VirtualizedCellInfoCollection newItems = new VirtualizedCellInfoCollection(this._owner, list);
				for (int k = 0; k < count; k++)
				{
					for (int l = 0; l < list.Count; l++)
					{
						VirtualizedCellInfoCollection.CellRegion value = this._regions[k];
						if (value.Union(list[l]))
						{
							this._regions[k] = value;
							list.RemoveAt(l);
							l--;
						}
					}
				}
				int count2 = list.Count;
				for (int m = 0; m < count2; m++)
				{
					this._regions.Add(list[m]);
				}
				if (notify)
				{
					this.OnAdd(newItems);
				}
			}
		}

		// Token: 0x06000165 RID: 357 RVA: 0x00005DA0 File Offset: 0x00003FA0
		internal void RemoveRegion(int rowIndex, int columnIndex, int rowCount, int columnCount)
		{
			List<VirtualizedCellInfoCollection.CellRegion> list = null;
			this.RemoveRegion(rowIndex, columnIndex, rowCount, columnCount, ref list);
			if (list != null && list.Count > 0)
			{
				this.OnRemove(new VirtualizedCellInfoCollection(this._owner, list));
			}
		}

		// Token: 0x06000166 RID: 358 RVA: 0x00005DDC File Offset: 0x00003FDC
		private void RemoveRegion(int rowIndex, int columnIndex, int rowCount, int columnCount, ref List<VirtualizedCellInfoCollection.CellRegion> removeList)
		{
			if (!this.IsEmpty)
			{
				VirtualizedCellInfoCollection.CellRegion region = new VirtualizedCellInfoCollection.CellRegion(columnIndex, rowIndex, columnCount, rowCount);
				for (int i = 0; i < this._regions.Count; i++)
				{
					VirtualizedCellInfoCollection.CellRegion cellRegion = this._regions[i];
					VirtualizedCellInfoCollection.CellRegion cellRegion2 = cellRegion.Intersection(region);
					if (!cellRegion2.IsEmpty)
					{
						if (removeList == null)
						{
							removeList = new List<VirtualizedCellInfoCollection.CellRegion>();
						}
						removeList.Add(cellRegion2);
						this._regions.RemoveAt(i);
						List<VirtualizedCellInfoCollection.CellRegion> list;
						cellRegion.Remainder(cellRegion2, out list);
						if (list != null)
						{
							this._regions.InsertRange(i, list);
							i += list.Count;
						}
						i--;
					}
				}
			}
		}

		// Token: 0x06000167 RID: 359 RVA: 0x00005E84 File Offset: 0x00004084
		internal void OnItemsCollectionChanged(NotifyCollectionChangedEventArgs e, IList selectedRows)
		{
			if (!this.IsEmpty)
			{
				switch (e.Action)
				{
				case NotifyCollectionChangedAction.Add:
					this.OnAddRow(e.NewStartingIndex);
					return;
				case NotifyCollectionChangedAction.Remove:
					this.OnRemoveRow(e.OldStartingIndex, e.OldItems[0]);
					return;
				case NotifyCollectionChangedAction.Replace:
					this.OnReplaceRow(e.OldStartingIndex, e.OldItems[0]);
					return;
				case NotifyCollectionChangedAction.Move:
					this.OnMoveRow(e.OldStartingIndex, e.NewStartingIndex);
					return;
				case NotifyCollectionChangedAction.Reset:
					this.RestoreOnlyFullRows(selectedRows);
					break;
				default:
					return;
				}
			}
		}

		// Token: 0x06000168 RID: 360 RVA: 0x00005F14 File Offset: 0x00004114
		private void OnAddRow(int rowIndex)
		{
			List<VirtualizedCellInfoCollection.CellRegion> list = null;
			int count = this._owner.Items.Count;
			int count2 = this._owner.Columns.Count;
			if (count2 > 0)
			{
				this.RemoveRegion(rowIndex, 0, count - 1 - rowIndex, count2, ref list);
				if (list != null)
				{
					int count3 = list.Count;
					for (int i = 0; i < count3; i++)
					{
						VirtualizedCellInfoCollection.CellRegion cellRegion = list[i];
						this.AddRegion(cellRegion.Top + 1, cellRegion.Left, cellRegion.Height, cellRegion.Width, false);
					}
				}
			}
		}

		// Token: 0x06000169 RID: 361 RVA: 0x00005FA4 File Offset: 0x000041A4
		private void OnRemoveRow(int rowIndex, object item)
		{
			List<VirtualizedCellInfoCollection.CellRegion> list = null;
			List<VirtualizedCellInfoCollection.CellRegion> list2 = null;
			int count = this._owner.Items.Count;
			int count2 = this._owner.Columns.Count;
			if (count2 > 0)
			{
				this.RemoveRegion(rowIndex + 1, 0, count - rowIndex, count2, ref list);
				this.RemoveRegion(rowIndex, 0, 1, count2, ref list2);
				if (list != null)
				{
					int count3 = list.Count;
					for (int i = 0; i < count3; i++)
					{
						VirtualizedCellInfoCollection.CellRegion cellRegion = list[i];
						this.AddRegion(cellRegion.Top - 1, cellRegion.Left, cellRegion.Height, cellRegion.Width, false);
					}
				}
				if (list2 != null)
				{
					VirtualizedCellInfoCollection.RemovedCellInfoCollection oldItems = new VirtualizedCellInfoCollection.RemovedCellInfoCollection(this._owner, list2, item);
					this.OnRemove(oldItems);
				}
			}
		}

		// Token: 0x0600016A RID: 362 RVA: 0x00006060 File Offset: 0x00004260
		private void OnReplaceRow(int rowIndex, object item)
		{
			List<VirtualizedCellInfoCollection.CellRegion> list = null;
			this.RemoveRegion(rowIndex, 0, 1, this._owner.Columns.Count, ref list);
			if (list != null)
			{
				VirtualizedCellInfoCollection.RemovedCellInfoCollection oldItems = new VirtualizedCellInfoCollection.RemovedCellInfoCollection(this._owner, list, item);
				this.OnRemove(oldItems);
			}
		}

		// Token: 0x0600016B RID: 363 RVA: 0x000060A4 File Offset: 0x000042A4
		private void OnMoveRow(int oldIndex, int newIndex)
		{
			List<VirtualizedCellInfoCollection.CellRegion> list = null;
			List<VirtualizedCellInfoCollection.CellRegion> list2 = null;
			int count = this._owner.Items.Count;
			int count2 = this._owner.Columns.Count;
			if (count2 > 0)
			{
				this.RemoveRegion(oldIndex + 1, 0, count - oldIndex - 1, count2, ref list);
				this.RemoveRegion(oldIndex, 0, 1, count2, ref list2);
				if (list != null)
				{
					int count3 = list.Count;
					for (int i = 0; i < count3; i++)
					{
						VirtualizedCellInfoCollection.CellRegion cellRegion = list[i];
						this.AddRegion(cellRegion.Top - 1, cellRegion.Left, cellRegion.Height, cellRegion.Width, false);
					}
				}
				list = null;
				this.RemoveRegion(newIndex, 0, count - newIndex, count2, ref list);
				if (list2 != null)
				{
					int count4 = list2.Count;
					for (int j = 0; j < count4; j++)
					{
						VirtualizedCellInfoCollection.CellRegion cellRegion2 = list2[j];
						this.AddRegion(newIndex, cellRegion2.Left, cellRegion2.Height, cellRegion2.Width, false);
					}
				}
				if (list != null)
				{
					int count5 = list.Count;
					for (int k = 0; k < count5; k++)
					{
						VirtualizedCellInfoCollection.CellRegion cellRegion3 = list[k];
						this.AddRegion(cellRegion3.Top + 1, cellRegion3.Left, cellRegion3.Height, cellRegion3.Width, false);
					}
				}
			}
		}

		// Token: 0x0600016C RID: 364 RVA: 0x000061E8 File Offset: 0x000043E8
		internal void OnColumnsChanged(NotifyCollectionChangedAction action, int oldDisplayIndex, DataGridColumn oldColumn, int newDisplayIndex, IList selectedRows)
		{
			if (!this.IsEmpty)
			{
				switch (action)
				{
				case NotifyCollectionChangedAction.Add:
					this.OnAddColumn(newDisplayIndex, selectedRows);
					return;
				case NotifyCollectionChangedAction.Remove:
					this.OnRemoveColumn(oldDisplayIndex, oldColumn);
					return;
				case NotifyCollectionChangedAction.Replace:
					this.OnReplaceColumn(oldDisplayIndex, oldColumn, selectedRows);
					return;
				case NotifyCollectionChangedAction.Move:
					this.OnMoveColumn(oldDisplayIndex, newDisplayIndex);
					return;
				case NotifyCollectionChangedAction.Reset:
					this._regions.Clear();
					break;
				default:
					return;
				}
			}
		}

		// Token: 0x0600016D RID: 365 RVA: 0x00006250 File Offset: 0x00004450
		private void OnAddColumn(int columnIndex, IList selectedRows)
		{
			List<VirtualizedCellInfoCollection.CellRegion> list = null;
			int count = this._owner.Items.Count;
			int count2 = this._owner.Columns.Count;
			if (count > 0)
			{
				this.RemoveRegion(0, columnIndex, count, count2 - 1 - columnIndex, ref list);
				if (list != null)
				{
					int count3 = list.Count;
					for (int i = 0; i < count3; i++)
					{
						VirtualizedCellInfoCollection.CellRegion cellRegion = list[i];
						this.AddRegion(cellRegion.Top, cellRegion.Left + 1, cellRegion.Height, cellRegion.Width, false);
					}
				}
				this.FillInFullRowRegions(selectedRows, columnIndex, true);
			}
		}

		// Token: 0x0600016E RID: 366 RVA: 0x000062E8 File Offset: 0x000044E8
		private void FillInFullRowRegions(IList rows, int columnIndex, bool notify)
		{
			int count = rows.Count;
			for (int i = 0; i < count; i++)
			{
				int num = this._owner.Items.IndexOf(rows[i]);
				if (num >= 0)
				{
					this.AddRegion(num, columnIndex, 1, 1, notify);
				}
			}
		}

		// Token: 0x0600016F RID: 367 RVA: 0x00006330 File Offset: 0x00004530
		private void OnRemoveColumn(int columnIndex, DataGridColumn oldColumn)
		{
			List<VirtualizedCellInfoCollection.CellRegion> list = null;
			List<VirtualizedCellInfoCollection.CellRegion> list2 = null;
			int count = this._owner.Items.Count;
			int count2 = this._owner.Columns.Count;
			if (count > 0)
			{
				this.RemoveRegion(0, columnIndex + 1, count, count2 - columnIndex, ref list);
				this.RemoveRegion(0, columnIndex, count, 1, ref list2);
				if (list != null)
				{
					int count3 = list.Count;
					for (int i = 0; i < count3; i++)
					{
						VirtualizedCellInfoCollection.CellRegion cellRegion = list[i];
						this.AddRegion(cellRegion.Top, cellRegion.Left - 1, cellRegion.Height, cellRegion.Width, false);
					}
				}
				if (list2 != null)
				{
					VirtualizedCellInfoCollection.RemovedCellInfoCollection oldItems = new VirtualizedCellInfoCollection.RemovedCellInfoCollection(this._owner, list2, oldColumn);
					this.OnRemove(oldItems);
				}
			}
		}

		// Token: 0x06000170 RID: 368 RVA: 0x000063EC File Offset: 0x000045EC
		private void OnReplaceColumn(int columnIndex, DataGridColumn oldColumn, IList selectedRows)
		{
			List<VirtualizedCellInfoCollection.CellRegion> list = null;
			this.RemoveRegion(0, columnIndex, this._owner.Items.Count, 1, ref list);
			if (list != null)
			{
				VirtualizedCellInfoCollection.RemovedCellInfoCollection oldItems = new VirtualizedCellInfoCollection.RemovedCellInfoCollection(this._owner, list, oldColumn);
				this.OnRemove(oldItems);
			}
			this.FillInFullRowRegions(selectedRows, columnIndex, true);
		}

		// Token: 0x06000171 RID: 369 RVA: 0x00006438 File Offset: 0x00004638
		private void OnMoveColumn(int oldIndex, int newIndex)
		{
			List<VirtualizedCellInfoCollection.CellRegion> list = null;
			List<VirtualizedCellInfoCollection.CellRegion> list2 = null;
			int count = this._owner.Items.Count;
			int count2 = this._owner.Columns.Count;
			if (count > 0)
			{
				this.RemoveRegion(0, oldIndex + 1, count, count2 - oldIndex - 1, ref list);
				this.RemoveRegion(0, oldIndex, count, 1, ref list2);
				if (list != null)
				{
					int count3 = list.Count;
					for (int i = 0; i < count3; i++)
					{
						VirtualizedCellInfoCollection.CellRegion cellRegion = list[i];
						this.AddRegion(cellRegion.Top, cellRegion.Left - 1, cellRegion.Height, cellRegion.Width, false);
					}
				}
				list = null;
				this.RemoveRegion(0, newIndex, count, count2 - newIndex, ref list);
				if (list2 != null)
				{
					int count4 = list2.Count;
					for (int j = 0; j < count4; j++)
					{
						VirtualizedCellInfoCollection.CellRegion cellRegion2 = list2[j];
						this.AddRegion(cellRegion2.Top, newIndex, cellRegion2.Height, cellRegion2.Width, false);
					}
				}
				if (list != null)
				{
					int count5 = list.Count;
					for (int k = 0; k < count5; k++)
					{
						VirtualizedCellInfoCollection.CellRegion cellRegion3 = list[k];
						this.AddRegion(cellRegion3.Top, cellRegion3.Left + 1, cellRegion3.Height, cellRegion3.Width, false);
					}
				}
			}
		}

		// Token: 0x06000172 RID: 370 RVA: 0x0000657C File Offset: 0x0000477C
		internal void Union(VirtualizedCellInfoCollection collection)
		{
			int count = collection._regions.Count;
			for (int i = 0; i < count; i++)
			{
				VirtualizedCellInfoCollection.CellRegion cellRegion = collection._regions[i];
				this.AddRegion(cellRegion.Top, cellRegion.Left, cellRegion.Height, cellRegion.Width);
			}
		}

		// Token: 0x06000173 RID: 371 RVA: 0x000065D0 File Offset: 0x000047D0
		internal static void Xor(VirtualizedCellInfoCollection c1, VirtualizedCellInfoCollection c2)
		{
			VirtualizedCellInfoCollection virtualizedCellInfoCollection = new VirtualizedCellInfoCollection(c2._owner, c2._regions);
			int count = c1._regions.Count;
			for (int i = 0; i < count; i++)
			{
				VirtualizedCellInfoCollection.CellRegion cellRegion = c1._regions[i];
				c2.RemoveRegion(cellRegion.Top, cellRegion.Left, cellRegion.Height, cellRegion.Width);
			}
			count = virtualizedCellInfoCollection._regions.Count;
			for (int j = 0; j < count; j++)
			{
				VirtualizedCellInfoCollection.CellRegion cellRegion2 = virtualizedCellInfoCollection._regions[j];
				c1.RemoveRegion(cellRegion2.Top, cellRegion2.Left, cellRegion2.Height, cellRegion2.Width);
			}
		}

		// Token: 0x06000174 RID: 372 RVA: 0x00006684 File Offset: 0x00004884
		internal void ClearFullRows(IList rows)
		{
			if (!this.IsEmpty)
			{
				int count = this._owner.Columns.Count;
				if (this._regions.Count == 1)
				{
					VirtualizedCellInfoCollection.CellRegion cellRegion = this._regions[0];
					if (cellRegion.Width == count && cellRegion.Height == rows.Count)
					{
						this.Clear();
						return;
					}
				}
				List<VirtualizedCellInfoCollection.CellRegion> list = new List<VirtualizedCellInfoCollection.CellRegion>();
				int count2 = rows.Count;
				for (int i = 0; i < count2; i++)
				{
					int num = this._owner.Items.IndexOf(rows[i]);
					if (num >= 0)
					{
						this.RemoveRegion(num, 0, 1, count, ref list);
					}
				}
				if (list.Count > 0)
				{
					this.OnRemove(new VirtualizedCellInfoCollection(this._owner, list));
				}
			}
		}

		// Token: 0x06000175 RID: 373 RVA: 0x0000674C File Offset: 0x0000494C
		internal void RestoreOnlyFullRows(IList rows)
		{
			this.Clear();
			int count = this._owner.Columns.Count;
			if (count > 0)
			{
				int count2 = rows.Count;
				for (int i = 0; i < count2; i++)
				{
					int num = this._owner.Items.IndexOf(rows[i]);
					if (num >= 0)
					{
						this.AddRegion(num, 0, 1, count);
					}
				}
			}
		}

		// Token: 0x06000176 RID: 374 RVA: 0x000067B0 File Offset: 0x000049B0
		internal void RemoveAllButOne(DataGridCellInfo cellInfo)
		{
			if (!this.IsEmpty)
			{
				int rowIndex;
				int columnIndex;
				this.ConvertCellInfoToIndexes(cellInfo, out rowIndex, out columnIndex);
				this.RemoveAllButRegion(rowIndex, columnIndex, 1, 1);
			}
		}

		// Token: 0x06000177 RID: 375 RVA: 0x000067DC File Offset: 0x000049DC
		internal void RemoveAllButOne()
		{
			if (!this.IsEmpty)
			{
				VirtualizedCellInfoCollection.CellRegion cellRegion = this._regions[0];
				this.RemoveAllButRegion(cellRegion.Top, cellRegion.Left, 1, 1);
			}
		}

		// Token: 0x06000178 RID: 376 RVA: 0x00006814 File Offset: 0x00004A14
		internal void RemoveAllButOneRow(int rowIndex)
		{
			if (!this.IsEmpty && rowIndex >= 0)
			{
				this.RemoveAllButRegion(rowIndex, 0, 1, this._owner.Columns.Count);
			}
		}

		// Token: 0x06000179 RID: 377 RVA: 0x0000683C File Offset: 0x00004A3C
		private void RemoveAllButRegion(int rowIndex, int columnIndex, int rowCount, int columnCount)
		{
			List<VirtualizedCellInfoCollection.CellRegion> list = null;
			this.RemoveRegion(rowIndex, columnIndex, rowCount, columnCount, ref list);
			VirtualizedCellInfoCollection oldItems = new VirtualizedCellInfoCollection(this._owner, this._regions);
			this._regions.Clear();
			this._regions.Add(new VirtualizedCellInfoCollection.CellRegion(columnIndex, rowIndex, columnCount, rowCount));
			this.OnRemove(oldItems);
		}

		// Token: 0x0600017A RID: 378 RVA: 0x00006894 File Offset: 0x00004A94
		internal bool Intersects(int rowIndex)
		{
			VirtualizedCellInfoCollection.CellRegion region = new VirtualizedCellInfoCollection.CellRegion(0, rowIndex, this._owner.Columns.Count, 1);
			int count = this._regions.Count;
			for (int i = 0; i < count; i++)
			{
				if (this._regions[i].Intersects(region))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600017B RID: 379 RVA: 0x000068F0 File Offset: 0x00004AF0
		internal bool Intersects(int rowIndex, out List<int> columnIndexRanges)
		{
			VirtualizedCellInfoCollection.CellRegion region = new VirtualizedCellInfoCollection.CellRegion(0, rowIndex, this._owner.Columns.Count, 1);
			columnIndexRanges = null;
			int count = this._regions.Count;
			for (int i = 0; i < count; i++)
			{
				VirtualizedCellInfoCollection.CellRegion cellRegion = this._regions[i];
				if (cellRegion.Intersects(region))
				{
					if (columnIndexRanges == null)
					{
						columnIndexRanges = new List<int>();
					}
					columnIndexRanges.Add(cellRegion.Left);
					columnIndexRanges.Add(cellRegion.Width);
				}
			}
			return columnIndexRanges != null;
		}

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x0600017C RID: 380 RVA: 0x00006978 File Offset: 0x00004B78
		protected DataGrid Owner
		{
			get
			{
				return this._owner;
			}
		}

		// Token: 0x0600017D RID: 381 RVA: 0x00006980 File Offset: 0x00004B80
		private void ConvertCellInfoToIndexes(DataGridCellInfo cell, out int rowIndex, out int columnIndex)
		{
			columnIndex = cell.Column.DisplayIndex;
			rowIndex = this._owner.Items.IndexOf(cell.Item);
		}

		// Token: 0x0600017E RID: 382 RVA: 0x000069AC File Offset: 0x00004BAC
		private static void ConvertIndexToIndexes(List<VirtualizedCellInfoCollection.CellRegion> regions, int index, out int rowIndex, out int columnIndex)
		{
			columnIndex = -1;
			rowIndex = -1;
			int count = regions.Count;
			for (int i = 0; i < count; i++)
			{
				VirtualizedCellInfoCollection.CellRegion cellRegion = regions[i];
				int size = cellRegion.Size;
				if (index < size)
				{
					columnIndex = cellRegion.Left + index % cellRegion.Width;
					rowIndex = cellRegion.Top + index / cellRegion.Width;
					return;
				}
				index -= size;
			}
		}

		// Token: 0x0600017F RID: 383 RVA: 0x00006A14 File Offset: 0x00004C14
		private DataGridCellInfo GetCellInfoFromIndex(DataGrid owner, List<VirtualizedCellInfoCollection.CellRegion> regions, int index)
		{
			int num;
			int num2;
			VirtualizedCellInfoCollection.ConvertIndexToIndexes(regions, index, out num, out num2);
			if (num >= 0 && num2 >= 0 && num < owner.Items.Count && num2 < owner.Columns.Count)
			{
				DataGridColumn column = owner.ColumnFromDisplayIndex(num2);
				object rowItem = owner.Items[num];
				return this.CreateCellInfo(rowItem, column, owner);
			}
			return DataGridCellInfo.Unset;
		}

		// Token: 0x06000180 RID: 384 RVA: 0x00006A74 File Offset: 0x00004C74
		private void ValidateIsReadOnly()
		{
			if (this.IsReadOnly)
			{
				throw new NotSupportedException(SR.Get(SRID.VirtualizedCellInfoCollection_IsReadOnly));
			}
		}

		// Token: 0x06000181 RID: 385 RVA: 0x00006A90 File Offset: 0x00004C90
		private void AddRegionToList(VirtualizedCellInfoCollection.CellRegion region, List<DataGridCellInfo> list)
		{
			for (int i = region.Top; i <= region.Bottom; i++)
			{
				object rowItem = this._owner.Items[i];
				for (int j = region.Left; j <= region.Right; j++)
				{
					DataGridColumn column = this._owner.ColumnFromDisplayIndex(j);
					DataGridCellInfo item = this.CreateCellInfo(rowItem, column, this._owner);
					list.Add(item);
				}
			}
		}

		// Token: 0x06000182 RID: 386 RVA: 0x00006B04 File Offset: 0x00004D04
		protected virtual DataGridCellInfo CreateCellInfo(object rowItem, DataGridColumn column, DataGrid owner)
		{
			return new DataGridCellInfo(rowItem, column, owner);
		}

		// Token: 0x04000063 RID: 99
		private bool _isReadOnly;

		// Token: 0x04000064 RID: 100
		private DataGrid _owner;

		// Token: 0x04000065 RID: 101
		private List<VirtualizedCellInfoCollection.CellRegion> _regions;

		// Token: 0x02000016 RID: 22
		private class VirtualizedCellInfoCollectionEnumerator : IEnumerator<DataGridCellInfo>, IDisposable, IEnumerator
		{
			// Token: 0x06000183 RID: 387 RVA: 0x00006B10 File Offset: 0x00004D10
			public VirtualizedCellInfoCollectionEnumerator(DataGrid owner, List<VirtualizedCellInfoCollection.CellRegion> regions, VirtualizedCellInfoCollection collection)
			{
				this._owner = owner;
				this._regions = new List<VirtualizedCellInfoCollection.CellRegion>(regions);
				this._current = -1;
				this._collection = collection;
				if (this._regions != null)
				{
					int count = this._regions.Count;
					for (int i = 0; i < count; i++)
					{
						this._count += this._regions[i].Size;
					}
				}
			}

			// Token: 0x06000184 RID: 388 RVA: 0x00006B85 File Offset: 0x00004D85
			public void Dispose()
			{
				GC.SuppressFinalize(this);
			}

			// Token: 0x06000185 RID: 389 RVA: 0x00006B8D File Offset: 0x00004D8D
			public bool MoveNext()
			{
				if (this._current < this._count)
				{
					this._current++;
				}
				return this.CurrentWithinBounds;
			}

			// Token: 0x06000186 RID: 390 RVA: 0x00006BB1 File Offset: 0x00004DB1
			public void Reset()
			{
				this._current = -1;
			}

			// Token: 0x1700007C RID: 124
			// (get) Token: 0x06000187 RID: 391 RVA: 0x00006BBA File Offset: 0x00004DBA
			public DataGridCellInfo Current
			{
				get
				{
					if (this.CurrentWithinBounds)
					{
						return this._collection.GetCellInfoFromIndex(this._owner, this._regions, this._current);
					}
					return DataGridCellInfo.Unset;
				}
			}

			// Token: 0x1700007D RID: 125
			// (get) Token: 0x06000188 RID: 392 RVA: 0x00006BE7 File Offset: 0x00004DE7
			private bool CurrentWithinBounds
			{
				get
				{
					return this._current >= 0 && this._current < this._count;
				}
			}

			// Token: 0x1700007E RID: 126
			// (get) Token: 0x06000189 RID: 393 RVA: 0x00006C02 File Offset: 0x00004E02
			object IEnumerator.Current
			{
				get
				{
					return this.Current;
				}
			}

			// Token: 0x04000066 RID: 102
			private DataGrid _owner;

			// Token: 0x04000067 RID: 103
			private List<VirtualizedCellInfoCollection.CellRegion> _regions;

			// Token: 0x04000068 RID: 104
			private int _current;

			// Token: 0x04000069 RID: 105
			private int _count;

			// Token: 0x0400006A RID: 106
			private VirtualizedCellInfoCollection _collection;
		}

		// Token: 0x02000017 RID: 23
		private struct CellRegion
		{
			// Token: 0x0600018A RID: 394 RVA: 0x00006C0F File Offset: 0x00004E0F
			public CellRegion(int left, int top, int width, int height)
			{
				this._left = left;
				this._top = top;
				this._width = width;
				this._height = height;
			}

			// Token: 0x1700007F RID: 127
			// (get) Token: 0x0600018B RID: 395 RVA: 0x00006C2E File Offset: 0x00004E2E
			// (set) Token: 0x0600018C RID: 396 RVA: 0x00006C36 File Offset: 0x00004E36
			public int Left
			{
				get
				{
					return this._left;
				}
				set
				{
					this._left = value;
				}
			}

			// Token: 0x17000080 RID: 128
			// (get) Token: 0x0600018D RID: 397 RVA: 0x00006C3F File Offset: 0x00004E3F
			// (set) Token: 0x0600018E RID: 398 RVA: 0x00006C47 File Offset: 0x00004E47
			public int Top
			{
				get
				{
					return this._top;
				}
				set
				{
					this._top = value;
				}
			}

			// Token: 0x17000081 RID: 129
			// (get) Token: 0x0600018F RID: 399 RVA: 0x00006C50 File Offset: 0x00004E50
			// (set) Token: 0x06000190 RID: 400 RVA: 0x00006C61 File Offset: 0x00004E61
			public int Right
			{
				get
				{
					return this._left + this._width - 1;
				}
				set
				{
					this._width = value - this._left + 1;
				}
			}

			// Token: 0x17000082 RID: 130
			// (get) Token: 0x06000191 RID: 401 RVA: 0x00006C73 File Offset: 0x00004E73
			// (set) Token: 0x06000192 RID: 402 RVA: 0x00006C84 File Offset: 0x00004E84
			public int Bottom
			{
				get
				{
					return this._top + this._height - 1;
				}
				set
				{
					this._height = value - this._top + 1;
				}
			}

			// Token: 0x17000083 RID: 131
			// (get) Token: 0x06000193 RID: 403 RVA: 0x00006C96 File Offset: 0x00004E96
			// (set) Token: 0x06000194 RID: 404 RVA: 0x00006C9E File Offset: 0x00004E9E
			public int Width
			{
				get
				{
					return this._width;
				}
				set
				{
					this._width = value;
				}
			}

			// Token: 0x17000084 RID: 132
			// (get) Token: 0x06000195 RID: 405 RVA: 0x00006CA7 File Offset: 0x00004EA7
			// (set) Token: 0x06000196 RID: 406 RVA: 0x00006CAF File Offset: 0x00004EAF
			public int Height
			{
				get
				{
					return this._height;
				}
				set
				{
					this._height = value;
				}
			}

			// Token: 0x17000085 RID: 133
			// (get) Token: 0x06000197 RID: 407 RVA: 0x00006CB8 File Offset: 0x00004EB8
			public bool IsEmpty
			{
				get
				{
					return this._width == 0 || this._height == 0;
				}
			}

			// Token: 0x17000086 RID: 134
			// (get) Token: 0x06000198 RID: 408 RVA: 0x00006CCD File Offset: 0x00004ECD
			public int Size
			{
				get
				{
					return this._width * this._height;
				}
			}

			// Token: 0x06000199 RID: 409 RVA: 0x00006CDC File Offset: 0x00004EDC
			public bool Contains(int x, int y)
			{
				return !this.IsEmpty && (x >= this.Left && y >= this.Top && x <= this.Right) && y <= this.Bottom;
			}

			// Token: 0x0600019A RID: 410 RVA: 0x00006D14 File Offset: 0x00004F14
			public bool Contains(VirtualizedCellInfoCollection.CellRegion region)
			{
				return this.Left <= region.Left && this.Top <= region.Top && this.Right >= region.Right && this.Bottom >= region.Bottom;
			}

			// Token: 0x0600019B RID: 411 RVA: 0x00006D64 File Offset: 0x00004F64
			public bool Intersects(VirtualizedCellInfoCollection.CellRegion region)
			{
				return VirtualizedCellInfoCollection.CellRegion.Intersects(this.Left, this.Right, region.Left, region.Right) && VirtualizedCellInfoCollection.CellRegion.Intersects(this.Top, this.Bottom, region.Top, region.Bottom);
			}

			// Token: 0x0600019C RID: 412 RVA: 0x00006DB3 File Offset: 0x00004FB3
			private static bool Intersects(int start1, int end1, int start2, int end2)
			{
				return start1 <= end2 && end1 >= start2;
			}

			// Token: 0x0600019D RID: 413 RVA: 0x00006DC4 File Offset: 0x00004FC4
			public VirtualizedCellInfoCollection.CellRegion Intersection(VirtualizedCellInfoCollection.CellRegion region)
			{
				if (this.Intersects(region))
				{
					int num = Math.Max(this.Left, region.Left);
					int num2 = Math.Max(this.Top, region.Top);
					int num3 = Math.Min(this.Right, region.Right);
					int num4 = Math.Min(this.Bottom, region.Bottom);
					return new VirtualizedCellInfoCollection.CellRegion(num, num2, num3 - num + 1, num4 - num2 + 1);
				}
				return VirtualizedCellInfoCollection.CellRegion.Empty;
			}

			// Token: 0x0600019E RID: 414 RVA: 0x00006E40 File Offset: 0x00005040
			public bool Union(VirtualizedCellInfoCollection.CellRegion region)
			{
				if (this.Contains(region))
				{
					return true;
				}
				if (region.Contains(this))
				{
					this.Left = region.Left;
					this.Top = region.Top;
					this.Width = region.Width;
					this.Height = region.Height;
					return true;
				}
				bool flag = region.Left == this.Left && region.Width == this.Width;
				bool flag2 = region.Top == this.Top && region.Height == this.Height;
				if (flag || flag2)
				{
					int num = flag ? this.Top : this.Left;
					int num2 = flag ? this.Bottom : this.Right;
					int num3 = flag ? region.Top : region.Left;
					int num4 = flag ? region.Bottom : region.Right;
					bool flag3 = false;
					if (num4 <= num2)
					{
						flag3 = (num - num4 <= 1);
					}
					else if (num <= num3)
					{
						flag3 = (num3 - num2 <= 1);
					}
					if (flag3)
					{
						int right = this.Right;
						int bottom = this.Bottom;
						this.Left = Math.Min(this.Left, region.Left);
						this.Top = Math.Min(this.Top, region.Top);
						this.Right = Math.Max(right, region.Right);
						this.Bottom = Math.Max(bottom, region.Bottom);
						return true;
					}
				}
				return false;
			}

			// Token: 0x0600019F RID: 415 RVA: 0x00006FD0 File Offset: 0x000051D0
			public bool Remainder(VirtualizedCellInfoCollection.CellRegion region, out List<VirtualizedCellInfoCollection.CellRegion> remainder)
			{
				if (this.Intersects(region))
				{
					if (region.Contains(this))
					{
						remainder = null;
					}
					else
					{
						remainder = new List<VirtualizedCellInfoCollection.CellRegion>();
						if (this.Top < region.Top)
						{
							remainder.Add(new VirtualizedCellInfoCollection.CellRegion(this.Left, this.Top, this.Width, region.Top - this.Top));
						}
						if (this.Left < region.Left)
						{
							int num = Math.Max(this.Top, region.Top);
							int num2 = Math.Min(this.Bottom, region.Bottom);
							remainder.Add(new VirtualizedCellInfoCollection.CellRegion(this.Left, num, region.Left - this.Left, num2 - num + 1));
						}
						if (this.Right > region.Right)
						{
							int num3 = Math.Max(this.Top, region.Top);
							int num4 = Math.Min(this.Bottom, region.Bottom);
							remainder.Add(new VirtualizedCellInfoCollection.CellRegion(region.Right + 1, num3, this.Right - region.Right, num4 - num3 + 1));
						}
						if (this.Bottom > region.Bottom)
						{
							remainder.Add(new VirtualizedCellInfoCollection.CellRegion(this.Left, region.Bottom + 1, this.Width, this.Bottom - region.Bottom));
						}
					}
					return true;
				}
				remainder = null;
				return false;
			}

			// Token: 0x17000087 RID: 135
			// (get) Token: 0x060001A0 RID: 416 RVA: 0x0000713F File Offset: 0x0000533F
			public static VirtualizedCellInfoCollection.CellRegion Empty
			{
				get
				{
					return new VirtualizedCellInfoCollection.CellRegion(0, 0, 0, 0);
				}
			}

			// Token: 0x0400006B RID: 107
			private int _left;

			// Token: 0x0400006C RID: 108
			private int _top;

			// Token: 0x0400006D RID: 109
			private int _width;

			// Token: 0x0400006E RID: 110
			private int _height;
		}

		// Token: 0x02000018 RID: 24
		private class RemovedCellInfoCollection : VirtualizedCellInfoCollection
		{
			// Token: 0x060001A1 RID: 417 RVA: 0x0000714A File Offset: 0x0000534A
			internal RemovedCellInfoCollection(DataGrid owner, List<VirtualizedCellInfoCollection.CellRegion> regions, DataGridColumn column) : base(owner, regions)
			{
				this._removedColumn = column;
			}

			// Token: 0x060001A2 RID: 418 RVA: 0x0000715B File Offset: 0x0000535B
			internal RemovedCellInfoCollection(DataGrid owner, List<VirtualizedCellInfoCollection.CellRegion> regions, object item) : base(owner, regions)
			{
				this._removedItem = item;
			}

			// Token: 0x060001A3 RID: 419 RVA: 0x0000716C File Offset: 0x0000536C
			protected override DataGridCellInfo CreateCellInfo(object rowItem, DataGridColumn column, DataGrid owner)
			{
				if (this._removedColumn != null)
				{
					return new DataGridCellInfo(rowItem, this._removedColumn, owner);
				}
				return new DataGridCellInfo(this._removedItem, column, owner);
			}

			// Token: 0x0400006F RID: 111
			private DataGridColumn _removedColumn;

			// Token: 0x04000070 RID: 112
			private object _removedItem;
		}
	}
}
