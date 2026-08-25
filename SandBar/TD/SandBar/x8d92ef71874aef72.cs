using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TD.SandBar
{
	// Token: 0x0200006B RID: 107
	internal partial class x8d92ef71874aef72 : Form
	{
		// Token: 0x06000544 RID: 1348 RVA: 0x0001C630 File Offset: 0x0001B630
		public x8d92ef71874aef72(Color shadowColor, bool horizontal, bool fadeLastCorner)
		{
			base.ShowInTaskbar = false;
			base.FormBorderStyle = FormBorderStyle.None;
			this.x89e85fda7d4289a9 = (int)shadowColor.R;
			this.x1fecb440d4062566 = (int)shadowColor.G;
			this.xe81a1bbb3504e0b3 = (int)shadowColor.B;
			this.x176eb727dd265fce = horizontal;
			this.xabf662b5e786b50c = fadeLastCorner;
		}

		// Token: 0x17000146 RID: 326
		// (get) Token: 0x06000546 RID: 1350 RVA: 0x0001C6B0 File Offset: 0x0001B6B0
		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams createParams = base.CreateParams;
				createParams.Style = int.MinValue;
				createParams.ExStyle |= 524296;
				return createParams;
			}
		}

		// Token: 0x06000547 RID: 1351 RVA: 0x0001C6E4 File Offset: 0x0001B6E4
		private void x0ecee64b07d2d5b1(Bitmap xe205f0cd81228282, byte x1965e484c4a7c6c6)
		{
			IntPtr dc = x443cc432acaadb1d.GetDC(IntPtr.Zero);
			IntPtr intPtr = x443cc432acaadb1d.CreateCompatibleDC(dc);
			IntPtr intPtr2 = IntPtr.Zero;
			IntPtr hObject = IntPtr.Zero;
			try
			{
				intPtr2 = xe205f0cd81228282.GetHbitmap(Color.FromArgb(0));
				hObject = x443cc432acaadb1d.SelectObject(intPtr, intPtr2);
				x443cc432acaadb1d.Size size = new x443cc432acaadb1d.Size(xe205f0cd81228282.Width, xe205f0cd81228282.Height);
				x443cc432acaadb1d.POINTAPI pointapi = new x443cc432acaadb1d.POINTAPI(0, 0);
				x443cc432acaadb1d.POINTAPI pointapi2 = new x443cc432acaadb1d.POINTAPI(base.Left, base.Top);
				x443cc432acaadb1d.BLENDFUNCTION blendfunction = default(x443cc432acaadb1d.BLENDFUNCTION);
				blendfunction.BlendOp = 0;
				blendfunction.BlendFlags = 0;
				blendfunction.SourceConstantAlpha = x1965e484c4a7c6c6;
				blendfunction.AlphaFormat = 1;
				x443cc432acaadb1d.UpdateLayeredWindow(base.Handle, dc, ref pointapi2, ref size, intPtr, ref pointapi, 0, ref blendfunction, 2);
			}
			finally
			{
				if (intPtr2 != IntPtr.Zero)
				{
					x443cc432acaadb1d.SelectObject(intPtr, hObject);
					x443cc432acaadb1d.DeleteObject(intPtr2);
				}
				x443cc432acaadb1d.ReleaseDC(IntPtr.Zero, dc);
				x443cc432acaadb1d.DeleteDC(intPtr);
			}
		}

		// Token: 0x06000548 RID: 1352 RVA: 0x0001C7F0 File Offset: 0x0001B7F0
		private void x1cfa32acc0c91f95(Bitmap xe205f0cd81228282)
		{
			BitmapData bitmapData = xe205f0cd81228282.LockBits(new Rectangle(0, 0, xe205f0cd81228282.Width, xe205f0cd81228282.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
			byte[] array = new byte[xe205f0cd81228282.Width * xe205f0cd81228282.Height * 4];
			Marshal.Copy(bitmapData.Scan0, array, 0, array.Length);
			int num = 0;
			for (;;)
			{
				if (num >= xe205f0cd81228282.Width)
				{
					Marshal.Copy(array, 0, bitmapData.Scan0, array.Length);
					goto IL_138;
				}
				int num2 = 0;
				IL_5A:
				if (num2 >= xe205f0cd81228282.Height)
				{
					num++;
					continue;
				}
				int num3 = num2 * xe205f0cd81228282.Width + num;
				if (false)
				{
					goto IL_8C;
				}
				num3 *= 4;
				array[num3 + 2] = (byte)this.x89e85fda7d4289a9;
				array[num3 + 1] = (byte)this.x1fecb440d4062566;
				array[num3] = (byte)this.xe81a1bbb3504e0b3;
				float num4;
				if (this.x176eb727dd265fce)
				{
					num4 = (float)num2 / (float)xe205f0cd81228282.Height;
					goto IL_8C;
				}
				num4 = (float)num / (float)xe205f0cd81228282.Width;
				num4 = 1f - num4;
				if (num2 <= 3)
				{
					float num5 = (float)(num2 + 1) / 4f;
					num5 *= 0.8f;
					num4 *= num5;
				}
				float num6;
				if (this.xabf662b5e786b50c && num2 > xe205f0cd81228282.Height - 5)
				{
					num6 = (float)(xe205f0cd81228282.Height - num2);
					num6 /= 4f;
					num6 *= 0.8f;
					float num7;
					bool flag = (uint)num7 > uint.MaxValue;
					if (flag)
					{
						goto IL_138;
					}
					goto IL_39;
				}
				IL_3E:
				num4 *= 0.25f;
				array[num3 + 3] = (byte)(num4 * 255f);
				num2++;
				goto IL_5A;
				IL_39:
				num4 *= num6;
				goto IL_3E;
				IL_138:
				xe205f0cd81228282.UnlockBits(bitmapData);
				if (15 != 0)
				{
					break;
				}
				if (false)
				{
					goto IL_39;
				}
				IL_8C:
				num4 = 1f - num4;
				if (num <= 3)
				{
					float num7 = (float)(num + 1) / 4f;
					num7 *= 0.8f;
					num4 *= num7;
					goto IL_3E;
				}
				goto IL_3E;
			}
		}

		// Token: 0x06000549 RID: 1353 RVA: 0x0001C9D0 File Offset: 0x0001B9D0
		public void x47b5c057cc37f4ff(Rectangle xda73fcb97c77d998)
		{
			if (this.xe205f0cd81228282 != null)
			{
				this.xe205f0cd81228282.Dispose();
			}
			this.xe205f0cd81228282 = new Bitmap(xda73fcb97c77d998.Width, xda73fcb97c77d998.Height);
			this.x1cfa32acc0c91f95(this.xe205f0cd81228282);
			x443cc432acaadb1d.SetWindowPos(base.Handle, 0, xda73fcb97c77d998.X, xda73fcb97c77d998.Y, xda73fcb97c77d998.Width, xda73fcb97c77d998.Height, 84);
			this.x0ecee64b07d2d5b1(this.xe205f0cd81228282, byte.MaxValue);
		}

		// Token: 0x0400022C RID: 556
		private int x89e85fda7d4289a9;

		// Token: 0x0400022D RID: 557
		private int x1fecb440d4062566;

		// Token: 0x0400022E RID: 558
		private int xe81a1bbb3504e0b3;

		// Token: 0x0400022F RID: 559
		private bool x176eb727dd265fce;

		// Token: 0x04000230 RID: 560
		private bool xabf662b5e786b50c = true;
	}
}
