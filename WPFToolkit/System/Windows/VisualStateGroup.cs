using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media.Animation;

namespace System.Windows
{
	// Token: 0x0200007A RID: 122
	[RuntimeNameProperty("Name")]
	[ContentProperty("States")]
	public class VisualStateGroup : DependencyObject
	{
		// Token: 0x1700020D RID: 525
		// (get) Token: 0x060008B0 RID: 2224 RVA: 0x00027753 File Offset: 0x00025953
		// (set) Token: 0x060008B1 RID: 2225 RVA: 0x0002775B File Offset: 0x0002595B
		public string Name { get; set; }

		// Token: 0x1700020E RID: 526
		// (get) Token: 0x060008B2 RID: 2226 RVA: 0x00027764 File Offset: 0x00025964
		public IList States
		{
			get
			{
				if (this._states == null)
				{
					this._states = new FreezableCollection<VisualState>();
				}
				return this._states;
			}
		}

		// Token: 0x1700020F RID: 527
		// (get) Token: 0x060008B3 RID: 2227 RVA: 0x0002777F File Offset: 0x0002597F
		public IList Transitions
		{
			get
			{
				if (this._transitions == null)
				{
					this._transitions = new FreezableCollection<VisualTransition>();
				}
				return this._transitions;
			}
		}

		// Token: 0x17000210 RID: 528
		// (get) Token: 0x060008B4 RID: 2228 RVA: 0x0002779A File Offset: 0x0002599A
		// (set) Token: 0x060008B5 RID: 2229 RVA: 0x000277A2 File Offset: 0x000259A2
		internal VisualState CurrentState { get; set; }

		// Token: 0x060008B6 RID: 2230 RVA: 0x000277AC File Offset: 0x000259AC
		internal VisualState GetState(string stateName)
		{
			for (int i = 0; i < this.States.Count; i++)
			{
				VisualState visualState = (VisualState)this.States[i];
				if (visualState.Name == stateName)
				{
					return visualState;
				}
			}
			return null;
		}

		// Token: 0x17000211 RID: 529
		// (get) Token: 0x060008B7 RID: 2231 RVA: 0x000277F2 File Offset: 0x000259F2
		internal Collection<Storyboard> CurrentStoryboards
		{
			get
			{
				if (this._currentStoryboards == null)
				{
					this._currentStoryboards = new Collection<Storyboard>();
				}
				return this._currentStoryboards;
			}
		}

		// Token: 0x060008B8 RID: 2232 RVA: 0x00027810 File Offset: 0x00025A10
		internal void StartNewThenStopOld(FrameworkElement element, params Storyboard[] newStoryboards)
		{
			for (int i = 0; i < this.CurrentStoryboards.Count; i++)
			{
				if (this.CurrentStoryboards[i] != null)
				{
					this.CurrentStoryboards[i].Remove(element);
				}
			}
			this.CurrentStoryboards.Clear();
			for (int j = 0; j < newStoryboards.Length; j++)
			{
				if (newStoryboards[j] != null)
				{
					newStoryboards[j].Begin(element, HandoffBehavior.SnapshotAndReplace, true);
					this.CurrentStoryboards.Add(newStoryboards[j]);
				}
			}
		}

		// Token: 0x060008B9 RID: 2233 RVA: 0x0002788A File Offset: 0x00025A8A
		internal void RaiseCurrentStateChanging(FrameworkElement element, VisualState oldState, VisualState newState, Control control)
		{
			if (this.CurrentStateChanging != null)
			{
				this.CurrentStateChanging(element, new VisualStateChangedEventArgs(oldState, newState, control));
			}
		}

		// Token: 0x060008BA RID: 2234 RVA: 0x000278A9 File Offset: 0x00025AA9
		internal void RaiseCurrentStateChanged(FrameworkElement element, VisualState oldState, VisualState newState, Control control)
		{
			if (this.CurrentStateChanged != null)
			{
				this.CurrentStateChanged(element, new VisualStateChangedEventArgs(oldState, newState, control));
			}
		}

		// Token: 0x14000029 RID: 41
		// (add) Token: 0x060008BB RID: 2235 RVA: 0x000278C8 File Offset: 0x00025AC8
		// (remove) Token: 0x060008BC RID: 2236 RVA: 0x000278E1 File Offset: 0x00025AE1
		public event EventHandler<VisualStateChangedEventArgs> CurrentStateChanged;

		// Token: 0x1400002A RID: 42
		// (add) Token: 0x060008BD RID: 2237 RVA: 0x000278FA File Offset: 0x00025AFA
		// (remove) Token: 0x060008BE RID: 2238 RVA: 0x00027913 File Offset: 0x00025B13
		public event EventHandler<VisualStateChangedEventArgs> CurrentStateChanging;

		// Token: 0x040002B2 RID: 690
		private Collection<Storyboard> _currentStoryboards;

		// Token: 0x040002B3 RID: 691
		private FreezableCollection<VisualState> _states;

		// Token: 0x040002B4 RID: 692
		private FreezableCollection<VisualTransition> _transitions;
	}
}
