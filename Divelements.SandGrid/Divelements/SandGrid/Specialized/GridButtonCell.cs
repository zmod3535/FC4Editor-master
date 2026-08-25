using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Divelements.SandGrid.Rendering;

namespace Divelements.SandGrid.Specialized
{
	// Token: 0x02000098 RID: 152
	public class GridButtonCell : InteractiveGridCell
	{
		// Token: 0x060006DD RID: 1757 RVA: 0x00022ECC File Offset: 0x00021ECC
		public GridButtonCell()
		{
			this.x13ebc58426767551 = new Padding(1);
		}

		// Token: 0x060006DE RID: 1758 RVA: 0x00022EE0 File Offset: 0x00021EE0
		public GridButtonCell(string text) : this()
		{
			this.Text = text;
		}

		// Token: 0x060006DF RID: 1759 RVA: 0x00022EF0 File Offset: 0x00021EF0
		protected internal override void Draw(RenderingContext context, Font rowFont, bool rowSelected, TextFormattingInformation textFormat)
		{
			if (base.BackColor != Color.Transparent)
			{
				using (SolidBrush solidBrush = new SolidBrush(base.BackColor))
				{
					context.Graphics.FillRectangle(solidBrush, base.Bounds);
				}
			}
			if (base.DrawButton)
			{
				Rectangle buttonBounds = this.GetButtonBounds();
				PushButtonState state;
				if (base.Pressed)
				{
					state = PushButtonState.Pressed;
				}
				else if (base.Hover)
				{
					state = PushButtonState.Hot;
				}
				else
				{
					state = PushButtonState.Normal;
				}
				ButtonRenderer.DrawButton(context.Graphics, buttonBounds, this.Text, base.Font, textFormat.TextFormatFlags, base.Grid.SandGrid.FocusedElement == this, state);
			}
		}

		// Token: 0x060006E0 RID: 1760 RVA: 0x00022FB4 File Offset: 0x00021FB4
		protected override Rectangle GetButtonBounds()
		{
			Rectangle contentBounds = base.ContentBounds;
			contentBounds.X += this.x13ebc58426767551.Left;
			contentBounds.Y += this.x13ebc58426767551.Top;
			contentBounds.Width -= this.x13ebc58426767551.Left + this.x13ebc58426767551.Right;
			contentBounds.Height -= this.x13ebc58426767551.Top + this.x13ebc58426767551.Bottom;
			return contentBounds;
		}

		// Token: 0x170001B2 RID: 434
		// (get) Token: 0x060006E1 RID: 1761 RVA: 0x00023048 File Offset: 0x00022048
		// (set) Token: 0x060006E2 RID: 1762 RVA: 0x00023050 File Offset: 0x00022050
		[Category("Layout")]
		public Padding Margin
		{
			get
			{
				return this.x13ebc58426767551;
			}
			set
			{
				this.x13ebc58426767551 = value;
				base.MeasureNeeded();
			}
		}

		// Token: 0x060006E3 RID: 1763 RVA: 0x00023060 File Offset: 0x00022060
		private bool ShouldSerializeMargin()
		{
			return this.Margin != new Padding(1);
		}

		// Token: 0x040002AE RID: 686
		private Padding x13ebc58426767551;
	}
}
