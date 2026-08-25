using System;
using System.Collections;

namespace TD.SandBar
{
	// Token: 0x0200003D RID: 61
	internal class xf00666a2552f1592
	{
		// Token: 0x0600035A RID: 858 RVA: 0x00010F1C File Offset: 0x0000FF1C
		private xf00666a2552f1592()
		{
		}

		// Token: 0x0600035B RID: 859 RVA: 0x00010F24 File Offset: 0x0000FF24
		private xf00666a2552f1592(ToolbarItemBase item)
		{
			this.xccb63ca5f63dc470 = item;
		}

		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x0600035C RID: 860 RVA: 0x00010F34 File Offset: 0x0000FF34
		public bool xf303b4c014a7017b
		{
			get
			{
				return this.xf8b54ce7724a27f2 != null && this.xf8b54ce7724a27f2.Count != 0;
			}
		}

		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x0600035D RID: 861 RVA: 0x00010F54 File Offset: 0x0000FF54
		public ToolbarItemBase xe6d4b1b411ed94b5
		{
			get
			{
				return this.xccb63ca5f63dc470;
			}
		}

		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x0600035E RID: 862 RVA: 0x00010F5C File Offset: 0x0000FF5C
		public ArrayList xe0d5f9fb50308841
		{
			get
			{
				if (this.xf8b54ce7724a27f2 == null)
				{
					this.xf8b54ce7724a27f2 = new ArrayList();
				}
				return this.xf8b54ce7724a27f2;
			}
		}

		// Token: 0x0600035F RID: 863 RVA: 0x00010F78 File Offset: 0x0000FF78
		public void xbe2cb8264b39a622(ToolbarItemBaseCollection x3a0a6392259b19fe)
		{
			x3a0a6392259b19fe.Clear();
			ToolbarItemBase[] array = new ToolbarItemBase[this.xe0d5f9fb50308841.Count];
			for (int i = 0; i < array.Length; i++)
			{
				xf00666a2552f1592 xf00666a2552f = (xf00666a2552f1592)this.xe0d5f9fb50308841[i];
				array[i] = xf00666a2552f.xe6d4b1b411ed94b5;
				if (xf00666a2552f.xf303b4c014a7017b)
				{
					xf00666a2552f.xbe2cb8264b39a622(((MenuItemBase)array[i]).Items);
				}
			}
			x3a0a6392259b19fe.AddRange(array);
		}

		// Token: 0x06000360 RID: 864 RVA: 0x00010FE8 File Offset: 0x0000FFE8
		public static xf00666a2552f1592 xf97071ef9bf45fdf(IToolBarItemBaseCollectionHost x071bde1041617fce)
		{
			xf00666a2552f1592 xf00666a2552f = new xf00666a2552f1592();
			xf00666a2552f1592.xf9e4610d96590233(xf00666a2552f, x071bde1041617fce.Items);
			return xf00666a2552f;
		}

		// Token: 0x06000361 RID: 865 RVA: 0x00011008 File Offset: 0x00010008
		private static void xf9e4610d96590233(xf00666a2552f1592 xbad297e497c37b6c, ToolbarItemBaseCollection x38663035568a04c9)
		{
			xf00666a2552f1592[] array = new xf00666a2552f1592[x38663035568a04c9.Count];
			for (int i = 0; i < x38663035568a04c9.Count; i++)
			{
				array[i] = new xf00666a2552f1592(x38663035568a04c9[i]);
				if (x38663035568a04c9[i] is IToolBarItemBaseCollectionHost)
				{
					xf00666a2552f1592.xf9e4610d96590233(array[i], ((IToolBarItemBaseCollectionHost)x38663035568a04c9[i]).Items);
				}
			}
			xbad297e497c37b6c.xe0d5f9fb50308841.AddRange(array);
		}

		// Token: 0x04000133 RID: 307
		private ArrayList xf8b54ce7724a27f2;

		// Token: 0x04000134 RID: 308
		private ToolbarItemBase xccb63ca5f63dc470;
	}
}
