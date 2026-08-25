using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace TD.SandBar.Design
{
	// Token: 0x02000008 RID: 8
	internal class ToolBarItemBaseDesigner : ComponentDesigner
	{
		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600002D RID: 45 RVA: 0x00003624 File Offset: 0x00002624
		// (set) Token: 0x0600002E RID: 46 RVA: 0x0000363C File Offset: 0x0000263C
		public bool Visible
		{
			get
			{
				return (bool)base.ShadowProperties["Visible"];
			}
			set
			{
				base.ShadowProperties["Visible"] = value;
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600002F RID: 47 RVA: 0x00003654 File Offset: 0x00002654
		public override DesignerVerbCollection Verbs
		{
			get
			{
				if (this.x128517d7ded59312 != null)
				{
					DesignerVerb[] array = null;
					if (this.x128517d7ded59312.ToolBar != null)
					{
						ICollection verbs = this.xff9c60b45aa37b1e.GetDesigner(this.x128517d7ded59312.ToolBar).Verbs;
						array = new DesignerVerb[verbs.Count];
						verbs.CopyTo(array, 0);
					}
					return new DesignerVerbCollection(array);
				}
				return base.Verbs;
			}
		}

		// Token: 0x06000030 RID: 48 RVA: 0x000036B8 File Offset: 0x000026B8
		public override void Initialize(IComponent component)
		{
			base.Initialize(component);
			if (!(component is ToolbarItemBase))
			{
				DesignerFunctions.ShowCachedAssemblyError(component.GetType().Assembly, base.GetType().Assembly);
			}
			this.xff9c60b45aa37b1e = (IDesignerHost)this.GetService(typeof(IDesignerHost));
			this.x77da34c6f08140f2 = (ISelectionService)this.GetService(typeof(ISelectionService));
			this.x4cd3df9bd5e139a3 = (IComponentChangeService)this.GetService(typeof(IComponentChangeService));
			this.x77da34c6f08140f2.SelectionChanged += this.OnSelectionChanged;
			this.x128517d7ded59312 = (ToolbarItemBase)component;
			this.Visible = this.x128517d7ded59312.Visible;
			this.x128517d7ded59312.Visible = true;
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00003780 File Offset: 0x00002780
		private void InsertItem(Type type)
		{
			DesignerTransaction designerTransaction = this.xff9c60b45aa37b1e.CreateTransaction("Insert Item");
			try
			{
				if (this.x77da34c6f08140f2.PrimarySelection != base.Component)
				{
					this.x77da34c6f08140f2.SetSelectedComponents(new object[]
					{
						base.Component
					}, SelectionTypes.Replace);
				}
				ToolbarItemBase component = (ToolbarItemBase)this.xff9c60b45aa37b1e.CreateComponent(type);
				(this.xff9c60b45aa37b1e.GetDesigner(component) as ToolBarItemBaseDesigner).OnSetComponentDefaults();
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

		// Token: 0x06000032 RID: 50 RVA: 0x00003848 File Offset: 0x00002848
		protected override void PreFilterProperties(IDictionary properties)
		{
			base.PreFilterProperties(properties);
			properties["Visible"] = TypeDescriptor.CreateProperty(typeof(ToolBarItemBaseDesigner), (PropertyDescriptor)properties["Visible"], new Attribute[0]);
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00003884 File Offset: 0x00002884
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				this.x77da34c6f08140f2.SelectionChanged -= this.OnSelectionChanged;
				this.xff9c60b45aa37b1e = null;
				this.x77da34c6f08140f2 = null;
				this.x4cd3df9bd5e139a3 = null;
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000034 RID: 52 RVA: 0x000038BC File Offset: 0x000028BC
		private void OnSelectionChanged(object sender, EventArgs e)
		{
			bool componentSelected = this.x77da34c6f08140f2.GetComponentSelected(base.Component);
			if (componentSelected != this.x9f93ebd2ca5601a2)
			{
				this.x9f93ebd2ca5601a2 = componentSelected;
				this.x128517d7ded59312.Invalidate();
			}
		}

		// Token: 0x04000001 RID: 1
		private ToolbarItemBase x128517d7ded59312;

		// Token: 0x04000002 RID: 2
		private bool x9f93ebd2ca5601a2;

		// Token: 0x04000003 RID: 3
		private IDesignerHost xff9c60b45aa37b1e;

		// Token: 0x04000004 RID: 4
		private ISelectionService x77da34c6f08140f2;

		// Token: 0x04000005 RID: 5
		private IComponentChangeService x4cd3df9bd5e139a3;
	}
}
