using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Divelements.SandGrid.Rendering;
using Divelements.SandGrid.Resources;

namespace Divelements.SandGrid
{
	// Token: 0x02000009 RID: 9
	public abstract class GridElement
	{
		// Token: 0x06000046 RID: 70 RVA: 0x00005D50 File Offset: 0x00004D50
		internal GridElement()
		{
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00005D60 File Offset: 0x00004D60
		protected virtual GridElement GetChildElementAt(Point position)
		{
			return null;
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00005D64 File Offset: 0x00004D64
		public GridElement HitTest(Point position)
		{
			GridElement childElementAt = this.GetChildElementAt(position);
			if (childElementAt != null)
			{
				return childElementAt.HitTest(position);
			}
			return this;
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00005D88 File Offset: 0x00004D88
		internal void x2f9881556fe66cc1(Graphics x41347a961b838962, TextFormattingInformation xae3b2752a89e7464, bool x1158f70b6f5fc38e)
		{
			Size size = this.MeasureCore(x41347a961b838962, xae3b2752a89e7464, x1158f70b6f5fc38e);
			if (size.Width < 0 || size.Height < 0)
			{
				throw new InvalidOperationException(xf1a67b6a145d2603.x538d63a1354c16f2("ExceptionMeasureCoreNegative"));
			}
			this.xe0fd761af10d10b8 = size;
			this.xfb39fb8ddadd9197 = false;
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00005DD4 File Offset: 0x00004DD4
		internal void xb7ae55095fddecd9(Rectangle xda73fcb97c77d998)
		{
			this.xda73fcb97c77d998 = xda73fcb97c77d998;
			this.LayoutCore(xda73fcb97c77d998);
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00005DE4 File Offset: 0x00004DE4
		protected internal virtual string GetTooltipText(Point position)
		{
			return string.Empty;
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00005DEC File Offset: 0x00004DEC
		protected virtual void OnHotChanged()
		{
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600004D RID: 77 RVA: 0x00005DF0 File Offset: 0x00004DF0
		[Browsable(false)]
		public virtual GridElement ParentElement
		{
			get
			{
				return null;
			}
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00005DF4 File Offset: 0x00004DF4
		internal void x11f639c5d61688d8(x59ac1f306ac0f29d x1437816edeb48c46)
		{
			if (GridElement.xa12f14befb6e9c2d != null)
			{
				GridElement.xa12f14befb6e9c2d.Finished(Point.Empty, true);
			}
			GridElement.xa12f14befb6e9c2d = x1437816edeb48c46;
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600004F RID: 79 RVA: 0x00005E14 File Offset: 0x00004E14
		internal bool xc82620afa11d4a41
		{
			get
			{
				return this.Grid != null && this.Grid.SandGrid != null && this.Grid.SandGrid.Capture;
			}
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00005E40 File Offset: 0x00004E40
		protected internal virtual void OnMouseLostCapture()
		{
			this.x8951c36233a0ecf7(false);
			if (GridElement.xa12f14befb6e9c2d != null)
			{
				GridElement.xa12f14befb6e9c2d.Finished(Point.Empty, true);
				GridElement.xa12f14befb6e9c2d = null;
			}
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00005E68 File Offset: 0x00004E68
		protected internal virtual void OnMouseDown(MouseEventArgs e)
		{
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00005E6C File Offset: 0x00004E6C
		protected internal virtual void OnMouseDoubleClick(MouseEventArgs e)
		{
			if (GridElement.xa12f14befb6e9c2d != null)
			{
				GridElement.xa12f14befb6e9c2d.Finished(Point.Empty, true);
				GridElement.xa12f14befb6e9c2d = null;
			}
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00005E8C File Offset: 0x00004E8C
		protected internal virtual void OnMouseMove(MouseEventArgs e)
		{
			this.x8951c36233a0ecf7(true);
			if (e.Button == MouseButtons.Left && GridElement.xa12f14befb6e9c2d != null)
			{
				GridElement.xa12f14befb6e9c2d.MouseMove(e);
			}
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00005EB4 File Offset: 0x00004EB4
		protected internal virtual void OnMouseLeave()
		{
			this.x8951c36233a0ecf7(false);
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00005EC0 File Offset: 0x00004EC0
		protected internal virtual void OnMouseUp(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && GridElement.xa12f14befb6e9c2d != null)
			{
				GridElement.xa12f14befb6e9c2d.Finished(new Point(e.X, e.Y), false);
				GridElement.xa12f14befb6e9c2d = null;
			}
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00005EF8 File Offset: 0x00004EF8
		protected virtual void LayoutCore(Rectangle bounds)
		{
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00005EFC File Offset: 0x00004EFC
		protected virtual Size MeasureCore(Graphics graphics, TextFormattingInformation textFormat, bool rtl)
		{
			return Size.Empty;
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000058 RID: 88 RVA: 0x00005F04 File Offset: 0x00004F04
		[Browsable(false)]
		public InnerGrid Grid
		{
			get
			{
				return this.x3040c866fac95193;
			}
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00005F0C File Offset: 0x00004F0C
		public void EnsureVisible()
		{
			if (this.Grid != null && this.Grid.SandGrid != null)
			{
				this.Grid.SandGrid.ScrollElementIntoView(this);
			}
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00005F34 File Offset: 0x00004F34
		internal virtual void xea1c0bc64ab77594(InnerGrid xf57b149cb3f9c03a)
		{
			if (xf57b149cb3f9c03a == null && this.Grid != null)
			{
				this.Grid.x2f8a63bfec1c0c0f(this);
			}
			if (GridElement.xa12f14befb6e9c2d != null && GridElement.xa12f14befb6e9c2d.x2dcc7207ee287dbb == this)
			{
				GridElement.xa12f14befb6e9c2d.Finished(Point.Empty, true);
				GridElement.xa12f14befb6e9c2d = null;
			}
			this.x3040c866fac95193 = xf57b149cb3f9c03a;
			this.xfb39fb8ddadd9197 = true;
			this.x9f93ebd2ca5601a2 = false;
			this.x40fe165afa479af1 = false;
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00005FA0 File Offset: 0x00004FA0
		internal void x87c7306436764333(int xc0c4c459c6ccbd00)
		{
			this.xc0c4c459c6ccbd00 = xc0c4c459c6ccbd00;
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00005FAC File Offset: 0x00004FAC
		protected internal void RedrawNeeded()
		{
			if (this.x3040c866fac95193 != null)
			{
				this.x3040c866fac95193.x5e7a70d58e13247a(this);
			}
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00005FC4 File Offset: 0x00004FC4
		protected void RedrawNeeded(Rectangle bounds)
		{
			if (this.x3040c866fac95193 != null)
			{
				this.x3040c866fac95193.x5e7a70d58e13247a(bounds);
			}
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00005FDC File Offset: 0x00004FDC
		protected internal void MeasureNeeded()
		{
			this.xfb39fb8ddadd9197 = true;
			if (this.ShouldTriggerMeasure() && this.x3040c866fac95193 != null)
			{
				this.x3040c866fac95193.MeasureNeeded();
			}
			if (this.ParentElement != null)
			{
				this.ParentElement.MeasureNeeded();
			}
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00006014 File Offset: 0x00005014
		protected virtual bool ShouldTriggerMeasure()
		{
			return true;
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000060 RID: 96 RVA: 0x00006018 File Offset: 0x00005018
		internal static x59ac1f306ac0f29d x263912479c3c5786
		{
			get
			{
				return GridElement.xa12f14befb6e9c2d;
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000061 RID: 97 RVA: 0x00006020 File Offset: 0x00005020
		[Browsable(false)]
		public int Index
		{
			get
			{
				return this.xc0c4c459c6ccbd00;
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000062 RID: 98 RVA: 0x00006028 File Offset: 0x00005028
		// (set) Token: 0x06000063 RID: 99 RVA: 0x00006040 File Offset: 0x00005040
		[Description("The Font in use by the element.")]
		[Category("Appearance")]
		public Font Font
		{
			get
			{
				if (this.x26094932cf7a9139 != null)
				{
					return this.x26094932cf7a9139;
				}
				return this.GetDefaultFont();
			}
			set
			{
				this.x26094932cf7a9139 = value;
				if (this.ValueAffectsMeasurement())
				{
					this.MeasureNeeded();
					return;
				}
				this.RedrawNeeded();
			}
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00006060 File Offset: 0x00005060
		internal bool ShouldSerializeFont()
		{
			return this.x26094932cf7a9139 != null;
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00006070 File Offset: 0x00005070
		protected internal virtual bool ValueAffectsMeasurement()
		{
			return true;
		}

		// Token: 0x06000066 RID: 102 RVA: 0x00006074 File Offset: 0x00005074
		protected virtual Font GetDefaultFont()
		{
			if (this.Grid != null && this.Grid.SandGrid != null)
			{
				return this.Grid.SandGrid.Font;
			}
			return Control.DefaultFont;
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000067 RID: 103 RVA: 0x000060A4 File Offset: 0x000050A4
		// (set) Token: 0x06000068 RID: 104 RVA: 0x000060AC File Offset: 0x000050AC
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public bool Selected
		{
			get
			{
				return this.x9f93ebd2ca5601a2;
			}
			set
			{
				if (value != this.x9f93ebd2ca5601a2 && this.Grid != null)
				{
					this.x9f93ebd2ca5601a2 = value;
					if (this.x9f93ebd2ca5601a2)
					{
						this.Grid.xc8a038e04921ee9d(this);
					}
					else
					{
						this.Grid.x18fb6675e951c7a8(this);
					}
					this.xc1a3c3f3ff56b5d0();
				}
			}
		}

		// Token: 0x06000069 RID: 105 RVA: 0x000060FC File Offset: 0x000050FC
		internal virtual void xc1a3c3f3ff56b5d0()
		{
			this.RedrawNeeded();
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600006A RID: 106 RVA: 0x00006104 File Offset: 0x00005104
		protected bool Hot
		{
			get
			{
				return this.x40fe165afa479af1;
			}
		}

		// Token: 0x0600006B RID: 107 RVA: 0x0000610C File Offset: 0x0000510C
		private void x8951c36233a0ecf7(bool x40fe165afa479af1)
		{
			if (x40fe165afa479af1 != this.x40fe165afa479af1)
			{
				this.x40fe165afa479af1 = x40fe165afa479af1;
				this.OnHotChanged();
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x0600006C RID: 108 RVA: 0x00006124 File Offset: 0x00005124
		// (set) Token: 0x0600006D RID: 109 RVA: 0x0000612C File Offset: 0x0000512C
		internal bool x213abd9ea5eb87d6
		{
			get
			{
				return this.x9f93ebd2ca5601a2;
			}
			set
			{
				this.x9f93ebd2ca5601a2 = value;
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x0600006E RID: 110 RVA: 0x00006138 File Offset: 0x00005138
		[Browsable(false)]
		public Rectangle Bounds
		{
			get
			{
				return this.xda73fcb97c77d998;
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x0600006F RID: 111 RVA: 0x00006140 File Offset: 0x00005140
		internal bool x46eefbccf8310105
		{
			get
			{
				return this.xfb39fb8ddadd9197;
			}
		}

		// Token: 0x06000070 RID: 112 RVA: 0x00006148 File Offset: 0x00005148
		internal void x07304fb30d6dc43f(bool xfb39fb8ddadd9197)
		{
			this.xfb39fb8ddadd9197 = xfb39fb8ddadd9197;
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000071 RID: 113 RVA: 0x00006154 File Offset: 0x00005154
		internal Size x95f43364065e63e8
		{
			get
			{
				return this.xe0fd761af10d10b8;
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000072 RID: 114 RVA: 0x0000615C File Offset: 0x0000515C
		// (set) Token: 0x06000073 RID: 115 RVA: 0x00006164 File Offset: 0x00005164
		[Browsable(true)]
		[TypeConverter(typeof(StringConverter))]
		[DefaultValue(typeof(object), null)]
		public object Tag
		{
			get
			{
				return this.xffe521cc76054baf;
			}
			set
			{
				this.xffe521cc76054baf = value;
			}
		}

		// Token: 0x04000008 RID: 8
		private InnerGrid x3040c866fac95193;

		// Token: 0x04000009 RID: 9
		private Rectangle xda73fcb97c77d998;

		// Token: 0x0400000A RID: 10
		private bool x9f93ebd2ca5601a2;

		// Token: 0x0400000B RID: 11
		private bool x40fe165afa479af1;

		// Token: 0x0400000C RID: 12
		private Font x26094932cf7a9139;

		// Token: 0x0400000D RID: 13
		private int xc0c4c459c6ccbd00;

		// Token: 0x0400000E RID: 14
		private static x59ac1f306ac0f29d xa12f14befb6e9c2d;

		// Token: 0x0400000F RID: 15
		private Size xe0fd761af10d10b8;

		// Token: 0x04000010 RID: 16
		private bool xfb39fb8ddadd9197 = true;

		// Token: 0x04000011 RID: 17
		private object xffe521cc76054baf;
	}
}
