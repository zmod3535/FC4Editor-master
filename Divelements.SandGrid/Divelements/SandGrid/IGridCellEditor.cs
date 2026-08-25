using System;
using System.Windows.Forms;

namespace Divelements.SandGrid
{
	// Token: 0x02000002 RID: 2
	public interface IGridCellEditor
	{
		// Token: 0x06000001 RID: 1
		void InitializeContext(SandGridBase grid, GridRow row, GridColumn column);

		// Token: 0x06000002 RID: 2
		void StartEdit(bool selectAll);

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000003 RID: 3
		// (set) Token: 0x06000004 RID: 4
		object EditorValue { get; set; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000005 RID: 5
		BorderStyle HostBorderStyle { get; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000006 RID: 6
		Type DesiredType { get; }

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000007 RID: 7
		int FixedHeight { get; }
	}
}
