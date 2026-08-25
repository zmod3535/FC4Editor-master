using System;

namespace IGE.Nomad
{
	// Token: 0x020000FE RID: 254
	internal struct Plane
	{
		// Token: 0x060008F6 RID: 2294 RVA: 0x0001DF58 File Offset: 0x0001C158
		public static Plane FromPoints(Vec3 p1, Vec3 p2, Vec3 p3)
		{
			Plane result = default(Plane);
			Vec3 v = p2 - p1;
			Vec3 v2 = p2 - p3;
			Vec3 v3 = Vec3.Cross(v, v2);
			v3.Normalize();
			result.normal = v3;
			result.dist = Vec3.Dot(v3, p1);
			return result;
		}

		// Token: 0x060008F7 RID: 2295 RVA: 0x0001DFA4 File Offset: 0x0001C1A4
		public static Plane FromPointNormal(Vec3 pt, Vec3 normal)
		{
			return new Plane
			{
				normal = normal,
				dist = Vec3.Dot(normal, pt)
			};
		}

		// Token: 0x060008F8 RID: 2296 RVA: 0x0001DFD0 File Offset: 0x0001C1D0
		public bool RayIntersect(Vec3 raySrc, Vec3 rayDir, out Vec3 pt)
		{
			float num = Vec3.Dot(this.normal, rayDir);
			if (Math.Abs(num) < 0.0001f)
			{
				pt = default(Vec3);
				return false;
			}
			float s = Vec3.Dot(this.normal, this.dist * this.normal - raySrc) / num;
			pt = raySrc + s * rayDir;
			return true;
		}

		// Token: 0x04000458 RID: 1112
		public Vec3 normal;

		// Token: 0x04000459 RID: 1113
		public float dist;
	}
}
