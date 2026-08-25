using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using TD.SandDock.Rendering;

namespace TD.SandDock
{
	// Token: 0x0200002E RID: 46
	public class DocumentLayoutSystem : ControlLayoutSystem
	{
		// Token: 0x060003E5 RID: 997 RVA: 0x0001F3A8 File Offset: 0x0001E3A8
		public DocumentLayoutSystem()
		{
			do
			{
				this.x49dae83181e41d72 = new x0a9f5257a10031b2();
				this.xa8ae81960654bc0b = new x0a9f5257a10031b2();
				if (4 != 0)
				{
					this.x26e80f23e22a05ae = new x0a9f5257a10031b2();
					this.x361886ff08483890 = new x0a9f5257a10031b2();
					this.x5d56ae798b9cdf38 = new Timer();
				}
				this.x5d56ae798b9cdf38.Interval = 20;
				this.x5d56ae798b9cdf38.Tick += this.xcaf19fd9570f4eb4;
			}
			while (4 == 0);
		}

		// Token: 0x060003E6 RID: 998 RVA: 0x0001F428 File Offset: 0x0001E428
		public DocumentLayoutSystem(int desiredWidth, int desiredHeight) : this()
		{
			base.WorkingSize = new SizeF((float)desiredWidth, (float)desiredHeight);
		}

		// Token: 0x060003E7 RID: 999 RVA: 0x0001F440 File Offset: 0x0001E440
		[Obsolete("Use the constructor that takes a SizeF instead.")]
		public DocumentLayoutSystem(int desiredWidth, int desiredHeight, DockControl[] controls, DockControl selectedControl) : this(desiredWidth, desiredHeight)
		{
			base.Controls.AddRange(controls);
			if (selectedControl != null)
			{
				this.SelectedControl = selectedControl;
			}
		}

		// Token: 0x060003E8 RID: 1000 RVA: 0x0001F474 File Offset: 0x0001E474
		public DocumentLayoutSystem(SizeF workingSize, DockControl[] windows, DockControl selectedWindow) : this()
		{
			base.WorkingSize = workingSize;
			base.Controls.AddRange(windows);
			if (selectedWindow != null)
			{
				this.SelectedControl = selectedWindow;
			}
		}

		// Token: 0x170000FF RID: 255
		// (get) Token: 0x060003E9 RID: 1001 RVA: 0x0001F49C File Offset: 0x0001E49C
		private DocumentOverflowMode x7d2c5325d16e569d
		{
			get
			{
				DocumentContainer documentContainer = base.DockContainer as DocumentContainer;
				if (documentContainer == null)
				{
					return DocumentOverflowMode.Scrollable;
				}
				return documentContainer.x7d2c5325d16e569d;
			}
		}

		// Token: 0x17000100 RID: 256
		// (get) Token: 0x060003EA RID: 1002 RVA: 0x0001F4C4 File Offset: 0x0001E4C4
		private bool xa957e8f86f5e6115
		{
			get
			{
				DocumentContainer documentContainer = base.DockContainer as DocumentContainer;
				return documentContainer != null && documentContainer.xa957e8f86f5e6115;
			}
		}

		// Token: 0x17000101 RID: 257
		// (get) Token: 0x060003EB RID: 1003 RVA: 0x0001F4E8 File Offset: 0x0001E4E8
		// (set) Token: 0x060003EC RID: 1004 RVA: 0x0001F4F0 File Offset: 0x0001E4F0
		private DockControl xfccaf77d66322943
		{
			get
			{
				return this.x9241b98e8e24ab0c;
			}
			set
			{
				if (value != this.x9241b98e8e24ab0c)
				{
					for (;;)
					{
						if (base.DockContainer == null)
						{
							goto IL_48;
						}
						IL_40:
						if (this.x9241b98e8e24ab0c != null)
						{
							base.DockContainer.Invalidate(this.x9241b98e8e24ab0c.x123e054dab107457);
							if (-2 == 0)
							{
								continue;
							}
							if (false)
							{
								continue;
							}
						}
						IL_48:
						this.x9241b98e8e24ab0c = value;
						if (base.DockContainer == null || this.x9241b98e8e24ab0c == null)
						{
							break;
						}
						base.DockContainer.Invalidate(this.x9241b98e8e24ab0c.x123e054dab107457);
						if (2147483647 == 0)
						{
							goto IL_40;
						}
						break;
					}
				}
			}
		}

		// Token: 0x060003ED RID: 1005 RVA: 0x0001F584 File Offset: 0x0001E584
		protected internal override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			if (e.Button == MouseButtons.None)
			{
				this.xfccaf77d66322943 = this.GetControlAt(new Point(e.X, e.Y));
			}
		}

		// Token: 0x060003EE RID: 1006 RVA: 0x0001F5B4 File Offset: 0x0001E5B4
		protected internal override void OnMouseLeave()
		{
			base.OnMouseLeave();
			this.xfccaf77d66322943 = null;
		}

		// Token: 0x17000102 RID: 258
		// (get) Token: 0x060003EF RID: 1007 RVA: 0x0001F5C4 File Offset: 0x0001E5C4
		public Rectangle LeftScrollButtonBounds
		{
			get
			{
				return this.x49dae83181e41d72.xda73fcb97c77d998;
			}
		}

