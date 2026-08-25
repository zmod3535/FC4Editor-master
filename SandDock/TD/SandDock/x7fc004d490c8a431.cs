using System;
using System.Drawing;
using System.Windows.Forms;

namespace TD.SandDock
{
	// Token: 0x02000033 RID: 51
	internal class x7fc004d490c8a431 : x890231ddf317379e
	{
		// Token: 0x14000019 RID: 25
		// (add) Token: 0x06000438 RID: 1080 RVA: 0x00021DDC File Offset: 0x00020DDC
		// (remove) Token: 0x06000439 RID: 1081 RVA: 0x00021DF8 File Offset: 0x00020DF8
		public event x7fc004d490c8a431.ResizingManagerFinishedEventHandler x67ecc0d0e7c9a202;

		// Token: 0x0600043A RID: 1082 RVA: 0x00021E14 File Offset: 0x00020E14
		public x7fc004d490c8a431(x10ac79a4257c7f52 bar, x87cf4de36131799d popupContainer, Point startPoint) : base(bar, (bar.x460ab163f44a604d != null) ? bar.x460ab163f44a604d.DockingHints : DockingHints.TranslucentFill, false)
		{
			int num;
			bool flag = (uint)num < 0U;
			if (!flag)
			{
				this.x2ee8392f53a01b93 = bar;
				goto IL_3C0;
			}
			IL_3B1:
			int num4;
			for (;;)
			{
				IL_3A7:
				if (bar.x460ab163f44a604d != null)
				{
					goto IL_366;
				}
				int num2 = 30;
				IL_371:
				num = num2;
				int num3;
				if (bar.x460ab163f44a604d != null)
				{
					num3 = bar.x460ab163f44a604d.MaximumDockContainerSize;
					goto IL_3A1;
				}
				if ((uint)num >= 0U)
				{
					num3 = 500;
					goto IL_3A1;
				}
				IL_131:
				while (bar.x460ab163f44a604d.DockSystemContainer == null)
				{
					if (!false)
					{
						goto IL_1D9;
					}
				}
				IL_163:
				num4 = Math.Max(bar.x460ab163f44a604d.DockSystemContainer.Height - popupContainer.Bounds.Top - num, num);
				if ((uint)num < 0U)
				{
					goto IL_8F;
				}
				if ((uint)num - (uint)num4 < 0U)
				{
					goto IL_2FD;
				}
				if (!false)
				{
					while (!false)
					{
						if (15 != 0)
						{
							goto IL_E3;
						}
						if ((uint)num + (uint)num >= 0U)
						{
							if (!false)
							{
								goto IL_366;
							}
							goto IL_3A7;
						}
					}
				}
				IL_143:
				if (bar.x460ab163f44a604d == null)
				{
					goto IL_1C7;
				}
				flag = ((uint)num + (uint)num4 < 0U);
				if (flag)
				{
					goto IL_163;
				}
				goto IL_131;
				IL_2FD:
				this.xe7e5c1179f5c7ae1 = popupContainer.xca843b3e9a1c605f;
				if ((uint)num + (uint)num <= 4294967295U)
				{
					switch (bar.Dock)
					{
					case DockStyle.Top:
						goto IL_143;
					case DockStyle.Bottom:
						goto IL_85;
					case DockStyle.Left:
						goto IL_2CC;
					case DockStyle.Right:
						goto IL_1E7;
					}
					goto Block_16;
				}
				goto IL_143;
				IL_3A1:
				num4 = num3;
				goto IL_2FD;
				IL_366:
				num2 = bar.x460ab163f44a604d.MinimumDockContainerSize;
				goto IL_371;
			}
			IL_50:
			this.xffa8345bf918658d = startPoint.Y - (num4 - this.xe7e5c1179f5c7ae1);
			this.xb646339c3b9e735a = startPoint.Y + (this.xe7e5c1179f5c7ae1 - num);
			IL_7C:
			this.OnMouseMove(startPoint);
			return;
			IL_85:
			if (bar.x460ab163f44a604d == null)
			{
				goto IL_50;
			}
			if (bar.x460ab163f44a604d.DockSystemContainer == null)
			{
				flag = ((uint)num4 + (uint)num < 0U);
				if (flag)
				{
					return;
				}
				if ((uint)num4 - (uint)num <= 4294967295U)
				{
					goto IL_50;
				}
			}
			IL_8F:
			num4 = Math.Max(popupContainer.Bounds.Bottom - num, num);
			goto IL_50;
			IL_E3:
			if ((uint)num4 + (uint)num < 0U)
			{
				goto IL_3C0;
			}
			IL_FE:
			this.xffa8345bf918658d = startPoint.Y - (this.xe7e5c1179f5c7ae1 - num);
			this.xb646339c3b9e735a = startPoint.Y + (num4 - this.xe7e5c1179f5c7ae1);
			goto IL_7C;
			IL_1C7:
			IL_1D9:
			goto IL_FE;
			IL_1E7:
			if (bar.x460ab163f44a604d != null && bar.x460ab163f44a604d.DockSystemContainer != null)
			{
				num4 = Math.Max(popupContainer.Bounds.Right - num, num);
			}
			IL_1EF:
			this.xffa8345bf918658d = startPoint.X - (num4 - this.xe7e5c1179f5c7ae1);
			this.xb646339c3b9e735a = startPoint.X + (this.xe7e5c1179f5c7ae1 - num);
			goto IL_7C;
			IL_290:
			goto IL_1EF;
			IL_2CC:
			if (bar.x460ab163f44a604d == null)
			{
				if ((uint)num > 4294967295U)
				{
					goto IL_E3;
				}
			}
			else if (bar.x460ab163f44a604d.DockSystemContainer != null)
			{
				num4 = Math.Max(bar.x460ab163f44a604d.DockSystemContainer.Width - popupContainer.Bounds.Left - num, num);
			}
			this.xffa8345bf918658d = startPoint.X - (this.xe7e5c1179f5c7ae1 - num);
			this.xb646339c3b9e735a = startPoint.X + (num4 - this.xe7e5c1179f5c7ae1);
			flag = ((uint)num4 + (uint)num < 0U);
			if (flag)
			{
				goto IL_290;
			}
			Block_16:
			goto IL_7C;
			IL_3C0:
			this.x5fea292ffeb2c28c = popupContainer;
			this.xcb09bd0cee4909a3 = startPoint;
			goto IL_3B1;
		}

