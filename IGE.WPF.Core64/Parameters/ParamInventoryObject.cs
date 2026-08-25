using System;
using System.Windows;
using IGE.Nomad;

namespace IGE.Parameters
{
	// Token: 0x02000101 RID: 257
	internal class ParamInventoryObject : SingleParameter
	{
		// Token: 0x06000903 RID: 2307 RVA: 0x0001E17C File Offset: 0x0001C37C
		public ParamInventoryObject(string display, Func<Inventory.Entry, bool> filterFunc = null, bool showFolders = false) : base(display)
		{
			this.ObjectSelector = new ObjectSelectorViewModel(filterFunc, showFolders)
			{
				Root = ObjectInventory.Instance.Root,
				DisplayName = display
			};
			this.ObjectSelector.ValueChanged += delegate(object o, EventArgs a)
			{
				this.RaiseValueChanged();
			};
			this.UnsupportedAIVisibility = Visibility.Collapsed;
			this.EntitySizeVisibility = Visibility.Visible;
		}

		// Token: 0x17000208 RID: 520
		// (get) Token: 0x06000904 RID: 2308 RVA: 0x0001E1E2 File Offset: 0x0001C3E2
		// (set) Token: 0x06000905 RID: 2309 RVA: 0x0001E1EF File Offset: 0x0001C3EF
		public Func<Inventory.Entry, bool> Filter
		{
			get
			{
				return this.ObjectSelector.Filter;
			}
			set
			{
				this.ObjectSelector.Filter = value;
			}
		}

		// Token: 0x14000009 RID: 9
		// (add) Token: 0x06000906 RID: 2310 RVA: 0x0001E200 File Offset: 0x0001C400
		// (remove) Token: 0x06000907 RID: 2311 RVA: 0x0001E238 File Offset: 0x0001C438
		public event EventHandler ValueChanged;

		// Token: 0x06000908 RID: 2312 RVA: 0x0001E270 File Offset: 0x0001C470
		private void RaiseValueChanged()
		{
			EventHandler valueChanged = this.ValueChanged;
			if (valueChanged != null)
			{
				valueChanged(this, EventArgs.Empty);
			}
			if (this.UnsupportedAIVisibility == Visibility.Visible)
			{
				this.UpdateUnsupportedAI();
			}
		}

		// Token: 0x17000209 RID: 521
		// (get) Token: 0x06000909 RID: 2313 RVA: 0x0001E2A1 File Offset: 0x0001C4A1
		// (set) Token: 0x0600090A RID: 2314 RVA: 0x0001E2B3 File Offset: 0x0001C4B3
		public ObjectInventory.Entry Value
		{
			get
			{
				return (ObjectInventory.Entry)this.ObjectSelector.Value;
			}
			set
			{
				this.ObjectSelector.Value = value;
			}
		}

		// Token: 0x1700020A RID: 522
		// (get) Token: 0x0600090B RID: 2315 RVA: 0x0001E2C1 File Offset: 0x0001C4C1
		public InventoryEntryViewModel SelectedItem
		{
			get
			{
				return this.ObjectSelector.SelectedItem;
			}
		}

		// Token: 0x1700020B RID: 523
		// (get) Token: 0x0600090C RID: 2316 RVA: 0x0001E2CE File Offset: 0x0001C4CE
		// (set) Token: 0x0600090D RID: 2317 RVA: 0x0001E2D6 File Offset: 0x0001C4D6
		public Visibility UnsupportedAIVisibility
		{
			get
			{
				return this._unsupportedAIVisibility;
			}
			set
			{
				if (this._unsupportedAIVisibility == value)
				{
					return;
				}
				this._unsupportedAIVisibility = value;
				base.RaisePropertyChanged("UnsupportedAIVisibility");
			}
		}

		// Token: 0x1700020C RID: 524
		// (get) Token: 0x0600090E RID: 2318 RVA: 0x0001E2F4 File Offset: 0x0001C4F4
		// (set) Token: 0x0600090F RID: 2319 RVA: 0x0001E2FC File Offset: 0x0001C4FC
		public Visibility EntitySizeVisibility
		{
			get
			{
				return this._entitySizeVisibility;
			}
			set
			{
				if (this._entitySizeVisibility == value)
				{
					return;
				}
				this._entitySizeVisibility = value;
				base.RaisePropertyChanged("EntitySizeVisibility");
			}
		}