		// Token: 0x17000103 RID: 259
		// (get) Token: 0x060003F0 RID: 1008 RVA: 0x0001F5D4 File Offset: 0x0001E5D4
		public Rectangle RightScrollButtonBounds
		{
			get
			{
				return this.xa8ae81960654bc0b.xda73fcb97c77d998;
			}
		}

		// Token: 0x060003F1 RID: 1009 RVA: 0x0001F5E4 File Offset: 0x0001E5E4
		internal override string xe0e7b93bedab6c05(Point x13d4cb8d1bd20347)
		{
			x0a9f5257a10031b2 x0a9f5257a10031b = this.x07083a4bfd59263d(x13d4cb8d1bd20347.X, x13d4cb8d1bd20347.Y);
			while (x0a9f5257a10031b != this.x49dae83181e41d72)
			{
				if (3 != 0)
				{
					if (x0a9f5257a10031b == this.xa8ae81960654bc0b)
					{
						return SandDockLanguage.ScrollRightText;
					}
					if (x0a9f5257a10031b == this.x26e80f23e22a05ae)
					{
						return SandDockLanguage.CloseText;
					}
					if (x0a9f5257a10031b == this.x361886ff08483890)
					{
						return SandDockLanguage.ActiveFilesText;
					}
					return base.xe0e7b93bedab6c05(x13d4cb8d1bd20347);
				}
			}
			return SandDockLanguage.ScrollLeftText;
		}

		// Token: 0x060003F2 RID: 1010 RVA: 0x0001F658 File Offset: 0x0001E658
		internal override void x46ff430ed3944e0f(xedb4922162c60d3d.DockTarget x11d58b056c032b03)
		{
			base.x46ff430ed3944e0f(x11d58b056c032b03);
			while (x11d58b056c032b03 == null || x11d58b056c032b03.type == xedb4922162c60d3d.DockTargetType.None)
			{
				if (this.SelectedControl == null)
				{
					if (2 == 0)
					{
						goto IL_2E;
					}
				}
				else
				{
					if (!base.IsInContainer)
					{
						break;
					}
					if (8 != 0)
					{
						goto IL_2E;
					}
				}
				IL_76:
				if (-2 == 0)
				{
					continue;
				}
				break;
				IL_65:
				goto IL_76;
				IL_2E:
				Point position = this.SelectedControl.PointToClient(Cursor.Position);
				if (true)
				{
					base.DockContainer.x8ba6fce4f4601549(new ShowControlContextMenuEventArgs(this.SelectedControl, position, ContextMenuContext.Other));
					if (-2147483648 == 0)
					{
						goto IL_65;
					}
				}
				return;
			}
		}

		// Token: 0x060003F3 RID: 1011 RVA: 0x0001F6EC File Offset: 0x0001E6EC
		internal override void x11e90588eb0baaf1(x0a9f5257a10031b2 x128517d7ded59312)
		{
			if (x128517d7ded59312 == this.x49dae83181e41d72 || x128517d7ded59312 == this.xa8ae81960654bc0b)
			{
				this.xcf8b319f2bffca87();
			}
		}

		// Token: 0x060003F4 RID: 1012 RVA: 0x0001F70C File Offset: 0x0001E70C
		internal override void xa82f7b310984e03e(x0a9f5257a10031b2 x128517d7ded59312)
		{
			if (x128517d7ded59312 == this.x26e80f23e22a05ae)
			{
				goto IL_E4;
			}
			goto IL_90;
			IL_21:
			DockControl[] array;
			if (base.DockContainer == null)
			{
				if (!false)
				{
					if (false)
					{
						goto IL_E4;
					}
					return;
				}
			}
			else
			{
				if (base.DockContainer.Manager == null)
				{
					return;
				}
				array = new DockControl[base.Controls.Count];
				base.Controls.CopyTo(array, 0);
			}
			if (2 != 0)
			{
				base.DockContainer.Manager.OnShowActiveFilesList(new ActiveFilesListEventArgs(array, base.DockContainer, new Point(this.x361886ff08483890.xda73fcb97c77d998.X, this.x361886ff08483890.xda73fcb97c77d998.Bottom)));
				return;
			}
			goto IL_D4;
			IL_90:
			if (x128517d7ded59312 != this.x49dae83181e41d72)
			{
				if (x128517d7ded59312 != this.xa8ae81960654bc0b)
				{
					if (x128517d7ded59312 == this.x361886ff08483890)
					{
						goto IL_21;
					}
					return;
				}
			}
			IL_D4:
			this.xd11b6d3bf98020cb();
			if (-2147483648 != 0)
			{
				return;
			}
			if (!false)
			{
				goto IL_90;
			}
			IL_E4:
			if (true)
			{
				this.OnCloseButtonClick(new CancelEventArgs());
				return;
			}
			goto IL_21;
		}

