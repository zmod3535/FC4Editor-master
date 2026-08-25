using System;
using System.Runtime.InteropServices;
using System.Windows.Media;
using IGE.Helpers;

namespace IGE.Nomad
{
	// Token: 0x02000093 RID: 147
	public class WaterInventory : Inventory
	{
		// Token: 0x1700016A RID: 362
		// (get) Token: 0x06000635 RID: 1589 RVA: 0x0001652E File Offset: 0x0001472E
		public override Inventory.Entry Root
		{
			get
			{
				return new WaterInventory.Entry(Binding.FCE_Inventory_Water_GetRoot());
			}
		}

		// Token: 0x06000636 RID: 1590 RVA: 0x0001653F File Offset: 0x0001473F
		public WaterInventory.Entry GetFromId(string id)
		{
			return new WaterInventory.Entry(Binding.FCE_Inventory_Water_GetFromId(id));
		}

		// Token: 0x1700016B RID: 363
		// (get) Token: 0x06000637 RID: 1591 RVA: 0x00016551 File Offset: 0x00014751
		public static WaterInventory Instance
		{
			get
			{
				return WaterInventory.s_instance;
			}
		}

		// Token: 0x04000282 RID: 642
		private static WaterInventory s_instance = new WaterInventory();

		// Token: 0x02000094 RID: 148
		public new class Entry : Inventory.Entry
		{
			// Token: 0x0600063A RID: 1594 RVA: 0x0001656C File Offset: 0x0001476C
			public Entry(IntPtr ptr) : base(ptr)
			{
			}

			// Token: 0x1700016C RID: 364
			// (get) Token: 0x0600063B RID: 1595 RVA: 0x00016575 File Offset: 0x00014775
			public override ImageSource Icon
			{
				get
				{
					return (base.IsDirectory ? "icons/folder.png" : "icons/object.png").GetImageSource();
				}
			}

			// Token: 0x1700016D RID: 365
			// (get) Token: 0x0600063C RID: 1596 RVA: 0x00016590 File Offset: 0x00014790
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

			// Token: 0x1700016E RID: 366
			// (get) Token: 0x0600063D RID: 1597 RVA: 0x000165A5 File Offset: 0x000147A5
			// (set) Token: 0x0600063E RID: 1598 RVA: 0x000165BC File Offset: 0x000147BC
			public override string DisplayName
			{
				get
				{
					return Marshal.PtrToStringUni(Binding.FCE_Inventory_Water_GetDisplay(this.m_entryPtr));
				}
				set
				{
				}
			}

			// Token: 0x1700016F RID: 367
			// (get) Token: 0x0600063F RID: 1599 RVA: 0x000165BE File Offset: 0x000147BE
			// (set) Token: 0x06000640 RID: 1600 RVA: 0x000165D5 File Offset: 0x000147D5
			public override Inventory.Entry Parent
			{
				get
				{
					return new WaterInventory.Entry(Binding.FCE_Inventory_Water_GetParent(this.m_entryPtr));
				}
				set
				{
				}
			}

			// Token: 0x17000170 RID: 368
			// (get) Token: 0x06000641 RID: 1601 RVA: 0x000165D7 File Offset: 0x000147D7
			public override int Count
			{
				get
				{
					return Binding.FCE_Inventory_Water_GetChildCount(this.m_entryPtr);
				}
			}

			// Token: 0x17000171 RID: 369
			// (get) Token: 0x06000642 RID: 1602 RVA: 0x000165EC File Offset: 0x000147EC
			public override Inventory.Entry[] Children
			{
				get
				{
					int count = this.Count;
					Inventory.Entry[] array = new Inventory.Entry[count];
					for (int i = 0; i < count; i++)
					{
						array[i] = new WaterInventory.Entry(Binding.FCE_Inventory_Water_GetChild(this.m_entryPtr, i));
					}
					return array;
				}
			}

			// Token: 0x04000283 RID: 643
			public static WaterInventory.Entry Null = new WaterInventory.Entry(IntPtr.Zero);
		}
	}
}
