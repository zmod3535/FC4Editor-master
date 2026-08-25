using System;
using System.Windows;

namespace Divelements.SandDock.InteractiveDocking
{
	// Token: 0x0200003B RID: 59
	public abstract class DockingOperationBase
	{
		// Token: 0x06000380 RID: 896 RVA: 0x00040420 File Offset: 0x0003E820
		internal virtual bool x07fc84161e9632ab(DockableWindow xa096e9bd1fdbb4eb, out FrameworkElement x4bbc2c453c470189, out Rect xda73fcb97c77d998, out x4025ca48d3c65c4e x520d41bf4dc059d1)
		{
			x4bbc2c453c470189 = null;
			xda73fcb97c77d998 = Rect.Empty;
			x520d41bf4dc059d1 = x4025ca48d3c65c4e.xa86c909b890c3d62;
			return false;
		}

		// Token: 0x06000381 RID: 897
		internal abstract void xb82fe19b24eb0010(WindowGroup x45e7b4f4ed4ddeb2);

		// Token: 0x06000382 RID: 898
		internal abstract void x84795d7d5447dcfc(SplitContainer xb400351c70c4d6d6);

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x06000383 RID: 899
		internal abstract DockSituation x279bb9926f160988 { get; }
	}
}
