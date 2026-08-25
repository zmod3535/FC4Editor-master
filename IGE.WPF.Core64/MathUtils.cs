using System;

namespace IGE
{
	// Token: 0x02000063 RID: 99
	internal static class MathUtils
	{
		// Token: 0x06000453 RID: 1107 RVA: 0x00011125 File Offset: 0x0000F325
		public static float Clamp(float value, float min, float max)
		{
			if (value < min)
			{
				value = min;
			}
			else if (value > max)
			{
				value = max;
			}
			return value;
		}

		// Token: 0x06000454 RID: 1108 RVA: 0x00011138 File Offset: 0x0000F338
		public static float Deg2Rad(float angleDeg)
		{
			return angleDeg * 2f * 3.1415927f / 360f;
		}

		// Token: 0x06000455 RID: 1109 RVA: 0x0001114D File Offset: 0x0000F34D
		public static float Rad2Deg(float angleRad)
		{
			return angleRad * 360f / 6.2831855f;
		}
	}
}
