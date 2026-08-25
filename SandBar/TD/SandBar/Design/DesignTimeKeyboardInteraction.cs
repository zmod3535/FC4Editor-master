using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms.Design;

namespace TD.SandBar.Design
{
	// Token: 0x02000070 RID: 112
	public class DesignTimeKeyboardInteraction
	{
		// Token: 0x06000568 RID: 1384 RVA: 0x0001DB78 File Offset: 0x0001CB78
		public DesignTimeKeyboardInteraction(IServiceProvider serviceProvider)
		{
			this.xdc2614fb286b7e33 = serviceProvider;
			IDesignerHost designerHost = (IDesignerHost)serviceProvider.GetService(typeof(IDesignerHost));
			this.xeafda41f3ad47e63 = designerHost.RootComponent;
			this.xeafda41f3ad47e63.Disposed += this.xdc15b6f40d11d94e;
			this.x33a218ecadfd9caa = new MenuCommand(new EventHandler(this.xc3f1e9b0c944e91b), MenuCommands.KeyCancel);
			this.xd514b86d1795d33e(ref this.xe09638319e249060, this.x33a218ecadfd9caa, MenuCommands.KeyCancel);
			this.x68d3a63d0fada634 = new MenuCommand(new EventHandler(this.x3e1d77963eb1c98b), MenuCommands.KeyMoveUp);
			this.xd514b86d1795d33e(ref this.x416b0986c92d77b0, this.x68d3a63d0fada634, MenuCommands.KeyMoveUp);
			this.xb605fbd8e1671c08 = new MenuCommand(new EventHandler(this.xe5ee87079503b291), MenuCommands.KeyMoveDown);
			this.xd514b86d1795d33e(ref this.x3dba8ebf68e279e7, this.xb605fbd8e1671c08, MenuCommands.KeyMoveDown);
			this.x2c920f1504a71b8e = new MenuCommand(new EventHandler(this.x20632e8a8d84d34b), MenuCommands.KeyMoveLeft);
			this.xd514b86d1795d33e(ref this.xce558d12e8f7e296, this.x2c920f1504a71b8e, MenuCommands.KeyMoveLeft);
			this.x98f2adc693edf5f9 = new MenuCommand(new EventHandler(this.xc0abecec92a10179), MenuCommands.KeyMoveRight);
			this.xd514b86d1795d33e(ref this.x392bccb5e5807bc1, this.x98f2adc693edf5f9, MenuCommands.KeyMoveRight);
		}

		// Token: 0x06000569 RID: 1385 RVA: 0x0001DCCC File Offset: 0x0001CCCC
		private void xd514b86d1795d33e(ref MenuCommand xbd6b630400f59997, MenuCommand x2b89a0041fe96077, CommandID x519b858f36529a11)
		{
			xbd6b630400f59997 = this.x6e5bcaf3a034adb7.FindCommand(x519b858f36529a11);
			if (xbd6b630400f59997 != null)
			{
				this.x6e5bcaf3a034adb7.RemoveCommand(xbd6b630400f59997);
				this.x6e5bcaf3a034adb7.AddCommand(x2b89a0041fe96077);
			}
		}

		// Token: 0x1700014C RID: 332
		// (get) Token: 0x0600056A RID: 1386 RVA: 0x0001DCFC File Offset: 0x0001CCFC
		private IMenuCommandService x6e5bcaf3a034adb7
		{
			get
			{
				if (this.x9db41ede0753a00e == null)
				{
					this.x9db41ede0753a00e = (IMenuCommandService)this.xdc2614fb286b7e33.GetService(typeof(IMenuCommandService));
				}
				return this.x9db41ede0753a00e;
			}
		}

		// Token: 0x1700014D RID: 333
		// (get) Token: 0x0600056B RID: 1387 RVA: 0x0001DD2C File Offset: 0x0001CD2C
		private ISelectionService x764b78333ff9e3d0
		{
			get
			{
				if (this.x77da34c6f08140f2 == null)
				{
					this.x77da34c6f08140f2 = (ISelectionService)this.xdc2614fb286b7e33.GetService(typeof(ISelectionService));
				}
				return this.x77da34c6f08140f2;
			}
		}

