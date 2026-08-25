using System;

namespace IGE.Nomad
{
	// Token: 0x0200010A RID: 266
	internal class ObjectViewer
	{
		// Token: 0x17000215 RID: 533
		// (get) Token: 0x0600093D RID: 2365 RVA: 0x0001EEB0 File Offset: 0x0001D0B0
		// (set) Token: 0x0600093E RID: 2366 RVA: 0x0001EEB7 File Offset: 0x0001D0B7
		public static bool Active
		{
			get
			{
				return ObjectViewer.m_active;
			}
			set
			{
				ObjectViewer.m_active = value;
				Binding.FCE_ObjectViewer_SetActive(ObjectViewer.m_active);
			}
		}

		// Token: 0x17000216 RID: 534
		// (get) Token: 0x0600093F RID: 2367 RVA: 0x0001EECE File Offset: 0x0001D0CE
		// (set) Token: 0x06000940 RID: 2368 RVA: 0x0001EED5 File Offset: 0x0001D0D5
		public static EditorObject Object
		{
			get
			{
				return ObjectViewer.m_object;
			}
			set
			{
				ObjectViewer.m_object = value;
				Binding.FCE_ObjectViewer_SetObject(ObjectViewer.m_object.Pointer);
			}
		}

		// Token: 0x04000477 RID: 1143
		private static bool m_active;

		// Token: 0x04000478 RID: 1144
		private static EditorObject m_object;
	}
}
