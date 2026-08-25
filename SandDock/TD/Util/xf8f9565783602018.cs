using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace TD.Util
{
	// Token: 0x02000003 RID: 3
	internal class xf8f9565783602018 : IDisposable
	{
		// Token: 0x14000001 RID: 1
		// (add) Token: 0x0600000F RID: 15 RVA: 0x000048F4 File Offset: 0x000038F4
		// (remove) Token: 0x06000010 RID: 16 RVA: 0x00004910 File Offset: 0x00003910
		public event xf8f9565783602018.x58986a4a0b75e5b5 x9b21ee8e7ceaada3;

		// Token: 0x06000011 RID: 17
		[DllImport("user32.dll")]
		private static extern bool SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int y, int cx, int cy, int flags);

		// Token: 0x06000012 RID: 18 RVA: 0x0000492C File Offset: 0x0000392C
		public xf8f9565783602018(Control control)
		{
			if (-2147483648 != 0 && !false)
			{
				if (!false)
				{
					this.x43bec302f92080b9 = control;
					if (15 != 0)
					{
						control.MouseMove += this.x51529e0468abe27e;
						control.MouseLeave += this.x664829383a59617c;
						control.MouseDown += this.x1c8953a8a8447816;
						control.MouseWheel += this.x5e1cbc67acfe3317;
						control.Disposed += this.x77d9086325b6e538;
					}
					if (-2147483648 == 0)
					{
						goto IL_108;
					}
				}
				control.FontChanged += this.xb27df3b0091b2a36;
				this.xa6607dfd4b3038ad = new xf8f9565783602018.xab7df35839b7399e(this);
				IL_108:
				if (-2 == 0)
				{
					return;
				}
			}
			this.xa6607dfd4b3038ad.MouseMove += this.x1aaaf41037533886;
			this.x537a4001020fd4c7 = new Timer();
			this.x537a4001020fd4c7.Interval = SystemInformation.DoubleClickTime;
			this.x537a4001020fd4c7.Tick += this.x79a58a5d2c65c5a4;
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00004A4C File Offset: 0x00003A4C
		public void Dispose()
		{
			if (!this.x0e75cd3866dbb930)
			{
				if (!false)
				{
					this.x47c79a4d207183de();
					this.xa6607dfd4b3038ad.MouseMove -= this.x1aaaf41037533886;
					this.xa6607dfd4b3038ad.Dispose();
					this.xa6607dfd4b3038ad = null;
					if (255 == 0)
					{
						return;
					}
					if (-2 != 0)
					{
						this.x43bec302f92080b9.MouseMove -= this.x51529e0468abe27e;
						this.x43bec302f92080b9.MouseLeave -= this.x664829383a59617c;
						this.x43bec302f92080b9.MouseDown -= this.x1c8953a8a8447816;
						this.x43bec302f92080b9.MouseWheel -= this.x5e1cbc67acfe3317;
						if (-2 != 0)
						{
							this.x43bec302f92080b9.Disposed -= this.x77d9086325b6e538;
							this.x43bec302f92080b9.FontChanged -= this.xb27df3b0091b2a36;
						}
						this.x43bec302f92080b9 = null;
					}
				}
				this.x537a4001020fd4c7.Tick -= this.x79a58a5d2c65c5a4;
				this.x537a4001020fd4c7.Dispose();
				this.x0e75cd3866dbb930 = true;
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000014 RID: 20 RVA: 0x00004B80 File Offset: 0x00003B80
		// (set) Token: 0x06000015 RID: 21 RVA: 0x00004B88 File Offset: 0x00003B88
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

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000016 RID: 22 RVA: 0x00004B94 File Offset: 0x00003B94
		// (set) Token: 0x06000017 RID: 23 RVA: 0x00004BA4 File Offset: 0x00003BA4
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

		// Token: 0x06000018 RID: 24 RVA: 0x00004BB4 File Offset: 0x00003BB4
		private static bool x7fb2e1ce54a27086()
		{
			bool result = false;
			if (Environment.OSVersion.Platform == PlatformID.Win32NT)
			{
				result = (Environment.OSVersion.Version >= new Version(5, 1, 0, 0));
			}
			return result;
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00004BF0 File Offset: 0x00003BF0
		public void x4402a69f607144e3(Point xb9c2cfae130d9256, string xb41faee6912a2313)
		{
			this.xa6607dfd4b3038ad.Text = xb41faee6912a2313;
			if (255 != 0)
			{
				VisualStyleElement normal;
				for (;;)
				{
					Size size = Size.Ceiling(this.xa6607dfd4b3038ad.x0a8f2a18d3b53839(xb41faee6912a2313));
					Screen screen;
					for (;;)
					{
						IL_30A:
						size.Height += 4;
						if (8 != 0)
						{
							size.Width += 4;
							xb9c2cfae130d9256.Y += 19;
							while (!false)
							{
								screen = Screen.FromPoint(xb9c2cfae130d9256);
								for (;;)
								{
									if (xb9c2cfae130d9256.X >= screen.Bounds.Left)
									{
										if (2 == 0)
										{
											if (false)
											{
												break;
											}
											if (!false)
											{
												goto IL_298;
											}
											if (false)
											{
												goto IL_30A;
											}
										}
										if (!false)
										{
											goto Block_16;
										}
									}
									else
									{
										xb9c2cfae130d9256.X = screen.Bounds.Left;
									}
									IL_298:
									if (!false)
									{
										goto Block_17;
									}
								}
							}
							return;
						}
						goto IL_C8;
					}
					for (;;)
					{
						IL_1CA:
						if (xb9c2cfae130d9256.X + size.Width <= screen.Bounds.Right)
						{
							if (false)
							{
								goto IL_1ED;
							}
							goto IL_205;
						}
						else
						{
							xb9c2cfae130d9256.X = screen.Bounds.Right - size.Width;
							if (xb9c2cfae130d9256.X < screen.Bounds.Left)
							{
								return;
							}
							goto IL_205;
						}
						IL_21D:
						if (xb9c2cfae130d9256.Y + size.Height <= screen.Bounds.Bottom)
						{
							goto IL_123;
						}
						if (-2 == 0)
						{
							break;
						}
						xb9c2cfae130d9256.Y = screen.Bounds.Bottom - size.Height;
						if (false)
						{
							continue;
						}
						break;
						IL_1ED:
						xb9c2cfae130d9256.Y = screen.Bounds.Top;
						goto IL_21D;
						IL_205:
						if (xb9c2cfae130d9256.Y >= screen.Bounds.Top)
						{
							goto IL_21D;
						}
						goto IL_1ED;
					}
					if (xb9c2cfae130d9256.Y < screen.Bounds.Top)
					{
						return;
					}
					xb9c2cfae130d9256.X++;
					if (false)
					{
						continue;
					}
					if (false)
					{
						goto IL_34D;
					}
					IL_123:
					xf8f9565783602018.SetWindowPos(this.xa6607dfd4b3038ad.Handle, -1, xb9c2cfae130d9256.X, xb9c2cfae130d9256.Y, size.Width, size.Height, 80);
					normal = VisualStyleElement.ToolTip.Standard.Normal;
					if (!Application.RenderWithVisualStyles)
					{
						goto IL_7D;
					}
					if (-2147483648 == 0)
					{
						if (2147483647 == 0)
						{
							continue;
						}
					}
					else if (false)
					{
						break;
					}
					IL_C8:
					if (VisualStyleRenderer.IsElementDefined(normal))
					{
						break;
					}
					if (false)
					{
						goto IL_123;
					}
					goto IL_172;
					Block_16:
					Block_17:
					goto IL_1CA;
				}
				VisualStyleRenderer visualStyleRenderer = new VisualStyleRenderer(normal);
				using (Graphics graphics = this.xa6607dfd4b3038ad.CreateGraphics())
				{
					this.xa6607dfd4b3038ad.Region = visualStyleRenderer.GetBackgroundRegion(graphics, this.xa6607dfd4b3038ad.ClientRectangle);
				}
				IL_172:
				IL_34D:
				goto IL_7D;
			}
			if (!false)
			{
				goto IL_7D;
			}
			IL_55:
			this.x9238f6a5f034aeb5 = this.x624fa8b017460890(this.x43bec302f92080b9);
			if (!false && this.x9238f6a5f034aeb5 == null)
			{
				return;
			}
			this.x9238f6a5f034aeb5.Deactivate += this.xdef19f2ef265bf1e;
			this.xa6607dfd4b3038ad.Owner = this.x9238f6a5f034aeb5;
			return;
			IL_7D:
			this.xa6607dfd4b3038ad.Invalidate();
			this.x364c1e3b189d47fe = true;
			if (false)
			{
				goto IL_55;
			}
			if (15 == 0)
			{
				return;
			}
			if (this.x9238f6a5f034aeb5 == null)
			{
				goto IL_55;
			}
			this.x9238f6a5f034aeb5.Deactivate -= this.xdef19f2ef265bf1e;
			if (!false)
			{
				goto IL_55;
			}
			goto IL_7D;
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00004F6C File Offset: 0x00003F6C
		public void x47c79a4d207183de()
		{
			this.xa6607dfd4b3038ad.Owner = null;
			this.xa6607dfd4b3038ad.Visible = false;
			this.x364c1e3b189d47fe = false;
			if (-1 == 0 || this.x9238f6a5f034aeb5 != null)
			{
				this.x9238f6a5f034aeb5.Deactivate -= this.xdef19f2ef265bf1e;
				this.x9238f6a5f034aeb5 = null;
			}
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00004FD0 File Offset: 0x00003FD0
		private void x51529e0468abe27e(object xe0292b9ed559da7d, MouseEventArgs xfbf34718e704c6bc)
		{
			if (xfbf34718e704c6bc.Button != MouseButtons.None)
			{
				goto IL_10A;
			}
			goto IL_DC;
			IL_13:
			if (false)
			{
				goto IL_2A;
			}
			IL_16:
			if (!false)
			{
				return;
			}
			IL_1C:
			if (-2147483648 != 0)
			{
				goto IL_107;
			}
			goto IL_13;
			IL_2A:
			string text;
			if (text != this.xa6607dfd4b3038ad.Text)
			{
				this.x4402a69f607144e3(Cursor.Position, text);
				return;
			}
			IL_D4:
			if (false)
			{
				goto IL_13;
			}
			goto IL_1C;
			IL_DC:
			Point left;
			if (this.x364c1e3b189d47fe)
			{
				text = this.x9b21ee8e7ceaada3(new Point(xfbf34718e704c6bc.X, xfbf34718e704c6bc.Y));
				if (false)
				{
					goto IL_107;
				}
				if (text != null)
				{
					if (!true)
					{
						goto IL_16;
					}
					if (-2147483648 == 0)
					{
						goto IL_3F;
					}
					if (text.Length != 0)
					{
						if (text.Length == 0)
						{
							goto IL_13;
						}
						goto IL_2A;
					}
				}
				this.x47c79a4d207183de();
				return;
			}
			else
			{
				left = new Point(xfbf34718e704c6bc.X, xfbf34718e704c6bc.Y);
				if (!(left != this.xa639e9f791585165))
				{
					return;
				}
				if (false)
				{
					goto IL_D4;
				}
			}
			IL_3F:
			this.xa639e9f791585165 = left;
			this.x537a4001020fd4c7.Enabled = false;
			this.x537a4001020fd4c7.Enabled = true;
			return;
			IL_107:
			if (!false)
			{
				return;
			}
			IL_10A:
			if (false)
			{
				goto IL_13;
			}
			if (true)
			{
				return;
			}
			goto IL_DC;
		}

		// Token: 0x0600001C RID: 28 RVA: 0x000050F8 File Offset: 0x000040F8
		private void x79a58a5d2c65c5a4(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			this.x537a4001020fd4c7.Enabled = false;
			bool flag2;
			bool flag = (flag2 ? 1U : 0U) - (flag2 ? 1U : 0U) > uint.MaxValue;
			string text;
			Form form;
			Form activeForm;
			bool flag3;
			if (!flag)
			{
				for (;;)
				{
					Point point = this.x43bec302f92080b9.PointToClient(Cursor.Position);
					Rectangle clientRectangle = this.x43bec302f92080b9.ClientRectangle;
					flag = (((flag2 ? 1U : 0U) & 0U) == 0U);
					if (!flag)
					{
						return;
					}
					if (!clientRectangle.Contains(point))
					{
						return;
					}
					text = this.x9b21ee8e7ceaada3(point);
					if (text == null)
					{
						break;
					}
					if ((flag2 ? 1U : 0U) <= 4294967295U)
					{
						goto Block_9;
					}
				}
				return;
				Block_9:
				if (-2 == 0)
				{
					flag = ((flag2 ? 1U : 0U) + (flag2 ? 1U : 0U) < 0U);
					if (flag)
					{
						goto IL_89;
					}
					return;
				}
				else
				{
					if (text.Length != 0)
					{
						form = this.x624fa8b017460890(this.x43bec302f92080b9);
						activeForm = Form.ActiveForm;
						if (form != null)
						{
							if (activeForm != null)
							{
								goto IL_89;
							}
						}
						flag3 = false;
						goto IL_5E;
					}
					return;
				}
				return;
			}
			if (((flag2 ? 1U : 0U) & 0U) == 0U)
			{
				goto IL_89;
			}
			IL_3B:
			while (flag2)
			{
				if (!this.x43bec302f92080b9.Visible)
				{
					break;
				}
				this.x4402a69f607144e3(Cursor.Position, text);
				flag = ((flag2 ? 1U : 0U) > uint.MaxValue);
				if (!flag)
				{
					break;
				}
			}
			return;
			IL_5E:
			flag2 = flag3;
			goto IL_3B;
			IL_89:
			flag3 = (activeForm == form || activeForm == form.Owner);
			goto IL_5E;
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00005250 File Offset: 0x00004250
		private Form x624fa8b017460890(Control x3c4da2980d043c95)
		{
			while (x3c4da2980d043c95.Parent != null)
			{
				x3c4da2980d043c95 = x3c4da2980d043c95.Parent;
			}
			return x3c4da2980d043c95 as Form;
		}

		// Token: 0x0600001E RID: 30 RVA: 0x0000526C File Offset: 0x0000426C
		private void x664829383a59617c(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			if (this.x364c1e3b189d47fe)
			{
				this.x47c79a4d207183de();
			}
			this.x537a4001020fd4c7.Enabled = false;
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00005288 File Offset: 0x00004288
		private void x1c8953a8a8447816(object xe0292b9ed559da7d, MouseEventArgs xfbf34718e704c6bc)
		{
			if (this.x364c1e3b189d47fe)
			{
				this.x47c79a4d207183de();
			}
			this.x537a4001020fd4c7.Enabled = false;
		}

		// Token: 0x06000020 RID: 32 RVA: 0x000052A4 File Offset: 0x000042A4
		private void x5e1cbc67acfe3317(object xe0292b9ed559da7d, MouseEventArgs xfbf34718e704c6bc)
		{
			if (this.x364c1e3b189d47fe)
			{
				this.x47c79a4d207183de();
			}
			this.x537a4001020fd4c7.Enabled = false;
		}

		// Token: 0x06000021 RID: 33 RVA: 0x000052C0 File Offset: 0x000042C0
		private void x1aaaf41037533886(object xe0292b9ed559da7d, MouseEventArgs xfbf34718e704c6bc)
		{
			this.x47c79a4d207183de();
		}

		// Token: 0x06000022 RID: 34 RVA: 0x000052C8 File Offset: 0x000042C8
		private void xdef19f2ef265bf1e(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			this.x47c79a4d207183de();
		}

		// Token: 0x06000023 RID: 35 RVA: 0x000052D0 File Offset: 0x000042D0
		private void x77d9086325b6e538(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			this.Dispose();
		}

		// Token: 0x06000024 RID: 36 RVA: 0x000052D8 File Offset: 0x000042D8
		private void xb27df3b0091b2a36(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			this.xa6607dfd4b3038ad.Font = this.x43bec302f92080b9.Font;
		}

		// Token: 0x04000001 RID: 1
		private const int x77bf04ec211c4a37 = 16;

		// Token: 0x04000002 RID: 2
		private const int x339acab5bf3e83ae = 64;

		// Token: 0x04000003 RID: 3
		private const int xdbb7427772b219d6 = 128;

		// Token: 0x04000004 RID: 4
		private const int xb644deafcaa222c4 = 2;

		// Token: 0x04000005 RID: 5
		private const int xb8a822e576f3bf60 = 1;

		// Token: 0x04000006 RID: 6
		private Control x43bec302f92080b9;

		// Token: 0x04000007 RID: 7
		private bool x364c1e3b189d47fe;

		// Token: 0x04000008 RID: 8
		private bool xeefb7b23d49f09bc = true;

		// Token: 0x04000009 RID: 9
		private bool x0e75cd3866dbb930;

		// Token: 0x0400000A RID: 10
		private Point xa639e9f791585165;

		// Token: 0x0400000B RID: 11
		private xf8f9565783602018.xab7df35839b7399e xa6607dfd4b3038ad;

		// Token: 0x0400000C RID: 12
		private Timer x537a4001020fd4c7;

		// Token: 0x0400000D RID: 13
		private Form x9238f6a5f034aeb5;

		// Token: 0x02000004 RID: 4
		private class xab7df35839b7399e : Form
		{
			// Token: 0x06000025 RID: 37
			[DllImport("user32.dll")]
			private static extern bool SystemParametersInfo(int nAction, int nParam, ref int i, int nUpdate);

			// Token: 0x06000026 RID: 38 RVA: 0x000052F0 File Offset: 0x000042F0
			public xab7df35839b7399e(xf8f9565783602018 tooltips)
			{
				this.xac1c850120b1f254 = tooltips;
				for (;;)
				{
					base.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
					for (;;)
					{
						this.Font = tooltips.x43bec302f92080b9.Font;
						this.xae3b2752a89e7464 = (TextFormatFlags.NoClipping | TextFormatFlags.VerticalCenter);
						base.ShowInTaskbar = false;
						base.FormBorderStyle = FormBorderStyle.None;
						base.ControlBox = false;
						base.StartPosition = FormStartPosition.Manual;
						if (!true)
						{
							break;
						}
						if (-2 != 0)
						{
							return;
						}
					}
				}
			}

			// Token: 0x17000009 RID: 9
			// (get) Token: 0x06000027 RID: 39 RVA: 0x00005364 File Offset: 0x00004364
			// (set) Token: 0x06000028 RID: 40 RVA: 0x0000537C File Offset: 0x0000437C
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
						do
						{
							this.xae3b2752a89e7464 |= TextFormatFlags.HidePrefix;
						}
						while (false);
						this.xae3b2752a89e7464 &= ~TextFormatFlags.NoPrefix;
						return;
					}
					this.xae3b2752a89e7464 &= ~TextFormatFlags.HidePrefix;
					this.xae3b2752a89e7464 |= TextFormatFlags.NoPrefix;
				}
			}

			// Token: 0x06000029 RID: 41 RVA: 0x000053D8 File Offset: 0x000043D8
			public SizeF x0a8f2a18d3b53839(string xb41faee6912a2313)
			{
				SizeF result;
				using (Graphics graphics = base.CreateGraphics())
				{
					VisualStyleElement normal = VisualStyleElement.ToolTip.Standard.Normal;
					for (;;)
					{
						while (Application.RenderWithVisualStyles)
						{
							if (!VisualStyleRenderer.IsElementDefined(normal))
							{
								if (2147483647 != 0)
								{
									break;
								}
								if (!false)
								{
									if (!false)
									{
										break;
									}
								}
							}
							else
							{
								VisualStyleRenderer visualStyleRenderer = new VisualStyleRenderer(normal);
								Rectangle textExtent = visualStyleRenderer.GetTextExtent(graphics, xb41faee6912a2313, TextFormatFlags.Default);
								result = visualStyleRenderer.GetBackgroundExtent(graphics, textExtent).Size;
								if (!false)
								{
									goto Block_8;
								}
							}
						}
						break;
					}
					IL_15:
					SizeF result2 = TextRenderer.MeasureText(graphics, xb41faee6912a2313, this.Font, new Size(SystemInformation.PrimaryMonitorSize.Width, int.MaxValue), this.xae3b2752a89e7464);
					result2.Width -= 2f;
					if (true)
					{
						result2.Height += 2f;
					}
					return result2;
					goto IL_15;
					Block_8:;
				}
				return result;
			}

			// Token: 0x1700000A RID: 10
			// (get) Token: 0x0600002A RID: 42 RVA: 0x000054F8 File Offset: 0x000044F8
			protected override CreateParams CreateParams
			{
				get
				{
					CreateParams createParams = base.CreateParams;
					IL_40:
					while (this.xac1c850120b1f254 != null)
					{
						while (this.xac1c850120b1f254.xa6e4f463e64a5987)
						{
							if (!xf8f9565783602018.xab7df35839b7399e.x3b1aa41797c18588)
							{
								if (false)
								{
									if (3 == 0)
									{
										goto IL_40;
									}
									if (-1 != 0)
									{
										continue;
									}
									if (4 != 0)
									{
									}
								}
							}
							else
							{
								createParams.ClassStyle |= 131072;
							}
							break;
						}
						return createParams;
					}
					return createParams;
				}
			}

			// Token: 0x1700000B RID: 11
			// (get) Token: 0x0600002B RID: 43 RVA: 0x0000556C File Offset: 0x0000456C
			private static bool x3b1aa41797c18588
			{
				get
				{
					int num = 0;
					while (xf8f9565783602018.x7fb2e1ce54a27086())
					{
						bool flag = (uint)num + (uint)num > uint.MaxValue;
						if (!flag)
						{
							if (false && ((uint)num | 255U) == 0U)
							{
								continue;
							}
							xf8f9565783602018.xab7df35839b7399e.SystemParametersInfo(4132, 0, ref num, 0);
						}
						return Convert.ToBoolean(num);
					}
					return false;
				}
			}

			// Token: 0x0600002C RID: 44 RVA: 0x000055D4 File Offset: 0x000045D4
			protected override void Dispose(bool disposing)
			{
				base.Dispose(disposing);
			}

			// Token: 0x0600002D RID: 45 RVA: 0x000055E0 File Offset: 0x000045E0
			protected override void OnPaint(PaintEventArgs e)
			{
				VisualStyleElement normal = VisualStyleElement.ToolTip.Standard.Normal;
				if (false)
				{
					goto IL_1D9;
				}
				goto IL_2D2;
				IL_C4:
				Rectangle clientRectangle;
				TextRenderer.DrawText(e.Graphics, this.Text, this.Font, clientRectangle, SystemColors.InfoText, this.xae3b2752a89e7464);
				if (-2 == 0)
				{
					goto IL_2D2;
				}
				return;
				IL_F3:
				Pen pen = SystemPens.InfoText;
				IL_F8:
				Pen pen2 = pen;
				e.Graphics.DrawLine(pen2, base.ClientRectangle.Left, base.ClientRectangle.Top, base.ClientRectangle.Right, base.ClientRectangle.Top);
				if (!false)
				{
					e.Graphics.DrawLine(pen2, base.ClientRectangle.Left, base.ClientRectangle.Top, base.ClientRectangle.Left, base.ClientRectangle.Bottom);
					e.Graphics.DrawLine(SystemPens.InfoText, base.ClientRectangle.Left, base.ClientRectangle.Bottom - 1, base.ClientRectangle.Right, base.ClientRectangle.Bottom - 1);
					e.Graphics.DrawLine(SystemPens.InfoText, base.ClientRectangle.Right - 1, base.ClientRectangle.Top, base.ClientRectangle.Right - 1, base.ClientRectangle.Bottom);
					clientRectangle = base.ClientRectangle;
					clientRectangle.Inflate(-2, -2);
					goto IL_C4;
				}
				goto IL_1B6;
				IL_194:
				pen = SystemPens.Control;
				goto IL_F8;
				IL_1A8:
				if (SystemInformation.HighContrast)
				{
					goto IL_F3;
				}
				goto IL_194;
				IL_1B6:
				e.Graphics.FillRectangle(SystemBrushes.Info, base.ClientRectangle);
				if (false)
				{
					goto IL_194;
				}
				goto IL_1A8;
				IL_1D9:
				if (!VisualStyleRenderer.IsElementDefined(normal))
				{
					goto IL_1B6;
				}
				VisualStyleRenderer visualStyleRenderer = new VisualStyleRenderer(normal);
				visualStyleRenderer.DrawBackground(e.Graphics, base.ClientRectangle);
				Rectangle textExtent = visualStyleRenderer.GetTextExtent(e.Graphics, base.ClientRectangle, this.Text, this.xae3b2752a89e7464);
				if (!false)
				{
					textExtent.X = base.ClientRectangle.X + base.ClientRectangle.Width / 2 - textExtent.Width / 2;
					textExtent.Y = base.ClientRectangle.Y + base.ClientRectangle.Height / 2 - textExtent.Height / 2;
					do
					{
						visualStyleRenderer.DrawText(e.Graphics, textExtent, this.Text, false, this.xae3b2752a89e7464);
						if (-1 == 0)
						{
							goto IL_C4;
						}
					}
					while (4 == 0);
					return;
				}
				return;
				IL_2D2:
				if (!false)
				{
					if (Application.RenderWithVisualStyles)
					{
						goto IL_1D9;
					}
					goto IL_1B6;
				}
				else
				{
					if (3 != 0 && !false)
					{
						goto IL_F3;
					}
					goto IL_1A8;
				}
			}

			// Token: 0x0400000F RID: 15
			private const int x3e8b9d6faeff6586 = 32;

			// Token: 0x04000010 RID: 16
			private const int x2b7f5d3ca7ec1edf = -2147483648;

			// Token: 0x04000011 RID: 17
			private const int xd708511d2241a4fb = 131072;

			// Token: 0x04000012 RID: 18
			private const int x836e53e090609b16 = 4132;

			// Token: 0x04000013 RID: 19
			private xf8f9565783602018 xac1c850120b1f254;

			// Token: 0x04000014 RID: 20
			private TextFormatFlags xae3b2752a89e7464;
		}

		// Token: 0x02000022 RID: 34
		// (Invoke) Token: 0x0600032A RID: 810
		internal delegate string x58986a4a0b75e5b5(Point location);
	}
}
