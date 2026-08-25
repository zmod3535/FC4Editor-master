using System;
using System.Drawing;
using System.Windows.Forms;

namespace TD.SandDock
{
	// Token: 0x02000017 RID: 23
	internal abstract class x890231ddf317379e : IDisposable, IMessageFilter
	{
		// Token: 0x14000017 RID: 23
		// (add) Token: 0x060002CE RID: 718 RVA: 0x00019F58 File Offset: 0x00018F58
		// (remove) Token: 0x060002CF RID: 719 RVA: 0x00019F74 File Offset: 0x00018F74
		public event EventHandler x868a32060451dd2e;

		// Token: 0x060002D0 RID: 720 RVA: 0x00019F90 File Offset: 0x00018F90
		public x890231ddf317379e(Control control, DockingHints dockingHints, bool hollow, int tabStripSize) : this(control, dockingHints, hollow)
		{
			this.x189455fe88a3b711 = tabStripSize;
		}

		// Token: 0x060002D1 RID: 721 RVA: 0x00019FA4 File Offset: 0x00018FA4
		public x890231ddf317379e(Control control, DockingHints dockingHints, bool hollow)
		{
			if (!false)
			{
				goto IL_185;
			}
			bool flag2;
			bool flag = (flag2 ? 1U : 0U) + (flag2 ? 1U : 0U) > uint.MaxValue;
			if (!flag)
			{
				goto IL_164;
			}
			for (;;)
			{
				IL_117:
				flag2 = OSFeature.Feature.IsPresent(OSFeature.LayeredWindows);
				if ((hollow ? 1U : 0U) - (hollow ? 1U : 0U) >= 0U)
				{
				}
				if (dockingHints == DockingHints.TranslucentFill && !flag2)
				{
					dockingHints = DockingHints.RubberBand;
				}
				IL_E7:
				this.x48cee1d69929b4fe = dockingHints;
				if (!false)
				{
					this.xa6607dfd4b3038ad = control.FindForm();
					do
					{
						if (this.xa6607dfd4b3038ad != null)
						{
							this.xa6607dfd4b3038ad.Deactivate += this.xbf6ca0f637696dc9;
						}
						control.MouseCaptureChanged += this.x772288dc6422a53d;
						if (4 == 0)
						{
							goto IL_BF;
						}
						Application.AddMessageFilter(this);
					}
					while (false);
					IL_46:
					if (dockingHints != DockingHints.TranslucentFill)
					{
						flag = ((flag2 ? 1U : 0U) - (flag2 ? 1U : 0U) > uint.MaxValue);
						if (flag)
						{
							goto IL_E1;
						}
						flag = ((hollow ? 1U : 0U) - (hollow ? 1U : 0U) < 0U);
						if (flag)
						{
							continue;
						}
						break;
					}
					else
					{
						this.x74e209c76c4b5a3e = new x7a797590a9beb775(hollow);
					}
					IL_BF:
					flag = ((hollow ? 1U : 0U) + (flag2 ? 1U : 0U) < 0U);
					if (!flag)
					{
						return;
					}
					goto IL_46;
				}
				continue;
				IL_E1:
				goto IL_E7;
			}
			flag = ((flag2 ? 1U : 0U) - (flag2 ? 1U : 0U) < 0U);
			if (!flag)
			{
				flag = ((flag2 ? 1U : 0U) - (hollow ? 1U : 0U) < 0U);
				if (flag)
				{
					goto IL_185;
				}
				return;
			}
			IL_164:
			this.x21480c2e0df4efcd = hollow;
			goto IL_117;
			IL_185:
			this.x43bec302f92080b9 = control;
			flag = ((hollow ? 1U : 0U) - (hollow ? 1U : 0U) < 0U);
			if (!flag)
			{
				goto IL_164;
			}
		}

		// Token: 0x060002D2 RID: 722 RVA: 0x0001A158 File Offset: 0x00019158
		private void x772288dc6422a53d(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			this.Cancel();
		}

		// Token: 0x060002D3 RID: 723 RVA: 0x0001A160 File Offset: 0x00019160
		internal static bool xca8cda6e489f8dd8()
		{
			bool result = false;
			if (Environment.OSVersion.Platform == PlatformID.Win32NT)
			{
				result = (Environment.OSVersion.Version >= new Version(5, 0, 0, 0));
			}
			return result;
		}

