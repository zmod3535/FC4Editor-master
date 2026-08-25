using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using IGE.Helpers;
using IGE.Nomad;

namespace IGE.Views
{
	// Token: 0x02000030 RID: 48
	public class SaveAsDialog : Window, IComponentConnector
	{
		// Token: 0x06000264 RID: 612 RVA: 0x0000758C File Offset: 0x0000578C
		public SaveAsDialog()
		{
			this.ForUserData = true;
			SaveAsDialog.SaveAsDialogContext dataContext = new SaveAsDialog.SaveAsDialogContext();
			base.DataContext = dataContext;
			this.InitializeComponent();
		}

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x06000266 RID: 614 RVA: 0x000075F2 File Offset: 0x000057F2
		// (set) Token: 0x06000265 RID: 613 RVA: 0x000075E9 File Offset: 0x000057E9
		public bool RenameMode
		{
			get
			{
				return this._renameMode;
			}
			set
			{
				this._renameMode = value;
			}
		}

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x06000267 RID: 615 RVA: 0x000075FA File Offset: 0x000057FA
		// (set) Token: 0x06000268 RID: 616 RVA: 0x0000760C File Offset: 0x0000580C
		public string MapName
		{
			get
			{
				return ((SaveAsDialog.SaveAsDialogContext)base.DataContext).MapName;
			}
			set
			{
				((SaveAsDialog.SaveAsDialogContext)base.DataContext).MapName = value;
			}
		}

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x06000269 RID: 617 RVA: 0x0000761F File Offset: 0x0000581F
		// (set) Token: 0x0600026A RID: 618 RVA: 0x00007627 File Offset: 0x00005827
		public bool ForUserData { get; set; }

		// Token: 0x0600026B RID: 619 RVA: 0x00007630 File Offset: 0x00005830
		private void OkButton_Click(object sender, RoutedEventArgs e)
		{
			if (this.IsValid(this))
			{
				string path = this.ForUserData ? StorageUtils.GetFullUserMapPath(this.MapName) : StorageUtils.GetFullMapPathForConsole(this.MapName);
				if (File.Exists(path))
				{
					if (this.RenameMode)
					{
						MessageBox.Show(this, this._renameOverrideAlert, base.Title, MessageBoxButton.OK);
						return;
					}
					MessageBoxResult messageBoxResult = MessageBox.Show(this, this._overrideQuery, this._dialogTitle, MessageBoxButton.YesNo);
					if (messageBoxResult == MessageBoxResult.No)
					{
						return;
					}
				}
				base.DialogResult = new bool?(true);
			}
		}

		// Token: 0x0600026C RID: 620 RVA: 0x000076B1 File Offset: 0x000058B1
		private void CancelButton_Click(object sender, RoutedEventArgs e)
		{
			base.DialogResult = new bool?(false);
		}

		// Token: 0x0600026D RID: 621 RVA: 0x000076C0 File Offset: 0x000058C0
		private bool IsValid(DependencyObject node)
		{
			if (node != null && System.Windows.Controls.Validation.GetHasError(node))
			{
				if (node is IInputElement)
				{
					Keyboard.Focus((IInputElement)node);
				}
				return false;
			}
			foreach (object obj in LogicalTreeHelper.GetChildren(node))
			{
				if (obj is DependencyObject && !this.IsValid((DependencyObject)obj))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0600026E RID: 622 RVA: 0x00007754 File Offset: 0x00005954
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/IGE.WPF.Core64;component/views/windows/saveasdialog.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600026F RID: 623 RVA: 0x00007784 File Offset: 0x00005984
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000270 RID: 624 RVA: 0x00007790 File Offset: 0x00005990
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				this.MapNameTextBox = (TextBox)target;
				return;
			case 2:
				this.OkButton = (Button)target;
				this.OkButton.Click += this.OkButton_Click;
				return;
			case 3:
				this.CancelButton = (Button)target;
				this.CancelButton.Click += this.CancelButton_Click;
				return;
			default:
				this._contentLoaded = true;
				return;
			}
		}

		// Token: 0x040000FC RID: 252
		private string _dialogTitle = Localizer.LocalizeCommon("DIALOG_SAVE_AS");

		// Token: 0x040000FD RID: 253
		private string _overrideQuery = Localizer.LocalizeCommon("DIALOG_SAVE_AS_OVERRIDE_QUERY");

		// Token: 0x040000FE RID: 254
		private string _renameOverrideAlert = Localizer.LocalizeCommon("MSG_DESC_MAPNAME_DUPLICATED");

		// Token: 0x040000FF RID: 255
		private bool _renameMode;

		// Token: 0x04000100 RID: 256
		internal TextBox MapNameTextBox;

		// Token: 0x04000101 RID: 257
		internal Button OkButton;

		// Token: 0x04000102 RID: 258
		internal Button CancelButton;

		// Token: 0x04000103 RID: 259
		private bool _contentLoaded;

		// Token: 0x02000031 RID: 49
		private class SaveAsDialogContext : DependencyObject
		{
			// Token: 0x06000271 RID: 625 RVA: 0x00007811 File Offset: 0x00005A11
			public SaveAsDialogContext()
			{
				this.DialogTitle = this._dialogTitle;
				this.MapNameLabel = Localizer.Localize("PARAM_MAP_NAME", null);
			}

			// Token: 0x170000B2 RID: 178
			// (get) Token: 0x06000272 RID: 626 RVA: 0x00007846 File Offset: 0x00005A46
			// (set) Token: 0x06000273 RID: 627 RVA: 0x0000784E File Offset: 0x00005A4E
			public string DialogTitle { get; private set; }

			// Token: 0x170000B3 RID: 179
			// (get) Token: 0x06000274 RID: 628 RVA: 0x00007857 File Offset: 0x00005A57
			// (set) Token: 0x06000275 RID: 629 RVA: 0x0000785F File Offset: 0x00005A5F
			public string MapNameLabel { get; private set; }

			// Token: 0x170000B4 RID: 180
			// (get) Token: 0x06000276 RID: 630 RVA: 0x00007868 File Offset: 0x00005A68
			// (set) Token: 0x06000277 RID: 631 RVA: 0x0000787A File Offset: 0x00005A7A
			public string MapName
			{
				get
				{
					return (string)base.GetValue(SaveAsDialog.SaveAsDialogContext.MapNameProperty);
				}
				set
				{
					base.SetValue(SaveAsDialog.SaveAsDialogContext.MapNameProperty, value);
				}
			}

			// Token: 0x04000105 RID: 261
			private string _dialogTitle = Localizer.LocalizeCommon("DIALOG_SAVE_AS");

			// Token: 0x04000106 RID: 262
			public static readonly DependencyProperty MapNameProperty = DependencyProperty.Register("MapName", typeof(string), typeof(SaveAsDialog.SaveAsDialogContext), new UIPropertyMetadata(""));
		}
	}
}
