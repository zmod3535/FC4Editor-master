using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;

namespace TD.SandBar
{
	// Token: 0x0200005F RID: 95
	[Designer("TD.SandBar.Design.StatusBarDesigner, SandBar.Design, Version=1.0.0.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3")]
	public class StatusBar : ToolBar
	{
		// Token: 0x060004CF RID: 1231 RVA: 0x0001AF70 File Offset: 0x00019F70
		public StatusBar()
		{
			this.Text = "Menu Bar";
			this.Dock = DockStyle.Bottom;
		}

		// Token: 0x17000127 RID: 295
		// (get) Token: 0x060004D0 RID: 1232 RVA: 0x0001AF94 File Offset: 0x00019F94
		public override Type[] DesignableTypes
		{
			get
			{
				return new Type[]
				{
					typeof(StatusBarItem),
					typeof(ProgressBarItem)
				};
			}
		}

		// Token: 0x17000128 RID: 296
		// (get) Token: 0x060004D1 RID: 1233 RVA: 0x0001AFC4 File Offset: 0x00019FC4
		// (set) Token: 0x060004D2 RID: 1234 RVA: 0x0001AFCC File Offset: 0x00019FCC
		[Description("Indicates whether a gripper will be shown that the user can use to resize their form.")]
		[Category("Appearance")]
		[DefaultValue(true)]
		public bool ShowGripper
		{
			get
			{
				return this.x917b34032bde2a8d;
			}
			set
			{
				this.x917b34032bde2a8d = value;
				base.xcf42ad4a4f3fcbf6();
			}
		}

		// Token: 0x17000129 RID: 297
		// (get) Token: 0x060004D3 RID: 1235 RVA: 0x0001AFDC File Offset: 0x00019FDC
		// (set) Token: 0x060004D4 RID: 1236 RVA: 0x0001AFE4 File Offset: 0x00019FE4
		[Browsable(false)]
		public Form OwnerForm
		{
			get
			{
				return this.x9492ad63ba3e62cf;
			}
			set
			{
				if (this.x9492ad63ba3e62cf != null)
				{
					this.x9492ad63ba3e62cf.Resize -= this.x988a216f0577ee78;
					this.x9492ad63ba3e62cf.HandleCreated -= this.xecbd32f93d73d505;
				}
				this.x9492ad63ba3e62cf = value;
				if (this.x9492ad63ba3e62cf != null)
				{
					this.x9492ad63ba3e62cf.Resize += this.x988a216f0577ee78;
					this.x9492ad63ba3e62cf.HandleCreated += this.xecbd32f93d73d505;
				}
				this.xe7124a6771121587 = (this.OwnerForm != null && this.x71f8d50ddd67b44b(this.OwnerForm));
				base.xcf42ad4a4f3fcbf6();
			}
		}

		// Token: 0x060004D5 RID: 1237 RVA: 0x0001B088 File Offset: 0x0001A088
		private bool x71f8d50ddd67b44b(Form x0078185e1040c523)
		{
			return x0078185e1040c523.WindowState == FormWindowState.Normal && (x0078185e1040c523.FormBorderStyle == FormBorderStyle.Sizable || x0078185e1040c523.FormBorderStyle == FormBorderStyle.SizableToolWindow);
		}

		// Token: 0x060004D6 RID: 1238 RVA: 0x0001B0A8 File Offset: 0x0001A0A8
		private void xecbd32f93d73d505(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			bool flag = this.OwnerForm != null && this.x71f8d50ddd67b44b(this.OwnerForm);
			if (flag != this.xe7124a6771121587)
			{
				this.xe7124a6771121587 = flag;
				base.xcf42ad4a4f3fcbf6();
			}
		}

		// Token: 0x060004D7 RID: 1239 RVA: 0x0001B0E4 File Offset: 0x0001A0E4
		private void x988a216f0577ee78(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			bool flag = this.OwnerForm != null && this.x71f8d50ddd67b44b(this.OwnerForm);
			if (flag != this.xe7124a6771121587)
			{
				this.xe7124a6771121587 = flag;
				base.xcf42ad4a4f3fcbf6();
			}
		}

