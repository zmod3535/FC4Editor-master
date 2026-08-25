using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using Microsoft.Windows.Controls;

namespace System.Windows
{
	// Token: 0x0200001F RID: 31
	public class VisualStateManager : DependencyObject
	{
		// Token: 0x060001F6 RID: 502 RVA: 0x00007DE8 File Offset: 0x00005FE8
		public static bool GoToState(Control control, string stateName, bool useTransitions)
		{
			if (control == null)
			{
				throw new ArgumentNullException("control");
			}
			if (stateName == null)
			{
				throw new ArgumentNullException("stateName");
			}
			FrameworkElement templateRoot = VisualStateManager.GetTemplateRoot(control);
			if (templateRoot == null)
			{
				return false;
			}
			IList<VisualStateGroup> visualStateGroupsInternal = VisualStateManager.GetVisualStateGroupsInternal(templateRoot);
			if (visualStateGroupsInternal == null)
			{
				return false;
			}
			VisualStateGroup group;
			VisualState visualState;
			VisualStateManager.TryGetState(visualStateGroupsInternal, stateName, out group, out visualState);
			VisualStateManager customVisualStateManager = VisualStateManager.GetCustomVisualStateManager(templateRoot);
			if (customVisualStateManager != null)
			{
				return customVisualStateManager.GoToStateCore(control, templateRoot, stateName, group, visualState, useTransitions);
			}
			return visualState != null && VisualStateManager.GoToStateInternal(control, templateRoot, group, visualState, useTransitions);
		}

		// Token: 0x060001F7 RID: 503 RVA: 0x00007E5E File Offset: 0x0000605E
		protected virtual bool GoToStateCore(Control control, FrameworkElement templateRoot, string stateName, VisualStateGroup group, VisualState state, bool useTransitions)
		{
			return VisualStateManager.GoToStateInternal(control, templateRoot, group, state, useTransitions);
		}

		// Token: 0x060001F8 RID: 504 RVA: 0x00007E6D File Offset: 0x0000606D
		public static VisualStateManager GetCustomVisualStateManager(FrameworkElement obj)
		{
			if (obj == null)
			{
				throw new ArgumentNullException("obj");
			}
			return obj.GetValue(VisualStateManager.CustomVisualStateManagerProperty) as VisualStateManager;
		}

		// Token: 0x060001F9 RID: 505 RVA: 0x00007E8D File Offset: 0x0000608D
		public static void SetCustomVisualStateManager(FrameworkElement obj, VisualStateManager value)
		{
			if (obj == null)
			{
				throw new ArgumentNullException("obj");
			}
			obj.SetValue(VisualStateManager.CustomVisualStateManagerProperty, value);
		}

		// Token: 0x060001FA RID: 506 RVA: 0x00007EAC File Offset: 0x000060AC
		internal static Collection<VisualStateGroup> GetVisualStateGroupsInternal(FrameworkElement obj)
		{
			if (obj == null)
			{
				throw new ArgumentNullException("obj");
			}
			Collection<VisualStateGroup> collection = obj.GetValue(VisualStateManager.VisualStateGroupsProperty) as Collection<VisualStateGroup>;
			if (collection == null)
			{
				collection = new Collection<VisualStateGroup>();
				VisualStateManager.SetVisualStateGroups(obj, collection);
			}
			return collection;
		}

		// Token: 0x060001FB RID: 507 RVA: 0x00007EE9 File Offset: 0x000060E9
		public static IList GetVisualStateGroups(FrameworkElement obj)
		{
			return VisualStateManager.GetVisualStateGroupsInternal(obj);
		}

		// Token: 0x060001FC RID: 508 RVA: 0x00007EF1 File Offset: 0x000060F1
		internal static void SetVisualStateGroups(FrameworkElement obj, Collection<VisualStateGroup> value)
		{
			if (obj == null)
			{
				throw new ArgumentNullException("obj");
			}
			obj.SetValue(VisualStateManager.VisualStateGroupsProperty, value);
		}

		// Token: 0x060001FD RID: 509 RVA: 0x00007F10 File Offset: 0x00006110
		private static void OnVisualStateGroupsChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
		{
			FrameworkElement frameworkElement = obj as FrameworkElement;
			if (frameworkElement != null)
			{
				Control templatedParent = VisualStateManager.GetTemplatedParent(frameworkElement);
				if (templatedParent != null)
				{
					VisualStateBehaviorFactory.AttachBehavior(templatedParent);
				}
			}
		}

