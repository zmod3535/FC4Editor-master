using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;
using TD.SandBar.Design;

namespace TD.SandBar
{
	// Token: 0x0200006C RID: 108
	internal class x4bb39eb6330384f7 : xaa20bb2d964a49fc
	{
		// Token: 0x0600054A RID: 1354 RVA: 0x0001CA54 File Offset: 0x0001BA54
		public x4bb39eb6330384f7(PopupMenu popupMenu, Control containerControl) : base(popupMenu)
		{
			this.x2e56ed5925efe990 = containerControl;
			popupMenu.AllowDrop = true;
			popupMenu.MouseMove += this.x2c5d1da1234c3a6a;
			popupMenu.MouseDown += this.x2e2bbfe11746fd86;
			popupMenu.DragEnter += this.x8ef4c7ea29bfacbb;
			popupMenu.DragLeave += this.xed988a74a61a5c0a;
			popupMenu.DragDrop += this.x5372de4e735a0342;
			popupMenu.DragOver += this.x0af7bc9d6796df5c;
			popupMenu.DoubleClick += this.xfcb035b0c8a5f7de;
			popupMenu.Paint += this.xb8a4be83088cbf89;
		}

		// Token: 0x17000147 RID: 327
		// (get) Token: 0x0600054B RID: 1355 RVA: 0x0001CB08 File Offset: 0x0001BB08
		protected internal override bool AllowLowImportanceMenuItems
		{
			get
			{
				return false;
			}
		}

		// Token: 0x0600054C RID: 1356 RVA: 0x0001CB0C File Offset: 0x0001BB0C
		protected internal override void Show(ref int maximumMenuCount, TopLevelMenuItemBase.MenuAnimation desiredAnimation)
		{
			x443cc432acaadb1d.SetWindowPos(base.xebcaeeeb5a07df77.Handle, 0, 0, 0, 0, 0, 87);
		}

		// Token: 0x0600054D RID: 1357 RVA: 0x0001CB28 File Offset: 0x0001BB28
		protected internal override bool ShouldHighlightItem(MenuButtonItem item)
		{
			ISelectionService selectionService = (ISelectionService)base.xebcaeeeb5a07df77.Host.ToolBar.x7159e85e85b84817(typeof(ISelectionService));
			return item.Popup != null || selectionService.GetComponentSelected(item);
		}

		// Token: 0x17000148 RID: 328
		// (get) Token: 0x0600054E RID: 1358 RVA: 0x0001CB6C File Offset: 0x0001BB6C
		protected internal override Rectangle ConstraintArea
		{
			get
			{
				return this.x2e56ed5925efe990.ClientRectangle;
			}
		}

		// Token: 0x0600054F RID: 1359 RVA: 0x0001CB7C File Offset: 0x0001BB7C
		protected internal override Rectangle ModifyParentBounds(Rectangle parentBounds)
		{
			parentBounds = new Rectangle(this.x2e56ed5925efe990.PointToClient(parentBounds.Location), parentBounds.Size);
			return parentBounds;
		}

		// Token: 0x06000550 RID: 1360 RVA: 0x0001CBA0 File Offset: 0x0001BBA0
		private void xb8a4be83088cbf89(object xe0292b9ed559da7d, PaintEventArgs xfbf34718e704c6bc)
		{
			if (this.x26d093d7ebee61ad)
			{
				this.x102e9a712dac1aad(xfbf34718e704c6bc.Graphics);
			}
		}

		// Token: 0x06000551 RID: 1361 RVA: 0x0001CBB8 File Offset: 0x0001BBB8
		private void x102e9a712dac1aad(Graphics x4b101060f4767186)
		{
			Rectangle rect = new Rectangle(2, this.x72e5a8c213ad4134 - 1, base.xebcaeeeb5a07df77.ClientRectangle.Width - 4, 2);
			rect.Inflate(-3, 0);
			x4b101060f4767186.FillRectangle(SystemBrushes.ControlText, rect);
			x4b101060f4767186.DrawLine(SystemPens.ControlText, rect.X - 1, rect.Y - 2, rect.X - 1, rect.Y + 3);
			x4b101060f4767186.DrawLine(SystemPens.ControlText, rect.X, rect.Y - 1, rect.X, rect.Y + 2);
			x4b101060f4767186.DrawLine(SystemPens.ControlText, rect.Right, rect.Y - 2, rect.Right, rect.Y + 3);
			x4b101060f4767186.DrawLine(SystemPens.ControlText, rect.Right - 1, rect.Y - 1, rect.Right - 1, rect.Y + 2);
		}

