using System;
using System.Drawing;
using System.Windows.Forms;

namespace TD.SandBar
{
	// Token: 0x02000063 RID: 99
	internal class x4c834b893c51f017 : ButtonItem
	{
		// Token: 0x060004FF RID: 1279 RVA: 0x0001B594 File Offset: 0x0001A594
		public x4c834b893c51f017(ToolBarGlyphType glyph)
		{
			this.x268076ae4d2d65dd = glyph;
		}

		// Token: 0x06000500 RID: 1280 RVA: 0x0001B5A4 File Offset: 0x0001A5A4
		protected internal override void Paint(IToolBarRenderer renderer, Graphics graphics, Font font, bool vertical, bool rtl, ToolBarTextAlign textAlign, DrawItemState state)
		{
			base.ToolBar.WorkingRenderer.DrawSystemButton(graphics, base.ButtonBounds, this.x268076ae4d2d65dd, state, false);
		}

		// Token: 0x0400021B RID: 539
		private ToolBarGlyphType x268076ae4d2d65dd;
	}
}
