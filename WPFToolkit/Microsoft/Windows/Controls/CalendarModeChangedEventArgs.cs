using System;
using System.Windows;

namespace Microsoft.Windows.Controls
{
	// Token: 0x02000013 RID: 19
	public class CalendarModeChangedEventArgs : RoutedEventArgs
	{
		// Token: 0x0600013F RID: 319 RVA: 0x00005682 File Offset: 0x00003882
		public CalendarModeChangedEventArgs(CalendarMode oldMode, CalendarMode newMode)
		{
			this.OldMode = oldMode;
			this.NewMode = newMode;
		}

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x06000140 RID: 320 RVA: 0x00005698 File Offset: 0x00003898
		// (set) Token: 0x06000141 RID: 321 RVA: 0x000056A0 File Offset: 0x000038A0
		public CalendarMode NewMode { get; private set; }

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x06000142 RID: 322 RVA: 0x000056A9 File Offset: 0x000038A9
		// (set) Token: 0x06000143 RID: 323 RVA: 0x000056B1 File Offset: 0x000038B1
		public CalendarMode OldMode { get; private set; }
	}
}
