using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using TD.SandBar.Design;

namespace TD.SandBar
{
	// Token: 0x02000016 RID: 22
	[DefaultEvent("BeforePopup")]
	[Designer(typeof(MenuItemDesigner))]
	public abstract class MenuItemBase : ButtonItemBase, IToolBarItemBaseCollectionHost
	{
		// Token: 0x0600015F RID: 351 RVA: 0x00006A84 File Offset: 0x00005A84
		internal MenuItemBase()
		{
		}

		// Token: 0x06000160 RID: 352 RVA: 0x00006A94 File Offset: 0x00005A94
		internal MenuItemBase(string text) : this()
		{
			this.Text = text;
		}

		// Token: 0x14000009 RID: 9
		// (add) Token: 0x06000161 RID: 353 RVA: 0x00006AA4 File Offset: 0x00005AA4
		// (remove) Token: 0x06000162 RID: 354 RVA: 0x00006AC0 File Offset: 0x00005AC0
		public event MenuItemBase.BeforePopupEventHandler BeforePopup
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.xdccd26e8481ef075 = (MenuItemBase.BeforePopupEventHandler)Delegate.Combine(this.xdccd26e8481ef075, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.xdccd26e8481ef075 = (MenuItemBase.BeforePopupEventHandler)Delegate.Remove(this.xdccd26e8481ef075, value);
			}
		}

		// Token: 0x06000163 RID: 355 RVA: 0x00006ADC File Offset: 0x00005ADC
		internal void x9cc73f6a80ed2e5b(MenuProjection x82ae84eb9a8e4234)
		{
			this.x82ae84eb9a8e4234 = x82ae84eb9a8e4234;
		}

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x06000164 RID: 356 RVA: 0x00006AE8 File Offset: 0x00005AE8
		[Browsable(false)]
		public PopupMenu Popup
		{
			get
			{
				return this.xd70b090e3181abff;
			}
		}

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x06000165 RID: 357 RVA: 0x00006AF0 File Offset: 0x00005AF0
		internal override Font DefaultFont
		{
			get
			{
				if (this.Parent != null)
				{
					return this.Parent.Font;
				}
				return base.DefaultFont;
			}
		}

		// Token: 0x06000166 RID: 358 RVA: 0x00006B0C File Offset: 0x00005B0C
		internal void x0aa6d7992477fa5e(PopupMenu xbcea506a33cf9111)
		{
			if (this.xd70b090e3181abff != null && xbcea506a33cf9111 != null)
			{
				this.xd8d78252f915b76e();
			}
			this.xd70b090e3181abff = xbcea506a33cf9111;
			if (base.ToolBar != null)
			{
				base.ToolBar.Refresh();
			}
		}

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x06000167 RID: 359 RVA: 0x00006B3C File Offset: 0x00005B3C
		protected internal virtual Type DefaultChildType
		{
			get
			{
				return typeof(MenuButtonItem);
			}
		}

		// Token: 0x06000168 RID: 360 RVA: 0x00006B48 File Offset: 0x00005B48
		protected internal virtual PopupMenu CreatePopupMenu(IPopupMenuHost host)
		{
			return new PopupMenu(this, host);
		}

		// Token: 0x06000169 RID: 361 RVA: 0x00006B54 File Offset: 0x00005B54
		internal void xd8d78252f915b76e()
		{
			this.xd70b090e3181abff.Hide();
			this.xd70b090e3181abff.Dispose();
			this.x0aa6d7992477fa5e(null);
			this.OnAfterPopup(EventArgs.Empty);
		}

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x0600016A RID: 362 RVA: 0x00006B80 File Offset: 0x00005B80
		[Browsable(false)]
		public MenuProjection MenuDirection
		{
			get
			{
				return this.x82ae84eb9a8e4234;
			}
		}

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x0600016B RID: 363 RVA: 0x00006B88 File Offset: 0x00005B88
		// (set) Token: 0x0600016C RID: 364 RVA: 0x00006B90 File Offset: 0x00005B90
		internal MenuButtonItem xe4f42f0e511fcd41
		{
			get
			{
				return this.x716cbe6495cbcf0a;
			}
			set
			{
				if (this.x716cbe6495cbcf0a != value)
				{
					if (this.x716cbe6495cbcf0a != null)
					{
						this.x716cbe6495cbcf0a.Invalidate();
					}
					this.x716cbe6495cbcf0a = value;
					if (this.x716cbe6495cbcf0a != null)
					{
						this.x716cbe6495cbcf0a.Invalidate();
					}
					if (this.Parent != null && this.Parent.xd70b090e3181abff != null)
					{
						this.Parent.xe4f42f0e511fcd41 = (MenuButtonItem)this;
					}
				}
				if (value == null)
				{
					foreach (object obj in this.Items)
					{
						MenuButtonItem menuButtonItem = (MenuButtonItem)obj;
						if (menuButtonItem.xd70b090e3181abff != null)
						{
							menuButtonItem.xe4f42f0e511fcd41 = null;
							break;
						}
					}
				}
			}
		}

