using System;
using System.Windows;
using System.Windows.Controls;

namespace Divelements.SandDock.InteractiveDocking
{
	// Token: 0x02000048 RID: 72
	public class SplitWindowGroupOperation : DockingOperationBase
	{
		// Token: 0x060003C0 RID: 960 RVA: 0x00041A1C File Offset: 0x0003FE1C
		internal SplitWindowGroupOperation(WindowGroup windowGroup, Dock side)
		{
			this.x2df2648551d39285 = windowGroup;
			this.x4f217665270fa928 = side;
		}

		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x060003C1 RID: 961 RVA: 0x00041A34 File Offset: 0x0003FE34
		public WindowGroup WindowGroup
		{
			get
			{
				return this.x2df2648551d39285;
			}
		}

		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x060003C2 RID: 962 RVA: 0x00041A3C File Offset: 0x0003FE3C
		public Dock Side
		{
			get
			{
				return this.x4f217665270fa928;
			}
		}

		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x060003C3 RID: 963 RVA: 0x00041A44 File Offset: 0x0003FE44
		internal override DockSituation x279bb9926f160988
		{
			get
			{
				return xd679d9fc970c8f10.xb666df934bf80a36(this.x2df2648551d39285);
			}
		}

		// Token: 0x060003C4 RID: 964 RVA: 0x00041A54 File Offset: 0x0003FE54
		internal override void xb82fe19b24eb0010(WindowGroup x45e7b4f4ed4ddeb2)
		{
			this.x2df2648551d39285.SplitForElement(x45e7b4f4ed4ddeb2, this.x4f217665270fa928);
			x45e7b4f4ed4ddeb2.FadeIn();
		}

		// Token: 0x060003C5 RID: 965 RVA: 0x00041A70 File Offset: 0x0003FE70
		internal override void x84795d7d5447dcfc(SplitContainer xb400351c70c4d6d6)
		{
			this.x2df2648551d39285.SplitForElement(xb400351c70c4d6d6, this.x4f217665270fa928);
			foreach (object obj in xb400351c70c4d6d6.Children)
			{
				FrameworkElement frameworkElement = (FrameworkElement)obj;
				WindowGroup windowGroup = frameworkElement as WindowGroup;
				if (windowGroup != null)
				{
					windowGroup.FadeIn();
				}
			}
		}

		// Token: 0x060003C6 RID: 966 RVA: 0x00041AF0 File Offset: 0x0003FEF0
		internal override bool x07fc84161e9632ab(DockableWindow xa096e9bd1fdbb4eb, out FrameworkElement x4bbc2c453c470189, out Rect xda73fcb97c77d998, out x4025ca48d3c65c4e x520d41bf4dc059d1)
		{
			x4bbc2c453c470189 = this.x2df2648551d39285;
			Size workingSize = SplitContainer.GetWorkingSize(this.x2df2648551d39285);
			WindowGroup element = xa096e9bd1fdbb4eb.Parent as WindowGroup;
			Size workingSize2 = SplitContainer.GetWorkingSize(element);
			double num;
			if (this.x4f217665270fa928 == Dock.Top || this.x4f217665270fa928 == Dock.Bottom)
			{
				num = workingSize2.Height / (workingSize2.Height + workingSize.Height) * this.x2df2648551d39285.RenderSize.Height;
			}
			else
			{
				num = workingSize2.Width / (workingSize2.Width + workingSize.Width) * this.x2df2648551d39285.RenderSize.Width;
			}
			if (this.x4f217665270fa928 == Dock.Top)
			{
				xda73fcb97c77d998 = new Rect(0.0, 0.0, this.x2df2648551d39285.RenderSize.Width, num);
			}
			else if (this.x4f217665270fa928 == Dock.Right)
			{
				xda73fcb97c77d998 = new Rect(this.x2df2648551d39285.RenderSize.Width - num, 0.0, num, this.x2df2648551d39285.RenderSize.Height);
			}
			else if (this.x4f217665270fa928 == Dock.Bottom)
			{
				xda73fcb97c77d998 = new Rect(0.0, this.x2df2648551d39285.RenderSize.Height - num, this.x2df2648551d39285.RenderSize.Width, num);
			}
			else
			{
				xda73fcb97c77d998 = new Rect(0.0, 0.0, num, this.x2df2648551d39285.RenderSize.Height);
			}
			x520d41bf4dc059d1 = ((this.x2df2648551d39285.SelectedWindow.DockSituation == DockSituation.Document) ? x4025ca48d3c65c4e.xa2111e6282321fd1 : x4025ca48d3c65c4e.xa86c909b890c3d62);
			return true;
		}

		// Token: 0x0400019E RID: 414
		private WindowGroup x2df2648551d39285;

		// Token: 0x0400019F RID: 415
		private Dock x4f217665270fa928;
	}
}
