using System;
using System.Windows;
using System.Windows.Controls;

namespace Microsoft.Windows.Controls
{
	// Token: 0x02000012 RID: 18
	internal static class VisualStates
	{
		// Token: 0x0600013E RID: 318 RVA: 0x00005644 File Offset: 0x00003844
		public static void GoToState(Control control, bool useTransitions, params string[] stateNames)
		{
			if (control == null)
			{
				throw new ArgumentNullException("control");
			}
			if (stateNames == null)
			{
				return;
			}
			foreach (string stateName in stateNames)
			{
				if (System.Windows.VisualStateManager.GoToState(control, stateName, useTransitions))
				{
					return;
				}
			}
		}

		// Token: 0x04000047 RID: 71
		public const string StateCalendarButtonUnfocused = "CalendarButtonUnfocused";

		// Token: 0x04000048 RID: 72
		public const string StateCalendarButtonFocused = "CalendarButtonFocused";

		// Token: 0x04000049 RID: 73
		public const string GroupCalendarButtonFocus = "CalendarButtonFocusStates";

		// Token: 0x0400004A RID: 74
		public const string StateNormal = "Normal";

		// Token: 0x0400004B RID: 75
		public const string StateMouseOver = "MouseOver";

		// Token: 0x0400004C RID: 76
		public const string StatePressed = "Pressed";

		// Token: 0x0400004D RID: 77
		public const string StateDisabled = "Disabled";

		// Token: 0x0400004E RID: 78
		public const string GroupCommon = "CommonStates";

		// Token: 0x0400004F RID: 79
		public const string StateUnfocused = "Unfocused";

		// Token: 0x04000050 RID: 80
		public const string StateFocused = "Focused";

		// Token: 0x04000051 RID: 81
		public const string GroupFocus = "FocusStates";

		// Token: 0x04000052 RID: 82
		public const string StateSelected = "Selected";

		// Token: 0x04000053 RID: 83
		public const string StateUnselected = "Unselected";

		// Token: 0x04000054 RID: 84
		public const string GroupSelection = "SelectionStates";

		// Token: 0x04000055 RID: 85
		public const string StateActive = "Active";

		// Token: 0x04000056 RID: 86
		public const string StateInactive = "Inactive";

		// Token: 0x04000057 RID: 87
		public const string GroupActive = "ActiveStates";

		// Token: 0x04000058 RID: 88
		public const string StateValid = "Valid";

		// Token: 0x04000059 RID: 89
		public const string StateInvalidFocused = "InvalidFocused";

		// Token: 0x0400005A RID: 90
		public const string StateInvalidUnfocused = "InvalidUnfocused";

		// Token: 0x0400005B RID: 91
		public const string GroupValidation = "ValidationStates";

		// Token: 0x0400005C RID: 92
		public const string StateUnwatermarked = "Unwatermarked";

		// Token: 0x0400005D RID: 93
		public const string StateWatermarked = "Watermarked";

		// Token: 0x0400005E RID: 94
		public const string GroupWatermark = "WatermarkStates";
	}
}
