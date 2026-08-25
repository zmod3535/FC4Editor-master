using System;
using System.Drawing;
using System.Windows.Forms;

namespace TD.SandBar
{
	// Token: 0x02000047 RID: 71
	internal class xdf1e331801161ebc
	{
		// Token: 0x060003A9 RID: 937 RVA: 0x00011E14 File Offset: 0x00010E14
		public static Size xdd6d4e0a33c8a7db(ToolBar x169279a87b6b72b2, Graphics x41347a961b838962, IToolBarRenderer x38870620fd380a6b, bool xa092001467a0ab7b, int x8a5438a210b3746e, out bool x8e1d21c91e03470f)
		{
			x8e1d21c91e03470f = x169279a87b6b72b2.x0ab92e81b42892bf;
			if (x169279a87b6b72b2.x38eb4ab7578218ee != Size.Empty && x169279a87b6b72b2.x97714101ce5128df == xa092001467a0ab7b && x169279a87b6b72b2.x6e235f0bb3253d5b == x8a5438a210b3746e && x169279a87b6b72b2.x8c5e550ff4f6f29f == x169279a87b6b72b2.Situation)
			{
				return x169279a87b6b72b2.x38eb4ab7578218ee;
			}
			int num;
			int num2;
			xdf1e331801161ebc.x6bab8b033a9bdcdf(x169279a87b6b72b2, x41347a961b838962, x38870620fd380a6b, xa092001467a0ab7b, x8a5438a210b3746e, out num, out num2, out x8e1d21c91e03470f);
			Size size;
			if (xa092001467a0ab7b)
			{
				size = new Size(num2, num);
			}
			else
			{
				size = new Size(num, num2);
			}
			x169279a87b6b72b2.x38eb4ab7578218ee = size;
			x169279a87b6b72b2.x97714101ce5128df = xa092001467a0ab7b;
			x169279a87b6b72b2.x6e235f0bb3253d5b = x8a5438a210b3746e;
			x169279a87b6b72b2.x8c5e550ff4f6f29f = x169279a87b6b72b2.Situation;
			x169279a87b6b72b2.x0ab92e81b42892bf = x8e1d21c91e03470f;
			return size;
		}

		// Token: 0x060003AA RID: 938 RVA: 0x00011EBC File Offset: 0x00010EBC
		public static void xf01c0312483a47c8(ToolBar x169279a87b6b72b2, Graphics x41347a961b838962, Rectangle xda73fcb97c77d998, IToolBarRenderer x38870620fd380a6b, bool xa092001467a0ab7b, bool x1158f70b6f5fc38e, bool xae19c2cc7f3edb97)
		{
			int x3fb8b43b602e016f;
			int num;
			bool flag;
			ToolbarItemBase[] xf8b54ce7724a27f = xdf1e331801161ebc.x6bab8b033a9bdcdf(x169279a87b6b72b2, x41347a961b838962, x38870620fd380a6b, xa092001467a0ab7b, xa092001467a0ab7b ? xda73fcb97c77d998.Height : xda73fcb97c77d998.Width, out x3fb8b43b602e016f, out num, out flag);
			xdf1e331801161ebc.x79b6b5bb964d83ce(x169279a87b6b72b2, xda73fcb97c77d998, xa092001467a0ab7b, x1158f70b6f5fc38e, xae19c2cc7f3edb97, xf8b54ce7724a27f, x3fb8b43b602e016f);
			xdf1e331801161ebc.xa926ec58de0cdacc(x169279a87b6b72b2, x41347a961b838962, xf8b54ce7724a27f, xa092001467a0ab7b, x1158f70b6f5fc38e);
		}

