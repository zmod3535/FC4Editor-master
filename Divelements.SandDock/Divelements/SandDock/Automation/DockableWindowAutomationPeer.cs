using System;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;

namespace Divelements.SandDock.Automation
{
	// Token: 0x02000006 RID: 6
	internal class DockableWindowAutomationPeer : FrameworkElementAutomationPeer, IWindowProvider, IDockProvider
	{
		// Token: 0x0600001E RID: 30 RVA: 0x00030F5C File Offset: 0x0002F35C
		internal DockableWindowAutomationPeer(DockableWindow window) : base(window)
		{
			this.window = window;
			window.DockSituationChanged += this.OnWindowDockSituationChanged;
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00030F88 File Offset: 0x0002F388
		private void OnWindowDockSituationChanged(object sender, EventArgs e)
		{
			DockPosition dockPositionFromWindow = this.GetDockPositionFromWindow(this.window);
			base.RaisePropertyChangedEvent(DockPatternIdentifiers.DockPositionProperty, this.lastDockPosition, dockPositionFromWindow);
			this.lastDockPosition = dockPositionFromWindow;
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00030FC8 File Offset: 0x0002F3C8
		protected override string GetClassNameCore()
		{
			return "DockableWindow";
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00030FD0 File Offset: 0x0002F3D0
		protected override AutomationControlType GetAutomationControlTypeCore()
		{
			return AutomationControlType.Window;
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00030FD4 File Offset: 0x0002F3D4
		protected override bool IsOffscreenCore()
		{
			return this.window.DockSituation == DockSituation.None;
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00030FE4 File Offset: 0x0002F3E4
		public override object GetPattern(PatternInterface patternInterface)
		{
			switch (patternInterface)
			{
			case PatternInterface.Window:
				return this;
			case PatternInterface.Dock:
				return this;
			}
			return base.GetPattern(patternInterface);
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00031018 File Offset: 0x0002F418
		protected override string GetNameCore()
		{
			string text = base.GetNameCore();
			if (string.IsNullOrEmpty(text))
			{
				text = this.window.Title;
			}
			return text;
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00031044 File Offset: 0x0002F444
		private DockPosition GetDockPositionFromWindow(DockableWindow window)
		{
			if (window.DockSituation == DockSituation.Docked)
			{
				if (window.MetaData.LastFixedDockSide == Dock.Left)
				{
					return DockPosition.Left;
				}
				if (window.MetaData.LastFixedDockSide == Dock.Top)
				{
					return DockPosition.Top;
				}
				if (window.MetaData.LastFixedDockSide == Dock.Right)
				{
					return DockPosition.Right;
				}
				return DockPosition.Bottom;
			}
			else
			{
				if (window.DockSituation == DockSituation.Document)
				{
					return DockPosition.Fill;
				}
				return DockPosition.None;
			}
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00031098 File Offset: 0x0002F498
		protected override void SetFocusCore()
		{
			this.window.Open(WindowOpenMethod.OpenSelectActivate);
		}

		// Token: 0x06000027 RID: 39 RVA: 0x000310A8 File Offset: 0x0002F4A8
		void IWindowProvider.Close()
		{
			if (this.window.AllowClose)
			{
				this.window.Close();
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000028 RID: 40 RVA: 0x000310C4 File Offset: 0x0002F4C4
		WindowInteractionState IWindowProvider.InteractionState
		{
			get
			{
				return WindowInteractionState.ReadyForUserInteraction;
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000029 RID: 41 RVA: 0x000310C8 File Offset: 0x0002F4C8
		bool IWindowProvider.IsModal
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600002A RID: 42 RVA: 0x000310CC File Offset: 0x0002F4CC
		bool IWindowProvider.IsTopmost
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600002B RID: 43 RVA: 0x000310D0 File Offset: 0x0002F4D0
		bool IWindowProvider.Maximizable
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600002C RID: 44 RVA: 0x000310D4 File Offset: 0x0002F4D4
		bool IWindowProvider.Minimizable
		{
			get
			{
				return false;
			}
		}

		// Token: 0x0600002D RID: 45 RVA: 0x000310D8 File Offset: 0x0002F4D8
		void IWindowProvider.SetVisualState(WindowVisualState state)
		{
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600002E RID: 46 RVA: 0x000310DC File Offset: 0x0002F4DC
		WindowVisualState IWindowProvider.VisualState
		{
			get
			{
				return WindowVisualState.Normal;
			}
		}

		// Token: 0x0600002F RID: 47 RVA: 0x000310E0 File Offset: 0x0002F4E0
		bool IWindowProvider.WaitForInputIdle(int milliseconds)
		{
			return true;
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000030 RID: 48 RVA: 0x000310E4 File Offset: 0x0002F4E4
		DockPosition IDockProvider.DockPosition
		{
			get
			{
				return this.GetDockPositionFromWindow(this.window);
			}
		}

		// Token: 0x06000031 RID: 49 RVA: 0x000310F4 File Offset: 0x0002F4F4
		void IDockProvider.SetDockPosition(DockPosition dockPosition)
		{
			switch (dockPosition)
			{
			case DockPosition.Top:
				if (this.window.DockingRules.AllowDockTop)
				{
					this.window.Dock(WindowOpenMethod.OpenSelectActivate, Dock.Top);
					return;
				}
				return;
			case DockPosition.Left:
				if (this.window.DockingRules.AllowDockLeft)
				{
					this.window.Dock(WindowOpenMethod.OpenSelectActivate, Dock.Left);
					return;
				}
				return;
			case DockPosition.Bottom:
				if (this.window.DockingRules.AllowDockBottom)
				{
					this.window.Dock(WindowOpenMethod.OpenSelectActivate, Dock.Bottom);
					return;
				}
				return;
			case DockPosition.Right:
				if (this.window.DockingRules.AllowDockRight)
				{
					this.window.Dock(WindowOpenMethod.OpenSelectActivate, Dock.Right);
					return;
				}
				return;
			case DockPosition.Fill:
				if (this.window.DockingRules.AllowTab)
				{
					this.window.Document(WindowOpenMethod.OpenSelectActivate);
					return;
				}
				return;
			}
			if (this.window.DockingRules.AllowFloat)
			{
				this.window.Float(WindowOpenMethod.OpenSelectActivate);
			}
		}

		// Token: 0x04000004 RID: 4
		private DockableWindow window;

		// Token: 0x04000005 RID: 5
		private DockPosition lastDockPosition = DockPosition.None;
	}
}
