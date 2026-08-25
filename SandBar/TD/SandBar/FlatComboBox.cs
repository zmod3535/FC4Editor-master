using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace TD.SandBar
{
	// Token: 0x02000067 RID: 103
	public class FlatComboBox : ComboBox
	{
		// Token: 0x1400000F RID: 15
		// (add) Token: 0x06000511 RID: 1297 RVA: 0x0001B700 File Offset: 0x0001A700
		// (remove) Token: 0x06000512 RID: 1298 RVA: 0x0001B71C File Offset: 0x0001A71C
		public event EventHandler DefaultTextChanged
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.xf774e53067fc8375 = (EventHandler)Delegate.Combine(this.xf774e53067fc8375, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.xf774e53067fc8375 = (EventHandler)Delegate.Remove(this.xf774e53067fc8375, value);
			}
		}

		// Token: 0x06000513 RID: 1299 RVA: 0x0001B738 File Offset: 0x0001A738
		public FlatComboBox()
		{
			base.SetStyle(ControlStyles.ResizeRedraw, true);
			this.x38870620fd380a6b = new Office2002Renderer();
			this.x3820c8b6750f309e = new Timer();
			this.x3820c8b6750f309e.Interval = 50;
			this.x3820c8b6750f309e.Tick += this.x1c0d2e4fa5bd7391;
		}

		// Token: 0x06000514 RID: 1300 RVA: 0x0001B79C File Offset: 0x0001A79C
		protected override void OnSelectedValueChanged(EventArgs e)
		{
			int selectionLength = base.SelectionLength;
			base.OnSelectedValueChanged(e);
		}

		// Token: 0x06000515 RID: 1301 RVA: 0x0001B7AC File Offset: 0x0001A7AC
		protected override void OnSelectedIndexChanged(EventArgs e)
		{
			int selectionLength = base.SelectionLength;
			base.OnSelectedIndexChanged(e);
		}

		// Token: 0x06000516 RID: 1302 RVA: 0x0001B7BC File Offset: 0x0001A7BC
		protected override void OnSelectedItemChanged(EventArgs e)
		{
			int selectionLength = base.SelectionLength;
			base.OnSelectedItemChanged(e);
		}

		// Token: 0x06000517 RID: 1303 RVA: 0x0001B7CC File Offset: 0x0001A7CC
		private void x1c0d2e4fa5bd7391(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			if (base.IsDisposed || !base.ClientRectangle.Contains(base.PointToClient(Cursor.Position)))
			{
				this.x3820c8b6750f309e.Enabled = false;
				this._x809e5a637bb68f94 = false;
				if (!base.IsDisposed && !base.DroppedDown)
				{
					base.Invalidate();
				}
			}
		}

		// Token: 0x17000142 RID: 322
		// (get) Token: 0x06000518 RID: 1304 RVA: 0x0001B828 File Offset: 0x0001A828
		// (set) Token: 0x06000519 RID: 1305 RVA: 0x0001B830 File Offset: 0x0001A830
		[DefaultValue("")]
		[Category("Appearance")]
		[Localizable(true)]
		[Description("Provides a textual hint as to the type of data to enter, before any is entered.")]
		public string DefaultText
		{
			get
			{
				return this._x211d1fc19573f6d1;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException();
				}
				this._x211d1fc19573f6d1 = value;
				if (this._xb506b744f4091cb3)
				{
					if (value.Length == 0)
					{
						this._xb506b744f4091cb3 = false;
						this.ForeColor = SystemColors.ControlText;
						this.Text = "";
					}
					base.Text = value;
				}
				else
				{
					this.x6bda77f00ae9bf27();
				}
				this.OnDefaultTextChanged();
			}
		}

		// Token: 0x0600051A RID: 1306 RVA: 0x0001B890 File Offset: 0x0001A890
		protected virtual void OnDefaultTextChanged()
		{
			if (this.xf774e53067fc8375 != null)
			{
				this.xf774e53067fc8375(this, EventArgs.Empty);
			}
		}

		// Token: 0x0600051B RID: 1307 RVA: 0x0001B8AC File Offset: 0x0001A8AC
		private void x6bda77f00ae9bf27()
		{
			if (base.DropDownStyle == ComboBoxStyle.DropDown && this.Text.Length == 0 && !base.ContainsFocus && !this._xb506b744f4091cb3)
			{
				this._xb506b744f4091cb3 = true;
				base.Text = this._x211d1fc19573f6d1;
				this.ForeColor = SystemColors.ControlDark;
				return;
			}
			if (this._xb506b744f4091cb3)
			{
				this.ForeColor = SystemColors.ControlText;
				this._xb506b744f4091cb3 = false;
				base.Text = "";
			}
		}

		// Token: 0x17000143 RID: 323
		// (get) Token: 0x0600051C RID: 1308 RVA: 0x0001B924 File Offset: 0x0001A924
		// (set) Token: 0x0600051D RID: 1309 RVA: 0x0001B93C File Offset: 0x0001A93C
		public override string Text
		{
			get
			{
				if (this._xb506b744f4091cb3)
				{
					return "";
				}
				return base.Text;
			}
			set
			{
				if (value == null)
				{
					value = "";
				}
				if (this._xb506b744f4091cb3)
				{
					if (value.Length > 0)
					{
						this._xb506b744f4091cb3 = false;
						base.Text = value;
					}
					this.ForeColor = SystemColors.ControlText;
					return;
				}
				if (value.Length != 0)
				{
					base.Text = value;
					return;
				}
				if (!this._xb506b744f4091cb3 && this.DefaultText.Length != 0)
				{
					this._xb506b744f4091cb3 = true;
					this.ForeColor = SystemColors.ControlDark;
					base.Text = this.DefaultText;
					return;
				}
				base.Text = value;
			}
		}

		// Token: 0x0600051E RID: 1310 RVA: 0x0001B9CC File Offset: 0x0001A9CC
		private void x0ebf0cbbee550b04()
		{
			using (Graphics graphics = Graphics.FromHwnd(base.Handle))
			{
				IComboBoxRenderer workingRenderer = this.x38870620fd380a6b;
				if (base.Parent is ToolBar)
				{
					workingRenderer = ((ToolBar)base.Parent).WorkingRenderer;
				}
				DrawItemState drawItemState = DrawItemState.Default;
				if (this._x809e5a637bb68f94 || base.ContainsFocus)
				{
					drawItemState |= DrawItemState.HotLight;
				}
				if (!base.Enabled)
				{
					drawItemState |= DrawItemState.Disabled;
				}
				if (base.DroppedDown)
				{
					drawItemState |= DrawItemState.Selected;
				}
				if (workingRenderer is Office2003Renderer)
				{
					((Office2003Renderer)workingRenderer).xcb72be8a310acf66 = this;
				}
				workingRenderer.DrawComboBox(this, graphics, base.ClientRectangle, drawItemState, this.RightToLeft == RightToLeft.Yes);
			}
		}

		// Token: 0x0600051F RID: 1311 RVA: 0x0001BA90 File Offset: 0x0001AA90
		protected override void OnEnabledChanged(EventArgs e)
		{
			base.OnEnabledChanged(e);
			if (this._x809e5a637bb68f94 && !base.Enabled)
			{
				this._x809e5a637bb68f94 = false;
			}
			base.Invalidate();
		}

		// Token: 0x06000520 RID: 1312 RVA: 0x0001BAB8 File Offset: 0x0001AAB8
		protected override void OnGotFocus(EventArgs e)
		{
			base.OnGotFocus(e);
			this.x6bda77f00ae9bf27();
			base.Invalidate();
		}

		// Token: 0x06000521 RID: 1313 RVA: 0x0001BAD0 File Offset: 0x0001AAD0
		protected override void OnLostFocus(EventArgs e)
		{
			base.OnLostFocus(e);
			this.x6bda77f00ae9bf27();
			base.Invalidate();
		}

		// Token: 0x06000522 RID: 1314 RVA: 0x0001BAE8 File Offset: 0x0001AAE8
		protected override void WndProc(ref Message m)
		{
			if (m.Msg == 15)
			{
				base.WndProc(ref m);
				this.x0ebf0cbbee550b04();
				m.Result = IntPtr.Zero;
				return;
			}
			base.WndProc(ref m);
		}

		// Token: 0x06000523 RID: 1315 RVA: 0x0001BB14 File Offset: 0x0001AB14
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				this.x38870620fd380a6b.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000524 RID: 1316 RVA: 0x0001BB2C File Offset: 0x0001AB2C
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			if (!this._x809e5a637bb68f94)
			{
				this._x809e5a637bb68f94 = true;
				this.x3820c8b6750f309e.Enabled = true;
				base.Invalidate();
			}
		}

		// Token: 0x0400021C RID: 540
		private bool _x809e5a637bb68f94;

		// Token: 0x0400021D RID: 541
		private string _x211d1fc19573f6d1 = "";

		// Token: 0x0400021E RID: 542
		private bool _xb506b744f4091cb3;

		// Token: 0x0400021F RID: 543
		private static bool xc700d1f31b5ce30a;

		// Token: 0x04000220 RID: 544
		private IComboBoxRenderer x38870620fd380a6b;

		// Token: 0x04000221 RID: 545
		private Timer x3820c8b6750f309e;

		// Token: 0x04000222 RID: 546
		private EventHandler xf774e53067fc8375;
	}
}
