using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;

namespace TD.SandBar
{
	// Token: 0x0200001C RID: 28
	public abstract class ImageItemBase : ToolbarItemBase
	{
		// Token: 0x060001CB RID: 459 RVA: 0x000084CC File Offset: 0x000074CC
		internal ImageItemBase()
		{
		}

		// Token: 0x060001CC RID: 460 RVA: 0x000084EC File Offset: 0x000074EC
		public override ToolbarItemBase CloneItem()
		{
			ImageItemBase imageItemBase = (ImageItemBase)base.CloneItem();
			if (this.Icon != null)
			{
				imageItemBase.Icon = (Icon)this.Icon.Clone();
			}
			imageItemBase.IconSize = this.IconSize;
			if (this.Image != null)
			{
				imageItemBase.Image = (Image)this.Image.Clone();
			}
			imageItemBase.ImageIndex = this.ImageIndex;
			return imageItemBase;
		}

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x060001CD RID: 461 RVA: 0x0000855C File Offset: 0x0000755C
		public override Rectangle TextBounds
		{
			get
			{
				return this.x0961517ffd55017f;
			}
		}

		// Token: 0x060001CE RID: 462 RVA: 0x00008564 File Offset: 0x00007564
		protected internal override void ApplyLayout(Rectangle buttonBounds, Graphics graphics, bool vertical, bool rightToLeft)
		{
			base.ApplyLayout(buttonBounds, graphics, vertical, rightToLeft);
			this.LayoutImageAndText(base.ButtonInnerBounds, vertical, rightToLeft);
		}

		// Token: 0x060001CF RID: 463 RVA: 0x00008580 File Offset: 0x00007580
		protected void LayoutImageAndText(Rectangle bounds, bool vertical, bool rightToLeft)
		{
			if (base.ToolBar != null)
			{
				this.x276b886698b780bd(bounds, vertical, rightToLeft, base.ToolBar.TextAlign, base.ToolBar.ImageList);
			}
		}

		// Token: 0x060001D0 RID: 464 RVA: 0x000085AC File Offset: 0x000075AC
		internal void x276b886698b780bd(Rectangle xda73fcb97c77d998, bool xa092001467a0ab7b, bool xcb35b7c43d7acd61, ToolBarTextAlign xe4f97a5cc9204c1f, ImageList x6ec0d1228599f9ae)
		{
			if (this.Icon != null)
			{
				this.xfe4205d5dd815113 = new Rectangle(xda73fcb97c77d998.Location, this._x10bfbd9ec25bb113);
				this.xc379f3edcd8cffb4(xda73fcb97c77d998, xe4f97a5cc9204c1f, xa092001467a0ab7b, xcb35b7c43d7acd61);
			}
			else if (this.Image != null)
			{
				this.xfe4205d5dd815113 = new Rectangle(xda73fcb97c77d998.Location, this.xe058541ca798c059.Size);
				this.xc379f3edcd8cffb4(xda73fcb97c77d998, xe4f97a5cc9204c1f, xa092001467a0ab7b, xcb35b7c43d7acd61);
			}
			else if (x6ec0d1228599f9ae != null && this._xc931041ff8b5600b >= 0 && this._xc931041ff8b5600b < x6ec0d1228599f9ae.Images.Count)
			{
				this.xfe4205d5dd815113 = new Rectangle(xda73fcb97c77d998.Location, x6ec0d1228599f9ae.ImageSize);
				this.xc379f3edcd8cffb4(xda73fcb97c77d998, xe4f97a5cc9204c1f, xa092001467a0ab7b, xcb35b7c43d7acd61);
			}
			else
			{
				this.xfe4205d5dd815113 = Rectangle.Empty;
				this.x0961517ffd55017f = xda73fcb97c77d998;
			}
			if (this.Text.Length == 0)
			{
				this.x0961517ffd55017f = Rectangle.Empty;
			}
		}

