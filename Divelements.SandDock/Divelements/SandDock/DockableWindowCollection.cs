using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Divelements.SandDock
{
	// Token: 0x0200001E RID: 30
	public class DockableWindowCollection : ObservableCollection<DockableWindow>
	{
		// Token: 0x06000230 RID: 560 RVA: 0x00039528 File Offset: 0x00037928
		internal DockableWindowCollection(WindowGroup parent)
		{
			this.xb6a159a84cb992d6 = parent;
		}

		// Token: 0x06000231 RID: 561 RVA: 0x00039538 File Offset: 0x00037938
		protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
		{
			base.OnCollectionChanged(e);
			this.xb6a159a84cb992d6.NotifyChildrenChanged();
		}

		// Token: 0x06000232 RID: 562 RVA: 0x0003954C File Offset: 0x0003794C
		private void xbd21b80c1f547dc5(DockableWindow x76b3d9d2638e5ecd)
		{
			this.xb6a159a84cb992d6.AddLogicalChild(x76b3d9d2638e5ecd);
		}

		// Token: 0x06000233 RID: 563 RVA: 0x0003955C File Offset: 0x0003795C
		private void x520aa4f2f5eb2b41(DockableWindow x76b3d9d2638e5ecd)
		{
			this.xb6a159a84cb992d6.RemoveLogicalChild(x76b3d9d2638e5ecd);
		}

		// Token: 0x06000234 RID: 564 RVA: 0x0003956C File Offset: 0x0003796C
		protected override void InsertItem(int index, DockableWindow item)
		{
			this.xbd21b80c1f547dc5(item);
			try
			{
				base.InsertItem(index, item);
			}
			catch
			{
				this.x520aa4f2f5eb2b41(item);
			}
		}

		// Token: 0x06000235 RID: 565 RVA: 0x000395B0 File Offset: 0x000379B0
		protected override void RemoveItem(int index)
		{
			DockableWindow x76b3d9d2638e5ecd = base[index];
			base.RemoveItem(index);
			this.x520aa4f2f5eb2b41(x76b3d9d2638e5ecd);
		}

		// Token: 0x06000236 RID: 566 RVA: 0x000395D4 File Offset: 0x000379D4
		protected override void ClearItems()
		{
			foreach (DockableWindow x76b3d9d2638e5ecd in this)
			{
				this.x520aa4f2f5eb2b41(x76b3d9d2638e5ecd);
			}
			base.ClearItems();
		}

		// Token: 0x040000B7 RID: 183
		private WindowGroup xb6a159a84cb992d6;
	}
}
