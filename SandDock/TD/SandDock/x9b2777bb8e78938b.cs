using System;
using System.Drawing;

namespace TD.SandDock
{
	// Token: 0x0200002B RID: 43
	internal class x9b2777bb8e78938b
	{
		// Token: 0x060003A4 RID: 932 RVA: 0x0001CB08 File Offset: 0x0001BB08
		private x9b2777bb8e78938b()
		{
		}

		// Token: 0x060003A5 RID: 933 RVA: 0x0001CB10 File Offset: 0x0001BB10
		public static void xeac2e7eb44dff86e(Graphics x41347a961b838962, Rectangle xda73fcb97c77d998, Pen x90279591611601bc)
		{
			int num = xda73fcb97c77d998.Width / 4;
			int num2 = 1;
			for (;;)
			{
				if (num2 <= num)
				{
					goto IL_2C;
				}
				bool flag;
				if (-1 != 0)
				{
					flag = ((uint)num > uint.MaxValue);
					if (flag)
					{
						goto IL_2C;
					}
					break;
				}
				IL_70:
				num2++;
				int num3;
				flag = (((uint)num3 | 1U) == 0U);
				if (flag)
				{
					break;
				}
				continue;
				IL_2C:
				int num4 = (num - num2) * 2;
				num3 = xda73fcb97c77d998.Left + xda73fcb97c77d998.Width / 2 - (num - num2);
				int num5 = xda73fcb97c77d998.Top + xda73fcb97c77d998.Height / 2 + (num2 - 1);
				x41347a961b838962.DrawLine(x90279591611601bc, num3, num5, num3 + num4 + 1, num5);
				goto IL_70;
			}
		}

		// Token: 0x060003A6 RID: 934 RVA: 0x0001CBB8 File Offset: 0x0001BBB8
		public static void xd70a4c1a2378c84e(Graphics x41347a961b838962, Rectangle xda73fcb97c77d998, Color x6c50a99faab7d741, bool x2fef7d841879a711)
		{
			int num = xda73fcb97c77d998.Left + xda73fcb97c77d998.Width / 2;
			int num2 = xda73fcb97c77d998.Top + xda73fcb97c77d998.Height / 2;
			Point[] x6fa2570084b2ad = new Point[]
			{
				new Point(num + 2, num2 - 5),
				new Point(num - 2, num2 - 1),
				new Point(num + 2, num2 + 3)
			};
			do
			{
				x9b2777bb8e78938b.x31bdb6d312240ef9(x41347a961b838962, x6fa2570084b2ad, x6c50a99faab7d741, x2fef7d841879a711);
			}
			while ((uint)num2 > 4294967295U);
		}

		// Token: 0x060003A7 RID: 935 RVA: 0x0001CC5C File Offset: 0x0001BC5C
		public static void x793dc1a7cf4113f9(Graphics x41347a961b838962, Rectangle xda73fcb97c77d998, Color x6c50a99faab7d741, bool x2fef7d841879a711)
		{
			int num = xda73fcb97c77d998.Left + xda73fcb97c77d998.Width / 2;
			int num2 = xda73fcb97c77d998.Top + xda73fcb97c77d998.Height / 2;
			Point[] array = new Point[3];
			if ((x2fef7d841879a711 ? 1U : 0U) <= 4294967295U)
			{
				array[0] = new Point(num - 2, num2 - 5);
			}
			array[1] = new Point(num + 2, num2 - 1);
			array[2] = new Point(num - 2, num2 + 3);
			x9b2777bb8e78938b.x31bdb6d312240ef9(x41347a961b838962, array, x6c50a99faab7d741, x2fef7d841879a711);
		}

		// Token: 0x060003A8 RID: 936 RVA: 0x0001CD00 File Offset: 0x0001BD00
		private static void x31bdb6d312240ef9(Graphics x41347a961b838962, Point[] x6fa2570084b2ad39, Color x6c50a99faab7d741, bool x2fef7d841879a711)
		{
			if (x2fef7d841879a711)
			{
				using (SolidBrush solidBrush = new SolidBrush(x6c50a99faab7d741))
				{
					x41347a961b838962.FillPolygon(solidBrush, x6fa2570084b2ad39);
					return;
				}
			}
			using (Pen pen = new Pen(x6c50a99faab7d741))
			{
				x41347a961b838962.DrawPolygon(pen, x6fa2570084b2ad39);
			}
		}

