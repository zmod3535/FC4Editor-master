using System;
using System.Drawing;
using System.Windows.Forms;

namespace Divelements.SandGrid
{
	// Token: 0x02000012 RID: 18
	public abstract class FocusableGridElement : GridElement
	{
		// Token: 0x060002BE RID: 702
		protected internal abstract bool AdvanceFocus(FocusAdvanceDirection direction, FocusAdvanceMethod method, int steps, bool loop);

		// Token: 0x060002BF RID: 703 RVA: 0x00012138 File Offset: 0x00011138
		public void AdvanceFocus(FocusAdvanceDirection direction)
		{
			this.AdvanceFocus(direction, FocusAdvanceMethod.MoveSelection, 1, false);
		}

		// Token: 0x060002C0 RID: 704 RVA: 0x00012148 File Offset: 0x00011148
		internal virtual void x0b035f832721de35()
		{
			base.Grid.x2f8a63bfec1c0c0f(this);
		}

		// Token: 0x060002C1 RID: 705
		public abstract FocusableGridElement GetNextElement(FocusAdvanceDirection direction, bool loop, out bool exposedFurtherElements);

		// Token: 0x060002C2 RID: 706 RVA: 0x00012158 File Offset: 0x00011158
		public FocusableGridElement GetNextElement(FocusAdvanceDirection direction)
		{
			bool flag;
			return this.GetNextElement(direction, false, out flag);
		}

		// Token: 0x060002C3 RID: 707 RVA: 0x00012170 File Offset: 0x00011170
		protected internal virtual void OnEnter()
		{
			base.RedrawNeeded();
		}

		// Token: 0x060002C4 RID: 708 RVA: 0x00012178 File Offset: 0x00011178
		protected internal virtual void OnLeave()
		{
			base.RedrawNeeded();
		}

		// Token: 0x060002C5 RID: 709
		public abstract void SelectBlock(FocusableGridElement startElement, FocusableGridElement toElement);

		// Token: 0x060002C6 RID: 710 RVA: 0x00012180 File Offset: 0x00011180
		protected internal override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			if (e.Button == MouseButtons.Left && this.x347356f8d21c1dbf)
			{
				Rectangle rectangle = new Rectangle(this.x47e21e460a22281a, Size.Empty);
				rectangle.Inflate(SystemInformation.DragSize.Width, SystemInformation.DragSize.Height);
				if (rectangle.Contains(e.X, e.Y))
				{
					base.Grid.x614e783eda4ed71f();
					base.Grid.SelectedElements.Clear();
					base.Selected = true;
					base.Grid.x06727b7d4fe7a302();
				}
			}
			if (e.Button == MouseButtons.Left && base.Grid.SandGrid != null && base.Grid.SandGrid.MouseEditing == MouseEditMode.DelayedSingleClick && !this.x9d212e4f44290d63 && base.Selected && Control.ModifierKeys == Keys.None && base.Bounds.Contains(e.X, e.Y))
			{
				this.x0c44cc8270354ceb(e);
			}
		}

		// Token: 0x060002C7 RID: 711 RVA: 0x00012288 File Offset: 0x00011288
		internal virtual void x0c44cc8270354ceb(MouseEventArgs xfbf34718e704c6bc)
		{
		}

		// Token: 0x060002C8 RID: 712 RVA: 0x0001228C File Offset: 0x0001128C
		protected internal override void OnMouseDoubleClick(MouseEventArgs e)
		{
			this.x9d212e4f44290d63 = true;
			base.OnMouseDoubleClick(e);
		}

		// Token: 0x060002C9 RID: 713 RVA: 0x0001229C File Offset: 0x0001129C
		protected internal override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			this.x347356f8d21c1dbf = false;
			this.x9d212e4f44290d63 = !base.Grid.SandGrid.Focused;
			if (!base.Grid.SandGrid.Focused)
			{
				base.Grid.SandGrid.Focus();
			}
			if (base.Grid == null)
			{
				return;
			}
			this.SelectWithMouseButton(e);
		}

		// Token: 0x060002CA RID: 714 RVA: 0x00012304 File Offset: 0x00011304
		protected virtual void SelectWithMouseButton(MouseEventArgs e)
		{
			bool flag = (Control.ModifierKeys & Keys.Shift) == Keys.Shift;
			bool flag2 = (Control.ModifierKeys & Keys.Control) == Keys.Control;
			InnerGrid grid = base.Grid;
			grid.x614e783eda4ed71f();
			try
			{
				if (base.Grid.AllowMultipleSelection)
				{
					goto IL_17F;
				}
				goto IL_DE;
				IL_48:
				this.x347356f8d21c1dbf = true;
				this.x47e21e460a22281a = new Point(e.X, e.Y);
				IL_66:
				this.x9d212e4f44290d63 = true;
				base.Grid.SandGrid.xf023f44afe4ba919 = this;
				IL_7E:
				this.x9d212e4f44290d63 = (this.x9d212e4f44290d63 || base.Grid.SandGrid.ActiveGrid != base.Grid);
				base.Grid.SandGrid.FocusedElement = this;
				if (!false)
				{
					goto IL_232;
				}
				bool flag3 = (flag2 ? 1U : 0U) + (flag ? 1U : 0U) < 0U;
				if (!flag3)
				{
					goto IL_17F;
				}
				IL_DC:
				goto IL_7E;
				IL_DE:
				if (base.Grid.AllowMultipleSelection && flag2 && e.Button == MouseButtons.Left)
				{
					base.Selected = !base.Selected;
					this.x9d212e4f44290d63 = true;
					base.Grid.SandGrid.xf023f44afe4ba919 = this;
				}
				else if (base.Grid.SelectedElements.Count == 1 && base.Selected)
				{
					base.Grid.SandGrid.xf023f44afe4ba919 = this;
				}
				else
				{
					if (!base.Selected)
					{
						base.Grid.SelectedElements.Clear();
						base.Selected = true;
						goto IL_66;
					}
					goto IL_48;
				}
				IL_153:
				goto IL_7E;
				IL_17F:
				if (!flag)
				{
					goto IL_DE;
				}
				if (((flag2 ? 1U : 0U) | 255U) == 0U)
				{
					goto IL_153;
				}
				if (e.Button != MouseButtons.Left)
				{
					goto IL_DE;
				}
				FocusableGridElement focusableGridElement;
				if (flag2)
				{
					focusableGridElement = base.Grid.SandGrid.FocusedElement;
				}
				else
				{
					focusableGridElement = base.Grid.SandGrid.xf023f44afe4ba919;
				}
				if (focusableGridElement != null && focusableGridElement.Grid == base.Grid)
				{
					if (!flag2)
					{
						base.Grid.SelectedElements.Clear();
					}
					this.SelectBlock(focusableGridElement, this);
					flag3 = ((flag2 ? 1U : 0U) - (flag ? 1U : 0U) > uint.MaxValue);
					if (!flag3)
					{
						goto IL_DC;
					}
					flag3 = ((flag ? 1U : 0U) > uint.MaxValue);
					if (!flag3)
					{
						goto IL_48;
					}
				}
				IL_232:;
			}
			finally
			{
				grid.x06727b7d4fe7a302();
			}
		}

		// Token: 0x040000A6 RID: 166
		private bool x9d212e4f44290d63;

		// Token: 0x040000A7 RID: 167
		private bool x347356f8d21c1dbf;

		// Token: 0x040000A8 RID: 168
		private Point x47e21e460a22281a;
	}
}
