using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using IGE.Nomad;
using IGE.ViewModels;
using Ubisoft.ApplicationModel.ContextCommands;

namespace IGE.Views
{
	// Token: 0x0200007E RID: 126
	public partial class PromptInventoryListView : Window
	{
		// Token: 0x06000556 RID: 1366 RVA: 0x000144FC File Offset: 0x000126FC
		public PromptInventoryListView(Inventory.Entry root, bool showFolders = true, string initFolder = "")
		{
			this.InitializeComponent();
			this._context = (PromptInventoryListViewModel)base.DataContext;
			this._context.DisplayName = Localizer.Localize("PROMPT_INVENTORY_TEXT", null);
			this._context.Root = root;
			this._context.ObjectSelector.ShowFolders = showFolders;
			this._context.ObjectSelector.CommandItemDoubleClick = new SimpleCommand
			{
				ExecuteDelegate = new Action<object>(this.ItemDoubleClick)
			};
			if (showFolders)
			{
				if (string.IsNullOrEmpty(initFolder))
				{
					this._context.ObjectSelector.SelectDefaultFolder();
					return;
				}
				this._context.ObjectSelector.SelectFolderByName(initFolder);
			}
		}

		// Token: 0x06000557 RID: 1367 RVA: 0x000145AF File Offset: 0x000127AF
		public PromptInventoryListView()
		{
			throw new Exception();
		}

		// Token: 0x1700011C RID: 284
		// (get) Token: 0x06000558 RID: 1368 RVA: 0x000145BC File Offset: 0x000127BC
		public Inventory.Entry Result
		{
			get
			{
				return this._context.Value;
			}
		}

		// Token: 0x1700011D RID: 285
		// (get) Token: 0x06000559 RID: 1369 RVA: 0x000145CC File Offset: 0x000127CC
		public string SelectedFolder
		{
			get
			{
				string result = string.Empty;
				if (this._context.ObjectSelector.SelectedFolder != null)
				{
					result = this._context.ObjectSelector.SelectedFolder.Text;
				}
				return result;
			}
		}

		// Token: 0x0600055A RID: 1370 RVA: 0x00014608 File Offset: 0x00012808
		private void ButtonOk_Click(object sender, RoutedEventArgs e)
		{
			this.CloseWithSucces();
		}

		// Token: 0x0600055B RID: 1371 RVA: 0x00014610 File Offset: 0x00012810
		private void ButtonCancel_Click(object sender, RoutedEventArgs e)
		{
			base.DialogResult = new bool?(false);
			base.Close();
		}

		// Token: 0x0600055C RID: 1372 RVA: 0x00014624 File Offset: 0x00012824
		private void ItemDoubleClick(object param)
		{
			this.CloseWithSucces();
		}

		// Token: 0x0600055D RID: 1373 RVA: 0x0001462C File Offset: 0x0001282C
		private void CloseWithSucces()
		{
			base.DialogResult = new bool?(true);
			base.Close();
		}

		// Token: 0x04000241 RID: 577
		private readonly PromptInventoryListViewModel _context;
	}
}
