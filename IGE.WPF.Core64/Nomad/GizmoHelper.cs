using System;

namespace IGE.Nomad
{
	// Token: 0x02000036 RID: 54
	internal class GizmoHelper
	{
		// Token: 0x060002AF RID: 687 RVA: 0x00008274 File Offset: 0x00006474
		public void InitVirtualPlane(Vec3 planePos, CoordinateSystem planeBase, Axis axisConstraint)
		{
			this.m_virtualPlanePos = planePos;
			this.m_virtualPlaneBase = planeBase;
			this.m_axisConstraint = axisConstraint;
			CoordinateSystem virtualPlaneCoords = default(CoordinateSystem);
			switch (this.m_axisConstraint)
			{
			case Axis.X:
				virtualPlaneCoords.axisX = planeBase.axisX;
				virtualPlaneCoords.axisY = Vec3.Cross(Camera.FrontVector, planeBase.axisX);
				virtualPlaneCoords.axisY.Normalize();
				virtualPlaneCoords.axisZ = Vec3.Cross(planeBase.axisX, virtualPlaneCoords.axisY);
				virtualPlaneCoords.axisZ.Normalize();
				break;
			case Axis.Y:
				virtualPlaneCoords.axisX = planeBase.axisY;
				virtualPlaneCoords.axisY = Vec3.Cross(Camera.FrontVector, planeBase.axisY);
				virtualPlaneCoords.axisY.Normalize();
				virtualPlaneCoords.axisZ = Vec3.Cross(planeBase.axisY, virtualPlaneCoords.axisY);
				virtualPlaneCoords.axisZ.Normalize();
				break;
			case Axis.XY:
				virtualPlaneCoords.axisX = planeBase.axisX;
				virtualPlaneCoords.axisY = planeBase.axisY;
				virtualPlaneCoords.axisZ = planeBase.axisZ;
				break;
			case Axis.Z:
				virtualPlaneCoords.axisX = planeBase.axisZ;
				virtualPlaneCoords.axisY = Vec3.Cross(Camera.FrontVector, planeBase.axisZ);
				virtualPlaneCoords.axisY.Normalize();
				virtualPlaneCoords.axisZ = Vec3.Cross(planeBase.axisZ, virtualPlaneCoords.axisY);
				virtualPlaneCoords.axisZ.Normalize();
				break;
			case Axis.XZ:
				virtualPlaneCoords.axisX = planeBase.axisX;
				virtualPlaneCoords.axisY = planeBase.axisZ;
				virtualPlaneCoords.axisZ = planeBase.axisY;
				break;
			case Axis.YZ:
				virtualPlaneCoords.axisX = planeBase.axisY;
				virtualPlaneCoords.axisY = planeBase.axisZ;
				virtualPlaneCoords.axisZ = planeBase.axisX;
				break;
			}
			this.m_virtualPlane = Plane.FromPointNormal(this.m_virtualPlanePos, virtualPlaneCoords.axisZ);
			this.m_virtualPlaneCoords = virtualPlaneCoords;
		}

		// Token: 0x060002B0 RID: 688 RVA: 0x00008488 File Offset: 0x00006688
		public bool GetVirtualPos(out Vec3 pos)
		{
			Vec3 raySrc;
			Vec3 rayDir;
			Editor.GetWorldRayFromScreenPoint(Editor.Viewport.NormalizedMousePos, out raySrc, out rayDir);
			if (!this.m_virtualPlane.RayIntersect(raySrc, rayDir, out pos))
			{
				return false;
			}
			switch (this.m_axisConstraint)
			{
			case Axis.X:
				pos = Vec3.Dot(pos, this.m_virtualPlaneBase.axisX) * this.m_virtualPlaneBase.axisX;
				break;
			case Axis.Y:
				pos = Vec3.Dot(pos, this.m_virtualPlaneBase.axisY) * this.m_virtualPlaneBase.axisY;
				break;
			case Axis.Z:
				pos = Vec3.Dot(pos, this.m_virtualPlaneBase.axisZ) * this.m_virtualPlaneBase.axisZ;
				break;
			}
			return true;
		}

		// Token: 0x0400010C RID: 268
		private Axis m_axisConstraint;

		// Token: 0x0400010D RID: 269
		private Plane m_virtualPlane;

		// Token: 0x0400010E RID: 270
		private Vec3 m_virtualPlanePos;

		// Token: 0x0400010F RID: 271
		private CoordinateSystem m_virtualPlaneBase;

		// Token: 0x04000110 RID: 272
		private CoordinateSystem m_virtualPlaneCoords;
	}
}
