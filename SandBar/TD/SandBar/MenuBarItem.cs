using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace TD.SandBar
{
	// Token: 0x0200003A RID: 58
	public class MenuBarItem : TopLevelMenuItemBase
	{
		// Token: 0x0600031E RID: 798 RVA: 0x0000FD58 File Offset: 0x0000ED58
		public MenuBarItem()
		{
		}

		// Token: 0x0600031F RID: 799 RVA: 0x0000FD60 File Offset: 0x0000ED60
		public MenuBarItem(string text) : base(text)
		{
		}

		// Token: 0x06000320 RID: 800 RVA: 0x0000FD6C File Offset: 0x0000ED6C
		internal override ToolbarItemBase.ItemPadding CreateDefaultPadding()
		{
			return new ToolbarItemBase.ItemPadding(this, 3, 7, 2, 7);
		}

		// Token: 0x06000321 RID: 801 RVA: 0x0000FD78 File Offset: 0x0000ED78
		private void xefce92626dd053c7()
		{
			if (this.xbfb266230bf6dc0e != null)
			{
				foreach (object obj in this.xbfb266230bf6dc0e)
				{
					MenuButtonItem menuButtonItem = (MenuButtonItem)obj;
					menuButtonItem.Activate -= this.x3a23503b9b12b27a;
					menuButtonItem.Dispose();
				}
				this.xbfb266230bf6dc0e.Clear();
			}
		}

		// Token: 0x06000322 RID: 802 RVA: 0x0000FE04 File Offset: 0x0000EE04
		public override ToolbarItemBase CloneItem()
		{
			MenuBarItem menuBarItem = (MenuBarItem)base.CloneItem();
			menuBarItem.MdiWindowList = this.MdiWindowList;
			menuBarItem.ShowIconsOnMdiWindowList = this.ShowIconsOnMdiWindowList;
			return menuBarItem;
		}

		// Token: 0x170000E3 RID: 227
		// (get) Token: 0x06000323 RID: 803 RVA: 0x0000FE38 File Offset: 0x0000EE38
		// (set) Token: 0x06000324 RID: 804 RVA: 0x0000FE40 File Offset: 0x0000EE40
		[Description("Indicates whether form icons should be shown in the mdi window list.")]
		[DefaultValue(false)]
		[Category("Behavior")]
		public virtual bool ShowIconsOnMdiWindowList
		{
			get
			{
				return this._xef805a7b56c18350;
			}
			set
			{
				this._xef805a7b56c18350 = value;
			}
		}

		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x06000325 RID: 805 RVA: 0x0000FE4C File Offset: 0x0000EE4C
		// (set) Token: 0x06000326 RID: 806 RVA: 0x0000FE54 File Offset: 0x0000EE54
		[Description("Indicates whether this item will show a list of mdi children.")]
		[Category("Behavior")]
		[DefaultValue(false)]
		public virtual bool MdiWindowList
		{
			get
			{
				return this._xdd59f36573fd8dd5;
			}
			set
			{
				this._xdd59f36573fd8dd5 = value;
				if (this._xdd59f36573fd8dd5 && this.xbfb266230bf6dc0e == null)
				{
					this.xbfb266230bf6dc0e = new ArrayList();
				}
			}
		}

		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x06000327 RID: 807 RVA: 0x0000FE78 File Offset: 0x0000EE78
		// (set) Token: 0x06000328 RID: 808 RVA: 0x0000FE7C File Offset: 0x0000EE7C
		[Browsable(false)]
		public override bool BeginGroup
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x06000329 RID: 809 RVA: 0x0000FE80 File Offset: 0x0000EE80
		// (set) Token: 0x0600032A RID: 810 RVA: 0x0000FE84 File Offset: 0x0000EE84
		[Browsable(false)]
		public override bool Checked
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x0600032B RID: 811 RVA: 0x0000FE88 File Offset: 0x0000EE88
		// (set) Token: 0x0600032C RID: 812 RVA: 0x0000FE90 File Offset: 0x0000EE90
		[Browsable(false)]
		public override Image Image
		{
			get
			{
				return base.Image;
			}
			set
			{
				base.Image = value;
			}
		}

		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x0600032D RID: 813 RVA: 0x0000FE9C File Offset: 0x0000EE9C
		// (set) Token: 0x0600032E RID: 814 RVA: 0x0000FEA0 File Offset: 0x0000EEA0
		[Browsable(false)]
		public override int ImageIndex
		{
			get
			{
				return -1;
			}
			set
			{
			}
		}

		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x0600032F RID: 815 RVA: 0x0000FEA4 File Offset: 0x0000EEA4
		// (set) Token: 0x06000330 RID: 816 RVA: 0x0000FEAC File Offset: 0x0000EEAC
		[Browsable(false)]
		public override Icon Icon
		{
			get
			{
				return base.Icon;
			}
			set
			{
				base.Icon = value;
			}
		}

		// Token: 0x170000EA RID: 234
		// (get) Token: 0x06000331 RID: 817 RVA: 0x0000FEB8 File Offset: 0x0000EEB8
		// (set) Token: 0x06000332 RID: 818 RVA: 0x0000FEC0 File Offset: 0x0000EEC0
		[Browsable(false)]
		public override Size IconSize
		{
			get
			{
				return base.IconSize;
			}
			set
			{
				base.IconSize = value;
			}
		}

		// Token: 0x06000333 RID: 819 RVA: 0x0000FECC File Offset: 0x0000EECC
		protected internal override void OnBeforePopup(MenuPopupEventArgs e)
		{
			if (this._xdd59f36573fd8dd5)
			{
				MenuBar menuBar;
				Form[] mdiChildren;
				int i;
				if (-1 != 0)
				{
					if (!(base.ToolBar is MenuBar))
					{
						return;
					}
					menuBar = (MenuBar)base.ToolBar;
					if (menuBar.OwnerForm == null || !menuBar.OwnerForm.IsMdiContainer)
					{
						return;
					}
					this.xefce92626dd053c7();
					mdiChildren = menuBar.OwnerForm.MdiChildren;
					i = 0;
				}
				while (i < mdiChildren.Length)
				{
					Form form = mdiChildren[i];
					MenuBarItem.x7d181b2dac75bef4 x7d181b2dac75bef = new MenuBarItem.x7d181b2dac75bef4();
					x7d181b2dac75bef.x0998f88679e46e9c = form;
					x7d181b2dac75bef.Text = form.Text;
					if (this._xef805a7b56c18350)
					{
						x7d181b2dac75bef.Icon = new Icon(form.Icon, 16, 16);
						x7d181b2dac75bef.IconSize = new Size(16, 16);
					}
					this.xbfb266230bf6dc0e.Add(x7d181b2dac75bef);
					base.Items.Add(x7d181b2dac75bef);
					if (menuBar.OwnerForm.ActiveMdiChild == form)
					{
						x7d181b2dac75bef.Checked = true;
					}
					x7d181b2dac75bef.Activate += this.x3a23503b9b12b27a;
					i++;
				}
				if (this.xbfb266230bf6dc0e.Count != 0)
				{
					((MenuButtonItem)this.xbfb266230bf6dc0e[0]).BeginGroup = true;
				}
			}
			base.OnBeforePopup(e);
		}

		// Token: 0x06000334 RID: 820 RVA: 0x00010008 File Offset: 0x0000F008
		protected internal override void OnAfterPopup(EventArgs e)
		{
			base.OnAfterPopup(e);
			this.xefce92626dd053c7();
		}

		// Token: 0x06000335 RID: 821 RVA: 0x00010018 File Offset: 0x0000F018
		private void x3a23503b9b12b27a(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			Form form = (Form)((MenuButtonItem)xe0292b9ed559da7d).Tag;
			form.Activate();
		}

		// Token: 0x0400012B RID: 299
		private bool _xdd59f36573fd8dd5;

		// Token: 0x0400012C RID: 300
		private bool _xef805a7b56c18350;

		// Token: 0x0400012D RID: 301
		private ArrayList xbfb266230bf6dc0e;

		// Token: 0x0200003B RID: 59
		private class x7d181b2dac75bef4 : MenuButtonItem
		{
			// Token: 0x06000336 RID: 822 RVA: 0x0001003C File Offset: 0x0000F03C
			protected internal override void OnActivate()
			{
				base.OnActivate();
				if (this.x0998f88679e46e9c != null)
				{
					this.x0998f88679e46e9c.Activate();
				}
			}

			// Token: 0x0400012E RID: 302
			public Form x0998f88679e46e9c;
		}
	}
}
