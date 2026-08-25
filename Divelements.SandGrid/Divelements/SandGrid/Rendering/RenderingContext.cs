using System;
using System.Drawing;

namespace Divelements.SandGrid.Rendering
{
	// Token: 0x0200003B RID: 59
	public class RenderingContext
	{
		// Token: 0x060004C8 RID: 1224 RVA: 0x0001A8AC File Offset: 0x000198AC
		internal RenderingContext(Graphics graphics, ISandGridRenderer renderer, bool printing, Font font, bool containsFocus, bool focusRectanglesEnabled, GridRow rowWithFocus, GridCell cellWithFocus, bool hideSelection, Pen gridLinePen, int noPaintBeforeY, int noPaintAfterY)
		{
			this.x41347a961b838962 = graphics;
			this.x38870620fd380a6b = renderer;
			this.x21495198a04e77be = printing;
			this.x26094932cf7a9139 = font;
			this.xd34ff54c5dd91133 = containsFocus;
			this.x7baf0f76fbae6a58 = focusRectanglesEnabled;
			this.x3465315f462d0acf = rowWithFocus;
			this.xb1310922036bec04 = cellWithFocus;
			this.x93ef78fd87a99a3c = hideSelection;
			this.x13c06dc1e5fc0ccc = gridLinePen;
			this.xafa125fec9c28c53 = noPaintBeforeY;
			this.xf61c42a5d8298218 = noPaintAfterY;
		}

		// Token: 0x1700012F RID: 303
		// (get) Token: 0x060004C9 RID: 1225 RVA: 0x0001A91C File Offset: 0x0001991C
		internal GridElement xf58ff9ce0e24a20c
		{
			get
			{
				return this.x9fde6943eed61cee;
			}
		}

		// Token: 0x060004CA RID: 1226 RVA: 0x0001A924 File Offset: 0x00019924
		internal void xde71c10cc59cfe08(FocusableGridElement x4bbc2c453c470189)
		{
			this.x9fde6943eed61cee = x4bbc2c453c470189;
		}

		// Token: 0x17000130 RID: 304
		// (get) Token: 0x060004CB RID: 1227 RVA: 0x0001A930 File Offset: 0x00019930
		// (set) Token: 0x060004CC RID: 1228 RVA: 0x0001A938 File Offset: 0x00019938
		internal int x540a99e0b172a09e
		{
			get
			{
				return this.xafa125fec9c28c53;
			}
			set
			{
				this.xafa125fec9c28c53 = value;
			}
		}

		// Token: 0x17000131 RID: 305
		// (get) Token: 0x060004CD RID: 1229 RVA: 0x0001A944 File Offset: 0x00019944
		// (set) Token: 0x060004CE RID: 1230 RVA: 0x0001A94C File Offset: 0x0001994C
		internal int xc59eabb55ae986f8
		{
			get
			{
				return this.xf61c42a5d8298218;
			}
			set
			{
				this.xf61c42a5d8298218 = value;
			}
		}

		// Token: 0x17000132 RID: 306
		// (get) Token: 0x060004CF RID: 1231 RVA: 0x0001A958 File Offset: 0x00019958
		public Pen GridLinePen
		{
			get
			{
				return this.x13c06dc1e5fc0ccc;
			}
		}

		// Token: 0x17000133 RID: 307
		// (get) Token: 0x060004D0 RID: 1232 RVA: 0x0001A960 File Offset: 0x00019960
		// (set) Token: 0x060004D1 RID: 1233 RVA: 0x0001A968 File Offset: 0x00019968
		internal GridColumn[] x29fd0770898d0daa
		{
			get
			{
				return this.xcc5602389899eb48;
			}
			set
			{
				this.xcc5602389899eb48 = value;
			}
		}

		// Token: 0x17000134 RID: 308
		// (get) Token: 0x060004D2 RID: 1234 RVA: 0x0001A974 File Offset: 0x00019974
		// (set) Token: 0x060004D3 RID: 1235 RVA: 0x0001A97C File Offset: 0x0001997C
		internal TextFormattingInformation[] x7b70952c02a0fb86
		{
			get
			{
				return this.x097e90c41a6023bf;
			}
			set
			{
				this.x097e90c41a6023bf = value;
			}
		}