		// Token: 0x060001FE RID: 510 RVA: 0x00007F38 File Offset: 0x00006138
		internal static bool TryGetState(IList<VisualStateGroup> groups, string stateName, out VisualStateGroup group, out VisualState state)
		{
			for (int i = 0; i < groups.Count; i++)
			{
				VisualStateGroup visualStateGroup = groups[i];
				VisualState state2 = visualStateGroup.GetState(stateName);
				if (state2 != null)
				{
					group = visualStateGroup;
					state = state2;
					return true;
				}
			}
			group = null;
			state = null;
			return false;
		}

		// Token: 0x060001FF RID: 511 RVA: 0x00008118 File Offset: 0x00006318
		private static bool GoToStateInternal(Control control, FrameworkElement element, VisualStateGroup group, VisualState state, bool useTransitions)
		{
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			if (state == null)
			{
				throw new ArgumentNullException("state");
			}
			if (group == null)
			{
				throw new InvalidOperationException();
			}
			VisualState lastState = group.CurrentState;
			if (lastState == state)
			{
				return true;
			}
			VisualTransition transition = useTransitions ? VisualStateManager.GetTransition(element, group, lastState, state) : null;
			Storyboard storyboard = VisualStateManager.GenerateDynamicTransitionAnimations(element, group, state, transition);
			if (transition == null || (transition.GeneratedDuration == VisualStateManager.DurationZero && (transition.Storyboard == null || transition.Storyboard.Duration == VisualStateManager.DurationZero)))
			{
				if (transition != null && transition.Storyboard != null)
				{
					group.StartNewThenStopOld(element, new Storyboard[]
					{
						transition.Storyboard,
						state.Storyboard
					});
				}
				else
				{
					group.StartNewThenStopOld(element, new Storyboard[]
					{
						state.Storyboard
					});
				}
				group.RaiseCurrentStateChanging(element, lastState, state, control);
				group.RaiseCurrentStateChanged(element, lastState, state, control);
			}
			else
			{
				transition.DynamicStoryboardCompleted = false;
				storyboard.Completed += delegate(object sender, EventArgs e)
				{
					if (transition.Storyboard == null || transition.ExplicitStoryboardCompleted)
					{
						if (VisualStateManager.ShouldRunStateStoryboard(control, element, state, group))
						{
							group.StartNewThenStopOld(element, new Storyboard[]
							{
								state.Storyboard
							});
						}
						group.RaiseCurrentStateChanged(element, lastState, state, control);
					}
					transition.DynamicStoryboardCompleted = true;
				};
				if (transition.Storyboard != null && transition.ExplicitStoryboardCompleted)
				{
					EventHandler transitionCompleted = null;
					transitionCompleted = delegate(object sender, EventArgs e)
					{
						if (transition.DynamicStoryboardCompleted)
						{
							if (VisualStateManager.ShouldRunStateStoryboard(control, element, state, group))
							{
								group.StartNewThenStopOld(element, new Storyboard[]
								{
									state.Storyboard
								});
							}
							group.RaiseCurrentStateChanged(element, lastState, state, control);
						}
						transition.Storyboard.Completed -= transitionCompleted;
						transition.ExplicitStoryboardCompleted = true;
					};
					transition.ExplicitStoryboardCompleted = false;
					transition.Storyboard.Completed += transitionCompleted;
				}
				group.StartNewThenStopOld(element, new Storyboard[]
				{
					transition.Storyboard,
					storyboard
				});
				group.RaiseCurrentStateChanging(element, lastState, state, control);
			}
			group.CurrentState = state;
			return true;
		}

		// Token: 0x06000200 RID: 512 RVA: 0x000083E4 File Offset: 0x000065E4
		private static bool ShouldRunStateStoryboard(FrameworkElement control, FrameworkElement stateGroupsRoot, VisualState state, VisualStateGroup group)
		{
			bool flag = true;
			bool flag2 = true;
			if (control != null && !control.IsVisible)
			{
				flag = (PresentationSource.FromVisual(control) != null);
			}
			if (stateGroupsRoot != null && !stateGroupsRoot.IsVisible)
			{
				flag2 = (PresentationSource.FromVisual(stateGroupsRoot) != null);
			}
			return flag && flag2 && state == group.CurrentState;
		}

