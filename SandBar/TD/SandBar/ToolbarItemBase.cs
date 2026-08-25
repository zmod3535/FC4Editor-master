using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using TD.SandBar.Design;

namespace TD.SandBar
{
	// Token: 0x02000009 RID: 9
	[ToolboxItem(false)]
	[DefaultEvent("Activate")]
	[DesignTimeVisible(false)]
	[Designer(typeof(ToolBarItemBaseDesigner))]
	public abstract class ToolbarItemBase : Component, ICloneable
	{
		// Token: 0x14000002 RID: 2
		// (add) Token: 0x06000035 RID: 53 RVA: 0x000038F8 File Offset: 0x000028F8
		// (remove) Token: 0x06000036 RID: 54 RVA: 0x00003914 File Offset: 0x00002914
		public event EventHandler Activate
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.x5b7f6ddd07ded8cd = (EventHandler)Delegate.Combine(this.x5b7f6ddd07ded8cd, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.x5b7f6ddd07ded8cd = (EventHandler)Delegate.Remove(this.x5b7f6ddd07ded8cd, value);
			}
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00003930 File Offset: 0x00002930
		internal ToolbarItemBase()
		{
			this._xcaf2e4729806e32b = this.CreateDefaultPadding();
		}

		// Token: 0x06000038 RID: 56 RVA: 0x000039B0 File Offset: 0x000029B0
		public override string ToString()
		{
			return base.ToString() + " (" + this.Text + ")";
		}

		// Token: 0x06000039 RID: 57 RVA: 0x000039D0 File Offset: 0x000029D0
		internal virtual ToolbarItemBase.ItemPadding CreateDefaultPadding()
		{
			return new ToolbarItemBase.ItemPadding(this, 3, 3, 2, 3);
		}

