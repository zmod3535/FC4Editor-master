using System;
using System.Drawing;
using System.Windows.Forms;

namespace TD.SandDock
{
	// Token: 0x02000058 RID: 88
	internal class x09c1c18390e52ebf : x890231ddf317379e
	{
		// Token: 0x1400001B RID: 27
		// (add) Token: 0x06000512 RID: 1298 RVA: 0x00026C3C File Offset: 0x00025C3C
		// (remove) Token: 0x06000513 RID: 1299 RVA: 0x00026C58 File Offset: 0x00025C58
		public event x09c1c18390e52ebf.ResizingManagerFinishedEventHandler x67ecc0d0e7c9a202;

		// Token: 0x06000514 RID: 1300 RVA: 0x00026C74 File Offset: 0x00025C74
		public x09c1c18390e52ebf(SandDockManager manager, DockContainer container, Point startPoint) : base(container, manager.DockingHints, false)
		{
			Rectangle rectangle;
			int num2;
			int x555227b0d2a372bd;
			int num4;
			bool flag;
			for (;;)
			{
				this.xd3311d815ca25f02 = container;
				rectangle = Rectangle.Empty;
				rectangle = xedb4922162c60d3d.xc68a4bb946c59a9e(xedb4922162c60d3d.x41c62f474d3fb367(container.Parent), container.Parent);
				rectangle = new Rectangle(container.PointToClient(rectangle.Location), rectangle.Size);
				if (manager == null)
				{
					goto IL_2B9;
				}
				int num = manager.MinimumDockContainerSize;
				IL_275:
				num2 = num;
				num2 = Math.Max(num2, LayoutUtilities.xc6fb69ef430eaa44(container));
				int num3;
				if (!false)
				{
					if (manager != null)
					{
						goto IL_234;
					}
					num3 = 500;
					goto IL_23A;
				}
				IL_1D7:
				switch (container.Dock)
				{
				case DockStyle.Top:
					do
					{
						this.xffa8345bf918658d = startPoint.Y - (x555227b0d2a372bd - num2);
					}
					while ((uint)num2 - (uint)x555227b0d2a372bd < 0U);
					if ((uint)num2 < 0U)
					{
						goto IL_234;
					}
					flag = ((uint)x555227b0d2a372bd + (uint)num4 < 0U);
					if (flag)
					{
						return;
					}
					if ((uint)num4 - (uint)x555227b0d2a372bd >= 0U)
					{
						goto Block_1;
					}
					goto IL_2B9;
				case DockStyle.Bottom:
					goto IL_32;
				case DockStyle.Left:
					goto IL_1FD;
				case DockStyle.Right:
					this.xffa8345bf918658d = Math.Max(rectangle.Left + 20, startPoint.X - (num4 - x555227b0d2a372bd));
					if (((uint)x555227b0d2a372bd & 0U) != 0U)
					{
						continue;
					}
					goto IL_2D9;
				}
				goto Block_4;
				IL_23A:
				num4 = num3;
				if ((uint)num4 - (uint)num4 >= 0U)
				{
					x555227b0d2a372bd = container.x555227b0d2a372bd;
					goto IL_2D4;
				}
				goto IL_1D7;
				IL_234:
				num3 = manager.MaximumDockContainerSize;
				goto IL_23A;
				IL_2D4:
				goto IL_1D7;
				IL_2B9:
				num = 30;
				goto IL_275;
			}
			IL_32:
			this.xffa8345bf918658d = Math.Max(rectangle.Top + 20, startPoint.Y - (num4 - x555227b0d2a372bd));
			this.xb646339c3b9e735a = startPoint.Y + (x555227b0d2a372bd - num2);
			this.xf623ffb827affd4f = startPoint.Y - container.x0c42f19be578ccee.Y;
			IL_80:
			this.OnMouseMove(startPoint);
			return;
			Block_1:
			flag = ((uint)num2 > uint.MaxValue);
			if (!flag)
			{
				this.xb646339c3b9e735a = Math.Min(rectangle.Bottom - 20, startPoint.Y + (num4 - x555227b0d2a372bd));
				this.xf623ffb827affd4f = startPoint.Y - container.x0c42f19be578ccee.Y;
				goto IL_80;
			}
			return;
			Block_4:
			goto IL_80;
			IL_1FD:
			this.xffa8345bf918658d = startPoint.X - (x555227b0d2a372bd - num2);
			this.xb646339c3b9e735a = Math.Min(rectangle.Right - 20, startPoint.X + (num4 - x555227b0d2a372bd));
			this.xf623ffb827affd4f = startPoint.X - container.x0c42f19be578ccee.X;
			goto IL_80;
			IL_2D9:
			this.xb646339c3b9e735a = startPoint.X + (x555227b0d2a372bd - num2);
			this.xf623ffb827affd4f = startPoint.X - container.x0c42f19be578ccee.X;
			goto IL_80;
		}

