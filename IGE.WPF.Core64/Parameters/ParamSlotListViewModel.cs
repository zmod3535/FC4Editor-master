using System;
using System.Collections.ObjectModel;
using System.Windows;
using IGE.Nomad;
using IGE.Views;
using Ubisoft.ApplicationModel.ContextCommands;

namespace IGE.Parameters
{
	// Token: 0x02000382 RID: 898
	internal class ParamSlotListViewModel : SingleParameter
	{
		// Token: 0x06001413 RID: 5139 RVA: 0x0002A778 File Offset: 0x00028978
		public ParamSlotListViewModel(string display, Inventory.Entry root, int slotCount, bool keepFirst = false, bool enableChange = false, bool showFolders = true) : base(display)
		{
			this.SlotCount = slotCount;
			this.KeepFirst = keepFirst;
			this.ChangeVisible = (enableChange ? Visibility.Visible : Visibility.Hidden);
			this.ShowFolders = showFolders;
			this._root = root;
			SimpleCommand simpleCommand = new SimpleCommand();
			simpleCommand.ExecuteDelegate = delegate(object o)
			{
				this.RaiseAdd();
			};
			simpleCommand.CanExecuteDelegate = ((object o) => this.Items.Count < this.SlotCount);
			this.CommandAdd = simpleCommand;
			SimpleCommand simpleCommand2 = new SimpleCommand();
			simpleCommand2.ExecuteDelegate = delegate(object o)
			{
				this.RaiseChange();
			};
			simpleCommand2.CanExecuteDelegate = ((object o) => this.CanChangeSelectedItem());
			this.CommandChange = simpleCommand2;
			SimpleCommand simpleCommand3 = new SimpleCommand();
			simpleCommand3.ExecuteDelegate = delegate(object o)
			{
				this.RaiseRemove();
			};
			simpleCommand3.CanExecuteDelegate = ((object o) => this.CanRemoveSelectedItem());
			this.CommandRemove = simpleCommand3;
			this.AddBtnLabel = Localizer.Localize("PARAM_ADD", null);
			this.ChangeBtnLabel = Localizer.LocalizeCommon("PARAM_CHANGE");
			this.RemoveBtnLabel = Localizer.Localize("PARAM_REMOVE", null);
		}

		// Token: 0x17000267 RID: 615
		// (get) Token: 0x06001414 RID: 5140 RVA: 0x0002A8C6 File Offset: 0x00028AC6
		// (set) Token: 0x06001415 RID: 5141 RVA: 0x0002A8CE File Offset: 0x00028ACE
		public SimpleCommand CommandAdd { get; set; }

		// Token: 0x17000268 RID: 616
		// (get) Token: 0x06001416 RID: 5142 RVA: 0x0002A8D7 File Offset: 0x00028AD7
		// (set) Token: 0x06001417 RID: 5143 RVA: 0x0002A8DF File Offset: 0x00028ADF
		public SimpleCommand CommandChange { get; set; }

		// Token: 0x17000269 RID: 617
		// (get) Token: 0x06001418 RID: 5144 RVA: 0x0002A8E8 File Offset: 0x00028AE8
		// (set) Token: 0x06001419 RID: 5145 RVA: 0x0002A8F0 File Offset: 0x00028AF0
		public SimpleCommand CommandRemove { get; set; }

		// Token: 0x1700026A RID: 618
		// (get) Token: 0x0600141A RID: 5146 RVA: 0x0002A8F9 File Offset: 0x00028AF9
		// (set) Token: 0x0600141B RID: 5147 RVA: 0x0002A901 File Offset: 0x00028B01
		public string AddBtnLabel { get; private set; }

		// Token: 0x1700026B RID: 619
		// (get) Token: 0x0600141C RID: 5148 RVA: 0x0002A90A File Offset: 0x00028B0A
		// (set) Token: 0x0600141D RID: 5149 RVA: 0x0002A912 File Offset: 0x00028B12
		public string ChangeBtnLabel { get; private set; }

		// Token: 0x1700026C RID: 620
		// (get) Token: 0x0600141E RID: 5150 RVA: 0x0002A91B File Offset: 0x00028B1B
		// (set) Token: 0x0600141F RID: 5151 RVA: 0x0002A923 File Offset: 0x00028B23
		public string RemoveBtnLabel { get; private set; }