		// Token: 0x0600016D RID: 365 RVA: 0x00006C60 File Offset: 0x00005C60
		protected internal override void ApplyLayout(Rectangle buttonBounds, Graphics graphics, bool vertical, bool rightToLeft)
		{
			base.ApplyLayout(buttonBounds, graphics, vertical, rightToLeft);
			if (this.xd70b090e3181abff != null)
			{
				this.xd70b090e3181abff.xcf42ad4a4f3fcbf6();
			}
		}

		// Token: 0x0600016E RID: 366 RVA: 0x00006C80 File Offset: 0x00005C80
		public override ToolbarItemBase CloneItem()
		{
			MenuItemBase menuItemBase = (MenuItemBase)base.CloneItem();
			menuItemBase.xdccd26e8481ef075 = this.xdccd26e8481ef075;
			foreach (object obj in this.Items)
			{
				MenuItemBase menuItemBase2 = (MenuItemBase)obj;
				menuItemBase.Items.Add((MenuButtonItem)menuItemBase2.CloneItem());
			}
			return menuItemBase;
		}

		// Token: 0x0600016F RID: 367 RVA: 0x00006D10 File Offset: 0x00005D10
		internal virtual void xcedf4ee3756f36dc()
		{
			if (this._xb6a159a84cb992d6 != null)
			{
				this._xb6a159a84cb992d6.xcedf4ee3756f36dc();
			}
		}

		// Token: 0x06000170 RID: 368 RVA: 0x00006D28 File Offset: 0x00005D28
		public bool HasVisibleSubitems()
		{
			if (this._xffd861c4fc9ace66 == null)
			{
				return false;
			}
			foreach (object obj in this.Items)
			{
				MenuButtonItem menuButtonItem = (MenuButtonItem)obj;
				if (menuButtonItem.Visible)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000171 RID: 369 RVA: 0x00006DA0 File Offset: 0x00005DA0
		internal void xb2b69aae23a4ae6d(MenuItemBase xb6a159a84cb992d6)
		{
			this._xb6a159a84cb992d6 = xb6a159a84cb992d6;
		}

		// Token: 0x06000172 RID: 370 RVA: 0x00006DAC File Offset: 0x00005DAC
		protected internal virtual void OnBeforePopup(MenuPopupEventArgs e)
		{
			if (this.xdccd26e8481ef075 != null)
			{
				this.xdccd26e8481ef075(this, e);
			}
		}

		// Token: 0x06000173 RID: 371 RVA: 0x00006DC4 File Offset: 0x00005DC4
		protected internal virtual void OnAfterPopup(EventArgs e)
		{
		}

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x06000174 RID: 372 RVA: 0x00006DC8 File Offset: 0x00005DC8
		[Browsable(false)]
		public MenuItemBase Parent
		{
			get
			{
				return this._xb6a159a84cb992d6;
			}
		}

		// Token: 0x06000175 RID: 373 RVA: 0x00006DD0 File Offset: 0x00005DD0
		internal MenuButtonItem x8e743e02cd363657()
		{
			if (!this.HasChildren)
			{
				return null;
			}
			for (int i = 0; i < this.Items.Count; i++)
			{
				if (this.Items[i].Visible && !this.Items[i].x3780ff57150950cd)
				{
					return this.Items[i];
				}
			}
			return null;
		}

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x06000176 RID: 374 RVA: 0x00006E34 File Offset: 0x00005E34
		// (set) Token: 0x06000177 RID: 375 RVA: 0x00006E3C File Offset: 0x00005E3C
		[Browsable(false)]
		public override string ToolTipText
		{
			get
			{
				return base.ToolTipText;
			}
			set
			{
				base.ToolTipText = value;
			}
		}

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x06000178 RID: 376 RVA: 0x00006E48 File Offset: 0x00005E48
		[Browsable(false)]
		public bool HasChildren
		{
			get
			{
				return this._xffd861c4fc9ace66 != null && this._xffd861c4fc9ace66.Count != 0;
			}
		}

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x06000179 RID: 377 RVA: 0x00006E68 File Offset: 0x00005E68
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public MenuItemBase.MenuItemCollection Items
		{
			get
			{
				if (this._xffd861c4fc9ace66 == null)
				{
					this._xffd861c4fc9ace66 = new MenuItemBase.MenuItemCollection(this);
				}
				return this._xffd861c4fc9ace66;
			}
		}

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x0600017A RID: 378 RVA: 0x00006E84 File Offset: 0x00005E84
		ToolbarItemBaseCollection IToolBarItemBaseCollectionHost.xf7a93b05c545ee2b
		{
			get
			{
				return this.Items;
			}
		}

		// Token: 0x0600017B RID: 379 RVA: 0x00006E8C File Offset: 0x00005E8C
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (this.Parent != null && this.Parent.Items.Contains((MenuButtonItem)this))
				{
					this.Parent.Items.Remove((MenuButtonItem)this);
				}
				if (this.HasChildren)
				{
					MenuButtonItem[] array = new MenuButtonItem[this.Items.Count];
					this.Items.CopyTo(array, 0);
					this.Items.Clear();
					foreach (MenuButtonItem menuButtonItem in array)
					{
						menuButtonItem.Dispose();
					}
				}
			}
			base.Dispose(disposing);
		}

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x0600017C RID: 380 RVA: 0x00006F28 File Offset: 0x00005F28
		Control IToolBarItemBaseCollectionHost.x426d9984f6586bce
		{
			get
			{
				return null;
			}
		}

