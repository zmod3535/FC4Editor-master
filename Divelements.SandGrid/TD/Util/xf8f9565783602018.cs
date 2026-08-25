using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TD.Util
{
	// Token: 0x0200001C RID: 28
	internal class xf8f9565783602018 : IDisposable
	{
		// Token: 0x14000010 RID: 16
		// (add) Token: 0x06000393 RID: 915 RVA: 0x00015514 File Offset: 0x00014514
		// (remove) Token: 0x06000394 RID: 916 RVA: 0x00015530 File Offset: 0x00014530
		public event xf8f9565783602018.x58986a4a0b75e5b5 x9b21ee8e7ceaada3;

		// Token: 0x06000395 RID: 917
		[DllImport("user32.dll")]
		private static extern bool SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int y, int cx, int cy, int flags);

		// Token: 0x06000396 RID: 918 RVA: 0x0001554C File Offset: 0x0001454C
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

		// Token: 0x06000397 RID: 919 RVA: 0x00015630 File Offset: 0x00014630
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

		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x06000398 RID: 920 RVA: 0x00015734 File Offset: 0x00014734
		// (set) Token: 0x06000399 RID: 921 RVA: 0x0001573C File Offset: 0x0001473C
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

		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x0600039A RID: 922 RVA: 0x00015748 File Offset: 0x00014748
		// (set) Token: 0x0600039B RID: 923 RVA: 0x00015758 File Offset: 0x00014758
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

		// Token: 0x0600039C RID: 924 RVA: 0x00015768 File Offset: 0x00014768
		private static bool x7fb2e1ce54a27086()
		{
			bool result = false;
			if (Environment.OSVersion.Platform == PlatformID.Win32NT)
			{
				result = (Environment.OSVersion.Version >= new Version(5, 1, 0, 0));
			}
			return result;
		}

		// Token: 0x0600039D RID: 925 RVA: 0x000157A0 File Offset: 0x000147A0
		public void x4402a69f607144e3(Point xb9c2cfae130d9256, string xb41faee6912a2313)
		{
			this.xa6607dfd4b3038ad.Text = xb41faee6912a2313;
			for (;;)
			{
				Size size = Size.Ceiling(this.xa6607dfd4b3038ad.x0a8f2a18d3b53839(xb41faee6912a2313));
				size.Height += 4;
				size.Width += 4;
				xb9c2cfae130d9256.Y += 19;
				Screen screen = Screen.FromPoint(xb9c2cfae130d9256);
				if (xb9c2cfae130d9256.X < screen.Bounds.Left)
				{
					xb9c2cfae130d9256.X = screen.Bounds.Left;
				}
				if (xb9c2cfae130d9256.X + size.Width > screen.Bounds.Right)
				{
					xb9c2cfae130d9256.X = screen.Bounds.Right - size.Width;
					if (xb9c2cfae130d9256.X < screen.Bounds.Left)
					{
						break;
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
					if (-2 == 0)
					{
						continue;
					}
				}
				xf8f9565783602018.SetWindowPos(this.xa6607dfd4b3038ad.Handle, -1, xb9c2cfae130d9256.X, xb9c2cfae130d9256.Y, size.Width, size.Height, 80);
				this.xa6607dfd4b3038ad.Invalidate();
				this.x364c1e3b189d47fe = true;
				if (this.x9238f6a5f034aeb5 != null)
				{
					this.x9238f6a5f034aeb5.Deactivate -= this.xdef19f2ef265bf1e;
				}
				this.x9238f6a5f034aeb5 = this.x624fa8b017460890(this.x43bec302f92080b9);
				if (this.x9238f6a5f034aeb5 == null)
				{
					return;
				}
				this.x9238f6a5f034aeb5.Deactivate += this.xdef19f2ef265bf1e;
				this.xa6607dfd4b3038ad.Owner = this.x9238f6a5f034aeb5;
				if (-2147483648 != 0)
				{
					return;
				}
			}
		}

		// Token: 0x0600039E RID: 926 RVA: 0x000159E4 File Offset: 0x000149E4
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

		// Token: 0x0600039F RID: 927 RVA: 0x00015A38 File Offset: 0x00014A38
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

		// Token: 0x060003A0 RID: 928 RVA: 0x00015AF0 File Offset: 0x00014AF0
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

		// Token: 0x060003A1 RID: 929 RVA: 0x00015B98 File Offset: 0x00014B98
		private Form x624fa8b017460890(Control x3c4da2980d043c95)
		{
			while (x3c4da2980d043c95.Parent != null)
			{
				x3c4da2980d043c95 = x3c4da2980d043c95.Parent;
			}
			return x3c4da2980d043c95 as Form;
		}

		// Token: 0x060003A2 RID: 930 RVA: 0x00015BB4 File Offset: 0x00014BB4
		private void x664829383a59617c(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			if (this.x364c1e3b189d47fe)
			{
				this.x47c79a4d207183de();
			}
			this.x537a4001020fd4c7.Enabled = false;
		}

		// Token: 0x060003A3 RID: 931 RVA: 0x00015BD0 File Offset: 0x00014BD0
		private void x1c8953a8a8447816(object xe0292b9ed559da7d, MouseEventArgs xfbf34718e704c6bc)
		{
			if (this.x364c1e3b189d47fe)
			{
				this.x47c79a4d207183de();
			}
			this.x537a4001020fd4c7.Enabled = false;
		}

		// Token: 0x060003A4 RID: 932 RVA: 0x00015BEC File Offset: 0x00014BEC
		private void x5e1cbc67acfe3317(object xe0292b9ed559da7d, MouseEventArgs xfbf34718e704c6bc)
		{
			if (this.x364c1e3b189d47fe)
			{
				this.x47c79a4d207183de();
			}
			this.x537a4001020fd4c7.Enabled = false;
		}

		// Token: 0x060003A5 RID: 933 RVA: 0x00015C08 File Offset: 0x00014C08
		private void x1aaaf41037533886(object xe0292b9ed559da7d, MouseEventArgs xfbf34718e704c6bc)
		{
			this.x47c79a4d207183de();
		}

		// Token: 0x060003A6 RID: 934 RVA: 0x00015C10 File Offset: 0x00014C10
		private void xdef19f2ef265bf1e(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			this.x47c79a4d207183de();
		}

		// Token: 0x060003A7 RID: 935 RVA: 0x00015C18 File Offset: 0x00014C18
		private void x77d9086325b6e538(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			this.Dispose();
		}

		// Token: 0x060003A8 RID: 936 RVA: 0x00015C20 File Offset: 0x00014C20
		private void xb27df3b0091b2a36(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			this.xa6607dfd4b3038ad.Font = this.x43bec302f92080b9.Font;
		}

		// Token: 0x040000FC RID: 252
		private const int x77bf04ec211c4a37 = 16;

		// Token: 0x040000FD RID: 253
		private const int x339acab5bf3e83ae = 64;

		// Token: 0x040000FE RID: 254
		private const int xdbb7427772b219d6 = 128;

		// Token: 0x040000FF RID: 255
		private const int xb644deafcaa222c4 = 2;

		// Token: 0x04000100 RID: 256
		private const int xb8a822e576f3bf60 = 1;

		// Token: 0x04000101 RID: 257
		private Control x43bec302f92080b9;

		// Token: 0x04000102 RID: 258
		private bool x364c1e3b189d47fe;

		// Token: 0x04000103 RID: 259
		private bool xeefb7b23d49f09bc = true;

		// Token: 0x04000104 RID: 260
		private bool x0e75cd3866dbb930;

		// Token: 0x04000105 RID: 261
		private Point xa639e9f791585165;

		// Token: 0x04000106 RID: 262
		private xf8f9565783602018.xab7df35839b7399e xa6607dfd4b3038ad;

		// Token: 0x04000107 RID: 263
		private Timer x537a4001020fd4c7;

		// Token: 0x04000108 RID: 264
		private Form x9238f6a5f034aeb5;

		// Token: 0x02000030 RID: 48
		// (Invoke) Token: 0x06000497 RID: 1175
		internal delegate string x58986a4a0b75e5b5(Point location);

		// Token: 0x02000052 RID: 82
		private class xab7df35839b7399e : Form
		{
			// Token: 0x06000535 RID: 1333
			[DllImport("user32.dll")]
			private static extern bool SystemParametersInfo(int nAction, int nParam, ref int i, int nUpdate);

			// Token: 0x06000536 RID: 1334 RVA: 0x0001B224 File Offset: 0x0001A224
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

			// Token: 0x1700014B RID: 331
			// (get) Token: 0x06000537 RID: 1335 RVA: 0x0001B284 File Offset: 0x0001A284
			// (set) Token: 0x06000538 RID: 1336 RVA: 0x0001B29C File Offset: 0x0001A29C
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

			// Token: 0x06000539 RID: 1337 RVA: 0x0001B2F8 File Offset: 0x0001A2F8
			public SizeF x0a8f2a18d3b53839(string xb41faee6912a2313)
			{
				SizeF result;
				using (Graphics graphics = base.CreateGraphics())
				{
					SizeF sizeF = TextRenderer.MeasureText(graphics, xb41faee6912a2313, this.Font, new Size(int.MaxValue, int.MaxValue), this.xae3b2752a89e7464);
					sizeF.Width -= 2f;
					sizeF.Height += 2f;
					result = sizeF;
				}
				return result;
			}

			// Token: 0x1700014C RID: 332
			// (get) Token: 0x0600053A RID: 1338 RVA: 0x0001B388 File Offset: 0x0001A388
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

			// Token: 0x1700014D RID: 333
			// (get) Token: 0x0600053B RID: 1339 RVA: 0x0001B3CC File Offset: 0x0001A3CC
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

			// Token: 0x0600053C RID: 1340 RVA: 0x0001B3FC File Offset: 0x0001A3FC
			protected override void Dispose(bool disposing)
			{
				base.Dispose(disposing);
			}

			// Token: 0x0600053D RID: 1341 RVA: 0x0001B408 File Offset: 0x0001A408
			protected override void OnPaint(PaintEventArgs e)
			{
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

			// Token: 0x040001DA RID: 474
			private const int x3e8b9d6faeff6586 = 32;

			// Token: 0x040001DB RID: 475
			private const int x2b7f5d3ca7ec1edf = -2147483648;

			// Token: 0x040001DC RID: 476
			private const int xd708511d2241a4fb = 131072;

			// Token: 0x040001DD RID: 477
			private const int x836e53e090609b16 = 4132;

			// Token: 0x040001DE RID: 478
			private xf8f9565783602018 xac1c850120b1f254;

			// Token: 0x040001DF RID: 479
			private TextFormatFlags xae3b2752a89e7464;
		}
	}
}
