using System;
using System.Drawing;
using System.Windows.Forms;

namespace TD.SandBar
{
	// Token: 0x0200006F RID: 111
	internal class xb5e3ab8b746d6d67
	{
		// Token: 0x06000565 RID: 1381 RVA: 0x0001D8A0 File Offset: 0x0001C8A0
		public xb5e3ab8b746d6d67(ContainerBar containerBar, Point startPosition)
		{
			this.x4cf50b9182f67386 = containerBar;
			this.xcb09bd0cee4909a3 = startPosition;
		}

		// Token: 0x06000566 RID: 1382 RVA: 0x0001D8C4 File Offset: 0x0001C8C4
		public void x2c5d1da1234c3a6a(Point x13d4cb8d1bd20347)
		{
			this.x670868e728a31760(x13d4cb8d1bd20347);
		}

		// Token: 0x06000567 RID: 1383 RVA: 0x0001D8D0 File Offset: 0x0001C8D0
		private void x670868e728a31760(Point x13d4cb8d1bd20347)
		{
			int num = 0;
			int num2;
			bool flag = (uint)num2 > uint.MaxValue;
			int num3;
			Size minimumSize;
			if (flag)
			{
				if (8 != 0)
				{
					goto IL_197;
				}
				flag = ((uint)num < 0U);
				if (!flag)
				{
					goto IL_DA;
				}
			}
			else
			{
				num2 = 0;
				num3 = 0;
				switch (this.x4cf50b9182f67386.Parent.Dock)
				{
				case DockStyle.Top:
					goto IL_DA;
				case DockStyle.Bottom:
					num = this.x4cf50b9182f67386.MinimumSize.Height + (this.xcb09bd0cee4909a3.Y - x13d4cb8d1bd20347.Y);
					num2 = this.x4cf50b9182f67386.MinimumFloatingSize.Height;
					num3 = this.x4cf50b9182f67386.MaximumFloatingSize.Height;
					goto IL_189;
				case DockStyle.Left:
					num = this.x4cf50b9182f67386.MinimumSize.Width + (x13d4cb8d1bd20347.X - this.xcb09bd0cee4909a3.X);
					num2 = this.x4cf50b9182f67386.MinimumFloatingSize.Width;
					num3 = this.x4cf50b9182f67386.MaximumFloatingSize.Width;
					this.xcb09bd0cee4909a3 = x13d4cb8d1bd20347;
					goto IL_189;
				case DockStyle.Right:
					minimumSize = this.x4cf50b9182f67386.MinimumSize;
					goto IL_197;
				default:
					flag = (((uint)num2 & 0U) == 0U);
					if (flag)
					{
						goto IL_189;
					}
					goto IL_1C8;
				}
			}
			IL_36:
			if (num2 > 0)
			{
				num = num2;
			}
			IL_3C:
			if (num > num3 && num3 > 0)
			{
				num = num3;
			}
			if (this.x4cf50b9182f67386.Parent.Dock == DockStyle.Left || this.x4cf50b9182f67386.Parent.Dock == DockStyle.Right)
			{
				this.x4cf50b9182f67386.MinimumSize = new Size(num, this.x4cf50b9182f67386.MinimumSize.Height);
			}
			else
			{
				this.x4cf50b9182f67386.MinimumSize = new Size(this.x4cf50b9182f67386.MinimumSize.Width, num);
			}
			this.x4cf50b9182f67386.Refresh();
			if (((uint)num & 0U) == 0U)
			{
				return;
			}
			IL_DA:
			num = this.x4cf50b9182f67386.MinimumSize.Height + (x13d4cb8d1bd20347.Y - this.xcb09bd0cee4909a3.Y);
			num2 = this.x4cf50b9182f67386.MinimumFloatingSize.Height;
			num3 = this.x4cf50b9182f67386.MaximumFloatingSize.Height;
			this.xcb09bd0cee4909a3 = x13d4cb8d1bd20347;
			IL_189:
			if (num < num2)
			{
				goto IL_36;
			}
			goto IL_3C;
			IL_197:
			num = minimumSize.Width + (this.xcb09bd0cee4909a3.X - x13d4cb8d1bd20347.X);
			num2 = this.x4cf50b9182f67386.MinimumFloatingSize.Width;
			IL_1C8:
			num3 = this.x4cf50b9182f67386.MaximumFloatingSize.Width;
			goto IL_189;
		}

		// Token: 0x0400023A RID: 570
		private ContainerBar x4cf50b9182f67386;

		// Token: 0x0400023B RID: 571
		private Point xcb09bd0cee4909a3 = Point.Empty;
	}
}
