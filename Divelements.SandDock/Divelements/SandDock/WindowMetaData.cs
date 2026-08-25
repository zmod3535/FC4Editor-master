using System;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace Divelements.SandDock
{
	// Token: 0x02000009 RID: 9
	public class WindowMetaData
	{
		// Token: 0x060000A6 RID: 166 RVA: 0x00033428 File Offset: 0x00031828
		internal WindowMetaData()
		{
			this.x02053c1a8559b85f = new xd0aa9d0e7d3446c0();
			this.xa93c1ee3649251c3 = new x129cb2a2bdfd0ab2();
			this.xd322344ef33dfd34 = new x129cb2a2bdfd0ab2();
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x060000A7 RID: 167 RVA: 0x00033484 File Offset: 0x00031884
		// (set) Token: 0x060000A8 RID: 168 RVA: 0x0003348C File Offset: 0x0003188C
		public DateTime LastFocused
		{
			get
			{
				return this.x36addad21d4cd225;
			}
			internal set
			{
				this.x36addad21d4cd225 = value;
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x060000A9 RID: 169 RVA: 0x00033498 File Offset: 0x00031898
		// (set) Token: 0x060000AA RID: 170 RVA: 0x000334A0 File Offset: 0x000318A0
		public double DockedContentSize
		{
			get
			{
				return this.x0c34bafa1bebd8d8;
			}
			internal set
			{
				this.x0c34bafa1bebd8d8 = value;
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x060000AB RID: 171 RVA: 0x000334AC File Offset: 0x000318AC
		// (set) Token: 0x060000AC RID: 172 RVA: 0x000334B4 File Offset: 0x000318B4
		public DockSituation LastOpenDockSituation
		{
			get
			{
				return this.x2097366c1b6e436a;
			}
			internal set
			{
				this.x2097366c1b6e436a = value;
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x060000AD RID: 173 RVA: 0x000334C0 File Offset: 0x000318C0
		// (set) Token: 0x060000AE RID: 174 RVA: 0x000334C8 File Offset: 0x000318C8
		public DockSituation LastFixedDockSituation
		{
			get
			{
				return this.x86d57ad3fc8ec08d;
			}
			internal set
			{
				this.x86d57ad3fc8ec08d = value;
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x060000AF RID: 175 RVA: 0x000334D4 File Offset: 0x000318D4
		internal xd0aa9d0e7d3446c0 xe62a3d24e0fde928
		{
			get
			{
				return this.x02053c1a8559b85f;
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x060000B0 RID: 176 RVA: 0x000334DC File Offset: 0x000318DC
		internal x129cb2a2bdfd0ab2 x25e1dbd0e63329bf
		{
			get
			{
				return this.xa93c1ee3649251c3;
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x060000B1 RID: 177 RVA: 0x000334E4 File Offset: 0x000318E4
		internal x129cb2a2bdfd0ab2 xba74b873ae2f845a
		{
			get
			{
				return this.xd322344ef33dfd34;
			}
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x060000B2 RID: 178 RVA: 0x000334EC File Offset: 0x000318EC
		// (set) Token: 0x060000B3 RID: 179 RVA: 0x000334F4 File Offset: 0x000318F4
		internal Guid xe54c39cad89808e2
		{
			get
			{
				return this.xa637547ad85d295d;
			}
			set
			{
				this.xa637547ad85d295d = value;
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x060000B4 RID: 180 RVA: 0x00033500 File Offset: 0x00031900
		// (set) Token: 0x060000B5 RID: 181 RVA: 0x00033508 File Offset: 0x00031908
		public Dock LastFixedDockSide
		{
			get
			{
				return this.xf2998bb098f0c782;
			}
			internal set
			{
				this.xf2998bb098f0c782 = value;
			}
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x060000B6 RID: 182 RVA: 0x00033514 File Offset: 0x00031914
		// (set) Token: 0x060000B7 RID: 183 RVA: 0x0003351C File Offset: 0x0003191C
		internal xdeadcc9941b6354e[] x89d9f6f099893f30 { get; set; }

		// Token: 0x0400002E RID: 46
		private DateTime x36addad21d4cd225;

		// Token: 0x0400002F RID: 47
		private double x0c34bafa1bebd8d8 = (double)DockableWindow.ContentSizeProperty.DefaultMetadata.DefaultValue;

		// Token: 0x04000030 RID: 48
		private DockSituation x2097366c1b6e436a = DockSituation.Docked;

		// Token: 0x04000031 RID: 49
		private DockSituation x86d57ad3fc8ec08d = DockSituation.Docked;

		// Token: 0x04000032 RID: 50
		private x129cb2a2bdfd0ab2 xa93c1ee3649251c3;

		// Token: 0x04000033 RID: 51
		private x129cb2a2bdfd0ab2 xd322344ef33dfd34;

		// Token: 0x04000034 RID: 52
		private xd0aa9d0e7d3446c0 x02053c1a8559b85f;

		// Token: 0x04000035 RID: 53
		private Guid xa637547ad85d295d;

		// Token: 0x04000036 RID: 54
		private Dock xf2998bb098f0c782;

		// Token: 0x04000037 RID: 55
		[CompilerGenerated]
		private xdeadcc9941b6354e[] x5fc35951f0d3c781;
	}
}
