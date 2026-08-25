using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using IGE.Nomad;
using Ubisoft;

namespace IGE.Views
{
	// Token: 0x020000F1 RID: 241
	public class NewMapDialog : Window, IComponentConnector
	{
		// Token: 0x06000878 RID: 2168 RVA: 0x0001CAAC File Offset: 0x0001ACAC
		public NewMapDialog()
		{
			NewMapDialog.NewMapDialogContext dataContext = new NewMapDialog.NewMapDialogContext();
			base.DataContext = dataContext;
			this.InitializeComponent();
		}

		// Token: 0x170001E7 RID: 487
		// (get) Token: 0x06000879 RID: 2169 RVA: 0x0001CAD2 File Offset: 0x0001ACD2
		public ulong SelectedObjective
		{
			get
			{
				return ((NewMapDialog.NewMapDialogContext)base.DataContext).SelectedObjectiveListItem.Data;
			}
		}

		// Token: 0x170001E8 RID: 488
		// (get) Token: 0x0600087A RID: 2170 RVA: 0x0001CAE9 File Offset: 0x0001ACE9
		public ulong SelectedTerrain
		{
			get
			{
				return ((NewMapDialog.NewMapDialogContext)base.DataContext).SelectedTerrainListItem.Data;
			}
		}

		// Token: 0x0600087B RID: 2171 RVA: 0x0001CB00 File Offset: 0x0001AD00
		private void OkButton_Click(object sender, RoutedEventArgs e)
		{
			if (this.IsValid(this))
			{
				base.DialogResult = new bool?(true);
			}
		}

		// Token: 0x0600087C RID: 2172 RVA: 0x0001CB17 File Offset: 0x0001AD17
		private void CancelButton_Click(object sender, RoutedEventArgs e)
		{
			base.DialogResult = new bool?(false);
		}

		// Token: 0x0600087D RID: 2173 RVA: 0x0001CB28 File Offset: 0x0001AD28
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

