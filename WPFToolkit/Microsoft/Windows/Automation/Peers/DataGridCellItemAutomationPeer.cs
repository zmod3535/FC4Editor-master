using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Data;
using Microsoft.Windows.Controls;
using Microsoft.Windows.Controls.Primitives;

namespace Microsoft.Windows.Automation.Peers
{
	// Token: 0x02000087 RID: 135
	public sealed class DataGridCellItemAutomationPeer : AutomationPeer, ITableItemProvider, IGridItemProvider, IInvokeProvider, IScrollItemProvider, ISelectionItemProvider
	{
		// Token: 0x06000995 RID: 2453 RVA: 0x0002A4FA File Offset: 0x000286FA
		public DataGridCellItemAutomationPeer(object item, DataGridColumn dataGridColumn)
		{
			if (item == null)
			{
				throw new ArgumentNullException("item");
			}
			if (dataGridColumn == null)
			{
				throw new ArgumentNullException("dataGridColumn");
			}
			this._item = item;
			this._column = dataGridColumn;
		}

		// Token: 0x06000996 RID: 2454 RVA: 0x0002A52C File Offset: 0x0002872C
		protected override string GetAcceleratorKeyCore()
		{
			if (this.OwningCellPeer == null)
			{
				return string.Empty;
			}
			return this.OwningCellPeer.GetAcceleratorKey();
		}

		// Token: 0x06000997 RID: 2455 RVA: 0x0002A547 File Offset: 0x00028747
		protected override string GetAccessKeyCore()
		{
			if (this.OwningCellPeer == null)
			{
				return string.Empty;
			}
			return this.OwningCellPeer.GetAccessKey();
		}

		// Token: 0x06000998 RID: 2456 RVA: 0x0002A562 File Offset: 0x00028762
		protected override AutomationControlType GetAutomationControlTypeCore()
		{
			return AutomationControlType.Custom;
		}

		// Token: 0x06000999 RID: 2457 RVA: 0x0002A566 File Offset: 0x00028766
		protected override string GetAutomationIdCore()
		{
			if (this.OwningCellPeer == null)
			{
				return string.Empty;
			}
			return this.OwningCellPeer.GetAutomationId();
		}

		// Token: 0x0600099A RID: 2458 RVA: 0x0002A584 File Offset: 0x00028784
		protected override Rect GetBoundingRectangleCore()
		{
			if (this.OwningCellPeer == null)
			{
				return default(Rect);
			}
			return this.OwningCellPeer.GetBoundingRectangle();
		}

		// Token: 0x0600099B RID: 2459 RVA: 0x0002A5B0 File Offset: 0x000287B0
		protected override List<AutomationPeer> GetChildrenCore()
		{
			AutomationPeer owningCellPeer = this.OwningCellPeer;
			if (owningCellPeer != null)
			{
				owningCellPeer.ResetChildrenCache();
				return owningCellPeer.GetChildren();
			}
			return null;
		}

		// Token: 0x0600099C RID: 2460 RVA: 0x0002A5D5 File Offset: 0x000287D5
		protected override string GetClassNameCore()
		{
			if (this.OwningCellPeer == null)
			{
				return string.Empty;
			}
			return this.OwningCellPeer.GetClassName();
		}

		// Token: 0x0600099D RID: 2461 RVA: 0x0002A5F0 File Offset: 0x000287F0
		protected override Point GetClickablePointCore()
		{
			if (this.OwningCellPeer == null)
			{
				return new Point(double.NaN, double.NaN);
			}
			return this.OwningCellPeer.GetClickablePoint();
		}

		// Token: 0x0600099E RID: 2462 RVA: 0x0002A61D File Offset: 0x0002881D
		protected override string GetHelpTextCore()
		{
			if (this.OwningCellPeer == null)
			{
				return string.Empty;
			}
			return this.OwningCellPeer.GetHelpText();
		}

