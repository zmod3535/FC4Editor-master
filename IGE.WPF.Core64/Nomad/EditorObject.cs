using System;

namespace IGE.Nomad
{
	// Token: 0x0200007B RID: 123
	internal class EditorObject
	{
		// Token: 0x0600051F RID: 1311 RVA: 0x00013BB3 File Offset: 0x00011DB3
		public EditorObject(IntPtr objPtr)
		{
			this.m_objPtr = objPtr;
		}

		// Token: 0x06000520 RID: 1312 RVA: 0x00013BC2 File Offset: 0x00011DC2
		public static EditorObject CreateFromEntry(ObjectInventory.Entry entry, bool altIcon, bool managed)
		{
			return new EditorObject(Binding.FCE_Object_Create_FromEntry(entry.Pointer, altIcon, managed));
		}

		// Token: 0x06000521 RID: 1313 RVA: 0x00013BDB File Offset: 0x00011DDB
		public void Acquire()
		{
			Binding.FCE_Object_AddRef(this.m_objPtr);
		}

		// Token: 0x06000522 RID: 1314 RVA: 0x00013BED File Offset: 0x00011DED
		public void Release()
		{
			Binding.FCE_Object_Release(this.m_objPtr);
		}

		// Token: 0x06000523 RID: 1315 RVA: 0x00013BFF File Offset: 0x00011DFF
		public void Destroy()
		{
			Binding.FCE_Object_Destroy(this.m_objPtr);
			this.m_objPtr = IntPtr.Zero;
		}

		// Token: 0x17000103 RID: 259
		// (get) Token: 0x06000524 RID: 1316 RVA: 0x00013C1C File Offset: 0x00011E1C
		public bool IsValid
		{
			get
			{
				return this.Pointer != IntPtr.Zero;
			}
		}

		// Token: 0x17000104 RID: 260
		// (get) Token: 0x06000525 RID: 1317 RVA: 0x00013C2E File Offset: 0x00011E2E
		public IntPtr Pointer
		{
			get
			{
				return this.m_objPtr;
			}
		}

		// Token: 0x06000526 RID: 1318 RVA: 0x00013C38 File Offset: 0x00011E38
		public override bool Equals(object obj)
		{
			Inventory.Entry entry = obj as Inventory.Entry;
			if (entry == null)
			{
				return base.Equals(obj);
			}
			return this.Pointer == entry.Pointer;
		}

		// Token: 0x06000527 RID: 1319 RVA: 0x00013C6E File Offset: 0x00011E6E
		public static bool operator ==(EditorObject x, EditorObject y)
		{
			if (object.ReferenceEquals(x, null))
			{
				return object.ReferenceEquals(y, null);
			}
			return x.Equals(y);
		}

		// Token: 0x06000528 RID: 1320 RVA: 0x00013C88 File Offset: 0x00011E88
		public static bool operator !=(EditorObject x, EditorObject y)
		{
			return !(x == y);
		}

		// Token: 0x06000529 RID: 1321 RVA: 0x00013C94 File Offset: 0x00011E94
		public override int GetHashCode()
		{
			return this.Pointer.ToInt32();
		}

		// Token: 0x0600052A RID: 1322 RVA: 0x00013CAF File Offset: 0x00011EAF
		public EditorObject Clone()
		{
			return new EditorObject(Binding.FCE_Object_Clone(this.m_objPtr));
		}

		// Token: 0x17000105 RID: 261
		// (get) Token: 0x0600052B RID: 1323 RVA: 0x00013CC6 File Offset: 0x00011EC6
		public bool IsLoaded
		{
			get
			{
				return Binding.FCE_Object_IsLoaded(this.m_objPtr);
			}
		}

		// Token: 0x17000106 RID: 262
		// (get) Token: 0x0600052C RID: 1324 RVA: 0x00013CD8 File Offset: 0x00011ED8
		public ObjectInventory.Entry Entry
		{
			get
			{
				return new ObjectInventory.Entry(Binding.FCE_Object_GetEntry(this.m_objPtr));
			}
		}