		// Token: 0x060003AB RID: 939 RVA: 0x00011F0C File Offset: 0x00010F0C
		private static void xa926ec58de0cdacc(ToolBar x169279a87b6b72b2, Graphics x41347a961b838962, ToolbarItemBase[] xf8b54ce7724a27f2, bool xa092001467a0ab7b, bool xcb35b7c43d7acd61)
		{
			foreach (ToolbarItemBase toolbarItemBase in xf8b54ce7724a27f2)
			{
				if (!toolbarItemBase.Visible || toolbarItemBase.x3780ff57150950cd)
				{
					toolbarItemBase.ApplyLayout(Rectangle.Empty, x41347a961b838962, xa092001467a0ab7b, xcb35b7c43d7acd61);
				}
				else
				{
					toolbarItemBase.ApplyLayout(toolbarItemBase.x4c41994726d9329e, x41347a961b838962, xa092001467a0ab7b, xcb35b7c43d7acd61);
				}
				if (toolbarItemBase is ControlContainerItem)
				{
					Control containedControl = ((ControlContainerItem)toolbarItemBase).ContainedControl;
					containedControl.Visible = (toolbarItemBase.Visible && !toolbarItemBase.x3780ff57150950cd);
				}
			}
		}

		// Token: 0x060003AC RID: 940 RVA: 0x00011F90 File Offset: 0x00010F90
		private static ToolbarItemBase[] x6bab8b033a9bdcdf(ToolBar x169279a87b6b72b2, Graphics x41347a961b838962, IToolBarRenderer x38870620fd380a6b, bool xa092001467a0ab7b, int x2691ec01b4783780, out int x31f982dcfc622bfb, out int x4025be4ede763f0a, out bool x8e1d21c91e03470f)
		{
			x38870620fd380a6b.StartToolBarRender(x169279a87b6b72b2, x169279a87b6b72b2.Flow == ToolBarLayout.Vertical, x169279a87b6b72b2.RightToLeft == RightToLeft.Yes);
			ToolbarItemBase[] array;
			int num6;
			int num7;
			for (;;)
			{
				IL_18A:
				int num;
				int num2;
				ToolbarItemBase[] array2;
				int num4;
				if ((uint)num + (uint)num <= 4294967295U)
				{
					num2 = 0;
					x8e1d21c91e03470f = false;
					array = new ToolbarItemBase[x169279a87b6b72b2.Items.Count];
					if (x169279a87b6b72b2.TextAlign == ToolBarTextAlign.Underneath)
					{
						num2 = xdf1e331801161ebc.x3959db82eb8dc8ee(x169279a87b6b72b2, x41347a961b838962, x38870620fd380a6b, xa092001467a0ab7b);
					}
					int num3 = 0;
					foreach (object obj in x169279a87b6b72b2.Items)
					{
						ToolbarItemBase toolbarItemBase = (ToolbarItemBase)obj;
						Size x8f61b3344614569b = xdf1e331801161ebc.xe1897dd78afef85a(x169279a87b6b72b2, x41347a961b838962, toolbarItemBase, xa092001467a0ab7b, x38870620fd380a6b);
						if (num2 != 0 && toolbarItemBase is ButtonItemBase)
						{
							if (xa092001467a0ab7b)
							{
								x8f61b3344614569b.Height = num2;
							}
							else if (toolbarItemBase is DropDownMenuItem)
							{
								x8f61b3344614569b.Width = num2 + 11;
							}
							else
							{
								x8f61b3344614569b.Width = num2;
							}
						}
						toolbarItemBase.x8f61b3344614569b = x8f61b3344614569b;
						array[num3++] = toolbarItemBase;
					}
					array2 = array;
					num4 = 0;
				}
				int num5;
				bool flag;
				for (;;)
				{
					ToolbarItemBase toolbarItemBase2;
					Size x8f61b3344614569b2;
					if (num4 >= array2.Length)
					{
						if ((uint)num5 - (flag ? 1U : 0U) <= 4294967295U)
						{
							break;
						}
						goto IL_2C9;
					}
					else
					{
						toolbarItemBase2 = array2[num4];
						x8f61b3344614569b2 = toolbarItemBase2.x8f61b3344614569b;
						if (!xa092001467a0ab7b)
						{
							goto IL_2C9;
						}
						x8f61b3344614569b2.Width += toolbarItemBase2.Padding.Top + toolbarItemBase2.Padding.Bottom;
						x8f61b3344614569b2.Height += toolbarItemBase2.Padding.Left + toolbarItemBase2.Padding.Right;
					}
					IL_317:
					toolbarItemBase2.x431c36f4c0c5b98d = x8f61b3344614569b2;
					num4++;
					continue;
					IL_2C9:
					x8f61b3344614569b2.Width += toolbarItemBase2.Padding.Left + toolbarItemBase2.Padding.Right;
					x8f61b3344614569b2.Height += toolbarItemBase2.Padding.Top + toolbarItemBase2.Padding.Bottom;
					goto IL_317;
				}
				num5 = 0;
				num6 = 0;
				x31f982dcfc622bfb = 0;
				num7 = 0;
				flag = true;
				ToolbarItemBase[] array3 = array;
				int i = 0;
				while (i < array3.Length)
				{
					ToolbarItemBase toolbarItemBase3 = array3[i];
					Size x431c36f4c0c5b98d = toolbarItemBase3.x431c36f4c0c5b98d;
					int num8 = xa092001467a0ab7b ? x431c36f4c0c5b98d.Height : x431c36f4c0c5b98d.Width;
					bool flag2 = ((uint)num2 | 15U) == 0U;
					if (flag2)
					{
						goto IL_18A;
					}
					int num9 = xa092001467a0ab7b ? x431c36f4c0c5b98d.Width : x431c36f4c0c5b98d.Height;
					if (toolbarItemBase3.Visible && (!(toolbarItemBase3 is ControlContainerItem) || !xa092001467a0ab7b))
					{
						num = 0;
						if (toolbarItemBase3.BeginGroup && !flag)
						{
							num += 7;
						}
						flag = false;
						num += num8;
						if (x169279a87b6b72b2.Overflow == ToolBarOverflow.Wrap && num5 + num > x2691ec01b4783780)
						{
							num5 = 0;
							num6 += num7 + 1;
							num7 = 0;
							x8e1d21c91e03470f = true;
						}
						if (x169279a87b6b72b2.Overflow != ToolBarOverflow.Wrap || num5 + num <= x2691ec01b4783780)
						{
							num5 += num + 1;
						}
						else
						{
							num9 = 0;
						}
						if (num5 > x31f982dcfc622bfb)
						{
							x31f982dcfc622bfb = num5;
						}
					}
					if (!(toolbarItemBase3 is ControlContainerItem))
					{
						goto IL_1E;
					}
					if (!xa092001467a0ab7b)
					{
						goto IL_1E;
					}
					IL_28:
					i++;
					continue;
					IL_1E:
					if (num9 > num7)
					{
						num7 = num9;
						goto IL_28;
					}
					goto IL_28;
				}
				break;
			}
			x4025be4ede763f0a = num6 + num7 + 1;
			x38870620fd380a6b.FinishToolBarRender();
			return array;
		}

