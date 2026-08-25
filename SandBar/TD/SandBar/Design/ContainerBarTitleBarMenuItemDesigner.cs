using System;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace TD.SandBar.Design
{
	// Token: 0x0200006E RID: 110
	internal class ContainerBarTitleBarMenuItemDesigner : MenuItemDesigner
	{
		// Token: 0x06000561 RID: 1377 RVA: 0x0001D750 File Offset: 0x0001C750
		public ContainerBarTitleBarMenuItemDesigner()
		{
			this.xaee865f2ca8b74fe = new DesignerVerb("Select &Panel", new EventHandler(this.x83d6f7e6008a385e));
		}

		// Token: 0x06000562 RID: 1378 RVA: 0x0001D774 File Offset: 0x0001C774
		public override void Initialize(IComponent component)
		{
			base.Initialize(component);
			this.xcbf78b15dd820156 = (ContainerBarTitleBarMenuItem)component;
		}

		// Token: 0x06000563 RID: 1379 RVA: 0x0001D78C File Offset: 0x0001C78C
		private void x83d6f7e6008a385e(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			ISelectionService selectionService = (ISelectionService)this.GetService(typeof(ISelectionService));
			IComponentChangeService componentChangeService = (IComponentChangeService)this.GetService(typeof(IComponentChangeService));
			if (this.xcbf78b15dd820156.ClientPanel != null && this.xcbf78b15dd820156.Parent != null && this.xcbf78b15dd820156.Parent.ToolBar is ContainerBar)
			{
				ContainerBar containerBar = (ContainerBar)this.xcbf78b15dd820156.Parent.ToolBar;
				componentChangeService.OnComponentChanging(containerBar, TypeDescriptor.GetProperties(containerBar)["SelectedClientPanel"]);
				containerBar.SelectedClientPanel = this.xcbf78b15dd820156.ClientPanel;
				componentChangeService.OnComponentChanged(containerBar, TypeDescriptor.GetProperties(containerBar)["SelectedClientPanel"], null, null);
				selectionService.SetSelectedComponents(new object[]
				{
					this.xcbf78b15dd820156.ClientPanel
				}, SelectionTypes.Replace);
			}
		}

		// Token: 0x1700014B RID: 331
		// (get) Token: 0x06000564 RID: 1380 RVA: 0x0001D870 File Offset: 0x0001C870
		public override DesignerVerbCollection Verbs
		{
			get
			{
				DesignerVerbCollection verbs = base.Verbs;
				if (!verbs.Contains(this.xaee865f2ca8b74fe))
				{
					verbs.Add(this.xaee865f2ca8b74fe);
				}
				return verbs;
			}
		}

		// Token: 0x04000238 RID: 568
		private ContainerBarTitleBarMenuItem xcbf78b15dd820156;

		// Token: 0x04000239 RID: 569
		private DesignerVerb xaee865f2ca8b74fe;
	}
}