		// Token: 0x0600043B RID: 1083 RVA: 0x000221F4 File Offset: 0x000211F4
		public override void OnMouseMove(Point position)
		{
			Rectangle empty = Rectangle.Empty;
			for (;;)
			{
				if (false)
				{
					if (2 == 0)
					{
						goto IL_11D;
					}
					if (!false)
					{
						goto IL_1BC;
					}
					continue;
				}
				else
				{
					if (this.x2ee8392f53a01b93.x61c108cc44ef385a)
					{
						goto IL_1BC;
					}
					if (false)
					{
						goto IL_2D;
					}
					if (position.Y < this.xffa8345bf918658d)
					{
						if (-1 == 0)
						{
							goto IL_C2;
						}
						position.Y = this.xffa8345bf918658d;
					}
					if (position.Y <= this.xb646339c3b9e735a)
					{
						if (false)
						{
							goto IL_1F7;
						}
						goto IL_99;
					}
					else
					{
						position.Y = this.xb646339c3b9e735a;
						if (!false)
						{
							if (3 == 0)
							{
								goto IL_17D;
							}
							goto IL_11D;
						}
					}
				}
				IL_4D:
				base.xe5e4149f382149cc(new Rectangle(this.x5fea292ffeb2c28c.PointToScreen(empty.Location), empty.Size), false);
				if (3 != 0)
				{
					break;
				}
				if (3 == 0)
				{
					goto IL_1F7;
				}
				continue;
				IL_2B:
				goto IL_4D;
				IL_C2:
				DockStyle dock;
				switch (dock)
				{
				case DockStyle.Top:
					this.x0d4b3b88c5b24565 = this.xe7e5c1179f5c7ae1 + (position.Y - this.xcb09bd0cee4909a3.Y);
					goto IL_2B;
				case DockStyle.Bottom:
					IL_2D:
					this.x0d4b3b88c5b24565 = this.xe7e5c1179f5c7ae1 + (this.xcb09bd0cee4909a3.Y - position.Y);
					goto IL_4D;
				case DockStyle.Left:
					this.x0d4b3b88c5b24565 = this.xe7e5c1179f5c7ae1 + (position.X - this.xcb09bd0cee4909a3.X);
					goto IL_4D;
				case DockStyle.Right:
					this.x0d4b3b88c5b24565 = this.xe7e5c1179f5c7ae1 + (this.xcb09bd0cee4909a3.X - position.X);
					goto IL_4D;
				default:
					goto IL_4D;
				}
				IL_B6:
				dock = this.x2ee8392f53a01b93.Dock;
				goto IL_C2;
				IL_99:
				empty = new Rectangle(0, position.Y - 2, this.x5fea292ffeb2c28c.Width, 4);
				goto IL_B6;
				IL_11D:
				goto IL_99;
				IL_17D:
				goto IL_B6;
				IL_198:
				empty = new Rectangle(position.X - 2, 0, 4, this.x5fea292ffeb2c28c.Height);
				goto IL_17D;
				IL_1E1:
				if (position.X > this.xb646339c3b9e735a)
				{
					goto IL_1D2;
				}
				if (-2147483648 != 0)
				{
					goto IL_198;
				}
				IL_1F7:
				position.X = this.xffa8345bf918658d;
				goto IL_1E1;
				IL_1BC:
				if (position.X < this.xffa8345bf918658d)
				{
					goto IL_1F7;
				}
				if (-1 != 0)
				{
					goto IL_1E1;
				}
				IL_1D2:
				position.X = this.xb646339c3b9e735a;
				goto IL_198;
			}
		}

		// Token: 0x0600043C RID: 1084 RVA: 0x0002242C File Offset: 0x0002142C
		public override void Commit()
		{
			base.Commit();
			if (this.x67ecc0d0e7c9a202 != null)
			{
				this.x67ecc0d0e7c9a202(this.x0d4b3b88c5b24565);
			}
		}

		// Token: 0x04000161 RID: 353
		private x10ac79a4257c7f52 x2ee8392f53a01b93;

		// Token: 0x04000162 RID: 354
		private x87cf4de36131799d x5fea292ffeb2c28c;

		// Token: 0x04000163 RID: 355
		private Point xcb09bd0cee4909a3;

		// Token: 0x04000164 RID: 356
		private int xe7e5c1179f5c7ae1;

		// Token: 0x04000165 RID: 357
		private int xffa8345bf918658d;

		// Token: 0x04000166 RID: 358
		private int xb646339c3b9e735a;

		// Token: 0x04000167 RID: 359
		private int x0d4b3b88c5b24565;

		// Token: 0x02000034 RID: 52
		// (Invoke) Token: 0x0600043E RID: 1086
		public delegate void ResizingManagerFinishedEventHandler(int newSize);
	}
}