		// Token: 0x06000552 RID: 1362 RVA: 0x0001CCB8 File Offset: 0x0001BCB8
		private void x2e2bbfe11746fd86(object xe0292b9ed559da7d, MouseEventArgs xfbf34718e704c6bc)
		{
			IDesignerHost designerHost = (IDesignerHost)base.xebcaeeeb5a07df77.Host.ToolBar.x7159e85e85b84817(typeof(IDesignerHost));
			MenuButtonItem itemAt = base.xebcaeeeb5a07df77.GetItemAt(new Point(xfbf34718e704c6bc.X, xfbf34718e704c6bc.Y));
			if (itemAt == base.xebcaeeeb5a07df77.x5683678bceda6657)
			{
				if (designerHost != null)
				{
					IDesigner designer = designerHost.GetDesigner(base.xebcaeeeb5a07df77.MenuItem);
					if (designer != null)
					{
						designer.Verbs[0].Invoke();
						return;
					}
				}
			}
			else if (itemAt != null)
			{
				ISelectionService selectionService = (ISelectionService)base.xebcaeeeb5a07df77.Host.ToolBar.x7159e85e85b84817(typeof(ISelectionService));
				if (!selectionService.GetComponentSelected(itemAt))
				{
					selectionService.SetSelectedComponents(new object[]
					{
						itemAt
					}, SelectionTypes.MouseDown | SelectionTypes.Click);
					this.x1dfad267d2e4592c = new Point(xfbf34718e704c6bc.X, xfbf34718e704c6bc.Y);
					base.xebcaeeeb5a07df77.Invalidate();
				}
			}
		}

		// Token: 0x06000553 RID: 1363 RVA: 0x0001CDB0 File Offset: 0x0001BDB0
		private void x2c5d1da1234c3a6a(object xe0292b9ed559da7d, MouseEventArgs xfbf34718e704c6bc)
		{
			Rectangle buttonBounds = base.xebcaeeeb5a07df77.x5683678bceda6657.ButtonBounds;
			if (buttonBounds.Contains(xfbf34718e704c6bc.X, xfbf34718e704c6bc.Y))
			{
				base.xebcaeeeb5a07df77.Cursor = Cursors.Hand;
			}
			else
			{
				base.xebcaeeeb5a07df77.Cursor = Cursors.Default;
			}
			if (xfbf34718e704c6bc.Button != MouseButtons.Left)
			{
				return;
			}
			buttonBounds = new Rectangle(this.x1dfad267d2e4592c.X, this.x1dfad267d2e4592c.Y, SystemInformation.DragSize.Width, SystemInformation.DragSize.Height);
			buttonBounds.Offset(-(SystemInformation.DragSize.Width / 2), -(SystemInformation.DragSize.Height / 2));
			if (buttonBounds.Contains(xfbf34718e704c6bc.X, xfbf34718e704c6bc.Y))
			{
				return;
			}
			ISelectionService selectionService = (ISelectionService)base.xebcaeeeb5a07df77.Host.ToolBar.x7159e85e85b84817(typeof(ISelectionService));
			foreach (object obj in selectionService.GetSelectedComponents())
			{
				if (!(obj is MenuButtonItem))
				{
					this.x1dfad267d2e4592c = Point.Empty;
					return;
				}
				if (!base.xebcaeeeb5a07df77.MenuItem.Items.Contains((MenuButtonItem)obj))
				{
					this.x1dfad267d2e4592c = Point.Empty;
					return;
				}
			}
			ArrayList arrayList = new ArrayList();
			foreach (object obj2 in base.xebcaeeeb5a07df77.MenuItem.Items)
			{
				MenuButtonItem menuButtonItem = (MenuButtonItem)obj2;
				if (selectionService.GetComponentSelected(menuButtonItem))
				{
					arrayList.Add(menuButtonItem);
				}
			}
			MenuButtonItem[] array = new MenuButtonItem[arrayList.Count];
			arrayList.CopyTo(array);
			base.xebcaeeeb5a07df77.DoDragDrop(array, DragDropEffects.Copy | DragDropEffects.Move);
		}

		// Token: 0x06000554 RID: 1364 RVA: 0x0001CFE4 File Offset: 0x0001BFE4
		private void x8ef4c7ea29bfacbb(object xe0292b9ed559da7d, DragEventArgs xfcbfa9575a5afacf)
		{
			this.x26d093d7ebee61ad = true;
		}

		// Token: 0x06000555 RID: 1365 RVA: 0x0001CFF0 File Offset: 0x0001BFF0
		private void xed988a74a61a5c0a(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			if (this.x26d093d7ebee61ad)
			{
				this.x26d093d7ebee61ad = false;
				base.xebcaeeeb5a07df77.Invalidate();
			}
		}

		// Token: 0x06000556 RID: 1366 RVA: 0x0001D00C File Offset: 0x0001C00C
		private bool xe6586172b49067ad(MenuItemBase xccb63ca5f63dc470)
		{
			MenuItemBase menuItemBase = base.xebcaeeeb5a07df77.MenuItem;
			while (menuItemBase.Parent != null)
			{
				if (menuItemBase == xccb63ca5f63dc470)
				{
					return true;
				}
				menuItemBase = menuItemBase.Parent;
			}
			return false;
		}

