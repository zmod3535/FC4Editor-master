using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using TD.Util;

namespace TD.SandBar
{
	// Token: 0x0200000B RID: 11
	[DefaultEvent("ButtonClick")]
	[Designer("TD.SandBar.Design.ToolBarDesigner, SandBar.Design, Version=1.0.0.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3")]
	public class ToolBar : Control, IPopupMenuHost, IToolBarItemBaseCollectionHost
	{
		// Token: 0x14000003 RID: 3
		// (add) Token: 0x06000078 RID: 120 RVA: 0x00004154 File Offset: 0x00003154
		// (remove) Token: 0x06000079 RID: 121 RVA: 0x00004170 File Offset: 0x00003170
		public event EventHandler EnterMenuLoop
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.x0ef5a9135fb0040c = (EventHandler)Delegate.Combine(this.x0ef5a9135fb0040c, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.x0ef5a9135fb0040c = (EventHandler)Delegate.Remove(this.x0ef5a9135fb0040c, value);
			}
		}

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x0600007A RID: 122 RVA: 0x0000418C File Offset: 0x0000318C
		// (remove) Token: 0x0600007B RID: 123 RVA: 0x000041A8 File Offset: 0x000031A8
		public event EventHandler ExitMenuLoop
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.xf1ebf4d370594337 = (EventHandler)Delegate.Combine(this.xf1ebf4d370594337, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.xf1ebf4d370594337 = (EventHandler)Delegate.Remove(this.xf1ebf4d370594337, value);
			}
		}

		// Token: 0x14000005 RID: 5
		// (add) Token: 0x0600007C RID: 124 RVA: 0x000041C4 File Offset: 0x000031C4
		// (remove) Token: 0x0600007D RID: 125 RVA: 0x000041E0 File Offset: 0x000031E0
		public event ToolBar.ButtonClickEventHandler ButtonClick
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.x7ce50b15d48de9a6 = (ToolBar.ButtonClickEventHandler)Delegate.Combine(this.x7ce50b15d48de9a6, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.x7ce50b15d48de9a6 = (ToolBar.ButtonClickEventHandler)Delegate.Remove(this.x7ce50b15d48de9a6, value);
			}
		}

		// Token: 0x14000006 RID: 6
		// (add) Token: 0x0600007E RID: 126 RVA: 0x000041FC File Offset: 0x000031FC
		// (remove) Token: 0x0600007F RID: 127 RVA: 0x00004218 File Offset: 0x00003218
		public event EventHandler CustomizeActionsButtonMenu
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.xc426734a00cfd031 = (EventHandler)Delegate.Combine(this.xc426734a00cfd031, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.xc426734a00cfd031 = (EventHandler)Delegate.Remove(this.xc426734a00cfd031, value);
			}
		}

		// Token: 0x06000080 RID: 128 RVA: 0x00004234 File Offset: 0x00003234
		public ToolBar()
		{
			this.x20aee281977480cf();
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000081 RID: 129 RVA: 0x000042B4 File Offset: 0x000032B4
		// (set) Token: 0x06000082 RID: 130 RVA: 0x000042BC File Offset: 0x000032BC
		[DefaultValue("Tool Bar")]
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

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000083 RID: 131 RVA: 0x000042C8 File Offset: 0x000032C8
		// (set) Token: 0x06000084 RID: 132 RVA: 0x000042D0 File Offset: 0x000032D0
		[Browsable(false)]
		public override Color BackColor
		{
			get
			{
				return base.BackColor;
			}
			set
			{
				base.BackColor = value;
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000085 RID: 133 RVA: 0x000042DC File Offset: 0x000032DC
		// (set) Token: 0x06000086 RID: 134 RVA: 0x000042E4 File Offset: 0x000032E4
		[Browsable(false)]
		public override Image BackgroundImage
		{
			get
			{
				return base.BackgroundImage;
			}
			set
			{
				base.BackgroundImage = value;
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000087 RID: 135 RVA: 0x000042F0 File Offset: 0x000032F0
		// (set) Token: 0x06000088 RID: 136 RVA: 0x000042F8 File Offset: 0x000032F8
		[Browsable(false)]
		public override AnchorStyles Anchor
		{
			get
			{
				return base.Anchor;
			}
			set
			{
				base.Anchor = value;
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x06000089 RID: 137 RVA: 0x00004304 File Offset: 0x00003304
		// (set) Token: 0x0600008A RID: 138 RVA: 0x0000430C File Offset: 0x0000330C
		[DefaultValue(typeof(DockStyle), "Top")]
		public override DockStyle Dock
		{
			get
			{
				return base.Dock;
			}
			set
			{
				base.Dock = value;
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x0600008B RID: 139 RVA: 0x00004318 File Offset: 0x00003318
		// (set) Token: 0x0600008C RID: 140 RVA: 0x00004320 File Offset: 0x00003320
		[Browsable(false)]
		public override Color ForeColor
		{
			get
			{
				return base.ForeColor;
			}
			set
			{
				base.ForeColor = value;
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x0600008D RID: 141 RVA: 0x0000432C File Offset: 0x0000332C
		[Browsable(false)]
		public virtual Type[] DesignableTypes
		{
			get
			{
				return new Type[]
				{
					typeof(ButtonItem),
					typeof(ComboBoxItem),
					typeof(DropDownMenuItem),
					typeof(LabelItem)
				};
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x0600008E RID: 142 RVA: 0x00004378 File Offset: 0x00003378
		// (set) Token: 0x0600008F RID: 143 RVA: 0x00004380 File Offset: 0x00003380
		[DefaultValue(false)]
		[Category("Merging")]
		[Description("Indicates whether the MenuBar will allow itself to be merged or allow another MenuBar to merge with it.")]
		public bool AllowMerge
		{
			get
			{
				return this.xd81a36bac1bd4fad;
			}
			set
			{
				this.xd81a36bac1bd4fad = value;
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x06000090 RID: 144 RVA: 0x0000438C File Offset: 0x0000338C
		// (set) Token: 0x06000091 RID: 145 RVA: 0x00004394 File Offset: 0x00003394
		internal xf00666a2552f1592 x4fd1b19af748ed20
		{
			get
			{
				return this.x08574a93c960045e;
			}
			set
			{
				this.x08574a93c960045e = value;
			}
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x06000092 RID: 146 RVA: 0x000043A0 File Offset: 0x000033A0
		[Browsable(false)]
		public ToolBar MergedToolBar
		{
			get
			{
				return this.x60222503ecf769d3;
			}
		}

		// Token: 0x06000093 RID: 147 RVA: 0x000043A8 File Offset: 0x000033A8
		internal void x5937e70b1b3ec5d7(ToolBar x169279a87b6b72b2)
		{
			this.x60222503ecf769d3 = x169279a87b6b72b2;
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x06000094 RID: 148 RVA: 0x000043B4 File Offset: 0x000033B4
		// (set) Token: 0x06000095 RID: 149 RVA: 0x000043BC File Offset: 0x000033BC
		[Description("Indicates whether right to left layout of items in the toolbar is permitted.")]
		[DefaultValue(false)]
		[Category("Item Layout")]
		public virtual bool AllowRightToLeft
		{
			get
			{
				return this.x893e4996ed4f2aeb;
			}
			set
			{
				this.x893e4996ed4f2aeb = value;
				this.xcf42ad4a4f3fcbf6();
			}
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x06000096 RID: 150 RVA: 0x000043CC File Offset: 0x000033CC
		// (set) Token: 0x06000097 RID: 151 RVA: 0x000043D4 File Offset: 0x000033D4
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Obsolete("Use the Stretch property on the item in question instead.")]
		[Browsable(false)]
		public ToolbarItemBase StretchItem
		{
			get
			{
				return this.xd1a551a498add963;
			}
			set
			{
				if (this.xd1a551a498add963 != null)
				{
					this.xd1a551a498add963.Stretch = false;
				}
				this.xd1a551a498add963 = value;
				if (this.xd1a551a498add963 != null)
				{
					this.xd1a551a498add963.Stretch = true;
				}
			}
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x06000098 RID: 152 RVA: 0x00004408 File Offset: 0x00003408
		// (set) Token: 0x06000099 RID: 153 RVA: 0x00004410 File Offset: 0x00003410
		[Category("Item Layout")]
		[Description("Indicates whether the last item on the toolbar is flipped to the far side of the button space.")]
		[DefaultValue(false)]
		public bool FlipLastItem
		{
			get
			{
				return this.xae19c2cc7f3edb97;
			}
			set
			{
				this.xae19c2cc7f3edb97 = value;
				this.xcf42ad4a4f3fcbf6();
			}
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x0600009A RID: 154 RVA: 0x00004420 File Offset: 0x00003420
		// (set) Token: 0x0600009B RID: 155 RVA: 0x00004428 File Offset: 0x00003428
		[DefaultValue(typeof(TopLevelMenuItemBase.MenuAnimation), "System")]
		[Description("Indicates the animation performed on menu items as they are displayed.")]
		[Category("Behavior")]
		public TopLevelMenuItemBase.MenuAnimation MenuAnimation
		{
			get
			{
				return this.x95be56bdc2cd6bd1;
			}
			set
			{
				this.x95be56bdc2cd6bd1 = value;
			}
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x0600009C RID: 156 RVA: 0x00004434 File Offset: 0x00003434
		// (set) Token: 0x0600009D RID: 157 RVA: 0x0000443C File Offset: 0x0000343C
		[DefaultValue(false)]
		[Category("Appearance")]
		[Description("Indicates whether keyboard shortcuts are shown in tooltips. Keyboard shortcuts are retreived from the menu associated with a button.")]
		public bool ShowShortcutsInToolTips
		{
			get
			{
				return this._x9f56c704356128c2;
			}
			set
			{
				this._x9f56c704356128c2 = value;
			}
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x0600009E RID: 158 RVA: 0x00004448 File Offset: 0x00003448
		// (set) Token: 0x0600009F RID: 159 RVA: 0x00004458 File Offset: 0x00003458
		[Category("Appearance")]
		[DefaultValue(true)]
		[Description("Indicates whether the Add/Remove buttons option will be visible in the actions menu.")]
		public bool AddRemoveButtonsVisible
		{
			get
			{
				return this.xab98d56e18146fb2.x27c8fc232c1d233e;
			}
			set
			{
				this.xab98d56e18146fb2.x27c8fc232c1d233e = value;
			}
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x060000A0 RID: 160 RVA: 0x00004468 File Offset: 0x00003468
		// (set) Token: 0x060000A1 RID: 161 RVA: 0x00004470 File Offset: 0x00003470
		[Category("Docking")]
		[Description("The minimum desired size of the toolbar when floating.")]
		[DefaultValue(typeof(Size), "60,30")]
		public virtual Size MinimumFloatingSize
		{
			get
			{
				return this.x09af322dc5e0b969;
			}
			set
			{
				this.x09af322dc5e0b969 = value;
				if (this.Situation == ToolBarSituation.Floating)
				{
					((x502bf86f15e12152)base.Parent).xe9433ca9139ae2b2();
				}
			}
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x060000A2 RID: 162 RVA: 0x00004494 File Offset: 0x00003494
		// (set) Token: 0x060000A3 RID: 163 RVA: 0x0000449C File Offset: 0x0000349C
		[Description("The maximum desired size of the toolbar when floating.")]
		[DefaultValue(typeof(Size), "0,0")]
		[Category("Docking")]
		public virtual Size MaximumFloatingSize
		{
			get
			{
				return this.xd903e1624789f810;
			}
			set
			{
				this.xd903e1624789f810 = value;
				if (this.Situation == ToolBarSituation.Floating)
				{
					((x502bf86f15e12152)base.Parent).xe9433ca9139ae2b2();
				}
			}
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x060000A4 RID: 164 RVA: 0x000044C0 File Offset: 0x000034C0
		// (set) Token: 0x060000A5 RID: 165 RVA: 0x000044C8 File Offset: 0x000034C8
		[Category("Docking")]
		[DefaultValue(false)]
		[Description("Indicates whether the toolbar will take up the full extent of its row, where possible.")]
		public virtual bool Stretch
		{
			get
			{
				return this._x4138104f20394708;
			}
			set
			{
				this._x4138104f20394708 = value;
				if (this.Situation == ToolBarSituation.Contained)
				{
					((ToolBarContainer)base.Parent).xeea2f63c63de806c();
				}
			}
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x060000A6 RID: 166 RVA: 0x000044EC File Offset: 0x000034EC
		// (set) Token: 0x060000A7 RID: 167 RVA: 0x000044F4 File Offset: 0x000034F4
		[DefaultValue(true)]
		[Description("Indicates whether the user will be able to dock this toolbar at the left or right of the form.")]
		[Category("Docking")]
		public bool AllowVerticalDock
		{
			get
			{
				return this._x40d287ff78071b64;
			}
			set
			{
				this._x40d287ff78071b64 = value;
			}
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x060000A8 RID: 168 RVA: 0x00004500 File Offset: 0x00003500
		// (set) Token: 0x060000A9 RID: 169 RVA: 0x00004508 File Offset: 0x00003508
		[Category("Docking")]
		[DefaultValue(true)]
		[Description("Indicates whether the user will be able to dock this toolbar at the top or bottom of the form.")]
		public bool AllowHorizontalDock
		{
			get
			{
				return this._xdcf9c56dd44e3777;
			}
			set
			{
				this._xdcf9c56dd44e3777 = value;
			}
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x060000AA RID: 170 RVA: 0x00004514 File Offset: 0x00003514
		// (set) Token: 0x060000AB RID: 171 RVA: 0x0000451C File Offset: 0x0000351C
		[Browsable(false)]
		public Guid Guid
		{
			get
			{
				return this._xb51cd75f17ace1ec;
			}
			set
			{
				this._xb51cd75f17ace1ec = value;
			}
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x060000AC RID: 172 RVA: 0x00004528 File Offset: 0x00003528
		// (set) Token: 0x060000AD RID: 173 RVA: 0x0000453C File Offset: 0x0000353C
		[Description("Indicates how toolbar items that flow off the toolbar's normal width are treated.")]
		[DefaultValue(typeof(ToolBarOverflow), "Chevron")]
		[Category("Item Layout")]
		public virtual ToolBarOverflow Overflow
		{
			get
			{
				if (this.Situation == ToolBarSituation.Floating)
				{
					return ToolBarOverflow.Wrap;
				}
				return this.xdd7ed1da9999fb29;
			}
			set
			{
				this.xdd7ed1da9999fb29 = value;
				this.xcf42ad4a4f3fcbf6();
			}
		}

		// Token: 0x060000AE RID: 174 RVA: 0x0000454C File Offset: 0x0000354C
		private bool ShouldSerializeFlow()
		{
			return this.Situation == ToolBarSituation.Standalone && this.x2612f62f94df47de != ToolBarLayout.Horizontal;
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x060000AF RID: 175 RVA: 0x00004564 File Offset: 0x00003564
		// (set) Token: 0x060000B0 RID: 176 RVA: 0x000045A0 File Offset: 0x000035A0
		[Category("Item Layout")]
		[Description("Indicates how items are laid out within the toolbar.")]
		public virtual ToolBarLayout Flow
		{
			get
			{
				if (this.Situation == ToolBarSituation.Contained)
				{
					if (base.Parent.Dock != DockStyle.Left && base.Parent.Dock != DockStyle.Right)
					{
						return ToolBarLayout.Horizontal;
					}
					return ToolBarLayout.Vertical;
				}
				else
				{
					if (this.Situation == ToolBarSituation.Floating)
					{
						return ToolBarLayout.Horizontal;
					}
					return this.x2612f62f94df47de;
				}
			}
			set
			{
				this.x2612f62f94df47de = value;
				if (this.Situation == ToolBarSituation.Standalone)
				{
					if (this.x2612f62f94df47de == ToolBarLayout.Vertical && (this.Dock == DockStyle.Top || this.Dock == DockStyle.Bottom))
					{
						this.Dock = DockStyle.Left;
						return;
					}
					if (this.x2612f62f94df47de == ToolBarLayout.Horizontal && (this.Dock == DockStyle.Left || this.Dock == DockStyle.Right))
					{
						this.Dock = DockStyle.Top;
						return;
					}
				}
				else
				{
					this.xcf42ad4a4f3fcbf6();
				}
			}
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x060000B1 RID: 177 RVA: 0x00004608 File Offset: 0x00003608
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public bool IsOpen
		{
			get
			{
				if (this.Situation == ToolBarSituation.Floating)
				{
					return base.Parent.Visible || ((x502bf86f15e12152)base.Parent).x36c9bbcb771daf63;
				}
				return base.Visible;
			}
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x0000463C File Offset: 0x0000363C
		protected override void SetVisibleCore(bool value)
		{
			if (this.Situation != ToolBarSituation.Floating)
			{
				base.SetVisibleCore(value);
				return;
			}
			base.SetVisibleCore(value);
			x502bf86f15e12152 x502bf86f15e = (x502bf86f15e12152)base.Parent;
			if (!x502bf86f15e.x460ab163f44a604d.FormHasFocus)
			{
				x502bf86f15e.Hide();
				x502bf86f15e.x36c9bbcb771daf63 = value;
				return;
			}
			if (value)
			{
				x502bf86f15e.x2c6f5ac62ee048e5();
				return;
			}
			x502bf86f15e.Hide();
		}

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x060000B3 RID: 179 RVA: 0x0000469C File Offset: 0x0000369C
		// (set) Token: 0x060000B4 RID: 180 RVA: 0x000046A4 File Offset: 0x000036A4
		[Description("Indicates the line of toolbars in the container that this toolbar will be on.")]
		[DefaultValue(0)]
		[Category("Docking")]
		public virtual int DockLine
		{
			get
			{
				return this.x932e914cea303e55;
			}
			set
			{
				if (this.x932e914cea303e55 != value)
				{
					this.x932e914cea303e55 = value;
					if (this.Situation == ToolBarSituation.Contained)
					{
						((ToolBarContainer)base.Parent).xeea2f63c63de806c();
					}
				}
			}
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x060000B5 RID: 181 RVA: 0x000046D0 File Offset: 0x000036D0
		// (set) Token: 0x060000B6 RID: 182 RVA: 0x000046D8 File Offset: 0x000036D8
		[Category("Docking")]
		[Description("Indicates the offset, in pixels, of this toolbar in the line of toolbars it belongs to.")]
		[DefaultValue(0)]
		public virtual int DockOffset
		{
			get
			{
				return this.x6feecfd1acdf4007;
			}
			set
			{
				if (this.x6feecfd1acdf4007 != value)
				{
					this.x6feecfd1acdf4007 = value;
					if (this.Situation == ToolBarSituation.Contained)
					{
						((ToolBarContainer)base.Parent).xeea2f63c63de806c();
					}
				}
			}
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x060000B7 RID: 183 RVA: 0x00004704 File Offset: 0x00003704
		// (set) Token: 0x060000B8 RID: 184 RVA: 0x00004714 File Offset: 0x00003714
		[Category("Appearance")]
		[Description("Indicates whether an extra, thin button is drawn on the end of the toolbar.")]
		[DefaultValue(true)]
		public virtual bool DrawActionsButton
		{
			get
			{
				return this.xab98d56e18146fb2.Visible;
			}
			set
			{
				this.xab98d56e18146fb2.Visible = value;
				this.xcf42ad4a4f3fcbf6();
			}
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x060000B9 RID: 185 RVA: 0x00004728 File Offset: 0x00003728
		// (set) Token: 0x060000BA RID: 186 RVA: 0x00004730 File Offset: 0x00003730
		[Description("Controls how the text is positioned relative to the image in each button.")]
		[Category("Item Layout")]
		[DefaultValue(typeof(ToolBarTextAlign), "Side")]
		public virtual ToolBarTextAlign TextAlign
		{
			get
			{
				return this._xe4f97a5cc9204c1f;
			}
			set
			{
				this._xe4f97a5cc9204c1f = value;
				this.xcf42ad4a4f3fcbf6();
			}
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x060000BB RID: 187 RVA: 0x00004740 File Offset: 0x00003740
		// (set) Token: 0x060000BC RID: 188 RVA: 0x00004748 File Offset: 0x00003748
		[Description("Indicates whether the ToolBar is resizable by the user.")]
		[DefaultValue(true)]
		[Category("Docking")]
		public bool Resizable
		{
			get
			{
				return this.x8cad996bf8337776;
			}
			set
			{
				this.x8cad996bf8337776 = value;
			}
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x060000BD RID: 189 RVA: 0x00004754 File Offset: 0x00003754
		// (set) Token: 0x060000BE RID: 190 RVA: 0x0000475C File Offset: 0x0000375C
		[Description("Indicates whether the toolbar will display a grab handle and let the user move it within its container.")]
		[DefaultValue(true)]
		[Category("Docking")]
		public virtual bool Movable
		{
			get
			{
				return this._xfd9e8be9c7129364;
			}
			set
			{
				this._xfd9e8be9c7129364 = value;
				this.xcf42ad4a4f3fcbf6();
			}
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x060000BF RID: 191 RVA: 0x0000476C File Offset: 0x0000376C
		// (set) Token: 0x060000C0 RID: 192 RVA: 0x00004774 File Offset: 0x00003774
		[Category("Docking")]
		[DefaultValue(true)]
		[Description("Indicates whether the toolbar will allow the user to tear it out of its container in to a floating state.")]
		public virtual bool Tearable
		{
			get
			{
				return this._x463c7d57d1af6f9e;
			}
			set
			{
				this._x463c7d57d1af6f9e = value;
			}
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x060000C1 RID: 193 RVA: 0x00004780 File Offset: 0x00003780
		// (set) Token: 0x060000C2 RID: 194 RVA: 0x00004788 File Offset: 0x00003788
		[Category("Docking")]
		[DefaultValue(true)]
		[Description("Indicates whether, when floating, the toolbar will display a close button.")]
		public virtual bool Closable
		{
			get
			{
				return this._x6c3086899dc42885;
			}
			set
			{
				this._x6c3086899dc42885 = value;
				if (this.Situation == ToolBarSituation.Floating)
				{
					this.xcf42ad4a4f3fcbf6();
				}
			}
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x060000C3 RID: 195 RVA: 0x000047A0 File Offset: 0x000037A0
		// (set) Token: 0x060000C4 RID: 196 RVA: 0x000047A8 File Offset: 0x000037A8
		[DefaultValue(typeof(ImageList), null)]
		[Category("Appearance")]
		public ImageList ImageList
		{
			get
			{
				return this._x6ec0d1228599f9ae;
			}
			set
			{
				if (this._x6ec0d1228599f9ae != null)
				{
					this._x6ec0d1228599f9ae.RecreateHandle -= this.x6fcab81821bdbaf7;
					this._x6ec0d1228599f9ae.Disposed -= this.xccb154db494aa970;
				}
				this._x6ec0d1228599f9ae = value;
				if (this._x6ec0d1228599f9ae != null)
				{
					this._x6ec0d1228599f9ae.RecreateHandle += this.x6fcab81821bdbaf7;
					this._x6ec0d1228599f9ae.Disposed += this.xccb154db494aa970;
				}
				this.xcf42ad4a4f3fcbf6();
			}
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x00004830 File Offset: 0x00003830
		protected override void ScaleControl(SizeF factor, BoundsSpecified specified)
		{
			base.ScaleControl(factor, specified);
			foreach (object obj in this.Items)
			{
				ToolbarItemBase toolbarItemBase = (ToolbarItemBase)obj;
				ControlContainerItem controlContainerItem = toolbarItemBase as ControlContainerItem;
				if (controlContainerItem != null)
				{
					controlContainerItem.MinimumControlWidth = Convert.ToInt32((float)controlContainerItem.MinimumControlWidth * factor.Width);
				}
			}
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x000048BC File Offset: 0x000038BC
		protected internal virtual void OnButtonClick(ToolBarItemEventArgs e)
		{
			if (this.x7ce50b15d48de9a6 != null)
			{
				this.x7ce50b15d48de9a6(this, e);
			}
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x000048D4 File Offset: 0x000038D4
		protected internal virtual void OnCustomizeActionsButtonMenu(EventArgs e)
		{
			if (this.xc426734a00cfd031 != null)
			{
				this.xc426734a00cfd031(this, e);
			}
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x000048EC File Offset: 0x000038EC
		protected internal void OnEnterMenuLoop()
		{
			if (this.x0ef5a9135fb0040c != null)
			{
				this.x0ef5a9135fb0040c(this, EventArgs.Empty);
			}
			this.xfa015f7c2b22c712 = true;
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x00004910 File Offset: 0x00003910
		protected internal void OnExitMenuLoop()
		{
			if (this.xf1ebf4d370594337 != null)
			{
				this.xf1ebf4d370594337(this, EventArgs.Empty);
			}
			this.xfa015f7c2b22c712 = false;
		}

		// Token: 0x060000CA RID: 202 RVA: 0x00004934 File Offset: 0x00003934
		internal virtual void xa2414c47d888068e()
		{
		}

		// Token: 0x060000CB RID: 203 RVA: 0x00004938 File Offset: 0x00003938
		internal virtual void x19e788b09b195d4f()
		{
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x060000CC RID: 204 RVA: 0x0000493C File Offset: 0x0000393C
		[Browsable(false)]
		public ToolBarSituation Situation
		{
			get
			{
				return this.xd39eba9a9a1b028e;
			}
		}

		// Token: 0x060000CD RID: 205 RVA: 0x00004944 File Offset: 0x00003944
		protected internal virtual void OnCloseButtonPressed()
		{
			base.Hide();
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x060000CE RID: 206 RVA: 0x0000494C File Offset: 0x0000394C
		// (set) Token: 0x060000CF RID: 207 RVA: 0x00004954 File Offset: 0x00003954
		internal ToolbarItemBase xe4f42f0e511fcd41
		{
			get
			{
				return this.x716cbe6495cbcf0a;
			}
			set
			{
				if (this.x716cbe6495cbcf0a != value)
				{
					if (this.x716cbe6495cbcf0a != null)
					{
						this.x716cbe6495cbcf0a.Invalidate();
					}
					this.x716cbe6495cbcf0a = value;
					if (this.x716cbe6495cbcf0a != null)
					{
						this.x716cbe6495cbcf0a.Invalidate();
					}
				}
			}
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x060000D0 RID: 208 RVA: 0x0000498C File Offset: 0x0000398C
		[Browsable(false)]
		internal TopLevelMenuItemBase[] xd9ea46f5e3831639
		{
			get
			{
				ArrayList arrayList = new ArrayList();
				foreach (object obj in this.Items)
				{
					ToolbarItemBase toolbarItemBase = (ToolbarItemBase)obj;
					if (toolbarItemBase is TopLevelMenuItemBase)
					{
						arrayList.Add(toolbarItemBase);
					}
				}
				TopLevelMenuItemBase[] array = new TopLevelMenuItemBase[arrayList.Count];
				arrayList.CopyTo(array);
				return array;
			}
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x060000D1 RID: 209 RVA: 0x00004A18 File Offset: 0x00003A18
		internal bool x972331c8ecf83413
		{
			get
			{
				return base.DesignMode;
			}
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x00004A20 File Offset: 0x00003A20
		internal object x7159e85e85b84817(Type xbbc167e43765af4e)
		{
			return this.GetService(xbbc167e43765af4e);
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x00004A2C File Offset: 0x00003A2C
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				ToolbarItemBase[] array = new ToolbarItemBase[this.Items.Count];
				this.Items.CopyTo(array, 0);
				this.Items.Clear();
				foreach (ToolbarItemBase toolbarItemBase in array)
				{
					toolbarItemBase.Dispose();
				}
				this.x38870620fd380a6b.RedrawRequired -= this.xadd697061e4ba3d4;
				this.x38870620fd380a6b.RemoveConsumer(this);
				this.xab98d56e18146fb2.Dispose();
				this.xac1c850120b1f254.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x00004AC4 File Offset: 0x00003AC4
		private bool ShouldSerializeRenderer()
		{
			return this.Renderer.GetType() != typeof(Office2003Renderer);
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x060000D5 RID: 213 RVA: 0x00004AE0 File Offset: 0x00003AE0
		// (set) Token: 0x060000D6 RID: 214 RVA: 0x00004AE8 File Offset: 0x00003AE8
		[Browsable(true)]
		[Description("The renderer used by the toolbar when in a standalone state.")]
		[TypeConverter(typeof(x01480672935e1b10))]
		[Category("Appearance")]
		public IToolBarRenderer Renderer
		{
			get
			{
				return this.x38870620fd380a6b;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException();
				}
				if (value == this.x38870620fd380a6b)
				{
					return;
				}
				if (this.x38870620fd380a6b != null)
				{
					this.x38870620fd380a6b.RedrawRequired -= this.xadd697061e4ba3d4;
					this.x38870620fd380a6b.RemoveConsumer(this);
				}
				this.x38870620fd380a6b = value;
				if (this.x38870620fd380a6b != null)
				{
					this.x38870620fd380a6b.AddConsumer(this);
					this.x38870620fd380a6b.RedrawRequired += this.xadd697061e4ba3d4;
				}
				base.Invalidate(true);
				this.OnRendererChanged();
			}
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x00004B74 File Offset: 0x00003B74
		protected internal virtual void OnRendererChanged()
		{
			this.xadd697061e4ba3d4(null, null);
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x060000D8 RID: 216 RVA: 0x00004B80 File Offset: 0x00003B80
		[Browsable(false)]
		public IToolBarRenderer WorkingRenderer
		{
			get
			{
				if (this.Situation == ToolBarSituation.Contained)
				{
					return ((ToolBarContainer)base.Parent).Manager.Renderer;
				}
				if (this.Situation == ToolBarSituation.Floating)
				{
					return ((x502bf86f15e12152)base.Parent).x460ab163f44a604d.Renderer;
				}
				return this.x38870620fd380a6b;
			}
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x060000D9 RID: 217 RVA: 0x00004BD4 File Offset: 0x00003BD4
		[Browsable(false)]
		public SandBarManager Manager
		{
			get
			{
				if (this.Situation == ToolBarSituation.Contained)
				{
					return ((ToolBarContainer)base.Parent).Manager;
				}
				return null;
			}
		}

		// Token: 0x060000DA RID: 218 RVA: 0x00004BF4 File Offset: 0x00003BF4
		internal void x2407369b053315a8(ToolbarItemBase x128517d7ded59312)
		{
			if (this.xe4f42f0e511fcd41 == x128517d7ded59312)
			{
				this.xe4f42f0e511fcd41 = null;
			}
		}

		// Token: 0x060000DB RID: 219 RVA: 0x00004C08 File Offset: 0x00003C08
		private void x20aee281977480cf()
		{
			this.Text = "Tool Bar";
			base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			base.SetStyle(ControlStyles.DoubleBuffer, true);
			base.SetStyle(ControlStyles.UserPaint, true);
			base.SetStyle(ControlStyles.Selectable, false);
			this.Dock = DockStyle.Top;
			this._xffd861c4fc9ace66 = new ToolBar.ToolBarItemCollection(this);
			this.x38870620fd380a6b = new Office2003Renderer();
			this.x38870620fd380a6b.RedrawRequired += this.xadd697061e4ba3d4;
			this.xab98d56e18146fb2 = new xb3f7a6163630a970(this);
			this.xac1c850120b1f254 = new xf8f9565783602018(this);
			this.xac1c850120b1f254.xa6e4f463e64a5987 = false;
			this.xac1c850120b1f254.x9ab519b46dd91330 = true;
			this.xac1c850120b1f254.x9b21ee8e7ceaada3 += this.xa3a7472ac4e61f76;
			this._xb51cd75f17ace1ec = Guid.NewGuid();
		}

		// Token: 0x060000DC RID: 220 RVA: 0x00004CD4 File Offset: 0x00003CD4
		private void x6fcab81821bdbaf7(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			this.xcf42ad4a4f3fcbf6();
		}

		// Token: 0x060000DD RID: 221 RVA: 0x00004CDC File Offset: 0x00003CDC
		private void xccb154db494aa970(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			this.ImageList = null;
		}

		// Token: 0x060000DE RID: 222 RVA: 0x00004CE8 File Offset: 0x00003CE8
		private void x2d020c867466444d(IToolBarRenderer x38870620fd380a6b, Graphics x41347a961b838962, ToolbarItemBase xccb63ca5f63dc470, bool xa092001467a0ab7b, bool x1158f70b6f5fc38e, bool x3a11b5c51887f30b)
		{
			if (xccb63ca5f63dc470.x3de314ab70bbd9bf)
			{
				x38870620fd380a6b.DrawToolBarSeparator(x41347a961b838962, xccb63ca5f63dc470.xa92e62bde95607f6, xa092001467a0ab7b);
			}
			DrawItemState drawItemState = DrawItemState.Default;
			if ((xccb63ca5f63dc470 == this.xe4f42f0e511fcd41 && xccb63ca5f63dc470 is ButtonItemBase) || x3a11b5c51887f30b)
			{
				drawItemState |= DrawItemState.HotLight;
			}
			if ((drawItemState & DrawItemState.HotLight) == DrawItemState.HotLight && this.xfa5e20eb950b9ee1)
			{
				drawItemState |= DrawItemState.Selected;
			}
			if (xccb63ca5f63dc470 is ButtonItemBase && ((ButtonItemBase)xccb63ca5f63dc470).Checked)
			{
				drawItemState |= DrawItemState.Checked;
			}
			if (!xccb63ca5f63dc470.Enabled || !base.Enabled)
			{
				drawItemState |= DrawItemState.Disabled;
			}
			xccb63ca5f63dc470.Paint(x38870620fd380a6b, x41347a961b838962, this.Font, xa092001467a0ab7b, x1158f70b6f5fc38e, this._xe4f97a5cc9204c1f, drawItemState);
		}

		// Token: 0x060000DF RID: 223 RVA: 0x00004D84 File Offset: 0x00003D84
		protected override void OnPaint(PaintEventArgs e)
		{
			bool flag = false;
			bool flag3;
			bool flag2 = (flag3 ? 1U : 0U) + (flag3 ? 1U : 0U) < 0U;
			IToolBarRenderer workingRenderer;
			DrawItemState drawItemState;
			if (!flag2)
			{
				int i;
				for (;;)
				{
					flag3 = (this.Flow == ToolBarLayout.Vertical);
					bool flag4 = this.RightToLeft == RightToLeft.Yes && this.AllowRightToLeft;
					workingRenderer = this.WorkingRenderer;
					if (this.xb011a3316da48ee8)
					{
						break;
					}
					ISelectionService selectionService = null;
					if (base.DesignMode)
					{
						selectionService = (ISelectionService)this.GetService(typeof(ISelectionService));
					}
					workingRenderer.StartToolBarRender(this, flag3, flag4);
					if ((this.Situation == ToolBarSituation.Contained || this is ContainerBar) && this._xfd9e8be9c7129364)
					{
						workingRenderer.DrawToolBarGrabHandle(e.Graphics, this.x446b42c2caf105ce, flag3);
					}
					foreach (object obj in this.Items)
					{
						ToolbarItemBase toolbarItemBase = (ToolbarItemBase)obj;
						if (toolbarItemBase.Visible)
						{
							if (toolbarItemBase.x3780ff57150950cd)
							{
								flag = true;
							}
							else
							{
								this.x2d020c867466444d(workingRenderer, e.Graphics, toolbarItemBase, flag3, flag4, base.DesignMode && selectionService.GetComponentSelected(toolbarItemBase));
							}
						}
					}
					ToolbarItemBase[] x0366497b06ec1dfe = this.x0366497b06ec1dfe;
					for (i = 0; i < x0366497b06ec1dfe.Length; i++)
					{
						ToolbarItemBase toolbarItemBase2 = x0366497b06ec1dfe[i];
						if (toolbarItemBase2 != this.xab98d56e18146fb2 && toolbarItemBase2.Visible && toolbarItemBase2.ButtonBounds != Rectangle.Empty)
						{
							this.x2d020c867466444d(workingRenderer, e.Graphics, toolbarItemBase2, flag3, flag4, false);
						}
					}
					if (!this.DrawActionsButton)
					{
						goto IL_61;
					}
					if (false)
					{
						return;
					}
					if (this.Situation != ToolBarSituation.Contained || this is ContainerBar)
					{
						goto IL_61;
					}
					drawItemState = DrawItemState.Default;
					if (false)
					{
						break;
					}
					if (this.xe4f42f0e511fcd41 != this.xab98d56e18146fb2)
					{
						goto IL_2E;
					}
					flag2 = ((flag ? 1U : 0U) - (flag3 ? 1U : 0U) > uint.MaxValue);
					if (flag2)
					{
						break;
					}
					flag2 = (((flag ? 1U : 0U) | 2147483647U) == 0U);
					if (!flag2)
					{
						goto IL_251;
					}
				}
				return;
				IL_251:
				flag2 = ((uint)i < 0U);
				if (flag2)
				{
					return;
				}
			}
			drawItemState |= DrawItemState.HotLight;
			if (this.xfa5e20eb950b9ee1)
			{
				drawItemState |= DrawItemState.Selected;
			}
			IL_2E:
			if (this.xab98d56e18146fb2.x785370fd71860ecc)
			{
				drawItemState |= (DrawItemState.HotLight | DrawItemState.Selected);
			}
			workingRenderer.DrawToolBarActionsButton(e.Graphics, this.xab98d56e18146fb2.ButtonBounds, flag3, flag, drawItemState, base.DesignMode);
			IL_61:
			workingRenderer.FinishToolBarRender();
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x00005014 File Offset: 0x00004014
		protected override void OnPaintBackground(PaintEventArgs pevent)
		{
			this.WorkingRenderer.DrawToolBarBackground(this, pevent.Graphics, base.ClientRectangle, this.Flow == ToolBarLayout.Vertical);
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x060000E1 RID: 225 RVA: 0x00005038 File Offset: 0x00004038
		// (set) Token: 0x060000E2 RID: 226 RVA: 0x00005040 File Offset: 0x00004040
		internal bool x73be6e650087b30e
		{
			get
			{
				return this.xb011a3316da48ee8;
			}
			set
			{
				this.xb011a3316da48ee8 = value;
			}
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x0000504C File Offset: 0x0000404C
		internal void xcf42ad4a4f3fcbf6()
		{
			if (this.xb011a3316da48ee8 || base.Parent == null)
			{
				return;
			}
			this.x38eb4ab7578218ee = Size.Empty;
			if (this.RightToLeft == RightToLeft.Yes)
			{
				bool allowRightToLeft = this.AllowRightToLeft;
			}
			switch (this.Situation)
			{
			case ToolBarSituation.Standalone:
				this.x1a2b7835c4f6410b(this.WorkingRenderer, this.x2612f62f94df47de == ToolBarLayout.Vertical);
				return;
			case ToolBarSituation.Contained:
				this.x1ee1d676c79f53ba = true;
				((ToolBarContainer)base.Parent).xbfd94ee78a3ab05f();
				return;
			case ToolBarSituation.Floating:
				((x502bf86f15e12152)base.Parent).xcf42ad4a4f3fcbf6();
				return;
			default:
				return;
			}
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x000050E0 File Offset: 0x000040E0
		internal virtual Size xb72141a39aa76ab2(Size x745e975ddcb1a4a4)
		{
			int num = 0;
			num += 6;
			num += this.LeftPadding + this.RightPadding;
			if (this.Situation == ToolBarSituation.Contained && this.Movable)
			{
				num += 5;
			}
			if (this.DrawActionsButton && this.Situation == ToolBarSituation.Contained)
			{
				num += 13;
			}
			num += ((this.Flow == ToolBarLayout.Horizontal) ? x745e975ddcb1a4a4.Width : x745e975ddcb1a4a4.Height);
			if (num < 18)
			{
				num = 18;
			}
			int num2 = 2;
			num2 += ((this.Flow == ToolBarLayout.Horizontal) ? x745e975ddcb1a4a4.Height : x745e975ddcb1a4a4.Width);
			if (this.Situation == ToolBarSituation.Contained)
			{
				num2 += 2;
			}
			if (num2 < 18)
			{
				num2 = 18;
			}
			if (this.Flow != ToolBarLayout.Horizontal)
			{
				return new Size(num2, num);
			}
			return new Size(num, num2);
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x0000519C File Offset: 0x0000419C
		internal virtual Rectangle x2bae8e54dc041c43(Rectangle x4bc955bd8cfefd39)
		{
			int num = 3 + this.LeftPadding;
			if (this.Situation == ToolBarSituation.Contained && this.Movable)
			{
				num += 5;
			}
			int num2 = 3 + this.RightPadding;
			if (this.Situation == ToolBarSituation.Contained && this.DrawActionsButton)
			{
				num2 += 13;
			}
			int num3 = 1;
			int num4 = 1;
			if (this.Situation == ToolBarSituation.Contained)
			{
				num3++;
				num4++;
			}
			if (this.Flow == ToolBarLayout.Horizontal)
			{
				x4bc955bd8cfefd39.Offset(num, num3);
				x4bc955bd8cfefd39.Width -= num + num2;
				x4bc955bd8cfefd39.Height -= num3 + num4;
			}
			else
			{
				x4bc955bd8cfefd39.Offset(num3, num);
				x4bc955bd8cfefd39.Width -= num3 + num4;
				x4bc955bd8cfefd39.Height -= num + num2;
			}
			return x4bc955bd8cfefd39;
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x0000525C File Offset: 0x0000425C
		internal Size xf99417bde67b156a()
		{
			return this.x3385488b2bb8e38c(int.MaxValue);
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x0000526C File Offset: 0x0000426C
		internal Size x3385488b2bb8e38c(int x8a5438a210b3746e)
		{
			bool flag;
			return this.x3385488b2bb8e38c(x8a5438a210b3746e, out flag);
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x00005284 File Offset: 0x00004284
		internal virtual Size x3385488b2bb8e38c(int x8a5438a210b3746e, out bool x8e1d21c91e03470f)
		{
			Size x745e975ddcb1a4a = new Size(100, 100);
			Size size = this.xb72141a39aa76ab2(x745e975ddcb1a4a);
			x8a5438a210b3746e -= ((this.Flow == ToolBarLayout.Horizontal) ? (size.Width - x745e975ddcb1a4a.Width) : (size.Height - x745e975ddcb1a4a.Height));
			Size size2;
			using (Graphics graphics = base.CreateGraphics())
			{
				size2 = xdf1e331801161ebc.xdd6d4e0a33c8a7db(this, graphics, this.WorkingRenderer, this.Flow == ToolBarLayout.Vertical, x8a5438a210b3746e, out x8e1d21c91e03470f);
			}
			size2 = this.xb72141a39aa76ab2(size2);
			return size2;
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x060000E9 RID: 233 RVA: 0x00005324 File Offset: 0x00004324
		protected internal virtual int LeftPadding
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x060000EA RID: 234 RVA: 0x00005328 File Offset: 0x00004328
		protected internal virtual int RightPadding
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x060000EB RID: 235 RVA: 0x0000532C File Offset: 0x0000432C
		[Browsable(false)]
		public TopLevelMenuItemBase ActionsButton
		{
			get
			{
				return this.xab98d56e18146fb2;
			}
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x060000EC RID: 236 RVA: 0x00005334 File Offset: 0x00004334
		[Browsable(false)]
		public ToolBarContainer LastFixedContainer
		{
			get
			{
				if (this.xbb3c9d3140e86cb0 == null || !this.xbb3c9d3140e86cb0.IsAlive)
				{
					return null;
				}
				return (ToolBarContainer)this.xbb3c9d3140e86cb0.Target;
			}
		}

		// Token: 0x060000ED RID: 237 RVA: 0x00005360 File Offset: 0x00004360
		internal virtual void x1e4c4ef34f4a4bd2()
		{
			if (this.Situation != ToolBarSituation.Contained || !this.Movable)
			{
				this.x446b42c2caf105ce = Rectangle.Empty;
				return;
			}
			if (this.Flow == ToolBarLayout.Vertical)
			{
				this.x446b42c2caf105ce = new Rectangle(5, 1, base.ClientRectangle.Width - 8, 6);
				return;
			}
			this.x446b42c2caf105ce = new Rectangle(1, 5, 6, base.ClientRectangle.Height - 8);
		}

		// Token: 0x060000EE RID: 238 RVA: 0x000053D0 File Offset: 0x000043D0
		internal virtual void xe86489bc13d45afa()
		{
			if (this.DrawActionsButton && this.Situation == ToolBarSituation.Contained)
			{
				Rectangle buttonBounds;
				if (this.Flow == ToolBarLayout.Vertical)
				{
					buttonBounds = new Rectangle(1, base.ClientRectangle.Height - 12, base.ClientRectangle.Width - 2, 13);
				}
				else
				{
					buttonBounds = new Rectangle(base.ClientRectangle.Width - 13, 0, 13, base.ClientRectangle.Height);
				}
				this.xab98d56e18146fb2.ApplyLayout(buttonBounds, null, false, false);
			}
		}

		// Token: 0x060000EF RID: 239 RVA: 0x00005460 File Offset: 0x00004460
		protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
		{
			if (this.Situation == ToolBarSituation.Standalone && base.IsHandleCreated && !(this is ContainerBar))
			{
				bool flag = this.Flow == ToolBarLayout.Vertical;
				Size size = this.x3385488b2bb8e38c(flag ? height : width);
				if (flag)
				{
					width = size.Width;
				}
				else
				{
					height = size.Height;
				}
			}
			base.SetBoundsCore(x, y, width, height, specified);
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x000054C4 File Offset: 0x000044C4
		internal virtual void x1a2b7835c4f6410b(IToolBarRenderer x38870620fd380a6b, bool xa092001467a0ab7b)
		{
			if (this.xb011a3316da48ee8 || !base.IsHandleCreated)
			{
				return;
			}
			this.xb011a3316da48ee8 = true;
			if (this.Situation == ToolBarSituation.Standalone)
			{
				Size size = this.x3385488b2bb8e38c(xa092001467a0ab7b ? base.Height : base.Width);
				if (xa092001467a0ab7b && base.Width != size.Width)
				{
					base.Width = size.Width;
				}
				else if (!xa092001467a0ab7b && base.Height != size.Height)
				{
					base.Height = size.Height;
				}
			}
			Rectangle xda73fcb97c77d = this.x2bae8e54dc041c43(base.ClientRectangle);
			this.x1e4c4ef34f4a4bd2();
			this.xe86489bc13d45afa();
			bool x1158f70b6f5fc38e = this.RightToLeft == RightToLeft.Yes && this.AllowRightToLeft;
			using (Graphics graphics = base.CreateGraphics())
			{
				xdf1e331801161ebc.xf01c0312483a47c8(this, graphics, xda73fcb97c77d, x38870620fd380a6b, xa092001467a0ab7b, x1158f70b6f5fc38e, this.FlipLastItem);
			}
			base.Invalidate();
			this.xb011a3316da48ee8 = false;
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x000055C4 File Offset: 0x000045C4
		public void Redock(Control container)
		{
			base.Parent = container;
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x000055D0 File Offset: 0x000045D0
		public void Float(SandBarManager manager, Point desktopLocation)
		{
			this.x5d1aeeb0b6ebccac(manager, desktopLocation, false);
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x000055DC File Offset: 0x000045DC
		internal void x5d1aeeb0b6ebccac(SandBarManager x91f347c6e97f1846, Point x812a15ab39d962d7, bool x35903aeefece98bf)
		{
			if (x91f347c6e97f1846 == null)
			{
				throw new ArgumentNullException();
			}
			if (!(base.Parent is x502bf86f15e12152))
			{
				Font font = new Font(this.Font, this.Font.Style);
				RightToLeft rightToLeft = this.RightToLeft;
				if (base.Parent != null)
				{
					base.Parent.Controls.Remove(this);
				}
				x502bf86f15e12152 x502bf86f15e = new x502bf86f15e12152(this, x91f347c6e97f1846, rightToLeft);
				x502bf86f15e.Font = font;
				x502bf86f15e.RightToLeft = rightToLeft;
				Size xafc895301c3c68ee = this.xf99417bde67b156a();
				x502bf86f15e.x717b578f97e88385(xafc895301c3c68ee);
				if (x91f347c6e97f1846.OwnerForm != null)
				{
					x91f347c6e97f1846.OwnerForm.AddOwnedForm(x502bf86f15e);
				}
			}
			base.Parent.Location = x812a15ab39d962d7;
			if (!x35903aeefece98bf)
			{
				((x502bf86f15e12152)base.Parent).x2c6f5ac62ee048e5();
			}
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x00005690 File Offset: 0x00004690
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			if (e.Button != MouseButtons.Left)
			{
				return;
			}
			this.x1c052ea7408f43d4(new Point(e.X, e.Y));
			if (this.xe4f42f0e511fcd41 != null)
			{
				this.OnItemPush(this.xe4f42f0e511fcd41, new Point(e.X, e.Y));
				return;
			}
			if (this.xe4f42f0e511fcd41 == null && this._xfd9e8be9c7129364)
			{
				if (this.Situation == ToolBarSituation.Contained)
				{
					Cursor.Current = Cursors.SizeAll;
					this.x59a14ca9cc50a075 = new x5c4975da3c2417f1(this, e);
					base.Capture = true;
					return;
				}
				if (this.Situation == ToolBarSituation.Floating)
				{
					Point point = base.Parent.PointToClient(base.PointToScreen(new Point(e.X, e.Y)));
					((x502bf86f15e12152)base.Parent).x93dffb29518a0417(new MouseEventArgs(MouseButtons.None, 0, point.X, point.Y, 0));
				}
			}
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x00005780 File Offset: 0x00004780
		protected virtual void OnItemPush(ToolbarItemBase item, Point position)
		{
			if (item == this.xab98d56e18146fb2)
			{
				this.xab98d56e18146fb2.Show();
				return;
			}
			if (item is TopLevelMenuItemBase)
			{
				if (!(item is DropDownMenuItem))
				{
					((TopLevelMenuItemBase)item).Show();
					return;
				}
				Rectangle buttonBounds = item.ButtonBounds;
				if (position.X > buttonBounds.Right - 11)
				{
					((TopLevelMenuItemBase)item).Show();
					return;
				}
			}
			this.xfa5e20eb950b9ee1 = true;
			item.Invalidate();
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x000057F4 File Offset: 0x000047F4
		protected virtual void OnItemRelease(ToolbarItemBase item, Point position)
		{
			if (this.xfa5e20eb950b9ee1)
			{
				item.OnActivate();
			}
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x00005804 File Offset: 0x00004804
		protected override void OnMouseUp(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				if (this.xe4f42f0e511fcd41 != null)
				{
					if (this.xe4f42f0e511fcd41.ButtonBounds.Contains(e.X, e.Y))
					{
						this.OnItemRelease(this.xe4f42f0e511fcd41, new Point(e.X, e.Y));
					}
					if (this.xe4f42f0e511fcd41 != null)
					{
						this.xe4f42f0e511fcd41.Invalidate();
					}
				}
				this.xfa5e20eb950b9ee1 = false;
			}
			if (e.Button == MouseButtons.Right && base.Parent is ToolBarContainer)
			{
				((ToolBarContainer)base.Parent).Manager.ShowContextMenu(this, this, new Point(e.X, e.Y));
			}
			base.OnMouseUp(e);
		}

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x060000F8 RID: 248 RVA: 0x000058C8 File Offset: 0x000048C8
		internal virtual ToolbarItemBase[] x0366497b06ec1dfe
		{
			get
			{
				return new ToolbarItemBase[]
				{
					this.xab98d56e18146fb2
				};
			}
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x000058E8 File Offset: 0x000048E8
		protected override void OnMouseMove(MouseEventArgs e)
		{
			if (this.x59a14ca9cc50a075 != null)
			{
				this.x59a14ca9cc50a075.x2c5d1da1234c3a6a(e);
				return;
			}
			if (e.Button == MouseButtons.None)
			{
				if (this._xfd9e8be9c7129364 && this.x446b42c2caf105ce.Contains(e.X, e.Y))
				{
					Cursor.Current = Cursors.SizeAll;
				}
				else
				{
					Cursor.Current = this.Cursor;
				}
			}
			if (!this.xfa5e20eb950b9ee1)
			{
				this.x1c052ea7408f43d4(new Point(e.X, e.Y));
			}
			base.OnMouseMove(e);
		}

		// Token: 0x060000FA RID: 250 RVA: 0x00005970 File Offset: 0x00004970
		private void x1c052ea7408f43d4(Point x13d4cb8d1bd20347)
		{
			ToolbarItemBase toolbarItemBase = this.GetItemAt(new Point(x13d4cb8d1bd20347.X, x13d4cb8d1bd20347.Y));
			if (toolbarItemBase == null)
			{
				foreach (ToolbarItemBase toolbarItemBase2 in this.x0366497b06ec1dfe)
				{
					if (toolbarItemBase2.Visible)
					{
						Rectangle buttonBounds = toolbarItemBase2.ButtonBounds;
						buttonBounds.Width++;
						buttonBounds.Height++;
						if (buttonBounds.Contains(x13d4cb8d1bd20347.X, x13d4cb8d1bd20347.Y))
						{
							toolbarItemBase = toolbarItemBase2;
						}
					}
				}
			}
			if (this.xe4f42f0e511fcd41 == toolbarItemBase)
			{
				return;
			}
			if (toolbarItemBase != null && !toolbarItemBase.Enabled)
			{
				toolbarItemBase = null;
			}
			this.xe4f42f0e511fcd41 = toolbarItemBase;
		}

		// Token: 0x060000FB RID: 251 RVA: 0x00005A1C File Offset: 0x00004A1C
		protected override void OnMouseLeave(EventArgs e)
		{
			if (this.xe4f42f0e511fcd41 != null && !this.xfa015f7c2b22c712)
			{
				this.xe4f42f0e511fcd41 = null;
			}
			base.OnMouseLeave(e);
		}

		// Token: 0x060000FC RID: 252 RVA: 0x00005A3C File Offset: 0x00004A3C
		protected override void OnHandleCreated(EventArgs e)
		{
			base.OnHandleCreated(e);
			this.xcf42ad4a4f3fcbf6();
		}

		// Token: 0x060000FD RID: 253 RVA: 0x00005A4C File Offset: 0x00004A4C
		protected override void OnFontChanged(EventArgs e)
		{
			base.OnFontChanged(e);
			this.xcf42ad4a4f3fcbf6();
		}

		// Token: 0x060000FE RID: 254 RVA: 0x00005A5C File Offset: 0x00004A5C
		public ToolbarItemBase GetItemAt(Point position)
		{
			if (this.xe4f42f0e511fcd41 != null)
			{
				Rectangle buttonBounds = this.xe4f42f0e511fcd41.ButtonBounds;
				buttonBounds.Width++;
				buttonBounds.Height++;
				if (buttonBounds.Contains(position))
				{
					return this.xe4f42f0e511fcd41;
				}
			}
			foreach (object obj in this.Items)
			{
				ToolbarItemBase toolbarItemBase = (ToolbarItemBase)obj;
				if (toolbarItemBase.Visible && !toolbarItemBase.x3780ff57150950cd)
				{
					Rectangle buttonBounds2 = toolbarItemBase.ButtonBounds;
					buttonBounds2.Width++;
					buttonBounds2.Height++;
					if (buttonBounds2.Contains(position))
					{
						return toolbarItemBase;
					}
				}
			}
			return null;
		}

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x060000FF RID: 255 RVA: 0x00005B4C File Offset: 0x00004B4C
		internal bool x1a3934a4b789f2c3
		{
			get
			{
				return this.ShowKeyboardCues;
			}
		}

		// Token: 0x06000100 RID: 256 RVA: 0x00005B54 File Offset: 0x00004B54
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			if (this.Situation == ToolBarSituation.Standalone)
			{
				this.xcf42ad4a4f3fcbf6();
			}
		}

		// Token: 0x06000101 RID: 257 RVA: 0x00005B6C File Offset: 0x00004B6C
		protected override void OnParentChanged(EventArgs e)
		{
			base.OnParentChanged(e);
			if (base.Parent is ToolBarContainer)
			{
				this.xd39eba9a9a1b028e = ToolBarSituation.Contained;
				if (this.x59a14ca9cc50a075 == null)
				{
					this.xbb3c9d3140e86cb0 = new WeakReference((ToolBarContainer)base.Parent);
				}
			}
			else if (base.Parent is x502bf86f15e12152)
			{
				this.xd39eba9a9a1b028e = ToolBarSituation.Floating;
			}
			else
			{
				this.xd39eba9a9a1b028e = ToolBarSituation.Standalone;
			}
			this.xcf42ad4a4f3fcbf6();
		}

		// Token: 0x06000102 RID: 258 RVA: 0x00005BD8 File Offset: 0x00004BD8
		protected override bool ProcessMnemonic(char charCode)
		{
			if ((Control.ModifierKeys & Keys.Alt) != Keys.Alt)
			{
				return false;
			}
			foreach (object obj in this._xffd861c4fc9ace66)
			{
				ToolbarItemBase toolbarItemBase = (ToolbarItemBase)obj;
				if (base.Enabled && base.Visible && toolbarItemBase.Visible && toolbarItemBase.Enabled && Control.IsMnemonic(charCode, toolbarItemBase.Text))
				{
					if (toolbarItemBase is TopLevelMenuItemBase)
					{
						((TopLevelMenuItemBase)toolbarItemBase).Show(true);
					}
					else
					{
						toolbarItemBase.OnActivate();
					}
					return true;
				}
			}
			return base.ProcessMnemonic(charCode);
		}

		// Token: 0x06000103 RID: 259 RVA: 0x00005CA4 File Offset: 0x00004CA4
		protected override void OnChangeUICues(UICuesEventArgs e)
		{
			base.OnChangeUICues(e);
			base.Invalidate();
		}

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x06000104 RID: 260 RVA: 0x00005CB4 File Offset: 0x00004CB4
		bool IPopupMenuHost.x160b24535b6b9bcd
		{
			get
			{
				return SystemInformation.RightAlignedMenus;
			}
		}

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x06000105 RID: 261 RVA: 0x00005CBC File Offset: 0x00004CBC
		ImageList IPopupMenuHost.x3d7e964d20671957
		{
			get
			{
				if (this.xe4f42f0e511fcd41 is DropDownMenuItem && ((DropDownMenuItem)this.xe4f42f0e511fcd41).MenuImageList != null)
				{
					return ((DropDownMenuItem)this.xe4f42f0e511fcd41).MenuImageList;
				}
				if (this.xc30476d9d8314d3c != null && this.xc30476d9d8314d3c is DropDownMenuItem && ((DropDownMenuItem)this.xc30476d9d8314d3c).MenuImageList != null)
				{
					return ((DropDownMenuItem)this.xc30476d9d8314d3c).MenuImageList;
				}
				return this.ImageList;
			}
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x06000106 RID: 262 RVA: 0x00005D38 File Offset: 0x00004D38
		IMenuRenderer IPopupMenuHost.xee2f5422778b35ea
		{
			get
			{
				return this.WorkingRenderer;
			}
		}

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x06000107 RID: 263 RVA: 0x00005D40 File Offset: 0x00004D40
		bool IPopupMenuHost.x2b07f71a3b16a14f
		{
			get
			{
				return this.RightToLeft == RightToLeft.Yes;
			}
		}

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x06000108 RID: 264 RVA: 0x00005D4C File Offset: 0x00004D4C
		ToolBar IPopupMenuHost.x6a53c5ddac47298d
		{
			get
			{
				return this;
			}
		}

		// Token: 0x06000109 RID: 265 RVA: 0x00005D50 File Offset: 0x00004D50
		private void xadd697061e4ba3d4(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			if (this.Situation == ToolBarSituation.Floating)
			{
				base.Parent.Invalidate(true);
				return;
			}
			base.Invalidate(true);
		}

		// Token: 0x0600010A RID: 266 RVA: 0x00005D70 File Offset: 0x00004D70
		private string xa3a7472ac4e61f76(Point xb9c2cfae130d9256)
		{
			ToolbarItemBase itemAt = this.GetItemAt(xb9c2cfae130d9256);
			if (itemAt != null)
			{
				string text = itemAt.ToolTipText;
				ButtonItem buttonItem = itemAt as ButtonItem;
				if (buttonItem != null)
				{
					if (text.Length == 0 && buttonItem.BuddyMenu != null)
					{
						text = buttonItem.BuddyMenu.Text;
					}
					if (this.ShowShortcutsInToolTips && buttonItem.BuddyMenu != null && buttonItem.BuddyMenu.Shortcut != Shortcut.None)
					{
						text = text + " (" + buttonItem.BuddyMenu.ShortcutDisplayString + ")";
					}
				}
				return text;
			}
			return "";
		}

		// Token: 0x0600010B RID: 267 RVA: 0x00005DF8 File Offset: 0x00004DF8
		protected override void WndProc(ref Message m)
		{
			if (m.Msg == 533 && this.x59a14ca9cc50a075 != null && !this.x59a14ca9cc50a075.x57ba069a692cbf47)
			{
				this.x59a14ca9cc50a075.Dispose();
				this.x59a14ca9cc50a075 = null;
				if (this.Situation == ToolBarSituation.Contained)
				{
					this.xbb3c9d3140e86cb0 = new WeakReference((ToolBarContainer)base.Parent);
				}
			}
			base.WndProc(ref m);
		}

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x0600010C RID: 268 RVA: 0x00005E60 File Offset: 0x00004E60
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public ToolbarItemBaseCollection Items
		{
			get
			{
				return this._xffd861c4fc9ace66;
			}
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x0600010D RID: 269 RVA: 0x00005E68 File Offset: 0x00004E68
		Control IToolBarItemBaseCollectionHost.x426d9984f6586bce
		{
			get
			{
				return this;
			}
		}

		// Token: 0x0600010E RID: 270 RVA: 0x00005E6C File Offset: 0x00004E6C
		void IToolBarItemBaseCollectionHost.xe572f918f1a60bde()
		{
			if (this.xe4f42f0e511fcd41 != null && !this.Items.Contains(this.xe4f42f0e511fcd41))
			{
				this.xe4f42f0e511fcd41 = null;
			}
			this.xcf42ad4a4f3fcbf6();
			if (this is MenuBar)
			{
				((MenuBar)this).ShortcutListener.UpdateAcceleratorTable(this);
			}
		}

		// Token: 0x0400002A RID: 42
		internal const int x24a792c9b7d4b84c = 3;

		// Token: 0x0400002B RID: 43
		private const int x9759a8ac22327c41 = 5;

		// Token: 0x0400002C RID: 44
		internal const int xdf9d45d72bc336a6 = 7;

		// Token: 0x0400002D RID: 45
		private const int x97977fda9c2ee798 = 13;

		// Token: 0x0400002E RID: 46
		private ToolbarItemBaseCollection _xffd861c4fc9ace66;

		// Token: 0x0400002F RID: 47
		private ToolbarItemBase x716cbe6495cbcf0a;

		// Token: 0x04000030 RID: 48
		private bool xae19c2cc7f3edb97;

		// Token: 0x04000031 RID: 49
		private ToolBarOverflow xdd7ed1da9999fb29 = ToolBarOverflow.Chevron;

		// Token: 0x04000032 RID: 50
		private ToolBarLayout x2612f62f94df47de;

		// Token: 0x04000033 RID: 51
		private bool xb011a3316da48ee8;

		// Token: 0x04000034 RID: 52
		private ToolBarTextAlign _xe4f97a5cc9204c1f;

		// Token: 0x04000035 RID: 53
		private ToolbarItemBase xd1a551a498add963;

		// Token: 0x04000036 RID: 54
		private bool x893e4996ed4f2aeb;

		// Token: 0x04000037 RID: 55
		private xb3f7a6163630a970 xab98d56e18146fb2;

		// Token: 0x04000038 RID: 56
		private static bool xc700d1f31b5ce30a;

		// Token: 0x04000039 RID: 57
		internal bool xfa5e20eb950b9ee1;

		// Token: 0x0400003A RID: 58
		internal TopLevelMenuItemBase xc30476d9d8314d3c;

		// Token: 0x0400003B RID: 59
		private TopLevelMenuItemBase.MenuAnimation x95be56bdc2cd6bd1 = TopLevelMenuItemBase.MenuAnimation.System;

		// Token: 0x0400003C RID: 60
		private bool _x9f56c704356128c2;

		// Token: 0x0400003D RID: 61
		private xf8f9565783602018 xac1c850120b1f254;

		// Token: 0x0400003E RID: 62
		private ToolBarSituation xd39eba9a9a1b028e;

		// Token: 0x0400003F RID: 63
		internal int x932e914cea303e55;

		// Token: 0x04000040 RID: 64
		private int x6feecfd1acdf4007;

		// Token: 0x04000041 RID: 65
		internal x5c4975da3c2417f1 x59a14ca9cc50a075;

		// Token: 0x04000042 RID: 66
		private bool _xfd9e8be9c7129364 = true;

		// Token: 0x04000043 RID: 67
		private bool _x463c7d57d1af6f9e = true;

		// Token: 0x04000044 RID: 68
		private bool _x6c3086899dc42885 = true;

		// Token: 0x04000045 RID: 69
		private bool _x4138104f20394708;

		// Token: 0x04000046 RID: 70
		private Guid _xb51cd75f17ace1ec;

		// Token: 0x04000047 RID: 71
		private bool _xdcf9c56dd44e3777 = true;

		// Token: 0x04000048 RID: 72
		private bool _x40d287ff78071b64 = true;

		// Token: 0x04000049 RID: 73
		private WeakReference xbb3c9d3140e86cb0;

		// Token: 0x0400004A RID: 74
		private Size x09af322dc5e0b969 = new Size(60, 30);

		// Token: 0x0400004B RID: 75
		private Size xd903e1624789f810 = Size.Empty;

		// Token: 0x0400004C RID: 76
		private bool x8cad996bf8337776 = true;

		// Token: 0x0400004D RID: 77
		private IToolBarRenderer x38870620fd380a6b;

		// Token: 0x0400004E RID: 78
		private ImageList _x6ec0d1228599f9ae;

		// Token: 0x0400004F RID: 79
		private bool xfa015f7c2b22c712;

		// Token: 0x04000050 RID: 80
		internal bool x1ee1d676c79f53ba;

		// Token: 0x04000051 RID: 81
		internal Size x38eb4ab7578218ee = Size.Empty;

		// Token: 0x04000052 RID: 82
		internal bool x97714101ce5128df;

		// Token: 0x04000053 RID: 83
		internal int x6e235f0bb3253d5b;

		// Token: 0x04000054 RID: 84
		internal ToolBarSituation x8c5e550ff4f6f29f = ToolBarSituation.Contained;

		// Token: 0x04000055 RID: 85
		internal bool x0ab92e81b42892bf;

		// Token: 0x04000056 RID: 86
		internal Rectangle x446b42c2caf105ce;

		// Token: 0x04000057 RID: 87
		private bool xd81a36bac1bd4fad;

		// Token: 0x04000058 RID: 88
		private ToolBar x60222503ecf769d3;

		// Token: 0x04000059 RID: 89
		private xf00666a2552f1592 x08574a93c960045e;

		// Token: 0x0400005A RID: 90
		private EventHandler x0ef5a9135fb0040c;

		// Token: 0x0400005B RID: 91
		private EventHandler xf1ebf4d370594337;

		// Token: 0x0400005C RID: 92
		private ToolBar.ButtonClickEventHandler x7ce50b15d48de9a6;

		// Token: 0x0400005D RID: 93
		private EventHandler xc426734a00cfd031;

		// Token: 0x02000014 RID: 20
		// (Invoke) Token: 0x0600013B RID: 315
		public delegate void ButtonClickEventHandler(object sender, ToolBarItemEventArgs e);

		// Token: 0x0200005A RID: 90
		public class ToolBarItemCollection : ToolbarItemBaseCollection
		{
			// Token: 0x0600040A RID: 1034 RVA: 0x000148C8 File Offset: 0x000138C8
			internal ToolBarItemCollection(IToolBarItemBaseCollectionHost owner) : base(owner)
			{
			}

			// Token: 0x0600040B RID: 1035 RVA: 0x000148D4 File Offset: 0x000138D4
			internal override void x2c6dfd2e92209a38(ToolbarItemBase xccb63ca5f63dc470, object x071bde1041617fce)
			{
				xccb63ca5f63dc470.SetToolbar((ToolBar)x071bde1041617fce);
			}

			// Token: 0x0600040C RID: 1036 RVA: 0x000148E4 File Offset: 0x000138E4
			public static bool IsComponentSuitableForToolBar(ToolbarItemBase item)
			{
				return !(item is MenuItemBase) || item is TopLevelMenuItemBase;
			}

			// Token: 0x0600040D RID: 1037 RVA: 0x000148FC File Offset: 0x000138FC
			internal override bool x69be3d3be3df174e(ToolbarItemBase xccb63ca5f63dc470)
			{
				return ToolBar.ToolBarItemCollection.IsComponentSuitableForToolBar(xccb63ca5f63dc470);
			}
		}
	}
}
