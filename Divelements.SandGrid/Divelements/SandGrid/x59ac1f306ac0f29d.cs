using System;
using System.Drawing;
using System.Windows.Forms;

namespace Divelements.SandGrid
{
	// Token: 0x02000023 RID: 35
	internal abstract class x59ac1f306ac0f29d
	{
		// Token: 0x060003DC RID: 988 RVA: 0x00016850 File Offset: 0x00015850
		protected x59ac1f306ac0f29d(GridElement element, Point startPoint)
		{
			this.x4bbc2c453c470189 = element;
			this.xcb09bd0cee4909a3 = startPoint;
		}

		// Token: 0x060003DD RID: 989 RVA: 0x00016870 File Offset: 0x00015870
		protected internal virtual void Finished(Point position, bool cancelled)
		{
		}

		// Token: 0x060003DE RID: 990
		protected internal abstract void MouseMove(MouseEventArgs e);

		// Token: 0x170000FD RID: 253
		// (get) Token: 0x060003DF RID: 991 RVA: 0x00016874 File Offset: 0x00015874
		public GridElement x2dcc7207ee287dbb
		{
			get
			{
				return this.x4bbc2c453c470189;
			}
		}

		// Token: 0x170000FE RID: 254
		// (get) Token: 0x060003E0 RID: 992 RVA: 0x0001687C File Offset: 0x0001587C
		public Point xaf4e0fbe61814cf5
		{
			get
			{
				return this.xcb09bd0cee4909a3;
			}
		}

		// Token: 0x170000FF RID: 255
		// (get) Token: 0x060003E1 RID: 993 RVA: 0x00016884 File Offset: 0x00015884
		public InnerGrid x03bb6a33fcd217b4
		{
			get
			{
				return this.x4bbc2c453c470189.Grid;
			}
		}

		// Token: 0x17000100 RID: 256
		// (get) Token: 0x060003E2 RID: 994 RVA: 0x00016894 File Offset: 0x00015894
		// (set) Token: 0x060003E3 RID: 995 RVA: 0x0001689C File Offset: 0x0001589C
		public bool x7e153dc1ab2f9ad3
		{
			get
			{
				return this.x6ce827af594d68ef;
			}
			set
			{
				this.x6ce827af594d68ef = value;
			}
		}

		// Token: 0x04000123 RID: 291
		private GridElement x4bbc2c453c470189;

		// Token: 0x04000124 RID: 292
		private Point xcb09bd0cee4909a3;

		// Token: 0x04000125 RID: 293
		private bool x6ce827af594d68ef = true;
	}
}