		// Token: 0x06000201 RID: 513 RVA: 0x00008438 File Offset: 0x00006638
		protected void RaiseCurrentStateChanging(VisualStateGroup stateGroup, VisualState oldState, VisualState newState, Control control)
		{
			if (stateGroup == null)
			{
				throw new ArgumentNullException("stateGroup");
			}
			if (newState == null)
			{
				throw new ArgumentNullException("newState");
			}
			if (control == null)
			{
				throw new ArgumentNullException("control");
			}
			FrameworkElement templateRoot = VisualStateManager.GetTemplateRoot(control);
			if (templateRoot == null)
			{
				return;
			}
			stateGroup.RaiseCurrentStateChanging(templateRoot, oldState, newState, control);
		}

		// Token: 0x06000202 RID: 514 RVA: 0x00008488 File Offset: 0x00006688
		protected void RaiseCurrentStateChanged(VisualStateGroup stateGroup, VisualState oldState, VisualState newState, Control control)
		{
			if (stateGroup == null)
			{
				throw new ArgumentNullException("stateGroup");
			}
			if (newState == null)
			{
				throw new ArgumentNullException("newState");
			}
			if (control == null)
			{
				throw new ArgumentNullException("control");
			}
			FrameworkElement templateRoot = VisualStateManager.GetTemplateRoot(control);
			if (templateRoot == null)
			{
				return;
			}
			stateGroup.RaiseCurrentStateChanged(templateRoot, oldState, newState, control);
		}

		// Token: 0x06000203 RID: 515 RVA: 0x000084D8 File Offset: 0x000066D8
		private static Storyboard GenerateDynamicTransitionAnimations(FrameworkElement root, VisualStateGroup group, VisualState newState, VisualTransition transition)
		{
			Storyboard storyboard = new Storyboard();
			if (transition != null)
			{
				Duration generatedDuration = transition.GeneratedDuration;
				storyboard.Duration = transition.GeneratedDuration;
			}
			else
			{
				storyboard.Duration = new Duration(TimeSpan.Zero);
			}
			Dictionary<VisualStateManager.TimelineDataToken, Timeline> dictionary = VisualStateManager.FlattenTimelines(group.CurrentStoryboards);
			Dictionary<VisualStateManager.TimelineDataToken, Timeline> dictionary2 = VisualStateManager.FlattenTimelines((transition != null) ? transition.Storyboard : null);
			Dictionary<VisualStateManager.TimelineDataToken, Timeline> dictionary3 = VisualStateManager.FlattenTimelines(newState.Storyboard);
			foreach (KeyValuePair<VisualStateManager.TimelineDataToken, Timeline> keyValuePair in dictionary2)
			{
				dictionary.Remove(keyValuePair.Key);
				dictionary3.Remove(keyValuePair.Key);
			}
			foreach (KeyValuePair<VisualStateManager.TimelineDataToken, Timeline> keyValuePair2 in dictionary3)
			{
				Timeline timeline = VisualStateManager.GenerateToAnimation(root, keyValuePair2.Value, true);
				if (timeline != null)
				{
					timeline.Duration = storyboard.Duration;
					storyboard.Children.Add(timeline);
				}
				dictionary.Remove(keyValuePair2.Key);
			}
			foreach (KeyValuePair<VisualStateManager.TimelineDataToken, Timeline> keyValuePair3 in dictionary)
			{
				Timeline timeline2 = VisualStateManager.GenerateFromAnimation(root, keyValuePair3.Value);
				if (timeline2 != null)
				{
					timeline2.Duration = storyboard.Duration;
					storyboard.Children.Add(timeline2);
				}
			}
			return storyboard;
		}

