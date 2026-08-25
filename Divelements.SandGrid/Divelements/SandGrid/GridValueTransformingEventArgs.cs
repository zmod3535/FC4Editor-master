using System;

namespace Divelements.SandGrid
{
	// Token: 0x02000040 RID: 64
	public class GridValueTransformingEventArgs : GridRowColumnEventArgs
	{
		// Token: 0x060004E6 RID: 1254 RVA: 0x0001AB4C File Offset: 0x00019B4C
		internal GridValueTransformingEventArgs(GridRow row, GridColumn column, object value, Type desiredType) : base(row, column)
		{
			this.xbcea506a33cf9111 = value;
			this.x742f2122f737ee25 = desiredType;
		}

		// Token: 0x1700013F RID: 319
		// (get) Token: 0x060004E7 RID: 1255 RVA: 0x0001AB68 File Offset: 0x00019B68
		// (set) Token: 0x060004E8 RID: 1256 RVA: 0x0001AB70 File Offset: 0x00019B70
		public object Value
		{
			get
			{
				return this.xbcea506a33cf9111;
			}
			set
			{
				this.xbcea506a33cf9111 = value;
				this.xf9c91e4f2e63a9ab = true;
			}
		}

		// Token: 0x17000140 RID: 320
		// (get) Token: 0x060004E9 RID: 1257 RVA: 0x0001AB80 File Offset: 0x00019B80
		public Type DesiredType
		{
			get
			{
				return this.x742f2122f737ee25;
			}
		}

		// Token: 0x17000141 RID: 321
		// (get) Token: 0x060004EA RID: 1258 RVA: 0x0001AB88 File Offset: 0x00019B88
		internal bool xe35949838fcd5d1e
		{
			get
			{
				return this.xf9c91e4f2e63a9ab;
			}
		}

		// Token: 0x040001A4 RID: 420
		private object xbcea506a33cf9111;

		// Token: 0x040001A5 RID: 421
		private Type x742f2122f737ee25;

		// Token: 0x040001A6 RID: 422
		private bool xf9c91e4f2e63a9ab;
	}
}
