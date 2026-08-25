using System;
using System.ComponentModel;

namespace Divelements.SandGrid.Specialized
{
	// Token: 0x02000066 RID: 102
	[TypeConverter(typeof(x933c789ad966b48f))]
	public abstract class TypedGridCell : GridCell
	{
		// Token: 0x17000180 RID: 384
		// (get) Token: 0x060005FB RID: 1531 RVA: 0x0001FE0C File Offset: 0x0001EE0C
		// (set) Token: 0x060005FC RID: 1532 RVA: 0x0001FE14 File Offset: 0x0001EE14
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public override string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
			}
		}
	}
}
