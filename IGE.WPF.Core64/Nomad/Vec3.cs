using System;

namespace IGE.Nomad
{
	// Token: 0x020000FC RID: 252
	internal struct Vec3
	{
		// Token: 0x060008CE RID: 2254 RVA: 0x0001D6F2 File Offset: 0x0001B8F2
		public Vec3(float x, float y, float z)
		{
			this.X = x;
			this.Y = y;
			this.Z = z;
		}

		// Token: 0x170001FF RID: 511
		// (get) Token: 0x060008CF RID: 2255 RVA: 0x0001D709 File Offset: 0x0001B909
		// (set) Token: 0x060008D0 RID: 2256 RVA: 0x0001D71C File Offset: 0x0001B91C
		public Vec2 XY
		{
			get
			{
				return new Vec2(this.X, this.Y);
			}
			set
			{
				this.X = value.X;
				this.Y = value.Y;
			}
		}

		// Token: 0x17000200 RID: 512
		// (get) Token: 0x060008D1 RID: 2257 RVA: 0x0001D738 File Offset: 0x0001B938
		// (set) Token: 0x060008D2 RID: 2258 RVA: 0x0001D74B File Offset: 0x0001B94B
		public Vec2 XZ
		{
			get
			{
				return new Vec2(this.X, this.Z);
			}
			set
			{
				this.X = value.X;
				this.Z = value.Y;
			}
		}

		// Token: 0x17000201 RID: 513
		// (get) Token: 0x060008D3 RID: 2259 RVA: 0x0001D767 File Offset: 0x0001B967
		// (set) Token: 0x060008D4 RID: 2260 RVA: 0x0001D77A File Offset: 0x0001B97A
		public Vec2 YZ
		{
			get
			{
				return new Vec2(this.Y, this.Z);
			}
			set
			{
				this.Y = value.X;
				this.Z = value.Y;
			}
		}

