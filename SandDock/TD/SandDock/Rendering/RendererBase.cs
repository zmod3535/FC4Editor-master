using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.Win32;

namespace TD.SandDock.Rendering
{
	// Token: 0x02000021 RID: 33
	[TypeConverter(typeof(x9c9262004128fe00))]
	public abstract class RendererBase : ITabControlRenderer, IDisposable
	{
		// Token: 0x14000018 RID: 24
		// (add) Token: 0x060002F6 RID: 758 RVA: 0x0001AABC File Offset: 0x00019ABC
		// (remove) Token: 0x060002F7 RID: 759 RVA: 0x0001AAD8 File Offset: 0x00019AD8
		public event EventHandler MetricsChanged
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.x8b0d947fe3d04bb9 = (EventHandler)Delegate.Combine(this.x8b0d947fe3d04bb9, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.x8b0d947fe3d04bb9 = (EventHandler)Delegate.Remove(this.x8b0d947fe3d04bb9, value);
			}
		}

		// Token: 0x060002F8 RID: 760 RVA: 0x0001AAF4 File Offset: 0x00019AF4
		public RendererBase()
		{
			SystemEvents.UserPreferenceChanged += this.x985016783c040310;
			this.GetColorsFromSystem();
		}

		// Token: 0x060002F9 RID: 761 RVA: 0x0001AB24 File Offset: 0x00019B24
		public void Dispose()
		{
			SystemEvents.UserPreferenceChanged -= this.x985016783c040310;
		}

		// Token: 0x060002FA RID: 762 RVA: 0x0001AB38 File Offset: 0x00019B38
		protected virtual void OnMetricsChanged(EventArgs e)
		{
			if (this.x8b0d947fe3d04bb9 != null)
			{
				this.x8b0d947fe3d04bb9(this, e);
			}
		}

		// Token: 0x060002FB RID: 763 RVA: 0x0001AB50 File Offset: 0x00019B50
		public virtual void ModifyDefaultWindowColors(DockControl window, ref Color backColor, ref Color borderColor)
		{
		}

		// Token: 0x060002FC RID: 764 RVA: 0x0001AB54 File Offset: 0x00019B54
		private void x985016783c040310(object xe0292b9ed559da7d, UserPreferenceChangedEventArgs xfbf34718e704c6bc)
		{
			if (xfbf34718e704c6bc.Category == UserPreferenceCategory.Color && !this.x106e6f99e65ccd35)
			{
				this.GetColorsFromSystem();
				this.x106e6f99e65ccd35 = false;
			}
		}

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x060002FD RID: 765 RVA: 0x0001AB74 File Offset: 0x00019B74
		// (set) Token: 0x060002FE RID: 766 RVA: 0x0001AB7C File Offset: 0x00019B7C
		public bool CustomColors
		{
			get
			{
				return this.x106e6f99e65ccd35;
			}
			set
			{
				this.x106e6f99e65ccd35 = value;
				if (!false)
				{
					goto IL_30;
				}
				IL_0A:
				if (this.x106e6f99e65ccd35)
				{
					if (true)
					{
					}
					return;
				}
				goto IL_37;
				IL_30:
				if (8 != 0)
				{
					goto IL_0A;
				}
				IL_37:
				this.GetColorsFromSystem();
				if ((value ? 1U : 0U) > 4294967295U)
				{
					goto IL_0A;
				}
				if (false)
				{
					goto IL_30;
				}
			}
		}

		// Token: 0x060002FF RID: 767 RVA: 0x0001ABC8 File Offset: 0x00019BC8
		protected internal static Color InterpolateColors(Color color1, Color color2, float percentage)
		{
			int r = (int)color1.R;
			int g = (int)color1.G;
			int b = (int)color1.B;
			int a = (int)color1.A;
			int g2;
			int b2;
			int a2;
			byte red;
			do
			{
				int r2 = (int)color2.R;
				g2 = (int)color2.G;
				b2 = (int)color2.B;
				a2 = (int)color2.A;
				red = Convert.ToByte((float)r + (float)(r2 - r) * percentage);
				if ((uint)r2 - (uint)g < 0U)
				{
					goto IL_CB;
				}
			}
			while ((uint)g + (uint)percentage < 0U);
			byte green = Convert.ToByte((float)g + (float)(g2 - g) * percentage);
			byte blue = Convert.ToByte((float)b + (float)(b2 - b) * percentage);
			byte alpha = Convert.ToByte((float)a + (float)(a2 - a) * percentage);
			IL_CB:
			return Color.FromArgb((int)alpha, (int)red, (int)green, (int)blue);
		}

