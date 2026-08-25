using System;
using System.Runtime.InteropServices;

namespace Microsoft.Windows.Controls
{
	// Token: 0x0200003B RID: 59
	internal class NativeMethods
	{
		// Token: 0x060004C5 RID: 1221 RVA: 0x00012FA2 File Offset: 0x000111A2
		private NativeMethods()
		{
		}

		// Token: 0x060004C6 RID: 1222
		[DllImport("User32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
		internal static extern int GetDoubleClickTime();
	}
}
