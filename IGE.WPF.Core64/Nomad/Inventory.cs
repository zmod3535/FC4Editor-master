using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace IGE.Nomad
{
	// Token: 0x0200008A RID: 138
	public abstract class Inventory : IDisposable
	{
		// Token: 0x17000125 RID: 293
		// (get) Token: 0x060005AE RID: 1454
		public abstract Inventory.Entry Root { get; }

		// Token: 0x060005AF RID: 1455 RVA: 0x000157E0 File Offset: 0x000139E0
		public void Dispose()
		{
			foreach (Inventory.Entry entry in this.m_ownedDirectories)
			{
				this.DestroyFilterDirectory(entry);
			}
		}

		// Token: 0x060005B0 RID: 1456 RVA: 0x00015834 File Offset: 0x00013A34
		public Inventory.Entry CreateDirectory()
		{
			Inventory.Entry entry = this.CreateFilterDirectory();
			if (entry != null)
			{
				this.m_ownedDirectories.Add(entry);
			}
			return entry;
		}

		// Token: 0x060005B1 RID: 1457 RVA: 0x0001585E File Offset: 0x00013A5E
		protected virtual Inventory.Entry CreateFilterDirectory()
		{
			return null;
		}

		// Token: 0x060005B2 RID: 1458 RVA: 0x00015861 File Offset: 0x00013A61
		protected virtual void DestroyFilterDirectory(Inventory.Entry entry)
		{
		}

		// Token: 0x060005B3 RID: 1459 RVA: 0x00015863 File Offset: 0x00013A63
		public virtual void SearchInventory(string criteria, Inventory.Entry resultEntry)
		{
		}

		// Token: 0x0400026E RID: 622
		private List<Inventory.Entry> m_ownedDirectories = new List<Inventory.Entry>();

		// Token: 0x0200008B RID: 139
		public abstract class Entry
		{
			// Token: 0x060005B5 RID: 1461 RVA: 0x00015878 File Offset: 0x00013A78
			public Entry(IntPtr ptr)
			{
				this.m_entryPtr = ptr;
			}

			// Token: 0x17000126 RID: 294
			// (get) Token: 0x060005B6 RID: 1462 RVA: 0x00015887 File Offset: 0x00013A87
			public bool IsDirectory
			{
				get
				{
					return Binding.FCE_Inventory_Entry_IsDirectory(this.Pointer);
				}
			}

			// Token: 0x17000127 RID: 295
			// (get) Token: 0x060005B7 RID: 1463 RVA: 0x00015899 File Offset: 0x00013A99
			// (set) Token: 0x060005B8 RID: 1464 RVA: 0x000158AB File Offset: 0x00013AAB
			public bool Deleted
			{
				get
				{
					return Binding.FCE_Inventory_Entry_IsDeleted(this.Pointer);
				}
				set
				{
					Binding.FCE_Inventory_Entry_SetDeleted(this.Pointer, value);
				}
			}

			// Token: 0x17000128 RID: 296
			// (get) Token: 0x060005B9 RID: 1465
			public abstract ImageSource Icon { get; }

			// Token: 0x17000129 RID: 297
			// (get) Token: 0x060005BA RID: 1466
			public abstract string IconName { get; }

			// Token: 0x1700012A RID: 298
			// (get) Token: 0x060005BB RID: 1467
			// (set) Token: 0x060005BC RID: 1468
			public abstract string DisplayName { get; set; }

			// Token: 0x1700012B RID: 299
			// (get) Token: 0x060005BD RID: 1469 RVA: 0x000158BE File Offset: 0x00013ABE
			// (set) Token: 0x060005BE RID: 1470 RVA: 0x000158C6 File Offset: 0x00013AC6
			public virtual bool IsSpawner { get; set; }

			// Token: 0x1700012C RID: 300
			// (get) Token: 0x060005BF RID: 1471 RVA: 0x000158CF File Offset: 0x00013ACF
			// (set) Token: 0x060005C0 RID: 1472 RVA: 0x000158D7 File Offset: 0x00013AD7
			public virtual bool IsSTP { get; set; }

			// Token: 0x1700012D RID: 301
			// (get) Token: 0x060005C1 RID: 1473 RVA: 0x000158E0 File Offset: 0x00013AE0
			// (set) Token: 0x060005C2 RID: 1474 RVA: 0x000158E8 File Offset: 0x00013AE8
			public virtual bool IsSTPAnimal { get; set; }

			// Token: 0x1700012E RID: 302
			// (get) Token: 0x060005C3 RID: 1475 RVA: 0x000158F1 File Offset: 0x00013AF1
			// (set) Token: 0x060005C4 RID: 1476 RVA: 0x000158F9 File Offset: 0x00013AF9
			public virtual bool IsEnemy { get; set; }

			// Token: 0x1700012F RID: 303
			// (get) Token: 0x060005C5 RID: 1477 RVA: 0x00015902 File Offset: 0x00013B02
			// (set) Token: 0x060005C6 RID: 1478 RVA: 0x0001590A File Offset: 0x00013B0A
			public virtual bool IsAlly { get; set; }

			// Token: 0x17000130 RID: 304
			// (get) Token: 0x060005C7 RID: 1479 RVA: 0x00015913 File Offset: 0x00013B13
			// (set) Token: 0x060005C8 RID: 1480 RVA: 0x0001591B File Offset: 0x00013B1B
			public virtual bool IsAnimal { get; set; }

			// Token: 0x17000131 RID: 305
			// (get) Token: 0x060005C9 RID: 1481 RVA: 0x00015924 File Offset: 0x00013B24
			// (set) Token: 0x060005CA RID: 1482 RVA: 0x0001592C File Offset: 0x00013B2C
			public virtual bool IsGameplay { get; set; }

			// Token: 0x17000132 RID: 306
			// (get) Token: 0x060005CB RID: 1483 RVA: 0x00015935 File Offset: 0x00013B35
			// (set) Token: 0x060005CC RID: 1484 RVA: 0x0001593D File Offset: 0x00013B3D
			public virtual bool IsObjectiveGameplay { get; set; }

			// Token: 0x17000133 RID: 307
			// (get) Token: 0x060005CD RID: 1485 RVA: 0x00015946 File Offset: 0x00013B46
			// (set) Token: 0x060005CE RID: 1486 RVA: 0x0001594E File Offset: 0x00013B4E
			public virtual bool IsToolsOnly { get; set; }

			// Token: 0x17000134 RID: 308
			// (get) Token: 0x060005CF RID: 1487 RVA: 0x00015957 File Offset: 0x00013B57
			// (set) Token: 0x060005D0 RID: 1488 RVA: 0x0001595F File Offset: 0x00013B5F
			public virtual bool IsAmbientOnly { get; set; }

			// Token: 0x17000135 RID: 309
			// (get) Token: 0x060005D1 RID: 1489
			// (set) Token: 0x060005D2 RID: 1490
			public abstract Inventory.Entry Parent { get; set; }

			// Token: 0x17000136 RID: 310
			// (get) Token: 0x060005D3 RID: 1491
			public abstract int Count { get; }

			// Token: 0x17000137 RID: 311
			// (get) Token: 0x060005D4 RID: 1492
			public abstract Inventory.Entry[] Children { get; }

			// Token: 0x060005D5 RID: 1493 RVA: 0x00015BCC File Offset: 0x00013DCC
			public IEnumerable<Inventory.Entry> GetRecursiveEntries()
			{
				foreach (Inventory.Entry entry in this.Children)
				{
					if (entry.IsDirectory)
					{
						foreach (Inventory.Entry child in entry.GetRecursiveEntries())
						{
							yield return child;
						}
					}
					else
					{
						yield return entry;
					}
				}
				yield break;
			}

			// Token: 0x17000138 RID: 312
			// (get) Token: 0x060005D6 RID: 1494 RVA: 0x00015BE9 File Offset: 0x00013DE9
			public bool IsValid
			{
				get
				{
					return this.m_entryPtr != IntPtr.Zero;
				}
			}

			// Token: 0x17000139 RID: 313
			// (get) Token: 0x060005D7 RID: 1495 RVA: 0x00015BFB File Offset: 0x00013DFB
			public IntPtr Pointer
			{
				get
				{
					return this.m_entryPtr;
				}
			}

			// Token: 0x060005D8 RID: 1496 RVA: 0x00015C04 File Offset: 0x00013E04
			public override bool Equals(object obj)
			{
				Inventory.Entry entry = obj as Inventory.Entry;
				if (entry == null)
				{
					return base.Equals(obj);
				}
				return this.Pointer == entry.Pointer;
			}

			// Token: 0x060005D9 RID: 1497 RVA: 0x00015C3A File Offset: 0x00013E3A
			public static bool operator ==(Inventory.Entry x, Inventory.Entry y)
			{
				if (object.ReferenceEquals(x, null))
				{
					return object.ReferenceEquals(y, null);
				}
				return x.Equals(y);
			}

			// Token: 0x060005DA RID: 1498 RVA: 0x00015C54 File Offset: 0x00013E54
			public static bool operator !=(Inventory.Entry x, Inventory.Entry y)
			{
				return !(x == y);
			}

			// Token: 0x060005DB RID: 1499 RVA: 0x00015C60 File Offset: 0x00013E60
			public override int GetHashCode()
			{
				return this.Pointer.ToInt32();
			}

			// Token: 0x060005DC RID: 1500 RVA: 0x00015C7B File Offset: 0x00013E7B
			public void ClearChildren()
			{
				Binding.FCE_Inventory_Entry_ClearChildren(this.Pointer);
			}

			// Token: 0x060005DD RID: 1501 RVA: 0x00015C8D File Offset: 0x00013E8D
			public void AddChild(Inventory.Entry child)
			{
				Binding.FCE_Inventory_Entry_AddChild(this.Pointer, child.Pointer);
			}

			// Token: 0x060005DE RID: 1502 RVA: 0x00015CA5 File Offset: 0x00013EA5
			public void SetChildIndex(Inventory.Entry child, int index)
			{
				Binding.FCE_Inventory_Entry_SetChildIndex(this.m_entryPtr, child.Pointer, index);
			}

			// Token: 0x060005DF RID: 1503 RVA: 0x00015CC0 File Offset: 0x00013EC0
			public MemoryStream GetThumbnailData()
			{
				IntPtr intPtr;
				int num;
				Binding.FCE_Inventory_Entry_OpenThumbnailData(this.m_entryPtr, out intPtr, out num);
				if (intPtr == IntPtr.Zero)
				{
					return null;
				}
				MemoryStream memoryStream = new MemoryStream(num);
				memoryStream.SetLength((long)num);
				byte[] buffer = memoryStream.GetBuffer();
				Marshal.Copy(intPtr, buffer, 0, num);
				Binding.FCE_Inventory_Entry_CloseThumbnailData(this.m_entryPtr, intPtr);
				return memoryStream;
			}

			// Token: 0x060005E0 RID: 1504 RVA: 0x00015D24 File Offset: 0x00013F24
			public BitmapFrame GetThumbnail()
			{
				BitmapFrame result;
				using (MemoryStream thumbnailData = this.GetThumbnailData())
				{
					result = ((thumbnailData == null) ? null : BitmapFrame.Create(thumbnailData, BitmapCreateOptions.None, BitmapCacheOption.OnLoad));
				}
				return result;
			}

			// Token: 0x060005E1 RID: 1505 RVA: 0x00015D64 File Offset: 0x00013F64
			public virtual Color? GetBackgroundColor()
			{
				return null;
			}

			// Token: 0x060005E2 RID: 1506 RVA: 0x00015D7A File Offset: 0x00013F7A
			public virtual Image GetThumbnailOverlay()
			{
				return null;
			}

			// Token: 0x060005E3 RID: 1507 RVA: 0x00015D7D File Offset: 0x00013F7D
			public virtual string GetTextOverlay()
			{
				return null;
			}

			// Token: 0x1700013A RID: 314
			// (get) Token: 0x060005E4 RID: 1508 RVA: 0x00015D80 File Offset: 0x00013F80
			public int WaveNum
			{
				get
				{
					return (int)Binding.FCE_Inventory_Object_GetWaveNum(this.m_entryPtr);
				}
			}

			// Token: 0x0400026F RID: 623
			protected IntPtr m_entryPtr;
		}
	}
}
