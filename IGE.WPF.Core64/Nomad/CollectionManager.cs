using System;

namespace IGE.Nomad
{
	// Token: 0x02000016 RID: 22
	internal static class CollectionManager
	{
		// Token: 0x060000AC RID: 172 RVA: 0x00002E31 File Offset: 0x00001031
		public static CollectionInventory.Entry GetCollectionEntryFromId(int id)
		{
			return new CollectionInventory.Entry(Binding.FCE_CollectionManager_GetCollectionEntryFromId(id));
		}

		// Token: 0x060000AD RID: 173 RVA: 0x00002E43 File Offset: 0x00001043
		public static void AssignCollectionId(int id, CollectionInventory.Entry entry)
		{
			Binding.FCE_CollectionManager_AssignCollectionId(id, entry.Pointer);
		}

		// Token: 0x060000AE RID: 174 RVA: 0x00002E56 File Offset: 0x00001056
		public static void WriteMaskCircle(float x, float y, float radius, int id, bool update)
		{
			Binding.FCE_CollectionManager_WriteMaskCircle(x, y, radius, id, update);
		}

		// Token: 0x060000AF RID: 175 RVA: 0x00002E68 File Offset: 0x00001068
		public static void WriteMaskSquare(float x, float y, float radius, int id, bool update)
		{
			Binding.FCE_CollectionManager_WriteMaskSquare(x, y, radius, id, update);
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x00002E7A File Offset: 0x0000107A
		public static void ClearMaskId(int id)
		{
			Binding.FCE_CollectionManager_ClearMaskId(id);
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x00002E87 File Offset: 0x00001087
		public static void UpdateCollections(Win32.Rect rect)
		{
			Binding.FCE_CollectionManager_UpdateCollections(rect.left, rect.top, rect.Width, rect.Height);
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x00002EAF File Offset: 0x000010AF
		public static void ActivatePhysics(bool activate)
		{
			Binding.FCE_CollectionManager_ActivatePhysics(activate);
		}

		// Token: 0x0400002B RID: 43
		public static int EmptyCollectionId = 8;
	}
}
