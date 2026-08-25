using System;
using System.Windows.Forms;

namespace TD.SandBar
{
	// Token: 0x0200004F RID: 79
	internal class x72ff29faed0885ea
	{
		// Token: 0x060003D2 RID: 978 RVA: 0x00013C6C File Offset: 0x00012C6C
		public x72ff29faed0885ea(x72ff29faed0885ea.MenuCommandType commandType, MenuItemBase menu, bool selectTopItem) : this(commandType, menu)
		{
			this.xa9ffede45d327713 = selectTopItem;
		}

		// Token: 0x060003D3 RID: 979 RVA: 0x00013C80 File Offset: 0x00012C80
		public x72ff29faed0885ea(x72ff29faed0885ea.MenuCommandType commandType, MenuItemBase menu) : this(commandType)
		{
			this.xbc9a1cbeed95c3fc = menu;
		}

		// Token: 0x060003D4 RID: 980 RVA: 0x00013C90 File Offset: 0x00012C90
		public x72ff29faed0885ea(x72ff29faed0885ea.MenuCommandType commandType)
		{
			this.x1cbe9ccc3cd216b4 = commandType;
		}

		// Token: 0x060003D5 RID: 981 RVA: 0x00013CA8 File Offset: 0x00012CA8
		public x72ff29faed0885ea(x72ff29faed0885ea.MenuCommandType commandType, Control control) : this(commandType)
		{
			this.xd5a7a92b8cfb14b3 = control;
		}

		// Token: 0x040001AF RID: 431
		public x72ff29faed0885ea.MenuCommandType x1cbe9ccc3cd216b4;

		// Token: 0x040001B0 RID: 432
		public MenuItemBase xbc9a1cbeed95c3fc;

		// Token: 0x040001B1 RID: 433
		public bool xa9ffede45d327713;

		// Token: 0x040001B2 RID: 434
		public Control xd5a7a92b8cfb14b3;

		// Token: 0x040001B3 RID: 435
		public bool xd5e60b0fe283887c = true;

		// Token: 0x02000050 RID: 80
		public enum MenuCommandType
		{
			// Token: 0x040001B5 RID: 437
			Show,
			// Token: 0x040001B6 RID: 438
			Cancel,
			// Token: 0x040001B7 RID: 439
			Execute
		}
	}
}