		// Token: 0x0600087E RID: 2174 RVA: 0x0001CBBC File Offset: 0x0001ADBC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/IGE.WPF.Core64;component/views/windows/newmapdialog.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600087F RID: 2175 RVA: 0x0001CBEC File Offset: 0x0001ADEC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				this.ObjectiveComboBox = (ComboBox)target;
				return;
			case 2:
				this.TerrainComboBox = (ComboBox)target;
				return;
			case 3:
				this.OkButton = (Button)target;
				this.OkButton.Click += this.OkButton_Click;
				return;
			case 4:
				this.CancelButton = (Button)target;
				this.CancelButton.Click += this.CancelButton_Click;
				return;
			default:
				this._contentLoaded = true;
				return;
			}
		}

		// Token: 0x04000421 RID: 1057
		internal ComboBox ObjectiveComboBox;

		// Token: 0x04000422 RID: 1058
		internal ComboBox TerrainComboBox;

		// Token: 0x04000423 RID: 1059
		internal Button OkButton;

		// Token: 0x04000424 RID: 1060
		internal Button CancelButton;

		// Token: 0x04000425 RID: 1061
		private bool _contentLoaded;

		// Token: 0x020000F2 RID: 242
		private class NewMapDialogContext : ViewModel
		{
			// Token: 0x06000880 RID: 2176 RVA: 0x0001CC80 File Offset: 0x0001AE80
			public NewMapDialogContext()
			{
				this.DialogTitle = Localizer.LocalizeCommon("STARTUP_NEW_MAP");
				this.ObjectiveLabel = Localizer.LocalizeCommon("PARAM_MAP_OBJECTIVE");
				this.TerainLabel = Localizer.LocalizeCommon("GAMEMODE_TERRAIN");
				this.ObjectiveList = new List<NewMapDialog.NewMapDialogContext.Entry>();
				foreach (ObjectiveType objectiveType in GameModeManager.ObjectiveTypes.Values)
				{
					NewMapDialog.NewMapDialogContext.Entry entry = new NewMapDialog.NewMapDialogContext.Entry();
					entry.Content = string.Format("{0}", objectiveType.Name);
					entry.Data = objectiveType.Id;
					this.ObjectiveList.Add(entry);
				}
				if (this.ObjectiveList.Count > 0)
				{
					this.SelectedObjectiveListItem = this.ObjectiveList[0];
				}
				this.TerrainList = new List<NewMapDialog.NewMapDialogContext.Entry>();
				foreach (WildernessInventory.Entry entry2 in WildernessInventory.Instance.Entries.Values)
				{
					string text = Localizer.LocalizeCommon(entry2.LocId);
					text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
					NewMapDialog.NewMapDialogContext.Entry entry3 = new NewMapDialog.NewMapDialogContext.Entry();
					entry3.Content = text;
					entry3.Data = entry2.DbId;
					this.TerrainList.Add(entry3);
				}
				if (this.TerrainList.Count > 0)
				{
					this.SelectedTerrainListItem = this.TerrainList[0];
				}
			}

			// Token: 0x170001E9 RID: 489
			// (get) Token: 0x06000881 RID: 2177 RVA: 0x0001CE24 File Offset: 0x0001B024
			// (set) Token: 0x06000882 RID: 2178 RVA: 0x0001CE2C File Offset: 0x0001B02C
			public string DialogTitle { get; private set; }

			// Token: 0x170001EA RID: 490
			// (get) Token: 0x06000883 RID: 2179 RVA: 0x0001CE35 File Offset: 0x0001B035
			// (set) Token: 0x06000884 RID: 2180 RVA: 0x0001CE3D File Offset: 0x0001B03D
			public string ObjectiveLabel { get; private set; }

			// Token: 0x170001EB RID: 491
			// (get) Token: 0x06000885 RID: 2181 RVA: 0x0001CE46 File Offset: 0x0001B046
			// (set) Token: 0x06000886 RID: 2182 RVA: 0x0001CE4E File Offset: 0x0001B04E
			public string TerainLabel { get; private set; }

			// Token: 0x170001EC RID: 492
			// (get) Token: 0x06000887 RID: 2183 RVA: 0x0001CE57 File Offset: 0x0001B057
			// (set) Token: 0x06000888 RID: 2184 RVA: 0x0001CE5F File Offset: 0x0001B05F
			public NewMapDialog.NewMapDialogContext.Entry SelectedObjectiveListItem
			{
				get
				{
					return this._selectedObjectiveListItem;
				}
				set
				{
					this._selectedObjectiveListItem = value;
					base.RaisePropertyChanged("SelectedObjectiveListItem");
				}
			}

			// Token: 0x170001ED RID: 493
			// (get) Token: 0x06000889 RID: 2185 RVA: 0x0001CE73 File Offset: 0x0001B073
			// (set) Token: 0x0600088A RID: 2186 RVA: 0x0001CE7B File Offset: 0x0001B07B
			public NewMapDialog.NewMapDialogContext.Entry SelectedTerrainListItem
			{
				get
				{
					return this._selectedTerrainListItem;
				}
				set
				{
					this._selectedTerrainListItem = value;
					base.RaisePropertyChanged("SelectedTerrainListItem");
				}
			}

			// Token: 0x170001EE RID: 494
			// (get) Token: 0x0600088B RID: 2187 RVA: 0x0001CE8F File Offset: 0x0001B08F
			// (set) Token: 0x0600088C RID: 2188 RVA: 0x0001CE97 File Offset: 0x0001B097
			public List<NewMapDialog.NewMapDialogContext.Entry> ObjectiveList { get; private set; }

			// Token: 0x170001EF RID: 495
			// (get) Token: 0x0600088D RID: 2189 RVA: 0x0001CEA0 File Offset: 0x0001B0A0
			// (set) Token: 0x0600088E RID: 2190 RVA: 0x0001CEA8 File Offset: 0x0001B0A8
			public List<NewMapDialog.NewMapDialogContext.Entry> TerrainList { get; private set; }

			// Token: 0x04000426 RID: 1062
			private NewMapDialog.NewMapDialogContext.Entry _selectedObjectiveListItem;

			// Token: 0x04000427 RID: 1063
			private NewMapDialog.NewMapDialogContext.Entry _selectedTerrainListItem;

			// Token: 0x020000F3 RID: 243
			public class Entry
			{
				// Token: 0x170001F0 RID: 496
				// (get) Token: 0x0600088F RID: 2191 RVA: 0x0001CEB1 File Offset: 0x0001B0B1
				// (set) Token: 0x06000890 RID: 2192 RVA: 0x0001CEB9 File Offset: 0x0001B0B9
				public string Content { get; set; }

				// Token: 0x170001F1 RID: 497
				// (get) Token: 0x06000891 RID: 2193 RVA: 0x0001CEC2 File Offset: 0x0001B0C2
				// (set) Token: 0x06000892 RID: 2194 RVA: 0x0001CECA File Offset: 0x0001B0CA
				public ulong Data { get; set; }

				// Token: 0x06000893 RID: 2195 RVA: 0x0001CED3 File Offset: 0x0001B0D3
				public override string ToString()
				{
					return this.Content;
				}
			}
		}
	}
}
