using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using TD.SandDock.Design;
using TD.SandDock.Rendering;

namespace TD.SandDock
{
	// Token: 0x0200000D RID: 13
	[DefaultEvent("Closing")]
	[ToolboxItem(false)]
	[Designer(typeof(DockControlDesigner))]
	public abstract class DockControl : ContainerControl
	{
		// Token: 0x1400000C RID: 12
		// (add) Token: 0x060000FC RID: 252 RVA: 0x0000BD2C File Offset: 0x0000AD2C
		// (remove) Token: 0x060000FD RID: 253 RVA: 0x0000BD48 File Offset: 0x0000AD48
		public event DockControlClosingEventHandler Closing
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.xb451d7f50d849473 = (DockControlClosingEventHandler)Delegate.Combine(this.xb451d7f50d849473, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.xb451d7f50d849473 = (DockControlClosingEventHandler)Delegate.Remove(this.xb451d7f50d849473, value);
			}
		}

		// Token: 0x1400000D RID: 13
		// (add) Token: 0x060000FE RID: 254 RVA: 0x0000BD64 File Offset: 0x0000AD64
		// (remove) Token: 0x060000FF RID: 255 RVA: 0x0000BD80 File Offset: 0x0000AD80
		public event EventHandler Closed
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.x289bf94a509dd84c = (EventHandler)Delegate.Combine(this.x289bf94a509dd84c, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.x289bf94a509dd84c = (EventHandler)Delegate.Remove(this.x289bf94a509dd84c, value);
			}
		}

		// Token: 0x1400000E RID: 14
		// (add) Token: 0x06000100 RID: 256 RVA: 0x0000BD9C File Offset: 0x0000AD9C
		// (remove) Token: 0x06000101 RID: 257 RVA: 0x0000BDB8 File Offset: 0x0000ADB8
		public event EventHandler Load
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.x5d95f5f98c940295 = (EventHandler)Delegate.Combine(this.x5d95f5f98c940295, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.x5d95f5f98c940295 = (EventHandler)Delegate.Remove(this.x5d95f5f98c940295, value);
			}
		}

		// Token: 0x1400000F RID: 15
		// (add) Token: 0x06000102 RID: 258 RVA: 0x0000BDD4 File Offset: 0x0000ADD4
		// (remove) Token: 0x06000103 RID: 259 RVA: 0x0000BDF0 File Offset: 0x0000ADF0
		public event EventHandler AutoHidePopupOpened
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.x5b29af28d5fc1a4e = (EventHandler)Delegate.Combine(this.x5b29af28d5fc1a4e, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.x5b29af28d5fc1a4e = (EventHandler)Delegate.Remove(this.x5b29af28d5fc1a4e, value);
			}
		}

		// Token: 0x14000010 RID: 16
		// (add) Token: 0x06000104 RID: 260 RVA: 0x0000BE0C File Offset: 0x0000AE0C
		// (remove) Token: 0x06000105 RID: 261 RVA: 0x0000BE28 File Offset: 0x0000AE28
		public event EventHandler AutoHidePopupClosed
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.x7e416c13135971ea = (EventHandler)Delegate.Combine(this.x7e416c13135971ea, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.x7e416c13135971ea = (EventHandler)Delegate.Remove(this.x7e416c13135971ea, value);
			}
		}

		// Token: 0x14000011 RID: 17
		// (add) Token: 0x06000106 RID: 262 RVA: 0x0000BE44 File Offset: 0x0000AE44
		// (remove) Token: 0x06000107 RID: 263 RVA: 0x0000BE60 File Offset: 0x0000AE60
		public event EventHandler DockSituationChanged
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.x8e01005e38b88f59 = (EventHandler)Delegate.Combine(this.x8e01005e38b88f59, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.x8e01005e38b88f59 = (EventHandler)Delegate.Remove(this.x8e01005e38b88f59, value);
			}
		}

		// Token: 0x06000108 RID: 264 RVA: 0x0000BE7C File Offset: 0x0000AE7C
		protected DockControl()
		{
			if (3 != 0)
			{
				goto IL_139;
			}
			IL_70:
			base.SetStyle(ControlStyles.Selectable, false);
			if (15 != 0)
			{
				this.BackColor = SystemColors.Control;
				this.xca874006c41dfe29 = this.DefaultSize;
				return;
			}
			goto IL_F1;
			IL_CE:
			this.xfffbdea061bfa120 = new WindowMetaData();
			this.xd447c58f1b8b8e4b = this.CreateDockingRules();
			if (this.xd447c58f1b8b8e4b == null)
			{
				throw new InvalidOperationException();
			}
			if (2 != 0)
			{
				base.SetStyle(ControlStyles.ResizeRedraw, true);
				base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
				goto IL_70;
			}
			goto IL_114;
			IL_F1:
			goto IL_FD;
			IL_F3:
			if (4 == 0)
			{
				goto IL_107;
			}
			IL_FA:
			if (!false && !false)
			{
				goto IL_CE;
			}
			IL_FD:
			if (false)
			{
				goto IL_F3;
			}
			if (!false)
			{
				goto IL_CE;
			}
			goto IL_FA;
			IL_107:
			if (2 != 0)
			{
				goto IL_F1;
			}
			goto IL_139;
			IL_114:
			DockControl.x28afaed1891a17a1 = Image.FromStream(typeof(DockControl).Assembly.GetManifestResourceStream("TD.SandDock.sanddock.png"));
			goto IL_107;
			IL_139:
			if (DockControl.x28afaed1891a17a1 != null)
			{
				goto IL_F3;
			}
			goto IL_114;
		}

		// Token: 0x06000109 RID: 265 RVA: 0x0000BFD8 File Offset: 0x0000AFD8
		protected DockControl(SandDockManager manager, Control control, string text) : this()
		{
			if (manager != null)
			{
				if (true)
				{
					if (control == null)
					{
						throw new ArgumentNullException("control");
					}
					if (text == null)
					{
						goto IL_E5;
					}
					IL_C5:
					this.Manager = manager;
					if (false)
					{
						if (!false)
						{
							goto IL_DA;
						}
					}
					else
					{
						if (control is Form)
						{
							goto IL_DA;
						}
						if (false)
						{
							goto IL_75;
						}
						goto IL_28;
					}
					IL_0B:
					IL_20:
					if (text == null)
					{
						goto IL_FA;
					}
					this.Text = text;
					if (-2147483648 != 0)
					{
						return;
					}
					goto IL_0B;
					IL_28:
					if (control != null)
					{
						goto IL_75;
					}
					goto IL_20;
					IL_75:
					base.SuspendLayout();
					if (false)
					{
						goto IL_C5;
					}
					if (false)
					{
						goto IL_20;
					}
					base.Controls.Add(control);
					control.Dock = DockStyle.Fill;
					if (!false)
					{
						if (4 != 0)
						{
							control.BringToFront();
							if (8 == 0)
							{
								goto IL_86;
							}
						}
						if (!false)
						{
							base.ResumeLayout();
							control.Visible = true;
							if (255 != 0)
							{
								if (!false)
								{
									goto IL_F4;
								}
							}
						}
						goto IL_28;
					}
					IL_86:
					Form form;
					form.TopLevel = false;
					form.FormBorderStyle = FormBorderStyle.None;
					if (!false)
					{
						goto IL_28;
					}
					goto IL_E5;
					IL_DA:
					form = (Form)control;
					if (!false)
					{
						goto IL_86;
					}
					IL_F4:
					if (!false)
					{
						goto IL_0B;
					}
					IL_FA:
					return;
					IL_E5:
					text = string.Empty;
					goto IL_C5;
				}
				return;
			}
			throw new ArgumentNullException("manager");
		}

		// Token: 0x0600010A RID: 266
		protected abstract DockingRules CreateDockingRules();

		// Token: 0x0600010B RID: 267 RVA: 0x0000C114 File Offset: 0x0000B114
		internal void xbdd4aaac1291a8c7(bool x364c1e3b189d47fe)
		{
			base.SetVisibleCore(x364c1e3b189d47fe);
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x0600010C RID: 268 RVA: 0x0000C120 File Offset: 0x0000B120
		[Browsable(false)]
		protected virtual bool AllowKeyboardNavigation
		{
			get
			{
				return this.Manager == null || this.Manager.AllowKeyboardNavigation;
			}
		}

		// Token: 0x0600010D RID: 269 RVA: 0x0000C138 File Offset: 0x0000B138
		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if (this.xb6a159a84cb992d6 != null && this.AllowKeyboardNavigation)
			{
				int num;
				int num2;
				bool flag;
				if (keyData != (Keys.LButton | Keys.Space | Keys.Control))
				{
					if (keyData == (Keys.RButton | Keys.Space | Keys.Control))
					{
						goto IL_19A;
					}
					if (keyData == (Keys.LButton | Keys.MButton | Keys.Back | Keys.ShiftKey | Keys.Space | Keys.F17 | Keys.Alt))
					{
						if (false)
						{
							goto IL_140;
						}
						goto IL_A2;
					}
				}
				else
				{
					num = this.xb6a159a84cb992d6.Controls.IndexOf(this);
					num--;
					if ((uint)num + (uint)num >= 0U)
					{
						if (num >= 0)
						{
							goto IL_276;
						}
						goto IL_25D;
					}
					else
					{
						if (false)
						{
							goto IL_A2;
						}
						flag = ((uint)num2 > uint.MaxValue);
						if (flag)
						{
							goto IL_CC;
						}
					}
				}
				IL_30:
				if (keyData != Keys.Escape)
				{
					goto IL_2FC;
				}
				goto IL_CC;
				IL_48:
				DockControl dockControl;
				dockControl.Activate();
				return true;
				IL_50:
				if (dockControl != null)
				{
					goto IL_48;
				}
				return true;
				IL_A2:
				if (!this.xb6a159a84cb992d6.IsInContainer)
				{
					goto IL_30;
				}
				this.xb6a159a84cb992d6.DockContainer.x8ba6fce4f4601549(new ShowControlContextMenuEventArgs(this, new Point(0, 0), ContextMenuContext.Keyboard));
				return true;
				IL_CC:
				if (this.Manager == null)
				{
					goto IL_2FC;
				}
				if (2 == 0)
				{
					goto IL_1C9;
				}
				if (this.DockSituation == DockSituation.Document)
				{
					if ((uint)num + (uint)num <= 4294967295U)
					{
						goto IL_2FC;
					}
				}
				else
				{
					if (this.Manager.OwnerForm != null)
					{
						this.Manager.OwnerForm.Activate();
						if (!true)
						{
							goto IL_A2;
						}
					}
					dockControl = this.Manager.FindMostRecentlyUsedWindow(DockSituation.Document);
					flag = ((uint)num2 < 0U);
					if (flag)
					{
						goto IL_48;
					}
					goto IL_50;
				}
				IL_140:
				if (num2 >= this.xb6a159a84cb992d6.Controls.Count)
				{
					num2 = 0;
				}
				this.xb6a159a84cb992d6.SelectedControl = this.xb6a159a84cb992d6.Controls[num2];
				if (this.xb6a159a84cb992d6.SelectedControl == this.xb6a159a84cb992d6.Controls[num2])
				{
					this.xb6a159a84cb992d6.Controls[num2].Activate();
				}
				return true;
				IL_19A:
				num2 = this.xb6a159a84cb992d6.Controls.IndexOf(this);
				num2++;
				if ((uint)num <= 4294967295U)
				{
					goto IL_22B;
				}
				if (!false)
				{
					goto IL_25D;
				}
				goto IL_50;
				IL_1C9:
				if (this.xb6a159a84cb992d6.SelectedControl == this.xb6a159a84cb992d6.Controls[num])
				{
					goto IL_1F9;
				}
				return true;
				IL_1F9:
				this.xb6a159a84cb992d6.Controls[num].Activate();
				flag = ((uint)num2 > uint.MaxValue);
				if (!flag)
				{
					return true;
				}
				if (true)
				{
					goto IL_19A;
				}
				IL_22B:
				flag = (((uint)num2 | 4294967294U) == 0U);
				if (flag)
				{
					goto IL_A2;
				}
				goto IL_140;
				IL_25D:
				num = this.xb6a159a84cb992d6.Controls.Count - 1;
				IL_276:
				this.xb6a159a84cb992d6.SelectedControl = this.xb6a159a84cb992d6.Controls[num];
				if (false)
				{
					goto IL_1F9;
				}
				goto IL_1C9;
			}
			IL_2FC:
			return base.ProcessCmdKey(ref msg, keyData);
		}

		// Token: 0x0600010E RID: 270 RVA: 0x0000C44C File Offset: 0x0000B44C
		internal void x7735d9a753c63a0a()
		{
			if (this.LayoutSystem != null)
			{
				this.LayoutSystem.x3e0280cae730d1f2();
			}
		}

		// Token: 0x0600010F RID: 271 RVA: 0x0000C464 File Offset: 0x0000B464
		internal void x81444a37d39a0e4a()
		{
			base.SetStyle(ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x06000110 RID: 272 RVA: 0x0000C474 File Offset: 0x0000B474
		private void x63491667e252563e()
		{
			if (!this.x4e7c2c44587adeda)
			{
				if (this.Manager == null)
				{
					goto IL_3F;
				}
				if (this.Manager.DocumentContainer == null)
				{
					goto IL_3F;
				}
				if (!this.Manager.DocumentContainer.x1ec2ea49664e1074)
				{
					goto IL_3F;
				}
				if (2147483647 == 0)
				{
					return;
				}
				IL_28:
				if (this.Manager == null)
				{
					return;
				}
				this.Manager.OnDockControlActivated(new DockControlEventArgs(this));
				if (!false)
				{
					return;
				}
				IL_3F:
				this.MetaData.x15481da58c59597a(DateTime.Now);
				goto IL_28;
			}
		}

		// Token: 0x06000111 RID: 273 RVA: 0x0000C504 File Offset: 0x0000B504
		protected override void OnEnter(EventArgs e)
		{
			base.OnEnter(e);
			if (!false)
			{
				while (this.LayoutSystem == null)
				{
					if (255 != 0)
					{
						goto IL_27;
					}
				}
			}
			this.LayoutSystem.x317ed3bc8decf394 = true;
			IL_27:
			this.x63491667e252563e();
		}

		// Token: 0x06000112 RID: 274 RVA: 0x0000C534 File Offset: 0x0000B534
		protected override void OnLeave(EventArgs e)
		{
			base.OnLeave(e);
			if (this.LayoutSystem != null)
			{
				this.LayoutSystem.x317ed3bc8decf394 = false;
			}
		}

		// Token: 0x06000113 RID: 275 RVA: 0x0000C554 File Offset: 0x0000B554
		public void SetPositionMetaData(DockSituation dockSituation)
		{
			if (this.DockSituation != DockSituation.None)
			{
				if (3 != 0)
				{
					throw new InvalidOperationException("This operation is only valid when the window is not currently open.");
				}
			}
			else
			{
				if (dockSituation == DockSituation.None)
				{
					throw new ArgumentException("dockSituation");
				}
				this.xfffbdea061bfa120.xb0e0bc77d88737a8(dockSituation);
				this.xfffbdea061bfa120.x0ba17c4cff658fcf(dockSituation);
			}
		}

		// Token: 0x06000114 RID: 276 RVA: 0x0000C5A4 File Offset: 0x0000B5A4
		public void SetPositionMetaData(DockSituation dockSituation, ContainerDockLocation dockLocation)
		{
			if (this.DockSituation != DockSituation.None)
			{
				throw new InvalidOperationException("This operation is only valid when the window is not currently open.");
			}
			if (dockSituation != DockSituation.None)
			{
				if (-2147483648 == 0)
				{
					if (!false)
					{
						goto IL_51;
					}
					if (4 == 0)
					{
						return;
					}
				}
				if (dockLocation != ContainerDockLocation.Center)
				{
					this.xfffbdea061bfa120.xb0e0bc77d88737a8(dockSituation);
					if (dockSituation != DockSituation.Document)
					{
						if (dockSituation != DockSituation.Docked)
						{
							goto IL_1F;
						}
					}
					this.xfffbdea061bfa120.x0ba17c4cff658fcf(dockSituation);
					IL_1F:
					this.xfffbdea061bfa120.xfca44c52f41f0e26(dockLocation);
					return;
				}
				IL_51:
				throw new ArgumentException("dockLocation");
			}
			throw new ArgumentException("dockSituation");
		}

		// Token: 0x06000115 RID: 277 RVA: 0x0000C640 File Offset: 0x0000B640
		internal static void xe1da469e4d960f02(Control x43bec302f92080b9, Graphics x41347a961b838962, TD.SandDock.Rendering.BorderStyle xacfbd7a08ba56c78)
		{
			if (xacfbd7a08ba56c78 == TD.SandDock.Rendering.BorderStyle.None)
			{
				return;
			}
			Rectangle rectangle;
			Border3DStyle style;
			for (;;)
			{
				rectangle = new Rectangle(0, 0, x43bec302f92080b9.Width, x43bec302f92080b9.Height);
				if (3 != 0 && xacfbd7a08ba56c78 != TD.SandDock.Rendering.BorderStyle.Flat)
				{
					switch (xacfbd7a08ba56c78)
					{
					case TD.SandDock.Rendering.BorderStyle.Flat:
						goto IL_2B;
					case TD.SandDock.Rendering.BorderStyle.RaisedThick:
						style = Border3DStyle.Raised;
						if (false)
						{
							goto IL_6D;
						}
						goto IL_B5;
					case TD.SandDock.Rendering.BorderStyle.RaisedThin:
						goto IL_1B;
					case TD.SandDock.Rendering.BorderStyle.SunkenThick:
						goto IL_20;
					}
					break;
				}
				Color backColor = x43bec302f92080b9.BackColor;
				Color controlDark = SystemColors.ControlDark;
				if (false)
				{
					return;
				}
				goto IL_EB;
				IL_8B:
				if (!false)
				{
				}
				if (!false)
				{
					using (Pen pen = new Pen(controlDark))
					{
						x41347a961b838962.DrawRectangle(pen, rectangle);
						return;
					}
					goto IL_B5;
				}
				continue;
				IL_6D:
				rectangle.Width--;
				rectangle.Height--;
				goto IL_8B;
				IL_EB:
				DockControl dockControl = x43bec302f92080b9 as DockControl;
				if (dockControl == null)
				{
					goto IL_6D;
				}
				if (dockControl.Manager == null)
				{
					goto IL_6D;
				}
				if (!false)
				{
					dockControl.Manager.Renderer.ModifyDefaultWindowColors(dockControl, ref backColor, ref controlDark);
					goto IL_6D;
				}
				goto IL_8B;
				IL_B5:
				if (!true)
				{
					goto IL_EB;
				}
				goto IL_F4;
			}
			IL_0B:
			style = Border3DStyle.SunkenOuter;
			IL_0E:
			ControlPaint.DrawBorder3D(x41347a961b838962, rectangle, style);
			return;
			IL_1B:
			style = Border3DStyle.RaisedInner;
			goto IL_0E;
			IL_20:
			style = Border3DStyle.Sunken;
			goto IL_0E;
			IL_2B:
			style = Border3DStyle.Flat;
			goto IL_0E;
			goto IL_0B;
			IL_F4:
			goto IL_0E;
		}

		// Token: 0x06000116 RID: 278 RVA: 0x0000C794 File Offset: 0x0000B794
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			DockControl.xe1da469e4d960f02(this, e.Graphics, this.xacfbd7a08ba56c78);
		}

		// Token: 0x06000117 RID: 279 RVA: 0x0000C7B0 File Offset: 0x0000B7B0
		protected override void OnPaintBackground(PaintEventArgs e)
		{
			Rectangle clientRectangle = base.ClientRectangle;
			Color backColor;
			for (;;)
			{
				IL_E9:
				switch (this.BorderStyle)
				{
				case TD.SandDock.Rendering.BorderStyle.Flat:
				case TD.SandDock.Rendering.BorderStyle.RaisedThin:
				case TD.SandDock.Rendering.BorderStyle.SunkenThin:
					clientRectangle.Inflate(-1, -1);
					if (4 == 0)
					{
						goto IL_2A;
					}
					break;
				case TD.SandDock.Rendering.BorderStyle.RaisedThick:
				case TD.SandDock.Rendering.BorderStyle.SunkenThick:
					clientRectangle.Inflate(-2, -2);
					break;
				}
				backColor = this.BackColor;
				if (3 != 0)
				{
					Color transparent = Color.Transparent;
					if (this.Manager != null)
					{
						this.Manager.Renderer.ModifyDefaultWindowColors(this, ref backColor, ref transparent);
					}
					while (clientRectangle != base.ClientRectangle)
					{
						e.Graphics.SetClip(clientRectangle);
						if (!false)
						{
							if (-2147483648 == 0 || 255 == 0)
							{
								continue;
							}
							if (!false)
							{
								break;
							}
							if (4 == 0)
							{
								goto IL_14;
							}
						}
						if (false)
						{
							goto IL_E9;
						}
						goto IL_F7;
					}
					goto IL_4B;
				}
			}
			IL_0C:
			base.OnPaintBackground(e);
			return;
			IL_14:
			goto IL_1E;
			IL_16:
			if (this.BackgroundImage != null)
			{
				goto IL_0C;
			}
			IL_1E:
			xa811784015ed8842.x91433b5e99eb7cac(e.Graphics, backColor);
			IL_2A:
			if (255 != 0)
			{
				return;
			}
			IL_4B:
			goto IL_16;
			IL_F7:
			goto IL_0C;
		}

		// Token: 0x06000118 RID: 280 RVA: 0x0000C8BC File Offset: 0x0000B8BC
		internal void x56e964269d48cfcc(DockContainer x0467b00af7810f0c)
		{
			if (x0467b00af7810f0c != null)
			{
				if (!false)
				{
					while (x0467b00af7810f0c.Manager != null)
					{
						if (!false)
						{
							goto IL_06;
						}
					}
					goto IL_14;
				}
				IL_06:
				if (x0467b00af7810f0c.Manager != this.Manager)
				{
					this.Manager = x0467b00af7810f0c.Manager;
				}
			}
			IL_14:
			this.x44fd51d909a57a2a();
		}

		// Token: 0x06000119 RID: 281 RVA: 0x0000C8FC File Offset: 0x0000B8FC
		internal void x44fd51d909a57a2a()
		{
			DockSituation dockSituation;
			if (this.LayoutSystem != null && this.LayoutSystem.DockContainer != null)
			{
				dockSituation = LayoutUtilities.x8d287cc6f0a2f529(this.LayoutSystem.DockContainer);
				if (2147483647 != 0)
				{
					goto IL_188;
				}
				goto IL_15;
			}
			else
			{
				dockSituation = DockSituation.None;
				if (255 == 0)
				{
					goto IL_164;
				}
				if (2147483647 != 0)
				{
					goto IL_188;
				}
				goto IL_12A;
			}
			IL_12:
			x129cb2a2bdfd0ab2 x129cb2a2bdfd0ab;
			if (x129cb2a2bdfd0ab != null)
			{
				this.x301b78956138d163(x129cb2a2bdfd0ab);
			}
			IL_15:
			this.x409072a6bb877e49(dockSituation);
			return;
			IL_5E:
			if (this.Manager == null)
			{
				goto IL_12;
			}
			IL_BA:
			DockContainer[] dockContainers = this.Manager.GetDockContainers(this.LayoutSystem.DockContainer.Dock);
			this.xfffbdea061bfa120.xe62a3d24e0fde928.xd25c313925dc7d4e = dockContainers.Length;
			this.xfffbdea061bfa120.xe62a3d24e0fde928.x71a5d248534c8557 = Array.IndexOf<DockContainer>(dockContainers, this.LayoutSystem.DockContainer);
			IL_119:
			goto IL_12;
			IL_12A:
			this.xfffbdea061bfa120.x0ba17c4cff658fcf(DockSituation.Docked);
			if (-2147483648 == 0)
			{
				goto IL_119;
			}
			this.xfffbdea061bfa120.xfca44c52f41f0e26(LayoutUtilities.x3650f3b579b2b4d2(this.LayoutSystem.DockContainer.Dock));
			this.xfffbdea061bfa120.x3ef4455ea4965093(this.LayoutSystem.DockContainer.ContentSize);
			if (-2 == 0)
			{
				goto IL_BA;
			}
			goto IL_5E;
			IL_164:
			DockSituation dockSituation2;
			switch (dockSituation2)
			{
			case DockSituation.Docked:
				x129cb2a2bdfd0ab = this.xfffbdea061bfa120.xe62a3d24e0fde928;
				goto IL_12A;
			case DockSituation.Document:
				goto IL_85;
			case DockSituation.Floating:
				x129cb2a2bdfd0ab = this.xfffbdea061bfa120.xba74b873ae2f845a;
				this.xfffbdea061bfa120.x87f4a9b62a380563(((x410f3612b9a8f9de)this.LayoutSystem.DockContainer).x0217cda8370c1f17);
				if (-1 == 0)
				{
					goto IL_5E;
				}
				goto IL_12;
			default:
				if (15 == 0)
				{
					goto IL_85;
				}
				if (4 != 0)
				{
					goto IL_119;
				}
				break;
			}
			IL_6A:
			this.xfffbdea061bfa120.x0ba17c4cff658fcf(DockSituation.Document);
			if (!false)
			{
				goto IL_12;
			}
			goto IL_188;
			IL_85:
			x129cb2a2bdfd0ab = this.xfffbdea061bfa120.x25e1dbd0e63329bf;
			goto IL_6A;
			IL_188:
			if (dockSituation != DockSituation.None)
			{
				this.xfffbdea061bfa120.xb0e0bc77d88737a8(dockSituation);
			}
			x129cb2a2bdfd0ab = null;
			dockSituation2 = dockSituation;
			goto IL_164;
		}

		// Token: 0x0600011A RID: 282 RVA: 0x0000CAF0 File Offset: 0x0000BAF0
		private void x301b78956138d163(x129cb2a2bdfd0ab2 xfffbdea061bfa120)
		{
			if (this.LayoutSystem != null)
			{
				xfffbdea061bfa120.x703937d70a13725c = this.LayoutSystem.x0217cda8370c1f17;
				xfffbdea061bfa120.x8c8f170696764fac = this.LayoutSystem.Controls.IndexOf(this);
				xfffbdea061bfa120.x3a4e0c379519d4a2 = this.LayoutSystem.WorkingSize;
				xfffbdea061bfa120.x61743036ad30763d = LayoutUtilities.x27f6597db2aeb7d7(this.LayoutSystem);
			}
		}

		// Token: 0x0600011B RID: 283 RVA: 0x0000CB50 File Offset: 0x0000BB50
		private void x550f9212086279db()
		{
			if (base.IsDisposed)
			{
				throw new ObjectDisposedException(base.GetType().Name);
			}
		}

		// Token: 0x0600011C RID: 284 RVA: 0x0000CB6C File Offset: 0x0000BB6C
		internal void xb37e72cd3ce9b2b4()
		{
			base.CreateControl();
		}

		// Token: 0x0600011D RID: 285 RVA: 0x0000CB74 File Offset: 0x0000BB74
		private void x298b2fdefeb76ab8()
		{
			this.x550f9212086279db();
			if (this.x91f347c6e97f1846 != null)
			{
				return;
			}
			throw new InvalidOperationException("No SandDockManager is associated with this DockControl. To create an association, set the Manager property.");
		}

		// Token: 0x0600011E RID: 286 RVA: 0x0000CB94 File Offset: 0x0000BB94
		private void xc64dfbbdd2fa7bf6()
		{
			this.x298b2fdefeb76ab8();
			if (this.Manager.DockSystemContainer != null)
			{
				return;
			}
			throw new InvalidOperationException("The SandDockManager associated with this DockControl does not have its DockSystemContainer property set.");
		}

		// Token: 0x0600011F RID: 287 RVA: 0x0000CBB8 File Offset: 0x0000BBB8
		public void OpenFloating()
		{
			this.OpenFloating(WindowOpenMethod.OnScreenActivate);
		}

		// Token: 0x06000120 RID: 288 RVA: 0x0000CBC4 File Offset: 0x0000BBC4
		public void OpenFloating(Rectangle bounds, WindowOpenMethod openMethod)
		{
			this.x298b2fdefeb76ab8();
			if (-2147483648 != 0)
			{
				this.Remove();
			}
			if (!false)
			{
			}
			this.MetaData.x87f4a9b62a380563(Guid.Empty);
			this.MetaData.xba74b873ae2f845a.x703937d70a13725c = Guid.Empty;
			this.FloatingLocation = bounds.Location;
			this.FloatingSize = bounds.Size;
			this.OpenFloating(openMethod);
		}

		// Token: 0x06000121 RID: 289 RVA: 0x0000CC34 File Offset: 0x0000BC34
		public void OpenFloating(WindowOpenMethod openMethod)
		{
			this.x298b2fdefeb76ab8();
			Rectangle xda73fcb97c77d;
			ControlLayoutSystem controlLayoutSystem;
			x410f3612b9a8f9de x410f3612b9a8f9de;
			x5678bb8d80c0f12e x5678bb8d80c0f12e;
			for (;;)
			{
				IL_279:
				this.xb37e72cd3ce9b2b4();
				if (-1 == 0)
				{
					return;
				}
				while (this.DockSituation != DockSituation.Floating)
				{
					xda73fcb97c77d = this.xc0154d85fceb081c();
					if (3 == 0)
					{
						goto IL_199;
					}
					if (-2147483648 == 0)
					{
						goto IL_279;
					}
					if (true)
					{
						this.Remove();
						controlLayoutSystem = LayoutUtilities.xba5fd484c0e6478b(this.Manager, DockSituation.Floating, this.MetaData.xba74b873ae2f845a);
					}
					if (controlLayoutSystem != null)
					{
						goto Block_9;
					}
					x410f3612b9a8f9de = this.Manager.FindFloatingDockContainer(this.MetaData.LastFloatingWindowGuid);
					if (x410f3612b9a8f9de == null)
					{
						goto IL_199;
					}
					if (false)
					{
						goto Block_4;
					}
					x5678bb8d80c0f12e = LayoutUtilities.x2f8f74d308cc9f3f(x410f3612b9a8f9de, this.MetaData.xba74b873ae2f845a.x61743036ad30763d);
					controlLayoutSystem = x5678bb8d80c0f12e.x07bf3386da210f81.DockContainer.CreateNewLayoutSystem(this, this.MetaData.xba74b873ae2f845a.x3a4e0c379519d4a2);
					if (this.MetaData.xba74b873ae2f845a.x703937d70a13725c == Guid.Empty)
					{
						this.MetaData.xba74b873ae2f845a.x703937d70a13725c = Guid.NewGuid();
					}
					controlLayoutSystem.x0217cda8370c1f17 = this.MetaData.xba74b873ae2f845a.x703937d70a13725c;
					if (2 != 0)
					{
						goto Block_1;
					}
				}
				return;
			}
			Block_1:
			x5678bb8d80c0f12e.x07bf3386da210f81.LayoutSystems.Insert(x5678bb8d80c0f12e.xd1bdf42207dd3638, controlLayoutSystem);
			return;
			Block_4:
			if (-2147483648 != 0)
			{
				goto IL_109;
			}
			IL_D0:
			controlLayoutSystem.x0217cda8370c1f17 = this.MetaData.xba74b873ae2f845a.x703937d70a13725c;
			x410f3612b9a8f9de.LayoutSystem.LayoutSystems.Add(controlLayoutSystem);
			x410f3612b9a8f9de.x159713d3b60fae0c(xda73fcb97c77d, true, openMethod == WindowOpenMethod.OnScreenActivate);
			if (!false)
			{
				return;
			}
			goto IL_120;
			IL_109:
			x410f3612b9a8f9de = new x410f3612b9a8f9de(this.Manager, this.xfffbdea061bfa120.LastFloatingWindowGuid);
			IL_120:
			controlLayoutSystem = x410f3612b9a8f9de.CreateNewLayoutSystem(this, this.xfffbdea061bfa120.xba74b873ae2f845a.x3a4e0c379519d4a2);
			if (!(this.MetaData.xba74b873ae2f845a.x703937d70a13725c == Guid.Empty))
			{
				goto IL_D0;
			}
			IL_13A:
			this.MetaData.xba74b873ae2f845a.x703937d70a13725c = Guid.NewGuid();
			goto IL_D0;
			IL_199:
			if (!(this.xfffbdea061bfa120.LastFloatingWindowGuid == Guid.Empty))
			{
				goto IL_109;
			}
			this.xfffbdea061bfa120.x87f4a9b62a380563(Guid.NewGuid());
			goto IL_109;
			Block_9:
			controlLayoutSystem.Controls.Insert(Math.Min(this.MetaData.xba74b873ae2f845a.x8c8f170696764fac, controlLayoutSystem.Controls.Count), this);
			if (openMethod != WindowOpenMethod.OnScreen)
			{
				this.x6d1b64d6c637a91d(openMethod == WindowOpenMethod.OnScreenActivate);
				if (2147483647 == 0)
				{
					goto IL_199;
				}
				if (15 == 0)
				{
					goto IL_13A;
				}
			}
		}

		// Token: 0x06000122 RID: 290 RVA: 0x0000CED8 File Offset: 0x0000BED8
		internal Rectangle xc0154d85fceb081c()
		{
			this.x298b2fdefeb76ab8();
			if (!false)
			{
				if (true)
				{
					if (this.xc868bd63c888e533.X != -1)
					{
						goto IL_09;
					}
					if (this.xc868bd63c888e533.Y != -1)
					{
						goto IL_42;
					}
				}
				this.xc868bd63c888e533 = this.GetDefaultFloatingLocation();
			}
			IL_09:
			IL_42:
			return new Rectangle(this.xc868bd63c888e533, this.xca874006c41dfe29);
		}

		// Token: 0x06000123 RID: 291 RVA: 0x0000CF38 File Offset: 0x0000BF38
		protected virtual Point GetDefaultFloatingLocation()
		{
			Point point;
			if (!this.x1a9802d2d8708515)
			{
				Screen screen = (this.Manager.DockSystemContainer == null) ? Screen.PrimaryScreen : Screen.FromControl(this.Manager.DockSystemContainer);
				Rectangle workingArea = screen.WorkingArea;
				point = new Point(workingArea.X + workingArea.Width / 2 - this.xca874006c41dfe29.Width / 2, workingArea.Y + workingArea.Height / 2 - this.xca874006c41dfe29.Height / 2);
				if (-1 != 0)
				{
					return point;
				}
			}
			do
			{
				point = this.LayoutSystem.DockContainer.PointToScreen(this.LayoutSystem.Bounds.Location);
				point -= new Size(SystemInformation.CaptionHeight, SystemInformation.CaptionHeight);
			}
			while (false);
			return point;
		}

		// Token: 0x06000124 RID: 292 RVA: 0x0000D01C File Offset: 0x0000C01C
		public Form GetFloatingForm()
		{
			if (this.DockSituation != DockSituation.Floating || base.Parent == null)
			{
				return null;
			}
			return base.Parent.Parent as Form;
		}

		// Token: 0x06000125 RID: 293
		public abstract void Open();

		// Token: 0x06000126 RID: 294 RVA: 0x0000D044 File Offset: 0x0000C044
		public void Open(WindowOpenMethod openMethod)
		{
			this.x298b2fdefeb76ab8();
			if (!false)
			{
				if (this.DockSituation != DockSituation.None)
				{
					goto IL_18;
				}
				switch (this.xfffbdea061bfa120.LastOpenDockSituation)
				{
				case DockSituation.Docked:
					this.OpenDocked(openMethod);
					return;
				case DockSituation.Document:
					this.OpenDocument(openMethod);
					return;
				case DockSituation.Floating:
					this.OpenFloating(openMethod);
					return;
				default:
					goto IL_18;
				}
			}
			IL_08:
			this.x6d1b64d6c637a91d(openMethod == WindowOpenMethod.OnScreenActivate);
			if (false)
			{
				if (!false)
				{
				}
			}
			else if (255 != 0)
			{
				return;
			}
			IL_18:
			if (openMethod != WindowOpenMethod.OnScreen)
			{
				goto IL_08;
			}
		}

		// Token: 0x06000127 RID: 295 RVA: 0x0000D0CC File Offset: 0x0000C0CC
		internal void x6d1b64d6c637a91d(bool x53c0846b47593790)
		{
			if (this.LayoutSystem != null)
			{
				bool flag;
				for (;;)
				{
					if (this.LayoutSystem.SelectedControl != this)
					{
						goto IL_A6;
					}
					IL_19:
					if (this.LayoutSystem.x10ac79a4257c7f52 == null)
					{
						break;
					}
					this.LayoutSystem.x10ac79a4257c7f52.xe6ff614263a59ef9(this, true, x53c0846b47593790);
					flag = (((x53c0846b47593790 ? 1U : 0U) | 2147483648U) == 0U);
					if (!flag)
					{
						if (8 == 0)
						{
							continue;
						}
						goto IL_BF;
					}
					IL_A6:
					this.LayoutSystem.SelectedControl = this;
					if (this.LayoutSystem.SelectedControl == this)
					{
						goto IL_19;
					}
					return;
				}
				if ((x53c0846b47593790 ? 1U : 0U) + (x53c0846b47593790 ? 1U : 0U) < 0U)
				{
					goto IL_0D;
				}
				if (!false)
				{
					goto IL_0D;
				}
				return;
				IL_BF:
				flag = ((x53c0846b47593790 ? 1U : 0U) < 0U);
				if (flag)
				{
					return;
				}
				return;
			}
			IL_0D:
			if (x53c0846b47593790)
			{
				this.Activate();
			}
		}

		// Token: 0x06000128 RID: 296 RVA: 0x0000D1B0 File Offset: 0x0000C1B0
		internal bool xe302f2203dc14a18(ContainerDockLocation xb9c2cfae130d9256)
		{
			switch (xb9c2cfae130d9256)
			{
			case ContainerDockLocation.Left:
				return this.DockingRules.AllowDockLeft;
			case ContainerDockLocation.Right:
				return this.DockingRules.AllowDockRight;
			case ContainerDockLocation.Top:
				return this.DockingRules.AllowDockTop;
			case ContainerDockLocation.Bottom:
				return this.DockingRules.AllowDockBottom;
			}
			return this.DockingRules.AllowTab;
		}

		// Token: 0x06000129 RID: 297 RVA: 0x0000D21C File Offset: 0x0000C21C
		public void Remove()
		{
			LayoutUtilities.xf1cbd48a28ce6e74(this);
		}

		// Token: 0x0600012A RID: 298 RVA: 0x0000D224 File Offset: 0x0000C224
		public void OpenDocked()
		{
			this.OpenDocked(this.xfffbdea061bfa120.LastFixedDockSide);
		}

		// Token: 0x0600012B RID: 299 RVA: 0x0000D238 File Offset: 0x0000C238
		public void OpenDocked(ContainerDockLocation dockLocation)
		{
			if (dockLocation == this.xfffbdea061bfa120.LastFixedDockSide)
			{
				this.OpenDocked(WindowOpenMethod.OnScreenSelect);
				return;
			}
			this.OpenDocked(dockLocation, WindowOpenMethod.OnScreenSelect);
		}

		// Token: 0x0600012C RID: 300 RVA: 0x0000D258 File Offset: 0x0000C258
		public void OpenDocked(ContainerDockLocation dockLocation, WindowOpenMethod openMethod)
		{
			if (dockLocation == ContainerDockLocation.Center)
			{
				if (!false)
				{
					this.OpenDocument(openMethod);
					return;
				}
			}
			else
			{
				this.x298b2fdefeb76ab8();
				if (this.DockSituation == DockSituation.Docked)
				{
					if (this.xfffbdea061bfa120.LastFixedDockSide == dockLocation)
					{
						return;
					}
				}
				this.Remove();
				this.xfffbdea061bfa120.xfca44c52f41f0e26(dockLocation);
				this.xfffbdea061bfa120.xe62a3d24e0fde928.x703937d70a13725c = Guid.Empty;
				if (false)
				{
					return;
				}
				this.xfffbdea061bfa120.xe62a3d24e0fde928.x61743036ad30763d = new int[0];
			}
			this.OpenDocked(openMethod);
		}

		// Token: 0x0600012D RID: 301 RVA: 0x0000D2EC File Offset: 0x0000C2EC
		public void OpenDocument(WindowOpenMethod openMethod)
		{
			this.x298b2fdefeb76ab8();
			ControlLayoutSystem controlLayoutSystem;
			if (255 != 0)
			{
				this.xb37e72cd3ce9b2b4();
				if (this.DockSituation != DockSituation.Document)
				{
					if (2 == 0)
					{
						return;
					}
					if (!false)
					{
						if (!false)
						{
							this.Remove();
							if (false)
							{
								goto IL_AC;
							}
							controlLayoutSystem = LayoutUtilities.xba5fd484c0e6478b(this.Manager, DockSituation.Document, this.xfffbdea061bfa120.x25e1dbd0e63329bf);
							if (controlLayoutSystem == null)
							{
								goto IL_AC;
							}
						}
						controlLayoutSystem.Controls.Insert(Math.Min(this.xfffbdea061bfa120.xe62a3d24e0fde928.x8c8f170696764fac, controlLayoutSystem.Controls.Count), this);
						if (openMethod != WindowOpenMethod.OnScreen)
						{
							this.x6d1b64d6c637a91d(openMethod == WindowOpenMethod.OnScreenActivate);
						}
						return;
					}
				}
				return;
			}
			if (false)
			{
				goto IL_50;
			}
			DockContainer dockContainer;
			for (;;)
			{
				IL_AC:
				dockContainer = this.Manager.FindDockContainer(ContainerDockLocation.Center);
				if (4 == 0)
				{
					goto IL_68;
				}
				if (dockContainer == null)
				{
					dockContainer = this.Manager.CreateNewDockContainer(ContainerDockLocation.Center, ContainerDockEdge.Inside, this.MetaData.DockedContentSize);
					if (!false)
					{
					}
				}
				controlLayoutSystem = LayoutUtilities.FindControlLayoutSystem(dockContainer);
				if (controlLayoutSystem != null)
				{
					break;
				}
				if (2 != 0)
				{
					goto IL_E0;
				}
			}
			if (this.Manager.DocumentOpenPosition != DocumentContainerWindowOpenPosition.First)
			{
				controlLayoutSystem.Controls.Add(this);
				goto IL_45;
			}
			controlLayoutSystem.Controls.Insert(0, this);
			goto IL_45;
			IL_E0:
			if (false)
			{
				return;
			}
			goto IL_50;
			IL_45:
			if (openMethod != WindowOpenMethod.OnScreen)
			{
				if (!false)
				{
					this.x6d1b64d6c637a91d(openMethod == WindowOpenMethod.OnScreenActivate);
					if (-2 == 0)
					{
						goto IL_50;
					}
				}
				return;
			}
			return;
			IL_50:
			controlLayoutSystem = dockContainer.CreateNewLayoutSystem(this, this.MetaData.x25e1dbd0e63329bf.x3a4e0c379519d4a2);
			IL_68:
			dockContainer.LayoutSystem.LayoutSystems.Add(controlLayoutSystem);
			goto IL_45;
		}

		// Token: 0x0600012E RID: 302 RVA: 0x0000D46C File Offset: 0x0000C46C
		public void OpenDocked(WindowOpenMethod openMethod)
		{
			this.x298b2fdefeb76ab8();
			if (!false)
			{
				this.xb37e72cd3ce9b2b4();
				if (this.DockSituation == DockSituation.Docked)
				{
					return;
				}
				if (false)
				{
					return;
				}
			}
			ControlLayoutSystem controlLayoutSystem;
			for (;;)
			{
				this.Remove();
				if (8 == 0)
				{
					goto IL_20;
				}
				if (-2147483648 != 0)
				{
					controlLayoutSystem = LayoutUtilities.xba5fd484c0e6478b(this.Manager, DockSituation.Docked, this.xfffbdea061bfa120.xe62a3d24e0fde928);
					if (controlLayoutSystem == null)
					{
						goto IL_78;
					}
					controlLayoutSystem.Controls.Insert(Math.Min(this.xfffbdea061bfa120.xe62a3d24e0fde928.x8c8f170696764fac, controlLayoutSystem.Controls.Count), this);
				}
				if (-2 == 0)
				{
					break;
				}
				if (-2147483648 == 0)
				{
					goto IL_168;
				}
				if (openMethod != WindowOpenMethod.OnScreen)
				{
					goto IL_D3;
				}
				if (2 != 0)
				{
					goto IL_168;
				}
			}
			IL_11:
			this.x6d1b64d6c637a91d(openMethod == WindowOpenMethod.OnScreenActivate);
			return;
			IL_20:
			if (openMethod == WindowOpenMethod.OnScreen)
			{
				return;
			}
			goto IL_11;
			IL_78:
			x5678bb8d80c0f12e x5678bb8d80c0f12e = LayoutUtilities.x4689c8634e31fc55(this.Manager, this.xfffbdea061bfa120);
			controlLayoutSystem = x5678bb8d80c0f12e.x07bf3386da210f81.DockContainer.CreateNewLayoutSystem(this, this.xfffbdea061bfa120.xe62a3d24e0fde928.x3a4e0c379519d4a2);
			if (this.MetaData.xe62a3d24e0fde928.x703937d70a13725c == Guid.Empty)
			{
				this.MetaData.xe62a3d24e0fde928.x703937d70a13725c = Guid.NewGuid();
			}
			controlLayoutSystem.x0217cda8370c1f17 = this.MetaData.xe62a3d24e0fde928.x703937d70a13725c;
			x5678bb8d80c0f12e.x07bf3386da210f81.LayoutSystems.Insert(x5678bb8d80c0f12e.xd1bdf42207dd3638, controlLayoutSystem);
			goto IL_20;
			IL_D3:
			this.x6d1b64d6c637a91d(openMethod == WindowOpenMethod.OnScreenActivate);
			return;
			IL_168:
			if (4 != 0)
			{
				return;
			}
		}

		// Token: 0x0600012F RID: 303 RVA: 0x0000D608 File Offset: 0x0000C608
		public void Split(DockSide direction)
		{
			if (this.x1a9802d2d8708515)
			{
				goto IL_85;
			}
			if (2 != 0)
			{
				goto IL_77;
			}
			IL_45:
			if (direction == DockSide.None)
			{
				throw new ArgumentException("direction");
			}
			for (;;)
			{
				SizeF workingSize = this.LayoutSystem.WorkingSize;
				ControlLayoutSystem layoutSystem = this.LayoutSystem;
				if (15 == 0)
				{
					break;
				}
				LayoutUtilities.xf1cbd48a28ce6e74(this);
				ControlLayoutSystem layoutSystem2 = layoutSystem.DockContainer.CreateNewLayoutSystem(this, workingSize);
				layoutSystem.SplitForLayoutSystem(layoutSystem2, direction);
				this.Activate();
				if (!false)
				{
					break;
				}
				if (2 == 0)
				{
					goto IL_85;
				}
			}
			if (!false)
			{
				return;
			}
			IL_77:
			throw new InvalidOperationException("A window cannot be split while it is not hosted in a DockContainer.");
			IL_85:
			if (this.LayoutSystem.Controls.Count < 2)
			{
				throw new InvalidOperationException("A minimum of 2 windows need to be present in a tab group before one can be split off. Check LayoutSystem.Controls.Count before calling this method.");
			}
			goto IL_45;
		}

		// Token: 0x06000130 RID: 304 RVA: 0x0000D6BC File Offset: 0x0000C6BC
		public bool Close()
		{
			return this.x8ffe90e7fbccfccd(false);
		}

		// Token: 0x06000131 RID: 305 RVA: 0x0000D6C8 File Offset: 0x0000C6C8
		internal bool x8ffe90e7fbccfccd(bool xc481dbe8dc50af3f)
		{
			DockControlClosingEventArgs dockControlClosingEventArgs = new DockControlClosingEventArgs(this, false);
			if (!false)
			{
				if (this.Manager == null)
				{
					goto IL_66;
				}
				this.Manager.OnDockControlClosing(dockControlClosingEventArgs);
				goto IL_9C;
			}
			IL_15:
			if (this.CloseAction == DockControlCloseAction.Dispose)
			{
				base.Dispose();
				goto IL_23;
			}
			IL_1E:
			return true;
			IL_23:
			if (!false)
			{
				if (!true)
				{
					goto IL_66;
				}
				return true;
			}
			IL_45:
			goto IL_15;
			IL_47:
			if (dockControlClosingEventArgs.Cancel)
			{
				return false;
			}
			LayoutUtilities.xf1cbd48a28ce6e74(this);
			if ((xc481dbe8dc50af3f ? 1U : 0U) >= 0U)
			{
				this.OnClosed(EventArgs.Empty);
				goto IL_45;
			}
			goto IL_1E;
			IL_66:
			bool flag = (xc481dbe8dc50af3f ? 1U : 0U) + (xc481dbe8dc50af3f ? 1U : 0U) < 0U;
			if (!flag)
			{
				goto IL_9C;
			}
			if ((xc481dbe8dc50af3f ? 1U : 0U) > 4294967295U)
			{
				goto IL_23;
			}
			IL_93:
			this.OnClosing(dockControlClosingEventArgs);
			goto IL_47;
			IL_9C:
			if (dockControlClosingEventArgs.Cancel)
			{
				goto IL_47;
			}
			goto IL_93;
		}

		// Token: 0x06000132 RID: 306 RVA: 0x0000D7A0 File Offset: 0x0000C7A0
		protected internal virtual void OnClosing(DockControlClosingEventArgs e)
		{
			if (this.xb451d7f50d849473 != null)
			{
				this.xb451d7f50d849473(this, e);
			}
		}

		// Token: 0x06000133 RID: 307 RVA: 0x0000D7B8 File Offset: 0x0000C7B8
		protected internal virtual void OnClosed(EventArgs e)
		{
			if (this.x289bf94a509dd84c != null)
			{
				this.x289bf94a509dd84c(this, e);
			}
		}

		// Token: 0x06000134 RID: 308 RVA: 0x0000D7D0 File Offset: 0x0000C7D0
		protected virtual void OnLoad(EventArgs e)
		{
			if (this.x5d95f5f98c940295 != null)
			{
				this.x5d95f5f98c940295(this, e);
			}
		}

		// Token: 0x06000135 RID: 309 RVA: 0x0000D7E8 File Offset: 0x0000C7E8
		protected virtual void OnDockSituationChanged(EventArgs e)
		{
			if (this.x8e01005e38b88f59 != null)
			{
				this.x8e01005e38b88f59(this, e);
			}
		}

		// Token: 0x06000136 RID: 310 RVA: 0x0000D800 File Offset: 0x0000C800
		protected internal virtual void OnTabDoubleClick()
		{
			switch (this.DockSituation)
			{
			case DockSituation.Docked:
			case DockSituation.Document:
				if (!this.DockingRules.AllowFloat)
				{
					goto IL_6F;
				}
				this.OpenFloating(WindowOpenMethod.OnScreenActivate);
				if (2147483647 == 0)
				{
					goto IL_71;
				}
				return;
			case DockSituation.Floating:
				if (this.xfffbdea061bfa120.LastFixedDockSituation != DockSituation.Docked)
				{
					goto IL_71;
				}
				break;
			default:
				return;
			}
			IL_3B:
			if (this.xe302f2203dc14a18(this.xfffbdea061bfa120.LastFixedDockSide))
			{
				this.OpenDocked(WindowOpenMethod.OnScreenActivate);
				return;
			}
			IL_4E:
			if (this.xfffbdea061bfa120.LastFixedDockSituation == DockSituation.Document)
			{
				if (false)
				{
					goto IL_3B;
				}
				if (this.xe302f2203dc14a18(ContainerDockLocation.Center))
				{
					if (-2 != 0)
					{
						if (!false)
						{
						}
						this.OpenDocument(WindowOpenMethod.OnScreenActivate);
					}
				}
			}
			IL_6F:
			return;
			IL_71:
			goto IL_4E;
		}

		// Token: 0x06000137 RID: 311 RVA: 0x0000D8B0 File Offset: 0x0000C8B0
		public void Activate()
		{
			if (this.LayoutSystem == null || base.Parent == null)
			{
				return;
			}
			if (this.LayoutSystem.SelectedControl != this)
			{
				this.LayoutSystem.SelectedControl = this;
				if (this.LayoutSystem.SelectedControl != this)
				{
					return;
				}
			}
			if (this.DockSituation == DockSituation.Floating)
			{
				this.x410f3612b9a8f9de.x5b7f6ddd07ded8cd();
			}
			if (this.IsOpen)
			{
				if (!false)
				{
					this.x4e7c2c44587adeda = true;
					try
					{
						IContainerControl containerControl = base.Parent.GetContainerControl();
						containerControl.ActiveControl = base.ActiveControl;
						if (!false)
						{
							while (!base.ContainsFocus)
							{
								if (this.PrimaryControl != null)
								{
									goto IL_80;
								}
								base.SelectNextControl(this, true, true, true, true);
								IL_32:
								if (!base.ContainsFocus)
								{
									if (base.Controls.Count != 1)
									{
										base.Focus();
										if (false)
										{
											goto IL_80;
										}
										if (!false)
										{
											break;
										}
									}
									base.Controls[0].Focus();
									break;
								}
								if (false)
								{
									continue;
								}
								break;
								IL_80:
								this.PrimaryControl.Focus();
								goto IL_32;
							}
						}
					}
					finally
					{
						this.x4e7c2c44587adeda = false;
					}
					this.x63491667e252563e();
				}
				return;
			}
		}

		// Token: 0x06000138 RID: 312 RVA: 0x0000DA04 File Offset: 0x0000CA04
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Use the OpenWith method instead.")]
		public void DockNextTo(DockControl existingWindow)
		{
			this.OpenWith(existingWindow);
		}

		// Token: 0x06000139 RID: 313 RVA: 0x0000DA10 File Offset: 0x0000CA10
		public void OpenWith(DockControl existingWindow)
		{
			if (existingWindow == null)
			{
				if (!false)
				{
					throw new ArgumentNullException();
				}
			}
			else if (existingWindow == this)
			{
				return;
			}
			if (existingWindow.DockSituation != DockSituation.None)
			{
				this.Remove();
				existingWindow.LayoutSystem.Controls.Add(this);
				return;
			}
			throw new InvalidOperationException("The specified window is not open.");
		}

		// Token: 0x0600013A RID: 314 RVA: 0x0000DA80 File Offset: 0x0000CA80
		public void OpenBeside(DockControl existingWindow, DockSide side)
		{
			if (existingWindow != null)
			{
				if (existingWindow != this)
				{
					if (existingWindow.DockSituation == DockSituation.None)
					{
						throw new InvalidOperationException("The specified window is not open.");
					}
					this.Remove();
					existingWindow.LayoutSystem.SplitForLayoutSystem(new ControlLayoutSystem(this.MetaData.xe62a3d24e0fde928.x3a4e0c379519d4a2, new DockControl[]
					{
						this
					}, this), side);
					if (!false)
					{
						if (-1 == 0)
						{
							goto IL_64;
						}
						return;
					}
				}
				return;
			}
			IL_64:
			throw new ArgumentNullException();
		}

		// Token: 0x0600013B RID: 315 RVA: 0x0000DAFC File Offset: 0x0000CAFC
		public void DockInNewContainer(ContainerDockLocation dockLocation, ContainerDockEdge edge)
		{
			this.xc64dfbbdd2fa7bf6();
			this.Remove();
			DockContainer dockContainer = this.Manager.CreateNewDockContainer(dockLocation, edge, this.xfffbdea061bfa120.DockedContentSize);
			ControlLayoutSystem layoutSystem = dockContainer.CreateNewLayoutSystem(this, this.FloatingSize);
			dockContainer.LayoutSystem.LayoutSystems.Add(layoutSystem);
		}

		// Token: 0x0600013C RID: 316 RVA: 0x0000DB54 File Offset: 0x0000CB54
		internal void x02847d0dec2e498a(ControlLayoutSystem x6e150040c8d97700, int xc0c4c459c6ccbd00)
		{
			if (this.xb6a159a84cb992d6 != x6e150040c8d97700)
			{
				LayoutUtilities.xf1cbd48a28ce6e74(this);
				x6e150040c8d97700.Controls.Insert(xc0c4c459c6ccbd00, this);
				goto IL_2B;
			}
			IL_1E:
			x6e150040c8d97700.Controls.SetChildIndex(this, xc0c4c459c6ccbd00);
			IL_2B:
			x6e150040c8d97700.SelectedControl = this;
			if ((uint)xc0c4c459c6ccbd00 >= 0U)
			{
				return;
			}
			goto IL_1E;
		}

		// Token: 0x0600013D RID: 317 RVA: 0x0000DBA8 File Offset: 0x0000CBA8
		protected override void OnCreateControl()
		{
			base.OnCreateControl();
			this.OnLoad(EventArgs.Empty);
		}

		// Token: 0x0600013E RID: 318 RVA: 0x0000DBBC File Offset: 0x0000CBBC
		protected internal virtual void OnAutoHidePopupClosed(EventArgs e)
		{
			if (this.x7e416c13135971ea != null)
			{
				this.x7e416c13135971ea(this, e);
			}
		}

		// Token: 0x0600013F RID: 319 RVA: 0x0000DBD4 File Offset: 0x0000CBD4
		protected internal virtual void OnAutoHidePopupOpened(EventArgs e)
		{
			if (this.x5b29af28d5fc1a4e != null)
			{
				this.x5b29af28d5fc1a4e(this, e);
			}
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x06000140 RID: 320 RVA: 0x0000DBEC File Offset: 0x0000CBEC
		// (set) Token: 0x06000141 RID: 321 RVA: 0x0000DC44 File Offset: 0x0000CC44
		public override BindingContext BindingContext
		{
			get
			{
				if (this.x2464cce8c6385330 != null)
				{
					return this.x2464cce8c6385330;
				}
				if (this.Manager != null && this.Manager.DockSystemContainer != null)
				{
					return this.Manager.DockSystemContainer.BindingContext;
				}
				if (base.DesignMode)
				{
					return base.BindingContext;
				}
				return null;
			}
			set
			{
				this.x2464cce8c6385330 = value;
				base.BindingContext = value;
			}
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x06000142 RID: 322 RVA: 0x0000DC54 File Offset: 0x0000CC54
		// (set) Token: 0x06000143 RID: 323 RVA: 0x0000DC5C File Offset: 0x0000CC5C
		[Category("Behavior")]
		[Description("The control that will be focused when the window is activated.")]
		[DefaultValue(typeof(Control), null)]
		public Control PrimaryControl
		{
			get
			{
				return this.x3f02d9fd7ae06803;
			}
			set
			{
				this.x3f02d9fd7ae06803 = value;
			}
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x06000144 RID: 324 RVA: 0x0000DC68 File Offset: 0x0000CC68
		// (set) Token: 0x06000145 RID: 325 RVA: 0x0000DC80 File Offset: 0x0000CC80
		[DefaultValue(false)]
		[Description("Indicates whether the window is collapsed when docked.")]
		[Category("Layout")]
		public bool Collapsed
		{
			get
			{
				return this.LayoutSystem != null && this.LayoutSystem.Collapsed;
			}
			set
			{
				if (this.LayoutSystem != null)
				{
					this.LayoutSystem.Collapsed = value;
				}
			}
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x06000146 RID: 326 RVA: 0x0000DC98 File Offset: 0x0000CC98
		// (set) Token: 0x06000147 RID: 327 RVA: 0x0000DCA0 File Offset: 0x0000CCA0
		[Description("Indicates what action will be performed when the DockControl is closed.")]
		[DefaultValue(typeof(DockControlCloseAction), "HideOnly")]
		[Category("Behavior")]
		public virtual DockControlCloseAction CloseAction
		{
			get
			{
				return this.x8fbef9afc77bc952;
			}
			set
			{
				this.x8fbef9afc77bc952 = value;
			}
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x06000148 RID: 328 RVA: 0x0000DCAC File Offset: 0x0000CCAC
		[Browsable(false)]
		public WindowMetaData MetaData
		{
			get
			{
				return this.xfffbdea061bfa120;
			}
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x06000149 RID: 329 RVA: 0x0000DCB4 File Offset: 0x0000CCB4
		// (set) Token: 0x0600014A RID: 330 RVA: 0x0000DCBC File Offset: 0x0000CCBC
		internal bool xadad18dc04073a00
		{
			get
			{
				return this.xb98085e1d76c9b6d;
			}
			set
			{
				this.xb98085e1d76c9b6d = value;
			}
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x0600014B RID: 331 RVA: 0x0000DCC8 File Offset: 0x0000CCC8
		// (set) Token: 0x0600014C RID: 332 RVA: 0x0000DCD0 File Offset: 0x0000CCD0
		[Browsable(false)]
		public override DockStyle Dock
		{
			get
			{
				return base.Dock;
			}
			set
			{
				base.Dock = value;
			}
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x0600014D RID: 333 RVA: 0x0000DCDC File Offset: 0x0000CCDC
		public override Rectangle DisplayRectangle
		{
			get
			{
				Rectangle displayRectangle = base.DisplayRectangle;
				if (-2 != 0)
				{
				}
				switch (this.xacfbd7a08ba56c78)
				{
				case TD.SandDock.Rendering.BorderStyle.Flat:
				case TD.SandDock.Rendering.BorderStyle.RaisedThin:
				case TD.SandDock.Rendering.BorderStyle.SunkenThin:
					displayRectangle.Inflate(-1, -1);
					break;
				case TD.SandDock.Rendering.BorderStyle.RaisedThick:
				case TD.SandDock.Rendering.BorderStyle.SunkenThick:
					displayRectangle.Inflate(-2, -2);
					break;
				}
				return displayRectangle;
			}
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x0600014E RID: 334 RVA: 0x0000DD38 File Offset: 0x0000CD38
		// (set) Token: 0x0600014F RID: 335 RVA: 0x0000DD40 File Offset: 0x0000CD40
		[Description("Indicates whether the location of the DockControl will be included in layout serialization.")]
		[DefaultValue(true)]
		[Browsable(true)]
		[Category("Behavior")]
		public virtual bool PersistState
		{
			get
			{
				return this.x35db3fd5e409fffb;
			}
			set
			{
				this.x35db3fd5e409fffb = value;
			}
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x06000150 RID: 336 RVA: 0x0000DD4C File Offset: 0x0000CD4C
		// (set) Token: 0x06000151 RID: 337 RVA: 0x0000DD54 File Offset: 0x0000CD54
		[Category("Appearance")]
		[Description("The type of border to be drawn around the control.")]
		[DefaultValue(typeof(TD.SandDock.Rendering.BorderStyle), "None")]
		public TD.SandDock.Rendering.BorderStyle BorderStyle
		{
			get
			{
				return this.xacfbd7a08ba56c78;
			}
			set
			{
				this.xacfbd7a08ba56c78 = value;
				base.PerformLayout();
				base.Invalidate();
			}
		}

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x06000152 RID: 338 RVA: 0x0000DD6C File Offset: 0x0000CD6C
		[Browsable(false)]
		public ControlLayoutSystem LayoutSystem
		{
			get
			{
				return this.xb6a159a84cb992d6;
			}
		}

		// Token: 0x06000153 RID: 339 RVA: 0x0000DD74 File Offset: 0x0000CD74
		internal void xb2b69aae23a4ae6d(ControlLayoutSystem x6e150040c8d97700)
		{
			this.xb6a159a84cb992d6 = x6e150040c8d97700;
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x06000154 RID: 340 RVA: 0x0000DD80 File Offset: 0x0000CD80
		// (set) Token: 0x06000155 RID: 341 RVA: 0x0000DD88 File Offset: 0x0000CD88
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public SandDockManager Manager
		{
			get
			{
				return this.x91f347c6e97f1846;
			}
			set
			{
				if (value != this.x91f347c6e97f1846)
				{
					do
					{
						if (this.x91f347c6e97f1846 != null)
						{
							this.x91f347c6e97f1846.UnregisterWindow(this);
						}
						this.x91f347c6e97f1846 = value;
						if (2 != 0)
						{
							if (this.x91f347c6e97f1846 == null)
							{
								break;
							}
						}
						this.x91f347c6e97f1846.RegisterWindow(this);
					}
					while (-2147483648 == 0);
				}
			}
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x06000156 RID: 342 RVA: 0x0000DDE8 File Offset: 0x0000CDE8
		// (set) Token: 0x06000157 RID: 343 RVA: 0x0000DDF0 File Offset: 0x0000CDF0
		[Description("The unique identifier for the window.")]
		[Category("Advanced")]
		public Guid Guid
		{
			get
			{
				return this.xb51cd75f17ace1ec;
			}
			set
			{
				Guid oldGuid = this.xb51cd75f17ace1ec;
				this.xb51cd75f17ace1ec = value;
				if (this.Manager != null)
				{
					this.Manager.ReRegisterWindow(this, oldGuid);
				}
			}
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x06000158 RID: 344 RVA: 0x0000DE20 File Offset: 0x0000CE20
		[Browsable(false)]
		[Obsolete("Use the DockSituation property instead.")]
		public bool IsDocked
		{
			get
			{
				return this.x1a9802d2d8708515 && !(this.xb6a159a84cb992d6.DockContainer is DocumentContainer) && !(this.xb6a159a84cb992d6.DockContainer is x410f3612b9a8f9de);
			}
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x06000159 RID: 345 RVA: 0x0000DE54 File Offset: 0x0000CE54
		[Obsolete("Use the DockSituation property instead.")]
		[Browsable(false)]
		public bool IsTabbedDocument
		{
			get
			{
				return this.x1a9802d2d8708515 && this.xb6a159a84cb992d6.DockContainer is DocumentContainer;
			}
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x0600015A RID: 346 RVA: 0x0000DE74 File Offset: 0x0000CE74
		[Obsolete("Use the DockSituation property instead.")]
		[Browsable(false)]
		public bool IsFloating
		{
			get
			{
				return this.x1a9802d2d8708515 && this.xb6a159a84cb992d6.DockContainer.IsFloating;
			}
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x0600015B RID: 347 RVA: 0x0000DE90 File Offset: 0x0000CE90
		[Browsable(false)]
		internal bool x1a9802d2d8708515
		{
			get
			{
				return this.xb6a159a84cb992d6 != null && this.xb6a159a84cb992d6.DockContainer != null;
			}
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x0600015C RID: 348 RVA: 0x0000DEB0 File Offset: 0x0000CEB0
		[Browsable(false)]
		public bool IsOpen
		{
			get
			{
				bool flag = this.x1a9802d2d8708515 && this.xb6a159a84cb992d6 != null && this.xb6a159a84cb992d6.SelectedControl == this;
				do
				{
					if (!flag)
					{
						if (!false)
						{
							break;
						}
					}
					else if (this.xb6a159a84cb992d6.Collapsed)
					{
						goto IL_1B;
					}
				}
				while (false);
				return flag;
				IL_1B:
				flag = this.xb6a159a84cb992d6.IsPoppedUp;
				return flag;
			}
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x0600015D RID: 349 RVA: 0x0000DF18 File Offset: 0x0000CF18
		// (set) Token: 0x0600015E RID: 350 RVA: 0x0000DF20 File Offset: 0x0000CF20
		[DefaultValue(typeof(Color), "Control")]
		public override Color BackColor
		{
			get
			{
				return base.BackColor;
			}
			set
			{
				base.BackColor = value;
				while (this.LayoutSystem != null)
				{
					if (this.LayoutSystem.DockContainer == null)
					{
						if (2147483647 == 0)
						{
							continue;
						}
					}
					else
					{
						this.LayoutSystem.DockContainer.Invalidate(this.LayoutSystem.Bounds);
					}
					return;
				}
			}
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x0600015F RID: 351 RVA: 0x0000DF78 File Offset: 0x0000CF78
		// (set) Token: 0x06000160 RID: 352 RVA: 0x0000DF80 File Offset: 0x0000CF80
		public override Color ForeColor
		{
			get
			{
				return base.ForeColor;
			}
			set
			{
				base.ForeColor = value;
				if ((2147483647 == 0 || this.LayoutSystem != null) && this.LayoutSystem.DockContainer != null)
				{
					this.LayoutSystem.DockContainer.Invalidate(this.x123e054dab107457);
				}
			}
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x06000161 RID: 353 RVA: 0x0000DFC0 File Offset: 0x0000CFC0
		// (set) Token: 0x06000162 RID: 354 RVA: 0x0000DFC8 File Offset: 0x0000CFC8
		[Description("Indicates the default size this control will assume when floating on its own.")]
		[Category("Layout")]
		[DefaultValue(typeof(Size), "250, 400")]
		public Size FloatingSize
		{
			get
			{
				return this.xca874006c41dfe29;
			}
			set
			{
				if (value.Width > 0)
				{
					while (15 != 0)
					{
						if (value.Height > 0)
						{
							this.xca874006c41dfe29 = value;
							if (this.DockSituation == DockSituation.Floating && this.x410f3612b9a8f9de.xb1090c5821a633b5 != this.xca874006c41dfe29)
							{
								if (false)
								{
									continue;
								}
								this.x410f3612b9a8f9de.xb1090c5821a633b5 = this.xca874006c41dfe29;
							}
							return;
						}
						break;
					}
				}
				throw new ArgumentOutOfRangeException("value");
			}
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x06000163 RID: 355 RVA: 0x0000E050 File Offset: 0x0000D050
		// (set) Token: 0x06000164 RID: 356 RVA: 0x0000E058 File Offset: 0x0000D058
		[Browsable(false)]
		[DefaultValue(typeof(Point), "-1, -1")]
		public Point FloatingLocation
		{
			get
			{
				return this.xc868bd63c888e533;
			}
			set
			{
				this.xc868bd63c888e533 = value;
				if (3 != 0)
				{
					goto IL_61;
				}
				if (3 == 0)
				{
					goto IL_38;
				}
				goto IL_45;
				IL_17:
				if (!false)
				{
					if (-1 == 0)
					{
						goto IL_61;
					}
					return;
				}
				IL_1E:
				if (!(this.x410f3612b9a8f9de.x12992900724b93dc != this.xc868bd63c888e533))
				{
					return;
				}
				goto IL_45;
				IL_38:
				if (this.DockSituation != DockSituation.Floating)
				{
					goto IL_17;
				}
				goto IL_1E;
				IL_45:
				this.x410f3612b9a8f9de.x12992900724b93dc = this.xc868bd63c888e533;
				return;
				IL_61:
				if (!false)
				{
					goto IL_38;
				}
				goto IL_17;
			}
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x06000165 RID: 357 RVA: 0x0000E0CC File Offset: 0x0000D0CC
		private x410f3612b9a8f9de x410f3612b9a8f9de
		{
			get
			{
				return this.xb6a159a84cb992d6.DockContainer as x410f3612b9a8f9de;
			}
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x06000166 RID: 358 RVA: 0x0000E0E0 File Offset: 0x0000D0E0
		// (set) Token: 0x06000167 RID: 359 RVA: 0x0000E0F0 File Offset: 0x0000D0F0
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Obsolete("Use the DockingRules property instead.")]
		public bool AllowFloat
		{
			get
			{
				return this.DockingRules.AllowFloat;
			}
			set
			{
				this.DockingRules.AllowFloat = value;
			}
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x06000168 RID: 360 RVA: 0x0000E100 File Offset: 0x0000D100
		// (set) Token: 0x06000169 RID: 361 RVA: 0x0000E110 File Offset: 0x0000D110
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Obsolete("Use the DockingRules property instead.")]
		public bool AllowDockCenter
		{
			get
			{
				return this.DockingRules.AllowTab;
			}
			set
			{
				this.DockingRules.AllowTab = value;
			}
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x0600016A RID: 362 RVA: 0x0000E120 File Offset: 0x0000D120
		// (set) Token: 0x0600016B RID: 363 RVA: 0x0000E130 File Offset: 0x0000D130
		[Browsable(false)]
		[Obsolete("Use the DockingRules property instead.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool AllowDockLeft
		{
			get
			{
				return this.DockingRules.AllowDockLeft;
			}
			set
			{
				this.DockingRules.AllowDockLeft = value;
			}
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x0600016C RID: 364 RVA: 0x0000E140 File Offset: 0x0000D140
		// (set) Token: 0x0600016D RID: 365 RVA: 0x0000E150 File Offset: 0x0000D150
		[Obsolete("Use the DockingRules property instead.")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool AllowDockRight
		{
			get
			{
				return this.DockingRules.AllowDockRight;
			}
			set
			{
				this.DockingRules.AllowDockRight = value;
			}
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x0600016E RID: 366 RVA: 0x0000E160 File Offset: 0x0000D160
		// (set) Token: 0x0600016F RID: 367 RVA: 0x0000E170 File Offset: 0x0000D170
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Obsolete("Use the DockingRules property instead.")]
		public bool AllowDockTop
		{
			get
			{
				return this.DockingRules.AllowDockTop;
			}
			set
			{
				this.DockingRules.AllowDockTop = value;
			}
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x06000170 RID: 368 RVA: 0x0000E180 File Offset: 0x0000D180
		// (set) Token: 0x06000171 RID: 369 RVA: 0x0000E190 File Offset: 0x0000D190
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Obsolete("Use the DockingRules property instead.")]
		[Browsable(false)]
		public bool AllowDockBottom
		{
			get
			{
				return this.DockingRules.AllowDockBottom;
			}
			set
			{
				this.DockingRules.AllowDockBottom = value;
			}
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x06000172 RID: 370 RVA: 0x0000E1A0 File Offset: 0x0000D1A0
		// (set) Token: 0x06000173 RID: 371 RVA: 0x0000E1A8 File Offset: 0x0000D1A8
		[Description("The rules with which to govern where the user can move the window.")]
		[Category("Behavior")]
		public DockingRules DockingRules
		{
			get
			{
				return this.xd447c58f1b8b8e4b;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				this.xd447c58f1b8b8e4b = value;
			}
		}

		// Token: 0x06000174 RID: 372 RVA: 0x0000E1C0 File Offset: 0x0000D1C0
		private bool ShouldSerializeDockingRules()
		{
			DockingRules dockingRules = this.CreateDockingRules();
			if (-1 != 0)
			{
				if (dockingRules.AllowDockTop != this.DockingRules.AllowDockTop || false)
				{
					return true;
				}
			}
			IL_97:
			while (4 != 0)
			{
				while (dockingRules.AllowDockBottom == this.DockingRules.AllowDockBottom)
				{
					if (255 == 0)
					{
						if (!false)
						{
							goto IL_97;
						}
						if (false)
						{
							goto IL_AA;
						}
						if (!false)
						{
							break;
						}
					}
					else
					{
						if (false)
						{
							goto IL_C7;
						}
						goto IL_5E;
					}
				}
				goto IL_95;
				IL_5E:
				if (dockingRules.AllowDockLeft == this.DockingRules.AllowDockLeft)
				{
					goto IL_C7;
				}
				IL_95:
				return true;
				IL_AA:
				return dockingRules.AllowFloat != this.DockingRules.AllowFloat;
				IL_C7:
				if (false)
				{
					break;
				}
				IL_1C:
				if (dockingRules.AllowDockRight != this.DockingRules.AllowDockRight)
				{
					return true;
				}
				if (dockingRules.AllowTab != this.DockingRules.AllowTab)
				{
					return true;
				}
				goto IL_AA;
			}
			if (2 == 0)
			{
				goto IL_1C;
			}
			goto IL_5E;
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x06000175 RID: 373 RVA: 0x0000E2B4 File Offset: 0x0000D2B4
		// (set) Token: 0x06000176 RID: 374 RVA: 0x0000E2C4 File Offset: 0x0000D2C4
		[Category("Behavior")]
		[Description("Determines whether the user will be able to press tab to bring the focus within the window when docked.")]
		[DefaultValue(false)]
		public bool AllowKeyboardFocus
		{
			get
			{
				return base.GetStyle(ControlStyles.Selectable);
			}
			set
			{
				base.SetStyle(ControlStyles.Selectable, value);
			}
		}

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x06000177 RID: 375 RVA: 0x0000E2D4 File Offset: 0x0000D2D4
		// (set) Token: 0x06000178 RID: 376 RVA: 0x0000E2DC File Offset: 0x0000D2DC
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[Obsolete("Use the AllowClose property instead.", true)]
		public bool Closable
		{
			get
			{
				return this.AllowClose;
			}
			set
			{
				this.AllowClose = value;
			}
		}

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x06000179 RID: 377 RVA: 0x0000E2E8 File Offset: 0x0000D2E8
		// (set) Token: 0x0600017A RID: 378 RVA: 0x0000E2F0 File Offset: 0x0000D2F0
		[DefaultValue(true)]
		[Description("Indicates whether this control will be closable by the user.")]
		[Category("Docking")]
		public virtual bool AllowClose
		{
			get
			{
				return this.x6c3086899dc42885;
			}
			set
			{
				this.x6c3086899dc42885 = value;
				this.x7735d9a753c63a0a();
			}
		}

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x0600017B RID: 379 RVA: 0x0000E300 File Offset: 0x0000D300
		// (set) Token: 0x0600017C RID: 380 RVA: 0x0000E308 File Offset: 0x0000D308
		[DefaultValue(0)]
		[Category("Layout")]
		[Description("Indicates the maximum width of the tab representing the window.")]
		public int MaximumTabWidth
		{
			get
			{
				return this.x3214e09b677ccd2b;
			}
			set
			{
				if (value < 0)
				{
					throw new ArgumentException("Value must be greater than or equal to zero.");
				}
				this.x3214e09b677ccd2b = value;
				this.x7735d9a753c63a0a();
			}
		}

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x0600017D RID: 381 RVA: 0x0000E328 File Offset: 0x0000D328
		// (set) Token: 0x0600017E RID: 382 RVA: 0x0000E330 File Offset: 0x0000D330
		[Description("Indicates the minimum width of the tab representing the window.")]
		[DefaultValue(0)]
		[Category("Layout")]
		public int MinimumTabWidth
		{
			get
			{
				return this.xcf3ab1252c42eac6;
			}
			set
			{
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException("value");
				}
				this.xcf3ab1252c42eac6 = value;
				this.x7735d9a753c63a0a();
			}
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x0600017F RID: 383 RVA: 0x0000E350 File Offset: 0x0000D350
		// (set) Token: 0x06000180 RID: 384 RVA: 0x0000E358 File Offset: 0x0000D358
		[DefaultValue(true)]
		[Category("Appearance")]
		[Description("Indicates whether an options button will be displayed in the titlebar for this window.")]
		public bool ShowOptions
		{
			get
			{
				return this.x1def1a42ad5b7095;
			}
			set
			{
				this.x1def1a42ad5b7095 = value;
				this.x7735d9a753c63a0a();
			}
		}

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x06000181 RID: 385 RVA: 0x0000E368 File Offset: 0x0000D368
		// (set) Token: 0x06000182 RID: 386 RVA: 0x0000E370 File Offset: 0x0000D370
		[Category("Docking")]
		[DefaultValue(true)]
		[Description("Indicates whether the user will be able to put this control in to auto-hide mode.")]
		public virtual bool AllowCollapse
		{
			get
			{
				return this.x9b80917b168ce488;
			}
			set
			{
				this.x9b80917b168ce488 = value;
				if (-1 != 0)
				{
					if (value)
					{
						goto IL_22;
					}
					while (!false)
					{
						if (this.Collapsed)
						{
							break;
						}
						if (!false)
						{
							goto IL_22;
						}
					}
				}
				this.Collapsed = false;
				IL_22:
				this.x7735d9a753c63a0a();
			}
		}

		// Token: 0x06000183 RID: 387 RVA: 0x0000E3A4 File Offset: 0x0000D3A4
		private bool ShouldSerializeTabText()
		{
			return this.xc3d462fde66905e5.Length != 0 && this.xc3d462fde66905e5 != this.Text;
		}

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x06000184 RID: 388 RVA: 0x0000E3C8 File Offset: 0x0000D3C8
		// (set) Token: 0x06000185 RID: 389 RVA: 0x0000E3D0 File Offset: 0x0000D3D0
		[Localizable(true)]
		[Category("Appearance")]
		[DefaultValue("")]
		[Description("Gets or sets the text that appears as a ToolTip for the control tab.")]
		public virtual string ToolTipText
		{
			get
			{
				return this.xd84978f0dad7afcd;
			}
			set
			{
				if (value == null)
				{
					value = string.Empty;
				}
				this.xd84978f0dad7afcd = value;
			}
		}

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x06000186 RID: 390 RVA: 0x0000E3E4 File Offset: 0x0000D3E4
		// (set) Token: 0x06000187 RID: 391 RVA: 0x0000E400 File Offset: 0x0000D400
		[Localizable(true)]
		[Category("Appearance")]
		[Description("The text to display on the tab for the DockControl. This can be different to the standard text.")]
		public virtual string TabText
		{
			get
			{
				if (this.xc3d462fde66905e5.Length == 0)
				{
					return this.Text;
				}
				return this.xc3d462fde66905e5;
			}
			set
			{
				if (value == null)
				{
					value = string.Empty;
				}
				this.xc3d462fde66905e5 = value;
				this.x7735d9a753c63a0a();
			}
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x06000188 RID: 392 RVA: 0x0000E41C File Offset: 0x0000D41C
		// (set) Token: 0x06000189 RID: 393 RVA: 0x0000E424 File Offset: 0x0000D424
		[Description("The size of the control when popped up from a collapsed state. Leave this as zero for the default size.")]
		[DefaultValue(0)]
		[Category("Docking")]
		public int PopupSize
		{
			get
			{
				return this.x5614e4ef0596c91d;
			}
			set
			{
				if (value >= 0)
				{
					goto IL_E9;
				}
				bool flag = (uint)value - (uint)value > uint.MaxValue;
				if (flag)
				{
					goto IL_A4;
				}
				goto IL_DE;
				IL_81:
				if (!this.MetaData.x057495d927e64b9e)
				{
					goto IL_BC;
				}
				if (2 == 0)
				{
					goto IL_E9;
				}
				IL_95:
				if (this.LayoutSystem != null && this.LayoutSystem.x10ac79a4257c7f52 != null)
				{
					if (this.LayoutSystem.x10ac79a4257c7f52.x23498f53d87354d4 != this.LayoutSystem)
					{
						if (((uint)value & 0U) != 0U)
						{
							goto IL_DE;
						}
					}
					else
					{
						this.LayoutSystem.x10ac79a4257c7f52.xca843b3e9a1c605f = value;
					}
				}
				return;
				IL_A4:
				if ((uint)value - (uint)value < 0U)
				{
					goto IL_DE;
				}
				IL_BC:
				this.MetaData.x3ef4455ea4965093(value);
				flag = ((uint)value + (uint)value > uint.MaxValue);
				if (flag)
				{
					goto IL_81;
				}
				goto IL_95;
				IL_DE:
				throw new ArgumentException("Value must be at least equal to zero.");
				IL_E9:
				this.x5614e4ef0596c91d = value;
				flag = ((uint)value + (uint)value < 0U);
				if (flag)
				{
					goto IL_A4;
				}
				goto IL_81;
			}
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x0600018A RID: 394 RVA: 0x0000E540 File Offset: 0x0000D540
		// (set) Token: 0x0600018B RID: 395 RVA: 0x0000E548 File Offset: 0x0000D548
		public override string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				base.Text = value;
				for (;;)
				{
					IL_39:
					this.x7735d9a753c63a0a();
					while (this.DockSituation == DockSituation.Floating)
					{
						if (!this.x410f3612b9a8f9de.HasSingleControlLayoutSystem)
						{
							if (!false)
							{
								break;
							}
							if (-2147483648 == 0)
							{
								break;
							}
						}
						else
						{
							if (this.LayoutSystem.SelectedControl != this)
							{
								break;
							}
							this.x410f3612b9a8f9de.xd1bdd0ee5924b59e();
						}
						if (4 != 0)
						{
							if (false)
							{
								goto IL_39;
							}
							break;
						}
					}
					break;
				}
			}
		}

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x0600018C RID: 396 RVA: 0x0000E5B4 File Offset: 0x0000D5B4
		internal Image x1999b243e321e38a
		{
			get
			{
				if (this.x564c6c527905c683 == null)
				{
					return DockControl.x28afaed1891a17a1;
				}
				return this.x564c6c527905c683;
			}
		}

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x0600018D RID: 397 RVA: 0x0000E5CC File Offset: 0x0000D5CC
		[Browsable(false)]
		public Rectangle TabBounds
		{
			get
			{
				return this.x123e054dab107457;
			}
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x0600018E RID: 398 RVA: 0x0000E5D4 File Offset: 0x0000D5D4
		[Browsable(false)]
		public DockSituation DockSituation
		{
			get
			{
				return this.xef84499526c04953;
			}
		}

		// Token: 0x0600018F RID: 399 RVA: 0x0000E5DC File Offset: 0x0000D5DC
		private void x409072a6bb877e49(DockSituation xbcea506a33cf9111)
		{
			if (this.x131b418d4c565c70)
			{
				throw new InvalidOperationException("The requested operation is not valid on a window that is currently engaged in an activity further up the call stack. Consider using BeginInvoke to postpone the operation until the stack has unwound.");
			}
			if (xbcea506a33cf9111 != this.xef84499526c04953)
			{
				this.xef84499526c04953 = xbcea506a33cf9111;
				this.x131b418d4c565c70 = true;
				try
				{
					this.OnDockSituationChanged(EventArgs.Empty);
				}
				finally
				{
					this.x131b418d4c565c70 = false;
				}
			}
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x06000190 RID: 400 RVA: 0x0000E644 File Offset: 0x0000D644
		// (set) Token: 0x06000191 RID: 401 RVA: 0x0000E64C File Offset: 0x0000D64C
		[DefaultValue(typeof(Image), null)]
		[AmbientValue(typeof(Image), null)]
		[Description("The image displayed for this control on docking tabs.")]
		[Category("Appearance")]
		public Image TabImage
		{
			get
			{
				return this.x564c6c527905c683;
			}
			set
			{
				this.x564c6c527905c683 = value;
				this.x7735d9a753c63a0a();
			}
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x06000192 RID: 402 RVA: 0x0000E65C File Offset: 0x0000D65C
		protected override Size DefaultSize
		{
			get
			{
				return new Size(250, 400);
			}
		}

		// Token: 0x06000193 RID: 403 RVA: 0x0000E670 File Offset: 0x0000D670
		protected override void OnFontChanged(EventArgs e)
		{
			base.OnFontChanged(e);
			if (!this.xadad18dc04073a00)
			{
				this.x7735d9a753c63a0a();
			}
		}

		// Token: 0x06000194 RID: 404 RVA: 0x0000E68C File Offset: 0x0000D68C
		protected override void Dispose(bool disposing)
		{
			if (!disposing)
			{
				goto IL_14;
			}
			if (this.xb6a159a84cb992d6 != null)
			{
				goto IL_45;
			}
			IL_07:
			while (this.Manager != null)
			{
				this.Manager = null;
				if (false)
				{
					return;
				}
				if (!false)
				{
					break;
				}
			}
			IL_0F:
			IL_14:
			base.Dispose(disposing);
			bool flag = (disposing ? 1U : 0U) - (disposing ? 1U : 0U) < 0U;
			if (!flag)
			{
				return;
			}
			if ((disposing ? 1U : 0U) < 0U)
			{
				goto IL_0F;
			}
			IL_45:
			LayoutUtilities.xf1cbd48a28ce6e74(this);
			goto IL_07;
		}

		// Token: 0x06000195 RID: 405 RVA: 0x0000E700 File Offset: 0x0000D700
		protected override void WndProc(ref Message m)
		{
			if (m.Msg == 33)
			{
				if (!false)
				{
					base.WndProc(ref m);
					if (!false)
					{
					}
					if (base.ContainsFocus)
					{
						return;
					}
				}
				this.Activate();
				return;
			}
			base.WndProc(ref m);
		}

		// Token: 0x0400004B RID: 75
		private SandDockManager x91f347c6e97f1846;

		// Token: 0x0400004C RID: 76
		private ControlLayoutSystem xb6a159a84cb992d6;

		// Token: 0x0400004D RID: 77
		internal Rectangle x123e054dab107457 = Rectangle.Empty;

		// Token: 0x0400004E RID: 78
		internal Rectangle x700c42042910e68b = Rectangle.Empty;

		// Token: 0x0400004F RID: 79
		private static Image x28afaed1891a17a1;

		// Token: 0x04000050 RID: 80
		private Image x564c6c527905c683;

		// Token: 0x04000051 RID: 81
		private TD.SandDock.Rendering.BorderStyle xacfbd7a08ba56c78;

		// Token: 0x04000052 RID: 82
		private bool xb98085e1d76c9b6d;

		// Token: 0x04000053 RID: 83
		private bool x4e7c2c44587adeda;

		// Token: 0x04000054 RID: 84
		private bool x131b418d4c565c70;

		// Token: 0x04000055 RID: 85
		internal bool xcfac6723d8a41375;

		// Token: 0x04000056 RID: 86
		private string xd84978f0dad7afcd = "";

		// Token: 0x04000057 RID: 87
		private int x5614e4ef0596c91d;

		// Token: 0x04000058 RID: 88
		private int x3214e09b677ccd2b;

		// Token: 0x04000059 RID: 89
		private int xcf3ab1252c42eac6;

		// Token: 0x0400005A RID: 90
		private WindowMetaData xfffbdea061bfa120;

		// Token: 0x0400005B RID: 91
		private string xc3d462fde66905e5 = string.Empty;

		// Token: 0x0400005C RID: 92
		private bool x6c3086899dc42885 = true;

		// Token: 0x0400005D RID: 93
		private bool x9b80917b168ce488 = true;

		// Token: 0x0400005E RID: 94
		private BindingContext x2464cce8c6385330;

		// Token: 0x0400005F RID: 95
		private Guid xb51cd75f17ace1ec = Guid.NewGuid();

		// Token: 0x04000060 RID: 96
		private Size xca874006c41dfe29;

		// Token: 0x04000061 RID: 97
		private Point xc868bd63c888e533 = new Point(-1, -1);

		// Token: 0x04000062 RID: 98
		private bool x35db3fd5e409fffb = true;

		// Token: 0x04000063 RID: 99
		private DockingRules xd447c58f1b8b8e4b;

		// Token: 0x04000064 RID: 100
		private bool x1def1a42ad5b7095 = true;

		// Token: 0x04000065 RID: 101
		private DockControlCloseAction x8fbef9afc77bc952;

		// Token: 0x04000066 RID: 102
		private Control x3f02d9fd7ae06803;

		// Token: 0x04000067 RID: 103
		private DockSituation xef84499526c04953;

		// Token: 0x04000068 RID: 104
		private DockControlClosingEventHandler xb451d7f50d849473;

		// Token: 0x04000069 RID: 105
		private EventHandler x289bf94a509dd84c;

		// Token: 0x0400006A RID: 106
		private EventHandler x5d95f5f98c940295;

		// Token: 0x0400006B RID: 107
		private EventHandler x5b29af28d5fc1a4e;

		// Token: 0x0400006C RID: 108
		private EventHandler x7e416c13135971ea;

		// Token: 0x0400006D RID: 109
		private EventHandler x8e01005e38b88f59;
	}
}
