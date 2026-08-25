using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Divelements.SandGrid.Rendering
{
	// Token: 0x02000061 RID: 97
	public class WindowsXPRenderer : ISandGridRenderer
	{
		// Token: 0x14000014 RID: 20
		// (add) Token: 0x060005C3 RID: 1475 RVA: 0x0001E5E8 File Offset: 0x0001D5E8
		// (remove) Token: 0x060005C4 RID: 1476 RVA: 0x0001E604 File Offset: 0x0001D604
		public event EventHandler RedrawNeeded
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.x5e7a70d58e13247a = (EventHandler)Delegate.Combine(this.x5e7a70d58e13247a, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.x5e7a70d58e13247a = (EventHandler)Delegate.Remove(this.x5e7a70d58e13247a, value);
			}
		}

		// Token: 0x060005C5 RID: 1477 RVA: 0x0001E620 File Offset: 0x0001D620
		public WindowsXPRenderer()
		{
			this.x590319ff0c518232();
		}

		// Token: 0x060005C6 RID: 1478 RVA: 0x0001E644 File Offset: 0x0001D644
		public override string ToString()
		{
			return "Windows (Themed)";
		}

		// Token: 0x060005C7 RID: 1479 RVA: 0x0001E64C File Offset: 0x0001D64C
		private void x590319ff0c518232()
		{
			this.x57dd8cbd69f9704d = SystemColors.ControlLight;
			this.x3e144089e7f076e3 = SystemColors.InactiveCaption;
			bool highContrast = SystemInformation.HighContrast;
		}

		// Token: 0x060005C8 RID: 1480 RVA: 0x0001E66C File Offset: 0x0001D66C
		public virtual Pen CreateResizeHintPen()
		{
			return new Pen(Color.FromArgb(200, SystemColors.WindowText), 2f);
		}

		// Token: 0x060005C9 RID: 1481 RVA: 0x0001E688 File Offset: 0x0001D688
		public virtual bool DrawGridBorder(Graphics graphics, Rectangle bounds)
		{
			if (this.x2bac484d59d27d03)
			{
				VisualStyleElement normal = VisualStyleElement.TextBox.TextEdit.Normal;
				VisualStyleRenderer visualStyleRenderer = new VisualStyleRenderer(normal);
				visualStyleRenderer.DrawBackground(graphics, bounds);
				return true;
			}
			return false;
		}

		// Token: 0x17000176 RID: 374
		// (get) Token: 0x060005CA RID: 1482 RVA: 0x0001E6B8 File Offset: 0x0001D6B8
		private bool x2bac484d59d27d03
		{
			get
			{
				VisualStyleElement normal = VisualStyleElement.TextBox.TextEdit.Normal;
				return Application.RenderWithVisualStyles && VisualStyleRenderer.IsElementDefined(normal);
			}
		}

		// Token: 0x060005CB RID: 1483 RVA: 0x0001E6DC File Offset: 0x0001D6DC
		public virtual void DrawNestedGridBorder(Graphics graphics, InnerGrid grid, Rectangle gridBounds)
		{
			Rectangle rectangle = gridBounds;
			bool terminalServerSession = SystemInformation.TerminalServerSession;
			if (this.x15edd106dba2f3b0 && !SystemInformation.HighContrast && !terminalServerSession)
			{
				rectangle.Offset(1, 1);
				rectangle.Inflate(-2, -2);
				DrawingMethods.DrawDropShadow(graphics, rectangle, 5, (grid.SandGrid.ActiveGrid == grid) ? SystemColors.Highlight : Color.Black);
				return;
			}
			rectangle.Offset(-1, -1);
			rectangle.Width++;
			rectangle.Height++;
			graphics.DrawRectangle(SystemPens.ControlDark, rectangle);
		}

		// Token: 0x060005CC RID: 1484 RVA: 0x0001E770 File Offset: 0x0001D770
		public virtual void DrawSortedColumnBackground(Graphics graphics, GridColumn column, Rectangle bounds)
		{
			if (SystemInformation.HighContrast)
			{
				return;
			}
			if (this.ColumnShade == ColumnShadeType.None)
			{
				return;
			}
			if (this.ColumnShade == ColumnShadeType.SortOnly && column.Grid.GroupColumn != null)
			{
				return;
			}
			Color color = DrawingMethods.InterpolateColors(SystemColors.Control, column.Grid.SandGrid.BackColor, 0.77f);
			using (SolidBrush solidBrush = new SolidBrush(color))
			{
				graphics.FillRectangle(solidBrush, bounds);
			}
		}

		// Token: 0x060005CD RID: 1485 RVA: 0x0001E7FC File Offset: 0x0001D7FC
		public virtual void DrawGroupHeading(Graphics graphics, GridGroup group, Rectangle bounds, Font rowFont, DrawItemState state, GridColumn[] columns, TextFormattingInformation[] textFormats)
		{
			if (group.Grid.AllowGroupCollapse)
			{
				this.DrawExpandButton(graphics, group.ExpandButtonBounds, group.Expanded);
			}
			using (Font font = new Font(rowFont, FontStyle.Bold))
			{
				Rectangle bounds2 = new Rectangle(bounds.Left + 14, bounds.Top, bounds.Width - 14, bounds.Height);
				using (TextFormattingInformation textFormat = TextFormattingInformation.CreateFormattingInformation(group.Grid.RightToLeft, false, StringAlignment.Near, StringAlignment.Center, false))
				{
					IndependentText.DrawText(graphics, group.Text, font, bounds2, textFormat, group.Grid.SandGrid.ForeColor);
				}
				Rectangle rect = new Rectangle(bounds.Left, bounds.Top + bounds.Height / 2 + font.Height / 2 + 1, 300, 1);
				using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect, x443cc432acaadb1d.xdd5501c2b4985e92, Color.Transparent, LinearGradientMode.Horizontal))
				{
					graphics.FillRectangle(linearGradientBrush, rect);
				}
			}
		}

		// Token: 0x060005CE RID: 1486 RVA: 0x0001E954 File Offset: 0x0001D954
		public virtual Rectangle CalculateGroupHeadingExpandButtonBounds(GridGroup group)
		{
			Rectangle bounds = group.Bounds;
			bounds.X += 2;
			bounds.Y = bounds.Y + bounds.Height / 2 - 5;
			bounds.Size = new Size(10, 10);
			return bounds;
		}

		// Token: 0x060005CF RID: 1487 RVA: 0x0001E9A4 File Offset: 0x0001D9A4
		public virtual Pen CreateTreeHierarchyLinePen()
		{
			return new Pen(SystemColors.GrayText)
			{
				DashStyle = DashStyle.Dot
			};
		}

		// Token: 0x060005D0 RID: 1488 RVA: 0x0001E9C4 File Offset: 0x0001D9C4
		public virtual Pen CreateGridLinePen()
		{
			return new Pen(this.x57dd8cbd69f9704d);
		}

		// Token: 0x060005D1 RID: 1489 RVA: 0x0001E9D4 File Offset: 0x0001D9D4
		public virtual void DrawRubberBandSelection(Graphics graphics, Rectangle bounds)
		{
			if (!SystemInformation.HighContrast)
			{
				using (SolidBrush solidBrush = new SolidBrush(Color.FromArgb(70, SystemColors.Highlight)))
				{
					graphics.FillRectangle(solidBrush, bounds);
				}
			}
			graphics.DrawRectangle(SystemPens.Highlight, bounds);
		}

		// Token: 0x060005D2 RID: 1490 RVA: 0x0001EA38 File Offset: 0x0001DA38
		public virtual void DrawSelectionRectangle(Graphics graphics, Rectangle bounds, bool selected, bool focused, bool focusRectangle)
		{
			Color color = SystemColors.Window;
			if (selected)
			{
				Brush brush;
				if (focused)
				{
					brush = SystemBrushes.Highlight;
					color = SystemColors.Highlight;
				}
				else
				{
					brush = SystemBrushes.Control;
					color = SystemColors.Control;
				}
				graphics.FillRectangle(brush, bounds);
			}
			if (focused && focusRectangle)
			{
				ControlPaint.DrawFocusRectangle(graphics, bounds, color, color);
			}
		}

		// Token: 0x060005D3 RID: 1491 RVA: 0x0001EA88 File Offset: 0x0001DA88
		public virtual void DrawProgressBar(Graphics graphics, Rectangle bounds, int minimum, int maximum, int value)
		{
			float num = ((float)value - (float)minimum) / (float)(maximum - minimum);
			if (ProgressBarRenderer.IsSupported)
			{
				ProgressBarRenderer.DrawHorizontalBar(graphics, bounds);
				bounds.Inflate(-ProgressBarRenderer.ChunkSpaceThickness * 2, -ProgressBarRenderer.ChunkThickness / 2);
				bounds.Width = Convert.ToInt32((float)bounds.Width * num);
				ProgressBarRenderer.DrawHorizontalChunks(graphics, bounds);
				return;
			}
			graphics.FillRectangle(SystemBrushes.Window, bounds);
			int width = (int)((float)bounds.Width * num);
			graphics.FillRectangle(SystemBrushes.Highlight, bounds.X, bounds.Y, width, bounds.Height);
			graphics.DrawRectangle(SystemPens.ControlText, bounds);
		}

		// Token: 0x060005D4 RID: 1492 RVA: 0x0001EB2C File Offset: 0x0001DB2C
		public virtual void DrawExpandButton(Graphics graphics, Rectangle bounds, bool expanded)
		{
			VisualStyleElement element = expanded ? VisualStyleElement.TreeView.Glyph.Opened : VisualStyleElement.TreeView.Glyph.Closed;
			if (Application.RenderWithVisualStyles && VisualStyleRenderer.IsElementDefined(element))
			{
				VisualStyleRenderer visualStyleRenderer = new VisualStyleRenderer(element);
				visualStyleRenderer.DrawBackground(graphics, bounds);
				return;
			}
			if (expanded)
			{
				graphics.DrawImageUnscaled(WindowsXPRenderer.xe6f4b92cdeb7842c, bounds.Left, bounds.Top);
				return;
			}
			graphics.DrawImageUnscaled(WindowsXPRenderer.x049829b2565ec461, bounds.Left, bounds.Top);
		}

		// Token: 0x060005D5 RID: 1493 RVA: 0x0001EBA0 File Offset: 0x0001DBA0
		public virtual void DrawRowHeader(Graphics graphics, GridRow row, Rectangle bounds, TextFormattingInformation textFormat, DrawItemState state)
		{
			if (SystemInformation.HighContrast)
			{
				graphics.FillRectangle(SystemBrushes.Control, bounds);
			}
			else
			{
				using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(new Point(bounds.Left, bounds.Top), new Point(bounds.Right - 1, bounds.Top), SystemColors.Control, DrawingMethods.InterpolateColors(SystemColors.Control, SystemColors.ControlDark, 0.9f)))
				{
					Blend blend = new Blend(3);
					blend.Positions[0] = 0f;
					blend.Factors[0] = 0f;
					blend.Positions[1] = 0.75f;
					blend.Factors[1] = 0f;
					blend.Positions[2] = 1f;
					blend.Factors[2] = 0.9f;
					linearGradientBrush.Blend = blend;
					graphics.FillRectangle(linearGradientBrush, bounds);
				}
			}
			graphics.DrawLine(SystemPens.ControlDark, bounds.Right - 1, bounds.Y, bounds.Right - 1, bounds.Bottom - 1);
			if (!SystemInformation.HighContrast && (state & DrawItemState.Hot) == DrawItemState.Hot)
			{
				using (SolidBrush solidBrush = new SolidBrush(Color.FromArgb(150, SystemColors.ControlLightLight)))
				{
					graphics.FillRectangle(solidBrush, bounds);
				}
				graphics.DrawLine(Pens.Orange, bounds.Right - 1, bounds.Y, bounds.Right - 1, bounds.Bottom - 1);
				graphics.DrawLine(Pens.Orange, bounds.Right - 2, bounds.Y, bounds.Right - 2, bounds.Bottom - 1);
			}
			if (row == null || row.PreviousVisibleRow != null)
			{
				graphics.DrawLine(SystemPens.ControlLightLight, bounds.Left + 2, bounds.Top, bounds.Right - 5, bounds.Top);
			}
			if (row == null || row.NextVisibleRow != null || !row.Grid.IsNested)
			{
				graphics.DrawLine(SystemPens.ControlDark, bounds.Left + 2, bounds.Bottom - 1, bounds.Right - 5, bounds.Bottom - 1);
			}
			if (!this.x2bac484d59d27d03)
			{
				graphics.DrawLine(SystemPens.ControlLightLight, bounds.Left, bounds.Top, bounds.Left, bounds.Bottom - 1);
			}
		}

		// Token: 0x060005D6 RID: 1494 RVA: 0x0001EE24 File Offset: 0x0001DE24
		public virtual void DrawColumnHeader(Graphics graphics, GridColumn column, Rectangle bounds, TextFormattingInformation textFormat, DrawItemState state)
		{
			VisualStyleElement element = this.x58e1fc2461e4d13a(column, state);
			for (;;)
			{
				bool flag;
				if (!Application.RenderWithVisualStyles || !VisualStyleRenderer.IsElementDefined(element))
				{
					if (SystemInformation.HighContrast)
					{
						if (((flag ? 1U : 0U) | 4U) == 0U)
						{
							goto IL_1BA;
						}
						graphics.FillRectangle(SystemBrushes.Control, bounds);
					}
					else
					{
						float percentage = ((state & DrawItemState.Pushed) == DrawItemState.Pushed) ? 0.4f : 0.9f;
						using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(new Point(bounds.Left, bounds.Top - 1), new Point(bounds.Left, bounds.Bottom), SystemColors.Control, DrawingMethods.InterpolateColors(SystemColors.Control, SystemColors.ControlDark, percentage)))
						{
							Blend blend = new Blend(3);
							blend.Positions[0] = 0f;
							blend.Factors[0] = 0f;
							blend.Positions[1] = 0.75f;
							blend.Factors[1] = 0f;
							blend.Positions[2] = 1f;
							blend.Factors[2] = 0.9f;
							linearGradientBrush.Blend = blend;
							graphics.FillRectangle(linearGradientBrush, bounds);
						}
					}
					graphics.DrawLine(SystemPens.ControlDark, bounds.X, bounds.Bottom - 1, bounds.Right - 1, bounds.Bottom - 1);
					if (!SystemInformation.HighContrast && (state & DrawItemState.Hot) == DrawItemState.Hot)
					{
						using (SolidBrush solidBrush = new SolidBrush(Color.FromArgb(150, SystemColors.ControlLightLight)))
						{
							graphics.FillRectangle(solidBrush, bounds);
						}
						graphics.DrawLine(Pens.Orange, bounds.X, bounds.Bottom - 1, bounds.Right - 1, bounds.Bottom - 1);
						graphics.DrawLine(Pens.Orange, bounds.X, bounds.Bottom - 2, bounds.Right - 1, bounds.Bottom - 2);
					}
					if (column == null || column.PreviousColumn != null)
					{
						graphics.DrawLine(SystemPens.ControlLightLight, bounds.Left, bounds.Top + 2, bounds.Left, bounds.Bottom - 5);
					}
					graphics.DrawLine(SystemPens.ControlDark, bounds.Right - 1, bounds.Top + 2, bounds.Right - 1, bounds.Bottom - 5);
					graphics.DrawLine(SystemPens.ControlLightLight, bounds.Left, bounds.Top, bounds.Right - 1, bounds.Top);
					goto IL_1B4;
				}
				VisualStyleRenderer visualStyleRenderer = new VisualStyleRenderer(element);
				visualStyleRenderer.DrawBackground(graphics, bounds);
				if (!this.x2bac484d59d27d03)
				{
					graphics.DrawLine(SystemPens.ControlLightLight, bounds.Left, bounds.Top, bounds.Right - 1, bounds.Top);
					goto IL_1B4;
				}
				goto IL_1B4;
				IL_1BA:
				bounds = column.TextBounds;
				if ((state & DrawItemState.Pushed) == DrawItemState.Pushed)
				{
					bounds.Offset(1, 1);
				}
				IndependentText.DrawText(graphics, column.HeaderText, column.Font, bounds, textFormat, SystemColors.ControlText, SystemBrushes.ControlText);
				if (column.HeaderImage != null)
				{
					bounds = column.ImageBounds;
					if ((state & DrawItemState.Pushed) == DrawItemState.Pushed)
					{
						bounds.Offset(1, 1);
					}
					graphics.DrawImage(column.HeaderImage, bounds);
				}
				if (column.SortOrder == SortOrder.None)
				{
					break;
				}
				flag = ((column.HeaderHorizontalAlignment == StringAlignment.Far && !column.Grid.RightToLeft) || (column.HeaderHorizontalAlignment == StringAlignment.Near && column.Grid.RightToLeft));
				int num = flag ? column.TextBounds.Left : (column.TextBounds.Right - 11);
				if (num >= column.TextBounds.Right - 9 || num < column.TextBounds.Left)
				{
					break;
				}
				this.x539681bb802a760f(graphics, column.SortOrder, new Rectangle(num, column.Bounds.Top, 10, column.Bounds.Height));
				if (!true)
				{
					continue;
				}
				break;
				IL_1B4:
				if (column != null)
				{
					goto IL_1BA;
				}
				break;
			}
		}

		// Token: 0x060005D7 RID: 1495 RVA: 0x0001F274 File Offset: 0x0001E274
		private void x539681bb802a760f(Graphics x41347a961b838962, SortOrder x0be0482b5fb3b33d, Rectangle xda73fcb97c77d998)
		{
			VisualStyleElement element = (x0be0482b5fb3b33d == SortOrder.Ascending) ? VisualStyleElement.Header.SortArrow.SortedUp : VisualStyleElement.Header.SortArrow.SortedDown;
			if (Application.RenderWithVisualStyles && VisualStyleRenderer.IsElementDefined(element))
			{
				VisualStyleRenderer visualStyleRenderer = new VisualStyleRenderer(element);
				xda73fcb97c77d998 = new Rectangle(xda73fcb97c77d998.X, xda73fcb97c77d998.Y + xda73fcb97c77d998.Height / 2 - xda73fcb97c77d998.Width / 2, xda73fcb97c77d998.Width, xda73fcb97c77d998.Width);
				visualStyleRenderer.DrawBackground(x41347a961b838962, xda73fcb97c77d998);
				return;
			}
			int num = xda73fcb97c77d998.Top + xda73fcb97c77d998.Height / 2;
			Point[] points;
			if (x0be0482b5fb3b33d == SortOrder.Descending)
			{
				points = new Point[]
				{
					new Point(xda73fcb97c77d998.X, num - 3),
					new Point(xda73fcb97c77d998.X + 9, num - 3),
					new Point(xda73fcb97c77d998.X + 4, num + 2)
				};
			}
			else
			{
				points = new Point[]
				{
					new Point(xda73fcb97c77d998.X, num + 2),
					new Point(xda73fcb97c77d998.X + 10, num + 2),
					new Point(xda73fcb97c77d998.X + 5, num - 4)
				};
			}
			using (SolidBrush solidBrush = new SolidBrush(Color.FromArgb(70, SystemColors.ControlText)))
			{
				x41347a961b838962.FillPolygon(solidBrush, points);
			}
		}

		// Token: 0x060005D8 RID: 1496 RVA: 0x0001F410 File Offset: 0x0001E410
		private VisualStyleElement x58e1fc2461e4d13a(GridColumn xe3e287548b3d01f5, DrawItemState x01b557925841ae51)
		{
			VisualStyleElement visualStyleElement = null;
			if (xe3e287548b3d01f5 == null)
			{
				if ((x01b557925841ae51 & DrawItemState.Pushed) == DrawItemState.Pushed)
				{
					visualStyleElement = VisualStyleElement.Header.ItemRight.Pressed;
				}
				else if ((x01b557925841ae51 & DrawItemState.Hot) == DrawItemState.Hot)
				{
					visualStyleElement = VisualStyleElement.Header.ItemRight.Hot;
				}
				else
				{
					visualStyleElement = VisualStyleElement.Header.ItemRight.Normal;
				}
			}
			else if (xe3e287548b3d01f5.PreviousColumn == null)
			{
				if ((x01b557925841ae51 & DrawItemState.Pushed) == DrawItemState.Pushed)
				{
					visualStyleElement = VisualStyleElement.Header.ItemLeft.Pressed;
				}
				else if ((x01b557925841ae51 & DrawItemState.Hot) == DrawItemState.Hot)
				{
					visualStyleElement = VisualStyleElement.Header.ItemLeft.Hot;
				}
				else
				{
					visualStyleElement = VisualStyleElement.Header.ItemLeft.Normal;
				}
			}
			IL_2E:
			if (visualStyleElement != null)
			{
				if (3 == 0)
				{
					goto IL_89;
				}
				if (Application.RenderWithVisualStyles && VisualStyleRenderer.IsElementDefined(visualStyleElement))
				{
					return visualStyleElement;
				}
			}
			if ((x01b557925841ae51 & DrawItemState.Pushed) == DrawItemState.Pushed)
			{
				return VisualStyleElement.Header.Item.Pressed;
			}
			if ((x01b557925841ae51 & DrawItemState.Hot) == DrawItemState.Hot)
			{
				return VisualStyleElement.Header.Item.Hot;
			}
			return VisualStyleElement.Header.Item.Normal;
			IL_89:
			goto IL_2E;
		}

		// Token: 0x060005D9 RID: 1497 RVA: 0x0001F4B0 File Offset: 0x0001E4B0
		public virtual Brush CreateAlternateRowBackgroundBrush(GridRow row, Rectangle bounds)
		{
			return new SolidBrush(Color.FromArgb((int)this.AlternateRowOpacity, this.AlternateRowBackgroundColor));
		}

		// Token: 0x060005DA RID: 1498 RVA: 0x0001F4C8 File Offset: 0x0001E4C8
		protected virtual void OnRedrawNeeded(EventArgs e)
		{
			if (this.x5e7a70d58e13247a != null)
			{
				this.x5e7a70d58e13247a(this, e);
			}
		}

		// Token: 0x060005DB RID: 1499 RVA: 0x0001F4E0 File Offset: 0x0001E4E0
		public virtual void DrawGlyph(Graphics graphics, Rectangle bounds, SandGridGlyphType glyphType)
		{
			switch (glyphType)
			{
			case SandGridGlyphType.EditMode:
				graphics.DrawImage(WindowsXPRenderer.x3bdc93f4d0202b0e, bounds.X + bounds.Width / 2 - WindowsXPRenderer.x3bdc93f4d0202b0e.Width / 2, bounds.Y + bounds.Height / 2 - WindowsXPRenderer.x3bdc93f4d0202b0e.Height / 2);
				return;
			case SandGridGlyphType.CurrentRow:
				graphics.DrawImage(WindowsXPRenderer.x9cd648873d53f7f8, bounds.X + bounds.Width / 2 - WindowsXPRenderer.x9cd648873d53f7f8.Width / 2, bounds.Y + bounds.Height / 2 - WindowsXPRenderer.x9cd648873d53f7f8.Height / 2);
				return;
			case SandGridGlyphType.Error:
				graphics.DrawImage(WindowsXPRenderer.xef0187f549dd9707, bounds.X + bounds.Width / 2 - WindowsXPRenderer.xef0187f549dd9707.Width / 2, bounds.Y + bounds.Height / 2 - WindowsXPRenderer.xef0187f549dd9707.Height / 2);
				return;
			default:
				return;
			}
		}

		// Token: 0x060005DC RID: 1500 RVA: 0x0001F5DC File Offset: 0x0001E5DC
		public virtual void DrawCorner(Graphics graphics, Rectangle bounds)
		{
			if (Application.RenderWithVisualStyles)
			{
				VisualStyleElement normal = VisualStyleElement.Header.ItemLeft.Normal;
				if (!VisualStyleRenderer.IsElementDefined(normal))
				{
					normal = VisualStyleElement.Header.Item.Normal;
				}
				if (VisualStyleRenderer.IsElementDefined(normal))
				{
					VisualStyleRenderer visualStyleRenderer = new VisualStyleRenderer(normal);
					visualStyleRenderer.DrawBackground(graphics, bounds);
					if (!this.x2bac484d59d27d03)
					{
						graphics.DrawLine(SystemPens.ControlLightLight, bounds.Left, bounds.Top, bounds.Right - 1, bounds.Top);
						graphics.DrawLine(SystemPens.ControlLightLight, bounds.Left, bounds.Top, bounds.Left, bounds.Bottom - 1);
					}
					return;
				}
			}
			graphics.FillRectangle(SystemBrushes.Control, bounds);
			if (!SystemInformation.HighContrast)
			{
				Rectangle rect = new Rectangle(bounds.Right - 4, bounds.Bottom - 4, 3, 3);
				using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(new Point(rect.Left - 1, rect.Top - 1), new Point(rect.Right, rect.Bottom), SystemColors.Control, DrawingMethods.InterpolateColors(SystemColors.Control, SystemColors.ControlDark, 0.8f)))
				{
					graphics.FillRectangle(linearGradientBrush, rect);
				}
			}
			graphics.DrawLine(SystemPens.ControlDark, bounds.Right - 1, bounds.Y, bounds.Right - 1, bounds.Bottom - 1);
			graphics.DrawLine(SystemPens.ControlDark, bounds.X, bounds.Bottom - 1, bounds.Right - 1, bounds.Bottom - 1);
			graphics.DrawLine(SystemPens.ControlLightLight, bounds.Left, bounds.Top, bounds.Right - 1, bounds.Top);
			graphics.DrawLine(SystemPens.ControlLightLight, bounds.Left, bounds.Top, bounds.Left, bounds.Bottom - 1);
		}

		// Token: 0x060005DD RID: 1501 RVA: 0x0001F7CC File Offset: 0x0001E7CC
		public virtual void DrawCheckBox(Graphics graphics, Rectangle bounds, CheckState checkState)
		{
			VisualStyleElement element = VisualStyleElement.Button.CheckBox.UncheckedNormal;
			int num;
			int num2;
			bool flag = (uint)num - (uint)num2 > uint.MaxValue;
			if (!flag)
			{
				if (checkState == CheckState.Checked)
				{
					element = VisualStyleElement.Button.CheckBox.CheckedNormal;
				}
				if (checkState != CheckState.Indeterminate)
				{
					goto IL_1A6;
				}
			}
			IL_1A0:
			element = VisualStyleElement.Button.CheckBox.MixedNormal;
			IL_1A6:
			if (Application.RenderWithVisualStyles && VisualStyleRenderer.IsElementDefined(element))
			{
				VisualStyleRenderer visualStyleRenderer = new VisualStyleRenderer(element);
				visualStyleRenderer.DrawBackground(graphics, bounds);
				return;
			}
			bounds.Width -= 2;
			bounds.Height -= 2;
			using (Pen pen = new Pen(SystemColors.WindowText, 2f))
			{
				graphics.DrawRectangle(pen, bounds);
			}
			if (checkState == CheckState.Checked)
			{
				num2 = bounds.X + bounds.Width / 2;
				num = bounds.Y + bounds.Height / 2;
				Point[] array = new Point[6];
				array[0] = new Point(num2 - 3, num - 2);
				array[1] = new Point(num2 - 1, num + 1);
				array[2] = new Point(num2 + 4, num - 4);
				array[3] = new Point(num2 + 4, num - 1);
				if ((uint)num - (uint)num <= 4294967295U)
				{
					array[4] = new Point(num2 - 1, num + 4);
					array[5] = new Point(num2 - 3, num + 1);
					Point[] points = array;
					graphics.FillPolygon(SystemBrushes.WindowText, points);
					return;
				}
			}
			else
			{
				if (checkState != CheckState.Indeterminate)
				{
					return;
				}
				bounds.Inflate(-3, -3);
			}
			using (SolidBrush solidBrush = new SolidBrush(SystemColors.GrayText))
			{
				graphics.FillRectangle(solidBrush, bounds);
				return;
			}
			goto IL_1A0;
		}

		// Token: 0x060005DE RID: 1502 RVA: 0x0001F9E0 File Offset: 0x0001E9E0
		public virtual Color GetSelectedTextColor(bool focused)
		{
			if (focused)
			{
				return SystemColors.HighlightText;
			}
			return SystemColors.WindowText;
		}

		// Token: 0x17000177 RID: 375
		// (get) Token: 0x060005DF RID: 1503 RVA: 0x0001F9F0 File Offset: 0x0001E9F0
		// (set) Token: 0x060005E0 RID: 1504 RVA: 0x0001F9F8 File Offset: 0x0001E9F8
		[Description("Indicates how solid the background of alternate rows is drawn.")]
		[DefaultValue(20)]
		public byte AlternateRowOpacity
		{
			get
			{
				return this.xbd2bb820e0456aa5;
			}
			set
			{
				this.xbd2bb820e0456aa5 = value;
				this.OnRedrawNeeded(EventArgs.Empty);
			}
		}

		// Token: 0x17000178 RID: 376
		// (get) Token: 0x060005E1 RID: 1505 RVA: 0x0001FA0C File Offset: 0x0001EA0C
		// (set) Token: 0x060005E2 RID: 1506 RVA: 0x0001FA14 File Offset: 0x0001EA14
		[Description("Indicates the color used to draw the background of alternate rows.")]
		[DefaultValue(typeof(Color), "InactiveCaption")]
		public Color AlternateRowBackgroundColor
		{
			get
			{
				return this.x3e144089e7f076e3;
			}
			set
			{
				this.x3e144089e7f076e3 = value;
				this.OnRedrawNeeded(EventArgs.Empty);
			}
		}

		// Token: 0x17000179 RID: 377
		// (get) Token: 0x060005E3 RID: 1507 RVA: 0x0001FA28 File Offset: 0x0001EA28
		// (set) Token: 0x060005E4 RID: 1508 RVA: 0x0001FA30 File Offset: 0x0001EA30
		[Description("Indicates whether drop shadows are drawn.")]
		[DefaultValue(true)]
		public bool DrawShadows
		{
			get
			{
				return this.x15edd106dba2f3b0;
			}
			set
			{
				this.x15edd106dba2f3b0 = value;
				this.OnRedrawNeeded(EventArgs.Empty);
			}
		}

		// Token: 0x1700017A RID: 378
		// (get) Token: 0x060005E5 RID: 1509 RVA: 0x0001FA44 File Offset: 0x0001EA44
		// (set) Token: 0x060005E6 RID: 1510 RVA: 0x0001FA4C File Offset: 0x0001EA4C
		[DefaultValue(typeof(ColumnShadeType), "SortOnly")]
		[Description("Indicates when the backgrounds of columns are shaded.")]
		public ColumnShadeType ColumnShade
		{
			get
			{
				return this.x7508f055717dd2c8;
			}
			set
			{
				this.x7508f055717dd2c8 = value;
				this.OnRedrawNeeded(EventArgs.Empty);
			}
		}

		// Token: 0x04000232 RID: 562
		private static Image xe6f4b92cdeb7842c = Image.FromStream(typeof(WindowsXPRenderer).Assembly.GetManifestResourceStream("Divelements.SandGrid.Resources.expanded.gif"));

		// Token: 0x04000233 RID: 563
		private static Image x049829b2565ec461 = Image.FromStream(typeof(WindowsXPRenderer).Assembly.GetManifestResourceStream("Divelements.SandGrid.Resources.collapsed.gif"));

		// Token: 0x04000234 RID: 564
		private static Image x3bdc93f4d0202b0e = Image.FromStream(typeof(WindowsXPRenderer).Assembly.GetManifestResourceStream("Divelements.SandGrid.Resources.pencil.gif"));

		// Token: 0x04000235 RID: 565
		private static Image x9cd648873d53f7f8 = Image.FromStream(typeof(WindowsXPRenderer).Assembly.GetManifestResourceStream("Divelements.SandGrid.Resources.currentrow.png"));

		// Token: 0x04000236 RID: 566
		private static Image xef0187f549dd9707 = Image.FromStream(typeof(WindowsXPRenderer).Assembly.GetManifestResourceStream("Divelements.SandGrid.Resources.error.png"));

		// Token: 0x04000237 RID: 567
		private ColumnShadeType x7508f055717dd2c8 = ColumnShadeType.SortOnly;

		// Token: 0x04000238 RID: 568
		private bool x15edd106dba2f3b0 = true;

		// Token: 0x04000239 RID: 569
		private Color x57dd8cbd69f9704d;

		// Token: 0x0400023A RID: 570
		private Color x3e144089e7f076e3;

		// Token: 0x0400023B RID: 571
		private byte xbd2bb820e0456aa5 = 20;

		// Token: 0x0400023C RID: 572
		private EventHandler x5e7a70d58e13247a;
	}
}
