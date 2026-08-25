using System;
using System.Drawing;
using System.Windows.Forms;

namespace TD.SandDock
{
	// Token: 0x0200003F RID: 63
	internal partial class xd936980ea1aac341 : Form
	{
		// Token: 0x060004B0 RID: 1200 RVA: 0x000241EC File Offset: 0x000231EC
		public xd936980ea1aac341(x410f3612b9a8f9de container)
		{
			this.xd3311d815ca25f02 = container;
			base.FormBorderStyle = FormBorderStyle.SizableToolWindow;
			base.StartPosition = FormStartPosition.Manual;
			base.ShowInTaskbar = false;
		}

		// Token: 0x060004B1 RID: 1201 RVA: 0x00024210 File Offset: 0x00023210
		protected override void OnActivated(EventArgs e)
		{
			base.OnActivated(e);
			ControlLayoutSystem controlLayoutSystem;
			if (4 != 0 && this.xd3311d815ca25f02.ActiveControl != null)
			{
				if (2 == 0)
				{
					return;
				}
				if (!false)
				{
					return;
				}
			}
			else
			{
				controlLayoutSystem = LayoutUtilities.FindControlLayoutSystem(this.xd3311d815ca25f02);
				if (4 == 0)
				{
					goto IL_18;
				}
			}
			if (controlLayoutSystem == null)
			{
				return;
			}
			IL_18:
			if (controlLayoutSystem.SelectedControl != null)
			{
				this.xd3311d815ca25f02.ActiveControl = controlLayoutSystem.SelectedControl;
			}
		}

		// Token: 0x060004B2 RID: 1202 RVA: 0x00024280 File Offset: 0x00023280
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			DockControl[] x9476096be9672d;
			int num;
			if (2 != 0)
			{
				if (!false && this.xd3311d815ca25f02 == null)
				{
					return;
				}
				x9476096be9672d = this.xd3311d815ca25f02.LayoutSystem.x9476096be9672d38;
				num = 0;
				goto IL_12;
			}
			IL_0E:
			num++;
			IL_12:
			if (num < x9476096be9672d.Length)
			{
				DockControl dockControl = x9476096be9672d[num];
				if (((uint)num & 0U) == 0U)
				{
					bool flag = ((uint)num & 0U) == 0U;
					if (flag)
					{
					}
					dockControl.FloatingSize = base.Size;
				}
				if (-2 != 0)
				{
					goto IL_0E;
				}
			}
		}

		// Token: 0x060004B3 RID: 1203 RVA: 0x00024310 File Offset: 0x00023310
		protected override void OnMove(EventArgs e)
		{
			base.OnMove(e);
			if (2 != 0)
			{
			}
			while (this.xd3311d815ca25f02 != null)
			{
				DockControl[] x9476096be9672d = this.xd3311d815ca25f02.LayoutSystem.x9476096be9672d38;
				int i;
				for (i = 0; i < x9476096be9672d.Length; i++)
				{
					DockControl dockControl = x9476096be9672d[i];
					dockControl.FloatingLocation = base.Location;
				}
				bool flag = (uint)i - (uint)i > uint.MaxValue;
				if (!flag)
				{
					return;
				}
			}
		}

		// Token: 0x060004B4 RID: 1204 RVA: 0x00024380 File Offset: 0x00023380
		private bool x8956f13386ebab05()
		{
			if (this.xd3311d815ca25f02.HasSingleControlLayoutSystem)
			{
				ControlLayoutSystem controlLayoutSystem;
				for (;;)
				{
					controlLayoutSystem = (ControlLayoutSystem)this.xd3311d815ca25f02.LayoutSystem.LayoutSystems[0];
					if (controlLayoutSystem.SelectedControl != null)
					{
						break;
					}
					if (2147483647 != 0)
					{
						return false;
					}
				}
				this.xd3311d815ca25f02.x8ba6fce4f4601549(new ShowControlContextMenuEventArgs(controlLayoutSystem.SelectedControl, controlLayoutSystem.SelectedControl.PointToClient(Cursor.Position), ContextMenuContext.RightClick));
				return true;
			}
			return false;
		}

