using System;
using System.Windows.Controls;

namespace System.Windows
{
	// Token: 0x02000029 RID: 41
	public sealed class VisualStateChangedEventArgs : EventArgs
	{
		// Token: 0x06000250 RID: 592 RVA: 0x000095C3 File Offset: 0x000077C3
		internal VisualStateChangedEventArgs(VisualState oldState, VisualState newState, Control control)
		{
			this._oldState = oldState;
			this._newState = newState;
			this._control = control;
		}

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x06000251 RID: 593 RVA: 0x000095E0 File Offset: 0x000077E0
		public VisualState OldState
		{
			get
			{
				return this._oldState;
			}
		}

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x06000252 RID: 594 RVA: 0x000095E8 File Offset: 0x000077E8
		public VisualState NewState
		{
			get
			{
				return this._newState;
			}
		}

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x06000253 RID: 595 RVA: 0x000095F0 File Offset: 0x000077F0
		public Control Control
		{
			get
			{
				return this._control;
			}
		}

		// Token: 0x0400008E RID: 142
		private VisualState _oldState;

		// Token: 0x0400008F RID: 143
		private VisualState _newState;

		// Token: 0x04000090 RID: 144
		private Control _control;
	}
}