		// Token: 0x0600056C RID: 1388 RVA: 0x0001DD5C File Offset: 0x0001CD5C
		private void xc3f1e9b0c944e91b(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			this.xe09638319e249060.Invoke();
		}

		// Token: 0x0600056D RID: 1389 RVA: 0x0001DD6C File Offset: 0x0001CD6C
		private bool x87ddba91af8a3188(bool x984399ee4edeb5af)
		{
			bool flag = false;
			if (this.x764b78333ff9e3d0.PrimarySelection is MenuItemBase)
			{
				MenuItemBase menuItemBase = (MenuItemBase)this.x764b78333ff9e3d0.PrimarySelection;
				if (menuItemBase.Parent != null)
				{
					int num = menuItemBase.Parent.Items.IndexOf((MenuButtonItem)menuItemBase);
					if (x984399ee4edeb5af)
					{
						num++;
					}
					else
					{
						num--;
					}
					if (num == menuItemBase.Parent.Items.Count)
					{
						IDesignerHost designerHost = (IDesignerHost)this.xdc2614fb286b7e33.GetService(typeof(IDesignerHost));
						(designerHost.GetDesigner(menuItemBase.Parent) as MenuItemDesigner).xf5cf29b763aca844 = true;
					}
					else if (num == -1)
					{
						this.x764b78333ff9e3d0.SetSelectedComponents(new object[]
						{
							menuItemBase.Parent
						}, SelectionTypes.Replace);
					}
					else
					{
						this.x764b78333ff9e3d0.SetSelectedComponents(new object[]
						{
							menuItemBase.Parent.Items[num]
						}, SelectionTypes.Replace);
					}
					flag = true;
				}
				else if (menuItemBase is TopLevelMenuItemBase)
				{
					int i;
					if (x984399ee4edeb5af)
					{
						i = 0;
					}
					else
					{
						i = menuItemBase.Items.Count;
					}
					while (i >= 0)
					{
						if (i < menuItemBase.Items.Count)
						{
							this.x764b78333ff9e3d0.SetSelectedComponents(new object[]
							{
								menuItemBase.Items[i]
							}, SelectionTypes.Replace);
							return flag;
						}
						if ((uint)i - (flag ? 1U : 0U) <= 4294967295U)
						{
							break;
						}
					}
					IDesignerHost designerHost2 = (IDesignerHost)this.xdc2614fb286b7e33.GetService(typeof(IDesignerHost));
					(designerHost2.GetDesigner(menuItemBase) as MenuItemDesigner).xf5cf29b763aca844 = true;
				}
			}
			else if (this.x764b78333ff9e3d0.PrimarySelection is MenuItemDesigner.TemplateMenuItem)
			{
				MenuItemDesigner.TemplateMenuItem templateMenuItem = (MenuItemDesigner.TemplateMenuItem)this.x764b78333ff9e3d0.PrimarySelection;
				if (x984399ee4edeb5af || !templateMenuItem.x332a8eedb847940d.HasChildren)
				{
					this.x764b78333ff9e3d0.SetSelectedComponents(new object[]
					{
						templateMenuItem.x332a8eedb847940d
					}, SelectionTypes.Replace);
				}
				else
				{
					this.x764b78333ff9e3d0.SetSelectedComponents(new object[]
					{
						templateMenuItem.x332a8eedb847940d.Items[templateMenuItem.x332a8eedb847940d.Items.Count - 1]
					}, SelectionTypes.Replace);
				}
			}
			return flag;
		}

		// Token: 0x0600056E RID: 1390 RVA: 0x0001DFD4 File Offset: 0x0001CFD4
		private void x6ecbf5af0ab5e8ad(MenuItemBase x7bf8c4d03998048a, out ToolBar x2183afa7b8ad9896, out TopLevelMenuItemBase xa5d774eb6cb6bee6)
		{
			while (x7bf8c4d03998048a.Parent != null)
			{
				x7bf8c4d03998048a = x7bf8c4d03998048a.Parent;
			}
			x2183afa7b8ad9896 = x7bf8c4d03998048a.ToolBar;
			xa5d774eb6cb6bee6 = (TopLevelMenuItemBase)x7bf8c4d03998048a;
		}