		// Token: 0x0600099F RID: 2463 RVA: 0x0002A638 File Offset: 0x00028838
		protected override string GetItemStatusCore()
		{
			if (this.OwningCellPeer == null)
			{
				return string.Empty;
			}
			return this.OwningCellPeer.GetItemStatus();
		}

		// Token: 0x060009A0 RID: 2464 RVA: 0x0002A653 File Offset: 0x00028853
		protected override string GetItemTypeCore()
		{
			if (this.OwningCellPeer == null)
			{
				return string.Empty;
			}
			return this.OwningCellPeer.GetItemType();
		}

		// Token: 0x060009A1 RID: 2465 RVA: 0x0002A66E File Offset: 0x0002886E
		protected override AutomationPeer GetLabeledByCore()
		{
			if (this.OwningCellPeer == null)
			{
				return null;
			}
			return this.OwningCellPeer.GetLabeledBy();
		}

		// Token: 0x060009A2 RID: 2466 RVA: 0x0002A685 File Offset: 0x00028885
		protected override string GetLocalizedControlTypeCore()
		{
			if (this.OwningCellPeer == null)
			{
				return base.GetLocalizedControlTypeCore();
			}
			return this.OwningCellPeer.GetLocalizedControlType();
		}

		// Token: 0x060009A3 RID: 2467 RVA: 0x0002A6A4 File Offset: 0x000288A4
		protected override string GetNameCore()
		{
			return SR.Get(SRID.DataGridCellItemAutomationPeer_NameCoreFormat, new object[]
			{
				this._item,
				this._column.DisplayIndex
			});
		}

		// Token: 0x060009A4 RID: 2468 RVA: 0x0002A6DF File Offset: 0x000288DF
		protected override AutomationOrientation GetOrientationCore()
		{
			if (this.OwningCellPeer == null)
			{
				return AutomationOrientation.None;
			}
			return this.OwningCellPeer.GetOrientation();
		}

		// Token: 0x060009A5 RID: 2469 RVA: 0x0002A6F8 File Offset: 0x000288F8
		public override object GetPattern(PatternInterface patternInterface)
		{
			if (patternInterface <= PatternInterface.ScrollItem)
			{
				if (patternInterface != PatternInterface.Invoke)
				{
					if (patternInterface != PatternInterface.ScrollItem)
					{
						goto IL_48;
					}
				}
				else
				{
					if (!this.OwningDataGrid.IsReadOnly && !this._column.IsReadOnly)
					{
						return this;
					}
					goto IL_48;
				}
			}
			else if (patternInterface != PatternInterface.GridItem)
			{
				if (patternInterface != PatternInterface.SelectionItem)
				{
					if (patternInterface != PatternInterface.TableItem)
					{
						goto IL_48;
					}
				}
				else
				{
					if (this.IsCellSelectionUnit)
					{
						return this;
					}
					goto IL_48;
				}
			}
			return this;
			IL_48:
			return null;
		}

		// Token: 0x060009A6 RID: 2470 RVA: 0x0002A74E File Offset: 0x0002894E
		protected override bool HasKeyboardFocusCore()
		{
			return this.OwningCellPeer != null && this.OwningCellPeer.HasKeyboardFocus();
		}

		// Token: 0x060009A7 RID: 2471 RVA: 0x0002A765 File Offset: 0x00028965
		protected override bool IsContentElementCore()
		{
			return this.OwningCellPeer == null || this.OwningCellPeer.IsContentElement();
		}

		// Token: 0x060009A8 RID: 2472 RVA: 0x0002A77C File Offset: 0x0002897C
		protected override bool IsControlElementCore()
		{
			return this.OwningCellPeer == null || this.OwningCellPeer.IsControlElement();
		}

		// Token: 0x060009A9 RID: 2473 RVA: 0x0002A793 File Offset: 0x00028993
		protected override bool IsEnabledCore()
		{
			return this.OwningCellPeer == null || this.OwningCellPeer.IsEnabled();
		}

		// Token: 0x060009AA RID: 2474 RVA: 0x0002A7AA File Offset: 0x000289AA
		protected override bool IsKeyboardFocusableCore()
		{
			return this.OwningCellPeer != null && this.OwningCellPeer.IsKeyboardFocusable();
		}

