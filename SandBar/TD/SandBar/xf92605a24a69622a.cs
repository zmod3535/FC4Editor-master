using System;
using System.Collections;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TD.SandBar
{
	// Token: 0x02000036 RID: 54
	internal class xf92605a24a69622a : IDisposable
	{
		// Token: 0x06000294 RID: 660 RVA: 0x0000C140 File Offset: 0x0000B140
		public xf92605a24a69622a(IPopupMenuHost host, Control control, TopLevelMenuItemBase[] availableMenus, SandBarManager manager)
		{
			this.x43bec302f92080b9 = control;
			this.x64f259306803411c = host;
			this.x8ba1db939a763ebf = availableMenus;
			this.x91f347c6e97f1846 = manager;
			if (this.x8ba1db939a763ebf.Length == 0 && host.ToolBar != null)
			{
				this.x8ba1db939a763ebf = new TopLevelMenuItemBase[]
				{
					host.ToolBar.ActionsButton
				};
			}
			if (host == null)
			{
				throw new ArgumentNullException();
			}
			if (manager != null && !manager.AllowLowImportanceMenuItems)
			{
				this.xb1cbe6161311389a = false;
			}
		}

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x06000295 RID: 661 RVA: 0x0000C1C4 File Offset: 0x0000B1C4
		// (set) Token: 0x06000296 RID: 662 RVA: 0x0000C1CC File Offset: 0x0000B1CC
		public bool xb09380584c8ebe01
		{
			get
			{
				return this.xc8051b100df41d07;
			}
			set
			{
				this.xc8051b100df41d07 = value;
			}
		}

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x06000297 RID: 663 RVA: 0x0000C1D8 File Offset: 0x0000B1D8
		public bool x35065c826a7c41d7
		{
			get
			{
				return this.xb1cbe6161311389a;
			}
		}

		// Token: 0x06000298 RID: 664 RVA: 0x0000C1E0 File Offset: 0x0000B1E0
		public void xb8440663279d3c82()
		{
			this.xb1cbe6161311389a = false;
		}

		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x06000299 RID: 665 RVA: 0x0000C1EC File Offset: 0x0000B1EC
		// (set) Token: 0x0600029A RID: 666 RVA: 0x0000C1F4 File Offset: 0x0000B1F4
		public bool x98e68e83977b6367
		{
			get
			{
				return this._xd26e49a758f9a316;
			}
			set
			{
				this._xd26e49a758f9a316 = value;
			}
		}

		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x0600029B RID: 667 RVA: 0x0000C200 File Offset: 0x0000B200
		// (set) Token: 0x0600029C RID: 668 RVA: 0x0000C208 File Offset: 0x0000B208
		internal x72ff29faed0885ea xeb711626eeda8972
		{
			get
			{
				return this.xbd9bfab6467ba857;
			}
			set
			{
				this.xbd9bfab6467ba857 = value;
			}
		}

		// Token: 0x0600029D RID: 669 RVA: 0x0000C214 File Offset: 0x0000B214
		private void x30ed6b2cc9e9b563(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			if (this.x3ba5952d08de00ff)
			{
				this.xd674415062c2b55f();
			}
		}

		// Token: 0x0600029E RID: 670 RVA: 0x0000C224 File Offset: 0x0000B224
		public void xd674415062c2b55f()
		{
			if (this.x3ba5952d08de00ff)
			{
				this.x3ba5952d08de00ff = false;
				xf92605a24a69622a.PostMessage(this.x43bec302f92080b9.Handle, 31, IntPtr.Zero, IntPtr.Zero);
			}
		}

		// Token: 0x0600029F RID: 671 RVA: 0x0000C254 File Offset: 0x0000B254
		public static void x54516ceea3116eb1()
		{
			if (xf92605a24a69622a.x6ed4ed9ed59eb694 != null)
			{
				xf92605a24a69622a.x6ed4ed9ed59eb694.xd674415062c2b55f();
			}
		}

		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x060002A0 RID: 672 RVA: 0x0000C268 File Offset: 0x0000B268
		// (set) Token: 0x060002A1 RID: 673 RVA: 0x0000C270 File Offset: 0x0000B270
		private Form xb3e396733028b0ab
		{
			get
			{
				return this.xf19292428fc241ea;
			}
			set
			{
				if (this.xf19292428fc241ea != null)
				{
					this.xf19292428fc241ea.Deactivate -= this.x30ed6b2cc9e9b563;
				}
				this.xf19292428fc241ea = value;
				if (this.xf19292428fc241ea != null)
				{
					this.xf19292428fc241ea.Deactivate += this.x30ed6b2cc9e9b563;
				}
			}
		}

		// Token: 0x060002A2 RID: 674 RVA: 0x0000C2C4 File Offset: 0x0000B2C4
		public MenuButtonItem x0ef5a9135fb0040c(TopLevelMenuItemBase xccb63ca5f63dc470, bool x674341222c6bbaba, bool x37b4525011735d95, Point x13d4cb8d1bd20347)
		{
			this.xfbb4579b829aef10 = !x37b4525011735d95;
			xf92605a24a69622a.x54516ceea3116eb1();
			xf92605a24a69622a.x6ed4ed9ed59eb694 = this;
			if (this.x64f259306803411c.ToolBar != null)
			{
				this.x64f259306803411c.ToolBar.OnEnterMenuLoop();
			}
			this.xb3e396733028b0ab = Form.ActiveForm;
			if (this.xb3e396733028b0ab != null)
			{
				this.xafda855cbcd154fd = this.xb3e396733028b0ab;
			}
			MenuButtonItem menuButtonItem;
			try
			{
				if (!this.x98e68e83977b6367)
				{
					if (!this.x3de934e448399b46(xccb63ca5f63dc470, x674341222c6bbaba, x37b4525011735d95, x13d4cb8d1bd20347))
					{
						return null;
					}
				}
				else
				{
					this.x64f259306803411c.ToolBar.xe4f42f0e511fcd41 = xccb63ca5f63dc470;
				}
				x443cc432acaadb1d.ReleaseCapture();
				menuButtonItem = this.x9b347c061ed5a4b1(xccb63ca5f63dc470);
			}
			finally
			{
				this.xb3e396733028b0ab = null;
				this.xafda855cbcd154fd = null;
				if (this.x64f259306803411c.ToolBar != null)
				{
					this.x64f259306803411c.ToolBar.OnExitMenuLoop();
				}
				xf92605a24a69622a.x6ed4ed9ed59eb694 = null;
			}
			if (menuButtonItem != null)
			{
				MenuActivationType menuActivationType = MenuActivationType.DoEvents;
				if (this.x91f347c6e97f1846 != null)
				{
					menuActivationType = this.x91f347c6e97f1846.MenuActivation;
				}
				if (menuActivationType == MenuActivationType.DoEvents || menuActivationType == MenuActivationType.Immediate)
				{
					menuButtonItem.OnActivate();
				}
			}
			return menuButtonItem;
		}

		// Token: 0x060002A3 RID: 675 RVA: 0x0000C3D8 File Offset: 0x0000B3D8
		private void x19887b3821b9be99(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			MenuButtonItem menuButtonItem = (MenuButtonItem)xe0292b9ed559da7d;
			menuButtonItem.OnActivate();
		}

		// Token: 0x060002A4 RID: 676 RVA: 0x0000C3F4 File Offset: 0x0000B3F4
		private void x307cfc52e0cadda9(MenuItemBase xccb63ca5f63dc470, MenuItemBase xb6a159a84cb992d6, bool x674341222c6bbaba)
		{
			MenuPopupEventArgs e = new MenuPopupEventArgs(MenuItemBase.MenuPopupMode.SubMenu);
			xccb63ca5f63dc470.OnBeforePopup(e);
			PopupMenu popupMenu = xccb63ca5f63dc470.CreatePopupMenu(this.x64f259306803411c);
			popupMenu.xd95bd0c58a935da0(this, this.x5f4a93c3032a9eb8);
			if (this.xafda855cbcd154fd != null)
			{
				this.xafda855cbcd154fd.AddOwnedForm(popupMenu);
			}
			xccb63ca5f63dc470.x0aa6d7992477fa5e(popupMenu);
			popupMenu.x9f953666761d03df(true);
			if (x674341222c6bbaba)
			{
				xccb63ca5f63dc470.xe4f42f0e511fcd41 = xccb63ca5f63dc470.x8e743e02cd363657();
			}
			else
			{
				xccb63ca5f63dc470.xe4f42f0e511fcd41 = null;
			}
			popupMenu.x35579b297303ed43(ref this.x2286e22de2d4a38e, xd552f4634d304df2.x26618c6ae8a848ca(this.x64f259306803411c.MenuAnimation, x674341222c6bbaba));
			if (xccb63ca5f63dc470.xe4f42f0e511fcd41 != null)
			{
				xccb63ca5f63dc470.xe4f42f0e511fcd41.OnSelect();
			}
		}

		// Token: 0x060002A5 RID: 677 RVA: 0x0000C494 File Offset: 0x0000B494
		private bool x3de934e448399b46(TopLevelMenuItemBase xccb63ca5f63dc470, bool x674341222c6bbaba, bool x37b4525011735d95, Point x13d4cb8d1bd20347)
		{
			MenuPopupEventArgs menuPopupEventArgs;
			if (x37b4525011735d95)
			{
				menuPopupEventArgs = new MenuPopupEventArgs(MenuItemBase.MenuPopupMode.TopLevelMenu, this.x43bec302f92080b9, this.xb09380584c8ebe01);
				xccb63ca5f63dc470.OnBeforePopup(menuPopupEventArgs);
			}
			else
			{
				menuPopupEventArgs = new MenuPopupEventArgs(MenuItemBase.MenuPopupMode.ContextMenu, this.x43bec302f92080b9, this.xb09380584c8ebe01, x13d4cb8d1bd20347);
				xccb63ca5f63dc470.OnBeforePopup(menuPopupEventArgs);
				x13d4cb8d1bd20347 = menuPopupEventArgs.Position;
			}
			while (xccb63ca5f63dc470.HasVisibleSubitems() && !menuPopupEventArgs.Cancel)
			{
				Rectangle buttonBounds;
				if (!this.xfbb4579b829aef10)
				{
					buttonBounds = xccb63ca5f63dc470.ButtonBounds;
					goto IL_DC;
				}
				this.x5f4a93c3032a9eb8 = Screen.FromPoint(x13d4cb8d1bd20347);
				IL_FE:
				if (x37b4525011735d95 && this.x64f259306803411c.ToolBar != null)
				{
					this.x64f259306803411c.ToolBar.xe4f42f0e511fcd41 = xccb63ca5f63dc470;
					if ((x674341222c6bbaba ? 1U : 0U) - (x37b4525011735d95 ? 1U : 0U) > 4294967295U)
					{
						goto IL_DC;
					}
				}
				PopupMenu popupMenu = xccb63ca5f63dc470.CreatePopupMenu(this.x64f259306803411c);
				popupMenu.xd95bd0c58a935da0(this, this.x5f4a93c3032a9eb8);
				popupMenu.xd3b329aadd8fdeb3 = !x37b4525011735d95;
				bool flag = (x37b4525011735d95 ? 1U : 0U) + (x37b4525011735d95 ? 1U : 0U) > uint.MaxValue;
				if (flag)
				{
					goto IL_176;
				}
				if (this.xafda855cbcd154fd != null)
				{
					this.xafda855cbcd154fd.AddOwnedForm(popupMenu);
				}
				xccb63ca5f63dc470.x0aa6d7992477fa5e(popupMenu);
				if (x37b4525011735d95)
				{
					popupMenu.x9f953666761d03df(false);
				}
				else
				{
					popupMenu.x9f953666761d03df(false, x13d4cb8d1bd20347);
				}
				if (x674341222c6bbaba)
				{
					xccb63ca5f63dc470.xe4f42f0e511fcd41 = xccb63ca5f63dc470.x8e743e02cd363657();
				}
				else
				{
					xccb63ca5f63dc470.xe4f42f0e511fcd41 = null;
					flag = ((x674341222c6bbaba ? 1U : 0U) - (x37b4525011735d95 ? 1U : 0U) < 0U);
					if (flag)
					{
						continue;
					}
					goto IL_176;
				}
				IL_0B:
				popupMenu.x35579b297303ed43(ref this.x2286e22de2d4a38e, xd552f4634d304df2.x26618c6ae8a848ca(this.x64f259306803411c.MenuAnimation, x674341222c6bbaba));
				if (xccb63ca5f63dc470.xe4f42f0e511fcd41 != null)
				{
					xccb63ca5f63dc470.xe4f42f0e511fcd41.OnSelect();
					if (false)
					{
						continue;
					}
				}
				return true;
				IL_176:
				if (!false)
				{
					goto IL_0B;
				}
				return true;
				IL_DC:
				this.x5f4a93c3032a9eb8 = Screen.FromPoint(this.x64f259306803411c.ToolBar.PointToScreen(buttonBounds.Location));
				goto IL_FE;
			}
			return false;
		}

		// Token: 0x170000CA RID: 202
		// (get) Token: 0x060002A6 RID: 678 RVA: 0x0000C668 File Offset: 0x0000B668
		internal int xe1721ea98058f5f1
		{
			get
			{
				int num = 0;
				x443cc432acaadb1d.SystemParametersInfo(106, 0, ref num, 0);
				if (num <= 0)
				{
					num = 1;
				}
				return num;
			}
		}

		// Token: 0x060002A7 RID: 679 RVA: 0x0000C68C File Offset: 0x0000B68C
		private void xdeff01678c6ecd41(MenuItemBase xccb63ca5f63dc470)
		{
			if (xccb63ca5f63dc470.Popup != null)
			{
				xccb63ca5f63dc470.xd8d78252f915b76e();
			}
		}

		// Token: 0x060002A8 RID: 680 RVA: 0x0000C69C File Offset: 0x0000B69C
		private Point x62fd837908e21a28(IntPtr x96e7d32425e52ebf, IntPtr x130fbcecf32fe781)
		{
			x443cc432acaadb1d.POINTAPI pointapi = default(x443cc432acaadb1d.POINTAPI);
			pointapi.x = x443cc432acaadb1d.x0fcc9d0a21bd41f3(x130fbcecf32fe781.ToInt32());
			pointapi.y = x443cc432acaadb1d.xefc704ff04352756(x130fbcecf32fe781.ToInt32());
			x443cc432acaadb1d.ClientToScreen(x96e7d32425e52ebf, out pointapi);
			return new Point(pointapi.x, pointapi.y);
		}

		// Token: 0x060002A9 RID: 681 RVA: 0x0000C6F4 File Offset: 0x0000B6F4
		internal void x75622bee932c5a3d(MenuItemBase xcbf78b15dd820156, bool x18e9566618ba9e93)
		{
			while (this.x8aa653e6f10d0f59.Count != 0 && this.x8aa653e6f10d0f59[0] != xcbf78b15dd820156 && this.x8aa653e6f10d0f59[0] != xcbf78b15dd820156.Parent)
			{
				this.xdeff01678c6ecd41((MenuItemBase)this.x8aa653e6f10d0f59[0]);
				this.x8aa653e6f10d0f59.RemoveAt(0);
			}
			if (xcbf78b15dd820156.Parent != null && xcbf78b15dd820156.Parent.Popup != null && xcbf78b15dd820156.Popup == null && xcbf78b15dd820156.Enabled && xcbf78b15dd820156.Visible && !xcbf78b15dd820156.x3780ff57150950cd && xcbf78b15dd820156.HasVisibleSubitems())
			{
				this.x307cfc52e0cadda9(xcbf78b15dd820156, xcbf78b15dd820156.Parent, x18e9566618ba9e93);
				this.x8aa653e6f10d0f59.Insert(0, xcbf78b15dd820156);
			}
		}

		// Token: 0x060002AA RID: 682 RVA: 0x0000C7B0 File Offset: 0x0000B7B0
		private MenuButtonItem x9b347c061ed5a4b1(TopLevelMenuItemBase x243655256d921d02)
		{
			x443cc432acaadb1d.MSG msg = default(x443cc432acaadb1d.MSG);
			this.x8aa653e6f10d0f59 = new ArrayList();
			int message;
			if ((uint)message > 4294967295U)
			{
				goto IL_DA;
			}
			MenuButtonItem result = null;
			bool flag = false;
			x72ff29faed0885ea x72ff29faed0885ea = null;
			IntPtr intPtr = IntPtr.Zero;
			bool flag2 = false;
			Control x3ed4f4f0195b98d = null;
			x443cc432acaadb1d.HideCaret(IntPtr.Zero);
			Cursor.Current = Cursors.Default;
			if (this.x98e68e83977b6367)
			{
				flag = true;
			}
			this.x8aa653e6f10d0f59.Insert(0, x243655256d921d02);
			this.x3ba5952d08de00ff = true;
			IL_6E:
			int messageA;
			bool flag3;
			int message2;
			while (this.x3ba5952d08de00ff)
			{
				messageA = x443cc432acaadb1d.GetMessageA(out msg, IntPtr.Zero, 0, 0);
				if (messageA != -1)
				{
					if (messageA != 0)
					{
						x443cc432acaadb1d.TranslateMessage(out msg);
						this.xbd9bfab6467ba857 = null;
						if (msg.message != 161)
						{
							if (msg.message == 164)
							{
								flag3 = (((flag2 ? 1U : 0U) & 0U) == 0U);
								if (flag3)
								{
									goto IL_90B;
								}
							}
							else if (msg.message != 123)
							{
								if (msg.message == 31)
								{
									x72ff29faed0885ea = new x72ff29faed0885ea(x72ff29faed0885ea.MenuCommandType.Cancel);
									goto IL_10B;
								}
								MenuItemBase menuItemBase;
								if (msg.message < 512 || msg.message > 521)
								{
									while (msg.message >= 256 && msg.message <= 264)
									{
										menuItemBase = (MenuItemBase)this.x8aa653e6f10d0f59[0];
										message2 = msg.message;
										switch (message2)
										{
										case 256:
										case 260:
											if (!this.x64f259306803411c.RightToLeft)
											{
												if ((flag2 ? 1U : 0U) + (uint)message < 0U)
												{
													break;
												}
												if (msg.wParam.ToInt32() == 37)
												{
													goto IL_71B;
												}
											}
											if (!this.x64f259306803411c.RightToLeft || msg.wParam.ToInt32() != 39)
											{
												if ((!this.x64f259306803411c.RightToLeft && msg.wParam.ToInt32() == 39) || (this.x64f259306803411c.RightToLeft && msg.wParam.ToInt32() == 37))
												{
													if (menuItemBase.Popup != null)
													{
														flag3 = (((uint)message2 & 0U) == 0U);
														if (!flag3)
														{
															continue;
														}
														if (menuItemBase.xe4f42f0e511fcd41 != null && menuItemBase.xe4f42f0e511fcd41.HasVisibleSubitems() && menuItemBase.xe4f42f0e511fcd41.Enabled)
														{
															this.x307cfc52e0cadda9(menuItemBase.xe4f42f0e511fcd41, menuItemBase, true);
															this.x8aa653e6f10d0f59.Insert(0, menuItemBase.xe4f42f0e511fcd41);
															goto IL_10B;
														}
													}
													x72ff29faed0885ea = this.x38d4bcd65c0c6742(x243655256d921d02);
													if (4 == 0)
													{
														goto IL_741;
													}
													goto IL_10B;
												}
												else
												{
													int num = msg.wParam.ToInt32();
													if (num == 18)
													{
														x72ff29faed0885ea = new x72ff29faed0885ea(x72ff29faed0885ea.MenuCommandType.Cancel);
														x72ff29faed0885ea.xd5e60b0fe283887c = false;
														goto IL_3AC;
													}
													if (num != 27)
													{
														switch (num)
														{
														case 38:
															if (!menuItemBase.HasVisibleSubitems())
															{
																goto IL_10B;
															}
															if (flag)
															{
																flag = false;
																this.x3de934e448399b46(x243655256d921d02, true, true, Point.Empty);
																goto IL_10B;
															}
															menuItemBase.Popup.x00a9ccc077fe5b1a(-1);
															goto IL_10B;
														case 40:
															if (!menuItemBase.HasVisibleSubitems())
															{
																goto IL_10B;
															}
															if (flag)
															{
																flag = false;
																goto IL_51D;
															}
															menuItemBase.Popup.x00a9ccc077fe5b1a(1);
															goto IL_10B;
														}
														if (msg.message != 260)
														{
															goto IL_10B;
														}
														if ((uint)messageA <= 4294967295U)
														{
															if (menuItemBase.Popup == null)
															{
																x72ff29faed0885ea = new x72ff29faed0885ea(x72ff29faed0885ea.MenuCommandType.Cancel);
																x72ff29faed0885ea.xd5e60b0fe283887c = false;
																goto IL_10B;
															}
															x72ff29faed0885ea = this.x7151329d87ec5bac(menuItemBase, char.ToUpper(Convert.ToChar(msg.wParam.ToInt32())), this.x8aa653e6f10d0f59);
															x443cc432acaadb1d.MSG msg2;
															if (x72ff29faed0885ea != null && x72ff29faed0885ea.x1cbe9ccc3cd216b4 == x72ff29faed0885ea.MenuCommandType.Execute && x443cc432acaadb1d.PeekMessage(out msg2, IntPtr.Zero, 0U, 0U, 0U) && msg2.message == 262)
															{
																x443cc432acaadb1d.GetMessageA(out msg2, IntPtr.Zero, 0, 0);
																goto IL_10B;
															}
															goto IL_10B;
														}
														IL_51D:
														this.x3de934e448399b46(x243655256d921d02, true, true, Point.Empty);
														goto IL_10B;
													}
													if (menuItemBase.Popup == null)
													{
														x72ff29faed0885ea = new x72ff29faed0885ea(x72ff29faed0885ea.MenuCommandType.Cancel);
														goto IL_10B;
													}
													this.xdeff01678c6ecd41(menuItemBase);
													if (this.x8aa653e6f10d0f59.Count > 1)
													{
														this.x8aa653e6f10d0f59.Remove(menuItemBase);
													}
													if (this.xfbb4579b829aef10)
													{
														x72ff29faed0885ea = new x72ff29faed0885ea(x72ff29faed0885ea.MenuCommandType.Cancel);
														goto IL_10B;
													}
													if (this.x8aa653e6f10d0f59.Count != 1 || ((MenuItemBase)this.x8aa653e6f10d0f59[0]).Popup != null)
													{
														goto IL_10B;
													}
													if ((uint)messageA + (flag ? 1U : 0U) >= 0U)
													{
														menuItemBase = (MenuItemBase)this.x8aa653e6f10d0f59[0];
														flag = true;
														goto IL_10B;
													}
													goto IL_87C;
												}
											}
											IL_71B:
											if (this.x8aa653e6f10d0f59.Count < 2)
											{
												x72ff29faed0885ea = this.x3c4e832f012505be(x243655256d921d02);
												goto IL_10B;
											}
											this.xdeff01678c6ecd41(menuItemBase);
											this.x8aa653e6f10d0f59.Remove(menuItemBase);
											menuItemBase = (MenuItemBase)this.x8aa653e6f10d0f59[0];
											if (menuItemBase.xe4f42f0e511fcd41 != null)
											{
												menuItemBase.xe4f42f0e511fcd41.OnSelect();
												goto IL_10B;
											}
											goto IL_10B;
										case 257:
										case 259:
											goto IL_10B;
										case 258:
											if (msg.wParam.ToInt32() == 13)
											{
												if (flag)
												{
													flag = false;
												}
												else
												{
													if (menuItemBase.xe4f42f0e511fcd41 == null || !menuItemBase.xe4f42f0e511fcd41.Enabled)
													{
														goto IL_10B;
													}
													if (menuItemBase.xe4f42f0e511fcd41.HasVisibleSubitems())
													{
														this.x75622bee932c5a3d(menuItemBase.xe4f42f0e511fcd41, true);
														goto IL_10B;
													}
													x72ff29faed0885ea = new x72ff29faed0885ea(x72ff29faed0885ea.MenuCommandType.Execute, menuItemBase.xe4f42f0e511fcd41);
													goto IL_10B;
												}
											}
											else
											{
												if (menuItemBase.Popup != null)
												{
													x72ff29faed0885ea = this.x7151329d87ec5bac(menuItemBase, char.ToUpper(Convert.ToChar(msg.wParam.ToInt32())), this.x8aa653e6f10d0f59);
													goto IL_10B;
												}
												x72ff29faed0885ea = this.xc0225038568f1a79(char.ToUpper(Convert.ToChar(msg.wParam.ToInt32())));
												flag3 = (((flag2 ? 1U : 0U) | 3U) == 0U);
												if (!flag3)
												{
													if (x72ff29faed0885ea == null)
													{
														goto IL_10B;
													}
												}
												int num;
												flag3 = ((uint)intPtr - (uint)num < 0U);
												if (flag3)
												{
													goto IL_3AC;
												}
												flag = false;
												goto IL_DA;
											}
											break;
										default:
											goto IL_10B;
										}
										this.x3de934e448399b46(x243655256d921d02, true, true, Point.Empty);
										goto IL_10B;
									}
									x443cc432acaadb1d.DispatchMessageA(ref msg);
									goto IL_10B;
								}
								Point x8a6d69cf001869f = this.x62fd837908e21a28(msg.hwnd, msg.lParam);
								menuItemBase = this.x3ee374d3ae2d7f35(this.x8aa653e6f10d0f59, x8a6d69cf001869f);
								Control control = Control.FromHandle(msg.hwnd);
								message = msg.message;
								switch (message)
								{
								case 512:
									if (!(intPtr != msg.lParam))
									{
										goto IL_10B;
									}
									if (!(control is PopupMenu))
									{
										if (control == this.x64f259306803411c.ToolBar && control != null)
										{
											x72ff29faed0885ea = this.x1ec6f9b43a0c8162(x243655256d921d02, x8a6d69cf001869f);
											goto IL_769;
										}
										goto IL_769;
									}
									break;
								case 513:
								case 515:
								case 516:
								case 517:
								case 518:
									if (control == null)
									{
										goto IL_89C;
									}
									if (!false)
									{
										goto IL_87C;
									}
									continue;
								case 514:
									if (control is PopupMenu)
									{
										x443cc432acaadb1d.DispatchMessageA(ref msg);
										goto IL_10B;
									}
									if (control != this.x64f259306803411c.ToolBar && control != this.x43bec302f92080b9)
									{
										x72ff29faed0885ea = new x72ff29faed0885ea(x72ff29faed0885ea.MenuCommandType.Cancel, control);
										goto IL_10B;
									}
									goto IL_10B;
								default:
									goto IL_10B;
								}
								IL_741:
								x443cc432acaadb1d.DispatchMessageA(ref msg);
								IL_769:
								intPtr = msg.lParam;
								goto IL_10B;
								IL_87C:
								if (control is PopupMenu || this.xa079d91a62b19c8e(control))
								{
									x443cc432acaadb1d.DispatchMessageA(ref msg);
									goto IL_10B;
								}
								IL_89C:
								x72ff29faed0885ea = new x72ff29faed0885ea(x72ff29faed0885ea.MenuCommandType.Cancel, control);
								goto IL_10B;
							}
							this.x3ba5952d08de00ff = true;
							goto IL_10B;
						}
						IL_90B:
						x72ff29faed0885ea = new x72ff29faed0885ea(x72ff29faed0885ea.MenuCommandType.Cancel);
						goto IL_10B;
					}
				}
				this.x3ba5952d08de00ff = false;
			}
			this.x919006554709f99b(this.x8aa653e6f10d0f59, x243655256d921d02);
			x443cc432acaadb1d.ShowCaret(IntPtr.Zero);
			this.x8aa653e6f10d0f59.Clear();
			if (flag2 && this.xe8bfec26ce09d6bd(x3ed4f4f0195b98d))
			{
				xf92605a24a69622a.PostMessage(msg.hwnd, msg.message, msg.wParam, msg.lParam);
				goto IL_1EC;
			}
			return result;
			IL_DA:
			IL_10B:
			if (this.xbd9bfab6467ba857 != null)
			{
				x72ff29faed0885ea = this.xbd9bfab6467ba857;
				this.xbd9bfab6467ba857 = null;
			}
			if (x72ff29faed0885ea != null)
			{
				switch (x72ff29faed0885ea.x1cbe9ccc3cd216b4)
				{
				case x72ff29faed0885ea.MenuCommandType.Show:
					this.x919006554709f99b(this.x8aa653e6f10d0f59, x243655256d921d02);
					this.x64f259306803411c.ToolBar.xe4f42f0e511fcd41 = x72ff29faed0885ea.xbc9a1cbeed95c3fc;
					if (!flag)
					{
						this.x3de934e448399b46((TopLevelMenuItemBase)x72ff29faed0885ea.xbc9a1cbeed95c3fc, x72ff29faed0885ea.xa9ffede45d327713, true, Point.Empty);
					}
					this.x8aa653e6f10d0f59.Add(x72ff29faed0885ea.xbc9a1cbeed95c3fc);
					x243655256d921d02 = (TopLevelMenuItemBase)x72ff29faed0885ea.xbc9a1cbeed95c3fc;
					flag3 = (((flag ? 1U : 0U) | 2U) == 0U);
					if (flag3)
					{
						goto IL_1EC;
					}
					break;
				case x72ff29faed0885ea.MenuCommandType.Cancel:
					this.x3ba5952d08de00ff = false;
					flag2 = x72ff29faed0885ea.xd5e60b0fe283887c;
					x3ed4f4f0195b98d = x72ff29faed0885ea.xd5a7a92b8cfb14b3;
					break;
				case x72ff29faed0885ea.MenuCommandType.Execute:
					if (x72ff29faed0885ea.xbc9a1cbeed95c3fc is xb3f7a6163630a970.x15b157a7676ca959)
					{
						((MenuButtonItem)x72ff29faed0885ea.xbc9a1cbeed95c3fc).OnActivate();
						((MenuItemBase)this.x8aa653e6f10d0f59[0]).Popup.Invalidate(x72ff29faed0885ea.xbc9a1cbeed95c3fc.ButtonBounds);
					}
					else
					{
						result = (MenuButtonItem)x72ff29faed0885ea.xbc9a1cbeed95c3fc;
						this.x3ba5952d08de00ff = false;
					}
					break;
				}
				x72ff29faed0885ea = null;
				goto IL_6E;
			}
			goto IL_6E;
			IL_1EC:
			flag3 = ((uint)message2 + (uint)messageA > uint.MaxValue);
			if (!flag3)
			{
				return result;
			}
			IL_3AC:
			goto IL_10B;
			goto IL_6E;
		}

		// Token: 0x060002AB RID: 683
		[DllImport("user32.dll", SetLastError = true)]
		private static extern bool PostMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

		// Token: 0x060002AC RID: 684 RVA: 0x0000D194 File Offset: 0x0000C194
		private bool xe8bfec26ce09d6bd(Control x3ed4f4f0195b98d7)
		{
			bool flag = x3ed4f4f0195b98d7 != this.x64f259306803411c.ToolBar || this.xfbb4579b829aef10;
			bool flag2 = !(x3ed4f4f0195b98d7 is x502bf86f15e12152);
			return flag && flag2;
		}

		// Token: 0x060002AD RID: 685 RVA: 0x0000D1CC File Offset: 0x0000C1CC
		private bool xa079d91a62b19c8e(Control xde860fba55c41d76)
		{
			for (Control parent = xde860fba55c41d76.Parent; parent != null; parent = parent.Parent)
			{
				if (parent is PopupMenu)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060002AE RID: 686 RVA: 0x0000D1F8 File Offset: 0x0000C1F8
		private void x919006554709f99b(IList x8aa653e6f10d0f59, TopLevelMenuItemBase x243655256d921d02)
		{
			if (this.x64f259306803411c.ToolBar != null)
			{
				this.x64f259306803411c.ToolBar.xe4f42f0e511fcd41 = null;
			}
			foreach (object obj in x8aa653e6f10d0f59)
			{
				MenuItemBase xccb63ca5f63dc = (MenuItemBase)obj;
				this.xdeff01678c6ecd41(xccb63ca5f63dc);
			}
			x8aa653e6f10d0f59.Clear();
		}

		// Token: 0x060002AF RID: 687 RVA: 0x0000D27C File Offset: 0x0000C27C
		private x72ff29faed0885ea xc0225038568f1a79(char xba08ce632055a1d9)
		{
			foreach (object obj in this.x64f259306803411c.ToolBar.Items)
			{
				ToolbarItemBase toolbarItemBase = (ToolbarItemBase)obj;
				if (toolbarItemBase.Enabled && toolbarItemBase.Visible && toolbarItemBase is TopLevelMenuItemBase && Control.IsMnemonic(xba08ce632055a1d9, toolbarItemBase.Text))
				{
					return new x72ff29faed0885ea(x72ff29faed0885ea.MenuCommandType.Show, (TopLevelMenuItemBase)toolbarItemBase, true);
				}
			}
			return null;
		}

		// Token: 0x060002B0 RID: 688 RVA: 0x0000D320 File Offset: 0x0000C320
		private x72ff29faed0885ea x7151329d87ec5bac(MenuItemBase xcc028d5aa84f13ce, char xba08ce632055a1d9, ArrayList xb097b8d6ca5fb27a)
		{
			MenuButtonItem menuButtonItem = null;
			int num = 0;
			int index = 0;
			int num2 = -1;
			foreach (object obj in xcc028d5aa84f13ce.Items)
			{
				MenuButtonItem menuButtonItem2 = (MenuButtonItem)obj;
				if (menuButtonItem2.Visible && menuButtonItem2.Enabled && !menuButtonItem2.x3780ff57150950cd && Control.IsMnemonic(xba08ce632055a1d9, menuButtonItem2.Text))
				{
					num++;
					if (num == 1)
					{
						index = xcc028d5aa84f13ce.Items.IndexOf(menuButtonItem2);
					}
					if (xcc028d5aa84f13ce.xe4f42f0e511fcd41 != null && xcc028d5aa84f13ce.Items.IndexOf(menuButtonItem2) > xcc028d5aa84f13ce.Items.IndexOf(xcc028d5aa84f13ce.xe4f42f0e511fcd41) && num2 == -1)
					{
						num2 = xcc028d5aa84f13ce.Items.IndexOf(menuButtonItem2);
					}
					menuButtonItem = menuButtonItem2;
				}
			}
			if (num == 0)
			{
				return null;
			}
			if (num != 1)
			{
				if (num2 == -1)
				{
					xcc028d5aa84f13ce.xe4f42f0e511fcd41 = xcc028d5aa84f13ce.Items[index];
				}
				else
				{
					xcc028d5aa84f13ce.xe4f42f0e511fcd41 = xcc028d5aa84f13ce.Items[num2];
				}
				xcc028d5aa84f13ce.xe4f42f0e511fcd41.OnSelect();
				return null;
			}
			if (menuButtonItem.HasVisibleSubitems())
			{
				this.x75622bee932c5a3d(menuButtonItem, true);
				return null;
			}
			return new x72ff29faed0885ea(x72ff29faed0885ea.MenuCommandType.Execute, menuButtonItem);
		}

		// Token: 0x060002B1 RID: 689 RVA: 0x0000D470 File Offset: 0x0000C470
		private x72ff29faed0885ea x1ec6f9b43a0c8162(MenuItemBase x243655256d921d02, Point x8a6d69cf001869f5)
		{
			if (!this.xfbb4579b829aef10 && this.x64f259306803411c.ToolBar.Items.Contains(x243655256d921d02))
			{
				Point point = this.x64f259306803411c.ToolBar.PointToClient(x8a6d69cf001869f5);
				if (this.x64f259306803411c.ToolBar.ClientRectangle.Contains(point))
				{
					ToolbarItemBase itemAt = this.x64f259306803411c.ToolBar.GetItemAt(point);
					if (itemAt != x243655256d921d02 && itemAt is TopLevelMenuItemBase && itemAt.Enabled)
					{
						return new x72ff29faed0885ea(x72ff29faed0885ea.MenuCommandType.Show, (MenuItemBase)itemAt);
					}
				}
			}
			return null;
		}

		// Token: 0x060002B2 RID: 690 RVA: 0x0000D504 File Offset: 0x0000C504
		private MenuItemBase x3ee374d3ae2d7f35(ICollection xb097b8d6ca5fb27a, Point x8a6d69cf001869f5)
		{
			foreach (object obj in xb097b8d6ca5fb27a)
			{
				MenuItemBase menuItemBase = (MenuItemBase)obj;
				if (menuItemBase.Popup != null && menuItemBase.Popup.Bounds.Contains(x8a6d69cf001869f5))
				{
					return menuItemBase;
				}
			}
			return null;
		}

		// Token: 0x060002B3 RID: 691 RVA: 0x0000D588 File Offset: 0x0000C588
		private x72ff29faed0885ea x3c4e832f012505be(TopLevelMenuItemBase x192f45eeb07722f5)
		{
			TopLevelMenuItemBase topLevelMenuItemBase = this.xa2c01f3b52755262(x192f45eeb07722f5, -1);
			if (topLevelMenuItemBase == x192f45eeb07722f5)
			{
				return null;
			}
			return new x72ff29faed0885ea(x72ff29faed0885ea.MenuCommandType.Show, topLevelMenuItemBase, true);
		}

		// Token: 0x060002B4 RID: 692 RVA: 0x0000D5AC File Offset: 0x0000C5AC
		private x72ff29faed0885ea x38d4bcd65c0c6742(TopLevelMenuItemBase x192f45eeb07722f5)
		{
			TopLevelMenuItemBase topLevelMenuItemBase = this.xa2c01f3b52755262(x192f45eeb07722f5, 1);
			if (topLevelMenuItemBase == x192f45eeb07722f5)
			{
				return null;
			}
			return new x72ff29faed0885ea(x72ff29faed0885ea.MenuCommandType.Show, topLevelMenuItemBase, true);
		}

		// Token: 0x060002B5 RID: 693 RVA: 0x0000D5D0 File Offset: 0x0000C5D0
		private TopLevelMenuItemBase xa2c01f3b52755262(TopLevelMenuItemBase xccb63ca5f63dc470, int x23e85093ba3a7d1d)
		{
			int num = Array.IndexOf<TopLevelMenuItemBase>(this.x8ba1db939a763ebf, xccb63ca5f63dc470);
			int num2 = num;
			for (;;)
			{
				num2 += x23e85093ba3a7d1d;
				if (num2 < 0)
				{
					num2 = this.x8ba1db939a763ebf.Length - 1;
				}
				if (num2 == this.x8ba1db939a763ebf.Length)
				{
					num2 = 0;
				}
				if (this.x8ba1db939a763ebf[num2] == xccb63ca5f63dc470)
				{
					break;
				}
				if (this.x8ba1db939a763ebf[num2].Visible && this.x8ba1db939a763ebf[num2].Enabled)
				{
					goto Block_5;
				}
			}
			return xccb63ca5f63dc470;
			Block_5:
			return this.x8ba1db939a763ebf[num2];
		}

		// Token: 0x060002B6 RID: 694 RVA: 0x0000D640 File Offset: 0x0000C640
		public void Dispose()
		{
			this.x64f259306803411c = null;
			this.x43bec302f92080b9 = null;
			this.x5f4a93c3032a9eb8 = null;
		}

		// Token: 0x04000102 RID: 258
		private SandBarManager x91f347c6e97f1846;

		// Token: 0x04000103 RID: 259
		private IPopupMenuHost x64f259306803411c;

		// Token: 0x04000104 RID: 260
		private Control x43bec302f92080b9;

		// Token: 0x04000105 RID: 261
		private Screen x5f4a93c3032a9eb8;

		// Token: 0x04000106 RID: 262
		private Form xf19292428fc241ea;

		// Token: 0x04000107 RID: 263
		private Form xafda855cbcd154fd;

		// Token: 0x04000108 RID: 264
		private ArrayList x8aa653e6f10d0f59;

		// Token: 0x04000109 RID: 265
		private x72ff29faed0885ea xbd9bfab6467ba857;

		// Token: 0x0400010A RID: 266
		private bool x3ba5952d08de00ff;

		// Token: 0x0400010B RID: 267
		private int x2286e22de2d4a38e;

		// Token: 0x0400010C RID: 268
		private bool xc8051b100df41d07;

		// Token: 0x0400010D RID: 269
		private TopLevelMenuItemBase[] x8ba1db939a763ebf;

		// Token: 0x0400010E RID: 270
		private bool xfbb4579b829aef10;

		// Token: 0x0400010F RID: 271
		private bool _xd26e49a758f9a316;

		// Token: 0x04000110 RID: 272
		private static xf92605a24a69622a x6ed4ed9ed59eb694;

		// Token: 0x04000111 RID: 273
		private bool xb1cbe6161311389a = true;
	}
}
