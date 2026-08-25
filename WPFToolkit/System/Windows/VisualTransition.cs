using System;
using System.ComponentModel;
using System.Windows.Markup;
using System.Windows.Media.Animation;

namespace System.Windows
{
	// Token: 0x02000080 RID: 128
	[ContentProperty("Storyboard")]
	public class VisualTransition : DependencyObject
	{
		// Token: 0x060008F4 RID: 2292 RVA: 0x000283B4 File Offset: 0x000265B4
		public VisualTransition()
		{
			this.DynamicStoryboardCompleted = true;
			this.ExplicitStoryboardCompleted = true;
		}

		// Token: 0x17000217 RID: 535
		// (get) Token: 0x060008F5 RID: 2293 RVA: 0x000283E9 File Offset: 0x000265E9
		// (set) Token: 0x060008F6 RID: 2294 RVA: 0x000283F1 File Offset: 0x000265F1
		public string From { get; set; }

		// Token: 0x17000218 RID: 536
		// (get) Token: 0x060008F7 RID: 2295 RVA: 0x000283FA File Offset: 0x000265FA
		// (set) Token: 0x060008F8 RID: 2296 RVA: 0x00028402 File Offset: 0x00026602
		public string To { get; set; }

		// Token: 0x17000219 RID: 537
		// (get) Token: 0x060008F9 RID: 2297 RVA: 0x0002840B File Offset: 0x0002660B
		// (set) Token: 0x060008FA RID: 2298 RVA: 0x00028413 File Offset: 0x00026613
		public Storyboard Storyboard { get; set; }

		// Token: 0x1700021A RID: 538
		// (get) Token: 0x060008FB RID: 2299 RVA: 0x0002841C File Offset: 0x0002661C
		// (set) Token: 0x060008FC RID: 2300 RVA: 0x00028424 File Offset: 0x00026624
		[TypeConverter(typeof(DurationConverter))]
		public Duration GeneratedDuration
		{
			get
			{
				return this._generatedDuration;
			}
			set
			{
				this._generatedDuration = value;
			}
		}

		// Token: 0x1700021B RID: 539
		// (get) Token: 0x060008FD RID: 2301 RVA: 0x0002842D File Offset: 0x0002662D
		internal bool IsDefault
		{
			get
			{
				return this.From == null && this.To == null;
			}
		}

		// Token: 0x1700021C RID: 540
		// (get) Token: 0x060008FE RID: 2302 RVA: 0x00028442 File Offset: 0x00026642
		// (set) Token: 0x060008FF RID: 2303 RVA: 0x0002844A File Offset: 0x0002664A
		internal bool DynamicStoryboardCompleted { get; set; }

		// Token: 0x1700021D RID: 541
		// (get) Token: 0x06000900 RID: 2304 RVA: 0x00028453 File Offset: 0x00026653
		// (set) Token: 0x06000901 RID: 2305 RVA: 0x0002845B File Offset: 0x0002665B
		internal bool ExplicitStoryboardCompleted { get; set; }

		// Token: 0x040002BD RID: 701
		private Duration _generatedDuration = new Duration(default(TimeSpan));
	}
}
