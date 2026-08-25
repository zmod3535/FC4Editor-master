using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using IGE.Nomad;
using Ubisoft.AttachedCommandBehavior;

namespace IGE.Parameters
{
	// Token: 0x020000DC RID: 220
	internal class ParamObjectSelection : SingleParameter
	{
		// Token: 0x060007FC RID: 2044 RVA: 0x0001BB97 File Offset: 0x00019D97
		public ParamObjectSelection(string display) : base(display)
		{
			this.OnDoubleClick = new SimpleCommand();
		}

		// Token: 0x170001CE RID: 462
		// (set) Token: 0x060007FD RID: 2045 RVA: 0x0001BBAC File Offset: 0x00019DAC
		public EditorObjectSelection ObjectSelection
		{
			set
			{
				IEnumerable<EditorObject> objects = value.GetObjects();
				ObservableCollection<EditorObjectViewModel> observableCollection = new ObservableCollection<EditorObjectViewModel>();
				foreach (EditorObject model in objects)
				{
					observableCollection.Add(new EditorObjectViewModel(model)
					{
						OnDoubleClick = this.OnDoubleClick
					});
				}
				this.Items = observableCollection;
			}
		}

		// Token: 0x14000007 RID: 7
		// (add) Token: 0x060007FE RID: 2046 RVA: 0x0001BC24 File Offset: 0x00019E24
		// (remove) Token: 0x060007FF RID: 2047 RVA: 0x0001BC5C File Offset: 0x00019E5C
		public event EventHandler SelectionChanged;

		// Token: 0x06000800 RID: 2048 RVA: 0x0001BC94 File Offset: 0x00019E94
		private void RaiseSelectionChanged()
		{
			EventHandler selectionChanged = this.SelectionChanged;
			if (selectionChanged != null)
			{
				selectionChanged(this, EventArgs.Empty);
			}
		}

		// Token: 0x170001CF RID: 463
		// (get) Token: 0x06000801 RID: 2049 RVA: 0x0001BCB7 File Offset: 0x00019EB7
		// (set) Token: 0x06000802 RID: 2050 RVA: 0x0001BCBF File Offset: 0x00019EBF
		public ObservableCollection<EditorObjectViewModel> Items
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

		// Token: 0x170001D0 RID: 464
		// (get) Token: 0x06000803 RID: 2051 RVA: 0x0001BCD3 File Offset: 0x00019ED3
		// (set) Token: 0x06000804 RID: 2052 RVA: 0x0001BCDB File Offset: 0x00019EDB
		public EditorObjectViewModel SelectedObject
		{
			get
			{
				return this._selectedObject;
			}
			set
			{
				if (this._selectedObject == value)
				{
					return;
				}
				this._selectedObject = value;
				base.RaisePropertyChanged("SelectedObject");
				this.RaiseSelectionChanged();
			}
		}

		// Token: 0x170001D1 RID: 465
		// (get) Token: 0x06000805 RID: 2053 RVA: 0x0001BCFF File Offset: 0x00019EFF
		public EditorObject EditorObject
		{
			get
			{
				if (this.SelectedObject != null)
				{
					return this.SelectedObject.Model;
				}
				return null;
			}
		}

		// Token: 0x170001D2 RID: 466
		// (get) Token: 0x06000806 RID: 2054 RVA: 0x0001BD16 File Offset: 0x00019F16
		// (set) Token: 0x06000807 RID: 2055 RVA: 0x0001BD1E File Offset: 0x00019F1E
		public SimpleCommand OnDoubleClick { get; private set; }

		// Token: 0x040003EA RID: 1002
		private ObservableCollection<EditorObjectViewModel> _items;

		// Token: 0x040003EB RID: 1003
		private EditorObjectViewModel _selectedObject;
	}
}
