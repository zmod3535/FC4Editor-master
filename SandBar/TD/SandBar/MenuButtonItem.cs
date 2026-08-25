using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace TD.SandBar
{
	// Token: 0x02000015 RID: 21
	[DefaultEvent("Activate")]
	public class MenuButtonItem : MenuItemBase
	{
		// Token: 0x14000007 RID: 7
		// (add) Token: 0x0600013E RID: 318 RVA: 0x00006538 File Offset: 0x00005538
		// (remove) Token: 0x0600013F RID: 319 RVA: 0x00006554 File Offset: 0x00005554
		internal event EventHandler x295cb4a1df7a5add;

		// Token: 0x14000008 RID: 8
		// (add) Token: 0x06000140 RID: 320 RVA: 0x00006570 File Offset: 0x00005570
		// (remove) Token: 0x06000141 RID: 321 RVA: 0x0000658C File Offset: 0x0000558C
		public event EventHandler Select
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.xbec03ac07d5e4cdf = (EventHandler)Delegate.Combine(this.xbec03ac07d5e4cdf, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.xbec03ac07d5e4cdf = (EventHandler)Delegate.Remove(this.xbec03ac07d5e4cdf, value);
			}
		}

		// Token: 0x06000142 RID: 322 RVA: 0x000065A8 File Offset: 0x000055A8
		public MenuButtonItem()
		{
		}

		// Token: 0x06000143 RID: 323 RVA: 0x000065C8 File Offset: 0x000055C8
		public MenuButtonItem(string text) : base(text)
		{
		}

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x06000144 RID: 324 RVA: 0x000065E8 File Offset: 0x000055E8
		internal override IToolBarItemBaseCollectionHost Owner
		{
			get
			{
				return base.Parent;
			}
		}

		// Token: 0x06000145 RID: 325 RVA: 0x000065F0 File Offset: 0x000055F0
		public override ToolbarItemBase CloneItem()
		{
			MenuButtonItem menuButtonItem = (MenuButtonItem)base.CloneItem();
			menuButtonItem.PrimaryShortcut = this.PrimaryShortcut;
			menuButtonItem.SecondaryShortcut = this.SecondaryShortcut;
			menuButtonItem.xbec03ac07d5e4cdf = this.xbec03ac07d5e4cdf;
			return menuButtonItem;
		}

		// Token: 0x06000146 RID: 326 RVA: 0x00006630 File Offset: 0x00005630
		public MenuButtonItem(string text, EventHandler eventHandler) : this(text)
		{
			base.Activate += eventHandler;
		}

		// Token: 0x06000147 RID: 327 RVA: 0x00006640 File Offset: 0x00005640
		protected internal void OnSelect()
		{
			if (this.xbec03ac07d5e4cdf != null)
			{
				this.xbec03ac07d5e4cdf(this, EventArgs.Empty);
			}
		}

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x06000148 RID: 328 RVA: 0x0000665C File Offset: 0x0000565C
		// (set) Token: 0x06000149 RID: 329 RVA: 0x00006664 File Offset: 0x00005664
		[Description("Indicates whether the menu item will initially be displayed in the menu or will be accessible via a chevron.")]
		public override ItemImportance ItemImportance
		{
			get
			{
				return base.ItemImportance;
			}
			set
			{
				if (value != ItemImportance.Medium && value != ItemImportance.Low)
				{
					throw new ArgumentException("Only Medium and Low are acceptable values for menu items.");
				}
				base.ItemImportance = value;
			}
		}

		// Token: 0x0600014A RID: 330 RVA: 0x00006680 File Offset: 0x00005680
		internal bool x54994c015fecc727()
		{
			if (!this.Enabled)
			{
				return false;
			}
			MenuItemBase menuItemBase = this;
			do
			{
				menuItemBase = menuItemBase.Parent;
				if (menuItemBase == null)
				{
					return true;
				}
			}
			while (menuItemBase.Enabled);
			return false;
		}

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x0600014B RID: 331 RVA: 0x000066B0 File Offset: 0x000056B0
		// (set) Token: 0x0600014C RID: 332 RVA: 0x000066CC File Offset: 0x000056CC
		[Localizable(true)]
		[Category("Appearance")]
		[Description("The text shown as a description for the shortcut for the item.")]
		public string ShortcutDisplayString
		{
			get
			{
				if (this.x40bf76510a8d3cd9.Length == 0)
				{
					return this.x1f866fddc5dcb3a3();
				}
				return this.x40bf76510a8d3cd9;
			}
			set
			{
				if (value == null)
				{
					value = string.Empty;
				}
				this.x40bf76510a8d3cd9 = value;
				this.LayoutNeeded();
			}
		}

		// Token: 0x0600014D RID: 333 RVA: 0x000066E8 File Offset: 0x000056E8
		private void ResetShortcutDisplayString()
		{
			this.ShortcutDisplayString = string.Empty;
		}

		// Token: 0x0600014E RID: 334 RVA: 0x000066F8 File Offset: 0x000056F8
		private bool ShouldSerializeShortcutDisplayString()
		{
			return this.x40bf76510a8d3cd9.Length != 0;
		}

		// Token: 0x0600014F RID: 335 RVA: 0x0000670C File Offset: 0x0000570C
		private string x1f866fddc5dcb3a3()
		{
			if (this.x27c523a532a84d07.Length == 0 && this.x167e91b6ef93398c != Keys.None)
			{
				KeysConverter keysConverter = (KeysConverter)TypeDescriptor.GetConverter(typeof(Keys));
				string text = keysConverter.ConvertToString(this.x167e91b6ef93398c);
				if (text.Length >= 3 && text.Substring(text.Length - 3, 1) == "+" && text.Substring(text.Length - 2, 1) == "D")
				{
					text = text.Substring(0, text.Length - 2) + text.Substring(text.Length - 1, 1);
				}
				string text2 = "";
				if (this.x9fcd3fa8a812c3df != Keys.None)
				{
					text2 = keysConverter.ConvertToString(this.x9fcd3fa8a812c3df);
					if (text2.Length >= 3 && text2.Substring(text2.Length - 3, 1) == "+" && text2.Substring(text2.Length - 2, 1) == "D")
					{
						text2 = text2.Substring(0, text2.Length - 2) + text2.Substring(text2.Length - 1, 1);
					}
				}
				this.x27c523a532a84d07 = ((text2.Length != 0) ? (text + ", " + text2) : text);
			}
			return this.x27c523a532a84d07;
		}

		// Token: 0x06000150 RID: 336 RVA: 0x00006864 File Offset: 0x00005864
		internal override void LayoutNeeded()
		{
			base.LayoutNeeded();
			if (base.Parent != null && base.Parent.Popup != null)
			{
				base.Parent.Popup.xcf42ad4a4f3fcbf6();
			}
		}

		// Token: 0x06000151 RID: 337 RVA: 0x00006894 File Offset: 0x00005894
		public override void Invalidate()
		{
			if (base.Parent != null && base.Parent.Popup != null)
			{
				Rectangle buttonBounds = base.ButtonBounds;
				buttonBounds.Inflate(2, 2);
				base.Parent.Popup.Invalidate(buttonBounds);
			}
		}

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x06000152 RID: 338 RVA: 0x000068D8 File Offset: 0x000058D8
		// (set) Token: 0x06000153 RID: 339 RVA: 0x00006918 File Offset: 0x00005918
		[Description("Indicates the key combination that will activate this menu item.")]
		[Category("Behavior")]
		[Localizable(true)]
		[DefaultValue(typeof(Shortcut), "None")]
		public Shortcut Shortcut
		{
			get
			{
				Shortcut primaryShortcut;
				try
				{
					primaryShortcut = (Shortcut)this.PrimaryShortcut;
				}
				catch
				{
					throw new InvalidOperationException("An advanced key combination that cannot be represented by the Shortcut enumeration has been used.");
				}
				return primaryShortcut;
			}
			set
			{
				this.PrimaryShortcut = (Keys)value;
			}
		}

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x06000154 RID: 340 RVA: 0x00006924 File Offset: 0x00005924
		// (set) Token: 0x06000155 RID: 341 RVA: 0x00006964 File Offset: 0x00005964
		[DefaultValue(typeof(Shortcut), "None")]
		[Localizable(true)]
		[Description("The second key combination that will activate the item after the first is activated.")]
		[Category("Behavior")]
		public Shortcut Shortcut2
		{
			get
			{
				Shortcut secondaryShortcut;
				try
				{
					secondaryShortcut = (Shortcut)this.SecondaryShortcut;
				}
				catch
				{
					throw new InvalidOperationException("An advanced key combination that cannot be represented by the Shortcut enumeration has been used.");
				}
				return secondaryShortcut;
			}
			set
			{
				this.SecondaryShortcut = (Keys)value;
			}
		}

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x06000156 RID: 342 RVA: 0x00006970 File Offset: 0x00005970
		// (set) Token: 0x06000157 RID: 343 RVA: 0x00006978 File Offset: 0x00005978
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("The combination of keys that will activate this item.")]
		[Category("Behavior")]
		public Keys PrimaryShortcut
		{
			get
			{
				return this.x167e91b6ef93398c;
			}
			set
			{
				this.x167e91b6ef93398c = value;
				this.x27c523a532a84d07 = "";
				if (base.Parent != null)
				{
					base.Parent.xcedf4ee3756f36dc();
				}
				this.LayoutNeeded();
			}
		}

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x06000158 RID: 344 RVA: 0x000069A8 File Offset: 0x000059A8
		// (set) Token: 0x06000159 RID: 345 RVA: 0x000069B0 File Offset: 0x000059B0
		[Browsable(false)]
		[Description("The second key combination that will activate the item after the first is activated.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Category("Behavior")]
		public Keys SecondaryShortcut
		{
			get
			{
				return this.x9fcd3fa8a812c3df;
			}
			set
			{
				this.x9fcd3fa8a812c3df = value;
				this.x27c523a532a84d07 = "";
				if (base.Parent != null)
				{
					base.Parent.xcedf4ee3756f36dc();
				}
				this.LayoutNeeded();
			}
		}

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x0600015A RID: 346 RVA: 0x000069E0 File Offset: 0x000059E0
		public override ImageList ImageList
		{
			get
			{
				MenuItemBase menuItemBase = this;
				while (menuItemBase.Parent != null)
				{
					menuItemBase = menuItemBase.Parent;
				}
				if (menuItemBase is DropDownMenuItem && ((DropDownMenuItem)menuItemBase).MenuImageList != null)
				{
					return ((DropDownMenuItem)menuItemBase).MenuImageList;
				}
				return menuItemBase.ToolBar.ImageList;
			}
		}

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x0600015B RID: 347 RVA: 0x00006A2C File Offset: 0x00005A2C
		// (set) Token: 0x0600015C RID: 348 RVA: 0x00006A34 File Offset: 0x00005A34
		public override bool Checked
		{
			get
			{
				return base.Checked;
			}
			set
			{
				base.Checked = value;
				if (this.x295cb4a1df7a5add != null)
				{
					this.x295cb4a1df7a5add(this, EventArgs.Empty);
				}
			}
		}

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x0600015D RID: 349 RVA: 0x00006A58 File Offset: 0x00005A58
		// (set) Token: 0x0600015E RID: 350 RVA: 0x00006A60 File Offset: 0x00005A60
		public override bool Enabled
		{
			get
			{
				return base.Enabled;
			}
			set
			{
				base.Enabled = value;
				if (this.x295cb4a1df7a5add != null)
				{
					this.x295cb4a1df7a5add(this, EventArgs.Empty);
				}
			}
		}

		// Token: 0x0400007A RID: 122
		private Keys x167e91b6ef93398c;

		// Token: 0x0400007B RID: 123
		private Keys x9fcd3fa8a812c3df;

		// Token: 0x0400007C RID: 124
		private string x27c523a532a84d07 = string.Empty;

		// Token: 0x0400007D RID: 125
		private string x40bf76510a8d3cd9 = string.Empty;

		// Token: 0x0400007F RID: 127
		private EventHandler xbec03ac07d5e4cdf;
	}
}
