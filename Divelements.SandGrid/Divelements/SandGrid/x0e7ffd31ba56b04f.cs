using System;
using System.Drawing;
using System.Windows.Forms;

namespace Divelements.SandGrid
{
	// Token: 0x02000076 RID: 118
	internal class x0e7ffd31ba56b04f : x59ac1f306ac0f29d
	{
		// Token: 0x0600062C RID: 1580 RVA: 0x000205E0 File Offset: 0x0001F5E0
		public x0e7ffd31ba56b04f(GridRow row, Point startPoint) : base(row, startPoint)
		{
			this.xa806b754814b9ae0 = row;
			this.x6afebf16b45c02e0 = startPoint;
			this.xa6f49ba8ce5ae3db(startPoint, false);
			Cursor.Current = Cursors.HSplit;
		}

		// Token: 0x0600062D RID: 1581 RVA: 0x0002060C File Offset: 0x0001F60C
		protected internal override void MouseMove(MouseEventArgs e)
		{
			this.xa6f49ba8ce5ae3db(new Point(e.X, e.Y), false);
		}

		// Token: 0x0600062E RID: 1582 RVA: 0x00020628 File Offset: 0x0001F628
		private void xa6f49ba8ce5ae3db(Point x13d4cb8d1bd20347, bool x4877b29f469432c2)
		{
			int num = x13d4cb8d1bd20347.Y - this.x6afebf16b45c02e0.Y;
			int num2 = 0;
			if (this.xa806b754814b9ae0.Height + num < 5)
			{
				num2 = 5 - this.xa806b754814b9ae0.Height - num;
			}
			num += num2;
			if (base.x03bb6a33fcd217b4.LiveResize || x4877b29f469432c2)
			{
				this.xa806b754814b9ae0.Height += num;
				this.x6afebf16b45c02e0 = new Point(x13d4cb8d1bd20347.X, x13d4cb8d1bd20347.Y + num2);
				return;
			}
			base.x03bb6a33fcd217b4.HorizontalMarkerPosition = x13d4cb8d1bd20347.Y + num2;
		}

		// Token: 0x0600062F RID: 1583 RVA: 0x000206C4 File Offset: 0x0001F6C4
		protected internal override void Finished(Point position, bool cancelled)
		{
			base.x03bb6a33fcd217b4.HorizontalMarkerPosition = -1;
			if (!cancelled)
			{
				this.xa6f49ba8ce5ae3db(position, true);
			}
		}

		// Token: 0x04000261 RID: 609
		private const int x5ce80d62a81ef263 = 5;

		// Token: 0x04000262 RID: 610
		private GridRow xa806b754814b9ae0;

		// Token: 0x04000263 RID: 611
		private Point x6afebf16b45c02e0;
	}
}
