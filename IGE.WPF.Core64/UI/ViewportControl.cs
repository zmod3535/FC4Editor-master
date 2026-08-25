using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using IGE.Nomad;
using IGE.Properties;

namespace IGE.UI
{
	// Token: 0x02000079 RID: 121
	internal class ViewportControl : UserControl
	{
		// Token: 0x060004F8 RID: 1272 RVA: 0x00013208 File Offset: 0x00011408
		public ViewportControl()
		{
			this.InitializeComponent();
			this.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.m_invisibleCursor = new Cursor(new MemoryStream(Resources.invisible_cursor));
			base.MouseWheel += this.ViewportControl_MouseWheel;
		}

		// Token: 0x060004F9 RID: 1273 RVA: 0x00013270 File Offset: 0x00011470
		protected override bool IsInputKey(Keys keyData)
		{
			return true;
		}

		// Token: 0x060004FA RID: 1274 RVA: 0x00013274 File Offset: 0x00011474
		public override bool PreProcessMessage(ref Message msg)
		{
			bool flag = msg.Msg == 256 || msg.Msg == 260;
			bool flag2 = (msg.LParam.ToInt64() & 1073741824L) != 0L;
			if (flag)
			{
				if (!flag2)
				{
					this.BlockNextKeyRepeats = false;
				}
				else if (this.BlockNextKeyRepeats)
				{
					return true;
				}
			}
			return base.PreProcessMessage(ref msg);
		}

		// Token: 0x060004FB RID: 1275 RVA: 0x000132DC File Offset: 0x000114DC
		protected override bool ProcessKeyMessage(ref Message msg)
		{
			if (msg.Msg == 258)
			{
				IGE.Nomad.Binding.FCE_PC_KeyboardKeyEvent((char)((int)msg.WParam));
			}
			if (!Editor.IsIngame)
			{
				this.UpdateCameraState();
			}
			return Editor.HandleWindowMessage(msg.HWnd, msg.Msg, msg.WParam, msg.LParam) || base.ProcessKeyMessage(ref msg);
		}

		// Token: 0x170000FB RID: 251
		// (get) Token: 0x060004FC RID: 1276 RVA: 0x00013341 File Offset: 0x00011541
		// (set) Token: 0x060004FD RID: 1277 RVA: 0x00013349 File Offset: 0x00011549
		public bool BlockNextKeyRepeats
		{
			get
			{
				return this.m_blockNextKeyRepeats;
			}
			set
			{
				this.m_blockNextKeyRepeats = value;
			}
		}

		// Token: 0x060004FE RID: 1278 RVA: 0x00013352 File Offset: 0x00011552
		private void ViewportControl_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (this.CameraMode == ViewportControl.CameraModes.None && this.ViewportDoubleClicked != null)
			{
				this.ViewportDoubleClicked();
			}
		}

		// Token: 0x060004FF RID: 1279 RVA: 0x00013370 File Offset: 0x00011570
		private void ViewportControl_MouseDown(object sender, MouseEventArgs e)
		{
			if (this.CameraMode == ViewportControl.CameraModes.None)
			{
				MouseButtons button = e.Button;
				if (button == MouseButtons.Left)
				{
					Editor.OnMouseEvent(Editor.MouseEvent.MouseDown, e);
					return;
				}
				if (button != MouseButtons.Right)
				{
					if (button != MouseButtons.Middle)
					{
						return;
					}
					if (!Editor.IsIngame && this.CameraEnabled)
					{
						this.CameraMode = ViewportControl.CameraModes.Panning;
						return;
					}
				}
				else if (!Editor.IsIngame && this.CameraEnabled)
				{
					this.CameraMode = ViewportControl.CameraModes.Lookaround;
				}
			}
		}

		// Token: 0x06000500 RID: 1280 RVA: 0x000133E0 File Offset: 0x000115E0
		private void ViewportControl_MouseUp(object sender, MouseEventArgs e)
		{
			if (this.CameraMode == ViewportControl.CameraModes.None)
			{
				if (e.Button == MouseButtons.Left)
				{
					Editor.OnMouseEvent(Editor.MouseEvent.MouseUp, e);
					return;
				}
			}
			else if (e.Button == MouseButtons.Middle || e.Button == MouseButtons.Right)
			{
				this.CameraMode = ViewportControl.CameraModes.None;
			}
		}

