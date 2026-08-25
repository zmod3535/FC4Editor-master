using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using TD.SandDock.Design;
using TD.SandDock.Rendering;

namespace TD.SandDock
{
	// Token: 0x0200003B RID: 59
	[Designer(typeof(DocumentContainerDesigner))]
	[ToolboxItem(false)]
	public class DocumentContainer : DockContainer, IMessageFilter
	{
		// Token: 0x06000479 RID: 1145 RVA: 0x0002336C File Offset: 0x0002236C
		public DocumentContainer()
		{
			this.Dock = DockStyle.Fill;
			this.BackColor = SystemColors.AppWorkspace;
		}

		// Token: 0x17000121 RID: 289
		// (get) Token: 0x0600047A RID: 1146 RVA: 0x0002339C File Offset: 0x0002239C
		internal bool x1ec2ea49664e1074
		{
			get
			{
				return this.xe1c7adce7be56121 != null;
			}
		}

		// Token: 0x0600047B RID: 1147 RVA: 0x000233AC File Offset: 0x000223AC
		internal override ControlLayoutSystem xd6284ffe96aec512()
		{
			return new DocumentLayoutSystem();
		}

		// Token: 0x17000122 RID: 290
		// (get) Token: 0x0600047C RID: 1148 RVA: 0x000233B4 File Offset: 0x000223B4
		internal override bool x0c2484ccd29b8358
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000123 RID: 291
		// (get) Token: 0x0600047D RID: 1149 RVA: 0x000233B8 File Offset: 0x000223B8
		private bool xe96ee18ce2c3b205
		{
			get
			{
				return this.Manager == null || this.Manager.AllowKeyboardNavigation;
			}
		}

		// Token: 0x0600047E RID: 1150 RVA: 0x000233D0 File Offset: 0x000223D0
		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if (keyData == (Keys.LButton | Keys.Back | Keys.Control))
			{
				goto IL_1F;
			}
			int num;
			bool flag = (uint)num > uint.MaxValue;
			if (!flag)
			{
				goto IL_13C;
			}
			return true;
			IL_1F:
			if (!this.xe96ee18ce2c3b205)
			{
				flag = (((uint)num | 3U) == 0U);
				if (!flag)
				{
					goto IL_15D;
				}
			}
			else
			{
				DockControl[] dockControls = this.Manager.GetDockControls(DockSituation.Document);
				if (3 == 0)
				{
					goto IL_4C;
				}
				if (dockControls.Length < 2)
				{
					return true;
				}
				DateTime[] array = new DateTime[dockControls.Length];
				num = 0;
				goto IL_D3;
				IL_4A:
				goto IL_53;
				IL_4C:
				this.xabb78e5e36f68ff6 = 1;
				IL_53:
				this.xf166541af22172c9();
				Application.AddMessageFilter(this);
				flag = (((uint)num & 0U) == 0U);
				if (!flag)
				{
					goto IL_F8;
				}
				if ((uint)num - (uint)num > 4294967295U)
				{
					goto IL_4A;
				}
				if (!false)
				{
					if (-2147483648 == 0)
					{
						goto IL_AB;
					}
					goto IL_CD;
				}
				IL_92:
				this.xabb78e5e36f68ff6 = this.xe1c7adce7be56121.Length - 1;
				goto IL_4A;
				IL_AB:
				if ((keyData & Keys.Shift) != Keys.Shift)
				{
					goto IL_4C;
				}
				if (((uint)num & 0U) == 0U)
				{
					goto IL_92;
				}
				IL_CD:
				goto IL_125;
				IL_D3:
				if (num >= dockControls.Length)
				{
					Array.Sort<DateTime, DockControl>(array, dockControls);
					this.xe1c7adce7be56121 = dockControls;
					goto IL_AB;
				}
				IL_F8:
				array[num] = dockControls[num].MetaData.LastFocused;
				if (((uint)num & 0U) == 0U)
				{
					num++;
					goto IL_D3;
				}
				IL_125:
				if (!false)
				{
					return true;
				}
			}
			IL_13C:
			if (keyData == (Keys.LButton | Keys.Back | Keys.Shift | Keys.Control))
			{
				goto IL_1F;
			}
			IL_15D:
			return base.ProcessCmdKey(ref msg, keyData);
		}

