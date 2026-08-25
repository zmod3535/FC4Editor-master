using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Divelements.SandGrid.Rendering
{
	// Token: 0x02000003 RID: 3
	[TypeConverter(typeof(x01480672935e1b10))]
	public interface ISandGridRenderer
	{
		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000008 RID: 8
		// (remove) Token: 0x06000009 RID: 9
		event EventHandler RedrawNeeded;

		// Token: 0x0600000A RID: 10
		Rectangle CalculateGroupHeadingExpandButtonBounds(GridGroup group);

		// Token: 0x0600000B RID: 11
		void DrawColumnHeader(Graphics graphics, GridColumn column, Rectangle bounds, TextFormattingInformation textFormat, DrawItemState state);

		// Token: 0x0600000C RID: 12
		void DrawRowHeader(Graphics graphics, GridRow row, Rectangle bounds, TextFormattingInformation textFormat, DrawItemState state);

		// Token: 0x0600000D RID: 13
		void DrawExpandButton(Graphics graphics, Rectangle bounds, bool expanded);

		// Token: 0x0600000E RID: 14
		void DrawSelectionRectangle(Graphics graphics, Rectangle bounds, bool selected, bool focused, bool focusRectangle);

		// Token: 0x0600000F RID: 15
		void DrawRubberBandSelection(Graphics graphics, Rectangle bounds);

		// Token: 0x06000010 RID: 16
		Pen CreateTreeHierarchyLinePen();

		// Token: 0x06000011 RID: 17
		Pen CreateGridLinePen();

		// Token: 0x06000012 RID: 18
		Pen CreateResizeHintPen();

		// Token: 0x06000013 RID: 19
		Brush CreateAlternateRowBackgroundBrush(GridRow row, Rectangle bounds);

		// Token: 0x06000014 RID: 20
		Color GetSelectedTextColor(bool focused);

		// Token: 0x06000015 RID: 21
		void DrawSortedColumnBackground(Graphics graphics, GridColumn column, Rectangle bounds);

		// Token: 0x06000016 RID: 22
		void DrawGroupHeading(Graphics graphics, GridGroup group, Rectangle bounds, Font font, DrawItemState state, GridColumn[] columns, TextFormattingInformation[] textFormats);

		// Token: 0x06000017 RID: 23
		void DrawNestedGridBorder(Graphics graphics, InnerGrid grid, Rectangle gridBounds);

		// Token: 0x06000018 RID: 24
		bool DrawGridBorder(Graphics graphics, Rectangle bounds);

		// Token: 0x06000019 RID: 25
		void DrawGlyph(Graphics graphics, Rectangle bounds, SandGridGlyphType glyphType);

		// Token: 0x0600001A RID: 26
		void DrawCorner(Graphics graphics, Rectangle bounds);

		// Token: 0x0600001B RID: 27
		void DrawCheckBox(Graphics graphics, Rectangle bounds, CheckState checkState);

		// Token: 0x0600001C RID: 28
		void DrawProgressBar(Graphics graphics, Rectangle bounds, int minimum, int maximum, int value);
	}
}
