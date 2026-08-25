using System;

namespace TD.SandBar
{
	// Token: 0x0200002B RID: 43
	internal class xb3f7a6163630a970 : TopLevelMenuItemBase
	{
		// Token: 0x0600025C RID: 604 RVA: 0x0000B9E0 File Offset: 0x0000A9E0
		public xb3f7a6163630a970(ToolBar toolbar)
		{
			this.x169279a87b6b72b2 = toolbar;
			base.SetToolbar(toolbar);
			this.ToolTipText = SandBarLanguage.ToolbarOptionsText;
			SandBarLanguage.xecd56f675e8e00c4 += this.x04aedd2ce14fbd43;
		}

		// Token: 0x0600025D RID: 605 RVA: 0x0000BA1C File Offset: 0x0000AA1C
		private void x04aedd2ce14fbd43(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			this.ToolTipText = SandBarLanguage.ToolbarOptionsText;
		}

		// Token: 0x0600025E RID: 606 RVA: 0x0000BA2C File Offset: 0x0000AA2C
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				SandBarLanguage.xecd56f675e8e00c4 -= this.x04aedd2ce14fbd43;
			}
			base.Dispose(disposing);
		}

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x0600025F RID: 607 RVA: 0x0000BA4C File Offset: 0x0000AA4C
		// (set) Token: 0x06000260 RID: 608 RVA: 0x0000BA54 File Offset: 0x0000AA54
		public bool x27c8fc232c1d233e
		{
			get
			{
				return this.x69a518f5d317e1ed;
			}
			set
			{
				this.x69a518f5d317e1ed = value;
			}
		}

		// Token: 0x06000261 RID: 609 RVA: 0x0000BA60 File Offset: 0x0000AA60
		private void x1937b4a767dfc89f()
		{
			MenuButtonItem[] array = new MenuButtonItem[base.Items.Count];
			base.Items.CopyTo(array, 0);
			foreach (MenuButtonItem menuButtonItem in array)
			{
				menuButtonItem.Dispose();
			}
		}

		// Token: 0x06000262 RID: 610 RVA: 0x0000BAA8 File Offset: 0x0000AAA8
		protected internal override void OnAfterPopup(EventArgs e)
		{
			base.OnAfterPopup(e);
			this.x1937b4a767dfc89f();
		}

		// Token: 0x06000263 RID: 611 RVA: 0x0000BAB8 File Offset: 0x0000AAB8
		protected internal override void OnBeforePopup(MenuPopupEventArgs e)
		{
			base.OnBeforePopup(e);
			int num;
			if (this.x169279a87b6b72b2.Overflow == ToolBarOverflow.Chevron)
			{
				num = 0;
				goto IL_9D;
			}
			goto IL_B3;
			IL_99:
			num++;
			IL_9D:
			if (num < this.x169279a87b6b72b2.Items.Count)
			{
				goto IL_139;
			}
			IL_B3:
			if (this.x69a518f5d317e1ed)
			{
				MenuButtonItem menuButtonItem = new MenuButtonItem(SandBarLanguage.AddRemoveButtonsText);
				menuButtonItem.BeginGroup = true;
				this.x3665a2b2764a40d3(menuButtonItem);
				menuButtonItem.Enabled = menuButtonItem.HasChildren;
				base.Items.Add(menuButtonItem);
			}
			base.ToolBar.OnCustomizeActionsButtonMenu(EventArgs.Empty);
			bool flag = (uint)num - (uint)num > uint.MaxValue;
			if (!flag)
			{
				return;
			}
			if ((uint)num + (uint)num < 0U)
			{
				goto IL_1C0;
			}
			IL_139:
			if (!this.x169279a87b6b72b2.Items[num].x3780ff57150950cd || !(this.x169279a87b6b72b2.Items[num] is ButtonItemBase) || !this.x169279a87b6b72b2.Items[num].Visible)
			{
				goto IL_99;
			}
			ButtonItemBase buttonItemBase = (ButtonItemBase)this.x169279a87b6b72b2.Items[num];
			xb3f7a6163630a970.x3c0e01e8276625a8 x3c0e01e8276625a = new xb3f7a6163630a970.x3c0e01e8276625a8(buttonItemBase);
			x3c0e01e8276625a.Text = buttonItemBase.Text;
			x3c0e01e8276625a.ImageIndex = buttonItemBase.ImageIndex;
			IL_1C0:
			x3c0e01e8276625a.Icon = buttonItemBase.Icon;
			x3c0e01e8276625a.Image = buttonItemBase.Image;
			x3c0e01e8276625a.IconSize = buttonItemBase.IconSize;
			x3c0e01e8276625a.BeginGroup = buttonItemBase.BeginGroup;
			x3c0e01e8276625a.Checked = buttonItemBase.Checked;
			x3c0e01e8276625a.Enabled = buttonItemBase.Enabled;
			if (x3c0e01e8276625a.Text.Length == 0)
			{
				x3c0e01e8276625a.Text = buttonItemBase.ToolTipText;
			}
			if (buttonItemBase is MenuItemBase)
			{
				foreach (object obj in ((MenuItemBase)buttonItemBase).Items)
				{
					ToolbarItemBase toolbarItemBase = (ToolbarItemBase)obj;
					x3c0e01e8276625a.Items.Add(toolbarItemBase.CloneItem());
				}
			}
			base.Items.Add(x3c0e01e8276625a);
			goto IL_99;
		}

		// Token: 0x06000264 RID: 612 RVA: 0x0000BCFC File Offset: 0x0000ACFC
		private void x3665a2b2764a40d3(MenuButtonItem xb13f2de377f27597)
		{
			foreach (object obj in this.x169279a87b6b72b2.Items)
			{
				ToolbarItemBase toolbarItemBase = (ToolbarItemBase)obj;
				xb3f7a6163630a970.x38c4f0819d8bb9d9 x38c4f0819d8bb9d = new xb3f7a6163630a970.x38c4f0819d8bb9d9(toolbarItemBase);
				x38c4f0819d8bb9d.Checked = toolbarItemBase.Visible;
				x38c4f0819d8bb9d.Text = toolbarItemBase.Text;
				if (x38c4f0819d8bb9d.Text.Length == 0)
				{
					x38c4f0819d8bb9d.Text = toolbarItemBase.ToolTipText;
				}
				x38c4f0819d8bb9d.BeginGroup = toolbarItemBase.BeginGroup;
				x38c4f0819d8bb9d.Activate += this.xeb813f2a0d0b7e1f;
				if (x38c4f0819d8bb9d.Text.Length == 0 && toolbarItemBase is ButtonItem && ((ButtonItem)toolbarItemBase).BuddyMenu != null)
				{
					x38c4f0819d8bb9d.Text = ((ButtonItem)toolbarItemBase).BuddyMenu.Text;
				}
				if (toolbarItemBase is ImageItemBase)
				{
					ImageItemBase imageItemBase = (ImageItemBase)toolbarItemBase;
					x38c4f0819d8bb9d.ImageIndex = imageItemBase.ImageIndex;
					x38c4f0819d8bb9d.Icon = imageItemBase.Icon;
					x38c4f0819d8bb9d.IconSize = imageItemBase.IconSize;
					x38c4f0819d8bb9d.Image = imageItemBase.Image;
				}
				xb13f2de377f27597.Items.Add(x38c4f0819d8bb9d);
			}
		}

		// Token: 0x06000265 RID: 613 RVA: 0x0000BE44 File Offset: 0x0000AE44
		private void xeb813f2a0d0b7e1f(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			xb3f7a6163630a970.x38c4f0819d8bb9d9 x38c4f0819d8bb9d = (xb3f7a6163630a970.x38c4f0819d8bb9d9)xe0292b9ed559da7d;
			x38c4f0819d8bb9d.Checked = !x38c4f0819d8bb9d.Checked;
			x38c4f0819d8bb9d.xe6d4b1b411ed94b5.Visible = x38c4f0819d8bb9d.Checked;
		}

		// Token: 0x040000DE RID: 222
		private ToolBar x169279a87b6b72b2;

		// Token: 0x040000DF RID: 223
		private bool x69a518f5d317e1ed = true;

		// Token: 0x0200002F RID: 47
		internal class x3c0e01e8276625a8 : MenuButtonItem
		{
			// Token: 0x0600028B RID: 651 RVA: 0x0000C100 File Offset: 0x0000B100
			public x3c0e01e8276625a8(ToolbarItemBase originalItem)
			{
				this.x99521ce0e142c71b = originalItem;
			}

			// Token: 0x0600028C RID: 652 RVA: 0x0000C110 File Offset: 0x0000B110
			protected internal override void OnActivate()
			{
				this.x99521ce0e142c71b.OnActivate();
			}

			// Token: 0x040000F5 RID: 245
			private ToolbarItemBase x99521ce0e142c71b;
		}

		// Token: 0x02000033 RID: 51
		internal class x38c4f0819d8bb9d9 : xb3f7a6163630a970.x15b157a7676ca959
		{
			// Token: 0x06000291 RID: 657 RVA: 0x0000C120 File Offset: 0x0000B120
			public x38c4f0819d8bb9d9(ToolbarItemBase item)
			{
				this._xccb63ca5f63dc470 = item;
			}

			// Token: 0x170000C4 RID: 196
			// (get) Token: 0x06000292 RID: 658 RVA: 0x0000C130 File Offset: 0x0000B130
			public ToolbarItemBase xe6d4b1b411ed94b5
			{
				get
				{
					return this._xccb63ca5f63dc470;
				}
			}

			// Token: 0x040000FE RID: 254
			private ToolbarItemBase _xccb63ca5f63dc470;
		}

		// Token: 0x02000034 RID: 52
		internal class x15b157a7676ca959 : MenuButtonItem
		{
		}
	}
}
