using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using TD.SandDock.Rendering;

namespace TD.SandDock
{
	// Token: 0x02000011 RID: 17
	public abstract class LayoutSystemBase
	{
		// Token: 0x060001FA RID: 506 RVA: 0x00012788 File Offset: 0x00011788
		internal void xe9a159cd1e028df2(SandDockManager x91f347c6e97f1846, DockContainer xd3311d815ca25f02, LayoutSystemBase x6e150040c8d97700, DockControl x43bec302f92080b9, int x9562cf1322eeedf1, Point x6afebf16b45c02e0, DockingHints x48cee1d69929b4fe, DockingManager xab4835b6b3620991)
		{
			if (xab4835b6b3620991 == DockingManager.Whidbey)
			{
				goto IL_7A;
			}
			IL_07:
			this.x531514c39973cbc6 = new xedb4922162c60d3d(x91f347c6e97f1846, this.DockContainer, this, x43bec302f92080b9, x9562cf1322eeedf1, x6afebf16b45c02e0, x48cee1d69929b4fe);
			IL_22:
			this.x531514c39973cbc6.x67ecc0d0e7c9a202 += this.x46ff430ed3944e0f;
			this.x531514c39973cbc6.x868a32060451dd2e += this.x0ae87c4881d90427;
			IL_52:
			this.x531514c39973cbc6.OnMouseMove(Cursor.Position);
			bool flag = (uint)x9562cf1322eeedf1 - (uint)x9562cf1322eeedf1 < 0U;
			if (!flag)
			{
				return;
			}
			IL_7A:
			flag = ((uint)x9562cf1322eeedf1 > uint.MaxValue);
			if (flag || x890231ddf317379e.xca8cda6e489f8dd8())
			{
				this.x531514c39973cbc6 = new x31248f32f85df1dd(x91f347c6e97f1846, this.DockContainer, this, x43bec302f92080b9, x9562cf1322eeedf1, x6afebf16b45c02e0, x48cee1d69929b4fe);
				goto IL_22;
			}
			if (!false)
			{
				goto IL_07;
			}
			goto IL_52;
		}

		// Token: 0x060001FB RID: 507 RVA: 0x00012850 File Offset: 0x00011850
		private void xf6aefb7d0abb95ba()
		{
			this.x531514c39973cbc6.x67ecc0d0e7c9a202 -= this.x46ff430ed3944e0f;
			this.x531514c39973cbc6.x868a32060451dd2e -= this.x0ae87c4881d90427;
			this.x531514c39973cbc6 = null;
		}

		// Token: 0x060001FC RID: 508 RVA: 0x0001288C File Offset: 0x0001188C
		internal virtual void x46ff430ed3944e0f(xedb4922162c60d3d.DockTarget x11d58b056c032b03)
		{
			this.xf6aefb7d0abb95ba();
		}

		// Token: 0x060001FD RID: 509 RVA: 0x00012894 File Offset: 0x00011894
		internal virtual void x0ae87c4881d90427(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			this.xf6aefb7d0abb95ba();
		}

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x060001FE RID: 510
		internal abstract bool x56005f23d6948487 { get; }

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x060001FF RID: 511 RVA: 0x0001289C File Offset: 0x0001189C
		// (set) Token: 0x06000200 RID: 512 RVA: 0x000128A4 File Offset: 0x000118A4
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public SizeF WorkingSize
		{
			get
			{
				return this.x0e30cd10f9fd6d77;
			}
			set
			{
				if (value.Width > 0f && value.Height > 0f)
				{
					this.x0e30cd10f9fd6d77 = value;
					return;
				}
				throw new ArgumentException("value");
			}
		}

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x06000201 RID: 513 RVA: 0x000128F8 File Offset: 0x000118F8
		public DockContainer DockContainer
		{
			get
			{
				return this.x0467b00af7810f0c;
			}
		}

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x06000202 RID: 514 RVA: 0x00012900 File Offset: 0x00011900
		public bool IsInContainer
		{
			get
			{
				return this.x0467b00af7810f0c != null;
			}
		}

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x06000203 RID: 515 RVA: 0x00012910 File Offset: 0x00011910
		public SplitLayoutSystem Parent
		{
			get
			{
				return this.xb6a159a84cb992d6;
			}
		}

		// Token: 0x06000204 RID: 516 RVA: 0x00012918 File Offset: 0x00011918
		internal virtual void x56e964269d48cfcc(DockContainer x0467b00af7810f0c)
		{
			this.x0467b00af7810f0c = x0467b00af7810f0c;
		}

		// Token: 0x06000205 RID: 517 RVA: 0x00012924 File Offset: 0x00011924
		internal LayoutSystemBase()
		{
		}

		// Token: 0x06000206 RID: 518 RVA: 0x0001294C File Offset: 0x0001194C
		protected internal virtual void OnDragOver(DragEventArgs drgevent)
		{
		}

		// Token: 0x06000207 RID: 519 RVA: 0x00012950 File Offset: 0x00011950
		protected internal virtual void OnMouseMove(MouseEventArgs e)
		{
		}

		// Token: 0x06000208 RID: 520 RVA: 0x00012954 File Offset: 0x00011954
		protected internal virtual void OnMouseLeave()
		{
		}

		// Token: 0x06000209 RID: 521 RVA: 0x00012958 File Offset: 0x00011958
		protected internal virtual void OnMouseDoubleClick()
		{
		}

		// Token: 0x0600020A RID: 522 RVA: 0x0001295C File Offset: 0x0001195C
		protected internal virtual void OnMouseDown(MouseEventArgs e)
		{
		}

		// Token: 0x0600020B RID: 523 RVA: 0x00012960 File Offset: 0x00011960
		protected internal virtual void OnMouseUp(MouseEventArgs e)
		{
		}