		// Token: 0x060003F5 RID: 1013 RVA: 0x0001F818 File Offset: 0x0001E818
		internal override x0a9f5257a10031b2 x07083a4bfd59263d(int x08db3aeabb253cb1, int x1e218ceaee1bb583)
		{
			if (this.x49dae83181e41d72.x364c1e3b189d47fe && this.x49dae83181e41d72.x2fef7d841879a711 && this.x49dae83181e41d72.xda73fcb97c77d998.Contains(x08db3aeabb253cb1, x1e218ceaee1bb583))
			{
				return this.x49dae83181e41d72;
			}
			if (this.xa8ae81960654bc0b.x364c1e3b189d47fe)
			{
				if (this.xa8ae81960654bc0b.x2fef7d841879a711)
				{
					if (this.xa8ae81960654bc0b.xda73fcb97c77d998.Contains(x08db3aeabb253cb1, x1e218ceaee1bb583))
					{
						return this.xa8ae81960654bc0b;
					}
				}
			}
			if (!this.x361886ff08483890.x364c1e3b189d47fe)
			{
				goto IL_61;
			}
			bool flag;
			if ((uint)x1e218ceaee1bb583 + (uint)x08db3aeabb253cb1 >= 0U)
			{
				if (!this.x361886ff08483890.x2fef7d841879a711)
				{
					goto IL_61;
				}
				flag = ((uint)x1e218ceaee1bb583 < 0U);
				if (!flag && !this.x361886ff08483890.xda73fcb97c77d998.Contains(x08db3aeabb253cb1, x1e218ceaee1bb583))
				{
					goto IL_9B;
				}
				return this.x361886ff08483890;
			}
			else if ((uint)x08db3aeabb253cb1 + (uint)x1e218ceaee1bb583 > 4294967295U)
			{
				goto IL_61;
			}
			IL_15:
			if (!this.x26e80f23e22a05ae.x2fef7d841879a711)
			{
				if (!false)
				{
					goto IL_198;
				}
			}
			IL_22:
			if (!this.x26e80f23e22a05ae.xda73fcb97c77d998.Contains(x08db3aeabb253cb1, x1e218ceaee1bb583))
			{
				goto IL_198;
			}
			return this.x26e80f23e22a05ae;
			IL_61:
			if (!this.x26e80f23e22a05ae.x364c1e3b189d47fe)
			{
				goto IL_198;
			}
			flag = ((uint)x1e218ceaee1bb583 - (uint)x1e218ceaee1bb583 > uint.MaxValue);
			if (!flag)
			{
				goto IL_15;
			}
			IL_9B:
			if (!false)
			{
				goto IL_61;
			}
			flag = ((uint)x08db3aeabb253cb1 < 0U);
			if (flag)
			{
				goto IL_22;
			}
			goto IL_15;
			IL_198:
			return null;
		}

		// Token: 0x060003F6 RID: 1014 RVA: 0x0001F9C0 File Offset: 0x0001E9C0
		internal override void xd541e2fc281b554b()
		{
			if (base.DockContainer != null)
			{
				base.DockContainer.Invalidate(this.xa358da7dd5364cab);
			}
		}

		// Token: 0x060003F7 RID: 1015 RVA: 0x0001F9DC File Offset: 0x0001E9DC
		internal override void x84b6f3c22477dacb(RendererBase x38870620fd380a6b, Graphics x41347a961b838962, Font x26094932cf7a9139)
		{
			x38870620fd380a6b.DrawDocumentStripBackground(x41347a961b838962, this.xa358da7dd5364cab);
			int num;
			bool flag;
			do
			{
				flag = ((uint)num > uint.MaxValue);
				if (flag || this.SelectedControl != null)
				{
					goto IL_1CE;
				}
				x38870620fd380a6b.DrawDocumentClientBackground(x41347a961b838962, this.x21ed2ecc088ef4e4, SystemColors.Control);
				if (false)
				{
					return;
				}
			}
			while (255 == 0);
			IL_161:
			Region clip = x41347a961b838962.Clip;
			Rectangle xa358da7dd5364cab = this.xa358da7dd5364cab;
			xa358da7dd5364cab.X += this.LeftPadding;
			xa358da7dd5364cab.Width -= this.LeftPadding;
			xa358da7dd5364cab.Width -= this.RightPadding;
			for (;;)
			{
				if ((uint)num + (uint)num < 0U)
				{
					goto IL_10D;
				}
				x41347a961b838962.SetClip(xa358da7dd5364cab);
				num = base.Controls.Count - 1;
				IL_DF:
				DockControl dockControl;
				if (num < 0)
				{
					if (this.SelectedControl == null)
					{
						goto Block_4;
					}
					this.xc33f5f7a18a754cb(x38870620fd380a6b, x41347a961b838962, this.SelectedControl.Font, this.SelectedControl);
					if (-2147483648 == 0)
					{
						continue;
					}
					goto IL_158;
				}
				else
				{
					dockControl = base.Controls[num];
				}
				IL_10D:
				this.xc33f5f7a18a754cb(x38870620fd380a6b, x41347a961b838962, dockControl.Font, dockControl);
				num--;
				goto IL_DF;
			}
			IL_6E:
			x41347a961b838962.Clip = clip;
			if (!this.xa957e8f86f5e6115)
			{
				base.xb30ec7cfdf3e5c19(x41347a961b838962, x38870620fd380a6b, this.x26e80f23e22a05ae, SandDockButtonType.Close, true);
			}
			base.xb30ec7cfdf3e5c19(x41347a961b838962, x38870620fd380a6b, this.xa8ae81960654bc0b, SandDockButtonType.ScrollRight, this.xa8ae81960654bc0b.x2fef7d841879a711);
			if (!false)
			{
				base.xb30ec7cfdf3e5c19(x41347a961b838962, x38870620fd380a6b, this.x49dae83181e41d72, SandDockButtonType.ScrollLeft, this.x49dae83181e41d72.x2fef7d841879a711);
				base.xb30ec7cfdf3e5c19(x41347a961b838962, x38870620fd380a6b, this.x361886ff08483890, SandDockButtonType.ActiveFiles, true);
				return;
			}
			goto IL_1E6;
			IL_B0:
			if (!this.xa957e8f86f5e6115)
			{
				goto IL_D6;
			}
			base.xb30ec7cfdf3e5c19(x41347a961b838962, x38870620fd380a6b, this.x26e80f23e22a05ae, SandDockButtonType.Close, true);
			if ((uint)num + (uint)num <= 4294967295U)
			{
			}
			goto IL_6E;
			Block_4:
			flag = ((uint)num < 0U);
			if (!flag)
			{
				goto IL_B0;
			}
			IL_D6:
			goto IL_6E;
			IL_158:
			goto IL_B0;
			IL_1CE:
			x38870620fd380a6b.DrawDocumentClientBackground(x41347a961b838962, this.x21ed2ecc088ef4e4, this.SelectedControl.BackColor);
			IL_1E6:
			goto IL_161;
		}

