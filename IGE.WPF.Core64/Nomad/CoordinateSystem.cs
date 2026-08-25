using System;

namespace IGE.Nomad
{
	// Token: 0x020000FD RID: 253
	internal struct CoordinateSystem
	{
		// Token: 0x060008ED RID: 2285 RVA: 0x0001DC48 File Offset: 0x0001BE48
		public CoordinateSystem(Vec3 x, Vec3 y, Vec3 z)
		{
			this.axisX = x;
			this.axisY = y;
			this.axisZ = z;
		}

		// Token: 0x060008EE RID: 2286 RVA: 0x0001DC60 File Offset: 0x0001BE60
		public static CoordinateSystem FromAngles(Vec3 angles)
		{
			CoordinateSystem result = default(CoordinateSystem);
			Binding.FCE_Core_GetAxisFromAngles(angles.X, angles.Y, angles.Z, out result.axisX.X, out result.axisX.Y, out result.axisX.Z, out result.axisY.X, out result.axisY.Y, out result.axisY.Z, out result.axisZ.X, out result.axisZ.Y, out result.axisZ.Z);
			return result;
		}

		// Token: 0x060008EF RID: 2287 RVA: 0x0001DD04 File Offset: 0x0001BF04
		public Vec3 ToAngles()
		{
			Vec3 result = default(Vec3);
			Binding.FCE_Core_GetAnglesFromAxis(out result.X, out result.Y, out result.Z, this.axisX.X, this.axisX.Y, this.axisX.Z, this.axisY.X, this.axisY.Y, this.axisY.Z, this.axisZ.X, this.axisZ.Y, this.axisZ.Z);
			return result;
		}

		// Token: 0x060008F0 RID: 2288 RVA: 0x0001DD9C File Offset: 0x0001BF9C
		public Vec3 ConvertFromWorld(Vec3 pos)
		{
			return new Vec3(Vec3.Dot(pos, this.axisX), Vec3.Dot(pos, this.axisY), Vec3.Dot(pos, this.axisZ));
		}

		// Token: 0x060008F1 RID: 2289 RVA: 0x0001DDC8 File Offset: 0x0001BFC8
		public Vec3 ConvertToWorld(Vec3 pos)
		{
			return pos.X * this.axisX + pos.Y * this.axisY + pos.Z * this.axisZ;
		}

		// Token: 0x060008F2 RID: 2290 RVA: 0x0001DE18 File Offset: 0x0001C018
		public Vec3 ConvertFromSystem(Vec3 pos, CoordinateSystem coords)
		{
			Vec3 pos2 = coords.ConvertToWorld(pos);
			return this.ConvertFromWorld(pos2);
		}

		// Token: 0x060008F3 RID: 2291 RVA: 0x0001DE38 File Offset: 0x0001C038
		public Vec3 ConvertToSystem(Vec3 pos, CoordinateSystem coords)
		{
			Vec3 pos2 = this.ConvertToWorld(pos);
			return coords.ConvertFromWorld(pos2);
		}

		// Token: 0x060008F4 RID: 2292 RVA: 0x0001DE58 File Offset: 0x0001C058
		public Vec3 GetPivotPoint(Vec3 center, AABB bounds, Pivot pivot)
		{
			Vec3 vec = center;
			switch (pivot)
			{
			case Pivot.Left:
				vec += this.axisX * bounds.min.X;
				break;
			case Pivot.Right:
				vec += this.axisX * bounds.max.X;
				break;
			case Pivot.Down:
				vec += this.axisY * bounds.min.Y;
				break;
			case Pivot.Up:
				vec += this.axisY * bounds.max.Y;
				break;
			}
			return vec;
		}

		// Token: 0x04000454 RID: 1108
		public static CoordinateSystem Standard = new CoordinateSystem(new Vec3(1f, 0f, 0f), new Vec3(0f, 1f, 0f), new Vec3(0f, 0f, 1f));

		// Token: 0x04000455 RID: 1109
		public Vec3 axisX;

		// Token: 0x04000456 RID: 1110
		public Vec3 axisY;

		// Token: 0x04000457 RID: 1111
		public Vec3 axisZ;
	}
}