		// Token: 0x0600003A RID: 58 RVA: 0x000039DC File Offset: 0x000029DC
		protected internal virtual void OnActivate()
		{
			if (this.ToolBar != null)
			{
				this.ToolBar.OnButtonClick(new ToolBarItemEventArgs(this));
			}
			if (this.x5b7f6ddd07ded8cd != null)
			{
				this.x5b7f6ddd07ded8cd(this, EventArgs.Empty);
			}
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00003A10 File Offset: 0x00002A10
		public void PerformActivate()
		{
			this.OnActivate();
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00003A18 File Offset: 0x00002A18
		protected internal virtual void Paint(IToolBarRenderer renderer, Graphics graphics, Font font, bool vertical, bool rtl, ToolBarTextAlign textAlign, DrawItemState state)
		{
			renderer.DrawToolBarItem(this, graphics, font, vertical, state, textAlign);
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00003A2C File Offset: 0x00002A2C
		protected virtual ToolbarItemBase CreateClonedItem()
		{
			return (ToolbarItemBase)Activator.CreateInstance(base.GetType());
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00003A40 File Offset: 0x00002A40
		public virtual ToolbarItemBase CloneItem()
		{
			ToolbarItemBase toolbarItemBase = this.CreateClonedItem();
			toolbarItemBase.BeginGroup = this.BeginGroup;
			toolbarItemBase.Enabled = this.Enabled;
			toolbarItemBase.ItemImportance = this.ItemImportance;
			toolbarItemBase.Padding.Left = this.Padding.Left;
			toolbarItemBase.Padding.Top = this.Padding.Top;
			toolbarItemBase.Padding.Right = this.Padding.Right;
			toolbarItemBase.Padding.Bottom = this.Padding.Bottom;
			toolbarItemBase.Tag = this.Tag;
			toolbarItemBase.Text = this.Text;
			toolbarItemBase.ToolTipText = this.ToolTipText;
			toolbarItemBase.Visible = this.Visible;
			toolbarItemBase.ForeColor = this.ForeColor;
			toolbarItemBase.MinimumSize = this.MinimumSize;
			toolbarItemBase.x5b7f6ddd07ded8cd = this.x5b7f6ddd07ded8cd;
			return toolbarItemBase;
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00003B28 File Offset: 0x00002B28
		internal ToolbarItemBase FindMergeTarget(ToolbarItemBaseCollection destinationItems)
		{
			ToolbarItemBase toolbarItemBase = null;
			if (this.x90db551379a5ba1c >= 0 && this.x90db551379a5ba1c < destinationItems.Count)
			{
				toolbarItemBase = destinationItems[this.x90db551379a5ba1c];
			}
			if (toolbarItemBase == null)
			{
				foreach (object obj in destinationItems)
				{
					ToolbarItemBase toolbarItemBase2 = (ToolbarItemBase)obj;
					if (toolbarItemBase2.Text.CompareTo(this.Text) == 0)
					{
						toolbarItemBase = toolbarItemBase2;
						break;
					}
				}
			}
			return toolbarItemBase;
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000040 RID: 64 RVA: 0x00003BC4 File Offset: 0x00002BC4
		// (set) Token: 0x06000041 RID: 65 RVA: 0x00003BDC File Offset: 0x00002BDC
		[Description("Indicates the font that is used to draw the item.")]
		[AmbientValue(null)]
		[Category("Appearance")]
		public Font Font
		{
			get
			{
				if (this.x26094932cf7a9139 != null)
				{
					return this.x26094932cf7a9139;
				}
				return this.DefaultFont;
			}
			set
			{
				this.x26094932cf7a9139 = value;
				this.LayoutNeeded();
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000042 RID: 66 RVA: 0x00003BEC File Offset: 0x00002BEC
		internal virtual Font DefaultFont
		{
			get
			{
				if (this.ToolBar != null)
				{
					return this.ToolBar.Font;
				}
				return Control.DefaultFont;
			}
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00003C08 File Offset: 0x00002C08
		private bool ShouldSerializeFont()
		{
			return this.x26094932cf7a9139 != null;
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000044 RID: 68 RVA: 0x00003C18 File Offset: 0x00002C18
		// (set) Token: 0x06000045 RID: 69 RVA: 0x00003C20 File Offset: 0x00002C20
		[Description("The foreground color used to display text in this item.")]
		[Category("Appearance")]
		[DefaultValue(typeof(Color), "ControlText")]
		public Color ForeColor
		{
			get
			{
				return this.x93532ca0ace0c1ae;
			}
			set
			{
				this.x93532ca0ace0c1ae = value;
				this.Invalidate();
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000046 RID: 70 RVA: 0x00003C30 File Offset: 0x00002C30
		[Browsable(false)]
		public bool HiddenFromCurrentView
		{
			get
			{
				return this.x3780ff57150950cd;
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000047 RID: 71 RVA: 0x00003C38 File Offset: 0x00002C38
		// (set) Token: 0x06000048 RID: 72 RVA: 0x00003C40 File Offset: 0x00002C40
		[DefaultValue(typeof(ItemMergeAction), "MergeChildren")]
		[Description("How to merge this item with the equivalent collection of items on a merge target.")]
		[Category("Merging")]
		public ItemMergeAction MergeAction
		{
			get
			{
				return this.xab052a17976d6c87;
			}
			set
			{
				if (value == ItemMergeAction.MergeChildren && !(this is MenuItemBase))
				{
					throw new ArgumentException("MergeChildren is only valid on menu items.");
				}
				this.xab052a17976d6c87 = value;
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000049 RID: 73 RVA: 0x00003C60 File Offset: 0x00002C60
		// (set) Token: 0x0600004A RID: 74 RVA: 0x00003C68 File Offset: 0x00002C68
		[Description("The index of the matching menu item on the target.")]
		[DefaultValue(-1)]
		[Category("Merging")]
		public int MergeIndex
		{
			get
			{
				return this.xfde93dea28494a02;
			}
			set
			{
				this.xfde93dea28494a02 = value;
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x0600004B RID: 75 RVA: 0x00003C74 File Offset: 0x00002C74
		// (set) Token: 0x0600004C RID: 76 RVA: 0x00003C7C File Offset: 0x00002C7C
		[DefaultValue(0)]
		[Description("The minimum amount of toolbar space the item will occupy.")]
		[Category("Behavior")]
		public virtual int MinimumSize
		{
			get
			{
				return this.x5cf198ac0488ae74;
			}
			set
			{
				if (value < 0)
				{
					throw new ArgumentException("Value must be positive.");
				}
				this.x5cf198ac0488ae74 = value;
				this.LayoutNeeded();
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x0600004D RID: 77 RVA: 0x00003C9C File Offset: 0x00002C9C
		// (set) Token: 0x0600004E RID: 78 RVA: 0x00003CA4 File Offset: 0x00002CA4
		[Description("Indicates whether the item will stretch to fill all available space in its container.")]
		[DefaultValue(false)]
		[Category("Layout")]
		public bool Stretch
		{
			get
			{
				return this.x4138104f20394708;
			}
			set
			{
				if (value != this.x4138104f20394708)
				{
					this.x4138104f20394708 = value;
					this.LayoutNeeded();
				}
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x0600004F RID: 79 RVA: 0x00003CBC File Offset: 0x00002CBC
		// (set) Token: 0x06000050 RID: 80 RVA: 0x00003CC4 File Offset: 0x00002CC4
		[Description("Indicates the importance of the item. Items with lower importance are hidden first when short of space.")]
		[Category("Behavior")]
		[DefaultValue(typeof(ItemImportance), "Medium")]
		public virtual ItemImportance ItemImportance
		{
			get
			{
				return this.x22700e7299dd036a;
			}
			set
			{
				this.x22700e7299dd036a = value;
				this.LayoutNeeded();
			}
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00003CD4 File Offset: 0x00002CD4
		protected internal virtual void ApplyLayout(Rectangle buttonBounds, Graphics graphics, bool vertical, bool rightToLeft)
		{
			this.xe1c70196e644fa71 = buttonBounds;
			this.x0bd0d09521a6c8ef = buttonBounds;
			if (buttonBounds != Rectangle.Empty)
			{
				if (vertical)
				{
					this.x0bd0d09521a6c8ef = new Rectangle(buttonBounds.X + this.Padding.Bottom, buttonBounds.Y + this.Padding.Left, buttonBounds.Width - (this.Padding.Top + this.Padding.Bottom), buttonBounds.Height - (this.Padding.Left + this.Padding.Right));
				}
				else
				{
					this.x0bd0d09521a6c8ef = new Rectangle(buttonBounds.X + this.Padding.Left, buttonBounds.Y + this.Padding.Top, buttonBounds.Width - (this.Padding.Left + this.Padding.Right), buttonBounds.Height - (this.Padding.Top + this.Padding.Bottom));
				}
			}
			if (this.x3de314ab70bbd9bf)
			{
				if (vertical && rightToLeft)
				{
					this.xa92e62bde95607f6 = new Rectangle(buttonBounds.X, buttonBounds.Bottom + 3, buttonBounds.Width, 7);
					return;
				}
				if (vertical && !rightToLeft)
				{
					this.xa92e62bde95607f6 = new Rectangle(buttonBounds.X, buttonBounds.Y + 2 - 7, buttonBounds.Width, 7);
					return;
				}
				if (!vertical && rightToLeft)
				{
					this.xa92e62bde95607f6 = new Rectangle(buttonBounds.Right + 3, buttonBounds.Y, 7, buttonBounds.Height);
					return;
				}
				if (!vertical && !rightToLeft)
				{
					this.xa92e62bde95607f6 = new Rectangle(buttonBounds.X + 2 - 7, buttonBounds.Y, 7, buttonBounds.Height);
				}
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000052 RID: 82 RVA: 0x00003E9C File Offset: 0x00002E9C
		// (set) Token: 0x06000053 RID: 83 RVA: 0x00003EA4 File Offset: 0x00002EA4
		[TypeConverter(typeof(StringConverter))]
		[Browsable(true)]
		[DefaultValue(typeof(object), null)]
		public object Tag
		{
			get
			{
				return this._xffe521cc76054baf;
			}
			set
			{
				this._xffe521cc76054baf = value;
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000054 RID: 84 RVA: 0x00003EB0 File Offset: 0x00002EB0
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Category("Layout")]
		[Description("Controls the amount of space between the highlight and the item content.")]
		public ToolbarItemBase.ItemPadding Padding
		{
			get
			{
				return this._xcaf2e4729806e32b;
			}
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00003EB8 File Offset: 0x00002EB8
		private void ResetPadding()
		{
			this.Padding.x74f5a1ef3906e23c();
			this.LayoutNeeded();
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000056 RID: 86 RVA: 0x00003ECC File Offset: 0x00002ECC
		internal virtual IToolBarItemBaseCollectionHost Owner
		{
			get
			{
				return this._x169279a87b6b72b2;
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000057 RID: 87 RVA: 0x00003ED4 File Offset: 0x00002ED4
		[Browsable(false)]
		public ToolBar ToolBar
		{
			get
			{
				return this._x169279a87b6b72b2;
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000058 RID: 88 RVA: 0x00003EDC File Offset: 0x00002EDC
		[Browsable(false)]
		public Rectangle ButtonBounds
		{
			get
			{
				return this.xe1c70196e644fa71;
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000059 RID: 89 RVA: 0x00003EE4 File Offset: 0x00002EE4
		[Browsable(false)]
		public Rectangle ButtonInnerBounds
		{
			get
			{
				return this.x0bd0d09521a6c8ef;
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x0600005A RID: 90
		[Browsable(false)]
		public abstract Rectangle TextBounds { get; }

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x0600005B RID: 91 RVA: 0x00003EEC File Offset: 0x00002EEC
		// (set) Token: 0x0600005C RID: 92 RVA: 0x00003EF4 File Offset: 0x00002EF4
		[Category("Appearance")]
		[DefaultValue("")]
		[Localizable(true)]
		[Description("The text associated with this toolbar item.")]
		public virtual string Text
		{
			get
			{
				return this._xd1020a9db563b699;
			}
			set
			{
				if (value == null)
				{
					value = "";
				}
				this._xd1020a9db563b699 = value;
				this.LayoutNeeded();
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x0600005D RID: 93 RVA: 0x00003F10 File Offset: 0x00002F10
		// (set) Token: 0x0600005E RID: 94 RVA: 0x00003F18 File Offset: 0x00002F18
		[Description("Indicates whether this item is visible or not.")]
		[DefaultValue(true)]
		[Category("Behavior")]
		public virtual bool Visible
		{
			get
			{
				return this._x364c1e3b189d47fe;
			}
			set
			{
				this._x364c1e3b189d47fe = value;
				this.LayoutNeeded();
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x0600005F RID: 95 RVA: 0x00003F28 File Offset: 0x00002F28
		// (set) Token: 0x06000060 RID: 96 RVA: 0x00003F30 File Offset: 0x00002F30
		[Localizable(true)]
		[Category("Appearance")]
		[DefaultValue("")]
		[Description("Gets or sets the text that appears as a ToolTip for the toolbar item.")]
		public virtual string ToolTipText
		{
			get
			{
				return this._xd84978f0dad7afcd;
			}
			set
			{
				if (value == null)
				{
					value = "";
				}
				this._xd84978f0dad7afcd = value;
			}
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00003F44 File Offset: 0x00002F44
		internal void SetToolbar(ToolBar toolbar)
		{
			this._x169279a87b6b72b2 = toolbar;
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000062 RID: 98 RVA: 0x00003F50 File Offset: 0x00002F50
		// (set) Token: 0x06000063 RID: 99 RVA: 0x00003F58 File Offset: 0x00002F58
		[DefaultValue(true)]
		[Category("Behavior")]
		[Description("Gets or sets a value indicating whether the item is enabled.")]
		public virtual bool Enabled
		{
			get
			{
				return this._x2fef7d841879a711;
			}
			set
			{
				if (this._x2fef7d841879a711 != value)
				{
					this._x2fef7d841879a711 = value;
					if (this.ToolBar != null && !value)
					{
						this.ToolBar.x2407369b053315a8(this);
					}
					this.Invalidate();
				}
			}
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00003F88 File Offset: 0x00002F88
		public virtual void Invalidate()
		{
			if (this._x169279a87b6b72b2 != null)
			{
				Rectangle rc = this.xe1c70196e644fa71;
				rc.Inflate(5, 5);
				this._x169279a87b6b72b2.Invalidate(rc);
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000065 RID: 101 RVA: 0x00003FBC File Offset: 0x00002FBC
		// (set) Token: 0x06000066 RID: 102 RVA: 0x00003FC4 File Offset: 0x00002FC4
		[DefaultValue(false)]
		[Description("Indicates whether the item will be preceeded by a separator.")]
		[Category("Appearance")]
		public virtual bool BeginGroup
		{
			get
			{
				return this._x5618686d5894de8e;
			}
			set
			{
				this._x5618686d5894de8e = value;
				this.LayoutNeeded();
			}
		}

		// Token: 0x06000067 RID: 103 RVA: 0x00003FD4 File Offset: 0x00002FD4
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.ToolBar != null && this.ToolBar.Items.Contains(this))
			{
				this.ToolBar.Items.Remove(this);
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000068 RID: 104 RVA: 0x0000400C File Offset: 0x0000300C
		internal virtual void LayoutNeeded()
		{
			if (this._x169279a87b6b72b2 != null)
			{
				this._x169279a87b6b72b2.xcf42ad4a4f3fcbf6();
			}
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00004024 File Offset: 0x00003024
		public object Clone()
		{
			return this.CloneItem();
		}

		// Token: 0x04000006 RID: 6
		private bool _x5618686d5894de8e;

		// Token: 0x04000007 RID: 7
		private bool _x2fef7d841879a711 = true;

		// Token: 0x04000008 RID: 8
		private bool _x364c1e3b189d47fe = true;

		// Token: 0x04000009 RID: 9
		private string _xd1020a9db563b699 = "";

		// Token: 0x0400000A RID: 10
		private ToolbarItemBase.ItemPadding _xcaf2e4729806e32b;

		// Token: 0x0400000B RID: 11
		private object _xffe521cc76054baf;

		// Token: 0x0400000C RID: 12
		private ItemImportance x22700e7299dd036a = ItemImportance.Medium;

		// Token: 0x0400000D RID: 13
		private int x5cf198ac0488ae74;

		// Token: 0x0400000E RID: 14
		private Font x26094932cf7a9139;

		// Token: 0x0400000F RID: 15
		private Color x93532ca0ace0c1ae = SystemColors.ControlText;

		// Token: 0x04000010 RID: 16
		private bool x4138104f20394708;

		// Token: 0x04000011 RID: 17
		private ToolBar _x169279a87b6b72b2;

		// Token: 0x04000012 RID: 18
		private Rectangle x0bd0d09521a6c8ef = Rectangle.Empty;

		// Token: 0x04000013 RID: 19
		private Rectangle xe1c70196e644fa71 = Rectangle.Empty;

		// Token: 0x04000014 RID: 20
		internal Size x8f61b3344614569b;

		// Token: 0x04000015 RID: 21
		internal Size x431c36f4c0c5b98d;

		// Token: 0x04000016 RID: 22
		internal bool x3780ff57150950cd;

		// Token: 0x04000017 RID: 23
		internal int xcad45d9e26d3a755;

		// Token: 0x04000018 RID: 24
		internal int x9be9d8a5ea186c43;

		// Token: 0x04000019 RID: 25
		internal bool x3de314ab70bbd9bf;

		// Token: 0x0400001A RID: 26
		internal Rectangle x4c41994726d9329e;

		// Token: 0x0400001B RID: 27
		internal Rectangle xa92e62bde95607f6;

		// Token: 0x0400001C RID: 28
		private string _xd84978f0dad7afcd = "";

		// Token: 0x0400001D RID: 29
		private ItemMergeAction xab052a17976d6c87 = ItemMergeAction.MergeChildren;

		// Token: 0x0400001E RID: 30
		private int xfde93dea28494a02 = -1;

		// Token: 0x0400001F RID: 31
		internal int x90db551379a5ba1c = -1;

		// Token: 0x04000020 RID: 32
		private EventHandler x5b7f6ddd07ded8cd;

		// Token: 0x0200000A RID: 10
		[TypeConverter(typeof(ExpandableObjectConverter))]
		public class ItemPadding
		{
			// Token: 0x0600006A RID: 106 RVA: 0x0000402C File Offset: 0x0000302C
			internal ItemPadding(ToolbarItemBase parent, int defaultTop, int defaultLeft, int defaultBottom, int defaultRight)
			{
				this.xb6a159a84cb992d6 = parent;
				this.xf1e25cfbf273d33f = defaultTop;
				this.x2af5abe6cd2052ab = defaultLeft;
				this.xca9c209028e8aad6 = defaultRight;
				this.xd75049adb9178a61 = defaultBottom;
				this.x74f5a1ef3906e23c();
			}

			// Token: 0x0600006B RID: 107 RVA: 0x00004060 File Offset: 0x00003060
			internal void x74f5a1ef3906e23c()
			{
				this.xc941868c59399d3e = this.xf1e25cfbf273d33f;
				this.xa447fc54e41dfe06 = this.x2af5abe6cd2052ab;
				this.xfc2074a859a5db8c = this.xca9c209028e8aad6;
				this.xaf9a0436a70689de = this.xd75049adb9178a61;
			}

			// Token: 0x0600006C RID: 108 RVA: 0x00004094 File Offset: 0x00003094
			private bool ShouldSerializeTop()
			{
				return this.Top != this.xf1e25cfbf273d33f;
			}

			// Token: 0x17000024 RID: 36
			// (get) Token: 0x0600006D RID: 109 RVA: 0x000040A8 File Offset: 0x000030A8
			// (set) Token: 0x0600006E RID: 110 RVA: 0x000040B0 File Offset: 0x000030B0
			public int Top
			{
				get
				{
					return this.xc941868c59399d3e;
				}
				set
				{
					this.xc941868c59399d3e = value;
					this.xb6a159a84cb992d6.LayoutNeeded();
				}
			}

			// Token: 0x0600006F RID: 111 RVA: 0x000040C4 File Offset: 0x000030C4
			private bool ShouldSerializeLeft()
			{
				return this.Left != this.x2af5abe6cd2052ab;
			}

			// Token: 0x17000025 RID: 37
			// (get) Token: 0x06000070 RID: 112 RVA: 0x000040D8 File Offset: 0x000030D8
			// (set) Token: 0x06000071 RID: 113 RVA: 0x000040E0 File Offset: 0x000030E0
			public int Left
			{
				get
				{
					return this.xa447fc54e41dfe06;
				}
				set
				{
					this.xa447fc54e41dfe06 = value;
					this.xb6a159a84cb992d6.LayoutNeeded();
				}
			}

			// Token: 0x06000072 RID: 114 RVA: 0x000040F4 File Offset: 0x000030F4
			private bool ShouldSerializeBottom()
			{
				return this.Bottom != this.xd75049adb9178a61;
			}

			// Token: 0x17000026 RID: 38
			// (get) Token: 0x06000073 RID: 115 RVA: 0x00004108 File Offset: 0x00003108
			// (set) Token: 0x06000074 RID: 116 RVA: 0x00004110 File Offset: 0x00003110
			public int Bottom
			{
				get
				{
					return this.xaf9a0436a70689de;
				}
				set
				{
					this.xaf9a0436a70689de = value;
					this.xb6a159a84cb992d6.LayoutNeeded();
				}
			}

			// Token: 0x06000075 RID: 117 RVA: 0x00004124 File Offset: 0x00003124
			private bool ShouldSerializeRight()
			{
				return this.Right != this.xca9c209028e8aad6;
			}

			// Token: 0x17000027 RID: 39
			// (get) Token: 0x06000076 RID: 118 RVA: 0x00004138 File Offset: 0x00003138
			// (set) Token: 0x06000077 RID: 119 RVA: 0x00004140 File Offset: 0x00003140
			public int Right
			{
				get
				{
					return this.xfc2074a859a5db8c;
				}
				set
				{
					this.xfc2074a859a5db8c = value;
					this.xb6a159a84cb992d6.LayoutNeeded();
				}
			}

			// Token: 0x04000021 RID: 33
			private ToolbarItemBase xb6a159a84cb992d6;

			// Token: 0x04000022 RID: 34
			private int xc941868c59399d3e;

			// Token: 0x04000023 RID: 35
			private int xa447fc54e41dfe06;

			// Token: 0x04000024 RID: 36
			private int xfc2074a859a5db8c;

			// Token: 0x04000025 RID: 37
			private int xaf9a0436a70689de;

			// Token: 0x04000026 RID: 38
			private int xf1e25cfbf273d33f;

			// Token: 0x04000027 RID: 39
			private int x2af5abe6cd2052ab;

			// Token: 0x04000028 RID: 40
			private int xd75049adb9178a61;

			// Token: 0x04000029 RID: 41
			private int xca9c209028e8aad6;
		}
	}
}
