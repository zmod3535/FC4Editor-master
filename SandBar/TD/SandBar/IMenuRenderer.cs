using System;
using System.Drawing;
using System.Windows.Forms;

namespace TD.SandBar
{
	// Token: 0x02000003 RID: 3
	public interface IMenuRenderer
	{
		// Token: 0x06000008 RID: 8
		void DrawMenuBackground(Graphics graphics, Rectangle bounds, int marginWidth, int breakOffset, int breakSize, MenuProjection menuDirection, bool rightToLeft, bool rightAligned);

		// Token: 0x06000009 RID: 9
		void DrawMenuItem(Graphics graphics, MenuButtonItem item, IPopupMenuHost host, int marginWidth, DrawItemState state, bool drawSpecial);

		// Token: 0x0600000A RID: 10
		void DrawMenuSeparator(Graphics graphics, Rectangle bounds, int marginWidth, bool rightToLeft);

		// Token: 0x0600000B RID: 11
		void DrawMenuActionsButton(Graphics graphics, Rectangle bounds, int marginWidth, DrawItemState state, bool designMode);

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600000C RID: 12
		TextFormatFlags MenuTextFormatFlags { get; }

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600000D RID: 13
		Color ShadowColor { get; }
	}
}
