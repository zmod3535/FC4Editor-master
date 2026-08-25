using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TD.SandDock
{
	// Token: 0x0200001A RID: 26
	internal class x130e0425ae2d4496
	{
		// Token: 0x060002E5 RID: 741
		[DllImport("gdi32.dll")]
		private static extern IntPtr CreateBitmap(int nWidth, int nHeight, int nPlanes, int nBitsPerPixel, short[] lpvBits);

		// Token: 0x060002E6 RID: 742
		[DllImport("gdi32.dll")]
		private static extern IntPtr CreateBrushIndirect(x130e0425ae2d4496.x78c6fa48e5c2be9b lb);

		// Token: 0x060002E7 RID: 743
		[DllImport("gdi32.dll")]
		private static extern bool DeleteObject(HandleRef hObject);

		// Token: 0x060002E8 RID: 744
		[DllImport("user32.dll")]
		private static extern int ReleaseDC(HandleRef hWnd, HandleRef hDC);

		// Token: 0x060002E9 RID: 745
		[DllImport("gdi32.dll")]
		private static extern IntPtr SelectObject(HandleRef hDC, HandleRef hObject);

		// Token: 0x060002EA RID: 746
		[DllImport("gdi32.dll")]
		private static extern bool PatBlt(HandleRef hdc, int left, int top, int width, int height, int rop);

		// Token: 0x060002EB RID: 747
		[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
		private static extern IntPtr GetDC(HandleRef hWnd);

		// Token: 0x060002EC RID: 748 RVA: 0x0001A6C4 File Offset: 0x000196C4
		public static void xda2defffc25953e0(Control xd9927c905e42526c, Rectangle xa688a683bf2cfced, bool xc346f54d9968657b, int x189455fe88a3b711)
		{
			x130e0425ae2d4496.xe5e0d1644c72aafd(xd9927c905e42526c, new Rectangle(xa688a683bf2cfced.X, xa688a683bf2cfced.Y, xa688a683bf2cfced.Width, 4));
			if (!xc346f54d9968657b)
			{
				if (!false)
				{
					bool flag = (xc346f54d9968657b ? 1U : 0U) - (xc346f54d9968657b ? 1U : 0U) > uint.MaxValue;
					if (!flag)
					{
						x130e0425ae2d4496.xe5e0d1644c72aafd(xd9927c905e42526c, new Rectangle(xa688a683bf2cfced.X, xa688a683bf2cfced.Y + 4, 4, xa688a683bf2cfced.Height - 8));
						x130e0425ae2d4496.xe5e0d1644c72aafd(xd9927c905e42526c, new Rectangle(xa688a683bf2cfced.Right - 4, xa688a683bf2cfced.Y + 4, 4, xa688a683bf2cfced.Height - 8));
						x130e0425ae2d4496.xe5e0d1644c72aafd(xd9927c905e42526c, new Rectangle(xa688a683bf2cfced.X, xa688a683bf2cfced.Bottom - 4, xa688a683bf2cfced.Width, 4));
					}
					return;
				}
			}
			else
			{
				x130e0425ae2d4496.xe5e0d1644c72aafd(xd9927c905e42526c, new Rectangle(xa688a683bf2cfced.X, xa688a683bf2cfced.Y + 4, 4, xa688a683bf2cfced.Height - 4 - x189455fe88a3b711));
				x130e0425ae2d4496.xe5e0d1644c72aafd(xd9927c905e42526c, new Rectangle(xa688a683bf2cfced.Right - 4, xa688a683bf2cfced.Y + 4, 4, xa688a683bf2cfced.Height - 4 - x189455fe88a3b711));
				x130e0425ae2d4496.xe5e0d1644c72aafd(xd9927c905e42526c, new Rectangle(xa688a683bf2cfced.X, xa688a683bf2cfced.Bottom - x189455fe88a3b711, 10, 4));
				if ((xc346f54d9968657b ? 1U : 0U) > 4294967295U)
				{
					goto IL_10E;
				}
				if (false)
				{
					return;
				}
			}
			x130e0425ae2d4496.xe5e0d1644c72aafd(xd9927c905e42526c, new Rectangle(xa688a683bf2cfced.X + 80, xa688a683bf2cfced.Bottom - x189455fe88a3b711, xa688a683bf2cfced.Width - 80, 4));
			IL_10E:
			x130e0425ae2d4496.xe5e0d1644c72aafd(xd9927c905e42526c, new Rectangle(xa688a683bf2cfced.X + 10, xa688a683bf2cfced.Bottom - 4, 70, 4));
			x130e0425ae2d4496.xe5e0d1644c72aafd(xd9927c905e42526c, new Rectangle(xa688a683bf2cfced.X + 10, xa688a683bf2cfced.Bottom - x189455fe88a3b711, 4, x189455fe88a3b711 - 4));
			x130e0425ae2d4496.xe5e0d1644c72aafd(xd9927c905e42526c, new Rectangle(xa688a683bf2cfced.X + 76, xa688a683bf2cfced.Bottom - x189455fe88a3b711, 4, x189455fe88a3b711 - 4));
		}

		// Token: 0x060002ED RID: 749 RVA: 0x0001A8B0 File Offset: 0x000198B0
		public static void xe5e0d1644c72aafd(Control xd9927c905e42526c, Rectangle xa688a683bf2cfced)
		{
			IntPtr intPtr = IntPtr.Zero;
			while (!(xa688a683bf2cfced == Rectangle.Empty))
			{
				if (xd9927c905e42526c == null)
				{
					intPtr = IntPtr.Zero;
				}
				else
				{
					intPtr = xd9927c905e42526c.Handle;
				}
				IntPtr dc = x130e0425ae2d4496.GetDC(new HandleRef(xd9927c905e42526c, intPtr));
				IntPtr handle = x130e0425ae2d4496.xf7ba50da2798338e();
				IntPtr intPtr2 = x130e0425ae2d4496.SelectObject(new HandleRef(xd9927c905e42526c, dc), new HandleRef(null, handle));
				x130e0425ae2d4496.PatBlt(new HandleRef(xd9927c905e42526c, dc), xa688a683bf2cfced.X, xa688a683bf2cfced.Y, xa688a683bf2cfced.Width, xa688a683bf2cfced.Height, 5898313);
				x130e0425ae2d4496.SelectObject(new HandleRef(xd9927c905e42526c, dc), new HandleRef(null, intPtr2));
				if ((uint)intPtr <= 4294967295U)
				{
					bool flag = (uint)intPtr2 - (uint)dc < 0U;
					if (flag)
					{
						if (-2 != 0)
						{
							continue;
						}
						continue;
					}
				}
				x130e0425ae2d4496.DeleteObject(new HandleRef(null, handle));
				x130e0425ae2d4496.ReleaseDC(new HandleRef(xd9927c905e42526c, intPtr), new HandleRef(null, dc));
				return;
			}
		}

		// Token: 0x060002EE RID: 750 RVA: 0x0001A9C4 File Offset: 0x000199C4
		private static IntPtr xf7ba50da2798338e()
		{
			short[] array = new short[8];
			IntPtr result;
			for (;;)
			{
				int i;
				for (i = 0; i < 8; i++)
				{
					array[i] = (short)(21845 << (i & 1));
				}
				IntPtr intPtr = x130e0425ae2d4496.CreateBitmap(8, 8, 1, 1, array);
				x130e0425ae2d4496.x78c6fa48e5c2be9b x78c6fa48e5c2be9b = new x130e0425ae2d4496.x78c6fa48e5c2be9b();
				for (;;)
				{
					x78c6fa48e5c2be9b.x1e592a1c6402f4a1 = ColorTranslator.ToWin32(Color.Black);
					x78c6fa48e5c2be9b.x7cedc2a7cb7ec88d = 3;
					x78c6fa48e5c2be9b.x7d12b02569342309 = intPtr;
					result = x130e0425ae2d4496.CreateBrushIndirect(x78c6fa48e5c2be9b);
					if ((uint)i + (uint)intPtr <= 4294967295U)
					{
					}
					if ((uint)intPtr + (uint)i > 4294967295U)
					{
						break;
					}
					x130e0425ae2d4496.DeleteObject(new HandleRef(null, intPtr));
					if (255 != 0)
					{
						return result;
					}
				}
			}
			return result;
		}

		// Token: 0x0200001B RID: 27
		[StructLayout(LayoutKind.Sequential)]
		private class x78c6fa48e5c2be9b
		{
			// Token: 0x040000E1 RID: 225
			public int x7cedc2a7cb7ec88d;

			// Token: 0x040000E2 RID: 226
			public int x1e592a1c6402f4a1;

			// Token: 0x040000E3 RID: 227
			public IntPtr x7d12b02569342309;
		}
	}
}
