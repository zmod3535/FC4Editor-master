using System;
using System.Collections.ObjectModel;
using IGE.Nomad;
using Ubisoft;

namespace IGE.Parameters
{
	// Token: 0x0200002A RID: 42
	internal class InventoryTreeViewModel : ViewModel
	{
		// Token: 0x06000120 RID: 288 RVA: 0x00003A2D File Offset: 0x00001C2D
		public InventoryTreeViewModel()
		{
		}

		// Token: 0x06000121 RID: 289 RVA: 0x00003A35 File Offset: 0x00001C35
		public InventoryTreeViewModel(Inventory.Entry root)
		{
			this.Root = root;
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x06000122 RID: 290 RVA: 0x00003A44 File Offset: 0x00001C44
		// (set) Token: 0x06000123 RID: 291 RVA: 0x00003A4C File Offset: 0x00001C4C
		public InventoryTreeItemViewModel SelectedItem
		{
			get
			{
				return this._selectedItem;
			}
			set
			{
				if (this._selectedItem == value)
				{
					return;
				}
				this._selectedItem = value;
				base.RaisePropertyChanged("SelectedItem");
				base.RaisePropertyChanged("HasSelectedItem");
			}
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x06000124 RID: 292 RVA: 0x00003A75 File Offset: 0x00001C75
		public bool HasSelectedItem
		{
			get
			{
				return this.SelectedItem != null;
			}
		}

		// Token: 0x06000125 RID: 293 RVA: 0x00003A84 File Offset: 0x00001C84
		private void UpdateTree()
		{
			ObservableCollection<InventoryTreeItemViewModel> observableCollection = new ObservableCollection<InventoryTreeItemViewModel>();
			if (this.Root != null)
			{
				if (this.ShowRoot)
				{
					if (!this.OnlyDirectories || this.Root.IsDirectory)
					{
						observableCollection.Add(new InventoryTreeItemViewModel(this.Root, this.OnlyDirectories));
					}
				}
				else
				{
					foreach (Inventory.Entry entry in this.Root.Children)
					{
						if (!this.OnlyDirectories || entry.IsDirectory)
						{
							observableCollection.Add(new InventoryTreeItemViewModel(entry, this.OnlyDirectories));
						}
					}
				}
			}
			this.Items = observableCollection;
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x06000126 RID: 294 RVA: 0x00003B22 File Offset: 0x00001D22
		// (set) Token: 0x06000127 RID: 295 RVA: 0x00003B2A File Offset: 0x00001D2A
		public ObservableCollection<InventoryTreeItemViewModel> Items
		{
			get
			{
				return this._items;
			}
			set
			{
				this._items = value;
				base.RaisePropertyChanged("Items");
			}
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x06000128 RID: 296 RVA: 0x00003B3E File Offset: 0x00001D3E
		// (set) Token: 0x06000129 RID: 297 RVA: 0x00003B46 File Offset: 0x00001D46
		public Inventory.Entry Root
		{
			get
			{
				return this._root;
			}
			set
			{
				this._root = value;
				this.UpdateTree();
			}
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x0600012A RID: 298 RVA: 0x00003B55 File Offset: 0x00001D55
		// (set) Token: 0x0600012B RID: 299 RVA: 0x00003B5D File Offset: 0x00001D5D
		public bool OnlyDirectories
		{
			get
			{
				return this._onlyDirectories;
			}
			set
			{
				this._onlyDirectories = value;
				this.UpdateTree();
			}
		}

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x0600012C RID: 300 RVA: 0x00003B6C File Offset: 0x00001D6C
		// (set) Token: 0x0600012D RID: 301 RVA: 0x00003B74 File Offset: 0x00001D74
		public bool ShowRoot
		{
			get
			{
				return this._showRoot;
			}
			set
			{
				this._showRoot = value;
				this.UpdateTree();
			}
		}

		// Token: 0x0400005A RID: 90
		private InventoryTreeItemViewModel _selectedItem;

		// Token: 0x0400005B RID: 91
		private ObservableCollection<InventoryTreeItemViewModel> _items;

		// Token: 0x0400005C RID: 92
		private Inventory.Entry _root;

		// Token: 0x0400005D RID: 93
		private bool _onlyDirectories;

		// Token: 0x0400005E RID: 94
		private bool _showRoot;
	}
}
