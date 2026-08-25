using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace TD.SandDock.Rendering
{
	// Token: 0x02000002 RID: 2
	public interface ITabControlRenderer
	{
		// Token: 0x06000001 RID: 1
		void DrawFakeTabControlBackgroundExtension(Graphics graphics, Rectangle bounds, Color backColor);

		// Token: 0x06000002 RID: 2
		void DrawTabControlButton(Graphics graphics, Rectangle bounds, SandDockButtonType buttonType, DrawItemState state);

		// Token: 0x06000003 RID: 3
		void DrawTabControlBackground(Graphics graphics, Rectangle bounds, Color backColor, bool client);

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000004 RID: 4
		bool ShouldDrawTabControlBackground { get; }

		// Token: 0x06000005 RID: 5
		void DrawTabControlTab(Graphics graphics, Rectangle bounds, Image image, string text, Font font, Color backColor, Color foreColor, DrawItemState state, bool drawSeparator);

		// Token: 0x06000006 RID: 6
		Size MeasureTabControlTab(Graphics graphics, Image image, string text, Font font, DrawItemState state);

		// Token: 0x06000007 RID: 7
		void DrawTabControlTabStripBackground(Graphics graphics, Rectangle bounds, Color backColor);

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000008 RID: 8
		int TabControlTabExtra { get; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000009 RID: 9
		int TabControlTabStripHeight { get; }

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600000A RID: 10
		int TabControlTabHeight { get; }

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600000B RID: 11
		Size TabControlPadding { get; }

		// Token: 0x0600000C RID: 12
		void StartRenderSession(HotkeyPrefix tabHotKeys);

		// Token: 0x0600000D RID: 13
		void FinishRenderSession();

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600000E RID: 14
		bool ShouldDrawControlBorder { get; }
	}
}
