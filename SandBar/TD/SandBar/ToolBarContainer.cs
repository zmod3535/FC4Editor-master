using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace TD.SandBar
{
	// Token: 0x0200003C RID: 60
	[Designer("TD.SandBar.Design.ToolBarContainerDesigner, SandBar.Design, Version=1.0.0.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3")]
	[ToolboxItem(false)]
	public class ToolBarContainer : ContainerControl
	{
		// Token: 0x06000338 RID: 824 RVA: 0x00010060 File Offset: 0x0000F060
		public ToolBarContainer()
		{
			this._x91f347c6e97f1846 = this.Manager;
			base.SetStyle(ControlStyles.UserPaint, true);
			base.SetStyle(ControlStyles.ResizeRedraw, true);
			base.SetStyle(ControlStyles.Selectable, false);
			this.Text = "SandBarDock";
		}

		// Token: 0x170000EB RID: 235
		// (get) Token: 0x06000339 RID: 825 RVA: 0x000100B4 File Offset: 0x0000F0B4
		// (set) Token: 0x0600033A RID: 826 RVA: 0x000100BC File Offset: 0x0000F0BC
		[DefaultValue("SandBarDock")]
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

		// Token: 0x170000EC RID: 236
		// (get) Token: 0x0600033B RID: 827 RVA: 0x000100C8 File Offset: 0x0000F0C8
		// (set) Token: 0x0600033C RID: 828 RVA: 0x000100D0 File Offset: 0x0000F0D0
		[Browsable(false)]
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

		// Token: 0x170000ED RID: 237
		// (get) Token: 0x0600033D RID: 829 RVA: 0x000100DC File Offset: 0x0000F0DC
		// (set) Token: 0x0600033E RID: 830 RVA: 0x000100E4 File Offset: 0x0000F0E4
		[Browsable(false)]
		public override Image BackgroundImage
		{
			get
			{
				return base.BackgroundImage;
			}
			set
			{
				base.BackgroundImage = value;
			}
		}

		// Token: 0x170000EE RID: 238
		// (get) Token: 0x0600033F RID: 831 RVA: 0x000100F0 File Offset: 0x0000F0F0
		// (set) Token: 0x06000340 RID: 832 RVA: 0x000100F8 File Offset: 0x0000F0F8
		[Browsable(false)]
		public override Color ForeColor
		{
			get
			{
				return base.ForeColor;
			}
			set
			{
				base.ForeColor = value;
			}
		}

		// Token: 0x06000341 RID: 833 RVA: 0x00010104 File Offset: 0x0000F104
		internal void xa2414c47d888068e()
		{
			foreach (object obj in base.Controls)
			{
				ToolBar toolBar = (ToolBar)obj;
				toolBar.xa2414c47d888068e();
			}
		}

		// Token: 0x06000342 RID: 834 RVA: 0x00010168 File Offset: 0x0000F168
		internal void x19e788b09b195d4f()
		{
			foreach (object obj in base.Controls)
			{
				ToolBar toolBar = (ToolBar)obj;
				toolBar.x19e788b09b195d4f();
			}
		}

		// Token: 0x06000343 RID: 835 RVA: 0x000101CC File Offset: 0x0000F1CC
		public int GetNextFreeDockLine()
		{
			int num = 0;
			foreach (object obj in base.Controls)
			{
				ToolBar toolBar = (ToolBar)obj;
				if (toolBar.DockLine > num)
				{
					num = toolBar.DockLine;
				}
			}
			return num + 1;
		}

		// Token: 0x170000EF RID: 239
		// (get) Token: 0x06000344 RID: 836 RVA: 0x00010240 File Offset: 0x0000F240
		// (set) Token: 0x06000345 RID: 837 RVA: 0x00010248 File Offset: 0x0000F248
		[Browsable(false)]
		public Guid Guid
		{
			get
			{
				return this.xb51cd75f17ace1ec;
			}
			set
			{
				this.xb51cd75f17ace1ec = value;
			}
		}

		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x06000346 RID: 838 RVA: 0x00010254 File Offset: 0x0000F254
		// (set) Token: 0x06000347 RID: 839 RVA: 0x0001025C File Offset: 0x0000F25C
		[Browsable(false)]
		public SandBarManager Manager
		{
			get
			{
				return this._x91f347c6e97f1846;
			}
			set
			{
				if (this._x91f347c6e97f1846 != null)
				{
					this._x91f347c6e97f1846.UnregisterToolBarContainer(this);
				}
				this._x91f347c6e97f1846 = value;
				if (this._x91f347c6e97f1846 != null)
				{
					this._x91f347c6e97f1846.RegisterToolBarContainer(this);
					foreach (object obj in base.Controls)
					{
						ToolBar toolbar = (ToolBar)obj;
						this._x91f347c6e97f1846.AddToolbar(toolbar);
					}
					if (this._x91f347c6e97f1846.OwnerForm != null)
					{
						foreach (object obj2 in base.Controls)
						{
							ToolBar toolBar = (ToolBar)obj2;
							if (toolBar is MenuBar)
							{
								((MenuBar)toolBar).OwnerForm = this._x91f347c6e97f1846.OwnerForm;
							}
						}
					}
				}
				this.xebe668a62443b65f();
			}
		}

		// Token: 0x06000348 RID: 840 RVA: 0x00010380 File Offset: 0x0000F380
		internal void xebe668a62443b65f()
		{
			base.Invalidate(true);
		}

		// Token: 0x06000349 RID: 841 RVA: 0x0001038C File Offset: 0x0000F38C
		internal void xb43d2df1d97b51f4(int x311e7a92306d7199, int x23e85093ba3a7d1d)
		{
			foreach (object obj in base.Controls)
			{
				ToolBar toolBar = (ToolBar)obj;
				if (x23e85093ba3a7d1d == -1)
				{
					if (toolBar.DockLine <= x311e7a92306d7199)
					{
						toolBar.x932e914cea303e55--;
					}
				}
				else if (x23e85093ba3a7d1d == 1 && toolBar.DockLine >= x311e7a92306d7199)
				{
					toolBar.x932e914cea303e55++;
				}
			}
		}

		// Token: 0x0600034A RID: 842 RVA: 0x00010424 File Offset: 0x0000F424
		internal void x0b8be6b766a66eec(int x311e7a92306d7199, int x23e85093ba3a7d1d)
		{
			int num = x311e7a92306d7199 + x23e85093ba3a7d1d;
			bool flag = false;
			foreach (object obj in base.Controls)
			{
				ToolBar toolBar = (ToolBar)obj;
				if (toolBar.DockLine == num)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				return;
			}
			foreach (object obj2 in base.Controls)
			{
				ToolBar toolBar2 = (ToolBar)obj2;
				if (x23e85093ba3a7d1d == -1)
				{
					if (toolBar2.DockLine < x311e7a92306d7199)
					{
						toolBar2.x932e914cea303e55--;
					}
				}
				else if (x23e85093ba3a7d1d == 1 && toolBar2.DockLine > x311e7a92306d7199)
				{
					toolBar2.x932e914cea303e55++;
				}
			}
		}

		// Token: 0x0600034B RID: 843 RVA: 0x0001052C File Offset: 0x0000F52C
		internal int xe132de531f28d339(int x311e7a92306d7199)
		{
			int num = 0;
			foreach (object obj in base.Controls)
			{
				ToolBar toolBar = (ToolBar)obj;
				if (toolBar.DockLine == x311e7a92306d7199)
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x0600034C RID: 844 RVA: 0x0001059C File Offset: 0x0000F59C
		protected override void OnHandleCreated(EventArgs e)
		{
			base.OnHandleCreated(e);
			this.xeea2f63c63de806c();
		}

		// Token: 0x0600034D RID: 845 RVA: 0x000105AC File Offset: 0x0000F5AC
		private void x1a2b7835c4f6410b(bool xa092001467a0ab7b)
		{
			if (!base.IsHandleCreated)
			{
				return;
			}
			int num = 0;
			if (base.Controls.Count != 0 && this._x91f347c6e97f1846 != null)
			{
				int[] array = new int[base.Controls.Count];
				int i;
				for (i = 0; i < base.Controls.Count; i++)
				{
					array[i] = ((ToolBar)base.Controls[i]).DockLine;
				}
				Array.Sort<int>(array);
				int[] array2 = new int[base.Controls.Count];
				int num2 = int.MinValue;
				int num3 = 0;
				int j = 0;
				while (j < array.Length)
				{
					if (array[j] != num2)
					{
						array2[num3] = array[j];
						goto IL_CC;
					}
					IL_D8:
					j++;
					if ((uint)num + (uint)i >= 0U)
					{
						continue;
					}
					IL_CC:
					num3++;
					num2 = array[j];
					goto IL_D8;
				}
				for (int k = 0; k < num3; k++)
				{
					num += this.x6a53cec2ada67e5c(array2[k], num, xa092001467a0ab7b);
				}
			}
			if (xa092001467a0ab7b)
			{
				base.Width = num;
				return;
			}
			base.Height = num;
		}

		// Token: 0x0600034E RID: 846 RVA: 0x000106C0 File Offset: 0x0000F6C0
		internal int x6a53cec2ada67e5c(int x311e7a92306d7199, int xae163081c913e829, bool xa092001467a0ab7b)
		{
			int num = 0;
			for (;;)
			{
				int num2 = 0;
				ToolBar[] array = new ToolBar[base.Controls.Count];
				int[] array2 = new int[base.Controls.Count];
				foreach (object obj in base.Controls)
				{
					ToolBar toolBar = (ToolBar)obj;
					if (toolBar.DockLine == x311e7a92306d7199 && toolBar.Visible)
					{
						array[num2] = toolBar;
						array2[num2] = toolBar.DockOffset;
						num2++;
					}
				}
				ToolBar[] array3 = new ToolBar[num2];
				Array.Copy(array, array3, num2);
				array = array3;
				int[] array4 = new int[num2];
				Array.Copy(array2, array4, num2);
				array2 = array4;
				Array.Sort<int, ToolBar>(array2, array);
				int[] array5 = new int[num2];
				int[] array6 = new int[num2];
				int num3 = 0;
				for (;;)
				{
					if (num3 >= array.Length)
					{
						int[] array7 = new int[num2];
						int num4 = 0;
						int i;
						for (i = 0; i < num2; i++)
						{
							num4 += 2;
							if (array[i].DockOffset >= num4)
							{
								array7[i] = array[i].DockOffset - num4;
								num4 = array[i].DockOffset;
							}
							num4 += array5[i] + array6[i];
						}
						if (!xa092001467a0ab7b)
						{
							goto IL_29F;
						}
						int num5 = num4 - base.ClientRectangle.Height;
						IL_2B3:
						if (num5 <= 0)
						{
							goto IL_330;
						}
						int num6;
						if ((uint)num3 >= 0U)
						{
							num6 = num2 - 1;
							goto IL_2D6;
						}
						goto IL_13;
						IL_194:
						int num7;
						bool flag;
						int num8;
						bool flag2;
						if (num7 >= num2)
						{
							flag = ((uint)num7 - (uint)i > uint.MaxValue);
							if (flag)
							{
								goto IL_1B5;
							}
							goto IL_B8;
						}
						else
						{
							array5[num7] -= (int)Math.Ceiling((double)((float)array5[num7] / (float)num8 * (float)num5));
							flag2 = (flag2 || array[num7].Overflow == ToolBarOverflow.Wrap);
							if ((uint)num5 - (uint)num5 <= 4294967295U)
							{
								goto IL_18E;
							}
							goto IL_58D;
						}
						IL_330:
						int k;
						if (num5 > 0)
						{
							for (int j = num2 - 1; j >= 0; j--)
							{
								if (array6[j] > num5)
								{
									array6[j] -= num5;
									num5 = 0;
								}
								else
								{
									num5 -= array6[j];
									array6[j] = 0;
									if ((uint)k > 4294967295U)
									{
										goto IL_311;
									}
								}
								if (num5 == 0)
								{
									break;
								}
							}
						}
						flag2 = false;
						if (num5 <= 0 || base.DesignMode)
						{
							goto IL_B8;
						}
						num8 = 0;
						int l = 0;
						int num9;
						while (l < num2)
						{
							num8 += array5[l];
							l++;
							flag = ((uint)num - (uint)num9 > uint.MaxValue);
							if (flag)
							{
								goto IL_29F;
							}
							if (((uint)xae163081c913e829 & 0U) != 0U)
							{
								goto Block_28;
							}
						}
						if (num8 > 0)
						{
							num7 = 0;
							goto IL_194;
						}
						goto IL_B8;
						IL_321:
						if (num5 != 0)
						{
							num6--;
							goto IL_32B;
						}
						goto IL_330;
						IL_311:
						goto IL_321;
						IL_18E:
						num7++;
						goto IL_194;
						IL_AA:
						if (num9 >= num2)
						{
							return num;
						}
						num4 += 2;
						Size size;
						if (xa092001467a0ab7b)
						{
							size = new Size(num, array5[num9] + array6[num9]);
						}
						else
						{
							size = new Size(array5[num9] + array6[num9], num);
						}
						if (size != array[num9].Size)
						{
							goto IL_08;
						}
						if (!array[num9].x1ee1d676c79f53ba)
						{
							goto IL_4D;
						}
						flag = ((uint)num3 + (uint)i > uint.MaxValue);
						if (flag)
						{
							goto IL_18E;
						}
						goto IL_1B5;
						IL_B8:
						if (flag2)
						{
							for (k = 0; k < num2; k++)
							{
								if (!(array[k] is ContainerBar))
								{
									Size size2 = array[k].x3385488b2bb8e38c(array5[k]);
									if (xa092001467a0ab7b && size2.Width > num)
									{
										num = size2.Width;
									}
									else if (!xa092001467a0ab7b && size2.Height > num)
									{
										num = size2.Height;
									}
								}
							}
						}
						num4 = 0;
						num9 = 0;
						goto IL_AA;
						IL_4D:
						num4 += array7[num9];
						Point point;
						if (xa092001467a0ab7b)
						{
							point = new Point(xae163081c913e829, num4);
						}
						else
						{
							point = new Point(num4, xae163081c913e829);
						}
						num4 += array5[num9] + array6[num9];
						if (point != array[num9].Location)
						{
							array[num9].Location = point;
							array[num9].Invalidate();
						}
						num9++;
						goto IL_AA;
						IL_13:
						array[num9].x1a2b7835c4f6410b(this.Manager.Renderer, xa092001467a0ab7b);
						if ((uint)k - (uint)num6 >= 0U)
						{
							array[num9].x1ee1d676c79f53ba = false;
							goto IL_4D;
						}
						goto IL_58D;
						IL_08:
						array[num9].Size = size;
						goto IL_13;
						IL_1B5:
						goto IL_08;
						IL_32B:
						if (num6 < 0)
						{
							goto IL_330;
						}
						if (array7[num6] <= num5)
						{
							num5 -= array7[num6];
							array7[num6] = 0;
							goto IL_321;
						}
						array7[num6] -= num5;
						num5 = 0;
						if ((uint)num5 - (uint)xae163081c913e829 >= 0U)
						{
							goto IL_311;
						}
						IL_2D6:
						goto IL_32B;
						IL_29F:
						num5 = num4 - base.ClientRectangle.Width;
						goto IL_2B3;
					}
					IL_58D:
					Size size3 = array[num3].xf99417bde67b156a();
					if (array[num3].Stretch)
					{
						if (xa092001467a0ab7b)
						{
							array6[num3] = base.ClientRectangle.Height - size3.Height;
						}
						else
						{
							array6[num3] = base.ClientRectangle.Width - size3.Width;
						}
						if (array6[num3] < 0)
						{
							array6[num3] = 0;
						}
					}
					if (xa092001467a0ab7b)
					{
						array5[num3] = size3.Height;
						if (size3.Width > num)
						{
							num = size3.Width;
						}
					}
					else
					{
						array5[num3] = size3.Width;
						if (size3.Height > num)
						{
							num = size3.Height;
						}
					}
					num3++;
				}
				Block_28:;
			}
			return num;
		}

		// Token: 0x0600034F RID: 847 RVA: 0x00010CA8 File Offset: 0x0000FCA8
		protected override void OnLayout(LayoutEventArgs levent)
		{
			Form form = base.FindForm();
			if (form != null && form.WindowState == FormWindowState.Minimized)
			{
				return;
			}
			if (form != null && form.WindowState == FormWindowState.Maximized && !this.xab062dafa000291a)
			{
				base.BeginInvoke(new EventHandler(this.xc131700a9e6eae5a), null);
				return;
			}
			if (levent.AffectedControl is ToolBar && levent.AffectedProperty == "Bounds")
			{
				return;
			}
			this.x1a2b7835c4f6410b(this.Dock == DockStyle.Left || this.Dock == DockStyle.Right);
		}

		// Token: 0x06000350 RID: 848 RVA: 0x00010D30 File Offset: 0x0000FD30
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			Form form = base.FindForm();
			if (base.IsHandleCreated && form != null && form.WindowState == FormWindowState.Maximized)
			{
				base.BeginInvoke(new EventHandler(this.xc131700a9e6eae5a), null);
			}
		}

		// Token: 0x06000351 RID: 849 RVA: 0x00010D74 File Offset: 0x0000FD74
		private void xc131700a9e6eae5a(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			this.xab062dafa000291a = true;
			try
			{
				base.PerformLayout();
			}
			finally
			{
				this.xab062dafa000291a = false;
			}
		}

		// Token: 0x06000352 RID: 850 RVA: 0x00010DB4 File Offset: 0x0000FDB4
		internal void xeea2f63c63de806c()
		{
			this.x1ee1d676c79f53ba = true;
			this.x1a2b7835c4f6410b(this.Dock == DockStyle.Left || this.Dock == DockStyle.Right);
		}

		// Token: 0x06000353 RID: 851 RVA: 0x00010DD8 File Offset: 0x0000FDD8
		internal void xbfd94ee78a3ab05f()
		{
			this.x1ee1d676c79f53ba = true;
			base.Invalidate(new Rectangle(0, 0, 1, 1));
		}

		// Token: 0x06000354 RID: 852 RVA: 0x00010DF0 File Offset: 0x0000FDF0
		protected override void OnPaint(PaintEventArgs e)
		{
			if (this.x1ee1d676c79f53ba)
			{
				this.x1a2b7835c4f6410b(this.Dock == DockStyle.Left || this.Dock == DockStyle.Right);
				this.x1ee1d676c79f53ba = false;
			}
		}

		// Token: 0x06000355 RID: 853 RVA: 0x00010E1C File Offset: 0x0000FE1C
		protected override void OnPaintBackground(PaintEventArgs pevent)
		{
			if (this._x91f347c6e97f1846 != null)
			{
				Rectangle screenBounds = this._x91f347c6e97f1846.GetScreenBounds();
				screenBounds = new Rectangle(base.PointToClient(new Point(screenBounds.X, screenBounds.Y)), screenBounds.Size);
				if (screenBounds.Width > 0 && screenBounds.Height > 0)
				{
					this._x91f347c6e97f1846.Renderer.DrawContainerBackground(pevent.Graphics, base.ClientRectangle, screenBounds);
					return;
				}
			}
			else
			{
				base.OnPaintBackground(pevent);
			}
		}

		// Token: 0x06000356 RID: 854 RVA: 0x00010EA0 File Offset: 0x0000FEA0
		protected override Control.ControlCollection CreateControlsInstance()
		{
			return new ToolBarContainer.x665c5a922dcff5ef(this);
		}

		// Token: 0x06000357 RID: 855 RVA: 0x00010EA8 File Offset: 0x0000FEA8
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				this.Manager = null;
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000358 RID: 856 RVA: 0x00010EBC File Offset: 0x0000FEBC
		internal bool x972331c8ecf83413()
		{
			return base.DesignMode;
		}

		// Token: 0x06000359 RID: 857 RVA: 0x00010EC4 File Offset: 0x0000FEC4
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			if (e.Button == MouseButtons.Right && this._x91f347c6e97f1846 != null)
			{
				this._x91f347c6e97f1846.ShowContextMenu((ToolBar)base.Controls[0], this, new Point(e.X, e.Y));
			}
		}

		// Token: 0x0400012F RID: 303
		private SandBarManager _x91f347c6e97f1846;

		// Token: 0x04000130 RID: 304
		private bool x1ee1d676c79f53ba;

		// Token: 0x04000131 RID: 305
		private Guid xb51cd75f17ace1ec = Guid.NewGuid();

		// Token: 0x04000132 RID: 306
		private bool xab062dafa000291a;

		// Token: 0x02000058 RID: 88
		private class x665c5a922dcff5ef : Control.ControlCollection
		{
			// Token: 0x06000407 RID: 1031 RVA: 0x000147E8 File Offset: 0x000137E8
			public x665c5a922dcff5ef(Control owner) : base(owner)
			{
				this.xd3311d815ca25f02 = (ToolBarContainer)owner;
			}

			// Token: 0x06000408 RID: 1032 RVA: 0x00014800 File Offset: 0x00013800
			public override void Add(Control value)
			{
				if (!(value is ToolBar))
				{
					throw new ArgumentException("Only toolbars can be added to a ToolBarContainer.");
				}
				if (this.xd3311d815ca25f02.Manager != null)
				{
					this.xd3311d815ca25f02.Manager.AddToolbar((ToolBar)value);
				}
				base.Add(value);
				if (value is MenuBar && this.xd3311d815ca25f02.Manager != null && this.xd3311d815ca25f02.Manager.OwnerForm != null)
				{
					((MenuBar)value).OwnerForm = this.xd3311d815ca25f02.Manager.OwnerForm;
				}
			}

			// Token: 0x06000409 RID: 1033 RVA: 0x0001488C File Offset: 0x0001388C
			public override void Remove(Control value)
			{
				base.Remove(value);
				if (this.xd3311d815ca25f02.Manager != null && this.xd3311d815ca25f02.x972331c8ecf83413())
				{
					this.xd3311d815ca25f02.Manager.RemoveToolbar((ToolBar)value);
				}
			}

			// Token: 0x040001CE RID: 462
			private ToolBarContainer xd3311d815ca25f02;
		}
	}
}
