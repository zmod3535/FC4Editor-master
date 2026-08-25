using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace TD.SandDock
{
	// Token: 0x02000016 RID: 22
	internal class xedb4922162c60d3d : x890231ddf317379e
	{
		// Token: 0x14000016 RID: 22
		// (add) Token: 0x060002AA RID: 682 RVA: 0x00017DD4 File Offset: 0x00016DD4
		// (remove) Token: 0x060002AB RID: 683 RVA: 0x00017DF0 File Offset: 0x00016DF0
		public event xedb4922162c60d3d.DockingManagerFinishedEventHandler x67ecc0d0e7c9a202;

		// Token: 0x060002AC RID: 684 RVA: 0x00017E0C File Offset: 0x00016E0C
		public xedb4922162c60d3d(SandDockManager manager, DockContainer container, LayoutSystemBase sourceControlSystem, DockControl sourceControl, int dockedSize, Point startPoint, DockingHints dockingHints) : base(container, dockingHints, true, container.x631afe05fcecf1f4.TabStripMetrics.Height)
		{
			this.x91f347c6e97f1846 = manager;
			this.x0467b00af7810f0c = container;
			for (;;)
			{
				this.x83e1554f4315a375 = sourceControlSystem;
				this.x493191df254612e4 = sourceControl;
				if (!false)
				{
					this.x9562cf1322eeedf1 = dockedSize;
					if (container is DocumentContainer)
					{
						this.x90ce1c0ec8c6028d = new Cursor(base.GetType().Assembly.GetManifestResourceStream("TD.SandDock.Resources.splitting.cur"));
						this.x52988e63e407fffa = new Cursor(base.GetType().Assembly.GetManifestResourceStream("TD.SandDock.Resources.splittingno.cur"));
						goto IL_20B;
					}
					if (8 != 0)
					{
						goto IL_20B;
					}
					IL_2A4:
					this.xca874006c41dfe29 = ((x410f3612b9a8f9de)container).xb1090c5821a633b5;
					goto IL_206;
					IL_20B:
					if (sourceControlSystem is SplitLayoutSystem)
					{
						goto IL_2A4;
					}
					goto IL_1E6;
				}
				IL_18F:
				Rectangle bounds = sourceControlSystem.Bounds;
				if (!false && bounds.Width <= 0)
				{
					if (false)
					{
						goto IL_206;
					}
					startPoint.X = this.xca874006c41dfe29.Width / 2;
					if (false)
					{
						continue;
					}
				}
				else
				{
					startPoint.X -= bounds.Left;
					startPoint.X = Convert.ToInt32((float)startPoint.X / (float)bounds.Width * (float)this.xca874006c41dfe29.Width);
				}
				if (sourceControl != null)
				{
					this.x2a2e0ce22e62c94e = new Point(startPoint.X, this.xca874006c41dfe29.Height - (bounds.Bottom - startPoint.Y));
					goto IL_35;
				}
				this.x2a2e0ce22e62c94e = new Point(startPoint.X, startPoint.Y - bounds.Top);
				bool flag = (uint)dockedSize < 0U;
				if (!flag)
				{
					goto IL_35;
				}
				IL_103:
				if (false)
				{
					goto IL_1E6;
				}
				break;
				IL_35:
				this.x2a2e0ce22e62c94e.Y = Math.Max(this.x2a2e0ce22e62c94e.Y, 0);
				this.x2a2e0ce22e62c94e.Y = Math.Min(this.x2a2e0ce22e62c94e.Y, this.xca874006c41dfe29.Height);
				this.xcd940949dfd37534 = this.x0ce9d68830aba643();
				this.x0467b00af7810f0c.OnDockingStarted(EventArgs.Empty);
				goto IL_103;
				IL_1E4:
				IL_206:
				goto IL_18F;
				IL_1E6:
				if (sourceControl == null)
				{
					while (sourceControlSystem is ControlLayoutSystem)
					{
						if (((ControlLayoutSystem)sourceControlSystem).SelectedControl == null)
						{
							IL_17B:
							this.xca874006c41dfe29 = sourceControlSystem.Bounds.Size;
							goto IL_18F;
						}
						this.xca874006c41dfe29 = ((ControlLayoutSystem)sourceControlSystem).SelectedControl.FloatingSize;
						if (-1 != 0)
						{
							goto IL_18F;
						}
					}
					goto IL_17B;
				}
				this.xca874006c41dfe29 = sourceControl.FloatingSize;
				goto IL_1E4;
			}
		}

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x060002AD RID: 685 RVA: 0x000180C4 File Offset: 0x000170C4
		protected ControlLayoutSystem[] xcdb018cc067a38ae
		{
			get
			{
				return this.xcd940949dfd37534;
			}
		}

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x060002AE RID: 686 RVA: 0x000180CC File Offset: 0x000170CC
		public SandDockManager x460ab163f44a604d
		{
			get
			{
				return this.x91f347c6e97f1846;
			}
		}

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x060002AF RID: 687 RVA: 0x000180D4 File Offset: 0x000170D4
		public int xf8ec28822747d4db
		{
			get
			{
				return this.x9562cf1322eeedf1;
			}
		}

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x060002B0 RID: 688 RVA: 0x000180DC File Offset: 0x000170DC
		public DockContainer xc99dabdb533b119a
		{
			get
			{
				return this.x0467b00af7810f0c;
			}
		}

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x060002B1 RID: 689 RVA: 0x000180E4 File Offset: 0x000170E4
		public LayoutSystemBase xf333586e50dccad2
		{
			get
			{
				return this.x83e1554f4315a375;
			}
		}

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x060002B2 RID: 690 RVA: 0x000180EC File Offset: 0x000170EC
		public DockControl x59ae058c4a0dec87
		{
			get
			{
				return this.x493191df254612e4;
			}
		}

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x060002B3 RID: 691 RVA: 0x000180F4 File Offset: 0x000170F4
		private Point x6fbe0a6d89f5dffb
		{
			get
			{
				return new Point(Cursor.Position.X - this.x2a2e0ce22e62c94e.X, Cursor.Position.Y - this.x2a2e0ce22e62c94e.Y);
			}
		}

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x060002B4 RID: 692 RVA: 0x00018138 File Offset: 0x00017138
		public bool xd065d1541e1bea63
		{
			get
			{
				return this.x0467b00af7810f0c.x972331c8ecf83413;
			}
		}

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x060002B5 RID: 693 RVA: 0x00018148 File Offset: 0x00017148
		public bool x74e31f9641656e0b
		{
			get
			{
				if (this.xd065d1541e1bea63)
				{
					return false;
				}
				if (this.x59ae058c4a0dec87 == null)
				{
					return this.xf333586e50dccad2.x74e31f9641656e0b;
				}
				return this.x59ae058c4a0dec87.DockingRules.AllowFloat;
			}
		}

		// Token: 0x060002B6 RID: 694 RVA: 0x00018178 File Offset: 0x00017178
		public bool xe302f2203dc14a18(ContainerDockLocation xb9c2cfae130d9256)
		{
			if (this.x59ae058c4a0dec87 != null)
			{
				return this.x59ae058c4a0dec87.xe302f2203dc14a18(xb9c2cfae130d9256);
			}
			return this.xf333586e50dccad2.xe302f2203dc14a18(xb9c2cfae130d9256);
		}

		// Token: 0x060002B7 RID: 695 RVA: 0x0001819C File Offset: 0x0001719C
		public override void OnMouseMove(Point position)
		{
			xedb4922162c60d3d.DockTarget dockTarget = null;
			if ((Control.ModifierKeys & Keys.Control) != Keys.Control)
			{
				dockTarget = this.FindDockTarget(position);
			}
			if (dockTarget == null)
			{
				goto IL_210;
			}
			if (dockTarget.type == xedb4922162c60d3d.DockTargetType.Undefined)
			{
				goto IL_26C;
			}
			IL_1E3:
			if (dockTarget.type == xedb4922162c60d3d.DockTargetType.Undefined)
			{
				dockTarget.type = xedb4922162c60d3d.DockTargetType.None;
			}
			if (dockTarget.type == xedb4922162c60d3d.DockTargetType.Float)
			{
				goto IL_1AC;
			}
			goto IL_187;
			IL_1D:
			if (this.x0467b00af7810f0c is DocumentContainer)
			{
				if (dockTarget.type == xedb4922162c60d3d.DockTargetType.AlreadyActioned)
				{
					Cursor.Current = Cursors.Default;
					goto IL_DF;
				}
				if (dockTarget.type == xedb4922162c60d3d.DockTargetType.None)
				{
					goto IL_35;
				}
				Cursor.Current = this.x90ce1c0ec8c6028d;
			}
			IL_2A:
			this.x521249670374b9ee = dockTarget;
			return;
			IL_35:
			Cursor.Current = this.x52988e63e407fffa;
			if (255 != 0)
			{
				goto IL_2A;
			}
			goto IL_143;
			IL_51:
			goto IL_1D;
			IL_6B:
			if (dockTarget.type == xedb4922162c60d3d.DockTargetType.None)
			{
				base.x11972e8742c570b8();
				goto IL_1D;
			}
			base.xe5e4149f382149cc(dockTarget.bounds, dockTarget.type == xedb4922162c60d3d.DockTargetType.JoinExistingSystem);
			if (2 == 0)
			{
				goto IL_DF;
			}
			goto IL_51;
			IL_A7:
			if (2 != 0)
			{
				if (false)
				{
					goto IL_51;
				}
				if (false)
				{
					goto IL_6B;
				}
				goto IL_D3;
			}
			IL_C1:
			ControlLayoutSystem controlLayoutSystem;
			if (dockTarget.dockSide == DockSide.None)
			{
				base.x11972e8742c570b8();
				controlLayoutSystem = (ControlLayoutSystem)this.x83e1554f4315a375;
				if (dockTarget.index != controlLayoutSystem.Controls.IndexOf(this.x493191df254612e4))
				{
					goto IL_11F;
				}
				goto IL_13C;
			}
			IL_CD:
			if (false)
			{
				if (!false)
				{
					if (2 != 0)
					{
						goto IL_A7;
					}
					goto IL_169;
				}
			}
			else if (false)
			{
				goto IL_A7;
			}
			IL_D3:
			goto IL_6B;
			IL_DF:
			if (15 != 0)
			{
				goto IL_2A;
			}
			if (2 != 0)
			{
				goto IL_234;
			}
			IL_FA:
			dockTarget.type = xedb4922162c60d3d.DockTargetType.AlreadyActioned;
			goto IL_23E;
			IL_11F:
			if (dockTarget.index == controlLayoutSystem.Controls.IndexOf(this.x493191df254612e4) + 1)
			{
				goto IL_FA;
			}
			controlLayoutSystem.Controls.SetChildIndex(this.x493191df254612e4, dockTarget.index);
			goto IL_169;
			IL_13C:
			if (2 == 0)
			{
				goto IL_11F;
			}
			IL_143:
			if (false)
			{
				goto IL_CD;
			}
			if (false)
			{
				goto IL_23E;
			}
			IL_169:
			goto IL_FA;
			IL_187:
			if (dockTarget.layoutSystem != this.x83e1554f4315a375)
			{
				goto IL_6B;
			}
			if (!false)
			{
				if (false)
				{
					goto IL_35;
				}
				if (false)
				{
					goto IL_26C;
				}
				if (this.x493191df254612e4 != null || false)
				{
					goto IL_C1;
				}
				goto IL_A7;
			}
			IL_1AC:
			dockTarget.bounds = new Rectangle(this.x6fbe0a6d89f5dffb, this.xca874006c41dfe29);
			dockTarget.bounds = this.x90c590fcd758eaee(dockTarget.bounds);
			if (false)
			{
				goto IL_13C;
			}
			goto IL_187;
			IL_23E:
			goto IL_1D;
			IL_210:
			if (this.x91f347c6e97f1846 != null)
			{
				if (this.x74e31f9641656e0b)
				{
					dockTarget = new xedb4922162c60d3d.DockTarget(xedb4922162c60d3d.DockTargetType.Float);
					goto IL_1E3;
				}
			}
			dockTarget = new xedb4922162c60d3d.DockTarget(xedb4922162c60d3d.DockTargetType.None);
			goto IL_1E3;
			IL_234:
			goto IL_210;
			IL_26C:
			if (this.x91f347c6e97f1846 == null)
			{
				goto IL_1E3;
			}
			if (2 == 0)
			{
				goto IL_234;
			}
			if (!this.x74e31f9641656e0b)
			{
				goto IL_1E3;
			}
			goto IL_234;
		}

		// Token: 0x060002B8 RID: 696 RVA: 0x00018434 File Offset: 0x00017434
		private Rectangle x90c590fcd758eaee(Rectangle xda73fcb97c77d998)
		{
			if (xda73fcb97c77d998.X >= Screen.PrimaryScreen.Bounds.X)
			{
				if (-1 != 0 && 15 != 0)
				{
					if (xda73fcb97c77d998.Right > Screen.PrimaryScreen.Bounds.Right)
					{
						goto IL_62;
					}
				}
				if (xda73fcb97c77d998.Y > Screen.PrimaryScreen.WorkingArea.Bottom)
				{
					xda73fcb97c77d998.Y = Screen.PrimaryScreen.WorkingArea.Bottom - xda73fcb97c77d998.Height;
				}
			}
			IL_62:
			Screen screen = Screen.FromRectangle(xda73fcb97c77d998);
			if (screen != null && xda73fcb97c77d998.Y < screen.WorkingArea.Y)
			{
				xda73fcb97c77d998.Y = screen.WorkingArea.Y;
			}
			return xda73fcb97c77d998;
		}

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x060002B9 RID: 697 RVA: 0x00018508 File Offset: 0x00017508
		public xedb4922162c60d3d.DockTarget x42f4c234c9358072
		{
			get
			{
				return this.x521249670374b9ee;
			}
		}

		// Token: 0x060002BA RID: 698 RVA: 0x00018510 File Offset: 0x00017510
		protected Rectangle x8a1b221df357d098(ContainerDockLocation x9c911703d455884e, bool x24c3791e61dc49c9)
		{
			int height;
			Control dockSystemContainer;
			int num;
			int width;
			if (x24c3791e61dc49c9)
			{
				bool flag = (uint)height + (uint)height > uint.MaxValue;
				if (!flag)
				{
					return this.x257d5a0e25592705(x9c911703d455884e, 30, true);
				}
			}
			else
			{
				dockSystemContainer = this.x460ab163f44a604d.DockSystemContainer;
				num = 0;
				width = dockSystemContainer.ClientRectangle.Width;
				bool flag = ((uint)height | 2147483647U) == 0U;
				if (flag)
				{
					goto IL_D7;
				}
			}
			int num2;
			if (!false)
			{
				num2 = 0;
				height = dockSystemContainer.ClientRectangle.Height;
				switch (x9c911703d455884e)
				{
				case ContainerDockLocation.Left:
					return new Rectangle(num - 30, num2, 30, height - num2);
				case ContainerDockLocation.Right:
					break;
				case ContainerDockLocation.Top:
					return new Rectangle(num, num2 - 30, width - num, 30);
				case ContainerDockLocation.Bottom:
					return new Rectangle(num, height, width - num, 30);
				default:
					goto IL_D7;
				}
			}
			return new Rectangle(width, num2, 30, height - num2);
			IL_D7:
			return Rectangle.Empty;
		}

		// Token: 0x060002BB RID: 699 RVA: 0x000185FC File Offset: 0x000175FC
		public static Rectangle x41c62f474d3fb367(Control xd3311d815ca25f02)
		{
			int num = 0;
			int num2;
			int num3;
			int num4;
			for (;;)
			{
				if (!false)
				{
					num2 = xd3311d815ca25f02.ClientRectangle.Width;
					num3 = 0;
				}
				num4 = xd3311d815ca25f02.ClientRectangle.Height;
				if (-2147483648 == 0)
				{
					break;
				}
				using (IEnumerator enumerator = xd3311d815ca25f02.Controls.GetEnumerator())
				{
					for (;;)
					{
						if (enumerator.MoveNext())
						{
							goto IL_2D2;
						}
						bool flag = (uint)num3 + (uint)num2 < 0U;
						if (flag)
						{
							goto IL_6B;
						}
						goto IL_BF;
						IL_3F:
						Rectangle bounds;
						if (bounds.Top >= num4)
						{
							continue;
						}
						goto IL_163;
						IL_2D2:
						Control control = (Control)enumerator.Current;
						if (2147483647 == 0)
						{
							goto IL_263;
						}
						flag = ((uint)num + (uint)num3 < 0U);
						if (!flag)
						{
							if (!control.Visible)
							{
								if (-2 == 0)
								{
									goto IL_18C;
								}
								flag = ((uint)num4 - (uint)num4 < 0U);
								if (flag)
								{
									goto IL_1CD;
								}
								flag = ((uint)num > uint.MaxValue);
								if (flag || ((uint)num | 1U) == 0U)
								{
									goto IL_109;
								}
								flag = ((uint)num3 + (uint)num2 < 0U);
								if (flag)
								{
									goto IL_BF;
								}
								continue;
							}
						}
						IL_27E:
						DockStyle dock = control.Dock;
						Rectangle bounds2;
						if ((uint)num2 >= 0U)
						{
							if ((uint)num3 <= 4294967295U)
							{
								switch (dock)
								{
								case DockStyle.Top:
									bounds2 = control.Bounds;
									if ((uint)num4 + (uint)num2 < 0U)
									{
										continue;
									}
									break;
								case DockStyle.Bottom:
									bounds = control.Bounds;
									flag = ((uint)num2 - (uint)num2 > uint.MaxValue);
									if (flag)
									{
										goto IL_163;
									}
									goto IL_3F;
								case DockStyle.Left:
									goto IL_263;
								case DockStyle.Right:
									goto IL_1E5;
								default:
									continue;
								}
							}
							goto IL_6B;
						}
						goto IL_2D2;
						IL_BF:
						flag = ((uint)num3 > uint.MaxValue);
						if (!flag)
						{
							break;
						}
						flag = ((uint)num4 + (uint)num < 0U);
						if (flag)
						{
							goto IL_27E;
						}
						if ((uint)num + (uint)num4 >= 0U)
						{
							goto IL_2D2;
						}
						continue;
						IL_6B:
						if (bounds2.Bottom <= num3)
						{
							continue;
						}
						num3 = control.Bounds.Bottom;
						continue;
						IL_1CD:
						flag = ((uint)num3 + (uint)num3 < 0U);
						if (flag)
						{
							goto IL_1E5;
						}
						goto IL_6B;
						IL_18C:
						Rectangle bounds3;
						if (bounds3.Left < num2)
						{
							num2 = control.Bounds.Left;
							continue;
						}
						flag = ((uint)num4 + (uint)num2 > uint.MaxValue);
						if (flag)
						{
							goto IL_3F;
						}
						continue;
						IL_1E5:
						bounds3 = control.Bounds;
						goto IL_18C;
						IL_109:
						Rectangle bounds4;
						if (bounds4.Right > num)
						{
							num = control.Bounds.Right;
							continue;
						}
						if ((uint)num3 < 0U)
						{
							goto IL_163;
						}
						flag = ((uint)num2 - (uint)num4 > uint.MaxValue);
						if (flag)
						{
							goto IL_1CD;
						}
						continue;
						IL_263:
						bounds4 = control.Bounds;
						goto IL_109;
						continue;
						IL_163:
						num4 = control.Bounds.Top;
					}
					break;
				}
			}
			return new Rectangle(num, num3, num2 - num, num4 - num3);
		}

		// Token: 0x060002BC RID: 700 RVA: 0x0001898C File Offset: 0x0001798C
		protected Rectangle x257d5a0e25592705(ContainerDockLocation x9c911703d455884e, int x73f61fa085749e85, bool x24c3791e61dc49c9)
		{
			Rectangle rectangle = xedb4922162c60d3d.x41c62f474d3fb367(this.x460ab163f44a604d.DockSystemContainer);
			Rectangle result;
			int val;
			if (((uint)x73f61fa085749e85 | 4294967295U) != 0U)
			{
				result = rectangle;
				if (!x24c3791e61dc49c9)
				{
					result = this.x460ab163f44a604d.DockSystemContainer.ClientRectangle;
				}
				val = x73f61fa085749e85 + 4;
				switch (x9c911703d455884e)
				{
				case ContainerDockLocation.Left:
					goto IL_6E;
				case ContainerDockLocation.Right:
					return new Rectangle(result.Right - Math.Min(val, Convert.ToInt32((double)rectangle.Width * 0.9)), result.Top, Math.Min(val, Convert.ToInt32((double)rectangle.Width * 0.9)), result.Height);
				case ContainerDockLocation.Top:
					return new Rectangle(result.Left, result.Top, result.Width, Math.Min(val, Convert.ToInt32((double)rectangle.Height * 0.9)));
				case ContainerDockLocation.Bottom:
					return new Rectangle(result.Left, result.Bottom - Math.Min(val, Convert.ToInt32((double)rectangle.Height * 0.9)), result.Width, Math.Min(val, Convert.ToInt32((double)rectangle.Height * 0.9)));
				}
				return result;
			}
			IL_6E:
			return new Rectangle(result.Left, result.Top, Math.Min(val, Convert.ToInt32((double)rectangle.Width * 0.9)), result.Height);
		}

		// Token: 0x060002BD RID: 701 RVA: 0x00018B28 File Offset: 0x00017B28
		protected bool xecd95d3d6bb4afc3()
		{
			return this.x460ab163f44a604d.FindDockedContainer(DockStyle.Fill) is DocumentContainer;
		}

		// Token: 0x060002BE RID: 702 RVA: 0x00018B40 File Offset: 0x00017B40
		private ControlLayoutSystem[] x0ce9d68830aba643()
		{
			ArrayList arrayList = new ArrayList();
			bool flag2;
			bool flag = ((flag2 ? 1U : 0U) & 0U) == 0U;
			if (!flag)
			{
				goto IL_E1;
			}
			DockContainer[] array;
			if (this.x91f347c6e97f1846 != null)
			{
				array = this.x91f347c6e97f1846.GetDockContainers();
				goto IL_239;
			}
			DockContainer[] array2 = new DockContainer[]
			{
				this.xc99dabdb533b119a
			};
			goto IL_294;
			IL_23:
			int num;
			num++;
			IL_29:
			DockContainer[] array3;
			DockContainer dockContainer;
			ControlLayoutSystem[] array4;
			if (num < array3.Length)
			{
				dockContainer = array3[num];
				bool isFloating = dockContainer.IsFloating;
				flag2 = (dockContainer.Dock == DockStyle.Fill && !dockContainer.IsFloating);
				bool flag3 = this.xc99dabdb533b119a.Dock == DockStyle.Fill && !this.xc99dabdb533b119a.IsFloating;
				while (isFloating)
				{
					if (this.xf333586e50dccad2.DockContainer != dockContainer)
					{
						break;
					}
					if (this.xf333586e50dccad2 is SplitLayoutSystem)
					{
						if (4 == 0)
						{
							goto IL_149;
						}
						if ((uint)num >= 0U)
						{
							goto IL_23;
						}
					}
					else
					{
						flag = (((isFloating ? 1U : 0U) & 0U) == 0U);
						if (flag)
						{
							break;
						}
						continue;
					}
					IL_6E:
					if (this.xe302f2203dc14a18(LayoutUtilities.x3650f3b579b2b4d2(dockContainer.Dock)))
					{
						goto IL_140;
					}
					if ((flag3 ? 1U : 0U) + (isFloating ? 1U : 0U) >= 0U)
					{
						goto IL_23;
					}
					IL_89:
					if (this.xc99dabdb533b119a == dockContainer)
					{
						goto IL_E1;
					}
					IL_92:
					if ((uint)num - (isFloating ? 1U : 0U) < 0U)
					{
						break;
					}
					flag = (((isFloating ? 1U : 0U) | 2U) == 0U);
					if (flag)
					{
						flag = ((flag2 ? 1U : 0U) - (uint)num > uint.MaxValue);
						if (flag)
						{
							goto IL_129;
						}
						goto IL_1A5;
					}
					else
					{
						flag = ((flag2 ? 1U : 0U) + (flag3 ? 1U : 0U) < 0U);
						if (flag)
						{
							return array4;
						}
						goto IL_51;
					}
					IL_DB:
					if (flag3)
					{
						goto IL_89;
					}
					goto IL_E1;
					IL_129:
					if ((flag3 ? 1U : 0U) >= 0U)
					{
						goto IL_DB;
					}
					goto IL_92;
					IL_140:
					if (!flag2)
					{
						goto IL_DB;
					}
					IL_149:
					if (!flag3)
					{
						goto IL_23;
					}
					if (true)
					{
						goto IL_129;
					}
					IL_159:
					if (isFloating)
					{
						goto IL_140;
					}
					flag = ((flag2 ? 1U : 0U) + (uint)num > uint.MaxValue);
					if (!flag)
					{
						goto IL_6E;
					}
					flag = (((uint)num & 0U) == 0U);
					if (!flag)
					{
						goto IL_41;
					}
					if ((uint)num >= 0U)
					{
						goto IL_140;
					}
					goto IL_294;
					IL_1A5:
					goto IL_159;
					IL_1A7:
					if (!isFloating)
					{
						goto IL_159;
					}
					if (this.x74e31f9641656e0b)
					{
						goto IL_159;
					}
					if (this.xf333586e50dccad2.DockContainer == dockContainer)
					{
						goto IL_1A5;
					}
					goto IL_23;
				}
				goto IL_1A7;
			}
			array4 = new ControlLayoutSystem[arrayList.Count];
			IL_41:
			arrayList.CopyTo(array4, 0);
			if (-2147483648 != 0)
			{
				return array4;
			}
			IL_51:
			goto IL_23;
			IL_E1:
			this.x53faf379dc10cd0f(dockContainer, arrayList);
			goto IL_23;
			IL_239:
			array3 = array;
			num = 0;
			goto IL_29;
			IL_294:
			array = array2;
			goto IL_239;
		}

		// Token: 0x060002BF RID: 703 RVA: 0x00018E0C File Offset: 0x00017E0C
		private void x53faf379dc10cd0f(DockContainer xd3311d815ca25f02, ArrayList x3c4da2980d043c95)
		{
			bool flag;
			if (xd3311d815ca25f02.Width > 0)
			{
				flag = true;
				goto IL_6C;
			}
			if (-1 != 0)
			{
				if (!false)
				{
					flag = (xd3311d815ca25f02.Height > 0);
					goto IL_6C;
				}
				goto IL_5B;
			}
			IL_10:
			if (!xd3311d815ca25f02.Visible)
			{
				return;
			}
			IL_32:
			this.xabdf625bc93be733(xd3311d815ca25f02, xd3311d815ca25f02.LayoutSystem, x3c4da2980d043c95);
			bool flag3;
			bool flag2 = (flag3 ? 1U : 0U) - (flag3 ? 1U : 0U) < 0U;
			if (!flag2)
			{
				return;
			}
			IL_58:
			if (flag3)
			{
				if (xd3311d815ca25f02.Enabled)
				{
					flag2 = ((flag3 ? 1U : 0U) + (flag3 ? 1U : 0U) < 0U);
					if (flag2)
					{
						goto IL_32;
					}
					goto IL_10;
				}
			}
			IL_5B:
			return;
			IL_6C:
			flag3 = flag;
			goto IL_58;
		}

		// Token: 0x060002C0 RID: 704 RVA: 0x00018E94 File Offset: 0x00017E94
		private void xabdf625bc93be733(DockContainer xd3311d815ca25f02, SplitLayoutSystem x35c76d526f88c3c8, ArrayList x3c4da2980d043c95)
		{
			using (IEnumerator enumerator = x35c76d526f88c3c8.LayoutSystems.GetEnumerator())
			{
				IL_20:
				while (enumerator.MoveNext())
				{
					LayoutSystemBase layoutSystemBase;
					for (;;)
					{
						layoutSystemBase = (LayoutSystemBase)enumerator.Current;
						if (layoutSystemBase is SplitLayoutSystem)
						{
							goto IL_E2;
						}
						for (;;)
						{
							bool flag;
							bool flag2;
							if (layoutSystemBase is ControlLayoutSystem)
							{
								flag = ((this.x493191df254612e4 == null || layoutSystemBase != this.x83e1554f4315a375 || this.x493191df254612e4.LayoutSystem.Controls.Count != 1) && !((ControlLayoutSystem)layoutSystemBase).Collapsed);
								while (flag)
								{
									x3c4da2980d043c95.Add(layoutSystemBase);
									flag2 = ((flag ? 1U : 0U) > uint.MaxValue);
									if (flag2)
									{
										goto Block_9;
									}
									if (false)
									{
										goto IL_10D;
									}
									if (-2147483648 != 0)
									{
										goto IL_0E;
									}
								}
								goto Block_4;
							}
							if (15 != 0)
							{
								goto IL_2D;
							}
							flag2 = (((flag ? 1U : 0U) | 8U) == 0U);
							if (flag2)
							{
								goto IL_6A;
							}
							IL_0E:
							if ((flag ? 1U : 0U) >= 0U)
							{
								goto IL_20;
							}
						}
						Block_9:
						if (false)
						{
							goto Block_10;
						}
					}
					IL_2D:
					continue;
					IL_6A:
					break;
					Block_4:
					continue;
					IL_E2:
					this.xabdf625bc93be733(xd3311d815ca25f02, (SplitLayoutSystem)layoutSystemBase, x3c4da2980d043c95);
					continue;
					Block_10:
					goto IL_E2;
					IL_10D:
					break;
				}
			}
		}

		// Token: 0x060002C1 RID: 705 RVA: 0x00018FE0 File Offset: 0x00017FE0
		protected virtual xedb4922162c60d3d.DockTarget FindDockTarget(Point position)
		{
			xedb4922162c60d3d.DockTarget dockTarget = null;
			int num;
			int num2;
			bool flag = (uint)num + (uint)num2 > uint.MaxValue;
			if (flag)
			{
				goto IL_281;
			}
			while (this.x91f347c6e97f1846 != null)
			{
				flag = ((uint)num + (uint)num2 > uint.MaxValue);
				if (flag)
				{
					flag = ((uint)num2 < 0U);
					if (flag)
					{
						if (!false)
						{
							goto IL_281;
						}
						goto IL_18D;
					}
				}
				else
				{
					flag = ((uint)num > uint.MaxValue);
					if (flag)
					{
						xedb4922162c60d3d.DockTarget result;
						return result;
					}
					goto IL_281;
				}
			}
			goto IL_55C;
			IL_18D:
			ContainerDockLocation containerDockLocation;
			dockTarget.dockLocation = containerDockLocation;
			dockTarget.bounds = xedb4922162c60d3d.xc68a4bb946c59a9e(this.x257d5a0e25592705(containerDockLocation, this.x9562cf1322eeedf1, true), this.x460ab163f44a604d.DockSystemContainer);
			dockTarget.middle = true;
			return dockTarget;
			IL_267:
			ControlLayoutSystem[] array = this.xcd940949dfd37534;
			num = 0;
			for (;;)
			{
				if (num >= array.Length)
				{
					flag = ((uint)num - (uint)num2 > uint.MaxValue);
					if (flag)
					{
						goto IL_2A6;
					}
					flag = (((uint)num2 | 8U) == 0U);
					if (flag)
					{
						goto IL_1BF;
					}
					goto IL_4A;
					IL_5F:
					if (num2 > 4)
					{
						flag = ((uint)num - (uint)num2 < 0U);
						if (flag)
						{
							goto IL_22;
						}
						flag = ((uint)num2 < 0U);
						if (flag)
						{
							goto IL_4A;
						}
						goto IL_22;
					}
					else
					{
						containerDockLocation = (ContainerDockLocation)num2;
						if ((uint)num - (uint)num2 <= 4294967295U)
						{
							goto IL_2A6;
						}
						goto IL_21E;
					}
					IL_1BF:
					num2 = 1;
					goto IL_5F;
					IL_4A:
					if (this.x460ab163f44a604d == null)
					{
						break;
					}
					goto IL_1BF;
					IL_22:
					flag = (((uint)num2 & 0U) == 0U);
					if (flag)
					{
						break;
					}
					goto IL_4A;
					IL_2A6:
					if (this.xe302f2203dc14a18(containerDockLocation))
					{
						Rectangle rectangle = xedb4922162c60d3d.xc68a4bb946c59a9e(this.x8a1b221df357d098(containerDockLocation, true), this.x460ab163f44a604d.DockSystemContainer);
						if (-1 == 0)
						{
							goto IL_22;
						}
						if (rectangle.Contains(position))
						{
							goto Block_9;
						}
						rectangle = xedb4922162c60d3d.xc68a4bb946c59a9e(this.x8a1b221df357d098(containerDockLocation, false), this.x460ab163f44a604d.DockSystemContainer);
						flag = ((uint)num > uint.MaxValue);
						if (flag)
						{
							goto IL_148;
						}
						if (false)
						{
							goto IL_4A;
						}
						flag = (((uint)num2 | 8U) == 0U);
						if (flag || rectangle.Contains(position))
						{
							goto IL_D9;
						}
					}
					num2++;
					goto IL_5F;
				}
				ControlLayoutSystem controlLayoutSystem = array[num];
				Rectangle rectangle2 = new Rectangle(controlLayoutSystem.DockContainer.PointToScreen(controlLayoutSystem.Bounds.Location), controlLayoutSystem.Bounds.Size);
				while (-1 != 0 && !rectangle2.Contains(position))
				{
					if (!false)
					{
						goto IL_1ED;
					}
				}
				goto IL_21E;
				IL_1ED:
				num++;
				continue;
				IL_21E:
				dockTarget = this.xede53ab1a4b2e20b(controlLayoutSystem.DockContainer, controlLayoutSystem, position, true);
				if (dockTarget == null)
				{
					goto IL_1ED;
				}
				goto IL_200;
			}
			IL_36:
			return null;
			goto IL_36;
			IL_D9:
			dockTarget = new xedb4922162c60d3d.DockTarget(xedb4922162c60d3d.DockTargetType.CreateNewContainer);
			dockTarget.dockLocation = containerDockLocation;
			IL_148:
			dockTarget.bounds = xedb4922162c60d3d.xc68a4bb946c59a9e(this.x257d5a0e25592705(containerDockLocation, this.x9562cf1322eeedf1, false), this.x460ab163f44a604d.DockSystemContainer);
			return dockTarget;
			Block_9:
			dockTarget = new xedb4922162c60d3d.DockTarget(xedb4922162c60d3d.DockTargetType.CreateNewContainer);
			goto IL_18D;
			IL_200:
			return dockTarget;
			IL_281:
			if (this.x74e31f9641656e0b)
			{
				IEnumerator enumerator = this.x91f347c6e97f1846.xd27fa35d10494112.GetEnumerator();
				try
				{
					DockContainer dockContainer;
					for (;;)
					{
						IL_318:
						if (!enumerator.MoveNext())
						{
							flag = ((uint)num - (uint)num > uint.MaxValue);
							if (!flag)
							{
								goto IL_4DB;
							}
						}
						dockContainer = (DockContainer)enumerator.Current;
						if ((uint)num <= 4294967295U)
						{
							if (dockContainer.IsFloating && ((x410f3612b9a8f9de)dockContainer).xd936980ea1aac341.Visible)
							{
								do
								{
									IL_329:
									if (!((x410f3612b9a8f9de)dockContainer).HasSingleControlLayoutSystem)
									{
										if (!false)
										{
											break;
										}
									}
									if (dockContainer.LayoutSystem == this.x83e1554f4315a375)
									{
										break;
									}
									for (;;)
									{
										Rectangle rectangle2 = ((x410f3612b9a8f9de)dockContainer).x5de6fa99acd93adb;
										if ((uint)num2 - (uint)num < 0U)
										{
											goto IL_329;
										}
										if (!rectangle2.Contains(position))
										{
											flag = ((uint)num - (uint)num2 < 0U);
											if (!flag)
											{
												goto IL_318;
											}
										}
										else
										{
											rectangle2 = new Rectangle(dockContainer.PointToScreen(dockContainer.LayoutSystem.LayoutSystems[0].Bounds.Location), dockContainer.LayoutSystem.LayoutSystems[0].Bounds.Size);
										}
										if (rectangle2.Contains(position))
										{
											break;
										}
										dockTarget = new xedb4922162c60d3d.DockTarget(xedb4922162c60d3d.DockTargetType.JoinExistingSystem);
										dockTarget.dockContainer = dockContainer;
										if (4 != 0)
										{
											goto IL_477;
										}
									}
									flag = ((uint)num2 - (uint)num > uint.MaxValue);
								}
								while (flag);
							}
						}
					}
					IL_477:
					dockTarget.layoutSystem = (ControlLayoutSystem)dockContainer.LayoutSystem.LayoutSystems[0];
					dockTarget.bounds = ((x410f3612b9a8f9de)dockContainer).x5de6fa99acd93adb;
					return dockTarget;
					IL_4DB:;
				}
				finally
				{
					IDisposable disposable = enumerator as IDisposable;
					if (((uint)num & 0U) != 0U)
					{
					}
					for (;;)
					{
						IL_4FD:
						if (disposable == null)
						{
							goto IL_501;
						}
						disposable.Dispose();
						IL_503:
						if (false)
						{
							continue;
						}
						if (-2 != 0)
						{
							if (((uint)num & 0U) == 0U)
							{
								goto IL_556;
							}
						}
						IL_521:
						if (((uint)num2 | 15U) != 0U)
						{
							break;
						}
						goto IL_503;
						IL_501:
						goto IL_521;
					}
					flag = ((uint)num2 > uint.MaxValue);
					if (flag)
					{
						goto IL_54B;
					}
					IL_556:
					goto EndFinally_34;
					IL_54B:
					goto IL_4FD;
					EndFinally_34:;
				}
			}
			IL_55C:
			goto IL_267;
		}

		// Token: 0x060002C2 RID: 706 RVA: 0x00019594 File Offset: 0x00018594
		public static Rectangle xc68a4bb946c59a9e(Rectangle x337e217cb3ba0627, Control x43bec302f92080b9)
		{
			return new Rectangle(x43bec302f92080b9.PointToScreen(x337e217cb3ba0627.Location), x337e217cb3ba0627.Size);
		}

		// Token: 0x060002C3 RID: 707 RVA: 0x000195B0 File Offset: 0x000185B0
		protected xedb4922162c60d3d.DockTarget xede53ab1a4b2e20b(DockContainer xd3311d815ca25f02, ControlLayoutSystem x6e150040c8d97700, Point x13d4cb8d1bd20347, bool xcef4185c23f358e0)
		{
			xedb4922162c60d3d.DockTarget dockTarget = new xedb4922162c60d3d.DockTarget(xedb4922162c60d3d.DockTargetType.Undefined);
			Point point;
			for (;;)
			{
				point = xd3311d815ca25f02.PointToClient(x13d4cb8d1bd20347);
				bool flag = (xcef4185c23f358e0 ? 1U : 0U) < 0U;
				if (flag)
				{
					goto IL_1D9;
				}
				while (this.x493191df254612e4 != null)
				{
					flag = ((xcef4185c23f358e0 ? 1U : 0U) - (xcef4185c23f358e0 ? 1U : 0U) > uint.MaxValue);
					if (!flag)
					{
						goto IL_1D9;
					}
				}
				if (x6e150040c8d97700 == this.x83e1554f4315a375)
				{
					goto Block_11;
				}
				IL_11C:
				while (x6e150040c8d97700.xccb1fc68964285c2.Contains(point) || x6e150040c8d97700.xa358da7dd5364cab.Contains(point))
				{
					dockTarget = new xedb4922162c60d3d.DockTarget(xedb4922162c60d3d.DockTargetType.JoinExistingSystem);
					flag = ((xcef4185c23f358e0 ? 1U : 0U) - (xcef4185c23f358e0 ? 1U : 0U) > uint.MaxValue);
					if (flag)
					{
						goto Block_8;
					}
					dockTarget.dockContainer = xd3311d815ca25f02;
					if (8 != 0)
					{
						if ((xcef4185c23f358e0 ? 1U : 0U) <= 4294967295U)
						{
							dockTarget.layoutSystem = x6e150040c8d97700;
							dockTarget.dockSide = DockSide.None;
							dockTarget.bounds = new Rectangle(xd3311d815ca25f02.PointToScreen(x6e150040c8d97700.Bounds.Location), x6e150040c8d97700.Bounds.Size);
							if ((xcef4185c23f358e0 ? 1U : 0U) < 0U)
							{
								continue;
							}
							flag = ((xcef4185c23f358e0 ? 1U : 0U) > uint.MaxValue);
							if (flag || x6e150040c8d97700.xa358da7dd5364cab.Contains(point))
							{
								dockTarget.index = x6e150040c8d97700.x17fd454c85fad336(point);
								break;
							}
						}
					}
					dockTarget.index = x6e150040c8d97700.Controls.Count;
					break;
				}
				if (dockTarget.type != xedb4922162c60d3d.DockTargetType.Undefined)
				{
					flag = ((xcef4185c23f358e0 ? 1U : 0U) > uint.MaxValue);
					if (!flag)
					{
						return dockTarget;
					}
				}
				if (xcef4185c23f358e0 || (xcef4185c23f358e0 ? 1U : 0U) + (xcef4185c23f358e0 ? 1U : 0U) > 4294967295U)
				{
					break;
				}
				if (255 == 0)
				{
					continue;
				}
				return dockTarget;
				IL_1D9:
				if (((xcef4185c23f358e0 ? 1U : 0U) & 0U) != 0U)
				{
					return dockTarget;
				}
				goto IL_11C;
			}
			IL_0C:
			return this.xc366f13a00f0a38d(xd3311d815ca25f02, x6e150040c8d97700, x13d4cb8d1bd20347);
			Block_8:
			goto IL_0C;
			Block_11:
			if (x6e150040c8d97700.xccb1fc68964285c2.Contains(point))
			{
				return new xedb4922162c60d3d.DockTarget(xedb4922162c60d3d.DockTargetType.None);
			}
			return new xedb4922162c60d3d.DockTarget(xedb4922162c60d3d.DockTargetType.Undefined);
		}

		// Token: 0x060002C4 RID: 708 RVA: 0x000197B0 File Offset: 0x000187B0
		private xedb4922162c60d3d.DockTarget xc366f13a00f0a38d(DockContainer xd3311d815ca25f02, ControlLayoutSystem x6e150040c8d97700, Point x13d4cb8d1bd20347)
		{
			xedb4922162c60d3d.DockTarget dockTarget = null;
			if (!false)
			{
				Point point;
				Rectangle x21ed2ecc088ef4e;
				for (;;)
				{
					point = xd3311d815ca25f02.PointToClient(x13d4cb8d1bd20347);
					if (-2147483648 == 0)
					{
						goto Block_21;
					}
					x21ed2ecc088ef4e = x6e150040c8d97700.x21ed2ecc088ef4e4;
					if (new Rectangle(x21ed2ecc088ef4e.Left, x21ed2ecc088ef4e.Top, x21ed2ecc088ef4e.Width, 30).Contains(point))
					{
						goto Block_20;
					}
					Rectangle rectangle = new Rectangle(x21ed2ecc088ef4e.Left, x21ed2ecc088ef4e.Top, 30, x21ed2ecc088ef4e.Height);
					if (false)
					{
						goto IL_260;
					}
					if (!false)
					{
						goto IL_315;
					}
				}
				IL_36:
				if (point.X > x21ed2ecc088ef4e.Right - 30)
				{
					do
					{
						this.x4ea01976b3079611(xd3311d815ca25f02, x6e150040c8d97700, dockTarget, x21ed2ecc088ef4e, point);
					}
					while (false);
					return dockTarget;
				}
				IL_49:
				this.xa86a93682c30b8c6(xd3311d815ca25f02, x6e150040c8d97700, dockTarget, DockSide.Bottom);
				return dockTarget;
				IL_170:
				this.xa86a93682c30b8c6(xd3311d815ca25f02, x6e150040c8d97700, dockTarget, DockSide.Left);
				return dockTarget;
				IL_1AD:
				goto IL_170;
				IL_1E3:
				if (false)
				{
					goto IL_49;
				}
				if (!false && point.Y >= x21ed2ecc088ef4e.Top + 30)
				{
					if (point.Y <= x21ed2ecc088ef4e.Bottom - 30)
					{
						goto IL_170;
					}
					this.x6ff0606cba620904(xd3311d815ca25f02, x6e150040c8d97700, dockTarget, x21ed2ecc088ef4e, point);
					return dockTarget;
				}
				else
				{
					this.x2a1e65376d30fca5(xd3311d815ca25f02, x6e150040c8d97700, dockTarget, x21ed2ecc088ef4e, point);
					if (!false)
					{
						return dockTarget;
					}
					if (-1 != 0)
					{
						goto IL_227;
					}
				}
				IL_201:
				if (false)
				{
					goto IL_1AD;
				}
				if (!false)
				{
					Rectangle rectangle;
					if (rectangle.Contains(point))
					{
						goto IL_217;
					}
					if (!new Rectangle(x21ed2ecc088ef4e.Right - 30, x21ed2ecc088ef4e.Top, 30, x21ed2ecc088ef4e.Height).Contains(point))
					{
						if (!new Rectangle(x21ed2ecc088ef4e.Left, x21ed2ecc088ef4e.Bottom - 30, x21ed2ecc088ef4e.Width, 30).Contains(point))
						{
							return dockTarget;
						}
						dockTarget = this.x7aa9d6b148df47c3(xd3311d815ca25f02, x6e150040c8d97700);
						if (point.X < x21ed2ecc088ef4e.Left + 30)
						{
							this.x6ff0606cba620904(xd3311d815ca25f02, x6e150040c8d97700, dockTarget, x21ed2ecc088ef4e, point);
							return dockTarget;
						}
						if (4 != 0)
						{
							goto IL_36;
						}
						goto IL_1E3;
					}
					else
					{
						dockTarget = this.x7aa9d6b148df47c3(xd3311d815ca25f02, x6e150040c8d97700);
						if (4 != 0)
						{
							if (!false)
							{
								if (-1 != 0 && point.Y >= x21ed2ecc088ef4e.Top + 30)
								{
									goto IL_E8;
								}
								this.x142a59be2748bb95(xd3311d815ca25f02, x6e150040c8d97700, dockTarget, x21ed2ecc088ef4e, point);
							}
							return dockTarget;
						}
						goto IL_260;
					}
				}
				IL_E8:
				if (point.Y <= x21ed2ecc088ef4e.Bottom - 30)
				{
					this.xa86a93682c30b8c6(xd3311d815ca25f02, x6e150040c8d97700, dockTarget, DockSide.Right);
					return dockTarget;
				}
				this.x4ea01976b3079611(xd3311d815ca25f02, x6e150040c8d97700, dockTarget, x21ed2ecc088ef4e, point);
				return dockTarget;
				IL_217:
				dockTarget = this.x7aa9d6b148df47c3(xd3311d815ca25f02, x6e150040c8d97700);
				if (3 != 0)
				{
					if (-1 != 0)
					{
						goto IL_1E3;
					}
					goto IL_36;
				}
				IL_227:
				goto IL_1AD;
				IL_260:
				if (!true)
				{
					goto IL_29E;
				}
				IL_267:
				if (point.X > x21ed2ecc088ef4e.Right - 30)
				{
					this.x142a59be2748bb95(xd3311d815ca25f02, x6e150040c8d97700, dockTarget, x21ed2ecc088ef4e, point);
					return dockTarget;
				}
				this.xa86a93682c30b8c6(xd3311d815ca25f02, x6e150040c8d97700, dockTarget, DockSide.Top);
				if (false)
				{
					goto IL_2C0;
				}
				if (!false)
				{
					return dockTarget;
				}
				goto IL_217;
				IL_29E:
				if (point.X >= x21ed2ecc088ef4e.Left + 30)
				{
					goto IL_267;
				}
				this.x2a1e65376d30fca5(xd3311d815ca25f02, x6e150040c8d97700, dockTarget, x21ed2ecc088ef4e, point);
				IL_2C0:
				return dockTarget;
				Block_20:
				dockTarget = this.x7aa9d6b148df47c3(xd3311d815ca25f02, x6e150040c8d97700);
				goto IL_29E;
				Block_21:
				if (!false)
				{
					goto IL_260;
				}
				IL_315:
				goto IL_201;
			}
			return dockTarget;
		}

		// Token: 0x060002C5 RID: 709 RVA: 0x00019AE0 File Offset: 0x00018AE0
		private void x4ea01976b3079611(DockContainer xd3311d815ca25f02, ControlLayoutSystem x6e150040c8d97700, xedb4922162c60d3d.DockTarget x11d58b056c032b03, Rectangle x21ed2ecc088ef4e4, Point x6b2bb9f943411698)
		{
			x21ed2ecc088ef4e4.X = x21ed2ecc088ef4e4.Right - 30;
			x21ed2ecc088ef4e4.Y = x21ed2ecc088ef4e4.Bottom - 30;
			x6b2bb9f943411698.X -= x21ed2ecc088ef4e4.Left;
			x6b2bb9f943411698.Y -= x21ed2ecc088ef4e4.Top;
			x21ed2ecc088ef4e4 = new Rectangle(0, 0, 30, 30);
			while (x6b2bb9f943411698.Y > x21ed2ecc088ef4e4.Top + (int)((float)x21ed2ecc088ef4e4.Height * ((float)x6b2bb9f943411698.X / (float)x21ed2ecc088ef4e4.Width)))
			{
				this.xa86a93682c30b8c6(xd3311d815ca25f02, x6e150040c8d97700, x11d58b056c032b03, DockSide.Bottom);
				if (2147483647 != 0)
				{
					return;
				}
			}
			this.xa86a93682c30b8c6(xd3311d815ca25f02, x6e150040c8d97700, x11d58b056c032b03, DockSide.Right);
		}

		// Token: 0x060002C6 RID: 710 RVA: 0x00019BA0 File Offset: 0x00018BA0
		private void x6ff0606cba620904(DockContainer xd3311d815ca25f02, ControlLayoutSystem x6e150040c8d97700, xedb4922162c60d3d.DockTarget x11d58b056c032b03, Rectangle x21ed2ecc088ef4e4, Point x6b2bb9f943411698)
		{
			x21ed2ecc088ef4e4.Y = x21ed2ecc088ef4e4.Bottom - 30;
			x6b2bb9f943411698.X -= x21ed2ecc088ef4e4.Left;
			x6b2bb9f943411698.Y -= x21ed2ecc088ef4e4.Top;
			x21ed2ecc088ef4e4 = new Rectangle(0, 0, 30, 30);
			if (-2147483648 == 0)
			{
				if (false)
				{
					return;
				}
			}
			else if (x6b2bb9f943411698.Y <= x21ed2ecc088ef4e4.Bottom - (int)((float)x21ed2ecc088ef4e4.Height * ((float)x6b2bb9f943411698.X / (float)x21ed2ecc088ef4e4.Width)))
			{
				this.xa86a93682c30b8c6(xd3311d815ca25f02, x6e150040c8d97700, x11d58b056c032b03, DockSide.Left);
				return;
			}
			this.xa86a93682c30b8c6(xd3311d815ca25f02, x6e150040c8d97700, x11d58b056c032b03, DockSide.Bottom);
		}

		// Token: 0x060002C7 RID: 711 RVA: 0x00019C48 File Offset: 0x00018C48
		private void x142a59be2748bb95(DockContainer xd3311d815ca25f02, ControlLayoutSystem x6e150040c8d97700, xedb4922162c60d3d.DockTarget x11d58b056c032b03, Rectangle x21ed2ecc088ef4e4, Point x6b2bb9f943411698)
		{
			x21ed2ecc088ef4e4.X = x21ed2ecc088ef4e4.Right - 30;
			x6b2bb9f943411698.X -= x21ed2ecc088ef4e4.Left;
			x6b2bb9f943411698.Y -= x21ed2ecc088ef4e4.Top;
			x21ed2ecc088ef4e4 = new Rectangle(0, 0, 30, 30);
			if (x6b2bb9f943411698.Y <= x21ed2ecc088ef4e4.Top + (int)((float)x21ed2ecc088ef4e4.Height * ((float)(x21ed2ecc088ef4e4.Right - x6b2bb9f943411698.X) / (float)x21ed2ecc088ef4e4.Width)))
			{
				this.xa86a93682c30b8c6(xd3311d815ca25f02, x6e150040c8d97700, x11d58b056c032b03, DockSide.Top);
				goto IL_AE;
			}
			this.xa86a93682c30b8c6(xd3311d815ca25f02, x6e150040c8d97700, x11d58b056c032b03, DockSide.Right);
			if (-2147483648 == 0)
			{
				goto IL_AE;
			}
			return;
			IL_AE:
			if (true)
			{
				return;
			}
		}

		// Token: 0x060002C8 RID: 712 RVA: 0x00019D08 File Offset: 0x00018D08
		private void x2a1e65376d30fca5(DockContainer xd3311d815ca25f02, ControlLayoutSystem x6e150040c8d97700, xedb4922162c60d3d.DockTarget x11d58b056c032b03, Rectangle x21ed2ecc088ef4e4, Point x6b2bb9f943411698)
		{
			x6b2bb9f943411698.X -= x21ed2ecc088ef4e4.Left;
			for (;;)
			{
				x6b2bb9f943411698.Y -= x21ed2ecc088ef4e4.Top;
				x21ed2ecc088ef4e4 = new Rectangle(0, 0, 30, 30);
				while (x6b2bb9f943411698.Y > x21ed2ecc088ef4e4.Top + (int)((float)x21ed2ecc088ef4e4.Height * ((float)x6b2bb9f943411698.X / (float)x21ed2ecc088ef4e4.Width)))
				{
					if (15 != 0)
					{
						goto Block_2;
					}
				}
				this.xa86a93682c30b8c6(xd3311d815ca25f02, x6e150040c8d97700, x11d58b056c032b03, DockSide.Top);
				if (!false)
				{
					return;
				}
			}
			Block_2:
			this.xa86a93682c30b8c6(xd3311d815ca25f02, x6e150040c8d97700, x11d58b056c032b03, DockSide.Left);
		}

		// Token: 0x060002C9 RID: 713 RVA: 0x00019D9C File Offset: 0x00018D9C
		private void xa86a93682c30b8c6(DockContainer xd3311d815ca25f02, ControlLayoutSystem x6e150040c8d97700, xedb4922162c60d3d.DockTarget x11d58b056c032b03, DockSide x4f217665270fa928)
		{
			x11d58b056c032b03.bounds = this.x3102817291e84207(xd3311d815ca25f02, x6e150040c8d97700, x4f217665270fa928);
			x11d58b056c032b03.dockSide = x4f217665270fa928;
		}

		// Token: 0x060002CA RID: 714 RVA: 0x00019DB8 File Offset: 0x00018DB8
		internal Rectangle x3102817291e84207(DockContainer xd3311d815ca25f02, ControlLayoutSystem x6e150040c8d97700, DockSide x4f217665270fa928)
		{
			Rectangle result = new Rectangle(xd3311d815ca25f02.PointToScreen(x6e150040c8d97700.Bounds.Location), x6e150040c8d97700.Bounds.Size);
			if (2147483647 != 0)
			{
				switch (x4f217665270fa928)
				{
				case DockSide.Top:
					result.Height /= 2;
					if (3 != 0)
					{
						return result;
					}
					break;
				case DockSide.Bottom:
					goto IL_30;
				case DockSide.Left:
					break;
				case DockSide.Right:
					result.Offset(result.Width / 2, 0);
					result.Width /= 2;
					return result;
				default:
					if (!false)
					{
						return result;
					}
					goto IL_41;
				}
				result.Width /= 2;
				return result;
			}
			IL_30:
			result.Offset(0, result.Height / 2);
			IL_41:
			result.Height /= 2;
			return result;
		}

		// Token: 0x060002CB RID: 715 RVA: 0x00019E84 File Offset: 0x00018E84
		private xedb4922162c60d3d.DockTarget x7aa9d6b148df47c3(DockContainer xd3311d815ca25f02, ControlLayoutSystem x6e150040c8d97700)
		{
			return new xedb4922162c60d3d.DockTarget(xedb4922162c60d3d.DockTargetType.SplitExistingSystem)
			{
				dockContainer = xd3311d815ca25f02,
				layoutSystem = x6e150040c8d97700
			};
		}

		// Token: 0x060002CC RID: 716 RVA: 0x00019EA8 File Offset: 0x00018EA8
		public override void Commit()
		{
			base.Commit();
			LayoutUtilities.x3a04ba0cdf69aff2();
			try
			{
				if (this.x67ecc0d0e7c9a202 != null)
				{
					this.x67ecc0d0e7c9a202(this.x521249670374b9ee);
				}
			}
			finally
			{
				LayoutUtilities.x861aa05d0acfeb39();
			}
		}

		// Token: 0x060002CD RID: 717 RVA: 0x00019F00 File Offset: 0x00018F00
		public override void Dispose()
		{
			this.x0467b00af7810f0c.OnDockingFinished(EventArgs.Empty);
			if (!(this.x90ce1c0ec8c6028d != null))
			{
				goto IL_29;
			}
			IL_1E:
			this.x90ce1c0ec8c6028d.Dispose();
			IL_29:
			if (this.x52988e63e407fffa != null)
			{
				this.x52988e63e407fffa.Dispose();
			}
			base.Dispose();
			if (!false)
			{
				return;
			}
			goto IL_1E;
		}

		// Token: 0x040000BC RID: 188
		private const int x92d9c1851cace8e0 = 30;

		// Token: 0x040000BD RID: 189
		private SandDockManager x91f347c6e97f1846;

		// Token: 0x040000BE RID: 190
		private DockContainer x0467b00af7810f0c;

		// Token: 0x040000BF RID: 191
		private LayoutSystemBase x83e1554f4315a375;

		// Token: 0x040000C0 RID: 192
		private DockControl x493191df254612e4;

		// Token: 0x040000C1 RID: 193
		private Size xca874006c41dfe29 = Size.Empty;

		// Token: 0x040000C2 RID: 194
		private int x9562cf1322eeedf1;

		// Token: 0x040000C3 RID: 195
		private Point x2a2e0ce22e62c94e = Point.Empty;

		// Token: 0x040000C4 RID: 196
		private xedb4922162c60d3d.DockTarget x521249670374b9ee;

		// Token: 0x040000C5 RID: 197
		private Cursor x90ce1c0ec8c6028d;

		// Token: 0x040000C6 RID: 198
		private Cursor x52988e63e407fffa;

		// Token: 0x040000C7 RID: 199
		private ControlLayoutSystem[] xcd940949dfd37534;

		// Token: 0x0200001C RID: 28
		// (Invoke) Token: 0x060002F2 RID: 754
		public delegate void DockingManagerFinishedEventHandler(xedb4922162c60d3d.DockTarget target);

		// Token: 0x0200001D RID: 29
		public class DockTarget
		{
			// Token: 0x060002F5 RID: 757 RVA: 0x0001AA94 File Offset: 0x00019A94
			public DockTarget(xedb4922162c60d3d.DockTargetType type)
			{
				this.type = type;
			}

			// Token: 0x040000E4 RID: 228
			public xedb4922162c60d3d.DockTargetType type;

			// Token: 0x040000E5 RID: 229
			public DockContainer dockContainer;

			// Token: 0x040000E6 RID: 230
			public ControlLayoutSystem layoutSystem;

			// Token: 0x040000E7 RID: 231
			public DockSide dockSide = DockSide.None;

			// Token: 0x040000E8 RID: 232
			public Rectangle bounds = Rectangle.Empty;

			// Token: 0x040000E9 RID: 233
			public int index;

			// Token: 0x040000EA RID: 234
			public ContainerDockLocation dockLocation = ContainerDockLocation.Center;

			// Token: 0x040000EB RID: 235
			public bool middle;
		}

		// Token: 0x0200001E RID: 30
		public enum DockTargetType
		{
			// Token: 0x040000ED RID: 237
			Undefined,
			// Token: 0x040000EE RID: 238
			None,
			// Token: 0x040000EF RID: 239
			Float,
			// Token: 0x040000F0 RID: 240
			SplitExistingSystem,
			// Token: 0x040000F1 RID: 241
			JoinExistingSystem,
			// Token: 0x040000F2 RID: 242
			CreateNewContainer,
			// Token: 0x040000F3 RID: 243
			AlreadyActioned
		}
	}
}
