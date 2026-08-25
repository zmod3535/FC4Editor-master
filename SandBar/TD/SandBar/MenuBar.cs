using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;

namespace TD.SandBar
{
	// Token: 0x02000038 RID: 56
	[ProvideProperty("SandBarMenu", typeof(Control))]
	[ProvideProperty("SandBarContextMenu", typeof(NotifyIcon))]
	[Designer("TD.SandBar.Design.MenuBarDesigner, SandBar.Design, Version=1.0.0.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3")]
	public class MenuBar : ToolBar, IExtenderProvider
	{
		// Token: 0x060002E7 RID: 743 RVA: 0x0000EC7C File Offset: 0x0000DC7C
		public MenuBar()
		{
			this.x241399f44d8db343 = new Hashtable();
			this.x83edece623ddc642 = new Hashtable();
			this.xa5b485ae103026e5 = new ShortcutListener();
			this.Text = "Menu Bar";
			this.Closable = false;
			this.Stretch = true;
			this.Overflow = ToolBarOverflow.Wrap;
			this.AllowRightToLeft = true;
			this.x0c43e97df9f37461 = new x67a479f649e0eafe(this);
			this.x0c43e97df9f37461.xcf02ab93209aaa9e += this.xe7d491b7e8f35c6a;
		}

		// Token: 0x060002E8 RID: 744 RVA: 0x0000ED10 File Offset: 0x0000DD10
		private void xb1be88bbed869d11()
		{
			MenuBarItem menuBarItem = null;
			foreach (object obj in base.Items)
			{
				ToolbarItemBase toolbarItemBase = (ToolbarItemBase)obj;
				if (toolbarItemBase is MenuBarItem && toolbarItemBase.Enabled && toolbarItemBase.Visible)
				{
					menuBarItem = (MenuBarItem)toolbarItemBase;
					break;
				}
			}
			if (menuBarItem == null)
			{
				return;
			}
			xf92605a24a69622a xf92605a24a69622a = new xf92605a24a69622a(this, this, base.xd9ea46f5e3831639, base.Manager);
			xf92605a24a69622a.x98e68e83977b6367 = true;
			xf92605a24a69622a.x0ef5a9135fb0040c(menuBarItem, false, true, Point.Empty);
			xf92605a24a69622a.Dispose();
		}

		// Token: 0x060002E9 RID: 745 RVA: 0x0000EDC8 File Offset: 0x0000DDC8
		private void x9f591d556f17eb34(Graphics x41347a961b838962)
		{
			if (this.OwnerForm.ActiveMdiChild == null)
			{
				return;
			}
			try
			{
				using (Icon icon = new Icon(this.OwnerForm.ActiveMdiChild.Icon, new Size(16, 16)))
				{
					x41347a961b838962.DrawIcon(icon, this.xf630f2d01cda5794.ButtonBounds);
				}
			}
			catch
			{
			}
		}

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x060002EA RID: 746 RVA: 0x0000EE5C File Offset: 0x0000DE5C
		// (set) Token: 0x060002EB RID: 747 RVA: 0x0000EE64 File Offset: 0x0000DE64
		[DefaultValue(true)]
		[Category("Appearance")]
		[Description("Indicates whether the MDI system menu will be shown for maximized MDI children.")]
		public bool ShowMdiSystemMenu
		{
			get
			{
				return this.xc6b99210da758595;
			}
			set
			{
				this.xc6b99210da758595 = value;
				if (this.x602659a62fba3dc7)
				{
					base.xcf42ad4a4f3fcbf6();
				}
			}
		}

		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x060002EC RID: 748 RVA: 0x0000EE7C File Offset: 0x0000DE7C
		// (set) Token: 0x060002ED RID: 749 RVA: 0x0000EE84 File Offset: 0x0000DE84
		[DefaultValue(typeof(MenuBar.MdiButtonDisplayMode), "All")]
		[Description("Indicates which mdi buttons will be displayed when an mdi child form is maximized.")]
		[Category("Appearance")]
		public MenuBar.MdiButtonDisplayMode MdiButtonDisplay
		{
			get
			{
				return this._xbb10bdab994fc008;
			}
			set
			{
				this._xbb10bdab994fc008 = value;
				if (this.x602659a62fba3dc7)
				{
					base.xcf42ad4a4f3fcbf6();
				}
			}
		}

		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x060002EE RID: 750 RVA: 0x0000EE9C File Offset: 0x0000DE9C
		// (set) Token: 0x060002EF RID: 751 RVA: 0x0000EEA4 File Offset: 0x0000DEA4
		[Browsable(false)]
		public Form OwnerForm
		{
			get
			{
				return this._x9492ad63ba3e62cf;
			}
			set
			{
				if (value == this._x9492ad63ba3e62cf)
				{
					return;
				}
				if (this._x9492ad63ba3e62cf != null && !base.DesignMode)
				{
					this._x9492ad63ba3e62cf.MdiChildActivate -= this.x02c0e44e1901f23e;
					this._x3c493e27923c491c.Dispose();
				}
				this._x9492ad63ba3e62cf = value;
				this.x0c43e97df9f37461.x9b136c277ef34154 = value;
				this.xa5b485ae103026e5.OwnerForm = value;
				if (this._x9492ad63ba3e62cf != null && !base.DesignMode)
				{
					this._x9492ad63ba3e62cf.MdiChildActivate += this.x02c0e44e1901f23e;
					this._x3c493e27923c491c = new MenuBar.xb92ba0a6ca727c50(this._x9492ad63ba3e62cf, this);
				}
			}
		}