		// Token: 0x060003AD RID: 941 RVA: 0x000122F0 File Offset: 0x000112F0
		private static void x79b6b5bb964d83ce(ToolBar x169279a87b6b72b2, Rectangle xda73fcb97c77d998, bool xa092001467a0ab7b, bool x1158f70b6f5fc38e, bool xae19c2cc7f3edb97, ToolbarItemBase[] xf8b54ce7724a27f2, int x3fb8b43b602e016f)
		{
			int num = x169279a87b6b72b2.Items.Count - 1;
			int num2 = 0;
			for (;;)
			{
				ToolbarItemBase toolbarItemBase2;
				if (num2 > num)
				{
					int j;
					if (x3fb8b43b602e016f > (xa092001467a0ab7b ? xda73fcb97c77d998.Height : xda73fcb97c77d998.Width) && x169279a87b6b72b2.Overflow != ToolBarOverflow.Wrap)
					{
						for (int i = 0; i <= 4; i++)
						{
							for (j = num; j >= 0; j--)
							{
								if (xf8b54ce7724a27f2[j].ItemImportance == (ItemImportance)i && xf8b54ce7724a27f2[j].Visible)
								{
									xf8b54ce7724a27f2[j].x3780ff57150950cd = true;
									if (xf8b54ce7724a27f2[j].BeginGroup)
									{
										x3fb8b43b602e016f -= 7;
									}
									Size x431c36f4c0c5b98d = xf8b54ce7724a27f2[j].x431c36f4c0c5b98d;
									x3fb8b43b602e016f -= (xa092001467a0ab7b ? x431c36f4c0c5b98d.Height : x431c36f4c0c5b98d.Width);
									x3fb8b43b602e016f--;
									if (x3fb8b43b602e016f <= (xa092001467a0ab7b ? xda73fcb97c77d998.Height : xda73fcb97c77d998.Width))
									{
										goto IL_154;
									}
								}
							}
						}
					}
					IL_154:
					int num3 = 0;
					int k = 0;
					while (k < xf8b54ce7724a27f2.Length)
					{
						xdf1e331801161ebc.xd58a5e49d9cdd49e(x169279a87b6b72b2, xda73fcb97c77d998, ref k, ref num3, xa092001467a0ab7b, x1158f70b6f5fc38e, xae19c2cc7f3edb97, xf8b54ce7724a27f2);
					}
					num3--;
					int num4 = xa092001467a0ab7b ? xda73fcb97c77d998.Width : xda73fcb97c77d998.Height;
					if (num4 > num3 + 1)
					{
						int num5 = (num4 - num3) / 2;
						foreach (ToolbarItemBase toolbarItemBase in xf8b54ce7724a27f2)
						{
							Rectangle x4c41994726d9329e = toolbarItemBase.x4c41994726d9329e;
							if (xa092001467a0ab7b)
							{
								bool flag = (uint)x3fb8b43b602e016f > uint.MaxValue;
								if (flag)
								{
									break;
								}
								x4c41994726d9329e.X += num5;
							}
							else
							{
								x4c41994726d9329e.Y += num5;
								if ((uint)num4 - (uint)j < 0U)
								{
									goto IL_174;
								}
							}
							toolbarItemBase.x4c41994726d9329e = x4c41994726d9329e;
						}
						break;
					}
					break;
				}
				else
				{
					toolbarItemBase2 = xf8b54ce7724a27f2[num2];
					toolbarItemBase2.x3780ff57150950cd = false;
				}
				IL_174:
				if (toolbarItemBase2 is ControlContainerItem && xa092001467a0ab7b)
				{
					toolbarItemBase2.x3780ff57150950cd = true;
					Size x431c36f4c0c5b98d2 = toolbarItemBase2.x431c36f4c0c5b98d;
					x3fb8b43b602e016f -= (xa092001467a0ab7b ? x431c36f4c0c5b98d2.Height : x431c36f4c0c5b98d2.Width);
					if (toolbarItemBase2.BeginGroup)
					{
						x3fb8b43b602e016f -= 7;
					}
				}
				num2++;
			}
		}

