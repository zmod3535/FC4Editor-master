using System;
using System.Runtime.InteropServices;
using System.Windows.Media;
using IGE.Helpers;

namespace IGE.Nomad
{
	// Token: 0x02000097 RID: 151
	public class RegionInventory : Inventory
	{
		// Token: 0x1700017B RID: 379
		// (get) Token: 0x06000653 RID: 1619 RVA: 0x0001674C File Offset: 0x0001494C
		public override Inventory.Entry Root
		{
			get
			{
				return new RegionInventory.Entry(Binding.FCE_Inventory_Region_GetRoot());
			}
		}

		// Token: 0x06000654 RID: 1620 RVA: 0x0001675D File Offset: 0x0001495D
		public RegionInventory.Entry GetEntryFromId(string id)
		{
			return new RegionInventory.Entry(Binding.FCE_Inventory_Region_GetEntryFromId(id));
		}

		// Token: 0x06000655 RID: 1621 RVA: 0x0001676F File Offset: 0x0001496F
		public RegionInventory.Entry GetDirectoryFromId(string id)
		{
			return new RegionInventory.Entry(Binding.FCE_Inventory_Region_GetDirectoryFromId(id));
		}

		// Token: 0x1700017C RID: 380
		// (get) Token: 0x06000656 RID: 1622 RVA: 0x00016781 File Offset: 0x00014981
		public static RegionInventory Instance
		{
			get
			{
				return RegionInventory.s_instance;
			}
		}

		// Token: 0x04000286 RID: 646
		private static RegionInventory s_instance = new RegionInventory();

		// Token: 0x02000098 RID: 152
		public new class Entry : Inventory.Entry
		{
			// Token: 0x06000659 RID: 1625 RVA: 0x0001679C File Offset: 0x0001499C
			public Entry(IntPtr ptr) : base(ptr)
			{
			}

			// Token: 0x1700017D RID: 381
			// (get) Token: 0x0600065A RID: 1626 RVA: 0x000167A5 File Offset: 0x000149A5
			public override ImageSource Icon
			{
				get
				{
					return (base.IsDirectory ? "icons/folder.png" : "icons/object.png").GetImageSource();
				}
			}

			// Token: 0x1700017E RID: 382
			// (get) Token: 0x0600065B RID: 1627 RVA: 0x000167C0 File Offset: 0x000149C0
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

			// Token: 0x1700017F RID: 383
			// (get) Token: 0x0600065C RID: 1628 RVA: 0x000167D5 File Offset: 0x000149D5
			// (set) Token: 0x0600065D RID: 1629 RVA: 0x000167EC File Offset: 0x000149EC
			public override string DisplayName
			{
				get
				{
					return Marshal.PtrToStringUni(Binding.FCE_Inventory_Region_GetDisplay(this.m_entryPtr));
				}
				set
				{
				}
			}

			// Token: 0x17000180 RID: 384
			// (get) Token: 0x0600065E RID: 1630 RVA: 0x000167EE File Offset: 0x000149EE
			// (set) Token: 0x0600065F RID: 1631 RVA: 0x00016805 File Offset: 0x00014A05
			public override Inventory.Entry Parent
			{
				get
				{
					return new RegionInventory.Entry(Binding.FCE_Inventory_Region_GetParent(this.m_entryPtr));
				}
				set
				{
				}
			}

			// Token: 0x17000181 RID: 385
			// (get) Token: 0x06000660 RID: 1632 RVA: 0x00016807 File Offset: 0x00014A07
			public override int Count
			{
				get
				{
					return Binding.FCE_Inventory_Region_GetChildCount(this.m_entryPtr);
				}
			}

			// Token: 0x17000182 RID: 386
			// (get) Token: 0x06000661 RID: 1633 RVA: 0x0001681C File Offset: 0x00014A1C
			public override Inventory.Entry[] Children
			{
				get
				{
					int count = this.Count;
					Inventory.Entry[] array = new Inventory.Entry[count];
					for (int i = 0; i < count; i++)
					{
						array[i] = new RegionInventory.Entry(Binding.FCE_Inventory_Region_GetChild(this.m_entryPtr, i));
					}
					return array;
				}
			}

			// Token: 0x17000183 RID: 387
			// (get) Token: 0x06000662 RID: 1634 RVA: 0x0001685D File Offset: 0x00014A5D
			// (set) Token: 0x06000663 RID: 1635 RVA: 0x0001686F File Offset: 0x00014A6F
			public int RegionId
			{
				get
				{
					return Binding.FCE_Inventory_Region_GetRegionId(this.m_entryPtr);
				}
				set
				{
				}
			}

			// Token: 0x04000287 RID: 647
			public static RegionInventory.Entry Null = new RegionInventory.Entry(IntPtr.Zero);
		}
	}
}