		// Token: 0x0600056F RID: 1391 RVA: 0x0001DFF8 File Offset: 0x0001CFF8
		private MenuItemBase x378ab7e166f2d37e(MenuItemBase xa4baf9eb095feaed, bool xfc2074a859a5db8c)
		{
			ToolBar toolBar;
			TopLevelMenuItemBase value;
			this.x6ecbf5af0ab5e8ad(xa4baf9eb095feaed, out toolBar, out value);
			TopLevelMenuItemBase[] xd9ea46f5e = toolBar.xd9ea46f5e3831639;
			int num = Array.IndexOf<TopLevelMenuItemBase>(xd9ea46f5e, value);
			if (xfc2074a859a5db8c)
			{
				num++;
			}
			else
			{
				num--;
			}
			if (num == xd9ea46f5e.Length)
			{
				num = 0;
			}
			else if (num == -1)
			{
				num = xd9ea46f5e.Length - 1;
			}
			return xd9ea46f5e[num];
		}

		// Token: 0x06000570 RID: 1392 RVA: 0x0001E044 File Offset: 0x0001D044
		private bool x4aa738b77509d4e5(bool xfc2074a859a5db8c)
		{
			bool flag = false;
			if (!false)
			{
				MenuItemBase menuItemBase;
				MenuItemDesigner.TemplateMenuItem templateMenuItem;
				bool flag2;
				for (;;)
				{
					if (this.x764b78333ff9e3d0.PrimarySelection is MenuItemBase)
					{
						menuItemBase = (MenuItemBase)this.x764b78333ff9e3d0.PrimarySelection;
						if (xfc2074a859a5db8c)
						{
							goto Block_5;
						}
						if (xfc2074a859a5db8c)
						{
							return flag;
						}
						if (menuItemBase.Parent == null)
						{
							goto IL_1E4;
						}
						if ((flag ? 1U : 0U) + (flag ? 1U : 0U) <= 4294967295U)
						{
							goto Block_10;
						}
					}
					if (!(this.x764b78333ff9e3d0.PrimarySelection is MenuItemDesigner.TemplateMenuItem))
					{
						return flag;
					}
					templateMenuItem = (MenuItemDesigner.TemplateMenuItem)this.x764b78333ff9e3d0.PrimarySelection;
					if (xfc2074a859a5db8c)
					{
						break;
					}
					if (templateMenuItem.x332a8eedb847940d is TopLevelMenuItemBase)
					{
						goto Block_3;
					}
					this.x764b78333ff9e3d0.SetSelectedComponents(new object[]
					{
						templateMenuItem.x332a8eedb847940d
					}, SelectionTypes.Replace);
					flag2 = ((xfc2074a859a5db8c ? 1U : 0U) > uint.MaxValue);
					if (!flag2)
					{
						return flag;
					}
				}
				this.x764b78333ff9e3d0.SetSelectedComponents(new object[]
				{
					this.x378ab7e166f2d37e(templateMenuItem.x332a8eedb847940d, xfc2074a859a5db8c)
				}, SelectionTypes.Replace);
				return flag;
				Block_3:
				this.x764b78333ff9e3d0.SetSelectedComponents(new object[]
				{
					this.x378ab7e166f2d37e(templateMenuItem.x332a8eedb847940d, xfc2074a859a5db8c)
				}, SelectionTypes.Replace);
				return flag;
				Block_5:
				if (menuItemBase.Parent == null)
				{
					this.x764b78333ff9e3d0.SetSelectedComponents(new object[]
					{
						this.x378ab7e166f2d37e(menuItemBase, xfc2074a859a5db8c)
					}, SelectionTypes.Replace);
				}
				else if (menuItemBase.HasChildren)
				{
					this.x764b78333ff9e3d0.SetSelectedComponents(new object[]
					{
						menuItemBase.Items[0]
					}, SelectionTypes.Replace);
				}
				else
				{
					IDesignerHost designerHost = (IDesignerHost)this.xdc2614fb286b7e33.GetService(typeof(IDesignerHost));
					(designerHost.GetDesigner(menuItemBase) as MenuItemDesigner).xf5cf29b763aca844 = true;
				}
				return true;
				Block_10:
				if (!(menuItemBase.Parent is TopLevelMenuItemBase))
				{
					this.x764b78333ff9e3d0.SetSelectedComponents(new object[]
					{
						menuItemBase.Parent
					}, SelectionTypes.Replace);
					goto IL_206;
				}
				IL_1E4:
				this.x764b78333ff9e3d0.SetSelectedComponents(new object[]
				{
					this.x378ab7e166f2d37e(menuItemBase, xfc2074a859a5db8c)
				}, SelectionTypes.Replace);
				IL_206:
				flag = true;
				flag2 = (((xfc2074a859a5db8c ? 1U : 0U) | 8U) == 0U);
				if (flag2)
				{
				}
			}
			return flag;
		}