		// Token: 0x060003AE RID: 942 RVA: 0x00012528 File Offset: 0x00011528
		private static void xd58a5e49d9cdd49e(ToolBar x169279a87b6b72b2, Rectangle xda73fcb97c77d998, ref int x192f45eeb07722f5, ref int x277da5a0c0e937b7, bool xa092001467a0ab7b, bool x1158f70b6f5fc38e, bool xae19c2cc7f3edb97, ToolbarItemBase[] xf8b54ce7724a27f2)
		{
			int num = 0;
			int num2 = -1;
			ToolbarItemBase[] array = new ToolbarItemBase[xf8b54ce7724a27f2.Length];
			int num3 = 0;
			bool flag = true;
			int num4 = 0;
			int num5 = 0;
			int i = x192f45eeb07722f5;
			int num6;
			int num7;
			bool flag2;
			while (i < xf8b54ce7724a27f2.Length)
			{
				ToolbarItemBase toolbarItemBase = xf8b54ce7724a27f2[i];
				if (toolbarItemBase.Visible && !toolbarItemBase.x3780ff57150950cd)
				{
					num6 = 0;
					toolbarItemBase.x3de314ab70bbd9bf = (toolbarItemBase.BeginGroup && !flag);
					if (toolbarItemBase.x3de314ab70bbd9bf)
					{
						num6 += 7;
					}
					flag = false;
					Size x431c36f4c0c5b98d = toolbarItemBase.x431c36f4c0c5b98d;
					num6 += (xa092001467a0ab7b ? x431c36f4c0c5b98d.Height : x431c36f4c0c5b98d.Width);
					flag2 = ((uint)num7 + (uint)num7 > uint.MaxValue);
					if (!flag2)
					{
						if (x169279a87b6b72b2.Overflow == ToolBarOverflow.Wrap && num + num6 > (xa092001467a0ab7b ? xda73fcb97c77d998.Height : xda73fcb97c77d998.Width))
						{
							break;
						}
						toolbarItemBase.xcad45d9e26d3a755 = num;
						if (toolbarItemBase.x3de314ab70bbd9bf)
						{
							toolbarItemBase.xcad45d9e26d3a755 += 7;
						}
						num += num6 + 1;
						if (xa092001467a0ab7b && x431c36f4c0c5b98d.Width > num4)
						{
							num4 = x431c36f4c0c5b98d.Width;
						}
						else if (!xa092001467a0ab7b && x431c36f4c0c5b98d.Height > num4)
						{
							num4 = x431c36f4c0c5b98d.Height;
						}
						num2 = i;
						array[num3++] = toolbarItemBase;
						if (toolbarItemBase.Stretch)
						{
							num5++;
						}
					}
				}
				else
				{
					num2 = i;
				}
				IL_413:
				i++;
				continue;
				goto IL_413;
			}
			if (num5 == 0 || num2 == -1)
			{
				goto IL_2FD;
			}
			num7 = (xa092001467a0ab7b ? (xda73fcb97c77d998.Height - num) : (xda73fcb97c77d998.Width - num));
			int num8 = num5;
			int num9 = num7 / num8;
			flag2 = (((uint)num6 | 4294967294U) == 0U);
			if (flag2)
			{
				goto IL_5D0;
			}
			goto IL_367;
			IL_D0:
			int num10;
			num10++;
			IL_D6:
			if (num10 > num2)
			{
				x277da5a0c0e937b7 += num4 + 1;
				x192f45eeb07722f5 = num2 + 1;
				flag2 = ((uint)num3 - (xae19c2cc7f3edb97 ? 1U : 0U) > uint.MaxValue);
				if (flag2)
				{
					goto IL_1C2;
				}
				return;
			}
			else
			{
				ToolbarItemBase toolbarItemBase2 = xf8b54ce7724a27f2[num10];
				if (!toolbarItemBase2.Visible || toolbarItemBase2.x3780ff57150950cd)
				{
					goto IL_D0;
				}
				Size x431c36f4c0c5b98d2 = toolbarItemBase2.x431c36f4c0c5b98d;
				Size x8f61b3344614569b = toolbarItemBase2.x8f61b3344614569b;
				if (xa092001467a0ab7b)
				{
					if (!x1158f70b6f5fc38e)
					{
						toolbarItemBase2.x4c41994726d9329e = new Rectangle(xda73fcb97c77d998.X + x277da5a0c0e937b7 + toolbarItemBase2.x9be9d8a5ea186c43, xda73fcb97c77d998.Y + toolbarItemBase2.xcad45d9e26d3a755, x431c36f4c0c5b98d2.Width, x431c36f4c0c5b98d2.Height);
						goto IL_D0;
					}
					if ((uint)i < 0U)
					{
						goto IL_3AB;
					}
					toolbarItemBase2.x4c41994726d9329e = new Rectangle(xda73fcb97c77d998.X + x277da5a0c0e937b7 + toolbarItemBase2.x9be9d8a5ea186c43, xda73fcb97c77d998.Bottom - toolbarItemBase2.xcad45d9e26d3a755 - x431c36f4c0c5b98d2.Height, x431c36f4c0c5b98d2.Width, x431c36f4c0c5b98d2.Height);
					flag2 = ((uint)num9 > uint.MaxValue);
					if (flag2)
					{
						goto IL_1C2;
					}
					goto IL_D0;
				}
				else
				{
					if (x1158f70b6f5fc38e)
					{
						toolbarItemBase2.x4c41994726d9329e = new Rectangle(xda73fcb97c77d998.Right - toolbarItemBase2.xcad45d9e26d3a755 - x431c36f4c0c5b98d2.Width, xda73fcb97c77d998.Y + x277da5a0c0e937b7 + toolbarItemBase2.x9be9d8a5ea186c43, x431c36f4c0c5b98d2.Width, x431c36f4c0c5b98d2.Height);
						goto IL_D0;
					}
					toolbarItemBase2.x4c41994726d9329e = new Rectangle(xda73fcb97c77d998.X + toolbarItemBase2.xcad45d9e26d3a755, xda73fcb97c77d998.Y + x277da5a0c0e937b7 + toolbarItemBase2.x9be9d8a5ea186c43, x431c36f4c0c5b98d2.Width, x431c36f4c0c5b98d2.Height);
					goto IL_D0;
				}
			}
			IL_11B:
			goto IL_D6;
			IL_1C2:
			Size x431c36f4c0c5b98d3;
			if (xa092001467a0ab7b)
			{
				xf8b54ce7724a27f2[num2].xcad45d9e26d3a755 = xda73fcb97c77d998.Height - x431c36f4c0c5b98d3.Height;
			}
			else
			{
				xf8b54ce7724a27f2[num2].xcad45d9e26d3a755 = xda73fcb97c77d998.Width - x431c36f4c0c5b98d3.Width;
				if ((uint)num9 - (uint)num7 < 0U)
				{
					goto IL_D0;
				}
			}
			IL_213:
			float num11 = (float)num4 / 2f;
			for (int j = x192f45eeb07722f5; j <= num2; j++)
			{
				ToolbarItemBase toolbarItemBase3 = xf8b54ce7724a27f2[j];
				if (toolbarItemBase3.Visible && !toolbarItemBase3.x3780ff57150950cd)
				{
					Size x431c36f4c0c5b98d4 = toolbarItemBase3.x431c36f4c0c5b98d;
					int num12 = xa092001467a0ab7b ? x431c36f4c0c5b98d4.Width : x431c36f4c0c5b98d4.Height;
					toolbarItemBase3.x9be9d8a5ea186c43 = (int)Math.Round((double)(num11 - (float)num12 / 2f), 0);
				}
			}
			num10 = x192f45eeb07722f5;
			goto IL_11B;
			IL_2EF:
			int num13;
			num13++;
			IL_2F5:
			if (num13 <= num2)
			{
				if (!xf8b54ce7724a27f2[num13].Stretch)
				{
					goto IL_2EF;
				}
				if ((x1158f70b6f5fc38e ? 1U : 0U) >= 0U)
				{
					goto IL_3AB;
				}
				goto IL_304;
			}
			IL_2FD:
			if (num2 != -1)
			{
				goto IL_312;
			}
			num2 = x192f45eeb07722f5;
			IL_304:
			ToolbarItemBase toolbarItemBase4 = xf8b54ce7724a27f2[num2];
			toolbarItemBase4.x3780ff57150950cd = true;
			IL_312:
			if (!xae19c2cc7f3edb97 || num2 != xf8b54ce7724a27f2.Length - 1 || xf8b54ce7724a27f2[num2].x3780ff57150950cd || !xf8b54ce7724a27f2[num2].Visible)
			{
				goto IL_213;
			}
			x431c36f4c0c5b98d3 = xf8b54ce7724a27f2[num2].x431c36f4c0c5b98d;
			flag2 = ((uint)num7 - (uint)num11 < 0U);
			if (!flag2)
			{
				goto IL_5D0;
			}
			IL_367:
			flag2 = (((uint)num5 & 0U) == 0U);
			if (flag2)
			{
				num13 = x192f45eeb07722f5;
				goto IL_2F5;
			}
			goto IL_11B;
			IL_3AB:
			int num14 = (num8 == 1) ? num7 : num9;
			Size x431c36f4c0c5b98d5 = xf8b54ce7724a27f2[num13].x431c36f4c0c5b98d;
			Size x8f61b3344614569b2 = xf8b54ce7724a27f2[num13].x8f61b3344614569b;
			if (xa092001467a0ab7b)
			{
				x431c36f4c0c5b98d5.Height += num14;
				x8f61b3344614569b2.Height += num14;
			}
			else
			{
				x431c36f4c0c5b98d5.Width += num14;
				x8f61b3344614569b2.Width += num14;
			}
			xf8b54ce7724a27f2[num13].x431c36f4c0c5b98d = x431c36f4c0c5b98d5;
			xf8b54ce7724a27f2[num13].x8f61b3344614569b = x8f61b3344614569b2;
			num7 -= num14;
			num8--;
			if (num13 < num2)
			{
				for (int k = num13 + 1; k <= num2; k++)
				{
					xf8b54ce7724a27f2[k].xcad45d9e26d3a755 += num14;
				}
				goto IL_2EF;
			}
			goto IL_2EF;
			IL_5D0:
			goto IL_1C2;
		}

