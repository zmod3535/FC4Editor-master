using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using IGE.Nomad;
using Ubisoft;
using Ubisoft.ApplicationModel.ContextCommands;

namespace IGE.Parameters
{
	// Token: 0x02000378 RID: 888
	internal class ObjectSelectorViewModel : ViewModel
	{
		// Token: 0x060013AC RID: 5036 RVA: 0x00028F58 File Offset: 0x00027158
		public ObjectSelectorViewModel(Func<Inventory.Entry, bool> inFunc = null, bool showFolders = true)
		{
			SimpleCommand simpleCommand = new SimpleCommand();
			simpleCommand.ExecuteDelegate = delegate(object o)
			{
				this.ParentFolder();
			};
			simpleCommand.CanExecuteDelegate = ((object o) => this.FolderHasParent());
			this.CommandParent = simpleCommand;
			this.ShowFolders = showFolders;
			this._filterFunc = inFunc;
		}

		// Token: 0x060013AD RID: 5037 RVA: 0x00028FDC File Offset: 0x000271DC
		public ObjectSelectorViewModel()
		{
			SimpleCommand simpleCommand = new SimpleCommand();
			simpleCommand.ExecuteDelegate = delegate(object o)
			{
				this.ParentFolder();
			};
			simpleCommand.CanExecuteDelegate = ((object o) => this.FolderHasParent());
			this.CommandParent = simpleCommand;
		}

		// Token: 0x17000250 RID: 592
		// (get) Token: 0x060013AE RID: 5038 RVA: 0x00029040 File Offset: 0x00027240
		// (set) Token: 0x060013AF RID: 5039 RVA: 0x00029048 File Offset: 0x00027248
		public bool ShowFolders
		{
			get
			{
				return this._showFolders;
			}
			set
			{
				if (this._showFolders == value)
				{
					return;
				}
				this._showFolders = value;
				if (!this._showFolders)
				{
					this.Items = this._allItems;
				}
				else
				{
					this.SelectDefaultFolder();
				}
				base.RaisePropertyChanged("ShowFolders");
			}
		}

		// Token: 0x17000251 RID: 593
		// (get) Token: 0x060013B0 RID: 5040 RVA: 0x00029082 File Offset: 0x00027282
		// (set) Token: 0x060013B1 RID: 5041 RVA: 0x0002908A File Offset: 0x0002728A
		public Func<Inventory.Entry, bool> Filter
		{
			get
			{
				return this._filterFunc;
			}
			set
			{
				this._filterFunc = value;
				this.FilterInventory();
			}
		}

		// Token: 0x060013B2 RID: 5042 RVA: 0x0002909C File Offset: 0x0002729C
		public void FilterInventory()
		{
			List<InventoryFolderViewModel> list = new List<InventoryFolderViewModel>();
			this.FillCategories(this._root, 0, ref list, null);
			this.FilterEmptyBranches(ref list);
			this.FilterEmptyRoot(ref list);
			this.Folders = new ObservableCollection<InventoryFolderViewModel>(list);
			this._allItems = new ObservableCollection<InventoryEntryViewModel>();
			this.FilterInventoryItems(this.Folders);
			if (!this._showFolders)
			{
				this.Items = this._allItems;
			}
		}

		// Token: 0x060013B3 RID: 5043 RVA: 0x00029128 File Offset: 0x00027328
		private void FilterEmptyBranches(ref List<InventoryFolderViewModel> folders)
		{
			int depth2 = folders.Max((InventoryFolderViewModel x) => x.Depth);
			List<InventoryFolderViewModel> list = new List<InventoryFolderViewModel>();
			int depth;
			for (depth = depth2; depth > 0; depth--)
			{
				foreach (InventoryFolderViewModel inventoryFolderViewModel in from x in folders
				where x.Depth == depth
				select x)
				{
					if (inventoryFolderViewModel.ChildEntries == 0 && inventoryFolderViewModel.ChildFolders == 0)
					{
						list.Add(inventoryFolderViewModel);
						inventoryFolderViewModel.Parent.ChildFolders--;
					}
				}
			}
			foreach (InventoryFolderViewModel item in list)
			{
				folders.Remove(item);
			}
		}