		// Token: 0x06000557 RID: 1367 RVA: 0x0001D040 File Offset: 0x0001C040
		private void x0af7bc9d6796df5c(object xe0292b9ed559da7d, DragEventArgs xfcbfa9575a5afacf)
		{
			if (!xfcbfa9575a5afacf.Data.GetDataPresent(typeof(MenuButtonItem[]).FullName))
			{
				return;
			}
			MenuButtonItem[] array = (MenuButtonItem[])xfcbfa9575a5afacf.Data.GetData(typeof(MenuButtonItem[]).FullName);
			for (;;)
			{
				IL_1DF:
				MenuButtonItem[] array2 = array;
				int i = 0;
				while (i < array2.Length)
				{
					MenuButtonItem xccb63ca5f63dc = array2[i];
					if (this.xe6586172b49067ad(xccb63ca5f63dc))
					{
						goto Block_6;
					}
					i++;
					if (((uint)i | 255U) == 0U)
					{
						goto IL_1DF;
					}
				}
				goto Block_7;
			}
			Block_6:
			return;
			Block_7:
			MenuButtonItem itemAt = base.xebcaeeeb5a07df77.GetItemAt(base.xebcaeeeb5a07df77.PointToClient(new Point(xfcbfa9575a5afacf.X, xfcbfa9575a5afacf.Y)));
			if (itemAt != null && base.xebcaeeeb5a07df77.MenuItem.Items.Contains(itemAt))
			{
				ISelectionService selectionService = (ISelectionService)base.xebcaeeeb5a07df77.Host.ToolBar.x7159e85e85b84817(typeof(ISelectionService));
				selectionService.SetSelectedComponents(new object[]
				{
					itemAt
				}, SelectionTypes.Replace);
			}
			if ((xfcbfa9575a5afacf.KeyState & 8) == 8)
			{
				xfcbfa9575a5afacf.Effect = DragDropEffects.Copy;
			}
			else
			{
				xfcbfa9575a5afacf.Effect = DragDropEffects.Move;
			}
			this.x1dfad267d2e4592c = base.xebcaeeeb5a07df77.PointToClient(new Point(xfcbfa9575a5afacf.X, xfcbfa9575a5afacf.Y));
			this.xb9b45c47f3e94991 = 0;
			this.x72e5a8c213ad4134 = 5;
			foreach (object obj in base.xebcaeeeb5a07df77.MenuItem.Items)
			{
				MenuButtonItem menuButtonItem = (MenuButtonItem)obj;
				if (this.x1dfad267d2e4592c.Y < menuButtonItem.ButtonBounds.Y + menuButtonItem.ButtonBounds.Height / 2)
				{
					this.xb9b45c47f3e94991 = base.xebcaeeeb5a07df77.MenuItem.Items.IndexOf(menuButtonItem);
					this.x72e5a8c213ad4134 = menuButtonItem.ButtonBounds.Y - 1;
					break;
				}
				this.xb9b45c47f3e94991 = base.xebcaeeeb5a07df77.MenuItem.Items.IndexOf(menuButtonItem) + 1;
				this.x72e5a8c213ad4134 = menuButtonItem.ButtonBounds.Bottom;
			}
			base.xebcaeeeb5a07df77.Invalidate();
		}

