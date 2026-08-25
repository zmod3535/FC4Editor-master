using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;
using TD.SandDock.Rendering;

namespace TD.SandDock
{
	// Token: 0x02000010 RID: 16
	[TypeConverter(typeof(x44c2ba9761cb4dd2))]
	public class ControlLayoutSystem : LayoutSystemBase
	{
		// Token: 0x14000012 RID: 18
		// (add) Token: 0x060001AF RID: 431 RVA: 0x0000EEE8 File Offset: 0x0000DEE8
		// (remove) Token: 0x060001B0 RID: 432 RVA: 0x0000EF04 File Offset: 0x0000DF04
		internal event ControlLayoutSystem.xf09a9df3c262275d xcc55983eb55360ac;

		// Token: 0x060001B1 RID: 433 RVA: 0x0000EF20 File Offset: 0x0000DF20
		public ControlLayoutSystem()
		{
			this.xe477cc01ecfef1fb = new ControlLayoutSystem.DockControlCollection(this);
			this.x26e80f23e22a05ae = new x0a9f5257a10031b2();
			this.x65911b61bef3a921 = new x0a9f5257a10031b2();
			this.x3b444f64233558c3 = new x0a9f5257a10031b2();
		}

		// Token: 0x060001B2 RID: 434 RVA: 0x0000EF78 File Offset: 0x0000DF78
		public ControlLayoutSystem(int desiredWidth, int desiredHeight) : this()
		{
			base.WorkingSize = new SizeF((float)desiredWidth, (float)desiredHeight);
		}

		// Token: 0x060001B3 RID: 435 RVA: 0x0000EF90 File Offset: 0x0000DF90
		[Obsolete("Use the constructor that takes a SizeF instead.")]
		public ControlLayoutSystem(int desiredWidth, int desiredHeight, DockControl[] controls, DockControl selectedControl) : this(desiredWidth, desiredHeight)
		{
			do
			{
				this.xe477cc01ecfef1fb.AddRange(controls);
			}
			while (false);
			if (selectedControl != null)
			{
				this.SelectedControl = selectedControl;
			}
		}

		// Token: 0x060001B4 RID: 436 RVA: 0x0000EFBC File Offset: 0x0000DFBC
		public ControlLayoutSystem(SizeF workingSize, DockControl[] windows, DockControl selectedWindow) : this()
		{
			if (15 != 0)
			{
				base.WorkingSize = workingSize;
				this.Controls.AddRange(windows);
				if (2 == 0)
				{
					goto IL_35;
				}
				IL_0A:
				if (selectedWindow == null)
				{
					return;
				}
				IL_35:
				this.SelectedControl = selectedWindow;
				if (false)
				{
					goto IL_0A;
				}
			}
		}

