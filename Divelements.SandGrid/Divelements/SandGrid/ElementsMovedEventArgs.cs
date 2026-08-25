using System;

namespace Divelements.SandGrid
{
	// Token: 0x0200007B RID: 123
	public class ElementsMovedEventArgs : EventArgs
	{
		// Token: 0x0600063C RID: 1596 RVA: 0x00020C14 File Offset: 0x0001FC14
		internal ElementsMovedEventArgs(InnerGrid grid, GridElement[] elements)
		{
			this.x3040c866fac95193 = grid;
			this.x6e96c3657c96bbbe = elements;
		}

		// Token: 0x1700018B RID: 395
		// (get) Token: 0x0600063D RID: 1597 RVA: 0x00020C2C File Offset: 0x0001FC2C
		public InnerGrid Grid
		{
			get
			{
				return this.x3040c866fac95193;
			}
		}

		// Token: 0x1700018C RID: 396
		// (get) Token: 0x0600063E RID: 1598 RVA: 0x00020C34 File Offset: 0x0001FC34
		public GridElement[] Elements
		{
			get
			{
				return this.x6e96c3657c96bbbe;
			}
		}

		// Token: 0x0400026E RID: 622
		private InnerGrid x3040c866fac95193;

		// Token: 0x0400026F RID: 623
		private GridElement[] x6e96c3657c96bbbe;
	}
}