		// Token: 0x06000204 RID: 516 RVA: 0x00008670 File Offset: 0x00006870
		private static Timeline GenerateFromAnimation(FrameworkElement root, Timeline timeline)
		{
			Timeline timeline2 = null;
			if (timeline is ColorAnimation || timeline is ColorAnimationUsingKeyFrames)
			{
				timeline2 = new ColorAnimation();
			}
			else if (timeline is DoubleAnimation || timeline is DoubleAnimationUsingKeyFrames)
			{
				timeline2 = new DoubleAnimation();
			}
			else if (timeline is PointAnimation || timeline is PointAnimationUsingKeyFrames)
			{
				timeline2 = new PointAnimation();
			}
			if (timeline2 != null)
			{
				VisualStateManager.CopyStoryboardTargetProperties(root, timeline, timeline2);
			}
			return timeline2;
		}

		// Token: 0x06000205 RID: 517 RVA: 0x000086D4 File Offset: 0x000068D4
		private static Timeline GenerateToAnimation(FrameworkElement root, Timeline timeline, bool isEntering)
		{
			Timeline timeline2 = null;
			Color? targetColor = VisualStateManager.GetTargetColor(timeline, isEntering);
			if (targetColor != null)
			{
				ColorAnimation colorAnimation = new ColorAnimation
				{
					To = targetColor
				};
				timeline2 = colorAnimation;
			}
			if (timeline2 == null)
			{
				double? targetDouble = VisualStateManager.GetTargetDouble(timeline, isEntering);
				if (targetDouble != null)
				{
					DoubleAnimation doubleAnimation = new DoubleAnimation
					{
						To = targetDouble
					};
					timeline2 = doubleAnimation;
				}
			}
			if (timeline2 == null)
			{
				Point? targetPoint = VisualStateManager.GetTargetPoint(timeline, isEntering);
				if (targetPoint != null)
				{
					PointAnimation pointAnimation = new PointAnimation
					{
						To = targetPoint
					};
					timeline2 = pointAnimation;
				}
			}
			if (timeline2 != null)
			{
				VisualStateManager.CopyStoryboardTargetProperties(root, timeline, timeline2);
			}
			return timeline2;
		}

		// Token: 0x06000206 RID: 518 RVA: 0x0000876C File Offset: 0x0000696C
		private static void CopyStoryboardTargetProperties(FrameworkElement root, Timeline source, Timeline destination)
		{
			if (source != null || destination != null)
			{
				string targetName = Storyboard.GetTargetName(source);
				DependencyObject dependencyObject = Storyboard.GetTarget(source);
				PropertyPath targetProperty = Storyboard.GetTargetProperty(source);
				if (dependencyObject == null && !string.IsNullOrEmpty(targetName))
				{
					dependencyObject = (root.FindName(targetName) as DependencyObject);
				}
				if (targetName != null)
				{
					Storyboard.SetTargetName(destination, targetName);
				}
				if (dependencyObject != null)
				{
					Storyboard.SetTarget(destination, dependencyObject);
				}
				if (targetProperty != null)
				{
					Storyboard.SetTargetProperty(destination, targetProperty);
				}
			}
		}

		// Token: 0x06000207 RID: 519 RVA: 0x000087CC File Offset: 0x000069CC
		internal static VisualTransition GetTransition(FrameworkElement element, VisualStateGroup group, VisualState from, VisualState to)
		{
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			if (group == null)
			{
				throw new ArgumentNullException("group");
			}
			if (to == null)
			{
				throw new ArgumentNullException("to");
			}
			VisualTransition visualTransition = null;
			VisualTransition visualTransition2 = null;
			int num = -1;
			IList<VisualTransition> list = (IList<VisualTransition>)group.Transitions;
			if (list != null)
			{
				foreach (VisualTransition visualTransition3 in list)
				{
					if (visualTransition2 == null && visualTransition3.IsDefault)
					{
						visualTransition2 = visualTransition3;
					}
					else
					{
						int num2 = -1;
						VisualState state = group.GetState(visualTransition3.From);
						VisualState state2 = group.GetState(visualTransition3.To);
						if (from == state)
						{
							num2++;
						}
						else if (state != null)
						{
							continue;
						}
						if (to == state2)
						{
							num2 += 2;
						}
						else if (state2 != null)
						{
							continue;
						}
						if (num2 > num)
						{
							num = num2;
							visualTransition = visualTransition3;
						}
					}
				}
			}
			return visualTransition ?? visualTransition2;
		}