		// Token: 0x060001D1 RID: 465 RVA: 0x0000868C File Offset: 0x0000768C
		private void xc379f3edcd8cffb4(Rectangle xda73fcb97c77d998, ToolBarTextAlign xe4f97a5cc9204c1f, bool xa092001467a0ab7b, bool xcb35b7c43d7acd61)
		{
			if (xe4f97a5cc9204c1f != ToolBarTextAlign.Side)
			{
				goto IL_1B2;
			}
			if (((xa092001467a0ab7b ? 1U : 0U) & 0U) == 0U)
			{
				goto IL_112;
			}
			IL_1D:
			int num = xda73fcb97c77d998.Width - this.xfe4205d5dd815113.Width;
			num /= 2;
			this.xfe4205d5dd815113.Offset(num, 0);
			this.x0961517ffd55017f = new Rectangle(xda73fcb97c77d998.X, this.xfe4205d5dd815113.Bottom + 2, xda73fcb97c77d998.Width, xda73fcb97c77d998.Height - this.xfe4205d5dd815113.Height - 2);
			return;
			IL_112:
			if (xa092001467a0ab7b)
			{
				goto IL_1B2;
			}
			int num2 = xda73fcb97c77d998.Height - this.xfe4205d5dd815113.Height;
			num2 /= 2;
			this.xfe4205d5dd815113.Offset(0, num2);
			if (xcb35b7c43d7acd61)
			{
				this.xfe4205d5dd815113.X = xda73fcb97c77d998.Right - this.xfe4205d5dd815113.Width;
			}
			this.x0961517ffd55017f = new Rectangle(xda73fcb97c77d998.X, xda73fcb97c77d998.Y, xda73fcb97c77d998.Width - (this.xfe4205d5dd815113.Width + 2), xda73fcb97c77d998.Height);
			if (xcb35b7c43d7acd61)
			{
				return;
			}
			this.x0961517ffd55017f.Offset(this.xfe4205d5dd815113.Width + 2, 0);
			return;
			IL_1B2:
			if (!xa092001467a0ab7b && xe4f97a5cc9204c1f == ToolBarTextAlign.Underneath)
			{
				goto IL_1D;
			}
			if (xa092001467a0ab7b && xe4f97a5cc9204c1f == ToolBarTextAlign.Side)
			{
				goto IL_1D;
			}
			this.xfe4205d5dd815113.Offset(xda73fcb97c77d998.Right - this.xfe4205d5dd815113.Right, 0);
			int num3 = xda73fcb97c77d998.Height - this.xfe4205d5dd815113.Height;
			num3 /= 2;
			if (((uint)num | 4294967294U) == 0U)
			{
				return;
			}
			this.xfe4205d5dd815113.Offset(0, num3);
			this.x0961517ffd55017f = base.ButtonInnerBounds;
			this.x0961517ffd55017f.Width = this.x0961517ffd55017f.Width - (this.xfe4205d5dd815113.Width + 2);
			if (-2147483648 == 0)
			{
				goto IL_112;
			}
		}

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x060001D2 RID: 466 RVA: 0x00008868 File Offset: 0x00007868
		[Browsable(false)]
		public virtual ImageList ImageList
		{
			get
			{
				if (base.ToolBar != null)
				{
					return base.ToolBar.ImageList;
				}
				return null;
			}
		}

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x060001D3 RID: 467 RVA: 0x00008880 File Offset: 0x00007880
		// (set) Token: 0x060001D4 RID: 468 RVA: 0x00008888 File Offset: 0x00007888
		[Editor("System.Windows.Forms.Design.ImageIndexEditor, System.Design", typeof(UITypeEditor))]
		[Category("Image")]
		[TypeConverter(typeof(ImageIndexConverter))]
		[DefaultValue(-1)]
		[Description("Gets or sets the index value of the image assigned to the button.")]
		public virtual int ImageIndex
		{
			get
			{
				return this._xc931041ff8b5600b;
			}
			set
			{
				this._xc931041ff8b5600b = value;
				this.LayoutNeeded();
			}
		}

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x060001D5 RID: 469 RVA: 0x00008898 File Offset: 0x00007898
		// (set) Token: 0x060001D6 RID: 470 RVA: 0x000088A0 File Offset: 0x000078A0
		[Category("Image")]
		[AmbientValue(typeof(Image), null)]
		[DefaultValue(typeof(Image), null)]
		[Description("The image assigned to the button.")]
		public virtual Image Image
		{
			get
			{
				return this.xe058541ca798c059;
			}
			set
			{
				this.xe058541ca798c059 = value;
				this.LayoutNeeded();
			}
		}

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x060001D7 RID: 471 RVA: 0x000088B0 File Offset: 0x000078B0
		// (set) Token: 0x060001D8 RID: 472 RVA: 0x000088B8 File Offset: 0x000078B8
		[Category("Image")]
		[Description("The desired icon size to extract from the icon.")]
		[DefaultValue(typeof(Size), "16, 16")]
		public virtual Size IconSize
		{
			get
			{
				return this._x10bfbd9ec25bb113;
			}
			set
			{
				this._x10bfbd9ec25bb113 = value;
				this.LayoutNeeded();
			}
		}

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x060001D9 RID: 473 RVA: 0x000088C8 File Offset: 0x000078C8
		// (set) Token: 0x060001DA RID: 474 RVA: 0x000088D0 File Offset: 0x000078D0
		[DefaultValue(typeof(Icon), null)]
		[Description("The icon to show in place of an image.")]
		[AmbientValue(typeof(Icon), null)]
		[Category("Image")]
		public virtual Icon Icon
		{
			get
			{
				return this._x8546e7d3d8c4f973;
			}
			set
			{
				this._x8546e7d3d8c4f973 = value;
				this.LayoutNeeded();
			}
		}

		// Token: 0x0400009D RID: 157
		private int _xc931041ff8b5600b = -1;

		// Token: 0x0400009E RID: 158
		private Icon _x8546e7d3d8c4f973;

		// Token: 0x0400009F RID: 159
		private Image xe058541ca798c059;

		// Token: 0x040000A0 RID: 160
		private Size _x10bfbd9ec25bb113 = new Size(16, 16);

		// Token: 0x040000A1 RID: 161
		internal Rectangle xfe4205d5dd815113;

		// Token: 0x040000A2 RID: 162
		private Rectangle x0961517ffd55017f;
	}
}
