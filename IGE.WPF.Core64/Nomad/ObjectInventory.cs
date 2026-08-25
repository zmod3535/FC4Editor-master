using System;
using System.Runtime.InteropServices;
using System.Windows.Controls;
using System.Windows.Media;
using IGE.Helpers;

namespace IGE.Nomad
{
	// Token: 0x0200008C RID: 140
	internal class ObjectInventory : Inventory
	{
		// Token: 0x1700013B RID: 315
		// (get) Token: 0x060005E5 RID: 1509 RVA: 0x00015D92 File Offset: 0x00013F92
		public override Inventory.Entry Root
		{
			get
			{
				return new ObjectInventory.Entry(Binding.FCE_Inventory_Object_GetRoot());
			}
		}

		// Token: 0x060005E6 RID: 1510 RVA: 0x00015DA3 File Offset: 0x00013FA3
		public void SaveChanges()
		{
			Binding.FCE_Inventory_Object_SaveChanges();
		}

		// Token: 0x060005E7 RID: 1511 RVA: 0x00015DAF File Offset: 0x00013FAF
		public ObjectInventory.Entry CreateDirectory(ObjectInventory.Entry parent)
		{
			return new ObjectInventory.Entry(Binding.FCE_Inventory_Object_CreateDirectory(parent.Pointer));
		}

		// Token: 0x060005E8 RID: 1512 RVA: 0x00015DC6 File Offset: 0x00013FC6
		public ObjectInventory.Entry CreatePrefabObject(ObjectInventory.Entry parent, string id)
		{
			return new ObjectInventory.Entry(Binding.FCE_Inventory_Object_CreatePrefabObject(parent.Pointer, id));
		}

		// Token: 0x060005E9 RID: 1513 RVA: 0x00015DDE File Offset: 0x00013FDE
		protected override Inventory.Entry CreateFilterDirectory()
		{
			return new ObjectInventory.Entry(Binding.FCE_Inventory_Object_CreateFilterDirectory());
		}

		// Token: 0x060005EA RID: 1514 RVA: 0x00015DEF File Offset: 0x00013FEF
		protected override void DestroyFilterDirectory(Inventory.Entry entry)
		{
			Binding.FCE_Inventory_Object_DestroyFilterDirectory(entry.Pointer);
		}

		// Token: 0x060005EB RID: 1515 RVA: 0x00015E01 File Offset: 0x00014001
		public override void SearchInventory(string criteria, Inventory.Entry resultEntry)
		{
			Binding.FCE_Inventory_Object_SearchInventoryEntry(this.Root.Pointer, criteria, resultEntry.Pointer);
		}

		// Token: 0x1700013C RID: 316
		// (get) Token: 0x060005EC RID: 1516 RVA: 0x00015E1F File Offset: 0x0001401F
		public static ObjectInventory Instance
		{
			get
			{
				return ObjectInventory.s_instance;
			}
		}

		// Token: 0x0400027A RID: 634
		private static ObjectInventory s_instance = new ObjectInventory();

