using System;
using System.Windows.Input;

namespace IGE.Nomad
{
	// Token: 0x020000DD RID: 221
	internal class UndoManager
	{
		// Token: 0x170001D3 RID: 467
		// (get) Token: 0x06000808 RID: 2056 RVA: 0x0001BD27 File Offset: 0x00019F27
		public static int UndoCount
		{
			get
			{
				return Binding.FCE_UndoManager_GetUndoCount();
			}
		}

		// Token: 0x170001D4 RID: 468
		// (get) Token: 0x06000809 RID: 2057 RVA: 0x0001BD33 File Offset: 0x00019F33
		public static int RedoCount
		{
			get
			{
				return Binding.FCE_UndoManager_GetRedoCount();
			}
		}

		// Token: 0x0600080A RID: 2058 RVA: 0x0001BD3F File Offset: 0x00019F3F
		public static void Undo()
		{
			Binding.FCE_UndoManager_Undo();
		}

		// Token: 0x0600080B RID: 2059 RVA: 0x0001BD4B File Offset: 0x00019F4B
		public static void Redo()
		{
			Binding.FCE_UndoManager_Redo();
		}

		// Token: 0x0600080C RID: 2060 RVA: 0x0001BD57 File Offset: 0x00019F57
		public static void RecordUndo()
		{
			Binding.FCE_UndoManager_RecordUndo();
		}

		// Token: 0x0600080D RID: 2061 RVA: 0x0001BD63 File Offset: 0x00019F63
		public static void CommitUndo()
		{
			Binding.FCE_UndoManager_CommitUndo();
			CommandManager.InvalidateRequerySuggested();
		}
	}
}
