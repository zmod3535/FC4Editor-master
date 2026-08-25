using System;
using System.Runtime.InteropServices;
using System.Windows.Media;
using IGE.Helpers;

namespace IGE.Nomad
{
	// Token: 0x02000091 RID: 145
	internal class TextureInventory : Inventory
	{
		// Token: 0x17000162 RID: 354
		// (get) Token: 0x06000627 RID: 1575 RVA: 0x00016432 File Offset: 0x00014632
		public override Inventory.Entry Root
		{
			get
			{
				return new TextureInventory.Entry(Binding.FCE_Inventory_Texture_GetRoot());
			}
		}

		// Token: 0x17000163 RID: 355
		// (get) Token: 0x06000628 RID: 1576 RVA: 0x00016443 File Offset: 0x00014643
		public static TextureInventory Instance
		{
			get
			{
				return TextureInventory.s_instance;
			}
		}

		// Token: 0x04000280 RID: 640
		private static TextureInventory s_instance = new TextureInventory();

		// Token: 0x02000092 RID: 146
		public new class Entry : Inventory.Entry
		{
			// Token: 0x0600062B RID: 1579 RVA: 0x0001645E File Offset: 0x0001465E
			public Entry(IntPtr ptr) : base(ptr)
			{
			}

			// Token: 0x17000164 RID: 356
			// (get) Token: 0x0600062C RID: 1580 RVA: 0x00016467 File Offset: 0x00014667
			public override ImageSource Icon
			{
				get
				{
					return (base.IsDirectory ? "icons/folder.png" : "icons/object.png").GetImageSource();
				}
			}

			// Token: 0x17000165 RID: 357
			// (get) Token: 0x0600062D RID: 1581 RVA: 0x00016482 File Offset: 0x00014682
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

			// Token: 0x17000166 RID: 358
			// (get) Token: 0x0600062E RID: 1582 RVA: 0x00016497 File Offset: 0x00014697
			// (set) Token: 0x0600062F RID: 1583 RVA: 0x000164AE File Offset: 0x000146AE
			public override string DisplayName
			{
				get
				{
					return Marshal.PtrToStringUni(Binding.FCE_Inventory_Texture_GetDisplay(this.m_entryPtr));
				}
				set
				{
				}
			}

			// Token: 0x17000167 RID: 359
			// (get) Token: 0x06000630 RID: 1584 RVA: 0x000164B0 File Offset: 0x000146B0
			// (set) Token: 0x06000631 RID: 1585 RVA: 0x000164C7 File Offset: 0x000146C7
			public override Inventory.Entry Parent
			{
				get
				{
					return new TextureInventory.Entry(Binding.FCE_Inventory_Texture_GetParent(this.m_entryPtr));
				}
				set
				{
				}
			}

			// Token: 0x17000168 RID: 360
			// (get) Token: 0x06000632 RID: 1586 RVA: 0x000164C9 File Offset: 0x000146C9
			public override int Count
			{
				get
				{
					return Binding.FCE_Inventory_Texture_GetChildCount(this.m_entryPtr);
				}
			}

			// Token: 0x17000169 RID: 361
			// (get) Token: 0x06000633 RID: 1587 RVA: 0x000164DC File Offset: 0x000146DC
			public override Inventory.Entry[] Children
			{
				get
				{
					int count = this.Count;
					Inventory.Entry[] array = new Inventory.Entry[count];
					for (int i = 0; i < count; i++)
					{
						array[i] = new TextureInventory.Entry(Binding.FCE_Inventory_Texture_GetChild(this.m_entryPtr, i));
					}
					return array;
				}
			}

			// Token: 0x04000281 RID: 641
			public static TextureInventory.Entry Null = new TextureInventory.Entry(IntPtr.Zero);
		}
	}
}
