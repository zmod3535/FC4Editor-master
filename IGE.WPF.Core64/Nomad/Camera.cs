using System;

namespace IGE.Nomad
{
	// Token: 0x020000A8 RID: 168
	internal class Camera
	{
		// Token: 0x1700018B RID: 395
		// (set) Token: 0x060006CC RID: 1740 RVA: 0x00019004 File Offset: 0x00017204
		public static float ForwardInput
		{
			set
			{
				Binding.FCE_Camera_Input_Forward(value);
			}
		}

		// Token: 0x1700018C RID: 396
		// (set) Token: 0x060006CD RID: 1741 RVA: 0x00019011 File Offset: 0x00017211
		public static float LateralInput
		{
			set
			{
				Binding.FCE_Camera_Input_Lateral(value);
			}
		}

		// Token: 0x1700018D RID: 397
		// (get) Token: 0x060006CE RID: 1742 RVA: 0x00019020 File Offset: 0x00017220
		// (set) Token: 0x060006CF RID: 1743 RVA: 0x00019055 File Offset: 0x00017255
		public static Vec3 Position
		{
			get
			{
				Vec3 result = default(Vec3);
				Binding.FCE_Camera_GetPos(out result.X, out result.Y, out result.Z);
				return result;
			}
			set
			{
				Binding.FCE_Camera_SetPos(value.X, value.Y, value.Z);
			}
		}

		// Token: 0x1700018E RID: 398
		// (get) Token: 0x060006D0 RID: 1744 RVA: 0x00019078 File Offset: 0x00017278
		// (set) Token: 0x060006D1 RID: 1745 RVA: 0x000190AD File Offset: 0x000172AD
		public static Vec3 Angles
		{
			get
			{
				Vec3 result = default(Vec3);
				Binding.FCE_Camera_GetAngles(out result.X, out result.Y, out result.Z);
				return result;
			}
			set
			{
				Binding.FCE_Camera_SetAngles(value.X, value.Y, value.Z);
			}
		}

		// Token: 0x060006D2 RID: 1746 RVA: 0x000190CE File Offset: 0x000172CE
		public static void Rotate(float pitch, float roll, float yaw)
		{
			Binding.FCE_Camera_Rotate(pitch, roll, yaw);
		}

		// Token: 0x1700018F RID: 399
		// (get) Token: 0x060006D3 RID: 1747 RVA: 0x000190E0 File Offset: 0x000172E0
		public static Vec3 FrontVector
		{
			get
			{
				Vec3 result = default(Vec3);
				Binding.FCE_Camera_GetFrontVector(out result.X, out result.Y, out result.Z);
				return result;
			}
		}

		// Token: 0x17000190 RID: 400
		// (get) Token: 0x060006D4 RID: 1748 RVA: 0x00019118 File Offset: 0x00017318
		public static Vec3 RightVector
		{
			get
			{
				Vec3 result = default(Vec3);
				Binding.FCE_Camera_GetRightVector(out result.X, out result.Y, out result.Z);
				return result;
			}
		}

		// Token: 0x17000191 RID: 401
		// (get) Token: 0x060006D5 RID: 1749 RVA: 0x00019150 File Offset: 0x00017350
		public static Vec3 UpVector
		{
			get
			{
				Vec3 result = default(Vec3);
				Binding.FCE_Camera_GetUpVector(out result.X, out result.Y, out result.Z);
				return result;
			}
		}

		// Token: 0x17000192 RID: 402
		// (get) Token: 0x060006D6 RID: 1750 RVA: 0x00019185 File Offset: 0x00017385
		public static CoordinateSystem Axis
		{
			get
			{
				return new CoordinateSystem(Camera.RightVector, Camera.FrontVector, Camera.UpVector);
			}
		}

		// Token: 0x17000193 RID: 403
		// (get) Token: 0x060006D7 RID: 1751 RVA: 0x0001919B File Offset: 0x0001739B
		// (set) Token: 0x060006D8 RID: 1752 RVA: 0x000191A7 File Offset: 0x000173A7
		public static float Speed
		{
			get
			{
				return Binding.FCE_Camera_GetSpeed();
			}
			set
			{
				Binding.FCE_Camera_SetSpeed(value);
			}
		}

		// Token: 0x17000194 RID: 404
		// (set) Token: 0x060006D9 RID: 1753 RVA: 0x000191B4 File Offset: 0x000173B4
		public static float SpeedFactor
		{
			set
			{
				Binding.FCE_Camera_SetSpeedFactor(value);
			}
		}

		// Token: 0x17000195 RID: 405
		// (get) Token: 0x060006DA RID: 1754 RVA: 0x000191C1 File Offset: 0x000173C1
		public static float FOV
		{
			get
			{
				return Binding.FCE_Camera_GetFOV();
			}
		}

		// Token: 0x17000196 RID: 406
		// (get) Token: 0x060006DB RID: 1755 RVA: 0x000191CD File Offset: 0x000173CD
		public static float HalfFOV
		{
			get
			{
				return Camera.FOV * 0.5f;
			}
		}

		// Token: 0x060006DC RID: 1756 RVA: 0x000191DA File Offset: 0x000173DA
		public static void Focus(EditorObject obj)
		{
			if (!obj.IsValid)
			{
				return;
			}
			Binding.FCE_Camera_AlignToObject(obj.Pointer);
		}
	}
}
