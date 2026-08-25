using System;
using System.Drawing;
using System.Windows.Forms;

namespace TD.SandBar
{
	// Token: 0x02000006 RID: 6
	public interface IComboBoxRenderer : IDisposable
	{
		// Token: 0x06000025 RID: 37
		void DrawComboBox(ComboBox comboBox, Graphics graphics, Rectangle bounds, DrawItemState state, bool rightToLeft);
	}
}
