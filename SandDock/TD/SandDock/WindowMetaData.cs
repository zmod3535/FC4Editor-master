using System;

namespace TD.SandDock
{
	// Token: 0x02000035 RID: 53
	public class WindowMetaData
	{
		// Token: 0x06000441 RID: 1089 RVA: 0x00022450 File Offset: 0x00021450
		internal WindowMetaData()
		{
			this.x02053c1a8559b85f = new xd0aa9d0e7d3446c0();
			this.xa93c1ee3649251c3 = new x129cb2a2bdfd0ab2();
			this.xd322344ef33dfd34 = new x129cb2a2bdfd0ab2();
		}

		// Token: 0x1700010E RID: 270
		// (get) Token: 0x06000442 RID: 1090 RVA: 0x000224A0 File Offset: 0x000214A0
		public DateTime LastFocused
		{
			get
			{
				return this.x36addad21d4cd225;
			}
		}

		// Token: 0x06000443 RID: 1091 RVA: 0x000224A8 File Offset: 0x000214A8
		internal void x15481da58c59597a(DateTime xbcea506a33cf9111)
		{
			this.x36addad21d4cd225 = xbcea506a33cf9111;
		}

		// Token: 0x1700010F RID: 271
		// (get) Token: 0x06000444 RID: 1092 RVA: 0x000224B4 File Offset: 0x000214B4
		public ContainerDockLocation LastFixedDockSide
		{
			get
			{
				return this.xdcf3623df6a7e235;
			}
		}

		// Token: 0x06000445 RID: 1093 RVA: 0x000224BC File Offset: 0x000214BC
		internal void xfca44c52f41f0e26(ContainerDockLocation xbcea506a33cf9111)
		{
			this.xdcf3623df6a7e235 = xbcea506a33cf9111;
		}

		// Token: 0x17000110 RID: 272
		// (get) Token: 0x06000446 RID: 1094 RVA: 0x000224C8 File Offset: 0x000214C8
		public int DockedContentSize
		{
			get
			{
				if (this.x0c34bafa1bebd8d8 == -1)
				{
					return 200;
				}
				return this.x0c34bafa1bebd8d8;
			}
		}

		// Token: 0x06000447 RID: 1095 RVA: 0x000224E0 File Offset: 0x000214E0
		internal void x3ef4455ea4965093(int xbcea506a33cf9111)
		{
			this.x0c34bafa1bebd8d8 = xbcea506a33cf9111;
		}

		// Token: 0x17000111 RID: 273
		// (get) Token: 0x06000448 RID: 1096 RVA: 0x000224EC File Offset: 0x000214EC
		internal bool x057495d927e64b9e
		{
			get
			{
				return this.x0c34bafa1bebd8d8 != -1;
			}
		}

		// Token: 0x17000112 RID: 274
		// (get) Token: 0x06000449 RID: 1097 RVA: 0x000224FC File Offset: 0x000214FC
		public DockSituation LastOpenDockSituation
		{
			get
			{
				return this.x2097366c1b6e436a;
			}
		}

		// Token: 0x0600044A RID: 1098 RVA: 0x00022504 File Offset: 0x00021504
		internal void xb0e0bc77d88737a8(DockSituation xbcea506a33cf9111)
		{
			this.x2097366c1b6e436a = xbcea506a33cf9111;
		}

		// Token: 0x17000113 RID: 275
		// (get) Token: 0x0600044B RID: 1099 RVA: 0x00022510 File Offset: 0x00021510
		public DockSituation LastFixedDockSituation
		{
			get
			{
				return this.x86d57ad3fc8ec08d;
			}
		}

		// Token: 0x0600044C RID: 1100 RVA: 0x00022518 File Offset: 0x00021518
		internal void x0ba17c4cff658fcf(DockSituation xbcea506a33cf9111)
		{
			this.x86d57ad3fc8ec08d = xbcea506a33cf9111;
		}

		// Token: 0x17000114 RID: 276
		// (get) Token: 0x0600044D RID: 1101 RVA: 0x00022524 File Offset: 0x00021524
		internal xd0aa9d0e7d3446c0 xe62a3d24e0fde928
		{
			get
			{
				return this.x02053c1a8559b85f;
			}
		}

		// Token: 0x17000115 RID: 277
		// (get) Token: 0x0600044E RID: 1102 RVA: 0x0002252C File Offset: 0x0002152C
		internal x129cb2a2bdfd0ab2 x25e1dbd0e63329bf
		{
			get
			{
				return this.xa93c1ee3649251c3;
			}
		}

		// Token: 0x17000116 RID: 278
		// (get) Token: 0x0600044F RID: 1103 RVA: 0x00022534 File Offset: 0x00021534
		internal x129cb2a2bdfd0ab2 xba74b873ae2f845a
		{
			get
			{
				return this.xd322344ef33dfd34;
			}
		}

		// Token: 0x17000117 RID: 279
		// (get) Token: 0x06000450 RID: 1104 RVA: 0x0002253C File Offset: 0x0002153C
		public Guid LastFloatingWindowGuid
		{
			get
			{
				return this.xa637547ad85d295d;
			}
		}

		// Token: 0x06000451 RID: 1105 RVA: 0x00022544 File Offset: 0x00021544
		internal void x87f4a9b62a380563(Guid xbcea506a33cf9111)
		{
			this.xa637547ad85d295d = xbcea506a33cf9111;
		}

		// Token: 0x04000169 RID: 361
		private DateTime x36addad21d4cd225 = DateTime.FromFileTime(0L);

		// Token: 0x0400016A RID: 362
		private int x0c34bafa1bebd8d8 = -1;

		// Token: 0x0400016B RID: 363
		private DockSituation x2097366c1b6e436a;

		// Token: 0x0400016C RID: 364
		private DockSituation x86d57ad3fc8ec08d;

		// Token: 0x0400016D RID: 365
		private x129cb2a2bdfd0ab2 xa93c1ee3649251c3;

		// Token: 0x0400016E RID: 366
		private x129cb2a2bdfd0ab2 xd322344ef33dfd34;

		// Token: 0x0400016F RID: 367
		private xd0aa9d0e7d3446c0 x02053c1a8559b85f;

		// Token: 0x04000170 RID: 368
		private Guid xa637547ad85d295d;

		// Token: 0x04000171 RID: 369
		private ContainerDockLocation xdcf3623df6a7e235 = ContainerDockLocation.Right;
	}
}
