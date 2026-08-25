using System;
using System.Drawing;
using System.Windows.Forms;

namespace TD.SandBar
{
	// Token: 0x02000005 RID: 5
	public interface IToolBarRenderer : IMenuRenderer, IComboBoxRenderer, IContainerBarRenderer, IDisposable
	{
		// Token: 0x06000011 RID: 17
		void AddConsumer(object consumer);

		// Token: 0x06000012 RID: 18
		void RemoveConsumer(object consumer);

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000013 RID: 19
		// (remove) Token: 0x06000014 RID: 20
		event EventHandler RedrawRequired;

		// Token: 0x06000015 RID: 21
		void StartToolBarRender(ToolBar toolbar, bool vertical, bool rightToLeft);

		// Token: 0x06000016 RID: 22
		void FinishToolBarRender();

		// Token: 0x06000017 RID: 23
		void DrawStatusBarBackground(StatusBar statusBar, Graphics graphics, Rectangle bounds, bool vertical);

		// Token: 0x06000018 RID: 24
		void DrawStatusBarGripper(StatusBar statusBar, Graphics graphics, Rectangle bounds, bool vertical);

		// Token: 0x06000019 RID: 25
		void DrawToolBarBackground(ToolBar toolbar, Graphics graphics, Rectangle bounds, bool vertical);

		// Token: 0x0600001A RID: 26
		void DrawMenuBarBackground(MenuBar menubar, Graphics graphics, Rectangle bounds, bool vertical);

		// Token: 0x0600001B RID: 27
		void DrawToolBarGrabHandle(Graphics graphics, Rectangle bounds, bool vertical);

		// Token: 0x0600001C RID: 28
		void DrawSystemButton(Graphics graphics, Rectangle bounds, ToolBarGlyphType glyphType, DrawItemState state, bool floating);

		// Token: 0x0600001D RID: 29
		void DrawContainerBackground(Graphics graphics, Rectangle bounds, Rectangle layoutBounds);

		// Token: 0x0600001E RID: 30
		void DrawToolBarSeparator(Graphics graphics, Rectangle bounds, bool vertical);

		// Token: 0x0600001F RID: 31
		void DrawToolBarActionsButton(Graphics graphics, Rectangle bounds, bool vertical, bool chevron, DrawItemState state, bool designMode);

		// Token: 0x06000020 RID: 32
		void DrawToolBarItem(ToolbarItemBase item, Graphics graphics, Font font, bool vertical, DrawItemState state, ToolBarTextAlign textAlign);

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000021 RID: 33
		// (set) Token: 0x06000022 RID: 34
		TextFormatFlags ItemTextFormatFlags { get; set; }

		// Token: 0x06000023 RID: 35
		void DrawFloatingFormBackground(Graphics graphics, Rectangle bounds);

		// Token: 0x06000024 RID: 36
		void DrawFloatingFormText(string text, Graphics graphics, Font font, Rectangle bounds);
	}
}
