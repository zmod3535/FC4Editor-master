using System;
using System.Drawing;

namespace TD.SandDock.Rendering
{
	// Token: 0x02000024 RID: 36
	public class BoxModel
	{
		// Token: 0x0600032D RID: 813 RVA: 0x0001ADD4 File Offset: 0x00019DD4
		public BoxModel()
		{
			this.x13ebc58426767551 = new BoxEdges();
			this.xcaf2e4729806e32b = new BoxEdges();
		}

		// Token: 0x0600032E RID: 814 RVA: 0x0001ADF4 File Offset: 0x00019DF4
		public BoxModel(int width, int height, int paddingLeft, int paddingTop, int paddingRight, int paddingBottom, int marginLeft, int marginTop, int marginRight, int marginBottom)
		{
			this.x9b0739496f8b5475 = width;
			this.x4d5aabc7a55b12ba = height;
			this.xcaf2e4729806e32b = new BoxEdges(paddingLeft, paddingTop, paddingRight, paddingBottom);
			this.x13ebc58426767551 = new BoxEdges(marginLeft, marginTop, marginRight, marginBottom);
		}

		// Token: 0x170000BF RID: 191
		// (get) Token: 0x0600032F RID: 815 RVA: 0x0001AE30 File Offset: 0x00019E30
		public int ExtraWidth
		{
			get
			{
				return this.x13ebc58426767551.Left + this.x13ebc58426767551.Right + this.xcaf2e4729806e32b.Left + this.xcaf2e4729806e32b.Right;
			}
		}

		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x06000330 RID: 816 RVA: 0x0001AE64 File Offset: 0x00019E64
		public int ExtraHeight
		{
			get
			{
				return this.x13ebc58426767551.Top + this.x13ebc58426767551.Bottom + this.xcaf2e4729806e32b.Top + this.xcaf2e4729806e32b.Bottom;
			}
		}

		// Token: 0x06000331 RID: 817 RVA: 0x0001AE98 File Offset: 0x00019E98
		public Rectangle RemovePadding(Rectangle source)
		{
			source.X += this.xcaf2e4729806e32b.Left;
			source.Y += this.xcaf2e4729806e32b.Top;
			source.Width -= this.xcaf2e4729806e32b.Left + this.xcaf2e4729806e32b.Right;
			source.Height -= this.xcaf2e4729806e32b.Top + this.xcaf2e4729806e32b.Bottom;
			return source;
		}

		// Token: 0x06000332 RID: 818 RVA: 0x0001AF24 File Offset: 0x00019F24
		public Rectangle RemoveMargin(Rectangle source)
		{
			source.X += this.x13ebc58426767551.Left;
			source.Y += this.x13ebc58426767551.Top;
			source.Width -= this.x13ebc58426767551.Left + this.x13ebc58426767551.Right;
			source.Height -= this.x13ebc58426767551.Top + this.x13ebc58426767551.Bottom;
			return source;
		}

		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x06000333 RID: 819 RVA: 0x0001AFB0 File Offset: 0x00019FB0
		public Size InnerSize
		{
			get
			{
				return new Size(this.x9b0739496f8b5475 - this.x13ebc58426767551.Left - this.x13ebc58426767551.Right, this.x4d5aabc7a55b12ba - this.x13ebc58426767551.Top - this.x13ebc58426767551.Bottom);
			}
		}

		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x06000334 RID: 820 RVA: 0x0001B000 File Offset: 0x0001A000
		// (set) Token: 0x06000335 RID: 821 RVA: 0x0001B008 File Offset: 0x0001A008
		public int Height
		{
			get
			{
				return this.x4d5aabc7a55b12ba;
			}
			set
			{
				this.x4d5aabc7a55b12ba = value;
			}
		}

		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x06000336 RID: 822 RVA: 0x0001B014 File Offset: 0x0001A014
		// (set) Token: 0x06000337 RID: 823 RVA: 0x0001B01C File Offset: 0x0001A01C
		public int Width
		{
			get
			{
				return this.x9b0739496f8b5475;
			}
			set
			{
				this.x9b0739496f8b5475 = value;
			}
		}

		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x06000338 RID: 824 RVA: 0x0001B028 File Offset: 0x0001A028
		// (set) Token: 0x06000339 RID: 825 RVA: 0x0001B030 File Offset: 0x0001A030
		public BoxEdges Margin
		{
			get
			{
				return this.x13ebc58426767551;
			}
			set
			{
				this.x13ebc58426767551 = value;
			}
		}

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x0600033A RID: 826 RVA: 0x0001B03C File Offset: 0x0001A03C
		// (set) Token: 0x0600033B RID: 827 RVA: 0x0001B044 File Offset: 0x0001A044
		public BoxEdges Padding
		{
			get
			{
				return this.xcaf2e4729806e32b;
			}
			set
			{
				this.xcaf2e4729806e32b = value;
			}
		}

		// Token: 0x0400010A RID: 266
		private BoxEdges x13ebc58426767551;

		// Token: 0x0400010B RID: 267
		private BoxEdges xcaf2e4729806e32b;

		// Token: 0x0400010C RID: 268
		private int x9b0739496f8b5475;

		// Token: 0x0400010D RID: 269
		private int x4d5aabc7a55b12ba;
	}
}
