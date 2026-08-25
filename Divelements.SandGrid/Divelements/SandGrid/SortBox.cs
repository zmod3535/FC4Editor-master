using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Divelements.SandGrid.Rendering;

namespace Divelements.SandGrid
{
	// Token: 0x0200002D RID: 45
	[DefaultProperty("Grid")]
	public class SortBox : Control
	{
		// Token: 0x14000011 RID: 17
		// (add) Token: 0x0600044F RID: 1103 RVA: 0x000187D0 File Offset: 0x000177D0
		// (remove) Token: 0x06000450 RID: 1104 RVA: 0x000187EC File Offset: 0x000177EC
		public event SortColumnsEventHandler BeforeApplySort
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.x2b4e23ce060078cb = (SortColumnsEventHandler)Delegate.Combine(this.x2b4e23ce060078cb, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.x2b4e23ce060078cb = (SortColumnsEventHandler)Delegate.Remove(this.x2b4e23ce060078cb, value);
			}
		}

		// Token: 0x14000012 RID: 18
		// (add) Token: 0x06000451 RID: 1105 RVA: 0x00018808 File Offset: 0x00017808
		// (remove) Token: 0x06000452 RID: 1106 RVA: 0x00018824 File Offset: 0x00017824
		public event SortColumnsEventHandler BeforeDisplaySort
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.xe4b44126a1b7c143 = (SortColumnsEventHandler)Delegate.Combine(this.xe4b44126a1b7c143, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.xe4b44126a1b7c143 = (SortColumnsEventHandler)Delegate.Remove(this.xe4b44126a1b7c143, value);
			}
		}

		// Token: 0x06000453 RID: 1107 RVA: 0x00018840 File Offset: 0x00017840
		public SortBox()
		{
			this.x9a8772e3d2a72c37 = new InnerGrid();
			this.AutoSize = true;
			this.Text = "Drag a column header here to sort by that column.";
			this.Renderer = new WindowsXPRenderer();
			base.SetStyle(ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			base.SetStyle(ControlStyles.Selectable, false);
		}

		// Token: 0x06000454 RID: 1108 RVA: 0x00018904 File Offset: 0x00017904
		protected virtual void OnBeforeApplySort(SortColumnsEventArgs e)
		{
			if (this.x2b4e23ce060078cb != null)
			{
				this.x2b4e23ce060078cb(this, e);
			}
		}

		// Token: 0x06000455 RID: 1109 RVA: 0x0001891C File Offset: 0x0001791C
		protected virtual void OnBeforeDisplaySort(SortColumnsEventArgs e)
		{
			if (this.xe4b44126a1b7c143 != null)
			{
				this.xe4b44126a1b7c143(this, e);
			}
		}

		// Token: 0x06000456 RID: 1110 RVA: 0x00018934 File Offset: 0x00017934
		protected override void OnPaintBackground(PaintEventArgs pevent)
		{
			if (this.BorderStyle == SortBoxBorderStyle.None)
			{
				DrawingMethods.x91433b5e99eb7cac(pevent.Graphics, SystemColors.Window);
				return;
			}
			if (this.BorderStyle == SortBoxBorderStyle.PartialBorder)
			{
				this.Renderer.DrawGridBorder(pevent.Graphics, new Rectangle(0, 0, base.ClientRectangle.Width, base.ClientRectangle.Height + 1));
				return;
			}
			this.Renderer.DrawGridBorder(pevent.Graphics, base.ClientRectangle);
		}

		// Token: 0x06000457 RID: 1111 RVA: 0x000189B4 File Offset: 0x000179B4
		protected override void OnPaint(PaintEventArgs e)
		{
			Rectangle clientRectangle = base.ClientRectangle;
			clientRectangle.Inflate(-this.xb384c86738fd7c19, -this.x9077f305c3fd8da1);
			if (this.x26c511b92db96554.Length == 0)
			{
				using (TextFormattingInformation textFormat = TextFormattingInformation.CreateFormattingInformation(this.RightToLeft == RightToLeft.Yes, true, StringAlignment.Near, StringAlignment.Center, true))
				{
					IndependentText.DrawText(e.Graphics, this.Text, this.Font, clientRectangle, textFormat, SystemColors.WindowText);
					goto IL_73;
				}
			}
			this.x2a2a4b1ea96b433e(e.Graphics);
			IL_73:
			this.x206277478b948861(e.Graphics);
			base.OnPaint(e);
		}

		// Token: 0x06000458 RID: 1112 RVA: 0x00018A64 File Offset: 0x00017A64
		private void x206277478b948861(Graphics x41347a961b838962)
		{
			bool flag = this.RightToLeft == RightToLeft.Yes;
			if (this.xb9b45c47f3e94991 != -1)
			{
				int num;
				if (this.xb9b45c47f3e94991 == 0)
				{
					num = (flag ? (base.ClientRectangle.Right - this.xb384c86738fd7c19) : this.xb384c86738fd7c19);
				}
				else if (this.xb9b45c47f3e94991 == this.x26c511b92db96554.Length)
				{
					Rectangle bounds = this.x3e44975184a7421b[this.x26c511b92db96554.Length - 1].Bounds;
					num = (flag ? (bounds.X - 5) : (bounds.Right + 5));
				}
				else
				{
					Rectangle bounds2 = this.x3e44975184a7421b[this.xb9b45c47f3e94991].Bounds;
					num = (flag ? (bounds2.Right + 5) : (bounds2.X - 5));
				}
				SmoothingMode smoothingMode = x41347a961b838962.SmoothingMode;
				x41347a961b838962.SmoothingMode = SmoothingMode.AntiAlias;
				using (Pen pen = new Pen(SystemColors.WindowText, 2.5f))
				{
					pen.EndCap = LineCap.ArrowAnchor;
					x41347a961b838962.DrawLine(pen, new PointF((float)num, 0.5f), new PointF((float)num, (float)(base.ClientRectangle.Height / 2 - this.x624c4b22da43f1f8 / 2)));
					x41347a961b838962.DrawLine(pen, new PointF((float)num, (float)base.ClientRectangle.Height - 0.5f), new PointF((float)num, (float)(base.ClientRectangle.Height / 2 + this.x624c4b22da43f1f8 / 2)));
				}
				x41347a961b838962.SmoothingMode = smoothingMode;
			}
		}

		// Token: 0x06000459 RID: 1113 RVA: 0x00018BF8 File Offset: 0x00017BF8
		private void x2a2a4b1ea96b433e(Graphics x41347a961b838962)
		{
			RightToLeft rightToLeft = this.RightToLeft;
			for (int i = 0; i < this.x26c511b92db96554.Length; i++)
			{
				GridColumn gridColumn = this.x26c511b92db96554[i];
				Rectangle bounds = this.x3e44975184a7421b[i].Bounds;
				using (TextFormattingInformation textFormat = gridColumn.CreateTextFormat(GridColumnTextFormatType.Header))
				{
					GridColumn column = this.x3e44975184a7421b[i];
					Divelements.SandGrid.Rendering.DrawItemState drawItemState = Divelements.SandGrid.Rendering.DrawItemState.None;
					if (i == 0 && this.Grid != null && this.Grid.PrimaryGrid.GroupColumn == this.x26c511b92db96554[i])
					{
						drawItemState |= Divelements.SandGrid.Rendering.DrawItemState.Hot;
					}
					this.Renderer.DrawColumnHeader(x41347a961b838962, column, bounds, textFormat, drawItemState);
					x41347a961b838962.ResetClip();
					if (i < this.x26c511b92db96554.Length - 1)
					{
						Rectangle bounds2 = this.x3e44975184a7421b[i + 1].Bounds;
						int y = Math.Min(bounds.Bottom + 3, bounds2.Bottom - 1);
						using (Pen pen = new Pen(SystemColors.WindowText))
						{
							x41347a961b838962.DrawLines(pen, new Point[]
							{
								new Point(bounds.Right - 8, bounds.Bottom),
								new Point(bounds.Right - 8, y),
								new Point(bounds2.X, y)
							});
						}
					}
				}
			}
		}

		// Token: 0x0600045A RID: 1114 RVA: 0x00018D98 File Offset: 0x00017D98
		private void xd691c593fb2614e1(object xe0292b9ed559da7d, GridEventArgs x94ee9f76af474bbf)
		{
			SortColumnsEventArgs sortColumnsEventArgs = (SortColumnsEventArgs)x94ee9f76af474bbf;
			this.x6d325ba4caeba2b1(sortColumnsEventArgs.SortColumns, sortColumnsEventArgs.SortDirections);
		}

		// Token: 0x0600045B RID: 1115 RVA: 0x00018DC0 File Offset: 0x00017DC0
		private void x6d325ba4caeba2b1(GridColumn[] x94c6d9c743d62341, ListSortDirection[] x30193a48d57c0a72)
		{
			SortColumnsEventArgs sortColumnsEventArgs = new SortColumnsEventArgs(this.Grid.PrimaryGrid, x94c6d9c743d62341, x30193a48d57c0a72);
			this.OnBeforeDisplaySort(sortColumnsEventArgs);
			this.x26c511b92db96554 = sortColumnsEventArgs.SortColumns;
			this.x0835ff38739ed7ac = sortColumnsEventArgs.SortDirections;
			foreach (GridColumn gridColumn in this.x3e44975184a7421b)
			{
				gridColumn.xea1c0bc64ab77594(null);
			}
			this.x3e44975184a7421b = new GridColumn[this.x26c511b92db96554.Length];
			for (int j = 0; j < this.x26c511b92db96554.Length; j++)
			{
				this.x3e44975184a7421b[j] = new GridColumn();
				this.x3e44975184a7421b[j].xea1c0bc64ab77594(this.x9a8772e3d2a72c37);
			}
			this.x956d50d3dc849ffe();
			this.x436f6f3ee14607e0();
		}

		// Token: 0x0600045C RID: 1116 RVA: 0x00018E78 File Offset: 0x00017E78
		private void x13adc72dec8fd64d(GridColumn[] x272ae358840118c0, ListSortDirection[] x33e1a4b5eb208cc5)
		{
			SortColumnsEventArgs sortColumnsEventArgs = new SortColumnsEventArgs(this.Grid.PrimaryGrid, x272ae358840118c0, x33e1a4b5eb208cc5);
			this.OnBeforeApplySort(sortColumnsEventArgs);
			this.Grid.PrimaryGrid.xd1cd3159d407b7fd((sortColumnsEventArgs.SortColumns.Length != 0 && this.EnableGrouping) ? sortColumnsEventArgs.SortColumns[0] : null);
			this.Grid.PrimaryGrid.SetSort(sortColumnsEventArgs.SortColumns, sortColumnsEventArgs.SortDirections);
		}

		// Token: 0x0600045D RID: 1117 RVA: 0x00018EE8 File Offset: 0x00017EE8
		private void xa5f086d2d991ce91(int xc4932df8b360aab4, int xc0c4c459c6ccbd00)
		{
			ArrayList arrayList = new ArrayList(this.x26c511b92db96554);
			ArrayList arrayList2 = new ArrayList(this.x0835ff38739ed7ac);
			GridColumn value = this.x26c511b92db96554[xc4932df8b360aab4];
			ListSortDirection listSortDirection = this.x0835ff38739ed7ac[xc4932df8b360aab4];
			arrayList.RemoveAt(xc4932df8b360aab4);
			arrayList2.RemoveAt(xc4932df8b360aab4);
			if (xc0c4c459c6ccbd00 > xc4932df8b360aab4)
			{
				xc0c4c459c6ccbd00--;
			}
			arrayList.Insert(xc0c4c459c6ccbd00, value);
			arrayList2.Insert(xc0c4c459c6ccbd00, listSortDirection);
			this.x13adc72dec8fd64d((GridColumn[])arrayList.ToArray(typeof(GridColumn)), (ListSortDirection[])arrayList2.ToArray(typeof(ListSortDirection)));
		}

		// Token: 0x0600045E RID: 1118 RVA: 0x00018F7C File Offset: 0x00017F7C
		private void x593802f1d292b7af(int xc0c4c459c6ccbd00, GridColumn xe3e287548b3d01f5)
		{
			ListSortDirection listSortDirection = ListSortDirection.Ascending;
			ArrayList arrayList = new ArrayList(this.x26c511b92db96554);
			ArrayList arrayList2 = new ArrayList(this.x0835ff38739ed7ac);
			arrayList.Insert(xc0c4c459c6ccbd00, xe3e287548b3d01f5);
			arrayList2.Insert(xc0c4c459c6ccbd00, listSortDirection);
			this.x13adc72dec8fd64d((GridColumn[])arrayList.ToArray(typeof(GridColumn)), (ListSortDirection[])arrayList2.ToArray(typeof(ListSortDirection)));
		}

		// Token: 0x0600045F RID: 1119 RVA: 0x00018FE8 File Offset: 0x00017FE8
		private void x72fc4fb5ee1c9caf(GridColumn xe3e287548b3d01f5)
		{
			ArrayList arrayList = new ArrayList(this.x26c511b92db96554);
			ArrayList arrayList2 = new ArrayList(this.x0835ff38739ed7ac);
			int num = arrayList.IndexOf(xe3e287548b3d01f5);
			if (num != -1)
			{
				arrayList.RemoveAt(num);
				arrayList2.RemoveAt(num);
			}
			this.x13adc72dec8fd64d((GridColumn[])arrayList.ToArray(typeof(GridColumn)), (ListSortDirection[])arrayList2.ToArray(typeof(ListSortDirection)));
		}

		// Token: 0x06000460 RID: 1120 RVA: 0x00019058 File Offset: 0x00018058
		private void x7758f10feabd97bc(int xc0c4c459c6ccbd00)
		{
			ArrayList arrayList = new ArrayList(this.x26c511b92db96554);
			ArrayList arrayList2 = new ArrayList(this.x0835ff38739ed7ac);
			arrayList.RemoveAt(xc0c4c459c6ccbd00);
			arrayList2.RemoveAt(xc0c4c459c6ccbd00);
			this.x13adc72dec8fd64d((GridColumn[])arrayList.ToArray(typeof(GridColumn)), (ListSortDirection[])arrayList2.ToArray(typeof(ListSortDirection)));
		}

		// Token: 0x06000461 RID: 1121 RVA: 0x000190BC File Offset: 0x000180BC
		protected override void OnHandleCreated(EventArgs e)
		{
			base.OnHandleCreated(e);
			this.x436f6f3ee14607e0();
		}

		// Token: 0x06000462 RID: 1122 RVA: 0x000190CC File Offset: 0x000180CC
		internal void xc00d126d33ba98b1()
		{
			if (base.IsHandleCreated)
			{
				this.x436f6f3ee14607e0();
			}
		}

		// Token: 0x06000463 RID: 1123 RVA: 0x000190DC File Offset: 0x000180DC
		private void x436f6f3ee14607e0()
		{
			bool flag = this.RightToLeft == RightToLeft.Yes;
			int num = base.ClientRectangle.Height - this.x9077f305c3fd8da1 * 2 - this.x624c4b22da43f1f8;
			float num2;
			float num3;
			if (this.x26c511b92db96554.Length <= 1)
			{
				num2 = 0f;
				num3 = (float)(base.ClientRectangle.Y + base.ClientRectangle.Height / 2 - this.x624c4b22da43f1f8 / 2);
			}
			else
			{
				num2 = Math.Min((float)num / (float)(this.x26c511b92db96554.Length - 1), 10f);
				num3 = (float)(base.ClientRectangle.Y + base.ClientRectangle.Height / 2) - ((float)this.x624c4b22da43f1f8 + num2 * (float)(this.x26c511b92db96554.Length - 1)) / 2f;
			}
			using (Graphics graphics = base.CreateGraphics())
			{
				int num4 = flag ? (base.ClientRectangle.Right - this.xb384c86738fd7c19) : this.xb384c86738fd7c19;
				for (int i = 0; i < this.x26c511b92db96554.Length; i++)
				{
					GridColumn gridColumn = this.x26c511b92db96554[i];
					ListSortDirection listSortDirection = this.x0835ff38739ed7ac[i];
					GridColumn gridColumn2 = this.x3e44975184a7421b[i];
					gridColumn2.HeaderText = gridColumn.HeaderText;
					gridColumn2.SetSortIndicator((listSortDirection == ListSortDirection.Ascending) ? SortOrder.Ascending : SortOrder.Descending);
					gridColumn2.Font = this.Font;
					int num5;
					using (TextFormattingInformation textFormat = gridColumn.CreateTextFormat(GridColumnTextFormatType.Header))
					{
						num5 = IndependentText.MeasureText(graphics, gridColumn.HeaderText, this.Font, textFormat).Width + 8 + this.x82750971ca0f16e8;
					}
					Rectangle xda73fcb97c77d = new Rectangle(flag ? (num4 - num5) : num4, Convert.ToInt32(num3), num5, this.x624c4b22da43f1f8);
					gridColumn2.xb7ae55095fddecd9(xda73fcb97c77d);
					if (flag)
					{
						num4 -= num5 - this.x30a6287300905d29;
					}
					else
					{
						num4 += num5 + this.x30a6287300905d29;
					}
					num3 += num2;
				}
			}
			base.Invalidate();
		}

		// Token: 0x06000464 RID: 1124 RVA: 0x00019318 File Offset: 0x00018318
		private int xfa7e811c9c2e2625(Point x13d4cb8d1bd20347)
		{
			for (int i = 0; i < this.x26c511b92db96554.Length; i++)
			{
				if (this.x3e44975184a7421b[i].Bounds.Contains(x13d4cb8d1bd20347))
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06000465 RID: 1125 RVA: 0x00019354 File Offset: 0x00018354
		protected override void OnMouseDown(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.x93cd47bf7b0e4414 = this.xfa7e811c9c2e2625(new Point(e.X, e.Y));
				if (this.x93cd47bf7b0e4414 != -1)
				{
					this.x9820a8b63818d22d = new Point(e.X, e.Y);
				}
				else
				{
					this.x9820a8b63818d22d = new Point(-1, -1);
				}
			}
			base.OnMouseDown(e);
		}

		// Token: 0x06000466 RID: 1126 RVA: 0x000193C4 File Offset: 0x000183C4
		protected override void OnMouseUp(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				if (this.x25eed74eb4ee59a1 != -1)
				{
					if (!base.ClientRectangle.Contains(e.X, e.Y))
					{
						this.x7758f10feabd97bc(this.x25eed74eb4ee59a1);
						return;
					}
					this.xa5f086d2d991ce91(this.x25eed74eb4ee59a1, this.xa8701311de4f2006);
				}
				else if (this.x93cd47bf7b0e4414 != -1)
				{
					this.x104587adb17ddeef(this.x93cd47bf7b0e4414);
				}
			}
			base.OnMouseUp(e);
		}

		// Token: 0x06000467 RID: 1127 RVA: 0x00019440 File Offset: 0x00018440
		protected override void OnMouseMove(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && this.x9820a8b63818d22d != new Point(-1, -1))
			{
				if (this.x25eed74eb4ee59a1 == -1)
				{
					Rectangle rectangle = new Rectangle(this.x9820a8b63818d22d, new Size(0, 0));
					rectangle.Inflate(SystemInformation.DragSize.Width, SystemInformation.DragSize.Height);
					if (!rectangle.Contains(e.X, e.Y))
					{
						this.x25eed74eb4ee59a1 = this.x93cd47bf7b0e4414;
					}
				}
				if (this.x25eed74eb4ee59a1 != -1)
				{
					this.x961449b60cf35805(new Point(e.X, e.Y));
				}
			}
			base.OnMouseMove(e);
		}

		// Token: 0x06000468 RID: 1128 RVA: 0x000194FC File Offset: 0x000184FC
		protected override void WndProc(ref Message m)
		{
			if (m.Msg == 533)
			{
				this.x20304545453d4b87();
				return;
			}
			base.WndProc(ref m);
		}

		// Token: 0x06000469 RID: 1129 RVA: 0x0001951C File Offset: 0x0001851C
		private void x20304545453d4b87()
		{
			this.x25eed74eb4ee59a1 = -1;
			this.x5750b70055efd1e8 = null;
		}

		// Token: 0x0600046A RID: 1130 RVA: 0x0001952C File Offset: 0x0001852C
		private void x104587adb17ddeef(int xc0c4c459c6ccbd00)
		{
			this.x0835ff38739ed7ac[xc0c4c459c6ccbd00] = ((this.x0835ff38739ed7ac[xc0c4c459c6ccbd00] == ListSortDirection.Ascending) ? ListSortDirection.Descending : ListSortDirection.Ascending);
			this.x13adc72dec8fd64d(this.x26c511b92db96554, this.x0835ff38739ed7ac);
		}

		// Token: 0x0600046B RID: 1131 RVA: 0x00019558 File Offset: 0x00018558
		internal void xe28f535d61c67e4a(bool xef7c496d8b1184f5)
		{
			if (!xef7c496d8b1184f5 && this.x5750b70055efd1e8 != null && this.xa8701311de4f2006 != -1)
			{
				this.x593802f1d292b7af(this.xa8701311de4f2006, this.x5750b70055efd1e8);
			}
			this.x5750b70055efd1e8 = null;
		}

		// Token: 0x0600046C RID: 1132 RVA: 0x00019588 File Offset: 0x00018588
		internal void x73e47da3b48300b2(GridColumn xe3e287548b3d01f5, Point x13d4cb8d1bd20347)
		{
			Point point = base.PointToClient(x13d4cb8d1bd20347);
			if (base.ClientRectangle.Contains(point) && Array.IndexOf<GridColumn>(this.x26c511b92db96554, xe3e287548b3d01f5) == -1)
			{
				this.x5750b70055efd1e8 = xe3e287548b3d01f5;
				this.x961449b60cf35805(point);
				return;
			}
			this.x5750b70055efd1e8 = null;
		}

		// Token: 0x0600046D RID: 1133 RVA: 0x000195D4 File Offset: 0x000185D4
		private void x961449b60cf35805(Point x13d4cb8d1bd20347)
		{
			int xa8701311de4f = 0;
			for (int i = 0; i < this.x26c511b92db96554.Length; i++)
			{
				Rectangle bounds = this.x3e44975184a7421b[i].Bounds;
				if ((this.RightToLeft == RightToLeft.Yes && x13d4cb8d1bd20347.X < bounds.X + bounds.Width / 2) || (this.RightToLeft != RightToLeft.Yes && x13d4cb8d1bd20347.X > bounds.X + bounds.Width / 2))
				{
					xa8701311de4f = i + 1;
				}
			}
			this.xa8701311de4f2006 = xa8701311de4f;
		}

		// Token: 0x0600046E RID: 1134 RVA: 0x00019658 File Offset: 0x00018658
		private void x956d50d3dc849ffe()
		{
			if (this.AutoSize)
			{
				int num = this.xabcd5513b727b20d;
				try
				{
					base.Size = new Size(base.Width, base.PreferredSize.Height);
				}
				finally
				{
					this.xabcd5513b727b20d = num;
				}
			}
		}

		// Token: 0x0600046F RID: 1135 RVA: 0x000196BC File Offset: 0x000186BC
		protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
		{
			if ((specified & BoundsSpecified.Height) != BoundsSpecified.None)
			{
				this.xabcd5513b727b20d = height;
			}
			if (this.AutoSize)
			{
				height = base.PreferredSize.Height;
			}
			base.SetBoundsCore(x, y, width, height, specified);
		}

		// Token: 0x06000470 RID: 1136 RVA: 0x000196FC File Offset: 0x000186FC
		public override Size GetPreferredSize(Size proposedSize)
		{
			if (this.AutoSize)
			{
				if (this.x26c511b92db96554.Length < 2)
				{
					proposedSize.Height = this.x624c4b22da43f1f8 * 2;
				}
				else
				{
					proposedSize.Height = this.x624c4b22da43f1f8 + 12 + (this.x26c511b92db96554.Length - 1) * 10;
				}
			}
			return new Size(base.GetPreferredSize(proposedSize).Width, proposedSize.Height);
		}

		// Token: 0x06000471 RID: 1137 RVA: 0x00019768 File Offset: 0x00018768
		protected override void OnParentChanged(EventArgs e)
		{
			base.OnParentChanged(e);
			this.x956d50d3dc849ffe();
		}

		// Token: 0x17000117 RID: 279
		// (get) Token: 0x06000472 RID: 1138 RVA: 0x00019778 File Offset: 0x00018778
		// (set) Token: 0x06000473 RID: 1139 RVA: 0x00019780 File Offset: 0x00018780
		[DefaultValue(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[Browsable(true)]
		public override bool AutoSize
		{
			get
			{
				return base.AutoSize;
			}
			set
			{
				if (value != base.AutoSize)
				{
					base.AutoSize = value;
					this.x956d50d3dc849ffe();
				}
			}
		}

		// Token: 0x17000118 RID: 280
		// (get) Token: 0x06000474 RID: 1140 RVA: 0x00019798 File Offset: 0x00018798
		// (set) Token: 0x06000475 RID: 1141 RVA: 0x000197A0 File Offset: 0x000187A0
		[Browsable(false)]
		public override Image BackgroundImage
		{
			get
			{
				return base.BackgroundImage;
			}
			set
			{
				base.BackgroundImage = value;
			}
		}

		// Token: 0x17000119 RID: 281
		// (get) Token: 0x06000476 RID: 1142 RVA: 0x000197AC File Offset: 0x000187AC
		// (set) Token: 0x06000477 RID: 1143 RVA: 0x000197B4 File Offset: 0x000187B4
		[Browsable(false)]
		public override ImageLayout BackgroundImageLayout
		{
			get
			{
				return base.BackgroundImageLayout;
			}
			set
			{
				base.BackgroundImageLayout = value;
			}
		}

		// Token: 0x1700011A RID: 282
		// (get) Token: 0x06000478 RID: 1144 RVA: 0x000197C0 File Offset: 0x000187C0
		// (set) Token: 0x06000479 RID: 1145 RVA: 0x000197C8 File Offset: 0x000187C8
		[Browsable(false)]
		public override Color BackColor
		{
			get
			{
				return base.BackColor;
			}
			set
			{
				base.BackColor = value;
			}
		}

		// Token: 0x1700011B RID: 283
		// (get) Token: 0x0600047A RID: 1146 RVA: 0x000197D4 File Offset: 0x000187D4
		protected override Size DefaultSize
		{
			get
			{
				return new Size(250, 38);
			}
		}

		// Token: 0x1700011C RID: 284
		// (get) Token: 0x0600047B RID: 1147 RVA: 0x000197E4 File Offset: 0x000187E4
		// (set) Token: 0x0600047C RID: 1148 RVA: 0x000197EC File Offset: 0x000187EC
		[DefaultValue("Drag a column header here to sort by that column.")]
		public override string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				base.Text = value;
				if (this.x26c511b92db96554.Length == 0)
				{
					base.Invalidate();
				}
			}
		}

		// Token: 0x1700011D RID: 285
		// (get) Token: 0x0600047D RID: 1149 RVA: 0x00019808 File Offset: 0x00018808
		// (set) Token: 0x0600047E RID: 1150 RVA: 0x00019810 File Offset: 0x00018810
		private int xa8701311de4f2006
		{
			get
			{
				return this.xb9b45c47f3e94991;
			}
			set
			{
				if (value != this.xb9b45c47f3e94991)
				{
					this.xb9b45c47f3e94991 = value;
					base.Invalidate();
				}
			}
		}

		// Token: 0x1700011E RID: 286
		// (get) Token: 0x0600047F RID: 1151 RVA: 0x00019828 File Offset: 0x00018828
		// (set) Token: 0x06000480 RID: 1152 RVA: 0x00019830 File Offset: 0x00018830
		[Category("Appearance")]
		[Description("The type of border to draw in the control.")]
		[DefaultValue(typeof(SortBoxBorderStyle), "WholeBorder")]
		public SortBoxBorderStyle BorderStyle
		{
			get
			{
				return this.xacfbd7a08ba56c78;
			}
			set
			{
				this.xacfbd7a08ba56c78 = value;
				base.Invalidate();
			}
		}

		// Token: 0x1700011F RID: 287
		// (get) Token: 0x06000481 RID: 1153 RVA: 0x00019840 File Offset: 0x00018840
		// (set) Token: 0x06000482 RID: 1154 RVA: 0x00019848 File Offset: 0x00018848
		private int x25eed74eb4ee59a1
		{
			get
			{
				return this.x941965b1b4dee362;
			}
			set
			{
				if (this.x941965b1b4dee362 != value)
				{
					this.x941965b1b4dee362 = value;
					this.xb9b45c47f3e94991 = ((value != -1) ? 0 : -1);
					base.Invalidate();
				}
			}
		}

		// Token: 0x17000120 RID: 288
		// (get) Token: 0x06000483 RID: 1155 RVA: 0x00019870 File Offset: 0x00018870
		// (set) Token: 0x06000484 RID: 1156 RVA: 0x00019878 File Offset: 0x00018878
		private GridColumn x5750b70055efd1e8
		{
			get
			{
				return this.x6e073b7a8e9ec7ad;
			}
			set
			{
				if (value != this.x6e073b7a8e9ec7ad)
				{
					this.x6e073b7a8e9ec7ad = value;
					this.xb9b45c47f3e94991 = ((value != null) ? 0 : -1);
					base.Invalidate();
				}
			}
		}

		// Token: 0x17000121 RID: 289
		// (get) Token: 0x06000485 RID: 1157 RVA: 0x000198A0 File Offset: 0x000188A0
		// (set) Token: 0x06000486 RID: 1158 RVA: 0x000198A8 File Offset: 0x000188A8
		[DefaultValue(false)]
		[Category("Behavior")]
		[Description("Indicates whether grouping will be enabled for the first column.")]
		public bool EnableGrouping
		{
			get
			{
				return this.x5980b9db9f15be03;
			}
			set
			{
				if (value != this.x5980b9db9f15be03)
				{
					this.x5980b9db9f15be03 = value;
					if (this.Grid != null && this.x26c511b92db96554.Length != 0)
					{
						if (this.x5980b9db9f15be03)
						{
							this.Grid.PrimaryGrid.GroupColumn = this.x26c511b92db96554[0];
							return;
						}
						this.Grid.PrimaryGrid.GroupColumn = null;
					}
				}
			}
		}

		// Token: 0x17000122 RID: 290
		// (get) Token: 0x06000487 RID: 1159 RVA: 0x0001990C File Offset: 0x0001890C
		// (set) Token: 0x06000488 RID: 1160 RVA: 0x00019914 File Offset: 0x00018914
		[DefaultValue(null)]
		[Category("Behavior")]
		[Description("The grid which the control will sort.")]
		public SandGridBase Grid
		{
			get
			{
				return this.x3040c866fac95193;
			}
			set
			{
				if (value != this.x3040c866fac95193)
				{
					if (value != null && value.x5142973d45b32e92 != null)
					{
						throw new InvalidOperationException();
					}
					if (this.x3040c866fac95193 != null)
					{
						this.x3040c866fac95193.x5142973d45b32e92 = null;
						this.x3040c866fac95193.SortChanged -= this.xd691c593fb2614e1;
					}
					this.x3040c866fac95193 = value;
					if (this.x3040c866fac95193 != null)
					{
						this.x3040c866fac95193.x5142973d45b32e92 = this;
						this.x3040c866fac95193.SortChanged += this.xd691c593fb2614e1;
						GridColumn[] x94c6d9c743d;
						ListSortDirection[] x30193a48d57c0a;
						this.Grid.Rows.GetSort(out x94c6d9c743d, out x30193a48d57c0a);
						this.x6d325ba4caeba2b1(x94c6d9c743d, x30193a48d57c0a);
						return;
					}
					this.x6d325ba4caeba2b1(new GridColumn[0], new ListSortDirection[0]);
				}
			}
		}

		// Token: 0x17000123 RID: 291
		// (get) Token: 0x06000489 RID: 1161 RVA: 0x000199CC File Offset: 0x000189CC
		// (set) Token: 0x0600048A RID: 1162 RVA: 0x000199D4 File Offset: 0x000189D4
		[Description("The renderer in use by the control.")]
		[Category("Appearance")]
		public ISandGridRenderer Renderer
		{
			get
			{
				return this.x38870620fd380a6b;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				if (this.x38870620fd380a6b != null)
				{
					this.x38870620fd380a6b.RedrawNeeded -= this.x266134e26f4bcc76;
				}
				this.x38870620fd380a6b = value;
				if (this.x38870620fd380a6b != null)
				{
					this.x38870620fd380a6b.RedrawNeeded += this.x266134e26f4bcc76;
				}
				base.Invalidate();
			}
		}

		// Token: 0x0600048B RID: 1163 RVA: 0x00019A3C File Offset: 0x00018A3C
		private void x266134e26f4bcc76(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			base.Invalidate();
		}

		// Token: 0x0400014D RID: 333
		private ISandGridRenderer x38870620fd380a6b;

		// Token: 0x0400014E RID: 334
		private SandGridBase x3040c866fac95193;

		// Token: 0x0400014F RID: 335
		private InnerGrid x9a8772e3d2a72c37;

		// Token: 0x04000150 RID: 336
		private GridColumn[] x26c511b92db96554 = new GridColumn[0];

		// Token: 0x04000151 RID: 337
		private GridColumn[] x3e44975184a7421b = new GridColumn[0];

		// Token: 0x04000152 RID: 338
		private ListSortDirection[] x0835ff38739ed7ac = new ListSortDirection[0];

		// Token: 0x04000153 RID: 339
		private int x624c4b22da43f1f8 = GridRow.x993356576cc2bf99 + 1;

		// Token: 0x04000154 RID: 340
		private int x9077f305c3fd8da1 = 3;

		// Token: 0x04000155 RID: 341
		private int x30a6287300905d29 = 6;

		// Token: 0x04000156 RID: 342
		private int x82750971ca0f16e8 = 16;

		// Token: 0x04000157 RID: 343
		private int xb384c86738fd7c19 = 10;

		// Token: 0x04000158 RID: 344
		private SortBoxBorderStyle xacfbd7a08ba56c78 = SortBoxBorderStyle.WholeBorder;

		// Token: 0x04000159 RID: 345
		private int xabcd5513b727b20d;

		// Token: 0x0400015A RID: 346
		private bool x5980b9db9f15be03;

		// Token: 0x0400015B RID: 347
		private int x93cd47bf7b0e4414;

		// Token: 0x0400015C RID: 348
		private GridColumn x6e073b7a8e9ec7ad;

		// Token: 0x0400015D RID: 349
		private int xb9b45c47f3e94991 = -1;

		// Token: 0x0400015E RID: 350
		private int x941965b1b4dee362 = -1;

		// Token: 0x0400015F RID: 351
		private Point x9820a8b63818d22d = new Point(-1, -1);

		// Token: 0x04000160 RID: 352
		private SortColumnsEventHandler x2b4e23ce060078cb;

		// Token: 0x04000161 RID: 353
		private SortColumnsEventHandler xe4b44126a1b7c143;
	}
}
