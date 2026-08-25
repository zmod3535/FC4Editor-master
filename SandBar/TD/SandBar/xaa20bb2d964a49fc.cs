using System;
using System.Drawing;

namespace TD.SandBar
{
	// Token: 0x02000028 RID: 40
	internal abstract class xaa20bb2d964a49fc : IDisposable
	{
		// Token: 0x06000250 RID: 592 RVA: 0x0000B6B8 File Offset: 0x0000A6B8
		public xaa20bb2d964a49fc(PopupMenu popupMenu)
		{
			this.x56be4c3c4c4173b7 = popupMenu;
		}

		// Token: 0x06000251 RID: 593 RVA: 0x0000B6C8 File Offset: 0x0000A6C8
		protected internal virtual bool ShouldHighlightItem(MenuButtonItem item)
		{
			return false;
		}

		// Token: 0x06000252 RID: 594 RVA: 0x0000B6CC File Offset: 0x0000A6CC
		protected internal virtual Rectangle ModifyParentBounds(Rectangle parentBounds)
		{
			return parentBounds;
		}

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x06000253 RID: 595 RVA: 0x0000B6D0 File Offset: 0x0000A6D0
		protected PopupMenu xebcaeeeb5a07df77
		{
			get
			{
				return this.x56be4c3c4c4173b7;
			}
		}

		// Token: 0x06000254 RID: 596 RVA: 0x0000B6D8 File Offset: 0x0000A6D8
		public virtual void Dispose()
		{
		}

		// Token: 0x06000255 RID: 597 RVA: 0x0000B6DC File Offset: 0x0000A6DC
		protected internal virtual void LowImportanceItemsExpanded()
		{
		}

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x06000256 RID: 598
		protected internal abstract bool AllowLowImportanceMenuItems { get; }

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x06000257 RID: 599
		protected internal abstract Rectangle ConstraintArea { get; }

		// Token: 0x06000258 RID: 600
		protected internal abstract void Show(ref int maximumMenuCount, TopLevelMenuItemBase.MenuAnimation desiredAnimation);

		// Token: 0x040000D7 RID: 215
		private PopupMenu x56be4c3c4c4173b7;
	}
}
