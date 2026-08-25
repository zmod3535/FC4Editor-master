using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Effects;
using Divelements.SandDock.InteractiveDocking;

namespace Divelements.SandDock.Primitives
{
	// Token: 0x02000045 RID: 69
	[TemplatePart(Name = "PART_LeftArrow", Type = typeof(UIElement))]
	[TemplatePart(Name = "PART_RightArrow", Type = typeof(UIElement))]
	[TemplatePart(Name = "PART_DownArrow", Type = typeof(UIElement))]
	[TemplatePart(Name = "PART_UpArrow", Type = typeof(UIElement))]
	[TemplatePart(Name = "PART_CenterSpot", Type = typeof(UIElement))]
	public class DockingHint : Control
	{
		// Token: 0x060003A8 RID: 936 RVA: 0x000410E4 File Offset: 0x0003F4E4
		static DockingHint()
		{
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(DockingHint), new FrameworkPropertyMetadata(typeof(DockingHint)));
			UIElement.FocusableProperty.OverrideMetadata(typeof(DockingHint), new FrameworkPropertyMetadata(false));
			FrameworkElement.MarginProperty.OverrideMetadata(typeof(DockingHint), new FrameworkPropertyMetadata(new Thickness(12.0)));
		}

		// Token: 0x060003A9 RID: 937 RVA: 0x000411B8 File Offset: 0x0003F5B8
		public DockingHint(DockSite dockSite, DockingHintType dockingHintType, DockingRules rules)
		{
			if (dockSite == null)
			{
				throw new ArgumentNullException("dockSite");
			}
			this.dockSite = dockSite;
			this.DockingHintType = dockingHintType;
			this.Rules = rules;
		}

