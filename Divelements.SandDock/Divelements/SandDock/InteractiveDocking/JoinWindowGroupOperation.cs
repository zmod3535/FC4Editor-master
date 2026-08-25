using System;
using System.Windows;

namespace Divelements.SandDock.InteractiveDocking
{
	// Token: 0x02000049 RID: 73
	public class JoinWindowGroupOperation : DockingOperationBase
	{
		// Token: 0x060003C7 RID: 967 RVA: 0x00041CB8 File Offset: 0x000400B8
		internal JoinWindowGroupOperation(WindowGroup windowGroup)
		{
			this.x2df2648551d39285 = windowGroup;
		}

		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x060003C8 RID: 968 RVA: 0x00041CC8 File Offset: 0x000400C8
		public WindowGroup WindowGroup
		{
			get
			{
				return this.x2df2648551d39285;
			}
		}

		// Token: 0x170000DA RID: 218
		// (get) Token: 0x060003C9 RID: 969 RVA: 0x00041CD0 File Offset: 0x000400D0
		internal override DockSituation x279bb9926f160988
		{
			get
			{
				return xd679d9fc970c8f10.xb666df934bf80a36(this.x2df2648551d39285);
			}
		}

		// Token: 0x060003CA RID: 970 RVA: 0x00041CE0 File Offset: 0x000400E0
		internal override void xb82fe19b24eb0010(WindowGroup x45e7b4f4ed4ddeb2)
		{
			DockableWindow[] array = new DockableWindow[x45e7b4f4ed4ddeb2.Items.Count];
			x45e7b4f4ed4ddeb2.Windows.CopyTo(array, 0);
			foreach (DockableWindow x76b3d9d2638e5ecd in array)
			{
				xd679d9fc970c8f10.xe3db202f22b97a52(x76b3d9d2638e5ecd);
			}
			foreach (DockableWindow item in array)
			{
				this.x2df2648551d39285.Windows.Add(item);
			}
			this.x2df2648551d39285.FadeIn();
		}

		// Token: 0x060003CB RID: 971 RVA: 0x00041D64 File Offset: 0x00040164
		internal override void x84795d7d5447dcfc(SplitContainer xb400351c70c4d6d6)
		{
			DockableWindow[] array = xd679d9fc970c8f10.x19fa3ae70a75ea3c(xb400351c70c4d6d6);
			foreach (DockableWindow dockableWindow in array)
			{
				xd679d9fc970c8f10.xe3db202f22b97a52(dockableWindow);
				this.x2df2648551d39285.Windows.Add(dockableWindow);
			}
			this.x2df2648551d39285.FadeIn();
		}

		// Token: 0x060003CC RID: 972 RVA: 0x00041DB0 File Offset: 0x000401B0
		internal override bool x07fc84161e9632ab(DockableWindow xa096e9bd1fdbb4eb, out FrameworkElement x4bbc2c453c470189, out Rect xda73fcb97c77d998, out x4025ca48d3c65c4e x520d41bf4dc059d1)
		{
			x4bbc2c453c470189 = this.x2df2648551d39285;
			xda73fcb97c77d998 = new Rect(new Point(0.0, 0.0), this.x2df2648551d39285.RenderSize);
			x520d41bf4dc059d1 = x4025ca48d3c65c4e.x52cffb079963bcb2;
			return true;
		}

		// Token: 0x040001A0 RID: 416
		private WindowGroup x2df2648551d39285;
	}
}
