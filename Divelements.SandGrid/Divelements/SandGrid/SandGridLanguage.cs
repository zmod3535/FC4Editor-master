using System;
using Divelements.SandGrid.Resources;

namespace Divelements.SandGrid
{
	// Token: 0x02000090 RID: 144
	public sealed class SandGridLanguage
	{
		// Token: 0x06000691 RID: 1681 RVA: 0x000222A4 File Offset: 0x000212A4
		private SandGridLanguage()
		{
		}

		// Token: 0x1700019D RID: 413
		// (get) Token: 0x06000692 RID: 1682 RVA: 0x000222AC File Offset: 0x000212AC
		// (set) Token: 0x06000693 RID: 1683 RVA: 0x000222B4 File Offset: 0x000212B4
		public static string DataConversionError
		{
			get
			{
				return SandGridLanguage.x507aee2adfadfd51;
			}
			set
			{
				SandGridLanguage.x507aee2adfadfd51 = value;
			}
		}

		// Token: 0x1700019E RID: 414
		// (get) Token: 0x06000694 RID: 1684 RVA: 0x000222BC File Offset: 0x000212BC
		// (set) Token: 0x06000695 RID: 1685 RVA: 0x000222C4 File Offset: 0x000212C4
		public static string[] FriendlyDates
		{
			get
			{
				return SandGridLanguage.xb7934cd257a19f5c;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				if (value.Length != SandGridLanguage.xb7934cd257a19f5c.Length)
				{
					throw new ArgumentException(xf1a67b6a145d2603.x538d63a1354c16f2("ExceptionArrayWrongLength"), "value");
				}
				SandGridLanguage.xb7934cd257a19f5c = value;
			}
		}

		// Token: 0x0400029A RID: 666
		private static string[] xb7934cd257a19f5c = new string[]
		{
			"Future",
			"Today",
			"Yesterday",
			"Last Week",
			"Two Weeks Ago",
			"Previous",
			"Tomorrow"
		};

		// Token: 0x0400029B RID: 667
		private static string x507aee2adfadfd51 = "The data entered cannot be converted to the type expected.";
	}
}
