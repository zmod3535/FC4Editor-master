using System;

namespace IGE.Nomad
{
	// Token: 0x020000FF RID: 255
	internal struct AABB
	{
		// Token: 0x060008F9 RID: 2297 RVA: 0x0001E039 File Offset: 0x0001C239
		public AABB(Vec3 min, Vec3 max)
		{
			this.min = min;
			this.max = max;
		}

		// Token: 0x060008FA RID: 2298 RVA: 0x0001E04C File Offset: 0x0001C24C
		public static AABB operator -(AABB a, Vec3 b)
		{
			Vec3 vec = a.min - b;
			Vec3 vec2 = a.max - b;
			return new AABB(vec, vec2);
		}

		// Token: 0x17000205 RID: 517
		// (get) Token: 0x060008FB RID: 2299 RVA: 0x0001E07C File Offset: 0x0001C27C
		public Vec3 Length
		{
			get
			{
				return this.max - this.min;
			}
		}

		// Token: 0x17000206 RID: 518
		// (get) Token: 0x060008FC RID: 2300 RVA: 0x0001E08F File Offset: 0x0001C28F
		public Vec3 Center
		{
			get
			{
				return (this.max + this.min) * 0.5f;
			}
		}

		// Token: 0x060008FD RID: 2301 RVA: 0x0001E0AC File Offset: 0x0001C2AC
		public override string ToString()
		{
			Vec3 length = this.Length;
			return string.Concat(new string[]
			{
				length.X.ToString("F1"),
				" x ",
				length.Y.ToString("F1"),
				" x ",
				length.Z.ToString("F1"),
				" m"
			});
		}

		// Token: 0x0400045A RID: 1114
		public Vec3 min;

		// Token: 0x0400045B RID: 1115
		public Vec3 max;
	}
}
