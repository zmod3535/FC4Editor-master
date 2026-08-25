using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace TD.Util
{
	// Token: 0x02000025 RID: 37
	internal class xf8f9565783602018 : IDisposable
	{
		// Token: 0x1400000A RID: 10
		// (add) Token: 0x0600022D RID: 557 RVA: 0x0000AA88 File Offset: 0x00009A88
		// (remove) Token: 0x0600022E RID: 558 RVA: 0x0000AAA4 File Offset: 0x00009AA4
		public event xf8f9565783602018.x58986a4a0b75e5b5 x9b21ee8e7ceaada3;

		// Token: 0x0600022F RID: 559
		[DllImport("user32.dll")]
		private static extern bool SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int y, int cx, int cy, int flags);

		// Token: 0x06000230 RID: 560 RVA: 0x0000AAC0 File Offset: 0x00009AC0
		public xf8f9565783602018(Control control)
		{
			this.x43bec302f92080b9 = control;
			control.MouseMove += this.x51529e0468abe27e;
			control.MouseLeave += this.x664829383a59617c;
			control.MouseDown += this.x1c8953a8a8447816;
			control.MouseWheel += this.x5e1cbc67acfe3317;
			control.Disposed += this.x77d9086325b6e538;
			control.FontChanged += this.xb27df3b0091b2a36;
			this.xa6607dfd4b3038ad = new xf8f9565783602018.xab7df35839b7399e(this);
			this.xa6607dfd4b3038ad.MouseMove += this.x1aaaf41037533886;
			this.x537a4001020fd4c7 = new Timer();
			this.x537a4001020fd4c7.Interval = SystemInformation.DoubleClickTime;
			this.x537a4001020fd4c7.Tick += this.x79a58a5d2c65c5a4;
		}

		// Token: 0x06000231 RID: 561 RVA: 0x0000ABA4 File Offset: 0x00009BA4
		public void Dispose()
		{
			if (!this.x0e75cd3866dbb930)
			{
				this.x47c79a4d207183de();
				this.xa6607dfd4b3038ad.MouseMove -= this.x1aaaf41037533886;
				this.xa6607dfd4b3038ad.Dispose();
				this.xa6607dfd4b3038ad = null;
				this.x43bec302f92080b9.MouseMove -= this.x51529e0468abe27e;
				this.x43bec302f92080b9.MouseLeave -= this.x664829383a59617c;
				this.x43bec302f92080b9.MouseDown -= this.x1c8953a8a8447816;
				this.x43bec302f92080b9.MouseWheel -= this.x5e1cbc67acfe3317;
				this.x43bec302f92080b9.Disposed -= this.x77d9086325b6e538;
				this.x43bec302f92080b9.FontChanged -= this.xb27df3b0091b2a36;
				this.x43bec302f92080b9 = null;
				this.x537a4001020fd4c7.Tick -= this.x79a58a5d2c65c5a4;
				this.x537a4001020fd4c7.Dispose();
				this.x0e75cd3866dbb930 = true;
			}
		}

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x06000232 RID: 562 RVA: 0x0000ACA8 File Offset: 0x00009CA8
		// (set) Token: 0x06000233 RID: 563 RVA: 0x0000ACB0 File Offset: 0x00009CB0
		public bool xa6e4f463e64a5987
		{
			get
			{
				return this.xeefb7b23d49f09bc;
			}
			set
			{
				this.xeefb7b23d49f09bc = value;
			}
		}

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x06000234 RID: 564 RVA: 0x0000ACBC File Offset: 0x00009CBC
		// (set) Token: 0x06000235 RID: 565 RVA: 0x0000ACCC File Offset: 0x00009CCC
		public bool x9ab519b46dd91330
		{
			get
			{
				return this.xa6607dfd4b3038ad.x9ab519b46dd91330;
			}
			set
			{
				this.xa6607dfd4b3038ad.x9ab519b46dd91330 = value;
			}
		}

		// Token: 0x06000236 RID: 566 RVA: 0x0000ACDC File Offset: 0x00009CDC
		private static bool x7fb2e1ce54a27086()
		{
			bool result = false;
			if (Environment.OSVersion.Platform == PlatformID.Win32NT)
			{
				result = (Environment.OSVersion.Version >= new Version(5, 1, 0, 0));
			}
			return result;
		}

		// Token: 0x06000237 RID: 567 RVA: 0x0000AD14 File Offset: 0x00009D14
		public void x4402a69f607144e3(Point xb9c2cfae130d9256, string xb41faee6912a2313)
		{
			this.xa6607dfd4b3038ad.Text = xb41faee6912a2313;
			Size size;
			Screen screen;
			if (2147483647 != 0)
			{
				size = Size.Ceiling(this.xa6607dfd4b3038ad.x0a8f2a18d3b53839(xb41faee6912a2313));
				size.Height += 4;
				size.Width += 4;
				xb9c2cfae130d9256.Y += 19;
				screen = Screen.FromPoint(xb9c2cfae130d9256);
				if (xb9c2cfae130d9256.X < screen.Bounds.Left)
				{
					xb9c2cfae130d9256.X = screen.Bounds.Left;
				}
			}
			if (xb9c2cfae130d9256.X + size.Width > screen.Bounds.Right)
			{
				xb9c2cfae130d9256.X = screen.Bounds.Right - size.Width;
				if (xb9c2cfae130d9256.X < screen.Bounds.Left)
				{
					if (false)
					{
						return;
					}
					return;
				}
			}
			if (xb9c2cfae130d9256.Y < screen.Bounds.Top)
			{
				xb9c2cfae130d9256.Y = screen.Bounds.Top;
			}
			if (xb9c2cfae130d9256.Y + size.Height > screen.Bounds.Bottom)
			{
				xb9c2cfae130d9256.Y = screen.Bounds.Bottom - size.Height;
				if (xb9c2cfae130d9256.Y < screen.Bounds.Top)
				{
					return;
				}
				xb9c2cfae130d9256.X++;
			}
			xf8f9565783602018.SetWindowPos(this.xa6607dfd4b3038ad.Handle, -1, xb9c2cfae130d9256.X, xb9c2cfae130d9256.Y, size.Width, size.Height, 80);
			VisualStyleElement normal = VisualStyleElement.ToolTip.Standard.Normal;
			if (Application.RenderWithVisualStyles && VisualStyleRenderer.IsElementDefined(normal))
			{
				VisualStyleRenderer visualStyleRenderer = new VisualStyleRenderer(normal);
				using (Graphics graphics = this.xa6607dfd4b3038ad.CreateGraphics())
				{
					this.xa6607dfd4b3038ad.Region = visualStyleRenderer.GetBackgroundRegion(graphics, this.xa6607dfd4b3038ad.ClientRectangle);
				}
			}
			this.xa6607dfd4b3038ad.Invalidate();
			this.x364c1e3b189d47fe = true;
			if (this.x9238f6a5f034aeb5 != null)
			{
				this.x9238f6a5f034aeb5.Deactivate -= this.xdef19f2ef265bf1e;
			}
			this.x9238f6a5f034aeb5 = this.x624fa8b017460890(this.x43bec302f92080b9);
			if (this.x9238f6a5f034aeb5 != null)
			{
				this.x9238f6a5f034aeb5.Deactivate += this.xdef19f2ef265bf1e;
				this.xa6607dfd4b3038ad.Owner = this.x9238f6a5f034aeb5;
			}
		}

		// Token: 0x06000238 RID: 568 RVA: 0x0000AFC4 File Offset: 0x00009FC4
		public void x47c79a4d207183de()
		{
			this.xa6607dfd4b3038ad.Owner = null;
			this.xa6607dfd4b3038ad.Visible = false;
			this.x364c1e3b189d47fe = false;
			if (this.x9238f6a5f034aeb5 != null)
			{
				this.x9238f6a5f034aeb5.Deactivate -= this.xdef19f2ef265bf1e;
				this.x9238f6a5f034aeb5 = null;
			}
		}

		// Token: 0x06000239 RID: 569 RVA: 0x0000B018 File Offset: 0x0000A018
		private void x51529e0468abe27e(object xe0292b9ed559da7d, MouseEventArgs xfbf34718e704c6bc)
		{
			if (xfbf34718e704c6bc.Button != MouseButtons.None)
			{
				return;
			}
			if (this.x364c1e3b189d47fe)
			{
				string text = this.x9b21ee8e7ceaada3(new Point(xfbf34718e704c6bc.X, xfbf34718e704c6bc.Y));
				if (text == null || text.Length == 0)
				{
					this.x47c79a4d207183de();
					return;
				}
				if (text.Length != 0 && text != this.xa6607dfd4b3038ad.Text)
				{
					this.x4402a69f607144e3(Cursor.Position, text);
					return;
				}
			}
			else
			{
				Point left = new Point(xfbf34718e704c6bc.X, xfbf34718e704c6bc.Y);
				if (left != this.xa639e9f791585165)
				{
					this.xa639e9f791585165 = left;
					this.x537a4001020fd4c7.Enabled = false;
					this.x537a4001020fd4c7.Enabled = true;
				}
			}
		}

		// Token: 0x0600023A RID: 570 RVA: 0x0000B0D0 File Offset: 0x0000A0D0
		private void x79a58a5d2c65c5a4(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			this.x537a4001020fd4c7.Enabled = false;
			Point point = this.x43bec302f92080b9.PointToClient(Cursor.Position);
			if (!this.x43bec302f92080b9.ClientRectangle.Contains(point))
			{
				return;
			}
			string text = this.x9b21ee8e7ceaada3(point);
			if (text == null || text.Length == 0)
			{
				return;
			}
			Form form = this.x624fa8b017460890(this.x43bec302f92080b9);
			Form activeForm = Form.ActiveForm;
			bool flag = form != null && activeForm != null && (activeForm == form || activeForm == form.Owner);
			if (flag && this.x43bec302f92080b9.Visible)
			{
				this.x4402a69f607144e3(Cursor.Position, text);
			}
		}

		// Token: 0x0600023B RID: 571 RVA: 0x0000B178 File Offset: 0x0000A178
		private Form x624fa8b017460890(Control x3c4da2980d043c95)
		{
			while (x3c4da2980d043c95.Parent != null)
			{
				x3c4da2980d043c95 = x3c4da2980d043c95.Parent;
			}
			return x3c4da2980d043c95 as Form;
		}

		// Token: 0x0600023C RID: 572 RVA: 0x0000B194 File Offset: 0x0000A194
		private void x664829383a59617c(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			if (this.x364c1e3b189d47fe)
			{
				this.x47c79a4d207183de();
			}
			this.x537a4001020fd4c7.Enabled = false;
		}

		// Token: 0x0600023D RID: 573 RVA: 0x0000B1B0 File Offset: 0x0000A1B0
		private void x1c8953a8a8447816(object xe0292b9ed559da7d, MouseEventArgs xfbf34718e704c6bc)
		{
			if (this.x364c1e3b189d47fe)
			{
				this.x47c79a4d207183de();
			}
			this.x537a4001020fd4c7.Enabled = false;
		}

		// Token: 0x0600023E RID: 574 RVA: 0x0000B1CC File Offset: 0x0000A1CC
		private void x5e1cbc67acfe3317(object xe0292b9ed559da7d, MouseEventArgs xfbf34718e704c6bc)
		{
			if (this.x364c1e3b189d47fe)
			{
				this.x47c79a4d207183de();
			}
			this.x537a4001020fd4c7.Enabled = false;
		}

		// Token: 0x0600023F RID: 575 RVA: 0x0000B1E8 File Offset: 0x0000A1E8
		private void x1aaaf41037533886(object xe0292b9ed559da7d, MouseEventArgs xfbf34718e704c6bc)
		{
			this.x47c79a4d207183de();
		}

		// Token: 0x06000240 RID: 576 RVA: 0x0000B1F0 File Offset: 0x0000A1F0
		private void xdef19f2ef265bf1e(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			this.x47c79a4d207183de();
		}

		// Token: 0x06000241 RID: 577 RVA: 0x0000B1F8 File Offset: 0x0000A1F8
		private void x77d9086325b6e538(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			this.Dispose();
		}

		// Token: 0x06000242 RID: 578 RVA: 0x0000B200 File Offset: 0x0000A200
		private void xb27df3b0091b2a36(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			this.xa6607dfd4b3038ad.Font = this.x43bec302f92080b9.Font;
		}

		// Token: 0x040000C3 RID: 195
		private const int x77bf04ec211c4a37 = 16;

		// Token: 0x040000C4 RID: 196
		private const int x339acab5bf3e83ae = 64;

		// Token: 0x040000C5 RID: 197
		private const int xdbb7427772b219d6 = 128;

		// Token: 0x040000C6 RID: 198
		private const int xb644deafcaa222c4 = 2;

		// Token: 0x040000C7 RID: 199
		private const int xb8a822e576f3bf60 = 1;

		// Token: 0x040000C8 RID: 200
		private Control x43bec302f92080b9;

		// Token: 0x040000C9 RID: 201
		private bool x364c1e3b189d47fe;

		// Token: 0x040000CA RID: 202
		private bool xeefb7b23d49f09bc = true;

		// Token: 0x040000CB RID: 203
		private bool x0e75cd3866dbb930;

		// Token: 0x040000CC RID: 204
		private Point xa639e9f791585165;

		// Token: 0x040000CD RID: 205
		private xf8f9565783602018.xab7df35839b7399e xa6607dfd4b3038ad;

		// Token: 0x040000CE RID: 206
		private Timer x537a4001020fd4c7;

		// Token: 0x040000CF RID: 207
		private Form x9238f6a5f034aeb5;

		// Token: 0x02000026 RID: 38
		// (Invoke) Token: 0x06000244 RID: 580
		internal delegate string x58986a4a0b75e5b5(Point location);

		// Token: 0x02000027 RID: 39
		private class xab7df35839b7399e : Form
		{
			// Token: 0x06000247 RID: 583
			[DllImport("user32.dll")]
			private static extern bool SystemParametersInfo(int nAction, int nParam, ref int i, int nUpdate);

			// Token: 0x06000248 RID: 584 RVA: 0x0000B218 File Offset: 0x0000A218
			public xab7df35839b7399e(xf8f9565783602018 tooltips)
			{
				this.xac1c850120b1f254 = tooltips;
				base.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
				this.Font = tooltips.x43bec302f92080b9.Font;
				this.xae3b2752a89e7464 = (TextFormatFlags.NoClipping | TextFormatFlags.VerticalCenter);
				base.ShowInTaskbar = false;
				base.FormBorderStyle = FormBorderStyle.None;
				base.ControlBox = false;
				base.StartPosition = FormStartPosition.Manual;
			}

			// Token: 0x170000AD RID: 173
			// (get) Token: 0x06000249 RID: 585 RVA: 0x0000B278 File Offset: 0x0000A278
			// (set) Token: 0x0600024A RID: 586 RVA: 0x0000B290 File Offset: 0x0000A290
			public bool x9ab519b46dd91330
			{
				get
				{
					return (this.xae3b2752a89e7464 & TextFormatFlags.HidePrefix) != TextFormatFlags.HidePrefix;
				}
				set
				{
					if (value)
					{
						this.xae3b2752a89e7464 |= TextFormatFlags.HidePrefix;
						this.xae3b2752a89e7464 &= ~TextFormatFlags.NoPrefix;
						return;
					}
					this.xae3b2752a89e7464 &= ~TextFormatFlags.HidePrefix;
					this.xae3b2752a89e7464 |= TextFormatFlags.NoPrefix;
				}
			}

			// Token: 0x0600024B RID: 587 RVA: 0x0000B2EC File Offset: 0x0000A2EC
			public SizeF x0a8f2a18d3b53839(string xb41faee6912a2313)
			{
				SizeF result;
				using (Graphics graphics = base.CreateGraphics())
				{
					VisualStyleElement normal = VisualStyleElement.ToolTip.Standard.Normal;
					if (Application.RenderWithVisualStyles && VisualStyleRenderer.IsElementDefined(normal))
					{
						VisualStyleRenderer visualStyleRenderer = new VisualStyleRenderer(normal);
						Rectangle textExtent = visualStyleRenderer.GetTextExtent(graphics, xb41faee6912a2313, TextFormatFlags.Default);
						result = visualStyleRenderer.GetBackgroundExtent(graphics, textExtent).Size;
					}
					else
					{
						SizeF sizeF = TextRenderer.MeasureText(graphics, xb41faee6912a2313, this.Font, new Size(SystemInformation.PrimaryMonitorSize.Width, int.MaxValue), this.xae3b2752a89e7464);
						sizeF.Width -= 2f;
						sizeF.Height += 2f;
						result = sizeF;
					}
				}
				return result;
			}

			// Token: 0x170000AE RID: 174
			// (get) Token: 0x0600024C RID: 588 RVA: 0x0000B3C8 File Offset: 0x0000A3C8
			protected override CreateParams CreateParams
			{
				get
				{
					CreateParams createParams = base.CreateParams;
					if (this.xac1c850120b1f254 != null && this.xac1c850120b1f254.xa6e4f463e64a5987 && xf8f9565783602018.xab7df35839b7399e.x3b1aa41797c18588)
					{
						createParams.ClassStyle |= 131072;
					}
					return createParams;
				}
			}

			// Token: 0x170000AF RID: 175
			// (get) Token: 0x0600024D RID: 589 RVA: 0x0000B40C File Offset: 0x0000A40C
			private static bool x3b1aa41797c18588
			{
				get
				{
					int value = 0;
					if (!xf8f9565783602018.x7fb2e1ce54a27086())
					{
						return false;
					}
					xf8f9565783602018.xab7df35839b7399e.SystemParametersInfo(4132, 0, ref value, 0);
					return Convert.ToBoolean(value);
				}
			}

			// Token: 0x0600024E RID: 590 RVA: 0x0000B43C File Offset: 0x0000A43C
			protected override void Dispose(bool disposing)
			{
				base.Dispose(disposing);
			}

			// Token: 0x0600024F RID: 591 RVA: 0x0000B448 File Offset: 0x0000A448
			protected override void OnPaint(PaintEventArgs e)
			{
				VisualStyleElement normal = VisualStyleElement.ToolTip.Standard.Normal;
				if (Application.RenderWithVisualStyles && VisualStyleRenderer.IsElementDefined(normal))
				{
					VisualStyleRenderer visualStyleRenderer = new VisualStyleRenderer(normal);
					visualStyleRenderer.DrawBackground(e.Graphics, base.ClientRectangle);
					Rectangle textExtent = visualStyleRenderer.GetTextExtent(e.Graphics, base.ClientRectangle, this.Text, this.xae3b2752a89e7464);
					textExtent.X = base.ClientRectangle.X + base.ClientRectangle.Width / 2 - textExtent.Width / 2;
					textExtent.Y = base.ClientRectangle.Y + base.ClientRectangle.Height / 2 - textExtent.Height / 2;
					visualStyleRenderer.DrawText(e.Graphics, textExtent, this.Text, false, this.xae3b2752a89e7464);
					return;
				}
				e.Graphics.FillRectangle(SystemBrushes.Info, base.ClientRectangle);
				Pen pen = SystemInformation.HighContrast ? SystemPens.InfoText : SystemPens.Control;
				e.Graphics.DrawLine(pen, base.ClientRectangle.Left, base.ClientRectangle.Top, base.ClientRectangle.Right, base.ClientRectangle.Top);
				e.Graphics.DrawLine(pen, base.ClientRectangle.Left, base.ClientRectangle.Top, base.ClientRectangle.Left, base.ClientRectangle.Bottom);
				e.Graphics.DrawLine(SystemPens.InfoText, base.ClientRectangle.Left, base.ClientRectangle.Bottom - 1, base.ClientRectangle.Right, base.ClientRectangle.Bottom - 1);
				e.Graphics.DrawLine(SystemPens.InfoText, base.ClientRectangle.Right - 1, base.ClientRectangle.Top, base.ClientRectangle.Right - 1, base.ClientRectangle.Bottom);
				Rectangle clientRectangle = base.ClientRectangle;
				clientRectangle.Inflate(-2, -2);
				TextRenderer.DrawText(e.Graphics, this.Text, this.Font, clientRectangle, SystemColors.InfoText, this.xae3b2752a89e7464);
			}

			// Token: 0x040000D1 RID: 209
			private const int x3e8b9d6faeff6586 = 32;

			// Token: 0x040000D2 RID: 210
			private const int x2b7f5d3ca7ec1edf = -2147483648;

			// Token: 0x040000D3 RID: 211
			private const int xd708511d2241a4fb = 131072;

			// Token: 0x040000D4 RID: 212
			private const int x836e53e090609b16 = 4132;

			// Token: 0x040000D5 RID: 213
			private xf8f9565783602018 xac1c850120b1f254;

			// Token: 0x040000D6 RID: 214
			private TextFormatFlags xae3b2752a89e7464;
		}
	}
}
