using System;
using System.Windows.Input;

namespace Microsoft.Windows.Controls
{
	// Token: 0x02000088 RID: 136
	internal static class KeyboardHelper
	{
		// Token: 0x060009C4 RID: 2500 RVA: 0x0002AC69 File Offset: 0x00028E69
		public static void GetMetaKeyState(out bool ctrl, out bool shift)
		{
			ctrl = ((Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control);
			shift = ((Keyboard.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift);
		}
	}
}
