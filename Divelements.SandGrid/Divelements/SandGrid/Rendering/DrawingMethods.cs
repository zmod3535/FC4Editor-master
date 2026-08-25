using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Divelements.SandGrid.Rendering
{
	// Token: 0x02000058 RID: 88
	public class DrawingMethods
	{
		// Token: 0x0600054F RID: 1359 RVA: 0x0001BBC4 File Offset: 0x0001ABC4
		private DrawingMethods()
		{
		}

		// Token: 0x06000550 RID: 1360 RVA: 0x0001BBCC File Offset: 0x0001ABCC
		internal static void x91433b5e99eb7cac(Graphics x41347a961b838962, Color x6c50a99faab7d741)
		{
			try
			{
				x41347a961b838962.Clear(x6c50a99faab7d741);
			}
			catch
			{
			}
		}

		// Token: 0x06000551 RID: 1361 RVA: 0x0001BC04 File Offset: 0x0001AC04
		public static Image CreateHighlightedImage(Image sourceImage, float factor)
		{
			Bitmap bitmap = new Bitmap(sourceImage);
			if (bitmap.PixelFormat != PixelFormat.Format32bppArgb)
			{
				return bitmap;
			}
			BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
			byte[] array = new byte[bitmap.Width * bitmap.Height * 4];
			Marshal.Copy(bitmapData.Scan0, array, 0, array.Length);
			byte r = SystemColors.Highlight.R;
			byte g = SystemColors.Highlight.G;
			byte b = SystemColors.Highlight.B;
			for (int i = 0; i < array.Length; i += 4)
			{
				if (array[i + 3] != 0)
				{
					byte[] array2 = array;
					int num = i;
					array2[num] += (byte)((float)(b - array[i]) * factor);
					byte[] array3 = array;
					int num2 = i + 1;
					array3[num2] += (byte)((float)(g - array[i + 1]) * factor);
					byte[] array4 = array;
					int num3 = i + 2;
					array4[num3] += (byte)((float)(r - array[i + 2]) * factor);
				}
			}
			Marshal.Copy(array, 0, bitmapData.Scan0, array.Length);
			bitmap.UnlockBits(bitmapData);
			return bitmap;
		}

		// Token: 0x06000552 RID: 1362 RVA: 0x0001BD38 File Offset: 0x0001AD38
		public static Color InterpolateColors(Color color1, Color color2, float percentage)
		{
			int r = (int)color1.R;
			int g = (int)color1.G;
			int b = (int)color1.B;
			int a = (int)color1.A;
			int r2 = (int)color2.R;
			int g2 = (int)color2.G;
			int b2 = (int)color2.B;
			int a2 = (int)color2.A;
			byte red = Convert.ToByte((float)r + (float)(r2 - r) * percentage);
			byte green = Convert.ToByte((float)g + (float)(g2 - g) * percentage);
			byte blue = Convert.ToByte((float)b + (float)(b2 - b) * percentage);
			byte alpha = Convert.ToByte((float)a + (float)(a2 - a) * percentage);
			return Color.FromArgb((int)alpha, (int)red, (int)green, (int)blue);
		}

		// Token: 0x06000553 RID: 1363 RVA: 0x0001BDDC File Offset: 0x0001ADDC
		public static void DrawDropShadow(Graphics graphics, Rectangle bounds, int size, Color shadowColor)
		{
			using (SolidBrush solidBrush = new SolidBrush(shadowColor))
			{
				graphics.FillRectangle(solidBrush, bounds);
			}
			using (Bitmap bitmap = DrawingMethods.x3a1184c139c0984c(size, Color.Black))
			{
				graphics.DrawImage(bitmap, bounds.X - size, bounds.Y - size);
				bitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);
				graphics.DrawImage(bitmap, bounds.Right, bounds.Y - size);
				bitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);
				graphics.DrawImage(bitmap, bounds.Right, bounds.Bottom);
				bitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);
				graphics.DrawImage(bitmap, bounds.X - size, bounds.Bottom);
			}
			for (int i = 0; i < size; i++)
			{
				double num = (double)(i + 1) / ((double)size + 1.0);
				num = 1.0 - Math.Cos(num * 3.141592653589793 / 2.0);
				int alpha = (int)(num * 255.0);
				using (Pen pen = new Pen(Color.FromArgb(alpha, shadowColor)))
				{
					graphics.DrawLine(pen, bounds.X, bounds.Y - size + i, bounds.Right - 1, bounds.Y - size + i);
					graphics.DrawLine(pen, bounds.X, bounds.Bottom + size - i - 1, bounds.Right - 1, bounds.Bottom + size - i - 1);
					graphics.DrawLine(pen, bounds.X - size + i, bounds.Y, bounds.X - size + i, bounds.Bottom - 1);
					graphics.DrawLine(pen, bounds.Right + size - i - 1, bounds.Y, bounds.Right + size - i - 1, bounds.Bottom - 1);
				}
			}
		}

		// Token: 0x06000554 RID: 1364 RVA: 0x0001C010 File Offset: 0x0001B010
		private static Bitmap x3a1184c139c0984c(int x0ceec69a97f73617, Color x228f9881a1be0e5d)
		{
			Bitmap bitmap = new Bitmap(x0ceec69a97f73617, x0ceec69a97f73617);
			BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
			double num;
			byte[] array;
			if ((uint)num <= 4294967295U)
			{
				array = new byte[bitmap.Width * bitmap.Height * 4];
				Marshal.Copy(bitmapData.Scan0, array, 0, array.Length);
			}
			for (int i = 0; i < x0ceec69a97f73617; i++)
			{
				for (int j = 0; j < x0ceec69a97f73617; j++)
				{
					double num2 = (double)(i + 1) / ((double)x0ceec69a97f73617 + 1.0);
					num = (double)(j + 1) / ((double)x0ceec69a97f73617 + 1.0);
					double num3 = num2 * num;
					num3 = 1.0 - Math.Cos(num3 * 3.141592653589793 / 2.0);
					int num4 = (int)(num3 * 255.0);
					int num5 = (j * x0ceec69a97f73617 + i) * 4;
					array[num5] = x228f9881a1be0e5d.B;
					array[num5 + 1] = x228f9881a1be0e5d.G;
					array[num5 + 2] = x228f9881a1be0e5d.R;
					array[num5 + 3] = (byte)num4;
				}
			}
			Marshal.Copy(array, 0, bitmapData.Scan0, array.Length);
			bitmap.UnlockBits(bitmapData);
			return bitmap;
		}
	}
}