		// Token: 0x06000501 RID: 1281 RVA: 0x00013430 File Offset: 0x00011630
		private void Viewport_MouseMove(object sender, MouseEventArgs e)
		{
			if (this.CaptureMouse && !Editor.IsIngame)
			{
				if (Program.MainWin.IsActive)
				{
					System.Drawing.Point position = base.PointToScreen(new System.Drawing.Point(base.Width / 2, base.Height / 2));
					int num = Cursor.Position.X - position.X;
					int num2 = Cursor.Position.Y - position.Y;
					if (num != 0 || num2 != 0)
					{
						switch (this.CameraMode)
						{
						case ViewportControl.CameraModes.Lookaround:
							Camera.Rotate((float)(EditorSettings.InvertMouseView ? num2 : (-(float)num2)) * 0.005f, 0f, (float)(-(float)num) * 0.005f);
							break;
						case ViewportControl.CameraModes.Panning:
							Camera.Position += Camera.RightVector * (float)num * 0.125f + Camera.UpVector * (float)(EditorSettings.InvertMousePan ? num2 : (-(float)num2)) * 0.125f;
							break;
						default:
							Editor.OnMouseEvent(Editor.MouseEvent.MouseMoveDelta, new MouseEventArgs(e.Button, e.Clicks, num, num2, e.Delta));
							break;
						}
						Cursor.Position = position;
						return;
					}
				}
			}
			else
			{
				this.m_normalizedMousePos = new Vec2((float)e.X / (float)base.ClientSize.Width, (float)e.Y / (float)base.ClientSize.Height);
				ObjectManager.SetViewportPickingPos(this.m_normalizedMousePos);
				Editor.OnMouseEvent(Editor.MouseEvent.MouseMove, e);
			}
		}

		// Token: 0x06000502 RID: 1282 RVA: 0x000135C0 File Offset: 0x000117C0
		private void ViewportControl_MouseEnter(object sender, EventArgs e)
		{
			if (Program.MainWin.IsActive)
			{
				base.Focus();
			}
			this.m_mouseOver = true;
			Editor.OnMouseEvent(Editor.MouseEvent.MouseEnter, null);
		}

