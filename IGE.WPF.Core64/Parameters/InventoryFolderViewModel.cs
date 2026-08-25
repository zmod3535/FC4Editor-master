using System;
using System.Collections.ObjectModel;
using System.Windows.Media;
using IGE.Nomad;
using Ubisoft;

namespace IGE.Parameters
{
	// Token: 0x0200007D RID: 125
	internal class InventoryFolderViewModel : ViewModel
	{
		// Token: 0x06000546 RID: 1350 RVA: 0x0001437A File Offset: 0x0001257A
		public InventoryFolderViewModel(Inventory.Entry model, int depth, InventoryFolderViewModel parent, Func<Inventory.Entry, bool> filter = null)
		{
			this._model = model;
			this.Image = this._model.Icon;
			this.Depth = depth;
			this.Parent = parent;
			this._filter = filter;
		}

		// Token: 0x17000112 RID: 274
		// (get) Token: 0x06000547 RID: 1351 RVA: 0x000143B0 File Offset: 0x000125B0
		public Inventory.Entry Model
		{
			get
			{
				return this._model;
			}
		}

		// Token: 0x17000113 RID: 275
		// (get) Token: 0x06000548 RID: 1352 RVA: 0x000143B8 File Offset: 0x000125B8
		// (set) Token: 0x06000549 RID: 1353 RVA: 0x000143C0 File Offset: 0x000125C0
		public InventoryFolderViewModel Parent { get; private set; }

		// Token: 0x17000114 RID: 276
		// (get) Token: 0x0600054A RID: 1354 RVA: 0x000143C9 File Offset: 0x000125C9
		// (set) Token: 0x0600054B RID: 1355 RVA: 0x000143D1 File Offset: 0x000125D1
		public ImageSource Image
		{
			get
			{
				return this._image;
			}
			set
			{
				this._image = value;
				base.RaisePropertyChanged("Image");
			}
		}

		// Token: 0x17000115 RID: 277
		// (get) Token: 0x0600054C RID: 1356 RVA: 0x000143E5 File Offset: 0x000125E5
		public string Text
		{
			get
			{
				return this._model.DisplayName;
			}
		}

		// Token: 0x17000116 RID: 278
		// (get) Token: 0x0600054D RID: 1357 RVA: 0x000143F2 File Offset: 0x000125F2
		// (set) Token: 0x0600054E RID: 1358 RVA: 0x000143FA File Offset: 0x000125FA
		public int Depth { get; set; }

		// Token: 0x17000117 RID: 279
		// (get) Token: 0x0600054F RID: 1359 RVA: 0x00014403 File Offset: 0x00012603
		public int DepthSpace
		{
			get
			{
				return 16 * this.Depth;
			}
		}

		// Token: 0x17000118 RID: 280
		// (get) Token: 0x06000550 RID: 1360 RVA: 0x0001440E File Offset: 0x0001260E
		// (set) Token: 0x06000551 RID: 1361 RVA: 0x00014416 File Offset: 0x00012616
		public int ChildEntries
		{
			get
			{
				return this._childEntries;
			}
			set
			{
				if (this._childEntries == value)
				{
					return;
				}
				this._childEntries = value;
				base.RaisePropertyChanged("ChildEntries");
			}
		}

		// Token: 0x17000119 RID: 281
		// (get) Token: 0x06000552 RID: 1362 RVA: 0x00014434 File Offset: 0x00012634
		// (set) Token: 0x06000553 RID: 1363 RVA: 0x0001443C File Offset: 0x0001263C
		public int ChildFolders
		{
			get
			{
				return this._childFolders;
			}
			set
			{
				if (this._childFolders == value)
				{
					return;
				}
				this._childFolders = value;
				base.RaisePropertyChanged("ChildFolders");
			}
		}

		// Token: 0x1700011A RID: 282
		// (get) Token: 0x06000554 RID: 1364 RVA: 0x0001445C File Offset: 0x0001265C
		public ObservableCollection<InventoryEntryViewModel> Children
		{
			get
			{
				if (this._children == null)
				{
					this._children = new ObservableCollection<InventoryEntryViewModel>();
					foreach (Inventory.Entry entry in this._model.Children)
					{
						if (this._filter == null || (this._filter != null && this._filter(entry)))
						{
							InventoryEntryViewModel item = new InventoryEntryViewModel(entry);
							this._children.Add(item);
						}
					}
				}
				return this._children;
			}
		}

		// Token: 0x1700011B RID: 283
		// (get) Token: 0x06000555 RID: 1365 RVA: 0x000144D1 File Offset: 0x000126D1
		public string ChildEntriesText
		{
			get
			{
				if (this.ChildEntries != 0)
				{
					return "(" + this.ChildEntries + ")";
				}
				return "";
			}
		}

		// Token: 0x04000239 RID: 569
		private readonly Inventory.Entry _model;

		// Token: 0x0400023A RID: 570
		private ObservableCollection<InventoryEntryViewModel> _children;

		// Token: 0x0400023B RID: 571
		private Func<Inventory.Entry, bool> _filter;

		// Token: 0x0400023C RID: 572
		private ImageSource _image;

		// Token: 0x0400023D RID: 573
		private int _childEntries;

		// Token: 0x0400023E RID: 574
		private int _childFolders;
	}
}
