using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using Divelements.SandGrid.Rendering;
using Divelements.SandGrid.Resources;

namespace Divelements.SandGrid
{
	// Token: 0x02000031 RID: 49
	public class GridGroup : FocusableGridElement
	{
		// Token: 0x0600049A RID: 1178 RVA: 0x00019AD8 File Offset: 0x00018AD8
		internal GridGroup(string text)
		{
			if (text == null)
			{
				throw new ArgumentNullException("text");
			}
			this.xb41faee6912a2313 = text;
		}

		// Token: 0x0600049B RID: 1179 RVA: 0x00019AFC File Offset: 0x00018AFC
		protected internal override bool AdvanceFocus(FocusAdvanceDirection direction, FocusAdvanceMethod method, int steps, bool loop)
		{
			if (direction == FocusAdvanceDirection.Up || direction == FocusAdvanceDirection.Down)
			{
				FocusableGridElement nextElement = base.GetNextElement(direction);
				if (nextElement != null)
				{
					base.Grid.SelectElement(nextElement);
				}
				return true;
			}
			return false;
		}

		// Token: 0x0600049C RID: 1180 RVA: 0x00019B2C File Offset: 0x00018B2C
		public override FocusableGridElement GetNextElement(FocusAdvanceDirection direction, bool loop, out bool exposedFurtherElements)
		{
			exposedFurtherElements = false;
			GridRow gridRow2;
			GridGroup gridGroup2;
			Rectangle bounds;
			if (direction == FocusAdvanceDirection.Down)
			{
				GridRow gridRow = this.xa19781cfbe8b4961.xe0f8497fba2e6972 ? this.xa19781cfbe8b4961 : this.xa19781cfbe8b4961.x2cc76ebec5b074e0();
				GridGroup gridGroup = this.xeeb8ba9d086b79b8(direction);
				if (gridGroup == null)
				{
					return gridRow;
				}
				if (gridRow == null)
				{
					return gridGroup;
				}
				if (gridRow.Bounds.Y < gridGroup.Bounds.Y)
				{
					return gridRow;
				}
				if ((loop ? 1U : 0U) + (loop ? 1U : 0U) >= 0U)
				{
					return gridGroup;
				}
			}
			else
			{
				if (direction != FocusAdvanceDirection.Up)
				{
					return null;
				}
				gridRow2 = this.xa19781cfbe8b4961.x92c0e4f64c084ab1();
				gridGroup2 = this.xeeb8ba9d086b79b8(direction);
				if (gridGroup2 == null)
				{
					return gridRow2;
				}
				if (gridRow2 == null)
				{
					return gridGroup2;
				}
				bounds = gridRow2.Bounds;
			}
			if (bounds.Y <= gridGroup2.Bounds.Y)
			{
				return gridGroup2;
			}
			return gridRow2;
		}

		// Token: 0x0600049D RID: 1181 RVA: 0x00019BF8 File Offset: 0x00018BF8
		private GridGroup xeeb8ba9d086b79b8(FocusAdvanceDirection x23e85093ba3a7d1d)
		{
			int num = (x23e85093ba3a7d1d == FocusAdvanceDirection.Up) ? 0 : int.MaxValue;
			GridGroup gridGroup = null;
			foreach (object obj in base.Grid.Groups)
			{
				GridGroup gridGroup2 = (GridGroup)obj;
				if (gridGroup2 != this && ((x23e85093ba3a7d1d == FocusAdvanceDirection.Up && gridGroup2.Bounds.Y < base.Bounds.Y && gridGroup2.Bounds.Y > num) || (x23e85093ba3a7d1d == FocusAdvanceDirection.Down && gridGroup2.Bounds.Y > base.Bounds.Y && gridGroup2.Bounds.Y < num)))
				{
					gridGroup = gridGroup2;
					num = gridGroup.Bounds.Y;
				}
			}
			return gridGroup;
		}

		// Token: 0x0600049E RID: 1182 RVA: 0x00019CF8 File Offset: 0x00018CF8
		public override void SelectBlock(FocusableGridElement startElement, FocusableGridElement toElement)
		{
		}

		// Token: 0x0600049F RID: 1183 RVA: 0x00019CFC File Offset: 0x00018CFC
		protected override void SelectWithMouseButton(MouseEventArgs e)
		{
			if (base.Grid.GroupHeadingClickBehavior == GroupHeadingClickBehavior.Select)
			{
				base.SelectWithMouseButton(e);
			}
		}

