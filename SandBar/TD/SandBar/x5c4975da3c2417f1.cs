using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace TD.SandBar
{
	// Token: 0x0200004C RID: 76
	internal class x5c4975da3c2417f1 : IDisposable
	{
		// Token: 0x060003C4 RID: 964 RVA: 0x000131E0 File Offset: 0x000121E0
		public x5c4975da3c2417f1(ToolBar toolbar, MouseEventArgs e)
		{
			this.x169279a87b6b72b2 = toolbar;
			if (toolbar.Parent is ToolBarContainer && ((ToolBarContainer)toolbar.Parent).Manager != null)
			{
				this.x91f347c6e97f1846 = ((ToolBarContainer)toolbar.Parent).Manager;
			}
			else if (toolbar.Parent is x502bf86f15e12152)
			{
				this.x91f347c6e97f1846 = ((x502bf86f15e12152)toolbar.Parent).x460ab163f44a604d;
			}
			this.x9820a8b63818d22d = new Point(e.X, e.Y);
		}

		// Token: 0x060003C5 RID: 965 RVA: 0x0001326C File Offset: 0x0001226C
		public void x1aaaf41037533886(MouseEventArgs xfbf34718e704c6bc)
		{
			Point position = Cursor.Position;
			this.x169279a87b6b72b2.Parent.Location = new Point(position.X - this.x9820a8b63818d22d.X, position.Y - this.x9820a8b63818d22d.Y);
			if ((Control.ModifierKeys & Keys.Control) != Keys.Control)
			{
				ToolBarContainer toolBarContainer = this.x50298394ddc9b0dd(position);
				if (toolBarContainer != null)
				{
					this.xa8f09dea364b03ef(toolBarContainer, Cursor.Position);
					this.x8ea26dc54e883a56 = true;
					this.x169279a87b6b72b2.Redock(toolBarContainer);
					this.x8ea26dc54e883a56 = false;
					this.x169279a87b6b72b2.Capture = true;
				}
			}
		}

		// Token: 0x060003C6 RID: 966 RVA: 0x0001330C File Offset: 0x0001230C
		public void x2c5d1da1234c3a6a(MouseEventArgs xfbf34718e704c6bc)
		{
			Point point = this.x169279a87b6b72b2.PointToScreen(new Point(xfbf34718e704c6bc.X, xfbf34718e704c6bc.Y));
			if (this.x91f347c6e97f1846 == null)
			{
				return;
			}
			Rectangle rectangle = new Rectangle(this.x169279a87b6b72b2.Parent.PointToScreen(new Point(0, 0)), this.x169279a87b6b72b2.Parent.ClientRectangle.Size);
			rectangle.Inflate(22, 22);
			bool flag = !rectangle.Contains(point);
			ToolBarContainer toolBarContainer = this.x50298394ddc9b0dd(point);
			if (flag)
			{
				if (toolBarContainer != null)
				{
					this.x8ea26dc54e883a56 = true;
					this.x169279a87b6b72b2.Redock(toolBarContainer);
					this.x8ea26dc54e883a56 = false;
					this.x169279a87b6b72b2.Capture = true;
					return;
				}
				if (this.x169279a87b6b72b2.Tearable)
				{
					this.x08c5b87a6057bc80();
					return;
				}
			}
			else
			{
				this.xa8f09dea364b03ef((ToolBarContainer)this.x169279a87b6b72b2.Parent, point);
			}
		}

		// Token: 0x060003C7 RID: 967 RVA: 0x000133F0 File Offset: 0x000123F0
		private void xa8f09dea364b03ef(ToolBarContainer xd3311d815ca25f02, Point x8a6d69cf001869f5)
		{
			Point pt = xd3311d815ca25f02.PointToClient(x8a6d69cf001869f5);
			Point point = this.x169279a87b6b72b2.PointToClient(x8a6d69cf001869f5);
			bool flag = xd3311d815ca25f02.Dock == DockStyle.Left || xd3311d815ca25f02.Dock == DockStyle.Right;
			if (!false)
			{
				int num = 0;
				if (flag)
				{
					this.x169279a87b6b72b2.DockOffset = pt.Y - this.x9820a8b63818d22d.Y;
				}
				else
				{
					this.x169279a87b6b72b2.DockOffset = pt.X - this.x9820a8b63818d22d.X;
				}
				int num2 = xd3311d815ca25f02.xe132de531f28d339(this.x169279a87b6b72b2.DockLine);
				if (num2 > 1)
				{
					if (flag)
					{
						if (point.X >= 0)
						{
							goto IL_3C4;
						}
						goto IL_3EA;
					}
					else
					{
						if (point.Y >= 0 && point.Y < 3)
						{
							num = -1;
							goto IL_3EA;
						}
						goto IL_3EA;
					}
				}
				IL_1B:
				num = 0;
				int num3;
				using (IEnumerator enumerator = xd3311d815ca25f02.Controls.GetEnumerator())
				{
					while (enumerator.MoveNext() || ((uint)num2 & 0U) != 0U)
					{
						ToolBar toolBar = (ToolBar)enumerator.Current;
						if (toolBar.Visible)
						{
							Rectangle rectangle;
							if (flag)
							{
								rectangle = new Rectangle(toolBar.Left, 0, toolBar.Width, xd3311d815ca25f02.ClientRectangle.Height);
								goto IL_1B4;
							}
							rectangle = new Rectangle(0, toolBar.Top, xd3311d815ca25f02.ClientRectangle.Width, toolBar.Height);
							if (((uint)num3 | 4294967295U) != 0U)
							{
								goto IL_1B4;
							}
							goto IL_30;
							IL_6C:
							if (flag)
							{
								if (pt.X >= toolBar.Left && pt.X <= toolBar.Left + 3)
								{
									num = 1;
								}
							}
							else if (pt.Y >= toolBar.Top && pt.Y <= toolBar.Top + 3)
							{
								num = 1;
							}
							if (num != 0)
							{
								int dockLine = toolBar.DockLine;
								xd3311d815ca25f02.xb43d2df1d97b51f4(toolBar.DockLine, 1);
								this.x169279a87b6b72b2.DockLine = dockLine;
								return;
							}
							if (!toolBar.Stretch && !this.x169279a87b6b72b2.Stretch)
							{
								this.x169279a87b6b72b2.DockLine = toolBar.DockLine;
								return;
							}
							continue;
							IL_33:
							if (num != 0)
							{
								num3 = this.x169279a87b6b72b2.DockLine + num;
								xd3311d815ca25f02.x0b8be6b766a66eec(this.x169279a87b6b72b2.DockLine, num);
								this.x169279a87b6b72b2.DockLine = num3;
								return;
							}
							goto IL_6C;
							IL_30:
							num = 1;
							goto IL_33;
							IL_1B4:
							if (rectangle.Contains(pt) && toolBar.DockLine != this.x169279a87b6b72b2.DockLine)
							{
								if (num2 <= 1)
								{
									goto IL_6C;
								}
								if (flag)
								{
									if (pt.X >= this.x169279a87b6b72b2.Bounds.Right && pt.X <= this.x169279a87b6b72b2.Bounds.Right + 3)
									{
										num = 1;
										goto IL_33;
									}
									goto IL_33;
								}
								else
								{
									if (pt.Y < this.x169279a87b6b72b2.Bounds.Bottom || pt.Y > this.x169279a87b6b72b2.Bounds.Bottom + 3)
									{
										goto IL_33;
									}
									if (2 == 0)
									{
										break;
									}
									goto IL_30;
								}
							}
						}
					}
				}
				switch (xd3311d815ca25f02.Dock)
				{
				case DockStyle.Top:
				case DockStyle.Bottom:
					if (pt.Y >= xd3311d815ca25f02.Height && pt.Y <= xd3311d815ca25f02.Height + 5)
					{
						num = 1;
					}
					break;
				case DockStyle.Left:
				case DockStyle.Right:
					if (pt.X >= xd3311d815ca25f02.Width)
					{
						if ((uint)num3 + (flag ? 1U : 0U) < 0U)
						{
							goto IL_3C4;
						}
						if (pt.X <= xd3311d815ca25f02.Width + 5)
						{
							num = 1;
						}
					}
					break;
				}
				if (num != 0 && (num2 > 1 || this.x169279a87b6b72b2.DockLine != xd3311d815ca25f02.GetNextFreeDockLine() - 1) && num == 1)
				{
					this.x169279a87b6b72b2.DockLine = xd3311d815ca25f02.GetNextFreeDockLine();
					return;
				}
				return;
				IL_3C4:
				if (point.X < 3)
				{
					num = -1;
				}
				IL_3EA:
				if (num != 0)
				{
					int dockLine2 = this.x169279a87b6b72b2.DockLine + num;
					xd3311d815ca25f02.x0b8be6b766a66eec(this.x169279a87b6b72b2.DockLine, num);
					this.x169279a87b6b72b2.DockLine = dockLine2;
					return;
				}
				goto IL_1B;
			}
		}

		// Token: 0x060003C8 RID: 968 RVA: 0x00013860 File Offset: 0x00012860
		private void x08c5b87a6057bc80()
		{
			Point point = this.x9820a8b63818d22d;
			this.x8ea26dc54e883a56 = true;
			this.x169279a87b6b72b2.Capture = false;
			this.x8ea26dc54e883a56 = false;
			this.x169279a87b6b72b2.x5d1aeeb0b6ebccac(this.x91f347c6e97f1846, Cursor.Position, true);
			Size size = this.x169279a87b6b72b2.xf99417bde67b156a();
			if (point.X > size.Width)
			{
				point.X = size.Width;
			}
			if (point.Y > size.Height)
			{
				point.Y = size.Height;
			}
			this.x169279a87b6b72b2.Parent.Location = new Point(Cursor.Position.X - point.X, Cursor.Position.Y - point.Y);
			((x502bf86f15e12152)this.x169279a87b6b72b2.Parent).x2c6f5ac62ee048e5();
			this.x9820a8b63818d22d = point;
			this.x9820a8b63818d22d.Y = this.x9820a8b63818d22d.Y + SystemInformation.FixedFrameBorderSize.Height;
			if (!(this.x169279a87b6b72b2 is ContainerBar))
			{
				this.x9820a8b63818d22d.Y = this.x9820a8b63818d22d.Y + SystemInformation.ToolWindowCaptionHeight;
			}
			this.x169279a87b6b72b2.Parent.Capture = true;
		}

		// Token: 0x170000FC RID: 252
		// (get) Token: 0x060003C9 RID: 969 RVA: 0x000139A0 File Offset: 0x000129A0
		public bool x57ba069a692cbf47
		{
			get
			{
				return this.x8ea26dc54e883a56;
			}
		}

		// Token: 0x060003CA RID: 970 RVA: 0x000139A8 File Offset: 0x000129A8
		private bool x0f6e043b4b3f1c8a(ToolBarContainer xd3311d815ca25f02, Point x8a6d69cf001869f5)
		{
			if (xd3311d815ca25f02 == null)
			{
				return false;
			}
			if (!xd3311d815ca25f02.Enabled)
			{
				return false;
			}
			Rectangle rectangle = new Rectangle(xd3311d815ca25f02.PointToScreen(new Point(0, 0)), xd3311d815ca25f02.ClientRectangle.Size);
			if (rectangle.Width == 0)
			{
				rectangle.Inflate(10, 0);
			}
			if (rectangle.Height == 0)
			{
				rectangle.Inflate(0, 10);
			}
			switch (xd3311d815ca25f02.Dock)
			{
			case DockStyle.Top:
			case DockStyle.Bottom:
				rectangle.Height += 5;
				break;
			case DockStyle.Left:
			case DockStyle.Right:
				rectangle.Width += 5;
				break;
			}
			return rectangle.Contains(x8a6d69cf001869f5);
		}

		// Token: 0x060003CB RID: 971 RVA: 0x00013A58 File Offset: 0x00012A58
		private ToolBarContainer x50298394ddc9b0dd(Point x8a6d69cf001869f5)
		{
			foreach (object obj in this.x91f347c6e97f1846.xd27fa35d10494112)
			{
				ToolBarContainer toolBarContainer = (ToolBarContainer)obj;
				bool flag = (toolBarContainer.Dock == DockStyle.Left || toolBarContainer.Dock == DockStyle.Right) ? this.x169279a87b6b72b2.AllowVerticalDock : this.x169279a87b6b72b2.AllowHorizontalDock;
				if (flag && this.x0f6e043b4b3f1c8a(toolBarContainer, x8a6d69cf001869f5))
				{
					return toolBarContainer;
				}
			}
			return null;
		}

		// Token: 0x060003CC RID: 972 RVA: 0x00013B00 File Offset: 0x00012B00
		public void Dispose()
		{
			this.x169279a87b6b72b2 = null;
		}

		// Token: 0x040001A7 RID: 423
		private const int xf045a70bb7755fa5 = 5;

		// Token: 0x040001A8 RID: 424
		private ToolBar x169279a87b6b72b2;

		// Token: 0x040001A9 RID: 425
		private SandBarManager x91f347c6e97f1846;

		// Token: 0x040001AA RID: 426
		private Point x9820a8b63818d22d;

		// Token: 0x040001AB RID: 427
		private bool x8ea26dc54e883a56;
	}
}
