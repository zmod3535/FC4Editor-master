using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace TD.SandBar
{
	// Token: 0x0200005B RID: 91
	public class Office2003Renderer : Office2002Renderer, IMenuRenderer, IToolBarRenderer, IComboBoxRenderer, IContainerBarRenderer, IDisposable
	{
		// Token: 0x0600040E RID: 1038 RVA: 0x00014904 File Offset: 0x00013904
		public Office2003Renderer()
		{
			this.CalculateBaseColors();
		}

		// Token: 0x17000106 RID: 262
		// (get) Token: 0x0600040F RID: 1039 RVA: 0x00014914 File Offset: 0x00013914
		// (set) Token: 0x06000410 RID: 1040 RVA: 0x0001491C File Offset: 0x0001391C
		public Office2003Renderer.Office2003ColorScheme ColorScheme
		{
			get
			{
				return this._x62a65b2c0f145432;
			}
			set
			{
				this._x62a65b2c0f145432 = value;
				this.CalculateBaseColors();
				this.OnRedrawRequired();
			}
		}

		// Token: 0x06000411 RID: 1041 RVA: 0x00014934 File Offset: 0x00013934
		internal virtual void x434cf9ebf433329c()
		{
			this.x0ea41556e91b8cce = SystemColors.Control;
			if (!false)
			{
				this.xaab0a0f66214f237 = Office2002Renderer.InterpolateColors(SystemColors.Control, SystemColors.Window, 0.8f);
				this.xaaaf059eaea34d20 = this.xaab0a0f66214f237;
				this.x8bb53ee85f70380e = Office2002Renderer.InterpolateColors(this.x0ea41556e91b8cce, Color.Black, 0.03f);
			}
			do
			{
				this._x273909d58eb80850 = ControlPaint.ContrastControlDark;
				this.x70d4b2922d9dda6a = SystemColors.ControlDark;
				this.xa94aca0885c7a27e = Office2002Renderer.IncreaseBrightness(this.x70d4b2922d9dda6a, 32);
				this._xa1359fb73f86c7a4 = SystemColors.Control;
				this.xca2b1cd1d862168f = SystemColors.AppWorkspace;
				this.x7f9d9df7414c77ae = SystemColors.ActiveCaptionText;
				this.x342ecbecb7467fe7 = SystemColors.ControlDark;
				this.x89f2076276dd61f9 = Office2002Renderer.InterpolateColors(SystemColors.Control, SystemColors.ControlLightLight, 0.5f);
				this.x1b9c0c9f53901c0e = SystemColors.Control;
				this.x963e6753ab680aa3 = this.x89f2076276dd61f9;
				this.xf1bce6e83ae00185 = Office2002Renderer.InterpolateColors(SystemColors.AppWorkspace, SystemColors.ControlLightLight, 0.3f);
				this.x5f8540e2e750d7a9 = SystemColors.ControlLightLight;
				if (!SystemInformation.HighContrast)
				{
					goto IL_133;
				}
				this._x5bdc84993d5749e9 = SystemColors.HighlightText;
				this.x228685f29c2ed324 = SystemColors.Highlight;
				this.x2b5af2e4edc60a47 = SystemColors.Highlight;
				this.x59bf7e25a95a2780 = SystemColors.Highlight;
				this.xf3f219013bfbc916 = SystemColors.Highlight;
				this.x546109961b6ba7ce = SystemColors.Highlight;
				this.x1a50e46d85acd88d = SystemColors.Highlight;
			}
			while (8 == 0);
			this.x154e298f2834a9ad = SystemColors.Highlight;
			return;
			IL_133:
			this._x5bdc84993d5749e9 = SystemColors.Highlight;
			if (-2 != 0)
			{
				this.x489a5698d424c87b();
			}
		}

		// Token: 0x06000412 RID: 1042 RVA: 0x00014AD4 File Offset: 0x00013AD4
		private void x489a5698d424c87b()
		{
			this.x228685f29c2ed324 = Office2002Renderer.InterpolateColors(this._x5bdc84993d5749e9, SystemColors.Window, 0.7f);
			this.x2b5af2e4edc60a47 = this.x228685f29c2ed324;
			this.x59bf7e25a95a2780 = Office2002Renderer.InterpolateColors(this._x5bdc84993d5749e9, SystemColors.Window, 0.5f);
			this.xf3f219013bfbc916 = this.x59bf7e25a95a2780;
			this.x546109961b6ba7ce = Office2002Renderer.InterpolateColors(this._x5bdc84993d5749e9, SystemColors.Window, 0.85f);
			this.x1a50e46d85acd88d = this.x546109961b6ba7ce;
			this.x154e298f2834a9ad = this.x228685f29c2ed324;
		}

		// Token: 0x06000413 RID: 1043 RVA: 0x00014B64 File Offset: 0x00013B64
		internal virtual void xe057fba0af96ba45()
		{
			this.x0ea41556e91b8cce = Color.FromArgb(158, 190, 245);
			if (2 != 0)
			{
				this.xaab0a0f66214f237 = Color.FromArgb(195, 218, 249);
			}
			this.xaaaf059eaea34d20 = Color.FromArgb(221, 236, 254);
			this.x8bb53ee85f70380e = Color.FromArgb(129, 169, 226);
			this._x273909d58eb80850 = Color.FromArgb(39, 65, 118);
			this.xa94aca0885c7a27e = Color.FromArgb(117, 166, 241);
			this.x70d4b2922d9dda6a = Color.FromArgb(0, 53, 145);
			this._xa1359fb73f86c7a4 = Color.FromArgb(59, 97, 156);
			this.xca2b1cd1d862168f = Color.FromArgb(42, 102, 201);
			this.x7f9d9df7414c77ae = Color.White;
			this.x342ecbecb7467fe7 = Color.FromArgb(106, 140, 203);
			this.x963e6753ab680aa3 = Color.FromArgb(185, 212, 249);
			this.x89f2076276dd61f9 = Color.FromArgb(221, 236, 254);
			this.x1b9c0c9f53901c0e = Color.FromArgb(74, 122, 201);
			this.xf1bce6e83ae00185 = Color.FromArgb(74, 122, 201);
			this.x5f8540e2e750d7a9 = SystemColors.ControlText;
			this._xace53b20b987446c = Color.FromArgb(246, 246, 246);
			if (!false)
			{
				this._x5bdc84993d5749e9 = Color.FromArgb(0, 0, 128);
			}
			this.x228685f29c2ed324 = Color.FromArgb(255, 244, 204);
			this.x2b5af2e4edc60a47 = Color.FromArgb(255, 211, 142);
			this.x59bf7e25a95a2780 = Color.FromArgb(254, 145, 78);
			this.xf3f219013bfbc916 = Color.FromArgb(255, 211, 142);
			this.x546109961b6ba7ce = Color.FromArgb(255, 211, 142);
			this.x1a50e46d85acd88d = Color.FromArgb(254, 145, 78);
			this.x154e298f2834a9ad = Color.FromArgb(255, 238, 194);
		}

		// Token: 0x06000414 RID: 1044 RVA: 0x00014DB8 File Offset: 0x00013DB8
		internal virtual void x3f960e027a3441e5()
		{
			this.x0ea41556e91b8cce = Color.FromArgb(217, 217, 167);
			this.xaab0a0f66214f237 = Color.FromArgb(242, 240, 228);
			this.xaaaf059eaea34d20 = Color.FromArgb(244, 247, 222);
			this.x8bb53ee85f70380e = Color.FromArgb(183, 198, 145);
			this._x273909d58eb80850 = Color.FromArgb(81, 94, 51);
			this.xa94aca0885c7a27e = Color.FromArgb(176, 194, 140);
			this.x70d4b2922d9dda6a = Color.FromArgb(96, 119, 107);
			this._xa1359fb73f86c7a4 = Color.FromArgb(96, 128, 88);
			this.xca2b1cd1d862168f = Color.FromArgb(116, 134, 94);
			this.x7f9d9df7414c77ae = Color.White;
			this.x342ecbecb7467fe7 = Color.FromArgb(96, 128, 88);
			this.x963e6753ab680aa3 = Color.White;
			this.x89f2076276dd61f9 = Color.FromArgb(243, 242, 231);
			this.x1b9c0c9f53901c0e = Color.FromArgb(159, 171, 128);
			this.xf1bce6e83ae00185 = Color.FromArgb(116, 134, 94);
			this.x5f8540e2e750d7a9 = SystemColors.ControlText;
			this._xace53b20b987446c = Color.FromArgb(244, 244, 238);
			this._x5bdc84993d5749e9 = Color.FromArgb(63, 93, 56);
			this.x228685f29c2ed324 = Color.FromArgb(255, 244, 204);
			if (!false)
			{
				this.x2b5af2e4edc60a47 = Color.FromArgb(255, 211, 142);
				this.x59bf7e25a95a2780 = Color.FromArgb(254, 145, 78);
			}
			this.xf3f219013bfbc916 = Color.FromArgb(255, 211, 142);
			this.x546109961b6ba7ce = Color.FromArgb(255, 211, 142);
			this.x1a50e46d85acd88d = Color.FromArgb(254, 145, 78);
			this.x154e298f2834a9ad = Color.FromArgb(255, 238, 194);
		}

		// Token: 0x06000415 RID: 1045 RVA: 0x00015000 File Offset: 0x00014000
		internal virtual void x0ac2de2217c5007e()
		{
			this.x0ea41556e91b8cce = Color.FromArgb(215, 215, 229);
			this.xaab0a0f66214f237 = Color.FromArgb(243, 243, 247);
			if (3 != 0)
			{
				this.xaaaf059eaea34d20 = Color.FromArgb(243, 244, 250);
				this.x8bb53ee85f70380e = Color.FromArgb(140, 138, 172);
				this._x273909d58eb80850 = Color.FromArgb(84, 84, 117);
				this.xa94aca0885c7a27e = Color.FromArgb(179, 178, 200);
				if (!false)
				{
					this.x70d4b2922d9dda6a = Color.FromArgb(118, 116, 146);
					this._xa1359fb73f86c7a4 = Color.FromArgb(124, 124, 148);
					this.xca2b1cd1d862168f = Color.FromArgb(122, 121, 153);
					this.x7f9d9df7414c77ae = Color.White;
					this.x342ecbecb7467fe7 = Color.FromArgb(110, 109, 143);
					this.x963e6753ab680aa3 = Color.White;
					this.x89f2076276dd61f9 = Color.FromArgb(238, 238, 244);
					this.x1b9c0c9f53901c0e = Color.FromArgb(162, 162, 181);
					this.xf1bce6e83ae00185 = Color.FromArgb(122, 121, 153);
					this.x5f8540e2e750d7a9 = SystemColors.ControlText;
					this._xace53b20b987446c = Color.FromArgb(253, 250, 255);
					this._x5bdc84993d5749e9 = Color.FromArgb(75, 75, 111);
					this.x228685f29c2ed324 = Color.FromArgb(255, 244, 204);
					this.x2b5af2e4edc60a47 = Color.FromArgb(255, 211, 142);
					this.x59bf7e25a95a2780 = Color.FromArgb(254, 145, 78);
					this.xf3f219013bfbc916 = Color.FromArgb(255, 211, 142);
				}
				this.x546109961b6ba7ce = Color.FromArgb(255, 211, 142);
				this.x1a50e46d85acd88d = Color.FromArgb(254, 145, 78);
				this.x154e298f2834a9ad = Color.FromArgb(255, 238, 194);
			}
		}

		// Token: 0x06000416 RID: 1046 RVA: 0x0001524C File Offset: 0x0001424C
		protected override void CalculateBaseColors()
		{
			base.CalculateBaseColors();
			if (!false)
			{
				goto IL_43;
			}
			IL_09:
			this.x434cf9ebf433329c();
			IL_37:
			this.CalculateDerivedColors();
			if (!false)
			{
				return;
			}
			IL_43:
			switch (this._x62a65b2c0f145432)
			{
			case Office2003Renderer.Office2003ColorScheme.Automatic:
			{
				if (!Office2003Renderer.x7fb2e1ce54a27086())
				{
					this.x434cf9ebf433329c();
					goto IL_37;
				}
				x60f3af502af1d663 x60f3af502af1d = new x60f3af502af1d663();
				if (!x60f3af502af1d.x2e20a402b77c44dc)
				{
					this.x434cf9ebf433329c();
					goto IL_37;
				}
				string x4f15c2ab6fab;
				if ((x4f15c2ab6fab = x60f3af502af1d.x4f15c2ab6fab0941) == null)
				{
					goto IL_09;
				}
				if (x4f15c2ab6fab == "NormalColor")
				{
					this.xe057fba0af96ba45();
					goto IL_37;
				}
				if (x4f15c2ab6fab == "HomeStead")
				{
					this.x3f960e027a3441e5();
					goto IL_37;
				}
				if (!(x4f15c2ab6fab == "Metallic"))
				{
					goto IL_09;
				}
				this.x0ac2de2217c5007e();
				goto IL_37;
			}
			case Office2003Renderer.Office2003ColorScheme.Standard:
				this.x434cf9ebf433329c();
				goto IL_37;
			case Office2003Renderer.Office2003ColorScheme.LunaBlue:
				this.xe057fba0af96ba45();
				goto IL_37;
			case Office2003Renderer.Office2003ColorScheme.LunaOlive:
				this.x3f960e027a3441e5();
				goto IL_37;
			case Office2003Renderer.Office2003ColorScheme.LunaSilver:
				this.x0ac2de2217c5007e();
				goto IL_37;
			default:
				goto IL_37;
			}
		}

		// Token: 0x17000107 RID: 263
		// (get) Token: 0x06000417 RID: 1047 RVA: 0x0001533C File Offset: 0x0001433C
		// (set) Token: 0x06000418 RID: 1048 RVA: 0x00015344 File Offset: 0x00014344
		public Color FormCaptionForeColor
		{
			get
			{
				return this.x7f9d9df7414c77ae;
			}
			set
			{
				this.x7f9d9df7414c77ae = value;
				base.CustomColors = true;
			}
		}

		// Token: 0x17000108 RID: 264
		// (get) Token: 0x06000419 RID: 1049 RVA: 0x00015354 File Offset: 0x00014354
		// (set) Token: 0x0600041A RID: 1050 RVA: 0x0001535C File Offset: 0x0001435C
		public Color FormCaptionBackColor
		{
			get
			{
				return this.xca2b1cd1d862168f;
			}
			set
			{
				this.xca2b1cd1d862168f = value;
				base.CustomColors = true;
			}
		}

		// Token: 0x17000109 RID: 265
		// (get) Token: 0x0600041B RID: 1051 RVA: 0x0001536C File Offset: 0x0001436C
		// (set) Token: 0x0600041C RID: 1052 RVA: 0x00015374 File Offset: 0x00014374
		public Color ContainerBarToolBarBackgroundColor
		{
			get
			{
				return this.xf1bce6e83ae00185;
			}
			set
			{
				this.xf1bce6e83ae00185 = value;
				base.CustomColors = true;
			}
		}

		// Token: 0x1700010A RID: 266
		// (get) Token: 0x0600041D RID: 1053 RVA: 0x00015384 File Offset: 0x00014384
		// (set) Token: 0x0600041E RID: 1054 RVA: 0x0001538C File Offset: 0x0001438C
		public Color ContainerBarBackgroundColor1
		{
			get
			{
				return this.x89f2076276dd61f9;
			}
			set
			{
				this.x89f2076276dd61f9 = value;
				base.CustomColors = true;
			}
		}

		// Token: 0x1700010B RID: 267
		// (get) Token: 0x0600041F RID: 1055 RVA: 0x0001539C File Offset: 0x0001439C
		// (set) Token: 0x06000420 RID: 1056 RVA: 0x000153A4 File Offset: 0x000143A4
		public Color ContainerBarBackgroundColor2
		{
			get
			{
				return this.x1b9c0c9f53901c0e;
			}
			set
			{
				this.x1b9c0c9f53901c0e = value;
				base.CustomColors = true;
			}
		}

		// Token: 0x1700010C RID: 268
		// (get) Token: 0x06000421 RID: 1057 RVA: 0x000153B4 File Offset: 0x000143B4
		// (set) Token: 0x06000422 RID: 1058 RVA: 0x000153BC File Offset: 0x000143BC
		public Color ContainerBarBorderColor
		{
			get
			{
				return this.x963e6753ab680aa3;
			}
			set
			{
				this.x963e6753ab680aa3 = value;
				base.CustomColors = true;
			}
		}

		// Token: 0x1700010D RID: 269
		// (get) Token: 0x06000423 RID: 1059 RVA: 0x000153CC File Offset: 0x000143CC
		// (set) Token: 0x06000424 RID: 1060 RVA: 0x000153D4 File Offset: 0x000143D4
		public Color GrabHandleColor
		{
			get
			{
				return this._x273909d58eb80850;
			}
			set
			{
				this._x273909d58eb80850 = value;
				base.CustomColors = true;
			}
		}

		// Token: 0x1700010E RID: 270
		// (get) Token: 0x06000425 RID: 1061 RVA: 0x000153E4 File Offset: 0x000143E4
		// (set) Token: 0x06000426 RID: 1062 RVA: 0x000153EC File Offset: 0x000143EC
		public Color BorderColor
		{
			get
			{
				return this._xa1359fb73f86c7a4;
			}
			set
			{
				this._xa1359fb73f86c7a4 = value;
				base.CustomColors = true;
			}
		}

		// Token: 0x1700010F RID: 271
		// (get) Token: 0x06000427 RID: 1063 RVA: 0x000153FC File Offset: 0x000143FC
		// (set) Token: 0x06000428 RID: 1064 RVA: 0x00015404 File Offset: 0x00014404
		public Color ActionsButtonColor1
		{
			get
			{
				return this.xa94aca0885c7a27e;
			}
			set
			{
				this.xa94aca0885c7a27e = value;
				base.CustomColors = true;
				this.CalculateDerivedColors();
			}
		}

		// Token: 0x17000110 RID: 272
		// (get) Token: 0x06000429 RID: 1065 RVA: 0x0001541C File Offset: 0x0001441C
		// (set) Token: 0x0600042A RID: 1066 RVA: 0x00015424 File Offset: 0x00014424
		public Color ActionsButtonColor2
		{
			get
			{
				return this.x70d4b2922d9dda6a;
			}
			set
			{
				this.x70d4b2922d9dda6a = value;
				base.CustomColors = true;
				this.CalculateDerivedColors();
			}
		}

		// Token: 0x17000111 RID: 273
		// (get) Token: 0x0600042B RID: 1067 RVA: 0x0001543C File Offset: 0x0001443C
		// (set) Token: 0x0600042C RID: 1068 RVA: 0x00015444 File Offset: 0x00014444
		public override Color HighlightBorderColor
		{
			get
			{
				return this._x5bdc84993d5749e9;
			}
			set
			{
				this._x5bdc84993d5749e9 = value;
				this.x489a5698d424c87b();
			}
		}

		// Token: 0x17000112 RID: 274
		// (get) Token: 0x0600042D RID: 1069 RVA: 0x00015454 File Offset: 0x00014454
		// (set) Token: 0x0600042E RID: 1070 RVA: 0x0001545C File Offset: 0x0001445C
		public Color ToolBarGradientColor1
		{
			get
			{
				return this.xaaaf059eaea34d20;
			}
			set
			{
				this.xaaaf059eaea34d20 = value;
				base.CustomColors = true;
				this.CalculateDerivedColors();
			}
		}

		// Token: 0x17000113 RID: 275
		// (get) Token: 0x0600042F RID: 1071 RVA: 0x00015474 File Offset: 0x00014474
		// (set) Token: 0x06000430 RID: 1072 RVA: 0x0001547C File Offset: 0x0001447C
		public Color ToolBarGradientColor2
		{
			get
			{
				return this.x8bb53ee85f70380e;
			}
			set
			{
				this.x8bb53ee85f70380e = value;
				base.CustomColors = true;
				this.CalculateDerivedColors();
			}
		}

		// Token: 0x17000114 RID: 276
		// (get) Token: 0x06000431 RID: 1073 RVA: 0x00015494 File Offset: 0x00014494
		// (set) Token: 0x06000432 RID: 1074 RVA: 0x0001549C File Offset: 0x0001449C
		public Color ToolBarSeparatorColor
		{
			get
			{
				return this.x342ecbecb7467fe7;
			}
			set
			{
				this.x342ecbecb7467fe7 = value;
				base.CustomColors = true;
				this.CalculateDerivedColors();
			}
		}

		// Token: 0x17000115 RID: 277
		// (get) Token: 0x06000433 RID: 1075 RVA: 0x000154B4 File Offset: 0x000144B4
		// (set) Token: 0x06000434 RID: 1076 RVA: 0x000154BC File Offset: 0x000144BC
		public Color BackgroundGradientColor1
		{
			get
			{
				return this.x0ea41556e91b8cce;
			}
			set
			{
				this.x0ea41556e91b8cce = value;
				base.CustomColors = true;
				this.CalculateDerivedColors();
			}
		}

		// Token: 0x17000116 RID: 278
		// (get) Token: 0x06000435 RID: 1077 RVA: 0x000154D4 File Offset: 0x000144D4
		// (set) Token: 0x06000436 RID: 1078 RVA: 0x000154DC File Offset: 0x000144DC
		public Color BackgroundGradientColor2
		{
			get
			{
				return this.xaab0a0f66214f237;
			}
			set
			{
				this.xaab0a0f66214f237 = value;
				base.CustomColors = true;
				this.CalculateDerivedColors();
			}
		}

		// Token: 0x06000437 RID: 1079 RVA: 0x000154F4 File Offset: 0x000144F4
		protected override void CalculateDerivedColors()
		{
			base.CalculateDerivedColors();
			if (SystemInformation.HighContrast)
			{
				this.x20c63f79cff12f42 = ControlPaint.ContrastControlDark;
			}
			else
			{
				this.x20c63f79cff12f42 = Office2002Renderer.InterpolateColors(this.x70d4b2922d9dda6a, Color.Black, 0.1f);
			}
			this.xf0506556289a2233 = Office2002Renderer.InterpolateColors(this.xaab0a0f66214f237, Color.White, 0.5f);
			this.xb388c8c4edc070f5 = Office2002Renderer.InterpolateColors(this.xaaaf059eaea34d20, this.x8bb53ee85f70380e, 0.25f);
		}

		// Token: 0x06000438 RID: 1080 RVA: 0x00015570 File Offset: 0x00014570
		internal static bool x7fb2e1ce54a27086()
		{
			bool result = false;
			if (Environment.OSVersion.Platform == PlatformID.Win32NT)
			{
				result = (Environment.OSVersion.Version >= new Version(5, 1, 0, 0));
			}
			return result;
		}

		// Token: 0x06000439 RID: 1081 RVA: 0x000155A8 File Offset: 0x000145A8
		internal static bool x50291ec0a16eb117()
		{
			bool result = false;
			if (Environment.OSVersion.Platform == PlatformID.Win32NT)
			{
				result = (Environment.OSVersion.Version >= new Version(5, 0, 0, 0));
			}
			return result;
		}

		// Token: 0x0600043A RID: 1082 RVA: 0x000155E0 File Offset: 0x000145E0
		private LinearGradientBrush xb45023eeb6b54dd3(ToolBar x169279a87b6b72b2)
		{
			LinearGradientBrush result;
			if (x169279a87b6b72b2.Parent is ToolBarContainer && ((ToolBarContainer)x169279a87b6b72b2.Parent).Manager != null)
			{
				Rectangle rect = ((ToolBarContainer)x169279a87b6b72b2.Parent).Manager.GetScreenBounds();
				Point point = x169279a87b6b72b2.PointToClient(new Point(rect.X, rect.Y));
				Point point2 = x169279a87b6b72b2.PointToClient(new Point(rect.Right, rect.Y));
				result = new LinearGradientBrush(point, point2, this.x0ea41556e91b8cce, this.xaab0a0f66214f237);
			}
			else
			{
				Rectangle rect = x169279a87b6b72b2.ClientRectangle;
				result = new LinearGradientBrush(rect, this.x0ea41556e91b8cce, this.xaab0a0f66214f237, LinearGradientMode.Horizontal);
			}
			return result;
		}

		// Token: 0x0600043B RID: 1083 RVA: 0x00015688 File Offset: 0x00014688
		private void x24c579f9d6cb25b1(Graphics x41347a961b838962, Rectangle xda73fcb97c77d998, LinearGradientMode x23e85093ba3a7d1d)
		{
			if (xda73fcb97c77d998.Width > 0 && xda73fcb97c77d998.Height > 0)
			{
				using (Brush brush = this.xe70d5b03e620fb01(xda73fcb97c77d998, x23e85093ba3a7d1d))
				{
					x41347a961b838962.FillRectangle(brush, xda73fcb97c77d998);
				}
			}
		}

		// Token: 0x0600043C RID: 1084 RVA: 0x000156E4 File Offset: 0x000146E4
		private void x24c579f9d6cb25b1(Graphics x41347a961b838962, Rectangle xda73fcb97c77d998, LinearGradientMode x23e85093ba3a7d1d, Point[] x6fa2570084b2ad39)
		{
			if (xda73fcb97c77d998.Width > 0 && xda73fcb97c77d998.Height > 0)
			{
				using (Brush brush = this.xe70d5b03e620fb01(xda73fcb97c77d998, x23e85093ba3a7d1d))
				{
					x41347a961b838962.FillPolygon(brush, x6fa2570084b2ad39);
				}
			}
		}

		// Token: 0x0600043D RID: 1085 RVA: 0x00015740 File Offset: 0x00014740
		private Brush xe70d5b03e620fb01(Rectangle xda73fcb97c77d998, LinearGradientMode x23e85093ba3a7d1d)
		{
			return new LinearGradientBrush(xda73fcb97c77d998, this.xaaaf059eaea34d20, this.x8bb53ee85f70380e, x23e85093ba3a7d1d)
			{
				InterpolationColors = new ColorBlend(3)
				{
					Colors = new Color[]
					{
						this.xaaaf059eaea34d20,
						this.xb388c8c4edc070f5,
						this.x8bb53ee85f70380e
					},
					Positions = new float[]
					{
						0f,
						0.5f,
						1f
					}
				}
			};
		}

		// Token: 0x0600043E RID: 1086 RVA: 0x000157D4 File Offset: 0x000147D4
		protected override void DrawOpenDropDownItem(Graphics graphics, TopLevelMenuItemBase item)
		{
			Rectangle buttonBounds = item.ButtonBounds;
			if (!SystemInformation.HighContrast)
			{
				using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(buttonBounds, this.xf0506556289a2233, this.x0ea41556e91b8cce, LinearGradientMode.Vertical))
				{
					graphics.FillRectangle(linearGradientBrush, buttonBounds);
				}
			}
			using (Pen pen = new Pen(this.x20c63f79cff12f42))
			{
				if (item.MenuDirection != MenuProjection.Left)
				{
					graphics.DrawLine(pen, buttonBounds.X, buttonBounds.Y, buttonBounds.X, buttonBounds.Y + buttonBounds.Height - 1);
				}
				if (item.MenuDirection != MenuProjection.Right)
				{
					graphics.DrawLine(pen, buttonBounds.X + buttonBounds.Width, buttonBounds.Y, buttonBounds.X + buttonBounds.Width, buttonBounds.Y + buttonBounds.Height - 1);
				}
				if (item.MenuDirection != MenuProjection.Bottom)
				{
					graphics.DrawLine(pen, buttonBounds.X, buttonBounds.Bottom, buttonBounds.X + buttonBounds.Width, buttonBounds.Bottom);
				}
				if (item.MenuDirection != MenuProjection.Top)
				{
					graphics.DrawLine(pen, buttonBounds.X, buttonBounds.Y, buttonBounds.X + buttonBounds.Width, buttonBounds.Y);
				}
			}
		}

		// Token: 0x0600043F RID: 1087 RVA: 0x00015948 File Offset: 0x00014948
		public override void DrawSystemButton(Graphics graphics, Rectangle bounds, ToolBarGlyphType glyphType, DrawItemState state, bool floating)
		{
			this.DrawButtonHighlight(graphics, bounds, state, false);
			if (state != DrawItemState.Default || !floating)
			{
				base.xc64a3464af8e94fb(graphics, bounds, glyphType, Color.Black);
				return;
			}
			base.xc64a3464af8e94fb(graphics, bounds, glyphType, this.x7f9d9df7414c77ae);
		}

		// Token: 0x06000440 RID: 1088 RVA: 0x00015980 File Offset: 0x00014980
		protected override void DrawTextCore(string text, Graphics graphics, Font font, Color color, DrawItemState state, Rectangle bounds, TextFormatFlags textFormat)
		{
			if ((state & DrawItemState.Disabled) == DrawItemState.Disabled)
			{
				TextRenderer.DrawText(graphics, text, font, bounds, SystemColors.GrayText, textFormat);
				return;
			}
			if ((state & DrawItemState.Selected) == DrawItemState.Selected)
			{
				TextRenderer.DrawText(graphics, text, font, bounds, this.x5f8540e2e750d7a9, textFormat);
				return;
			}
			TextRenderer.DrawText(graphics, text, font, bounds, color, textFormat);
		}

		// Token: 0x06000441 RID: 1089 RVA: 0x000159D0 File Offset: 0x000149D0
		public override void DrawImageCore(ImageList imageList, int imageIndex, Graphics graphics, DrawItemState state, Rectangle bounds)
		{
			if ((state & DrawItemState.Disabled) == DrawItemState.Disabled || SystemInformation.HighContrast)
			{
				using (Image image = imageList.Images[imageIndex])
				{
					this.DrawImageCore(image, graphics, state, bounds);
					return;
				}
			}
			imageList.Draw(graphics, bounds.X, bounds.Y, imageIndex);
		}

		// Token: 0x06000442 RID: 1090 RVA: 0x00015A44 File Offset: 0x00014A44
		public override void DrawImageCore(Image image, Graphics graphics, DrawItemState state, Rectangle bounds)
		{
			if ((state & DrawItemState.Disabled) == DrawItemState.Disabled)
			{
				graphics.DrawImage(image, bounds, 0, 0, bounds.Width, bounds.Height, GraphicsUnit.Pixel, base.x45a4d3ef4697069b);
				return;
			}
			if (SystemInformation.HighContrast)
			{
				graphics.DrawImage(image, bounds, 0, 0, bounds.Width, bounds.Height, GraphicsUnit.Pixel, base.x5680416382e412a2);
				return;
			}
			graphics.DrawImage(image, bounds);
		}

		// Token: 0x06000443 RID: 1091 RVA: 0x00015AAC File Offset: 0x00014AAC
		public override void DrawIconCore(Icon icon, Graphics graphics, DrawItemState state, Rectangle bounds)
		{
			if ((state & DrawItemState.Disabled) == DrawItemState.Disabled)
			{
				using (Bitmap bitmap = Office2002Renderer.x9507a49742823ba9(icon))
				{
					graphics.DrawImage(bitmap, bounds, 0, 0, bounds.Width, bounds.Height, GraphicsUnit.Pixel, base.x45a4d3ef4697069b);
					return;
				}
			}
			graphics.DrawIconUnstretched(icon, bounds);
		}

		// Token: 0x06000444 RID: 1092 RVA: 0x00015B18 File Offset: 0x00014B18
		public override void DrawButtonHighlight(Graphics graphics, Rectangle bounds, DrawItemState state, bool dropDown)
		{
			if (bounds.Width > 0)
			{
				bool flag2;
				bool flag = (flag2 ? 1U : 0U) + (flag2 ? 1U : 0U) < 0U;
				Pen pen;
				Brush brush;
				if (!flag)
				{
					if (bounds.Height <= 0)
					{
						return;
					}
					flag2 = ((state & DrawItemState.HotLight) == DrawItemState.HotLight || (state & DrawItemState.Selected) == DrawItemState.Selected || (state & DrawItemState.Checked) == DrawItemState.Checked);
					pen = new Pen(this._x5bdc84993d5749e9);
					if (!flag2)
					{
						goto IL_3E;
					}
					if ((state & DrawItemState.Selected) == DrawItemState.Selected)
					{
						brush = new LinearGradientBrush(bounds, this.x59bf7e25a95a2780, this.xf3f219013bfbc916, LinearGradientMode.Vertical);
					}
					else if ((state & DrawItemState.HotLight) == DrawItemState.HotLight)
					{
						if (((dropDown ? 1U : 0U) | 4294967294U) == 0U)
						{
							goto IL_45;
						}
						brush = new LinearGradientBrush(bounds, this.x228685f29c2ed324, this.x2b5af2e4edc60a47, LinearGradientMode.Vertical);
					}
					else
					{
						brush = new LinearGradientBrush(bounds, this.x546109961b6ba7ce, this.x1a50e46d85acd88d, LinearGradientMode.Vertical);
					}
				}
				graphics.FillRectangle(brush, bounds);
				graphics.DrawRectangle(pen, bounds);
				brush.Dispose();
				IL_3E:
				if (!dropDown || !flag2)
				{
					goto IL_99;
				}
				IL_45:
				bounds.Offset(bounds.Width - 11, 0);
				bounds.Width -= bounds.Width - 11;
				brush = new LinearGradientBrush(bounds, this.x228685f29c2ed324, this.x2b5af2e4edc60a47, LinearGradientMode.Vertical);
				graphics.FillRectangle(brush, bounds);
				graphics.DrawRectangle(pen, bounds);
				brush.Dispose();
				IL_99:
				pen.Dispose();
				return;
			}
		}

		// Token: 0x06000445 RID: 1093 RVA: 0x00015C74 File Offset: 0x00014C74
		public override void DrawFloatingFormBackground(Graphics graphics, Rectangle bounds)
		{
			using (SolidBrush solidBrush = new SolidBrush(this.xca2b1cd1d862168f))
			{
				graphics.FillRectangle(solidBrush, bounds);
			}
			bounds.Inflate(-SystemInformation.FixedFrameBorderSize.Width, -SystemInformation.FixedFrameBorderSize.Height);
			using (Pen pen = new Pen(this.xaab0a0f66214f237))
			{
				graphics.DrawLine(pen, bounds.X, bounds.Y - 1, bounds.Right - 1, bounds.Y - 1);
				graphics.DrawLine(pen, bounds.X, bounds.Bottom, bounds.Right - 1, bounds.Bottom);
				graphics.DrawLine(pen, bounds.X - 1, bounds.Y, bounds.X - 1, bounds.Bottom - 1);
				graphics.DrawLine(pen, bounds.Right, bounds.Y, bounds.Right, bounds.Bottom - 1);
			}
			bounds.Height = SystemInformation.ToolWindowCaptionButtonSize.Height;
			using (SolidBrush solidBrush2 = new SolidBrush(this.xca2b1cd1d862168f))
			{
				graphics.FillRectangle(solidBrush2, bounds);
			}
		}

		// Token: 0x06000446 RID: 1094 RVA: 0x00015DFC File Offset: 0x00014DFC
		public override void DrawFloatingFormText(string text, Graphics graphics, Font font, Rectangle bounds)
		{
			bounds.Inflate(-2, 0);
			using (Font font2 = new Font(font, FontStyle.Bold))
			{
				base.DrawText(text, graphics, font2, this.x7f9d9df7414c77ae, DrawItemState.Default, bounds, this.ItemTextFormatFlags, false);
			}
		}

		// Token: 0x06000447 RID: 1095 RVA: 0x00015E60 File Offset: 0x00014E60
		public override void DrawToolBarBackground(ToolBar toolbar, Graphics graphics, Rectangle bounds, bool vertical)
		{
			bool flag = toolbar.Situation == ToolBarSituation.Contained;
			for (;;)
			{
				IL_3E9:
				bool flag2 = true;
				bool flag3 = toolbar.Situation == ToolBarSituation.Contained;
				if (flag)
				{
					using (Brush brush = this.xb45023eeb6b54dd3(toolbar))
					{
						graphics.FillRectangle(brush, bounds);
					}
				}
				if (toolbar.Situation == ToolBarSituation.Contained)
				{
					if (vertical)
					{
						bounds.X++;
						bounds.Width--;
					}
					else
					{
						bounds.Y++;
						bounds.Height--;
					}
				}
				for (;;)
				{
					LinearGradientMode x23e85093ba3a7d1d = vertical ? LinearGradientMode.Horizontal : LinearGradientMode.Vertical;
					for (;;)
					{
						if (flag2)
						{
							if (flag3)
							{
								Point[] x6fa2570084b2ad = new Point[]
								{
									new Point(bounds.Left + 2, bounds.Bottom),
									new Point(bounds.Left, bounds.Bottom - 3),
									new Point(bounds.Left, bounds.Top + 2),
									new Point(bounds.Left + 2, bounds.Top),
									new Point(bounds.Right - 2, bounds.Top),
									new Point(bounds.Right, bounds.Top + 2),
									new Point(bounds.Right, bounds.Bottom - 3),
									new Point(bounds.Right - 3, bounds.Bottom)
								};
								this.x24c579f9d6cb25b1(graphics, bounds, x23e85093ba3a7d1d, x6fa2570084b2ad);
								Color color = Color.FromArgb(100, this.xaaaf059eaea34d20);
								using (SolidBrush solidBrush = new SolidBrush(color))
								{
									graphics.FillRectangle(solidBrush, bounds.Left + 1, bounds.Top, 1, 1);
									graphics.FillRectangle(solidBrush, bounds.Left, bounds.Top + 1, 1, 1);
									goto IL_0F;
								}
								goto IL_3E9;
								IL_0F:
								if (!toolbar.DrawActionsButton)
								{
									if (vertical)
									{
										color = Color.FromArgb(100, this.x8bb53ee85f70380e);
									}
									using (SolidBrush solidBrush2 = new SolidBrush(color))
									{
										graphics.FillRectangle(solidBrush2, bounds.Right - 2, bounds.Top, 1, 1);
										graphics.FillRectangle(solidBrush2, bounds.Right - 1, bounds.Top + 1, 1, 1);
									}
								}
								Color color2 = Color.FromArgb(100, this.x8bb53ee85f70380e);
								if (!toolbar.DrawActionsButton)
								{
									using (SolidBrush solidBrush3 = new SolidBrush(color2))
									{
										graphics.FillRectangle(solidBrush3, bounds.Right - 2, bounds.Bottom - 1, 1, 1);
										graphics.FillRectangle(solidBrush3, bounds.Right - 1, bounds.Bottom - 2, 1, 1);
									}
								}
								if (vertical)
								{
									color2 = Color.FromArgb(100, this.xaaaf059eaea34d20);
								}
								using (SolidBrush solidBrush4 = new SolidBrush(color2))
								{
									graphics.FillRectangle(solidBrush4, bounds.Left + 1, bounds.Bottom - 1, 1, 1);
									graphics.FillRectangle(solidBrush4, bounds.Left, bounds.Bottom - 2, 1, 1);
									goto IL_147;
								}
							}
							this.x24c579f9d6cb25b1(graphics, bounds, x23e85093ba3a7d1d);
						}
						IL_147:
						if (toolbar.Situation != ToolBarSituation.Contained)
						{
							break;
						}
						if ((vertical ? 1U : 0U) - (vertical ? 1U : 0U) >= 0U)
						{
							goto Block_9;
						}
					}
					IL_1F2:
					if (SystemInformation.HighContrast)
					{
						bounds.Width--;
						bounds.Height--;
						using (Pen pen = new Pen(SystemColors.ControlDark))
						{
							pen.DashStyle = DashStyle.Dot;
							graphics.DrawRectangle(pen, bounds);
							return;
						}
						continue;
					}
					return;
					Block_9:
					if (toolbar.DrawActionsButton)
					{
						using (Pen pen2 = new Pen(this._xa1359fb73f86c7a4))
						{
							if (vertical)
							{
								graphics.DrawLine(pen2, bounds.Right - 1, bounds.Top + 3, bounds.Right - 1, bounds.Bottom - 3);
							}
							else
							{
								graphics.DrawLine(pen2, bounds.X + 2, bounds.Bottom - 1, bounds.Right - 3, bounds.Bottom - 1);
							}
						}
						goto IL_1F2;
					}
					goto IL_1F2;
				}
			}
		}

		// Token: 0x06000448 RID: 1096 RVA: 0x00016388 File Offset: 0x00015388
		public override void DrawToolBarSeparator(Graphics graphics, Rectangle bounds, bool vertical)
		{
			using (Pen pen = new Pen(this.x342ecbecb7467fe7))
			{
				if (vertical)
				{
					graphics.DrawLine(pen, bounds.Left + 4, bounds.Top + 1, bounds.Right - 5, bounds.Top + 1);
					graphics.DrawLine(SystemPens.ControlLightLight, bounds.Left + 5, bounds.Top + 2, bounds.Right - 4, bounds.Top + 2);
				}
				else
				{
					graphics.DrawLine(pen, bounds.Left + 1, bounds.Top + 4, bounds.Left + 1, bounds.Bottom - 5);
					graphics.DrawLine(SystemPens.ControlLightLight, bounds.Left + 2, bounds.Top + 5, bounds.Left + 2, bounds.Bottom - 4);
				}
			}
		}

		// Token: 0x06000449 RID: 1097 RVA: 0x00016484 File Offset: 0x00015484
		public override void DrawToolBarGrabHandle(Graphics graphics, Rectangle bounds, bool vertical)
		{
			using (SolidBrush solidBrush = new SolidBrush(this._x273909d58eb80850))
			{
				if (vertical)
				{
					int num = (bounds.Width - 2) / 4;
					int num2 = num * 4 - 2;
					int num3 = bounds.Y + bounds.Height / 2 - 1;
					int num4 = bounds.X + bounds.Width / 2 - num2 / 2 - 1;
					for (int i = num4; i <= num4 + num2; i += 4)
					{
						graphics.FillRectangle(SystemBrushes.ControlLightLight, new Rectangle(i + 1, num3 + 1, 2, 2));
						graphics.FillRectangle(solidBrush, new Rectangle(i, num3, 2, 2));
					}
				}
				else
				{
					int num = (bounds.Height - 2) / 4;
					int num2 = num * 4 - 2;
					int num3 = bounds.X + bounds.Width / 2 - 1;
					int num4 = bounds.Y + bounds.Height / 2 - num2 / 2;
					for (int j = num4; j <= num4 + num2; j += 4)
					{
						graphics.FillRectangle(SystemBrushes.ControlLightLight, new Rectangle(num3 + 1, j + 1, 2, 2));
						graphics.FillRectangle(solidBrush, new Rectangle(num3, j, 2, 2));
					}
				}
			}
		}

		// Token: 0x0600044A RID: 1098 RVA: 0x000165C4 File Offset: 0x000155C4
		private void xdd737923572c4311(Graphics x41347a961b838962, int x08db3aeabb253cb1, int x1e218ceaee1bb583)
		{
			x41347a961b838962.DrawLine(Pens.Black, x08db3aeabb253cb1, x1e218ceaee1bb583, x08db3aeabb253cb1, x1e218ceaee1bb583 + 2);
			x41347a961b838962.DrawLine(Pens.Black, x08db3aeabb253cb1, x1e218ceaee1bb583 + 1, x08db3aeabb253cb1 + 1, x1e218ceaee1bb583 + 1);
			x41347a961b838962.DrawLine(Pens.White, x08db3aeabb253cb1 + 1, x1e218ceaee1bb583 + 2, x08db3aeabb253cb1 + 1, x1e218ceaee1bb583 + 3);
			x41347a961b838962.DrawLine(Pens.White, x08db3aeabb253cb1 + 1, x1e218ceaee1bb583 + 2, x08db3aeabb253cb1 + 2, x1e218ceaee1bb583 + 2);
			x41347a961b838962.DrawLine(Pens.Black, x08db3aeabb253cb1 + 4, x1e218ceaee1bb583, x08db3aeabb253cb1 + 4, x1e218ceaee1bb583 + 2);
			x41347a961b838962.DrawLine(Pens.Black, x08db3aeabb253cb1 + 4, x1e218ceaee1bb583 + 1, x08db3aeabb253cb1 + 5, x1e218ceaee1bb583 + 1);
			x41347a961b838962.DrawLine(Pens.White, x08db3aeabb253cb1 + 5, x1e218ceaee1bb583 + 2, x08db3aeabb253cb1 + 5, x1e218ceaee1bb583 + 3);
			x41347a961b838962.DrawLine(Pens.White, x08db3aeabb253cb1 + 5, x1e218ceaee1bb583 + 2, x08db3aeabb253cb1 + 6, x1e218ceaee1bb583 + 2);
		}

		// Token: 0x0600044B RID: 1099 RVA: 0x00016680 File Offset: 0x00015680
		public override void DrawToolBarActionsButton(Graphics graphics, Rectangle bounds, bool vertical, bool chevron, DrawItemState state, bool designMode)
		{
			Point[] array = new Point[8];
			bounds.Inflate(0, -1);
			bounds.Height++;
			LinearGradientMode linearGradientMode;
			if (vertical)
			{
				linearGradientMode = LinearGradientMode.Horizontal;
			}
			else
			{
				linearGradientMode = LinearGradientMode.Vertical;
			}
			Color color;
			Color color2;
			if ((state & DrawItemState.Selected) == DrawItemState.Selected)
			{
				color = this.x59bf7e25a95a2780;
				color2 = this.xf3f219013bfbc916;
			}
			else if ((state & DrawItemState.HotLight) == DrawItemState.HotLight)
			{
				color = this.x228685f29c2ed324;
				color2 = this.x2b5af2e4edc60a47;
			}
			else
			{
				color = this.xa94aca0885c7a27e;
				color2 = this.x70d4b2922d9dda6a;
			}
			LinearGradientBrush linearGradientBrush = new LinearGradientBrush(bounds, color, color2, linearGradientMode);
			if (vertical)
			{
				array[0] = new Point(bounds.Right, bounds.Y - 3);
				array[1] = new Point(bounds.Right, bounds.Bottom - 3);
				array[2] = new Point(bounds.Right - 3, bounds.Bottom - 1);
				goto IL_37A;
			}
			array[0] = new Point(bounds.X, bounds.Y);
			array[1] = new Point(bounds.Right - 2, bounds.Top);
			array[2] = new Point(bounds.Right, bounds.Top + 2);
			array[3] = new Point(bounds.Right, bounds.Bottom - 3);
			array[4] = new Point(bounds.Right - 3, bounds.Bottom);
			array[5] = new Point(bounds.X - 1, bounds.Bottom);
			array[6] = new Point(bounds.X + 2, bounds.Bottom - 3);
			array[7] = new Point(bounds.X + 2, bounds.Top + 2);
			IL_209:
			if (!SystemInformation.HighContrast)
			{
				graphics.FillPolygon(linearGradientBrush, array);
			}
			Color color3 = Color.FromArgb(100, color);
			using (SolidBrush solidBrush = new SolidBrush(color3))
			{
				if (!vertical)
				{
					graphics.FillRectangle(solidBrush, bounds.Right - 2, bounds.Top, 1, 1);
					graphics.FillRectangle(solidBrush, bounds.Right - 1, bounds.Top + 1, 1, 1);
				}
			}
			Color color4 = Color.FromArgb(100, color2);
			using (SolidBrush solidBrush2 = new SolidBrush(color4))
			{
				if (!vertical)
				{
					graphics.FillRectangle(solidBrush2, bounds.Right - 2, bounds.Bottom - 1, 1, 1);
					graphics.FillRectangle(solidBrush2, bounds.Right - 1, bounds.Bottom - 2, 1, 1);
				}
			}
			if (designMode)
			{
				int num;
				int num2;
				if (!vertical)
				{
					num = bounds.X + bounds.Width / 2 + 1;
					num2 = bounds.Y + bounds.Height / 2 - 1;
					goto IL_348;
				}
				if ((uint)num2 - (designMode ? 1U : 0U) < 0U)
				{
					goto IL_58;
				}
				num = bounds.X + bounds.Width / 2;
				IL_307:
				num2 = bounds.Y + bounds.Height / 2 - 1;
				IL_348:
				graphics.DrawLine(Pens.White, num - 1, num2 + 1, num + 3, num2 + 1);
				if (((uint)num & 0U) != 0U)
				{
					goto IL_37A;
				}
				graphics.DrawLine(Pens.White, num + 1, num2 - 1, num + 1, num2 + 3);
				if (((vertical ? 1U : 0U) & 0U) != 0U)
				{
					return;
				}
				graphics.DrawLine(Pens.Black, num - 2, num2, num + 2, num2);
				if ((uint)num2 >= 0U)
				{
					graphics.DrawLine(Pens.Black, num, num2 - 2, num, num2 + 2);
					goto IL_1BB;
				}
				goto IL_307;
			}
			else if (!chevron)
			{
				goto IL_71;
			}
			IL_58:
			this.xdd737923572c4311(graphics, bounds.X + 4, bounds.Y + 4);
			IL_71:
			if (vertical)
			{
				base.xc856767407074e62(graphics, bounds.Right - 6, bounds.Bottom - 8, Color.White);
				base.xc856767407074e62(graphics, bounds.Right - 7, bounds.Bottom - 9, Color.Black);
				graphics.DrawLine(Pens.Black, bounds.Right - 10, bounds.Y + 2, bounds.Right - 10, bounds.Bottom - 5);
				graphics.DrawLine(Pens.White, bounds.Right - 9, bounds.Y + 3, bounds.Right - 9, bounds.Bottom - 4);
			}
			else
			{
				base.x68147b43ffdf95d9(graphics, bounds.X + 6, bounds.Bottom - 6, Color.White);
				base.x68147b43ffdf95d9(graphics, bounds.X + 5, bounds.Bottom - 7, Color.Black);
				graphics.DrawLine(Pens.Black, bounds.X + 5, bounds.Bottom - 10, bounds.X + 9, bounds.Bottom - 10);
				graphics.DrawLine(Pens.White, bounds.X + 6, bounds.Bottom - 9, bounds.X + 10, bounds.Bottom - 9);
			}
			IL_1BB:
			linearGradientBrush.Dispose();
			return;
			IL_37A:
			array[3] = new Point(bounds.X + 2, bounds.Bottom - 1);
			array[4] = new Point(bounds.X, bounds.Bottom - 3);
			array[5] = new Point(bounds.X, bounds.Y - 3);
			array[6] = new Point(bounds.X + 2, bounds.Y);
			array[7] = new Point(bounds.Right - 3, bounds.Y);
			goto IL_209;
		}

		// Token: 0x0600044C RID: 1100 RVA: 0x00016CD8 File Offset: 0x00015CD8
		public override void DrawContainerBackground(Graphics graphics, Rectangle bounds, Rectangle layoutBounds)
		{
			if (bounds.Width > 0 && bounds.Height > 0)
			{
				Point point = new Point(layoutBounds.X, layoutBounds.Y);
				Point point2 = new Point(layoutBounds.Right, layoutBounds.Y);
				using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(point, point2, this.x0ea41556e91b8cce, this.xaab0a0f66214f237))
				{
					graphics.FillRectangle(linearGradientBrush, bounds);
				}
			}
		}

		// Token: 0x17000117 RID: 279
		// (get) Token: 0x0600044D RID: 1101 RVA: 0x00016D68 File Offset: 0x00015D68
		public override Color ShadowColor
		{
			get
			{
				return this.x70d4b2922d9dda6a;
			}
		}

		// Token: 0x0600044E RID: 1102 RVA: 0x00016D70 File Offset: 0x00015D70
		public override void DrawMenuActionsButton(Graphics graphics, Rectangle bounds, int marginWidth, DrawItemState state, bool designMode)
		{
			bounds = new Rectangle(bounds.X + bounds.Width / 2 - 8, bounds.Y + bounds.Height / 2 - 7, 15, 15);
			this.xd5b7e2d5105fc2ed(graphics, bounds, this.xaaaf059eaea34d20, this.x8bb53ee85f70380e);
			if (designMode)
			{
				graphics.DrawLine(SystemPens.ControlLightLight, bounds.X + 8, bounds.Y + 7, bounds.X + 8, bounds.Y + 11);
				graphics.DrawLine(SystemPens.ControlLightLight, bounds.X + 6, bounds.Y + 9, bounds.X + 10, bounds.Y + 9);
				graphics.DrawLine(SystemPens.ControlText, bounds.X + 7, bounds.Y + 6, bounds.X + 7, bounds.Y + 10);
				graphics.DrawLine(SystemPens.ControlText, bounds.X + 5, bounds.Y + 8, bounds.X + 9, bounds.Y + 8);
				return;
			}
			graphics.DrawLine(SystemPens.ControlText, bounds.X + 5, bounds.Y + 4, bounds.X + 7, bounds.Y + 6);
			graphics.DrawLine(SystemPens.ControlText, bounds.X + 5, bounds.Y + 5, bounds.X + 7, bounds.Y + 7);
			graphics.DrawLine(SystemPens.ControlText, bounds.X + 5, bounds.Y + 8, bounds.X + 7, bounds.Y + 10);
			graphics.DrawLine(SystemPens.ControlText, bounds.X + 5, bounds.Y + 9, bounds.X + 7, bounds.Y + 11);
			graphics.DrawLine(SystemPens.ControlText, bounds.X + 7, bounds.Y + 6, bounds.X + 9, bounds.Y + 4);
			graphics.DrawLine(SystemPens.ControlText, bounds.X + 7, bounds.Y + 7, bounds.X + 9, bounds.Y + 5);
			graphics.DrawLine(SystemPens.ControlText, bounds.X + 7, bounds.Y + 10, bounds.X + 9, bounds.Y + 8);
			graphics.DrawLine(SystemPens.ControlText, bounds.X + 7, bounds.Y + 11, bounds.X + 9, bounds.Y + 9);
		}

		// Token: 0x0600044F RID: 1103 RVA: 0x00017010 File Offset: 0x00016010
		private void xd5b7e2d5105fc2ed(Graphics x41347a961b838962, Rectangle xda73fcb97c77d998, Color x6d9a095d183b6b50, Color x60a2487f840b534c)
		{
			SmoothingMode smoothingMode = x41347a961b838962.SmoothingMode;
			x41347a961b838962.SmoothingMode = SmoothingMode.AntiAlias;
			GraphicsPath graphicsPath = new GraphicsPath();
			Rectangle rect = xda73fcb97c77d998;
			rect.Offset(-Convert.ToInt32((double)xda73fcb97c77d998.Width * 0.2), -Convert.ToInt32((double)xda73fcb97c77d998.Height * 0.2));
			rect.Inflate(Convert.ToInt32((double)xda73fcb97c77d998.Width * 0.3), Convert.ToInt32((double)xda73fcb97c77d998.Width * 0.3));
			graphicsPath.AddEllipse(rect);
			using (PathGradientBrush pathGradientBrush = new PathGradientBrush(graphicsPath))
			{
				pathGradientBrush.CenterColor = x6d9a095d183b6b50;
				pathGradientBrush.SurroundColors = new Color[]
				{
					x60a2487f840b534c
				};
				x41347a961b838962.FillEllipse(pathGradientBrush, xda73fcb97c77d998);
			}
			x41347a961b838962.SmoothingMode = smoothingMode;
		}

		// Token: 0x06000450 RID: 1104 RVA: 0x0001710C File Offset: 0x0001610C
		protected virtual void DrawMenuMargin(Graphics graphics, Rectangle bounds)
		{
			this.x24c579f9d6cb25b1(graphics, bounds, LinearGradientMode.Horizontal);
		}

		// Token: 0x06000451 RID: 1105 RVA: 0x00017118 File Offset: 0x00016118
		public override void DrawMenuBackground(Graphics graphics, Rectangle bounds, int marginWidth, int breakOffset, int breakSize, MenuProjection menuDirection, bool rightToLeft, bool rightAligned)
		{
			graphics.Clear(base.MenuBackgroundColor);
			using (Pen pen = new Pen(this.x20c63f79cff12f42))
			{
				graphics.DrawRectangle(pen, bounds);
			}
			if (breakSize != 0)
			{
				using (Pen pen2 = new Pen(base.MenuBackgroundColor))
				{
					int x;
					int x2;
					int y;
					int y2;
					base.xca828f6f883d0151(bounds, breakOffset, breakSize, menuDirection, rightToLeft || rightAligned, out x, out x2, out y, out y2);
					graphics.DrawLine(pen2, x, y, x2, y2);
				}
			}
			bounds.Inflate(-1, -1);
			bounds.Y++;
			bounds.Height--;
			if (rightToLeft)
			{
				bounds.X = bounds.Right - (marginWidth - 8) + 1;
			}
			bounds.Width = marginWidth - 8;
			this.DrawMenuMargin(graphics, bounds);
		}

		// Token: 0x06000452 RID: 1106 RVA: 0x00017220 File Offset: 0x00016220
		public override void DrawMenuItemHighlight(Graphics graphics, MenuButtonItem item, Rectangle bounds)
		{
			if (item.Enabled)
			{
				using (SolidBrush solidBrush = new SolidBrush(this.x154e298f2834a9ad))
				{
					graphics.FillRectangle(solidBrush, bounds);
				}
			}
			using (Pen pen = new Pen(this._x5bdc84993d5749e9))
			{
				graphics.DrawRectangle(pen, bounds);
			}
		}

		// Token: 0x06000453 RID: 1107 RVA: 0x000172AC File Offset: 0x000162AC
		public override void DrawMenuItemCheck(Graphics graphics, MenuButtonItem item, bool drawCheckMark, Rectangle bounds)
		{
			Pen pen;
			if (item.Enabled)
			{
				pen = SystemPens.ControlText;
			}
			else
			{
				pen = SystemPens.ControlDark;
			}
			if (item.Enabled)
			{
				this.DrawButtonHighlight(graphics, bounds, DrawItemState.Checked, false);
			}
			else
			{
				graphics.DrawRectangle(pen, bounds);
			}
			if (drawCheckMark)
			{
				int num = bounds.X + bounds.Width / 2;
				int num2 = bounds.Y + bounds.Height / 2;
				graphics.DrawLine(pen, num - 3, num2, num - 1, num2 + 2);
				graphics.DrawLine(pen, num - 3, num2 + 1, num - 1, num2 + 3);
				graphics.DrawLine(pen, num - 1, num2 + 2, num + 3, num2 - 2);
				graphics.DrawLine(pen, num - 1, num2 + 3, num + 3, num2 - 1);
			}
		}

		// Token: 0x06000454 RID: 1108 RVA: 0x00017360 File Offset: 0x00016360
		public override void DrawMenuSeparator(Graphics graphics, Rectangle bounds, int marginWidth, bool rightToLeft)
		{
			using (Pen pen = new Pen(this.x0ea41556e91b8cce))
			{
				if (rightToLeft)
				{
					graphics.DrawLine(pen, bounds.Left, bounds.Y + 1, bounds.Right - marginWidth - 1, bounds.Y + 1);
				}
				else
				{
					graphics.DrawLine(pen, marginWidth + 1, bounds.Y + 1, bounds.Right - 1, bounds.Y + 1);
				}
			}
		}

		// Token: 0x06000455 RID: 1109 RVA: 0x000173F8 File Offset: 0x000163F8
		internal override void x201cde0ed3e8c66d(Graphics x41347a961b838962, Rectangle xda73fcb97c77d998, DrawItemState x01b557925841ae51)
		{
			if ((x01b557925841ae51 & DrawItemState.Selected) == DrawItemState.Selected)
			{
				LinearGradientBrush linearGradientBrush;
				LinearGradientBrush brush = linearGradientBrush = new LinearGradientBrush(xda73fcb97c77d998, this.x59bf7e25a95a2780, this.xf3f219013bfbc916, LinearGradientMode.Vertical);
				try
				{
					x41347a961b838962.FillRectangle(brush, xda73fcb97c77d998);
					return;
				}
				finally
				{
					if (linearGradientBrush != null)
					{
						((IDisposable)linearGradientBrush).Dispose();
					}
				}
			}
			if ((x01b557925841ae51 & DrawItemState.HotLight) == DrawItemState.HotLight)
			{
				LinearGradientBrush linearGradientBrush2;
				LinearGradientBrush brush = linearGradientBrush2 = new LinearGradientBrush(xda73fcb97c77d998, this.x228685f29c2ed324, this.x2b5af2e4edc60a47, LinearGradientMode.Vertical);
				try
				{
					x41347a961b838962.FillRectangle(brush, xda73fcb97c77d998);
					return;
				}
				finally
				{
					if (linearGradientBrush2 != null)
					{
						((IDisposable)linearGradientBrush2).Dispose();
					}
				}
			}
			this.x24c579f9d6cb25b1(x41347a961b838962, xda73fcb97c77d998, LinearGradientMode.Vertical);
		}

		// Token: 0x06000456 RID: 1110 RVA: 0x000174A4 File Offset: 0x000164A4
		internal override void x7f54571e6ebdb187(ComboBox xcb72be8a310acf66, Graphics x41347a961b838962, Rectangle xda73fcb97c77d998, DrawItemState x01b557925841ae51)
		{
			base.x7f54571e6ebdb187(xcb72be8a310acf66, x41347a961b838962, xda73fcb97c77d998, x01b557925841ae51);
			for (;;)
			{
				ToolBar toolBar = xcb72be8a310acf66.Parent as ToolBar;
				if ((x01b557925841ae51 & DrawItemState.Disabled) == DrawItemState.Disabled || toolBar == null || (x01b557925841ae51 & DrawItemState.HotLight) == DrawItemState.HotLight)
				{
					break;
				}
				LinearGradientBrush linearGradientBrush;
				if (xcb72be8a310acf66 == null)
				{
					linearGradientBrush = new LinearGradientBrush(xda73fcb97c77d998, this.xaaaf059eaea34d20, this.x8bb53ee85f70380e, LinearGradientMode.Vertical);
					goto IL_3B;
				}
				if (!(toolBar is MenuBar))
				{
					goto IL_13C;
				}
				if (false)
				{
					goto IL_52;
				}
				if (toolBar.Parent is ToolBarContainer)
				{
					goto IL_C2;
				}
				goto IL_13C;
				IL_1CC:
				if (false)
				{
					continue;
				}
				break;
				IL_52:
				Rectangle rect;
				rect.Width = 1;
				x41347a961b838962.FillRectangle(linearGradientBrush, rect);
				rect = xda73fcb97c77d998;
				rect.X = rect.Right;
				rect.Width = 1;
				x41347a961b838962.FillRectangle(linearGradientBrush, rect);
				rect = xda73fcb97c77d998;
				rect.Y = rect.Bottom;
				rect.Height = 1;
				rect.Width++;
				x41347a961b838962.FillRectangle(linearGradientBrush, rect);
				linearGradientBrush.Dispose();
				if (false)
				{
					goto IL_C2;
				}
				goto IL_1CC;
				IL_3B:
				rect = xda73fcb97c77d998;
				rect.Height = 1;
				x41347a961b838962.FillRectangle(linearGradientBrush, rect);
				rect = xda73fcb97c77d998;
				goto IL_52;
				IL_13C:
				Point point = new Point(0, -xcb72be8a310acf66.Top);
				Point point2 = new Point(0, toolBar.Height - xcb72be8a310acf66.Top);
				linearGradientBrush = new LinearGradientBrush(point, point2, this.xaaaf059eaea34d20, this.x8bb53ee85f70380e);
				ColorBlend colorBlend = new ColorBlend(3);
				colorBlend.Colors = new Color[]
				{
					this.xaaaf059eaea34d20,
					this.xb388c8c4edc070f5,
					this.x8bb53ee85f70380e
				};
				if (false)
				{
					goto IL_1CC;
				}
				colorBlend.Positions = new float[]
				{
					0f,
					0.5f,
					1f
				};
				linearGradientBrush.InterpolationColors = colorBlend;
				goto IL_3B;
				IL_C2:
				if (((ToolBarContainer)toolBar.Parent).Manager != null)
				{
					SandBarManager manager = ((ToolBarContainer)toolBar.Parent).Manager;
					Rectangle screenBounds = manager.GetScreenBounds();
					point = xcb72be8a310acf66.PointToClient(new Point(screenBounds.X, screenBounds.Y));
					point2 = xcb72be8a310acf66.PointToClient(new Point(screenBounds.Right, screenBounds.Y));
					linearGradientBrush = new LinearGradientBrush(point, point2, this.BackgroundGradientColor1, this.BackgroundGradientColor2);
					goto IL_3B;
				}
				goto IL_13C;
			}
		}

		// Token: 0x06000457 RID: 1111 RVA: 0x000176E4 File Offset: 0x000166E4
		public override void DrawContainerBarTitleBarBackground(Graphics graphics, Rectangle bounds, bool active)
		{
			if (bounds.Width > 0 && bounds.Height > 0)
			{
				if (active)
				{
					using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(bounds, this.x546109961b6ba7ce, this.x1a50e46d85acd88d, LinearGradientMode.Vertical))
					{
						graphics.FillRectangle(linearGradientBrush, bounds);
						return;
					}
				}
				this.x24c579f9d6cb25b1(graphics, bounds, LinearGradientMode.Vertical);
			}
		}

		// Token: 0x06000458 RID: 1112 RVA: 0x00017758 File Offset: 0x00016758
		public override void DrawContainerBarClientBackground(Graphics graphics, Rectangle bounds)
		{
			if (bounds.Width <= 0 || bounds.Height <= 0)
			{
				return;
			}
			using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(bounds, this.x89f2076276dd61f9, this.x1b9c0c9f53901c0e, LinearGradientMode.Vertical))
			{
				graphics.FillRectangle(linearGradientBrush, bounds);
			}
		}

		// Token: 0x06000459 RID: 1113 RVA: 0x000177C0 File Offset: 0x000167C0
		public override void DrawContainerBarBackground(ContainerBar containerBar, Graphics graphics, Rectangle bounds, Rectangle clientBounds)
		{
			using (Brush brush = new SolidBrush(this.xaab0a0f66214f237))
			{
				graphics.FillRectangle(brush, bounds);
			}
			bounds.Inflate(-2, -2);
			using (Pen pen = new Pen(this.x963e6753ab680aa3))
			{
				graphics.DrawLine(pen, bounds.X + 1, bounds.Y, bounds.Right - 2, bounds.Y);
				graphics.DrawLine(pen, bounds.X, bounds.Y + 1, bounds.X, bounds.Bottom - 2);
				graphics.DrawLine(pen, bounds.Right - 1, bounds.Y + 1, bounds.Right - 1, bounds.Bottom - 2);
				graphics.DrawLine(pen, bounds.X + 1, bounds.Bottom - 1, bounds.Right - 2, bounds.Bottom - 1);
			}
			bounds.Inflate(-1, -1);
			using (SolidBrush solidBrush = new SolidBrush(this.x89f2076276dd61f9))
			{
				graphics.FillRectangle(solidBrush, bounds);
			}
		}

		// Token: 0x0600045A RID: 1114 RVA: 0x0001792C File Offset: 0x0001692C
		public override void LayoutContainerBar(Rectangle bounds, Size toolbarSize, out Rectangle titlebarBounds, out Rectangle toolbarBounds, out Rectangle clientBounds, out Rectangle gripperBounds)
		{
			base.xaa6185ac058231c2(bounds, toolbarSize, 25, 2, out titlebarBounds, out toolbarBounds, out clientBounds, out gripperBounds);
			gripperBounds = titlebarBounds;
			gripperBounds.X++;
			gripperBounds.Inflate(0, -3);
			gripperBounds.Width = 6;
		}

		// Token: 0x0600045B RID: 1115 RVA: 0x0001797C File Offset: 0x0001697C
		public override void DrawContainerBarToolBarBackground(Graphics graphics, Rectangle bounds)
		{
			using (SolidBrush solidBrush = new SolidBrush(this.xf1bce6e83ae00185))
			{
				Rectangle rect;
				using (GraphicsPath graphicsPath = new GraphicsPath())
				{
					rect = bounds;
					rect.Inflate(-5, 0);
					graphicsPath.AddRectangle(rect);
					rect = bounds;
					rect.Y += 5;
					rect.Height -= 5;
					rect.Width = 5;
					graphicsPath.AddRectangle(rect);
					rect = bounds;
					rect.X = rect.Right - 5;
					rect.Width = 5;
					rect.Height -= 5;
					graphicsPath.AddRectangle(rect);
					graphics.FillPath(solidBrush, graphicsPath);
				}
				rect = bounds;
				rect.Width = 5;
				rect.Height = 5;
				using (SolidBrush solidBrush2 = new SolidBrush(this.x8bb53ee85f70380e))
				{
					graphics.FillRectangle(solidBrush2, rect);
				}
				SmoothingMode smoothingMode = graphics.SmoothingMode;
				graphics.SmoothingMode = SmoothingMode.AntiAlias;
				rect = bounds;
				rect.Width = 10;
				rect.Height = 10;
				graphics.FillEllipse(solidBrush, rect);
				rect = new Rectangle(bounds.Right - 10 - 1, bounds.Bottom - 10 - 1, 10, 10);
				graphics.FillEllipse(solidBrush, rect);
				graphics.SmoothingMode = smoothingMode;
			}
		}

		// Token: 0x0600045C RID: 1116 RVA: 0x00017B08 File Offset: 0x00016B08
		protected internal override void DrawStatusBarItem(StatusBarItem item, Graphics graphics, Font font, bool vertical, DrawItemState state)
		{
			base.DrawStatusBarItem(item, graphics, font, vertical, state);
			if (item.ShowBorder)
			{
				Color color = Office2002Renderer.InterpolateColors(SystemColors.Control, SystemColors.ControlDark, 0.4f);
				Rectangle buttonInnerBounds = item.ButtonInnerBounds;
				buttonInnerBounds.Width--;
				buttonInnerBounds.Height--;
				using (Pen pen = new Pen(color))
				{
					graphics.DrawRectangle(pen, buttonInnerBounds);
				}
			}
		}

		// Token: 0x0600045D RID: 1117 RVA: 0x00017B9C File Offset: 0x00016B9C
		public override void DrawStatusBarGripper(StatusBar statusBar, Graphics graphics, Rectangle bounds, bool vertical)
		{
			int num = Math.Min(bounds.Width, bounds.Height) / 4;
			for (int i = 1; i <= num; i++)
			{
				for (int j = 1; j <= num - i + 1; j++)
				{
					int num2 = bounds.Right - 1 - i * 4;
					int num3 = bounds.Bottom - j * 4;
					graphics.FillRectangle(SystemBrushes.ControlLightLight, num2 + 2, num3 + 1, 2, 2);
					graphics.FillRectangle(SystemBrushes.ControlDark, num2 + 1, num3, 2, 2);
				}
			}
		}

		// Token: 0x0600045E RID: 1118 RVA: 0x00017C1C File Offset: 0x00016C1C
		public override string ToString()
		{
			return "Office 2003";
		}

		// Token: 0x040001D3 RID: 467
		private Color xf0506556289a2233;

		// Token: 0x040001D4 RID: 468
		private Color xb388c8c4edc070f5;

		// Token: 0x040001D5 RID: 469
		internal Color x0ea41556e91b8cce;

		// Token: 0x040001D6 RID: 470
		internal Color xaab0a0f66214f237;

		// Token: 0x040001D7 RID: 471
		internal Color xaaaf059eaea34d20;

		// Token: 0x040001D8 RID: 472
		internal Color x8bb53ee85f70380e;

		// Token: 0x040001D9 RID: 473
		internal Color x5f8540e2e750d7a9;

		// Token: 0x040001DA RID: 474
		internal Color xa94aca0885c7a27e;

		// Token: 0x040001DB RID: 475
		internal Color x70d4b2922d9dda6a;

		// Token: 0x040001DC RID: 476
		private Color x20c63f79cff12f42;

		// Token: 0x040001DD RID: 477
		internal Color _x5bdc84993d5749e9;

		// Token: 0x040001DE RID: 478
		internal Color x228685f29c2ed324;

		// Token: 0x040001DF RID: 479
		internal Color x2b5af2e4edc60a47;

		// Token: 0x040001E0 RID: 480
		internal Color x59bf7e25a95a2780;

		// Token: 0x040001E1 RID: 481
		internal Color xf3f219013bfbc916;

		// Token: 0x040001E2 RID: 482
		internal Color x546109961b6ba7ce;

		// Token: 0x040001E3 RID: 483
		internal Color x1a50e46d85acd88d;

		// Token: 0x040001E4 RID: 484
		internal Color x154e298f2834a9ad;

		// Token: 0x040001E5 RID: 485
		internal Color _x273909d58eb80850;

		// Token: 0x040001E6 RID: 486
		internal Color _xa1359fb73f86c7a4;

		// Token: 0x040001E7 RID: 487
		internal Color x342ecbecb7467fe7;

		// Token: 0x040001E8 RID: 488
		internal Color xca2b1cd1d862168f;

		// Token: 0x040001E9 RID: 489
		internal Color x7f9d9df7414c77ae;

		// Token: 0x040001EA RID: 490
		internal Color x963e6753ab680aa3;

		// Token: 0x040001EB RID: 491
		internal Color x89f2076276dd61f9;

		// Token: 0x040001EC RID: 492
		internal Color x1b9c0c9f53901c0e;

		// Token: 0x040001ED RID: 493
		internal Color xf1bce6e83ae00185;

		// Token: 0x040001EE RID: 494
		private Office2003Renderer.Office2003ColorScheme _x62a65b2c0f145432;

		// Token: 0x040001EF RID: 495
		internal ComboBox xcb72be8a310acf66;

		// Token: 0x02000061 RID: 97
		public enum Office2003ColorScheme
		{
			// Token: 0x04000216 RID: 534
			Automatic,
			// Token: 0x04000217 RID: 535
			Standard,
			// Token: 0x04000218 RID: 536
			LunaBlue,
			// Token: 0x04000219 RID: 537
			LunaOlive,
			// Token: 0x0400021A RID: 538
			LunaSilver
		}
	}
}