		// Token: 0x1700012A RID: 298
		// (get) Token: 0x060004D8 RID: 1240 RVA: 0x0001B120 File Offset: 0x0001A120
		protected override Size DefaultSize
		{
			get
			{
				return new Size(300, 18);
			}
		}

		// Token: 0x1700012B RID: 299
		// (get) Token: 0x060004D9 RID: 1241 RVA: 0x0001B130 File Offset: 0x0001A130
		// (set) Token: 0x060004DA RID: 1242 RVA: 0x0001B138 File Offset: 0x0001A138
		public override ISite Site
		{
			get
			{
				return base.Site;
			}
			set
			{
				base.Site = value;
				if (value != null)
				{
					IDesignerHost designerHost = (IDesignerHost)this.GetService(typeof(IDesignerHost));
					if (designerHost != null && designerHost.RootComponent is Form)
					{
						this.OwnerForm = (Form)designerHost.RootComponent;
					}
				}
			}
		}

		// Token: 0x1700012C RID: 300
		// (get) Token: 0x060004DB RID: 1243 RVA: 0x0001B188 File Offset: 0x0001A188
		// (set) Token: 0x060004DC RID: 1244 RVA: 0x0001B18C File Offset: 0x0001A18C
		[Browsable(false)]
		[DefaultValue(false)]
		public override bool DrawActionsButton
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		// Token: 0x1700012D RID: 301
		// (get) Token: 0x060004DD RID: 1245 RVA: 0x0001B190 File Offset: 0x0001A190
		protected internal override int LeftPadding
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x1700012E RID: 302
		// (get) Token: 0x060004DE RID: 1246 RVA: 0x0001B194 File Offset: 0x0001A194
		protected internal override int RightPadding
		{
			get
			{
				if (this.xe7124a6771121587 && this.ShowGripper)
				{
					return 14;
				}
				return 0;
			}
		}

		// Token: 0x060004DF RID: 1247 RVA: 0x0001B1AC File Offset: 0x0001A1AC
		internal override void x1a2b7835c4f6410b(IToolBarRenderer x38870620fd380a6b, bool xa092001467a0ab7b)
		{
			base.x1a2b7835c4f6410b(x38870620fd380a6b, xa092001467a0ab7b);
			if (xa092001467a0ab7b)
			{
				this.x446b42c2caf105ce = new Rectangle(0, base.ClientRectangle.Height - 14, base.ClientRectangle.Width, 14);
				return;
			}
			this.x446b42c2caf105ce = new Rectangle(base.ClientRectangle.Width - 14, 0, 14, base.ClientRectangle.Height);
		}

		// Token: 0x060004E0 RID: 1248 RVA: 0x0001B220 File Offset: 0x0001A220
		internal override Rectangle x2bae8e54dc041c43(Rectangle x4bc955bd8cfefd39)
		{
			int leftPadding = this.LeftPadding;
			int rightPadding = this.RightPadding;
			int num = 1;
			int num2 = 0;
			if (this.Flow == ToolBarLayout.Horizontal)
			{
				x4bc955bd8cfefd39.Offset(leftPadding, num);
				x4bc955bd8cfefd39.Width -= leftPadding + rightPadding;
				x4bc955bd8cfefd39.Height -= num + num2;
			}
			else
			{
				x4bc955bd8cfefd39.Offset(num, leftPadding);
				x4bc955bd8cfefd39.Width -= num + num2;
				x4bc955bd8cfefd39.Height -= leftPadding + rightPadding;
			}
			return x4bc955bd8cfefd39;
		}

		// Token: 0x060004E1 RID: 1249 RVA: 0x0001B2A0 File Offset: 0x0001A2A0
		internal override Size xb72141a39aa76ab2(Size x745e975ddcb1a4a4)
		{
			int num = 0;
			num += this.LeftPadding + this.RightPadding;
			num += ((this.Flow == ToolBarLayout.Horizontal) ? x745e975ddcb1a4a4.Width : x745e975ddcb1a4a4.Height);
			if (num < 18)
			{
				num = 18;
			}
			int num2 = 1;
			num2 += ((this.Flow == ToolBarLayout.Horizontal) ? x745e975ddcb1a4a4.Height : x745e975ddcb1a4a4.Width);
			if (num2 < 18)
			{
				num2 = 18;
			}
			if (this.Flow != ToolBarLayout.Horizontal)
			{
				return new Size(num2, num);
			}
			return new Size(num, num2);
		}