		// Token: 0x060003AA RID: 938 RVA: 0x000411E4 File Offset: 0x0003F5E4
		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			this.templateLeftArrow = (base.GetTemplateChild("PART_LeftArrow") as UIElement);
			this.templateRightArrow = (base.GetTemplateChild("PART_RightArrow") as UIElement);
			this.templateUpArrow = (base.GetTemplateChild("PART_UpArrow") as UIElement);
			this.templateDownArrow = (base.GetTemplateChild("PART_DownArrow") as UIElement);
			this.templateCenterSpot = (base.GetTemplateChild("PART_CenterSpot") as UIElement);
			if (!BrowserInteropHelper.IsBrowserHosted)
			{
				base.BitmapEffect = new DropShadowBitmapEffect
				{
					ShadowDepth = 2.0,
					Softness = 0.2,
					Opacity = 0.3
				};
			}
		}

		// Token: 0x170000CF RID: 207
		// (get) Token: 0x060003AB RID: 939 RVA: 0x000412A8 File Offset: 0x0003F6A8
		// (set) Token: 0x060003AC RID: 940 RVA: 0x000412B0 File Offset: 0x0003F6B0
		[Browsable(false)]
		public WindowGroup WindowGroup
		{
			get
			{
				return this.windowGroup;
			}
			set
			{
				this.windowGroup = value;
			}
		}

		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x060003AD RID: 941 RVA: 0x000412BC File Offset: 0x0003F6BC
		// (set) Token: 0x060003AE RID: 942 RVA: 0x000412D0 File Offset: 0x0003F6D0
		[Browsable(false)]
		public DockingRules Rules
		{
			get
			{
				return (DockingRules)base.GetValue(DockingHint.DockingRulesProperty);
			}
			set
			{
				base.SetValue(DockingHint.DockingRulesProperty, value);
			}
		}

		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x060003AF RID: 943 RVA: 0x000412E0 File Offset: 0x0003F6E0
		// (set) Token: 0x060003B0 RID: 944 RVA: 0x000412F4 File Offset: 0x0003F6F4
		[Category("Appearance")]
		public DockingHintType DockingHintType
		{
			get
			{
				return (DockingHintType)base.GetValue(DockingHint.DockingHintTypeProperty);
			}
			set
			{
				base.SetValue(DockingHint.DockingHintTypeProperty, value);
			}
		}

		// Token: 0x060003B1 RID: 945 RVA: 0x00041308 File Offset: 0x0003F708
		internal DockingOperationBase GetDockTargetFromMousePosition(MouseEventArgs e)
		{
			DockingHintType dockingHintType = this.DockingHintType;
			if (2147483647 != 0)
			{
				for (;;)
				{
					switch (dockingHintType)
					{
					case DockingHintType.LeftWindowEdge:
						goto IL_274;
					case DockingHintType.RightWindowEdge:
						goto IL_1DD;
					case DockingHintType.TopWindowEdge:
						goto IL_291;
					case DockingHintType.BottomWindowEdge:
						goto IL_1FD;
					case DockingHintType.WindowMiddle:
						goto IL_21D;
					case DockingHintType.WindowGroupMiddle:
						if (this.WindowGroup != null)
						{
							if (this.HitTestTemplatePart(this.templateUpArrow, e))
							{
								goto Block_17;
							}
							if (this.HitTestTemplatePart(this.templateDownArrow, e))
							{
								goto Block_18;
							}
							if (!this.HitTestTemplatePart(this.templateLeftArrow, e))
							{
								goto IL_76;
							}
							if (-2 == 0)
							{
								continue;
							}
							goto IL_2AA;
						}
						break;
					}
					goto Block_25;
				}
				IL_76:
				if (this.HitTestTemplatePart(this.templateRightArrow, e))
				{
					return new SplitWindowGroupOperation(this.WindowGroup, Dock.Right);
				}
				if (this.Rules.AllowMerge && this.WindowGroup.DoAllChildrenAllowMerge())
				{
					goto IL_11;
				}
				goto IL_2C;
				IL_164:
				return new TabOperation(this.dockSite.DocumentContainer);
				Block_17:
				return new SplitWindowGroupOperation(this.WindowGroup, Dock.Top);
				Block_18:
				if (!false)
				{
					return new SplitWindowGroupOperation(this.WindowGroup, Dock.Bottom);
				}
				goto IL_164;
				IL_1DD:
				if (this.HitTestTemplatePart(this.templateRightArrow, e))
				{
					return new CreateNewContainerOperation(this.dockSite, Dock.Right, DockSiteEdge.Outside);
				}
				goto IL_2B4;
				IL_1FD:
				if (this.HitTestTemplatePart(this.templateDownArrow, e))
				{
					return new CreateNewContainerOperation(this.dockSite, Dock.Bottom, DockSiteEdge.Outside);
				}
				goto IL_2B4;
				IL_21D:
				if (this.Rules.AllowDockTop && this.HitTestTemplatePart(this.templateUpArrow, e))
				{
					return new CreateNewContainerOperation(this.dockSite, Dock.Top, DockSiteEdge.Inside);
				}
				if (this.Rules.AllowDockBottom && this.HitTestTemplatePart(this.templateDownArrow, e))
				{
					return new CreateNewContainerOperation(this.dockSite, Dock.Bottom, DockSiteEdge.Inside);
				}
				if (this.Rules.AllowDockLeft && this.HitTestTemplatePart(this.templateLeftArrow, e))
				{
					return new CreateNewContainerOperation(this.dockSite, Dock.Left, DockSiteEdge.Inside);
				}
				if (this.Rules.AllowDockRight && this.HitTestTemplatePart(this.templateRightArrow, e))
				{
					return new CreateNewContainerOperation(this.dockSite, Dock.Right, DockSiteEdge.Inside);
				}
				if (this.Rules.AllowTab && this.dockSite.DocumentContainer != null && this.HitTestTemplatePart(this.templateCenterSpot, e))
				{
					goto IL_164;
				}
				Block_25:
				goto IL_2B4;
				IL_274:
				if (this.HitTestTemplatePart(this.templateLeftArrow, e))
				{
					return new CreateNewContainerOperation(this.dockSite, Dock.Left, DockSiteEdge.Outside);
				}
				goto IL_2B4;
				IL_291:
				if (!this.HitTestTemplatePart(this.templateUpArrow, e))
				{
					goto IL_2B4;
				}
				if (-1 != 0)
				{
					return new CreateNewContainerOperation(this.dockSite, Dock.Top, DockSiteEdge.Outside);
				}
				IL_2AA:
				return new SplitWindowGroupOperation(this.WindowGroup, Dock.Left);
			}
			IL_11:
			if (this.HitTestTemplatePart(this.templateCenterSpot, e))
			{
				return new JoinWindowGroupOperation(this.WindowGroup);
			}
			IL_2C:
			if (this.Rules.AllowMerge && this.WindowGroup.DoAllChildrenAllowMerge() && this.WindowGroup.IsInTitleBar(e))
			{
				return new JoinWindowGroupOperation(this.windowGroup);
			}
			IL_2B4:
			return null;
		}

		// Token: 0x060003B2 RID: 946 RVA: 0x000415CC File Offset: 0x0003F9CC
		private bool HitTestTemplatePart(UIElement templatePart, MouseEventArgs e)
		{
			if (templatePart != null)
			{
				HitTestResult hitTestResult = VisualTreeHelper.HitTest(templatePart, e.GetPosition(templatePart));
				if (hitTestResult != null)
				{
					Visual visual = hitTestResult.VisualHit as Visual;
					if (visual != null && (visual == templatePart || visual.IsDescendantOf(templatePart)))
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x04000191 RID: 401
		public static readonly DependencyProperty DockingHintTypeProperty = DependencyProperty.Register("DockingHintType", typeof(DockingHintType), typeof(DockingHint), new FrameworkPropertyMetadata(DockingHintType.WindowMiddle));

		// Token: 0x04000192 RID: 402
		public static readonly DependencyProperty DockingRulesProperty = DependencyProperty.Register("DockingRules", typeof(DockingRules), typeof(DockingHint), new FrameworkPropertyMetadata(null));

		// Token: 0x04000193 RID: 403
		private DockSite dockSite;

		// Token: 0x04000194 RID: 404
		private WindowGroup windowGroup;

		// Token: 0x04000195 RID: 405
		private UIElement templateLeftArrow;

		// Token: 0x04000196 RID: 406
		private UIElement templateUpArrow;

		// Token: 0x04000197 RID: 407
		private UIElement templateDownArrow;

		// Token: 0x04000198 RID: 408
		private UIElement templateRightArrow;

		// Token: 0x04000199 RID: 409
		private UIElement templateCenterSpot;
	}
}