		// Token: 0x17000107 RID: 263
		// (get) Token: 0x0600052D RID: 1325 RVA: 0x00013CF0 File Offset: 0x00011EF0
		// (set) Token: 0x0600052E RID: 1326 RVA: 0x00013D23 File Offset: 0x00011F23
		public Vec3 Position
		{
			get
			{
				Vec3 result;
				Binding.FCE_Object_GetPos(this.m_objPtr, out result.X, out result.Y, out result.Z);
				return result;
			}
			set
			{
				Binding.FCE_Object_SetPos(this.m_objPtr, value.X, value.Y, value.Z);
			}
		}

		// Token: 0x17000108 RID: 264
		// (get) Token: 0x0600052F RID: 1327 RVA: 0x00013D4C File Offset: 0x00011F4C
		// (set) Token: 0x06000530 RID: 1328 RVA: 0x00013D7F File Offset: 0x00011F7F
		public Vec3 Angles
		{
			get
			{
				Vec3 result;
				Binding.FCE_Object_GetAngles(this.m_objPtr, out result.X, out result.Y, out result.Z);
				return result;
			}
			set
			{
				Binding.FCE_Object_SetAngles(this.m_objPtr, value.X, value.Y, value.Z);
			}
		}

		// Token: 0x17000109 RID: 265
		// (get) Token: 0x06000531 RID: 1329 RVA: 0x00013DA6 File Offset: 0x00011FA6
		public CoordinateSystem Axis
		{
			get
			{
				return CoordinateSystem.FromAngles(this.Angles);
			}
		}

		// Token: 0x06000532 RID: 1330 RVA: 0x00013DB4 File Offset: 0x00011FB4
		public Vec3 GetPivotPoint(Pivot pivot)
		{
			AABB bounds;
			if (this.IsLoaded)
			{
				bounds = this.LocalBounds;
			}
			else
			{
				bounds = default(AABB);
			}
			return this.Axis.GetPivotPoint(this.Position, bounds, pivot);
		}

		// Token: 0x1700010A RID: 266
		// (get) Token: 0x06000533 RID: 1331 RVA: 0x00013DF0 File Offset: 0x00011FF0
		public AABB LocalBounds
		{
			get
			{
				AABB result;
				Binding.FCE_Object_GetBounds(this.m_objPtr, false, out result.min.X, out result.min.Y, out result.min.Z, out result.max.X, out result.max.Y, out result.max.Z);
				return result;
			}
		}

		// Token: 0x1700010B RID: 267
		// (get) Token: 0x06000534 RID: 1332 RVA: 0x00013E58 File Offset: 0x00012058
		public AABB WorldBounds
		{
			get
			{
				AABB result;
				Binding.FCE_Object_GetBounds(this.m_objPtr, true, out result.min.X, out result.min.Y, out result.min.Z, out result.max.X, out result.max.Y, out result.max.Z);
				return result;
			}
		}

		// Token: 0x1700010C RID: 268
		// (get) Token: 0x06000535 RID: 1333 RVA: 0x00013EBF File Offset: 0x000120BF
		// (set) Token: 0x06000536 RID: 1334 RVA: 0x00013ED1 File Offset: 0x000120D1
		public bool Visible
		{
			get
			{
				return Binding.FCE_Object_IsVisible(this.m_objPtr);
			}
			set
			{
				Binding.FCE_Object_SetVisible(this.m_objPtr, value);
			}
		}

		// Token: 0x1700010D RID: 269
		// (set) Token: 0x06000537 RID: 1335 RVA: 0x00013EE4 File Offset: 0x000120E4
		public bool HighlightState
		{
			set
			{
				Binding.FCE_Object_SetHighlight(this.m_objPtr, value);
			}
		}

		// Token: 0x1700010E RID: 270
		// (set) Token: 0x06000538 RID: 1336 RVA: 0x00013EF7 File Offset: 0x000120F7
		public bool Frozen
		{
			set
			{
				Binding.FCE_Object_SetFreeze(this.m_objPtr, value);
			}
		}

