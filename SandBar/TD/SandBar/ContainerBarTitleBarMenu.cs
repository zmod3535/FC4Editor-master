using System;

namespace TD.SandBar
{
	// Token: 0x0200001F RID: 31
	public class ContainerBarTitleBarMenu : TopLevelMenuItemBase
	{
		// Token: 0x1700009A RID: 154
		// (get) Token: 0x060001DB RID: 475 RVA: 0x000088E0 File Offset: 0x000078E0
		protected internal override Type DefaultChildType
		{
			get
			{
				return typeof(ContainerBarTitleBarMenuItem);
			}
		}

		// Token: 0x060001DC RID: 476 RVA: 0x000088EC File Offset: 0x000078EC
		protected internal override void OnBeforePopup(MenuPopupEventArgs e)
		{
			base.OnBeforePopup(e);
			if (base.ToolBar is ContainerBar && base.HasChildren)
			{
				ContainerBarClientPanel selectedClientPanel = ((ContainerBar)base.ToolBar).SelectedClientPanel;
				foreach (object obj in base.Items)
				{
					MenuButtonItem menuButtonItem = (MenuButtonItem)obj;
					if (menuButtonItem is ContainerBarTitleBarMenuItem && ((ContainerBarTitleBarMenuItem)menuButtonItem).ClientPanel != null)
					{
						menuButtonItem.Checked = (((ContainerBarTitleBarMenuItem)menuButtonItem).ClientPanel == selectedClientPanel);
					}
				}
			}
		}

		// Token: 0x060001DD RID: 477 RVA: 0x000089A8 File Offset: 0x000079A8
		protected override void Dispose(bool disposing)
		{
			if (disposing && base.ToolBar is ContainerBar && ((ContainerBar)base.ToolBar).TitleBarMenu == this)
			{
				((ContainerBar)base.ToolBar).TitleBarMenu = null;
			}
			base.Dispose(disposing);
		}

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x060001DE RID: 478 RVA: 0x000089E8 File Offset: 0x000079E8
		// (set) Token: 0x060001DF RID: 479 RVA: 0x000089F0 File Offset: 0x000079F0
		public override string Text
		{
			get
			{
				return "";
			}
			set
			{
				base.Text = value;
			}
		}
	}
}
