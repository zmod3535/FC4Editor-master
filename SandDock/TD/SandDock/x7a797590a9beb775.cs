using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TD.SandDock
{
	// Token: 0x02000019 RID: 25
	internal partial class x7a797590a9beb775 : Form
	{
		// Token: 0x060002DE RID: 734
		[DllImport("user32.dll")]
		private static extern bool SetWindowPos(HandleRef hWnd, HandleRef hWndInsertAfter, int x, int y, int cx, int cy, int flags);

		// Token: 0x060002DF RID: 735
		[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true, SetLastError = true)]
		private static extern bool SetLayeredWindowAttributes(IntPtr hwnd, int crKey, byte bAlpha, int dwFlags);

		// Token: 0x060002E0 RID: 736 RVA: 0x0001A588 File Offset: 0x00019588
		public x7a797590a9beb775(bool hollow)
		{
			this.x21480c2e0df4efcd = hollow;
			this.BackColor = SystemColors.Highlight;
			base.ShowInTaskbar = false;
			base.SetStyle(ControlStyles.ResizeRedraw, true);
		}

		// Token: 0x060002E1 RID: 737 RVA: 0x0001A5B4 File Offset: 0x000195B4
		public void xf00ba4096f8180b1(Rectangle xda73fcb97c77d998, bool x067d6ddeefb41622)
		{
			x7a797590a9beb775.SetWindowPos(new HandleRef(this, base.Handle), new HandleRef(this, IntPtr.Zero), xda73fcb97c77d998.X, xda73fcb97c77d998.Y, xda73fcb97c77d998.Width, xda73fcb97c77d998.Height, 80);
		}

		// Token: 0x060002E2 RID: 738 RVA: 0x0001A5F4 File Offset: 0x000195F4
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			do
			{
				Rectangle clientRectangle;
				if (!false)
				{
					if (!this.x21480c2e0df4efcd)
					{
						break;
					}
					clientRectangle = base.ClientRectangle;
					clientRectangle.Width--;
					if (-2 == 0)
					{
						break;
					}
					clientRectangle.Height--;
					e.Graphics.DrawRectangle(SystemPens.ControlDark, clientRectangle);
				}
				clientRectangle.Inflate(-1, -1);
				e.Graphics.DrawRectangle(SystemPens.ControlDark, clientRectangle);
			}
			while (2 == 0);
		}

		// Token: 0x060002E3 RID: 739 RVA: 0x0001A674 File Offset: 0x00019674
		protected override void OnHandleCreated(EventArgs e)
		{
			base.OnHandleCreated(e);
			x7a797590a9beb775.SetLayeredWindowAttributes(base.Handle, 0, 128, 2);
		}

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x060002E4 RID: 740 RVA: 0x0001A690 File Offset: 0x00019690
		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams createParams = base.CreateParams;
				createParams.Style = int.MinValue;
				createParams.ExStyle |= 524288;
				return createParams;
			}
		}

		// Token: 0x040000DA RID: 218
		private const int x25e1af1de31299a2 = 2;

		// Token: 0x040000DB RID: 219
		private const int xb615ddf284afbdf6 = 524288;

		// Token: 0x040000DC RID: 220
		private const int x77bf04ec211c4a37 = 16;

		// Token: 0x040000DD RID: 221
		private const int x339acab5bf3e83ae = 64;

		// Token: 0x040000DE RID: 222
		private const int xb644deafcaa222c4 = 2;

		// Token: 0x040000DF RID: 223
		private const int xb8a822e576f3bf60 = 1;

		// Token: 0x040000E0 RID: 224
		private bool x21480c2e0df4efcd;
	}
}
