using System;

namespace Microsoft.Windows.Controls
{
	// Token: 0x02000073 RID: 115
	public class DatePickerDateValidationErrorEventArgs : EventArgs
	{
		// Token: 0x06000816 RID: 2070 RVA: 0x0002432B File Offset: 0x0002252B
		public DatePickerDateValidationErrorEventArgs(Exception exception, string text)
		{
			this.Text = text;
			this.Exception = exception;
		}

		// Token: 0x170001F1 RID: 497
		// (get) Token: 0x06000817 RID: 2071 RVA: 0x00024341 File Offset: 0x00022541
		// (set) Token: 0x06000818 RID: 2072 RVA: 0x00024349 File Offset: 0x00022549
		public Exception Exception { get; private set; }

		// Token: 0x170001F2 RID: 498
		// (get) Token: 0x06000819 RID: 2073 RVA: 0x00024352 File Offset: 0x00022552
		// (set) Token: 0x0600081A RID: 2074 RVA: 0x0002435A File Offset: 0x0002255A
		public string Text { get; private set; }

		// Token: 0x170001F3 RID: 499
		// (get) Token: 0x0600081B RID: 2075 RVA: 0x00024363 File Offset: 0x00022563
		// (set) Token: 0x0600081C RID: 2076 RVA: 0x0002436B File Offset: 0x0002256B
		public bool ThrowException
		{
			get
			{
				return this._throwException;
			}
			set
			{
				this._throwException = value;
			}
		}

		// Token: 0x0400028D RID: 653
		private bool _throwException;
	}
}
