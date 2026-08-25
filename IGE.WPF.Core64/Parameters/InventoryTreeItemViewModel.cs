using System;
using System.Collections.ObjectModel;
using IGE.Nomad;

namespace IGE.Parameters
{
	// Token: 0x0200002B RID: 43
	internal class InventoryTreeItemViewModel : InventoryEntryViewModel
	{
		// Token: 0x0600012E RID: 302 RVA: 0x00003B84 File Offset: 0x00001D84
		public InventoryTreeItemViewModel(Inventory.Entry model, bool onlyDirectories = false) : base(model)
		{
			ObservableCollection<InventoryTreeItemViewModel> observableCollection = new ObservableCollection<InventoryTreeItemViewModel>();
			foreach (Inventory.Entry entry in model.Children)
			{
				if (!onlyDirectories || entry.IsDirectory)
				{
					observableCollection.Add(new InventoryTreeItemViewModel(entry, onlyDirectories));
				}
			}
			this.Children = ((observableCollection.Count == 0) ? null : observableCollection);
		}

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x0600012F RID: 303 RVA: 0x00003BE1 File Offset: 0x00001DE1
		// (set) Token: 0x06000130 RID: 304 RVA: 0x00003BE9 File Offset: 0x00001DE9
		public ObservableCollection<InventoryTreeItemViewModel> Children { get; private set; }
	}
}