		// Token: 0x06000515 RID: 1301 RVA: 0x00026F60 File Offset: 0x00025F60
		public override void OnMouseMove(Point position)
		{
			Rectangle empty = Rectangle.Empty;
			if (this.xd3311d815ca25f02.x61c108cc44ef385a)
			{
				goto IL_261;
			}
			empty = new Rectangle(0, position.Y - this.xf623ffb827affd4f, this.xd3311d815ca25f02.Width, 4);
			if (empty.Y >= this.xffa8345bf918658d)
			{
				goto IL_195;
			}
			empty.Y = this.xffa8345bf918658d;
			if (2 == 0)
			{
				goto IL_ED;
			}
			if (false)
			{
				goto IL_1B7;
			}
			goto IL_195;
			IL_7D:
			base.xe5e4149f382149cc(new Rectangle(this.xd3311d815ca25f02.PointToScreen(empty.Location), empty.Size), false);
			if (!false)
			{
				if (this.xd3311d815ca25f02.Dock != DockStyle.Left)
				{
					while (this.xd3311d815ca25f02.Dock != DockStyle.Right)
					{
						Cursor.Current = Cursors.HSplit;
						if (false)
						{
							if (2147483647 == 0)
							{
								break;
							}
						}
						else
						{
							if (8 == 0)
							{
								goto IL_236;
							}
							return;
						}
					}
				}
				Cursor.Current = Cursors.VSplit;
				return;
			}
			return;
			IL_ED:
			this.x0d4b3b88c5b24565 = this.xd3311d815ca25f02.ContentSize + (empty.X - this.xd3311d815ca25f02.x0c42f19be578ccee.X);
			goto IL_7D;
			IL_153:
			DockStyle dock = this.xd3311d815ca25f02.Dock;
			if (!false)
			{
				switch (dock)
				{
				case DockStyle.Top:
					this.x0d4b3b88c5b24565 = this.xd3311d815ca25f02.ContentSize + (empty.Y - this.xd3311d815ca25f02.x0c42f19be578ccee.Y);
					goto IL_7D;
				case DockStyle.Bottom:
					this.x0d4b3b88c5b24565 = this.xd3311d815ca25f02.ContentSize + (this.xd3311d815ca25f02.x0c42f19be578ccee.Y - empty.Y);
					goto IL_7D;
				case DockStyle.Left:
					goto IL_ED;
				case DockStyle.Right:
					this.x0d4b3b88c5b24565 = this.xd3311d815ca25f02.ContentSize + (this.xd3311d815ca25f02.x0c42f19be578ccee.X - empty.X);
					goto IL_7D;
				}
			}
			if (!false)
			{
				goto IL_7D;
			}
			return;
			IL_182:
			if (empty.X > this.xb646339c3b9e735a - 4)
			{
				empty.X = this.xb646339c3b9e735a - 4;
				goto IL_153;
			}
			if (!false)
			{
				goto IL_153;
			}
			IL_195:
			if (empty.Y <= this.xb646339c3b9e735a - 4)
			{
				goto IL_153;
			}
			IL_1B7:
			empty.Y = this.xb646339c3b9e735a - 4;
			if (false)
			{
				goto IL_182;
			}
			goto IL_153;
			IL_236:
			if (empty.X >= this.xffa8345bf918658d)
			{
				goto IL_182;
			}
			goto IL_286;
			IL_261:
			empty = new Rectangle(position.X - this.xf623ffb827affd4f, 0, 4, this.xd3311d815ca25f02.Height);
			if (!false)
			{
				goto IL_236;
			}
			IL_286:
			empty.X = this.xffa8345bf918658d;
			if (!false)
			{
				goto IL_182;
			}
			goto IL_261;
		}

		// Token: 0x06000516 RID: 1302 RVA: 0x00027208 File Offset: 0x00026208
		public override void Commit()
		{
			base.Commit();
			if (this.x67ecc0d0e7c9a202 != null)
			{
				this.x67ecc0d0e7c9a202(this.x0d4b3b88c5b24565);
			}
		}

		// Token: 0x040001F7 RID: 503
		private DockContainer xd3311d815ca25f02;

		// Token: 0x040001F8 RID: 504
		private int xffa8345bf918658d;

		// Token: 0x040001F9 RID: 505
		private int xb646339c3b9e735a;

		// Token: 0x040001FA RID: 506
		private int x0d4b3b88c5b24565;

		// Token: 0x040001FB RID: 507
		private int xf623ffb827affd4f;

		// Token: 0x02000059 RID: 89
		// (Invoke) Token: 0x06000518 RID: 1304
		public delegate void ResizingManagerFinishedEventHandler(int newSize);
	}
}
