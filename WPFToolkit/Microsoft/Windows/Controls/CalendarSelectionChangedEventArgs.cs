using System;
using System.Collections;
using System.Windows;
using System.Windows.Controls;

namespace Microsoft.Windows.Controls
{
	// Token: 0x02000076 RID: 118
	internal class CalendarSelectionChangedEventArgs : SelectionChangedEventArgs
	{
		// Token: 0x06000886 RID: 2182 RVA: 0x00026E2C File Offset: 0x0002502C
		public CalendarSelectionChangedEventArgs(RoutedEvent eventId, IList removedItems, IList addedItems) : base(eventId, removedItems, addedItems)
		{
		}

		// Token: 0x06000887 RID: 2183 RVA: 0x00026E38 File Offset: 0x00025038
		protected override void InvokeEventHandler(Delegate genericHandler, object genericTarget)
		{
			EventHandler<SelectionChangedEventArgs> eventHandler = genericHandler as EventHandler<SelectionChangedEventArgs>;
			if (eventHandler != null)
			{
				eventHandler(genericTarget, this);
				return;
			}
			base.InvokeEventHandler(genericHandler, genericTarget);
		}
	}
}