		// Token: 0x060002F0 RID: 752 RVA: 0x0000EF48 File Offset: 0x0000DF48
		private void x02c0e44e1901f23e(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			if (this.x602659a62fba3dc7 && this.xf630f2d01cda5794 != null)
			{
				this.xf630f2d01cda5794.Invalidate();
			}
			SandBarManager.UndoMerge(this);
			if (base.AllowMerge && this.OwnerForm != null && this.OwnerForm.ActiveMdiChild != null)
			{
				MenuBar menuBar = null;
				foreach (object obj in this.OwnerForm.ActiveMdiChild.Controls)
				{
					Control control = (Control)obj;
					if (control is MenuBar && ((MenuBar)control).AllowMerge)
					{
						menuBar = (MenuBar)control;
						break;
					}
				}
				if (menuBar != null)
				{
					SandBarManager.Merge(menuBar, this);
				}
			}
		}

		// Token: 0x060002F1 RID: 753 RVA: 0x0000F024 File Offset: 0x0000E024
		private bool x00d1a3323b8020d8(Form x0078185e1040c523)
		{
			if (x0078185e1040c523.MdiChildren.Length == 0)
			{
				return false;
			}
			foreach (Form form in x0078185e1040c523.MdiChildren)
			{
				if (form.Visible)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060002F2 RID: 754 RVA: 0x0000F068 File Offset: 0x0000E068
		private void xe7d491b7e8f35c6a(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			bool flag = this.x00d1a3323b8020d8(this.OwnerForm);
			if (flag)
			{
				flag = false;
				foreach (Form form in this.OwnerForm.MdiChildren)
				{
					if (false)
					{
						goto IL_4A;
					}
					if (form.WindowState == FormWindowState.Maximized)
					{
						flag = true;
						break;
					}
				}
			}
			if (flag == this.x602659a62fba3dc7)
			{
				return;
			}
			this.x602659a62fba3dc7 = flag;
			if (!this.x602659a62fba3dc7)
			{
				goto IL_E4;
			}
			IL_4A:
			if (this.xf630f2d01cda5794 == null)
			{
				this.xf630f2d01cda5794 = new MenuBarItem();
				this.xf630f2d01cda5794.SetToolbar(this);
				this.x1b6439355c431111 = new x4c834b893c51f017(ToolBarGlyphType.Minimize);
				this.x1b6439355c431111.SetToolbar(this);
				this.x1b6439355c431111.ToolTipText = SandBarLanguage.MinimizeWindowText;
				this.x0abc55e6ce1d8aed = new x4c834b893c51f017(ToolBarGlyphType.Restore);
				this.x0abc55e6ce1d8aed.SetToolbar(this);
				this.x0abc55e6ce1d8aed.ToolTipText = SandBarLanguage.RestoreWindowText;
				this.x26e80f23e22a05ae = new x4c834b893c51f017(ToolBarGlyphType.Close);
				this.x26e80f23e22a05ae.SetToolbar(this);
				this.x26e80f23e22a05ae.ToolTipText = SandBarLanguage.CloseWindowText;
			}
			IL_E4:
			base.xcf42ad4a4f3fcbf6();
		}

		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x060002F3 RID: 755 RVA: 0x0000F18C File Offset: 0x0000E18C
		// (set) Token: 0x060002F4 RID: 756 RVA: 0x0000F194 File Offset: 0x0000E194
		public override ISite Site
		{
			get
			{
				return base.Site;
			}
			set
			{
				base.Site = value;
				if (value != null)
				{
					IDesignerHost designerHost = (IDesignerHost)this.GetService(typeof(IDesignerHost));
					if (designerHost != null && designerHost.RootComponent is Form)
					{
						this.OwnerForm = (Form)designerHost.RootComponent;
					}
				}
			}
		}

		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x060002F5 RID: 757 RVA: 0x0000F1E4 File Offset: 0x0000E1E4
		// (set) Token: 0x060002F6 RID: 758 RVA: 0x0000F1EC File Offset: 0x0000E1EC
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public ShortcutListener ShortcutListener
		{
			get
			{
				return this.xa5b485ae103026e5;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException();
				}
				this.xa5b485ae103026e5.Dispose();
				this.xa5b485ae103026e5 = value;
				this.xa5b485ae103026e5.UpdateAcceleratorTable(this);
			}
		}

		// Token: 0x060002F7 RID: 759 RVA: 0x0000F218 File Offset: 0x0000E218
		protected override void OnDoubleClick(EventArgs e)
		{
			Point pt = base.PointToClient(Cursor.Position);
			if (this.x602659a62fba3dc7 && this.ShowMdiSystemMenu && this.xf630f2d01cda5794.ButtonBounds.Contains(pt) && this.OwnerForm.ActiveMdiChild != null)
			{
				this.OwnerForm.ActiveMdiChild.Close();
				return;
			}
			base.OnDoubleClick(e);
		}

		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x060002F8 RID: 760 RVA: 0x0000F27C File Offset: 0x0000E27C
		// (set) Token: 0x060002F9 RID: 761 RVA: 0x0000F284 File Offset: 0x0000E284
		[Category("Appearance")]
		[DefaultValue(true)]
		[Description("Indicates whether keyboard mnemonics are always shown on the menu bar.")]
		public bool AlwaysShowMnemonics
		{
			get
			{
				return this._x0e4e97920f5cf62a;
			}
			set
			{
				this._x0e4e97920f5cf62a = value;
				base.Invalidate();
			}
		}

		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x060002FA RID: 762 RVA: 0x0000F294 File Offset: 0x0000E294
		public override Type[] DesignableTypes
		{
			get
			{
				return new Type[]
				{
					typeof(MenuBarItem),
					typeof(ContextMenuBarItem),
					typeof(ComboBoxItem)
				};
			}
		}

		// Token: 0x170000DA RID: 218
		// (get) Token: 0x060002FB RID: 763 RVA: 0x0000F2D0 File Offset: 0x0000E2D0
		// (set) Token: 0x060002FC RID: 764 RVA: 0x0000F2D8 File Offset: 0x0000E2D8
		[DefaultValue(true)]
		public override bool AllowRightToLeft
		{
			get
			{
				return base.AllowRightToLeft;
			}
			set
			{
				base.AllowRightToLeft = value;
			}
		}

		// Token: 0x170000DB RID: 219
		// (get) Token: 0x060002FD RID: 765 RVA: 0x0000F2E4 File Offset: 0x0000E2E4
		// (set) Token: 0x060002FE RID: 766 RVA: 0x0000F2E8 File Offset: 0x0000E2E8
		[Browsable(false)]
		[DefaultValue(false)]
		public override bool DrawActionsButton
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		// Token: 0x060002FF RID: 767 RVA: 0x0000F2EC File Offset: 0x0000E2EC
		private void xc4c02af6a465758f()
		{
			MenuButtonItem menuButtonItem = new MenuButtonItem(SandBarLanguage.RestoreMenuText);
			menuButtonItem.Image = Image.FromStream(typeof(MenuBar).Assembly.GetManifestResourceStream("TD.SandBar.Resources.restore.gif"));
			menuButtonItem.Enabled = (this.MdiButtonDisplay == MenuBar.MdiButtonDisplayMode.All);
			MenuButtonItem menuButtonItem2 = new MenuButtonItem(SandBarLanguage.MoveMenuText);
			menuButtonItem2.Enabled = false;
			MenuButtonItem menuButtonItem3 = new MenuButtonItem(SandBarLanguage.SizeMenuText);
			menuButtonItem3.Enabled = false;
			MenuButtonItem menuButtonItem4 = new MenuButtonItem(SandBarLanguage.MinimizeMenuText);
			menuButtonItem4.Image = Image.FromStream(typeof(MenuBar).Assembly.GetManifestResourceStream("TD.SandBar.Resources.minimize.gif"));
			MenuButtonItem menuButtonItem5;
			do
			{
				menuButtonItem4.Enabled = (this.MdiButtonDisplay == MenuBar.MdiButtonDisplayMode.All);
				menuButtonItem5 = new MenuButtonItem(SandBarLanguage.MaximizeMenuText);
				menuButtonItem5.Enabled = false;
				menuButtonItem5.Image = Image.FromStream(typeof(MenuBar).Assembly.GetManifestResourceStream("TD.SandBar.Resources.maximize.gif"));
			}
			while (-1 == 0);
			MenuButtonItem menuButtonItem6 = new MenuButtonItem(SandBarLanguage.CloseMenuText);
			menuButtonItem6.Image = Image.FromStream(typeof(MenuBar).Assembly.GetManifestResourceStream("TD.SandBar.Resources.close.gif"));
			menuButtonItem6.Enabled = (this.MdiButtonDisplay != MenuBar.MdiButtonDisplayMode.None);
			this.xf630f2d01cda5794.Items.AddRange(new MenuButtonItem[]
			{
				menuButtonItem,
				menuButtonItem2,
				menuButtonItem3,
				menuButtonItem4,
				menuButtonItem5,
				menuButtonItem6
			});
			menuButtonItem6.BeginGroup = true;
			MenuButtonItem menuButtonItem7 = this.xf630f2d01cda5794.Show(this, new Point(this.xf630f2d01cda5794.ButtonBounds.Left, this.xf630f2d01cda5794.ButtonBounds.Bottom));
			menuButtonItem.Image.Dispose();
			menuButtonItem.Dispose();
			menuButtonItem2.Dispose();
			menuButtonItem3.Dispose();
			menuButtonItem4.Image.Dispose();
			menuButtonItem4.Dispose();
			menuButtonItem5.Image.Dispose();
			menuButtonItem5.Dispose();
			menuButtonItem6.Image.Dispose();
			menuButtonItem6.Dispose();
			if (this.OwnerForm.ActiveMdiChild != null)
			{
				if (menuButtonItem7 == menuButtonItem)
				{
					this.OwnerForm.ActiveMdiChild.WindowState = FormWindowState.Normal;
					return;
				}
				if (menuButtonItem7 == menuButtonItem4)
				{
					this.OwnerForm.ActiveMdiChild.WindowState = FormWindowState.Minimized;
					return;
				}
				if (menuButtonItem7 == menuButtonItem6)
				{
					this.OwnerForm.ActiveMdiChild.Close();
				}
			}
		}

		// Token: 0x06000300 RID: 768 RVA: 0x0000F55C File Offset: 0x0000E55C
		protected override void OnMouseDown(MouseEventArgs e)
		{
			if (this.x602659a62fba3dc7 && this.ShowMdiSystemMenu && this.xf630f2d01cda5794.ButtonBounds.Contains(e.X, e.Y))
			{
				this.xc4c02af6a465758f();
				return;
			}
			base.OnMouseDown(e);
		}

		// Token: 0x06000301 RID: 769 RVA: 0x0000F5A8 File Offset: 0x0000E5A8
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				this.xa5b485ae103026e5.Dispose();
				this.x0c43e97df9f37461.x9b136c277ef34154 = null;
				if (this.xf630f2d01cda5794 != null)
				{
					this.xf630f2d01cda5794.Dispose();
					this.x26e80f23e22a05ae.Dispose();
					this.x1b6439355c431111.Dispose();
					this.x0abc55e6ce1d8aed.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000302 RID: 770 RVA: 0x0000F60C File Offset: 0x0000E60C
		bool IExtenderProvider.x6a9b263f96f9fa9e(object x3eeaf73dc27b314c)
		{
			return x3eeaf73dc27b314c is Control || x3eeaf73dc27b314c is NotifyIcon;
		}

		// Token: 0x06000303 RID: 771 RVA: 0x0000F624 File Offset: 0x0000E624
		internal void xe9df898cfdc77d97(Control x43bec302f92080b9, Point x6b2bb9f943411698, bool xc8051b100df41d07)
		{
			MenuBarItem menuBarItem = (MenuBarItem)this.x241399f44d8db343[x43bec302f92080b9];
			menuBarItem.x19ff15e843484593(x43bec302f92080b9, x6b2bb9f943411698, xc8051b100df41d07);
		}

		// Token: 0x06000304 RID: 772 RVA: 0x0000F650 File Offset: 0x0000E650
		private void x1b26f8da94258419(object xe0292b9ed559da7d, MouseEventArgs xfbf34718e704c6bc)
		{
			if (xfbf34718e704c6bc.Button == MouseButtons.Right)
			{
				MenuBarItem menuBarItem = (MenuBarItem)this.x241399f44d8db343[(NotifyIcon)xe0292b9ed559da7d];
				menuBarItem.ShowIndependent(Cursor.Position);
			}
		}

		// Token: 0x06000305 RID: 773 RVA: 0x0000F690 File Offset: 0x0000E690
		[Category("Behavior")]
		[DefaultValue(typeof(MenuBarItem), null)]
		public MenuBarItem GetSandBarContextMenu(NotifyIcon icon)
		{
			if (this.x241399f44d8db343.Contains(icon))
			{
				return (MenuBarItem)this.x241399f44d8db343[icon];
			}
			return null;
		}

		// Token: 0x06000306 RID: 774 RVA: 0x0000F6B4 File Offset: 0x0000E6B4
		public void SetSandBarContextMenu(NotifyIcon icon, MenuBarItem value)
		{
			if (icon == null)
			{
				throw new ArgumentNullException("icon");
			}
			if (this.x241399f44d8db343.Contains(icon) && value == null)
			{
				icon.MouseUp -= this.x1b26f8da94258419;
			}
			this.x241399f44d8db343[icon] = value;
			if (value == null)
			{
				this.x241399f44d8db343.Remove(icon);
			}
			if (value != null && !base.DesignMode)
			{
				icon.MouseUp += this.x1b26f8da94258419;
			}
		}

		// Token: 0x06000307 RID: 775 RVA: 0x0000F72C File Offset: 0x0000E72C
		[DisplayName("SandBarMenu")]
		[DefaultValue(typeof(MenuBarItem), null)]
		[Category("Behavior")]
		public MenuBarItem GetSandBarMenu(Control control)
		{
			if (this.x241399f44d8db343.Contains(control))
			{
				return (MenuBarItem)this.x241399f44d8db343[control];
			}
			return null;
		}

		// Token: 0x06000308 RID: 776 RVA: 0x0000F750 File Offset: 0x0000E750
		public void SetSandBarMenu(Control control, MenuBarItem value)
		{
			if (control == null)
			{
				throw new ArgumentNullException("control");
			}
			if (this.x83edece623ddc642.Contains(control) && value == null)
			{
				x209ff4cb51b91bfb x209ff4cb51b91bfb = (x209ff4cb51b91bfb)this.x83edece623ddc642[control];
				x209ff4cb51b91bfb.Dispose();
				this.x83edece623ddc642.Remove(control);
			}
			this.x241399f44d8db343[control] = value;
			if (value == null)
			{
				this.x241399f44d8db343.Remove(control);
			}
			if (value != null && !base.DesignMode && !this.x83edece623ddc642.Contains(control))
			{
				x209ff4cb51b91bfb x209ff4cb51b91bfb = new x209ff4cb51b91bfb(this, control);
				this.x83edece623ddc642.Add(control, x209ff4cb51b91bfb);
			}
		}

		// Token: 0x06000309 RID: 777 RVA: 0x0000F7EC File Offset: 0x0000E7EC
		protected override void OnHandleCreated(EventArgs e)
		{
			base.OnHandleCreated(e);
			if (!base.DesignMode)
			{
				this.xa5b485ae103026e5.Listening = true;
			}
		}

		// Token: 0x170000DC RID: 220
		// (get) Token: 0x0600030A RID: 778 RVA: 0x0000F80C File Offset: 0x0000E80C
		protected internal override int LeftPadding
		{
			get
			{
				if (this.x602659a62fba3dc7 && this.ShowMdiSystemMenu)
				{
					return 24;
				}
				return 0;
			}
		}

		// Token: 0x170000DD RID: 221
		// (get) Token: 0x0600030B RID: 779 RVA: 0x0000F824 File Offset: 0x0000E824
		protected internal override int RightPadding
		{
			get
			{
				if (this.x602659a62fba3dc7)
				{
					switch (this._xbb10bdab994fc008)
					{
					case MenuBar.MdiButtonDisplayMode.All:
						return SystemInformation.ToolWindowCaptionButtonSize.Width * 3 + 3;
					case MenuBar.MdiButtonDisplayMode.CloseOnly:
						return SystemInformation.ToolWindowCaptionButtonSize.Width + 3;
					}
					return 0;
				}
				return 0;
			}
		}

		// Token: 0x0600030C RID: 780 RVA: 0x0000F87C File Offset: 0x0000E87C
		protected override void OnPaintBackground(PaintEventArgs pevent)
		{
			base.WorkingRenderer.DrawMenuBarBackground(this, pevent.Graphics, base.ClientRectangle, this.Flow == ToolBarLayout.Vertical);
		}

		// Token: 0x0600030D RID: 781 RVA: 0x0000F8A0 File Offset: 0x0000E8A0
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			if (this.x602659a62fba3dc7 && this.ShowMdiSystemMenu)
			{
				this.x9f591d556f17eb34(e.Graphics);
			}
		}

		// Token: 0x170000DE RID: 222
		// (get) Token: 0x0600030E RID: 782 RVA: 0x0000F8C8 File Offset: 0x0000E8C8
		internal override ToolbarItemBase[] x0366497b06ec1dfe
		{
			get
			{
				if (!this.x602659a62fba3dc7)
				{
					return base.x0366497b06ec1dfe;
				}
				if (this.MdiButtonDisplay == MenuBar.MdiButtonDisplayMode.All)
				{
					return new ToolbarItemBase[]
					{
						this.x1b6439355c431111,
						this.x0abc55e6ce1d8aed,
						this.x26e80f23e22a05ae
					};
				}
				if (this.MdiButtonDisplay == MenuBar.MdiButtonDisplayMode.CloseOnly)
				{
					return new ToolbarItemBase[]
					{
						this.x26e80f23e22a05ae
					};
				}
				return new ToolbarItemBase[0];
			}
		}

		// Token: 0x0600030F RID: 783 RVA: 0x0000F934 File Offset: 0x0000E934
		internal override void x1a2b7835c4f6410b(IToolBarRenderer x38870620fd380a6b, bool xa092001467a0ab7b)
		{
			base.x1a2b7835c4f6410b(x38870620fd380a6b, xa092001467a0ab7b);
			while (this.x602659a62fba3dc7)
			{
				int num = SystemInformation.ToolWindowCaptionButtonSize.Width - 1;
				int num2 = num + 1;
				int num3;
				if (base.Situation == ToolBarSituation.Contained && this.Movable)
				{
					num3 = 12;
				}
				else
				{
					num3 = 6;
				}
				if (xa092001467a0ab7b)
				{
					this.xf630f2d01cda5794.ApplyLayout(new Rectangle(base.ClientRectangle.Width / 2 - 8, num3, 16, 16), null, false, false);
				}
				else
				{
					this.xf630f2d01cda5794.ApplyLayout(new Rectangle(num3, base.ClientRectangle.Height / 2 - 8, 16, 16), null, false, false);
				}
				int num4;
				if (xa092001467a0ab7b)
				{
					num4 = base.ClientRectangle.Width / 2 - num / 2;
				}
				else
				{
					num4 = base.ClientRectangle.Height / 2 - num / 2;
				}
				if (this._xbb10bdab994fc008 == MenuBar.MdiButtonDisplayMode.All)
				{
					if (xa092001467a0ab7b)
					{
						num3 = base.ClientRectangle.Height - 3 - num2 * 3;
						this.x1b6439355c431111.ApplyLayout(new Rectangle(num4, num3, num, num), null, false, false);
					}
					else
					{
						num3 = base.ClientRectangle.Width - 3 - num2 * 3;
						this.x1b6439355c431111.ApplyLayout(new Rectangle(num3, num4, num, num), null, false, false);
					}
					if (xa092001467a0ab7b)
					{
						num3 = base.ClientRectangle.Height - 3 - num2 * 2;
						this.x0abc55e6ce1d8aed.ApplyLayout(new Rectangle(num4, num3, num, num), null, false, false);
					}
					else
					{
						num3 = base.ClientRectangle.Width - 3 - num2 * 2;
						this.x0abc55e6ce1d8aed.ApplyLayout(new Rectangle(num3, num4, num, num), null, false, false);
					}
				}
				if (this._xbb10bdab994fc008 != MenuBar.MdiButtonDisplayMode.All)
				{
					bool flag = (uint)num4 + (uint)num4 < 0U;
					if (flag)
					{
						continue;
					}
					if (this._xbb10bdab994fc008 != MenuBar.MdiButtonDisplayMode.CloseOnly)
					{
						break;
					}
				}
				if (xa092001467a0ab7b)
				{
					num3 = base.ClientRectangle.Height - 3 - num2;
					this.x26e80f23e22a05ae.ApplyLayout(new Rectangle(num4, num3, num, num), null, false, false);
					return;
				}
				num3 = base.ClientRectangle.Width - 3 - num2;
				this.x26e80f23e22a05ae.ApplyLayout(new Rectangle(num3, num4, num, num), null, false, false);
				break;
			}
		}

		// Token: 0x06000310 RID: 784 RVA: 0x0000FB88 File Offset: 0x0000EB88
		protected override void OnItemRelease(ToolbarItemBase item, Point position)
		{
			if (item == this.x1b6439355c431111 && this.x602659a62fba3dc7)
			{
				this.OwnerForm.ActiveMdiChild.WindowState = FormWindowState.Minimized;
				return;
			}
			if (item == this.x0abc55e6ce1d8aed && this.x602659a62fba3dc7)
			{
				this.OwnerForm.ActiveMdiChild.WindowState = FormWindowState.Normal;
				return;
			}
			if (item == this.x26e80f23e22a05ae && this.x602659a62fba3dc7)
			{
				this.OwnerForm.ActiveMdiChild.Close();
				return;
			}
			base.OnItemRelease(item, position);
		}

		// Token: 0x170000DF RID: 223
		// (get) Token: 0x06000311 RID: 785 RVA: 0x0000FC08 File Offset: 0x0000EC08
		// (set) Token: 0x06000312 RID: 786 RVA: 0x0000FC10 File Offset: 0x0000EC10
		[DefaultValue("Menu Bar")]
		public override string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				base.Text = value;
			}
		}

		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x06000313 RID: 787 RVA: 0x0000FC1C File Offset: 0x0000EC1C
		// (set) Token: 0x06000314 RID: 788 RVA: 0x0000FC24 File Offset: 0x0000EC24
		[DefaultValue(false)]
		public override bool Closable
		{
			get
			{
				return base.Closable;
			}
			set
			{
				base.Closable = value;
			}
		}

		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x06000315 RID: 789 RVA: 0x0000FC30 File Offset: 0x0000EC30
		// (set) Token: 0x06000316 RID: 790 RVA: 0x0000FC38 File Offset: 0x0000EC38
		[DefaultValue(typeof(ToolBarOverflow), "Wrap")]
		public override ToolBarOverflow Overflow
		{
			get
			{
				return base.Overflow;
			}
			set
			{
				base.Overflow = value;
			}
		}

		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x06000317 RID: 791 RVA: 0x0000FC44 File Offset: 0x0000EC44
		// (set) Token: 0x06000318 RID: 792 RVA: 0x0000FC4C File Offset: 0x0000EC4C
		[DefaultValue(true)]
		public override bool Stretch
		{
			get
			{
				return base.Stretch;
			}
			set
			{
				base.Stretch = value;
			}
		}

