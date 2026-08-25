using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Divelements.SandGrid.Rendering;

namespace Divelements.SandGrid.Specialized
{
	// Token: 0x0200009D RID: 157
	public class GridCheckBoxCell : InteractiveGridCell
	{
		// Token: 0x0600070C RID: 1804 RVA: 0x00023600 File Offset: 0x00022600
		public GridCheckBoxCell()
		{
			this.Checked = false;
		}

		// Token: 0x0600070D RID: 1805 RVA: 0x0002361C File Offset: 0x0002261C
		protected override void OnClicked()
		{
			base.OnClicked();
			if (base.ParentColumn == null || base.ParentRow == null)
			{
				return;
			}
			switch (this.x85a932c1b6d9d163())
			{
			case CheckState.Unchecked:
				base.SetValue(base.ParentColumn.x9efd48e8072f42ef(base.ParentRow, CheckState.Checked));
				return;
			case CheckState.Checked:
				if (this.x146b5c27ee462394())
				{
					base.SetValue(base.ParentColumn.x9efd48e8072f42ef(base.ParentRow, CheckState.Indeterminate));
					return;
				}
				base.SetValue(base.ParentColumn.x9efd48e8072f42ef(base.ParentRow, CheckState.Unchecked));
				return;
			default:
				base.SetValue(base.ParentColumn.x9efd48e8072f42ef(base.ParentRow, CheckState.Unchecked));
				return;
			}
		}

		// Token: 0x0600070E RID: 1806 RVA: 0x000236D8 File Offset: 0x000226D8
		private bool x146b5c27ee462394()
		{
			GridCheckBoxColumn gridCheckBoxColumn = base.ParentColumn as GridCheckBoxColumn;
			return gridCheckBoxColumn != null && gridCheckBoxColumn.AllowIndeterminate;
		}

		// Token: 0x0600070F RID: 1807 RVA: 0x00023700 File Offset: 0x00022700
		protected internal override void Draw(RenderingContext context, Font rowFont, bool rowSelected, TextFormattingInformation textFormat)
		{
			if (base.BackColor != Color.Transparent)
			{
				using (SolidBrush solidBrush = new SolidBrush(base.BackColor))
				{
					context.Graphics.FillRectangle(solidBrush, base.Bounds);
				}
			}
			if (this.x73a275c1be7f04ab.IsEmpty)
			{
				this.x73a275c1be7f04ab = CheckBoxRenderer.GetGlyphSize(context.Graphics, CheckBoxState.UncheckedNormal);
			}
			if (base.DrawButton)
			{
				Rectangle buttonBounds = this.GetButtonBounds();
				CheckBoxRenderer.DrawCheckBox(context.Graphics, buttonBounds.Location, this.x83f57c5c3d76cefc());
			}
		}

		// Token: 0x06000710 RID: 1808 RVA: 0x000237AC File Offset: 0x000227AC
		private CheckBoxState x83f57c5c3d76cefc()
		{
			switch (this.x85a932c1b6d9d163())
			{
			case CheckState.Unchecked:
				if (base.Pressed)
				{
					return CheckBoxState.UncheckedPressed;
				}
				if (base.Hover)
				{
					return CheckBoxState.UncheckedHot;
				}
				return CheckBoxState.UncheckedNormal;
			case CheckState.Checked:
				if (base.Pressed)
				{
					return CheckBoxState.CheckedPressed;
				}
				if (base.Hover)
				{
					return CheckBoxState.CheckedHot;
				}
				return CheckBoxState.CheckedNormal;
			}
			if (base.Pressed)
			{
				return CheckBoxState.MixedPressed;
			}
			if (base.Hover)
			{
				return CheckBoxState.MixedHot;
			}
			return CheckBoxState.MixedNormal;
		}

		// Token: 0x06000711 RID: 1809 RVA: 0x00023818 File Offset: 0x00022818
		private CheckState x85a932c1b6d9d163()
		{
			if (base.ParentRow != null && base.ParentColumn != null)
			{
				object obj = base.ParentColumn.xf69eb59aa621a379(base.ParentRow, base.GetValue(), typeof(CheckState));
				if (obj is CheckState)
				{
					return (CheckState)obj;
				}
			}
			return CheckState.Indeterminate;
		}

		// Token: 0x06000712 RID: 1810 RVA: 0x00023868 File Offset: 0x00022868
		protected override Rectangle GetButtonBounds()
		{
			if (this.x73a275c1be7f04ab.IsEmpty)
			{
				return Rectangle.Empty;
			}
			Rectangle contentBounds = base.ContentBounds;
			contentBounds.X += contentBounds.Width / 2;
			contentBounds.Y += contentBounds.Height / 2;
			contentBounds.X -= this.x73a275c1be7f04ab.Width / 2;
			contentBounds.Y -= this.x73a275c1be7f04ab.Height / 2;
			contentBounds.Width = this.x73a275c1be7f04ab.Width;
			contentBounds.Height = this.x73a275c1be7f04ab.Height;
			return contentBounds;
		}

		// Token: 0x06000713 RID: 1811 RVA: 0x00023918 File Offset: 0x00022918
		protected override void SetValueCore(object value)
		{
			if (value is bool)
			{
				this.Checked = (bool)value;
				return;
			}
			throw new ArgumentException("The specified value was not of the correct type.", "value");
		}

		// Token: 0x06000714 RID: 1812 RVA: 0x00023940 File Offset: 0x00022940
		protected override object GetValueCore()
		{
			return this.x07d4c1c683eae0fd;
		}

		// Token: 0x170001BE RID: 446
		// (get) Token: 0x06000715 RID: 1813 RVA: 0x00023950 File Offset: 0x00022950
		// (set) Token: 0x06000716 RID: 1814 RVA: 0x00023958 File Offset: 0x00022958
		[DefaultValue(typeof(bool?), "False")]
		public bool Checked
		{
			get
			{
				return this.x07d4c1c683eae0fd;
			}
			set
			{
				this.x07d4c1c683eae0fd = value;
				base.IsNull = false;
				if (base.OnValueChanged())
				{
					return;
				}
				base.RedrawNeeded();
			}
		}

		// Token: 0x040002B6 RID: 694
		private Size x73a275c1be7f04ab = Size.Empty;

		// Token: 0x040002B7 RID: 695
		private bool x07d4c1c683eae0fd;
	}
}
