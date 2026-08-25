using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using Divelements.SandDock;
using IGE.Nomad;
using IGE.UI;
using IGE.ViewModels;
using Microsoft.Win32;

namespace IGE
{
	// Token: 0x02000085 RID: 133
	public class MainWindow : Window, IComponentConnector, IStyleConnector
	{
		// Token: 0x0600058E RID: 1422 RVA: 0x00015032 File Offset: 0x00013232
		public MainWindow()
		{
			this.InitializeComponent();
		}

		// Token: 0x17000123 RID: 291
		// (get) Token: 0x0600058F RID: 1423 RVA: 0x00015040 File Offset: 0x00013240
		internal ViewportControl GameViewport
		{
			get
			{
				return this.Viewport;
			}
		}

		// Token: 0x06000590 RID: 1424 RVA: 0x00015048 File Offset: 0x00013248
		private void MainWindow_Loaded(object sender, RoutedEventArgs e)
		{
			base.Topmost = false;
			MainWindowViewModel mainWindowViewModel = base.DataContext as MainWindowViewModel;
			if (mainWindowViewModel != null)
			{
				mainWindowViewModel.UiPostLoad();
			}
			HwndSource hwndSource = PresentationSource.FromVisual(this) as HwndSource;
			if (hwndSource != null)
			{
				hwndSource.AddHook(new HwndSourceHook(this.WndProc));
			}
		}

		// Token: 0x06000591 RID: 1425 RVA: 0x00015094 File Offset: 0x00013294
		private void MainWindow_OnClosing(object sender, CancelEventArgs e)
		{
			MainWindowViewModel mainWindowViewModel = base.DataContext as MainWindowViewModel;
			if (mainWindowViewModel.Loaded && !mainWindowViewModel.CloseWindow())
			{
				e.Cancel = true;
			}
			HwndSource hwndSource = PresentationSource.FromVisual(this) as HwndSource;
			if (hwndSource != null)
			{
				hwndSource.RemoveHook(new HwndSourceHook(this.WndProc));
			}
			this.SaveSettings();
		}

		// Token: 0x06000592 RID: 1426 RVA: 0x000150EC File Offset: 0x000132EC
		public void SaveSettings()
		{
			RegistryKey registrySettings = Editor.GetRegistrySettings();
			registrySettings.SetValue("Placement", this.GetPlacement());
			registrySettings.SetValue("SandDock", Program.MainWin.MainDockSite.GetLayout(false));
			registrySettings.Close();
		}

		// Token: 0x06000593 RID: 1427 RVA: 0x00015134 File Offset: 0x00013334
		public void LoadSettings()
		{
			RegistryKey registrySettings = Editor.GetRegistrySettings();
			this.SetPlacement(Editor.GetRegistryString(registrySettings, "Placement", null));
			string registryString = Editor.GetRegistryString(registrySettings, "SandDock", null);
			if (registryString != null)
			{
				try
				{
					Program.MainWin.MainDockSite.SetLayout(Editor.GetRegistryString(registrySettings, "SandDock", null));
				}
				catch
				{
				}
			}
			registrySettings.Close();
		}

		// Token: 0x06000594 RID: 1428 RVA: 0x000151A0 File Offset: 0x000133A0
		private void MainWindow_KeyEvent(object sender, System.Windows.Input.KeyEventArgs e)
		{
			if (this.IsEditable(e.OriginalSource) || this.Viewport.Focused)
			{
				return;
			}
			Keys keyData = (Keys)KeyInterop.VirtualKeyFromKey(e.Key);
			System.Windows.Forms.KeyEventArgs ea = new System.Windows.Forms.KeyEventArgs(keyData);
			if (e.IsDown)
			{
				Editor.HandleKeyDown(ea, e.IsRepeat);
				return;
			}
			if (e.IsUp)
			{
				Editor.HandleKeyUp(ea);
			}
		}

		// Token: 0x06000595 RID: 1429 RVA: 0x00015209 File Offset: 0x00013409
		private bool IsEditable(object source)
		{
			return source is System.Windows.Controls.Primitives.TextBoxBase || source is TextBlock;
		}