		// Token: 0x0400011B RID: 283
		private bool _x0e4e97920f5cf62a = true;

		// Token: 0x0400011C RID: 284
		private Hashtable x241399f44d8db343;

		// Token: 0x0400011D RID: 285
		private Hashtable x83edece623ddc642;

		// Token: 0x0400011E RID: 286
		private MenuBar.xb92ba0a6ca727c50 _x3c493e27923c491c;

		// Token: 0x0400011F RID: 287
		private ShortcutListener xa5b485ae103026e5;

		// Token: 0x04000120 RID: 288
		private Form _x9492ad63ba3e62cf;

		// Token: 0x04000121 RID: 289
		private bool x602659a62fba3dc7;

		// Token: 0x04000122 RID: 290
		private MenuBar.MdiButtonDisplayMode _xbb10bdab994fc008 = MenuBar.MdiButtonDisplayMode.All;

		// Token: 0x04000123 RID: 291
		private ButtonItem x1b6439355c431111;

		// Token: 0x04000124 RID: 292
		private ButtonItem x0abc55e6ce1d8aed;

		// Token: 0x04000125 RID: 293
		private ButtonItem x26e80f23e22a05ae;

		// Token: 0x04000126 RID: 294
		private MenuBarItem xf630f2d01cda5794;

		// Token: 0x04000127 RID: 295
		private x67a479f649e0eafe x0c43e97df9f37461;

