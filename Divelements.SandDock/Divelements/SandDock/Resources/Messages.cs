using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Divelements.SandDock.Resources
{
	// Token: 0x02000022 RID: 34
	[CompilerGenerated]
	[DebuggerNonUserCode]
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	internal class Messages
	{
		// Token: 0x06000252 RID: 594 RVA: 0x0003A000 File Offset: 0x00038400
		internal Messages()
		{
		}

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x06000253 RID: 595 RVA: 0x0003A008 File Offset: 0x00038408
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (object.ReferenceEquals(Messages.resourceMan, null))
				{
					ResourceManager resourceManager = new ResourceManager("Divelements.SandDock.Resources.Messages", typeof(Messages).Assembly);
					Messages.resourceMan = resourceManager;
				}
				return Messages.resourceMan;
			}
		}

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x06000254 RID: 596 RVA: 0x0003A048 File Offset: 0x00038448
		// (set) Token: 0x06000255 RID: 597 RVA: 0x0003A050 File Offset: 0x00038450
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Messages.resourceCulture;
			}
			set
			{
				Messages.resourceCulture = value;
			}
		}

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x06000256 RID: 598 RVA: 0x0003A058 File Offset: 0x00038458
		internal static string ExceptionCannotRemoveDockableWindow
		{
			get
			{
				return Messages.ResourceManager.GetString("ExceptionCannotRemoveDockableWindow", Messages.resourceCulture);
			}
		}

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x06000257 RID: 599 RVA: 0x0003A070 File Offset: 0x00038470
		internal static string ExceptionCannotRemoveWindowGroup
		{
			get
			{
				return Messages.ResourceManager.GetString("ExceptionCannotRemoveWindowGroup", Messages.resourceCulture);
			}
		}

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x06000258 RID: 600 RVA: 0x0003A088 File Offset: 0x00038488
		internal static string ExceptionCannotUpdateMetaData
		{
			get
			{
				return Messages.ResourceManager.GetString("ExceptionCannotUpdateMetaData", Messages.resourceCulture);
			}
		}

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x06000259 RID: 601 RVA: 0x0003A0A0 File Offset: 0x000384A0
		internal static string ExceptionDockSiteRequired
		{
			get
			{
				return Messages.ResourceManager.GetString("ExceptionDockSiteRequired", Messages.resourceCulture);
			}
		}

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x0600025A RID: 602 RVA: 0x0003A0B8 File Offset: 0x000384B8
		internal static string ExceptionDocumentContainerRequired
		{
			get
			{
				return Messages.ResourceManager.GetString("ExceptionDocumentContainerRequired", Messages.resourceCulture);
			}
		}

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x0600025B RID: 603 RVA: 0x0003A0D0 File Offset: 0x000384D0
		internal static string ExceptionDocumentContainerUnrecognisedContent
		{
			get
			{
				return Messages.ResourceManager.GetString("ExceptionDocumentContainerUnrecognisedContent", Messages.resourceCulture);
			}
		}

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x0600025C RID: 604 RVA: 0x0003A0E8 File Offset: 0x000384E8
		internal static string ExceptionEmptyGuid
		{
			get
			{
				return Messages.ResourceManager.GetString("ExceptionEmptyGuid", Messages.resourceCulture);
			}
		}

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x0600025D RID: 605 RVA: 0x0003A100 File Offset: 0x00038500
		internal static string ExceptionInvalidCustomWindowSwitcher
		{
			get
			{
				return Messages.ResourceManager.GetString("ExceptionInvalidCustomWindowSwitcher", Messages.resourceCulture);
			}
		}

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x0600025E RID: 606 RVA: 0x0003A118 File Offset: 0x00038518
		internal static string ExceptionInvalidSplitContainerChild
		{
			get
			{
				return Messages.ResourceManager.GetString("ExceptionInvalidSplitContainerChild", Messages.resourceCulture);
			}
		}

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x0600025F RID: 607 RVA: 0x0003A130 File Offset: 0x00038530
		internal static string ExceptionLayoutLocked
		{
			get
			{
				return Messages.ResourceManager.GetString("ExceptionLayoutLocked", Messages.resourceCulture);
			}
		}

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x06000260 RID: 608 RVA: 0x0003A148 File Offset: 0x00038548
		internal static string ExceptionWindowHasNoContent
		{
			get
			{
				return Messages.ResourceManager.GetString("ExceptionWindowHasNoContent", Messages.resourceCulture);
			}
		}

		// Token: 0x040000C2 RID: 194
		private static ResourceManager resourceMan;

		// Token: 0x040000C3 RID: 195
		private static CultureInfo resourceCulture;
	}
}
