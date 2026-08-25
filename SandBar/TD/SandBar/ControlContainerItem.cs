using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using TD.SandBar.Design;

namespace TD.SandBar
{
	// Token: 0x0200000E RID: 14
	[Designer(typeof(ControlContainerItemDesigner))]
	public abstract class ControlContainerItem : ToolbarItemBase
	{
		// Token: 0x0600011E RID: 286 RVA: 0x00006134 File Offset: 0x00005134
		protected ControlContainerItem(Control control)
		{
			if (control == null)
			{
				throw new ArgumentNullException();
			}
			this.x43bec302f92080b9 = control;
			this.x00e3ff1770a00e41 = new ToolTip();
		}

		// Token: 0x0600011F RID: 287 RVA: 0x00006160 File Offset: 0x00005160
		internal override ToolbarItemBase.ItemPadding CreateDefaultPadding()
		{
			return new ToolbarItemBase.ItemPadding(this, 0, 1, 0, 1);
		}

		// Token: 0x06000120 RID: 288 RVA: 0x0000616C File Offset: 0x0000516C
		protected internal override void OnActivate()
		{
			if (this.ContainedControl.CanFocus)
			{
				this.ContainedControl.Focus();
			}
			base.OnActivate();
		}

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x06000121 RID: 289 RVA: 0x00006190 File Offset: 0x00005190
		public override Rectangle TextBounds
		{
			get
			{
				return base.ButtonInnerBounds;
			}
		}

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x06000122 RID: 290 RVA: 0x00006198 File Offset: 0x00005198
		// (set) Token: 0x06000123 RID: 291 RVA: 0x000061A0 File Offset: 0x000051A0
		public override string ToolTipText
		{
			get
			{
				return base.ToolTipText;
			}
			set
			{
				base.ToolTipText = value;
				this.x00e3ff1770a00e41.SetToolTip(this.x43bec302f92080b9, value);
			}
		}

		// Token: 0x06000124 RID: 292 RVA: 0x000061BC File Offset: 0x000051BC
		protected internal override void ApplyLayout(Rectangle buttonBounds, Graphics graphics, bool vertical, bool rightToLeft)
		{
			base.ApplyLayout(buttonBounds, graphics, vertical, rightToLeft);
			Rectangle buttonInnerBounds = base.ButtonInnerBounds;
			if (base.ToolBar != null)
			{
				this.xecd9c96127670095 = base.ButtonInnerBounds;
				int num = 0;
				if (this.Text.Length != 0)
				{
					using (StringFormat stringFormat = new StringFormat(StringFormat.GenericTypographic))
					{
						stringFormat.HotkeyPrefix = HotkeyPrefix.Hide;
						num = Size.Ceiling(graphics.MeasureString(this.Text, base.ToolBar.Font, int.MaxValue, stringFormat)).Width + 3;
					}
				}
				this.xecd9c96127670095.X = this.xecd9c96127670095.X + num;
				this.xecd9c96127670095.Width = this.xecd9c96127670095.Width - num;
				this.ContainedControl.Bounds = this.xecd9c96127670095;
			}
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x06000125 RID: 293 RVA: 0x000062A0 File Offset: 0x000052A0
		// (set) Token: 0x06000126 RID: 294 RVA: 0x000062B0 File Offset: 0x000052B0
		[Category("Appearance")]
		[Description("The text contained in the control.")]
		[DefaultValue("")]
		public string ControlText
		{
			get
			{
				return this.x43bec302f92080b9.Text;
			}
			set
			{
				this.x43bec302f92080b9.Text = value;
			}
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x06000127 RID: 295 RVA: 0x000062C0 File Offset: 0x000052C0
		// (set) Token: 0x06000128 RID: 296 RVA: 0x000062C8 File Offset: 0x000052C8
		[Description("Sets the minimum acceptable width of the hosted control.")]
		[Category("Layout")]
		public virtual int MinimumControlWidth
		{
			get
			{
				return this.x84434e4700fbd6e8;
			}
			set
			{
				this.x84434e4700fbd6e8 = value;
				this.LayoutNeeded();
			}
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x06000129 RID: 297 RVA: 0x000062D8 File Offset: 0x000052D8
		// (set) Token: 0x0600012A RID: 298 RVA: 0x000062E8 File Offset: 0x000052E8
		[Description("Sets the height of the hosted control.")]
		[Category("Layout")]
		public int ControlHeight
		{
			get
			{
				return this.ContainedControl.Height;
			}
			set
			{
				if (value != this.ContainedControl.Height)
				{
					this.ContainedControl.Height = value;
					this.LayoutNeeded();
				}
			}
		}

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x0600012B RID: 299 RVA: 0x0000630C File Offset: 0x0000530C
		[Browsable(false)]
		public Control ContainedControl
		{
			get
			{
				return this.x43bec302f92080b9;
			}
		}

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x0600012C RID: 300 RVA: 0x00006314 File Offset: 0x00005314
		// (set) Token: 0x0600012D RID: 301 RVA: 0x0000631C File Offset: 0x0000531C
		[DefaultValue(true)]
		public override bool Enabled
		{
			get
			{
				return base.Enabled;
			}
			set
			{
				base.Enabled = value;
				if (!base.DesignMode)
				{
					this.x43bec302f92080b9.Enabled = value;
				}
			}
		}

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x0600012E RID: 302 RVA: 0x0000633C File Offset: 0x0000533C
		// (set) Token: 0x0600012F RID: 303 RVA: 0x00006344 File Offset: 0x00005344
		[DefaultValue(true)]
		[Description("Indicates whether this item is visible or not.")]
		public override bool Visible
		{
			get
			{
				return base.Visible;
			}
			set
			{
				this.x43bec302f92080b9.Visible = (value && !base.HiddenFromCurrentView);
				base.Visible = value;
			}
		}

		// Token: 0x06000130 RID: 304 RVA: 0x00006368 File Offset: 0x00005368
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				this.x43bec302f92080b9.Dispose();
				this.x00e3ff1770a00e41.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x04000065 RID: 101
		private Control x43bec302f92080b9;

		// Token: 0x04000066 RID: 102
		private ToolTip x00e3ff1770a00e41;

		// Token: 0x04000067 RID: 103
		private int x84434e4700fbd6e8 = 50;

		// Token: 0x04000068 RID: 104
		internal Rectangle xecd9c96127670095;
	}
}
