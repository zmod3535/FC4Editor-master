using System;

namespace Microsoft.Windows.Controls
{
	// Token: 0x02000074 RID: 116
	public class InitializingNewItemEventArgs : EventArgs
	{
		// Token: 0x0600081D RID: 2077 RVA: 0x00024374 File Offset: 0x00022574
		public InitializingNewItemEventArgs(object newItem)
		{
			this._newItem = newItem;
		}

		// Token: 0x170001F4 RID: 500
		// (get) Token: 0x0600081E RID: 2078 RVA: 0x00024383 File Offset: 0x00022583
		public object NewItem
		{
			get
			{
				return this._newItem;
			}
		}

		// Token: 0x04000290 RID: 656
		private object _newItem;
	}
}
