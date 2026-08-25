using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;

namespace TD.SandBar.Design
{
	// Token: 0x02000021 RID: 33
	internal class TopLevelMenuItemDesigner : MenuItemDesigner
	{
		// Token: 0x060001ED RID: 493 RVA: 0x00008C10 File Offset: 0x00007C10
		public TopLevelMenuItemDesigner()
		{
			this.x8aa653e6f10d0f59 = new ArrayList();
		}

		// Token: 0x060001EE RID: 494 RVA: 0x00008C24 File Offset: 0x00007C24
		public override void Initialize(IComponent component)
		{
			base.Initialize(component);
			this.x7bf8c4d03998048a = (TopLevelMenuItemBase)component;
			IComponentChangeService componentChangeService = (IComponentChangeService)this.GetService(typeof(IComponentChangeService));
			ISelectionService selectionService = (ISelectionService)this.GetService(typeof(ISelectionService));
			componentChangeService.ComponentRemoving += this.x97263465e88c9d8e;
			selectionService.SelectionChanged += this.x6179d221e3fa4b20;
		}

		// Token: 0x060001EF RID: 495 RVA: 0x00008C94 File Offset: 0x00007C94
		public override void OnSetComponentDefaults()
		{
			base.OnSetComponentDefaults();
			this.x7bf8c4d03998048a.Text = "Menu";
		}

		// Token: 0x060001F0 RID: 496 RVA: 0x00008CAC File Offset: 0x00007CAC
		private void x97263465e88c9d8e(object xe0292b9ed559da7d, ComponentEventArgs xfbf34718e704c6bc)
		{
			if (xfbf34718e704c6bc.Component == this.x7bf8c4d03998048a && this.x8aa653e6f10d0f59.Count != 0)
			{
				this.x28a6db46ee37edcd();
			}
		}

		// Token: 0x060001F1 RID: 497 RVA: 0x00008CD0 File Offset: 0x00007CD0
		private void x6179d221e3fa4b20(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			ISelectionService selectionService = (ISelectionService)this.GetService(typeof(ISelectionService));
			bool flag;
			if (selectionService.PrimarySelection is MenuItemDesigner.TemplateMenuItem)
			{
				MenuItemBase x332a8eedb847940d = (selectionService.PrimarySelection as MenuItemDesigner.TemplateMenuItem).x332a8eedb847940d;
				flag = (x332a8eedb847940d == this.x7bf8c4d03998048a || this.x44b5d2cd544ac406(x332a8eedb847940d));
			}
			else
			{
				flag = (selectionService.PrimarySelection is MenuItemBase && (selectionService.PrimarySelection == this.x7bf8c4d03998048a || this.x44b5d2cd544ac406((MenuItemBase)selectionService.PrimarySelection)));
			}
			if (this.x8aa653e6f10d0f59.Count != 0 && !flag)
			{
				this.x28a6db46ee37edcd();
				if (this.x7bf8c4d03998048a.ToolBar != null)
				{
					this.x7bf8c4d03998048a.ToolBar.xc30476d9d8314d3c = null;
					return;
				}
			}
			else if (flag)
			{
				if (this.x7bf8c4d03998048a.ToolBar != null)
				{
					this.x7bf8c4d03998048a.ToolBar.xc30476d9d8314d3c = this.x7bf8c4d03998048a;
				}
				this.x73670b1df3d6998d();
			}
		}

		// Token: 0x060001F2 RID: 498 RVA: 0x00008DBC File Offset: 0x00007DBC
		private void x73670b1df3d6998d()
		{
			ISelectionService selectionService = (ISelectionService)this.GetService(typeof(ISelectionService));
			IDesignerHost designerHost = (IDesignerHost)this.GetService(typeof(IDesignerHost));
			MenuItemBase menuItemBase;
			if (selectionService.PrimarySelection is MenuItemDesigner.TemplateMenuItem)
			{
				menuItemBase = (selectionService.PrimarySelection as MenuItemDesigner.TemplateMenuItem).x332a8eedb847940d;
			}
			else
			{
				menuItemBase = (MenuItemBase)selectionService.PrimarySelection;
			}
			if (!(designerHost.RootComponent is Control))
			{
				return;
			}
			Control control = (Control)designerHost.RootComponent;
			control = control.Parent;
			this.x8136c0c1c219a6a2(menuItemBase);
			ArrayList arrayList = new ArrayList();
			MenuItemBase menuItemBase2 = menuItemBase;
			do
			{
				arrayList.Insert(0, menuItemBase2);
				menuItemBase2 = menuItemBase2.Parent;
			}
			while (menuItemBase2 != null);
			arrayList.RemoveAt(arrayList.Count - 1);
			foreach (object obj in arrayList)
			{
				MenuItemBase menuItemBase3 = (MenuItemBase)obj;
				if (menuItemBase3.Popup == null)
				{
					this.xd5c31cf151883f4f(menuItemBase3, control);
				}
				menuItemBase3.Popup.Invalidate();
			}
			if (menuItemBase.Popup == null)
			{
				this.xd5c31cf151883f4f(menuItemBase, control);
			}
			menuItemBase = (MenuItemBase)this.x8aa653e6f10d0f59[0];
			menuItemBase.xe4f42f0e511fcd41 = null;
			menuItemBase.Popup.Invalidate();
		}

