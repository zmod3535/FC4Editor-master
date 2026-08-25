using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Divelements.Util.Registration;
using TD.SandDock.Rendering;

namespace TD.SandDock
{
	// Token: 0x02000061 RID: 97
	[LicenseProvider(typeof(x294bd621a33dc533))]
	[Designer("TD.SandDock.Design.TabControlDesigner, SandDock.Design, Version=1.0.0.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3")]
	[DefaultEvent("SelectedPageChanged")]
	[ToolboxItem(true)]
	[ToolboxBitmap(typeof(TabControl))]
	[DefaultProperty("TabLayout")]
	public class TabControl : Control
	{
		// Token: 0x1400001C RID: 28
		// (add) Token: 0x06000544 RID: 1348 RVA: 0x00027E30 File Offset: 0x00026E30
		// (remove) Token: 0x06000545 RID: 1349 RVA: 0x00027E4C File Offset: 0x00026E4C
		public event EventHandler SelectedPageChanged
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.x5c05af982a207d77 = (EventHandler)Delegate.Combine(this.x5c05af982a207d77, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.x5c05af982a207d77 = (EventHandler)Delegate.Remove(this.x5c05af982a207d77, value);
			}
		}

		// Token: 0x06000546 RID: 1350 RVA: 0x00027E68 File Offset: 0x00026E68
		public TabControl()
		{
			if (!false)
			{
				this.x266365ea27fa7af8 = (LicenseManager.Validate(typeof(TabControl), this) as xbd7c5470fc89975b);
				if (false)
				{
					return;
				}
				goto IL_81;
			}
			IL_1D:
			this.x5d56ae798b9cdf38.Interval = 20;
			if (!false)
			{
				this.x5d56ae798b9cdf38.Tick += this.xcaf19fd9570f4eb4;
				return;
			}
			IL_81:
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
			base.SetStyle(ControlStyles.Selectable, true);
			base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			this.x38870620fd380a6b = new MilborneRenderer();
			this.xc13824d17c0efae4 = new TabControl.TabPageCollection(this);
			this.x49dae83181e41d72 = new x0a9f5257a10031b2();
			this.xa8ae81960654bc0b = new x0a9f5257a10031b2();
			this.x5d56ae798b9cdf38 = new Timer();
			goto IL_1D;
		}

		// Token: 0x06000547 RID: 1351 RVA: 0x00027F3C File Offset: 0x00026F3C
		protected override Control.ControlCollection CreateControlsInstance()
		{
			return new TabControl.x9e8d5fa1ed8fe66b(this);
		}

