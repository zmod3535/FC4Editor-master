using System;

namespace IGE.Nomad
{
	// Token: 0x0200007C RID: 124
	internal class EditorObjectPivot
	{
		// Token: 0x06000544 RID: 1348 RVA: 0x00014174 File Offset: 0x00012374
		public void Unapply(EditorObject obj)
		{
			CoordinateSystem coordinateSystem = CoordinateSystem.FromAngles(obj.Angles);
			AABB localBounds = obj.LocalBounds;
			Vec3 vec = (localBounds.max + localBounds.min) * 0.5f;
			Vec3 vec2 = localBounds.Length * 0.5f;
			this.position -= obj.Position + vec.X * coordinateSystem.axisX + vec.Y * coordinateSystem.axisY;
			this.position = coordinateSystem.ConvertFromWorld(this.position);
			this.normal = coordinateSystem.ConvertFromWorld(this.normal);
			this.normalUp = coordinateSystem.ConvertFromWorld(this.normalUp);
			this.position.X = this.position.X / vec2.X;
			this.position.Y = this.position.Y / vec2.Y;
			if (this.position.X > 1f)
			{
				this.position.X = 1f;
			}
			else if (this.position.X < -1f)
			{
				this.position.X = -1f;
			}
			if (this.position.Y > 1f)
			{
				this.position.Y = 1f;
			}
			else if (this.position.Y < -1f)
			{
				this.position.Y = -1f;
			}
			if (this.position.Z > 1f)
			{
				this.position.Z = 1f;
			}
			else if (this.position.Z < -1f)
			{
				this.position.Z = -1f;
			}
			this.normal.Z = 0f;
			this.normalUp = new Vec3(0f, 0f, 1f);
		}

		// Token: 0x04000236 RID: 566
		public Vec3 position;

		// Token: 0x04000237 RID: 567
		public Vec3 normal;

		// Token: 0x04000238 RID: 568
		public Vec3 normalUp;
	}
}