		// Token: 0x0600017D RID: 381 RVA: 0x00006F2C File Offset: 0x00005F2C
		void IToolBarItemBaseCollectionHost.xe572f918f1a60bde()
		{
			if (this.xd70b090e3181abff != null)
			{
				this.xd70b090e3181abff.xcf42ad4a4f3fcbf6();
			}
			this.Invalidate();
			this.xcedf4ee3756f36dc();
		}

		// Token: 0x04000080 RID: 128
		private MenuItemBase.MenuItemCollection _xffd861c4fc9ace66;

		// Token: 0x04000081 RID: 129
		private MenuItemBase _xb6a159a84cb992d6;

		// Token: 0x04000082 RID: 130
		private MenuButtonItem x716cbe6495cbcf0a;

		// Token: 0x04000083 RID: 131
		private PopupMenu xd70b090e3181abff;

		// Token: 0x04000084 RID: 132
		private MenuProjection x82ae84eb9a8e4234 = MenuProjection.Bottom;

		// Token: 0x04000085 RID: 133
		private MenuItemBase.BeforePopupEventHandler xdccd26e8481ef075;

		// Token: 0x02000022 RID: 34
		public class MenuItemCollection : ToolbarItemBaseCollection
		{
			// Token: 0x060001FC RID: 508 RVA: 0x00009210 File Offset: 0x00008210
			internal MenuItemCollection(IToolBarItemBaseCollectionHost owner) : base(owner)
			{
			}

			// Token: 0x060001FD RID: 509 RVA: 0x0000921C File Offset: 0x0000821C
			internal override void x2c6dfd2e92209a38(ToolbarItemBase xccb63ca5f63dc470, object x071bde1041617fce)
			{
				((MenuButtonItem)xccb63ca5f63dc470).xb2b69aae23a4ae6d((MenuItemBase)x071bde1041617fce);
			}

			// Token: 0x060001FE RID: 510 RVA: 0x00009230 File Offset: 0x00008230
			internal override bool x69be3d3be3df174e(ToolbarItemBase xccb63ca5f63dc470)
			{
				return xccb63ca5f63dc470 is MenuButtonItem;
			}

			// Token: 0x1700009E RID: 158
			public MenuButtonItem this[int index]
			{
				get
				{
					return (MenuButtonItem)base[index];
				}
			}

			// Token: 0x06000200 RID: 512 RVA: 0x0000924C File Offset: 0x0000824C
			public int Add(string text)
			{
				return base.Add(new MenuButtonItem(text));
			}

			// Token: 0x06000201 RID: 513 RVA: 0x0000925C File Offset: 0x0000825C
			public int Add(string text, EventHandler eventHandler)
			{
				return base.Add(new MenuButtonItem(text, eventHandler));
			}
		}

		// Token: 0x0200002E RID: 46
		public enum MenuPopupMode
		{
			// Token: 0x040000F2 RID: 242
			TopLevelMenu,
			// Token: 0x040000F3 RID: 243
			ContextMenu,
			// Token: 0x040000F4 RID: 244
			SubMenu
		}

		// Token: 0x02000030 RID: 48
		// (Invoke) Token: 0x0600028E RID: 654
		public delegate void BeforePopupEventHandler(object sender, MenuPopupEventArgs e);
	}
}
