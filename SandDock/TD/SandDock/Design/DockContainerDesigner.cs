using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace TD.SandDock.Design
{
	// Token: 0x02000015 RID: 21
	internal class DockContainerDesigner : ParentControlDesigner
	{
		// Token: 0x06000291 RID: 657 RVA: 0x000168F0 File Offset: 0x000158F0
		public DockContainerDesigner()
		{
			base.EnableDragDrop(false);
		}

		// Token: 0x06000292 RID: 658 RVA: 0x0001690C File Offset: 0x0001590C
		private DockControl x37c93a224e23ba95(Point x13d4cb8d1bd20347)
		{
			LayoutSystemBase layoutSystemAt = this.x0467b00af7810f0c.GetLayoutSystemAt(x13d4cb8d1bd20347);
			if (!(layoutSystemAt is ControlLayoutSystem))
			{
				return null;
			}
			return ((ControlLayoutSystem)layoutSystemAt).GetControlAt(x13d4cb8d1bd20347);
		}

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x06000293 RID: 659 RVA: 0x00016940 File Offset: 0x00015940
		// (set) Token: 0x06000294 RID: 660 RVA: 0x00016944 File Offset: 0x00015944
		[Browsable(false)]
		[DefaultValue(false)]
		protected override bool DrawGrid
		{
			get
			{
				return false;
			}
			set
			{
				base.DrawGrid = value;
			}
		}

		// Token: 0x06000295 RID: 661 RVA: 0x00016950 File Offset: 0x00015950
		protected override void OnMouseDragBegin(int x, int y)
		{
			ISelectionService selectionService = (ISelectionService)this.GetService(typeof(ISelectionService));
			Point point = this.x0467b00af7810f0c.PointToClient(new Point(x, y));
			LayoutSystemBase layoutSystemAt = this.x0467b00af7810f0c.GetLayoutSystemAt(point);
			for (;;)
			{
				IL_3DD:
				bool flag = (uint)x + (uint)y < 0U;
				if (flag)
				{
					goto IL_3F8;
				}
				goto IL_358;
				IL_DE:
				ControlLayoutSystem controlLayoutSystem;
				while (controlLayoutSystem.SelectedControl != null)
				{
					selectionService.SetSelectedComponents(new object[]
					{
						controlLayoutSystem.SelectedControl
					}, SelectionTypes.Click);
					if (!false)
					{
						flag = ((uint)x + (uint)x > uint.MaxValue);
						if (flag)
						{
							goto IL_104;
						}
						if ((uint)y > 4294967295U)
						{
							goto IL_33C;
						}
						IL_AB:
						this.x6afebf16b45c02e0 = new Point(x, y);
						flag = ((uint)x < 0U);
						if (flag)
						{
							goto IL_15C;
						}
						flag = ((uint)y < 0U);
						if (flag)
						{
							goto IL_21C;
						}
						return;
					}
				}
				goto IL_AB;
				IL_21C:
				flag = ((uint)y < 0U);
				if (flag)
				{
					continue;
				}
				return;
				IL_35:
				selectionService.SetSelectedComponents(new object[]
				{
					this.x0467b00af7810f0c
				}, SelectionTypes.MouseDown | SelectionTypes.Click);
				if (3 == 0)
				{
					goto IL_1C6;
				}
				goto IL_21C;
				IL_1C:
				SplitLayoutSystem splitLayoutSystem;
				if (!splitLayoutSystem.x090b65ef9b096e0b(point.X, point.Y))
				{
					goto IL_35;
				}
				LayoutSystemBase aboveLayout;
				LayoutSystemBase belowLayout;
				splitLayoutSystem.x5a3264f7eba0fe4f(point, out aboveLayout, out belowLayout);
				this.x372569d2ea29984e = new x8e80e1c8bce8caf7(this.x0467b00af7810f0c, splitLayoutSystem, aboveLayout, belowLayout, point, DockingHints.TranslucentFill);
				this.x372569d2ea29984e.x868a32060451dd2e += this.xfae511fd7c4fb447;
				if ((uint)x + (uint)y > 4294967295U)
				{
					return;
				}
				flag = (((uint)y & 0U) == 0U);
				if (!flag)
				{
					goto IL_278;
				}
				for (;;)
				{
					this.x372569d2ea29984e.x67ecc0d0e7c9a202 += this.xc555e814c1720baf;
					this.x0467b00af7810f0c.Capture = true;
					if (3 != 0)
					{
						goto IL_44D;
					}
					flag = ((uint)y > uint.MaxValue);
					if (!flag)
					{
						goto IL_3DD;
					}
				}
				IL_104:
				if (!false)
				{
					goto IL_12E;
				}
				if (3 != 0)
				{
					goto IL_53;
				}
				goto IL_1C;
				IL_278:
				DockControl controlAt;
				if (layoutSystemAt is ControlLayoutSystem)
				{
					controlLayoutSystem = (ControlLayoutSystem)layoutSystemAt;
					controlAt = controlLayoutSystem.GetControlAt(point);
					goto IL_180;
				}
				goto IL_35;
				IL_261:
				if (!(this.x0467b00af7810f0c.x0c42f19be578ccee != Rectangle.Empty) || !this.x0467b00af7810f0c.x0c42f19be578ccee.Contains(point))
				{
					goto IL_278;
				}
				if (((uint)y | 1U) == 0U)
				{
					goto IL_33C;
				}
				this.x754f1c6f433be75d = new x09c1c18390e52ebf(this.x0467b00af7810f0c.Manager, this.x0467b00af7810f0c, point);
				this.x754f1c6f433be75d.x868a32060451dd2e += this.x30c28c62b1a6040e;
				this.x754f1c6f433be75d.x67ecc0d0e7c9a202 += this.xa7afb2334769edc5;
				flag = ((uint)y + (uint)x > uint.MaxValue);
				if (flag)
				{
					goto IL_337;
				}
				goto IL_28F;
				IL_358:
				if (!(layoutSystemAt is SplitLayoutSystem))
				{
					goto IL_261;
				}
				goto IL_3F8;
				IL_33C:
				flag = (((uint)y & 0U) == 0U);
				if (flag)
				{
					goto IL_261;
				}
				goto IL_358;
				IL_1C6:
				if (-2147483648 == 0)
				{
					goto IL_358;
				}
				IComponentChangeService componentChangeService;
				componentChangeService.OnComponentChanging(this.x0467b00af7810f0c, TypeDescriptor.GetProperties(this.x0467b00af7810f0c)["LayoutSystem"]);
				controlAt.LayoutSystem.SelectedControl = controlAt;
				componentChangeService.OnComponentChanged(this.x0467b00af7810f0c, TypeDescriptor.GetProperties(this.x0467b00af7810f0c)["LayoutSystem"], null, null);
				if ((uint)y + (uint)x >= 0U)
				{
					goto IL_104;
				}
				goto IL_180;
				IL_337:
				goto IL_1C6;
				IL_180:
				if (controlAt == null)
				{
					goto IL_12E;
				}
				if (controlAt.LayoutSystem.SelectedControl == controlAt)
				{
					goto IL_15C;
				}
				componentChangeService = (IComponentChangeService)this.GetService(typeof(IComponentChangeService));
				goto IL_337;
				IL_3F8:
				splitLayoutSystem = (SplitLayoutSystem)layoutSystemAt;
				goto IL_1C;
				IL_53:
				if (controlAt == null)
				{
					break;
				}
				flag = ((uint)y + (uint)x > uint.MaxValue);
				if (!flag)
				{
					goto IL_DE;
				}
				IL_12E:
				if (controlLayoutSystem.xb48529af1739dd06.Contains(point))
				{
					goto IL_DE;
				}
				goto IL_53;
				IL_15C:
				goto IL_12E;
			}
			selectionService.SetSelectedComponents(new object[]
			{
				this.x0467b00af7810f0c
			}, SelectionTypes.MouseDown | SelectionTypes.Click);
			this.x0467b00af7810f0c.Capture = true;
			return;
			IL_28F:
			this.x0467b00af7810f0c.Capture = true;
			return;
			IL_44D:;
		}

		// Token: 0x06000296 RID: 662 RVA: 0x00016DDC File Offset: 0x00015DDC
		private void x1b91eb6f6bb77abc()
		{
			this.x754f1c6f433be75d.x868a32060451dd2e -= this.x30c28c62b1a6040e;
			this.x754f1c6f433be75d.x67ecc0d0e7c9a202 -= this.xa7afb2334769edc5;
			this.x754f1c6f433be75d = null;
		}

		// Token: 0x06000297 RID: 663 RVA: 0x00016E14 File Offset: 0x00015E14
		private void xa7afb2334769edc5(int x0d4b3b88c5b24565)
		{
			this.x1b91eb6f6bb77abc();
			DesignerTransaction designerTransaction = this.xff9c60b45aa37b1e.CreateTransaction("Resize Docked Windows");
			do
			{
				base.RaiseComponentChanging(TypeDescriptor.GetProperties(base.Component)["ContentSize"]);
				this.x0467b00af7810f0c.ContentSize = x0d4b3b88c5b24565;
				base.RaiseComponentChanged(TypeDescriptor.GetProperties(base.Component)["ContentSize"], null, null);
			}
			while (false);
			designerTransaction.Commit();
		}

		// Token: 0x06000298 RID: 664 RVA: 0x00016E88 File Offset: 0x00015E88
		private void x30c28c62b1a6040e(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			this.x1b91eb6f6bb77abc();
		}

		// Token: 0x06000299 RID: 665 RVA: 0x00016E90 File Offset: 0x00015E90
		protected override void OnMouseDragEnd(bool cancel)
		{
			this.x6afebf16b45c02e0 = Point.Empty;
			try
			{
				if (this.x372569d2ea29984e != null)
				{
					bool flag = (cancel ? 1U : 0U) - (cancel ? 1U : 0U) < 0U;
					if (!flag)
					{
						this.x372569d2ea29984e.Commit();
						goto IL_118;
					}
				}
				else if (this.x754f1c6f433be75d != null)
				{
					this.x754f1c6f433be75d.Commit();
					this.x0467b00af7810f0c.Capture = false;
				}
				else
				{
					while (this.x531514c39973cbc6 == null)
					{
						DockControl dockControl = this.x37c93a224e23ba95(this.x0467b00af7810f0c.PointToClient(Cursor.Position));
						if (!false)
						{
							bool flag = ((cancel ? 1U : 0U) | 15U) == 0U;
							if (!flag)
							{
								if (!false)
								{
									if (dockControl == null)
									{
										LayoutSystemBase layoutSystemAt = this.x0467b00af7810f0c.GetLayoutSystemAt(this.x0467b00af7810f0c.PointToClient(Cursor.Position));
										if (layoutSystemAt is ControlLayoutSystem)
										{
										}
									}
								}
							}
							goto IL_31;
						}
					}
					this.x531514c39973cbc6.Commit();
					if ((cancel ? 1U : 0U) - (cancel ? 1U : 0U) > 4294967295U)
					{
						goto IL_118;
					}
					this.x0467b00af7810f0c.Capture = false;
				}
				IL_31:
				return;
				IL_118:
				this.x0467b00af7810f0c.Capture = false;
			}
			finally
			{
				if (this.Control != null)
				{
					this.Control.Capture = false;
				}
			}
		}

		// Token: 0x0600029A RID: 666 RVA: 0x00017020 File Offset: 0x00016020
		protected override void OnMouseDragMove(int x, int y)
		{
			Point position = this.x0467b00af7810f0c.PointToClient(new Point(x, y));
			if (false)
			{
				goto IL_1E7;
			}
			bool flag = ((uint)y & 0U) == 0U;
			if (flag)
			{
				flag = ((uint)x < 0U);
				if (flag)
				{
					goto IL_1E7;
				}
				if (this.x372569d2ea29984e != null)
				{
					this.x372569d2ea29984e.OnMouseMove(position);
					return;
				}
				if (this.x754f1c6f433be75d == null)
				{
					goto IL_1F1;
				}
				this.x754f1c6f433be75d.OnMouseMove(position);
				return;
			}
			IL_35:
			if ((uint)x + (uint)x >= 0U)
			{
				flag = ((uint)x + (uint)y > uint.MaxValue);
				if (!flag)
				{
					if ((uint)y < 0U)
					{
						goto IL_1B0;
					}
				}
				goto IL_18F;
			}
			IL_37:
			if (!(this.x6afebf16b45c02e0 != Point.Empty))
			{
				return;
			}
			Rectangle rectangle = new Rectangle(this.x6afebf16b45c02e0, SystemInformation.DragSize);
			rectangle.Offset(-SystemInformation.DragSize.Width / 2, -SystemInformation.DragSize.Height / 2);
			flag = ((uint)x + (uint)x > uint.MaxValue);
			if (flag)
			{
				goto IL_A8;
			}
			IL_51:
			if (rectangle.Contains(x, y))
			{
				return;
			}
			IL_A8:
			this.xe2e0ed61975ce467(this.x0467b00af7810f0c.PointToClient(this.x6afebf16b45c02e0));
			flag = ((uint)y + (uint)y > uint.MaxValue);
			if (!flag)
			{
				this.x6afebf16b45c02e0 = Point.Empty;
				goto IL_35;
			}
			IL_18F:
			return;
			IL_1B0:
			if ((uint)y - (uint)y >= 0U)
			{
				if (this.x531514c39973cbc6.x42f4c234c9358072 != null)
				{
					if ((uint)x + (uint)x > 4294967295U)
					{
						goto IL_51;
					}
					if (this.x531514c39973cbc6.x42f4c234c9358072.type != xedb4922162c60d3d.DockTargetType.None)
					{
						Cursor.Current = Cursors.Default;
						return;
					}
				}
				Cursor.Current = Cursors.No;
				flag = ((uint)y + (uint)x < 0U);
				if (!flag)
				{
					return;
				}
			}
			IL_1E7:
			IL_1F1:
			if (this.x531514c39973cbc6 != null)
			{
				this.x531514c39973cbc6.OnMouseMove(Cursor.Position);
				goto IL_1B0;
			}
			goto IL_37;
		}

		// Token: 0x0600029B RID: 667 RVA: 0x00017288 File Offset: 0x00016288
		private void xe2e0ed61975ce467(Point x13d4cb8d1bd20347)
		{
			LayoutSystemBase layoutSystemAt = this.x0467b00af7810f0c.GetLayoutSystemAt(x13d4cb8d1bd20347);
			if (255 != 0)
			{
				while (layoutSystemAt is ControlLayoutSystem)
				{
					if (this.x531514c39973cbc6 != null)
					{
						break;
					}
					ControlLayoutSystem controlLayoutSystem = (ControlLayoutSystem)layoutSystemAt;
					DockControl controlAt;
					do
					{
						controlAt = controlLayoutSystem.GetControlAt(x13d4cb8d1bd20347);
					}
					while (false);
					this.x531514c39973cbc6 = new x31248f32f85df1dd(this.x0467b00af7810f0c.Manager, this.x0467b00af7810f0c, controlLayoutSystem, controlAt, controlLayoutSystem.SelectedControl.MetaData.DockedContentSize, x13d4cb8d1bd20347, DockingHints.TranslucentFill);
					if (!false)
					{
						if (3 == 0)
						{
							break;
						}
						goto IL_23;
					}
				}
				return;
			}
			IL_23:
			this.x531514c39973cbc6.x67ecc0d0e7c9a202 += this.x46ff430ed3944e0f;
			this.x531514c39973cbc6.x868a32060451dd2e += this.x0ae87c4881d90427;
			this.x0467b00af7810f0c.Capture = true;
		}

		// Token: 0x0600029C RID: 668 RVA: 0x00017354 File Offset: 0x00016354
		private void xf6aefb7d0abb95ba()
		{
			this.x531514c39973cbc6.x67ecc0d0e7c9a202 -= this.x46ff430ed3944e0f;
			this.x531514c39973cbc6.x868a32060451dd2e -= this.x0ae87c4881d90427;
			this.x531514c39973cbc6 = null;
		}

		// Token: 0x0600029D RID: 669 RVA: 0x00017390 File Offset: 0x00016390
		internal virtual void x46ff430ed3944e0f(xedb4922162c60d3d.DockTarget x11d58b056c032b03)
		{
			IComponentChangeService componentChangeService = (IComponentChangeService)this.GetService(typeof(IComponentChangeService));
			bool flag2;
			bool flag = (flag2 ? 1U : 0U) - (flag2 ? 1U : 0U) > uint.MaxValue;
			IDesignerHost designerHost;
			if (flag)
			{
				flag = ((flag2 ? 1U : 0U) + (flag2 ? 1U : 0U) < 0U);
				if (flag)
				{
					goto IL_3E2;
				}
				goto IL_3FA;
			}
			else
			{
				designerHost = (IDesignerHost)this.GetService(typeof(IDesignerHost));
				if (2 != 0)
				{
					goto IL_3FA;
				}
			}
			IL_5D:
			ISelectionService selectionService;
			ControlLayoutSystem controlLayoutSystem;
			DockControl selectedControl;
			if (x11d58b056c032b03.type != xedb4922162c60d3d.DockTargetType.AlreadyActioned && ((flag2 ? 1U : 0U) | 4U) != 0U)
			{
				DesignerTransaction designerTransaction = designerHost.CreateTransaction("Move DockControl");
				try
				{
					Control control;
					if (this.x0467b00af7810f0c.Manager != null)
					{
						control = this.x0467b00af7810f0c.Manager.DockSystemContainer;
						goto IL_3A0;
					}
					IL_38D:
					control = null;
					IL_3A0:
					Control control2 = control;
					if ((flag2 ? 1U : 0U) + (flag2 ? 1U : 0U) < 0U)
					{
						goto IL_2AD;
					}
					if (control2 != null)
					{
						goto IL_330;
					}
					selectionService.SetSelectedComponents(new object[]
					{
						designerHost.RootComponent
					}, SelectionTypes.Replace);
					goto IL_328;
					IL_219:
					componentChangeService.OnComponentChanged(this.x0467b00af7810f0c, TypeDescriptor.GetProperties(this.x0467b00af7810f0c)["LayoutSystem"], null, null);
					if (((flag2 ? 1U : 0U) | 4U) == 0U)
					{
						goto IL_355;
					}
					if ((flag2 ? 1U : 0U) + (flag2 ? 1U : 0U) < 0U)
					{
						goto IL_31A;
					}
					IL_272:
					if (false)
					{
						goto IL_193;
					}
					if (4 == 0)
					{
						goto IL_282;
					}
					componentChangeService.OnComponentChanged(this.x0467b00af7810f0c, TypeDescriptor.GetProperties(this.x0467b00af7810f0c)["Manager"], null, null);
					if (control2 == null)
					{
						if (2 == 0)
						{
							goto IL_172;
						}
					}
					else
					{
						componentChangeService.OnComponentChanged(control2, TypeDescriptor.GetProperties(control2)["Controls"], null, null);
					}
					if (x11d58b056c032b03.dockContainer == null)
					{
						goto IL_138;
					}
					IL_172:
					componentChangeService.OnComponentChanging(x11d58b056c032b03.dockContainer, TypeDescriptor.GetProperties(x11d58b056c032b03.dockContainer)["LayoutSystem"]);
					goto IL_193;
					IL_AD:
					designerTransaction.Commit();
					if (!false)
					{
						goto IL_1BD;
					}
					IL_138:
					if (x11d58b056c032b03.type != xedb4922162c60d3d.DockTargetType.CreateNewContainer)
					{
						goto IL_AD;
					}
					for (;;)
					{
						if (control2 != null)
						{
							componentChangeService.OnComponentChanging(control2, TypeDescriptor.GetProperties(control2)["Controls"]);
						}
						controlLayoutSystem.x6b145af772038ef2(selectedControl.Manager, selectedControl, flag2, x11d58b056c032b03);
						designerHost.Container.Add(selectedControl.LayoutSystem.DockContainer);
						if (control2 == null)
						{
							goto IL_AD;
						}
						componentChangeService.OnComponentChanged(control2, TypeDescriptor.GetProperties(control2)["Controls"], null, null);
						if (2147483647 != 0)
						{
							goto IL_AD;
						}
					}
					IL_193:
					controlLayoutSystem.x6b145af772038ef2(x11d58b056c032b03.dockContainer.Manager, selectedControl, flag2, x11d58b056c032b03);
					if (((flag2 ? 1U : 0U) & 0U) == 0U)
					{
						componentChangeService.OnComponentChanged(x11d58b056c032b03.dockContainer, TypeDescriptor.GetProperties(x11d58b056c032b03.dockContainer)["LayoutSystem"], null, null);
						goto IL_AD;
					}
					IL_1BD:
					IL_282:
					if (!false)
					{
						return;
					}
					if (!false)
					{
						goto IL_38D;
					}
					if (2 != 0)
					{
						goto IL_330;
					}
					flag = ((flag2 ? 1U : 0U) < 0U);
					if (!flag)
					{
						goto IL_328;
					}
					IL_2AD:
					LayoutUtilities.xf1cbd48a28ce6e74(selectedControl);
					goto IL_219;
					IL_31A:
					if (!false && !flag2)
					{
						goto IL_2AD;
					}
					LayoutUtilities.x4487f2f8917e3fd0(controlLayoutSystem);
					goto IL_219;
					IL_328:
					if (control2 != null)
					{
						componentChangeService.OnComponentChanging(control2, TypeDescriptor.GetProperties(control2)["Controls"]);
					}
					componentChangeService.OnComponentChanging(this.x0467b00af7810f0c, TypeDescriptor.GetProperties(this.x0467b00af7810f0c)["Manager"]);
					componentChangeService.OnComponentChanging(this.x0467b00af7810f0c, TypeDescriptor.GetProperties(this.x0467b00af7810f0c)["LayoutSystem"]);
					goto IL_31A;
					IL_330:
					selectionService.SetSelectedComponents(new object[]
					{
						this.x0467b00af7810f0c.Manager.DockSystemContainer
					}, SelectionTypes.Replace);
					IL_355:
					flag = (((flag2 ? 1U : 0U) & 0U) == 0U);
					if (flag)
					{
						goto IL_328;
					}
					goto IL_272;
				}
				catch
				{
					designerTransaction.Cancel();
					return;
				}
				return;
			}
			return;
			IL_3E2:
			this.xf6aefb7d0abb95ba();
			if (x11d58b056c032b03 == null)
			{
				return;
			}
			if (!false)
			{
				if (x11d58b056c032b03.type == xedb4922162c60d3d.DockTargetType.None)
				{
					return;
				}
			}
			goto IL_5D;
			IL_3FA:
			selectionService = (ISelectionService)this.GetService(typeof(ISelectionService));
			controlLayoutSystem = (ControlLayoutSystem)this.x531514c39973cbc6.xf333586e50dccad2;
			flag2 = (this.x531514c39973cbc6.x59ae058c4a0dec87 == null);
			selectedControl = controlLayoutSystem.SelectedControl;
			goto IL_3E2;
		}

		// Token: 0x0600029E RID: 670 RVA: 0x00017818 File Offset: 0x00016818
		internal virtual void x0ae87c4881d90427(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			this.xf6aefb7d0abb95ba();
		}

		// Token: 0x0600029F RID: 671 RVA: 0x00017820 File Offset: 0x00016820
		private void x367ada130c39f434()
		{
			this.x372569d2ea29984e.x868a32060451dd2e -= this.xfae511fd7c4fb447;
			this.x372569d2ea29984e.x67ecc0d0e7c9a202 -= this.xc555e814c1720baf;
			this.x372569d2ea29984e = null;
		}

		// Token: 0x060002A0 RID: 672 RVA: 0x00017858 File Offset: 0x00016858
		private void xfae511fd7c4fb447(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			this.x367ada130c39f434();
		}

		// Token: 0x060002A1 RID: 673 RVA: 0x00017860 File Offset: 0x00016860
		private void xc555e814c1720baf(LayoutSystemBase xc13a8191724b6d55, LayoutSystemBase x5aa50bbadb0a1e6c, float x5c2440c931f8d932, float x4afa341b2323a009)
		{
			SplitLayoutSystem x07bf3386da210f = this.x372569d2ea29984e.x07bf3386da210f81;
			DesignerTransaction designerTransaction;
			IComponentChangeService componentChangeService;
			SizeF workingSize;
			SizeF workingSize2;
			for (;;)
			{
				IL_F1:
				this.x367ada130c39f434();
				designerTransaction = this.xff9c60b45aa37b1e.CreateTransaction("Resize Docked Windows");
				componentChangeService = (IComponentChangeService)this.GetService(typeof(IComponentChangeService));
				componentChangeService.OnComponentChanging(this.x0467b00af7810f0c, TypeDescriptor.GetProperties(this.x0467b00af7810f0c)["LayoutSystem"]);
				workingSize = xc13a8191724b6d55.WorkingSize;
				workingSize2 = x5aa50bbadb0a1e6c.WorkingSize;
				while (x07bf3386da210f.SplitMode == Orientation.Horizontal)
				{
					workingSize.Height = x5c2440c931f8d932;
					if (false)
					{
						goto IL_52;
					}
					bool flag = (uint)x5c2440c931f8d932 > uint.MaxValue;
					if (flag)
					{
						goto IL_F1;
					}
					if ((uint)x5c2440c931f8d932 >= 0U)
					{
						goto Block_3;
					}
				}
				goto IL_89;
			}
			IL_52:
			xc13a8191724b6d55.WorkingSize = workingSize;
			x5aa50bbadb0a1e6c.WorkingSize = workingSize2;
			if ((uint)x5c2440c931f8d932 + (uint)x5c2440c931f8d932 >= 0U)
			{
				goto IL_98;
			}
			return;
			IL_7E:
			workingSize2.Height = x4afa341b2323a009;
			goto IL_52;
			IL_89:
			workingSize.Width = x5c2440c931f8d932;
			if (2147483647 != 0)
			{
				workingSize2.Width = x4afa341b2323a009;
				goto IL_52;
			}
			IL_98:
			if (-1 != 0)
			{
				componentChangeService.OnComponentChanged(this.x0467b00af7810f0c, TypeDescriptor.GetProperties(this.x0467b00af7810f0c)["LayoutSystem"], null, null);
				designerTransaction.Commit();
				x07bf3386da210f.x3e0280cae730d1f2();
				if (8 == 0)
				{
					goto IL_7E;
				}
			}
			return;
			Block_3:
			goto IL_7E;
		}

		// Token: 0x060002A2 RID: 674 RVA: 0x000179C0 File Offset: 0x000169C0
		protected override void OnSetCursor()
		{
			Point point = this.x0467b00af7810f0c.PointToClient(Cursor.Position);
			SplitLayoutSystem splitLayoutSystem;
			for (;;)
			{
				LayoutSystemBase layoutSystemAt = this.x0467b00af7810f0c.GetLayoutSystemAt(point);
				splitLayoutSystem = (layoutSystemAt as SplitLayoutSystem);
				if (false)
				{
					if (8 == 0)
					{
						goto Block_14;
					}
					if (15 == 0)
					{
						goto Block_12;
					}
					goto IL_C8;
				}
				else
				{
					if (splitLayoutSystem == null)
					{
						goto IL_E5;
					}
					if (true)
					{
						goto IL_C8;
					}
				}
				IL_46:
				Cursor.Current = Cursors.Default;
				if (false)
				{
					continue;
				}
				return;
				IL_30:
				goto IL_46;
				IL_16:
				if (!(this.x0467b00af7810f0c.x0c42f19be578ccee != Rectangle.Empty))
				{
					goto IL_30;
				}
				goto IL_A5;
				IL_82:
				if (!false)
				{
					goto IL_16;
				}
				IL_B4:
				if (!false)
				{
					if (!true)
					{
						goto IL_82;
					}
					if (2 == 0)
					{
						return;
					}
					if (2147483647 == 0)
					{
						goto IL_A5;
					}
					goto IL_16;
				}
				IL_E5:
				if (3 != 0)
				{
					goto IL_82;
				}
				goto IL_C8;
				IL_A5:
				Rectangle x0c42f19be578ccee = this.x0467b00af7810f0c.x0c42f19be578ccee;
				if (false)
				{
					goto IL_B4;
				}
				if (x0c42f19be578ccee.Contains(point))
				{
					break;
				}
				if (15 != 0)
				{
					goto IL_46;
				}
				goto IL_103;
				IL_C8:
				if (splitLayoutSystem.x090b65ef9b096e0b(point.X, point.Y))
				{
					goto IL_103;
				}
				if (8 == 0)
				{
					goto IL_E5;
				}
				goto IL_B4;
			}
			if (!this.x0467b00af7810f0c.x61c108cc44ef385a)
			{
				Cursor.Current = Cursors.HSplit;
				return;
			}
			Cursor.Current = Cursors.VSplit;
			return;
			IL_103:
			if (splitLayoutSystem.SplitMode != Orientation.Horizontal)
			{
				Cursor.Current = Cursors.VSplit;
				return;
			}
			Cursor.Current = Cursors.HSplit;
			return;
			Block_12:
			Block_14:
			goto IL_103;
		}

		// Token: 0x060002A3 RID: 675 RVA: 0x00017B14 File Offset: 0x00016B14
		public override void InitializeNewComponent(IDictionary defaultValues)
		{
			base.InitializeNewComponent(defaultValues);
			this.x391093a02bb10339();
		}

		// Token: 0x060002A4 RID: 676 RVA: 0x00017B24 File Offset: 0x00016B24
		private void x391093a02bb10339()
		{
			IExtenderListService extenderListService = (IExtenderListService)this.GetService(typeof(IExtenderListService));
			IExtenderProvider[] extenderProviders = extenderListService.GetExtenderProviders();
			int i = 0;
			IExtenderProvider extenderProvider;
			for (;;)
			{
				while (i < extenderProviders.Length)
				{
					extenderProvider = extenderProviders[i];
					if (extenderProvider.GetType().FullName == "System.ComponentModel.Design.Serialization.CodeDomDesignerLoader+ModifiersExtenderProvider")
					{
						if (2 != 0)
						{
							goto Block_5;
						}
					}
					else
					{
						i++;
					}
					if (!false)
					{
					}
				}
				break;
			}
			return;
			Block_5:
			MethodInfo method = extenderProvider.GetType().GetMethod("SetGenerateMember", BindingFlags.Instance | BindingFlags.Public);
			while (!false && method == null)
			{
				if (!false)
				{
					return;
				}
			}
			method.Invoke(extenderProvider, new object[]
			{
				base.Component,
				false
			});
		}

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x060002A5 RID: 677 RVA: 0x00017BE0 File Offset: 0x00016BE0
		public override SelectionRules SelectionRules
		{
			get
			{
				return SelectionRules.Visible;
			}
		}

		// Token: 0x060002A6 RID: 678 RVA: 0x00017BE8 File Offset: 0x00016BE8
		public override void Initialize(IComponent component)
		{
			base.Initialize(component);
			if (4 == 0)
			{
				if (!false)
				{
					goto IL_26;
				}
			}
			else
			{
				if (false)
				{
					goto IL_B8;
				}
				goto IL_26;
			}
			IL_14:
			this.x0467b00af7810f0c = (DockContainer)component;
			if (!false)
			{
				return;
			}
			IL_26:
			if (!(component is DockContainer))
			{
				goto IL_B8;
			}
			IL_31:
			ISelectionService selectionService = (ISelectionService)this.GetService(typeof(ISelectionService));
			IL_47:
			this.x4cd3df9bd5e139a3 = (IComponentChangeService)this.GetService(typeof(IComponentChangeService));
			this.xff9c60b45aa37b1e = (IDesignerHost)this.GetService(typeof(IDesignerHost));
			this.x4cd3df9bd5e139a3.ComponentRemoving += this.x97263465e88c9d8e;
			this.x4cd3df9bd5e139a3.ComponentRemoved += this.x5c6da9d6db2adc7a;
			goto IL_14;
			IL_B8:
			SandDockLanguage.ShowCachedAssemblyError(component.GetType().Assembly, base.GetType().Assembly);
			if (8 != 0)
			{
				goto IL_31;
			}
			if (!false)
			{
				goto IL_26;
			}
			goto IL_47;
		}

		// Token: 0x060002A7 RID: 679 RVA: 0x00017CE0 File Offset: 0x00016CE0
		protected override void Dispose(bool disposing)
		{
			ISelectionService selectionService = (ISelectionService)this.GetService(typeof(ISelectionService));
			this.x4cd3df9bd5e139a3.ComponentRemoving += this.x97263465e88c9d8e;
			this.x4cd3df9bd5e139a3.ComponentRemoved += this.x5c6da9d6db2adc7a;
			base.Dispose(disposing);
		}

		// Token: 0x060002A8 RID: 680 RVA: 0x00017D38 File Offset: 0x00016D38
		private void x97263465e88c9d8e(object xe0292b9ed559da7d, ComponentEventArgs xfbf34718e704c6bc)
		{
			DockControl dockControl = xfbf34718e704c6bc.Component as DockControl;
			if (!false && dockControl != null)
			{
				if (dockControl.LayoutSystem != null)
				{
					if (dockControl.LayoutSystem.DockContainer == this.x0467b00af7810f0c)
					{
						this.xaaafffc15ba630b7 = dockControl;
						base.RaiseComponentChanging(TypeDescriptor.GetProperties(this.x0467b00af7810f0c)["LayoutSystem"]);
					}
				}
			}
		}

		// Token: 0x060002A9 RID: 681 RVA: 0x00017DA0 File Offset: 0x00016DA0
		private void x5c6da9d6db2adc7a(object xe0292b9ed559da7d, ComponentEventArgs xfbf34718e704c6bc)
		{
			if (xfbf34718e704c6bc.Component == this.xaaafffc15ba630b7)
			{
				this.xaaafffc15ba630b7 = null;
				base.RaiseComponentChanged(TypeDescriptor.GetProperties(this.x0467b00af7810f0c)["LayoutSystem"], null, null);
			}
		}

		// Token: 0x040000B4 RID: 180
		private DockContainer x0467b00af7810f0c;

		// Token: 0x040000B5 RID: 181
		private DockControl xaaafffc15ba630b7;

		// Token: 0x040000B6 RID: 182
		private Point x6afebf16b45c02e0 = Point.Empty;

		// Token: 0x040000B7 RID: 183
		private xedb4922162c60d3d x531514c39973cbc6;

		// Token: 0x040000B8 RID: 184
		private x8e80e1c8bce8caf7 x372569d2ea29984e;

		// Token: 0x040000B9 RID: 185
		private x09c1c18390e52ebf x754f1c6f433be75d;

		// Token: 0x040000BA RID: 186
		private IComponentChangeService x4cd3df9bd5e139a3;

		// Token: 0x040000BB RID: 187
		private IDesignerHost xff9c60b45aa37b1e;
	}
}