		// Token: 0x060004A0 RID: 1184 RVA: 0x00019D14 File Offset: 0x00018D14
		protected internal virtual void Draw(RenderingContext context)
		{
			if ((base.Selected || context.xf58ff9ce0e24a20c == this) && !context.HideSelection)
			{
				context.Renderer.DrawSelectionRectangle(context.Graphics, base.Bounds, base.Selected, context.ContainsFocus, context.xf58ff9ce0e24a20c == this && context.FocusRectanglesEnabled);
			}
			Divelements.SandGrid.Rendering.DrawItemState drawItemState = Divelements.SandGrid.Rendering.DrawItemState.None;
			if (base.Selected)
			{
				drawItemState |= Divelements.SandGrid.Rendering.DrawItemState.Selected;
			}
			if (base.Hot)
			{
				drawItemState |= Divelements.SandGrid.Rendering.DrawItemState.Hot;
			}
			context.Renderer.DrawGroupHeading(context.Graphics, this, base.Bounds, base.Font, drawItemState, context.x29fd0770898d0daa, context.x7b70952c02a0fb86);
		}

		// Token: 0x060004A1 RID: 1185 RVA: 0x00019DB4 File Offset: 0x00018DB4
		protected internal override void OnMouseDown(MouseEventArgs e)
		{
			if (this.ExpandButtonBounds.Contains(e.X, e.Y) && base.Grid.AllowGroupCollapse)
			{
				this.Expanded = !this.Expanded;
				return;
			}
			base.OnMouseDown(e);
			switch (base.Grid.GroupHeadingClickBehavior)
			{
			case GroupHeadingClickBehavior.SelectAll:
				if (base.Grid.AllowMultipleSelection)
				{
					this.SelectAll();
					return;
				}
				break;
			case GroupHeadingClickBehavior.ExpandCollapse:
				if (base.Grid.AllowGroupCollapse)
				{
					this.Expanded = !this.Expanded;
				}
				break;
			default:
				return;
			}
		}

		// Token: 0x060004A2 RID: 1186 RVA: 0x00019E50 File Offset: 0x00018E50
		protected override void OnHotChanged()
		{
			base.OnHotChanged();
			if (base.Grid != null && base.Grid.SandGrid != null)
			{
				Office2007Renderer office2007Renderer = base.Grid.SandGrid.Renderer as Office2007Renderer;
				if (office2007Renderer != null && office2007Renderer.GroupHeaderStyle == Office2007GroupHeaderStyle.Button)
				{
					base.RedrawNeeded();
				}
			}
		}

		// Token: 0x060004A3 RID: 1187 RVA: 0x00019EA0 File Offset: 0x00018EA0
		protected internal override void OnMouseDoubleClick(MouseEventArgs e)
		{
			if (base.Grid.AllowGroupCollapse && !this.ExpandButtonBounds.Contains(e.X, e.Y))
			{
				this.Expanded = !this.Expanded;
			}
		}

		// Token: 0x060004A4 RID: 1188 RVA: 0x00019EE8 File Offset: 0x00018EE8
		public void SelectAll()
		{
			bool flag = (Control.ModifierKeys & Keys.Shift) == Keys.Shift;
			bool flag2 = (Control.ModifierKeys & Keys.Control) == Keys.Control;
			GridRow[] rows = this.GetRows();
			bool flag3 = true;
			foreach (GridRow gridRow in rows)
			{
				if (!gridRow.Selected)
				{
					flag3 = false;
					break;
				}
			}
			base.Grid.x614e783eda4ed71f();
			try
			{
				if (!flag && !flag2)
				{
					base.Grid.SelectedElements.Clear();
				}
				if (flag3 && flag2)
				{
					base.Grid.x12a83acc7c1ca827(rows, false);
				}
				else
				{
					base.Grid.x12a83acc7c1ca827(rows, true);
				}
			}
			finally
			{
				base.Grid.x06727b7d4fe7a302();
			}
		}

		// Token: 0x17000126 RID: 294
		// (get) Token: 0x060004A5 RID: 1189 RVA: 0x00019FBC File Offset: 0x00018FBC
		public Rectangle ExpandButtonBounds
		{
			get
			{
				if (base.Grid != null && base.Grid.SandGrid != null)
				{
					return base.Grid.SandGrid.Renderer.CalculateGroupHeadingExpandButtonBounds(this);
				}
				return Rectangle.Empty;
			}
		}

