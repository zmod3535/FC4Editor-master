using System;
using System.ComponentModel;

namespace TD.SandBar
{
	// Token: 0x0200001A RID: 26
	public class ButtonItem : ButtonItemBase
	{
		// Token: 0x060001BF RID: 447 RVA: 0x00008228 File Offset: 0x00007228
		protected internal override void OnActivate()
		{
			if (this.BuddyMenu != null)
			{
				this.BuddyMenu.OnActivate();
				return;
			}
			base.OnActivate();
		}

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x060001C0 RID: 448 RVA: 0x00008244 File Offset: 0x00007244
		// (set) Token: 0x060001C1 RID: 449 RVA: 0x0000824C File Offset: 0x0000724C
		[DefaultValue(typeof(MenuButtonItem), null)]
		[Category("Behavior")]
		[Description("The MenuItem to invoke when the user clicks this button.")]
		public MenuButtonItem BuddyMenu
		{
			get
			{
				return this.xc6a6223232510e46;
			}
			set
			{
				if (this.xc6a6223232510e46 != null)
				{
					this.xc6a6223232510e46.x295cb4a1df7a5add -= this.x9c37880c2d8b156d;
				}
				this.xc6a6223232510e46 = value;
				if (this.xc6a6223232510e46 != null && base.DesignMode)
				{
					this.Checked = value.Checked;
					this.Enabled = value.Enabled;
					if (this.ImageIndex == -1)
					{
						this.ImageIndex = value.ImageIndex;
					}
				}
				if (this.xc6a6223232510e46 != null)
				{
					this.xc6a6223232510e46.x295cb4a1df7a5add += this.x9c37880c2d8b156d;
				}
			}
		}

		// Token: 0x060001C2 RID: 450 RVA: 0x000082DC File Offset: 0x000072DC
		private void x9c37880c2d8b156d(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			this.Checked = this.xc6a6223232510e46.Checked;
			this.Enabled = this.xc6a6223232510e46.Enabled;
		}

		// Token: 0x0400009A RID: 154
		private MenuButtonItem xc6a6223232510e46;
	}
}
