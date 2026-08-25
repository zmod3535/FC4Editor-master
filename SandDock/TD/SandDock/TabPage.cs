using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace TD.SandDock
{
	// Token: 0x02000063 RID: 99
	[Designer("TD.SandDock.Design.TabPageDesigner, SandDock.Design, Version=1.0.0.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3")]
	[ToolboxItem(false)]
	public class TabPage : Panel
	{
		// Token: 0x1400001D RID: 29
		// (add) Token: 0x0600059F RID: 1439 RVA: 0x0002A890 File Offset: 0x00029890
		// (remove) Token: 0x060005A0 RID: 1440 RVA: 0x0002A8AC File Offset: 0x000298AC
		public event EventHandler Load
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.x5d95f5f98c940295 = (EventHandler)Delegate.Combine(this.x5d95f5f98c940295, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.x5d95f5f98c940295 = (EventHandler)Delegate.Remove(this.x5d95f5f98c940295, value);
			}
		}

		// Token: 0x060005A1 RID: 1441 RVA: 0x0002A8C8 File Offset: 0x000298C8
		public TabPage()
		{
			base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
		}

		// Token: 0x060005A2 RID: 1442 RVA: 0x0002A8DC File Offset: 0x000298DC
		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
		}

		// Token: 0x060005A3 RID: 1443 RVA: 0x0002A8E8 File Offset: 0x000298E8
		public TabPage(string text) : this()
		{
			this.Text = text;
		}

		// Token: 0x060005A4 RID: 1444 RVA: 0x0002A8F8 File Offset: 0x000298F8
		protected override void OnCreateControl()
		{
			base.OnCreateControl();
			this.OnLoad(EventArgs.Empty);
		}

		// Token: 0x060005A5 RID: 1445 RVA: 0x0002A90C File Offset: 0x0002990C
		protected virtual void OnLoad(EventArgs e)
		{
			if (this.x5d95f5f98c940295 != null)
			{
				this.x5d95f5f98c940295(this, e);
			}
		}

		// Token: 0x060005A6 RID: 1446 RVA: 0x0002A924 File Offset: 0x00029924
		protected override void OnPaintBackground(PaintEventArgs pevent)
		{
			if (base.ClientRectangle == Rectangle.Empty)
			{
				if (-2 != 0)
				{
					if (!false)
					{
						return;
					}
					goto IL_4B;
				}
			}
			else
			{
				if (base.Parent is TabControl && ((TabControl)base.Parent).Renderer.ShouldDrawTabControlBackground)
				{
					goto IL_4B;
				}
				base.OnPaintBackground(pevent);
				return;
			}
			return;
			IL_4B:
			((TabControl)base.Parent).Renderer.DrawTabControlBackground(pevent.Graphics, base.ClientRectangle, this.BackColor, true);
		}

		// Token: 0x060005A7 RID: 1447 RVA: 0x0002A9A8 File Offset: 0x000299A8
		protected override void CreateHandle()
		{
			int newIndex = -1;
			for (;;)
			{
				if (base.Parent != null)
				{
					newIndex = base.Parent.Controls.IndexOf(this);
					if (false)
					{
						return;
					}
				}
				base.CreateHandle();
				if (base.Parent != null)
				{
					break;
				}
				if (4 != 0)
				{
					return;
				}
			}
			base.Parent.Controls.SetChildIndex(this, newIndex);
		}

		// Token: 0x17000164 RID: 356
		// (get) Token: 0x060005A8 RID: 1448 RVA: 0x0002AA04 File Offset: 0x00029A04
		// (set) Token: 0x060005A9 RID: 1449 RVA: 0x0002AA0C File Offset: 0x00029A0C
		public override Color BackColor
		{
			get
			{
				return base.BackColor;
			}
			set
			{
				base.BackColor = value;
				if (base.Parent is TabControl)
				{
					base.Parent.Invalidate(this.x123e054dab107457);
				}
			}
		}

		// Token: 0x17000165 RID: 357
		// (get) Token: 0x060005AA RID: 1450 RVA: 0x0002AA38 File Offset: 0x00029A38
		// (set) Token: 0x060005AB RID: 1451 RVA: 0x0002AA40 File Offset: 0x00029A40
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override DockStyle Dock
		{
			get
			{
				return base.Dock;
			}
			set
			{
				base.Dock = value;
			}
		}

		// Token: 0x17000166 RID: 358
		// (get) Token: 0x060005AC RID: 1452 RVA: 0x0002AA4C File Offset: 0x00029A4C
		// (set) Token: 0x060005AD RID: 1453 RVA: 0x0002AA54 File Offset: 0x00029A54
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override AnchorStyles Anchor
		{
			get
			{
				return base.Anchor;
			}
			set
			{
				base.Anchor = value;
			}
		}

		// Token: 0x17000167 RID: 359
		// (get) Token: 0x060005AE RID: 1454 RVA: 0x0002AA60 File Offset: 0x00029A60
		// (set) Token: 0x060005AF RID: 1455 RVA: 0x0002AA68 File Offset: 0x00029A68
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public new bool Enabled
		{
			get
			{
				return base.Enabled;
			}
			set
			{
				base.Enabled = value;
			}
		}

		// Token: 0x17000168 RID: 360
		// (get) Token: 0x060005B0 RID: 1456 RVA: 0x0002AA74 File Offset: 0x00029A74
		// (set) Token: 0x060005B1 RID: 1457 RVA: 0x0002AA7C File Offset: 0x00029A7C
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public new int TabIndex
		{
			get
			{
				return base.TabIndex;
			}
			set
			{
				base.TabIndex = value;
			}
		}

		// Token: 0x17000169 RID: 361
		// (get) Token: 0x060005B2 RID: 1458 RVA: 0x0002AA88 File Offset: 0x00029A88
		// (set) Token: 0x060005B3 RID: 1459 RVA: 0x0002AA90 File Offset: 0x00029A90
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public new bool TabStop
		{
			get
			{
				return base.TabStop;
			}
			set
			{
				base.TabStop = value;
			}
		}

		// Token: 0x1700016A RID: 362
		// (get) Token: 0x060005B4 RID: 1460 RVA: 0x0002AA9C File Offset: 0x00029A9C
		// (set) Token: 0x060005B5 RID: 1461 RVA: 0x0002AAA4 File Offset: 0x00029AA4
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public new bool Visible
		{
			get
			{
				return base.Visible;
			}
			set
			{
				base.Visible = value;
			}
		}

		// Token: 0x1700016B RID: 363
		// (get) Token: 0x060005B6 RID: 1462 RVA: 0x0002AAB0 File Offset: 0x00029AB0
		// (set) Token: 0x060005B7 RID: 1463 RVA: 0x0002AAB8 File Offset: 0x00029AB8
		[Category("Layout")]
		[DefaultValue(0)]
		[Description("Indicates the maximum width of the tab.")]
		public int MaximumTabWidth
		{
			get
			{
				return this.x3214e09b677ccd2b;
			}
			set
			{
				if (value < 0)
				{
					throw new ArgumentException("Value must be greater than or equal to zero.");
				}
				this.x3214e09b677ccd2b = value;
				if (base.Parent is TabControl)
				{
					((TabControl)base.Parent).x436f6f3ee14607e0();
				}
			}
		}

		// Token: 0x1700016C RID: 364
		// (get) Token: 0x060005B8 RID: 1464 RVA: 0x0002AAF0 File Offset: 0x00029AF0
		// (set) Token: 0x060005B9 RID: 1465 RVA: 0x0002AAF8 File Offset: 0x00029AF8
		[Browsable(true)]
		public override string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				base.Text = value;
				if (base.Parent is TabControl)
				{
					((TabControl)base.Parent).x436f6f3ee14607e0();
				}
			}
		}

		// Token: 0x1700016D RID: 365
		// (get) Token: 0x060005BA RID: 1466 RVA: 0x0002AB24 File Offset: 0x00029B24
		// (set) Token: 0x060005BB RID: 1467 RVA: 0x0002AB2C File Offset: 0x00029B2C
		[Category("Appearance")]
		[AmbientValue(typeof(Image), null)]
		[DefaultValue(typeof(Image), null)]
		[Description("The image displayed next to the text on the tab.")]
		public Image TabImage
		{
			get
			{
				return this.xe058541ca798c059;
			}
			set
			{
				this.xe058541ca798c059 = value;
				if (base.Parent is TabControl)
				{
					((TabControl)base.Parent).x436f6f3ee14607e0();
				}
			}
		}

		// Token: 0x1700016E RID: 366
		// (get) Token: 0x060005BC RID: 1468 RVA: 0x0002AB54 File Offset: 0x00029B54
		[Browsable(false)]
		public Rectangle TabBounds
		{
			get
			{
				return this.x123e054dab107457;
			}
		}

		// Token: 0x1700016F RID: 367
		// (get) Token: 0x060005BD RID: 1469 RVA: 0x0002AB5C File Offset: 0x00029B5C
		// (set) Token: 0x060005BE RID: 1470 RVA: 0x0002AB64 File Offset: 0x00029B64
		[Browsable(false)]
		[Obsolete]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Guid Guid
		{
			get
			{
				return Guid.Empty;
			}
			set
			{
			}
		}

		// Token: 0x17000170 RID: 368
		// (get) Token: 0x060005BF RID: 1471 RVA: 0x0002AB68 File Offset: 0x00029B68
		// (set) Token: 0x060005C0 RID: 1472 RVA: 0x0002AB70 File Offset: 0x00029B70
		[Browsable(false)]
		[Obsolete]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Size FloatingSize
		{
			get
			{
				return Size.Empty;
			}
			set
			{
			}
		}

		// Token: 0x17000171 RID: 369
		// (get) Token: 0x060005C1 RID: 1473 RVA: 0x0002AB74 File Offset: 0x00029B74
		// (set) Token: 0x060005C2 RID: 1474 RVA: 0x0002AB7C File Offset: 0x00029B7C
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Obsolete]
		public string TabText
		{
			get
			{
				return "";
			}
			set
			{
			}
		}

		// Token: 0x04000214 RID: 532
		private Image xe058541ca798c059;

		// Token: 0x04000215 RID: 533
		private int x3214e09b677ccd2b;

		// Token: 0x04000216 RID: 534
		internal double x9b0739496f8b5475;

		// Token: 0x04000217 RID: 535
		internal int xa806b754814b9ae0;

		// Token: 0x04000218 RID: 536
		internal Rectangle x123e054dab107457;

		// Token: 0x04000219 RID: 537
		internal bool xcfac6723d8a41375;

		// Token: 0x0400021A RID: 538
		private EventHandler x5d95f5f98c940295;
	}
}
