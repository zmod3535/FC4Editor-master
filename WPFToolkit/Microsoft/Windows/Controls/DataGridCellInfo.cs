using System;
using System.Windows;

namespace Microsoft.Windows.Controls
{
	// Token: 0x02000028 RID: 40
	public struct DataGridCellInfo
	{
		// Token: 0x0600023E RID: 574 RVA: 0x000093E3 File Offset: 0x000075E3
		public DataGridCellInfo(object item, DataGridColumn column)
		{
			if (column == null)
			{
				throw new ArgumentNullException("column");
			}
			this._item = item;
			this._column = column;
			this._owner = null;
		}

		// Token: 0x0600023F RID: 575 RVA: 0x00009408 File Offset: 0x00007608
		public DataGridCellInfo(DataGridCell cell)
		{
			if (cell == null)
			{
				throw new ArgumentNullException("cell");
			}
			this._item = cell.RowDataItem;
			this._column = cell.Column;
			this._owner = new WeakReference(cell.DataGridOwner);
		}

		// Token: 0x06000240 RID: 576 RVA: 0x00009441 File Offset: 0x00007641
		internal DataGridCellInfo(object item, DataGridColumn column, DataGrid owner)
		{
			this._item = item;
			this._column = column;
			this._owner = new WeakReference(owner);
		}

		// Token: 0x06000241 RID: 577 RVA: 0x0000945D File Offset: 0x0000765D
		internal DataGridCellInfo(object item)
		{
			this._item = item;
			this._column = null;
			this._owner = null;
		}

		// Token: 0x06000242 RID: 578 RVA: 0x00009474 File Offset: 0x00007674
		private DataGridCellInfo(DataGrid owner, DataGridColumn column, object item)
		{
			this._item = item;
			this._column = column;
			this._owner = new WeakReference(owner);
		}

		// Token: 0x06000243 RID: 579 RVA: 0x00009490 File Offset: 0x00007690
		internal static DataGridCellInfo CreatePossiblyPartialCellInfo(object item, DataGridColumn column, DataGrid owner)
		{
			if (item == null && column == null)
			{
				return DataGridCellInfo.Unset;
			}
			return new DataGridCellInfo(owner, column, (item == null) ? DependencyProperty.UnsetValue : item);
		}

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x06000244 RID: 580 RVA: 0x000094B0 File Offset: 0x000076B0
		public object Item
		{
			get
			{
				return this._item;
			}
		}

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x06000245 RID: 581 RVA: 0x000094B8 File Offset: 0x000076B8
		public DataGridColumn Column
		{
			get
			{
				return this._column;
			}
		}

		// Token: 0x06000246 RID: 582 RVA: 0x000094C0 File Offset: 0x000076C0
		public override bool Equals(object obj)
		{
			return obj is DataGridCellInfo && this.EqualsImpl((DataGridCellInfo)obj);
		}

		// Token: 0x06000247 RID: 583 RVA: 0x000094D8 File Offset: 0x000076D8
		public static bool operator ==(DataGridCellInfo cell1, DataGridCellInfo cell2)
		{
			return cell1.EqualsImpl(cell2);
		}

		// Token: 0x06000248 RID: 584 RVA: 0x000094E2 File Offset: 0x000076E2
		public static bool operator !=(DataGridCellInfo cell1, DataGridCellInfo cell2)
		{
			return !cell1.EqualsImpl(cell2);
		}

		// Token: 0x06000249 RID: 585 RVA: 0x000094EF File Offset: 0x000076EF
		internal bool EqualsImpl(DataGridCellInfo cell)
		{
			return cell._item == this._item && cell._column == this._column && cell.Owner == this.Owner;
		}

		// Token: 0x0600024A RID: 586 RVA: 0x00009520 File Offset: 0x00007720
		public override int GetHashCode()
		{
			return ((this._item == null) ? 0 : this._item.GetHashCode()) ^ ((this._column == null) ? 0 : this._column.GetHashCode());
		}

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x0600024B RID: 587 RVA: 0x0000954F File Offset: 0x0000774F
		public bool IsValid
		{
			get
			{
				return this.ArePropertyValuesValid;
			}
		}

		// Token: 0x0600024C RID: 588 RVA: 0x00009558 File Offset: 0x00007758
		internal bool IsValidForDataGrid(DataGrid dataGrid)
		{
			DataGrid owner = this.Owner;
			return (this.ArePropertyValuesValid && owner == dataGrid) || owner == null;
		}

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x0600024D RID: 589 RVA: 0x0000957E File Offset: 0x0000777E
		private bool ArePropertyValuesValid
		{
			get
			{
				return this._item != DependencyProperty.UnsetValue && this._column != null;
			}
		}

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x0600024E RID: 590 RVA: 0x0000959B File Offset: 0x0000779B
		internal static DataGridCellInfo Unset
		{
			get
			{
				return new DataGridCellInfo(DependencyProperty.UnsetValue);
			}
		}

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x0600024F RID: 591 RVA: 0x000095A7 File Offset: 0x000077A7
		private DataGrid Owner
		{
			get
			{
				if (this._owner != null)
				{
					return (DataGrid)this._owner.Target;
				}
				return null;
			}
		}

		// Token: 0x0400008B RID: 139
		private object _item;

		// Token: 0x0400008C RID: 140
		private DataGridColumn _column;

		// Token: 0x0400008D RID: 141
		private WeakReference _owner;
	}
}
