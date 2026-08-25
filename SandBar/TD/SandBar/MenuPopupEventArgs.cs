using System;
using System.Drawing;
using System.Windows.Forms;

namespace TD.SandBar
{
	// Token: 0x0200002D RID: 45
	public class MenuPopupEventArgs : EventArgs
	{
		// Token: 0x06000281 RID: 641 RVA: 0x0000C078 File Offset: 0x0000B078
		internal MenuPopupEventArgs(MenuItemBase.MenuPopupMode mode)
		{
			this.xa4aa8b4150b11435 = mode;
		}

		// Token: 0x06000282 RID: 642 RVA: 0x0000C094 File Offset: 0x0000B094
		internal MenuPopupEventArgs(MenuItemBase.MenuPopupMode mode, Control control, bool keyboard) : this(mode)
		{
			this.x43bec302f92080b9 = control;
			this.xc8051b100df41d07 = keyboard;
		}

		// Token: 0x06000283 RID: 643 RVA: 0x0000C0AC File Offset: 0x0000B0AC
		internal MenuPopupEventArgs(MenuItemBase.MenuPopupMode mode, Control control, bool keyboard, Point position) : this(mode, control, keyboard)
		{
			this.x13d4cb8d1bd20347 = position;
		}

		// Token: 0x170000BF RID: 191
		// (get) Token: 0x06000284 RID: 644 RVA: 0x0000C0C0 File Offset: 0x0000B0C0
		// (set) Token: 0x06000285 RID: 645 RVA: 0x0000C0C8 File Offset: 0x0000B0C8
		public bool Cancel
		{
			get
			{
				return this.x57602a0a0d178a2e;
			}
			set
			{
				this.x57602a0a0d178a2e = value;
			}
		}

		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x06000286 RID: 646 RVA: 0x0000C0D4 File Offset: 0x0000B0D4
		public bool Keyboard
		{
			get
			{
				return this.xc8051b100df41d07;
			}
		}

		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x06000287 RID: 647 RVA: 0x0000C0DC File Offset: 0x0000B0DC
		public MenuItemBase.MenuPopupMode Mode
		{
			get
			{
				return this.xa4aa8b4150b11435;
			}
		}

		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x06000288 RID: 648 RVA: 0x0000C0E4 File Offset: 0x0000B0E4
		public Control Control
		{
			get
			{
				return this.x43bec302f92080b9;
			}
		}

		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x06000289 RID: 649 RVA: 0x0000C0EC File Offset: 0x0000B0EC
		// (set) Token: 0x0600028A RID: 650 RVA: 0x0000C0F4 File Offset: 0x0000B0F4
		public Point Position
		{
			get
			{
				return this.x13d4cb8d1bd20347;
			}
			set
			{
				this.x13d4cb8d1bd20347 = value;
			}
		}

		// Token: 0x040000EC RID: 236
		private MenuItemBase.MenuPopupMode xa4aa8b4150b11435;

		// Token: 0x040000ED RID: 237
		private Control x43bec302f92080b9;

		// Token: 0x040000EE RID: 238
		private Point x13d4cb8d1bd20347 = Point.Empty;

		// Token: 0x040000EF RID: 239
		private bool xc8051b100df41d07;

		// Token: 0x040000F0 RID: 240
		private bool x57602a0a0d178a2e;
	}
}
