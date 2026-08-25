using System;
using System.Windows;

namespace Divelements.SandDock.InteractiveDocking
{
	// Token: 0x02000047 RID: 71
	public class TabOperation : DockingOperationBase
	{
		// Token: 0x060003BB RID: 955 RVA: 0x00041904 File Offset: 0x0003FD04
		internal TabOperation(DocumentContainer documentContainer)
		{
			this.x1f1a3b29d7ed7776 = documentContainer;
		}

		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x060003BC RID: 956 RVA: 0x00041914 File Offset: 0x0003FD14
		internal override DockSituation x279bb9926f160988
		{
			get
			{
				return DockSituation.Document;
			}
		}

		// Token: 0x060003BD RID: 957 RVA: 0x00041918 File Offset: 0x0003FD18
		internal override void xb82fe19b24eb0010(WindowGroup x45e7b4f4ed4ddeb2)
		{
			DockableWindow[] array = new DockableWindow[x45e7b4f4ed4ddeb2.Items.Count];
			x45e7b4f4ed4ddeb2.Windows.CopyTo(array, 0);
			foreach (DockableWindow x76b3d9d2638e5ecd in array)
			{
				xd679d9fc970c8f10.xe3db202f22b97a52(x76b3d9d2638e5ecd);
			}
			foreach (DockableWindow dockableWindow in array)
			{
				dockableWindow.Document(WindowOpenMethod.OpenSelectActivate);
			}
		}

		// Token: 0x060003BE RID: 958 RVA: 0x00041988 File Offset: 0x0003FD88
		internal override void x84795d7d5447dcfc(SplitContainer xb400351c70c4d6d6)
		{
			DockableWindow[] array = xd679d9fc970c8f10.x19fa3ae70a75ea3c(xb400351c70c4d6d6);
			foreach (DockableWindow x76b3d9d2638e5ecd in array)
			{
				xd679d9fc970c8f10.xe3db202f22b97a52(x76b3d9d2638e5ecd);
			}
			foreach (DockableWindow dockableWindow in array)
			{
				dockableWindow.Document(WindowOpenMethod.OpenSelectActivate);
			}
		}

		// Token: 0x060003BF RID: 959 RVA: 0x000419E0 File Offset: 0x0003FDE0
		internal override bool x07fc84161e9632ab(DockableWindow xa096e9bd1fdbb4eb, out FrameworkElement x4bbc2c453c470189, out Rect xda73fcb97c77d998, out x4025ca48d3c65c4e x520d41bf4dc059d1)
		{
			x4bbc2c453c470189 = this.x1f1a3b29d7ed7776;
			xda73fcb97c77d998 = new Rect(0.0, 0.0, x4bbc2c453c470189.ActualWidth, x4bbc2c453c470189.ActualHeight);
			x520d41bf4dc059d1 = x4025ca48d3c65c4e.xa2111e6282321fd1;
			return true;
		}

		// Token: 0x0400019D RID: 413
		private DocumentContainer x1f1a3b29d7ed7776;
	}
}
