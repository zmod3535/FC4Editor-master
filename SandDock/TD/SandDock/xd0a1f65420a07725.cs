using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TD.SandDock
{
	// Token: 0x02000044 RID: 68
	internal partial class xd0a1f65420a07725 : Form
	{
		// Token: 0x060004D8 RID: 1240 RVA: 0x000263AC File Offset: 0x000253AC
		public xd0a1f65420a07725()
		{
			base.FormBorderStyle = FormBorderStyle.None;
		}

		// Token: 0x060004D9 RID: 1241 RVA: 0x000263BC File Offset: 0x000253BC
		public void x0ecee64b07d2d5b1(Bitmap xe205f0cd81228282, byte x1965e484c4a7c6c6)
		{
			IntPtr dc = xd0a1f65420a07725.x443cc432acaadb1d.GetDC(IntPtr.Zero);
			IntPtr intPtr = xd0a1f65420a07725.x443cc432acaadb1d.CreateCompatibleDC(dc);
			IntPtr intPtr2 = IntPtr.Zero;
			IntPtr hObject = IntPtr.Zero;
			try
			{
				intPtr2 = xe205f0cd81228282.GetHbitmap(Color.FromArgb(0));
				hObject = xd0a1f65420a07725.x443cc432acaadb1d.SelectObject(intPtr, intPtr2);
				xd0a1f65420a07725.x443cc432acaadb1d.Size size;
				xd0a1f65420a07725.x443cc432acaadb1d.Point point;
				xd0a1f65420a07725.x443cc432acaadb1d.Point point2;
				xd0a1f65420a07725.x443cc432acaadb1d.BLENDFUNCTION blendfunction;
				do
				{
					size = new xd0a1f65420a07725.x443cc432acaadb1d.Size(xe205f0cd81228282.Width, xe205f0cd81228282.Height);
					point = new xd0a1f65420a07725.x443cc432acaadb1d.Point(0, 0);
					point2 = new xd0a1f65420a07725.x443cc432acaadb1d.Point(base.Left, base.Top);
					blendfunction = default(xd0a1f65420a07725.x443cc432acaadb1d.BLENDFUNCTION);
					blendfunction.BlendOp = 0;
				}
				while ((uint)intPtr2 + (uint)dc > 4294967295U);
				blendfunction.BlendFlags = 0;
				blendfunction.SourceConstantAlpha = x1965e484c4a7c6c6;
				blendfunction.AlphaFormat = 1;
				xd0a1f65420a07725.x443cc432acaadb1d.UpdateLayeredWindow(base.Handle, dc, ref point2, ref size, intPtr, ref point, 0, ref blendfunction, 2);
			}
			finally
			{
				if (intPtr2 != IntPtr.Zero)
				{
					xd0a1f65420a07725.x443cc432acaadb1d.SelectObject(intPtr, hObject);
					xd0a1f65420a07725.x443cc432acaadb1d.DeleteObject(intPtr2);
				}
				xd0a1f65420a07725.x443cc432acaadb1d.ReleaseDC(IntPtr.Zero, dc);
				xd0a1f65420a07725.x443cc432acaadb1d.DeleteDC(intPtr);
			}
		}

		// Token: 0x1700013C RID: 316
		// (get) Token: 0x060004DA RID: 1242 RVA: 0x000264F8 File Offset: 0x000254F8
		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams createParams = base.CreateParams;
				createParams.ExStyle |= 524288;
				return createParams;
			}
		}

		// Token: 0x02000045 RID: 69
		private class x443cc432acaadb1d
		{
			// Token: 0x060004DB RID: 1243 RVA: 0x00026520 File Offset: 0x00025520
			private x443cc432acaadb1d()
			{
			}

			// Token: 0x060004DC RID: 1244
			[DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
			public static extern bool UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref xd0a1f65420a07725.x443cc432acaadb1d.Point pptDst, ref xd0a1f65420a07725.x443cc432acaadb1d.Size psize, IntPtr hdcSrc, ref xd0a1f65420a07725.x443cc432acaadb1d.Point pprSrc, int crKey, ref xd0a1f65420a07725.x443cc432acaadb1d.BLENDFUNCTION pblend, int dwFlags);

			// Token: 0x060004DD RID: 1245
			[DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
			public static extern IntPtr GetDC(IntPtr hWnd);

			// Token: 0x060004DE RID: 1246
			[DllImport("user32.dll", ExactSpelling = true)]
			public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

			// Token: 0x060004DF RID: 1247
			[DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
			public static extern IntPtr CreateCompatibleDC(IntPtr hDC);

			// Token: 0x060004E0 RID: 1248
			[DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
			public static extern bool DeleteDC(IntPtr hdc);

			// Token: 0x060004E1 RID: 1249
			[DllImport("gdi32.dll", ExactSpelling = true)]
			public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);

			// Token: 0x060004E2 RID: 1250
			[DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
			public static extern bool DeleteObject(IntPtr hObject);

			// Token: 0x040001BA RID: 442
			public const int x5369785684a974f4 = 1;

			// Token: 0x040001BB RID: 443
			public const int x93b283a033d1b54a = 2;

			// Token: 0x040001BC RID: 444
			public const int x11a0985503a2d2df = 4;

			// Token: 0x040001BD RID: 445
			public const byte xdd6043f42253ee15 = 0;

			// Token: 0x040001BE RID: 446
			public const byte xa34cc3e091661d7f = 1;

			// Token: 0x02000046 RID: 70
			public struct Size
			{
				// Token: 0x060004E3 RID: 1251 RVA: 0x00026528 File Offset: 0x00025528
				public Size(int cx, int cy)
				{
					this.cx = cx;
					this.cy = cy;
				}

				// Token: 0x040001BF RID: 447
				public int cx;

				// Token: 0x040001C0 RID: 448
				public int cy;
			}

			// Token: 0x02000047 RID: 71
			public struct Point
			{
				// Token: 0x060004E4 RID: 1252 RVA: 0x00026538 File Offset: 0x00025538
				public Point(int x, int y)
				{
					this.x = x;
					this.y = y;
				}

				// Token: 0x040001C1 RID: 449
				public int x;

				// Token: 0x040001C2 RID: 450
				public int y;
			}

			// Token: 0x02000048 RID: 72
			[StructLayout(LayoutKind.Sequential, Pack = 1)]
			public struct BLENDFUNCTION
			{
				// Token: 0x040001C3 RID: 451
				public byte BlendOp;

				// Token: 0x040001C4 RID: 452
				public byte BlendFlags;

				// Token: 0x040001C5 RID: 453
				public byte SourceConstantAlpha;

				// Token: 0x040001C6 RID: 454
				public byte AlphaFormat;
			}
		}
	}
}