		// Token: 0x06000503 RID: 1283 RVA: 0x000135E3 File Offset: 0x000117E3
		private void ViewportControl_Paint(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x06000504 RID: 1284 RVA: 0x000135E5 File Offset: 0x000117E5
		protected override void WndProc(ref Message m)
		{
			base.WndProc(ref m);
		}

		// Token: 0x06000505 RID: 1285 RVA: 0x000135F0 File Offset: 0x000117F0
		public void UpdateFocus()
		{
			if (Program.MainWin.IsActive)
			{
				if (this.CaptureMouse)
				{
					System.Drawing.Point position = base.PointToScreen(new System.Drawing.Point(base.Width / 2, base.Height / 2));
					Cursor.Position = position;
					this.Cursor = this.m_invisibleCursor;
					return;
				}
			}
			else if (this.CaptureMouse)
			{
				this.Cursor = this.m_defaultCursor;
			}
		}

		// Token: 0x06000506 RID: 1286 RVA: 0x00013654 File Offset: 0x00011854
		private void ViewportControl_MouseLeave(object sender, EventArgs e)
		{
			this.CameraMode = ViewportControl.CameraModes.None;
			this.m_mouseOver = false;
			Editor.OnMouseEvent(Editor.MouseEvent.MouseLeave, null);
		}

		// Token: 0x06000507 RID: 1287 RVA: 0x0001366C File Offset: 0x0001186C
		private void ViewportControl_MouseWheel(object sender, MouseEventArgs e)
		{
			if (!this.m_captureWheel)
			{
				if (!Editor.IsIngame && this.m_mouseOver)
				{
					Vec3 v;
					Vec3 v2;
					if (Editor.RayCastPhysicsFromMouse(out v))
					{
						v2 = v - Camera.Position;
						v2.Normalize();
					}
					else
					{
						v2 = Camera.FrontVector;
					}
					Camera.Position += v2 * (float)e.Delta * 0.0625f;
					return;
				}
			}
			else
			{
				Editor.OnMouseEvent(Editor.MouseEvent.MouseWheel, e);
			}
		}

		// Token: 0x06000508 RID: 1288 RVA: 0x000136E8 File Offset: 0x000118E8
		private void Viewport_Leave(object sender, EventArgs e)
		{
			this.CameraMode = ViewportControl.CameraModes.None;
			this.ResetCameraState();
		}

		// Token: 0x06000509 RID: 1289 RVA: 0x000136F8 File Offset: 0x000118F8
		public void UpdateSize()
		{
			if (base.ParentForm != null && base.ParentForm.WindowState == FormWindowState.Minimized)
			{
				return;
			}
			System.Drawing.Size clientSize = base.ClientSize;
			if (clientSize.Width < 16)
			{
				clientSize.Width = 16;
			}
			if (clientSize.Height < 16)
			{
				clientSize.Height = 16;
			}
			clientSize.Width = (int)((float)clientSize.Width * EditorSettings.ViewportQuality);
			clientSize.Height = (int)((float)clientSize.Height * EditorSettings.ViewportQuality);
			Engine.UpdateResolution(new System.Windows.Size((double)clientSize.Width, (double)clientSize.Height));
		}

		// Token: 0x0600050A RID: 1290 RVA: 0x00013791 File Offset: 0x00011991
		private void ViewportControl_Resize(object sender, EventArgs e)
		{
			this.UpdateSize();
		}

		// Token: 0x170000FC RID: 252
		// (get) Token: 0x0600050B RID: 1291 RVA: 0x00013799 File Offset: 0x00011999
		// (set) Token: 0x0600050C RID: 1292 RVA: 0x000137A4 File Offset: 0x000119A4
		public Vec2 NormalizedMousePos
		{
			get
			{
				return this.m_normalizedMousePos;
			}
			set
			{
				Cursor.Position = base.PointToScreen(new System.Drawing.Point((int)(value.X * (float)base.ClientSize.Width), (int)(value.Y * (float)base.ClientSize.Height)));
			}
		}

		// Token: 0x0600050D RID: 1293 RVA: 0x000137F4 File Offset: 0x000119F4
		private void UpdateCaptureMouse()
		{
			if (this.CaptureMouse)
			{
				this.Cursor = this.m_invisibleCursor;
				this.m_captureMousePos = Cursor.Position;
				Cursor.Position = base.PointToScreen(new System.Drawing.Point(base.Width / 2, base.Height / 2));
				return;
			}
			Cursor.Position = this.m_captureMousePos;
			this.Cursor = this.m_defaultCursor;
		}

		// Token: 0x170000FD RID: 253
		// (get) Token: 0x0600050E RID: 1294 RVA: 0x00013858 File Offset: 0x00011A58
		// (set) Token: 0x0600050F RID: 1295 RVA: 0x00013860 File Offset: 0x00011A60
		public bool CaptureMouse
		{
			get
			{
				return this.m_captureMouse;
			}
			set
			{
				if (this.m_captureMouse == value)
				{
					return;
				}
				this.m_captureMouse = value;
				this.UpdateCaptureMouse();
			}
		}

		// Token: 0x170000FE RID: 254
		// (set) Token: 0x06000510 RID: 1296 RVA: 0x0001387C File Offset: 0x00011A7C
		public Vec2 CaptureMousePos
		{
			set
			{
				this.m_captureMousePos = base.PointToScreen(new System.Drawing.Point((int)(value.X * (float)base.ClientSize.Width), (int)(value.Y * (float)base.ClientSize.Height)));
			}
		}

		// Token: 0x170000FF RID: 255
		// (get) Token: 0x06000511 RID: 1297 RVA: 0x000138CA File Offset: 0x00011ACA
		// (set) Token: 0x06000512 RID: 1298 RVA: 0x000138D2 File Offset: 0x00011AD2
		public bool CaptureWheel
		{
			get
			{
				return this.m_captureWheel;
			}
			set
			{
				this.m_captureWheel = value;
			}
		}

		// Token: 0x06000513 RID: 1299 RVA: 0x000138DB File Offset: 0x00011ADB
		private void ResetCameraState()
		{
			Camera.ForwardInput = 0f;
			Camera.LateralInput = 0f;
			Camera.SpeedFactor = 1f;
		}

		// Token: 0x06000514 RID: 1300 RVA: 0x000138FC File Offset: 0x00011AFC
		private void UpdateCameraState()
		{
			if (!Engine.Initialized)
			{
				return;
			}
			if (Engine.ConsoleOpened || !this.Focused)
			{
				this.ResetCameraState();
				return;
			}
			IntPtr keyboardLayout = Win32.GetKeyboardLayout(0);
			int nVirtKey = Win32.MapVirtualKeyEx(17, 1, keyboardLayout);
			int nVirtKey2 = Win32.MapVirtualKeyEx(31, 1, keyboardLayout);
			int nVirtKey3 = Win32.MapVirtualKeyEx(30, 1, keyboardLayout);
			int nVirtKey4 = Win32.MapVirtualKeyEx(32, 1, keyboardLayout);
			if (Win32.IsKeyDown(nVirtKey))
			{
				Camera.ForwardInput = 1f;
			}
			else if (Win32.IsKeyDown(nVirtKey2))
			{
				Camera.ForwardInput = -1f;
			}
			else
			{
				Camera.ForwardInput = 0f;
			}
			if (Win32.IsKeyDown(nVirtKey3))
			{
				Camera.LateralInput = -1f;
			}
			else if (Win32.IsKeyDown(nVirtKey4))
			{
				Camera.LateralInput = 1f;
			}
			else
			{
				Camera.LateralInput = 0f;
			}
			if (Win32.IsKeyDown(160) || Win32.IsKeyDown(161))
			{
				Camera.SpeedFactor = 8f;
				return;
			}
			Camera.SpeedFactor = this._currentSpeed;
		}

		// Token: 0x06000515 RID: 1301 RVA: 0x000139EA File Offset: 0x00011BEA
		private void UpdateCameraMode()
		{
			if (this.CameraMode != ViewportControl.CameraModes.None)
			{
				this.CaptureMouse = true;
				this.UpdateCameraState();
				return;
			}
			this.CaptureMouse = false;
			Camera.ForwardInput = 0f;
			Camera.LateralInput = 0f;
		}

		// Token: 0x17000100 RID: 256
		// (get) Token: 0x06000516 RID: 1302 RVA: 0x00013A1D File Offset: 0x00011C1D
		// (set) Token: 0x06000517 RID: 1303 RVA: 0x00013A25 File Offset: 0x00011C25
		private ViewportControl.CameraModes CameraMode
		{
			get
			{
				return this.m_cameraMode;
			}
			set
			{
				if (this.m_cameraMode == value)
				{
					return;
				}
				this.m_cameraMode = value;
				this.UpdateCameraMode();
			}
		}

		// Token: 0x17000101 RID: 257
		// (get) Token: 0x06000518 RID: 1304 RVA: 0x00013A3E File Offset: 0x00011C3E
		// (set) Token: 0x06000519 RID: 1305 RVA: 0x00013A46 File Offset: 0x00011C46
		public bool CameraEnabled
		{
			get
			{
				return this.m_cameraEnabled;
			}
			set
			{
				this.m_cameraEnabled = value;
			}
		}

		// Token: 0x17000102 RID: 258
		// (get) Token: 0x0600051A RID: 1306 RVA: 0x00013A4F File Offset: 0x00011C4F
		public bool MouseOver
		{
			get
			{
				return this.m_mouseOver;
			}
		}

		// Token: 0x0600051B RID: 1307 RVA: 0x00013A57 File Offset: 0x00011C57
		public void CameraSpeedUp()
		{
			this._currentSpeed *= 2f;
			if (this._currentSpeed > 8f)
			{
				this._currentSpeed = 1f;
			}
		}

		// Token: 0x0600051C RID: 1308 RVA: 0x00013A83 File Offset: 0x00011C83
		public void CameraSpeedDown()
		{
			this._currentSpeed *= 0.5f;
			if (this._currentSpeed < 1f)
			{
				this._currentSpeed = 8f;
			}
		}

		// Token: 0x0600051D RID: 1309 RVA: 0x00013AAF File Offset: 0x00011CAF
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600051E RID: 1310 RVA: 0x00013AD0 File Offset: 0x00011CD0
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.Name = "ViewportControl";
			base.Paint += this.ViewportControl_Paint;
			base.Leave += this.Viewport_Leave;
			base.MouseDoubleClick += this.ViewportControl_MouseDoubleClick;
			base.MouseDown += this.ViewportControl_MouseDown;
			base.MouseEnter += this.ViewportControl_MouseEnter;
			base.MouseLeave += this.ViewportControl_MouseLeave;
			base.MouseMove += this.Viewport_MouseMove;
			base.MouseUp += this.ViewportControl_MouseUp;
			base.Resize += this.ViewportControl_Resize;
			base.ResumeLayout(false);
		}