		// Token: 0x06000539 RID: 1337 RVA: 0x00013F0A File Offset: 0x0001210A
		public void DropToGround(bool physics)
		{
			Binding.FCE_Object_DropToGround(this.m_objPtr, physics);
		}

		// Token: 0x0600053A RID: 1338 RVA: 0x00013F20 File Offset: 0x00012120
		public void ComputeAutoOrientation(ref Vec3 pos, out Vec3 angles, Vec3 normal)
		{
			angles = default(Vec3);
			Binding.FCE_Object_ComputeAutoOrientation(this.m_objPtr, ref pos.X, ref pos.Y, ref pos.Z, out angles.X, out angles.Y, out angles.Z, normal.X, normal.Y, normal.Z);
		}

		// Token: 0x0600053B RID: 1339 RVA: 0x00013F80 File Offset: 0x00012180
		public bool GetPivot(int idx, out EditorObjectPivot pivot)
		{
			pivot = new EditorObjectPivot();
			return Binding.FCE_Object_GetPivot(this.m_objPtr, idx, out pivot.position.X, out pivot.position.Y, out pivot.position.Z, out pivot.normal.X, out pivot.normal.Y, out pivot.normal.Z, out pivot.normalUp.X, out pivot.normalUp.Y, out pivot.normalUp.Z);
		}

		// Token: 0x0600053C RID: 1340 RVA: 0x00014011 File Offset: 0x00012211
		public bool GetClosestPivot(Vec3 pos, out EditorObjectPivot pivot)
		{
			return this.GetClosestPivot(pos, out pivot, float.MaxValue);
		}

		// Token: 0x0600053D RID: 1341 RVA: 0x00014020 File Offset: 0x00012220
		public bool GetClosestPivot(Vec3 pos, out EditorObjectPivot pivot, float minDist)
		{
			pivot = new EditorObjectPivot();
			return Binding.FCE_Object_GetClosestPivot(this.m_objPtr, pos.X, pos.Y, pos.Z, out pivot.position.X, out pivot.position.Y, out pivot.position.Z, out pivot.normal.X, out pivot.normal.Y, out pivot.normal.Z, out pivot.normalUp.X, out pivot.normalUp.Y, out pivot.normalUp.Z, minDist);
		}

		// Token: 0x0600053E RID: 1342 RVA: 0x000140C6 File Offset: 0x000122C6
		public void SnapToClosestObject()
		{
			Binding.FCE_Object_SnapToClosestObject(this.m_objPtr);
		}

		// Token: 0x0600053F RID: 1343 RVA: 0x000140D8 File Offset: 0x000122D8
		public void GetPhysEntities(PhysEntityVector vector)
		{
			Binding.FCE_Object_GetPhysEntities(this.m_objPtr, vector.Pointer);
		}

		// Token: 0x1700010F RID: 271
		// (get) Token: 0x06000540 RID: 1344 RVA: 0x000140F1 File Offset: 0x000122F1
		public bool IsAmbient
		{
			get
			{
				return (this.Entry.IsAI || this.Entry.IsAnimal) && !Binding.FCE_AI_IsValidObjectiveEntity(this.m_objPtr);
			}
		}

		// Token: 0x17000110 RID: 272
		// (get) Token: 0x06000541 RID: 1345 RVA: 0x00014122 File Offset: 0x00012322
		public bool IsObjective
		{
			get
			{
				return (this.Entry.IsAI || this.Entry.IsAnimal) && Binding.FCE_AI_IsValidObjectiveEntity(this.m_objPtr);
			}
		}

		// Token: 0x17000111 RID: 273
		// (set) Token: 0x06000542 RID: 1346 RVA: 0x00014150 File Offset: 0x00012350
		public string Group
		{
			set
			{
				Binding.FCE_AI_SetAIGroup(this.m_objPtr, value);
			}
		}

		// Token: 0x04000234 RID: 564
		public static EditorObject Null = new EditorObject(IntPtr.Zero);

		// Token: 0x04000235 RID: 565
		private IntPtr m_objPtr;
	}
}
