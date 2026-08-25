using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace IGE.Properties
{
	// Token: 0x020000C7 RID: 199
	[DebuggerNonUserCode]
	[CompilerGenerated]
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	internal class Resources
	{
		// Token: 0x06000772 RID: 1906 RVA: 0x0001ADC2 File Offset: 0x00018FC2
		internal Resources()
		{
		}

		// Token: 0x170001BC RID: 444
		// (get) Token: 0x06000773 RID: 1907 RVA: 0x0001ADCC File Offset: 0x00018FCC
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (object.ReferenceEquals(Resources.resourceMan, null))
				{
					ResourceManager resourceManager = new ResourceManager("IGE.Properties.Resources", typeof(Resources).Assembly);
					Resources.resourceMan = resourceManager;
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x170001BD RID: 445
		// (get) Token: 0x06000774 RID: 1908 RVA: 0x0001AE0B File Offset: 0x0001900B
		// (set) Token: 0x06000775 RID: 1909 RVA: 0x0001AE12 File Offset: 0x00019012
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Resources.resourceCulture;
			}
			set
			{
				Resources.resourceCulture = value;
			}
		}

		// Token: 0x170001BE RID: 446
		// (get) Token: 0x06000776 RID: 1910 RVA: 0x0001AE1C File Offset: 0x0001901C
		internal static Bitmap splash
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("splash", Resources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		// Token: 0x170001BF RID: 447
		// (get) Token: 0x06000777 RID: 1911 RVA: 0x0001AE44 File Offset: 0x00019044
		internal static byte[] invisible_cursor
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("invisible_cursor", Resources.resourceCulture);
				return (byte[])@object;
			}
		}

		// Token: 0x04000303 RID: 771
		private static ResourceManager resourceMan;

		// Token: 0x04000304 RID: 772
		private static CultureInfo resourceCulture;
	}
}
