using System;

namespace System.Windows
{
	// Token: 0x0200007B RID: 123
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
	public sealed class TemplateVisualStateAttribute : Attribute
	{
		// Token: 0x17000212 RID: 530
		// (get) Token: 0x060008C0 RID: 2240 RVA: 0x00027934 File Offset: 0x00025B34
		// (set) Token: 0x060008C1 RID: 2241 RVA: 0x0002793C File Offset: 0x00025B3C
		public string Name { get; set; }

		// Token: 0x17000213 RID: 531
		// (get) Token: 0x060008C2 RID: 2242 RVA: 0x00027945 File Offset: 0x00025B45
		// (set) Token: 0x060008C3 RID: 2243 RVA: 0x0002794D File Offset: 0x00025B4D
		public string GroupName { get; set; }
	}
}