		// Token: 0x060001F3 RID: 499 RVA: 0x00008F24 File Offset: 0x00007F24
		private void xd5c31cf151883f4f(MenuItemBase xccb63ca5f63dc470, Control x9492ad63ba3e62cf)
		{
			if (xccb63ca5f63dc470 == this.x7bf8c4d03998048a)
			{
				this.x3de934e448399b46((TopLevelMenuItemBase)xccb63ca5f63dc470, x9492ad63ba3e62cf);
			}
			else
			{
				this.x307cfc52e0cadda9(xccb63ca5f63dc470, xccb63ca5f63dc470.Parent, x9492ad63ba3e62cf);
			}
			this.x8aa653e6f10d0f59.Insert(0, xccb63ca5f63dc470);
		}

		// Token: 0x060001F4 RID: 500 RVA: 0x00008F5C File Offset: 0x00007F5C
		private void x8136c0c1c219a6a2(MenuItemBase xccb63ca5f63dc470)
		{
			while (this.x8aa653e6f10d0f59.Count != 0 && this.x8aa653e6f10d0f59[0] != xccb63ca5f63dc470 && this.x8aa653e6f10d0f59[0] != xccb63ca5f63dc470.Parent)
			{
				this.xdeff01678c6ecd41((MenuItemBase)this.x8aa653e6f10d0f59[0]);
				this.x8aa653e6f10d0f59.RemoveAt(0);
			}
		}

		// Token: 0x060001F5 RID: 501 RVA: 0x00008FC0 File Offset: 0x00007FC0
		private void x28a6db46ee37edcd()
		{
			while (this.x8aa653e6f10d0f59.Count != 0)
			{
				this.xdeff01678c6ecd41((MenuItemBase)this.x8aa653e6f10d0f59[0]);
				this.x8aa653e6f10d0f59.RemoveAt(0);
			}
		}

		// Token: 0x060001F6 RID: 502 RVA: 0x00008FF4 File Offset: 0x00007FF4
		private void xdeff01678c6ecd41(MenuItemBase xccb63ca5f63dc470)
		{
			xccb63ca5f63dc470.xd8d78252f915b76e();
		}

		// Token: 0x060001F7 RID: 503 RVA: 0x00008FFC File Offset: 0x00007FFC
		private void x307cfc52e0cadda9(MenuItemBase xccb63ca5f63dc470, MenuItemBase xb6a159a84cb992d6, Control x9492ad63ba3e62cf)
		{
			PopupMenu popupMenu = xccb63ca5f63dc470.CreatePopupMenu(this.x7bf8c4d03998048a.ToolBar);
			popupMenu.xb7036c6dfbc891e0(x9492ad63ba3e62cf);
			xccb63ca5f63dc470.x0aa6d7992477fa5e(popupMenu);
			x443cc432acaadb1d.SetParent(popupMenu.Handle, x9492ad63ba3e62cf.Handle);
			popupMenu.x9f953666761d03df(true);
			popupMenu.x35579b297303ed43(TopLevelMenuItemBase.MenuAnimation.None);
		}

		// Token: 0x060001F8 RID: 504 RVA: 0x0000904C File Offset: 0x0000804C
		private void x3de934e448399b46(TopLevelMenuItemBase xccb63ca5f63dc470, Control x9492ad63ba3e62cf)
		{
			PopupMenu popupMenu = xccb63ca5f63dc470.CreatePopupMenu(this.x7bf8c4d03998048a.ToolBar);
			popupMenu.xb7036c6dfbc891e0(x9492ad63ba3e62cf);
			xccb63ca5f63dc470.x0aa6d7992477fa5e(popupMenu);
			x443cc432acaadb1d.SetParent(popupMenu.Handle, x9492ad63ba3e62cf.Handle);
			popupMenu.x9f953666761d03df(false);
			popupMenu.x35579b297303ed43(TopLevelMenuItemBase.MenuAnimation.None);
		}

		// Token: 0x060001F9 RID: 505 RVA: 0x0000909C File Offset: 0x0000809C
		private bool x44b5d2cd544ac406(MenuItemBase xcbf78b15dd820156)
		{
			foreach (object obj in this.x7bf8c4d03998048a.Items)
			{
				MenuItemBase menuItemBase = (MenuItemBase)obj;
				if (menuItemBase == xcbf78b15dd820156)
				{
					return true;
				}
				bool flag = this.x4da945247defa662(menuItemBase, xcbf78b15dd820156);
				if (flag)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060001FA RID: 506 RVA: 0x00009120 File Offset: 0x00008120
		private bool x4da945247defa662(MenuItemBase xb6a159a84cb992d6, MenuItemBase x11d58b056c032b03)
		{
			if (!xb6a159a84cb992d6.HasChildren)
			{
				return false;
			}
			foreach (object obj in xb6a159a84cb992d6.Items)
			{
				MenuItemBase menuItemBase = (MenuItemBase)obj;
				if (menuItemBase == x11d58b056c032b03)
				{
					return true;
				}
				bool flag = this.x4da945247defa662(menuItemBase, x11d58b056c032b03);
				if (flag)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060001FB RID: 507 RVA: 0x000091A8 File Offset: 0x000081A8
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				IComponentChangeService componentChangeService = (IComponentChangeService)this.GetService(typeof(IComponentChangeService));
				ISelectionService selectionService = (ISelectionService)this.GetService(typeof(ISelectionService));
				componentChangeService.ComponentRemoving -= this.x97263465e88c9d8e;
				selectionService.SelectionChanged -= this.x6179d221e3fa4b20;
			}
			base.Dispose(disposing);
		}

		// Token: 0x040000AA RID: 170
		private TopLevelMenuItemBase x7bf8c4d03998048a;

		// Token: 0x040000AB RID: 171
		private ArrayList x8aa653e6f10d0f59;
	}
}
