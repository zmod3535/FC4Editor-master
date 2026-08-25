using System;
using System.ComponentModel;
using System.Drawing;
using Divelements.SandGrid.Rendering;

namespace Divelements.SandGrid.Specialized
{
	// Token: 0x0200002B RID: 43
	public class GridImageColumn : TypedGridColumn
	{
		// Token: 0x06000443 RID: 1091 RVA: 0x000184F4 File Offset: 0x000174F4
		public GridImageColumn(string text, int width) : base(text, width)
		{
		}

		// Token: 0x06000444 RID: 1092 RVA: 0x00018500 File Offset: 0x00017500
		public GridImageColumn()
		{
		}

		// Token: 0x06000445 RID: 1093 RVA: 0x00018508 File Offset: 0x00017508
		protected internal override bool IsTextOverflowing(GridRow row)
		{
			return false;
		}

		// Token: 0x17000114 RID: 276
		// (get) Token: 0x06000446 RID: 1094 RVA: 0x0001850C File Offset: 0x0001750C
		public override Type DataType
		{
			get
			{
				return typeof(Image);
			}
		}

		// Token: 0x06000447 RID: 1095 RVA: 0x00018518 File Offset: 0x00017518
		protected internal override void DrawCell(RenderingContext context, GridRow row, object value, Font rowFont, Image defaultImage, Rectangle bounds, bool selected, TextFormattingInformation textFormat, Color foreColor)
		{
			Image image = value as Image;
			bool flag = false;
			if (image == null && value != null && GridImageColumn.x6baeeb33d3174a8f.CanConvertFrom(value.GetType()))
			{
				image = (Image)GridImageColumn.x6baeeb33d3174a8f.ConvertFrom(value);
				flag = true;
			}
			if (image == null)
			{
				image = defaultImage;
			}
			if (image != null)
			{
				Rectangle srcRect = new Rectangle(0, 0, image.Width, image.Height);
				if (srcRect.Width > bounds.Width - 8)
				{
					srcRect.X = 0;
					srcRect.Width = bounds.Width - 8;
				}
				if (srcRect.Height > bounds.Height)
				{
					srcRect.Y = image.Height / 2 - bounds.Height / 2;
					srcRect.Height = bounds.Height;
				}
				Rectangle destRect = new Rectangle(0, 0, srcRect.Width, srcRect.Height);
				if ((selected ? 1U : 0U) - (flag ? 1U : 0U) <= 4294967295U)
				{
				}
				switch (this.CellHorizontalAlignment)
				{
				case StringAlignment.Near:
					destRect.X = bounds.X + 4;
					goto IL_1C1;
				case StringAlignment.Far:
					destRect.X = bounds.Right - 4 - srcRect.Width;
					goto IL_1C1;
				}
				destRect.X = bounds.X + bounds.Width / 2 - srcRect.Width / 2;
				IL_1C1:
				switch (this.CellVerticalAlignment)
				{
				case StringAlignment.Near:
					destRect.Y = bounds.Y + 2;
					goto IL_48;
				case StringAlignment.Far:
					destRect.Y = bounds.Bottom - 2 - srcRect.Height;
					goto IL_48;
				}
				destRect.Y = bounds.Y + bounds.Height / 2 - srcRect.Height / 2;
				IL_48:
				context.Graphics.DrawImage(image, destRect, srcRect, GraphicsUnit.Pixel);
			}
			else
			{
				base.DrawCell(context, row, value, rowFont, image, bounds, selected, textFormat, foreColor);
			}
			if (flag)
			{
				image.Dispose();
			}
		}

		// Token: 0x0400014B RID: 331
		private static TypeConverter x6baeeb33d3174a8f = TypeDescriptor.GetConverter(typeof(Image));
	}
}
