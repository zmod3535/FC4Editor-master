using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using IGE.Nomad;
using Ubisoft;

namespace IGE.Views
{
	// Token: 0x0200037A RID: 890
	public class EditMapDialog : Window, IComponentConnector
	{
		// Token: 0x1700025F RID: 607
		// (get) Token: 0x060013E4 RID: 5092 RVA: 0x00029CF7 File Offset: 0x00027EF7
		// (set) Token: 0x060013E5 RID: 5093 RVA: 0x00029D10 File Offset: 0x00027F10
		public ulong SelectedObjective
		{
			get
			{
				return ((EditMapDialog.EditMapContext)base.DataContext).SelectedObjectiveListItem.Data;
			}
			set
			{
				EditMapDialog.EditMapContext editMapContext = base.DataContext as EditMapDialog.EditMapContext;
				foreach (EditMapDialog.EditMapContext.Entry entry in editMapContext.ObjectiveList)
				{
					if (entry.Data == value)
					{
						editMapContext.SelectedObjectiveListItem = entry;
						break;
					}
				}
			}
		}

		// Token: 0x060013E6 RID: 5094 RVA: 0x00029D7C File Offset: 0x00027F7C
		public EditMapDialog(ulong currentObjID)
		{
			EditMapDialog.EditMapContext dataContext = new EditMapDialog.EditMapContext(currentObjID);
			base.DataContext = dataContext;
			this.InitializeComponent();
		}

		// Token: 0x060013E7 RID: 5095 RVA: 0x00029DA3 File Offset: 0x00027FA3
		private void OkButton_Click(object sender, RoutedEventArgs e)
		{
			if (this.SelectedObjective != 0UL)
			{
				base.DialogResult = new bool?(true);
			}
		}

		// Token: 0x060013E8 RID: 5096 RVA: 0x00029DBB File Offset: 0x00027FBB
		private void CancelButton_Click(object sender, RoutedEventArgs e)
		{
			base.DialogResult = new bool?(false);
		}

		// Token: 0x060013E9 RID: 5097 RVA: 0x00029DCC File Offset: 0x00027FCC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/IGE.WPF.Core64;component/views/windows/editmapdialog.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060013EA RID: 5098 RVA: 0x00029DFC File Offset: 0x00027FFC
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				this.ObjectiveComboBox = (ComboBox)target;
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

		// Token: 0x04000754 RID: 1876
		internal ComboBox ObjectiveComboBox;

		// Token: 0x04000755 RID: 1877
		internal Button OkButton;

		// Token: 0x04000756 RID: 1878
		internal Button CancelButton;

		// Token: 0x04000757 RID: 1879
		private bool _contentLoaded;

		// Token: 0x0200037B RID: 891
		private class EditMapContext : ViewModel
		{
			// Token: 0x060013EB RID: 5099 RVA: 0x00029E80 File Offset: 0x00028080
			public EditMapContext(ulong currentObjID)
			{
				this.DialogTitle = Localizer.Localize("DIALOG_EDIT_MAP", null);
				this.WarningText = Localizer.Localize("DIALOG_EDIT_MAP_QUERY", null);
				this.ObjectiveLabel = Localizer.LocalizeCommon("PARAM_MAP_OBJECTIVE");
				this.ObjectiveList = new List<EditMapDialog.EditMapContext.Entry>();
				foreach (ObjectiveType objectiveType in GameModeManager.ObjectiveTypes.Values)
				{
					if (objectiveType.Id != currentObjID)
					{
						EditMapDialog.EditMapContext.Entry entry = new EditMapDialog.EditMapContext.Entry();
						entry.Content = string.Format("{0}", objectiveType.Name);
						entry.Data = objectiveType.Id;
						this.ObjectiveList.Add(entry);
					}
				}
				if (this.ObjectiveList.Count > 0)
				{
					this.SelectedObjectiveListItem = this.ObjectiveList[0];
				}
			}

			// Token: 0x17000260 RID: 608
			// (get) Token: 0x060013EC RID: 5100 RVA: 0x00029F70 File Offset: 0x00028170
			// (set) Token: 0x060013ED RID: 5101 RVA: 0x00029F78 File Offset: 0x00028178
			public string DialogTitle { get; private set; }

			// Token: 0x17000261 RID: 609
			// (get) Token: 0x060013EE RID: 5102 RVA: 0x00029F81 File Offset: 0x00028181
			// (set) Token: 0x060013EF RID: 5103 RVA: 0x00029F89 File Offset: 0x00028189
			public string WarningText { get; private set; }

			// Token: 0x17000262 RID: 610
			// (get) Token: 0x060013F0 RID: 5104 RVA: 0x00029F92 File Offset: 0x00028192
			// (set) Token: 0x060013F1 RID: 5105 RVA: 0x00029F9A File Offset: 0x0002819A
			public string ObjectiveLabel { get; private set; }

			// Token: 0x17000263 RID: 611
			// (get) Token: 0x060013F2 RID: 5106 RVA: 0x00029FA3 File Offset: 0x000281A3
			// (set) Token: 0x060013F3 RID: 5107 RVA: 0x00029FAB File Offset: 0x000281AB
			public EditMapDialog.EditMapContext.Entry SelectedObjectiveListItem
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

			// Token: 0x17000264 RID: 612
			// (get) Token: 0x060013F4 RID: 5108 RVA: 0x00029FBF File Offset: 0x000281BF
			// (set) Token: 0x060013F5 RID: 5109 RVA: 0x00029FC7 File Offset: 0x000281C7
			public List<EditMapDialog.EditMapContext.Entry> ObjectiveList { get; private set; }

			// Token: 0x04000758 RID: 1880
			private EditMapDialog.EditMapContext.Entry _selectedObjectiveListItem;

			// Token: 0x0200037C RID: 892
			public class Entry
			{
				// Token: 0x17000265 RID: 613
				// (get) Token: 0x060013F6 RID: 5110 RVA: 0x00029FD0 File Offset: 0x000281D0
				// (set) Token: 0x060013F7 RID: 5111 RVA: 0x00029FD8 File Offset: 0x000281D8
				public string Content { get; set; }

				// Token: 0x17000266 RID: 614
				// (get) Token: 0x060013F8 RID: 5112 RVA: 0x00029FE1 File Offset: 0x000281E1
				// (set) Token: 0x060013F9 RID: 5113 RVA: 0x00029FE9 File Offset: 0x000281E9
				public ulong Data { get; set; }

				// Token: 0x060013FA RID: 5114 RVA: 0x00029FF2 File Offset: 0x000281F2
				public override string ToString()
				{
					return this.Content;
				}
			}
		}
	}
}