		// Token: 0x060009AB RID: 2475 RVA: 0x0002A7C1 File Offset: 0x000289C1
		protected override bool IsOffscreenCore()
		{
			return this.OwningCellPeer == null || this.OwningCellPeer.IsOffscreen();
		}

		// Token: 0x060009AC RID: 2476 RVA: 0x0002A7D8 File Offset: 0x000289D8
		protected override bool IsPasswordCore()
		{
			return this.OwningCellPeer != null && this.OwningCellPeer.IsPassword();
		}

		// Token: 0x060009AD RID: 2477 RVA: 0x0002A7EF File Offset: 0x000289EF
		protected override bool IsRequiredForFormCore()
		{
			return this.OwningCellPeer != null && this.OwningCellPeer.IsRequiredForForm();
		}

		// Token: 0x060009AE RID: 2478 RVA: 0x0002A806 File Offset: 0x00028A06
		protected override void SetFocusCore()
		{
			if (this.OwningCellPeer != null && this.OwningCellPeer.Owner.Focusable)
			{
				this.OwningCellPeer.SetFocus();
			}
		}

		// Token: 0x1700023E RID: 574
		// (get) Token: 0x060009AF RID: 2479 RVA: 0x0002A82D File Offset: 0x00028A2D
		int IGridItemProvider.Column
		{
			get
			{
				return this.OwningDataGrid.Columns.IndexOf(this._column);
			}
		}

		// Token: 0x1700023F RID: 575
		// (get) Token: 0x060009B0 RID: 2480 RVA: 0x0002A845 File Offset: 0x00028A45
		int IGridItemProvider.ColumnSpan
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17000240 RID: 576
		// (get) Token: 0x060009B1 RID: 2481 RVA: 0x0002A848 File Offset: 0x00028A48
		IRawElementProviderSimple IGridItemProvider.ContainingGrid
		{
			get
			{
				return this.ContainingGrid;
			}
		}

		// Token: 0x17000241 RID: 577
		// (get) Token: 0x060009B2 RID: 2482 RVA: 0x0002A850 File Offset: 0x00028A50
		int IGridItemProvider.Row
		{
			get
			{
				return this.OwningDataGrid.Items.IndexOf(this._item);
			}
		}

		// Token: 0x17000242 RID: 578
		// (get) Token: 0x060009B3 RID: 2483 RVA: 0x0002A868 File Offset: 0x00028A68
		int IGridItemProvider.RowSpan
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x060009B4 RID: 2484 RVA: 0x0002A86C File Offset: 0x00028A6C
		IRawElementProviderSimple[] ITableItemProvider.GetColumnHeaderItems()
		{
			if (this.OwningDataGrid != null && (this.OwningDataGrid.HeadersVisibility & DataGridHeadersVisibility.Column) == DataGridHeadersVisibility.Column && this.OwningDataGrid.ColumnHeadersPresenter != null)
			{
				DataGridColumnHeadersPresenter columnHeadersPresenter = this.OwningDataGrid.ColumnHeadersPresenter;
				DataGridColumnHeader dataGridColumnHeader = columnHeadersPresenter.ItemContainerGenerator.ContainerFromIndex(this.OwningDataGrid.Columns.IndexOf(this._column)) as DataGridColumnHeader;
				if (dataGridColumnHeader != null)
				{
					AutomationPeer automationPeer = UIElementAutomationPeer.CreatePeerForElement(dataGridColumnHeader);
					if (automationPeer != null)
					{
						return new List<IRawElementProviderSimple>(1)
						{
							base.ProviderFromPeer(automationPeer)
						}.ToArray();
					}
				}
			}
			return null;
		}

