using System;

namespace IGE.Nomad
{
	// Token: 0x020000FB RID: 251
	internal struct Vec2
	{
		// Token: 0x060008B9 RID: 2233 RVA: 0x0001D44D File Offset: 0x0001B64D
		public Vec2(float x, float y)
		{
			this.X = x;
			this.Y = y;
		}

		// Token: 0x060008BA RID: 2234 RVA: 0x0001D45D File Offset: 0x0001B65D
		public Vec2(double x, double y)
		{
			this.X = (float)x;
			this.Y = (float)y;
		}

		// Token: 0x060008BB RID: 2235 RVA: 0x0001D46F File Offset: 0x0001B66F
		public static Vec2 operator +(Vec2 v1, Vec2 v2)
		{
			return new Vec2(v1.X + v2.X, v1.Y + v2.Y);
		}

		// Token: 0x060008BC RID: 2236 RVA: 0x0001D494 File Offset: 0x0001B694
		public static Vec2 operator -(Vec2 v)
		{
			return new Vec2(-v.X, -v.Y);
		}

		// Token: 0x060008BD RID: 2237 RVA: 0x0001D4AB File Offset: 0x0001B6AB
		public static Vec2 operator -(Vec2 v1, Vec2 v2)
		{
			return new Vec2(v1.X - v2.X, v1.Y - v2.Y);
		}

		// Token: 0x060008BE RID: 2238 RVA: 0x0001D4D0 File Offset: 0x0001B6D0
		public static Vec2 operator *(float s, Vec2 v)
		{
			return new Vec2(v.X * s, v.Y * s);
		}

		// Token: 0x060008BF RID: 2239 RVA: 0x0001D4E9 File Offset: 0x0001B6E9
		public static Vec2 operator *(Vec2 v, float s)
		{
			return new Vec2(v.X * s, v.Y * s);
		}

		// Token: 0x060008C0 RID: 2240 RVA: 0x0001D502 File Offset: 0x0001B702
		public static Vec2 operator *(Vec2 v1, Vec2 v2)
		{
			return new Vec2(v1.X * v2.X, v1.Y * v2.Y);
		}

		// Token: 0x060008C1 RID: 2241 RVA: 0x0001D527 File Offset: 0x0001B727
		public static Vec2 operator /(Vec2 v, float s)
		{
			return new Vec2(v.X / s, v.Y / s);
		}

		// Token: 0x060008C2 RID: 2242 RVA: 0x0001D540 File Offset: 0x0001B740
		public static Vec2 operator /(Vec2 v1, Vec2 v2)
		{
			return new Vec2(v1.X / v2.X, v1.Y / v2.Y);
		}

		// Token: 0x060008C3 RID: 2243 RVA: 0x0001D565 File Offset: 0x0001B765
		public static bool operator ==(Vec2 v1, Vec2 v2)
		{
			return v1.X == v2.X && v1.Y == v2.Y;
		}

		// Token: 0x060008C4 RID: 2244 RVA: 0x0001D589 File Offset: 0x0001B789
		public static bool operator !=(Vec2 v1, Vec2 v2)
		{
			return !(v1 == v2);
		}

		// Token: 0x060008C5 RID: 2245 RVA: 0x0001D595 File Offset: 0x0001B795
		public override bool Equals(object obj)
		{
			return obj is Vec2 && this == (Vec2)obj;
		}

		// Token: 0x060008C6 RID: 2246 RVA: 0x0001D5B2 File Offset: 0x0001B7B2
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		// Token: 0x060008C7 RID: 2247 RVA: 0x0001D5C4 File Offset: 0x0001B7C4
		public static float Dot(Vec2 v1, Vec2 v2)
		{
			return v1.X * v2.X + v1.Y * v2.Y;
		}

		// Token: 0x170001FE RID: 510
		// (get) Token: 0x060008C8 RID: 2248 RVA: 0x0001D5E5 File Offset: 0x0001B7E5
		public float Length
		{
			get
			{
				return (float)Math.Sqrt((double)(this.X * this.X + this.Y * this.Y));
			}
		}

		// Token: 0x060008C9 RID: 2249 RVA: 0x0001D60C File Offset: 0x0001B80C
		public float Normalize()
		{
			float length = this.Length;
			this /= length;
			return length;
		}

		// Token: 0x060008CA RID: 2250 RVA: 0x0001D634 File Offset: 0x0001B834
		public void Rotate90CCW()
		{
			float x = this.X;
			this.X = -this.Y;
			this.Y = x;
		}

		// Token: 0x060008CB RID: 2251 RVA: 0x0001D65C File Offset: 0x0001B85C
		public void Rotate90CW()
		{
			float x = this.X;
			this.X = this.Y;
			this.Y = -x;
		}

		// Token: 0x060008CC RID: 2252 RVA: 0x0001D684 File Offset: 0x0001B884
		public override string ToString()
		{
			return string.Concat(new string[]
			{
				"(",
				this.X.ToString("F4"),
				", ",
				this.Y.ToString("F4"),
				")"
			});
		}

		// Token: 0x0400044E RID: 1102
		public static Vec2 Zero = new Vec2(0f, 0f);

		// Token: 0x0400044F RID: 1103
		public float X;

		// Token: 0x04000450 RID: 1104
		public float Y;
	}
}