		// Token: 0x06001420 RID: 5152 RVA: 0x0002A92C File Offset: 0x00028B2C
		private bool CanRemoveSelectedItem()
		{
			return this.SelectedItem != null && (!this.KeepFirst || this.SelectedItem != this.Items[0]);
		}

		// Token: 0x06001421 RID: 5153 RVA: 0x0002A959 File Offset: 0x00028B59
		private bool CanChangeSelectedItem()
		{
			return this.SelectedItem != null;
		}

		// Token: 0x1400000B RID: 11
		// (add) Token: 0x06001422 RID: 5154 RVA: 0x0002A968 File Offset: 0x00028B68
		// (remove) Token: 0x06001423 RID: 5155 RVA: 0x0002A9A0 File Offset: 0x00028BA0
		public event EventHandler SlotChanged;

		// Token: 0x06001424 RID: 5156 RVA: 0x0002A9D8 File Offset: 0x00028BD8
		private void RaiseEntryAdded(Inventory.Entry newEntry)
		{
			EventHandler slotChanged = this.SlotChanged;
			if (slotChanged != null)
			{
				int id = this.FindFreeSlot();
				slotChanged(this, new ParamSlotListViewModel.EntryChangeEventArgs
				{
					Entry = newEntry,
					Id = id
				});
			}
		}

		// Token: 0x06001425 RID: 5157 RVA: 0x0002AA14 File Offset: 0x00028C14
		private void RaiseEntryChanged(Inventory.Entry newEntry)
		{
			EventHandler slotChanged = this.SlotChanged;
			if (slotChanged != null && this.SelectedItem != null)
			{
				int value = this.SelectedItem.Value;
				slotChanged(this, new ParamSlotListViewModel.EntryChangeEventArgs
				{
					Entry = newEntry,
					Id = value
				});
			}
		}

		// Token: 0x06001426 RID: 5158 RVA: 0x0002AA5C File Offset: 0x00028C5C
		private void RaiseEntryRemoved()
		{
			EventHandler slotChanged = this.SlotChanged;
			if (slotChanged != null)
			{
				slotChanged(this, new ParamSlotListViewModel.EntryChangeEventArgs
				{
					Entry = null,
					Id = this.SelectedItem.Value
				});
			}
		}