		// Token: 0x06000571 RID: 1393 RVA: 0x0001E278 File Offset: 0x0001D278
		private void x3e1d77963eb1c98b(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			if (!this.x87ddba91af8a3188(false))
			{
				this.x416b0986c92d77b0.Invoke();
			}
		}

		// Token: 0x06000572 RID: 1394 RVA: 0x0001E290 File Offset: 0x0001D290
		private void xe5ee87079503b291(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			if (!this.x87ddba91af8a3188(true))
			{
				this.x3dba8ebf68e279e7.Invoke();
			}
		}

		// Token: 0x06000573 RID: 1395 RVA: 0x0001E2A8 File Offset: 0x0001D2A8
		private void x20632e8a8d84d34b(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			if (!this.x4aa738b77509d4e5(false))
			{
				this.xce558d12e8f7e296.Invoke();
			}
		}

		// Token: 0x06000574 RID: 1396 RVA: 0x0001E2C0 File Offset: 0x0001D2C0
		private void xc0abecec92a10179(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			if (!this.x4aa738b77509d4e5(true))
			{
				this.x392bccb5e5807bc1.Invoke();
			}
		}

		// Token: 0x06000575 RID: 1397 RVA: 0x0001E2D8 File Offset: 0x0001D2D8
		private void xdc15b6f40d11d94e(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			this.x6e5bcaf3a034adb7.RemoveCommand(this.x33a218ecadfd9caa);
			this.x6e5bcaf3a034adb7.RemoveCommand(this.x68d3a63d0fada634);
			this.x6e5bcaf3a034adb7.RemoveCommand(this.xb605fbd8e1671c08);
			this.x6e5bcaf3a034adb7.RemoveCommand(this.x2c920f1504a71b8e);
			this.x6e5bcaf3a034adb7.RemoveCommand(this.x98f2adc693edf5f9);
			this.xeafda41f3ad47e63.Disposed -= this.xdc15b6f40d11d94e;
			this.xeafda41f3ad47e63 = null;
		}

		// Token: 0x0400023C RID: 572
		private IServiceProvider xdc2614fb286b7e33;

		// Token: 0x0400023D RID: 573
		private MenuCommand xe09638319e249060;

		// Token: 0x0400023E RID: 574
		private MenuCommand x416b0986c92d77b0;

		// Token: 0x0400023F RID: 575
		private MenuCommand x3dba8ebf68e279e7;

		// Token: 0x04000240 RID: 576
		private MenuCommand xce558d12e8f7e296;

		// Token: 0x04000241 RID: 577
		private MenuCommand x392bccb5e5807bc1;

		// Token: 0x04000242 RID: 578
		private MenuCommand x33a218ecadfd9caa;

		// Token: 0x04000243 RID: 579
		private MenuCommand x68d3a63d0fada634;

		// Token: 0x04000244 RID: 580
		private MenuCommand xb605fbd8e1671c08;

		// Token: 0x04000245 RID: 581
		private MenuCommand x2c920f1504a71b8e;

		// Token: 0x04000246 RID: 582
		private MenuCommand x98f2adc693edf5f9;

		// Token: 0x04000247 RID: 583
		private IMenuCommandService x9db41ede0753a00e;

		// Token: 0x04000248 RID: 584
		private ISelectionService x77da34c6f08140f2;

		// Token: 0x04000249 RID: 585
		private IComponent xeafda41f3ad47e63;
	}
}