		// Token: 0x060003F8 RID: 1016 RVA: 0x0001FBF4 File Offset: 0x0001EBF4
		private void xc33f5f7a18a754cb(RendererBase x38870620fd380a6b, Graphics x41347a961b838962, Font x26094932cf7a9139, DockControl x43bec302f92080b9)
		{
			DrawItemState drawItemState = DrawItemState.Default;
			if (this.SelectedControl == x43bec302f92080b9)
			{
				if (false)
				{
					return;
				}
				drawItemState |= DrawItemState.Selected;
				goto IL_286;
			}
			IL_1EB:
			if (this.x9241b98e8e24ab0c == x43bec302f92080b9)
			{
				goto IL_1F5;
			}
			goto IL_1B0;
			IL_5E:
			Rectangle tabBounds;
			bool flag;
			using (Font font = new Font(x26094932cf7a9139, FontStyle.Bold))
			{
				x38870620fd380a6b.DrawDocumentStripTab(x41347a961b838962, x43bec302f92080b9.x123e054dab107457, tabBounds, x43bec302f92080b9.TabImage, x43bec302f92080b9.TabText, font, x43bec302f92080b9.BackColor, x43bec302f92080b9.ForeColor, drawItemState, flag);
				return;
			}
			IL_A8:
			bool flag2;
			if ((drawItemState & DrawItemState.Focus) != DrawItemState.Focus)
			{
				flag2 = (((flag ? 1U : 0U) | 8U) == 0U);
				if (!flag2)
				{
					x38870620fd380a6b.DrawDocumentStripTab(x41347a961b838962, x43bec302f92080b9.x123e054dab107457, tabBounds, x43bec302f92080b9.TabImage, x43bec302f92080b9.TabText, x26094932cf7a9139, x43bec302f92080b9.BackColor, x43bec302f92080b9.ForeColor, drawItemState, flag);
				}
				goto IL_1DE;
			}
			goto IL_5E;
			IL_B2:
			if (!this.xa957e8f86f5e6115)
			{
				goto IL_A8;
			}
			goto IL_F8;
			IL_EE:
			tabBounds = x43bec302f92080b9.TabBounds;
			goto IL_B2;
			IL_F8:
			if (!x43bec302f92080b9.AllowClose)
			{
				goto IL_A8;
			}
			if (!false)
			{
				tabBounds.Width -= 17;
				goto IL_172;
			}
			goto IL_1A0;
			IL_119:
			flag2 = ((flag ? 1U : 0U) - (flag ? 1U : 0U) < 0U);
			if (flag2 || base.Controls.IndexOf(x43bec302f92080b9) == base.Controls.IndexOf(this.SelectedControl) - 1)
			{
				flag = false;
				goto IL_EE;
			}
			flag2 = ((flag ? 1U : 0U) - (flag ? 1U : 0U) > uint.MaxValue);
			if (!flag2)
			{
				goto IL_EE;
			}
			IL_172:
			if (((flag ? 1U : 0U) & 0U) != 0U)
			{
				goto IL_1C9;
			}
			if (-1 == 0)
			{
				goto IL_1B0;
			}
			if ((flag ? 1U : 0U) < 0U)
			{
				goto IL_B2;
			}
			if (false)
			{
				goto IL_5E;
			}
			goto IL_A8;
			IL_1A0:
			if (!false)
			{
				goto IL_119;
			}
			goto IL_1F5;
			IL_1B0:
			if (!x43bec302f92080b9.Enabled)
			{
				drawItemState |= DrawItemState.Disabled;
			}
			flag = true;
			if (this.SelectedControl == null)
			{
				goto IL_EE;
			}
			if (!false)
			{
				if ((flag ? 1U : 0U) >= 0U)
				{
					goto IL_1A0;
				}
				goto IL_119;
			}
			IL_1C9:
			flag2 = ((flag ? 1U : 0U) < 0U);
			if (!flag2)
			{
				goto IL_B2;
			}
			IL_1DE:
			if (false)
			{
				goto IL_286;
			}
			return;
			IL_1F5:
			if (false)
			{
				goto IL_F8;
			}
			drawItemState |= DrawItemState.HotLight;
			if ((flag ? 1U : 0U) - (flag ? 1U : 0U) > 4294967295U)
			{
				goto IL_EE;
			}
			flag2 = ((flag ? 1U : 0U) + (flag ? 1U : 0U) > uint.MaxValue);
			if (flag2)
			{
				flag2 = ((flag ? 1U : 0U) - (flag ? 1U : 0U) > uint.MaxValue);
				if (!flag2)
				{
					goto IL_21F;
				}
			}
			else
			{
				flag2 = ((flag ? 1U : 0U) < 0U);
				if (flag2)
				{
					goto IL_286;
				}
				goto IL_1B0;
			}
			IL_21D:
			goto IL_1EB;
			IL_21F:
			if (base.DockContainer.Manager == null)
			{
				goto IL_21D;
			}
			if (base.DockContainer.Manager.ActiveTabbedDocument != x43bec302f92080b9)
			{
				goto IL_1EB;
			}
			drawItemState |= DrawItemState.Focus;
			goto IL_1EB;
			IL_286:
			goto IL_21F;
		}