		// Token: 0x06000300 RID: 768 RVA: 0x0001ACB0 File Offset: 0x00019CB0
		protected virtual void GetColorsFromSystem()
		{
			this.x106e6f99e65ccd35 = false;
		}

		// Token: 0x06000301 RID: 769 RVA: 0x0001ACBC File Offset: 0x00019CBC
		protected internal virtual Rectangle AdjustDockControlClientBounds(ControlLayoutSystem layoutSystem, DockControl control, Rectangle clientBounds)
		{
			return clientBounds;
		}

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x06000302 RID: 770
		protected internal abstract BoxModel TabStripMetrics { get; }

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x06000303 RID: 771
		protected internal abstract BoxModel TabMetrics { get; }

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x06000304 RID: 772
		protected internal abstract BoxModel TitleBarMetrics { get; }

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x06000305 RID: 773 RVA: 0x0001ACC0 File Offset: 0x00019CC0
		// (set) Token: 0x06000306 RID: 774 RVA: 0x0001ACC8 File Offset: 0x00019CC8
		public virtual Size ImageSize
		{
			get
			{
				return this.x95dac044246123ac;
			}
			set
			{
				this.x95dac044246123ac = value;
				this.OnMetricsChanged(EventArgs.Empty);
			}
		}

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x06000307 RID: 775
		protected internal abstract TabTextDisplayMode TabTextDisplay { get; }

		// Token: 0x06000308 RID: 776
		protected internal abstract Size MeasureDocumentStripTab(Graphics graphics, Image image, string text, Font font, DrawItemState state);

		// Token: 0x06000309 RID: 777
		protected internal abstract Size MeasureTabStripTab(Graphics graphics, Image image, string text, Font font, DrawItemState state);

		// Token: 0x0600030A RID: 778
		protected internal abstract void DrawDocumentStripBackground(Graphics graphics, Rectangle bounds);

		// Token: 0x0600030B RID: 779
		protected internal abstract void DrawControlClientBackground(Graphics graphics, Rectangle bounds, Color backColor);

		// Token: 0x0600030C RID: 780
		protected internal abstract void DrawDocumentClientBackground(Graphics graphics, Rectangle bounds, Color backColor);

		// Token: 0x0600030D RID: 781
		protected internal abstract void DrawDocumentStripTab(Graphics graphics, Rectangle bounds, Rectangle contentBounds, Image image, string text, Font font, Color backColor, Color foreColor, DrawItemState state, bool drawSeparator);

		// Token: 0x0600030E RID: 782
		protected internal abstract void DrawDockContainerBackground(Graphics graphics, DockContainer container, Rectangle bounds);

		// Token: 0x0600030F RID: 783
		protected internal abstract void DrawDocumentStripButton(Graphics graphics, Rectangle bounds, SandDockButtonType buttonType, DrawItemState state);

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x06000310 RID: 784
		protected internal abstract int DocumentTabExtra { get; }

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x06000311 RID: 785
		protected internal abstract int DocumentTabSize { get; }

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x06000312 RID: 786
		protected internal abstract int DocumentTabStripSize { get; }

		// Token: 0x06000313 RID: 787
		public abstract void StartRenderSession(HotkeyPrefix hotKeys);

		// Token: 0x06000314 RID: 788
		protected internal abstract void DrawTabStripBackground(Control container, Control control, Graphics graphics, Rectangle bounds, int selectedTabOffset);

		// Token: 0x06000315 RID: 789
		protected internal abstract void DrawSplitter(Control container, Control control, Graphics graphics, Rectangle bounds, Orientation orientation);

		// Token: 0x06000316 RID: 790
		protected internal abstract void DrawTabStripTab(Graphics graphics, Rectangle bounds, Image image, string text, Font font, Color backColor, Color foreColor, DrawItemState state, bool drawSeparator);

		// Token: 0x06000317 RID: 791
		protected internal abstract void DrawAutoHideBarBackground(Control container, Control control, Graphics graphics, Rectangle bounds);

		// Token: 0x06000318 RID: 792
		protected internal abstract void DrawCollapsedTab(Graphics graphics, Rectangle bounds, DockSide dockSide, Image image, string text, Font font, Color backColor, Color foreColor, DrawItemState state, bool vertical);