		// Token: 0x04000128 RID: 296
		private bool xc6b99210da758595 = true;

		// Token: 0x02000039 RID: 57
		private class xb92ba0a6ca727c50 : NativeWindow, IDisposable
		{
			// Token: 0x06000319 RID: 793 RVA: 0x0000FC58 File Offset: 0x0000EC58
			public xb92ba0a6ca727c50(Form ownerForm, MenuBar menuBar)
			{
				this.x9492ad63ba3e62cf = ownerForm;
				this.x49a2aa22606cd919 = menuBar;
				ownerForm.HandleCreated += this.xecbd32f93d73d505;
				ownerForm.HandleDestroyed += this.x2e1fad24746b5079;
				if (ownerForm.IsHandleCreated)
				{
					base.AssignHandle(ownerForm.Handle);
				}
			}

			// Token: 0x0600031A RID: 794 RVA: 0x0000FCB4 File Offset: 0x0000ECB4
			private void xecbd32f93d73d505(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
			{
				base.AssignHandle(this.x9492ad63ba3e62cf.Handle);
			}

			// Token: 0x0600031B RID: 795 RVA: 0x0000FCC8 File Offset: 0x0000ECC8
			private void x2e1fad24746b5079(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
			{
				this.ReleaseHandle();
			}

			// Token: 0x0600031C RID: 796 RVA: 0x0000FCD0 File Offset: 0x0000ECD0
			protected override void WndProc(ref Message m)
			{
				if (m.Msg == 274 && m.WParam.ToInt32() == 61696 && m.LParam.ToInt32() == 0 && this.x49a2aa22606cd919.Enabled)
				{
					this.x49a2aa22606cd919.xb1be88bbed869d11();
					m.Result = IntPtr.Zero;
					return;
				}
				base.WndProc(ref m);
			}

			// Token: 0x0600031D RID: 797 RVA: 0x0000FD3C File Offset: 0x0000ED3C
			public void Dispose()
			{
				if (base.Handle != IntPtr.Zero)
				{
					this.ReleaseHandle();
				}
			}

			// Token: 0x04000129 RID: 297
			private Form x9492ad63ba3e62cf;

			// Token: 0x0400012A RID: 298
			private MenuBar x49a2aa22606cd919;
		}

		// Token: 0x02000059 RID: 89
		public enum MdiButtonDisplayMode
		{
			// Token: 0x040001D0 RID: 464
			None,
			// Token: 0x040001D1 RID: 465
			All,
			// Token: 0x040001D2 RID: 466
			CloseOnly
		}
	}
}
