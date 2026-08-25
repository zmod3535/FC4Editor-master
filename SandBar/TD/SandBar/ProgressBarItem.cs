using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace TD.SandBar
{
	// Token: 0x02000060 RID: 96
	[ToolboxItem(false)]
	[TypeConverter(typeof(xe82e926721c67317))]
	public class ProgressBarItem : ControlContainerItem
	{
		// Token: 0x060004EF RID: 1263 RVA: 0x0001B41C File Offset: 0x0001A41C
		public ProgressBarItem() : base(new ProgressBar())
		{
			base.ContainedControl.Height = 16;
			this.MinimumControlWidth = 100;
		}

		// Token: 0x060004F0 RID: 1264 RVA: 0x0001B440 File Offset: 0x0001A440
		public override ToolbarItemBase CloneItem()
		{
			ProgressBarItem progressBarItem = (ProgressBarItem)base.CloneItem();
			progressBarItem.Minimum = this.Minimum;
			progressBarItem.Maximum = this.Maximum;
			progressBarItem.Value = this.Value;
			return progressBarItem;
		}

		// Token: 0x17000134 RID: 308
		// (get) Token: 0x060004F1 RID: 1265 RVA: 0x0001B480 File Offset: 0x0001A480
		// (set) Token: 0x060004F2 RID: 1266 RVA: 0x0001B488 File Offset: 0x0001A488
		[DefaultValue(100)]
		public override int MinimumControlWidth
		{
			get
			{
				return base.MinimumControlWidth;
			}
			set
			{
				base.MinimumControlWidth = value;
			}
		}

		// Token: 0x17000135 RID: 309
		// (get) Token: 0x060004F3 RID: 1267 RVA: 0x0001B494 File Offset: 0x0001A494
		// (set) Token: 0x060004F4 RID: 1268 RVA: 0x0001B4A4 File Offset: 0x0001A4A4
		[Description("Wraps the Minimum property of the inner ProgressBar.")]
		[Category("Progress Bar")]
		[DefaultValue(0)]
		public int Minimum
		{
			get
			{
				return this.ProgressBar.Minimum;
			}
			set
			{
				this.ProgressBar.Minimum = value;
			}
		}

		// Token: 0x17000136 RID: 310
		// (get) Token: 0x060004F5 RID: 1269 RVA: 0x0001B4B4 File Offset: 0x0001A4B4
		// (set) Token: 0x060004F6 RID: 1270 RVA: 0x0001B4C4 File Offset: 0x0001A4C4
		[Category("Progress Bar")]
		[DefaultValue(100)]
		[Description("Wraps the Maximum property of the inner ProgressBar.")]
		public int Maximum
		{
			get
			{
				return this.ProgressBar.Maximum;
			}
			set
			{
				this.ProgressBar.Maximum = value;
			}
		}

		// Token: 0x17000137 RID: 311
		// (get) Token: 0x060004F7 RID: 1271 RVA: 0x0001B4D4 File Offset: 0x0001A4D4
		// (set) Token: 0x060004F8 RID: 1272 RVA: 0x0001B4E4 File Offset: 0x0001A4E4
		[Description("Wraps the Value property of the inner ProgressBar.")]
		[DefaultValue(0)]
		[Category("Progress Bar")]
		public int Value
		{
			get
			{
				return this.ProgressBar.Value;
			}
			set
			{
				this.ProgressBar.Value = value;
			}
		}

		// Token: 0x17000138 RID: 312
		// (get) Token: 0x060004F9 RID: 1273 RVA: 0x0001B4F4 File Offset: 0x0001A4F4
		[Browsable(false)]
		public ProgressBar ProgressBar
		{
			get
			{
				return base.ContainedControl as ProgressBar;
			}
		}
	}
}