		// Token: 0x060001B5 RID: 437 RVA: 0x0000EFFC File Offset: 0x0000DFFC
		public ControlLayoutSystem(int desiredWidth, int desiredHeight, DockControl[] controls, DockControl selectedControl, bool collapsed) : this(new SizeF((float)desiredWidth, (float)desiredHeight), controls, selectedControl)
		{
			this.Collapsed = collapsed;
		}

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x060001B6 RID: 438 RVA: 0x0000F018 File Offset: 0x0000E018
		internal override DockControl[] x9476096be9672d38
		{
			get
			{
				DockControl[] array = new DockControl[this.Controls.Count];
				this.Controls.CopyTo(array, 0);
				return array;
			}
		}

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x060001B7 RID: 439 RVA: 0x0000F044 File Offset: 0x0000E044
		// (set) Token: 0x060001B8 RID: 440 RVA: 0x0000F094 File Offset: 0x0000E094
		internal int xca843b3e9a1c605f
		{
			get
			{
				if (this.SelectedControl != null && this.SelectedControl.PopupSize != 0)
				{
					return this.SelectedControl.PopupSize;
				}
				if (!base.IsInContainer)
				{
					return 200;
				}
				return base.DockContainer.ContentSize;
			}
			set
			{
				IEnumerator enumerator = this.Controls.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						object obj = enumerator.Current;
						DockControl dockControl = (DockControl)obj;
						dockControl.PopupSize = value;
					}
				}
				finally
				{
					IDisposable disposable = enumerator as IDisposable;
					if (false || disposable != null)
					{
						disposable.Dispose();
					}
				}
			}
		}

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x060001B9 RID: 441 RVA: 0x0000F100 File Offset: 0x0000E100
		internal override bool x56005f23d6948487
		{
			get
			{
				using (IEnumerator enumerator = this.Controls.GetEnumerator())
				{
					bool flag;
					for (;;)
					{
						DockControl dockControl;
						if (!enumerator.MoveNext())
						{
							if ((flag ? 1U : 0U) - (flag ? 1U : 0U) >= 0U)
							{
								break;
							}
						}
						else
						{
							dockControl = (DockControl)enumerator.Current;
						}
						if (dockControl.PersistState)
						{
							goto IL_4A;
						}
					}
					goto IL_4F;
					IL_4A:
					flag = true;
					if (!false)
					{
						return flag;
					}
					IL_4F:;
				}
				return false;
			}
		}

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x060001BA RID: 442 RVA: 0x0000F194 File Offset: 0x0000E194
		// (set) Token: 0x060001BB RID: 443 RVA: 0x0000F19C File Offset: 0x0000E19C
		internal Guid x0217cda8370c1f17
		{
			get
			{
				return this.xb51cd75f17ace1ec;
			}
			set
			{
				this.xb51cd75f17ace1ec = value;
			}
		}

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x060001BC RID: 444 RVA: 0x0000F1A8 File Offset: 0x0000E1A8
		// (set) Token: 0x060001BD RID: 445 RVA: 0x0000F1B0 File Offset: 0x0000E1B0
		public bool LockControls
		{
			get
			{
				return this.x04c163da360b887e;
			}
			set
			{
				this.x04c163da360b887e = value;
			}
		}

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x060001BE RID: 446 RVA: 0x0000F1BC File Offset: 0x0000E1BC
		public bool IsPoppedUp
		{
			get
			{
				return this.x10ac79a4257c7f52 != null && this.x10ac79a4257c7f52.x23498f53d87354d4 == this;
			}
		}

		// Token: 0x060001BF RID: 447 RVA: 0x0000F1D8 File Offset: 0x0000E1D8
		public void ClosePopup()
		{
			if (this.IsPoppedUp)
			{
				this.x10ac79a4257c7f52.xcdb145600c1b7224(true);
			}
		}

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x060001C0 RID: 448 RVA: 0x0000F1F0 File Offset: 0x0000E1F0
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public ControlLayoutSystem.DockControlCollection Controls
		{
			get
			{
				return this.xe477cc01ecfef1fb;
			}
		}

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x060001C1 RID: 449 RVA: 0x0000F1F8 File Offset: 0x0000E1F8
		internal x10ac79a4257c7f52 x10ac79a4257c7f52
		{
			get
			{
				return this.x4fb7dbcd13b8ce4b;
			}
		}

		// Token: 0x060001C2 RID: 450 RVA: 0x0000F200 File Offset: 0x0000E200
		internal void xa85d8c17921cc878(x10ac79a4257c7f52 x4fb7dbcd13b8ce4b)
		{
			this.x4fb7dbcd13b8ce4b = x4fb7dbcd13b8ce4b;
		}

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x060001C3 RID: 451 RVA: 0x0000F20C File Offset: 0x0000E20C
		internal Control x0e40cec3a0be4a70
		{
			get
			{
				if (base.IsInContainer)
				{
					while (!this.IsPoppedUp)
					{
						if (!false)
						{
							return base.DockContainer;
						}
					}
					return this.x10ac79a4257c7f52.x87cf4de36131799d;
				}
				return null;
			}
		}

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x060001C4 RID: 452 RVA: 0x0000F238 File Offset: 0x0000E238
		// (set) Token: 0x060001C5 RID: 453 RVA: 0x0000F240 File Offset: 0x0000E240
		[DefaultValue(false)]
		[Browsable(false)]
		public virtual bool Collapsed
		{
			get
			{
				return this.xb9835bbd335d127e;
			}
			set
			{
				if (this.xb9835bbd335d127e == value)
				{
					return;
				}
				this.xb9835bbd335d127e = value;
				if (-1 != 0)
				{
					this.x1f43ebe301d1df45 = null;
					if (!this.xb9835bbd335d127e)
					{
						goto IL_6E;
					}
					if (!base.IsInContainer)
					{
						if ((value ? 1U : 0U) - (value ? 1U : 0U) > 4294967295U)
						{
							goto IL_76;
						}
						if (3 == 0)
						{
							goto IL_6E;
						}
					}
					else
					{
						using (IEnumerator enumerator = this.xe477cc01ecfef1fb.GetEnumerator())
						{
							while (enumerator.MoveNext() || -2 == 0)
							{
								DockControl dockControl = (DockControl)enumerator.Current;
								while (dockControl.Parent == base.DockContainer)
								{
									LayoutUtilities.xa7513d57b4844d46(dockControl);
									if (3 == 0)
									{
										goto IL_1FD;
									}
									if (4 != 0)
									{
										break;
									}
								}
							}
							IL_1FD:
							goto IL_167;
						}
						goto IL_21F;
						IL_167:
						x10ac79a4257c7f52 autoHideBar = base.DockContainer.Manager.GetAutoHideBar(base.DockContainer.Dock);
						if (autoHideBar != null)
						{
							if (4 == 0)
							{
								goto IL_190;
							}
							if ((value ? 1U : 0U) - (value ? 1U : 0U) >= 0U)
							{
								if (!false)
								{
									autoHideBar.x7fdaeb05cb5e84f3.xd6b6ed77479ef68c(this);
								}
							}
						}
					}
					IL_11:
					if (base.IsInContainer)
					{
						base.DockContainer.x7e9646eed248ed11();
						goto IL_190;
					}
					return;
					IL_6E:
					if (this.x10ac79a4257c7f52 != null)
					{
						this.x10ac79a4257c7f52.x7fdaeb05cb5e84f3.x52b190e626f65140(this);
					}
					IL_76:
					IEnumerator enumerator2 = this.xe477cc01ecfef1fb.GetEnumerator();
					try
					{
						for (;;)
						{
							DockControl dockControl2;
							if (!enumerator2.MoveNext())
							{
								if (((value ? 1U : 0U) & 0U) == 0U)
								{
									break;
								}
							}
							else
							{
								dockControl2 = (DockControl)enumerator2.Current;
								if (-2147483648 == 0)
								{
									break;
								}
							}
							while (dockControl2.Parent != base.DockContainer)
							{
								dockControl2.Parent = base.DockContainer;
								if ((value ? 1U : 0U) - (value ? 1U : 0U) >= 0U)
								{
									break;
								}
							}
						}
					}
					finally
					{
						IDisposable disposable2 = enumerator2 as IDisposable;
						bool flag = (value ? 1U : 0U) - (value ? 1U : 0U) < 0U;
						if (flag || disposable2 != null)
						{
							disposable2.Dispose();
						}
					}
					goto IL_11;
					IL_190:
					IL_21F:;
				}
			}
		}

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x060001C6 RID: 454 RVA: 0x0000F4B4 File Offset: 0x0000E4B4
		// (set) Token: 0x060001C7 RID: 455 RVA: 0x0000F4BC File Offset: 0x0000E4BC
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual DockControl SelectedControl
		{
			get
			{
				return this.xbf5c00c8e3dd85fc;
			}
			set
			{
				if (value != null)
				{
					if (!this.xe477cc01ecfef1fb.Contains(value))
					{
						throw new ArgumentOutOfRangeException("value");
					}
				}
				if (this.SelectedControl == null || this.SelectedControl.Manager == null)
				{
					goto IL_99;
				}
				if (8 != 0)
				{
					if (!this.SelectedControl.Manager.RaiseValidationEvents)
					{
						goto IL_99;
					}
					if (-2147483648 == 0)
					{
						goto IL_6B;
					}
				}
				if (this.SelectedControl.ValidateChildren())
				{
					goto IL_99;
				}
				return;
				IL_6B:
				this.x3e0280cae730d1f2();
				DockControl dockControl;
				for (;;)
				{
					for (;;)
					{
						if (!this.IsPoppedUp)
						{
							goto IL_0E;
						}
						goto IL_64;
						IL_2E:
						if (this.xbf5c00c8e3dd85fc == null && !false)
						{
							goto IL_0E;
						}
						this.xbf5c00c8e3dd85fc.OnAutoHidePopupOpened(EventArgs.Empty);
						if (!false)
						{
							goto IL_0E;
						}
						break;
						IL_3B:
						if (!false)
						{
							goto IL_2E;
						}
						break;
						IL_0E:
						this.xe20c835979d60df8(dockControl, this.xbf5c00c8e3dd85fc);
						if (-1 == 0)
						{
							goto IL_3B;
						}
						if (!false)
						{
							return;
						}
						IL_64:
						if (dockControl == null)
						{
							goto IL_3B;
						}
						dockControl.OnAutoHidePopupClosed(EventArgs.Empty);
						goto IL_2E;
					}
				}
				return;
				IL_99:
				dockControl = this.xbf5c00c8e3dd85fc;
				this.xbf5c00c8e3dd85fc = value;
				goto IL_6B;
			}
		}

		// Token: 0x060001C8 RID: 456 RVA: 0x0000F5B8 File Offset: 0x0000E5B8
		protected virtual void OnCloseButtonClick(EventArgs e)
		{
			if (this.SelectedControl != null)
			{
				this.SelectedControl.x8ffe90e7fbccfccd(true);
			}
		}

		// Token: 0x060001C9 RID: 457 RVA: 0x0000F5D0 File Offset: 0x0000E5D0
		protected virtual void OnPinButtonClick()
		{
			this.Collapsed = !this.Collapsed;
			while (base.IsInContainer && this.SelectedControl != null)
			{
				if (this.Collapsed && this.x10ac79a4257c7f52 != null)
				{
					this.x10ac79a4257c7f52.xe6ff614263a59ef9(this.SelectedControl, true, false);
					this.x10ac79a4257c7f52.xcdb145600c1b7224(false);
					if (!false)
					{
						return;
					}
				}
				else
				{
					this.SelectedControl.Activate();
					if (true)
					{
						break;
					}
				}
			}
		}

		// Token: 0x060001CA RID: 458 RVA: 0x0000F64C File Offset: 0x0000E64C
		private void xe20c835979d60df8(DockControl x321bff1c322e5433, DockControl x31b34ee91c89cf69)
		{
			if (this.xcc55983eb55360ac != null)
			{
				this.xcc55983eb55360ac(x321bff1c322e5433, x31b34ee91c89cf69);
			}
		}

		// Token: 0x060001CB RID: 459 RVA: 0x0000F664 File Offset: 0x0000E664
		protected internal override void OnMouseDoubleClick()
		{
			Point point = base.DockContainer.PointToClient(Cursor.Position);
			if (base.DockContainer.Manager == null)
			{
				return;
			}
			if (!this.LockControls)
			{
				if (this.xb48529af1739dd06.Contains(point))
				{
					for (;;)
					{
						if (this.x26e80f23e22a05ae.xda73fcb97c77d998.Contains(point))
						{
							goto IL_3B;
						}
						IL_76:
						if (this.x65911b61bef3a921.xda73fcb97c77d998.Contains(point))
						{
							break;
						}
						if (this.Controls.Count != 0)
						{
							goto IL_AA;
						}
						if (2 != 0)
						{
							break;
						}
						if (!true)
						{
							continue;
						}
						IL_3B:
						if (2147483647 != 0)
						{
							break;
						}
						goto IL_76;
					}
					goto IL_4E;
					IL_AA:
					this.xa7b62e7d2cd81eb7();
					return;
				}
				IL_4E:
				DockControl controlAt = this.GetControlAt(point);
				if (controlAt != null)
				{
					controlAt.OnTabDoubleClick();
				}
			}
		}

		// Token: 0x060001CC RID: 460 RVA: 0x0000F74C File Offset: 0x0000E74C
		private void xa7b62e7d2cd81eb7()
		{
			DockSituation dockSituation = this.SelectedControl.DockSituation;
			for (;;)
			{
				IL_AC:
				switch (dockSituation)
				{
				case DockSituation.Docked:
				case DockSituation.Document:
					goto IL_40;
				case DockSituation.Floating:
					if (this.SelectedControl.MetaData.LastFixedDockSituation == DockSituation.Docked)
					{
						if (this.xe302f2203dc14a18(this.SelectedControl.MetaData.LastFixedDockSide))
						{
							goto IL_98;
						}
					}
					while (this.SelectedControl.MetaData.LastFixedDockSituation == DockSituation.Document)
					{
						if (this.xe302f2203dc14a18(ContainerDockLocation.Center))
						{
							goto IL_34;
						}
						if (-2 != 0)
						{
							break;
						}
						if (15 != 0)
						{
							goto IL_AC;
						}
						if (!false)
						{
						}
					}
					goto Block_1;
				}
				return;
			}
			Block_1:
			return;
			IL_34:
			this.x18f55df6f6629e9f(DockSituation.Document);
			return;
			IL_40:
			if (this.x74e31f9641656e0b)
			{
				this.x18f55df6f6629e9f(DockSituation.Floating);
				if (!false)
				{
					return;
				}
			}
			return;
			IL_98:
			this.x18f55df6f6629e9f(DockSituation.Docked);
		}

		// Token: 0x060001CD RID: 461 RVA: 0x0000F81C File Offset: 0x0000E81C
		protected internal override void OnMouseMove(MouseEventArgs e)
		{
			if (!this.xd30df1068ed42e28)
			{
				goto IL_248;
			}
			if (true)
			{
				return;
			}
			goto IL_1B7;
			IL_15:
			if (this.xf111a0cc60fdac46)
			{
				if (!true)
				{
					return;
				}
			}
			else
			{
				this.x1f43ebe301d1df45 = this.x07083a4bfd59263d(e.X, e.Y);
				if (15 == 0)
				{
					if (-1 != 0)
					{
						goto IL_23E;
					}
					if (false)
					{
						goto IL_180;
					}
					goto IL_187;
				}
			}
			return;
			IL_82:
			Rectangle rectangle;
			if (rectangle.Contains(e.X, e.Y) && !false)
			{
				if (4 == 0)
				{
					goto IL_E0;
				}
				goto IL_17E;
			}
			else
			{
				if (!base.IsInContainer)
				{
					goto IL_15;
				}
				if (!(this.x6afebf16b45c02e0 != Point.Empty))
				{
					goto IL_15;
				}
				if (!true)
				{
					if (false)
					{
						goto IL_1B7;
					}
				}
				else if (this.Collapsed)
				{
					goto IL_15;
				}
				if (this.LockControls)
				{
					goto IL_15;
				}
				goto IL_1B7;
			}
			IL_B7:
			if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
			{
				goto IL_213;
			}
			if (15 == 0)
			{
				goto IL_82;
			}
			goto IL_15;
			IL_E0:
			DockControl controlAt;
			DockingHints x48cee1d69929b4fe;
			DockingManager xab4835b6b;
			base.xe9a159cd1e028df2(base.DockContainer.Manager, base.DockContainer, this, controlAt, this.SelectedControl.MetaData.DockedContentSize, this.x6afebf16b45c02e0, x48cee1d69929b4fe, xab4835b6b);
			return;
			IL_119:
			if (base.DockContainer.Manager != null)
			{
				goto IL_140;
			}
			IL_126:
			xab4835b6b = DockingManager.Standard;
			if (true)
			{
				goto IL_174;
			}
			IL_12F:
			if (15 != 0)
			{
				goto IL_119;
			}
			if (15 == 0)
			{
				if (2147483647 != 0)
				{
					goto IL_213;
				}
				if (!false)
				{
					goto IL_202;
				}
				if (false)
				{
					goto IL_265;
				}
				goto IL_187;
			}
			IL_140:
			xab4835b6b = base.DockContainer.Manager.DockingManager;
			goto IL_E0;
			IL_174:
			if (!false)
			{
				goto IL_E0;
			}
			IL_17E:
			goto IL_265;
			IL_180:
			goto IL_119;
			IL_187:
			if (!false)
			{
			}
			IL_18A:
			x48cee1d69929b4fe = base.DockContainer.Manager.DockingHints;
			goto IL_180;
			IL_1B7:
			controlAt = this.GetControlAt(this.x6afebf16b45c02e0);
			this.x49cf4e0157d9436c = (controlAt == null);
			if (-2 != 0)
			{
				if (base.DockContainer.Manager != null)
				{
					goto IL_18A;
				}
				if (false)
				{
					goto IL_15;
				}
			}
			x48cee1d69929b4fe = DockingHints.TranslucentFill;
			if (2147483647 == 0)
			{
				goto IL_174;
			}
			goto IL_12F;
			IL_202:
			this.x531514c39973cbc6.OnMouseMove(Cursor.Position);
			return;
			IL_213:
			if (this.x531514c39973cbc6 != null)
			{
				goto IL_202;
			}
			rectangle = new Rectangle(this.x6afebf16b45c02e0, new Size(0, 0));
			if (true)
			{
				rectangle.Inflate(SystemInformation.DragSize);
				goto IL_82;
			}
			goto IL_126;
			IL_23E:
			if (4 != 0)
			{
				goto IL_B7;
			}
			IL_248:
			if (e.Button != MouseButtons.None)
			{
				goto IL_B7;
			}
			this.xf111a0cc60fdac46 = false;
			goto IL_23E;
			IL_265:
			if (3 != 0)
			{
				goto IL_15;
			}
			goto IL_15;
		}

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x060001CE RID: 462 RVA: 0x0000FAB0 File Offset: 0x0000EAB0
		// (set) Token: 0x060001CF RID: 463 RVA: 0x0000FAB8 File Offset: 0x0000EAB8
		internal x0a9f5257a10031b2 x1f43ebe301d1df45
		{
			get
			{
				return this.x502580ccb6d2ffd4;
			}
			set
			{
				if (value != this.x502580ccb6d2ffd4)
				{
					if (this.x502580ccb6d2ffd4 != null)
					{
						this.xd541e2fc281b554b();
						if (2147483647 == 0)
						{
							return;
						}
					}
					this.x502580ccb6d2ffd4 = value;
					if (this.x502580ccb6d2ffd4 != null)
					{
						this.xd541e2fc281b554b();
					}
				}
			}
		}

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x060001D0 RID: 464 RVA: 0x0000FAF0 File Offset: 0x0000EAF0
		internal override bool x2f61709eaa5ebf76
		{
			get
			{
				foreach (object obj in this.Controls)
				{
					DockControl dockControl = (DockControl)obj;
					if (!dockControl.DockingRules.AllowTab)
					{
						return false;
					}
					if (!false)
					{
					}
				}
				return true;
			}
		}

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x060001D1 RID: 465 RVA: 0x0000FB74 File Offset: 0x0000EB74
		internal override bool x74e31f9641656e0b
		{
			get
			{
				foreach (object obj in this.Controls)
				{
					DockControl dockControl = (DockControl)obj;
					if (!dockControl.DockingRules.AllowFloat)
					{
						if (-2 != 0)
						{
							return false;
						}
						break;
					}
				}
				return true;
			}
		}

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x060001D2 RID: 466 RVA: 0x0000FBF0 File Offset: 0x0000EBF0
		private bool x43d7533e3cdb2944
		{
			get
			{
				IEnumerator enumerator = this.Controls.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						object obj = enumerator.Current;
						DockControl dockControl = (DockControl)obj;
						if (!dockControl.AllowCollapse)
						{
							return false;
						}
					}
				}
				finally
				{
					IDisposable disposable = enumerator as IDisposable;
					if (false)
					{
					}
					IL_4A:
					while (disposable != null)
					{
						disposable.Dispose();
						bool flag;
						if (((flag ? 1U : 0U) | 15U) != 0U)
						{
							if (-2147483648 != 0)
							{
								IL_78:
								goto EndFinally_7;
							}
						}
					}
					goto IL_78;
					goto IL_4A;
					EndFinally_7:;
				}
				return true;
			}
		}

		// Token: 0x060001D3 RID: 467 RVA: 0x0000FC98 File Offset: 0x0000EC98
		internal override bool xe302f2203dc14a18(ContainerDockLocation xb9c2cfae130d9256)
		{
			IEnumerator enumerator = this.Controls.GetEnumerator();
			try
			{
				bool flag2;
				for (;;)
				{
					DockControl dockControl;
					if (enumerator.MoveNext())
					{
						dockControl = (DockControl)enumerator.Current;
						goto IL_29;
					}
					bool flag = (flag2 ? 1U : 0U) + (flag2 ? 1U : 0U) < 0U;
					if (!flag)
					{
						goto IL_50;
					}
					IL_4C:
					flag2 = false;
					if (8 != 0)
					{
						break;
					}
					if (!false)
					{
						continue;
					}
					IL_29:
					if (!dockControl.xe302f2203dc14a18(xb9c2cfae130d9256))
					{
						goto IL_4C;
					}
				}
				return flag2;
				IL_50:;
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				while (disposable != null)
				{
					disposable.Dispose();
					if (8 != 0)
					{
						bool flag2;
						bool flag = ((flag2 ? 1U : 0U) & 0U) == 0U;
						if (flag)
						{
							break;
						}
					}
				}
			}
			return true;
		}

		// Token: 0x060001D4 RID: 468 RVA: 0x0000FD5C File Offset: 0x0000ED5C
		internal virtual string xe0e7b93bedab6c05(Point x13d4cb8d1bd20347)
		{
			DockControl controlAt = this.GetControlAt(x13d4cb8d1bd20347);
			if (controlAt == null)
			{
				x0a9f5257a10031b2 x0a9f5257a10031b = this.x07083a4bfd59263d(x13d4cb8d1bd20347.X, x13d4cb8d1bd20347.Y);
				if (x0a9f5257a10031b == this.x26e80f23e22a05ae)
				{
					return SandDockLanguage.CloseText;
				}
				if (x0a9f5257a10031b == this.x65911b61bef3a921)
				{
					return SandDockLanguage.AutoHideText;
				}
				if (x0a9f5257a10031b == this.x3b444f64233558c3)
				{
					return SandDockLanguage.WindowPositionText;
				}
				return "";
			}
			else
			{
				if (controlAt.ToolTipText.Length != 0)
				{
					return controlAt.ToolTipText;
				}
				if (!controlAt.xcfac6723d8a41375)
				{
					return "";
				}
				return controlAt.Text;
			}
		}

		// Token: 0x060001D5 RID: 469 RVA: 0x0000FDF0 File Offset: 0x0000EDF0
		internal virtual x0a9f5257a10031b2 x07083a4bfd59263d(int x08db3aeabb253cb1, int x1e218ceaee1bb583)
		{
			if (this.x26e80f23e22a05ae.x364c1e3b189d47fe)
			{
				if (-2 == 0 || this.x26e80f23e22a05ae.xda73fcb97c77d998.Contains(x08db3aeabb253cb1, x1e218ceaee1bb583))
				{
					return this.x26e80f23e22a05ae;
				}
				bool flag = (uint)x1e218ceaee1bb583 + (uint)x08db3aeabb253cb1 < 0U;
				if (flag)
				{
					if (((uint)x1e218ceaee1bb583 & 0U) != 0U)
					{
						goto IL_71;
					}
					goto IL_1E;
				}
			}
			if (!this.x65911b61bef3a921.x364c1e3b189d47fe)
			{
				goto IL_32;
			}
			IL_1E:
			if (this.x65911b61bef3a921.xda73fcb97c77d998.Contains(x08db3aeabb253cb1, x1e218ceaee1bb583))
			{
				goto IL_71;
			}
			IL_32:
			if (this.x3b444f64233558c3.x364c1e3b189d47fe && this.x3b444f64233558c3.xda73fcb97c77d998.Contains(x08db3aeabb253cb1, x1e218ceaee1bb583))
			{
				return this.x3b444f64233558c3;
			}
			return null;
			IL_71:
			return this.x65911b61bef3a921;
		}

		// Token: 0x060001D6 RID: 470 RVA: 0x0000FEB8 File Offset: 0x0000EEB8
		internal override void x0ae87c4881d90427(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			base.x0ae87c4881d90427(xe0292b9ed559da7d, xfbf34718e704c6bc);
			this.x6afebf16b45c02e0 = Point.Empty;
		}

		// Token: 0x060001D7 RID: 471 RVA: 0x0000FED0 File Offset: 0x0000EED0
		protected internal override void OnDragOver(DragEventArgs drgevent)
		{
			base.OnDragOver(drgevent);
			if (3 != 0)
			{
				DockControl controlAt = this.GetControlAt(base.DockContainer.PointToClient(new Point(drgevent.X, drgevent.Y)));
				if (controlAt != null)
				{
					if (this.SelectedControl != controlAt || false)
					{
						controlAt.Open(WindowOpenMethod.OnScreenActivate);
					}
				}
			}
		}

		// Token: 0x060001D8 RID: 472 RVA: 0x0000FF2C File Offset: 0x0000EF2C
		protected internal override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			if (!false)
			{
				this.xf111a0cc60fdac46 = false;
			}
			for (;;)
			{
				IL_155:
				for (;;)
				{
					if (this.xb48529af1739dd06.Contains(e.X, e.Y) && this.SelectedControl != null)
					{
						this.SelectedControl.Activate();
					}
					for (;;)
					{
						if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
						{
							while (this.xb48529af1739dd06.Contains(e.X, e.Y))
							{
								this.x6afebf16b45c02e0 = new Point(e.X, e.Y);
								if (-2 == 0)
								{
									goto IL_155;
								}
								if (2 != 0)
								{
									goto IL_5F;
								}
							}
							if (false)
							{
								goto Block_8;
							}
							goto IL_5F;
						}
						IL_67:
						DockControl controlAt = this.GetControlAt(new Point(e.X, e.Y));
						if (controlAt == null)
						{
							return;
						}
						controlAt.Activate();
						if (255 == 0)
						{
							continue;
						}
						this.xf111a0cc60fdac46 = true;
						if (2147483647 == 0)
						{
							continue;
						}
						if ((e.Button & MouseButtons.Left) != MouseButtons.Left)
						{
							return;
						}
						if (-2 != 0)
						{
							break;
						}
						IL_5F:
						if (this.x1f43ebe301d1df45 == null)
						{
							goto IL_67;
						}
						goto IL_A0;
					}
					if (15 != 0)
					{
						goto Block_2;
					}
				}
			}
			Block_2:
			this.x6afebf16b45c02e0 = new Point(e.X, e.Y);
			return;
			IL_A0:
			this.xfa5e20eb950b9ee1 = true;
			this.xd541e2fc281b554b();
			this.x11e90588eb0baaf1(this.x1f43ebe301d1df45);
			this.x6afebf16b45c02e0 = Point.Empty;
			return;
			Block_8:
			goto IL_A0;
		}

		// Token: 0x060001D9 RID: 473 RVA: 0x000100AC File Offset: 0x0000F0AC
		protected internal override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			if (8 != 0)
			{
				for (;;)
				{
					this.x6afebf16b45c02e0 = Point.Empty;
					for (;;)
					{
						this.xf111a0cc60fdac46 = false;
						if (this.x531514c39973cbc6 == null)
						{
							DockControl dockControl;
							if (2 != 0)
							{
								if ((e.Button & MouseButtons.Right) != MouseButtons.Right)
								{
									goto Block_11;
								}
								dockControl = this.GetControlAt(new Point(e.X, e.Y));
								goto IL_1B5;
							}
							IL_16B:
							Point point = new Point(e.X, e.Y);
							if (-1 == 0)
							{
								goto IL_3B;
							}
							point = dockControl.Parent.PointToScreen(point);
							point = dockControl.PointToClient(point);
							if (8 == 0)
							{
								goto IL_1C9;
							}
							if (4 == 0)
							{
								continue;
							}
							base.DockContainer.x8ba6fce4f4601549(new ShowControlContextMenuEventArgs(dockControl, point, ContextMenuContext.RightClick));
							if (255 != 0)
							{
								goto IL_1C9;
							}
							if (4 == 0)
							{
								break;
							}
							IL_1B5:
							if (dockControl == null)
							{
								if (this.xb48529af1739dd06.Contains(e.X, e.Y))
								{
									goto IL_1CB;
								}
							}
							IL_199:
							if (dockControl == null)
							{
								goto IL_D8;
							}
							if (!false)
							{
								if (!base.IsInContainer)
								{
									goto Block_8;
								}
								goto IL_16B;
							}
							IL_1CB:
							dockControl = this.SelectedControl;
							goto IL_199;
						}
						goto IL_1FF;
					}
				}
				IL_3B:
				while (this.x1f43ebe301d1df45 != null)
				{
					this.xa82f7b310984e03e(this.x1f43ebe301d1df45);
					this.xfa5e20eb950b9ee1 = false;
					this.xd541e2fc281b554b();
					if (255 != 0)
					{
						break;
					}
				}
				IL_70:
				return;
				IL_C4:
				goto IL_D8;
				Block_8:
				if (-2147483648 != 0)
				{
				}
				IL_D8:
				if ((e.Button & MouseButtons.Middle) == MouseButtons.Middle && base.IsInContainer && base.DockContainer.Manager != null && base.DockContainer.Manager.AllowMiddleButtonClosure)
				{
					if (false)
					{
						return;
					}
					DockControl controlAt = this.GetControlAt(new Point(e.X, e.Y));
					if (controlAt != null)
					{
						if (controlAt.AllowClose)
						{
							controlAt.x8ffe90e7fbccfccd(true);
						}
					}
					return;
				}
				else
				{
					if ((e.Button & MouseButtons.Left) != MouseButtons.Left)
					{
						return;
					}
					if (-2 == 0)
					{
						goto IL_70;
					}
					goto IL_3B;
				}
				Block_11:
				goto IL_C4;
				IL_1C9:
				return;
				IL_1FF:
				this.x531514c39973cbc6.Commit();
				return;
			}
		}

		// Token: 0x060001DA RID: 474 RVA: 0x000102E8 File Offset: 0x0000F2E8
		internal virtual void x11e90588eb0baaf1(x0a9f5257a10031b2 x128517d7ded59312)
		{
		}

		// Token: 0x060001DB RID: 475 RVA: 0x000102EC File Offset: 0x0000F2EC
		internal virtual void xa82f7b310984e03e(x0a9f5257a10031b2 x128517d7ded59312)
		{
			if (this.x1f43ebe301d1df45 == this.x26e80f23e22a05ae)
			{
				this.OnCloseButtonClick(EventArgs.Empty);
				return;
			}
			if (this.x1f43ebe301d1df45 != this.x65911b61bef3a921)
			{
				if (this.x1f43ebe301d1df45 == this.x3b444f64233558c3 && !false)
				{
					this.xf0820a0467228c88();
				}
				return;
			}
			this.OnPinButtonClick();
		}

		// Token: 0x060001DC RID: 476 RVA: 0x00010348 File Offset: 0x0000F348
		private void xf0820a0467228c88()
		{
			Point point = new Point(this.x3b444f64233558c3.xda73fcb97c77d998.Left, this.x3b444f64233558c3.xda73fcb97c77d998.Bottom);
			point = this.SelectedControl.Parent.PointToScreen(point);
			point = this.SelectedControl.PointToClient(point);
			base.DockContainer.x8ba6fce4f4601549(new ShowControlContextMenuEventArgs(this.SelectedControl, point, ContextMenuContext.OptionsButton));
		}

		// Token: 0x060001DD RID: 477 RVA: 0x000103B4 File Offset: 0x0000F3B4
		protected internal override void OnMouseLeave()
		{
			base.OnMouseLeave();
			this.x1f43ebe301d1df45 = null;
			this.xfa5e20eb950b9ee1 = false;
		}

		// Token: 0x060001DE RID: 478 RVA: 0x000103CC File Offset: 0x0000F3CC
		internal bool x61ce2417e4ef76f9()
		{
			if (base.IsInContainer)
			{
				if (!false)
				{
					while (this.SelectedControl != null)
					{
						if (this.SelectedControl.ContainsFocus)
						{
							this.x317ed3bc8decf394 = true;
							goto IL_1E;
						}
						if (2147483647 != 0)
						{
							break;
						}
					}
					return false;
				}
				IL_1E:
				if (this.SelectedControl != null)
				{
					base.DockContainer.Manager.OnDockControlActivated(new DockControlEventArgs(this.SelectedControl));
				}
				return true;
			}
			return false;
		}

		// Token: 0x060001DF RID: 479 RVA: 0x0001043C File Offset: 0x0000F43C
		internal void x82dd941e2755ffd2()
		{
			this.x317ed3bc8decf394 = false;
		}

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x060001E0 RID: 480 RVA: 0x00010448 File Offset: 0x0000F448
		// (set) Token: 0x060001E1 RID: 481 RVA: 0x00010450 File Offset: 0x0000F450
		internal bool x317ed3bc8decf394
		{
			get
			{
				return this.xd34ff54c5dd91133;
			}
			set
			{
				if (value != this.xd34ff54c5dd91133)
				{
					this.xd34ff54c5dd91133 = value;
					this.xd541e2fc281b554b();
				}
			}
		}

		// Token: 0x060001E2 RID: 482 RVA: 0x00010468 File Offset: 0x0000F468
		internal override void x84b6f3c22477dacb(RendererBase x38870620fd380a6b, Graphics x41347a961b838962, Font x26094932cf7a9139)
		{
			if (base.DockContainer == null)
			{
				return;
			}
			bool flag;
			DrawItemState drawItemState2;
			for (;;)
			{
				if (base.DockContainer.IsFloating || base.DockContainer.Manager == null)
				{
					goto IL_7BA;
				}
				if (base.DockContainer.Manager.DockSystemContainer == null)
				{
					goto IL_7BA;
				}
				Control control = base.DockContainer.Manager.DockSystemContainer;
				IL_794:
				Control container = control;
				if (!base.IsInContainer || !base.DockContainer.x972331c8ecf83413)
				{
					flag = this.x317ed3bc8decf394;
					goto IL_6BF;
				}
				bool flag2;
				if ((flag2 ? 1U : 0U) + (flag ? 1U : 0U) >= 0U)
				{
					ISelectionService selectionService = (ISelectionService)base.DockContainer.x7159e85e85b84817(typeof(ISelectionService));
					flag = selectionService.GetComponentSelected(this.SelectedControl);
					goto IL_6BF;
				}
				goto IL_366;
				IL_704:
				int num;
				bool flag3 = (flag2 ? 1U : 0U) - (uint)num < 0U;
				if (flag3)
				{
					continue;
				}
				for (;;)
				{
					if ((flag2 ? 1U : 0U) - (flag ? 1U : 0U) > 4294967295U || this.xbf5c00c8e3dd85fc != null)
					{
						Rectangle x123e054dab = this.xbf5c00c8e3dd85fc.x123e054dab107457;
						num = x123e054dab.X - base.Bounds.Left;
						if ((uint)num + (flag ? 1U : 0U) > 4294967295U)
						{
							goto IL_FA;
						}
					}
					x38870620fd380a6b.DrawTabStripBackground(container, base.DockContainer, x41347a961b838962, this.xa358da7dd5364cab, num);
					flag3 = ((uint)num - (flag ? 1U : 0U) < 0U);
					if (flag3)
					{
						break;
					}
					using (IEnumerator enumerator = this.xe477cc01ecfef1fb.GetEnumerator())
					{
						for (;;)
						{
							DockControl dockControl;
							DrawItemState drawItemState;
							if (enumerator.MoveNext())
							{
								dockControl = (DockControl)enumerator.Current;
								drawItemState = DrawItemState.Default;
								for (;;)
								{
									if (this.xbf5c00c8e3dd85fc == dockControl)
									{
										drawItemState |= DrawItemState.Selected;
									}
									flag2 = true;
									if ((flag ? 1U : 0U) - (uint)num <= 4294967295U)
									{
										if (this.xbf5c00c8e3dd85fc == null)
										{
											break;
										}
										flag3 = ((flag2 ? 1U : 0U) + (uint)num < 0U);
										if (flag3)
										{
											goto IL_505;
										}
									}
									IL_50D:
									if (this.xe477cc01ecfef1fb.IndexOf(dockControl) != this.xe477cc01ecfef1fb.IndexOf(this.xbf5c00c8e3dd85fc) - 1)
									{
										if (((flag ? 1U : 0U) & 0U) != 0U)
										{
											continue;
										}
										break;
									}
									IL_505:
									flag2 = false;
									if (-1 != 0)
									{
										break;
									}
									goto IL_50D;
								}
								IL_48F:
								if (this.xe477cc01ecfef1fb.IndexOf(dockControl) == this.xe477cc01ecfef1fb.Count - 1)
								{
									if ((flag ? 1U : 0U) - (uint)num <= 4294967295U)
									{
										flag3 = ((flag ? 1U : 0U) < 0U);
										if (!flag3 && !(x38870620fd380a6b is WhidbeyRenderer))
										{
											goto IL_43D;
										}
									}
									flag2 = false;
									goto IL_430;
								}
								goto IL_43D;
								goto IL_48F;
							}
							if (!false)
							{
								break;
							}
							IL_43D:
							x38870620fd380a6b.DrawTabStripTab(x41347a961b838962, dockControl.x123e054dab107457, dockControl.x1999b243e321e38a, dockControl.TabText, dockControl.Font, dockControl.BackColor, dockControl.ForeColor, drawItemState, flag2);
							continue;
							IL_430:
							goto IL_43D;
						}
						goto IL_3D0;
					}
				}
				flag3 = ((uint)num + (flag ? 1U : 0U) < 0U);
				if (flag3)
				{
					goto IL_662;
				}
				IL_409:
				if (this.xe477cc01ecfef1fb.Count > 1)
				{
					goto IL_66C;
				}
				if ((flag ? 1U : 0U) + (uint)num >= 0U)
				{
					if (!base.DockContainer.x972331c8ecf83413)
					{
						goto IL_3D0;
					}
					goto IL_66C;
				}
				IL_681:
				num = 0;
				goto IL_704;
				IL_66C:
				if (this.xa358da7dd5364cab != Rectangle.Empty)
				{
					goto IL_681;
				}
				goto IL_3D0;
				IL_3F7:
				flag3 = ((uint)num < 0U);
				if (flag3)
				{
					goto IL_409;
				}
				goto IL_662;
				IL_351:
				Rectangle rectangle;
				rectangle.Width -= 21;
				goto IL_3F7;
				IL_2F6:
				if (this.x3b444f64233558c3.x364c1e3b189d47fe)
				{
					goto IL_351;
				}
				if (!false)
				{
					goto IL_306;
				}
				goto IL_32C;
				IL_21E:
				if (this.x26e80f23e22a05ae.xda73fcb97c77d998.Left <= this.xb48529af1739dd06.Left)
				{
					goto IL_C8;
				}
				drawItemState2 = DrawItemState.Default;
				while (this.x1f43ebe301d1df45 == this.x26e80f23e22a05ae)
				{
					drawItemState2 |= DrawItemState.HotLight;
					if (this.xfa5e20eb950b9ee1)
					{
						drawItemState2 |= DrawItemState.Selected;
						if ((uint)num - (uint)num > 4294967295U)
						{
							continue;
						}
					}
					IL_1D5:
					x38870620fd380a6b.DrawTitleBarButton(x41347a961b838962, this.x26e80f23e22a05ae.xda73fcb97c77d998, SandDockButtonType.Close, drawItemState2, flag, false);
					if ((flag2 ? 1U : 0U) - (flag ? 1U : 0U) <= 4294967295U)
					{
						goto IL_C8;
					}
					goto IL_2F6;
				}
				flag3 = ((flag ? 1U : 0U) - (flag2 ? 1U : 0U) < 0U);
				if (!flag3)
				{
					goto IL_1D5;
				}
				flag3 = ((flag2 ? 1U : 0U) > uint.MaxValue);
				if (flag3)
				{
					return;
				}
				IL_174:
				if (!this.x26e80f23e22a05ae.x364c1e3b189d47fe)
				{
					goto IL_C8;
				}
				goto IL_21E;
				IL_6BF:
				if (this.SelectedControl == null)
				{
					x38870620fd380a6b.DrawControlClientBackground(x41347a961b838962, this.x21ed2ecc088ef4e4, SystemColors.Control);
					goto IL_409;
				}
				if ((flag ? 1U : 0U) - (flag ? 1U : 0U) < 0U)
				{
					break;
				}
				if (true)
				{
					x38870620fd380a6b.DrawControlClientBackground(x41347a961b838962, this.x21ed2ecc088ef4e4, this.SelectedControl.BackColor);
					goto IL_409;
				}
				flag3 = ((uint)num + (flag2 ? 1U : 0U) > uint.MaxValue);
				if (flag3)
				{
					goto IL_704;
				}
				goto IL_409;
				IL_32C:
				if (!this.x65911b61bef3a921.x364c1e3b189d47fe)
				{
					flag3 = ((flag2 ? 1U : 0U) + (uint)num > uint.MaxValue);
					if (flag3)
					{
						goto IL_351;
					}
					goto IL_2F6;
				}
				else
				{
					rectangle.Width -= 21;
					flag3 = (((uint)num | 4U) == 0U);
					if (flag3)
					{
						goto IL_3F7;
					}
					goto IL_2F6;
				}
				IL_379:
				if (!this.x26e80f23e22a05ae.x364c1e3b189d47fe)
				{
					goto IL_32C;
				}
				goto IL_366;
				IL_4D:
				if (rectangle.Width <= 0)
				{
					flag3 = (((flag ? 1U : 0U) & 0U) == 0U);
					if (flag3)
					{
						if (-2147483648 == 0)
						{
							goto IL_21E;
						}
						return;
					}
				}
				if (rectangle.Height <= 0)
				{
					goto Block_5;
				}
				x38870620fd380a6b.DrawTitleBarBackground(x41347a961b838962, rectangle, flag);
				goto IL_379;
				IL_3D0:
				rectangle = this.xb48529af1739dd06;
				if (rectangle != Rectangle.Empty)
				{
					goto IL_4D;
				}
				goto IL_71;
				IL_C8:
				if (!this.x65911b61bef3a921.x364c1e3b189d47fe)
				{
					break;
				}
				if (this.x65911b61bef3a921.xda73fcb97c77d998.Left <= this.xb48529af1739dd06.Left)
				{
					break;
				}
				drawItemState2 = DrawItemState.Default;
				if (this.x1f43ebe301d1df45 == this.x65911b61bef3a921)
				{
					goto IL_147;
				}
				flag3 = ((flag ? 1U : 0U) + (flag2 ? 1U : 0U) > uint.MaxValue);
				if (flag3)
				{
					goto IL_4D;
				}
				goto IL_121;
				IL_366:
				rectangle.Width -= 21;
				if (false)
				{
					goto IL_379;
				}
				goto IL_32C;
				IL_306:
				rectangle = x38870620fd380a6b.TitleBarMetrics.RemovePadding(rectangle);
				if (rectangle.Width <= 8)
				{
					goto IL_174;
				}
				x38870620fd380a6b.DrawTitleBarText(x41347a961b838962, rectangle, flag, (this.xbf5c00c8e3dd85fc == null) ? "Empty Layout System" : this.xbf5c00c8e3dd85fc.Text, (this.xbf5c00c8e3dd85fc != null) ? this.xbf5c00c8e3dd85fc.Font : base.DockContainer.Font);
				flag3 = (((flag2 ? 1U : 0U) & 0U) == 0U);
				if (flag3)
				{
					goto IL_174;
				}
				goto IL_162;
				IL_662:
				goto IL_306;
				IL_7BA:
				control = base.DockContainer;
				goto IL_794;
			}
			IL_15:
			if (this.x3b444f64233558c3.x364c1e3b189d47fe)
			{
				if (this.x3b444f64233558c3.xda73fcb97c77d998.Left > this.xb48529af1739dd06.Left)
				{
					drawItemState2 = DrawItemState.Default;
					if (this.x1f43ebe301d1df45 != this.x3b444f64233558c3)
					{
						goto IL_8E;
					}
					drawItemState2 |= DrawItemState.HotLight;
					goto IL_AA;
				}
			}
			Block_5:
			IL_71:
			return;
			IL_8E:
			x38870620fd380a6b.DrawTitleBarButton(x41347a961b838962, this.x3b444f64233558c3.xda73fcb97c77d998, SandDockButtonType.WindowPosition, drawItemState2, flag, false);
			return;
			IL_AA:
			if (!this.xfa5e20eb950b9ee1)
			{
				goto IL_8E;
			}
			drawItemState2 |= DrawItemState.Selected;
			goto IL_8E;
			IL_C3:
			IL_FA:
			goto IL_15;
			IL_121:
			x38870620fd380a6b.DrawTitleBarButton(x41347a961b838962, this.x65911b61bef3a921.xda73fcb97c77d998, SandDockButtonType.Pin, drawItemState2, flag, this.Collapsed);
			goto IL_C3;
			IL_147:
			drawItemState2 |= DrawItemState.HotLight;
			if (this.xfa5e20eb950b9ee1)
			{
				if (false)
				{
					goto IL_AA;
				}
				drawItemState2 |= DrawItemState.Selected;
			}
			IL_162:
			goto IL_121;
		}

		// Token: 0x060001E3 RID: 483 RVA: 0x00010C7C File Offset: 0x0000FC7C
		internal void xb30ec7cfdf3e5c19(Graphics x41347a961b838962, RendererBase x38870620fd380a6b, x0a9f5257a10031b2 x128517d7ded59312, SandDockButtonType x271bd5d42b3ea793, bool x2fef7d841879a711)
		{
			if (x128517d7ded59312.x364c1e3b189d47fe)
			{
				DrawItemState drawItemState = DrawItemState.Default;
				while (this.x1f43ebe301d1df45 == x128517d7ded59312)
				{
					if ((x2fef7d841879a711 ? 1U : 0U) < 0U)
					{
						goto IL_47;
					}
					drawItemState |= DrawItemState.HotLight;
					IL_5F:
					if (!this.xfa5e20eb950b9ee1)
					{
						if (false)
						{
							return;
						}
						break;
					}
					else
					{
						drawItemState |= DrawItemState.Selected;
						if (((x2fef7d841879a711 ? 1U : 0U) | 3U) == 0U)
						{
							continue;
						}
					}
					IL_47:
					bool flag = (x2fef7d841879a711 ? 1U : 0U) + (x2fef7d841879a711 ? 1U : 0U) > uint.MaxValue;
					if (!flag && (x2fef7d841879a711 ? 1U : 0U) + (x2fef7d841879a711 ? 1U : 0U) >= 0U)
					{
						break;
					}
					goto IL_5F;
				}
				if (!x2fef7d841879a711)
				{
					drawItemState |= DrawItemState.Disabled;
				}
				x38870620fd380a6b.DrawDocumentStripButton(x41347a961b838962, x128517d7ded59312.xda73fcb97c77d998, x271bd5d42b3ea793, drawItemState);
			}
		}

		// Token: 0x060001E4 RID: 484 RVA: 0x00010D40 File Offset: 0x0000FD40
		internal virtual void xd541e2fc281b554b()
		{
			if (this.x10ac79a4257c7f52 == null)
			{
				goto IL_3F;
			}
			if (!true)
			{
			}
			IL_0F:
			if (this.x10ac79a4257c7f52.x23498f53d87354d4 == this)
			{
				this.x10ac79a4257c7f52.xbb5f70c792fb9034(this.xb48529af1739dd06);
				return;
			}
			if (!false)
			{
				return;
			}
			IL_3F:
			if (base.IsInContainer)
			{
				base.DockContainer.Invalidate(this.xb48529af1739dd06);
				if (false)
				{
					goto IL_0F;
				}
				if (2 == 0)
				{
					goto IL_0F;
				}
			}
		}

		// Token: 0x060001E5 RID: 485 RVA: 0x00010DAC File Offset: 0x0000FDAC
		internal override void x46ff430ed3944e0f(xedb4922162c60d3d.DockTarget x11d58b056c032b03)
		{
			base.x46ff430ed3944e0f(x11d58b056c032b03);
			DockControl selectedControl;
			SandDockManager manager;
			for (;;)
			{
				IL_11A:
				if (x11d58b056c032b03 == null)
				{
					if (!false)
					{
						return;
					}
					if (-2 == 0)
					{
						goto IL_12B;
					}
				}
				else
				{
					if (x11d58b056c032b03.type == xedb4922162c60d3d.DockTargetType.None)
					{
						return;
					}
					if (x11d58b056c032b03.type == xedb4922162c60d3d.DockTargetType.AlreadyActioned)
					{
						goto IL_11C;
					}
				}
				IL_10B:
				selectedControl = this.SelectedControl;
				if (false)
				{
					continue;
				}
				goto IL_12B;
				IL_F7:
				goto IL_10B;
				IL_12B:
				if (false)
				{
					return;
				}
				manager = base.DockContainer.Manager;
				if (!this.x49cf4e0157d9436c)
				{
					LayoutUtilities.xf1cbd48a28ce6e74(selectedControl);
				}
				else
				{
					LayoutUtilities.x4487f2f8917e3fd0(this);
				}
				while (x11d58b056c032b03.type != xedb4922162c60d3d.DockTargetType.Float)
				{
					if (3 == 0)
					{
						goto IL_82;
					}
					if (x11d58b056c032b03.dockContainer == null)
					{
						if (false)
						{
							goto Block_8;
						}
						if (2147483647 == 0)
						{
							continue;
						}
						if (255 != 0 && x11d58b056c032b03.type != xedb4922162c60d3d.DockTargetType.CreateNewContainer)
						{
							goto Block_1;
						}
					}
					this.x6b145af772038ef2(manager, selectedControl, this.x49cf4e0157d9436c, x11d58b056c032b03);
					if (selectedControl != null)
					{
						goto IL_0C;
					}
					if (!false)
					{
						return;
					}
					if (255 == 0)
					{
						goto IL_F7;
					}
					goto IL_11A;
				}
				goto IL_AB;
			}
			IL_0C:
			selectedControl.Activate();
			Block_1:
			return;
			Block_8:
			goto IL_0C;
			IL_82:
			selectedControl.OpenFloating(x11d58b056c032b03.bounds, WindowOpenMethod.OnScreenActivate);
			if (false)
			{
				return;
			}
			if (-2 != 0)
			{
				return;
			}
			IL_97:
			this.Float(manager, x11d58b056c032b03.bounds, WindowOpenMethod.OnScreenActivate);
			if (!false)
			{
				return;
			}
			IL_AB:
			selectedControl.MetaData.x87f4a9b62a380563(Guid.NewGuid());
			if (!this.x49cf4e0157d9436c)
			{
				goto IL_82;
			}
			goto IL_97;
			IL_11C:;
		}

		// Token: 0x060001E6 RID: 486 RVA: 0x00010EEC File Offset: 0x0000FEEC
		internal void x6b145af772038ef2(SandDockManager x91f347c6e97f1846, DockControl x43bec302f92080b9, bool x49cf4e0157d9436c, xedb4922162c60d3d.DockTarget x11d58b056c032b03)
		{
			if (x11d58b056c032b03.type == xedb4922162c60d3d.DockTargetType.JoinExistingSystem)
			{
				goto IL_16E;
			}
			if (x11d58b056c032b03.type != xedb4922162c60d3d.DockTargetType.CreateNewContainer)
			{
				if (x11d58b056c032b03.type == xedb4922162c60d3d.DockTargetType.SplitExistingSystem)
				{
					ControlLayoutSystem controlLayoutSystem = x11d58b056c032b03.dockContainer.CreateNewLayoutSystem(x49cf4e0157d9436c ? this.x9476096be9672d38 : new DockControl[]
					{
						x43bec302f92080b9
					}, base.WorkingSize);
					x11d58b056c032b03.layoutSystem.SplitForLayoutSystem(controlLayoutSystem, x11d58b056c032b03.dockSide);
					if (false)
					{
						return;
					}
				}
				return;
			}
			DockContainer container = x91f347c6e97f1846.FindDockedContainer(DockStyle.Fill);
			bool flag = (x49cf4e0157d9436c ? 1U : 0U) - (x49cf4e0157d9436c ? 1U : 0U) < 0U;
			if (flag)
			{
				goto IL_165;
			}
			if (x11d58b056c032b03.dockLocation != ContainerDockLocation.Center)
			{
				goto IL_8F;
			}
			IL_89:
			while (container != null)
			{
				ControlLayoutSystem controlLayoutSystem = LayoutUtilities.FindControlLayoutSystem(container);
				if (false)
				{
					flag = ((x49cf4e0157d9436c ? 1U : 0U) < 0U);
					if (flag)
					{
						goto IL_165;
					}
					goto IL_16E;
				}
				else
				{
					if (controlLayoutSystem == null)
					{
						return;
					}
					if (x49cf4e0157d9436c)
					{
						this.Dock(controlLayoutSystem);
						return;
					}
					x43bec302f92080b9.x02847d0dec2e498a(controlLayoutSystem, 0);
					if ((x49cf4e0157d9436c ? 1U : 0U) - (x49cf4e0157d9436c ? 1U : 0U) <= 4294967295U)
					{
						return;
					}
				}
			}
			IL_8F:
			if (x49cf4e0157d9436c)
			{
				base.x810df8ef88cf4bf2(x91f347c6e97f1846, x11d58b056c032b03.dockLocation, x11d58b056c032b03.middle ? ContainerDockEdge.Inside : ContainerDockEdge.Outside);
				return;
			}
			x43bec302f92080b9.DockInNewContainer(x11d58b056c032b03.dockLocation, x11d58b056c032b03.middle ? ContainerDockEdge.Inside : ContainerDockEdge.Outside);
			return;
			IL_119:
			x43bec302f92080b9.x02847d0dec2e498a(x11d58b056c032b03.layoutSystem, x11d58b056c032b03.index);
			flag = (((x49cf4e0157d9436c ? 1U : 0U) & 0U) == 0U);
			if (flag)
			{
				return;
			}
			goto IL_89;
			IL_165:
			goto IL_119;
			IL_16E:
			if (!x49cf4e0157d9436c)
			{
				goto IL_119;
			}
			this.Dock(x11d58b056c032b03.layoutSystem, x11d58b056c032b03.index);
		}

		// Token: 0x060001E7 RID: 487 RVA: 0x00011088 File Offset: 0x00010088
		public void SplitForLayoutSystem(LayoutSystemBase layoutSystem, DockSide side)
		{
			SplitLayoutSystem parent;
			if (layoutSystem == null)
			{
				if (-1 != 0)
				{
					throw new ArgumentNullException("layoutSystem");
				}
			}
			else
			{
				if (side == DockSide.None)
				{
					throw new ArgumentException("side");
				}
				if (layoutSystem.Parent != null)
				{
					throw new InvalidOperationException("This layout system must be removed from its parent before it can be moved to a new layout system.");
				}
				if (base.Parent == null)
				{
					throw new InvalidOperationException("This layout system is not parented yet.");
				}
				parent = base.Parent;
				if (parent.SplitMode == Orientation.Horizontal)
				{
					for (;;)
					{
						if (side != DockSide.Top)
						{
							goto IL_85;
						}
						for (;;)
						{
							IL_B2:
							this.x46d2db93dc2104ad(layoutSystem, (side == DockSide.Top) ? parent.LayoutSystems.IndexOf(this) : (parent.LayoutSystems.IndexOf(this) + 1), true);
							if (false)
							{
								break;
							}
							if (!false)
							{
								return;
							}
						}
						if (-2147483648 == 0)
						{
							continue;
						}
						IL_85:
						if (side != DockSide.Bottom)
						{
							break;
						}
						if (!false)
						{
							goto IL_B2;
						}
					}
					this.xd2be843c6119e3c3(layoutSystem, Orientation.Vertical, side == DockSide.Left);
					return;
				}
				if (parent.SplitMode != Orientation.Vertical)
				{
					return;
				}
				if (side == DockSide.Left)
				{
					goto IL_3D;
				}
			}
			if (side != DockSide.Right)
			{
				this.xd2be843c6119e3c3(layoutSystem, Orientation.Horizontal, side == DockSide.Top);
				return;
			}
			IL_3D:
			this.x46d2db93dc2104ad(layoutSystem, (side == DockSide.Left) ? parent.LayoutSystems.IndexOf(this) : (parent.LayoutSystems.IndexOf(this) + 1), false);
		}

		// Token: 0x060001E8 RID: 488 RVA: 0x000111E4 File Offset: 0x000101E4
		private void x46d2db93dc2104ad(LayoutSystemBase x6e150040c8d97700, int xc0c4c459c6ccbd00, bool xab8cd0402556fe8f)
		{
			SplitLayoutSystem parent = base.Parent;
			parent.LayoutSystems.xd7a3953bce504b63 = true;
			parent.LayoutSystems.Insert(xc0c4c459c6ccbd00, x6e150040c8d97700);
			parent.LayoutSystems.xd7a3953bce504b63 = false;
			parent.x8e9e04a70e31e166();
		}

		// Token: 0x060001E9 RID: 489 RVA: 0x00011224 File Offset: 0x00010224
		private void xd2be843c6119e3c3(LayoutSystemBase x6e150040c8d97700, Orientation xf65758d54b79fc7a, bool x6b161b1ae41c1651)
		{
			SplitLayoutSystem parent = base.Parent;
			SplitLayoutSystem splitLayoutSystem;
			int num;
			do
			{
				splitLayoutSystem = new SplitLayoutSystem();
			}
			while ((x6b161b1ae41c1651 ? 1U : 0U) + (uint)num < 0U);
			for (;;)
			{
				splitLayoutSystem.SplitMode = xf65758d54b79fc7a;
				splitLayoutSystem.WorkingSize = base.WorkingSize;
				num = parent.LayoutSystems.IndexOf(this);
				parent.LayoutSystems.xd7a3953bce504b63 = true;
				if (((x6b161b1ae41c1651 ? 1U : 0U) & 0U) == 0U)
				{
					parent.LayoutSystems.Remove(this);
					parent.LayoutSystems.Insert(num, splitLayoutSystem);
				}
				parent.LayoutSystems.xd7a3953bce504b63 = false;
				splitLayoutSystem.LayoutSystems.Add(this);
				if (!x6b161b1ae41c1651)
				{
					break;
				}
				splitLayoutSystem.LayoutSystems.Insert(0, x6e150040c8d97700);
				if (8 != 0)
				{
					goto Block_2;
				}
			}
			splitLayoutSystem.LayoutSystems.Add(x6e150040c8d97700);
			IL_1E:
			parent.x8e9e04a70e31e166();
			return;
			Block_2:
			goto IL_1E;
		}

		// Token: 0x060001EA RID: 490 RVA: 0x00011310 File Offset: 0x00010310
		internal void x18f55df6f6629e9f(DockSituation x7e49ae9bddfdfd07)
		{
			if (this.Controls.Count != 0)
			{
				IL_F8:
				while (this.SelectedControl.DockSituation != x7e49ae9bddfdfd07)
				{
					DockControl selectedControl;
					DockControl[] array;
					for (;;)
					{
						selectedControl = this.SelectedControl;
						array = new DockControl[this.Controls.Count];
						this.Controls.CopyTo(array, 0);
						if (!false)
						{
							break;
						}
						if (false)
						{
							goto IL_F8;
						}
					}
					if (2 == 0)
					{
						goto IL_11B;
					}
					if (!false)
					{
						LayoutUtilities.x4487f2f8917e3fd0(this);
						this.Controls.Clear();
						for (;;)
						{
							if (x7e49ae9bddfdfd07 != DockSituation.Docked)
							{
								if (3 == 0)
								{
									goto IL_A9;
								}
								while (x7e49ae9bddfdfd07 != DockSituation.Document)
								{
									if (x7e49ae9bddfdfd07 != DockSituation.Floating)
									{
										goto IL_2A;
									}
									if (-1 == 0)
									{
										goto IL_11B;
									}
									array[0].OpenFloating(WindowOpenMethod.OnScreenActivate);
									if (2 != 0)
									{
										goto IL_30;
									}
								}
								array[0].OpenDocument(WindowOpenMethod.OnScreenActivate);
							}
							else
							{
								array[0].OpenDocked(WindowOpenMethod.OnScreenActivate);
							}
							IL_30:
							DockControl[] array2 = new DockControl[array.Length - 1];
							do
							{
								Array.Copy(array, 1, array2, 0, array.Length - 1);
							}
							while (false);
							array[0].LayoutSystem.Controls.AddRange(array2);
							if (!false)
							{
								goto IL_A9;
							}
						}
						IL_2A:
						throw new InvalidOperationException();
						IL_A9:
						array[0].LayoutSystem.SelectedControl = selectedControl;
					}
					return;
				}
				return;
			}
			IL_11B:
			throw new InvalidOperationException();
		}

		// Token: 0x060001EB RID: 491 RVA: 0x00011448 File Offset: 0x00010448
		public void Float(SandDockManager manager, Rectangle bounds, WindowOpenMethod openMethod)
		{
			if (base.Parent != null)
			{
				goto IL_8B;
			}
			do
			{
				IL_B0:
				if (!(this.SelectedControl.MetaData.LastFloatingWindowGuid == Guid.Empty))
				{
					while (2147483647 != 0)
					{
						if (true)
						{
							goto IL_CE;
						}
						if (!false)
						{
							goto IL_8B;
						}
					}
				}
				else
				{
					this.SelectedControl.MetaData.x87f4a9b62a380563(Guid.NewGuid());
				}
			}
			while (3 == 0);
			IL_3A:
			x410f3612b9a8f9de x410f3612b9a8f9de = new x410f3612b9a8f9de(manager, this.SelectedControl.MetaData.LastFloatingWindowGuid);
			goto IL_51;
			IL_CE:
			goto IL_3A;
			IL_10:
			x410f3612b9a8f9de.x159713d3b60fae0c(bounds, true, openMethod == WindowOpenMethod.OnScreenActivate);
			if (openMethod == WindowOpenMethod.OnScreenActivate)
			{
				this.SelectedControl.Activate();
				if (2 == 0)
				{
					goto IL_51;
				}
			}
			return;
			IL_51:
			x410f3612b9a8f9de.LayoutSystem.LayoutSystems.Add(this);
			if (-2147483648 != 0)
			{
				goto IL_10;
			}
			IL_8B:
			if (!false)
			{
				LayoutUtilities.x4487f2f8917e3fd0(this);
				goto IL_B0;
			}
			goto IL_10;
		}

		// Token: 0x060001EC RID: 492 RVA: 0x00011530 File Offset: 0x00010530
		public void Float(SandDockManager manager)
		{
			if (this.SelectedControl == null)
			{
				throw new InvalidOperationException("The layout system must have a selected control to be floated.");
			}
			this.Float(manager, this.SelectedControl.xc0154d85fceb081c(), WindowOpenMethod.OnScreenActivate);
		}

		// Token: 0x060001ED RID: 493 RVA: 0x00011558 File Offset: 0x00010558
		public void Dock(ControlLayoutSystem layoutSystem)
		{
			if (layoutSystem == null)
			{
				throw new ArgumentNullException();
			}
			this.Dock(layoutSystem, 0);
		}

		// Token: 0x060001EE RID: 494 RVA: 0x0001156C File Offset: 0x0001056C
		public void Dock(ControlLayoutSystem layoutSystem, int index)
		{
			if (layoutSystem == null)
			{
				throw new ArgumentNullException();
			}
			if (base.Parent != null)
			{
				throw new InvalidOperationException("This layout system already has a parent. To remove it, use the parent layout system's LayoutSystems.Remove method.");
			}
			DockControl selectedControl = this.SelectedControl;
			for (;;)
			{
				DockControl control;
				if (this.xe477cc01ecfef1fb.Count == 0)
				{
					if (2147483647 != 0)
					{
						break;
					}
				}
				else
				{
					control = this.xe477cc01ecfef1fb[0];
				}
				this.xe477cc01ecfef1fb.RemoveAt(0);
				layoutSystem.Controls.Insert(index, control);
			}
			while (selectedControl != null)
			{
				layoutSystem.SelectedControl = selectedControl;
				if (2 != 0 && 3 != 0)
				{
					return;
				}
			}
		}

		// Token: 0x060001EF RID: 495 RVA: 0x0001161C File Offset: 0x0001061C
		internal override void x56e964269d48cfcc(DockContainer x0467b00af7810f0c)
		{
			if (x0467b00af7810f0c == null)
			{
				if (-2147483648 == 0)
				{
					goto IL_4C;
				}
				goto IL_207;
			}
			IL_1EC:
			while (x0467b00af7810f0c != null)
			{
				if (!base.IsInContainer)
				{
					IEnumerator enumerator = this.Controls.GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							object obj = enumerator.Current;
							DockControl dockControl = (DockControl)obj;
							if (-1 == 0 || dockControl.Parent != null)
							{
								LayoutUtilities.xa7513d57b4844d46(dockControl);
							}
							dockControl.Location = new Point(x0467b00af7810f0c.Width, x0467b00af7810f0c.Height);
							if (this.Collapsed)
							{
								if (x0467b00af7810f0c.x0c2484ccd29b8358)
								{
									continue;
								}
							}
							dockControl.Parent = x0467b00af7810f0c;
						}
						goto IL_125;
					}
					finally
					{
						IDisposable disposable = enumerator as IDisposable;
						if (!false)
						{
							goto IL_1E2;
						}
						IL_1D8:
						disposable.Dispose();
						if (!false)
						{
							continue;
						}
						IL_1E2:
						if (disposable != null)
						{
							goto IL_1D8;
						}
					}
					continue;
				}
				IL_125:
				base.x56e964269d48cfcc(x0467b00af7810f0c);
				for (;;)
				{
					using (IEnumerator enumerator2 = this.Controls.GetEnumerator())
					{
						while (enumerator2.MoveNext())
						{
							object obj2 = enumerator2.Current;
							DockControl dockControl2 = (DockControl)obj2;
							dockControl2.x56e964269d48cfcc(x0467b00af7810f0c);
						}
						goto IL_30;
					}
					goto IL_11E;
					IL_30:
					if (!this.Collapsed)
					{
						break;
					}
					if (x0467b00af7810f0c == null)
					{
						goto IL_8F;
					}
					if (x0467b00af7810f0c.Manager != null)
					{
						goto IL_71;
					}
					if (2147483647 != 0)
					{
						goto IL_17;
					}
					if (!false)
					{
						goto IL_71;
					}
					IL_9C:
					if (2 == 0)
					{
						continue;
					}
					goto IL_123;
					IL_71:
					if (this.x10ac79a4257c7f52 != null)
					{
						goto IL_9C;
					}
					goto IL_BB;
				}
				return;
				IL_8F:
				goto IL_17;
				IL_BB:
				x10ac79a4257c7f52 autoHideBar = x0467b00af7810f0c.Manager.GetAutoHideBar(x0467b00af7810f0c.Dock);
				IL_11E:
				if (autoHideBar != null)
				{
					IL_AD:
					autoHideBar.x7fdaeb05cb5e84f3.xd6b6ed77479ef68c(this);
					return;
				}
				if (!true)
				{
					goto IL_4A;
				}
				return;
				IL_123:
				goto IL_4C;
			}
			if (4 != 0)
			{
				goto IL_125;
			}
			goto IL_AD;
			IL_17:
			if (this.x10ac79a4257c7f52 != null)
			{
				goto IL_4F;
			}
			if (3 == 0)
			{
				goto IL_20C;
			}
			IL_4A:
			if (255 == 0)
			{
				goto IL_207;
			}
			return;
			IL_4C:
			if (!false)
			{
				goto IL_17;
			}
			IL_4F:
			this.x10ac79a4257c7f52.x7fdaeb05cb5e84f3.x52b190e626f65140(this);
			return;
			IL_207:
			goto IL_26D;
			IL_20C:
			using (IEnumerator enumerator3 = this.Controls.GetEnumerator())
			{
				while (enumerator3.MoveNext())
				{
					object obj3 = enumerator3.Current;
					DockControl dockControl3 = (DockControl)obj3;
					if (dockControl3.Parent == base.DockContainer)
					{
						LayoutUtilities.xa7513d57b4844d46(dockControl3);
					}
				}
				goto IL_1EC;
			}
			IL_26D:
			if (!base.IsInContainer)
			{
				goto IL_1EC;
			}
			goto IL_20C;
		}

		// Token: 0x060001F0 RID: 496 RVA: 0x000118FC File Offset: 0x000108FC
		public virtual DockControl GetControlAt(Point position)
		{
			if (this.xa358da7dd5364cab.Contains(position))
			{
				if (!false)
				{
					if (this.x26e80f23e22a05ae.xda73fcb97c77d998.Contains(position))
					{
						goto IL_36;
					}
				}
				if (!this.x65911b61bef3a921.xda73fcb97c77d998.Contains(position))
				{
					using (IEnumerator enumerator = this.xe477cc01ecfef1fb.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							DockControl dockControl;
							do
							{
								dockControl = (DockControl)enumerator.Current;
							}
							while (3 == 0);
							Rectangle x123e054dab = dockControl.x123e054dab107457;
							if (x123e054dab.Contains(position))
							{
								return dockControl;
							}
						}
						goto IL_36;
					}
					DockControl result;
					return result;
				}
			}
			IL_36:
			return null;
		}

		// Token: 0x060001F1 RID: 497 RVA: 0x000119C4 File Offset: 0x000109C4
		internal int x17fd454c85fad336(Point x13d4cb8d1bd20347)
		{
			int num = 0;
			IEnumerator enumerator = this.xe477cc01ecfef1fb.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					DockControl dockControl = (DockControl)obj;
					Rectangle x123e054dab = dockControl.x123e054dab107457;
					while (x13d4cb8d1bd20347.X > x123e054dab.Left + x123e054dab.Width / 2)
					{
						num++;
						bool flag = ((uint)num & 0U) == 0U;
						if (flag)
						{
							break;
						}
					}
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if ((uint)num - (uint)num < 0U || 15 != 0)
				{
					goto IL_8B;
				}
				IL_70:
				disposable.Dispose();
				if (((uint)num & 0U) == 0U && (uint)num >= 0U)
				{
					goto IL_BF;
				}
				IL_8B:
				if (disposable != null)
				{
					goto IL_70;
				}
				IL_BF:;
			}
			return num;
		}

		// Token: 0x060001F2 RID: 498 RVA: 0x00011AB0 File Offset: 0x00010AB0
		internal void x3e0280cae730d1f2()
		{
			if (this.x10ac79a4257c7f52 != null)
			{
				goto IL_4F;
			}
			IL_1D:
			if (base.IsInContainer)
			{
				goto IL_62;
			}
			if (4 != 0)
			{
				return;
			}
			IL_4F:
			this.x10ac79a4257c7f52.x200394302d96eb9b(this);
			if (-2147483648 != 0)
			{
				goto IL_1D;
			}
			IL_62:
			if (base.DockContainer.IsFloating)
			{
				base.DockContainer.CalculateAllMetricsAndLayout();
			}
			else
			{
				base.DockContainer.xec9697acef66c1bc(this, base.Bounds);
			}
			base.DockContainer.Invalidate(base.Bounds);
		}

		// Token: 0x060001F3 RID: 499 RVA: 0x00011B30 File Offset: 0x00010B30
		private void x5425d90305f1baa5()
		{
			int num;
			bool flag;
			int num2;
			if (this.xbf5c00c8e3dd85fc == null)
			{
				flag = (((uint)num | uint.MaxValue) == 0U);
				if (flag)
				{
					goto IL_122;
				}
				if (15 != 0)
				{
					this.x26e80f23e22a05ae.x364c1e3b189d47fe = false;
					this.x65911b61bef3a921.x364c1e3b189d47fe = false;
					this.x3b444f64233558c3.x364c1e3b189d47fe = false;
					return;
				}
				goto IL_F1;
			}
			else
			{
				num2 = this.xb48529af1739dd06.Top + this.xb48529af1739dd06.Height / 2 - 7;
				if (!false)
				{
					num = this.xb48529af1739dd06.Right - 2;
					if (!this.xbf5c00c8e3dd85fc.AllowClose)
					{
						this.x26e80f23e22a05ae.x364c1e3b189d47fe = false;
						goto IL_CA;
					}
					this.x26e80f23e22a05ae.x364c1e3b189d47fe = true;
				}
				this.x26e80f23e22a05ae.xda73fcb97c77d998 = new Rectangle(num - 19, num2, 19, 15);
				if ((uint)num - (uint)num2 >= 0U)
				{
					goto IL_1C6;
				}
				goto IL_10B;
			}
			IL_7F:
			if (this.xbf5c00c8e3dd85fc.ShowOptions)
			{
				this.x3b444f64233558c3.x364c1e3b189d47fe = true;
				this.x3b444f64233558c3.xda73fcb97c77d998 = new Rectangle(num - 19, num2, 19, 15);
				num -= 21;
				return;
			}
			this.x3b444f64233558c3.x364c1e3b189d47fe = false;
			if ((uint)num - (uint)num2 > 4294967295U)
			{
				goto IL_1C6;
			}
			if (2 != 0)
			{
				if (!true)
				{
					goto IL_122;
				}
				return;
			}
			IL_95:
			if ((uint)num2 - (uint)num2 < 0U)
			{
				goto IL_122;
			}
			IL_B0:
			this.x65911b61bef3a921.x364c1e3b189d47fe = false;
			goto IL_7F;
			IL_CA:
			if (this.x43d7533e3cdb2944)
			{
				goto IL_10B;
			}
			flag = ((uint)num2 + (uint)num < 0U);
			if (!flag)
			{
				goto IL_95;
			}
			if (!false)
			{
				goto IL_122;
			}
			IL_F1:
			flag = (((uint)num | 1U) == 0U);
			if (!flag)
			{
				goto IL_155;
			}
			IL_10B:
			if (!base.IsInContainer)
			{
				goto IL_153;
			}
			IL_113:
			if (!base.DockContainer.x0c2484ccd29b8358)
			{
				goto IL_B0;
			}
			goto IL_F1;
			IL_122:
			goto IL_113;
			IL_14E:
			goto IL_7F;
			IL_153:
			IL_155:
			this.x65911b61bef3a921.x364c1e3b189d47fe = true;
			this.x65911b61bef3a921.xda73fcb97c77d998 = new Rectangle(num - 19, num2, 19, 15);
			num -= 21;
			goto IL_14E;
			IL_1C6:
			if ((uint)num - (uint)num > 4294967295U)
			{
				goto IL_14E;
			}
			num -= 21;
			flag = ((uint)num2 - (uint)num < 0U);
			if (!flag)
			{
				flag = (((uint)num | 1U) == 0U);
				if (!flag)
				{
					goto IL_CA;
				}
				flag = (((uint)num2 | 4294967294U) == 0U);
				if (flag)
				{
					goto IL_122;
				}
				goto IL_153;
			}
		}

		// Token: 0x060001F4 RID: 500 RVA: 0x00011DE4 File Offset: 0x00010DE4
		protected internal virtual void LayoutCollapsed(RendererBase renderer, Rectangle bounds)
		{
			this.xb48529af1739dd06 = bounds;
			this.xb48529af1739dd06.Offset(0, renderer.TitleBarMetrics.Margin.Top);
			this.xb48529af1739dd06.Height = renderer.TitleBarMetrics.Height - (renderer.TitleBarMetrics.Margin.Top + renderer.TitleBarMetrics.Margin.Bottom);
			for (;;)
			{
				if (-2 != 0)
				{
				}
				this.x5425d90305f1baa5();
				bounds.Offset(0, renderer.TitleBarMetrics.Height);
				bounds.Height -= renderer.TitleBarMetrics.Height;
				this.x21ed2ecc088ef4e4 = bounds;
				this.xa358da7dd5364cab = Rectangle.Empty;
				using (IEnumerator enumerator = this.xe477cc01ecfef1fb.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						object obj = enumerator.Current;
						DockControl dockControl = (DockControl)obj;
						Rectangle bounds2 = renderer.AdjustDockControlClientBounds(this, dockControl, this.x21ed2ecc088ef4e4);
						if (-2147483648 == 0)
						{
							break;
						}
						dockControl.xbdd4aaac1291a8c7(dockControl == this.xbf5c00c8e3dd85fc);
						dockControl.Bounds = bounds2;
					}
					break;
				}
			}
		}

		// Token: 0x060001F5 RID: 501 RVA: 0x00011F2C File Offset: 0x00010F2C
		protected virtual void CalculateLayout(RendererBase renderer, Rectangle bounds, bool floating, out Rectangle titlebarBounds, out Rectangle tabstripBounds, out Rectangle clientBounds, out Rectangle joinCatchmentBounds)
		{
			if (floating)
			{
				goto IL_15D;
			}
			goto IL_16B;
			IL_10F:
			if (this.Controls.Count <= 1 && !base.DockContainer.x972331c8ecf83413)
			{
				tabstripBounds = Rectangle.Empty;
			}
			else
			{
				tabstripBounds = bounds;
				tabstripBounds.Y = tabstripBounds.Bottom - renderer.TabStripMetrics.Height;
				tabstripBounds.Height = renderer.TabStripMetrics.Height;
				tabstripBounds = renderer.TabStripMetrics.RemoveMargin(tabstripBounds);
				bounds.Height -= renderer.TabStripMetrics.Height;
			}
			clientBounds = bounds;
			if ((floating ? 1U : 0U) - (floating ? 1U : 0U) > 4294967295U)
			{
				goto IL_1BF;
			}
			if (((floating ? 1U : 0U) & 0U) == 0U)
			{
				joinCatchmentBounds = titlebarBounds;
				if (((floating ? 1U : 0U) | 2U) == 0U)
				{
					goto IL_16B;
				}
			}
			bool flag = (floating ? 1U : 0U) + (floating ? 1U : 0U) > uint.MaxValue;
			if (!flag)
			{
				return;
			}
			IL_15D:
			titlebarBounds = Rectangle.Empty;
			goto IL_10F;
			IL_16B:
			titlebarBounds = bounds;
			titlebarBounds.Offset(0, renderer.TitleBarMetrics.Margin.Top);
			titlebarBounds.Height = renderer.TitleBarMetrics.Height - (renderer.TitleBarMetrics.Margin.Top + renderer.TitleBarMetrics.Margin.Bottom);
			IL_1BF:
			this.x5425d90305f1baa5();
			bounds.Offset(0, renderer.TitleBarMetrics.Height);
			bounds.Height -= renderer.TitleBarMetrics.Height;
			goto IL_10F;
		}

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x060001F6 RID: 502 RVA: 0x00012110 File Offset: 0x00011110
		internal Rectangle xccb1fc68964285c2
		{
			get
			{
				return this.xc78399ba98eab19f;
			}
		}

		// Token: 0x060001F7 RID: 503 RVA: 0x00012118 File Offset: 0x00011118
		private void x7fd1f193b21c8833()
		{
			foreach (object obj in this.Controls)
			{
				DockControl dockControl = (DockControl)obj;
				dockControl.x44fd51d909a57a2a();
			}
		}

		// Token: 0x060001F8 RID: 504 RVA: 0x00012180 File Offset: 0x00011180
		protected internal override void Layout(RendererBase renderer, Graphics graphics, Rectangle bounds, bool floating)
		{
			base.Layout(renderer, graphics, bounds, floating);
			if (4 != 0)
			{
				for (;;)
				{
					this.x7fd1f193b21c8833();
					if ((false || this.Collapsed) && base.DockContainer.x0c2484ccd29b8358)
					{
						break;
					}
					this.CalculateLayout(renderer, bounds, floating, out this.xb48529af1739dd06, out this.xa358da7dd5364cab, out this.x21ed2ecc088ef4e4, out this.xc78399ba98eab19f);
					if ((floating ? 1U : 0U) >= 0U)
					{
						this.xd30df1068ed42e28 = true;
						try
						{
							if (this.xb48529af1739dd06 != Rectangle.Empty)
							{
								this.x5425d90305f1baa5();
							}
							this.x5d6e30ce9634c49e(renderer, graphics, this.xa358da7dd5364cab);
							foreach (object obj in this.xe477cc01ecfef1fb)
							{
								DockControl dockControl = (DockControl)obj;
								if (dockControl != this.SelectedControl)
								{
									dockControl.xbdd4aaac1291a8c7(false);
								}
							}
							using (IEnumerator enumerator2 = this.xe477cc01ecfef1fb.GetEnumerator())
							{
								for (;;)
								{
									DockControl dockControl2;
									if (!enumerator2.MoveNext())
									{
										if (!false)
										{
											break;
										}
									}
									else
									{
										dockControl2 = (DockControl)enumerator2.Current;
									}
									if (dockControl2 == this.SelectedControl)
									{
										Rectangle bounds2 = renderer.AdjustDockControlClientBounds(this, dockControl2, this.x21ed2ecc088ef4e4);
										dockControl2.Bounds = bounds2;
										dockControl2.xbdd4aaac1291a8c7(true);
									}
								}
							}
							return;
						}
						finally
						{
							this.xd30df1068ed42e28 = false;
						}
					}
				}
				return;
			}
		}

		// Token: 0x060001F9 RID: 505 RVA: 0x00012344 File Offset: 0x00011344
		private void x5d6e30ce9634c49e(RendererBase x38870620fd380a6b, Graphics x41347a961b838962, Rectangle xa358da7dd5364cab)
		{
			int num = 0;
			for (;;)
			{
				IL_3C6:
				int num2 = xa358da7dd5364cab.Width - (x38870620fd380a6b.TabStripMetrics.Padding.Left + x38870620fd380a6b.TabStripMetrics.Padding.Right);
				for (;;)
				{
					int[] array = new int[this.xe477cc01ecfef1fb.Count];
					int num3 = 0;
					int num4;
					int num5;
					int num6;
					int i;
					int num7;
					foreach (object obj in this.xe477cc01ecfef1fb)
					{
						DockControl dockControl = (DockControl)obj;
						dockControl.xcfac6723d8a41375 = false;
						num4 = x38870620fd380a6b.MeasureTabStripTab(x41347a961b838962, dockControl.TabImage, dockControl.TabText, dockControl.Font, DrawItemState.Default).Width;
						bool flag = ((uint)num4 | 255U) == 0U;
						if (flag)
						{
							goto IL_302;
						}
						goto IL_294;
						IL_270:
						num += num4;
						array[num3++] = num4;
						flag = ((uint)num5 + (uint)num2 > uint.MaxValue);
						if (!flag)
						{
							if ((uint)num6 + (uint)num5 > 4294967295U)
							{
								goto IL_294;
							}
							if (((uint)num6 & 0U) != 0U)
							{
								goto IL_292;
							}
						}
						flag = ((uint)i < 0U);
						if (flag)
						{
							goto IL_302;
						}
						continue;
						IL_25C:
						if (dockControl.MaximumTabWidth != 0)
						{
							goto IL_265;
						}
						goto IL_270;
						IL_292:
						goto IL_25C;
						IL_265:
						if (dockControl.MaximumTabWidth >= num4)
						{
							goto IL_270;
						}
						IL_27B:
						num4 = dockControl.MaximumTabWidth;
						dockControl.xcfac6723d8a41375 = true;
						goto IL_270;
						IL_294:
						if (dockControl.MinimumTabWidth != 0)
						{
							goto IL_31D;
						}
						flag = ((uint)num7 - (uint)num2 > uint.MaxValue);
						if (!flag)
						{
							goto IL_25C;
						}
						flag = ((uint)i + (uint)num6 > uint.MaxValue);
						if (flag)
						{
							goto IL_27B;
						}
						goto IL_265;
						IL_302:
						if ((uint)num6 - (uint)i < 0U)
						{
							goto IL_294;
						}
						IL_31D:
						num4 = Math.Max(num4, dockControl.MinimumTabWidth);
						goto IL_292;
					}
					for (;;)
					{
						if (num > num2)
						{
							num6 = num - num2;
							for (i = 0; i < num3; i++)
							{
								array[i] -= (int)((float)num6 * ((float)array[i] / (float)num));
								this.xe477cc01ecfef1fb[i].xcfac6723d8a41375 = true;
							}
						}
						xa358da7dd5364cab = x38870620fd380a6b.TabStripMetrics.RemovePadding(xa358da7dd5364cab);
						bool flag = (uint)i - (uint)num7 > uint.MaxValue;
						if (flag)
						{
							break;
						}
						flag = ((uint)num7 < 0U);
						if (!flag)
						{
							num7 = xa358da7dd5364cab.Left;
							num3 = 0;
							num5 = 0;
							goto IL_07;
						}
						IL_119:
						BoxModel tabMetrics = x38870620fd380a6b.TabMetrics;
						if ((uint)num4 > 4294967295U)
						{
							goto IL_E6;
						}
						IL_62:
						Rectangle x123e054dab = new Rectangle(num7 + tabMetrics.Margin.Left, xa358da7dd5364cab.Top + tabMetrics.Margin.Top, tabMetrics.Padding.Left + array[num3] + tabMetrics.Padding.Right, xa358da7dd5364cab.Height - (tabMetrics.Margin.Top + tabMetrics.Margin.Bottom));
						if ((uint)num7 + (uint)num < 0U)
						{
							continue;
						}
						IL_E6:
						if ((uint)num3 < 0U)
						{
							goto IL_62;
						}
						DockControl dockControl2;
						dockControl2.x123e054dab107457 = x123e054dab;
						num7 += x123e054dab.Width + tabMetrics.ExtraWidth;
						flag = ((uint)num7 > uint.MaxValue);
						if (!flag)
						{
							do
							{
								num3++;
								num5++;
							}
							while ((uint)i - (uint)num > 4294967295U);
						}
						if (!true)
						{
							return;
						}
						goto IL_07;
						IL_40A:
						goto IL_119;
						IL_07:
						if (num5 < this.xe477cc01ecfef1fb.Count)
						{
							dockControl2 = this.xe477cc01ecfef1fb[num5];
							goto IL_40A;
						}
						if (!false)
						{
							return;
						}
						flag = ((uint)num6 > uint.MaxValue);
						if (flag)
						{
							goto IL_119;
						}
						goto IL_3C6;
					}
				}
			}
		}

		// Token: 0x0400007D RID: 125
		private const int x1e9b7c427b6c44fa = 19;

		// Token: 0x0400007E RID: 126
		private const int x26539fe4604823df = 15;

		// Token: 0x0400007F RID: 127
		private ControlLayoutSystem.DockControlCollection xe477cc01ecfef1fb;

		// Token: 0x04000080 RID: 128
		private bool xb9835bbd335d127e;

		// Token: 0x04000081 RID: 129
		internal Rectangle xb48529af1739dd06;

		// Token: 0x04000082 RID: 130
		internal Rectangle xa358da7dd5364cab;

		// Token: 0x04000083 RID: 131
		internal Rectangle x21ed2ecc088ef4e4;

		// Token: 0x04000084 RID: 132
		internal Rectangle xc78399ba98eab19f;

		// Token: 0x04000085 RID: 133
		private DockControl xbf5c00c8e3dd85fc;

		// Token: 0x04000086 RID: 134
		private Guid xb51cd75f17ace1ec = Guid.NewGuid();

		// Token: 0x04000087 RID: 135
		private bool xf111a0cc60fdac46;

		// Token: 0x04000088 RID: 136
		private x10ac79a4257c7f52 x4fb7dbcd13b8ce4b;

		// Token: 0x04000089 RID: 137
		private x0a9f5257a10031b2 x26e80f23e22a05ae;

		// Token: 0x0400008A RID: 138
		private x0a9f5257a10031b2 x65911b61bef3a921;

		// Token: 0x0400008B RID: 139
		private x0a9f5257a10031b2 x3b444f64233558c3;

		// Token: 0x0400008C RID: 140
		private x0a9f5257a10031b2 x502580ccb6d2ffd4;

		// Token: 0x0400008D RID: 141
		internal bool xfa5e20eb950b9ee1;

		// Token: 0x0400008E RID: 142
		private Point x6afebf16b45c02e0 = Point.Empty;

		// Token: 0x0400008F RID: 143
		private bool x04c163da360b887e;

		// Token: 0x04000090 RID: 144
		internal bool xd30df1068ed42e28;

		// Token: 0x04000092 RID: 146
		private bool x49cf4e0157d9436c;

		// Token: 0x04000093 RID: 147
		private bool xd34ff54c5dd91133;

		// Token: 0x02000030 RID: 48
		public class DockControlCollection : CollectionBase
		{
			// Token: 0x0600040B RID: 1035 RVA: 0x00020A14 File Offset: 0x0001FA14
			internal DockControlCollection(ControlLayoutSystem parent)
			{
				this.xb6a159a84cb992d6 = parent;
			}

			// Token: 0x0600040C RID: 1036 RVA: 0x00020A24 File Offset: 0x0001FA24
			internal int x259d21cdec19b1cf(int xff665e1cf667e663, bool x1743ddb153315e91)
			{
				if (xff665e1cf667e663 >= 0 && xff665e1cf667e663 <= base.Count)
				{
					if (false)
					{
						if (!false)
						{
							bool flag = (x1743ddb153315e91 ? 1U : 0U) - (x1743ddb153315e91 ? 1U : 0U) > uint.MaxValue;
							if (flag)
							{
								goto IL_3F;
							}
						}
						goto IL_0B;
					}
					IL_3F:
					return xff665e1cf667e663;
				}
				IL_0B:
				xff665e1cf667e663 = ((!x1743ddb153315e91) ? 0 : base.Count);
				return xff665e1cf667e663;
			}

			// Token: 0x0600040D RID: 1037 RVA: 0x00020A78 File Offset: 0x0001FA78
			public void SetChildIndex(DockControl control, int index)
			{
				if (control == null)
				{
					if (!false)
					{
						goto IL_A5;
					}
					bool flag = (uint)index < 0U;
					if (!flag)
					{
						goto IL_7C;
					}
				}
				else
				{
					if (!this.Contains(control))
					{
						goto IL_7C;
					}
					if (-2 != 0)
					{
						if (index == this.IndexOf(control))
						{
							return;
						}
						if (this.IndexOf(control) < index)
						{
							index--;
						}
					}
				}
				this.xa536df1e17daee9d = true;
				base.List.Remove(control);
				base.List.Insert(index, control);
				this.xa536df1e17daee9d = false;
				if (8 != 0)
				{
				}
				this.xb6a159a84cb992d6.x3e0280cae730d1f2();
				if (-1 != 0)
				{
					if (255 == 0)
					{
						goto IL_A5;
					}
					return;
				}
				IL_7C:
				throw new ArgumentOutOfRangeException("control");
				IL_A5:
				throw new ArgumentNullException("control");
			}

			// Token: 0x0600040E RID: 1038 RVA: 0x00020B38 File Offset: 0x0001FB38
			protected override void OnClear()
			{
				base.OnClear();
				foreach (object obj in this)
				{
					DockControl dockControl = (DockControl)obj;
					dockControl.xb2b69aae23a4ae6d(null);
					dockControl.x44fd51d909a57a2a();
				}
			}

			// Token: 0x0600040F RID: 1039 RVA: 0x00020BA8 File Offset: 0x0001FBA8
			protected override void OnClearComplete()
			{
				base.OnClearComplete();
				this.xb6a159a84cb992d6.SelectedControl = null;
				this.xb6a159a84cb992d6.x3e0280cae730d1f2();
				if (this.xb6a159a84cb992d6.DockContainer != null)
				{
					this.xb6a159a84cb992d6.DockContainer.x5fc4eceec879ff0f();
				}
			}

			// Token: 0x06000410 RID: 1040 RVA: 0x00020BE4 File Offset: 0x0001FBE4
			protected override void OnInsertComplete(int index, object value)
			{
				base.OnInsertComplete(index, value);
				if (this.xa536df1e17daee9d)
				{
					return;
				}
				DockControl dockControl = (DockControl)value;
				for (;;)
				{
					dockControl.xb2b69aae23a4ae6d(this.xb6a159a84cb992d6);
					if (!this.xb6a159a84cb992d6.IsInContainer)
					{
						goto IL_15D;
					}
					goto IL_1A1;
					IL_1C:
					while (!this.x6278c23b2376c7c7)
					{
						this.xb6a159a84cb992d6.x3e0280cae730d1f2();
						if ((uint)index - (uint)index <= 4294967295U)
						{
							if (255 != 0)
							{
								return;
							}
							goto IL_AB;
						}
					}
					if ((uint)index - (uint)index >= 0U)
					{
						break;
					}
					continue;
					IL_132:
					bool flag;
					while (this.xb6a159a84cb992d6.IsInContainer)
					{
						dockControl.x56e964269d48cfcc(this.xb6a159a84cb992d6.DockContainer);
						flag = ((uint)index + (uint)index > uint.MaxValue);
						if (flag)
						{
							goto IL_1A1;
						}
						if (!false)
						{
							if (!false)
							{
								IL_DA:
								while (this.xb6a159a84cb992d6.IsInContainer)
								{
									if (dockControl.Parent == null)
									{
										if (false)
										{
											goto IL_15D;
										}
									}
									else
									{
										LayoutUtilities.xa7513d57b4844d46(dockControl);
									}
									dockControl.Parent = this.xb6a159a84cb992d6.x0e40cec3a0be4a70;
									if ((uint)index + (uint)index >= 0U)
									{
										IL_B9:
										if (this.xb6a159a84cb992d6.xbf5c00c8e3dd85fc == null)
										{
											goto IL_AB;
										}
										flag = ((uint)index > uint.MaxValue);
										if (!flag)
										{
											flag = ((uint)index > uint.MaxValue);
											if (flag)
											{
												goto IL_84;
											}
											goto IL_99;
										}
									}
								}
								goto IL_B9;
								IL_129:
								goto IL_DA;
							}
						}
					}
					goto IL_129;
					IL_84:
					this.xb6a159a84cb992d6.DockContainer.x5fc4eceec879ff0f();
					goto IL_1C;
					IL_99:
					if (this.xb6a159a84cb992d6.DockContainer == null)
					{
						goto IL_1C;
					}
					goto IL_84;
					IL_AB:
					this.xb6a159a84cb992d6.SelectedControl = dockControl;
					goto IL_99;
					IL_1A1:
					if (this.xb6a159a84cb992d6.DockContainer.Manager == null)
					{
						flag = ((uint)index - (uint)index > uint.MaxValue);
						if (!flag)
						{
							if (!false)
							{
								goto IL_132;
							}
						}
					}
					else
					{
						if (this.xb6a159a84cb992d6.DockContainer.Manager == dockControl.Manager)
						{
							goto IL_132;
						}
						flag = (((uint)index & 0U) == 0U);
						if (flag)
						{
							dockControl.Manager = this.xb6a159a84cb992d6.DockContainer.Manager;
							goto IL_132;
						}
						goto IL_84;
					}
					IL_15D:
					flag = (((uint)index & 0U) == 0U);
					if (flag)
					{
						goto IL_132;
					}
					goto IL_1A1;
				}
			}

			// Token: 0x06000411 RID: 1041 RVA: 0x00020E5C File Offset: 0x0001FE5C
			protected override void OnRemoveComplete(int index, object value)
			{
				base.OnRemoveComplete(index, value);
				bool flag = ((uint)index | 2147483648U) == 0U;
				if (!flag)
				{
					goto IL_12B;
				}
				if (!false)
				{
					goto IL_7A;
				}
				IL_26:
				if (this.xb6a159a84cb992d6.xe477cc01ecfef1fb.Count != 0)
				{
					this.xb6a159a84cb992d6.SelectedControl = this[0];
				}
				else
				{
					this.xb6a159a84cb992d6.SelectedControl = null;
					if (255 == 0)
					{
						goto IL_96;
					}
					flag = ((uint)index + (uint)index > uint.MaxValue);
					if (flag)
					{
						goto IL_12B;
					}
				}
				IL_4A:
				if (this.xb6a159a84cb992d6.DockContainer != null)
				{
					this.xb6a159a84cb992d6.DockContainer.x5fc4eceec879ff0f();
					if (false)
					{
						return;
					}
				}
				IL_6D:
				this.xb6a159a84cb992d6.x3e0280cae730d1f2();
				return;
				IL_7A:
				goto IL_4A;
				IL_96:
				if (false)
				{
					goto IL_6D;
				}
				if ((uint)index - (uint)index > 4294967295U)
				{
					return;
				}
				IL_C9:
				if (this.xb6a159a84cb992d6.xbf5c00c8e3dd85fc == value)
				{
					goto IL_26;
				}
				goto IL_4A;
				IL_12B:
				if (!this.xa536df1e17daee9d)
				{
					DockControl dockControl = (DockControl)value;
					dockControl.xb2b69aae23a4ae6d(null);
					dockControl.x44fd51d909a57a2a();
					while (dockControl.Parent != null)
					{
						if (dockControl.Parent != this.xb6a159a84cb992d6.x0e40cec3a0be4a70)
						{
							goto IL_C9;
						}
						LayoutUtilities.xa7513d57b4844d46(dockControl);
						flag = ((uint)index + (uint)index > uint.MaxValue);
						if (!flag)
						{
							goto IL_C9;
						}
					}
					flag = ((uint)index < 0U);
					if (flag)
					{
						goto IL_15D;
					}
					goto IL_96;
				}
				return;
				IL_15D:
				goto IL_7A;
			}

			// Token: 0x06000412 RID: 1042 RVA: 0x00020FCC File Offset: 0x0001FFCC
			public void AddRange(DockControl[] controls)
			{
				this.x6278c23b2376c7c7 = true;
				do
				{
					int i = 0;
					while (i < controls.Length)
					{
						DockControl control = controls[i];
						this.Add(control);
						do
						{
							i++;
						}
						while (8 == 0);
					}
					this.x6278c23b2376c7c7 = false;
					this.xb6a159a84cb992d6.x3e0280cae730d1f2();
				}
				while (false);
			}

			// Token: 0x06000413 RID: 1043 RVA: 0x00021024 File Offset: 0x00020024
			public int Add(DockControl control)
			{
				if (base.List.Contains(control))
				{
					throw new InvalidOperationException("The DockControl already belongs to this ControlLayoutSystem.");
				}
				int count = base.Count;
				this.Insert(count, control);
				return count;
			}

			// Token: 0x06000414 RID: 1044 RVA: 0x0002105C File Offset: 0x0002005C
			public void Insert(int index, DockControl control)
			{
				if (control == null)
				{
					return;
				}
				if (control.LayoutSystem != this.xb6a159a84cb992d6)
				{
					goto IL_93;
				}
				if (this.IndexOf(control) == index)
				{
					return;
				}
				while (base.Count != 1)
				{
					for (;;)
					{
						if ((uint)index - (uint)index <= 4294967295U)
						{
							if ((uint)index + (uint)index <= 4294967295U)
							{
								goto IL_93;
							}
						}
						if (false)
						{
							break;
						}
						if ((uint)index + (uint)index > 4294967295U)
						{
							goto IL_16;
						}
						if (4 != 0)
						{
							goto IL_93;
						}
					}
				}
				return;
				IL_0D:
				if (true)
				{
					goto IL_28;
				}
				goto IL_4C;
				IL_16:
				if ((uint)index > 4294967295U)
				{
					goto IL_0D;
				}
				IL_28:
				control.LayoutSystem.Controls.Remove(control);
				IL_39:
				base.List.Insert(index, control);
				return;
				IL_4C:
				if (!this.Contains(control))
				{
					goto IL_28;
				}
				if (this.IndexOf(control) >= index)
				{
					goto IL_16;
				}
				index--;
				goto IL_0D;
				IL_93:
				if (control.LayoutSystem != null)
				{
					goto IL_4C;
				}
				goto IL_39;
			}

			// Token: 0x17000108 RID: 264
			public DockControl this[int index]
			{
				get
				{
					return (DockControl)base.List[index];
				}
			}

			// Token: 0x06000416 RID: 1046 RVA: 0x0002117C File Offset: 0x0002017C
			public void Remove(DockControl control)
			{
				if (control == null)
				{
					throw new ArgumentNullException("control");
				}
				base.List.Remove(control);
			}

			// Token: 0x06000417 RID: 1047 RVA: 0x00021198 File Offset: 0x00020198
			public bool Contains(DockControl control)
			{
				return base.List.Contains(control);
			}

			// Token: 0x06000418 RID: 1048 RVA: 0x000211A8 File Offset: 0x000201A8
			public int IndexOf(DockControl control)
			{
				return base.List.IndexOf(control);
			}

			// Token: 0x06000419 RID: 1049 RVA: 0x000211B8 File Offset: 0x000201B8
			public void CopyTo(DockControl[] array, int index)
			{
				base.List.CopyTo(array, index);
			}

			// Token: 0x04000157 RID: 343
			private ControlLayoutSystem xb6a159a84cb992d6;

			// Token: 0x04000158 RID: 344
			private bool x6278c23b2376c7c7;

			// Token: 0x04000159 RID: 345
			private bool xa536df1e17daee9d;
		}

		// Token: 0x0200003D RID: 61
		// (Invoke) Token: 0x06000492 RID: 1170
		internal delegate void xf09a9df3c262275d(DockControl oldSelection, DockControl newSelection);
	}
}
