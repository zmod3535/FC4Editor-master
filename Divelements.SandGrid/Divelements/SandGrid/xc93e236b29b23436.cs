using System;
using System.Drawing;
using System.Windows.Forms;

namespace Divelements.SandGrid
{
	// Token: 0x02000033 RID: 51
	internal class xc93e236b29b23436 : Panel
	{
		// Token: 0x060004B2 RID: 1202 RVA: 0x0001A154 File Offset: 0x00019154
		public xc93e236b29b23436()
		{
			base.BorderStyle = BorderStyle.FixedSingle;
			this.BackColor = SystemColors.Window;
			base.SetStyle(ControlStyles.Selectable, false);
			base.SetStyle(ControlStyles.ResizeRedraw, true);
		}

		// Token: 0x060004B3 RID: 1203 RVA: 0x0001A184 File Offset: 0x00019184
		protected override void OnLayout(LayoutEventArgs levent)
		{
			Rectangle displayRectangle = this.DisplayRectangle;
			foreach (object obj in base.Controls)
			{
				Control control = (Control)obj;
				control.Bounds = displayRectangle;
			}
		}
	}
}
