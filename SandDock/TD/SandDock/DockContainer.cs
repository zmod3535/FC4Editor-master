using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Divelements.Util.Registration;
using TD.SandDock.Design;
using TD.SandDock.Rendering;
using TD.Util;

namespace TD.SandDock
{
	// Token: 0x02000014 RID: 20
	[Designer(typeof(DockContainerDesigner))]
	[LicenseProvider(typeof(x294bd621a33dc533))]
	[ToolboxItem(false)]
	public class DockContainer : ContainerControl
	{
		// Token: 0x14000014 RID: 20
		// (add) Token: 0x06000246 RID: 582 RVA: 0x00015060 File Offset: 0x00014060
		// (remove) Token: 0x06000247 RID: 583 RVA: 0x0001507C File Offset: 0x0001407C
		public event EventHandler DockingStarted
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.xc5f1fda5242cf905 = (EventHandler)Delegate.Combine(this.xc5f1fda5242cf905, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.xc5f1fda5242cf905 = (EventHandler)Delegate.Remove(this.xc5f1fda5242cf905, value);
			}
		}

		// Token: 0x14000015 RID: 21
		// (add) Token: 0x06000248 RID: 584 RVA: 0x00015098 File Offset: 0x00014098
		// (remove) Token: 0x06000249 RID: 585 RVA: 0x000150B4 File Offset: 0x000140B4
		public event EventHandler DockingFinished
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.x2556ec4d28ceecee = (EventHandler)Delegate.Combine(this.x2556ec4d28ceecee, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.x2556ec4d28ceecee = (EventHandler)Delegate.Remove(this.x2556ec4d28ceecee, value);
			}
		}

		// Token: 0x0600024A RID: 586 RVA: 0x000150D0 File Offset: 0x000140D0
		public DockContainer()
		{
			if (!false)
			{
				this.x266365ea27fa7af8 = (LicenseManager.Validate(typeof(DockContainer), this) as xbd7c5470fc89975b);
				this.x35c76d526f88c3c8 = new SplitLayoutSystem();
				while (255 != 0)
				{
					this.x35c76d526f88c3c8.x56e964269d48cfcc(this);
					base.SetStyle(ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
					base.SetStyle(ControlStyles.Selectable, false);
					if (-2147483648 != 0)
					{
						this.x83627743ea4ce5a2 = new ArrayList();
						this.xac1c850120b1f254 = new xf8f9565783602018(this);
						this.xac1c850120b1f254.xa6e4f463e64a5987 = false;
						if (-2 == 0)
						{
							continue;
						}
					}
					goto IL_2A;
				}
				return;
			}
			IL_2A:
			this.xac1c850120b1f254.x9b21ee8e7ceaada3 += this.xa3a7472ac4e61f76;
			this.BackColor = SystemColors.Control;
		}

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x0600024B RID: 587 RVA: 0x000151BC File Offset: 0x000141BC
		internal Rectangle x0c42f19be578ccee
		{
			get
			{
				return this.x59f159fe47159543;
			}
		}

		// Token: 0x0600024C RID: 588 RVA: 0x000151C4 File Offset: 0x000141C4
		internal virtual void x5fc4eceec879ff0f()
		{
		}

		// Token: 0x0600024D RID: 589 RVA: 0x000151C8 File Offset: 0x000141C8
		protected override void OnParentChanged(EventArgs e)
		{
			base.OnParentChanged(e);
			while (this.Manager == null)
			{
				if (-1 != 0)
				{
					return;
				}
				if (!false)
				{
					break;
				}
			}
			if (base.Parent == null)
			{
				if (false)
				{
					return;
				}
				if (!false)
				{
					return;
				}
			}
			if (base.Parent is xd936980ea1aac341)
			{
				return;
			}
			this.Manager.DockSystemContainer = base.Parent;
		}

		// Token: 0x0600024E RID: 590 RVA: 0x0001522C File Offset: 0x0001422C
		internal void x8ba6fce4f4601549(ShowControlContextMenuEventArgs xfbf34718e704c6bc)
		{
			if (this.Manager != null)
			{
				this.Manager.OnShowControlContextMenu(xfbf34718e704c6bc);
			}
		}

		// Token: 0x0600024F RID: 591 RVA: 0x00015244 File Offset: 0x00014244
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (false || this.xa2c39ea75c543fc7 != null)
				{
					this.xa2c39ea75c543fc7.Dispose();
					goto IL_45;
				}
				if ((disposing ? 1U : 0U) - (disposing ? 1U : 0U) < 0U)
				{
					goto IL_45;
				}
				IL_05:
				this.Manager = null;
				this.xac1c850120b1f254.x9b21ee8e7ceaada3 -= this.xa3a7472ac4e61f76;
				this.xac1c850120b1f254.Dispose();
				goto IL_2E;
				IL_45:
				this.xa2c39ea75c543fc7 = null;
				goto IL_05;
			}
			IL_2E:
			base.Dispose(disposing);
		}

		// Token: 0x06000250 RID: 592 RVA: 0x000152C4 File Offset: 0x000142C4
		public ControlLayoutSystem CreateNewLayoutSystem(SizeF size)
		{
			return this.CreateNewLayoutSystem(new DockControl[0], size);
		}

		// Token: 0x06000251 RID: 593 RVA: 0x000152D4 File Offset: 0x000142D4
		public ControlLayoutSystem CreateNewLayoutSystem(DockControl control, SizeF size)
		{
			return this.CreateNewLayoutSystem(new DockControl[]
			{
				control
			}, size);
		}

		// Token: 0x06000252 RID: 594 RVA: 0x000152F4 File Offset: 0x000142F4
		public ControlLayoutSystem CreateNewLayoutSystem(DockControl[] controls, SizeF size)
		{
			ControlLayoutSystem controlLayoutSystem;
			if (controls != null)
			{
				controlLayoutSystem = this.xd6284ffe96aec512();
				controlLayoutSystem.WorkingSize = size;
				goto IL_1B;
			}
			if (3 == 0)
			{
				goto IL_27;
			}
			throw new ArgumentNullException("controls");
			IL_19:
			return controlLayoutSystem;
			IL_1B:
			if (controls == null)
			{
				goto IL_19;
			}
			if (controls.Length == 0)
			{
				return controlLayoutSystem;
			}
			IL_27:
			controlLayoutSystem.Controls.AddRange(controls);
			if (-1 == 0)
			{
				goto IL_1B;
			}
			if (false)
			{
				if (false)
				{
					goto IL_1B;
				}
			}
			return controlLayoutSystem;
		}

		// Token: 0x06000253 RID: 595 RVA: 0x00015354 File Offset: 0x00014354
		internal virtual ControlLayoutSystem xd6284ffe96aec512()
		{
			return new ControlLayoutSystem();
		}

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x06000254 RID: 596 RVA: 0x0001535C File Offset: 0x0001435C
		// (set) Token: 0x06000255 RID: 597 RVA: 0x00015364 File Offset: 0x00014364
		[Browsable(false)]
		public override DockStyle Dock
		{
			get
			{
				return base.Dock;
			}
			set
			{
				if (value == DockStyle.None)
				{
					throw new ArgumentException("The value None is not supported for DockContainers.");
				}
				base.Dock = value;
				Orientation orientation = Orientation.Horizontal;
				for (;;)
				{
					if (this.Dock == DockStyle.Top)
					{
						goto IL_4C;
					}
					goto IL_25;
					IL_45:
					if (15 != 0)
					{
						goto IL_4C;
					}
					continue;
					IL_25:
					if (this.Dock != DockStyle.Bottom)
					{
						goto IL_2E;
					}
					goto IL_45;
					IL_4C:
					orientation = Orientation.Vertical;
					if (-2 == 0)
					{
						if (false)
						{
							goto IL_58;
						}
						goto IL_25;
					}
					IL_12:
					if (this.x35c76d526f88c3c8.SplitMode == orientation)
					{
						break;
					}
					this.x35c76d526f88c3c8.SplitMode = orientation;
					if (!false)
					{
						break;
					}
					if (!false)
					{
						goto IL_58;
					}
					if (!false)
					{
						goto IL_45;
					}
					break;
					IL_2E:
					goto IL_12;
					IL_58:
					if (15 != 0)
					{
						goto IL_12;
					}
					goto IL_2E;
				}
			}
		}

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x06000256 RID: 598 RVA: 0x000153F4 File Offset: 0x000143F4
		// (set) Token: 0x06000257 RID: 599 RVA: 0x000153FC File Offset: 0x000143FC
		[Browsable(false)]
		public override string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				base.Text = value;
			}
		}

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x06000258 RID: 600 RVA: 0x00015408 File Offset: 0x00014408
		// (set) Token: 0x06000259 RID: 601 RVA: 0x00015410 File Offset: 0x00014410
		[Browsable(false)]
		public override Image BackgroundImage
		{
			get
			{
				return base.BackgroundImage;
			}
			set
			{
				base.BackgroundImage = value;
			}
		}

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x0600025A RID: 602 RVA: 0x0001541C File Offset: 0x0001441C
		// (set) Token: 0x0600025B RID: 603 RVA: 0x00015424 File Offset: 0x00014424
		[DefaultValue(typeof(Color), "Control")]
		[Browsable(false)]
		public override Color BackColor
		{
			get
			{
				return base.BackColor;
			}
			set
			{
				base.BackColor = value;
			}
		}

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x0600025C RID: 604 RVA: 0x00015430 File Offset: 0x00014430
		// (set) Token: 0x0600025D RID: 605 RVA: 0x00015438 File Offset: 0x00014438
		[Browsable(false)]
		public override Color ForeColor
		{
			get
			{
				return base.ForeColor;
			}
			set
			{
				base.ForeColor = value;
			}
		}

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x0600025E RID: 606 RVA: 0x00015444 File Offset: 0x00014444
		[Browsable(false)]
		public bool HasSingleControlLayoutSystem
		{
			get
			{
				return this.LayoutSystem.LayoutSystems.Count == 1 && this.LayoutSystem.LayoutSystems[0] is ControlLayoutSystem;
			}
		}

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x0600025F RID: 607 RVA: 0x00015474 File Offset: 0x00014474
		internal virtual RendererBase x631afe05fcecf1f4
		{
			get
			{
				if (this.x91f347c6e97f1846 != null)
				{
					goto IL_19;
				}
				IL_0C:
				if (this.xa2c39ea75c543fc7 != null)
				{
					if (false)
					{
						goto IL_19;
					}
				}
				else
				{
					this.xa2c39ea75c543fc7 = new WhidbeyRenderer();
				}
				return this.xa2c39ea75c543fc7;
				IL_19:
				if (!false && this.x91f347c6e97f1846.Renderer == null)
				{
					goto IL_0C;
				}
				return this.x91f347c6e97f1846.Renderer;
			}
		}

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x06000260 RID: 608 RVA: 0x000154CC File Offset: 0x000144CC
		// (set) Token: 0x06000261 RID: 609 RVA: 0x000154D4 File Offset: 0x000144D4
		public int ContentSize
		{
			get
			{
				return this.xd987e7deb2afdfde;
			}
			set
			{
				value = Math.Max(value, 32);
				while (value == this.xd987e7deb2afdfde)
				{
					bool flag = (uint)value - (uint)value < 0U;
					if (!flag)
					{
						return;
					}
				}
				this.x841598f8fd19209c = true;
				if (-2 != 0)
				{
				}
				this.xd987e7deb2afdfde = value;
				this.x333d8ec4f70a6d86();
			}
		}

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x06000262 RID: 610 RVA: 0x00015530 File Offset: 0x00014530
		internal int x555227b0d2a372bd
		{
			get
			{
				if (this.x61c108cc44ef385a)
				{
					return this.x21ed2ecc088ef4e4.Width;
				}
				return this.x21ed2ecc088ef4e4.Height;
			}
		}

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x06000263 RID: 611 RVA: 0x00015554 File Offset: 0x00014554
		[Browsable(false)]
		protected internal virtual bool AllowResize
		{
			get
			{
				return this.Manager == null || this.Manager.AllowDockContainerResize;
			}
		}

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x06000264 RID: 612 RVA: 0x0001556C File Offset: 0x0001456C
		// (set) Token: 0x06000265 RID: 613 RVA: 0x00015574 File Offset: 0x00014574
		[Browsable(false)]
		public override bool AllowDrop
		{
			get
			{
				return base.AllowDrop;
			}
			set
			{
				base.AllowDrop = value;
			}
		}

		// Token: 0x06000266 RID: 614 RVA: 0x00015580 File Offset: 0x00014580
		internal object x7159e85e85b84817(Type x96168bd31f23b747)
		{
			return this.GetService(x96168bd31f23b747);
		}

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x06000267 RID: 615 RVA: 0x0001558C File Offset: 0x0001458C
		internal bool x972331c8ecf83413
		{
			get
			{
				return base.DesignMode;
			}
		}

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x06000268 RID: 616 RVA: 0x00015594 File Offset: 0x00014594
		// (set) Token: 0x06000269 RID: 617 RVA: 0x0001559C File Offset: 0x0001459C
		[Browsable(false)]
		public virtual SandDockManager Manager
		{
			get
			{
				return this.x91f347c6e97f1846;
			}
			set
			{
				if (this.x91f347c6e97f1846 != null)
				{
					goto IL_8F;
				}
				IL_89:
				if (value == null)
				{
					if (false)
					{
						goto IL_8F;
					}
				}
				else if (value.DockSystemContainer != null)
				{
					goto IL_70;
				}
				IL_5D:
				this.x91f347c6e97f1846 = value;
				if (255 == 0)
				{
					goto IL_7A;
				}
				if (!false)
				{
					if (8 != 0)
					{
						if (this.x91f347c6e97f1846 != null)
						{
							this.x91f347c6e97f1846.RegisterDockContainer(this);
							this.LayoutSystem.x56e964269d48cfcc(this);
						}
						return;
					}
					goto IL_7A;
				}
				IL_70:
				if (!this.IsFloating)
				{
					if (base.Parent != null && base.Parent != value.DockSystemContainer)
					{
						throw new ArgumentException("This DockContainer cannot use the specified manager as the manager's DockSystemContainer differs from the DockContainer's Parent.");
					}
				}
				IL_7A:
				goto IL_5D;
				IL_8F:
				this.x91f347c6e97f1846.UnregisterDockContainer(this);
				goto IL_89;
			}
		}

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x0600026A RID: 618 RVA: 0x00015654 File Offset: 0x00014654
		protected override Size DefaultSize
		{
			get
			{
				return new Size(0, 0);
			}
		}

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x0600026B RID: 619 RVA: 0x00015660 File Offset: 0x00014660
		[Browsable(false)]
		public virtual bool IsFloating
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x0600026C RID: 620 RVA: 0x00015664 File Offset: 0x00014664
		internal bool x61c108cc44ef385a
		{
			get
			{
				return this.Dock == DockStyle.Left || this.Dock == DockStyle.Right;
			}
		}

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x0600026D RID: 621 RVA: 0x0001567C File Offset: 0x0001467C
		// (set) Token: 0x0600026E RID: 622 RVA: 0x00015684 File Offset: 0x00014684
		[Browsable(false)]
		public virtual SplitLayoutSystem LayoutSystem
		{
			get
			{
				return this.x35c76d526f88c3c8;
			}
			set
			{
				if (value != this.x35c76d526f88c3c8)
				{
					if (-2 == 0 || value == null)
					{
						throw new ArgumentNullException("value");
					}
					DockContainer.x1f080f764b4036b1 = true;
					try
					{
						if (this.x35c76d526f88c3c8 != null)
						{
							this.x35c76d526f88c3c8.x56e964269d48cfcc(null);
						}
						if (!this.x841598f8fd19209c)
						{
							if (this.x61c108cc44ef385a)
							{
								this.xd987e7deb2afdfde = Convert.ToInt32(value.WorkingSize.Width);
								goto IL_9C;
							}
							goto IL_83;
						}
						IL_3A:
						this.x35c76d526f88c3c8 = value;
						if (!false)
						{
							this.x35c76d526f88c3c8.x56e964269d48cfcc(this);
							this.x7e9646eed248ed11();
							return;
						}
						IL_83:
						this.xd987e7deb2afdfde = Convert.ToInt32(value.WorkingSize.Height);
						IL_9C:
						this.x841598f8fd19209c = true;
						goto IL_3A;
					}
					finally
					{
						DockContainer.x1f080f764b4036b1 = false;
					}
				}
			}
		}

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x0600026F RID: 623 RVA: 0x00015770 File Offset: 0x00014770
		internal bool x5b1f9c5a8906ff95
		{
			get
			{
				return this.xa03963cfd21be862 > 0;
			}
		}

		// Token: 0x06000270 RID: 624 RVA: 0x0001577C File Offset: 0x0001477C
		internal void x272ed7848e373c56()
		{
			this.xa03963cfd21be862++;
			this.x35c76d526f88c3c8.x56e964269d48cfcc(null);
			IEnumerator enumerator = this.x83627743ea4ce5a2.GetEnumerator();
			try
			{
				while (enumerator.MoveNext() || 255 == 0)
				{
					LayoutSystemBase layoutSystemBase = (LayoutSystemBase)enumerator.Current;
					if (false || layoutSystemBase is ControlLayoutSystem)
					{
						((ControlLayoutSystem)layoutSystemBase).Controls.Clear();
					}
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (255 == 0 || disposable != null)
				{
					disposable.Dispose();
				}
			}
			this.x35c76d526f88c3c8 = new SplitLayoutSystem();
		}

		// Token: 0x06000271 RID: 625 RVA: 0x00015830 File Offset: 0x00014830
		internal void xfe00f14c7d278916()
		{
			if (this.xa03963cfd21be862 > 0)
			{
				this.xa03963cfd21be862--;
			}
			if (this.xa03963cfd21be862 == 0)
			{
				this.x7e9646eed248ed11();
			}
		}

		// Token: 0x06000272 RID: 626 RVA: 0x00015858 File Offset: 0x00014858
		internal void x4481febbc2e58301()
		{
			this.CalculateAllMetricsAndLayout();
		}

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x06000273 RID: 627 RVA: 0x00015860 File Offset: 0x00014860
		[Browsable(false)]
		internal virtual bool x0c2484ccd29b8358
		{
			get
			{
				return this.Dock != DockStyle.Fill && this.Dock != DockStyle.None;
			}
		}

		// Token: 0x06000274 RID: 628 RVA: 0x0001587C File Offset: 0x0001487C
		protected override void OnFontChanged(EventArgs e)
		{
			base.OnFontChanged(e);
			this.CalculateAllMetricsAndLayout();
		}

		// Token: 0x06000275 RID: 629 RVA: 0x0001588C File Offset: 0x0001488C
		public DockControl GetWindowAt(Point position)
		{
			ControlLayoutSystem controlLayoutSystem = this.GetLayoutSystemAt(position) as ControlLayoutSystem;
			if (controlLayoutSystem != null)
			{
				return controlLayoutSystem.GetControlAt(position);
			}
			return null;
		}

		// Token: 0x06000276 RID: 630 RVA: 0x000158B4 File Offset: 0x000148B4
		public LayoutSystemBase GetLayoutSystemAt(Point position)
		{
			LayoutSystemBase layoutSystemBase = null;
			using (IEnumerator enumerator = this.x83627743ea4ce5a2.GetEnumerator())
			{
				for (;;)
				{
					LayoutSystemBase layoutSystemBase2;
					Rectangle bounds;
					if (enumerator.MoveNext())
					{
						layoutSystemBase2 = (LayoutSystemBase)enumerator.Current;
						bounds = layoutSystemBase2.Bounds;
						goto IL_41;
					}
					if (false)
					{
						goto IL_3E;
					}
					break;
					IL_B6:
					while (!false)
					{
						if (8 == 0)
						{
							goto IL_D3;
						}
						if (3 != 0)
						{
							goto IL_84;
						}
						if (4 == 0)
						{
							goto IL_91;
						}
						if (!false)
						{
							goto IL_7D;
						}
					}
					goto IL_A7;
					IL_D3:
					if (8 == 0)
					{
						goto IL_3E;
					}
					if (-1 == 0)
					{
						goto IL_3E;
					}
					if (-2 != 0)
					{
						continue;
					}
					continue;
					IL_91:
					if (4 == 0)
					{
						goto IL_DA;
					}
					if (2 != 0)
					{
						goto IL_D3;
					}
					if (false)
					{
						goto IL_41;
					}
					goto IL_BD;
					IL_4E:
					if (255 != 0)
					{
						continue;
					}
					goto IL_B6;
					IL_41:
					if (!bounds.Contains(position))
					{
						goto IL_4E;
					}
					goto IL_A7;
					IL_3E:
					if (false)
					{
						goto IL_41;
					}
					goto IL_4E;
					IL_BD:
					layoutSystemBase = layoutSystemBase2;
					if (layoutSystemBase is ControlLayoutSystem)
					{
						break;
					}
					continue;
					IL_DA:
					goto IL_BD;
					IL_A7:
					if (!(layoutSystemBase2 is ControlLayoutSystem))
					{
						goto IL_BD;
					}
					if (8 == 0)
					{
						goto IL_B6;
					}
					goto IL_7D;
					IL_84:
					if (((ControlLayoutSystem)layoutSystemBase2).Collapsed)
					{
						goto IL_91;
					}
					goto IL_DA;
					IL_7D:
					if (15 != 0)
					{
						goto IL_84;
					}
					goto IL_B6;
				}
			}
			return layoutSystemBase;
		}

		// Token: 0x06000277 RID: 631 RVA: 0x000159EC File Offset: 0x000149EC
		internal virtual void x7e9646eed248ed11()
		{
			this.x7e9646eed248ed11(false);
		}

		// Token: 0x06000278 RID: 632 RVA: 0x000159F8 File Offset: 0x000149F8
		private void x7e9646eed248ed11(bool xaa70223940104cbe)
		{
			this.x83627743ea4ce5a2.Clear();
			this.x3df31cf55a47bc37 = null;
			if (!false)
			{
				this.x5b6d1177ca7f3461(this.x35c76d526f88c3c8);
				if (!xaa70223940104cbe)
				{
					if (this.xa03963cfd21be862 == 0)
					{
						this.x333d8ec4f70a6d86();
						if ((xaa70223940104cbe ? 1U : 0U) + (xaa70223940104cbe ? 1U : 0U) >= 0U)
						{
							Application.Idle += this.x4130a50ad5956bc2;
						}
					}
				}
			}
		}

		// Token: 0x06000279 RID: 633 RVA: 0x00015A6C File Offset: 0x00014A6C
		private void x4130a50ad5956bc2(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			Application.Idle -= this.x4130a50ad5956bc2;
			bool flag;
			if (((flag ? 1U : 0U) & 0U) == 0U)
			{
				goto IL_8E;
			}
			IL_28:
			if (4 != 0)
			{
				return;
			}
			IL_40:
			this.x7e9646eed248ed11(true);
			bool flag3;
			bool flag2 = (flag ? 1U : 0U) + (flag3 ? 1U : 0U) < 0U;
			if (!flag2)
			{
				goto IL_28;
			}
			IL_8E:
			flag = false;
			flag3 = false;
			for (;;)
			{
				flag = this.LayoutSystem.Optimize();
				if (false)
				{
					break;
				}
				flag2 = ((flag3 ? 1U : 0U) + (flag ? 1U : 0U) > uint.MaxValue);
				if (!flag2 && !flag)
				{
					break;
				}
				flag3 = true;
			}
			IL_34:
			if (!flag3)
			{
				return;
			}
			goto IL_40;
			goto IL_34;
		}

		// Token: 0x0600027A RID: 634 RVA: 0x00015B10 File Offset: 0x00014B10
		private void x5b6d1177ca7f3461(LayoutSystemBase x6e150040c8d97700)
		{
			this.x83627743ea4ce5a2.Add(x6e150040c8d97700);
			if (x6e150040c8d97700 is SplitLayoutSystem)
			{
				IEnumerator enumerator = ((SplitLayoutSystem)x6e150040c8d97700).LayoutSystems.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						object obj = enumerator.Current;
						LayoutSystemBase x6e150040c8d97701 = (LayoutSystemBase)obj;
						this.x5b6d1177ca7f3461(x6e150040c8d97701);
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

		// Token: 0x0600027B RID: 635 RVA: 0x00015B94 File Offset: 0x00014B94
		internal bool x61d88745bde7a5ec()
		{
			IEnumerator enumerator = this.x83627743ea4ce5a2.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					LayoutSystemBase layoutSystemBase = (LayoutSystemBase)obj;
					if (layoutSystemBase is ControlLayoutSystem)
					{
						bool flag = false;
						if (2147483647 != 0)
						{
							return flag;
						}
						break;
					}
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				bool flag;
				bool flag2 = (flag ? 1U : 0U) < 0U;
				if (!flag2)
				{
					goto IL_A4;
				}
				IL_56:
				if (((flag ? 1U : 0U) | 2147483648U) == 0U)
				{
					goto IL_CE;
				}
				flag2 = ((flag ? 1U : 0U) > uint.MaxValue);
				if (!flag2)
				{
					goto IL_D3;
				}
				IL_80:
				if ((flag ? 1U : 0U) < 0U)
				{
					goto IL_56;
				}
				flag2 = ((flag ? 1U : 0U) > uint.MaxValue);
				if (!flag2)
				{
					goto IL_D3;
				}
				IL_A4:
				if (3 == 0)
				{
					goto IL_56;
				}
				flag2 = ((flag ? 1U : 0U) + (flag ? 1U : 0U) > uint.MaxValue);
				if (!flag2)
				{
					goto IL_CE;
				}
				IL_C3:
				disposable.Dispose();
				goto IL_56;
				IL_CE:
				if (disposable == null)
				{
					goto IL_80;
				}
				goto IL_C3;
				IL_D3:;
			}
			return true;
		}

		// Token: 0x0600027C RID: 636 RVA: 0x00015C94 File Offset: 0x00014C94
		internal void x333d8ec4f70a6d86()
		{
			bool flag;
			int num;
			if (this.x0c2484ccd29b8358)
			{
				flag = true;
				using (IEnumerator enumerator = this.x83627743ea4ce5a2.GetEnumerator())
				{
					for (;;)
					{
						if (!enumerator.MoveNext())
						{
							bool flag2 = (flag ? 1U : 0U) > uint.MaxValue;
							if (!flag2)
							{
								goto IL_196;
							}
						}
						LayoutSystemBase layoutSystemBase = (LayoutSystemBase)enumerator.Current;
						ControlLayoutSystem controlLayoutSystem;
						for (;;)
						{
							bool flag2 = (flag ? 1U : 0U) + (flag ? 1U : 0U) < 0U;
							if (flag2)
							{
								if (false)
								{
									goto IL_11B;
								}
								if (2147483647 == 0)
								{
									goto IL_196;
								}
							}
							else if (!(layoutSystemBase is ControlLayoutSystem))
							{
								break;
							}
							controlLayoutSystem = (ControlLayoutSystem)layoutSystemBase;
							flag2 = (((flag ? 1U : 0U) & 0U) == 0U);
							if (flag2)
							{
								goto Block_18;
							}
						}
						continue;
						IL_11B:
						if (controlLayoutSystem.Collapsed)
						{
							continue;
						}
						break;
						Block_18:
						goto IL_11B;
					}
					flag = false;
					IL_196:;
				}
				num = 0;
				if (15 != 0)
				{
				}
				if (!flag)
				{
					num += this.ContentSize + (this.AllowResize ? 4 : 0);
				}
				while (!this.x61c108cc44ef385a)
				{
					if (!false)
					{
						goto IL_68;
					}
					if (!false)
					{
						IL_81:
						if (base.Width == num)
						{
							if (((uint)num | 255U) != 0U)
							{
								goto IL_68;
							}
							return;
						}
						else
						{
							base.Width = num;
							if ((flag ? 1U : 0U) - (flag ? 1U : 0U) >= 0U)
							{
								return;
							}
							return;
						}
					}
				}
				goto IL_81;
			}
			this.CalculateAllMetricsAndLayout();
			if ((flag ? 1U : 0U) + (uint)num >= 0U)
			{
				return;
			}
			IL_0F:
			if (false)
			{
				goto IL_68;
			}
			IL_12:
			this.CalculateAllMetricsAndLayout();
			return;
			IL_68:
			if (!this.x61c108cc44ef385a)
			{
				if (base.Height == num)
				{
					if (-2147483648 != 0)
					{
						goto IL_12;
					}
					bool flag2 = (flag ? 1U : 0U) - (flag ? 1U : 0U) > uint.MaxValue;
					if (flag2)
					{
						goto IL_0F;
					}
				}
				base.Height = num;
				return;
			}
			goto IL_12;
		}

		// Token: 0x0600027D RID: 637 RVA: 0x00015E7C File Offset: 0x00014E7C
		protected override void OnHandleCreated(EventArgs e)
		{
			base.OnHandleCreated(e);
			this.CalculateAllMetricsAndLayout();
		}

		// Token: 0x0600027E RID: 638 RVA: 0x00015E8C File Offset: 0x00014E8C
		internal void xec9697acef66c1bc(LayoutSystemBase x6e150040c8d97700, Rectangle xda73fcb97c77d998)
		{
			if (!base.IsHandleCreated)
			{
				return;
			}
			using (Graphics graphics = base.CreateGraphics())
			{
				RendererBase x631afe05fcecf1f = this.x631afe05fcecf1f4;
				x631afe05fcecf1f.StartRenderSession(HotkeyPrefix.None);
				if (!false)
				{
					if (false)
					{
						goto IL_5D;
					}
					goto IL_39;
				}
				IL_22:
				x6e150040c8d97700.Layout(x631afe05fcecf1f, graphics, xda73fcb97c77d998, false);
				IL_2C:
				x631afe05fcecf1f.FinishRenderSession();
				if (3 != 0)
				{
					goto IL_5D;
				}
				IL_39:
				if (x6e150040c8d97700 != this.x35c76d526f88c3c8)
				{
					goto IL_22;
				}
				x6e150040c8d97700.Layout(x631afe05fcecf1f, graphics, xda73fcb97c77d998, this.IsFloating);
				goto IL_2C;
				IL_5D:;
			}
		}

		// Token: 0x0600027F RID: 639 RVA: 0x00015F20 File Offset: 0x00014F20
		public void CalculateAllMetricsAndLayout()
		{
			if (!base.IsHandleCreated)
			{
				return;
			}
			if (base.Capture && !this.IsFloating)
			{
				base.Capture = false;
			}
			for (;;)
			{
				this.x21ed2ecc088ef4e4 = this.DisplayRectangle;
				if (false)
				{
					goto IL_1E1;
				}
				IL_2A:
				if (!this.AllowResize)
				{
					if (255 != 0)
					{
						goto Block_3;
					}
					continue;
				}
				IL_1E1:
				switch (this.Dock)
				{
				case DockStyle.Top:
					goto IL_9D;
				case DockStyle.Bottom:
					goto IL_E4;
				case DockStyle.Left:
					this.x59f159fe47159543 = new Rectangle(this.x21ed2ecc088ef4e4.Right - 4, this.x21ed2ecc088ef4e4.Top, 4, this.x21ed2ecc088ef4e4.Height);
					if (!false)
					{
						this.x21ed2ecc088ef4e4.Width = this.x21ed2ecc088ef4e4.Width - 4;
					}
					if (false)
					{
						goto IL_224;
					}
					if (-1 != 0)
					{
						goto Block_6;
					}
					goto IL_2A;
				case DockStyle.Right:
					goto IL_128;
				}
				goto Block_7;
			}
			IL_10:
			this.xec9697acef66c1bc(this.x35c76d526f88c3c8, this.x21ed2ecc088ef4e4);
			base.Invalidate();
			return;
			Block_3:
			if (!true)
			{
				goto IL_162;
			}
			this.x59f159fe47159543 = Rectangle.Empty;
			if (2147483647 != 0)
			{
				goto IL_10;
			}
			return;
			IL_9D:
			this.x59f159fe47159543 = new Rectangle(this.x21ed2ecc088ef4e4.Left, this.x21ed2ecc088ef4e4.Bottom - 4, this.x21ed2ecc088ef4e4.Width, 4);
			this.x21ed2ecc088ef4e4.Height = this.x21ed2ecc088ef4e4.Height - 4;
			goto IL_10;
			IL_E4:
			this.x59f159fe47159543 = new Rectangle(this.x21ed2ecc088ef4e4.Left, this.x21ed2ecc088ef4e4.Top, this.x21ed2ecc088ef4e4.Width, 4);
			if (!false)
			{
				if (!false)
				{
					this.x21ed2ecc088ef4e4.Offset(0, 4);
				}
				this.x21ed2ecc088ef4e4.Height = this.x21ed2ecc088ef4e4.Height - 4;
			}
			Block_6:
			goto IL_10;
			IL_128:
			this.x59f159fe47159543 = new Rectangle(this.x21ed2ecc088ef4e4.Left, this.x21ed2ecc088ef4e4.Top, 4, this.x21ed2ecc088ef4e4.Height);
			this.x21ed2ecc088ef4e4.Offset(4, 0);
			IL_162:
			this.x21ed2ecc088ef4e4.Width = this.x21ed2ecc088ef4e4.Width - 4;
			goto IL_10;
			Block_7:
			this.x59f159fe47159543 = Rectangle.Empty;
			IL_224:
			goto IL_10;
		}

		// Token: 0x06000280 RID: 640 RVA: 0x00016158 File Offset: 0x00015158
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			Form form = base.FindForm();
			if (form != null)
			{
				if (form.WindowState == FormWindowState.Minimized)
				{
					return;
				}
			}
			this.CalculateAllMetricsAndLayout();
			if (-1 != 0)
			{
			}
		}

		// Token: 0x06000281 RID: 641 RVA: 0x00016198 File Offset: 0x00015198
		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			if (this.x3df31cf55a47bc37 != null)
			{
				this.x3df31cf55a47bc37.OnMouseLeave();
				this.x3df31cf55a47bc37 = null;
			}
		}

		// Token: 0x06000282 RID: 642 RVA: 0x000161BC File Offset: 0x000151BC
		protected override void OnDoubleClick(EventArgs e)
		{
			base.OnDoubleClick(e);
			if (!false)
			{
				goto IL_60;
			}
			IL_19:
			if (!false)
			{
				return;
			}
			goto IL_29;
			IL_27:
			goto IL_19;
			IL_29:
			if (this.x3df31cf55a47bc37 == null)
			{
				if (!false)
				{
					while (false)
					{
						if (3 != 0)
						{
							goto IL_19;
						}
					}
					if (-2 == 0)
					{
						goto IL_19;
					}
				}
				if (2 == 0)
				{
					goto IL_60;
				}
				return;
			}
			else
			{
				this.x3df31cf55a47bc37.OnMouseDoubleClick();
				if (2147483647 != 0)
				{
					if (false)
					{
						return;
					}
					goto IL_27;
				}
			}
			IL_4A:
			goto IL_29;
			IL_60:
			if (!this.x266365ea27fa7af8.Locked)
			{
				goto IL_4A;
			}
		}

		// Token: 0x06000283 RID: 643 RVA: 0x00016230 File Offset: 0x00015230
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			if (!true)
			{
				if (2147483647 != 0)
				{
					goto IL_E7;
				}
			}
			else
			{
				if (!this.x266365ea27fa7af8.Locked)
				{
					goto IL_F6;
				}
				return;
			}
			for (;;)
			{
				IL_AB:
				if (8 != 0)
				{
					if (this.Manager == null)
					{
						goto Block_4;
					}
				}
				if (e.Button == MouseButtons.Left)
				{
					goto IL_97;
				}
				if (false)
				{
					break;
				}
				if (-2147483648 != 0)
				{
					goto IL_C7;
				}
			}
			IL_2F:
			this.x754f1c6f433be75d = new x09c1c18390e52ebf(this.Manager, this, new Point(e.X, e.Y));
			goto IL_52;
			Block_4:
			return;
			IL_95:
			goto IL_2F;
			IL_97:
			if (this.x754f1c6f433be75d == null)
			{
				goto IL_2F;
			}
			do
			{
				this.x754f1c6f433be75d.Dispose();
			}
			while (false);
			goto IL_95;
			IL_C7:
			if (false)
			{
				goto IL_E7;
			}
			return;
			IL_52:
			this.x754f1c6f433be75d.x868a32060451dd2e += this.x30c28c62b1a6040e;
			this.x754f1c6f433be75d.x67ecc0d0e7c9a202 += this.xa7afb2334769edc5;
			return;
			IL_E7:
			IL_F6:
			if (this.x3df31cf55a47bc37 != null)
			{
				if (2 != 0)
				{
					this.x3df31cf55a47bc37.OnMouseDown(e);
					return;
				}
				goto IL_52;
			}
			else if (this.x59f159fe47159543.Contains(e.X, e.Y))
			{
				goto IL_AB;
			}
		}

		// Token: 0x06000284 RID: 644 RVA: 0x0001635C File Offset: 0x0001535C
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			if (this.x266365ea27fa7af8.Locked)
			{
				if (!false)
				{
					return;
				}
			}
			else
			{
				if (this.x3df31cf55a47bc37 != null)
				{
					this.x3df31cf55a47bc37.OnMouseUp(e);
					if (!false)
					{
						return;
					}
				}
				else if (this.x754f1c6f433be75d == null)
				{
					return;
				}
				this.x754f1c6f433be75d.Commit();
			}
		}

		// Token: 0x06000285 RID: 645 RVA: 0x000163B4 File Offset: 0x000153B4
		protected override void OnDragOver(DragEventArgs drgevent)
		{
			base.OnDragOver(drgevent);
			LayoutSystemBase layoutSystemAt;
			do
			{
				Point position = base.PointToClient(new Point(drgevent.X, drgevent.Y));
				layoutSystemAt = this.GetLayoutSystemAt(position);
				if (!false)
				{
					goto IL_12;
				}
			}
			while (false);
			IL_09:
			layoutSystemAt.OnDragOver(drgevent);
			return;
			IL_12:
			if (layoutSystemAt == null)
			{
				return;
			}
			goto IL_09;
		}

		// Token: 0x06000286 RID: 646 RVA: 0x00016400 File Offset: 0x00015400
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			while (!false)
			{
				if (!base.Capture)
				{
					if (false)
					{
						goto IL_123;
					}
					goto IL_AC;
				}
				else
				{
					if (this.x3df31cf55a47bc37 != null)
					{
						this.x3df31cf55a47bc37.OnMouseMove(e);
						return;
					}
					if (false)
					{
						continue;
					}
					goto IL_F2;
				}
				IL_A1:
				LayoutSystemBase layoutSystemAt;
				while (this.x3df31cf55a47bc37 != layoutSystemAt)
				{
					this.x3df31cf55a47bc37.OnMouseLeave();
					if (!false)
					{
						goto IL_75;
					}
				}
				if (false)
				{
					goto IL_F2;
				}
				IL_75:
				layoutSystemAt.OnMouseMove(e);
				if (!false)
				{
					this.x3df31cf55a47bc37 = layoutSystemAt;
					return;
				}
				IL_AC:
				layoutSystemAt = this.GetLayoutSystemAt(new Point(e.X, e.Y));
				if (layoutSystemAt != null)
				{
					if (this.x3df31cf55a47bc37 != null)
					{
						goto IL_A1;
					}
					goto IL_75;
				}
				else
				{
					if (this.x3df31cf55a47bc37 != null)
					{
						this.x3df31cf55a47bc37.OnMouseLeave();
						this.x3df31cf55a47bc37 = null;
					}
					if (!this.x59f159fe47159543.Contains(e.X, e.Y))
					{
						Cursor.Current = Cursors.Default;
						return;
					}
					if (this.x61c108cc44ef385a)
					{
						Cursor.Current = Cursors.VSplit;
						return;
					}
					Cursor.Current = Cursors.HSplit;
					return;
				}
				IL_F2:
				if (false)
				{
					if (-2147483648 != 0)
					{
						goto IL_FF;
					}
					goto IL_A1;
				}
				IL_D7:
				if (this.x754f1c6f433be75d != null)
				{
					goto IL_FF;
				}
				return;
				IL_FF:
				this.x754f1c6f433be75d.OnMouseMove(new Point(e.X, e.Y));
				IL_E8:
				if (2 != 0)
				{
					return;
				}
				goto IL_D7;
				IL_123:
				goto IL_75;
			}
			if (true)
			{
				goto IL_E8;
			}
			goto IL_F2;
		}

		// Token: 0x06000287 RID: 647 RVA: 0x0001655C File Offset: 0x0001555C
		protected override void OnPaintBackground(PaintEventArgs pevent)
		{
			this.x631afe05fcecf1f4.DrawDockContainerBackground(pevent.Graphics, this, this.DisplayRectangle);
		}

		// Token: 0x06000288 RID: 648 RVA: 0x00016578 File Offset: 0x00015578
		protected override void OnPaint(PaintEventArgs e)
		{
			if (!DockContainer.x1f080f764b4036b1)
			{
				Control control;
				if (this.Manager != null)
				{
					control = this.Manager.DockSystemContainer;
					goto IL_106;
				}
				IL_F5:
				if (false)
				{
					goto IL_107;
				}
				control = null;
				IL_106:
				Control container = control;
				IL_107:
				this.x631afe05fcecf1f4.StartRenderSession(HotkeyPrefix.None);
				this.LayoutSystem.x84b6f3c22477dacb(this.x631afe05fcecf1f4, e.Graphics, this.Font);
				if (2 == 0)
				{
					goto IL_9A;
				}
				if (this.AllowResize)
				{
					goto IL_9A;
				}
				do
				{
					IL_D3:
					this.x631afe05fcecf1f4.FinishRenderSession();
					if (!this.x266365ea27fa7af8.Evaluation)
					{
						return;
					}
					if (!true)
					{
						goto Block_7;
					}
				}
				while (4 == 0);
				using (SolidBrush solidBrush = new SolidBrush(Color.FromArgb(50, Color.White)))
				{
					using (Font font = new Font(this.Font.FontFamily.Name, 14f, FontStyle.Bold))
					{
						e.Graphics.DrawString("evaluation", font, solidBrush, (float)(this.x21ed2ecc088ef4e4.Left + 4), (float)(this.x21ed2ecc088ef4e4.Top - 4), StringFormat.GenericTypographic);
					}
					return;
				}
				goto IL_9A;
				Block_7:
				if (false)
				{
					goto IL_F5;
				}
				return;
				IL_9A:
				this.x631afe05fcecf1f4.DrawSplitter(container, this, e.Graphics, this.x59f159fe47159543, (this.Dock == DockStyle.Top || this.Dock == DockStyle.Bottom) ? Orientation.Horizontal : Orientation.Vertical);
				goto IL_D3;
			}
		}

		// Token: 0x06000289 RID: 649 RVA: 0x0001670C File Offset: 0x0001570C
		internal void xa2414c47d888068e(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			foreach (object obj in this.x83627743ea4ce5a2)
			{
				LayoutSystemBase layoutSystemBase = (LayoutSystemBase)obj;
				if (layoutSystemBase is ControlLayoutSystem)
				{
					ControlLayoutSystem controlLayoutSystem = (ControlLayoutSystem)layoutSystemBase;
					if (controlLayoutSystem.x61ce2417e4ef76f9())
					{
						break;
					}
				}
			}
		}

		// Token: 0x0600028A RID: 650 RVA: 0x00016790 File Offset: 0x00015790
		internal void x19e788b09b195d4f(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			IEnumerator enumerator = this.x83627743ea4ce5a2.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					LayoutSystemBase layoutSystemBase = (LayoutSystemBase)obj;
					if (layoutSystemBase is ControlLayoutSystem)
					{
						((ControlLayoutSystem)layoutSystemBase).x82dd941e2755ffd2();
					}
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (8 == 0 || disposable != null)
				{
					disposable.Dispose();
				}
			}
		}

		// Token: 0x0600028B RID: 651 RVA: 0x0001680C File Offset: 0x0001580C
		private void x1b91eb6f6bb77abc()
		{
			this.x754f1c6f433be75d.x868a32060451dd2e -= this.x30c28c62b1a6040e;
			this.x754f1c6f433be75d.x67ecc0d0e7c9a202 -= this.xa7afb2334769edc5;
			this.x754f1c6f433be75d = null;
		}

		// Token: 0x0600028C RID: 652 RVA: 0x00016844 File Offset: 0x00015844
		private void x30c28c62b1a6040e(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			this.x1b91eb6f6bb77abc();
		}

		// Token: 0x0600028D RID: 653 RVA: 0x0001684C File Offset: 0x0001584C
		private void xa7afb2334769edc5(int x0d4b3b88c5b24565)
		{
			this.x1b91eb6f6bb77abc();
			this.ContentSize = x0d4b3b88c5b24565;
		}

		// Token: 0x0600028E RID: 654 RVA: 0x0001685C File Offset: 0x0001585C
		protected internal virtual void OnDockingStarted(EventArgs e)
		{
			if (this.xc5f1fda5242cf905 == null)
			{
				goto IL_29;
			}
			this.xc5f1fda5242cf905(this, e);
			if (!false)
			{
				goto IL_29;
			}
			if (false)
			{
				return;
			}
			IL_1B:
			this.Manager.OnDockingStarted(e);
			return;
			IL_29:
			if (this.Manager != null)
			{
				goto IL_1B;
			}
		}

		// Token: 0x0600028F RID: 655 RVA: 0x00016890 File Offset: 0x00015890
		protected internal virtual void OnDockingFinished(EventArgs e)
		{
			if (this.x2556ec4d28ceecee != null)
			{
				this.x2556ec4d28ceecee(this, e);
			}
			if (this.Manager != null)
			{
				this.Manager.OnDockingFinished(e);
			}
		}

		// Token: 0x06000290 RID: 656 RVA: 0x000168BC File Offset: 0x000158BC
		private string xa3a7472ac4e61f76(Point xb9c2cfae130d9256)
		{
			LayoutSystemBase layoutSystemAt = this.GetLayoutSystemAt(xb9c2cfae130d9256);
			if (!(layoutSystemAt is ControlLayoutSystem))
			{
				return "";
			}
			return ((ControlLayoutSystem)layoutSystemAt).xe0e7b93bedab6c05(xb9c2cfae130d9256);
		}

		// Token: 0x040000A3 RID: 163
		private const int xdb2b8faf7aefe99a = 32;

		// Token: 0x040000A4 RID: 164
		private SandDockManager x91f347c6e97f1846;

		// Token: 0x040000A5 RID: 165
		private SplitLayoutSystem x35c76d526f88c3c8;

		// Token: 0x040000A6 RID: 166
		internal ArrayList x83627743ea4ce5a2;

		// Token: 0x040000A7 RID: 167
		private RendererBase xa2c39ea75c543fc7;

		// Token: 0x040000A8 RID: 168
		private xf8f9565783602018 xac1c850120b1f254;

		// Token: 0x040000A9 RID: 169
		private int xa03963cfd21be862;

		// Token: 0x040000AA RID: 170
		private static bool x1f080f764b4036b1;

		// Token: 0x040000AB RID: 171
		private xbd7c5470fc89975b x266365ea27fa7af8;

		// Token: 0x040000AC RID: 172
		private x09c1c18390e52ebf x754f1c6f433be75d;

		// Token: 0x040000AD RID: 173
		private Rectangle x59f159fe47159543 = Rectangle.Empty;

		// Token: 0x040000AE RID: 174
		private Rectangle x21ed2ecc088ef4e4 = Rectangle.Empty;

		// Token: 0x040000AF RID: 175
		private int xd987e7deb2afdfde = 100;

		// Token: 0x040000B0 RID: 176
		private bool x841598f8fd19209c;

		// Token: 0x040000B1 RID: 177
		private EventHandler xc5f1fda5242cf905;

		// Token: 0x040000B2 RID: 178
		private EventHandler x2556ec4d28ceecee;

		// Token: 0x040000B3 RID: 179
		internal LayoutSystemBase x3df31cf55a47bc37;
	}
}