		// Token: 0x06000208 RID: 520 RVA: 0x000088BC File Offset: 0x00006ABC
		private static Color? GetTargetColor(Timeline timeline, bool isEntering)
		{
			ColorAnimation colorAnimation = timeline as ColorAnimation;
			if (colorAnimation != null)
			{
				if (colorAnimation.From == null)
				{
					return colorAnimation.To;
				}
				return colorAnimation.From;
			}
			else
			{
				ColorAnimationUsingKeyFrames colorAnimationUsingKeyFrames = timeline as ColorAnimationUsingKeyFrames;
				if (colorAnimationUsingKeyFrames == null)
				{
					return null;
				}
				if (colorAnimationUsingKeyFrames.KeyFrames.Count == 0)
				{
					return null;
				}
				ColorKeyFrame colorKeyFrame = colorAnimationUsingKeyFrames.KeyFrames[isEntering ? 0 : (colorAnimationUsingKeyFrames.KeyFrames.Count - 1)];
				return new Color?(colorKeyFrame.Value);
			}
		}

		// Token: 0x06000209 RID: 521 RVA: 0x00008948 File Offset: 0x00006B48
		private static double? GetTargetDouble(Timeline timeline, bool isEntering)
		{
			DoubleAnimation doubleAnimation = timeline as DoubleAnimation;
			if (doubleAnimation != null)
			{
				if (doubleAnimation.From == null)
				{
					return doubleAnimation.To;
				}
				return doubleAnimation.From;
			}
			else
			{
				DoubleAnimationUsingKeyFrames doubleAnimationUsingKeyFrames = timeline as DoubleAnimationUsingKeyFrames;
				if (doubleAnimationUsingKeyFrames == null)
				{
					return null;
				}
				if (doubleAnimationUsingKeyFrames.KeyFrames.Count == 0)
				{
					return null;
				}
				DoubleKeyFrame doubleKeyFrame = doubleAnimationUsingKeyFrames.KeyFrames[isEntering ? 0 : (doubleAnimationUsingKeyFrames.KeyFrames.Count - 1)];
				return new double?(doubleKeyFrame.Value);
			}
		}

		// Token: 0x0600020A RID: 522 RVA: 0x000089D4 File Offset: 0x00006BD4
		private static Point? GetTargetPoint(Timeline timeline, bool isEntering)
		{
			PointAnimation pointAnimation = timeline as PointAnimation;
			if (pointAnimation != null)
			{
				if (pointAnimation.From == null)
				{
					return pointAnimation.To;
				}
				return pointAnimation.From;
			}
			else
			{
				PointAnimationUsingKeyFrames pointAnimationUsingKeyFrames = timeline as PointAnimationUsingKeyFrames;
				if (pointAnimationUsingKeyFrames == null)
				{
					return null;
				}
				if (pointAnimationUsingKeyFrames.KeyFrames.Count == 0)
				{
					return null;
				}
				PointKeyFrame pointKeyFrame = pointAnimationUsingKeyFrames.KeyFrames[isEntering ? 0 : (pointAnimationUsingKeyFrames.KeyFrames.Count - 1)];
				return new Point?(pointKeyFrame.Value);
			}
		}

		// Token: 0x0600020B RID: 523 RVA: 0x00008A60 File Offset: 0x00006C60
		private static Dictionary<VisualStateManager.TimelineDataToken, Timeline> FlattenTimelines(Storyboard storyboard)
		{
			Dictionary<VisualStateManager.TimelineDataToken, Timeline> result = new Dictionary<VisualStateManager.TimelineDataToken, Timeline>();
			VisualStateManager.FlattenTimelines(storyboard, result);
			return result;
		}

		// Token: 0x0600020C RID: 524 RVA: 0x00008A7C File Offset: 0x00006C7C
		private static Dictionary<VisualStateManager.TimelineDataToken, Timeline> FlattenTimelines(Collection<Storyboard> storyboards)
		{
			Dictionary<VisualStateManager.TimelineDataToken, Timeline> result = new Dictionary<VisualStateManager.TimelineDataToken, Timeline>();
			for (int i = 0; i < storyboards.Count; i++)
			{
				VisualStateManager.FlattenTimelines(storyboards[i], result);
			}
			return result;
		}