		// Token: 0x060003F9 RID: 1017 RVA: 0x0001FED4 File Offset: 0x0001EED4
		public override DockControl GetControlAt(Point position)
		{
			if (this.xa358da7dd5364cab.Contains(position))
			{
				if (false)
				{
					goto IL_30;
				}
				if (position.X >= this.xa358da7dd5364cab.X + this.LeftPadding)
				{
					goto IL_30;
				}
				IL_2E:
				return null;
				IL_30:
				if (position.X > this.xa358da7dd5364cab.Right - this.RightPadding)
				{
					goto IL_2E;
				}
			}
			return base.GetControlAt(position);
		}

		// Token: 0x17000104 RID: 260
		// (get) Token: 0x060003FA RID: 1018 RVA: 0x0001FF34 File Offset: 0x0001EF34
		// (set) Token: 0x060003FB RID: 1019 RVA: 0x0001FF38 File Offset: 0x0001EF38
		public override bool Collapsed
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		// Token: 0x17000105 RID: 261
		// (get) Token: 0x060003FC RID: 1020 RVA: 0x0001FF3C File Offset: 0x0001EF3C
		protected virtual int LeftPadding
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x17000106 RID: 262
		// (get) Token: 0x060003FD RID: 1021 RVA: 0x0001FF40 File Offset: 0x0001EF40
		protected virtual int RightPadding
		{
			get
			{
				if (this.x49dae83181e41d72.x364c1e3b189d47fe)
				{
					goto IL_57;
				}
				if (this.x361886ff08483890.x364c1e3b189d47fe)
				{
					return base.Bounds.Right - this.x361886ff08483890.xda73fcb97c77d998.Left;
				}
				IL_2B:
				if (false)
				{
					if (-1 == 0)
					{
						goto IL_57;
					}
				}
				else if (!this.x26e80f23e22a05ae.x364c1e3b189d47fe)
				{
					return 0;
				}
				return base.Bounds.Right - this.x26e80f23e22a05ae.xda73fcb97c77d998.Left;
				IL_57:
				if (255 != 0)
				{
					return base.Bounds.Right - this.x49dae83181e41d72.xda73fcb97c77d998.Left;
				}
				goto IL_2B;
			}
		}

		// Token: 0x060003FE RID: 1022 RVA: 0x0001FFEC File Offset: 0x0001EFEC
		protected override void CalculateLayout(RendererBase renderer, Rectangle bounds, bool floating, out Rectangle titlebarBounds, out Rectangle tabstripBounds, out Rectangle clientBounds, out Rectangle joinCatchmentBounds)
		{
			titlebarBounds = Rectangle.Empty;
			tabstripBounds = bounds;
			bool flag;
			do
			{
				tabstripBounds.Height = renderer.DocumentTabStripSize;
				bounds.Offset(0, renderer.DocumentTabStripSize);
				bounds.Height -= renderer.DocumentTabStripSize;
				clientBounds = bounds;
				joinCatchmentBounds = tabstripBounds;
				flag = (((floating ? 1U : 0U) & 0U) == 0U);
			}
			while (!flag);
		}

		// Token: 0x060003FF RID: 1023 RVA: 0x0002006C File Offset: 0x0001F06C
		protected internal override void Layout(RendererBase renderer, Graphics graphics, Rectangle bounds, bool floating)
		{
			base.Layout(renderer, graphics, bounds, floating);
			this.xd00751399198ecd1(renderer, graphics, this.xa358da7dd5364cab);
			this.x5d6e30ce9634c49e(renderer, graphics, this.xa358da7dd5364cab);
		}

