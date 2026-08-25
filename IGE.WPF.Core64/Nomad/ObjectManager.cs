using System;
using System.Collections.Generic;
using System.Windows;

namespace IGE.Nomad
{
	// Token: 0x02000385 RID: 901
	internal static class ObjectManager
	{
		// Token: 0x0600144F RID: 5199 RVA: 0x0002B0B1 File Offset: 0x000292B1
		public static EditorObject GetObjectFromScreenPoint(Vec2 pt, out Vec3 hitPos)
		{
			return ObjectManager.GetObjectFromScreenPoint(pt, out hitPos, false, EditorObject.Null);
		}

		// Token: 0x06001450 RID: 5200 RVA: 0x0002B0C0 File Offset: 0x000292C0
		public static EditorObject GetObjectFromScreenPoint(Vec2 pt, out Vec3 hitPos, bool includeFrozen)
		{
			return ObjectManager.GetObjectFromScreenPoint(pt, out hitPos, includeFrozen, EditorObject.Null);
		}

		// Token: 0x06001451 RID: 5201 RVA: 0x0002B0D0 File Offset: 0x000292D0
		public static EditorObject GetObjectFromScreenPoint(Vec2 pt, out Vec3 hitPos, bool includeFrozen, EditorObject ignore)
		{
			PhysEntityVector vector = PhysEntityVector.Null;
			if (ignore.IsValid)
			{
				vector = PhysEntityVector.Create();
				ignore.GetPhysEntities(vector);
			}
			EditorObject result = new EditorObject(Binding.FCE_ObjectManager_GetObjectFromScreenPoint(pt.X, pt.Y, out hitPos.X, out hitPos.Y, out hitPos.Z, includeFrozen, vector.Pointer));
			if (vector.IsValid)
			{
				vector.Dispose();
			}
			return result;
		}

		// Token: 0x06001452 RID: 5202 RVA: 0x0002B144 File Offset: 0x00029344
		public static EditorObject GetObjectFromScreenPoint(Vec2 pt, out Vec3 hitPos, bool includeFrozen, EditorObjectSelection ignore)
		{
			EditorObject result;
			using (PhysEntityVector vector = PhysEntityVector.Create())
			{
				ignore.GetPhysEntities(vector);
				result = new EditorObject(Binding.FCE_ObjectManager_GetObjectFromScreenPoint(pt.X, pt.Y, out hitPos.X, out hitPos.Y, out hitPos.Z, includeFrozen, vector.Pointer));
			}
			return result;
		}

		// Token: 0x06001453 RID: 5203 RVA: 0x0002B1B8 File Offset: 0x000293B8
		public static void GetObjectsFromScreenRect(EditorObjectSelection selection, Rect rect)
		{
			ObjectManager.GetObjectsFromScreenRect(selection, rect, false);
		}

		// Token: 0x06001454 RID: 5204 RVA: 0x0002B1C2 File Offset: 0x000293C2
		public static void GetObjectsFromScreenRect(EditorObjectSelection selection, Rect rect, bool includeFrozen)
		{
			Binding.FCE_ObjectManager_GetObjectsFromScreenRect(selection.Pointer, (float)rect.Left, (float)rect.Top, (float)rect.Right, (float)rect.Bottom, includeFrozen);
		}

		// Token: 0x06001455 RID: 5205 RVA: 0x0002B1F6 File Offset: 0x000293F6
		public static void GetObjectsFromMagicWand(EditorObjectSelection selection, EditorObject obj)
		{
			Binding.FCE_ObjectManager_GetObjectsFromMagicWand(selection.Pointer, obj.Pointer);
		}

		// Token: 0x06001456 RID: 5206 RVA: 0x0002B20F File Offset: 0x0002940F
		public static void SetViewportPickingPos(Vec2 pt)
		{
			Binding.FCE_ObjectManager_SetViewportPickingPos(pt.X, pt.Y);
		}

		// Token: 0x06001457 RID: 5207 RVA: 0x0002B229 File Offset: 0x00029429
		public static void UnfreezeObjects()
		{
			Binding.FCE_ObjectManager_UnfreezeObjects();
		}

		// Token: 0x17000276 RID: 630
		// (get) Token: 0x06001458 RID: 5208 RVA: 0x0002B235 File Offset: 0x00029435
		public static int ObjectCount
		{
			get
			{
				return Binding.FCE_ObjectManager_GetObjectCount();
			}
		}

		// Token: 0x06001459 RID: 5209 RVA: 0x0002B241 File Offset: 0x00029441
		public static EditorObject GetObject(int index)
		{
			return new EditorObject(Binding.FCE_ObjectManager_GetObject(index));
		}

		// Token: 0x0600145A RID: 5210 RVA: 0x0002B350 File Offset: 0x00029550
		public static IEnumerable<EditorObject> GetObjects()
		{
			int numObjects = ObjectManager.ObjectCount;
			for (int i = 0; i < numObjects; i++)
			{
				yield return ObjectManager.GetObject(i);
			}
			yield break;
		}
	}
}