		// Token: 0x060003A9 RID: 937 RVA: 0x0001CD7C File Offset: 0x0001BD7C
		public static void x1477b5a75c8a8132(Graphics x41347a961b838962, Rectangle xda73fcb97c77d998, Pen x90279591611601bc, bool x533813ae5953a526)
		{
			int num = xda73fcb97c77d998.Left + xda73fcb97c77d998.Width / 2;
			int num2 = xda73fcb97c77d998.Top + xda73fcb97c77d998.Height / 2;
			bool flag;
			if (x533813ae5953a526)
			{
				x41347a961b838962.DrawLine(x90279591611601bc, num - 5, num2, num - 2, num2);
				x41347a961b838962.DrawLine(x90279591611601bc, num - 2, num2 - 3, num - 2, num2 + 3);
				x41347a961b838962.DrawLine(x90279591611601bc, num - 2, num2 - 2, num + 4, num2 - 2);
				x41347a961b838962.DrawLine(x90279591611601bc, num - 2, num2 + 1, num + 4, num2 + 1);
				if ((x533813ae5953a526 ? 1U : 0U) - (uint)num2 >= 0U)
				{
					x41347a961b838962.DrawLine(x90279591611601bc, num - 2, num2 + 2, num + 4, num2 + 2);
					flag = ((x533813ae5953a526 ? 1U : 0U) < 0U);
					if (!flag)
					{
						x41347a961b838962.DrawLine(x90279591611601bc, num + 4, num2 - 2, num + 4, num2 + 2);
						return;
					}
				}
			}
			x41347a961b838962.DrawLine(x90279591611601bc, num - 3, num2 + 2, num + 3, num2 + 2);
			x41347a961b838962.DrawLine(x90279591611601bc, num - 2, num2 - 3, num - 2, num2 + 2);
			x41347a961b838962.DrawLine(x90279591611601bc, num - 2, num2 - 3, num + 2, num2 - 3);
			x41347a961b838962.DrawLine(x90279591611601bc, num + 1, num2 - 3, num + 1, num2 + 2);
			flag = (((x533813ae5953a526 ? 1U : 0U) | 3U) == 0U);
			if (!flag)
			{
				x41347a961b838962.DrawLine(x90279591611601bc, num + 2, num2 - 3, num + 2, num2 + 2);
				x41347a961b838962.DrawLine(x90279591611601bc, num, num2 + 2, num, num2 + 5);
			}
		}

		// Token: 0x060003AA RID: 938 RVA: 0x0001CEF8 File Offset: 0x0001BEF8
		public static void xb176aa01ddab9f3e(Graphics x41347a961b838962, Rectangle xda73fcb97c77d998, Pen x90279591611601bc)
		{
			int num = xda73fcb97c77d998.Left + xda73fcb97c77d998.Width / 2 - 1;
			int num2 = xda73fcb97c77d998.Top + xda73fcb97c77d998.Height / 2;
			x41347a961b838962.DrawLine(x90279591611601bc, num - 3, num2 - 4, num + 3, num2 + 2);
			x41347a961b838962.DrawLine(x90279591611601bc, num - 2, num2 - 4, num + 4, num2 + 2);
			x41347a961b838962.DrawLine(x90279591611601bc, num - 3, num2 + 2, num + 3, num2 - 4);
			if ((uint)num - (uint)num <= 4294967295U)
			{
				x41347a961b838962.DrawLine(x90279591611601bc, num - 2, num2 + 2, num + 4, num2 - 4);
			}
		}

		// Token: 0x060003AB RID: 939 RVA: 0x0001CF90 File Offset: 0x0001BF90
		public static void x26f0f0028ef01fa5(Graphics x41347a961b838962, Rectangle xda73fcb97c77d998, Pen x90279591611601bc)
		{
			int num = xda73fcb97c77d998.Left + xda73fcb97c77d998.Width / 2 - 1;
			int num2 = xda73fcb97c77d998.Top + xda73fcb97c77d998.Height / 2;
			if (8 != 0)
			{
				x41347a961b838962.DrawLine(x90279591611601bc, num - 3, num2 - 3, num + 4, num2 + 4);
				x41347a961b838962.DrawLine(x90279591611601bc, num - 2, num2 - 3, num + 4, num2 + 3);
				x41347a961b838962.DrawLine(x90279591611601bc, num - 3, num2 - 2, num + 3, num2 + 4);
			}
			x41347a961b838962.DrawLine(x90279591611601bc, num + 4, num2 - 3, num - 3, num2 + 4);
			x41347a961b838962.DrawLine(x90279591611601bc, num + 3, num2 - 3, num - 3, num2 + 3);
			x41347a961b838962.DrawLine(x90279591611601bc, num + 4, num2 - 2, num - 2, num2 + 4);
		}
	}
}
