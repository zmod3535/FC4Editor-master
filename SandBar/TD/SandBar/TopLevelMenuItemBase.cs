using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using TD.SandBar.Design;

namespace TD.SandBar
{
	// Token: 0x02000020 RID: 32
	[Designer(typeof(TopLevelMenuItemDesigner))]
	public abstract class TopLevelMenuItemBase : MenuItemBase
	{
		// Token: 0x060001E1 RID: 481 RVA: 0x00008A04 File Offset: 0x00007A04
		internal TopLevelMenuItemBase()
		{
		}

		// Token: 0x060001E2 RID: 482 RVA: 0x00008A0C File Offset: 0x00007A0C
		internal TopLevelMenuItemBase(string text) : base(text)
		{
		}

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x060001E3 RID: 483 RVA: 0x00008A18 File Offset: 0x00007A18
		internal bool x785370fd71860ecc
		{
			get
			{
				return base.Popup != null && !base.Popup.xd3b329aadd8fdeb3;
			}
		}

		// Token: 0x060001E4 RID: 484 RVA: 0x00008A34 File Offset: 0x00007A34
		public MenuButtonItem ShowIndependent(Point position)
		{
			MenuButtonItem result;
			using (Form form = new Form())
			{
				x443cc432acaadb1d.SetForegroundWindow(form.Handle);
				result = this.Show(form, form.PointToClient(position));
			}
			return result;
		}

		// Token: 0x060001E5 RID: 485 RVA: 0x00008A8C File Offset: 0x00007A8C
		public MenuButtonItem Show(Control control, Point position)
		{
			return this.x19ff15e843484593(control, position, false);
		}

		// Token: 0x060001E6 RID: 486 RVA: 0x00008A98 File Offset: 0x00007A98
		internal MenuButtonItem x19ff15e843484593(Control x43bec302f92080b9, Point x13d4cb8d1bd20347, bool xc8051b100df41d07)
		{
			if (base.ToolBar == null)
			{
				throw new InvalidOperationException("This menu item must belong to a toolbar to be shown in this way.");
			}
			xf92605a24a69622a xf92605a24a69622a = new xf92605a24a69622a(base.ToolBar, x43bec302f92080b9, new TopLevelMenuItemBase[]
			{
				this
			}, base.ToolBar.Manager);
			xf92605a24a69622a.xb09380584c8ebe01 = xc8051b100df41d07;
			MenuButtonItem result = xf92605a24a69622a.x0ef5a9135fb0040c(this, false, false, x43bec302f92080b9.PointToScreen(x13d4cb8d1bd20347));
			xf92605a24a69622a.Dispose();
			return result;
		}

		// Token: 0x060001E7 RID: 487 RVA: 0x00008AFC File Offset: 0x00007AFC
		public MenuButtonItem Show(IPopupMenuHost host, Control control, Point position)
		{
			xf92605a24a69622a xf92605a24a69622a = new xf92605a24a69622a(host, control, new TopLevelMenuItemBase[]
			{
				this
			}, (host.ToolBar != null) ? host.ToolBar.Manager : null);
			MenuButtonItem result = xf92605a24a69622a.x0ef5a9135fb0040c(this, false, false, control.PointToScreen(position));
			xf92605a24a69622a.Dispose();
			return result;
		}

		// Token: 0x060001E8 RID: 488 RVA: 0x00008B4C File Offset: 0x00007B4C
		internal override void xcedf4ee3756f36dc()
		{
			if (base.ToolBar is MenuBar)
			{
				((MenuBar)base.ToolBar).ShortcutListener.UpdateAcceleratorTable(base.ToolBar);
			}
		}

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x060001E9 RID: 489 RVA: 0x00008B78 File Offset: 0x00007B78
		// (set) Token: 0x060001EA RID: 490 RVA: 0x00008B80 File Offset: 0x00007B80
		public override string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				base.Text = value;
				this.xcedf4ee3756f36dc();
			}
		}

		// Token: 0x060001EB RID: 491 RVA: 0x00008B90 File Offset: 0x00007B90
		public MenuButtonItem Show(bool select)
		{
			if (base.ToolBar == null)
			{
				throw new InvalidOperationException("This menu item must belong to a toolbar to be shown in this way.");
			}
			if (base.HiddenFromCurrentView)
			{
				throw new InvalidOperationException("The menu item cannot currently be shown. Please ensure its HiddenFromCurrentView property returns false before showing.");
			}
			xf92605a24a69622a xf92605a24a69622a = new xf92605a24a69622a(base.ToolBar, base.ToolBar, base.ToolBar.xd9ea46f5e3831639, base.ToolBar.Manager);
			MenuButtonItem result = xf92605a24a69622a.x0ef5a9135fb0040c(this, select, true, Point.Empty);
			xf92605a24a69622a.Dispose();
			return result;
		}

		// Token: 0x060001EC RID: 492 RVA: 0x00008C04 File Offset: 0x00007C04
		public MenuButtonItem Show()
		{
			return this.Show(false);
		}

		// Token: 0x02000029 RID: 41
		public enum MenuAnimation
		{
			// Token: 0x040000D9 RID: 217
			None,
			// Token: 0x040000DA RID: 218
			System,
			// Token: 0x040000DB RID: 219
			Fade,
			// Token: 0x040000DC RID: 220
			Slide,
			// Token: 0x040000DD RID: 221
			Unfold
		}
	}
}