		// Token: 0x06000400 RID: 1024 RVA: 0x00020098 File Offset: 0x0001F098
		private void xd00751399198ecd1(RendererBase x38870620fd380a6b, Graphics x41347a961b838962, Rectangle xa358da7dd5364cab)
		{
			int num = xa358da7dd5364cab.Top + xa358da7dd5364cab.Height / 2 - 7;
			if (((uint)num & 0U) == 0U)
			{
				goto IL_1CD;
			}
			bool flag = (uint)num - (uint)num < 0U;
			if (!flag)
			{
				goto IL_14F;
			}
			return;
			IL_13D:
			int num2;
			if (this.SelectedControl == null)
			{
				if (15 == 0)
				{
					goto IL_1DD;
				}
			}
			else if (this.SelectedControl.AllowClose && !this.xa957e8f86f5e6115)
			{
				this.x26e80f23e22a05ae.x364c1e3b189d47fe = true;
				this.x26e80f23e22a05ae.xda73fcb97c77d998 = new Rectangle(num2 - 14, num, 14, 15);
				num2 -= 15;
				flag = ((uint)num2 + (uint)num < 0U);
				if (flag)
				{
					goto IL_1CD;
				}
				goto IL_15B;
			}
			IL_14F:
			this.x26e80f23e22a05ae.x364c1e3b189d47fe = false;
			IL_15B:
			this.xa8ae81960654bc0b.x364c1e3b189d47fe = false;
			this.x49dae83181e41d72.x364c1e3b189d47fe = false;
			for (;;)
			{
				this.x361886ff08483890.x364c1e3b189d47fe = false;
				switch (this.x7d2c5325d16e569d)
				{
				case DocumentOverflowMode.Scrollable:
					this.xa8ae81960654bc0b.x364c1e3b189d47fe = true;
					this.xa8ae81960654bc0b.xda73fcb97c77d998 = new Rectangle(num2 - 14, num, 14, 15);
					num2 -= 15;
					flag = ((uint)num - (uint)num < 0U);
					if (flag)
					{
						continue;
					}
					goto IL_125;
				case DocumentOverflowMode.Menu:
					goto IL_47;
				}
				return;
			}
			IL_47:
			this.x361886ff08483890.x364c1e3b189d47fe = true;
			this.x361886ff08483890.xda73fcb97c77d998 = new Rectangle(num2 - 14, num, 14, 15);
			num2 -= 15;
			return;
			IL_125:
			this.x49dae83181e41d72.x364c1e3b189d47fe = true;
			this.x49dae83181e41d72.xda73fcb97c77d998 = new Rectangle(num2 - 14, num, 14, 15);
			num2 -= 15;
			if (((uint)num | 8U) == 0U)
			{
				goto IL_14F;
			}
			if (false)
			{
				goto IL_13D;
			}
			return;
			IL_1CD:
			num2 = xa358da7dd5364cab.Right - 2;
			if (false)
			{
				return;
			}
			IL_1DD:
			goto IL_13D;
		}