		// Token: 0x060013B4 RID: 5044 RVA: 0x0002926C File Offset: 0x0002746C
		private void FilterEmptyRoot(ref List<InventoryFolderViewModel> folders)
		{
			int num = folders.Max((InventoryFolderViewModel x) => x.Depth);
			List<InventoryFolderViewModel> list = new List<InventoryFolderViewModel>();
			int num2 = -1;
			int depth;
			for (depth = 0; depth <= num; depth++)
			{
				IEnumerable<InventoryFolderViewModel> enumerable = from x in folders
				where x.Depth == depth
				select x;
				foreach (InventoryFolderViewModel inventoryFolderViewModel in enumerable)
				{
					if (inventoryFolderViewModel.Depth != num2 + 1)
					{
						break;
					}
					if (inventoryFolderViewModel.ChildEntries == 0 && (inventoryFolderViewModel.ChildFolders == 1 || string.IsNullOrEmpty(inventoryFolderViewModel.Text) || enumerable.Count<InventoryFolderViewModel>() == 1))
					{
						list.Add(inventoryFolderViewModel);
						num2 = inventoryFolderViewModel.Depth;
					}
				}
				if (depth == num2 + 1)
				{
					break;
				}
			}
			foreach (InventoryFolderViewModel item in list)
			{
				folders.Remove(item);
			}
			if (list.Count > 0)
			{
				foreach (InventoryFolderViewModel inventoryFolderViewModel2 in folders)
				{
					inventoryFolderViewModel2.Depth -= num2 + 1;
				}
			}
		}

		// Token: 0x17000252 RID: 594
		// (get) Token: 0x060013B5 RID: 5045 RVA: 0x00029418 File Offset: 0x00027618
		// (set) Token: 0x060013B6 RID: 5046 RVA: 0x00029420 File Offset: 0x00027620
		public Inventory.Entry Root
		{
			get
			{
				return this._root;
			}
			set
			{
				this._root = value;
				if (this._filterFunc == null)
				{
					this.FilterInventory();
				}
			}
		}

		// Token: 0x17000253 RID: 595
		// (get) Token: 0x060013B7 RID: 5047 RVA: 0x00029437 File Offset: 0x00027637
		// (set) Token: 0x060013B8 RID: 5048 RVA: 0x0002943F File Offset: 0x0002763F
		public bool HasSelectedItem
		{
			get
			{
				return this._hasSelectedItem;
			}
			private set
			{
				this._hasSelectedItem = value;
				base.RaisePropertyChanged("HasSelectedItem");
			}
		}

		// Token: 0x17000254 RID: 596
		// (get) Token: 0x060013B9 RID: 5049 RVA: 0x00029453 File Offset: 0x00027653
		// (set) Token: 0x060013BA RID: 5050 RVA: 0x0002945B File Offset: 0x0002765B
		public string DisplayName
		{
			get
			{
				return this._displayName;
			}
			set
			{
				this._displayName = value;
				base.RaisePropertyChanged("DisplayName");
			}
		}

		// Token: 0x17000255 RID: 597
		// (get) Token: 0x060013BB RID: 5051 RVA: 0x0002946F File Offset: 0x0002766F
		// (set) Token: 0x060013BC RID: 5052 RVA: 0x00029477 File Offset: 0x00027677
		public InventoryFolderViewModel SelectedFolder
		{
			get
			{
				return this._selectedFolder;
			}
			set
			{
				this._selectedFolder = value;
				base.RaisePropertyChanged("SelectedFolder");
				this.Items = ((value == null) ? null : this.SelectedFolder.Children);
			}
		}

		// Token: 0x17000256 RID: 598
		// (get) Token: 0x060013BD RID: 5053 RVA: 0x000294A2 File Offset: 0x000276A2
		// (set) Token: 0x060013BE RID: 5054 RVA: 0x000294BF File Offset: 0x000276BF
		public int SelectedFolderIndex
		{
			get
			{
				if (this.Folders == null)
				{
					return -1;
				}
				return this.Folders.IndexOf(this.SelectedFolder);
			}
			set
			{
				if (value < 0 || value >= this.Folders.Count)
				{
					this.SelectDefaultFolder();
					return;
				}
				this.SelectedFolder = this.Folders[value];
			}
		}