		// Token: 0x1700020D RID: 525
		// (get) Token: 0x06000910 RID: 2320 RVA: 0x0001E31A File Offset: 0x0001C51A
		// (set) Token: 0x06000911 RID: 2321 RVA: 0x0001E322 File Offset: 0x0001C522
		public string UnsupportedAI
		{
			get
			{
				return this._unsupportedAI;
			}
			private set
			{
				this._unsupportedAI = value;
				base.RaisePropertyChanged("UnsupportedAI");
			}
		}

		// Token: 0x1700020E RID: 526
		// (get) Token: 0x06000912 RID: 2322 RVA: 0x0001E336 File Offset: 0x0001C536
		// (set) Token: 0x06000913 RID: 2323 RVA: 0x0001E33E File Offset: 0x0001C53E
		public string SearchObjInv
		{
			get
			{
				return this._searchObjInv;
			}
			set
			{
				this._searchObjInv = value;
				this.ObjectSelector.SelectedFolder = null;
				this.ObjectSelector.SetFlatListMode(!string.IsNullOrEmpty(this._searchObjInv));
				this.ObjectSelector.FilterInventoryByName(this._searchObjInv);
			}
		}

		// Token: 0x1700020F RID: 527
		// (get) Token: 0x06000914 RID: 2324 RVA: 0x0001E37D File Offset: 0x0001C57D
		// (set) Token: 0x06000915 RID: 2325 RVA: 0x0001E385 File Offset: 0x0001C585
		public ObjectSelectorViewModel ObjectSelector { get; private set; }

		// Token: 0x06000916 RID: 2326 RVA: 0x0001E390 File Offset: 0x0001C590
		public void UpdateFilter()
		{
			ulong currentObjectiveType = GameModeManager.GetCurrentObjectiveType();
			if (currentObjectiveType != this._objectiveId)
			{
				this._objectiveId = currentObjectiveType;
			}
			if (this._objectiveId != 0UL)
			{
				this.ObjectSelector.FilterInventory();
			}
		}

		// Token: 0x06000917 RID: 2327 RVA: 0x0001E3C8 File Offset: 0x0001C5C8
		public void SelectFolderByName(string folderName)
		{
			this.ObjectSelector.SelectFolderByName(folderName);
		}

		// Token: 0x06000918 RID: 2328 RVA: 0x0001E3D6 File Offset: 0x0001C5D6
		public void SelectDefaultFolder()
		{
			this.ObjectSelector.SelectDefaultFolder();
		}

		// Token: 0x06000919 RID: 2329 RVA: 0x0001E3E4 File Offset: 0x0001C5E4
		public void UpdateUnsupportedAI()
		{
			ObjectInventory.Entry entry = this.ObjectSelector.Value as ObjectInventory.Entry;
			if (!(entry != null) || entry.IsDirectory)
			{
				this.UnsupportedAI = string.Empty;
				return;
			}
			bool flag = !Binding.FCE_Inventory_Object_IsObjectType(entry.Pointer, 8192);
			bool flag2 = !Binding.FCE_Inventory_Object_IsObjectType(entry.Pointer, 16384);
			if (flag && flag2)
			{
				this.UnsupportedAI = Localizer.LocalizeCommon("AI_ARCHETYPE_HUNTER_HEAVY");
				return;
			}
			if (flag)
			{
				this.UnsupportedAI = Localizer.LocalizeCommon("AI_ARCHETYPE_HEAVY");
				return;
			}
			if (flag2)
			{
				this.UnsupportedAI = Localizer.LocalizeCommon("AI_ARCHETYPE_HUNTER");
				return;
			}
			this.UnsupportedAI = string.Empty;
		}

		// Token: 0x0400045F RID: 1119
		private Visibility _unsupportedAIVisibility;

		// Token: 0x04000460 RID: 1120
		private Visibility _entitySizeVisibility;

		// Token: 0x04000461 RID: 1121
		public string _unsupportedAI;

		// Token: 0x04000462 RID: 1122
		public string _searchObjInv;

		// Token: 0x04000463 RID: 1123
		private ulong _objectiveId;

		// Token: 0x02000102 RID: 258
		[Flags]
		private enum StpUsage
		{
			// Token: 0x04000466 RID: 1126
			eUsage_Generic = 1,
			// Token: 0x04000467 RID: 1127
			eUsage_Molotov = 2,
			// Token: 0x04000468 RID: 1128
			eUsage_Heavy = 4,
			// Token: 0x04000469 RID: 1129
			eUsage_Beheader = 8,
			// Token: 0x0400046A RID: 1130
			eUsage_Sniper = 16,
			// Token: 0x0400046B RID: 1131
			eUsage_Hunter = 32,
			// Token: 0x0400046C RID: 1132
			eUsage_Civilian = 64
		}
	}
}
