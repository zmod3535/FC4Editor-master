using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using IGE.Nomad;

namespace IGE.Views
{
	// Token: 0x02000086 RID: 134
	public class AboutWindow : Window, IComponentConnector
	{
		// Token: 0x0600059C RID: 1436 RVA: 0x0001544C File Offset: 0x0001364C
		public AboutWindow(bool isAbout = true)
		{
			this.InitializeComponent();
			this.IsAbout = isAbout;
			if (!this.IsAbout)
			{
				DispatcherTimer dispatcherTimer = new DispatcherTimer();
				dispatcherTimer.Tick += this.TimerOnTick;
				dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 30);
				dispatcherTimer.Start();
			}
			this.Progress.Visibility = (this.IsAbout ? Visibility.Hidden : Visibility.Visible);
			base.Topmost = this.IsAbout;
		}

		// Token: 0x0600059D RID: 1437 RVA: 0x000154C8 File Offset: 0x000136C8
		private void TimerOnTick(object sender, EventArgs eventArgs)
		{
			this._gradient += 0.1;
			this.TextLoading.Foreground.Opacity = 0.5 + (Math.Cos(this._gradient) + 1.0) / 4.0;
			int num = (Binding.FCE_GetProgress == null) ? 0 : Binding.FCE_GetProgress();
			if (this._previousValue != num)
			{
				if ((double)num > this.Progress.Value)
				{
					this.Progress.Value = (double)num;
				}
				this._previousValue = num;
				this._progressStep = (double)num / this._gradient;
				return;
			}
			double num2 = Math.Min(100.0, this._gradient * this._progressStep);
			if (num2 > this.Progress.Value)
			{
				this.Progress.Value = num2;
			}
		}

		// Token: 0x17000124 RID: 292
		// (get) Token: 0x0600059E RID: 1438 RVA: 0x000155AB File Offset: 0x000137AB
		// (set) Token: 0x0600059F RID: 1439 RVA: 0x000155BB File Offset: 0x000137BB
		private bool IsAbout
		{
			get
			{
				return this.TextLoading.Visibility == Visibility.Hidden;
			}
			set
			{
				this.TextLoading.Visibility = (value ? Visibility.Hidden : Visibility.Visible);
			}
		}

		// Token: 0x060005A0 RID: 1440 RVA: 0x000155CF File Offset: 0x000137CF
		private void AboutWindow_OnMouseDown(object sender, MouseButtonEventArgs e)
		{
			if (this.IsAbout)
			{
				base.Close();
			}
		}

		// Token: 0x060005A1 RID: 1441 RVA: 0x000155E8 File Offset: 0x000137E8
		private void OnClosing(object sender, CancelEventArgs e)
		{
			base.Closing -= this.OnClosing;
			e.Cancel = true;
			DoubleAnimation doubleAnimation = new DoubleAnimation(0.0, TimeSpan.FromSeconds(1.0));
			doubleAnimation.Completed += delegate(object s, EventArgs a)
			{
				base.Close();
			};
			base.BeginAnimation(UIElement.OpacityProperty, doubleAnimation);
		}

		// Token: 0x060005A2 RID: 1442 RVA: 0x00015650 File Offset: 0x00013850
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/IGE.WPF.Core64;component/views/windows/aboutwindowview.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060005A3 RID: 1443 RVA: 0x00015680 File Offset: 0x00013880
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				((AboutWindow)target).MouseDown += this.AboutWindow_OnMouseDown;
				((AboutWindow)target).Closing += this.OnClosing;
				return;
			case 2:
				this.Canvas = (Canvas)target;
				return;
			case 3:
				this.TextLoading = (TextBlock)target;
				return;
			case 4:
				this.Progress = (ProgressBar)target;
				return;
			default:
				this._contentLoaded = true;
				return;
			}
		}

		// Token: 0x04000263 RID: 611
		private const double GradientSpeed = 0.1;

		// Token: 0x04000264 RID: 612
		private double _gradient;

		// Token: 0x04000265 RID: 613
		private int _previousValue;

		// Token: 0x04000266 RID: 614
		private double _progressStep;

		// Token: 0x04000267 RID: 615
		internal Canvas Canvas;

		// Token: 0x04000268 RID: 616
		internal TextBlock TextLoading;

		// Token: 0x04000269 RID: 617
		internal ProgressBar Progress;

		// Token: 0x0400026A RID: 618
		private bool _contentLoaded;
	}
}