		// Token: 0x06000558 RID: 1368 RVA: 0x0001D2B4 File Offset: 0x0001C2B4
		private void x5372de4e735a0342(object xe0292b9ed559da7d, DragEventArgs xfcbfa9575a5afacf)
		{
			bool flag = xfcbfa9575a5afacf.Effect == DragDropEffects.Move;
			if (!xfcbfa9575a5afacf.Data.GetDataPresent(typeof(MenuButtonItem[]).FullName))
			{
				return;
			}
			MenuButtonItem[] array = (MenuButtonItem[])xfcbfa9575a5afacf.Data.GetData(typeof(MenuButtonItem[]).FullName);
			MenuItemBase parent = array[0].Parent;
			int num = this.xb9b45c47f3e94991;
			if (parent != base.xebcaeeeb5a07df77.MenuItem || !flag)
			{
				goto IL_196;
			}
			MenuButtonItem[] array2 = array;
			int i;
			bool flag2 = (uint)i + (flag ? 1U : 0U) < 0U;
			if (!flag2)
			{
				foreach (MenuButtonItem item in array2)
				{
					flag2 = (((uint)i & 0U) == 0U);
					if (!flag2)
					{
						goto IL_11E;
					}
					if (parent.Items.IndexOf(item) < this.xb9b45c47f3e94991)
					{
						num--;
					}
				}
				goto IL_196;
			}
			IL_0F:
			int num2;
			MenuButtonItem[] array3;
			if (num2 < array3.Length)
			{
				MenuButtonItem item2 = array3[num2];
				parent.Items.Remove(item2);
				num2++;
				goto IL_2A7;
			}
			IComponentChangeService componentChangeService;
			componentChangeService.OnComponentChanged(parent, TypeDescriptor.GetProperties(parent)["Items"], null, null);
			IL_34:
			if (flag)
			{
				goto IL_87;
			}
			DesignerFunctions.InsertingItem = true;
			IDesignerHost designerHost;
			for (int k = 0; k < array.Length; k++)
			{
				array[k] = (MenuButtonItem)array[k].CloneItem();
				x4bb39eb6330384f7.x271151fd14823005(array[k], designerHost);
				designerHost.Container.Add(array[k]);
			}
			IL_81:
			DesignerFunctions.InsertingItem = false;
			IL_87:
			componentChangeService.OnComponentChanging(base.xebcaeeeb5a07df77.MenuItem, TypeDescriptor.GetProperties(base.xebcaeeeb5a07df77.MenuItem)["Items"]);
			for (i = array.Length - 1; i >= 0; i--)
			{
				base.xebcaeeeb5a07df77.MenuItem.Items.Insert(num, array[i]);
			}
			componentChangeService.OnComponentChanged(base.xebcaeeeb5a07df77.MenuItem, TypeDescriptor.GetProperties(base.xebcaeeeb5a07df77.MenuItem)["Items"], null, null);
			DesignerTransaction designerTransaction;
			designerTransaction.Commit();
			this.x26d093d7ebee61ad = false;
			IL_11E:
			base.xebcaeeeb5a07df77.Invalidate();
			ISelectionService selectionService;
			selectionService.SetSelectedComponents(new object[]
			{
				base.xebcaeeeb5a07df77.MenuItem
			}, SelectionTypes.Replace);
			return;
			IL_196:
			designerHost = (IDesignerHost)base.xebcaeeeb5a07df77.Host.ToolBar.x7159e85e85b84817(typeof(IDesignerHost));
			selectionService = (ISelectionService)base.xebcaeeeb5a07df77.Host.ToolBar.x7159e85e85b84817(typeof(ISelectionService));
			componentChangeService = (IComponentChangeService)base.xebcaeeeb5a07df77.Host.ToolBar.x7159e85e85b84817(typeof(IComponentChangeService));
			if (flag)
			{
				designerTransaction = designerHost.CreateTransaction("Move Menu Items");
				int k;
				if ((uint)k - (uint)i < 0U)
				{
					goto IL_81;
				}
			}
			else
			{
				designerTransaction = designerHost.CreateTransaction("Copy Menu Items");
			}
			if (!flag)
			{
				goto IL_34;
			}
			componentChangeService.OnComponentChanging(parent, TypeDescriptor.GetProperties(parent)["Items"]);
			array3 = array;
			num2 = 0;
			IL_2A7:
			goto IL_0F;
		}

		// Token: 0x06000559 RID: 1369 RVA: 0x0001D5DC File Offset: 0x0001C5DC
		public static void x271151fd14823005(MenuItemBase xbad297e497c37b6c, IDesignerHost xff9c60b45aa37b1e)
		{
			if (xbad297e497c37b6c.HasChildren)
			{
				foreach (object obj in xbad297e497c37b6c.Items)
				{
					MenuButtonItem menuButtonItem = (MenuButtonItem)obj;
					xff9c60b45aa37b1e.Container.Add(menuButtonItem);
					x4bb39eb6330384f7.x271151fd14823005(menuButtonItem, xff9c60b45aa37b1e);
				}
			}
		}

		// Token: 0x0600055A RID: 1370 RVA: 0x0001D658 File Offset: 0x0001C658
		private void xfcb035b0c8a5f7de(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			MenuItemBase itemAt = base.xebcaeeeb5a07df77.GetItemAt(base.xebcaeeeb5a07df77.PointToClient(Cursor.Position));
			if (itemAt != null)
			{
				IDesignerHost designerHost = (IDesignerHost)base.xebcaeeeb5a07df77.Host.ToolBar.x7159e85e85b84817(typeof(IDesignerHost));
				if (designerHost != null)
				{
					designerHost.GetDesigner(itemAt).DoDefaultAction();
				}
			}
		}

		// Token: 0x04000232 RID: 562
		private Control x2e56ed5925efe990;

		// Token: 0x04000233 RID: 563
		private Point x1dfad267d2e4592c;

		// Token: 0x04000234 RID: 564
		private int xb9b45c47f3e94991;

		// Token: 0x04000235 RID: 565
		private int x72e5a8c213ad4134;

		// Token: 0x04000236 RID: 566
		private bool x26d093d7ebee61ad;
	}
}