		// Token: 0x17000257 RID: 599
		// (get) Token: 0x060013BF RID: 5055 RVA: 0x000294EC File Offset: 0x000276EC
		// (set) Token: 0x060013C0 RID: 5056 RVA: 0x0002951C File Offset: 0x0002771C
		public ObservableCollection<InventoryEntryViewModel> Items
		{
			get
			{
				return this._items;
			}
			private set
			{
				this._items = null;
				if (value != null)
				{
					List<InventoryEntryViewModel> list = value.ToList<InventoryEntryViewModel>();
					list.Sort((InventoryEntryViewModel lhs, InventoryEntryViewModel rhs) => lhs.Text.CompareTo(rhs.Text));
					if (this.ShowFolders)
					{
						ObservableCollection<InventoryEntryViewModel> items;
						if (this._filterFunc != null)
						{
							items = new ObservableCollection<InventoryEntryViewModel>(from x in list
							where this._filterFunc(x.Model)
							select x);
						}
						else
						{
							items = value;
						}
						this._items = items;
					}
					else
					{
						this._items = new ObservableCollection<InventoryEntryViewModel>(list);
					}
				}
				base.RaisePropertyChanged("Items");
			}
		}

		// Token: 0x17000258 RID: 600
		// (get) Token: 0x060013C1 RID: 5057 RVA: 0x000295AD File Offset: 0x000277AD
		// (set) Token: 0x060013C2 RID: 5058 RVA: 0x000295B5 File Offset: 0x000277B5
		public ObservableCollection<InventoryFolderViewModel> Folders
		{
			get
			{
				return this._folders;
			}
			private set
			{
				this._folders = value;
				base.RaisePropertyChanged("Folders");
			}
		}

		// Token: 0x17000259 RID: 601
		// (get) Token: 0x060013C3 RID: 5059 RVA: 0x000295C9 File Offset: 0x000277C9
		// (set) Token: 0x060013C4 RID: 5060 RVA: 0x00029600 File Offset: 0x00027800
		public Inventory.Entry Value
		{
			get
			{
				if (this.SelectedItem != null)
				{
					return this.SelectedItem.Model;
				}
				return null;
			}
			set
			{
				if (value == null)
				{
					this.SelectedItem = null;
					return;
				}
				if (!value.IsDirectory && (this.SelectedFolder == null || this.SelectedFolder.Model != value.Parent))
				{
					this.SelectedFolder = this.Folders.FirstOrDefault((InventoryFolderViewModel x) => x.Model == value.Parent);
				}
				if (this.Items == null)
				{
					return;
				}
				foreach (InventoryEntryViewModel inventoryEntryViewModel in this.Items)
				{
					if (!(inventoryEntryViewModel.Model != value))
					{
						this.SelectedItem = inventoryEntryViewModel;
						break;
					}
				}
			}
		}

		// Token: 0x1700025A RID: 602
		// (get) Token: 0x060013C5 RID: 5061 RVA: 0x000296E4 File Offset: 0x000278E4
		// (set) Token: 0x060013C6 RID: 5062 RVA: 0x000296EC File Offset: 0x000278EC
		public InventoryEntryViewModel SelectedItem
		{
			get
			{
				return this._selectedItem;
			}
			set
			{
				this._selectedItem = value;
				base.RaisePropertyChanged("SelectedItem");
				this.HasSelectedItem = (this._selectedItem != null && !this._selectedItem.Model.IsDirectory);
				this.RaiseValueChanged();
			}
		}

		// Token: 0x060013C7 RID: 5063 RVA: 0x0002972A File Offset: 0x0002792A
		private void ParentFolder()
		{
			this.SelectedFolder = this.SelectedFolder.Parent;
		}

		// Token: 0x060013C8 RID: 5064 RVA: 0x0002973D File Offset: 0x0002793D
		private bool FolderHasParent()
		{
			return this.SelectedFolder != null && this.SelectedFolder.Parent != null && this.SelectedFolder.Depth != 0;
		}

