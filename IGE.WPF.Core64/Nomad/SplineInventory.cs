using System;
using System.Runtime.InteropServices;
using System.Windows.Media;
using IGE.Helpers;

namespace IGE.Nomad
{
	// Token: 0x02000095 RID: 149
	internal class SplineInventory : Inventory
	{
		// Token: 0x17000172 RID: 370
		// (get) Token: 0x06000644 RID: 1604 RVA: 0x0001663E File Offset: 0x0001483E
		public override Inventory.Entry Root
		{
			get
			{
				return new SplineInventory.Entry(Binding.FCE_Inventory_Spline_GetRoot());
			}
		}

		// Token: 0x17000173 RID: 371
		// (get) Token: 0x06000645 RID: 1605 RVA: 0x0001664F File Offset: 0x0001484F
		public static SplineInventory Instance
		{
			get
			{
				return SplineInventory.s_instance;
			}
		}

		// Token: 0x04000284 RID: 644
		private static SplineInventory s_instance = new SplineInventory();

		// Token: 0x02000096 RID: 150
		public new class Entry : Inventory.Entry
		{
			// Token: 0x06000648 RID: 1608 RVA: 0x0001666A File Offset: 0x0001486A
			public Entry(IntPtr ptr) : base(ptr)
			{
			}

			// Token: 0x17000174 RID: 372
			// (get) Token: 0x06000649 RID: 1609 RVA: 0x00016673 File Offset: 0x00014873
			public override ImageSource Icon
			{
				get
				{
					return (base.IsDirectory ? "icons/folder.png" : "icons/object.png").GetImageSource();
				}
			}

			// Token: 0x17000175 RID: 373
			// (get) Token: 0x0600064A RID: 1610 RVA: 0x0001668E File Offset: 0x0001488E
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

			// Token: 0x17000176 RID: 374
			// (get) Token: 0x0600064B RID: 1611 RVA: 0x000166A3 File Offset: 0x000148A3
			// (set) Token: 0x0600064C RID: 1612 RVA: 0x000166BA File Offset: 0x000148BA
			public override string DisplayName
			{
				get
				{
					return Marshal.PtrToStringUni(Binding.FCE_Inventory_Spline_GetDisplay(this.m_entryPtr));
				}
				set
				{
				}
			}

			// Token: 0x17000177 RID: 375
			// (get) Token: 0x0600064D RID: 1613 RVA: 0x000166BC File Offset: 0x000148BC
			// (set) Token: 0x0600064E RID: 1614 RVA: 0x000166D3 File Offset: 0x000148D3
			public override Inventory.Entry Parent
			{
				get
				{
					return new SplineInventory.Entry(Binding.FCE_Inventory_Spline_GetParent(this.m_entryPtr));
				}
				set
				{
				}
			}

			// Token: 0x17000178 RID: 376
			// (get) Token: 0x0600064F RID: 1615 RVA: 0x000166D5 File Offset: 0x000148D5
			public override int Count
			{
				get
				{
					return Binding.FCE_Inventory_Spline_GetChildCount(this.m_entryPtr);
				}
			}

			// Token: 0x17000179 RID: 377
			// (get) Token: 0x06000650 RID: 1616 RVA: 0x000166E8 File Offset: 0x000148E8
			public override Inventory.Entry[] Children
			{
				get
				{
					int count = this.Count;
					Inventory.Entry[] array = new Inventory.Entry[count];
					for (int i = 0; i < count; i++)
					{
						array[i] = new SplineInventory.Entry(Binding.FCE_Inventory_Spline_GetChild(this.m_entryPtr, i));
					}
					return array;
				}
			}

			// Token: 0x1700017A RID: 378
			// (get) Token: 0x06000651 RID: 1617 RVA: 0x00016729 File Offset: 0x00014929
			public float DefaultWidth
			{
				get
				{
					return Binding.FCE_Inventory_Spline_GetDefaultWidth(this.m_entryPtr);
				}
			}

			// Token: 0x04000285 RID: 645
			public static SplineInventory.Entry Null = new SplineInventory.Entry(IntPtr.Zero);
		}
	}
}
