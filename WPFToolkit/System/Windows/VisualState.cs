using System;
using System.Windows.Markup;
using System.Windows.Media.Animation;

namespace System.Windows
{
	// Token: 0x02000002 RID: 2
	[ContentProperty("Storyboard")]
	[RuntimeNameProperty("Name")]
	public class VisualState : DependencyObject
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000001 RID: 1 RVA: 0x000020D0 File Offset: 0x000002D0
		// (set) Token: 0x06000002 RID: 2 RVA: 0x000020D8 File Offset: 0x000002D8
		public string Name { get; set; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000003 RID: 3 RVA: 0x000020E1 File Offset: 0x000002E1
		// (set) Token: 0x06000004 RID: 4 RVA: 0x000020F3 File Offset: 0x000002F3
		public Storyboard Storyboard
		{
			get
			{
				return (Storyboard)base.GetValue(VisualState.StoryboardProperty);
			}
			set
			{
				base.SetValue(VisualState.StoryboardProperty, value);
			}
		}

		// Token: 0x04000001 RID: 1
		private static readonly DependencyProperty StoryboardProperty = DependencyProperty.Register("Storyboard", typeof(Storyboard), typeof(VisualState));
	}
}
