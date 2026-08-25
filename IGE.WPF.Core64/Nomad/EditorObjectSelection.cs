using System;
using System.Collections.Generic;

namespace IGE.Nomad
{
	// Token: 0x0200010E RID: 270
	internal struct EditorObjectSelection : IDisposable
	{
		// Token: 0x0600094F RID: 2383 RVA: 0x0001EF77 File Offset: 0x0001D177
		public EditorObjectSelection(IntPtr ptr)
		{
			this.m_selPtr = ptr;
		}

		// Token: 0x06000950 RID: 2384 RVA: 0x0001EF80 File Offset: 0x0001D180
		public static EditorObjectSelection Create()
		{
			return new EditorObjectSelection(Binding.FCE_ObjectSelection_Create());
		}

		// Token: 0x06000951 RID: 2385 RVA: 0x0001EF91 File Offset: 0x0001D191
		public void Dispose()
		{
			Binding.FCE_ObjectSelection_Destroy(this.m_selPtr);
			this.m_selPtr = IntPtr.Zero;
		}

		// Token: 0x17000219 RID: 537
		// (get) Token: 0x06000952 RID: 2386 RVA: 0x0001EFAE File Offset: 0x0001D1AE
		public IntPtr Pointer
		{
			get
			{
				return this.m_selPtr;
			}
		}

		// Token: 0x1700021A RID: 538
		// (get) Token: 0x06000953 RID: 2387 RVA: 0x0001EFB6 File Offset: 0x0001D1B6
		public bool IsValid
		{
			get
			{
				return this.Pointer != IntPtr.Zero;
			}
		}

		// Token: 0x1700021B RID: 539
		// (get) Token: 0x06000954 RID: 2388 RVA: 0x0001EFC8 File Offset: 0x0001D1C8
		public int Count
		{
			get
			{
				return Binding.FCE_ObjectSelection_GetCount(this.m_selPtr);
			}
		}

		// Token: 0x1700021C RID: 540
		public EditorObject this[int index]
		{
			get
			{
				return new EditorObject(Binding.FCE_ObjectSelection_Get(this.m_selPtr, index));
			}
		}

		// Token: 0x06000956 RID: 2390 RVA: 0x0001F114 File Offset: 0x0001D314
		public IEnumerable<EditorObject> GetObjects()
		{
			int count = this.Count;
			for (int i = 0; i < count; i++)
			{
				yield return this[i];
			}
			yield break;
		}

		// Token: 0x06000957 RID: 2391 RVA: 0x0001F136 File Offset: 0x0001D336
		public void Clear()
		{
			Binding.FCE_ObjectSelection_Clear(this.m_selPtr);
		}

		// Token: 0x06000958 RID: 2392 RVA: 0x0001F148 File Offset: 0x0001D348
		public void AddObject(EditorObject obj)
		{
			Binding.FCE_ObjectSelection_Add(this.m_selPtr, obj.Pointer);
		}

		// Token: 0x06000959 RID: 2393 RVA: 0x0001F160 File Offset: 0x0001D360
		public void AddSelection(EditorObjectSelection selection)
		{
			Binding.FCE_ObjectSelection_AddSelection(this.m_selPtr, selection.Pointer);
		}

		// Token: 0x0600095A RID: 2394 RVA: 0x0001F179 File Offset: 0x0001D379
		public void GetValidObjects(EditorObjectSelection selection)
		{
			Binding.FCE_ObjectSelection_GetValidObjects(this.m_selPtr, selection.Pointer);
		}

		// Token: 0x0600095B RID: 2395 RVA: 0x0001F192 File Offset: 0x0001D392
		public void RemoveInvalidObjects()
		{
			Binding.FCE_ObjectSelection_RemoveInvalidObjects(this.m_selPtr);
		}

		// Token: 0x0600095C RID: 2396 RVA: 0x0001F1A4 File Offset: 0x0001D3A4
		public void Clone(EditorObjectSelection newSelection, bool cloneObjects)
		{
			Binding.FCE_ObjectSelection_Clone(this.m_selPtr, newSelection.Pointer, cloneObjects);
		}

		// Token: 0x0600095D RID: 2397 RVA: 0x0001F1BE File Offset: 0x0001D3BE
		public void Delete()
		{
			Binding.FCE_ObjectSelection_Delete(this.m_selPtr);
		}

		// Token: 0x0600095E RID: 2398 RVA: 0x0001F1D0 File Offset: 0x0001D3D0
		public void ToggleObject(EditorObject obj)
		{
			Binding.FCE_ObjectSelection_ToggleObject(this.m_selPtr, obj.Pointer);
		}

