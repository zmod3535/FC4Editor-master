using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace TD.SandBar
{
	// Token: 0x02000019 RID: 25
	[ToolboxItem(false)]
	public class ContainerBarClientPanel : Panel
	{
		// Token: 0x060001BA RID: 442 RVA: 0x00008190 File Offset: 0x00007190
		public ContainerBarClientPanel()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw, true);
			this.Text = "Task Pane";
		}

		// Token: 0x060001BB RID: 443 RVA: 0x000081AC File Offset: 0x000071AC
		protected override void OnPaintBackground(PaintEventArgs pevent)
		{
			if (base.Parent is ContainerBar)
			{
				((ContainerBar)base.Parent).WorkingRenderer.DrawContainerBarClientBackground(pevent.Graphics, base.ClientRectangle);
				return;
			}
			base.OnPaintBackground(pevent);
		}

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x060001BC RID: 444 RVA: 0x000081E4 File Offset: 0x000071E4
		// (set) Token: 0x060001BD RID: 445 RVA: 0x000081EC File Offset: 0x000071EC
		[DefaultValue("Task Pane")]
		[Browsable(true)]
		public override string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				base.Text = value;
				if (base.Parent is ContainerBar && ((ContainerBar)base.Parent).SelectedClientPanel == this)
				{
					base.Parent.Invalidate();
				}
			}
		}
	}
}