		// Token: 0x0600047F RID: 1151 RVA: 0x00023544 File Offset: 0x00022544
		private DockControl xf166541af22172c9()
		{
			if (this.xabb78e5e36f68ff6 > this.xe1c7adce7be56121.Length)
			{
				this.xabb78e5e36f68ff6 = this.xe1c7adce7be56121.Length;
			}
			int num = this.xe1c7adce7be56121.Length - 1 - this.xabb78e5e36f68ff6;
			this.xe1c7adce7be56121[num].x6d1b64d6c637a91d(true);
			return this.xe1c7adce7be56121[num];
		}

		// Token: 0x06000480 RID: 1152 RVA: 0x00023598 File Offset: 0x00022598
		bool IMessageFilter.x4bbcf05291a247a0(ref Message x6088325dec1baa2a)
		{
			IntPtr wparam;
			bool flag;
			if (x6088325dec1baa2a.Msg == 256)
			{
				flag = ((uint)wparam - (uint)wparam > uint.MaxValue);
				if (flag)
				{
					goto IL_14E;
				}
				flag = (((uint)wparam & 0U) == 0U);
				if (flag)
				{
					goto IL_14E;
				}
			}
			IL_B0:
			IntPtr wparam2;
			if (x6088325dec1baa2a.Msg == 256)
			{
				wparam2 = x6088325dec1baa2a.WParam;
				if (wparam2.ToInt32() == 16)
				{
					return true;
				}
			}
			IntPtr wparam3;
			for (;;)
			{
				if (x6088325dec1baa2a.Msg != 257)
				{
					if ((uint)wparam3 + (uint)wparam2 <= 4294967295U)
					{
						goto IL_32;
					}
					goto IL_126;
				}
				else
				{
					wparam = x6088325dec1baa2a.WParam;
					if (wparam.ToInt32() != 17)
					{
						goto IL_32;
					}
				}
				IL_44:
				DockControl dockControl = this.xf166541af22172c9();
				this.xabb78e5e36f68ff6 = -1;
				this.xe1c7adce7be56121 = null;
				dockControl.x6d1b64d6c637a91d(true);
				Application.RemoveMessageFilter(this);
				if (false)
				{
					continue;
				}
				goto IL_93;
				IL_32:
				if (x6088325dec1baa2a.Msg != 256)
				{
					break;
				}
				goto IL_44;
			}
			return false;
			IL_93:
			if (-1 != 0)
			{
				return true;
			}
			return false;
			IL_126:
			this.xabb78e5e36f68ff6++;
			IL_134:
			if (this.xabb78e5e36f68ff6 > this.xe1c7adce7be56121.Length - 1)
			{
				if (false)
				{
					if (false)
					{
						goto IL_14C;
					}
					goto IL_14E;
				}
				else
				{
					this.xabb78e5e36f68ff6 = 0;
				}
			}
			if (this.xabb78e5e36f68ff6 < 0)
			{
				this.xabb78e5e36f68ff6 = this.xe1c7adce7be56121.Length - 1;
			}
			this.xf166541af22172c9();
			return true;
			IL_14C:
			goto IL_134;
			IL_14E:
			wparam3 = x6088325dec1baa2a.WParam;
			if (wparam3.ToInt32() != 9)
			{
				goto IL_B0;
			}
			flag = ((uint)wparam < 0U);
			if (flag)
			{
				if (((uint)wparam | 4U) != 0U)
				{
					goto IL_18D;
				}
				goto IL_134;
			}
			IL_114:
			if ((Control.ModifierKeys & Keys.Shift) != Keys.Shift)
			{
				goto IL_126;
			}
			IL_18D:
			this.xabb78e5e36f68ff6--;
			if (255 == 0)
			{
				goto IL_114;
			}
			goto IL_14C;
		}

		// Token: 0x17000124 RID: 292
		// (get) Token: 0x06000481 RID: 1153 RVA: 0x00023778 File Offset: 0x00022778
		// (set) Token: 0x06000482 RID: 1154 RVA: 0x00023780 File Offset: 0x00022780
		[Description("The type of border to be drawn around the control.")]
		[DefaultValue(typeof(TD.SandDock.Rendering.BorderStyle), "Flat")]
		[Category("Appearance")]
		internal TD.SandDock.Rendering.BorderStyle x64b4c49ed703037e
		{
			get
			{
				return this.xacfbd7a08ba56c78;
			}
			set
			{
				this.xacfbd7a08ba56c78 = value;
				this.OnResize(EventArgs.Empty);
			}
		}