		// Token: 0x17000135 RID: 309
		// (get) Token: 0x060004D4 RID: 1236 RVA: 0x0001A988 File Offset: 0x00019988
		public bool Printing
		{
			get
			{
				return this.x21495198a04e77be;
			}
		}

		// Token: 0x17000136 RID: 310
		// (get) Token: 0x060004D5 RID: 1237 RVA: 0x0001A990 File Offset: 0x00019990
		public bool HideSelection
		{
			get
			{
				return this.x93ef78fd87a99a3c;
			}
		}

		// Token: 0x17000137 RID: 311
		// (get) Token: 0x060004D6 RID: 1238 RVA: 0x0001A998 File Offset: 0x00019998
		public ISandGridRenderer Renderer
		{
			get
			{
				return this.x38870620fd380a6b;
			}
		}

		// Token: 0x17000138 RID: 312
		// (get) Token: 0x060004D7 RID: 1239 RVA: 0x0001A9A0 File Offset: 0x000199A0
		public GridRow RowWithFocus
		{
			get
			{
				return this.x3465315f462d0acf;
			}
		}

		// Token: 0x17000139 RID: 313
		// (get) Token: 0x060004D8 RID: 1240 RVA: 0x0001A9A8 File Offset: 0x000199A8
		public GridCell CellWithFocus
		{
			get
			{
				return this.xb1310922036bec04;
			}
		}

		// Token: 0x1700013A RID: 314
		// (get) Token: 0x060004D9 RID: 1241 RVA: 0x0001A9B0 File Offset: 0x000199B0
		public Graphics Graphics
		{
			get
			{
				return this.x41347a961b838962;
			}
		}

		// Token: 0x1700013B RID: 315
		// (get) Token: 0x060004DA RID: 1242 RVA: 0x0001A9B8 File Offset: 0x000199B8
		public Font Font
		{
			get
			{
				return this.x26094932cf7a9139;
			}
		}

		// Token: 0x1700013C RID: 316
		// (get) Token: 0x060004DB RID: 1243 RVA: 0x0001A9C0 File Offset: 0x000199C0
		public bool ContainsFocus
		{
			get
			{
				return this.xd34ff54c5dd91133;
			}
		}

		// Token: 0x1700013D RID: 317
		// (get) Token: 0x060004DC RID: 1244 RVA: 0x0001A9C8 File Offset: 0x000199C8
		public bool FocusRectanglesEnabled
		{
			get
			{
				return this.x7baf0f76fbae6a58;
			}
		}

		// Token: 0x0400018C RID: 396
		private Graphics x41347a961b838962;

		// Token: 0x0400018D RID: 397
		private Font x26094932cf7a9139;

		// Token: 0x0400018E RID: 398
		private bool xd34ff54c5dd91133;

		// Token: 0x0400018F RID: 399
		private bool x7baf0f76fbae6a58;

		// Token: 0x04000190 RID: 400
		private bool x93ef78fd87a99a3c;

		// Token: 0x04000191 RID: 401
		private bool x21495198a04e77be;

		// Token: 0x04000192 RID: 402
		private GridRow x3465315f462d0acf;

		// Token: 0x04000193 RID: 403
		private GridCell xb1310922036bec04;

		// Token: 0x04000194 RID: 404
		private ISandGridRenderer x38870620fd380a6b;

		// Token: 0x04000195 RID: 405
		private Pen x13c06dc1e5fc0ccc;

		// Token: 0x04000196 RID: 406
		private int xafa125fec9c28c53;

		// Token: 0x04000197 RID: 407
		private int xf61c42a5d8298218;

		// Token: 0x04000198 RID: 408
		private FocusableGridElement x9fde6943eed61cee;

		// Token: 0x04000199 RID: 409
		private GridColumn[] xcc5602389899eb48;

		// Token: 0x0400019A RID: 410
		private TextFormattingInformation[] x097e90c41a6023bf;
	}
}
