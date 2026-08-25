using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace Microsoft.Windows.Controls
{
	// Token: 0x02000027 RID: 39
	public class DataGridCheckBoxColumn : DataGridBoundColumn
	{
		// Token: 0x0600022D RID: 557 RVA: 0x00009034 File Offset: 0x00007234
		static DataGridCheckBoxColumn()
		{
			DataGridBoundColumn.ElementStyleProperty.OverrideMetadata(typeof(DataGridCheckBoxColumn), new FrameworkPropertyMetadata(DataGridCheckBoxColumn.DefaultElementStyle));
			DataGridBoundColumn.EditingElementStyleProperty.OverrideMetadata(typeof(DataGridCheckBoxColumn), new FrameworkPropertyMetadata(DataGridCheckBoxColumn.DefaultEditingElementStyle));
		}

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x0600022E RID: 558 RVA: 0x000090B0 File Offset: 0x000072B0
		public static Style DefaultElementStyle
		{
			get
			{
				if (DataGridCheckBoxColumn._defaultElementStyle == null)
				{
					Style style = new Style(typeof(CheckBox));
					style.Setters.Add(new Setter(UIElement.IsHitTestVisibleProperty, false));
					style.Setters.Add(new Setter(UIElement.FocusableProperty, false));
					style.Setters.Add(new Setter(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Center));
					style.Setters.Add(new Setter(FrameworkElement.VerticalAlignmentProperty, VerticalAlignment.Top));
					style.Seal();
					DataGridCheckBoxColumn._defaultElementStyle = style;
				}
				return DataGridCheckBoxColumn._defaultElementStyle;
			}
		}

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x0600022F RID: 559 RVA: 0x00009154 File Offset: 0x00007354
		public static Style DefaultEditingElementStyle
		{
			get
			{
				if (DataGridCheckBoxColumn._defaultEditingElementStyle == null)
				{
					Style style = new Style(typeof(CheckBox));
					style.Setters.Add(new Setter(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Center));
					style.Setters.Add(new Setter(FrameworkElement.VerticalAlignmentProperty, VerticalAlignment.Top));
					style.Seal();
					DataGridCheckBoxColumn._defaultEditingElementStyle = style;
				}
				return DataGridCheckBoxColumn._defaultEditingElementStyle;
			}
		}

		// Token: 0x06000230 RID: 560 RVA: 0x000091BF File Offset: 0x000073BF
		protected override FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
		{
			return this.GenerateCheckBox(false, cell);
		}

		// Token: 0x06000231 RID: 561 RVA: 0x000091C9 File Offset: 0x000073C9
		protected override FrameworkElement GenerateEditingElement(DataGridCell cell, object dataItem)
		{
			return this.GenerateCheckBox(true, cell);
		}

		// Token: 0x06000232 RID: 562 RVA: 0x000091D4 File Offset: 0x000073D4
		private CheckBox GenerateCheckBox(bool isEditing, DataGridCell cell)
		{
			CheckBox checkBox = (cell != null) ? (cell.Content as CheckBox) : null;
			if (checkBox == null)
			{
				checkBox = new CheckBox();
			}
			checkBox.IsThreeState = this.IsThreeState;
			base.ApplyStyle(isEditing, true, checkBox);
			base.ApplyBinding(checkBox, ToggleButton.IsCheckedProperty);
			return checkBox;
		}

		// Token: 0x06000233 RID: 563 RVA: 0x00009220 File Offset: 0x00007420
		protected internal override void RefreshCellContent(FrameworkElement element, string propertyName)
		{
			DataGridCell dataGridCell = element as DataGridCell;
			if (dataGridCell != null && string.Compare(propertyName, "IsThreeState", StringComparison.Ordinal) == 0)
			{
				CheckBox checkBox = dataGridCell.Content as CheckBox;
				if (checkBox != null)
				{
					checkBox.IsThreeState = this.IsThreeState;
					return;
				}
			}
			else
			{
				base.RefreshCellContent(element, propertyName);
			}
		}

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x06000234 RID: 564 RVA: 0x00009269 File Offset: 0x00007469
		// (set) Token: 0x06000235 RID: 565 RVA: 0x0000927B File Offset: 0x0000747B
		public bool IsThreeState
		{
			get
			{
				return (bool)base.GetValue(DataGridCheckBoxColumn.IsThreeStateProperty);
			}
			set
			{
				base.SetValue(DataGridCheckBoxColumn.IsThreeStateProperty, value);
			}
		}

		// Token: 0x06000236 RID: 566 RVA: 0x00009290 File Offset: 0x00007490
		protected override object PrepareCellForEdit(FrameworkElement editingElement, RoutedEventArgs editingEventArgs)
		{
			CheckBox checkBox = editingElement as CheckBox;
			if (checkBox != null)
			{
				checkBox.Focus();
				bool? isChecked = checkBox.IsChecked;
				if ((DataGridCheckBoxColumn.IsMouseLeftButtonDown(editingEventArgs) && DataGridCheckBoxColumn.IsMouseOver(checkBox, editingEventArgs)) || DataGridCheckBoxColumn.IsSpaceKeyDown(editingEventArgs))
				{
					checkBox.IsChecked = new bool?(isChecked != true);
				}
				return isChecked;
			}
			return new bool?(false);
		}

		// Token: 0x06000237 RID: 567 RVA: 0x00009304 File Offset: 0x00007504
		protected override bool CommitCellEdit(FrameworkElement editingElement)
		{
			CheckBox checkBox = editingElement as CheckBox;
			if (checkBox != null)
			{
				DataGridHelper.UpdateSource(checkBox, ToggleButton.IsCheckedProperty);
				return !Validation.GetHasError(checkBox);
			}
			return true;
		}

		// Token: 0x06000238 RID: 568 RVA: 0x00009334 File Offset: 0x00007534
		protected override void CancelCellEdit(FrameworkElement editingElement, object uneditedValue)
		{
			CheckBox checkBox = editingElement as CheckBox;
			if (checkBox != null)
			{
				DataGridHelper.UpdateTarget(checkBox, ToggleButton.IsCheckedProperty);
			}
		}

		// Token: 0x06000239 RID: 569 RVA: 0x00009356 File Offset: 0x00007556
		internal override void OnInput(InputEventArgs e)
		{
			if (DataGridCheckBoxColumn.IsSpaceKeyDown(e))
			{
				base.BeginEdit(e);
			}
		}

		// Token: 0x0600023A RID: 570 RVA: 0x00009368 File Offset: 0x00007568
		private static bool IsMouseLeftButtonDown(RoutedEventArgs e)
		{
			MouseButtonEventArgs mouseButtonEventArgs = e as MouseButtonEventArgs;
			return mouseButtonEventArgs != null && mouseButtonEventArgs.ChangedButton == MouseButton.Left && mouseButtonEventArgs.ButtonState == MouseButtonState.Pressed;
		}

		// Token: 0x0600023B RID: 571 RVA: 0x00009392 File Offset: 0x00007592
		private static bool IsMouseOver(CheckBox checkBox, RoutedEventArgs e)
		{
			return checkBox.InputHitTest(((MouseButtonEventArgs)e).GetPosition(checkBox)) != null;
		}

		// Token: 0x0600023C RID: 572 RVA: 0x000093AC File Offset: 0x000075AC
		private static bool IsSpaceKeyDown(RoutedEventArgs e)
		{
			KeyEventArgs keyEventArgs = e as KeyEventArgs;
			return keyEventArgs != null && (byte)(keyEventArgs.KeyStates & KeyStates.Down) == 1 && keyEventArgs.Key == Key.Space;
		}

		// Token: 0x04000088 RID: 136
		public static readonly DependencyProperty IsThreeStateProperty = ToggleButton.IsThreeStateProperty.AddOwner(typeof(DataGridCheckBoxColumn), new FrameworkPropertyMetadata(false, new PropertyChangedCallback(DataGridColumn.NotifyPropertyChangeForRefreshContent)));

		// Token: 0x04000089 RID: 137
		private static Style _defaultElementStyle;

		// Token: 0x0400008A RID: 138
		private static Style _defaultEditingElementStyle;
	}
}