		// Token: 0x06000401 RID: 1025 RVA: 0x0002028C File Offset: 0x0001F28C
		private void x5d6e30ce9634c49e(RendererBase x38870620fd380a6b, Graphics x41347a961b838962, Rectangle xa358da7dd5364cab)
		{
			int num = 3;
			int num2;
			bool flag;
			int num3;
			using (IEnumerator enumerator = base.Controls.GetEnumerator())
			{
				for (;;)
				{
					DockControl dockControl;
					DrawItemState drawItemState;
					if (!enumerator.MoveNext())
					{
						flag = (((uint)num2 | 4U) == 0U);
						if (!flag)
						{
							break;
						}
						if ((uint)num3 + (uint)num >= 0U)
						{
							goto IL_2C7;
						}
					}
					else
					{
						dockControl = (DockControl)enumerator.Current;
						dockControl.xcfac6723d8a41375 = false;
						if (((uint)num2 & 0U) == 0U)
						{
							drawItemState = DrawItemState.Default;
							do
							{
								flag = ((uint)num2 + (uint)num < 0U);
								if (!flag)
								{
									goto IL_3A3;
								}
								flag = (((uint)num3 & 0U) == 0U);
							}
							while (!flag);
							if ((uint)num > 4294967295U)
							{
								goto IL_279;
							}
							IL_451:
							drawItemState |= DrawItemState.Selected;
							goto IL_47F;
							IL_3A3:
							if (this.SelectedControl == dockControl)
							{
								goto IL_451;
							}
							if (((uint)num & 0U) != 0U)
							{
								goto IL_3C3;
							}
							goto IL_350;
						}
						IL_47F:
						if (base.DockContainer.Manager == null)
						{
							goto IL_368;
						}
						flag = ((uint)num2 + (uint)num2 < 0U);
						if (flag)
						{
							goto IL_400;
						}
						goto IL_3C3;
					}
					IL_28B:
					dockControl.x123e054dab107457 = new Rectangle(num, xa358da7dd5364cab.Bottom - x38870620fd380a6b.DocumentTabSize, num3, x38870620fd380a6b.DocumentTabSize);
					num += num3 - x38870620fd380a6b.DocumentTabExtra + 1;
					continue;
					IL_279:
					if (dockControl.MaximumTabWidth < num3)
					{
						num3 = dockControl.MaximumTabWidth;
						dockControl.xcfac6723d8a41375 = true;
						goto IL_28B;
					}
					if (!false)
					{
						goto IL_28B;
					}
					goto IL_350;
					IL_2C7:
					if (false)
					{
						goto IL_279;
					}
					goto IL_28B;
					IL_368:
					num3 = x38870620fd380a6b.MeasureDocumentStripTab(x41347a961b838962, dockControl.TabImage, dockControl.TabText, dockControl.Font, drawItemState).Width;
					if (!this.xa957e8f86f5e6115)
					{
						goto IL_323;
					}
					if (!dockControl.AllowClose)
					{
						goto IL_323;
					}
					num3 += 17;
					if (2147483647 != 0)
					{
						goto IL_323;
					}
					IL_271:
					if (dockControl.MaximumTabWidth != 0)
					{
						goto IL_279;
					}
					goto IL_2C7;
					IL_323:
					if (dockControl.MinimumTabWidth == 0)
					{
						if (false)
						{
							goto IL_279;
						}
					}
					else
					{
						num3 = Math.Max(num3, dockControl.MinimumTabWidth);
					}
					goto IL_271;
					IL_400:
					drawItemState |= DrawItemState.Focus;
					goto IL_368;
					IL_3C3:
					if (base.DockContainer.Manager.ActiveTabbedDocument != dockControl)
					{
						goto IL_368;
					}
					goto IL_400;
					IL_350:
					if ((uint)num2 - (uint)num3 >= 0U)
					{
						goto IL_368;
					}
					goto IL_3C3;
				}
				goto IL_1EF;
			}
			IL_1B4:
			if (this.x4f8ccd50477a481e < 0)
			{
				this.x4f8ccd50477a481e = 0;
			}
			IL_1BD:
			if (this.x200b7f5a9d983ba4 > this.x4f8ccd50477a481e)
			{
				this.x200b7f5a9d983ba4 = this.x4f8ccd50477a481e;
				flag = ((uint)num3 > uint.MaxValue);
				if (flag)
				{
					flag = ((uint)num3 - (uint)num > uint.MaxValue);
					if (!flag)
					{
						goto IL_1D0;
					}
					if ((uint)num + (uint)num <= 4294967295U)
					{
						goto IL_1B4;
					}
					goto IL_200;
				}
				else if (((uint)num2 | 2147483647U) == 0U)
				{
					goto IL_141;
				}
			}
			this.x49dae83181e41d72.x2fef7d841879a711 = (this.x200b7f5a9d983ba4 > 0);
			IL_141:
			this.xa8ae81960654bc0b.x2fef7d841879a711 = (this.x200b7f5a9d983ba4 < this.x4f8ccd50477a481e);
			if (2 != 0)
			{
				foreach (object obj in base.Controls)
				{
					DockControl dockControl2 = (DockControl)obj;
					if (((uint)num2 | 8U) != 0U)
					{
						Rectangle x123e054dab = dockControl2.x123e054dab107457;
						x123e054dab.Offset(xa358da7dd5364cab.Left + this.LeftPadding - this.x200b7f5a9d983ba4, 0);
						dockControl2.x123e054dab107457 = x123e054dab;
					}
				}
				if (this.xa957e8f86f5e6115)
				{
					if (this.SelectedControl != null)
					{
						if (this.SelectedControl.AllowClose)
						{
							this.x26e80f23e22a05ae.x364c1e3b189d47fe = true;
							Rectangle x123e054dab2 = this.SelectedControl.x123e054dab107457;
							this.x26e80f23e22a05ae.xda73fcb97c77d998 = new Rectangle(x123e054dab2.Right - 17, x123e054dab2.Top + 2, 14, x123e054dab2.Height - 3);
						}
					}
				}
				return;
			}
			IL_1D0:
			goto IL_1B4;
			IL_1EF:
			if (base.Controls.Count != 0)
			{
				num += x38870620fd380a6b.DocumentTabExtra;
			}
			num += 3;
			IL_200:
			num2 = xa358da7dd5364cab.Width - this.LeftPadding - this.RightPadding;
			this.x4f8ccd50477a481e = num - num2;
			flag = (((uint)num3 & 0U) == 0U);
			if (!flag)
			{
				goto IL_1BD;
			}
			flag = ((uint)num3 - (uint)num3 > uint.MaxValue);
			if (flag)
			{
				goto IL_1EF;
			}
			goto IL_1D0;
		}

		// Token: 0x17000107 RID: 263
		// (get) Token: 0x06000402 RID: 1026 RVA: 0x00020784 File Offset: 0x0001F784
		// (set) Token: 0x06000403 RID: 1027 RVA: 0x0002078C File Offset: 0x0001F78C
		public override DockControl SelectedControl
		{
			get
			{
				return base.SelectedControl;
			}
			set
			{
				base.SelectedControl = value;
				if (!false && value == null)
				{
					if (!false)
					{
						return;
					}
				}
				else
				{
					if (base.DockContainer == null)
					{
						return;
					}
					if (!false)
					{
					}
				}
				if (base.DockContainer.IsHandleCreated)
				{
					Control dockContainer = base.DockContainer;
					Delegate method = new EventHandler(this.x71ad9ee77d4aa721);
					object[] args = new object[2];
					dockContainer.BeginInvoke(method, args);
				}
			}
		}