		// Token: 0x060004A6 RID: 1190 RVA: 0x00019FF0 File Offset: 0x00018FF0
		public GridRow[] GetRows()
		{
			if (this.xa19781cfbe8b4961 == null)
			{
				throw new InvalidOperationException(xf1a67b6a145d2603.x538d63a1354c16f2("ExceptionGroupNoRow"));
			}
			ArrayList arrayList = new ArrayList();
			GridRow gridRow = this.xa19781cfbe8b4961;
			while (gridRow != null && gridRow.Group == this)
			{
				arrayList.Add(gridRow);
				gridRow = gridRow.xa4c746a623bbf4f4(true);
			}
			return (GridRow[])arrayList.ToArray(typeof(GridRow));
		}

		// Token: 0x17000127 RID: 295
		// (get) Token: 0x060004A7 RID: 1191 RVA: 0x0001A058 File Offset: 0x00019058
		internal GridRow xa19781cfbe8b4961
		{
			get
			{
				return this.xa806b754814b9ae0;
			}
		}

		// Token: 0x17000128 RID: 296
		// (get) Token: 0x060004A8 RID: 1192 RVA: 0x0001A060 File Offset: 0x00019060
		internal GridRow xc22e54d85f137f3e
		{
			get
			{
				return this.xafdad421dc58a810;
			}
		}

		// Token: 0x060004A9 RID: 1193 RVA: 0x0001A068 File Offset: 0x00019068
		internal void x560d4dfd1783eedd(GridRow xa806b754814b9ae0, GridRow xafdad421dc58a810)
		{
			this.xa806b754814b9ae0 = xa806b754814b9ae0;
			this.xafdad421dc58a810 = xafdad421dc58a810;
		}

		// Token: 0x17000129 RID: 297
		// (get) Token: 0x060004AA RID: 1194 RVA: 0x0001A078 File Offset: 0x00019078
		public string Text
		{
			get
			{
				return this.xb41faee6912a2313;
			}
		}

		// Token: 0x1700012A RID: 298
		// (get) Token: 0x060004AB RID: 1195 RVA: 0x0001A080 File Offset: 0x00019080
		// (set) Token: 0x060004AC RID: 1196 RVA: 0x0001A088 File Offset: 0x00019088
		public bool Expanded
		{
			get
			{
				return this.x71ac7ec13c0d5285;
			}
			set
			{
				if (value != this.x71ac7ec13c0d5285)
				{
					if (base.Grid != null)
					{
						if (value)
						{
							this.x5f56404254a8b9b2();
						}
						else
						{
							this.x09be9a9580e1055f();
						}
					}
					this.x71ac7ec13c0d5285 = value;
					if (base.Grid != null)
					{
						if (value)
						{
							this.x9b232c6f94ab059d();
						}
						else
						{
							this.x2c3f3696d21dbfab();
						}
						base.Grid.MeasureNeeded();
					}
				}
			}
		}

		// Token: 0x060004AD RID: 1197 RVA: 0x0001A0E4 File Offset: 0x000190E4
		private void x530a591976340ded()
		{
			if (base.Grid != null)
			{
				base.Grid.Rows.x7f80f55d120d7028();
			}
		}

		// Token: 0x060004AE RID: 1198 RVA: 0x0001A100 File Offset: 0x00019100
		private void x5f56404254a8b9b2()
		{
			this.x530a591976340ded();
		}

		// Token: 0x060004AF RID: 1199 RVA: 0x0001A108 File Offset: 0x00019108
		private void x9b232c6f94ab059d()
		{
		}

		// Token: 0x060004B0 RID: 1200 RVA: 0x0001A10C File Offset: 0x0001910C
		private void x09be9a9580e1055f()
		{
			this.x530a591976340ded();
			this.x03da85ad2fcfe94e = this.GetRows();
		}

		// Token: 0x060004B1 RID: 1201 RVA: 0x0001A120 File Offset: 0x00019120
		private void x2c3f3696d21dbfab()
		{
			foreach (GridRow gridRow in this.x03da85ad2fcfe94e)
			{
				gridRow.x0b035f832721de35();
			}
			this.x03da85ad2fcfe94e = null;
		}

		// Token: 0x04000164 RID: 356
		private GridRow xa806b754814b9ae0;

		// Token: 0x04000165 RID: 357
		private GridRow xafdad421dc58a810;

		// Token: 0x04000166 RID: 358
		private string xb41faee6912a2313;

		// Token: 0x04000167 RID: 359
		private bool x71ac7ec13c0d5285 = true;

		// Token: 0x04000168 RID: 360
		private GridRow[] x03da85ad2fcfe94e;
	}
}