		// Token: 0x04000222 RID: 546
		private const float kSpeedBoost = 8f;

		// Token: 0x04000223 RID: 547
		private bool m_blockNextKeyRepeats;

		// Token: 0x04000224 RID: 548
		public Action ViewportDoubleClicked;

		// Token: 0x04000225 RID: 549
		private Vec2 m_normalizedMousePos;

		// Token: 0x04000226 RID: 550
		private bool m_captureMouse;

		// Token: 0x04000227 RID: 551
		private System.Drawing.Point m_captureMousePos;

		// Token: 0x04000228 RID: 552
		private bool m_captureWheel;

		// Token: 0x04000229 RID: 553
		private ViewportControl.CameraModes m_cameraMode;

		// Token: 0x0400022A RID: 554
		private bool m_cameraEnabled = true;

		// Token: 0x0400022B RID: 555
		private bool m_mouseOver;

		// Token: 0x0400022C RID: 556
		private Cursor m_defaultCursor = Cursors.Default;

		// Token: 0x0400022D RID: 557
		private Cursor m_invisibleCursor;

		// Token: 0x0400022E RID: 558
		private float _currentSpeed = 1f;

		// Token: 0x0400022F RID: 559
		private IContainer components;

		// Token: 0x0200007A RID: 122
		private enum CameraModes
		{
			// Token: 0x04000231 RID: 561
			None,
			// Token: 0x04000232 RID: 562
			Lookaround,
			// Token: 0x04000233 RID: 563
			Panning
		}
	}
}