		// Token: 0x06000548 RID: 1352 RVA: 0x00027F44 File Offset: 0x00026F44
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (false)
				{
					goto IL_81;
				}
				goto IL_4B;
				IL_14:
				while ((disposing ? 1U : 0U) >= 0U)
				{
					if (((disposing ? 1U : 0U) | 2147483647U) != 0U)
					{
						goto IL_3E;
					}
				}
				goto IL_6A;
				IL_3E:
				this.x5d56ae798b9cdf38.Dispose();
				goto IL_08;
				IL_4B:
				if (this.x38870620fd380a6b is IDisposable)
				{
					goto IL_81;
				}
				bool flag = (disposing ? 1U : 0U) < 0U;
				if (!flag)
				{
					goto IL_14;
				}
				IL_6A:
				if ((disposing ? 1U : 0U) >= 0U)
				{
					goto IL_3E;
				}
				goto IL_4B;
				IL_81:
				((IDisposable)this.x38870620fd380a6b).Dispose();
				if (8 != 0)
				{
					goto IL_6A;
				}
				if (4 == 0)
				{
					goto IL_14;
				}
				goto IL_4B;
			}
			IL_08:
			base.Dispose(disposing);
		}

		// Token: 0x06000549 RID: 1353 RVA: 0x00027FFC File Offset: 0x00026FFC
		protected override void OnPaint(PaintEventArgs e)
		{
			this.Renderer.StartRenderSession(this.ShowKeyboardCues ? HotkeyPrefix.Show : HotkeyPrefix.Hide);
			DockControl.xe1da469e4d960f02(this, e.Graphics, this.xacfbd7a08ba56c78);
			this.x38870620fd380a6b.DrawTabControlTabStripBackground(e.Graphics, this.xd2fe3b65e7e0ab37, this.BackColor);
			Region clip = null;
			for (;;)
			{
				if (this.TabLayout != TabLayout.SingleLineScrollable)
				{
					goto IL_271;
				}
				clip = e.Graphics.Clip;
				Rectangle clip2 = this.xd2fe3b65e7e0ab37;
				int i;
				if ((uint)i - (uint)i > 4294967295U)
				{
					goto IL_4D;
				}
				clip2.Width -= this.xd2fe3b65e7e0ab37.Right - this.x49dae83181e41d72.xda73fcb97c77d998.Left;
				e.Graphics.SetClip(clip2);
				if (3 == 0)
				{
					goto IL_2D1;
				}
				goto IL_271;
				IL_207:
				if (this.SelectedPage != null)
				{
					this.xc33f5f7a18a754cb(e.Graphics, this.SelectedPage);
					bool flag = (uint)i - (uint)i > uint.MaxValue;
					if (flag)
					{
						goto IL_33B;
					}
				}
				IL_1D8:
				if (this.TabLayout != TabLayout.SingleLineScrollable)
				{
					if (false)
					{
						continue;
					}
					if (!false)
					{
						if (false)
						{
							goto IL_EF;
						}
						goto IL_104;
					}
				}
				else
				{
					e.Graphics.Clip = clip;
				}
				IL_1EB:
				if ((uint)i - (uint)i < 0U)
				{
					goto IL_1D8;
				}
				if ((uint)i - (uint)i <= 4294967295U)
				{
					goto IL_104;
				}
				if (((uint)i & 0U) != 0U)
				{
					goto IL_271;
				}
				goto IL_27A;
				IL_33B:
				goto IL_1EB;
				IL_2D1:
				this.xe03691727ff38b10(e.Graphics);
				goto IL_207;
				IL_271:
				if (this.TabLayout == TabLayout.MultipleLine)
				{
					goto IL_2D1;
				}
				IL_27A:
				for (i = base.Controls.Count - 1; i >= 0; i--)
				{
					this.xc33f5f7a18a754cb(e.Graphics, (TabPage)base.Controls[i]);
					if ((uint)i > 4294967295U)
					{
						goto IL_21;
					}
				}
				goto IL_207;
				IL_EF:
				if ((uint)i >= 0U)
				{
					goto IL_104;
				}
				goto IL_207;
				IL_E8:
				if (8 == 0)
				{
					goto IL_EF;
				}
				break;
				IL_4D:
				using (SolidBrush solidBrush = new SolidBrush(Color.FromArgb(30, Color.Black)))
				{
					using (Font font = new Font(this.Font.FontFamily.Name, 14f, FontStyle.Bold))
					{
						e.Graphics.DrawString("evaluation", font, solidBrush, (float)(this.xd2fe3b65e7e0ab37.Left + 4), (float)(this.xd2fe3b65e7e0ab37.Top - 4), StringFormat.GenericTypographic);
					}
					break;
				}
				goto IL_E8;
				IL_21:
				if (!this.x266365ea27fa7af8.Evaluation)
				{
					goto IL_E8;
				}
				goto IL_4D;
				IL_104:
				if (this.SelectedPage != null)
				{
					this.x38870620fd380a6b.DrawTabControlBackground(e.Graphics, this.x21ed2ecc088ef4e4, this.SelectedPage.BackColor, false);
					goto IL_35;
				}
				if (2 == 0)
				{
					goto IL_119;
				}
				goto IL_35;
				IL_40:
				this.Renderer.FinishRenderSession();
				goto IL_21;
				IL_119:
				this.xb30ec7cfdf3e5c19(e.Graphics, this.x38870620fd380a6b, this.xa8ae81960654bc0b, SandDockButtonType.ScrollRight, this.xa8ae81960654bc0b.x2fef7d841879a711);
				this.xb30ec7cfdf3e5c19(e.Graphics, this.x38870620fd380a6b, this.x49dae83181e41d72, SandDockButtonType.ScrollLeft, this.x49dae83181e41d72.x2fef7d841879a711);
				goto IL_40;
				IL_35:
				if (this.TabLayout != TabLayout.SingleLineScrollable)
				{
					goto IL_40;
				}
				goto IL_119;
			}
		}

		// Token: 0x0600054A RID: 1354 RVA: 0x000283C0 File Offset: 0x000273C0
		private void xb30ec7cfdf3e5c19(Graphics x41347a961b838962, ITabControlRenderer x38870620fd380a6b, x0a9f5257a10031b2 x128517d7ded59312, SandDockButtonType x271bd5d42b3ea793, bool x2fef7d841879a711)
		{
			if (x128517d7ded59312.x364c1e3b189d47fe)
			{
				DrawItemState drawItemState = DrawItemState.Default;
				if (this.x1f43ebe301d1df45 != x128517d7ded59312)
				{
					goto IL_25;
				}
				drawItemState |= DrawItemState.HotLight;
				bool flag = (x2fef7d841879a711 ? 1U : 0U) + (x2fef7d841879a711 ? 1U : 0U) < 0U;
				if (flag)
				{
					goto IL_D4;
				}
				goto IL_87;
				IL_10:
				x38870620fd380a6b.DrawTabControlButton(x41347a961b838962, x128517d7ded59312.xda73fcb97c77d998, x271bd5d42b3ea793, drawItemState);
				return;
				IL_25:
				if (x2fef7d841879a711)
				{
					flag = ((x2fef7d841879a711 ? 1U : 0U) + (x2fef7d841879a711 ? 1U : 0U) > uint.MaxValue);
					if (flag)
					{
						goto IL_61;
					}
					goto IL_A1;
				}
				IL_43:
				drawItemState |= DrawItemState.Disabled;
				flag = ((x2fef7d841879a711 ? 1U : 0U) - (x2fef7d841879a711 ? 1U : 0U) > uint.MaxValue);
				if (!flag)
				{
					goto IL_10;
				}
				if (4 == 0)
				{
					goto IL_A1;
				}
				goto IL_25;
				IL_61:
				if ((x2fef7d841879a711 ? 1U : 0U) >= 0U)
				{
					if ((x2fef7d841879a711 ? 1U : 0U) <= 4294967295U)
					{
						goto IL_25;
					}
					goto IL_43;
				}
				IL_87:
				if (this.xfa5e20eb950b9ee1)
				{
					goto IL_D4;
				}
				if (false)
				{
					goto IL_43;
				}
				goto IL_25;
				IL_A1:
				goto IL_10;
				IL_D4:
				drawItemState |= DrawItemState.Selected;
				goto IL_61;
			}
		}

		// Token: 0x0600054B RID: 1355 RVA: 0x000284AC File Offset: 0x000274AC
		private void xe03691727ff38b10(Graphics x41347a961b838962)
		{
			ArrayList arrayList = new ArrayList();
			IEnumerator enumerator = base.Controls.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					TabPage tabPage = (TabPage)obj;
					if (!arrayList.Contains(tabPage.xa806b754814b9ae0))
					{
						arrayList.Add(tabPage.xa806b754814b9ae0);
					}
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				for (;;)
				{
					if (2147483647 != 0)
					{
						goto IL_1CE;
					}
					IL_1C5:
					disposable.Dispose();
					int i;
					bool flag = ((uint)i & 0U) == 0U;
					if (flag)
					{
						if (8 == 0)
						{
							continue;
						}
						break;
					}
					IL_1CE:
					if (disposable == null)
					{
						break;
					}
					goto IL_1C5;
				}
			}
			int[] array = (int[])arrayList.ToArray(typeof(int));
			Array.Sort<int>(array);
			for (int i = 0; i < array.Length; i++)
			{
				int j = base.Controls.Count - 1;
				while (j >= 0)
				{
					for (;;)
					{
						TabPage tabPage2 = (TabPage)base.Controls[j];
						if (false)
						{
							goto IL_143;
						}
						if (tabPage2.xa806b754814b9ae0 != array[i])
						{
							break;
						}
						this.xc33f5f7a18a754cb(x41347a961b838962, tabPage2);
						if ((uint)j - (uint)j > 4294967295U)
						{
							break;
						}
						IL_105:
						Rectangle x123e054dab;
						if (i >= array.Length - 1)
						{
							if ((uint)i >= 0U)
							{
								break;
							}
							continue;
						}
						else
						{
							x123e054dab = tabPage2.x123e054dab107457;
							x123e054dab.X = this.xd2fe3b65e7e0ab37.X;
						}
						IL_143:
						x123e054dab.Width = this.xd2fe3b65e7e0ab37.Width;
						for (;;)
						{
							x123e054dab.Y = x123e054dab.Bottom - 1;
							x123e054dab.Height = this.x21ed2ecc088ef4e4.Y - x123e054dab.Y - 2;
							bool flag = ((uint)j & 0U) == 0U;
							if (!flag)
							{
								goto IL_105;
							}
							this.x38870620fd380a6b.DrawFakeTabControlBackgroundExtension(x41347a961b838962, x123e054dab, tabPage2.BackColor);
							flag = (((uint)j & 0U) == 0U);
							if (flag)
							{
								goto Block_4;
							}
						}
					}
					IL_2B:
					j--;
					continue;
					Block_4:
					goto IL_2B;
				}
			}
		}

		// Token: 0x0600054C RID: 1356 RVA: 0x000286E8 File Offset: 0x000276E8
		private void xc33f5f7a18a754cb(Graphics x41347a961b838962, TabPage xbbe2f7d7c86e0379)
		{
			DrawItemState drawItemState = DrawItemState.Default;
			IL_61:
			while (xbbe2f7d7c86e0379 == this.SelectedPage)
			{
				do
				{
					drawItemState |= DrawItemState.Selected;
					if (!this.Focused)
					{
						break;
					}
					if (this.ShowFocusCues)
					{
						goto IL_57;
					}
					if (false)
					{
						goto IL_61;
					}
				}
				while (!true);
				break;
				IL_57:
				drawItemState |= DrawItemState.Checked;
				break;
			}
			this.Renderer.DrawTabControlTab(x41347a961b838962, xbbe2f7d7c86e0379.x123e054dab107457, xbbe2f7d7c86e0379.TabImage, xbbe2f7d7c86e0379.Text, this.Font, xbbe2f7d7c86e0379.BackColor, xbbe2f7d7c86e0379.ForeColor, drawItemState, true);
		}

		// Token: 0x0600054D RID: 1357 RVA: 0x00028768 File Offset: 0x00027768
		protected override void OnLayout(LayoutEventArgs levent)
		{
			if (this.x38c1fce82bb0e828.Width <= 0 || this.x38c1fce82bb0e828.Height <= 0)
			{
				return;
			}
			foreach (object obj in base.Controls)
			{
				Control control = (Control)obj;
				control.Bounds = this.x38c1fce82bb0e828;
			}
		}

		// Token: 0x0600054E RID: 1358 RVA: 0x000287F4 File Offset: 0x000277F4
		protected override void OnResize(EventArgs e)
		{
			this.x436f6f3ee14607e0();
			base.OnResize(e);
		}

		// Token: 0x0600054F RID: 1359 RVA: 0x00028804 File Offset: 0x00027804
		protected override void OnControlAdded(ControlEventArgs e)
		{
			base.OnControlAdded(e);
			this.x436f6f3ee14607e0();
			base.PerformLayout();
		}

		// Token: 0x06000550 RID: 1360 RVA: 0x0002881C File Offset: 0x0002781C
		protected override void OnControlRemoved(ControlEventArgs e)
		{
			base.OnControlRemoved(e);
			for (;;)
			{
				if (!false)
				{
					if (2 == 0)
					{
						goto IL_53;
					}
					if (this.SelectedPage != e.Control)
					{
						break;
					}
				}
				if (this.TabPages.Count != 0)
				{
					goto IL_3F;
				}
				if (!false)
				{
					goto IL_71;
				}
			}
			IL_19:
			this.x436f6f3ee14607e0();
			base.PerformLayout();
			return;
			IL_27:
			this.x980c1bf410aee986 = null;
			this.OnSelectedPageChanged(EventArgs.Empty);
			goto IL_19;
			IL_3F:
			this.SelectedPage = this.TabPages[0];
			goto IL_19;
			IL_53:
			IL_71:
			goto IL_27;
		}

		// Token: 0x06000551 RID: 1361 RVA: 0x000288A4 File Offset: 0x000278A4
		internal void x436f6f3ee14607e0()
		{
			if (base.IsHandleCreated)
			{
				ITabControlRenderer renderer = this.Renderer;
				if (4 != 0)
				{
					int num2;
					using (Graphics graphics = base.CreateGraphics())
					{
						renderer.StartRenderSession(HotkeyPrefix.Hide);
						using (IEnumerator enumerator = base.Controls.GetEnumerator())
						{
							for (;;)
							{
								TabPage tabPage;
								if (!enumerator.MoveNext())
								{
									if (false)
									{
										goto IL_33C;
									}
									break;
								}
								else
								{
									tabPage = (TabPage)enumerator.Current;
									tabPage.xcfac6723d8a41375 = false;
									DrawItemState state = (tabPage != this.SelectedPage) ? DrawItemState.Default : DrawItemState.Selected;
									tabPage.x9b0739496f8b5475 = (double)renderer.MeasureTabControlTab(graphics, tabPage.TabImage, tabPage.Text, this.Font, state).Width;
									int num;
									bool flag = (uint)num - (uint)num2 > uint.MaxValue;
									if (flag)
									{
										goto IL_33C;
									}
									if (tabPage.MaximumTabWidth == 0)
									{
										continue;
									}
								}
								IL_31C:
								if ((double)tabPage.MaximumTabWidth >= tabPage.x9b0739496f8b5475)
								{
									continue;
								}
								goto IL_350;
								IL_33C:
								int num3;
								if (((uint)num3 & 0U) == 0U)
								{
									goto IL_31C;
								}
								IL_350:
								tabPage.x9b0739496f8b5475 = (double)tabPage.MaximumTabWidth;
								if (255 == 0)
								{
									break;
								}
								tabPage.xcfac6723d8a41375 = true;
							}
						}
						renderer.FinishRenderSession();
					}
					TabLayout tabLayout = this.TabLayout;
					for (;;)
					{
						IL_C8:
						if (tabLayout != TabLayout.MultipleLine)
						{
							this.xd2fe3b65e7e0ab37 = this.DisplayRectangle;
							this.xd2fe3b65e7e0ab37.Height = renderer.TabControlTabStripHeight;
							goto IL_ED;
						}
						Rectangle displayRectangle = this.DisplayRectangle;
						goto IL_2B3;
						IL_8A:
						this.x38c1fce82bb0e828 = this.x21ed2ecc088ef4e4;
						this.x38c1fce82bb0e828.Inflate(-renderer.TabControlPadding.Width, -renderer.TabControlPadding.Height);
						if (!true)
						{
							continue;
						}
						int width;
						bool flag = (uint)width < 0U;
						if (!flag)
						{
							break;
						}
						flag = ((uint)num2 - (uint)num2 < 0U);
						if (flag)
						{
							goto IL_2B3;
						}
						return;
						IL_ED:
						this.x21ed2ecc088ef4e4 = this.DisplayRectangle;
						this.x21ed2ecc088ef4e4.Offset(0, this.xd2fe3b65e7e0ab37.Height);
						this.x21ed2ecc088ef4e4.Height = this.x21ed2ecc088ef4e4.Height - this.xd2fe3b65e7e0ab37.Height;
						goto IL_8A;
						IL_2B3:
						width = displayRectangle.Width;
						while ((uint)width >= 0U)
						{
							int num3 = 1;
							int num = 0;
							IEnumerator enumerator2 = base.Controls.GetEnumerator();
							try
							{
								for (;;)
								{
									if (enumerator2.MoveNext())
									{
										goto IL_1E1;
									}
									if ((uint)num2 + (uint)num3 <= 4294967295U)
									{
										break;
									}
									if (-2 == 0)
									{
										break;
									}
									flag = (((uint)width | 2147483648U) == 0U);
									if (flag)
									{
										goto IL_1E1;
									}
									if (-2 == 0)
									{
										break;
									}
									IL_154:
									TabPage tabPage2;
									while (num != (int)tabPage2.x9b0739496f8b5475)
									{
										num3++;
										num = (int)tabPage2.x9b0739496f8b5475;
										if ((uint)width + (uint)width >= 0U)
										{
											break;
										}
									}
									IL_17A:
									num -= renderer.TabControlTabExtra;
									continue;
									IL_1E1:
									tabPage2 = (TabPage)enumerator2.Current;
									num += (int)tabPage2.x9b0739496f8b5475;
									if (num > width)
									{
										goto IL_154;
									}
									goto IL_17A;
								}
							}
							finally
							{
								IDisposable disposable2 = enumerator2 as IDisposable;
								flag = ((uint)num2 + (uint)num2 > uint.MaxValue);
								if (flag || disposable2 != null)
								{
									disposable2.Dispose();
								}
							}
							num2 = (renderer.TabControlTabHeight - 2) * num3 + (renderer.TabControlTabStripHeight - renderer.TabControlTabHeight);
							num2 += 2;
							this.xd2fe3b65e7e0ab37 = this.DisplayRectangle;
							flag = (((uint)width | 4U) == 0U);
							if (flag)
							{
								goto IL_C8;
							}
							do
							{
								this.xd2fe3b65e7e0ab37.Height = num2;
							}
							while ((uint)width - (uint)width < 0U);
							if ((uint)num >= 0U)
							{
								goto IL_ED;
							}
						}
						goto IL_8A;
					}
					switch (this.TabLayout)
					{
					case TabLayout.SingleLineScrollable:
						this.xac46da8e3ebf1367();
						break;
					case TabLayout.SingleLineFixed:
						this.x9ad45a8b0cdc25f7();
						break;
					case TabLayout.MultipleLine:
						this.xad3ea5eacdd3e808();
						break;
					}
				}
				IL_26:
				base.Invalidate(renderer.ShouldDrawTabControlBackground);
				return;
				goto IL_26;
			}
		}

		// Token: 0x06000552 RID: 1362 RVA: 0x00028D28 File Offset: 0x00027D28
		private void xad3ea5eacdd3e808()
		{
			ArrayList arrayList = new ArrayList();
			int num;
			if (((uint)num | 2147483647U) == 0U)
			{
				goto IL_1C7;
			}
			Rectangle displayRectangle = this.DisplayRectangle;
			bool flag;
			bool flag2;
			ArrayList arrayList2;
			ArrayList arrayList3;
			int num2;
			bool flag3;
			int num3;
			int num4;
			if ((flag ? 1U : 0U) + (flag2 ? 1U : 0U) <= 4294967295U)
			{
				int width = displayRectangle.Width;
				arrayList2 = null;
				arrayList3 = new ArrayList();
				num2 = this.xd2fe3b65e7e0ab37.Left;
				flag = false;
				using (IEnumerator enumerator = base.Controls.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						TabPage tabPage;
						for (;;)
						{
							tabPage = (TabPage)enumerator.Current;
							if (arrayList3.Count != 0)
							{
								goto IL_32C;
							}
							flag3 = ((uint)num - (uint)num2 < 0U);
							if (flag3)
							{
								goto IL_3B0;
							}
							flag3 = ((uint)num3 + (uint)num4 > uint.MaxValue);
							if (flag3 || flag)
							{
								goto IL_32C;
							}
							bool flag4 = true;
							IL_34E:
							flag2 = flag4;
							if (((uint)num4 & 0U) == 0U && !flag2)
							{
								goto Block_22;
							}
							arrayList3.Add(tabPage);
							flag3 = ((flag2 ? 1U : 0U) < 0U);
							if (flag3)
							{
								continue;
							}
							goto IL_3B0;
							IL_32C:
							flag4 = ((double)num2 + tabPage.x9b0739496f8b5475 <= (double)this.xd2fe3b65e7e0ab37.Right);
							goto IL_34E;
						}
						IL_220:
						num2 += (int)tabPage.x9b0739496f8b5475 - this.x38870620fd380a6b.TabControlTabExtra;
						continue;
						IL_202:
						if ((flag ? 1U : 0U) >= 0U)
						{
							goto IL_220;
						}
						goto IL_2A4;
						IL_1F5:
						if (this.SelectedPage != tabPage)
						{
							goto IL_202;
						}
						arrayList2 = arrayList3;
						goto IL_220;
						IL_2A4:
						arrayList.Add(arrayList3);
						do
						{
							arrayList3 = new ArrayList();
						}
						while ((uint)num2 - (flag2 ? 1U : 0U) > 4294967295U);
						num2 = this.xd2fe3b65e7e0ab37.Left;
						arrayList3.Add(tabPage);
						if ((flag ? 1U : 0U) + (uint)num2 < 0U)
						{
							goto IL_1F5;
						}
						if (this.SelectedPage != tabPage)
						{
							goto IL_220;
						}
						arrayList2 = arrayList3;
						flag3 = ((uint)num3 + (flag2 ? 1U : 0U) < 0U);
						if (flag3)
						{
							if ((flag ? 1U : 0U) + (uint)num2 > 4294967295U)
							{
								goto IL_202;
							}
							flag3 = ((uint)num2 + (uint)num2 > uint.MaxValue);
							if (flag3)
							{
								IL_29F:
								goto IL_1AB;
							}
							goto IL_1F5;
						}
						else
						{
							if (2 != 0)
							{
								goto IL_220;
							}
							goto IL_1F5;
						}
						Block_22:
						goto IL_2A4;
						IL_3B0:
						goto IL_1F5;
					}
					goto IL_29F;
				}
				goto IL_3DE;
			}
			goto IL_1B3;
			IL_13:
			num4 = this.xd2fe3b65e7e0ab37.Top + (this.x38870620fd380a6b.TabControlTabStripHeight - this.x38870620fd380a6b.TabControlTabHeight);
			IEnumerator enumerator2 = arrayList.GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					object obj = enumerator2.Current;
					ArrayList arrayList4 = (ArrayList)obj;
					num3 = arrayList.IndexOf(arrayList4);
					if (arrayList.Count > 1)
					{
						this.xd022f7303b745a62(arrayList4, true);
					}
					num2 = this.xd2fe3b65e7e0ab37.Left;
					IEnumerator enumerator3 = arrayList4.GetEnumerator();
					try
					{
						while (enumerator3.MoveNext())
						{
							object obj2 = enumerator3.Current;
							TabPage tabPage2 = (TabPage)obj2;
							tabPage2.xa806b754814b9ae0 = num3;
							if ((uint)num3 + (uint)num4 <= 4294967295U)
							{
								num = (int)Math.Round(tabPage2.x9b0739496f8b5475, 0);
							}
							tabPage2.x123e054dab107457 = new Rectangle(num2, num4, num, this.x38870620fd380a6b.TabControlTabHeight);
							num2 += num - this.x38870620fd380a6b.TabControlTabExtra;
						}
					}
					finally
					{
						IDisposable disposable2 = enumerator3 as IDisposable;
						while (disposable2 != null)
						{
							disposable2.Dispose();
							flag3 = ((uint)num + (flag ? 1U : 0U) < 0U);
							if (!flag3)
							{
								break;
							}
						}
					}
					num4 += this.x38870620fd380a6b.TabControlTabHeight - 2;
				}
				return;
			}
			finally
			{
				IDisposable disposable3 = enumerator2 as IDisposable;
				flag3 = ((uint)num3 + (uint)num < 0U);
				if (flag3 || disposable3 != null)
				{
					disposable3.Dispose();
				}
			}
			IL_1AB:
			if (arrayList3.Count != 0)
			{
				goto IL_1C7;
			}
			IL_1B3:
			if (arrayList2 != null)
			{
				arrayList.Remove(arrayList2);
				goto IL_3DE;
			}
			goto IL_13;
			IL_1C7:
			arrayList.Add(arrayList3);
			goto IL_1B3;
			IL_3DE:
			flag3 = ((uint)num2 < 0U);
			if (!flag3)
			{
				arrayList.Add(arrayList2);
				goto IL_13;
			}
		}

		// Token: 0x06000553 RID: 1363 RVA: 0x000291C8 File Offset: 0x000281C8
		private void xac46da8e3ebf1367()
		{
			int y = this.xd2fe3b65e7e0ab37.Top + this.xd2fe3b65e7e0ab37.Height / 2 - 7;
			int num;
			int num2;
			int num3;
			bool flag;
			for (;;)
			{
				num = this.xd2fe3b65e7e0ab37.Right - 2;
				this.xa8ae81960654bc0b.x364c1e3b189d47fe = true;
				if (4 == 0)
				{
					return;
				}
				if (((uint)num2 | 2U) == 0U)
				{
					break;
				}
				this.xa8ae81960654bc0b.xda73fcb97c77d998 = new Rectangle(num - 14, y, 14, 15);
				num -= 15;
				this.x49dae83181e41d72.x364c1e3b189d47fe = true;
				if (!false)
				{
					this.x49dae83181e41d72.xda73fcb97c77d998 = new Rectangle(num - 14, y, 14, 15);
					for (;;)
					{
						num -= 15;
						num3 = this.xd2fe3b65e7e0ab37.Left;
						flag = ((uint)num3 + (uint)num > uint.MaxValue);
						if (flag)
						{
							break;
						}
						IEnumerator enumerator = base.Controls.GetEnumerator();
						try
						{
							while (enumerator.MoveNext())
							{
								object obj = enumerator.Current;
								TabPage tabPage = (TabPage)obj;
								num2 = (int)Math.Round(tabPage.x9b0739496f8b5475, 0);
								tabPage.x123e054dab107457 = new Rectangle(num3, this.xd2fe3b65e7e0ab37.Bottom - this.x38870620fd380a6b.TabControlTabHeight, num2, this.x38870620fd380a6b.TabControlTabHeight);
								if ((uint)num - (uint)num2 <= 4294967295U)
								{
								}
								num3 += num2 - this.x38870620fd380a6b.TabControlTabExtra;
							}
							goto IL_126;
						}
						finally
						{
							IDisposable disposable = enumerator as IDisposable;
							flag = ((uint)num3 > uint.MaxValue);
							if (flag || disposable != null)
							{
								disposable.Dispose();
							}
						}
					}
				}
			}
			IL_EF:
			this.x4f8ccd50477a481e = 0;
			IL_106:
			int num4;
			if (this.x200b7f5a9d983ba4 <= this.x4f8ccd50477a481e)
			{
				flag = (((uint)num4 | uint.MaxValue) == 0U);
				if (flag)
				{
					goto IL_16E;
				}
			}
			else
			{
				this.x200b7f5a9d983ba4 = this.x4f8ccd50477a481e;
			}
			IL_99:
			this.x49dae83181e41d72.x2fef7d841879a711 = (this.x200b7f5a9d983ba4 > 0);
			this.xa8ae81960654bc0b.x2fef7d841879a711 = (this.x200b7f5a9d983ba4 < this.x4f8ccd50477a481e);
			if (false)
			{
				flag = ((uint)num2 + (uint)num > uint.MaxValue);
				if (flag)
				{
					goto IL_116;
				}
				goto IL_124;
			}
			IL_16E:
			flag = ((uint)num2 < 0U);
			if (flag)
			{
				return;
			}
			using (IEnumerator enumerator2 = base.Controls.GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					object obj2 = enumerator2.Current;
					TabPage tabPage2 = (TabPage)obj2;
					Rectangle x123e054dab = tabPage2.x123e054dab107457;
					do
					{
						x123e054dab.Offset(-this.x200b7f5a9d983ba4, 0);
					}
					while ((uint)num < 0U);
					tabPage2.x123e054dab107457 = x123e054dab;
				}
				return;
			}
			goto IL_99;
			IL_116:
			this.x4f8ccd50477a481e = num3 - num4;
			if (this.x4f8ccd50477a481e < 0)
			{
				goto IL_EF;
			}
			goto IL_106;
			IL_124:
			goto IL_133;
			IL_126:
			if (base.Controls.Count != 0)
			{
				num3 += this.x38870620fd380a6b.TabControlTabExtra;
				flag = ((uint)num4 - (uint)num3 > uint.MaxValue);
				if (flag)
				{
					return;
				}
			}
			IL_133:
			num4 = this.x49dae83181e41d72.xda73fcb97c77d998.Left - this.xd2fe3b65e7e0ab37.Left;
			goto IL_116;
		}

		// Token: 0x06000554 RID: 1364 RVA: 0x00029564 File Offset: 0x00028564
		private void x9ad45a8b0cdc25f7()
		{
			this.xd022f7303b745a62(base.Controls, false);
			int num = this.xd2fe3b65e7e0ab37.Left;
			IEnumerator enumerator = base.Controls.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					TabPage tabPage;
					int num2;
					bool flag;
					do
					{
						tabPage = (TabPage)enumerator.Current;
						num2 = (int)Math.Round(tabPage.x9b0739496f8b5475, 0);
						flag = (((uint)num2 & 0U) == 0U);
					}
					while (!flag);
					tabPage.x123e054dab107457 = new Rectangle(num, this.xd2fe3b65e7e0ab37.Bottom - this.x38870620fd380a6b.TabControlTabHeight, num2, this.x38870620fd380a6b.TabControlTabHeight);
					num += num2 - this.x38870620fd380a6b.TabControlTabExtra;
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				while (disposable != null)
				{
					disposable.Dispose();
					int num2;
					bool flag = (uint)num2 + (uint)num2 < 0U;
					if (!flag && !false)
					{
						break;
					}
				}
			}
		}

		// Token: 0x06000555 RID: 1365 RVA: 0x00029664 File Offset: 0x00028664
		private void xd022f7303b745a62(IList xc06f388a56e1a8e4, bool x12583168cc11d7a7)
		{
			int width = this.xd2fe3b65e7e0ab37.Width;
			double num = 0.0;
			using (IEnumerator enumerator = xc06f388a56e1a8e4.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					TabPage tabPage = (TabPage)obj;
					num += tabPage.x9b0739496f8b5475;
				}
				goto IL_24E;
			}
			goto IL_231;
			for (;;)
			{
				IL_1D3:
				double num2;
				if (num > (double)width)
				{
					num2 = num - (double)width;
					goto IL_192;
				}
				goto IL_16;
				IL_47:
				int i;
				double num4;
				double num5;
				while (i < xc06f388a56e1a8e4.Count)
				{
					TabPage tabPage2 = (TabPage)xc06f388a56e1a8e4[i];
					double num3 = (i != 0) ? (tabPage2.x9b0739496f8b5475 - (double)this.x38870620fd380a6b.TabControlTabExtra) : tabPage2.x9b0739496f8b5475;
					if ((uint)num < 0U)
					{
						goto IL_F9;
					}
					num4 = num3 / num;
					num3 += num5 * num4;
					tabPage2.x9b0739496f8b5475 = ((i == 0) ? num3 : (num3 + (double)this.x38870620fd380a6b.TabControlTabExtra));
					double num6;
					if ((uint)num6 + (uint)num3 > 4294967295U)
					{
						goto IL_1D3;
					}
					if (false)
					{
						goto Block_8;
					}
					i++;
				}
				bool flag = (uint)num4 < 0U;
				if (flag)
				{
					goto IL_16;
				}
				break;
				IL_F9:
				num5 = (double)width - num;
				i = 0;
				goto IL_47;
				IL_16:
				if (!x12583168cc11d7a7)
				{
					break;
				}
				if (num < (double)width)
				{
					goto IL_F9;
				}
				flag = ((uint)num5 - (uint)width > uint.MaxValue);
				if (!flag)
				{
					break;
				}
				IL_192:
				for (int j = 0; j < xc06f388a56e1a8e4.Count; j++)
				{
					TabPage tabPage3 = (TabPage)xc06f388a56e1a8e4[j];
					double num6 = (false || j != 0) ? (tabPage3.x9b0739496f8b5475 - (double)this.x38870620fd380a6b.TabControlTabExtra) : tabPage3.x9b0739496f8b5475;
					if ((uint)i > 4294967295U)
					{
						goto IL_47;
					}
					double num7 = num6 / num;
					num6 -= num2 * num7;
					tabPage3.xcfac6723d8a41375 = true;
					tabPage3.x9b0739496f8b5475 = ((j == 0) ? num6 : (num6 + (double)this.x38870620fd380a6b.TabControlTabExtra));
				}
				return;
			}
			IL_11:
			return;
			Block_8:
			goto IL_11;
			IL_231:
			num -= (double)((xc06f388a56e1a8e4.Count - 1) * this.x38870620fd380a6b.TabControlTabExtra);
			goto IL_1D3;
			IL_24E:
			if (xc06f388a56e1a8e4.Count < 1)
			{
				goto IL_1D3;
			}
			goto IL_231;
		}

		// Token: 0x17000150 RID: 336
		// (get) Token: 0x06000556 RID: 1366 RVA: 0x000298F0 File Offset: 0x000288F0
		// (set) Token: 0x06000557 RID: 1367 RVA: 0x000298F8 File Offset: 0x000288F8
		internal x0a9f5257a10031b2 x1f43ebe301d1df45
		{
			get
			{
				return this.x216b0c2912ae7c6a;
			}
			set
			{
				if (value != this.x216b0c2912ae7c6a)
				{
					if (this.x216b0c2912ae7c6a != null)
					{
						base.Invalidate(this.xd2fe3b65e7e0ab37);
					}
					this.x216b0c2912ae7c6a = value;
					if (this.x216b0c2912ae7c6a != null)
					{
						base.Invalidate(this.xd2fe3b65e7e0ab37);
						if (-2 != 0)
						{
						}
					}
				}
			}
		}

		// Token: 0x06000558 RID: 1368 RVA: 0x0002994C File Offset: 0x0002894C
		private void xd11b6d3bf98020cb()
		{
			this.x5d56ae798b9cdf38.Enabled = false;
			this.x1f43ebe301d1df45 = null;
			this.xfa5e20eb950b9ee1 = false;
			base.Invalidate(this.xd2fe3b65e7e0ab37);
		}

		// Token: 0x06000559 RID: 1369 RVA: 0x00029974 File Offset: 0x00028974
		private void xcf8b319f2bffca87()
		{
			this.x5d56ae798b9cdf38.Enabled = true;
			this.xcaf19fd9570f4eb4(this.x5d56ae798b9cdf38, EventArgs.Empty);
		}

		// Token: 0x0600055A RID: 1370 RVA: 0x00029994 File Offset: 0x00028994
		private void x523c1f22a806032d(int xa00f04d8b3a6664c)
		{
			this.x200b7f5a9d983ba4 += xa00f04d8b3a6664c;
			if (this.x200b7f5a9d983ba4 > this.x4f8ccd50477a481e)
			{
				this.x200b7f5a9d983ba4 = this.x4f8ccd50477a481e;
				this.xd11b6d3bf98020cb();
			}
			if (this.x200b7f5a9d983ba4 < 0)
			{
				this.x200b7f5a9d983ba4 = 0;
				this.xd11b6d3bf98020cb();
				if ((uint)xa00f04d8b3a6664c - (uint)xa00f04d8b3a6664c >= 0U)
				{
				}
			}
			this.x436f6f3ee14607e0();
		}

		// Token: 0x0600055B RID: 1371 RVA: 0x00029A10 File Offset: 0x00028A10
		private void xcaf19fd9570f4eb4(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			if (this.x1f43ebe301d1df45 == this.x49dae83181e41d72)
			{
				this.x523c1f22a806032d(-15);
				return;
			}
			if (this.x1f43ebe301d1df45 == this.xa8ae81960654bc0b)
			{
				this.x523c1f22a806032d(15);
				return;
			}
			this.xd11b6d3bf98020cb();
		}

		// Token: 0x0600055C RID: 1372 RVA: 0x00029A4C File Offset: 0x00028A4C
		protected override void OnHandleCreated(EventArgs e)
		{
			base.OnHandleCreated(e);
			this.x436f6f3ee14607e0();
			base.PerformLayout();
		}

		// Token: 0x0600055D RID: 1373 RVA: 0x00029A64 File Offset: 0x00028A64
		public TabPage GetTabPageAt(Point position)
		{
			using (IEnumerator enumerator = base.Controls.GetEnumerator())
			{
				IL_1C:
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					TabPage tabPage = (TabPage)obj;
					Rectangle x123e054dab = tabPage.x123e054dab107457;
					for (;;)
					{
						while (!x123e054dab.Contains(position))
						{
							if (-2 != 0)
							{
								if (2147483647 != 0)
								{
									goto IL_1C;
								}
								if (!false)
								{
									goto Block_3;
								}
							}
						}
						goto IL_26;
					}
					Block_3:
					continue;
					IL_26:
					return tabPage;
				}
			}
			return null;
		}

		// Token: 0x0600055E RID: 1374 RVA: 0x00029AFC File Offset: 0x00028AFC
		protected override void OnMouseLeave(EventArgs e)
		{
			this.x1f43ebe301d1df45 = null;
			this.xfa5e20eb950b9ee1 = false;
			base.OnMouseLeave(e);
		}

		// Token: 0x0600055F RID: 1375 RVA: 0x00029B14 File Offset: 0x00028B14
		private x0a9f5257a10031b2 x07083a4bfd59263d(int x08db3aeabb253cb1, int x1e218ceaee1bb583)
		{
			if (this.x49dae83181e41d72.x364c1e3b189d47fe && this.x49dae83181e41d72.x2fef7d841879a711)
			{
				if (false || this.x49dae83181e41d72.xda73fcb97c77d998.Contains(x08db3aeabb253cb1, x1e218ceaee1bb583))
				{
					return this.x49dae83181e41d72;
				}
				if (2147483647 != 0)
				{
					if (false)
					{
						goto IL_31;
					}
					if (-1 == 0)
					{
						goto IL_24;
					}
				}
				else
				{
					bool flag = (uint)x1e218ceaee1bb583 > uint.MaxValue;
					if (flag)
					{
						goto IL_5E;
					}
				}
			}
			if (!this.xa8ae81960654bc0b.x364c1e3b189d47fe)
			{
				goto IL_5E;
			}
			IL_24:
			if (this.xa8ae81960654bc0b.x2fef7d841879a711)
			{
				if (this.xa8ae81960654bc0b.xda73fcb97c77d998.Contains(x08db3aeabb253cb1, x1e218ceaee1bb583))
				{
					return this.xa8ae81960654bc0b;
				}
			}
			IL_31:
			IL_5E:
			return null;
		}

		// Token: 0x06000560 RID: 1376 RVA: 0x00029BD0 File Offset: 0x00028BD0
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			while (this.TabLayout == TabLayout.SingleLineScrollable)
			{
				this.x1f43ebe301d1df45 = this.x07083a4bfd59263d(e.X, e.Y);
				if (3 != 0)
				{
					break;
				}
			}
		}

		// Token: 0x06000561 RID: 1377 RVA: 0x00029C04 File Offset: 0x00028C04
		private void x11e90588eb0baaf1(x0a9f5257a10031b2 x128517d7ded59312)
		{
			if (x128517d7ded59312 == this.x49dae83181e41d72 || x128517d7ded59312 == this.xa8ae81960654bc0b)
			{
				this.xcf8b319f2bffca87();
			}
		}

		// Token: 0x06000562 RID: 1378 RVA: 0x00029C20 File Offset: 0x00028C20
		private void xa82f7b310984e03e(x0a9f5257a10031b2 x128517d7ded59312)
		{
			if (x128517d7ded59312 == this.x49dae83181e41d72 || x128517d7ded59312 == this.xa8ae81960654bc0b)
			{
				this.xd11b6d3bf98020cb();
			}
		}

		// Token: 0x06000563 RID: 1379 RVA: 0x00029C40 File Offset: 0x00028C40
		protected override void OnMouseUp(MouseEventArgs e)
		{
			if (this.x266365ea27fa7af8.Locked)
			{
				return;
			}
			for (;;)
			{
				if ((e.Button & MouseButtons.Left) != MouseButtons.Left)
				{
					goto IL_0F;
				}
				if (this.x1f43ebe301d1df45 == null)
				{
					if (15 != 0)
					{
						goto IL_33;
					}
					goto IL_0F;
				}
				else
				{
					this.xa82f7b310984e03e(this.x1f43ebe301d1df45);
					if (!false)
					{
						this.xfa5e20eb950b9ee1 = false;
						if (false)
						{
							break;
						}
						base.Invalidate(this.xd2fe3b65e7e0ab37);
						goto IL_33;
					}
				}
				continue;
				IL_33:
				base.OnMouseUp(e);
				if (3 == 0)
				{
					continue;
				}
				break;
				IL_0F:
				goto IL_33;
			}
		}

		// Token: 0x06000564 RID: 1380 RVA: 0x00029CBC File Offset: 0x00028CBC
		protected override void OnMouseDown(MouseEventArgs e)
		{
			if (this.x266365ea27fa7af8.Locked)
			{
				return;
			}
			if (e.Button == MouseButtons.Left)
			{
				TabPage tabPageAt;
				while (this.x1f43ebe301d1df45 != null)
				{
					this.xfa5e20eb950b9ee1 = true;
					base.Invalidate(this.xd2fe3b65e7e0ab37);
					if (15 != 0)
					{
						if (!false)
						{
							this.x11e90588eb0baaf1(this.x1f43ebe301d1df45);
							return;
						}
						IL_70:
						if (tabPageAt == null)
						{
							goto IL_20;
						}
						while (15 != 0)
						{
							if (this.SelectedPage == tabPageAt)
							{
								IL_2C:
								base.Focus();
								return;
							}
							this.xf8af240c2d768134(tabPageAt, true);
							if (-2147483648 != 0)
							{
								IL_BE:
								if (255 == 0)
								{
									return;
								}
								return;
							}
						}
						if (false)
						{
							goto IL_BE;
						}
						goto IL_2C;
					}
				}
				tabPageAt = this.GetTabPageAt(new Point(e.X, e.Y));
				if (-2 != 0)
				{
					goto IL_70;
				}
				return;
			}
			IL_20:
			base.OnMouseDown(e);
		}

		// Token: 0x06000565 RID: 1381 RVA: 0x00029D94 File Offset: 0x00028D94
		private void xf8af240c2d768134(TabPage xbbe2f7d7c86e0379, bool x17cc8f73454a0462)
		{
			this.SelectedPage = xbbe2f7d7c86e0379;
			bool flag;
			Rectangle rectangle;
			int num;
			do
			{
				if (x17cc8f73454a0462)
				{
					this.SelectedPage.SelectNextControl(null, true, true, true, true);
					flag = ((x17cc8f73454a0462 ? 1U : 0U) - (x17cc8f73454a0462 ? 1U : 0U) < 0U);
					if (flag)
					{
						break;
					}
				}
				if (this.TabLayout != TabLayout.SingleLineScrollable)
				{
					return;
				}
				rectangle = this.xd2fe3b65e7e0ab37;
				rectangle.Width -= this.xd2fe3b65e7e0ab37.Right - this.x49dae83181e41d72.xda73fcb97c77d998.Left;
				flag = ((uint)num + (uint)num < 0U);
			}
			while (flag);
			Rectangle x123e054dab = xbbe2f7d7c86e0379.x123e054dab107457;
			if ((uint)num + (x17cc8f73454a0462 ? 1U : 0U) <= 4294967295U)
			{
				while (rectangle.Contains(x123e054dab))
				{
					if (8 == 0 && 255 != 0)
					{
						if (2 != 0)
						{
							goto IL_60;
						}
						IL_DC:
						if (x123e054dab.Right > rectangle.Right)
						{
							num = x123e054dab.Right - rectangle.Right + 20;
							goto IL_60;
						}
						if (x123e054dab.Left >= rectangle.Left)
						{
							goto IL_60;
						}
						num = x123e054dab.Left - rectangle.Left - 20;
						if (((uint)num & 0U) != 0U)
						{
							goto IL_73;
						}
						goto IL_60;
					}
					else
					{
						if (false)
						{
							goto IL_60;
						}
						flag = ((x17cc8f73454a0462 ? 1U : 0U) > uint.MaxValue);
						if (!flag && ((uint)num | 4294967295U) != 0U)
						{
							return;
						}
					}
				}
				num = 0;
				goto IL_DC;
			}
			IL_60:
			if (num == 0)
			{
				return;
			}
			IL_73:
			this.x523c1f22a806032d(num);
		}

		// Token: 0x06000566 RID: 1382 RVA: 0x00029F48 File Offset: 0x00028F48
		protected override bool IsInputKey(Keys keyData)
		{
			switch (keyData)
			{
			case Keys.Left:
			case Keys.Up:
			case Keys.Right:
			case Keys.Down:
				return true;
			default:
				return base.IsInputKey(keyData);
			}
		}

		// Token: 0x06000567 RID: 1383 RVA: 0x00029F80 File Offset: 0x00028F80
		protected override void OnGotFocus(EventArgs e)
		{
			base.OnGotFocus(e);
			base.Invalidate(this.TabStripBounds);
		}

		// Token: 0x06000568 RID: 1384 RVA: 0x00029F98 File Offset: 0x00028F98
		protected override void OnLostFocus(EventArgs e)
		{
			base.OnLostFocus(e);
			base.Invalidate(this.TabStripBounds);
		}

		// Token: 0x06000569 RID: 1385 RVA: 0x00029FB0 File Offset: 0x00028FB0
		protected override bool ProcessMnemonic(char charCode)
		{
			foreach (object obj in base.Controls)
			{
				TabPage tabPage = (TabPage)obj;
				if (Control.IsMnemonic(charCode, tabPage.Text))
				{
					this.xf8af240c2d768134(tabPage, true);
					return true;
				}
			}
			return base.ProcessMnemonic(charCode);
		}

		// Token: 0x0600056A RID: 1386 RVA: 0x0002A040 File Offset: 0x00029040
		protected override void OnKeyDown(KeyEventArgs e)
		{
			Keys keyCode = e.KeyCode;
			for (;;)
			{
				switch (keyCode)
				{
				case Keys.Left:
					goto IL_67;
				case Keys.Up:
					IL_26:
					if (this.TabLayout == TabLayout.MultipleLine)
					{
						goto IL_3C;
					}
					if (!true)
					{
						continue;
					}
					if (!true)
					{
						goto IL_23;
					}
					if (!false)
					{
						return;
					}
					break;
				case Keys.Right:
					goto IL_32;
				case Keys.Down:
					return;
				default:
					base.OnKeyDown(e);
					goto IL_23;
				}
				IL_13:
				if (15 != 0)
				{
					break;
				}
				goto IL_26;
				IL_23:
				if (false)
				{
					goto IL_26;
				}
				goto IL_13;
			}
			return;
			IL_32:
			this.xa3038751b16f6cc8(1, false, false);
			return;
			IL_3C:
			this.x35cf6ce73d51ebeb(-1, false);
			return;
			IL_67:
			this.xa3038751b16f6cc8(-1, false, false);
		}

		// Token: 0x0600056B RID: 1387 RVA: 0x0002A0C4 File Offset: 0x000290C4
		private void x35cf6ce73d51ebeb(int x23e85093ba3a7d1d, bool x17cc8f73454a0462)
		{
			if (this.SelectedPage != null)
			{
				int num;
				bool flag = ((uint)num & 0U) == 0U;
				int num2;
				if (flag)
				{
					Rectangle x123e054dab = this.SelectedPage.x123e054dab107457;
					num2 = x123e054dab.X + x123e054dab.Width / 2;
					num = this.SelectedPage.xa806b754814b9ae0;
					num += x23e85093ba3a7d1d;
				}
				using (IEnumerator enumerator = base.Controls.GetEnumerator())
				{
					TabPage tabPage;
					for (;;)
					{
						if (!enumerator.MoveNext() && !false)
						{
							flag = (((uint)num2 | 1U) == 0U);
							if (!flag)
							{
								goto IL_CC;
							}
						}
						tabPage = (TabPage)enumerator.Current;
						Rectangle x123e054dab = tabPage.x123e054dab107457;
						if (tabPage.xa806b754814b9ae0 == num)
						{
							if (x123e054dab.X <= num2 && x123e054dab.Right >= num2)
							{
								break;
							}
						}
					}
					this.xf8af240c2d768134(tabPage, x17cc8f73454a0462);
					IL_CC:;
				}
			}
		}

		// Token: 0x0600056C RID: 1388 RVA: 0x0002A1D4 File Offset: 0x000291D4
		private void xa3038751b16f6cc8(int x23e85093ba3a7d1d, bool x17cc8f73454a0462, bool x878956783d1decb2)
		{
			if (this.SelectedPage != null)
			{
				int num = base.Controls.IndexOf(this.SelectedPage);
				num += x23e85093ba3a7d1d;
				if (num > base.Controls.Count - 1)
				{
					num = (x878956783d1decb2 ? 0 : (base.Controls.Count - 1));
				}
				if (num < 0)
				{
					goto IL_99;
				}
				IL_19:
				this.xf8af240c2d768134((TabPage)base.Controls[num], x17cc8f73454a0462);
				if ((x17cc8f73454a0462 ? 1U : 0U) > 4294967295U)
				{
					goto IL_6D;
				}
				bool flag = (uint)x23e85093ba3a7d1d < 0U;
				if (!flag)
				{
					return;
				}
				IL_55:
				flag = (((x878956783d1decb2 ? 1U : 0U) | 2147483647U) == 0U);
				if (!flag && !false)
				{
					goto IL_84;
				}
				IL_6D:
				if ((uint)x23e85093ba3a7d1d > 4294967295U)
				{
					goto IL_99;
				}
				IL_84:
				int num2 = base.Controls.Count - 1;
				IL_91:
				num = num2;
				goto IL_19;
				IL_99:
				if (x878956783d1decb2)
				{
					goto IL_55;
				}
				num2 = 0;
				goto IL_91;
			}
		}

		// Token: 0x0600056D RID: 1389 RVA: 0x0002A2D4 File Offset: 0x000292D4
		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if (false)
			{
				goto IL_1D;
			}
			if (keyData != (Keys.LButton | Keys.Back | Keys.Control))
			{
				goto IL_1D;
			}
			IL_12:
			this.xa3038751b16f6cc8(1, true, true);
			return true;
			IL_1D:
			switch (keyData)
			{
			case Keys.LButton | Keys.Space | Keys.Control:
				break;
			case Keys.RButton | Keys.Space | Keys.Control:
				goto IL_12;
			default:
				if (keyData != (Keys.LButton | Keys.Back | Keys.Shift | Keys.Control))
				{
					return base.ProcessCmdKey(ref msg, keyData);
				}
				break;
			}
			this.xa3038751b16f6cc8(-1, true, true);
			return true;
		}

		// Token: 0x0600056E RID: 1390 RVA: 0x0002A330 File Offset: 0x00029330
		protected override void OnFontChanged(EventArgs e)
		{
			this.x436f6f3ee14607e0();
			base.PerformLayout();
			base.OnFontChanged(e);
		}

		// Token: 0x0600056F RID: 1391 RVA: 0x0002A348 File Offset: 0x00029348
		protected virtual void OnSelectedPageChanged(EventArgs e)
		{
			if (this.x5c05af982a207d77 != null)
			{
				this.x5c05af982a207d77(this, e);
			}
		}

		// Token: 0x17000151 RID: 337
		// (get) Token: 0x06000570 RID: 1392 RVA: 0x0002A360 File Offset: 0x00029360
		// (set) Token: 0x06000571 RID: 1393 RVA: 0x0002A368 File Offset: 0x00029368
		[Category("Behavior")]
		[DefaultValue(typeof(TabLayout), "SingleLineScrollable")]
		[Description("How the tabs of child controls are laid out.")]
		public TabLayout TabLayout
		{
			get
			{
				return this.xcd09bc4ebc470051;
			}
			set
			{
				this.xcd09bc4ebc470051 = value;
				this.x436f6f3ee14607e0();
				base.PerformLayout();
			}
		}

		// Token: 0x17000152 RID: 338
		// (get) Token: 0x06000572 RID: 1394 RVA: 0x0002A380 File Offset: 0x00029380
		// (set) Token: 0x06000573 RID: 1395 RVA: 0x0002A388 File Offset: 0x00029388
		[TypeConverter(typeof(xdc4dfd9427bbb983))]
		[RefreshProperties(RefreshProperties.All)]
		[Category("Appearance")]
		[Description("The renderer used to calculate object metrics and draw contents.")]
		public ITabControlRenderer Renderer
		{
			get
			{
				return this.x38870620fd380a6b;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException();
				}
				if (this.x38870620fd380a6b is IDisposable)
				{
					goto IL_D0;
				}
				IL_BA:
				if (this.x38870620fd380a6b is RendererBase)
				{
					((RendererBase)this.x38870620fd380a6b).MetricsChanged -= this.xadaf245f129714e2;
				}
				this.x38870620fd380a6b = value;
				if (-1 == 0)
				{
					goto IL_73;
				}
				if (false)
				{
					goto IL_36;
				}
				if (value.ShouldDrawControlBorder)
				{
					goto IL_73;
				}
				goto IL_59;
				IL_0D:
				if (this.x38870620fd380a6b is RendererBase)
				{
					goto IL_36;
				}
				IL_1A:
				this.x436f6f3ee14607e0();
				base.PerformLayout();
				return;
				IL_36:
				((RendererBase)this.x38870620fd380a6b).MetricsChanged += this.xadaf245f129714e2;
				goto IL_1A;
				IL_59:
				if (!value.ShouldDrawControlBorder)
				{
					goto IL_7E;
				}
				if (2 == 0)
				{
					if (false)
					{
						goto IL_7E;
					}
				}
				else if (8 != 0)
				{
					if (15 == 0)
					{
						goto IL_36;
					}
					goto IL_0D;
				}
				IL_6B:
				if (!false)
				{
					goto IL_0D;
				}
				goto IL_59;
				IL_73:
				if (this.BorderStyle != TD.SandDock.Rendering.BorderStyle.None)
				{
					if (!false)
					{
						goto IL_59;
					}
				}
				else
				{
					this.BorderStyle = TD.SandDock.Rendering.BorderStyle.Flat;
					if (!false)
					{
						goto IL_0D;
					}
					goto IL_D0;
				}
				IL_7E:
				if (this.BorderStyle != TD.SandDock.Rendering.BorderStyle.None)
				{
					this.BorderStyle = TD.SandDock.Rendering.BorderStyle.None;
					goto IL_6B;
				}
				goto IL_0D;
				IL_D0:
				((IDisposable)this.x38870620fd380a6b).Dispose();
				goto IL_BA;
			}
		}

		// Token: 0x06000574 RID: 1396 RVA: 0x0002A4C0 File Offset: 0x000294C0
		private void xadaf245f129714e2(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			this.x436f6f3ee14607e0();
			base.PerformLayout();
		}

		// Token: 0x17000153 RID: 339
		// (get) Token: 0x06000575 RID: 1397 RVA: 0x0002A4D0 File Offset: 0x000294D0
		// (set) Token: 0x06000576 RID: 1398 RVA: 0x0002A4D4 File Offset: 0x000294D4
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[Obsolete("Use the TabLayout property instead.")]
		public bool AllowScrolling
		{
			get
			{
				return true;
			}
			set
			{
			}
		}

		// Token: 0x17000154 RID: 340
		// (get) Token: 0x06000577 RID: 1399 RVA: 0x0002A4D8 File Offset: 0x000294D8
		public override Rectangle DisplayRectangle
		{
			get
			{
				Rectangle displayRectangle = base.DisplayRectangle;
				for (;;)
				{
					switch (this.xacfbd7a08ba56c78)
					{
					case TD.SandDock.Rendering.BorderStyle.Flat:
					case TD.SandDock.Rendering.BorderStyle.RaisedThin:
					case TD.SandDock.Rendering.BorderStyle.SunkenThin:
						goto IL_0B;
					case TD.SandDock.Rendering.BorderStyle.RaisedThick:
					case TD.SandDock.Rendering.BorderStyle.SunkenThick:
						do
						{
							displayRectangle.Inflate(-2, -2);
						}
						while (!true);
						if (false)
						{
							continue;
						}
						break;
					}
					return displayRectangle;
				}
				IL_0B:
				displayRectangle.Inflate(-1, -1);
				return displayRectangle;
			}
		}

		// Token: 0x17000155 RID: 341
		// (get) Token: 0x06000578 RID: 1400 RVA: 0x0002A538 File Offset: 0x00029538
		// (set) Token: 0x06000579 RID: 1401 RVA: 0x0002A540 File Offset: 0x00029540
		[Category("Appearance")]
		[Description("The type of border to be drawn around the control.")]
		[DefaultValue(typeof(TD.SandDock.Rendering.BorderStyle), "Flat")]
		public TD.SandDock.Rendering.BorderStyle BorderStyle
		{
			get
			{
				return this.xacfbd7a08ba56c78;
			}
			set
			{
				this.xacfbd7a08ba56c78 = value;
				this.x436f6f3ee14607e0();
				base.PerformLayout();
			}
		}

		// Token: 0x17000156 RID: 342
		// (get) Token: 0x0600057A RID: 1402 RVA: 0x0002A558 File Offset: 0x00029558
		[Description("A collection of TabPage controls belonging to this control.")]
		[Category("Behavior")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public TabControl.TabPageCollection TabPages
		{
			get
			{
				return this.xc13824d17c0efae4;
			}
		}

		// Token: 0x17000157 RID: 343
		// (get) Token: 0x0600057B RID: 1403 RVA: 0x0002A560 File Offset: 0x00029560
		protected override Size DefaultSize
		{
			get
			{
				return new Size(300, 200);
			}
		}

		// Token: 0x17000158 RID: 344
		// (get) Token: 0x0600057C RID: 1404 RVA: 0x0002A574 File Offset: 0x00029574
		// (set) Token: 0x0600057D RID: 1405 RVA: 0x0002A57C File Offset: 0x0002957C
		[Browsable(false)]
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

		// Token: 0x17000159 RID: 345
		// (get) Token: 0x0600057E RID: 1406 RVA: 0x0002A588 File Offset: 0x00029588
		// (set) Token: 0x0600057F RID: 1407 RVA: 0x0002A59C File Offset: 0x0002959C
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public int SelectedIndex
		{
			get
			{
				return this.TabPages.IndexOf(this.SelectedPage);
			}
			set
			{
				this.SelectedPage = this.TabPages[value];
			}
		}

		// Token: 0x1700015A RID: 346
		// (get) Token: 0x06000580 RID: 1408 RVA: 0x0002A5B0 File Offset: 0x000295B0
		// (set) Token: 0x06000581 RID: 1409 RVA: 0x0002A5B8 File Offset: 0x000295B8
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public TabPage SelectedPage
		{
			get
			{
				return this.x980c1bf410aee986;
			}
			set
			{
				if (value != null)
				{
					goto IL_79;
				}
				if (!false)
				{
					goto IL_AB;
				}
				IL_77:
				if (-2147483648 != 0)
				{
					goto IL_90;
				}
				IL_79:
				if (!base.Controls.Contains(value))
				{
					throw new ArgumentException("Specified TabPage does not belong to this TabControl.");
				}
				IL_90:
				this.x980c1bf410aee986 = value;
				this.x436f6f3ee14607e0();
				if (!false)
				{
					base.SuspendLayout();
					foreach (object obj in this.TabPages)
					{
						TabPage tabPage = (TabPage)obj;
						tabPage.Visible = (tabPage == this.x980c1bf410aee986);
					}
					base.ResumeLayout();
				}
				this.OnSelectedPageChanged(EventArgs.Empty);
				if (2147483647 == 0)
				{
					goto IL_77;
				}
				if (!false)
				{
					return;
				}
				IL_AB:
				throw new ArgumentNullException();
			}
		}

		// Token: 0x1700015B RID: 347
		// (get) Token: 0x06000582 RID: 1410 RVA: 0x0002A6A8 File Offset: 0x000296A8
		// (set) Token: 0x06000583 RID: 1411 RVA: 0x0002A6AC File Offset: 0x000296AC
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Obsolete]
		public SplitLayoutSystem LayoutSystem
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		// Token: 0x1700015C RID: 348
		// (get) Token: 0x06000584 RID: 1412 RVA: 0x0002A6B0 File Offset: 0x000296B0
		[Browsable(false)]
		public Rectangle TabStripBounds
		{
			get
			{
				return this.xd2fe3b65e7e0ab37;
			}
		}

		// Token: 0x040001FF RID: 511
		private const int x1e9b7c427b6c44fa = 14;

		// Token: 0x04000200 RID: 512
		private const int x26539fe4604823df = 15;

		// Token: 0x04000201 RID: 513
		private ITabControlRenderer x38870620fd380a6b;

		// Token: 0x04000202 RID: 514
		private TD.SandDock.Rendering.BorderStyle xacfbd7a08ba56c78 = TD.SandDock.Rendering.BorderStyle.Flat;

		// Token: 0x04000203 RID: 515
		private static bool xc700d1f31b5ce30a;

		// Token: 0x04000204 RID: 516
		private TabControl.TabPageCollection xc13824d17c0efae4;

		// Token: 0x04000205 RID: 517
		private TabPage x980c1bf410aee986;

		// Token: 0x04000206 RID: 518
		private xbd7c5470fc89975b x266365ea27fa7af8;

		// Token: 0x04000207 RID: 519
		private TabLayout xcd09bc4ebc470051;

		// Token: 0x04000208 RID: 520
		private Rectangle xd2fe3b65e7e0ab37;

		// Token: 0x04000209 RID: 521
		private Rectangle x21ed2ecc088ef4e4;

		// Token: 0x0400020A RID: 522
		private Rectangle x38c1fce82bb0e828;

		// Token: 0x0400020B RID: 523
		private int x200b7f5a9d983ba4;

		// Token: 0x0400020C RID: 524
		private int x4f8ccd50477a481e;

		// Token: 0x0400020D RID: 525
		private Timer x5d56ae798b9cdf38;

		// Token: 0x0400020E RID: 526
		private x0a9f5257a10031b2 x49dae83181e41d72;

		// Token: 0x0400020F RID: 527
		private x0a9f5257a10031b2 xa8ae81960654bc0b;

		// Token: 0x04000210 RID: 528
		private x0a9f5257a10031b2 x216b0c2912ae7c6a;

		// Token: 0x04000211 RID: 529
		private bool xfa5e20eb950b9ee1;

		// Token: 0x04000212 RID: 530
		private EventHandler x5c05af982a207d77;

		// Token: 0x02000062 RID: 98
		public class TabPageCollection : IList, ICollection, IEnumerable
		{
			// Token: 0x06000586 RID: 1414 RVA: 0x0002A6BC File Offset: 0x000296BC
			internal TabPageCollection(TabControl parent)
			{
				this.xb6a159a84cb992d6 = parent;
			}

			// Token: 0x1700015D RID: 349
			// (get) Token: 0x06000587 RID: 1415 RVA: 0x0002A6CC File Offset: 0x000296CC
			bool IList.xfc2a190cd9d7a9e2
			{
				get
				{
					return false;
				}
			}

			// Token: 0x1700015E RID: 350
			object IList.this[int xc0c4c459c6ccbd00]
			{
				get
				{
					return this[xc0c4c459c6ccbd00];
				}
				set
				{
				}
			}

			// Token: 0x0600058A RID: 1418 RVA: 0x0002A6E0 File Offset: 0x000296E0
			public void SetChildIndex(TabPage tabPage, int index)
			{
				this.xb6a159a84cb992d6.Controls.SetChildIndex(tabPage, index);
			}

			// Token: 0x0600058B RID: 1419 RVA: 0x0002A6F4 File Offset: 0x000296F4
			public void RemoveAt(int index)
			{
				this.xb6a159a84cb992d6.Controls.RemoveAt(index);
			}

			// Token: 0x0600058C RID: 1420 RVA: 0x0002A708 File Offset: 0x00029708
			void IList.x87c211383e3062d5(int xc0c4c459c6ccbd00, object xbcea506a33cf9111)
			{
				throw new NotSupportedException();
			}

			// Token: 0x0600058D RID: 1421 RVA: 0x0002A710 File Offset: 0x00029710
			void IList.x7d6f7f540d2a814d(object xbcea506a33cf9111)
			{
				if (xbcea506a33cf9111 is TabPage)
				{
					this.Remove((TabPage)xbcea506a33cf9111);
				}
			}

			// Token: 0x0600058E RID: 1422 RVA: 0x0002A728 File Offset: 0x00029728
			bool IList.x6532c18338cc2620(object xbcea506a33cf9111)
			{
				return xbcea506a33cf9111 is TabPage && this.Contains((TabPage)xbcea506a33cf9111);
			}

			// Token: 0x0600058F RID: 1423 RVA: 0x0002A740 File Offset: 0x00029740
			public void Clear()
			{
				this.xb6a159a84cb992d6.Controls.Clear();
			}

			// Token: 0x06000590 RID: 1424 RVA: 0x0002A754 File Offset: 0x00029754
			int IList.x104b91678c6b7dff(object xbcea506a33cf9111)
			{
				if (xbcea506a33cf9111 is TabPage)
				{
					return this.IndexOf((TabPage)xbcea506a33cf9111);
				}
				return -1;
			}

			// Token: 0x06000591 RID: 1425 RVA: 0x0002A76C File Offset: 0x0002976C
			int IList.xae8b83d75f3358b9(object xbcea506a33cf9111)
			{
				if (xbcea506a33cf9111 is TabPage)
				{
					this.xb6a159a84cb992d6.Controls.Add((TabPage)xbcea506a33cf9111);
					return this.IndexOf((TabPage)xbcea506a33cf9111);
				}
				throw new NotSupportedException();
			}

			// Token: 0x1700015F RID: 351
			// (get) Token: 0x06000592 RID: 1426 RVA: 0x0002A7A0 File Offset: 0x000297A0
			bool IList.xe4fa55b25bbd2be4
			{
				get
				{
					return false;
				}
			}

			// Token: 0x17000160 RID: 352
			// (get) Token: 0x06000593 RID: 1427 RVA: 0x0002A7A4 File Offset: 0x000297A4
			bool ICollection.x92a0b60a6509c47e
			{
				get
				{
					return false;
				}
			}

			// Token: 0x17000161 RID: 353
			// (get) Token: 0x06000594 RID: 1428 RVA: 0x0002A7A8 File Offset: 0x000297A8
			public int Count
			{
				get
				{
					return this.xb6a159a84cb992d6.Controls.Count;
				}
			}

			// Token: 0x06000595 RID: 1429 RVA: 0x0002A7BC File Offset: 0x000297BC
			void ICollection.x21912c843ee261be(Array x9d5750eb2d6373bc, int xc0c4c459c6ccbd00)
			{
				if (x9d5750eb2d6373bc is TabPage[])
				{
					this.CopyTo((TabPage[])x9d5750eb2d6373bc, xc0c4c459c6ccbd00);
				}
			}

			// Token: 0x17000162 RID: 354
			// (get) Token: 0x06000596 RID: 1430 RVA: 0x0002A7D4 File Offset: 0x000297D4
			object ICollection.x1efa7fe50de1e184
			{
				get
				{
					return this;
				}
			}

			// Token: 0x06000597 RID: 1431 RVA: 0x0002A7D8 File Offset: 0x000297D8
			public IEnumerator GetEnumerator()
			{
				TabPage[] array = new TabPage[this.Count];
				this.CopyTo(array, 0);
				return array.GetEnumerator();
			}

			// Token: 0x06000598 RID: 1432 RVA: 0x0002A800 File Offset: 0x00029800
			public void CopyTo(TabPage[] array, int index)
			{
				this.xb6a159a84cb992d6.Controls.CopyTo(array, index);
			}

			// Token: 0x17000163 RID: 355
			public TabPage this[int index]
			{
				get
				{
					return (TabPage)this.xb6a159a84cb992d6.Controls[index];
				}
			}

			// Token: 0x0600059A RID: 1434 RVA: 0x0002A82C File Offset: 0x0002982C
			public bool Contains(TabPage tabPage)
			{
				return this.xb6a159a84cb992d6.Controls.Contains(tabPage);
			}

			// Token: 0x0600059B RID: 1435 RVA: 0x0002A840 File Offset: 0x00029840
			public void AddRange(TabPage[] tabPages)
			{
				this.xb6a159a84cb992d6.Controls.AddRange(tabPages);
			}

			// Token: 0x0600059C RID: 1436 RVA: 0x0002A854 File Offset: 0x00029854
			public void Remove(TabPage tabPage)
			{
				this.xb6a159a84cb992d6.Controls.Remove(tabPage);
			}

			// Token: 0x0600059D RID: 1437 RVA: 0x0002A868 File Offset: 0x00029868
			public int IndexOf(TabPage tabPage)
			{
				return this.xb6a159a84cb992d6.Controls.IndexOf(tabPage);
			}

			// Token: 0x0600059E RID: 1438 RVA: 0x0002A87C File Offset: 0x0002987C
			public void Add(TabPage tabPage)
			{
				this.xb6a159a84cb992d6.Controls.Add(tabPage);
			}

			// Token: 0x04000213 RID: 531
			private TabControl xb6a159a84cb992d6;
		}

		// Token: 0x02000066 RID: 102
		internal class x9e8d5fa1ed8fe66b : Control.ControlCollection
		{
			// Token: 0x060005D8 RID: 1496 RVA: 0x0002BCFC File Offset: 0x0002ACFC
			public x9e8d5fa1ed8fe66b(TabControl owner) : base(owner)
			{
				this.xb6a159a84cb992d6 = owner;
			}

			// Token: 0x060005D9 RID: 1497 RVA: 0x0002BD0C File Offset: 0x0002AD0C
			public override void Add(Control value)
			{
				if (value is TabPage)
				{
					value.Visible = false;
					base.Add(value);
					while (this.Count == 1)
					{
						this.xb6a159a84cb992d6.SelectedPage = (TabPage)value;
						if (!false)
						{
							if (-1 == 0)
							{
								goto IL_4C;
							}
							return;
						}
					}
					return;
				}
				IL_4C:
				throw new ArgumentException("Only TabPage controls can be added to a TabControl control.");
			}

			// Token: 0x0400022C RID: 556
			private TabControl xb6a159a84cb992d6;
		}
	}
}
