using System;
using System.Drawing;
using System.Windows.Forms;

namespace Divelements.SandGrid
{
	// Token: 0x0200005A RID: 90
	internal static class x5d3666f49ba1c366
	{
		// Token: 0x06000555 RID: 1365 RVA: 0x0001C158 File Offset: 0x0001B158
		public static void x3b699d824d6abf29(SandGridBase x3040c866fac95193, MouseEventArgs xfbf34718e704c6bc)
		{
			if (!x3040c866fac95193.Capture)
			{
				x5d3666f49ba1c366.x1a125ea865e29ab6 = x3040c866fac95193.PrimaryGrid.HitTest(new Point(xfbf34718e704c6bc.X, xfbf34718e704c6bc.Y));
			}
			if (x5d3666f49ba1c366.x1a125ea865e29ab6 != null)
			{
				x5d3666f49ba1c366.x1a125ea865e29ab6.OnMouseMove(xfbf34718e704c6bc);
			}
		}

		// Token: 0x06000556 RID: 1366 RVA: 0x0001C198 File Offset: 0x0001B198
		public static void x35085a23be2a381a(SandGridBase x3040c866fac95193, MouseEventArgs xfbf34718e704c6bc)
		{
			if (!x3040c866fac95193.Capture)
			{
				x5d3666f49ba1c366.x1a125ea865e29ab6 = x3040c866fac95193.PrimaryGrid.HitTest(new Point(xfbf34718e704c6bc.X, xfbf34718e704c6bc.Y));
			}
			if (x5d3666f49ba1c366.x1a125ea865e29ab6 != null)
			{
				x5d3666f49ba1c366.x1a125ea865e29ab6.OnMouseDown(xfbf34718e704c6bc);
			}
		}

		// Token: 0x06000557 RID: 1367 RVA: 0x0001C1D8 File Offset: 0x0001B1D8
		public static void xaeb9c29200d2fd71(SandGridBase x3040c866fac95193)
		{
			x5d3666f49ba1c366.x1a125ea865e29ab6 = null;
		}

		// Token: 0x06000558 RID: 1368 RVA: 0x0001C1E0 File Offset: 0x0001B1E0
		public static void x13ea64a23cc9492a(SandGridBase x3040c866fac95193, MouseEventArgs xfbf34718e704c6bc)
		{
			if (x5d3666f49ba1c366.x1a125ea865e29ab6 != null)
			{
				x5d3666f49ba1c366.x1a125ea865e29ab6.OnMouseUp(xfbf34718e704c6bc);
			}
		}

		// Token: 0x06000559 RID: 1369 RVA: 0x0001C1F4 File Offset: 0x0001B1F4
		public static void x4a88bb2da4167d39(SandGridBase x3040c866fac95193)
		{
			if (x5d3666f49ba1c366.x1a125ea865e29ab6 != null)
			{
				x5d3666f49ba1c366.x1a125ea865e29ab6.OnMouseLostCapture();
			}
		}

		// Token: 0x0600055A RID: 1370 RVA: 0x0001C208 File Offset: 0x0001B208
		public static bool xa96e14d79552a61d(SandGridBase x3040c866fac95193, MouseEventArgs xfbf34718e704c6bc)
		{
			x5d3666f49ba1c366.xf9ca2a82eb46415d = false;
			if (x5d3666f49ba1c366.x1a125ea865e29ab6 != null)
			{
				x5d3666f49ba1c366.x1a125ea865e29ab6.OnMouseDoubleClick(xfbf34718e704c6bc);
			}
			return x5d3666f49ba1c366.xf9ca2a82eb46415d;
		}

		// Token: 0x0600055B RID: 1371 RVA: 0x0001C228 File Offset: 0x0001B228
		public static void x76b0eec27bc2d901(GridElement x4bbc2c453c470189)
		{
			x5d3666f49ba1c366.x1a125ea865e29ab6 = x4bbc2c453c470189;
		}

		// Token: 0x0600055C RID: 1372 RVA: 0x0001C230 File Offset: 0x0001B230
		public static void x2f8a63bfec1c0c0f(GridElement x4bbc2c453c470189)
		{
			if (x5d3666f49ba1c366.x1a125ea865e29ab6 == x4bbc2c453c470189)
			{
				x5d3666f49ba1c366.x1a125ea865e29ab6 = null;
			}
		}

		// Token: 0x17000151 RID: 337
		// (get) Token: 0x0600055D RID: 1373 RVA: 0x0001C240 File Offset: 0x0001B240
		// (set) Token: 0x0600055E RID: 1374 RVA: 0x0001C248 File Offset: 0x0001B248
		private static GridElement x1a125ea865e29ab6
		{
			get
			{
				return x5d3666f49ba1c366.xc4f40346f88dfb80;
			}
			set
			{
				if (value != x5d3666f49ba1c366.xc4f40346f88dfb80)
				{
					if (x5d3666f49ba1c366.xc4f40346f88dfb80 != null)
					{
						x5d3666f49ba1c366.xc4f40346f88dfb80.OnMouseLeave();
					}
					x5d3666f49ba1c366.xc4f40346f88dfb80 = value;
				}
			}
		}

		// Token: 0x040001F3 RID: 499
		private static GridElement xc4f40346f88dfb80;

		// Token: 0x040001F4 RID: 500
		private static bool xf9ca2a82eb46415d;
	}
}
