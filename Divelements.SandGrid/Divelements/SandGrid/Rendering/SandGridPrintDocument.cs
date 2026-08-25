using System;
using System.ComponentModel;
using System.Drawing.Printing;

namespace Divelements.SandGrid.Rendering
{
	// Token: 0x02000053 RID: 83
	[ToolboxItem(false)]
	public class SandGridPrintDocument : PrintDocument
	{
		// Token: 0x0600053E RID: 1342 RVA: 0x0001B5A4 File Offset: 0x0001A5A4
		internal SandGridPrintDocument(SandGridBase sandGrid)
		{
			this.xaf05a2aec36f5b1b = sandGrid;
		}

		// Token: 0x0600053F RID: 1343 RVA: 0x0001B5B4 File Offset: 0x0001A5B4
		protected override void OnBeginPrint(PrintEventArgs e)
		{
			base.OnBeginPrint(e);
			this.x2b1e52ef43940db7 = this.xaf05a2aec36f5b1b.UseCompatibleTextRendering;
			this.xaf05a2aec36f5b1b.UseCompatibleTextRendering = true;
			IndependentText.xc50a22da327d908e = true;
			SandGridPrintDocument.x3d11e516f9ed38e7 = true;
			this.x77628737d203d4ed = 0;
		}

		// Token: 0x06000540 RID: 1344 RVA: 0x0001B5F0 File Offset: 0x0001A5F0
		protected override void OnEndPrint(PrintEventArgs e)
		{
			base.OnEndPrint(e);
			this.xaf05a2aec36f5b1b.UseCompatibleTextRendering = this.x2b1e52ef43940db7;
			SandGridPrintDocument.x3d11e516f9ed38e7 = false;
		}

		// Token: 0x06000541 RID: 1345 RVA: 0x0001B610 File Offset: 0x0001A610
		protected override void OnPrintPage(PrintPageEventArgs e)
		{
			base.OnPrintPage(e);
			RenderingContext x0f7b23d1c393aed = this.xaf05a2aec36f5b1b.PrimaryGrid.xd916e3d12d2ec8e1(e.Graphics, true, this.x77628737d203d4ed, int.MaxValue);
			e.Graphics.SetClip(e.MarginBounds);
			float num = 1f;
			if (this.ShrinkToFit && this.xaf05a2aec36f5b1b.PrimaryGrid.Bounds.Width > e.MarginBounds.Width)
			{
				num = (float)e.MarginBounds.Width / (float)this.xaf05a2aec36f5b1b.PrimaryGrid.Bounds.Width;
			}
			e.Graphics.TranslateTransform((float)e.MarginBounds.Left, (float)(e.MarginBounds.Top - this.x77628737d203d4ed));
			e.Graphics.ScaleTransform(num, num);
			x9c22e59a9d485e4d x9c22e59a9d485e4d = this.xaf05a2aec36f5b1b.PrimaryGrid.x7f63857195e5d213(x0f7b23d1c393aed);
			this.xaf05a2aec36f5b1b.PrimaryGrid.xa773e3fe39c24b95(x0f7b23d1c393aed);
			this.x77628737d203d4ed += e.MarginBounds.Height - this.xaf05a2aec36f5b1b.PrimaryGrid.x5d332e6bd470be29;
			e.Graphics.ResetTransform();
			e.Graphics.TranslateTransform((float)e.MarginBounds.Left, (float)e.MarginBounds.Top);
			e.Graphics.ScaleTransform(num, num);
			this.xaf05a2aec36f5b1b.PrimaryGrid.xe38b34b4ef5b24ed(x0f7b23d1c393aed);
			this.xaf05a2aec36f5b1b.PrimaryGrid.xa1c45a8b0a8e79d9(x0f7b23d1c393aed);
			e.HasMorePages = ((float)x9c22e59a9d485e4d.x78e5b86be0df3240 > (float)this.x77628737d203d4ed / num);
		}

		// Token: 0x1700014E RID: 334
		// (get) Token: 0x06000542 RID: 1346 RVA: 0x0001B7C8 File Offset: 0x0001A7C8
		// (set) Token: 0x06000543 RID: 1347 RVA: 0x0001B7D0 File Offset: 0x0001A7D0
		public bool ShrinkToFit
		{
			get
			{
				return this.x42de7b1390e79e90;
			}
			set
			{
				this.x42de7b1390e79e90 = value;
			}
		}

		// Token: 0x040001E0 RID: 480
		private SandGridBase xaf05a2aec36f5b1b;

		// Token: 0x040001E1 RID: 481
		private int x77628737d203d4ed;

		// Token: 0x040001E2 RID: 482
		private bool x42de7b1390e79e90;

		// Token: 0x040001E3 RID: 483
		private bool x2b1e52ef43940db7;

		// Token: 0x040001E4 RID: 484
		internal static bool x3d11e516f9ed38e7;
	}
}
