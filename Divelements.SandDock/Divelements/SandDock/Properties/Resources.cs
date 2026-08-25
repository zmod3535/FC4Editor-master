using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Divelements.SandDock.Properties
{
	// Token: 0x02000078 RID: 120
	[CompilerGenerated]
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	[DebuggerNonUserCode]
	internal class Resources
	{
		// Token: 0x060004E1 RID: 1249 RVA: 0x00048A94 File Offset: 0x00046E94
		internal Resources()
		{
		}

		// Token: 0x17000111 RID: 273
		// (get) Token: 0x060004E2 RID: 1250 RVA: 0x00048A9C File Offset: 0x00046E9C
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (object.ReferenceEquals(Resources.resourceMan, null))
				{
					ResourceManager resourceManager = new ResourceManager("Divelements.SandDock.Properties.Resources", typeof(Resources).Assembly);
					Resources.resourceMan = resourceManager;
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x17000112 RID: 274
		// (get) Token: 0x060004E3 RID: 1251 RVA: 0x00048ADC File Offset: 0x00046EDC
		// (set) Token: 0x060004E4 RID: 1252 RVA: 0x00048AE4 File Offset: 0x00046EE4
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

		// Token: 0x04000299 RID: 665
		private static ResourceManager resourceMan;

		// Token: 0x0400029A RID: 666
		private static CultureInfo resourceCulture;
	}
}
