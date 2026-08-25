using System;
using System.Windows;

namespace Microsoft.Windows.Controls
{
	// Token: 0x02000089 RID: 137
	public class CalendarDateChangedEventArgs : RoutedEventArgs
	{
		// Token: 0x060009C5 RID: 2501 RVA: 0x0002AC83 File Offset: 0x00028E83
		internal CalendarDateChangedEventArgs(DateTime? removedDate, DateTime? addedDate)
		{
			this.RemovedDate = removedDate;
			this.AddedDate = addedDate;
		}

		// Token: 0x1700024B RID: 587
		// (get) Token: 0x060009C6 RID: 2502 RVA: 0x0002AC99 File Offset: 0x00028E99
		// (set) Token: 0x060009C7 RID: 2503 RVA: 0x0002ACA1 File Offset: 0x00028EA1
		public DateTime? AddedDate { get; private set; }

		// Token: 0x1700024C RID: 588
		// (get) Token: 0x060009C8 RID: 2504 RVA: 0x0002ACAA File Offset: 0x00028EAA
		// (set) Token: 0x060009C9 RID: 2505 RVA: 0x0002ACB2 File Offset: 0x00028EB2
		public DateTime? RemovedDate { get; private set; }
	}
}