		// Token: 0x0600020C RID: 524 RVA: 0x00012964 File Offset: 0x00011964
		protected internal virtual void Layout(RendererBase renderer, Graphics graphics, Rectangle bounds, bool floating)
		{
			this.xda73fcb97c77d998 = bounds;
		}

		// Token: 0x0600020D RID: 525 RVA: 0x00012970 File Offset: 0x00011970
		internal void x810df8ef88cf4bf2(SandDockManager x91f347c6e97f1846, ContainerDockLocation x9c911703d455884e, ContainerDockEdge x3e4dcab61996c9ea)
		{
			DockControl[] x9476096be9672d = this.x9476096be9672d38;
			DockContainer dockContainer;
			ControlLayoutSystem controlLayoutSystem;
			for (;;)
			{
				int num = 0;
				for (;;)
				{
					if (x9476096be9672d.Length > 0)
					{
						num = x9476096be9672d[0].MetaData.DockedContentSize;
						goto IL_139;
					}
					bool flag = (uint)num < 0U;
					if (flag)
					{
						goto IL_1A6;
					}
					goto IL_139;
					IL_B9:
					if (!(this is ControlLayoutSystem))
					{
						if (this.Parent != null)
						{
							this.Parent.LayoutSystems.Remove(this);
						}
					}
					else
					{
						LayoutUtilities.x4487f2f8917e3fd0((ControlLayoutSystem)this);
					}
					IL_74:
					dockContainer = x91f347c6e97f1846.CreateNewDockContainer(x9c911703d455884e, x3e4dcab61996c9ea, num);
					if (!false && !(dockContainer is DocumentContainer))
					{
						goto Block_3;
					}
					controlLayoutSystem = dockContainer.CreateNewLayoutSystem(this.WorkingSize);
					dockContainer.LayoutSystem.LayoutSystems.Add(controlLayoutSystem);
					if (this is SplitLayoutSystem)
					{
						goto Block_4;
					}
					controlLayoutSystem.Controls.AddRange(this.x9476096be9672d38);
					if (false)
					{
						break;
					}
					if ((uint)num + (uint)num > 4294967295U)
					{
						continue;
					}
					if ((uint)num >= 0U)
					{
						return;
					}
					goto IL_74;
					IL_10B:
					Rectangle rectangle;
					num = Math.Min(num, Convert.ToInt32((double)rectangle.Height * 0.9));
					goto IL_B9;
					IL_139:
					rectangle = xedb4922162c60d3d.x41c62f474d3fb367(x91f347c6e97f1846.DockSystemContainer);
					if (x9c911703d455884e != ContainerDockLocation.Left)
					{
						if (x9c911703d455884e == ContainerDockLocation.Right)
						{
							if (3 != 0)
							{
							}
						}
						else
						{
							if (x9c911703d455884e != ContainerDockLocation.Top && x9c911703d455884e != ContainerDockLocation.Bottom)
							{
								goto IL_B9;
							}
							goto IL_10B;
						}
					}
					num = Math.Min(num, Convert.ToInt32((double)rectangle.Width * 0.9));
					if (255 != 0)
					{
						goto IL_B9;
					}
					IL_1A6:
					goto IL_10B;
				}
			}
			return;
			Block_3:
			dockContainer.LayoutSystem.LayoutSystems.Add(this);
			return;
			Block_4:
			((SplitLayoutSystem)this).MoveToLayoutSystem(controlLayoutSystem);
		}

		// Token: 0x0600020E RID: 526 RVA: 0x00012B34 File Offset: 0x00011B34
		private void x298b2fdefeb76ab8()
		{
			if (this.x460ab163f44a604d == null)
			{
				throw new InvalidOperationException("No SandDockManager is associated with this ControlLayoutSystem.");
			}
		}

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x0600020F RID: 527 RVA: 0x00012B4C File Offset: 0x00011B4C
		private SandDockManager x460ab163f44a604d
		{
			get
			{
				if (this.DockContainer != null)
				{
					return this.DockContainer.Manager;
				}
				return null;
			}
		}

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x06000210 RID: 528 RVA: 0x00012B64 File Offset: 0x00011B64
		public Rectangle Bounds
		{
			get
			{
				return this.xda73fcb97c77d998;
			}
		}

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x06000211 RID: 529
		internal abstract DockControl[] x9476096be9672d38 { get; }

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x06000212 RID: 530
		internal abstract bool x74e31f9641656e0b { get; }

		// Token: 0x06000213 RID: 531
		internal abstract bool xe302f2203dc14a18(ContainerDockLocation xb9c2cfae130d9256);

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x06000214 RID: 532
		internal abstract bool x2f61709eaa5ebf76 { get; }

		// Token: 0x06000215 RID: 533
		internal abstract void x84b6f3c22477dacb(RendererBase x38870620fd380a6b, Graphics x41347a961b838962, Font x26094932cf7a9139);

		// Token: 0x04000094 RID: 148
		internal const int x35828a68467e5465 = 250;

		// Token: 0x04000095 RID: 149
		internal const int x87970cf44a2c6ba8 = 400;

		// Token: 0x04000096 RID: 150
		internal SplitLayoutSystem xb6a159a84cb992d6;

		// Token: 0x04000097 RID: 151
		private DockContainer x0467b00af7810f0c;

		// Token: 0x04000098 RID: 152
		private Rectangle xda73fcb97c77d998 = Rectangle.Empty;

		// Token: 0x04000099 RID: 153
		private SizeF x0e30cd10f9fd6d77 = new SizeF(250f, 400f);

		// Token: 0x0400009A RID: 154
		internal xedb4922162c60d3d x531514c39973cbc6;
	}
}