		// Token: 0x060008D5 RID: 2261 RVA: 0x0001D796 File Offset: 0x0001B996
		public static Vec3 operator +(Vec3 v1, Vec3 v2)
		{
			return new Vec3(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
		}

		// Token: 0x060008D6 RID: 2262 RVA: 0x0001D7CA File Offset: 0x0001B9CA
		public static Vec3 operator -(Vec3 v1, Vec3 v2)
		{
			return new Vec3(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
		}

		// Token: 0x060008D7 RID: 2263 RVA: 0x0001D7FE File Offset: 0x0001B9FE
		public static Vec3 operator -(Vec3 v)
		{
			return new Vec3(-v.X, -v.Y, -v.Z);
		}

		// Token: 0x060008D8 RID: 2264 RVA: 0x0001D81D File Offset: 0x0001BA1D
		public static Vec3 operator *(float s, Vec3 v)
		{
			return new Vec3(v.X * s, v.Y * s, v.Z * s);
		}

		// Token: 0x060008D9 RID: 2265 RVA: 0x0001D83F File Offset: 0x0001BA3F
		public static Vec3 operator *(Vec3 v, float s)
		{
			return new Vec3(v.X * s, v.Y * s, v.Z * s);
		}

		// Token: 0x060008DA RID: 2266 RVA: 0x0001D861 File Offset: 0x0001BA61
		public static Vec3 operator *(Vec3 v1, Vec3 v2)
		{
			return new Vec3(v1.X * v2.X, v1.Y * v2.Y, v1.Z * v2.Z);
		}

		// Token: 0x060008DB RID: 2267 RVA: 0x0001D895 File Offset: 0x0001BA95
		public static Vec3 operator /(Vec3 v, float s)
		{
			return new Vec3(v.X / s, v.Y / s, v.Z / s);
		}

		// Token: 0x060008DC RID: 2268 RVA: 0x0001D8B7 File Offset: 0x0001BAB7
		public static bool operator ==(Vec3 v1, Vec3 v2)
		{
			return v1.X == v2.X && v1.Y == v2.Y && v1.Z == v2.Z;
		}

		// Token: 0x060008DD RID: 2269 RVA: 0x0001D8EB File Offset: 0x0001BAEB
		public static bool operator !=(Vec3 v1, Vec3 v2)
		{
			return !(v1 == v2);
		}

		// Token: 0x060008DE RID: 2270 RVA: 0x0001D8F7 File Offset: 0x0001BAF7
		public override bool Equals(object obj)
		{
			return obj is Vec3 && this == (Vec3)obj;
		}

		// Token: 0x060008DF RID: 2271 RVA: 0x0001D914 File Offset: 0x0001BB14
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		// Token: 0x060008E0 RID: 2272 RVA: 0x0001D926 File Offset: 0x0001BB26
		public static float Dot(Vec3 v1, Vec3 v2)
		{
			return v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
		}

		// Token: 0x060008E1 RID: 2273 RVA: 0x0001D958 File Offset: 0x0001BB58
		public static Vec3 Cross(Vec3 v1, Vec3 v2)
		{
			return new Vec3(v1.Y * v2.Z - v1.Z * v2.Y, v1.Z * v2.X - v1.X * v2.Z, v1.X * v2.Y - v1.Y * v2.X);
		}

		// Token: 0x17000202 RID: 514
		// (get) Token: 0x060008E2 RID: 2274 RVA: 0x0001D9C7 File Offset: 0x0001BBC7
		public float LengthSquare
		{
			get
			{
				return this.X * this.X + this.Y * this.Y + this.Z * this.Z;
			}
		}

		// Token: 0x17000203 RID: 515
		// (get) Token: 0x060008E3 RID: 2275 RVA: 0x0001D9F2 File Offset: 0x0001BBF2
		public float Length
		{
			get
			{
				return (float)Math.Sqrt((double)this.LengthSquare);
			}
		}

		// Token: 0x17000204 RID: 516
		// (get) Token: 0x060008E4 RID: 2276 RVA: 0x0001DA01 File Offset: 0x0001BC01
		public bool IsZero
		{
			get
			{
				return Math.Abs(this.X) < 0.001f && Math.Abs(this.Y) < 0.001f && Math.Abs(this.Z) < 0.001f;
			}
		}

		// Token: 0x060008E5 RID: 2277 RVA: 0x0001DA3C File Offset: 0x0001BC3C
		public float Normalize()
		{
			float length = this.Length;
			this /= length;
			return length;
		}

		// Token: 0x060008E6 RID: 2278 RVA: 0x0001DA64 File Offset: 0x0001BC64
		public void Snap(float resolution)
		{
			this.X -= (float)Math.IEEERemainder((double)this.X, (double)resolution);
			this.Y -= (float)Math.IEEERemainder((double)this.Y, (double)resolution);
			this.Z -= (float)Math.IEEERemainder((double)this.Z, (double)resolution);
		}

		// Token: 0x060008E7 RID: 2279 RVA: 0x0001DAC8 File Offset: 0x0001BCC8
		public void Snap(Vec3 resolutionVector)
		{
			this.X -= (float)Math.IEEERemainder((double)this.X, (double)resolutionVector.X);
			this.Y -= (float)Math.IEEERemainder((double)this.Y, (double)resolutionVector.Y);
			this.Z -= (float)Math.IEEERemainder((double)this.Z, (double)resolutionVector.Z);
		}

		// Token: 0x060008E8 RID: 2280 RVA: 0x0001DB3C File Offset: 0x0001BD3C
		public Vec3 ToAngles()
		{
			Vec3 result = default(Vec3);
			Binding.FCE_Core_GetAnglesFromDir(out result.X, out result.Y, out result.Z, this.X, this.Y, this.Z);
			return result;
		}

		// Token: 0x060008E9 RID: 2281 RVA: 0x0001DB83 File Offset: 0x0001BD83
		public Vec3 Rad2Deg()
		{
			return new Vec3(MathUtils.Rad2Deg(this.X), MathUtils.Rad2Deg(this.Y), MathUtils.Rad2Deg(this.Z));
		}

		// Token: 0x060008EA RID: 2282 RVA: 0x0001DBAB File Offset: 0x0001BDAB
		public Vec3 Deg2Rad()
		{
			return new Vec3(MathUtils.Deg2Rad(this.X), MathUtils.Deg2Rad(this.Y), MathUtils.Deg2Rad(this.Z));
		}

		// Token: 0x060008EB RID: 2283 RVA: 0x0001DBD4 File Offset: 0x0001BDD4
		public string ToString(string format)
		{
			return string.Concat(new string[]
			{
				"(",
				this.X.ToString(format),
				", ",
				this.Y.ToString(format),
				", ",
				this.Z.ToString(format),
				")"
			});
		}

		// Token: 0x060008EC RID: 2284 RVA: 0x0001DC3B File Offset: 0x0001BE3B
		public override string ToString()
		{
			return this.ToString("F4");
		}

		// Token: 0x04000451 RID: 1105
		public float X;

		// Token: 0x04000452 RID: 1106
		public float Y;

		// Token: 0x04000453 RID: 1107
		public float Z;
	}
}