		// Token: 0x060009B5 RID: 2485 RVA: 0x0002A8FC File Offset: 0x00028AFC
		IRawElementProviderSimple[] ITableItemProvider.GetRowHeaderItems()
		{
			if (this.OwningDataGrid != null && (this.OwningDataGrid.HeadersVisibility & DataGridHeadersVisibility.Row) == DataGridHeadersVisibility.Row)
			{
				DataGridAutomationPeer dataGridAutomationPeer = UIElementAutomationPeer.CreatePeerForElement(this.OwningDataGrid) as DataGridAutomationPeer;
				DataGridItemAutomationPeer orCreateItemPeer = dataGridAutomationPeer.GetOrCreateItemPeer(this._item);
				if (orCreateItemPeer != null)
				{
					AutomationPeer rowHeaderAutomationPeer = orCreateItemPeer.RowHeaderAutomationPeer;
					if (rowHeaderAutomationPeer != null)
					{
						return new List<IRawElementProviderSimple>(1)
						{
							base.ProviderFromPeer(rowHeaderAutomationPeer)
						}.ToArray();
					}
				}
			}
			return null;
		}

		// Token: 0x060009B6 RID: 2486 RVA: 0x0002A968 File Offset: 0x00028B68
		void IInvokeProvider.Invoke()
		{
			if (this.OwningDataGrid.IsReadOnly || this._column.IsReadOnly)
			{
				return;
			}
			this.EnsureEnabled();
			bool flag = false;
			if (this.OwningCell == null)
			{
				this.OwningDataGrid.ScrollIntoView(this._item, this._column);
			}
			DataGridCell owningCell = this.OwningCell;
			if (owningCell != null)
			{
				if (!owningCell.IsEditing)
				{
					if (!owningCell.IsKeyboardFocusWithin)
					{
						owningCell.Focus();
					}
					this.OwningDataGrid.HandleSelectionForCellInput(owningCell, false, false, false);
					flag = this.OwningDataGrid.BeginEdit();
				}
				else
				{
					flag = true;
				}
			}
			if (!flag && !this.IsNewItemPlaceholder)
			{
				throw new InvalidOperationException(SR.Get(SRID.DataGrid_AutomationInvokeFailed));
			}
		}

		// Token: 0x060009B7 RID: 2487 RVA: 0x0002AA12 File Offset: 0x00028C12
		void IScrollItemProvider.ScrollIntoView()
		{
			this.OwningDataGrid.ScrollIntoView(this._item, this._column);
		}

		// Token: 0x17000243 RID: 579
		// (get) Token: 0x060009B8 RID: 2488 RVA: 0x0002AA2B File Offset: 0x00028C2B
		bool ISelectionItemProvider.IsSelected
		{
			get
			{
				return this.OwningDataGrid.SelectedCellsInternal.Contains(new DataGridCellInfo(this._item, this._column));
			}
		}

		// Token: 0x17000244 RID: 580
		// (get) Token: 0x060009B9 RID: 2489 RVA: 0x0002AA4E File Offset: 0x00028C4E
		IRawElementProviderSimple ISelectionItemProvider.SelectionContainer
		{
			get
			{
				return this.ContainingGrid;
			}
		}

		// Token: 0x060009BA RID: 2490 RVA: 0x0002AA58 File Offset: 0x00028C58
		void ISelectionItemProvider.AddToSelection()
		{
			if (!this.IsCellSelectionUnit)
			{
				throw new InvalidOperationException(SR.Get(SRID.DataGrid_CannotSelectCell));
			}
			DataGridCellInfo cell = new DataGridCellInfo(this._item, this._column);
			if (this.OwningDataGrid.SelectedCellsInternal.Contains(cell))
			{
				return;
			}
			this.EnsureEnabled();
			if (this.OwningDataGrid.SelectionMode == DataGridSelectionMode.Single && this.OwningDataGrid.SelectedCells.Count > 0)
			{
				throw new InvalidOperationException();
			}
			this.OwningDataGrid.SelectedCellsInternal.Add(cell);
		}