		// Token: 0x060002D4 RID: 724 RVA: 0x0001A19C File Offset: 0x0001919C
		protected void xe5e4149f382149cc(Rectangle xda73fcb97c77d998, bool x067d6ddeefb41622)
		{
			if (this.xca9fb28c817965fb == xda73fcb97c77d998)
			{
				return;
			}
			if (this.x48cee1d69929b4fe == DockingHints.RubberBand)
			{
				this.x45e11bb29ea5a4f9();
			}
			if (this.x48cee1d69929b4fe == DockingHints.RubberBand)
			{
				if (this.x21480c2e0df4efcd)
				{
					x130e0425ae2d4496.xda2defffc25953e0(null, xda73fcb97c77d998, x067d6ddeefb41622, this.x189455fe88a3b711);
					if (false)
					{
						return;
					}
				}
				else
				{
					x130e0425ae2d4496.xe5e0d1644c72aafd(null, xda73fcb97c77d998);
				}
				IL_38:
				this.xca9fb28c817965fb = xda73fcb97c77d998;
				if (!false)
				{
					this.xd0c8332c4cbc4175 = x067d6ddeefb41622;
					return;
				}
				goto IL_38;
			}
			else
			{
				this.x74e209c76c4b5a3e.xf00ba4096f8180b1(xda73fcb97c77d998, x067d6ddeefb41622);
			}
		}

		// Token: 0x060002D5 RID: 725 RVA: 0x0001A220 File Offset: 0x00019220
		protected void x11972e8742c570b8()
		{
			if (this.x48cee1d69929b4fe == DockingHints.RubberBand)
			{
				this.x45e11bb29ea5a4f9();
				return;
			}
			this.x74e209c76c4b5a3e.Hide();
		}

		// Token: 0x060002D6 RID: 726 RVA: 0x0001A23C File Offset: 0x0001923C
		private void x45e11bb29ea5a4f9()
		{
			if (this.xca9fb28c817965fb != Rectangle.Empty)
			{
				if (!this.x21480c2e0df4efcd)
				{
					x130e0425ae2d4496.xe5e0d1644c72aafd(null, this.xca9fb28c817965fb);
				}
				else
				{
					x130e0425ae2d4496.xda2defffc25953e0(null, this.xca9fb28c817965fb, this.xd0c8332c4cbc4175, this.x189455fe88a3b711);
				}
			}
			this.xca9fb28c817965fb = Rectangle.Empty;
		}

		// Token: 0x060002D7 RID: 727 RVA: 0x0001A2A0 File Offset: 0x000192A0
		public virtual void Commit()
		{
			this.Dispose();
		}

		// Token: 0x060002D8 RID: 728 RVA: 0x0001A2A8 File Offset: 0x000192A8
		public virtual void Cancel()
		{
			this.Dispose();
			if (this.x868a32060451dd2e != null)
			{
				this.x868a32060451dd2e(this, EventArgs.Empty);
			}
		}

		// Token: 0x060002D9 RID: 729 RVA: 0x0001A2CC File Offset: 0x000192CC
		public virtual void Dispose()
		{
			if (this.x43bec302f92080b9 == null)
			{
				goto IL_82;
			}
			IL_6B:
			this.x43bec302f92080b9.MouseCaptureChanged -= this.x772288dc6422a53d;
			IL_82:
			this.x11972e8742c570b8();
			if (this.x48cee1d69929b4fe == DockingHints.TranslucentFill)
			{
				if (false)
				{
					goto IL_6B;
				}
				this.x74e209c76c4b5a3e.Dispose();
				this.x74e209c76c4b5a3e = null;
			}
			IL_0F:
			if (this.xa6607dfd4b3038ad == null)
			{
				if (8 == 0)
				{
					goto IL_24;
				}
			}
			else
			{
				this.xa6607dfd4b3038ad.Deactivate -= this.xbf6ca0f637696dc9;
			}
			Application.RemoveMessageFilter(this);
			IL_24:
			this.xa6607dfd4b3038ad = null;
			this.x43bec302f92080b9 = null;
			if (!false)
			{
				return;
			}
			goto IL_0F;
		}

		// Token: 0x060002DA RID: 730 RVA: 0x0001A370 File Offset: 0x00019370
		private void xbf6ca0f637696dc9(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			this.Cancel();
		}

		// Token: 0x060002DB RID: 731 RVA: 0x0001A378 File Offset: 0x00019378
		private void x7ec1a570ae92aafb()
		{
			if (this.x48cee1d69929b4fe == DockingHints.RubberBand)
			{
				this.x45e11bb29ea5a4f9();
			}
		}

		// Token: 0x060002DC RID: 732
		public abstract void OnMouseMove(Point position);