		// Token: 0x17000125 RID: 293
		// (get) Token: 0x06000483 RID: 1155 RVA: 0x00023794 File Offset: 0x00022794
		public override Rectangle DisplayRectangle
		{
			get
			{
				Rectangle displayRectangle = base.DisplayRectangle;
				for (;;)
				{
					TD.SandDock.Rendering.BorderStyle borderStyle = this.xacfbd7a08ba56c78;
					if (3 != 0)
					{
						switch (borderStyle)
						{
						case TD.SandDock.Rendering.BorderStyle.Flat:
						case TD.SandDock.Rendering.BorderStyle.RaisedThin:
						case TD.SandDock.Rendering.BorderStyle.SunkenThin:
							goto IL_09;
						case TD.SandDock.Rendering.BorderStyle.RaisedThick:
						case TD.SandDock.Rendering.BorderStyle.SunkenThick:
							goto IL_14;
						}
						return displayRectangle;
					}
					IL_14:
					displayRectangle.Inflate(-2, -2);
					if (2147483647 != 0)
					{
						return displayRectangle;
					}
				}
				IL_09:
				displayRectangle.Inflate(-1, -1);
				return displayRectangle;
			}
		}

		// Token: 0x06000484 RID: 1156 RVA: 0x000237F4 File Offset: 0x000227F4
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			DockControl.xe1da469e4d960f02(this, e.Graphics, this.xacfbd7a08ba56c78);
		}

		// Token: 0x17000126 RID: 294
		// (get) Token: 0x06000485 RID: 1157 RVA: 0x00023810 File Offset: 0x00022810
		// (set) Token: 0x06000486 RID: 1158 RVA: 0x00023818 File Offset: 0x00022818
		internal bool xa957e8f86f5e6115
		{
			get
			{
				return this.x26be2ab374407894;
			}
			set
			{
				this.x26be2ab374407894 = value;
				base.CalculateAllMetricsAndLayout();
			}
		}

		// Token: 0x17000127 RID: 295
		// (get) Token: 0x06000487 RID: 1159 RVA: 0x00023828 File Offset: 0x00022828
		// (set) Token: 0x06000488 RID: 1160 RVA: 0x00023830 File Offset: 0x00022830
		internal DocumentOverflowMode x7d2c5325d16e569d
		{
			get
			{
				return this.x8362acb4106ff84c;
			}
			set
			{
				this.x8362acb4106ff84c = value;
				base.CalculateAllMetricsAndLayout();
			}
		}

		// Token: 0x17000128 RID: 296
		// (get) Token: 0x06000489 RID: 1161 RVA: 0x00023840 File Offset: 0x00022840
		protected override Size DefaultSize
		{
			get
			{
				return new Size(300, 300);
			}
		}

		// Token: 0x17000129 RID: 297
		// (get) Token: 0x0600048A RID: 1162 RVA: 0x00023854 File Offset: 0x00022854
		// (set) Token: 0x0600048B RID: 1163 RVA: 0x0002385C File Offset: 0x0002285C
		[DefaultValue(typeof(Color), "AppWorkspace")]
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

		// Token: 0x1700012A RID: 298
		// (get) Token: 0x0600048C RID: 1164 RVA: 0x00023868 File Offset: 0x00022868
		// (set) Token: 0x0600048D RID: 1165 RVA: 0x00023870 File Offset: 0x00022870
		[DefaultValue(typeof(DockStyle), "Fill")]
		public override DockStyle Dock
		{
			get
			{
				return base.Dock;
			}
			set
			{
				if (value != DockStyle.Fill)
				{
					throw new ArgumentException("Only the Fill dock style is valid for this type of container.");
				}
				base.Dock = value;
			}
		}

		// Token: 0x04000181 RID: 385
		private const int x3ab50d2ad9712e32 = 256;

		// Token: 0x04000182 RID: 386
		private const int xacaf912f8e96627a = 257;

		// Token: 0x04000183 RID: 387
		private const int xa1cfcecc2bbf1b88 = 9;

		// Token: 0x04000184 RID: 388
		private const int x94f3e1f6055486d7 = 17;

		// Token: 0x04000185 RID: 389
		private const int x0e421de239ce3d08 = 16;

		// Token: 0x04000186 RID: 390
		private TD.SandDock.Rendering.BorderStyle xacfbd7a08ba56c78 = TD.SandDock.Rendering.BorderStyle.Flat;

		// Token: 0x04000187 RID: 391
		private DocumentOverflowMode x8362acb4106ff84c = DocumentOverflowMode.Scrollable;

		// Token: 0x04000188 RID: 392
		private bool x26be2ab374407894;

		// Token: 0x04000189 RID: 393
		private DockControl[] xe1c7adce7be56121;

		// Token: 0x0400018A RID: 394
		private int xabb78e5e36f68ff6 = -1;
	}
}