		// Token: 0x060009BB RID: 2491 RVA: 0x0002AAE4 File Offset: 0x00028CE4
		void ISelectionItemProvider.RemoveFromSelection()
		{
			if (!this.IsCellSelectionUnit)
			{
				throw new InvalidOperationException(SR.Get(SRID.DataGrid_CannotSelectCell));
			}
			this.EnsureEnabled();
			DataGridCellInfo cell = new DataGridCellInfo(this._item, this._column);
			if (this.OwningDataGrid.SelectedCellsInternal.Contains(cell))
			{
				this.OwningDataGrid.SelectedCellsInternal.Remove(cell);
			}
		}

		// Token: 0x060009BC RID: 2492 RVA: 0x0002AB48 File Offset: 0x00028D48
		void ISelectionItemProvider.Select()
		{
			if (!this.IsCellSelectionUnit)
			{
				throw new InvalidOperationException(SR.Get(SRID.DataGrid_CannotSelectCell));
			}
			this.EnsureEnabled();
			DataGridCellInfo currentCellInfo = new DataGridCellInfo(this._item, this._column);
			this.OwningDataGrid.SelectOnlyThisCell(currentCellInfo);
		}

		// Token: 0x060009BD RID: 2493 RVA: 0x0002AB92 File Offset: 0x00028D92
		private void EnsureEnabled()
		{
			if (!this.OwningDataGrid.IsEnabled)
			{
				throw new ElementNotEnabledException();
			}
		}

		// Token: 0x17000245 RID: 581
		// (get) Token: 0x060009BE RID: 2494 RVA: 0x0002ABA7 File Offset: 0x00028DA7
		private bool IsCellSelectionUnit
		{
			get
			{
				return this.OwningDataGrid != null && (this.OwningDataGrid.SelectionUnit == DataGridSelectionUnit.Cell || this.OwningDataGrid.SelectionUnit == DataGridSelectionUnit.CellOrRowHeader);
			}
		}

		// Token: 0x17000246 RID: 582
		// (get) Token: 0x060009BF RID: 2495 RVA: 0x0002ABD0 File Offset: 0x00028DD0
		private bool IsNewItemPlaceholder
		{
			get
			{
				return this._item == CollectionView.NewItemPlaceholder || this._item == DataGrid.NewItemPlaceholder;
			}
		}

		// Token: 0x17000247 RID: 583
		// (get) Token: 0x060009C0 RID: 2496 RVA: 0x0002ABEE File Offset: 0x00028DEE
		private DataGrid OwningDataGrid
		{
			get
			{
				return this._column.DataGridOwner;
			}
		}

		// Token: 0x17000248 RID: 584
		// (get) Token: 0x060009C1 RID: 2497 RVA: 0x0002ABFB File Offset: 0x00028DFB
		private DataGridCell OwningCell
		{
			get
			{
				return this.OwningDataGrid.TryFindCell(this._item, this._column);
			}
		}

		// Token: 0x17000249 RID: 585
		// (get) Token: 0x060009C2 RID: 2498 RVA: 0x0002AC14 File Offset: 0x00028E14
		internal DataGridCellAutomationPeer OwningCellPeer
		{
			get
			{
				DataGridCellAutomationPeer dataGridCellAutomationPeer = null;
				DataGridCell owningCell = this.OwningCell;
				if (owningCell != null)
				{
					dataGridCellAutomationPeer = (UIElementAutomationPeer.CreatePeerForElement(owningCell) as DataGridCellAutomationPeer);
					dataGridCellAutomationPeer.EventsSource = this;
				}
				return dataGridCellAutomationPeer;
			}
		}

		// Token: 0x1700024A RID: 586
		// (get) Token: 0x060009C3 RID: 2499 RVA: 0x0002AC44 File Offset: 0x00028E44
		private IRawElementProviderSimple ContainingGrid
		{
			get
			{
				AutomationPeer automationPeer = UIElementAutomationPeer.CreatePeerForElement(this.OwningDataGrid);
				if (automationPeer != null)
				{
					return base.ProviderFromPeer(automationPeer);
				}
				return null;
			}
		}

		// Token: 0x040002E9 RID: 745
		private object _item;

		// Token: 0x040002EA RID: 746
		private DataGridColumn _column;
	}
}
