using System;
using System.Runtime.InteropServices;
using System.Windows;

namespace MS.Internal
{
	// Token: 0x02000066 RID: 102
	internal static class DoubleUtil
	{
		// Token: 0x060007A7 RID: 1959 RVA: 0x000225F8 File Offset: 0x000207F8
		public static bool AreClose(double value1, double value2)
		{
			if (value1 == value2)
			{
				return true;
			}
			double num = (Math.Abs(value1) + Math.Abs(value2) + 10.0) * 2.220446049250313E-16;
			double num2 = value1 - value2;
			return -num < num2 && num > num2;
		}

		// Token: 0x060007A8 RID: 1960 RVA: 0x0002263C File Offset: 0x0002083C
		public static bool LessThan(double value1, double value2)
		{
			return value1 < value2 && !DoubleUtil.AreClose(value1, value2);
		}

		// Token: 0x060007A9 RID: 1961 RVA: 0x0002264E File Offset: 0x0002084E
		public static bool GreaterThan(double value1, double value2)
		{
			return value1 > value2 && !DoubleUtil.AreClose(value1, value2);
		}

		// Token: 0x060007AA RID: 1962 RVA: 0x00022660 File Offset: 0x00020860
		public static bool LessThanOrClose(double value1, double value2)
		{
			return value1 < value2 || DoubleUtil.AreClose(value1, value2);
		}

		// Token: 0x060007AB RID: 1963 RVA: 0x0002266F File Offset: 0x0002086F
		public static bool GreaterThanOrClose(double value1, double value2)
		{
			return value1 > value2 || DoubleUtil.AreClose(value1, value2);
		}

		// Token: 0x060007AC RID: 1964 RVA: 0x0002267E File Offset: 0x0002087E
		public static bool IsOne(double value)
		{
			return Math.Abs(value - 1.0) < 2.220446049250313E-15;
		}

		// Token: 0x060007AD RID: 1965 RVA: 0x0002269B File Offset: 0x0002089B
		public static bool AreClose(Point point1, Point point2)
		{
			return DoubleUtil.AreClose(point1.X, point2.X) && DoubleUtil.AreClose(point1.Y, point2.Y);
		}

		// Token: 0x060007AE RID: 1966 RVA: 0x000226C8 File Offset: 0x000208C8
		public static bool AreClose(Rect rect1, Rect rect2)
		{
			if (rect1.IsEmpty)
			{
				return rect2.IsEmpty;
			}
			return !rect2.IsEmpty && DoubleUtil.AreClose(rect1.X, rect2.X) && DoubleUtil.AreClose(rect1.Y, rect2.Y) && DoubleUtil.AreClose(rect1.Height, rect2.Height) && DoubleUtil.AreClose(rect1.Width, rect2.Width);
		}

		// Token: 0x060007AF RID: 1967 RVA: 0x00022744 File Offset: 0x00020944
		public static bool IsNaN(double value)
		{
			DoubleUtil.NanUnion nanUnion = default(DoubleUtil.NanUnion);
			nanUnion.DoubleValue = value;
			ulong num = nanUnion.UintValue & 18442240474082181120UL;
			ulong num2 = nanUnion.UintValue & 4503599627370495UL;
			return (num == 9218868437227405312UL || num == 18442240474082181120UL) && num2 != 0UL;
		}

		// Token: 0x0400026A RID: 618
		internal const double DBL_EPSILON = 2.220446049250313E-16;

		// Token: 0x0400026B RID: 619
		internal const float FLT_MIN = 1.1754944E-38f;

		// Token: 0x02000067 RID: 103
		[StructLayout(LayoutKind.Explicit)]
		private struct NanUnion
		{
			// Token: 0x0400026C RID: 620
			[FieldOffset(0)]
			internal double DoubleValue;

			// Token: 0x0400026D RID: 621
			[FieldOffset(0)]
			internal ulong UintValue;
		}
	}
}
