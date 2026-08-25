using System;
using System.ComponentModel;
using TD.SandBar.Design;

namespace TD.SandBar
{
	// Token: 0x0200006D RID: 109
	[Designer(typeof(ContainerBarTitleBarMenuItemDesigner))]
	public class ContainerBarTitleBarMenuItem : MenuButtonItem
	{
		// Token: 0x17000149 RID: 329
		// (get) Token: 0x0600055B RID: 1371 RVA: 0x0001D6B8 File Offset: 0x0001C6B8
		// (set) Token: 0x0600055C RID: 1372 RVA: 0x0001D6C0 File Offset: 0x0001C6C0
		[Category("Behavior")]
		[DefaultValue(typeof(ContainerBarClientPanel), null)]
		[Description("The ClientPanel that will be selected when the menu item is activated.")]
		public ContainerBarClientPanel ClientPanel
		{
			get
			{
				return this.x0b07037301e4d87c;
			}
			set
			{
				this.x0b07037301e4d87c = value;
				this.LayoutNeeded();
			}
		}

		// Token: 0x0600055D RID: 1373 RVA: 0x0001D6D0 File Offset: 0x0001C6D0
		protected internal override void OnActivate()
		{
			if (this.ClientPanel != null && base.Parent != null && base.Parent.ToolBar is ContainerBar)
			{
				((ContainerBar)base.Parent.ToolBar).SelectedClientPanel = this.ClientPanel;
			}
			base.OnActivate();
		}

		// Token: 0x1700014A RID: 330
		// (get) Token: 0x0600055E RID: 1374 RVA: 0x0001D720 File Offset: 0x0001C720
		// (set) Token: 0x0600055F RID: 1375 RVA: 0x0001D73C File Offset: 0x0001C73C
		public override string Text
		{
			get
			{
				if (this.ClientPanel != null)
				{
					return this.ClientPanel.Text;
				}
				return base.Text;
			}
			set
			{
				base.Text = value;
			}
		}

		// Token: 0x04000237 RID: 567
		private ContainerBarClientPanel x0b07037301e4d87c;
	}
}