		// Token: 0x06000319 RID: 793
		protected internal abstract void DrawTitleBarBackground(Graphics graphics, Rectangle bounds, bool focused);

		// Token: 0x0600031A RID: 794
		protected internal abstract void DrawTitleBarText(Graphics graphics, Rectangle bounds, bool focused, string text, Font font);

		// Token: 0x0600031B RID: 795
		protected internal abstract void DrawTitleBarButton(Graphics graphics, Rectangle bounds, SandDockButtonType buttonType, DrawItemState state, bool focused, bool toggled);

		// Token: 0x0600031C RID: 796
		public abstract void FinishRenderSession();

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x0600031D RID: 797 RVA: 0x0001ACDC File Offset: 0x00019CDC
		public virtual bool ShouldDrawControlBorder
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600031E RID: 798 RVA: 0x0001ACE0 File Offset: 0x00019CE0
		public virtual void DrawFakeTabControlBackgroundExtension(Graphics graphics, Rectangle bounds, Color backColor)
		{
			using (SolidBrush solidBrush = new SolidBrush(backColor))
			{
				graphics.FillRectangle(solidBrush, bounds);
			}
		}

		// Token: 0x0600031F RID: 799 RVA: 0x0001AD24 File Offset: 0x00019D24
		public virtual void DrawTabControlButton(Graphics graphics, Rectangle bounds, SandDockButtonType buttonType, DrawItemState state)
		{
			this.DrawDocumentStripButton(graphics, bounds, buttonType, state);
		}

		// Token: 0x06000320 RID: 800 RVA: 0x0001AD34 File Offset: 0x00019D34
		public virtual void DrawTabControlBackground(Graphics graphics, Rectangle bounds, Color backColor, bool client)
		{
			using (SolidBrush solidBrush = new SolidBrush(backColor))
			{
				graphics.FillRectangle(solidBrush, bounds);
			}
		}

		// Token: 0x170000BA RID: 186
		// (get) Token: 0x06000321 RID: 801 RVA: 0x0001AD78 File Offset: 0x00019D78
		public virtual bool ShouldDrawTabControlBackground
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170000BB RID: 187
		// (get) Token: 0x06000322 RID: 802
		public abstract Size TabControlPadding { get; }

		// Token: 0x06000323 RID: 803 RVA: 0x0001AD7C File Offset: 0x00019D7C
		public virtual Size MeasureTabControlTab(Graphics graphics, Image image, string text, Font font, DrawItemState state)
		{
			return this.MeasureDocumentStripTab(graphics, image, text, font, state);
		}

		// Token: 0x06000324 RID: 804 RVA: 0x0001AD8C File Offset: 0x00019D8C
		public virtual void DrawTabControlTab(Graphics graphics, Rectangle bounds, Image image, string text, Font font, Color backColor, Color foreColor, DrawItemState state, bool drawSeparator)
		{
			this.DrawDocumentStripTab(graphics, bounds, bounds, image, text, font, backColor, foreColor, state, drawSeparator);
		}

		// Token: 0x06000325 RID: 805 RVA: 0x0001ADB0 File Offset: 0x00019DB0
		public virtual void DrawTabControlTabStripBackground(Graphics graphics, Rectangle bounds, Color backColor)
		{
			this.DrawDocumentStripBackground(graphics, bounds);
		}

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x06000326 RID: 806 RVA: 0x0001ADBC File Offset: 0x00019DBC
		public virtual int TabControlTabExtra
		{
			get
			{
				return this.DocumentTabExtra;
			}
		}

		// Token: 0x170000BD RID: 189
		// (get) Token: 0x06000327 RID: 807 RVA: 0x0001ADC4 File Offset: 0x00019DC4
		public virtual int TabControlTabStripHeight
		{
			get
			{
				return this.DocumentTabStripSize;
			}
		}

		// Token: 0x170000BE RID: 190
		// (get) Token: 0x06000328 RID: 808 RVA: 0x0001ADCC File Offset: 0x00019DCC
		public virtual int TabControlTabHeight
		{
			get
			{
				return this.DocumentTabSize;
			}
		}

		// Token: 0x04000100 RID: 256
		private EventHandler x8b0d947fe3d04bb9;

		// Token: 0x04000101 RID: 257
		private bool x106e6f99e65ccd35;

		// Token: 0x04000102 RID: 258
		private Size x95dac044246123ac = new Size(16, 16);
	}
}
