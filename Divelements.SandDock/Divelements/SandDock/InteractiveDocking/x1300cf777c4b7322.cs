using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace Divelements.SandDock.InteractiveDocking
{
	// Token: 0x0200004C RID: 76
	internal class x1300cf777c4b7322
	{
		// Token: 0x060003DD RID: 989 RVA: 0x0004202C File Offset: 0x0004042C
		public x1300cf777c4b7322(PositionPreview preview)
		{
			this.x8b4f3cb8df82acea = preview;
			if (this.x5d93c4d6d3efc524())
			{
				this.x76b3d9d2638e5ecd = new Window();
				this.x76b3d9d2638e5ecd.Topmost = true;
				this.x76b3d9d2638e5ecd.WindowStyle = WindowStyle.None;
				this.x76b3d9d2638e5ecd.ShowInTaskbar = false;
				this.x76b3d9d2638e5ecd.AllowsTransparency = true;
				this.x76b3d9d2638e5ecd.Background = Brushes.Transparent;
				typeof(Window).GetProperty("ShowActivated", BindingFlags.Instance | BindingFlags.Public).SetValue(this.x76b3d9d2638e5ecd, false, null);
				return;
			}
			this.xd70b090e3181abff = new Popup();
			this.xd70b090e3181abff.AllowsTransparency = true;
			this.xd70b090e3181abff.Placement = PlacementMode.Absolute;
		}

		// Token: 0x060003DE RID: 990 RVA: 0x000420E8 File Offset: 0x000404E8
		private bool x5d93c4d6d3efc524()
		{
			return false;
		}

		// Token: 0x060003DF RID: 991 RVA: 0x000420EC File Offset: 0x000404EC
		public void x47b5c057cc37f4ff(Rect xda73fcb97c77d998)
		{
			if (this.x76b3d9d2638e5ecd != null)
			{
				this.x76b3d9d2638e5ecd.Content = this.x8b4f3cb8df82acea;
				if ((xda73fcb97c77d998.Left != this.x76b3d9d2638e5ecd.Left && xda73fcb97c77d998.Top != this.x76b3d9d2638e5ecd.Top) || (xda73fcb97c77d998.Width != this.x76b3d9d2638e5ecd.Width && xda73fcb97c77d998.Height != this.x76b3d9d2638e5ecd.Height))
				{
					this.x76b3d9d2638e5ecd.Hide();
				}
				this.x76b3d9d2638e5ecd.Left = xda73fcb97c77d998.Left;
				this.x76b3d9d2638e5ecd.Top = xda73fcb97c77d998.Top;
				this.x76b3d9d2638e5ecd.Width = xda73fcb97c77d998.Width;
				this.x76b3d9d2638e5ecd.Height = xda73fcb97c77d998.Height;
				this.x76b3d9d2638e5ecd.Show();
				return;
			}
			this.xd70b090e3181abff.Child = this.x8b4f3cb8df82acea;
			this.xd70b090e3181abff.PlacementRectangle = new Rect(xda73fcb97c77d998.Location, new Size(0.0, 0.0));
			this.xd70b090e3181abff.Width = xda73fcb97c77d998.Width;
			this.xd70b090e3181abff.Height = xda73fcb97c77d998.Height;
			this.xd70b090e3181abff.IsOpen = true;
		}

		// Token: 0x060003E0 RID: 992 RVA: 0x00042234 File Offset: 0x00040634
		public void x5486e0b5e830d25c()
		{
			if (this.x76b3d9d2638e5ecd != null)
			{
				this.x76b3d9d2638e5ecd.Hide();
				this.x76b3d9d2638e5ecd.Content = null;
				return;
			}
			this.xd70b090e3181abff.Child = null;
			this.xd70b090e3181abff.IsOpen = false;
		}

		// Token: 0x060003E1 RID: 993 RVA: 0x00042270 File Offset: 0x00040670
		public void x3607c8ea8b9a05f6()
		{
			if (this.x76b3d9d2638e5ecd != null)
			{
				this.x76b3d9d2638e5ecd.Close();
			}
		}

		// Token: 0x040001A4 RID: 420
		private PositionPreview x8b4f3cb8df82acea;

		// Token: 0x040001A5 RID: 421
		private Popup xd70b090e3181abff;

		// Token: 0x040001A6 RID: 422
		private Window x76b3d9d2638e5ecd;
	}
}
