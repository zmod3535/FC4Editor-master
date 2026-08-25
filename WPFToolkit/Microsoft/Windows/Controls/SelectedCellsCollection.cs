using System;
using System.Collections.Specialized;

namespace Microsoft.Windows.Controls
{
	// Token: 0x02000019 RID: 25
	internal sealed class SelectedCellsCollection : VirtualizedCellInfoCollection
	{
		// Token: 0x060001A4 RID: 420 RVA: 0x00007191 File Offset: 0x00005391
		internal SelectedCellsCollection(DataGrid owner) : base(owner)
		{
		}

		// Token: 0x060001A5 RID: 421 RVA: 0x0000719A File Offset: 0x0000539A
		internal bool GetSelectionRange(out int minColumnDisplayIndex, out int maxColumnDisplayIndex, out int minRowIndex, out int maxRowIndex)
		{
			if (base.IsEmpty)
			{
				minColumnDisplayIndex = -1;
				maxColumnDisplayIndex = -1;
				minRowIndex = -1;
				maxRowIndex = -1;
				return false;
			}
			base.GetBoundingRegion(out minColumnDisplayIndex, out minRowIndex, out maxColumnDisplayIndex, out maxRowIndex);
			return true;
		}

		// Token: 0x060001A6 RID: 422 RVA: 0x000071BF File Offset: 0x000053BF
		protected override void OnCollectionChanged(NotifyCollectionChangedAction action, VirtualizedCellInfoCollection oldItems, VirtualizedCellInfoCollection newItems)
		{
			base.Owner.OnSelectedCellsChanged(action, oldItems, newItems);
		}
	}
}