		// Token: 0x0200008D RID: 141
		public new class Entry : Inventory.Entry
		{
			// Token: 0x060005EF RID: 1519 RVA: 0x00015E3A File Offset: 0x0001403A
			public Entry(IntPtr ptr) : base(ptr)
			{
			}

			// Token: 0x1700013D RID: 317
			// (get) Token: 0x060005F0 RID: 1520 RVA: 0x00015E43 File Offset: 0x00014043
			public override ImageSource Icon
			{
				get
				{
					if (!base.IsDirectory)
					{
						return "icons/object.png".GetImageSource();
					}
					return "icons/folder.png".GetImageSource();
				}
			}

			// Token: 0x1700013E RID: 318
			// (get) Token: 0x060005F1 RID: 1521 RVA: 0x00015E62 File Offset: 0x00014062
			public override string IconName
			{
				get
				{
					if (!base.IsDirectory)
					{
						return "icon_object";
					}
					return "icon_folder";
				}
			}

			// Token: 0x1700013F RID: 319
			// (get) Token: 0x060005F2 RID: 1522 RVA: 0x00015E77 File Offset: 0x00014077
			public uint Id
			{
				get
				{
					return Binding.FCE_Inventory_Object_GetId(this.m_entryPtr);
				}
			}

			// Token: 0x17000140 RID: 320
			// (get) Token: 0x060005F3 RID: 1523 RVA: 0x00015E89 File Offset: 0x00014089
			public string IdString
			{
				get
				{
					return Marshal.PtrToStringAnsi(Binding.FCE_Inventory_Object_GetIdString(this.m_entryPtr));
				}
			}

			// Token: 0x17000141 RID: 321
			// (get) Token: 0x060005F4 RID: 1524 RVA: 0x00015EA0 File Offset: 0x000140A0
			// (set) Token: 0x060005F5 RID: 1525 RVA: 0x00015EB7 File Offset: 0x000140B7
			public override string DisplayName
			{
				get
				{
					return Marshal.PtrToStringUni(Binding.FCE_Inventory_Object_GetDisplay(this.m_entryPtr));
				}
				set
				{
					Binding.FCE_Inventory_Object_SetDisplay(this.m_entryPtr, value);
				}
			}

			// Token: 0x17000142 RID: 322
			// (get) Token: 0x060005F6 RID: 1526 RVA: 0x00015ECA File Offset: 0x000140CA
			// (set) Token: 0x060005F7 RID: 1527 RVA: 0x00015EE1 File Offset: 0x000140E1
			public override Inventory.Entry Parent
			{
				get
				{
					return new ObjectInventory.Entry(Binding.FCE_Inventory_Object_GetParent(this.m_entryPtr));
				}
				set
				{
					Binding.FCE_Inventory_Object_SetParent(this.m_entryPtr, value.Pointer);
				}
			}

			// Token: 0x17000143 RID: 323
			// (get) Token: 0x060005F8 RID: 1528 RVA: 0x00015EF9 File Offset: 0x000140F9
			public override int Count
			{
				get
				{
					return Binding.FCE_Inventory_Object_GetChildCount(this.m_entryPtr);
				}
			}

			// Token: 0x17000144 RID: 324
			// (get) Token: 0x060005F9 RID: 1529 RVA: 0x00015F0B File Offset: 0x0001410B
			public override bool IsSpawner
			{
				get
				{
					return Binding.FCE_Inventory_Object_IsObjectType(this.m_entryPtr, 8);
				}
			}

			// Token: 0x17000145 RID: 325
			// (get) Token: 0x060005FA RID: 1530 RVA: 0x00015F1E File Offset: 0x0001411E
			public override bool IsSTP
			{
				get
				{
					return Binding.FCE_Inventory_Object_IsObjectType(this.m_entryPtr, 16);
				}
			}

			// Token: 0x17000146 RID: 326
			// (get) Token: 0x060005FB RID: 1531 RVA: 0x00015F32 File Offset: 0x00014132
			public override bool IsSTPAnimal
			{
				get
				{
					return Binding.FCE_Inventory_Object_IsObjectType(this.m_entryPtr, 32768);
				}
			}

			// Token: 0x17000147 RID: 327
			// (get) Token: 0x060005FC RID: 1532 RVA: 0x00015F49 File Offset: 0x00014149
			public override bool IsEnemy
			{
				get
				{
					return Binding.FCE_Inventory_Object_IsObjectType(this.m_entryPtr, 1);
				}
			}

			// Token: 0x17000148 RID: 328
			// (get) Token: 0x060005FD RID: 1533 RVA: 0x00015F5C File Offset: 0x0001415C
			public override bool IsAlly
			{
				get
				{
					return Binding.FCE_Inventory_Object_IsObjectType(this.m_entryPtr, 2);
				}
			}

			// Token: 0x17000149 RID: 329
			// (get) Token: 0x060005FE RID: 1534 RVA: 0x00015F6F File Offset: 0x0001416F
			public override bool IsAnimal
			{
				get
				{
					return Binding.FCE_Inventory_Object_IsObjectType(this.m_entryPtr, 4);
				}
			}

			// Token: 0x1700014A RID: 330
			// (get) Token: 0x060005FF RID: 1535 RVA: 0x00015F82 File Offset: 0x00014182
			public override bool IsGameplay
			{
				get
				{
					return Binding.FCE_Inventory_Object_IsObjectType(this.m_entryPtr, 512);
				}
			}

			// Token: 0x1700014B RID: 331
			// (get) Token: 0x06000600 RID: 1536 RVA: 0x00015F99 File Offset: 0x00014199
			public override bool IsObjectiveGameplay
			{
				get
				{
					return Binding.FCE_Inventory_Object_IsObjectiveGameplayObject(this.m_entryPtr);
				}
			}

			// Token: 0x1700014C RID: 332
			// (get) Token: 0x06000601 RID: 1537 RVA: 0x00015FAB File Offset: 0x000141AB
			public override bool IsToolsOnly
			{
				get
				{
					return Binding.FCE_Inventory_Object_IsObjectType(this.m_entryPtr, 4096);
				}
			}

			// Token: 0x1700014D RID: 333
			// (get) Token: 0x06000602 RID: 1538 RVA: 0x00015FC2 File Offset: 0x000141C2
			public override bool IsAmbientOnly
			{
				get
				{
					return Binding.FCE_Inventory_Object_IsObjectType(this.m_entryPtr, 524288);
				}
			}

			// Token: 0x1700014E RID: 334
			// (get) Token: 0x06000603 RID: 1539 RVA: 0x00015FDC File Offset: 0x000141DC
			public override Inventory.Entry[] Children
			{
				get
				{
					int count = this.Count;
					Inventory.Entry[] array = new Inventory.Entry[count];
					for (int i = 0; i < count; i++)
					{
						array[i] = new ObjectInventory.Entry(Binding.FCE_Inventory_Object_GetChild(this.m_entryPtr, i));
					}
					return array;
				}
			}

			// Token: 0x1700014F RID: 335
			// (get) Token: 0x06000604 RID: 1540 RVA: 0x0001601D File Offset: 0x0001421D
			// (set) Token: 0x06000605 RID: 1541 RVA: 0x00016034 File Offset: 0x00014234
			public string Tags
			{
				get
				{
					return Marshal.PtrToStringAnsi(Binding.FCE_Inventory_Object_GetTags(this.m_entryPtr));
				}
				set
				{
					Binding.FCE_Inventory_Object_SetTags(this.m_entryPtr, value);
				}
			}

			// Token: 0x17000150 RID: 336
			// (get) Token: 0x06000606 RID: 1542 RVA: 0x00016047 File Offset: 0x00014247
			public ObjectInventory.Entry.SourceTypes SourceType
			{
				get
				{
					return (ObjectInventory.Entry.SourceTypes)Binding.FCE_Inventory_Object_GetSourceType(this.m_entryPtr);
				}
			}

			// Token: 0x17000151 RID: 337
			// (get) Token: 0x06000607 RID: 1543 RVA: 0x0001605C File Offset: 0x0001425C
			public Vec3 BMin
			{
				get
				{
					float x;
					float y;
					float z;
					Binding.FCE_Inventory_Object_GetBMin(this.m_entryPtr, out x, out y, out z);
					return new Vec3(x, y, z);
				}
			}

			// Token: 0x17000152 RID: 338
			// (get) Token: 0x06000608 RID: 1544 RVA: 0x00016088 File Offset: 0x00014288
			public Vec3 BMax
			{
				get
				{
					float x;
					float y;
					float z;
					Binding.FCE_Inventory_Object_GetBMax(this.m_entryPtr, out x, out y, out z);
					return new Vec3(x, y, z);
				}
			}

			// Token: 0x17000153 RID: 339
			// (get) Token: 0x06000609 RID: 1545 RVA: 0x000160B4 File Offset: 0x000142B4
			public Vec3 Size
			{
				get
				{
					float x;
					float y;
					float z;
					Binding.FCE_Inventory_Object_GetSize(this.m_entryPtr, out x, out y, out z);
					return new Vec3(x, y, z);
				}
			}

			// Token: 0x17000154 RID: 340
			// (get) Token: 0x0600060A RID: 1546 RVA: 0x000160DF File Offset: 0x000142DF
			public bool AutoOrientation
			{
				get
				{
					return Binding.FCE_Inventory_Object_IsAutoOrientation(this.m_entryPtr);
				}
			}

			// Token: 0x17000155 RID: 341
			// (get) Token: 0x0600060B RID: 1547 RVA: 0x000160F1 File Offset: 0x000142F1
			// (set) Token: 0x0600060C RID: 1548 RVA: 0x00016103 File Offset: 0x00014303
			public float ZOffset
			{
				get
				{
					return Binding.FCE_Inventory_Object_GetZOffset(this.m_entryPtr);
				}
				set
				{
					Binding.FCE_Inventory_Object_SetZOffset(this.m_entryPtr, value);
				}
			}

			// Token: 0x17000156 RID: 342
			// (get) Token: 0x0600060D RID: 1549 RVA: 0x00016116 File Offset: 0x00014316
			public bool IsAI
			{
				get
				{
					return Binding.FCE_Inventory_Object_IsAI(this.m_entryPtr);
				}
			}

			// Token: 0x0600060E RID: 1550 RVA: 0x00016128 File Offset: 0x00014328
			public void ClearPivots()
			{
				Binding.FCE_Inventory_Object_ClearPivots(this.m_entryPtr);
			}

			// Token: 0x0600060F RID: 1551 RVA: 0x0001613C File Offset: 0x0001433C
			public void AddPivot(EditorObjectPivot pivot)
			{
				Binding.FCE_Inventory_Object_AddPivot(this.m_entryPtr, pivot.position.X, pivot.position.Y, pivot.position.Z, pivot.normal.X, pivot.normal.Y, pivot.normal.Z, pivot.normalUp.X, pivot.normalUp.Y, pivot.normalUp.Z);
			}

			// Token: 0x06000610 RID: 1552 RVA: 0x000161BC File Offset: 0x000143BC
			public void SetPivot(int idx, EditorObjectPivot pivot)
			{
				Binding.FCE_Inventory_Object_SetPivot(this.m_entryPtr, idx, pivot.position.X, pivot.position.Y, pivot.position.Z, pivot.normal.X, pivot.normal.Y, pivot.normal.Z, pivot.normalUp.X, pivot.normalUp.Y, pivot.normalUp.Z);
			}

			// Token: 0x06000611 RID: 1553 RVA: 0x0001623D File Offset: 0x0001443D
			public void SetPivots(float minX, float maxX, float minY, float maxY)
			{
				Binding.FCE_Inventory_Object_SetPivots(this.m_entryPtr, minX, maxX, minY, maxY);
			}

			// Token: 0x17000157 RID: 343
			// (get) Token: 0x06000612 RID: 1554 RVA: 0x00016254 File Offset: 0x00014454
			// (set) Token: 0x06000613 RID: 1555 RVA: 0x00016266 File Offset: 0x00014466
			public bool AutoPivot
			{
				get
				{
					return Binding.FCE_Inventory_Object_IsAutoPivot(this.m_entryPtr);
				}
				set
				{
					Binding.FCE_Inventory_Object_SetAutoPivot(this.m_entryPtr, value);
				}
			}

			// Token: 0x17000158 RID: 344
			// (get) Token: 0x06000614 RID: 1556 RVA: 0x00016279 File Offset: 0x00014479
			public int PivotCount
			{
				get
				{
					return Binding.FCE_Inventory_Object_GetPivotCount(this.m_entryPtr);
				}
			}

			// Token: 0x06000615 RID: 1557 RVA: 0x0001628B File Offset: 0x0001448B
			public override Color? GetBackgroundColor()
			{
				return base.GetBackgroundColor();
			}

			// Token: 0x06000616 RID: 1558 RVA: 0x00016293 File Offset: 0x00014493
			public override Image GetThumbnailOverlay()
			{
				return base.GetThumbnailOverlay();
			}

			// Token: 0x06000617 RID: 1559 RVA: 0x0001629C File Offset: 0x0001449C
			public override string GetTextOverlay()
			{
				if (base.IsDirectory)
				{
					return null;
				}
				Vec3 size = this.Size;
				float num = Math.Max(Math.Max(size.X, size.Y), size.Z);
				if (num < 1f)
				{
					return ((int)Math.Round((double)(num * 100f))).ToString() + "cm";
				}
				return num.ToString("F1") + "m";
			}

			// Token: 0x0200008E RID: 142
			public enum SourceTypes
			{
				// Token: 0x0400027C RID: 636
				Archetype,
				// Token: 0x0400027D RID: 637
				InlinePrefab
			}
		}
	}
}