		// Token: 0x06000404 RID: 1028 RVA: 0x000207F0 File Offset: 0x0001F7F0
		private void x71ad9ee77d4aa721(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			if (base.DockContainer != null && this.SelectedControl != null)
			{
				this.xd4949976eef9c304(this.SelectedControl);
			}
		}

		// Token: 0x06000405 RID: 1029 RVA: 0x00020814 File Offset: 0x0001F814
		private void xd4949976eef9c304(DockControl x43bec302f92080b9)
		{
			if (this.x4f8ccd50477a481e > 0)
			{
				Rectangle x123e054dab = x43bec302f92080b9.x123e054dab107457;
				int num;
				int num2;
				int num4;
				if ((uint)num + (uint)num2 <= 4294967295U)
				{
					int num3 = this.xa358da7dd5364cab.Right - this.RightPadding;
					num2 = this.xa358da7dd5364cab.Left + this.LeftPadding;
					num = num3 - num2;
					num4 = 0;
					if ((uint)num2 - (uint)num < 0U || x123e054dab.Right > num3)
					{
						num4 = x123e054dab.Right - num + 30;
					}
					if (x123e054dab.Left < num2)
					{
						num4 = x123e054dab.Left - num2 - 30;
					}
				}
				if (num4 != 0)
				{
					this.x523c1f22a806032d(num4);
				}
			}
		}

		// Token: 0x06000406 RID: 1030 RVA: 0x000208E0 File Offset: 0x0001F8E0
		private void xd11b6d3bf98020cb()
		{
			this.x5d56ae798b9cdf38.Enabled = false;
			base.x1f43ebe301d1df45 = null;
			this.xfa5e20eb950b9ee1 = false;
			this.xd541e2fc281b554b();
		}

		// Token: 0x06000407 RID: 1031 RVA: 0x00020904 File Offset: 0x0001F904
		private void xcf8b319f2bffca87()
		{
			this.x5d56ae798b9cdf38.Enabled = true;
			this.xcaf19fd9570f4eb4(this.x5d56ae798b9cdf38, EventArgs.Empty);
		}

		// Token: 0x06000408 RID: 1032 RVA: 0x00020924 File Offset: 0x0001F924
		private void x523c1f22a806032d(int xa00f04d8b3a6664c)
		{
			this.x200b7f5a9d983ba4 += xa00f04d8b3a6664c;
			for (;;)
			{
				if (this.x200b7f5a9d983ba4 > this.x4f8ccd50477a481e)
				{
					this.x200b7f5a9d983ba4 = this.x4f8ccd50477a481e;
					goto IL_4E;
				}
				IL_64:
				if (this.x200b7f5a9d983ba4 >= 0)
				{
					goto IL_1D;
				}
				if (!false)
				{
					this.x200b7f5a9d983ba4 = 0;
					if (((uint)xa00f04d8b3a6664c & 0U) != 0U)
					{
						continue;
					}
				}
				if (-1 != 0)
				{
					break;
				}
				IL_4E:
				this.xd11b6d3bf98020cb();
				goto IL_64;
			}
			this.xd11b6d3bf98020cb();
			IL_1D:
			base.x3e0280cae730d1f2();
		}

		// Token: 0x06000409 RID: 1033 RVA: 0x000209A4 File Offset: 0x0001F9A4
		private void xcaf19fd9570f4eb4(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			if (base.x1f43ebe301d1df45 != this.x49dae83181e41d72)
			{
				while (base.x1f43ebe301d1df45 == this.xa8ae81960654bc0b)
				{
					this.x523c1f22a806032d(15);
					if (-1 != 0)
					{
						return;
					}
					if (false)
					{
						return;
					}
				}
				this.xd11b6d3bf98020cb();
				if (!false)
				{
					return;
				}
			}
			this.x523c1f22a806032d(-15);
		}

		// Token: 0x04000149 RID: 329
		private const int x1e9b7c427b6c44fa = 14;

		// Token: 0x0400014A RID: 330
		private const int x26539fe4604823df = 15;

		// Token: 0x0400014B RID: 331
		private const int x088e2ac38f89d005 = 17;

		// Token: 0x0400014C RID: 332
		private int x200b7f5a9d983ba4;

		// Token: 0x0400014D RID: 333
		private int x4f8ccd50477a481e;

		// Token: 0x0400014E RID: 334
		private Timer x5d56ae798b9cdf38;

		// Token: 0x0400014F RID: 335
		private DockControl x9241b98e8e24ab0c;

		// Token: 0x04000150 RID: 336
		private x0a9f5257a10031b2 x49dae83181e41d72;

		// Token: 0x04000151 RID: 337
		private x0a9f5257a10031b2 xa8ae81960654bc0b;

		// Token: 0x04000152 RID: 338
		private x0a9f5257a10031b2 x26e80f23e22a05ae;

		// Token: 0x04000153 RID: 339
		private x0a9f5257a10031b2 x361886ff08483890;
	}
}
