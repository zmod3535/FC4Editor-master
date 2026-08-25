using System;

namespace Microsoft.Windows.Controls
{
	// Token: 0x02000006 RID: 6
	internal struct SRID
	{
		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000025 RID: 37 RVA: 0x0000264E File Offset: 0x0000084E
		public string String
		{
			get
			{
				return this._string;
			}
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00002656 File Offset: 0x00000856
		private SRID(string s)
		{
			this._string = s;
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000027 RID: 39 RVA: 0x0000265F File Offset: 0x0000085F
		public static SRID DataGrid_SelectAllCommandText
		{
			get
			{
				return new SRID("DataGrid_SelectAllCommandText");
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000028 RID: 40 RVA: 0x0000266B File Offset: 0x0000086B
		public static SRID DataGrid_SelectAllKey
		{
			get
			{
				return new SRID("DataGrid_SelectAllKey");
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000029 RID: 41 RVA: 0x00002677 File Offset: 0x00000877
		public static SRID DataGrid_SelectAllKeyDisplayString
		{
			get
			{
				return new SRID("DataGrid_SelectAllKeyDisplayString");
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600002A RID: 42 RVA: 0x00002683 File Offset: 0x00000883
		public static SRID DataGrid_BeginEditCommandText
		{
			get
			{
				return new SRID("DataGrid_BeginEditCommandText");
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600002B RID: 43 RVA: 0x0000268F File Offset: 0x0000088F
		public static SRID DataGrid_CommitEditCommandText
		{
			get
			{
				return new SRID("DataGrid_CommitEditCommandText");
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600002C RID: 44 RVA: 0x0000269B File Offset: 0x0000089B
		public static SRID DataGrid_CancelEditCommandText
		{
			get
			{
				return new SRID("DataGrid_CancelEditCommandText");
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600002D RID: 45 RVA: 0x000026A7 File Offset: 0x000008A7
		public static SRID DataGrid_DeleteCommandText
		{
			get
			{
				return new SRID("DataGrid_DeleteCommandText");
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600002E RID: 46 RVA: 0x000026B3 File Offset: 0x000008B3
		public static SRID DataGridCellItemAutomationPeer_NameCoreFormat
		{
			get
			{
				return new SRID("DataGridCellItemAutomationPeer_NameCoreFormat");
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600002F RID: 47 RVA: 0x000026BF File Offset: 0x000008BF
		public static SRID CalendarAutomationPeer_CalendarButtonLocalizedControlType
		{
			get
			{
				return new SRID("CalendarAutomationPeer_CalendarButtonLocalizedControlType");
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000030 RID: 48 RVA: 0x000026CB File Offset: 0x000008CB
		public static SRID CalendarAutomationPeer_DayButtonLocalizedControlType
		{
			get
			{
				return new SRID("CalendarAutomationPeer_DayButtonLocalizedControlType");
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000031 RID: 49 RVA: 0x000026D7 File Offset: 0x000008D7
		public static SRID CalendarAutomationPeer_BlackoutDayHelpText
		{
			get
			{
				return new SRID("CalendarAutomationPeer_BlackoutDayHelpText");
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000032 RID: 50 RVA: 0x000026E3 File Offset: 0x000008E3
		public static SRID Calendar_NextButtonName
		{
			get
			{
				return new SRID("Calendar_NextButtonName");
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000033 RID: 51 RVA: 0x000026EF File Offset: 0x000008EF
		public static SRID Calendar_PreviousButtonName
		{
			get
			{
				return new SRID("Calendar_PreviousButtonName");
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000034 RID: 52 RVA: 0x000026FB File Offset: 0x000008FB
		public static SRID DatePickerAutomationPeer_LocalizedControlType
		{
			get
			{
				return new SRID("DatePickerAutomationPeer_LocalizedControlType");
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000035 RID: 53 RVA: 0x00002707 File Offset: 0x00000907
		public static SRID DatePickerTextBox_DefaultWatermarkText
		{
			get
			{
				return new SRID("DatePickerTextBox_DefaultWatermarkText");
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000036 RID: 54 RVA: 0x00002713 File Offset: 0x00000913
		public static SRID DatePicker_DropDownButtonName
		{
			get
			{
				return new SRID("DatePicker_DropDownButtonName");
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000037 RID: 55 RVA: 0x0000271F File Offset: 0x0000091F
		public static SRID DataGrid_ColumnIndexOutOfRange
		{
			get
			{
				return new SRID("DataGrid_ColumnIndexOutOfRange");
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000038 RID: 56 RVA: 0x0000272B File Offset: 0x0000092B
		public static SRID DataGrid_ColumnDisplayIndexOutOfRange
		{
			get
			{
				return new SRID("DataGrid_ColumnDisplayIndexOutOfRange");
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000039 RID: 57 RVA: 0x00002737 File Offset: 0x00000937
		public static SRID DataGrid_DisplayIndexOutOfRange
		{
			get
			{
				return new SRID("DataGrid_DisplayIndexOutOfRange");
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x0600003A RID: 58 RVA: 0x00002743 File Offset: 0x00000943
		public static SRID DataGrid_InvalidColumnReuse
		{
			get
			{
				return new SRID("DataGrid_InvalidColumnReuse");
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x0600003B RID: 59 RVA: 0x0000274F File Offset: 0x0000094F
		public static SRID DataGrid_DuplicateDisplayIndex
		{
			get
			{
				return new SRID("DataGrid_DuplicateDisplayIndex");
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x0600003C RID: 60 RVA: 0x0000275B File Offset: 0x0000095B
		public static SRID DataGrid_NewColumnInvalidDisplayIndex
		{
			get
			{
				return new SRID("DataGrid_NewColumnInvalidDisplayIndex");
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x0600003D RID: 61 RVA: 0x00002767 File Offset: 0x00000967
		public static SRID DataGrid_NullColumn
		{
			get
			{
				return new SRID("DataGrid_NullColumn");
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x0600003E RID: 62 RVA: 0x00002773 File Offset: 0x00000973
		public static SRID DataGrid_ReadonlyCellsItemsSource
		{
			get
			{
				return new SRID("DataGrid_ReadonlyCellsItemsSource");
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x0600003F RID: 63 RVA: 0x0000277F File Offset: 0x0000097F
		public static SRID DataGrid_InvalidSortDescription
		{
			get
			{
				return new SRID("DataGrid_InvalidSortDescription");
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000040 RID: 64 RVA: 0x0000278B File Offset: 0x0000098B
		public static SRID DataGrid_ProbableInvalidSortDescription
		{
			get
			{
				return new SRID("DataGrid_ProbableInvalidSortDescription");
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000041 RID: 65 RVA: 0x00002797 File Offset: 0x00000997
		public static SRID DataGridLength_InvalidType
		{
			get
			{
				return new SRID("DataGridLength_InvalidType");
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000042 RID: 66 RVA: 0x000027A3 File Offset: 0x000009A3
		public static SRID DataGridLength_Infinity
		{
			get
			{
				return new SRID("DataGridLength_Infinity");
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000043 RID: 67 RVA: 0x000027AF File Offset: 0x000009AF
		public static SRID DataGrid_CannotSelectCell
		{
			get
			{
				return new SRID("DataGrid_CannotSelectCell");
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000044 RID: 68 RVA: 0x000027BB File Offset: 0x000009BB
		public static SRID DataGridRow_CannotSelectRowWhenCells
		{
			get
			{
				return new SRID("DataGridRow_CannotSelectRowWhenCells");
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x06000045 RID: 69 RVA: 0x000027C7 File Offset: 0x000009C7
		public static SRID DataGrid_AutomationInvokeFailed
		{
			get
			{
				return new SRID("DataGrid_AutomationInvokeFailed");
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x06000046 RID: 70 RVA: 0x000027D3 File Offset: 0x000009D3
		public static SRID SelectedCellsCollection_InvalidItem
		{
			get
			{
				return new SRID("SelectedCellsCollection_InvalidItem");
			}
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000047 RID: 71 RVA: 0x000027DF File Offset: 0x000009DF
		public static SRID SelectedCellsCollection_DuplicateItem
		{
			get
			{
				return new SRID("SelectedCellsCollection_DuplicateItem");
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000048 RID: 72 RVA: 0x000027EB File Offset: 0x000009EB
		public static SRID VirtualizedCellInfoCollection_IsReadOnly
		{
			get
			{
				return new SRID("VirtualizedCellInfoCollection_IsReadOnly");
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000049 RID: 73 RVA: 0x000027F7 File Offset: 0x000009F7
		public static SRID VirtualizedCellInfoCollection_DoesNotSupportIndexChanges
		{
			get
			{
				return new SRID("VirtualizedCellInfoCollection_DoesNotSupportIndexChanges");
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x0600004A RID: 74 RVA: 0x00002803 File Offset: 0x00000A03
		public static SRID ClipboardCopyMode_Disabled
		{
			get
			{
				return new SRID("ClipboardCopyMode_Disabled");
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x0600004B RID: 75 RVA: 0x0000280F File Offset: 0x00000A0F
		public static SRID Calendar_OnDisplayModePropertyChanged_InvalidValue
		{
			get
			{
				return new SRID("Calendar_OnDisplayModePropertyChanged_InvalidValue");
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x0600004C RID: 76 RVA: 0x0000281B File Offset: 0x00000A1B
		public static SRID Calendar_OnFirstDayOfWeekChanged_InvalidValue
		{
			get
			{
				return new SRID("Calendar_OnFirstDayOfWeekChanged_InvalidValue");
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x0600004D RID: 77 RVA: 0x00002827 File Offset: 0x00000A27
		public static SRID Calendar_OnSelectedDateChanged_InvalidValue
		{
			get
			{
				return new SRID("Calendar_OnSelectedDateChanged_InvalidValue");
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x0600004E RID: 78 RVA: 0x00002833 File Offset: 0x00000A33
		public static SRID Calendar_OnSelectedDateChanged_InvalidOperation
		{
			get
			{
				return new SRID("Calendar_OnSelectedDateChanged_InvalidOperation");
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x0600004F RID: 79 RVA: 0x0000283F File Offset: 0x00000A3F
		public static SRID CalendarCollection_MultiThreadedCollectionChangeNotSupported
		{
			get
			{
				return new SRID("CalendarCollection_MultiThreadedCollectionChangeNotSupported");
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x06000050 RID: 80 RVA: 0x0000284B File Offset: 0x00000A4B
		public static SRID Calendar_CheckSelectionMode_InvalidOperation
		{
			get
			{
				return new SRID("Calendar_CheckSelectionMode_InvalidOperation");
			}
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x06000051 RID: 81 RVA: 0x00002857 File Offset: 0x00000A57
		public static SRID Calendar_OnSelectionModeChanged_InvalidValue
		{
			get
			{
				return new SRID("Calendar_OnSelectionModeChanged_InvalidValue");
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x06000052 RID: 82 RVA: 0x00002863 File Offset: 0x00000A63
		public static SRID Calendar_UnSelectableDates
		{
			get
			{
				return new SRID("Calendar_UnSelectableDates");
			}
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x06000053 RID: 83 RVA: 0x0000286F File Offset: 0x00000A6F
		public static SRID DatePickerTextBox_TemplatePartIsOfIncorrectType
		{
			get
			{
				return new SRID("DatePickerTextBox_TemplatePartIsOfIncorrectType");
			}
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x06000054 RID: 84 RVA: 0x0000287B File Offset: 0x00000A7B
		public static SRID DatePicker_OnSelectedDateFormatChanged_InvalidValue
		{
			get
			{
				return new SRID("DatePicker_OnSelectedDateFormatChanged_InvalidValue");
			}
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x06000055 RID: 85 RVA: 0x00002887 File Offset: 0x00000A87
		public static SRID DatePicker_WatermarkText
		{
			get
			{
				return new SRID("DatePicker_WatermarkText");
			}
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x06000056 RID: 86 RVA: 0x00002893 File Offset: 0x00000A93
		public static SRID CalendarAutomationPeer_MonthMode
		{
			get
			{
				return new SRID("CalendarAutomationPeer_MonthMode");
			}
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x06000057 RID: 87 RVA: 0x0000289F File Offset: 0x00000A9F
		public static SRID CalendarAutomationPeer_YearMode
		{
			get
			{
				return new SRID("CalendarAutomationPeer_YearMode");
			}
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x06000058 RID: 88 RVA: 0x000028AB File Offset: 0x00000AAB
		public static SRID CalendarAutomationPeer_DecadeMode
		{
			get
			{
				return new SRID("CalendarAutomationPeer_DecadeMode");
			}
		}

		// Token: 0x04000005 RID: 5
		private string _string;
	}
}
