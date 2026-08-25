using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Microsoft.Windows.Controls
{
	// Token: 0x02000070 RID: 112
	public class SelectedCellsChangedEventArgs : EventArgs
	{
		// Token: 0x060007E3 RID: 2019 RVA: 0x0002304A File Offset: 0x0002124A
		public SelectedCellsChangedEventArgs(List<DataGridCellInfo> addedCells, List<DataGridCellInfo> removedCells)
		{
			if (addedCells == null)
			{
				throw new ArgumentNullException("addedCells");
			}
			if (removedCells == null)
			{
				throw new ArgumentNullException("removedCells");
			}
			this._addedCells = addedCells.AsReadOnly();
			this._removedCells = removedCells.AsReadOnly();
		}

		// Token: 0x060007E4 RID: 2020 RVA: 0x00023086 File Offset: 0x00021286
		public SelectedCellsChangedEventArgs(ReadOnlyCollection<DataGridCellInfo> addedCells, ReadOnlyCollection<DataGridCellInfo> removedCells)
		{
			if (addedCells == null)
			{
				throw new ArgumentNullException("addedCells");
			}
			if (removedCells == null)
			{
				throw new ArgumentNullException("removedCells");
			}
			this._addedCells = addedCells;
			this._removedCells = removedCells;
		}

		// Token: 0x060007E5 RID: 2021 RVA: 0x000230B8 File Offset: 0x000212B8
		internal SelectedCellsChangedEventArgs(DataGrid owner, VirtualizedCellInfoCollection addedCells, VirtualizedCellInfoCollection removedCells)
		{
			this._addedCells = ((addedCells != null) ? addedCells : VirtualizedCellInfoCollection.MakeEmptyCollection(owner));
			this._removedCells = ((removedCells != null) ? removedCells : VirtualizedCellInfoCollection.MakeEmptyCollection(owner));
		}

		// Token: 0x170001E7 RID: 487
		// (get) Token: 0x060007E6 RID: 2022 RVA: 0x000230E4 File Offset: 0x000212E4
		public IList<DataGridCellInfo> AddedCells
		{
			get
			{
				return this._addedCells;
			}
		}

		// Token: 0x170001E8 RID: 488
		// (get) Token: 0x060007E7 RID: 2023 RVA: 0x000230EC File Offset: 0x000212EC
		public IList<DataGridCellInfo> RemovedCells
		{
			get
			{
				return this._removedCells;
			}
		}

		// Token: 0x04000283 RID: 643
		private IList<DataGridCellInfo> _addedCells;

		// Token: 0x04000284 RID: 644
		private IList<DataGridCellInfo> _removedCells;
	}
}
