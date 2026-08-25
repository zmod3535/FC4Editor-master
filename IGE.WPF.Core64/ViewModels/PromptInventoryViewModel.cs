using System;
using IGE.Nomad;
using IGE.Parameters;
using Ubisoft;

namespace IGE.ViewModels
{
	// Token: 0x0200038A RID: 906
	internal class PromptInventoryViewModel : ViewModel
	{
		// Token: 0x17000278 RID: 632
		// (set) Token: 0x06001472 RID: 5234 RVA: 0x0002B984 File Offset: 0x00029B84
		public Inventory.Entry Root
		{
			set
			{
				this.Tree = new InventoryTreeViewModel(value);
			}
		}

		// Token: 0x17000279 RID: 633
		// (get) Token: 0x06001473 RID: 5235 RVA: 0x0002B992 File Offset: 0x00029B92
		public Inventory.Entry Value
		{
			get
			{
				return this.Tree.SelectedItem.Model;
			}
		}

		// Token: 0x1700027A RID: 634
		// (get) Token: 0x06001474 RID: 5236 RVA: 0x0002B9A4 File Offset: 0x00029BA4
		// (set) Token: 0x06001475 RID: 5237 RVA: 0x0002B9AC File Offset: 0x00029BAC
		public InventoryTreeViewModel Tree
		{
			get
			{
				return this._tree;
			}
			set
			{
				this._tree = value;
				base.RaisePropertyChanged("Tree");
			}
		}

		// Token: 0x04000782 RID: 1922
		private InventoryTreeViewModel _tree;
	}
}