		// Token: 0x1700025B RID: 603
		// (get) Token: 0x060013C9 RID: 5065 RVA: 0x00029767 File Offset: 0x00027967
		// (set) Token: 0x060013CA RID: 5066 RVA: 0x0002976F File Offset: 0x0002796F
		public ICommand CommandItemDoubleClick { get; set; }

		// Token: 0x1700025C RID: 604
		// (get) Token: 0x060013CB RID: 5067 RVA: 0x00029778 File Offset: 0x00027978
		// (set) Token: 0x060013CC RID: 5068 RVA: 0x00029780 File Offset: 0x00027980
		public ICommand CommandParent { get; private set; }

		// Token: 0x1400000A RID: 10
		// (add) Token: 0x060013CD RID: 5069 RVA: 0x0002978C File Offset: 0x0002798C
		// (remove) Token: 0x060013CE RID: 5070 RVA: 0x000297C4 File Offset: 0x000279C4
		public event EventHandler ValueChanged;

		// Token: 0x060013CF RID: 5071 RVA: 0x000297FC File Offset: 0x000279FC
		private void RaiseValueChanged()
		{
			EventHandler valueChanged = this.ValueChanged;
			if (valueChanged != null)
			{
				valueChanged(this, EventArgs.Empty);
			}
		}

		// Token: 0x060013D0 RID: 5072 RVA: 0x00029820 File Offset: 0x00027A20
		private void FilterInventoryItems(ObservableCollection<InventoryFolderViewModel> folders)
		{
			foreach (InventoryFolderViewModel inventoryFolderViewModel in folders)
			{
				foreach (InventoryEntryViewModel inventoryEntryViewModel in inventoryFolderViewModel.Children)
				{
					if (this._filterFunc == null || this._filterFunc(inventoryEntryViewModel.Model))
					{
						this._allItems.Add(inventoryEntryViewModel);
					}
				}
			}
		}

		// Token: 0x060013D1 RID: 5073 RVA: 0x000298C0 File Offset: 0x00027AC0
		public void SelectDefaultFolder()
		{
			foreach (InventoryFolderViewModel inventoryFolderViewModel in this.Folders)
			{
				foreach (InventoryEntryViewModel inventoryEntryViewModel in inventoryFolderViewModel.Children)
				{
					if (!inventoryEntryViewModel.Model.IsDirectory)
					{
						this.SelectedFolder = inventoryFolderViewModel;
						return;
					}
				}
			}
			this.SelectedFolder = null;
		}

		// Token: 0x060013D2 RID: 5074 RVA: 0x00029958 File Offset: 0x00027B58
		public void SelectFolderByName(string folderName)
		{
			foreach (InventoryFolderViewModel inventoryFolderViewModel in this.Folders)
			{
				if (inventoryFolderViewModel.Model.DisplayName == folderName)
				{
					this.SelectedFolder = inventoryFolderViewModel;
					break;
				}
			}
		}

		// Token: 0x060013D3 RID: 5075 RVA: 0x000299BC File Offset: 0x00027BBC
		private void FillCategories(Inventory.Entry entry, int depth, ref List<InventoryFolderViewModel> inventory, InventoryFolderViewModel parent = null)
		{
			if (!entry.IsDirectory)
			{
				return;
			}
			if (entry.Deleted)
			{
				return;
			}
			InventoryFolderViewModel inventoryFolderViewModel = new InventoryFolderViewModel(entry, depth, parent, this._filterFunc);
			inventory.Add(inventoryFolderViewModel);
			int num = 0;
			int num2 = 0;
			foreach (Inventory.Entry entry2 in entry.Children)
			{
				if (entry2.IsDirectory)
				{
					this.FillCategories(entry2, depth + 1, ref inventory, inventoryFolderViewModel);
					num2++;
				}
				else if (this._filterFunc == null || this._filterFunc(entry2))
				{
					num++;
				}
			}
			inventoryFolderViewModel.ChildEntries = num;
			inventoryFolderViewModel.ChildFolders = num2;
		}