		// Token: 0x06001427 RID: 5159 RVA: 0x0002AA9C File Offset: 0x00028C9C
		private int FindFreeSlot()
		{
			for (int i = 0; i < this.SlotCount; i++)
			{
				if (this.GetSlot(i) == null)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06001428 RID: 5160 RVA: 0x0002AAC8 File Offset: 0x00028CC8
		private void RaiseAdd()
		{
			PromptInventoryListView promptInventoryListView = new PromptInventoryListView(this._root, this.ShowFolders, this._lastSelectedFolder)
			{
				Owner = Program.MainWin
			};
			if (promptInventoryListView.ShowDialog() == true)
			{
				this.RaiseEntryAdded(promptInventoryListView.Result);
				this._lastSelectedFolder = promptInventoryListView.SelectedFolder;
			}
		}

		// Token: 0x06001429 RID: 5161 RVA: 0x0002AB30 File Offset: 0x00028D30
		private void RaiseChange()
		{
			PromptInventoryListView promptInventoryListView = new PromptInventoryListView(this._root, this.ShowFolders, this._lastSelectedFolder)
			{
				Owner = Program.MainWin
			};
			if (promptInventoryListView.ShowDialog() == true)
			{
				this.RaiseEntryChanged(promptInventoryListView.Result);
				this._lastSelectedFolder = promptInventoryListView.SelectedFolder;
			}
		}

		// Token: 0x0600142A RID: 5162 RVA: 0x0002AB96 File Offset: 0x00028D96
		private void RaiseRemove()
		{
			this.RaiseEntryRemoved();
		}

		// Token: 0x1400000C RID: 12
		// (add) Token: 0x0600142B RID: 5163 RVA: 0x0002ABA0 File Offset: 0x00028DA0
		// (remove) Token: 0x0600142C RID: 5164 RVA: 0x0002ABD8 File Offset: 0x00028DD8
		public event EventHandler ValueChanged;

		// Token: 0x0600142D RID: 5165 RVA: 0x0002AC10 File Offset: 0x00028E10
		private void RaiseValueChanged()
		{
			EventHandler valueChanged = this.ValueChanged;
			if (valueChanged != null)
			{
				valueChanged(this, EventArgs.Empty);
			}
		}

		// Token: 0x1700026D RID: 621
		// (get) Token: 0x0600142E RID: 5166 RVA: 0x0002AC33 File Offset: 0x00028E33
		public string SlotCountText
		{
			get
			{
				return this.Items.Count + "/" + this.SlotCount;
			}
		}

		// Token: 0x1700026E RID: 622
		// (get) Token: 0x0600142F RID: 5167 RVA: 0x0002AC5A File Offset: 0x00028E5A
		// (set) Token: 0x06001430 RID: 5168 RVA: 0x0002AC62 File Offset: 0x00028E62
		public int SlotCount { get; private set; }

		// Token: 0x1700026F RID: 623
		// (get) Token: 0x06001431 RID: 5169 RVA: 0x0002AC6B File Offset: 0x00028E6B
		// (set) Token: 0x06001432 RID: 5170 RVA: 0x0002AC73 File Offset: 0x00028E73
		public bool KeepFirst { get; private set; }

		// Token: 0x17000270 RID: 624
		// (get) Token: 0x06001433 RID: 5171 RVA: 0x0002AC7C File Offset: 0x00028E7C
		// (set) Token: 0x06001434 RID: 5172 RVA: 0x0002AC84 File Offset: 0x00028E84
		public Visibility ChangeVisible { get; private set; }

		// Token: 0x17000271 RID: 625
		// (get) Token: 0x06001435 RID: 5173 RVA: 0x0002AC8D File Offset: 0x00028E8D
		// (set) Token: 0x06001436 RID: 5174 RVA: 0x0002AC95 File Offset: 0x00028E95
		public bool ShowFolders { get; private set; }

		// Token: 0x17000272 RID: 626
		// (get) Token: 0x06001437 RID: 5175 RVA: 0x0002AC9E File Offset: 0x00028E9E
		public int Value
		{
			get
			{
				if (this.SelectedItem != null)
				{
					return this.SelectedItem.Value;
				}
				return -1;
			}
		}

		// Token: 0x17000273 RID: 627
		// (get) Token: 0x06001438 RID: 5176 RVA: 0x0002ACB5 File Offset: 0x00028EB5
		// (set) Token: 0x06001439 RID: 5177 RVA: 0x0002ACBD File Offset: 0x00028EBD
		public ParamSlotItemViewModel SelectedItem
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
				this.RaiseValueChanged();
			}
		}

		// Token: 0x0600143A RID: 5178 RVA: 0x0002ACE4 File Offset: 0x00028EE4
		private ParamSlotItemViewModel GetSlot(int i)
		{
			foreach (ParamSlotItemViewModel paramSlotItemViewModel in this.Items)
			{
				if (paramSlotItemViewModel.Value == i)
				{
					return paramSlotItemViewModel;
				}
			}
			return null;
		}

		// Token: 0x17000274 RID: 628
		// (get) Token: 0x0600143B RID: 5179 RVA: 0x0002AD3C File Offset: 0x00028F3C
		// (set) Token: 0x0600143C RID: 5180 RVA: 0x0002AD44 File Offset: 0x00028F44
		public ObservableCollection<ParamSlotItemViewModel> Items
		{
			get
			{
				return this._items;
			}
			set
			{
				this._items = value;
				base.RaisePropertyChanged("Items");
				base.RaisePropertyChanged("SlotCountText");
			}
		}

		// Token: 0x04000763 RID: 1891
		private readonly Inventory.Entry _root;

		// Token: 0x04000765 RID: 1893
		private string _lastSelectedFolder = string.Empty;

		// Token: 0x04000767 RID: 1895
		private ParamSlotItemViewModel _selectedItem;

		// Token: 0x04000768 RID: 1896
		private ObservableCollection<ParamSlotItemViewModel> _items;

		// Token: 0x02000383 RID: 899
		public class EntryChangeEventArgs : EventArgs
		{
			// Token: 0x04000773 RID: 1907
			public Inventory.Entry Entry;

			// Token: 0x04000774 RID: 1908
			public int Id;
		}
	}
}
