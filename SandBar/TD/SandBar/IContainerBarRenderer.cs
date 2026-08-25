using System;
using System.Drawing;

namespace TD.SandBar
{
	// Token: 0x02000007 RID: 7
	public interface IContainerBarRenderer
	{
		// Token: 0x06000026 RID: 38
		void LayoutContainerBar(Rectangle bounds, Size toolbarSize, out Rectangle titlebarBounds, out Rectangle toolbarBounds, out Rectangle clientBounds, out Rectangle gripperBounds);

		// Token: 0x06000027 RID: 39
		void DrawContainerBarText(string text, Graphics graphics, Font font, Rectangle bounds);

		// Token: 0x06000028 RID: 40
		void DrawContainerBarBackground(ContainerBar containerBar, Graphics graphics, Rectangle bounds, Rectangle clientBounds);

		// Token: 0x06000029 RID: 41
		void DrawContainerBarClientBackground(Graphics graphics, Rectangle bounds);

		// Token: 0x0600002A RID: 42
		void DrawContainerBarTitleBarBackground(Graphics graphics, Rectangle bounds, bool active);

		// Token: 0x0600002B RID: 43
		void DrawContainerBarToolBarBackground(Graphics graphics, Rectangle bounds);
	}
}
