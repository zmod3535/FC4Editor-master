using System;
using System.Collections;

namespace TD.SandBar
{
	// Token: 0x0200000D RID: 13
	public abstract class ToolbarItemBaseCollection : CollectionBase
	{
		// Token: 0x0600010F RID: 271 RVA: 0x00005EBC File Offset: 0x00004EBC
		internal ToolbarItemBaseCollection(IToolBarItemBaseCollectionHost owner)
		{
			this.x071bde1041617fce = owner;
		}

		// Token: 0x06000110 RID: 272
		internal abstract bool x69be3d3be3df174e(ToolbarItemBase xccb63ca5f63dc470);

		// Token: 0x06000111 RID: 273 RVA: 0x00005ECC File Offset: 0x00004ECC
		protected override void OnClear()
		{
			base.OnClear();
			foreach (object obj in this)
			{
				ToolbarItemBase toolbarItemBase = (ToolbarItemBase)obj;
				this.x2c6dfd2e92209a38(toolbarItemBase, null);
				if (toolbarItemBase is ControlContainerItem)
				{
					this.x071bde1041617fce.ControlHost.Controls.Remove(((ControlContainerItem)toolbarItemBase).ContainedControl);
				}
			}
		}

		// Token: 0x06000112 RID: 274 RVA: 0x00005F5C File Offset: 0x00004F5C
		protected override void OnClearComplete()
		{
			base.OnClearComplete();
			this.x071bde1041617fce.ChildItemsChanged();
		}

		// Token: 0x06000113 RID: 275
		internal abstract void x2c6dfd2e92209a38(ToolbarItemBase xccb63ca5f63dc470, object x071bde1041617fce);

		// Token: 0x06000114 RID: 276 RVA: 0x00005F70 File Offset: 0x00004F70
		protected override void OnInsertComplete(int index, object value)
		{
			base.OnInsertComplete(index, value);
			ToolbarItemBase toolbarItemBase = (ToolbarItemBase)value;
			this.x2c6dfd2e92209a38(toolbarItemBase, this.x071bde1041617fce);
			if (toolbarItemBase is ControlContainerItem)
			{
				this.x071bde1041617fce.ControlHost.Controls.Add(((ControlContainerItem)toolbarItemBase).ContainedControl);
				toolbarItemBase.Enabled = toolbarItemBase.Enabled;
			}
			if (!this.x6278c23b2376c7c7)
			{
				this.x071bde1041617fce.ChildItemsChanged();
			}
		}

		// Token: 0x06000115 RID: 277 RVA: 0x00005FE0 File Offset: 0x00004FE0
		protected override void OnRemoveComplete(int index, object value)
		{
			base.OnRemoveComplete(index, value);
			ToolbarItemBase toolbarItemBase = (ToolbarItemBase)value;
			this.x2c6dfd2e92209a38(toolbarItemBase, null);
			if (toolbarItemBase is ControlContainerItem)
			{
				this.x071bde1041617fce.ControlHost.Controls.Remove(((ControlContainerItem)toolbarItemBase).ContainedControl);
			}
			if (!this.x6278c23b2376c7c7)
			{
				this.x071bde1041617fce.ChildItemsChanged();
			}
		}

		// Token: 0x06000116 RID: 278 RVA: 0x00006040 File Offset: 0x00005040
		public void AddRange(ToolbarItemBase[] items)
		{
			this.x6278c23b2376c7c7 = true;
			foreach (ToolbarItemBase item in items)
			{
				this.Add(item);
			}
			this.x6278c23b2376c7c7 = false;
			this.x071bde1041617fce.ChildItemsChanged();
		}

		// Token: 0x06000117 RID: 279 RVA: 0x00006084 File Offset: 0x00005084
		public int Add(ToolbarItemBase item)
		{
			int count = base.Count;
			this.Insert(count, item);
			return count;
		}

		// Token: 0x06000118 RID: 280 RVA: 0x000060A4 File Offset: 0x000050A4
		public void Insert(int index, ToolbarItemBase item)
		{
			if (!this.x69be3d3be3df174e(item))
			{
				throw new ArgumentException("This type of item is not suitable for adding to this parent.");
			}
			if (item.Owner != null)
			{
				item.Owner.Items.Remove(item);
			}
			base.List.Insert(index, item);
		}

		// Token: 0x1700005F RID: 95
		public ToolbarItemBase this[int index]
		{
			get
			{
				return (ToolbarItemBase)base.List[index];
			}
		}

		// Token: 0x0600011A RID: 282 RVA: 0x000060F4 File Offset: 0x000050F4
		public void Remove(ToolbarItemBase item)
		{
			base.List.Remove(item);
		}

		// Token: 0x0600011B RID: 283 RVA: 0x00006104 File Offset: 0x00005104
		public bool Contains(ToolbarItemBase item)
		{
			return base.List.Contains(item);
		}

		// Token: 0x0600011C RID: 284 RVA: 0x00006114 File Offset: 0x00005114
		public int IndexOf(ToolbarItemBase item)
		{
			return base.List.IndexOf(item);
		}

		// Token: 0x0600011D RID: 285 RVA: 0x00006124 File Offset: 0x00005124
		public void CopyTo(ToolbarItemBase[] array, int index)
		{
			base.List.CopyTo(array, index);
		}

		// Token: 0x04000063 RID: 99
		private IToolBarItemBaseCollectionHost x071bde1041617fce;

		// Token: 0x04000064 RID: 100
		private bool x6278c23b2376c7c7;
	}
}