		// Token: 0x0600095F RID: 2399 RVA: 0x0001F1E8 File Offset: 0x0001D3E8
		public void ToggleSelection(EditorObjectSelection selection)
		{
			Binding.FCE_ObjectSelection_ToggleSelection(this.m_selPtr, selection.Pointer);
		}

		// Token: 0x06000960 RID: 2400 RVA: 0x0001F201 File Offset: 0x0001D401
		public void RemoveObject(EditorObject obj)
		{
			Binding.FCE_ObjectSelection_RemoveObject(this.m_selPtr, obj.Pointer);
		}

		// Token: 0x06000961 RID: 2401 RVA: 0x0001F219 File Offset: 0x0001D419
		public void RemoveSelection(EditorObjectSelection selection)
		{
			Binding.FCE_ObjectSelection_RemoveSelection(this.m_selPtr, selection.Pointer);
		}

		// Token: 0x06000962 RID: 2402 RVA: 0x0001F234 File Offset: 0x0001D434
		public int IndexOf(EditorObject obj)
		{
			for (int i = 0; i < this.Count; i++)
			{
				if (this[i].Pointer == obj.Pointer)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06000963 RID: 2403 RVA: 0x0001F26E File Offset: 0x0001D46E
		public bool Contains(EditorObject obj)
		{
			return this.IndexOf(obj) != -1;
		}

		// Token: 0x1700021D RID: 541
		// (get) Token: 0x06000964 RID: 2404 RVA: 0x0001F280 File Offset: 0x0001D480
		// (set) Token: 0x06000965 RID: 2405 RVA: 0x0001F2BB File Offset: 0x0001D4BB
		public Vec3 Center
		{
			get
			{
				Vec3 result = default(Vec3);
				Binding.FCE_ObjectSelection_GetCenter(this.m_selPtr, out result.X, out result.Y, out result.Z);
				return result;
			}
			set
			{
				Binding.FCE_ObjectSelection_SetCenter(this.m_selPtr, value.X, value.Y, value.Z);
			}
		}

		// Token: 0x06000966 RID: 2406 RVA: 0x0001F2E4 File Offset: 0x0001D4E4
		public Vec3 GetComputeCenter()
		{
			Vec3 result = default(Vec3);
			Binding.FCE_ObjectSelection_GetComputeCenter(this.m_selPtr, out result.X, out result.Y, out result.Z);
			return result;
		}

		// Token: 0x06000967 RID: 2407 RVA: 0x0001F31F File Offset: 0x0001D51F
		public void ComputeCenter()
		{
			Binding.FCE_ObjectSelection_ComputeCenter(this.m_selPtr);
		}

		// Token: 0x1700021E RID: 542
		// (get) Token: 0x06000968 RID: 2408 RVA: 0x0001F334 File Offset: 0x0001D534
		public AABB WorldBounds
		{
			get
			{
				AABB result = default(AABB);
				Binding.FCE_ObjectSelection_GetWorldBounds(this.m_selPtr, out result.min.X, out result.min.Y, out result.min.Z, out result.max.X, out result.max.Y, out result.max.Z);
				return result;
			}
		}

		// Token: 0x06000969 RID: 2409 RVA: 0x0001F3A2 File Offset: 0x0001D5A2
		public void MoveTo(Vec3 pos, EditorObjectSelection.MoveMode mode)
		{
			Binding.FCE_ObjectSelection_MoveTo(this.m_selPtr, pos.X, pos.Y, pos.Z, (int)mode);
		}

		// Token: 0x0600096A RID: 2410 RVA: 0x0001F3CC File Offset: 0x0001D5CC
		public void Rotate(float angle, Vec3 axis, Vec3 pivot, bool affectCenter)
		{
			Binding.FCE_ObjectSelection_Rotate(this.m_selPtr, angle, axis.X, axis.Y, axis.Z, pivot.X, pivot.Y, pivot.Z, affectCenter);
		}

		// Token: 0x0600096B RID: 2411 RVA: 0x0001F418 File Offset: 0x0001D618
		public void Rotate(Vec3 angles, Vec3 axis, Vec3 pivot, bool affectCenter)
		{
			Binding.FCE_ObjectSelection_Rotate3(this.m_selPtr, angles.X, angles.Y, angles.Z, axis.X, axis.Y, axis.Z, pivot.X, pivot.Y, pivot.Z, affectCenter);
		}

		// Token: 0x0600096C RID: 2412 RVA: 0x0001F476 File Offset: 0x0001D676
		public void RotateCenter(float angle, Vec3 axis)
		{
			Binding.FCE_ObjectSelection_RotateCenter(this.m_selPtr, angle, axis.X, axis.Y, axis.Z);
		}

		// Token: 0x0600096D RID: 2413 RVA: 0x0001F49E File Offset: 0x0001D69E
		public void RotateLocal(Vec3 angles)
		{
			Binding.FCE_ObjectSelection_RotateLocal3(this.m_selPtr, angles.X, angles.Y, angles.Z);
		}

		// Token: 0x0600096E RID: 2414 RVA: 0x0001F4C5 File Offset: 0x0001D6C5
		public void RotateGimbal(Vec3 angles)
		{
			Binding.FCE_ObjectSelection_RotateGimbal(this.m_selPtr, angles.X, angles.Y, angles.Z);
		}

		// Token: 0x0600096F RID: 2415 RVA: 0x0001F4EC File Offset: 0x0001D6EC
		public void SetPos(Vec3 pos)
		{
			foreach (EditorObject editorObject in this.GetObjects())
			{
				editorObject.Position = pos;
			}
		}

		// Token: 0x06000970 RID: 2416 RVA: 0x0001F53C File Offset: 0x0001D73C
		public void SetAngles(Vec3 angles)
		{
			foreach (EditorObject editorObject in this.GetObjects())
			{
				editorObject.Angles = angles;
			}
		}

		// Token: 0x06000971 RID: 2417 RVA: 0x0001F58C File Offset: 0x0001D78C
		public void DropToGround(bool physics, bool group)
		{
			Binding.FCE_ObjectSelection_DropToGround(this.m_selPtr, physics, group);
		}

		// Token: 0x06000972 RID: 2418 RVA: 0x0001F5A0 File Offset: 0x0001D7A0
		public void SnapToPivot(EditorObjectPivot source, EditorObjectPivot target, bool preserveOrientation, float snapAngle)
		{
			Binding.FCE_ObjectSelection_SnapToPivot(this.m_selPtr, source.position.X, source.position.Y, source.position.Z, source.normal.X, source.normal.Y, source.normal.Z, source.normalUp.X, source.normalUp.Y, source.normalUp.Z, target.position.X, target.position.Y, target.position.Z, target.normal.X, target.normal.Y, target.normal.Z, target.normalUp.X, target.normalUp.Y, target.normalUp.Z, preserveOrientation, snapAngle);
		}

		// Token: 0x06000973 RID: 2419 RVA: 0x0001F686 File Offset: 0x0001D886
		public void SnapToClosestObjects()
		{
			Binding.FCE_ObjectSelection_SnapToClosestObjects(this.m_selPtr);
		}

		// Token: 0x06000974 RID: 2420 RVA: 0x0001F698 File Offset: 0x0001D898
		public void GetPhysEntities(PhysEntityVector vector)
		{
			Binding.FCE_ObjectSelection_GetPhysEntities(this.m_selPtr, vector.Pointer);
		}

		// Token: 0x06000975 RID: 2421 RVA: 0x0001F6B1 File Offset: 0x0001D8B1
		public void ClearState()
		{
			Binding.FCE_ObjectSelection_ClearState(this.m_selPtr);
		}

		// Token: 0x06000976 RID: 2422 RVA: 0x0001F6C3 File Offset: 0x0001D8C3
		public void LoadState()
		{
			Binding.FCE_ObjectSelection_LoadState(this.m_selPtr);
		}

		// Token: 0x06000977 RID: 2423 RVA: 0x0001F6D5 File Offset: 0x0001D8D5
		public void SaveState()
		{
			Binding.FCE_ObjectSelection_SaveState(this.m_selPtr);
		}

		// Token: 0x06000978 RID: 2424 RVA: 0x0001F6E7 File Offset: 0x0001D8E7
		public bool LoadFromXml(string xml, bool managed, bool noGameplayObject)
		{
			return Binding.FCE_ObjectSelection_LoadFromXml(this.m_selPtr, xml, managed, noGameplayObject);
		}

		// Token: 0x06000979 RID: 2425 RVA: 0x0001F6FC File Offset: 0x0001D8FC
		public string SaveToXml()
		{
			return Binding.FCE_ObjectSelection_SaveToXml(this.m_selPtr);
		}

		// Token: 0x0600097A RID: 2426 RVA: 0x0001F70E File Offset: 0x0001D90E
		public bool IsAxesXYLocked()
		{
			return Binding.FCE_ObjectSelection_IsAxesXYLocked(this.m_selPtr);
		}

		// Token: 0x0400047C RID: 1148
		public static EditorObject Null = new EditorObject(IntPtr.Zero);

		// Token: 0x0400047D RID: 1149
		private IntPtr m_selPtr;

		// Token: 0x0200010F RID: 271
		public enum MoveMode
		{
			// Token: 0x0400047F RID: 1151
			MoveNormal,
			// Token: 0x04000480 RID: 1152
			MoveKeepHeight,
			// Token: 0x04000481 RID: 1153
			MoveSnapToTerrain,
			// Token: 0x04000482 RID: 1154
			MoveKeepAboveTerrain
		}
	}
}