		// Token: 0x060004E2 RID: 1250 RVA: 0x0001B320 File Offset: 0x0001A320
		protected override void OnPaintBackground(PaintEventArgs pevent)
		{
			base.WorkingRenderer.DrawStatusBarBackground(this, pevent.Graphics, base.ClientRectangle, this.Flow == ToolBarLayout.Vertical);
		}

		// Token: 0x060004E3 RID: 1251 RVA: 0x0001B344 File Offset: 0x0001A344
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			if (this.xe7124a6771121587 && this.ShowGripper)
			{
				base.WorkingRenderer.DrawStatusBarGripper(this, e.Graphics, this.x446b42c2caf105ce, this.Flow == ToolBarLayout.Vertical);
			}
		}

		// Token: 0x060004E4 RID: 1252 RVA: 0x0001B380 File Offset: 0x0001A380
		protected override void WndProc(ref Message m)
		{
			if (m.Msg == 132 && this.xe7124a6771121587 && this.ShowGripper && this.x446b42c2caf105ce.Contains(base.PointToClient(new Point(m.LParam.ToInt32()))))
			{
				m.Result = new IntPtr(17);
				return;
			}
			base.WndProc(ref m);
		}

		// Token: 0x1700012F RID: 303
		// (get) Token: 0x060004E5 RID: 1253 RVA: 0x0001B3E8 File Offset: 0x0001A3E8
		// (set) Token: 0x060004E6 RID: 1254 RVA: 0x0001B3F0 File Offset: 0x0001A3F0
		[DefaultValue("Status Bar")]
		public override string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				base.Text = value;
			}
		}

		// Token: 0x17000130 RID: 304
		// (get) Token: 0x060004E7 RID: 1255 RVA: 0x0001B3FC File Offset: 0x0001A3FC
		// (set) Token: 0x060004E8 RID: 1256 RVA: 0x0001B400 File Offset: 0x0001A400
		[Browsable(false)]
		[DefaultValue(false)]
		public override bool Closable
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		// Token: 0x17000131 RID: 305
		// (get) Token: 0x060004E9 RID: 1257 RVA: 0x0001B404 File Offset: 0x0001A404
		// (set) Token: 0x060004EA RID: 1258 RVA: 0x0001B408 File Offset: 0x0001A408
		[DefaultValue(typeof(ToolBarOverflow), "Hide")]
		[Browsable(false)]
		public override ToolBarOverflow Overflow
		{
			get
			{
				return ToolBarOverflow.Hide;
			}
			set
			{
			}
		}

		// Token: 0x17000132 RID: 306
		// (get) Token: 0x060004EB RID: 1259 RVA: 0x0001B40C File Offset: 0x0001A40C
		// (set) Token: 0x060004EC RID: 1260 RVA: 0x0001B410 File Offset: 0x0001A410
		[DefaultValue(false)]
		[Browsable(false)]
		public override bool Movable
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		// Token: 0x17000133 RID: 307
		// (get) Token: 0x060004ED RID: 1261 RVA: 0x0001B414 File Offset: 0x0001A414
		// (set) Token: 0x060004EE RID: 1262 RVA: 0x0001B418 File Offset: 0x0001A418
		[Browsable(false)]
		[DefaultValue(true)]
		public override bool Stretch
		{
			get
			{
				return true;
			}
			set
			{
			}
		}

		// Token: 0x04000210 RID: 528
		private const int x9759a8ac22327c41 = 14;

		// Token: 0x04000211 RID: 529
		private Form x9492ad63ba3e62cf;

		// Token: 0x04000212 RID: 530
		private bool x917b34032bde2a8d = true;

		// Token: 0x04000213 RID: 531
		private bool xe7124a6771121587;

		// Token: 0x04000214 RID: 532
		private new Rectangle x446b42c2caf105ce;
	}
}
