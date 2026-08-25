using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace TD.SandBar.Design
{
	// Token: 0x02000017 RID: 23
	internal class MenuItemDesigner : ToolBarItemBaseDesigner
	{
		// Token: 0x0600017F RID: 383 RVA: 0x00006F58 File Offset: 0x00005F58
		public override void Initialize(IComponent component)
		{
			base.Initialize(component);
			this.xff9c60b45aa37b1e = (IDesignerHost)this.GetService(typeof(IDesignerHost));
			this.x77da34c6f08140f2 = (ISelectionService)this.GetService(typeof(ISelectionService));
			this.x4cd3df9bd5e139a3 = (IComponentChangeService)this.GetService(typeof(IComponentChangeService));
			this.x7bf8c4d03998048a = (MenuItemBase)component;
			this.x4cd3df9bd5e139a3.ComponentRemoving += this.x97263465e88c9d8e;
			this.x4cd3df9bd5e139a3.ComponentRemoved += this.x5c6da9d6db2adc7a;
			this.x4cd3df9bd5e139a3.ComponentAdding += this.x22dd2b62a3b321a0;
			this.x4cd3df9bd5e139a3.ComponentAdded += this.x967d72d056a8df83;
			this.x77da34c6f08140f2.SelectionChanged += this.x6179d221e3fa4b20;
		}

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x06000180 RID: 384 RVA: 0x0000703C File Offset: 0x0000603C
		public static bool x1a79fa4ce8017d28
		{
			get
			{
				return MenuItemDesigner.xf326a3cace0c8379;
			}
		}

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x06000181 RID: 385 RVA: 0x00007044 File Offset: 0x00006044
		// (set) Token: 0x06000182 RID: 386 RVA: 0x0000704C File Offset: 0x0000604C
		public bool xf5cf29b763aca844
		{
			get
			{
				return this.x3ea7ead782671a71;
			}
			set
			{
				this.x3ea7ead782671a71 = value;
				MenuItemDesigner.xf326a3cace0c8379 = value;
				if (value)
				{
					MenuItemDesigner.TemplateMenuItem templateMenuItem = new MenuItemDesigner.TemplateMenuItem(this.x7bf8c4d03998048a);
					ISelectionService selectionService = (ISelectionService)this.GetService(typeof(ISelectionService));
					selectionService.SetSelectedComponents(new object[]
					{
						templateMenuItem
					}, SelectionTypes.Replace);
				}
				if (this.x7bf8c4d03998048a.Popup != null)
				{
					this.x7bf8c4d03998048a.Popup.Invalidate();
				}
			}
		}

		// Token: 0x06000183 RID: 387 RVA: 0x000070BC File Offset: 0x000060BC
		public override void OnSetComponentDefaults()
		{
			base.OnSetComponentDefaults();
			this.x7bf8c4d03998048a.Text = this.x7bf8c4d03998048a.Site.Name;
		}

		// Token: 0x06000184 RID: 388 RVA: 0x000070E0 File Offset: 0x000060E0
		public void xc8d65a83d76cf59f(int xc0c4c459c6ccbd00, bool x4156113459484ee3)
		{
			DesignerTransaction designerTransaction = this.xff9c60b45aa37b1e.CreateTransaction("Insert Menu Item");
			try
			{
				if (this.x77da34c6f08140f2.PrimarySelection != base.Component)
				{
					this.x77da34c6f08140f2.SetSelectedComponents(new object[]
					{
						base.Component
					}, SelectionTypes.Replace);
				}
				MenuButtonItem menuButtonItem = (MenuButtonItem)this.xff9c60b45aa37b1e.CreateComponent(this.x7bf8c4d03998048a.DefaultChildType);
				(this.xff9c60b45aa37b1e.GetDesigner(menuButtonItem) as ComponentDesigner).OnSetComponentDefaults();
				this.x77da34c6f08140f2.SetSelectedComponents(new object[]
				{
					menuButtonItem
				}, SelectionTypes.Replace);
			}
			catch
			{
				designerTransaction.Cancel();
				designerTransaction = null;
			}
			finally
			{
				if (designerTransaction != null)
				{
					designerTransaction.Commit();
					designerTransaction = null;
				}
			}
		}

		// Token: 0x06000185 RID: 389 RVA: 0x000071C8 File Offset: 0x000061C8
		internal void x82f86421ddfe798c(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			this.xc8d65a83d76cf59f(this.x7bf8c4d03998048a.Items.Count, true);
		}

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x06000186 RID: 390 RVA: 0x000071E4 File Offset: 0x000061E4
		public override ICollection AssociatedComponents
		{
			get
			{
				if (this.x7bf8c4d03998048a.HasChildren)
				{
					return this.x7bf8c4d03998048a.Items;
				}
				return new object[0];
			}
		}

		// Token: 0x06000187 RID: 391 RVA: 0x00007208 File Offset: 0x00006208
		private void x97263465e88c9d8e(object xe0292b9ed559da7d, ComponentEventArgs xfbf34718e704c6bc)
		{
			if (xfbf34718e704c6bc.Component is MenuButtonItem && ((MenuButtonItem)xfbf34718e704c6bc.Component).Parent == this.x7bf8c4d03998048a)
			{
				try
				{
					this.x07249c286ee121a6 = this.xff9c60b45aa37b1e.CreateTransaction("Remove Item");
					base.RaiseComponentChanging(TypeDescriptor.GetProperties(this.x7bf8c4d03998048a)["Items"]);
				}
				catch
				{
					if (this.x07249c286ee121a6 != null)
					{
						this.x07249c286ee121a6.Cancel();
						this.x07249c286ee121a6 = null;
					}
				}
			}
		}

		// Token: 0x06000188 RID: 392 RVA: 0x000072A8 File Offset: 0x000062A8
		private void x5c6da9d6db2adc7a(object xe0292b9ed559da7d, ComponentEventArgs xfbf34718e704c6bc)
		{
			if (xfbf34718e704c6bc.Component is MenuButtonItem && ((MenuButtonItem)xfbf34718e704c6bc.Component).Parent == this.x7bf8c4d03998048a)
			{
				MenuButtonItem item = (MenuButtonItem)xfbf34718e704c6bc.Component;
				try
				{
					if (this.x7bf8c4d03998048a.Items.Contains(item))
					{
						this.x7bf8c4d03998048a.Items.Remove(item);
						base.RaiseComponentChanged(TypeDescriptor.GetProperties(this.x7bf8c4d03998048a)["Items"], null, null);
					}
				}
				finally
				{
					if (this.x07249c286ee121a6 != null)
					{
						this.x07249c286ee121a6.Commit();
						this.x07249c286ee121a6 = null;
					}
				}
			}
		}

		// Token: 0x06000189 RID: 393 RVA: 0x00007364 File Offset: 0x00006364
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				this.x4cd3df9bd5e139a3.ComponentRemoving -= this.x97263465e88c9d8e;
				this.x4cd3df9bd5e139a3.ComponentRemoved -= this.x5c6da9d6db2adc7a;
				this.x4cd3df9bd5e139a3.ComponentAdding -= this.x22dd2b62a3b321a0;
				this.x4cd3df9bd5e139a3.ComponentAdded -= this.x967d72d056a8df83;
				this.x77da34c6f08140f2.SelectionChanged -= this.x6179d221e3fa4b20;
				this.xff9c60b45aa37b1e = null;
				this.x77da34c6f08140f2 = null;
				this.x4cd3df9bd5e139a3 = null;
			}
			base.Dispose(disposing);
		}

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x0600018A RID: 394 RVA: 0x00007408 File Offset: 0x00006408
		public override DesignerVerbCollection Verbs
		{
			get
			{
				if (this.xf83003a7726fe74e == null)
				{
					this.xf83003a7726fe74e = new DesignerVerbCollection();
					this.xf83003a7726fe74e.Add(new DesignerVerb("Add &" + this.x7bf8c4d03998048a.DefaultChildType.Name, new EventHandler(this.x82f86421ddfe798c)));
				}
				return this.xf83003a7726fe74e;
			}
		}

		// Token: 0x0600018B RID: 395 RVA: 0x00007468 File Offset: 0x00006468
		private void x6179d221e3fa4b20(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			if (this.xf5cf29b763aca844)
			{
				ISelectionService selectionService = (ISelectionService)this.GetService(typeof(ISelectionService));
				if (!(selectionService.PrimarySelection is MenuItemDesigner.TemplateMenuItem))
				{
					this.xf5cf29b763aca844 = false;
				}
			}
		}

		// Token: 0x0600018C RID: 396 RVA: 0x000074A8 File Offset: 0x000064A8
		private void x22dd2b62a3b321a0(object xe0292b9ed559da7d, ComponentEventArgs xfbf34718e704c6bc)
		{
			if (xfbf34718e704c6bc.Component is MenuButtonItem && ((MenuButtonItem)xfbf34718e704c6bc.Component).Parent == null && this.x77da34c6f08140f2.PrimarySelection == this.x7bf8c4d03998048a && !DesignerFunctions.InsertingItem && !this.x38578a6f2d4f7ee8)
			{
				this.x38578a6f2d4f7ee8 = true;
				if (this.x07249c286ee121a6 == null)
				{
					this.x07249c286ee121a6 = this.xff9c60b45aa37b1e.CreateTransaction("Add Item");
				}
			}
		}

		// Token: 0x0600018D RID: 397 RVA: 0x0000751C File Offset: 0x0000651C
		private void x967d72d056a8df83(object xe0292b9ed559da7d, ComponentEventArgs xfbf34718e704c6bc)
		{
			if (xfbf34718e704c6bc.Component is MenuButtonItem && this.x38578a6f2d4f7ee8)
			{
				MenuButtonItem item = (MenuButtonItem)xfbf34718e704c6bc.Component;
				this.x38578a6f2d4f7ee8 = false;
				try
				{
					base.RaiseComponentChanging(TypeDescriptor.GetProperties(this.x7bf8c4d03998048a)["Items"]);
					this.x7bf8c4d03998048a.Items.Add(item);
				}
				finally
				{
					base.RaiseComponentChanged(TypeDescriptor.GetProperties(this.x7bf8c4d03998048a)["Items"], null, null);
				}
				if (this.x07249c286ee121a6 != null)
				{
					this.x07249c286ee121a6.Commit();
					this.x07249c286ee121a6 = null;
				}
			}
		}

		// Token: 0x04000086 RID: 134
		private MenuItemBase x7bf8c4d03998048a;

		// Token: 0x04000087 RID: 135
		private DesignerVerbCollection xf83003a7726fe74e;

		// Token: 0x04000088 RID: 136
		private bool x3ea7ead782671a71;

		// Token: 0x04000089 RID: 137
		private static bool xf326a3cace0c8379;

		// Token: 0x0400008A RID: 138
		private DesignerTransaction x07249c286ee121a6;

		// Token: 0x0400008B RID: 139
		private bool x38578a6f2d4f7ee8;

		// Token: 0x0400008C RID: 140
		private IDesignerHost xff9c60b45aa37b1e;

		// Token: 0x0400008D RID: 141
		private ISelectionService x77da34c6f08140f2;

		// Token: 0x0400008E RID: 142
		private IComponentChangeService x4cd3df9bd5e139a3;

		// Token: 0x02000023 RID: 35
		internal class TemplateMenuItem
		{
			// Token: 0x06000202 RID: 514 RVA: 0x0000926C File Offset: 0x0000826C
			public TemplateMenuItem(MenuItemBase parent)
			{
				this.xb6a159a84cb992d6 = parent;
			}

			// Token: 0x1700009F RID: 159
			// (get) Token: 0x06000203 RID: 515 RVA: 0x0000927C File Offset: 0x0000827C
			[Browsable(false)]
			public MenuItemBase x332a8eedb847940d
			{
				get
				{
					return this.xb6a159a84cb992d6;
				}
			}

			// Token: 0x040000AC RID: 172
			private MenuItemBase xb6a159a84cb992d6;
		}
	}
}
