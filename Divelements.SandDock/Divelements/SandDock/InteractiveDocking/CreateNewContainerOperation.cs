using System;
using System.Windows;
using System.Windows.Controls;

namespace Divelements.SandDock.InteractiveDocking
{
	// Token: 0x02000046 RID: 70
	public class CreateNewContainerOperation : DockingOperationBase
	{
		// Token: 0x060003B3 RID: 947 RVA: 0x0004160C File Offset: 0x0003FA0C
		internal CreateNewContainerOperation(DockSite dockSite, Dock side, DockSiteEdge edge)
		{
			this.x7f72cb59f44fe44c = dockSite;
			this.x4f217665270fa928 = side;
			this.x3e4dcab61996c9ea = edge;
		}

		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x060003B4 RID: 948 RVA: 0x0004162C File Offset: 0x0003FA2C
		public Dock Side
		{
			get
			{
				return this.x4f217665270fa928;
			}
		}

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x060003B5 RID: 949 RVA: 0x00041634 File Offset: 0x0003FA34
		public DockSiteEdge Edge
		{
			get
			{
				return this.x3e4dcab61996c9ea;
			}
		}

		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x060003B6 RID: 950 RVA: 0x0004163C File Offset: 0x0003FA3C
		internal override DockSituation x279bb9926f160988
		{
			get
			{
				return DockSituation.Docked;
			}
		}

		// Token: 0x060003B7 RID: 951 RVA: 0x00041640 File Offset: 0x0003FA40
		public static double GetValidContentSize(DockSite dockSite, double contentSize, Dock side)
		{
			if (side == Dock.Left || side == Dock.Right)
			{
				return Math.Max(Math.Min(contentSize, dockSite.ClientBounds.Width), 15.0);
			}
			return Math.Max(Math.Min(contentSize, dockSite.ClientBounds.Height), 15.0);
		}

		// Token: 0x060003B8 RID: 952 RVA: 0x0004169C File Offset: 0x0003FA9C
		internal override void xb82fe19b24eb0010(WindowGroup x45e7b4f4ed4ddeb2)
		{
			SplitContainer splitContainer = this.x7f72cb59f44fe44c.CreateDockedSplitContainer(this.x4f217665270fa928, this.x3e4dcab61996c9ea, CreateNewContainerOperation.GetValidContentSize(this.x7f72cb59f44fe44c, x45e7b4f4ed4ddeb2.SelectedWindow.MetaData.DockedContentSize, this.x4f217665270fa928));
			splitContainer.Children.Add(x45e7b4f4ed4ddeb2);
			x45e7b4f4ed4ddeb2.FadeIn();
		}

		// Token: 0x060003B9 RID: 953 RVA: 0x000416F4 File Offset: 0x0003FAF4
		internal override void x84795d7d5447dcfc(SplitContainer xb400351c70c4d6d6)
		{
			FrameworkElement[] array = new FrameworkElement[xb400351c70c4d6d6.Children.Count];
			xb400351c70c4d6d6.Children.CopyTo(array, 0);
			double validContentSize = CreateNewContainerOperation.GetValidContentSize(this.x7f72cb59f44fe44c, xd679d9fc970c8f10.x19fa3ae70a75ea3c(xb400351c70c4d6d6)[0].MetaData.DockedContentSize, this.x4f217665270fa928);
			xb400351c70c4d6d6.Children.Clear();
			SplitContainer splitContainer = this.x7f72cb59f44fe44c.CreateDockedSplitContainer(this.x4f217665270fa928, this.x3e4dcab61996c9ea, validContentSize);
			splitContainer.SplitterOrientation = xb400351c70c4d6d6.SplitterOrientation;
			foreach (FrameworkElement element in array)
			{
				splitContainer.Children.Add(element);
			}
			foreach (FrameworkElement frameworkElement in array)
			{
				WindowGroup windowGroup = frameworkElement as WindowGroup;
				if (windowGroup != null)
				{
					windowGroup.FadeIn();
				}
			}
		}

		// Token: 0x060003BA RID: 954 RVA: 0x000417CC File Offset: 0x0003FBCC
		internal override bool x07fc84161e9632ab(DockableWindow xa096e9bd1fdbb4eb, out FrameworkElement x4bbc2c453c470189, out Rect xda73fcb97c77d998, out x4025ca48d3c65c4e x520d41bf4dc059d1)
		{
			x4bbc2c453c470189 = this.x7f72cb59f44fe44c;
			Rect rect = (this.x3e4dcab61996c9ea == DockSiteEdge.Inside) ? this.x7f72cb59f44fe44c.ClientBounds : new Rect(0.0, 0.0, this.x7f72cb59f44fe44c.RenderSize.Width, this.x7f72cb59f44fe44c.RenderSize.Height);
			double validContentSize = CreateNewContainerOperation.GetValidContentSize(this.x7f72cb59f44fe44c, xa096e9bd1fdbb4eb.MetaData.DockedContentSize, this.x4f217665270fa928);
			if (this.x4f217665270fa928 == Dock.Top)
			{
				xda73fcb97c77d998 = new Rect(rect.X, rect.Y, rect.Width, validContentSize);
			}
			else if (this.x4f217665270fa928 == Dock.Left)
			{
				xda73fcb97c77d998 = new Rect(rect.X, rect.Y, validContentSize, rect.Height);
			}
			else if (this.x4f217665270fa928 == Dock.Right)
			{
				xda73fcb97c77d998 = new Rect(rect.Right - validContentSize, rect.Y, validContentSize, rect.Height);
			}
			else
			{
				xda73fcb97c77d998 = new Rect(rect.X, rect.Bottom - validContentSize, rect.Width, validContentSize);
			}
			x520d41bf4dc059d1 = x4025ca48d3c65c4e.xa86c909b890c3d62;
			return true;
		}

		// Token: 0x0400019A RID: 410
		private DockSite x7f72cb59f44fe44c;

		// Token: 0x0400019B RID: 411
		private Dock x4f217665270fa928;

		// Token: 0x0400019C RID: 412
		private DockSiteEdge x3e4dcab61996c9ea;
	}
}
