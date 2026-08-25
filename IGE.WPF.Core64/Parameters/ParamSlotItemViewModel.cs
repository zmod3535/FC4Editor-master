using System;
using IGE.Nomad;

namespace IGE.Parameters
{
	// Token: 0x02000027 RID: 39
	internal class ParamSlotItemViewModel : InventoryEntryViewModel
	{
		// Token: 0x06000117 RID: 279 RVA: 0x0000397B File Offset: 0x00001B7B
		public ParamSlotItemViewModel(Inventory.Entry item, int value) : base(item)
		{
			this.Value = value;
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x06000118 RID: 280 RVA: 0x0000398B File Offset: 0x00001B8B
		// (set) Token: 0x06000119 RID: 281 RVA: 0x00003993 File Offset: 0x00001B93
		public int Value { get; private set; }
	}
}
