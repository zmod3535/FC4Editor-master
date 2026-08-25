using System;
using System.CodeDom.Compiler;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using IGE.Nomad;
using Ubisoft;

namespace IGE.Views
{
	// Token: 0x02000021 RID: 33
	public class InitDialog : Window, IComponentConnector, IStyleConnector
	{
		// Token: 0x060000EE RID: 238 RVA: 0x00003510 File Offset: 0x00001710
		public InitDialog()
		{
			InitDialog.InitDialogContext dataContext = new InitDialog.InitDialogContext();
			base.DataContext = dataContext;
			this.InitializeComponent();
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x060000EF RID: 239 RVA: 0x00003536 File Offset: 0x00001736
		public InitDialog.ActionEntry SelectedAction
		{
			get
			{
				return ((InitDialog.InitDialogContext)base.DataContext).SelectedAction;
			}
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x00003548 File Offset: 0x00001748
		public void AppendAction(InitDialog.ActionEntry action)
		{
			InitDialog.InitDialogContext initDialogContext = base.DataContext as InitDialog.InitDialogContext;
			if (initDialogContext != null)
			{
				initDialogContext.ActionList.Add(action);
			}
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x00003570 File Offset: 0x00001770
		private void CloseIfActionSelected()
		{
			InitDialog.InitDialogContext initDialogContext = base.DataContext as InitDialog.InitDialogContext;
			if (initDialogContext != null && initDialogContext.SelectedAction != null)
			{
				base.DialogResult = new bool?(true);
			}
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x000035A0 File Offset: 0x000017A0
		private void OkButton_Click(object sender, RoutedEventArgs e)
		{
			this.CloseIfActionSelected();
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x000035A8 File Offset: 0x000017A8
		private void CancelButton_Click(object sender, RoutedEventArgs e)
		{
			base.DialogResult = new bool?(false);
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x000035B6 File Offset: 0x000017B6
		private void ActionListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			this.OkButton.IsEnabled = (this.ActionListBox.SelectedItem != null);
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x000035D4 File Offset: 0x000017D4
		private void ListBoxItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			this.CloseIfActionSelected();
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x000035DC File Offset: 0x000017DC
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/IGE.WPF.Core64;component/views/windows/initdialog.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x0000360C File Offset: 0x0000180C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				this.ActionListBox = (ListBox)target;
				this.ActionListBox.SelectionChanged += this.ActionListBox_SelectionChanged;
				return;
			case 3:
				this.OkButton = (Button)target;
				this.OkButton.Click += this.OkButton_Click;
				return;
			case 4:
				this.CancelButton = (Button)target;
				this.CancelButton.Click += this.CancelButton_Click;
				return;
			}
			this._contentLoaded = true;
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x000036A8 File Offset: 0x000018A8
		[DebuggerNonUserCode]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		void IStyleConnector.Connect(int connectionId, object target)
		{
			if (connectionId != 2)
			{
				return;
			}
			EventSetter eventSetter = new EventSetter();
			eventSetter.Event = Control.MouseDoubleClickEvent;
			eventSetter.Handler = new MouseButtonEventHandler(this.ListBoxItem_MouseDoubleClick);
			((Style)target).Setters.Add(eventSetter);
		}

		// Token: 0x0400004B RID: 75
		internal ListBox ActionListBox;

		// Token: 0x0400004C RID: 76
		internal Button OkButton;

		// Token: 0x0400004D RID: 77
		internal Button CancelButton;

		// Token: 0x0400004E RID: 78
		private bool _contentLoaded;

		// Token: 0x02000022 RID: 34
		// (Invoke) Token: 0x060000FA RID: 250
		public delegate bool ActionDelegate();

		// Token: 0x02000023 RID: 35
		public class ActionEntry
		{
			// Token: 0x17000045 RID: 69
			// (get) Token: 0x060000FD RID: 253 RVA: 0x000036F0 File Offset: 0x000018F0
			// (set) Token: 0x060000FE RID: 254 RVA: 0x000036F8 File Offset: 0x000018F8
			public string Content { get; set; }

			// Token: 0x17000046 RID: 70
			// (get) Token: 0x060000FF RID: 255 RVA: 0x00003701 File Offset: 0x00001901
			// (set) Token: 0x06000100 RID: 256 RVA: 0x00003709 File Offset: 0x00001909
			public InitDialog.ActionDelegate Action { get; set; }

			// Token: 0x06000101 RID: 257 RVA: 0x00003712 File Offset: 0x00001912
			public override string ToString()
			{
				return this.Content;
			}
		}

		// Token: 0x02000024 RID: 36
		private class InitDialogContext : ViewModel
		{
			// Token: 0x06000103 RID: 259 RVA: 0x00003722 File Offset: 0x00001922
			public InitDialogContext()
			{
				this.DialogTitle = Localizer.Localize("EDITOR_NAME", null);
				this.ActionList = new ObservableCollection<InitDialog.ActionEntry>();
			}

			// Token: 0x17000047 RID: 71
			// (get) Token: 0x06000104 RID: 260 RVA: 0x00003746 File Offset: 0x00001946
			// (set) Token: 0x06000105 RID: 261 RVA: 0x0000374E File Offset: 0x0000194E
			public string DialogTitle { get; private set; }

			// Token: 0x17000048 RID: 72
			// (get) Token: 0x06000106 RID: 262 RVA: 0x00003757 File Offset: 0x00001957
			// (set) Token: 0x06000107 RID: 263 RVA: 0x0000375F File Offset: 0x0000195F
			public InitDialog.ActionEntry SelectedAction
			{
				get
				{
					return this._selectedAction;
				}
				set
				{
					this._selectedAction = value;
					base.RaisePropertyChanged("SelectedAction");
				}
			}

			// Token: 0x17000049 RID: 73
			// (get) Token: 0x06000108 RID: 264 RVA: 0x00003773 File Offset: 0x00001973
			// (set) Token: 0x06000109 RID: 265 RVA: 0x0000377B File Offset: 0x0000197B
			public ObservableCollection<InitDialog.ActionEntry> ActionList { get; set; }

			// Token: 0x04000051 RID: 81
			private InitDialog.ActionEntry _selectedAction;
		}
	}
}
