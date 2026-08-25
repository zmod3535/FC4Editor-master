using System;

namespace TD.SandDock.Rendering
{
	// Token: 0x02000025 RID: 37
	public class BoxEdges
	{
		// Token: 0x0600033C RID: 828 RVA: 0x0001B050 File Offset: 0x0001A050
		public BoxEdges()
		{
		}

		// Token: 0x0600033D RID: 829 RVA: 0x0001B058 File Offset: 0x0001A058
		public BoxEdges(int left, int top, int right, int bottom)
		{
			this.xa447fc54e41dfe06 = left;
			this.xc941868c59399d3e = top;
			this.xfc2074a859a5db8c = right;
			this.xaf9a0436a70689de = bottom;
		}

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x0600033E RID: 830 RVA: 0x0001B080 File Offset: 0x0001A080
		public int Left
		{
			get
			{
				return this.xa447fc54e41dfe06;
			}
		}

		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x0600033F RID: 831 RVA: 0x0001B088 File Offset: 0x0001A088
		public int Top
		{
			get
			{
				return this.xc941868c59399d3e;
			}
		}

		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x06000340 RID: 832 RVA: 0x0001B090 File Offset: 0x0001A090
		public int Right
		{
			get
			{
				return this.xfc2074a859a5db8c;
			}
		}

		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x06000341 RID: 833 RVA: 0x0001B098 File Offset: 0x0001A098
		public int Bottom
		{
			get
			{
				return this.xaf9a0436a70689de;
			}
		}

		// Token: 0x0400010E RID: 270
		private int xa447fc54e41dfe06;

		// Token: 0x0400010F RID: 271
		private int xc941868c59399d3e;

		// Token: 0x04000110 RID: 272
		private int xaf9a0436a70689de;

		// Token: 0x04000111 RID: 273
		private int xfc2074a859a5db8c;
	}
}
