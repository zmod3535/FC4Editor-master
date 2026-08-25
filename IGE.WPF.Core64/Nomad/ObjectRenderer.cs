using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace IGE.Nomad
{
	// Token: 0x02000384 RID: 900
	internal class ObjectRenderer
	{
		// Token: 0x06001444 RID: 5188 RVA: 0x0002AD6B File Offset: 0x00028F6B
		public static void Clear()
		{
			Binding.FCE_ObjectRenderer_Clear();
		}

		// Token: 0x17000275 RID: 629
		// (get) Token: 0x06001445 RID: 5189 RVA: 0x0002AD77 File Offset: 0x00028F77
		private static bool IsSnapshotReady
		{
			get
			{
				return Binding.FCE_ObjectRenderer_IsSnapshotReady();
			}
		}

		// Token: 0x06001446 RID: 5190 RVA: 0x0002AD83 File Offset: 0x00028F83
		private static bool ThumbnailDummy()
		{
			return false;
		}

		// Token: 0x06001447 RID: 5191 RVA: 0x0002AD86 File Offset: 0x00028F86
		private static void ClearSnapshot()
		{
			Binding.FCE_ObjectRenderer_ClearSnapshot();
		}

		// Token: 0x06001448 RID: 5192 RVA: 0x0002AD92 File Offset: 0x00028F92
		private static void RenderObject(ObjectInventory.Entry entry)
		{
			Binding.FCE_ObjectRenderer_RenderObject(entry.Pointer);
		}

		// Token: 0x06001449 RID: 5193 RVA: 0x0002ADA4 File Offset: 0x00028FA4
		public static void ClearCache()
		{
			foreach (string path in Directory.GetFiles(ObjectRenderer.cachePath))
			{
				File.Delete(path);
			}
		}

		// Token: 0x0600144A RID: 5194 RVA: 0x0002ADD4 File Offset: 0x00028FD4
		public static void GenerateThumbnails()
		{
			Binding.FCE_ObjectRenderer_GenerateThumbnails();
		}

		// Token: 0x0600144B RID: 5195 RVA: 0x0002ADE0 File Offset: 0x00028FE0
		public static void ResizeThumbnails(string subDir, int targetResolution, int targetColResolution, Color background, string thumbnailsPath)
		{
			string path = string.Format("{0}\\png_src\\", thumbnailsPath);
			if (!Directory.Exists(path))
			{
				MessageBox.Show("Cannot find thumbnails path, resizing failed.");
				return;
			}
			foreach (string text in Directory.GetFiles(path, "*.png"))
			{
				string fileName = Path.GetFileName(text);
				Image image = Image.FromFile(text);
				Rectangle srcRect = new Rectangle(0, 0, image.Width, image.Height);
				int num = targetResolution;
				if (fileName.StartsWith("col"))
				{
					if ((float)srcRect.Width / (float)srcRect.Height > 2f)
					{
						int num2 = (int)((float)Math.Min(srcRect.Height, srcRect.Width) * 0.8f);
						srcRect = new Rectangle((srcRect.Width - num2) / 2, 0, num2, num2);
					}
					num = targetColResolution;
				}
				int num3 = 3;
				int num4 = num - num3 * 2;
				int num5;
				int num6;
				if (image.Width > image.Height)
				{
					num5 = num4;
					num6 = (int)((float)num4 / (float)srcRect.Width * (float)srcRect.Height);
				}
				else
				{
					num6 = num4;
					num5 = (int)((float)num4 / (float)srcRect.Height * (float)srcRect.Width);
				}
				Bitmap bitmap = new Bitmap(num, num);
				Image image2 = bitmap;
				using (Graphics graphics = Graphics.FromImage(image2))
				{
					using (SolidBrush solidBrush = new SolidBrush(background))
					{
						graphics.FillRectangle(solidBrush, 0, 0, bitmap.Width, bitmap.Height);
					}
					graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
					graphics.DrawImage(image, new Rectangle(num3 + (num4 - num5) / 2, num3 + (num4 - num6) / 2, num5, num6), srcRect, GraphicsUnit.Pixel);
				}
				string text2 = string.Format("{0}\\{1}\\", thumbnailsPath, subDir);
				if (!Directory.Exists(text2))
				{
					Directory.CreateDirectory(text2);
				}
				string filename = text2 + Path.GetFileNameWithoutExtension(text) + ".png";
				BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
				Binding.FCE_ObjectRenderer_WritePNG(bitmapData.Scan0, bitmap.Width, bitmap.Height, filename);
				bitmap.UnlockBits(bitmapData);
				bitmap.Dispose();
				image.Dispose();
			}
		}

		// Token: 0x0600144C RID: 5196 RVA: 0x0002B044 File Offset: 0x00029244
		public static void ResizeThumbnails(string thumbnailsPath)
		{
			ObjectRenderer.ResizeThumbnails("pc", 256, 256, Color.FromArgb(0, 127, 127, 127), thumbnailsPath);
			ObjectRenderer.ResizeThumbnails("console", 128, 256, Color.FromArgb(0, 32, 32, 32), thumbnailsPath);
		}

		// Token: 0x04000775 RID: 1909
		public static string cachePath = Path.GetTempPath() + "\\FarCry4\\Editor\\";
	}
}
