using System;
using System.Windows.Forms;

namespace TD.SandBar
{
	// Token: 0x0200003F RID: 63
	internal partial class x5b55bb129f506dac : Form
	{
		// Token: 0x06000384 RID: 900 RVA: 0x00011DA4 File Offset: 0x00010DA4
		internal virtual void x2c6f5ac62ee048e5()
		{
			x443cc432acaadb1d.ShowWindow(base.Handle, 4);
		}

		// Token: 0x06000385 RID: 901 RVA: 0x00011DB4 File Offset: 0x00010DB4
		protected override void WndProc(ref Message m)
		{
			if (m.Msg == 33)
			{
				m.Result = new IntPtr(3);
				return;
			}
			base.WndProc(ref m);
		}
	}
}
