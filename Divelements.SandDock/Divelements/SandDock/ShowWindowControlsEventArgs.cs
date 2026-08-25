using System;
using System.Windows;
using System.Windows.Controls;

namespace Divelements.SandDock
{
	// Token: 0x02000016 RID: 22
	public class ShowWindowControlsEventArgs : EventArgs
	{
		// Token: 0x060001E3 RID: 483 RVA: 0x00037F24 File Offset: 0x00036324
		internal ShowWindowControlsEventArgs(DockableWindow window, UIElement placementTarget, Rect placementRectangle)
		{
			this.x76b3d9d2638e5ecd = window;
			this.x1ab75529f0362be8 = placementTarget;
			this.x7eb0a5c5cc38155e = placementRectangle;
		}

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x060001E4 RID: 484 RVA: 0x00037F44 File Offset: 0x00036344
		public DockableWindow Window
		{
			get
			{
				return this.x76b3d9d2638e5ecd;
			}
		}

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x060001E5 RID: 485 RVA: 0x00037F4C File Offset: 0x0003634C
		public Rect PlacementRectangle
		{
			get
			{
				return this.x7eb0a5c5cc38155e;
			}
		}

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x060001E6 RID: 486 RVA: 0x00037F54 File Offset: 0x00036354
		public UIElement PlacementTarget
		{
			get
			{
				return this.x1ab75529f0362be8;
			}
		}

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x060001E7 RID: 487 RVA: 0x00037F5C File Offset: 0x0003635C
		// (set) Token: 0x060001E8 RID: 488 RVA: 0x00037F64 File Offset: 0x00036364
		public ContextMenu ContextMenu
		{
			get
			{
				return this.xfbb4579b829aef10;
			}
			set
			{
				this.xfbb4579b829aef10 = value;
			}
		}

		// Token: 0x04000099 RID: 153
		private ContextMenu xfbb4579b829aef10;

		// Token: 0x0400009A RID: 154
		private DockableWindow x76b3d9d2638e5ecd;

		// Token: 0x0400009B RID: 155
		private UIElement x1ab75529f0362be8;

		// Token: 0x0400009C RID: 156
		private Rect x7eb0a5c5cc38155e;
	}
}