		// Token: 0x060013D4 RID: 5076 RVA: 0x00029A5C File Offset: 0x00027C5C
		internal void SetFlatListMode(bool flag)
		{
			if (this._flatListMode != flag)
			{
				this._flatListMode = flag;
				if (flag)
				{
					this.Items = this._allItems;
					return;
				}
				if (this.ShowFolders)
				{
					this.Items = ((this.SelectedFolder == null) ? null : this.SelectedFolder.Children);
					return;
				}
				this.Items = this._allItems;
			}
		}

		// Token: 0x060013D5 RID: 5077 RVA: 0x00029ABC File Offset: 0x00027CBC
		internal void FilterInventoryByName(string _searchObjInv)
		{
			if (string.IsNullOrEmpty(_searchObjInv))
			{
				if (this._currentTask.Status == TaskStatus.Running)
				{
					this._cancelationTokenSource.Cancel();
					this._currentTask.Wait();
				}
				this.Items = this._allItems;
				return;
			}
			if (this._currentTask == null || this._currentTask.IsCompleted || this._currentTask.IsCanceled)
			{
				this.RunFilterTask(_searchObjInv);
				return;
			}
			this._cancelationTokenSource.Cancel();
			try
			{
				this._currentTask.Wait();
			}
			catch (AggregateException)
			{
				this._cancelationTokenSource.Dispose();
				this._cancelationTokenSource = new CancellationTokenSource();
			}
			catch (OperationCanceledException)
			{
				this._cancelationTokenSource.Dispose();
				this._cancelationTokenSource = new CancellationTokenSource();
			}
			this.RunFilterTask(_searchObjInv);
		}

		// Token: 0x060013D6 RID: 5078 RVA: 0x00029C48 File Offset: 0x00027E48
		private void RunFilterTask(string _searchObjInv)
		{
			this._currentTask = Task.Factory.StartNew<ObservableCollection<InventoryEntryViewModel>>(delegate(object tokenObj)
			{
				CancellationToken cancellationToken = (CancellationToken)tokenObj;
				cancellationToken.ThrowIfCancellationRequested();
				ObservableCollection<InventoryEntryViewModel> observableCollection = new ObservableCollection<InventoryEntryViewModel>();
				foreach (InventoryEntryViewModel inventoryEntryViewModel in this._allItems)
				{
					if (cancellationToken.IsCancellationRequested)
					{
						cancellationToken.ThrowIfCancellationRequested();
					}
					if (inventoryEntryViewModel.Text.Contains(_searchObjInv, StringComparison.OrdinalIgnoreCase))
					{
						observableCollection.Add(inventoryEntryViewModel);
					}
				}
				return observableCollection;
			}, this._cancelationTokenSource.Token);
			this._currentTask.ContinueWith(delegate(Task<ObservableCollection<InventoryEntryViewModel>> filterItems)
			{
				if (filterItems.Status == TaskStatus.RanToCompletion)
				{
					this.Items = filterItems.Result;
				}
			}, TaskScheduler.FromCurrentSynchronizationContext());
		}

		// Token: 0x0400073F RID: 1855
		private bool _showFolders = true;

		// Token: 0x04000740 RID: 1856
		private Func<Inventory.Entry, bool> _filterFunc;

		// Token: 0x04000741 RID: 1857
		private Inventory.Entry _root;

		// Token: 0x04000742 RID: 1858
		private bool _hasSelectedItem;

		// Token: 0x04000743 RID: 1859
		private string _displayName;

		// Token: 0x04000744 RID: 1860
		private InventoryFolderViewModel _selectedFolder;

		// Token: 0x04000745 RID: 1861
		private ObservableCollection<InventoryEntryViewModel> _allItems;

		// Token: 0x04000746 RID: 1862
		private ObservableCollection<InventoryEntryViewModel> _items;

		// Token: 0x04000747 RID: 1863
		private ObservableCollection<InventoryFolderViewModel> _folders;

		// Token: 0x04000748 RID: 1864
		private InventoryEntryViewModel _selectedItem;

		// Token: 0x0400074A RID: 1866
		private bool _flatListMode;

		// Token: 0x0400074B RID: 1867
		private Task<ObservableCollection<InventoryEntryViewModel>> _currentTask;

		// Token: 0x0400074C RID: 1868
		private CancellationTokenSource _cancelationTokenSource = new CancellationTokenSource();
	}
}