		// Token: 0x06000596 RID: 1430 RVA: 0x0001521E File Offset: 0x0001341E
		private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
		{
			if (msg == 537)
			{
				IGE.Nomad.Binding.PC_DeviceChange(wParam.ToInt64(), lParam.ToInt64());
				handled = true;
				return new IntPtr(1);
			}
			return IntPtr.Zero;
		}

		// Token: 0x06000597 RID: 1431 RVA: 0x00015250 File Offset: 0x00013450
		private void MainWindow_CameraSpeedItemClick(object sender, RoutedEventArgs e)
		{
			object content = (sender as ComboBoxItem).Content;
			MainWindowViewModel mainWindowViewModel = base.DataContext as MainWindowViewModel;
			if (mainWindowViewModel.SelectCustomCameraSpeed(content))
			{
				int selectedIndex = this.CameraSpeedComboBox.SelectedIndex;
				this.CameraSpeedComboBox.SelectedIndex = -1;
				this.CameraSpeedComboBox.SelectedIndex = selectedIndex;
			}
		}

		// Token: 0x06000598 RID: 1432 RVA: 0x000152A4 File Offset: 0x000134A4
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/IGE.WPF.Core64;component/views/mainwindow.xaml", UriKind.Relative);
			System.Windows.Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000599 RID: 1433 RVA: 0x000152D4 File Offset: 0x000134D4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600059A RID: 1434 RVA: 0x000152E0 File Offset: 0x000134E0
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				((MainWindow)target).Loaded += this.MainWindow_Loaded;
				((MainWindow)target).Closing += this.MainWindow_OnClosing;
				((MainWindow)target).KeyDown += this.MainWindow_KeyEvent;
				((MainWindow)target).KeyUp += this.MainWindow_KeyEvent;
				return;
			case 2:
				this.CameraSpeedComboBox = (System.Windows.Controls.ComboBox)target;
				return;
			case 4:
				this.MainDockSite = (DockSite)target;
				return;
			case 5:
				this.Viewport = (ViewportControl)target;
				return;
			case 6:
				this.DockToolParameters = (DockableWindow)target;
				return;
			case 7:
				this.DockEditorSettings = (DockableWindow)target;
				return;
			case 8:
				this.DockContextHelp = (DockableWindow)target;
				return;
			case 9:
				this.ContextScroll = (ScrollViewer)target;
				return;
			case 10:
				this.DockBudgets = (DockableWindow)target;
				return;
			case 11:
				this.DockObjectProperties = (DockableWindow)target;
				return;
			}
			this._contentLoaded = true;
		}

		// Token: 0x0600059B RID: 1435 RVA: 0x00015404 File Offset: 0x00013604
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerNonUserCode]
		void IStyleConnector.Connect(int connectionId, object target)
		{
			if (connectionId != 3)
			{
				return;
			}
			EventSetter eventSetter = new EventSetter();
			eventSetter.Event = UIElement.PreviewMouseDownEvent;
			eventSetter.Handler = new MouseButtonEventHandler(this.MainWindow_CameraSpeedItemClick);
			((Style)target).Setters.Add(eventSetter);
		}

		// Token: 0x04000259 RID: 601
		internal System.Windows.Controls.ComboBox CameraSpeedComboBox;

		// Token: 0x0400025A RID: 602
		internal DockSite MainDockSite;

		// Token: 0x0400025B RID: 603
		internal ViewportControl Viewport;

		// Token: 0x0400025C RID: 604
		internal DockableWindow DockToolParameters;

		// Token: 0x0400025D RID: 605
		internal DockableWindow DockEditorSettings;

		// Token: 0x0400025E RID: 606
		internal DockableWindow DockContextHelp;

		// Token: 0x0400025F RID: 607
		internal ScrollViewer ContextScroll;

		// Token: 0x04000260 RID: 608
		internal DockableWindow DockBudgets;

		// Token: 0x04000261 RID: 609
		internal DockableWindow DockObjectProperties;

		// Token: 0x04000262 RID: 610
		private bool _contentLoaded;
	}
}