		// Token: 0x060003AF RID: 943 RVA: 0x00012B0C File Offset: 0x00011B0C
		private static int x3959db82eb8dc8ee(ToolBar x169279a87b6b72b2, Graphics x41347a961b838962, IToolBarRenderer x38870620fd380a6b, bool xa092001467a0ab7b)
		{
			int num = 0;
			foreach (object obj in x169279a87b6b72b2.Items)
			{
				ToolbarItemBase toolbarItemBase = (ToolbarItemBase)obj;
				if (toolbarItemBase is ButtonItemBase)
				{
					Size size = xdf1e331801161ebc.xe1897dd78afef85a(x169279a87b6b72b2, x41347a961b838962, toolbarItemBase, xa092001467a0ab7b, x38870620fd380a6b);
					if (xa092001467a0ab7b)
					{
						if (size.Height > num)
						{
							num = size.Height;
						}
					}
					else if (toolbarItemBase is DropDownMenuItem)
					{
						if (size.Width - 11 > num)
						{
							num = size.Width - 11;
						}
					}
					else if (size.Width > num)
					{
						num = size.Width;
					}
				}
			}
			return num;
		}

		// Token: 0x060003B0 RID: 944 RVA: 0x00012BD4 File Offset: 0x00011BD4
		public static Size xe1897dd78afef85a(ToolBar x169279a87b6b72b2, Graphics x41347a961b838962, ToolbarItemBase xccb63ca5f63dc470, bool xa092001467a0ab7b, IToolBarRenderer x38870620fd380a6b)
		{
			Size size = Size.Empty;
			Size size2 = Size.Empty;
			Size result;
			for (;;)
			{
				int width;
				if (xccb63ca5f63dc470.Text.Length != 0)
				{
					if (x169279a87b6b72b2.TextAlign == ToolBarTextAlign.Underneath)
					{
						x38870620fd380a6b.ItemTextFormatFlags |= TextFormatFlags.HorizontalCenter;
					}
					size = TextRenderer.MeasureText(x41347a961b838962, xccb63ca5f63dc470.Text, xccb63ca5f63dc470.Font, new Size(int.MaxValue, int.MaxValue), x38870620fd380a6b.ItemTextFormatFlags);
					x38870620fd380a6b.ItemTextFormatFlags &= ~TextFormatFlags.HorizontalCenter;
					if (xa092001467a0ab7b)
					{
						width = size.Width;
						size.Width = size.Height;
						goto IL_342;
					}
				}
				IL_34A:
				result = size;
				if (xccb63ca5f63dc470 is ImageItemBase)
				{
					ImageItemBase imageItemBase = (ImageItemBase)xccb63ca5f63dc470;
					if (imageItemBase.Icon != null)
					{
						size2 = imageItemBase.IconSize;
					}
					else if (imageItemBase.Image != null)
					{
						size2 = imageItemBase.Image.Size;
					}
					else if (imageItemBase.ImageList != null && imageItemBase.ImageIndex >= 0 && imageItemBase.ImageIndex <= imageItemBase.ImageList.Images.Count - 1)
					{
						size2 = imageItemBase.ImageList.ImageSize;
					}
					if (size2.Width != 0)
					{
						goto IL_29B;
					}
					goto IL_16B;
				}
				else
				{
					if (!(xccb63ca5f63dc470 is ControlContainerItem))
					{
						goto IL_16B;
					}
					ControlContainerItem controlContainerItem = (ControlContainerItem)xccb63ca5f63dc470;
					result.Width += controlContainerItem.MinimumControlWidth;
					result.Height = Math.Max(result.Height, controlContainerItem.ContainedControl.Height);
					if (size.Width != 0)
					{
						result.Width += 3;
						goto IL_16B;
					}
					goto IL_16B;
				}
				IL_1B5:
				bool flag;
				if (((StatusBarItem)xccb63ca5f63dc470).ShowBorder)
				{
					result.Width += 2;
					result.Height += 2;
					flag = ((xa092001467a0ab7b ? 1U : 0U) + (xa092001467a0ab7b ? 1U : 0U) > uint.MaxValue);
					if (flag)
					{
						flag = ((xa092001467a0ab7b ? 1U : 0U) + (xa092001467a0ab7b ? 1U : 0U) < 0U);
						if (flag)
						{
							goto IL_29B;
						}
						goto IL_342;
					}
				}
				if (xa092001467a0ab7b)
				{
					break;
				}
				result.Width += 4;
				flag = (((xa092001467a0ab7b ? 1U : 0U) & 0U) == 0U);
				if (flag)
				{
					goto IL_45;
				}
				continue;
				IL_16B:
				if (!(xccb63ca5f63dc470 is StatusBarItem))
				{
					goto IL_45;
				}
				int num = xccb63ca5f63dc470.Font.Height + 2;
				if (xa092001467a0ab7b && result.Width < num)
				{
					result.Width = num;
					goto IL_1B5;
				}
				if (!xa092001467a0ab7b && result.Height < num)
				{
					result.Height = num;
					goto IL_1B5;
				}
				goto IL_1B5;
				IL_29B:
				if (xa092001467a0ab7b)
				{
					if (size.Width != 0)
					{
						if (x169279a87b6b72b2.TextAlign == ToolBarTextAlign.Underneath)
						{
							if (size2.Height > result.Height)
							{
								result.Height = size2.Height;
							}
							result.Width += size2.Width + 2;
						}
						else
						{
							if (size2.Width > result.Width)
							{
								result.Width = size2.Width;
							}
							result.Height += size2.Height + 2;
						}
					}
					else
					{
						result = size2;
					}
				}
				else if (size.Width != 0)
				{
					if (x169279a87b6b72b2.TextAlign == ToolBarTextAlign.Underneath)
					{
						if (size2.Width > result.Width)
						{
							result.Width = size2.Width;
						}
						result.Height += size2.Height + 2;
					}
					else
					{
						if (size2.Height > result.Height)
						{
							result.Height = size2.Height;
						}
						result.Width += size2.Width + 2;
						if ((uint)width < 0U)
						{
							goto IL_1B5;
						}
					}
				}
				else
				{
					result = size2;
					if ((xa092001467a0ab7b ? 1U : 0U) - (uint)num >= 0U)
					{
					}
				}
				goto IL_16B;
				IL_342:
				size.Height = width;
				goto IL_34A;
			}
			result.Height += 4;
			IL_45:
			if (result.Width < 16)
			{
				result.Width = 16;
			}
			if (result.Height < 12)
			{
				result.Height = 12;
			}
			if (xccb63ca5f63dc470.MinimumSize > 0)
			{
				if (xa092001467a0ab7b && result.Height < xccb63ca5f63dc470.MinimumSize)
				{
					result.Height = xccb63ca5f63dc470.MinimumSize;
				}
				else if (!xa092001467a0ab7b && result.Width < xccb63ca5f63dc470.MinimumSize)
				{
					result.Width = xccb63ca5f63dc470.MinimumSize;
				}
			}
			if (xccb63ca5f63dc470 is DropDownMenuItem)
			{
				result.Width += 11;
			}
			return result;
		}

		// Token: 0x0400019E RID: 414
		public const int x36a47a6ef3565446 = 2;

		// Token: 0x0400019F RID: 415
		public const int xd69450dd60fc4aa9 = 3;
	}
}
