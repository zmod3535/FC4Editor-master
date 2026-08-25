using System;
using System.Drawing;
using System.Windows.Forms;

namespace TD.SandDock
{
	// Token: 0x02000056 RID: 86
	internal class x8e80e1c8bce8caf7 : x890231ddf317379e
	{
		// Token: 0x1400001A RID: 26
		// (add) Token: 0x06000508 RID: 1288 RVA: 0x000267B0 File Offset: 0x000257B0
		// (remove) Token: 0x06000509 RID: 1289 RVA: 0x000267CC File Offset: 0x000257CC
		public event x8e80e1c8bce8caf7.SplittingManagerFinishedEventHandler x67ecc0d0e7c9a202;

		// Token: 0x0600050A RID: 1290 RVA: 0x000267E8 File Offset: 0x000257E8
		public x8e80e1c8bce8caf7(DockContainer container, SplitLayoutSystem splitLayout, LayoutSystemBase aboveLayout, LayoutSystemBase belowLayout, Point startPoint, DockingHints dockingHints) : base(container, dockingHints, false)
		{
			for (;;)
			{
				IL_122:
				this.xd3311d815ca25f02 = container;
				this.xd0bab8a0f8013a7b = splitLayout;
				while (!false)
				{
					this.xc13a8191724b6d55 = aboveLayout;
					this.x5aa50bbadb0a1e6c = belowLayout;
					this.xcb09bd0cee4909a3 = startPoint;
					if (splitLayout.SplitMode == Orientation.Horizontal)
					{
						goto IL_A9;
					}
					this.xffa8345bf918658d = aboveLayout.Bounds.X + 25;
					this.xb646339c3b9e735a = belowLayout.Bounds.Right - 25;
					this.x3fb8b43b602e016f = aboveLayout.WorkingSize.Width + belowLayout.WorkingSize.Width;
					if (4 == 0)
					{
						if (false)
						{
							goto IL_A9;
						}
						continue;
					}
					else
					{
						if (false)
						{
							break;
						}
						if (false)
						{
							goto IL_C0;
						}
					}
					IL_20:
					this.OnMouseMove(startPoint);
					if (!false)
					{
						break;
					}
					if (255 == 0)
					{
						continue;
					}
					goto IL_122;
					IL_C0:
					this.xb646339c3b9e735a = belowLayout.Bounds.Bottom - 25;
					this.x3fb8b43b602e016f = aboveLayout.WorkingSize.Height + belowLayout.WorkingSize.Height;
					goto IL_20;
					IL_A9:
					this.xffa8345bf918658d = aboveLayout.Bounds.Y + 25;
					goto IL_C0;
				}
				break;
			}
		}

		// Token: 0x17000147 RID: 327
		// (get) Token: 0x0600050B RID: 1291 RVA: 0x00026930 File Offset: 0x00025930
		public SplitLayoutSystem x07bf3386da210f81
		{
			get
			{
				return this.xd0bab8a0f8013a7b;
			}
		}

		// Token: 0x0600050C RID: 1292 RVA: 0x00026938 File Offset: 0x00025938
		public override void Commit()
		{
			base.Commit();
			if (this.x67ecc0d0e7c9a202 != null)
			{
				this.x67ecc0d0e7c9a202(this.xc13a8191724b6d55, this.x5aa50bbadb0a1e6c, this.x5c2440c931f8d932, this.x4afa341b2323a009);
			}
		}

		// Token: 0x0600050D RID: 1293 RVA: 0x00026970 File Offset: 0x00025970
		public override void OnMouseMove(Point position)
		{
			Rectangle empty = Rectangle.Empty;
			float num2;
			while (this.xd0bab8a0f8013a7b.SplitMode == Orientation.Horizontal)
			{
				empty = new Rectangle(this.xd0bab8a0f8013a7b.Bounds.X, position.Y - 2, this.xd0bab8a0f8013a7b.Bounds.Width, 4);
				float num;
				bool flag = (uint)num + (uint)num2 < 0U;
				if (!flag)
				{
					empty.Y = Math.Max(empty.Y, this.xffa8345bf918658d);
					empty.Y = Math.Min(empty.Y, this.xb646339c3b9e735a - 4);
					num = (float)(this.x5aa50bbadb0a1e6c.Bounds.Bottom - this.xc13a8191724b6d55.Bounds.Top - 4);
					this.x5c2440c931f8d932 = (float)(empty.Y - this.xc13a8191724b6d55.Bounds.Top) / num * this.x3fb8b43b602e016f;
					this.x4afa341b2323a009 = this.x3fb8b43b602e016f - this.x5c2440c931f8d932;
					if (((uint)num2 | 4294967295U) == 0U)
					{
						IL_90:
						Rectangle bounds;
						num2 = (float)(bounds.Right - this.xc13a8191724b6d55.Bounds.Left - 4);
						this.x5c2440c931f8d932 = (float)(empty.X - this.xc13a8191724b6d55.Bounds.Left) / num2 * this.x3fb8b43b602e016f;
						if ((uint)num2 - (uint)num > 4294967295U)
						{
							IL_151:
							empty = new Rectangle(position.X - 2, this.xd0bab8a0f8013a7b.Bounds.Y, 4, this.xd0bab8a0f8013a7b.Bounds.Height);
							empty.X = Math.Max(empty.X, this.xffa8345bf918658d);
							empty.X = Math.Min(empty.X, this.xb646339c3b9e735a - 4);
							bounds = this.x5aa50bbadb0a1e6c.Bounds;
							goto IL_90;
						}
						this.x4afa341b2323a009 = this.x3fb8b43b602e016f - this.x5c2440c931f8d932;
						if (2 == 0)
						{
							return;
						}
					}
					base.xe5e4149f382149cc(new Rectangle(this.xd3311d815ca25f02.PointToScreen(empty.Location), empty.Size), false);
					Cursor.Current = ((this.xd0bab8a0f8013a7b.SplitMode != Orientation.Horizontal) ? Cursors.VSplit : Cursors.HSplit);
					return;
				}
			}
			if ((uint)num2 + (uint)num2 >= 0U)
			{
				goto IL_151;
			}
			goto IL_151;
		}

		// Token: 0x040001EB RID: 491
		internal const int x7ae613ae2690dbe6 = 25;

		// Token: 0x040001EC RID: 492
		private DockContainer xd3311d815ca25f02;

		// Token: 0x040001ED RID: 493
		private SplitLayoutSystem xd0bab8a0f8013a7b;

		// Token: 0x040001EE RID: 494
		private LayoutSystemBase xc13a8191724b6d55;

		// Token: 0x040001EF RID: 495
		private LayoutSystemBase x5aa50bbadb0a1e6c;

		// Token: 0x040001F0 RID: 496
		private Point xcb09bd0cee4909a3 = Point.Empty;

		// Token: 0x040001F1 RID: 497
		private int xffa8345bf918658d;

		// Token: 0x040001F2 RID: 498
		private int xb646339c3b9e735a;

		// Token: 0x040001F3 RID: 499
		private float x5c2440c931f8d932;

		// Token: 0x040001F4 RID: 500
		private float x4afa341b2323a009;

		// Token: 0x040001F5 RID: 501
		private float x3fb8b43b602e016f;

		// Token: 0x02000057 RID: 87
		// (Invoke) Token: 0x0600050F RID: 1295
		public delegate void SplittingManagerFinishedEventHandler(LayoutSystemBase aboveLayout, LayoutSystemBase belowLayout, float aboveSize, float belowSize);
	}
}
