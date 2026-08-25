using System;

namespace IGE.Nomad
{
	// Token: 0x020000B9 RID: 185
	internal class ObjectLegoBox
	{
		// Token: 0x170001A3 RID: 419
		// (get) Token: 0x06000713 RID: 1811 RVA: 0x00019760 File Offset: 0x00017960
		// (set) Token: 0x06000714 RID: 1812 RVA: 0x00019767 File Offset: 0x00017967
		public static bool Active
		{
			get
			{
				return ObjectLegoBox.m_active;
			}
			set
			{
				ObjectLegoBox.m_active = value;
				Binding.FCE_ObjectLegoBox_SetActive(ObjectLegoBox.m_active);
			}
		}

		// Token: 0x06000715 RID: 1813 RVA: 0x0001977E File Offset: 0x0001797E
		public static void AddEntry(ObjectInventory.Entry entry)
		{
			Binding.FCE_ObjectLegoBox_AddEntry(entry.Pointer);
		}

		// Token: 0x06000716 RID: 1814 RVA: 0x00019790 File Offset: 0x00017990
		public static void ClearEntries()
		{
			Binding.FCE_ObjectLegoBox_ClearEntries();
		}

		// Token: 0x06000717 RID: 1815 RVA: 0x0001979C File Offset: 0x0001799C
		public static void CreateLegoBox()
		{
			Binding.FCE_ObjectLegoBox_CreateLegoBox();
		}

		// Token: 0x06000718 RID: 1816 RVA: 0x000197A8 File Offset: 0x000179A8
		public static ObjectInventory.Entry GetEntryFromScreenPoint(Vec2 screenPoint)
		{
			return new ObjectInventory.Entry(Binding.FCE_ObjectLegoBox_GetEntryFromScreenPoint(screenPoint.X, screenPoint.Y));
		}

		// Token: 0x040002DA RID: 730
		private static bool m_active;
	}
}