		// Token: 0x060004B5 RID: 1205 RVA: 0x000243F4 File Offset: 0x000233F4
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			this.x6afebf16b45c02e0 = Point.Empty;
		}

		// Token: 0x060004B6 RID: 1206 RVA: 0x00024408 File Offset: 0x00023408
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			for (;;)
			{
				while (e.Button == MouseButtons.Left)
				{
					if (!(this.x6afebf16b45c02e0 != Point.Empty))
					{
						break;
					}
					Rectangle rectangle = new Rectangle(this.x6afebf16b45c02e0, SystemInformation.DragSize);
					rectangle.Offset(-SystemInformation.DragSize.Width / 2, -SystemInformation.DragSize.Height / 2);
					if (rectangle.Contains(e.X, e.Y))
					{
						break;
					}
					this.x6afebf16b45c02e0.Y = this.x6afebf16b45c02e0.Y + (SystemInformation.ToolWindowCaptionHeight + SystemInformation.FrameBorderSize.Height);
					if (!false)
					{
					}
					this.xd3311d815ca25f02.LayoutSystem.xe9a159cd1e028df2(this.xd3311d815ca25f02.Manager, this.xd3311d815ca25f02, this.xd3311d815ca25f02.LayoutSystem, null, this.xd3311d815ca25f02.xbe0b15fe97a1ee89.MetaData.DockedContentSize, this.x6afebf16b45c02e0, this.xd3311d815ca25f02.Manager.DockingHints, this.xd3311d815ca25f02.Manager.DockingManager);
					this.xd3311d815ca25f02.x3df31cf55a47bc37 = this.xd3311d815ca25f02.LayoutSystem;
					base.Capture = false;
					this.xd3311d815ca25f02.Capture = true;
					if (!false)
					{
						this.x6afebf16b45c02e0 = Point.Empty;
						if (!false)
						{
							break;
						}
					}
				}
				break;
			}
		}

		// Token: 0x060004B7 RID: 1207 RVA: 0x00024590 File Offset: 0x00023590
		protected override void WndProc(ref Message m)
		{
			IntPtr wparam;
			IntPtr wparam2;
			if (m.Msg == 161)
			{
				bool flag = (uint)wparam - (uint)wparam2 > uint.MaxValue;
				if (!flag)
				{
					wparam = m.WParam;
					flag = ((uint)wparam - (uint)wparam2 > uint.MaxValue);
					if (!flag)
					{
						goto IL_5D;
					}
					if (2 == 0)
					{
						goto IL_15D;
					}
					goto IL_12A;
				}
			}
			else if (m.Msg == 163)
			{
				if ((uint)wparam2 + (uint)wparam > 4294967295U)
				{
					goto IL_5D;
				}
				wparam2 = m.WParam;
				bool flag = (uint)wparam2 - (uint)wparam < 0U;
				if (flag)
				{
					goto IL_12A;
				}
				goto IL_15D;
			}
			else
			{
				if (m.Msg != 164)
				{
					goto IL_51;
				}
				base.Capture = false;
				if (this.x8956f13386ebab05())
				{
					m.Result = IntPtr.Zero;
					return;
				}
				goto IL_51;
			}
			IL_2B:
			if ((uint)wparam + (uint)wparam >= 0U)
			{
				goto IL_51;
			}
			IL_2D:
			if (wparam2.ToInt32() == 2)
			{
				this.OnDoubleClick(EventArgs.Empty);
				m.Result = IntPtr.Zero;
				return;
			}
			IL_51:
			base.WndProc(ref m);
			return;
			IL_5D:
			if (wparam.ToInt32() != 2)
			{
				goto IL_2B;
			}
			IL_12A:
			x443cc432acaadb1d.ReleaseCapture();
			base.Activate();
			this.x6afebf16b45c02e0 = base.PointToClient(Cursor.Position);
			base.Capture = true;
			m.Result = IntPtr.Zero;
			return;
			IL_15D:
			goto IL_2D;
		}

		// Token: 0x04000194 RID: 404
		private const int x7260e2e8b818e128 = 2;

		// Token: 0x04000195 RID: 405
		private const int xcc781840d1708149 = 165;

		// Token: 0x04000196 RID: 406
		private const int x07ac164555740e80 = 164;

		// Token: 0x04000197 RID: 407
		private const int x5898cfc7c31e0ba4 = 161;

		// Token: 0x04000198 RID: 408
		private const int xad2c4838c7f4b06e = 163;

		// Token: 0x04000199 RID: 409
		private x410f3612b9a8f9de xd3311d815ca25f02;

		// Token: 0x0400019A RID: 410
		private Point x6afebf16b45c02e0;
	}
}
