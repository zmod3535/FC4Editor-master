using System;
using System.Runtime.InteropServices;
using System.Windows.Media;
using IGE.Helpers;

namespace IGE.Nomad
{
	// Token: 0x0200008F RID: 143
	internal class CollectionInventory : Inventory
	{
		// Token: 0x17000159 RID: 345
		// (get) Token: 0x06000618 RID: 1560 RVA: 0x00016319 File Offset: 0x00014519
		public override Inventory.Entry Root
		{
			get
			{
				return new CollectionInventory.Entry(Binding.FCE_Inventory_Collection_GetRoot());
			}
		}

		// Token: 0x1700015A RID: 346
		// (get) Token: 0x06000619 RID: 1561 RVA: 0x0001632A File Offset: 0x0001452A
		public static CollectionInventory Instance
		{
			get
			{
				return CollectionInventory.s_instance;
			}
		}

		// Token: 0x0400027E RID: 638
		private static CollectionInventory s_instance = new CollectionInventory();

		// Token: 0x02000090 RID: 144
		public new class Entry : Inventory.Entry
		{
			// Token: 0x0600061C RID: 1564 RVA: 0x00016345 File Offset: 0x00014545
			public Entry(IntPtr ptr) : base(ptr)
			{
			}

			// Token: 0x1700015B RID: 347
			// (get) Token: 0x0600061D RID: 1565 RVA: 0x0001634E File Offset: 0x0001454E
			public override ImageSource Icon
			{
				get
				{
					return (base.IsDirectory ? "icons/folder.png" : "icons/object.png").GetImageSource();
				}
			}

			// Token: 0x1700015C RID: 348
			// (get) Token: 0x0600061E RID: 1566 RVA: 0x00016369 File Offset: 0x00014569
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

			// Token: 0x1700015D RID: 349
			// (get) Token: 0x0600061F RID: 1567 RVA: 0x0001637E File Offset: 0x0001457E
			// (set) Token: 0x06000620 RID: 1568 RVA: 0x00016395 File Offset: 0x00014595
			public override string DisplayName
			{
				get
				{
					return Marshal.PtrToStringUni(Binding.FCE_Inventory_Collection_GetDisplay(this.m_entryPtr));
				}
				set
				{
				}
			}

			// Token: 0x1700015E RID: 350
			// (get) Token: 0x06000621 RID: 1569 RVA: 0x00016397 File Offset: 0x00014597
			// (set) Token: 0x06000622 RID: 1570 RVA: 0x000163AE File Offset: 0x000145AE
			public override Inventory.Entry Parent
			{
				get
				{
					return new CollectionInventory.Entry(Binding.FCE_Inventory_Collection_GetParent(this.m_entryPtr));
				}
				set
				{
				}
			}

			// Token: 0x1700015F RID: 351
			// (get) Token: 0x06000623 RID: 1571 RVA: 0x000163B0 File Offset: 0x000145B0
			public override int Count
			{
				get
				{
					return Binding.FCE_Inventory_Collection_GetChildCount(this.m_entryPtr);
				}
			}

			// Token: 0x17000160 RID: 352
			// (get) Token: 0x06000624 RID: 1572 RVA: 0x000163C4 File Offset: 0x000145C4
			public override Inventory.Entry[] Children
			{
				get
				{
					int count = this.Count;
					Inventory.Entry[] array = new Inventory.Entry[count];
					for (int i = 0; i < count; i++)
					{
						array[i] = new CollectionInventory.Entry(Binding.FCE_Inventory_Collection_GetChild(this.m_entryPtr, i));
					}
					return array;
				}
			}

			// Token: 0x17000161 RID: 353
			// (get) Token: 0x06000625 RID: 1573 RVA: 0x00016405 File Offset: 0x00014605
			public bool HasBurnProfile
			{
				get
				{
					return Binding.FCE_Inventory_Collection_GetBurnProfile(this.m_entryPtr) != 2416722677U;
				}
			}

			// Token: 0x0400027F RID: 639
			public static CollectionInventory.Entry Null = new CollectionInventory.Entry(IntPtr.Zero);
		}
	}
}