		// Token: 0x060002DD RID: 733 RVA: 0x0001A388 File Offset: 0x00019388
		public bool PreFilterMessage(ref Message m)
		{
			if (m.Msg != 15)
			{
				goto IL_1CA;
			}
			this.x7ec1a570ae92aafb();
			IntPtr wparam;
			IntPtr wparam2;
			if ((uint)wparam - (uint)wparam2 >= 0U)
			{
				goto IL_1CA;
			}
			goto IL_D4;
			IL_13E:
			bool flag;
			while (m.Msg != 257)
			{
				if (((uint)wparam & 0U) == 0U)
				{
					flag = ((uint)wparam - (uint)wparam < 0U);
					if (!flag)
					{
						goto IL_C7;
					}
					if (!false)
					{
						goto IL_AD;
					}
					goto IL_12;
				}
			}
			goto IL_140;
			IL_12:
			IntPtr wparam3;
			if (m.Msg > 264)
			{
				flag = ((uint)wparam - (uint)wparam3 > uint.MaxValue);
				if (flag)
				{
					flag = ((uint)wparam3 - (uint)wparam3 > uint.MaxValue);
					if (!flag)
					{
						goto IL_63;
					}
				}
				else
				{
					flag = ((uint)wparam3 - (uint)wparam2 > uint.MaxValue);
					if (!flag)
					{
						return false;
					}
					flag = (((uint)wparam3 | 4294967294U) == 0U);
					if (flag)
					{
						goto IL_110;
					}
					goto IL_13E;
				}
			}
			else
			{
				this.Cancel();
			}
			return true;
			IL_51:
			if (m.Msg < 256)
			{
				return false;
			}
			goto IL_12;
			IL_63:
			if (wparam3.ToInt32() != 18)
			{
				goto IL_51;
			}
			return true;
			IL_7A:
			if (m.Msg == 261)
			{
				goto IL_C5;
			}
			IL_87:
			goto IL_51;
			IL_AD:
			flag = ((uint)wparam2 - (uint)wparam3 > uint.MaxValue);
			if (!flag)
			{
				goto IL_7A;
			}
			IL_C5:
			goto IL_D4;
			IL_C7:
			if (m.Msg != 260)
			{
				goto IL_7A;
			}
			IL_D4:
			wparam3 = m.WParam;
			goto IL_63;
			IL_110:
			if (wparam2.ToInt32() == 16)
			{
				return true;
			}
			goto IL_C7;
			IL_140:
			wparam2 = m.WParam;
			if ((uint)wparam2 - (uint)wparam >= 0U)
			{
				goto IL_110;
			}
			goto IL_AD;
			IL_1CA:
			if (m.Msg == 256)
			{
				goto IL_18A;
			}
			if (-1 == 0)
			{
				goto IL_87;
			}
			if (255 == 0)
			{
				goto IL_18A;
			}
			if (m.Msg == 257)
			{
				goto IL_18A;
			}
			IL_17B:
			if (m.Msg != 256)
			{
				goto IL_13E;
			}
			goto IL_140;
			IL_18A:
			wparam = m.WParam;
			if (wparam.ToInt32() == 17)
			{
				this.OnMouseMove(Cursor.Position);
				return false;
			}
			goto IL_17B;
		}

		// Token: 0x040000C9 RID: 201
		private const int x3ab50d2ad9712e32 = 256;

		// Token: 0x040000CA RID: 202
		private const int xacaf912f8e96627a = 257;

		// Token: 0x040000CB RID: 203
		private const int x9e72e1fc89a4d09f = 260;

		// Token: 0x040000CC RID: 204
		private const int x0099d1a3582c25df = 261;

		// Token: 0x040000CD RID: 205
		private const int xcd390c5181df4669 = 15;

		// Token: 0x040000CE RID: 206
		private Form xa6607dfd4b3038ad;

		// Token: 0x040000CF RID: 207
		private Control x43bec302f92080b9;

		// Token: 0x040000D0 RID: 208
		private DockingHints x48cee1d69929b4fe = DockingHints.TranslucentFill;

		// Token: 0x040000D1 RID: 209
		private Rectangle xca9fb28c817965fb = Rectangle.Empty;

		// Token: 0x040000D2 RID: 210
		private bool xd0c8332c4cbc4175;

		// Token: 0x040000D3 RID: 211
		private bool x21480c2e0df4efcd;

		// Token: 0x040000D4 RID: 212
		private x7a797590a9beb775 x74e209c76c4b5a3e;

		// Token: 0x040000D5 RID: 213
		private int x189455fe88a3b711 = 21;
	}
}
