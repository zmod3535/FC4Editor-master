using System;
using System.Windows;

namespace Microsoft.Windows.Controls
{
	// Token: 0x02000068 RID: 104
	public class DataGridRowDetailsEventArgs : EventArgs
	{
		// Token: 0x060007B0 RID: 1968 RVA: 0x000227A7 File Offset: 0x000209A7
		public DataGridRowDetailsEventArgs(DataGridRow row, FrameworkElement detailsElement)
		{
			this.Row = row;
			this.DetailsElement = detailsElement;
		}

		// Token: 0x170001DB RID: 475
		// (get) Token: 0x060007B1 RID: 1969 RVA: 0x000227BD File Offset: 0x000209BD
		// (set) Token: 0x060007B2 RID: 1970 RVA: 0x000227C5 File Offset: 0x000209C5
		public FrameworkElement DetailsElement { get; private set; }

		// Token: 0x170001DC RID: 476
		// (get) Token: 0x060007B3 RID: 1971 RVA: 0x000227CE File Offset: 0x000209CE
		// (set) Token: 0x060007B4 RID: 1972 RVA: 0x000227D6 File Offset: 0x000209D6
		public DataGridRow Row { get; private set; }
	}
}