		// Token: 0x0600020D RID: 525 RVA: 0x00008AB0 File Offset: 0x00006CB0
		private static void FlattenTimelines(Storyboard storyboard, Dictionary<VisualStateManager.TimelineDataToken, Timeline> result)
		{
			if (storyboard == null)
			{
				return;
			}
			for (int i = 0; i < storyboard.Children.Count; i++)
			{
				Timeline timeline = storyboard.Children[i];
				Storyboard storyboard2 = timeline as Storyboard;
				if (storyboard2 != null)
				{
					VisualStateManager.FlattenTimelines(storyboard2, result);
				}
				else
				{
					result[new VisualStateManager.TimelineDataToken(timeline)] = timeline;
				}
			}
		}

		// Token: 0x0600020E RID: 526 RVA: 0x00008B04 File Offset: 0x00006D04
		private static FrameworkElement GetTemplateRoot(Control control)
		{
			UserControl userControl = control as UserControl;
			if (userControl != null)
			{
				return userControl.Content as FrameworkElement;
			}
			if (VisualTreeHelper.GetChildrenCount(control) > 0)
			{
				return VisualTreeHelper.GetChild(control, 0) as FrameworkElement;
			}
			return null;
		}

		// Token: 0x0600020F RID: 527 RVA: 0x00008B40 File Offset: 0x00006D40
		private static Control GetTemplatedParent(FrameworkElement element)
		{
			DependencyObject templatedParent = element.TemplatedParent;
			if (templatedParent != null)
			{
				return templatedParent as Control;
			}
			UserControl userControl = element.Parent as UserControl;
			if (userControl != null)
			{
				return userControl;
			}
			return null;
		}

		// Token: 0x0400007B RID: 123
		public static readonly DependencyProperty CustomVisualStateManagerProperty = DependencyProperty.RegisterAttached("CustomVisualStateManager", typeof(VisualStateManager), typeof(VisualStateManager), null);

		// Token: 0x0400007C RID: 124
		internal static readonly DependencyProperty VisualStateGroupsProperty = DependencyProperty.RegisterAttached("InternalVisualStateGroups", typeof(Collection<VisualStateGroup>), typeof(VisualStateManager), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(VisualStateManager.OnVisualStateGroupsChanged)));

		// Token: 0x0400007D RID: 125
		private static readonly Duration DurationZero = new Duration(TimeSpan.Zero);

		// Token: 0x02000020 RID: 32
		private struct TimelineDataToken : IEquatable<VisualStateManager.TimelineDataToken>
		{
			// Token: 0x06000212 RID: 530 RVA: 0x00008BED File Offset: 0x00006DED
			public TimelineDataToken(Timeline timeline)
			{
				this._target = Storyboard.GetTarget(timeline);
				this._targetName = Storyboard.GetTargetName(timeline);
				this._targetProperty = Storyboard.GetTargetProperty(timeline);
			}

			// Token: 0x06000213 RID: 531 RVA: 0x00008C14 File Offset: 0x00006E14
			public bool Equals(VisualStateManager.TimelineDataToken other)
			{
				if (other._target == this._target && other._targetName == this._targetName && other._targetProperty.Path == this._targetProperty.Path && other._targetProperty.PathParameters.Count == this._targetProperty.PathParameters.Count)
				{
					bool result = true;
					int i = 0;
					int count = this._targetProperty.PathParameters.Count;
					while (i < count)
					{
						if (other._targetProperty.PathParameters[i] != this._targetProperty.PathParameters[i])
						{
							result = false;
							break;
						}
						i++;
					}
					return result;
				}
				return false;
			}

			// Token: 0x06000214 RID: 532 RVA: 0x00008CD8 File Offset: 0x00006ED8
			public override int GetHashCode()
			{
				int num = (this._target != null) ? this._target.GetHashCode() : 0;
				int num2 = (this._targetName != null) ? this._targetName.GetHashCode() : 0;
				int num3 = (this._targetProperty != null) ? this._targetProperty.GetHashCode() : 0;
				return num ^ num2 ^ num3;
			}

			// Token: 0x0400007E RID: 126
			private DependencyObject _target;

			// Token: 0x0400007F RID: 127
			private string _targetName;

			// Token: 0x04000080 RID: 128
			private PropertyPath _targetProperty;
		}
	}
}
