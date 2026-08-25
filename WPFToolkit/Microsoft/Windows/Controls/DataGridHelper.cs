using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Windows.Controls.Primitives;
using MS.Internal;

namespace Microsoft.Windows.Controls
{
	// Token: 0x02000037 RID: 55
	internal static class DataGridHelper
	{
		// Token: 0x060002E9 RID: 745 RVA: 0x0000B0B0 File Offset: 0x000092B0
		public static Size SubtractFromSize(Size size, double thickness, bool height)
		{
			if (height)
			{
				return new Size(size.Width, Math.Max(0.0, size.Height - thickness));
			}
			return new Size(Math.Max(0.0, size.Width - thickness), size.Height);
		}

		// Token: 0x060002EA RID: 746 RVA: 0x0000B108 File Offset: 0x00009308
		public static bool IsGridLineVisible(DataGrid dataGrid, bool isHorizontal)
		{
			if (dataGrid != null)
			{
				switch (dataGrid.GridLinesVisibility)
				{
				case DataGridGridLinesVisibility.All:
					return true;
				case DataGridGridLinesVisibility.Horizontal:
					return isHorizontal;
				case DataGridGridLinesVisibility.None:
					return false;
				case DataGridGridLinesVisibility.Vertical:
					return !isHorizontal;
				}
			}
			return false;
		}

		// Token: 0x060002EB RID: 747 RVA: 0x0000B145 File Offset: 0x00009345
		public static bool ShouldNotifyCells(NotificationTarget target)
		{
			return DataGridHelper.TestTarget(target, NotificationTarget.Cells);
		}

		// Token: 0x060002EC RID: 748 RVA: 0x0000B14E File Offset: 0x0000934E
		public static bool ShouldNotifyCellsPresenter(NotificationTarget target)
		{
			return DataGridHelper.TestTarget(target, NotificationTarget.CellsPresenter);
		}

		// Token: 0x060002ED RID: 749 RVA: 0x0000B157 File Offset: 0x00009357
		public static bool ShouldNotifyColumns(NotificationTarget target)
		{
			return DataGridHelper.TestTarget(target, NotificationTarget.Columns);
		}

		// Token: 0x060002EE RID: 750 RVA: 0x0000B160 File Offset: 0x00009360
		public static bool ShouldNotifyColumnHeaders(NotificationTarget target)
		{
			return DataGridHelper.TestTarget(target, NotificationTarget.ColumnHeaders);
		}

		// Token: 0x060002EF RID: 751 RVA: 0x0000B16A File Offset: 0x0000936A
		public static bool ShouldNotifyColumnHeadersPresenter(NotificationTarget target)
		{
			return DataGridHelper.TestTarget(target, NotificationTarget.ColumnHeadersPresenter);
		}

		// Token: 0x060002F0 RID: 752 RVA: 0x0000B174 File Offset: 0x00009374
		public static bool ShouldNotifyColumnCollection(NotificationTarget target)
		{
			return DataGridHelper.TestTarget(target, NotificationTarget.ColumnCollection);
		}

		// Token: 0x060002F1 RID: 753 RVA: 0x0000B17D File Offset: 0x0000937D
		public static bool ShouldNotifyDataGrid(NotificationTarget target)
		{
			return DataGridHelper.TestTarget(target, NotificationTarget.DataGrid);
		}

		// Token: 0x060002F2 RID: 754 RVA: 0x0000B187 File Offset: 0x00009387
		public static bool ShouldNotifyDetailsPresenter(NotificationTarget target)
		{
			return DataGridHelper.TestTarget(target, NotificationTarget.DetailsPresenter);
		}

		// Token: 0x060002F3 RID: 755 RVA: 0x0000B194 File Offset: 0x00009394
		public static bool ShouldRefreshCellContent(NotificationTarget target)
		{
			return DataGridHelper.TestTarget(target, NotificationTarget.RefreshCellContent);
		}

		// Token: 0x060002F4 RID: 756 RVA: 0x0000B1A1 File Offset: 0x000093A1
		public static bool ShouldNotifyRowHeaders(NotificationTarget target)
		{
			return DataGridHelper.TestTarget(target, NotificationTarget.RowHeaders);
		}

		// Token: 0x060002F5 RID: 757 RVA: 0x0000B1AE File Offset: 0x000093AE
		public static bool ShouldNotifyRows(NotificationTarget target)
		{
			return DataGridHelper.TestTarget(target, NotificationTarget.Rows);
		}

		// Token: 0x060002F6 RID: 758 RVA: 0x0000B1BC File Offset: 0x000093BC
		public static bool ShouldNotifyRowSubtree(NotificationTarget target)
		{
			NotificationTarget value = NotificationTarget.Cells | NotificationTarget.CellsPresenter | NotificationTarget.DetailsPresenter | NotificationTarget.RefreshCellContent | NotificationTarget.RowHeaders | NotificationTarget.Rows;
			return DataGridHelper.TestTarget(target, value);
		}

		// Token: 0x060002F7 RID: 759 RVA: 0x0000B1D6 File Offset: 0x000093D6
		private static bool TestTarget(NotificationTarget target, NotificationTarget value)
		{
			return (target & value) != NotificationTarget.None;
		}

		// Token: 0x060002F8 RID: 760 RVA: 0x0000B1E4 File Offset: 0x000093E4
		public static T FindParent<T>(FrameworkElement element) where T : FrameworkElement
		{
			for (FrameworkElement frameworkElement = element.TemplatedParent as FrameworkElement; frameworkElement != null; frameworkElement = (frameworkElement.TemplatedParent as FrameworkElement))
			{
				T t = frameworkElement as T;
				if (t != null)
				{
					return t;
				}
			}
			return default(T);
		}

		// Token: 0x060002F9 RID: 761 RVA: 0x0000B230 File Offset: 0x00009430
		public static T FindVisualParent<T>(UIElement element) where T : UIElement
		{
			for (UIElement uielement = element; uielement != null; uielement = (VisualTreeHelper.GetParent(uielement) as UIElement))
			{
				T t = uielement as T;
				if (t != null)
				{
					return t;
				}
			}
			return default(T);
		}

		// Token: 0x060002FA RID: 762 RVA: 0x0000B270 File Offset: 0x00009470
		public static bool TreeHasFocusAndTabStop(DependencyObject element)
		{
			if (element == null)
			{
				return false;
			}
			UIElement uielement = element as UIElement;
			if (uielement != null)
			{
				if (uielement.Focusable && KeyboardNavigation.GetIsTabStop(uielement))
				{
					return true;
				}
			}
			else
			{
				ContentElement contentElement = element as ContentElement;
				if (contentElement != null && contentElement.Focusable && KeyboardNavigation.GetIsTabStop(contentElement))
				{
					return true;
				}
			}
			int childrenCount = VisualTreeHelper.GetChildrenCount(element);
			for (int i = 0; i < childrenCount; i++)
			{
				DependencyObject child = VisualTreeHelper.GetChild(element, i);
				if (DataGridHelper.TreeHasFocusAndTabStop(child))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060002FB RID: 763 RVA: 0x0000B2E4 File Offset: 0x000094E4
		public static void OnColumnWidthChanged(IProvideDataGridColumn cell, DependencyPropertyChangedEventArgs e)
		{
			UIElement uielement = (UIElement)cell;
			DataGridColumn column = cell.Column;
			bool flag = cell is DataGridColumnHeader;
			if (column != null)
			{
				DataGridLength width = column.Width;
				if (width.IsAuto || (!flag && width.IsSizeToCells) || (flag && width.IsSizeToHeader))
				{
					DataGridLength dataGridLength = (DataGridLength)e.OldValue;
					double num;
					if (dataGridLength.UnitType != width.UnitType)
					{
						double constraintWidth = column.GetConstraintWidth(flag);
						if (!DoubleUtil.AreClose(uielement.DesiredSize.Width, constraintWidth))
						{
							uielement.InvalidateMeasure();
							uielement.Measure(new Size(constraintWidth, double.PositiveInfinity));
						}
						num = uielement.DesiredSize.Width;
					}
					else
					{
						num = dataGridLength.DesiredValue;
					}
					if (DoubleUtil.IsNaN(width.DesiredValue) || DoubleUtil.LessThan(width.DesiredValue, num))
					{
						column.SetWidthInternal(new DataGridLength(width.Value, width.UnitType, num, width.DisplayValue));
					}
				}
			}
		}

		// Token: 0x060002FC RID: 764 RVA: 0x0000B400 File Offset: 0x00009600
		public static Geometry GetFrozenClipForCell(IProvideDataGridColumn cell)
		{
			DataGridCellsPanel parentPanelForCell = DataGridHelper.GetParentPanelForCell(cell);
			if (parentPanelForCell != null)
			{
				return parentPanelForCell.GetFrozenClipForChild((UIElement)cell);
			}
			return null;
		}

		// Token: 0x060002FD RID: 765 RVA: 0x0000B428 File Offset: 0x00009628
		public static DataGridCellsPanel GetParentPanelForCell(IProvideDataGridColumn cell)
		{
			UIElement reference = (UIElement)cell;
			return VisualTreeHelper.GetParent(reference) as DataGridCellsPanel;
		}

		// Token: 0x060002FE RID: 766 RVA: 0x0000B448 File Offset: 0x00009648
		public static double GetParentCellsPanelHorizontalOffset(IProvideDataGridColumn cell)
		{
			DataGridCellsPanel parentPanelForCell = DataGridHelper.GetParentPanelForCell(cell);
			if (parentPanelForCell != null)
			{
				return parentPanelForCell.ComputeCellsPanelHorizontalOffset();
			}
			return 0.0;
		}

		// Token: 0x060002FF RID: 767 RVA: 0x0000B470 File Offset: 0x00009670
		public static bool IsDefaultValue(DependencyObject d, DependencyProperty dp)
		{
			return DependencyPropertyHelper.GetValueSource(d, dp).BaseValueSource == BaseValueSource.Default;
		}

		// Token: 0x06000300 RID: 768 RVA: 0x0000B48F File Offset: 0x0000968F
		public static object GetCoercedTransferPropertyValue(DependencyObject baseObject, object baseValue, DependencyProperty baseProperty, DependencyObject parentObject, DependencyProperty parentProperty)
		{
			return DataGridHelper.GetCoercedTransferPropertyValue(baseObject, baseValue, baseProperty, parentObject, parentProperty, null, null);
		}

		// Token: 0x06000301 RID: 769 RVA: 0x0000B4A0 File Offset: 0x000096A0
		public static object GetCoercedTransferPropertyValue(DependencyObject baseObject, object baseValue, DependencyProperty baseProperty, DependencyObject parentObject, DependencyProperty parentProperty, DependencyObject grandParentObject, DependencyProperty grandParentProperty)
		{
			object result = baseValue;
			if (DataGridHelper.IsPropertyTransferEnabled(baseObject, baseProperty))
			{
				BaseValueSource baseValueSource = DependencyPropertyHelper.GetValueSource(baseObject, baseProperty).BaseValueSource;
				if (parentObject != null)
				{
					ValueSource valueSource = DependencyPropertyHelper.GetValueSource(parentObject, parentProperty);
					if (valueSource.BaseValueSource > baseValueSource)
					{
						result = parentObject.GetValue(parentProperty);
						baseValueSource = valueSource.BaseValueSource;
					}
				}
				if (grandParentObject != null)
				{
					ValueSource valueSource2 = DependencyPropertyHelper.GetValueSource(grandParentObject, grandParentProperty);
					if (valueSource2.BaseValueSource > baseValueSource)
					{
						result = grandParentObject.GetValue(grandParentProperty);
						baseValueSource = valueSource2.BaseValueSource;
					}
				}
			}
			return result;
		}

		// Token: 0x06000302 RID: 770 RVA: 0x0000B51C File Offset: 0x0000971C
		public static void TransferProperty(DependencyObject d, DependencyProperty p)
		{
			Dictionary<DependencyProperty, bool> propertyTransferEnabledMapForObject = DataGridHelper.GetPropertyTransferEnabledMapForObject(d);
			propertyTransferEnabledMapForObject[p] = true;
			d.CoerceValue(p);
			propertyTransferEnabledMapForObject[p] = false;
		}

		// Token: 0x06000303 RID: 771 RVA: 0x0000B548 File Offset: 0x00009748
		private static Dictionary<DependencyProperty, bool> GetPropertyTransferEnabledMapForObject(DependencyObject d)
		{
			Dictionary<DependencyProperty, bool> dictionary = DataGridHelper._propertyTransferEnabledMap[d] as Dictionary<DependencyProperty, bool>;
			if (dictionary == null)
			{
				dictionary = new Dictionary<DependencyProperty, bool>();
				DataGridHelper._propertyTransferEnabledMap.SetWeak(d, dictionary);
			}
			return dictionary;
		}

		// Token: 0x06000304 RID: 772 RVA: 0x0000B57C File Offset: 0x0000977C
		internal static bool IsPropertyTransferEnabled(DependencyObject d, DependencyProperty p)
		{
			Dictionary<DependencyProperty, bool> dictionary = DataGridHelper._propertyTransferEnabledMap[d] as Dictionary<DependencyProperty, bool>;
			bool flag;
			return dictionary != null && dictionary.TryGetValue(p, out flag) && flag;
		}

		// Token: 0x06000305 RID: 773 RVA: 0x0000B5AC File Offset: 0x000097AC
		public static string GetTheme(FrameworkElement element)
		{
			object obj = element.ReadLocalValue(DataGridHelper.ThemeProperty);
			if (obj == DependencyProperty.UnsetValue)
			{
				element.SetResourceReference(DataGridHelper.ThemeProperty, DataGridHelper._themeKey);
			}
			return (string)element.GetValue(DataGridHelper.ThemeProperty);
		}

		// Token: 0x06000306 RID: 774 RVA: 0x0000B5ED File Offset: 0x000097ED
		public static void HookThemeChange(Type type, PropertyChangedCallback propertyChangedCallback)
		{
			DataGridHelper.ThemeProperty.OverrideMetadata(type, new FrameworkPropertyMetadata(string.Empty, propertyChangedCallback));
		}

		// Token: 0x06000307 RID: 775 RVA: 0x0000B608 File Offset: 0x00009808
		internal static bool IsOneWay(BindingBase bindingBase)
		{
			if (bindingBase == null)
			{
				return false;
			}
			Binding binding = bindingBase as Binding;
			if (binding != null)
			{
				return binding.Mode == BindingMode.OneWay;
			}
			MultiBinding multiBinding = bindingBase as MultiBinding;
			if (multiBinding != null)
			{
				return multiBinding.Mode == BindingMode.OneWay;
			}
			PriorityBinding priorityBinding = bindingBase as PriorityBinding;
			if (priorityBinding != null)
			{
				Collection<BindingBase> bindings = priorityBinding.Bindings;
				int count = bindings.Count;
				for (int i = 0; i < count; i++)
				{
					if (DataGridHelper.IsOneWay(bindings[i]))
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06000308 RID: 776 RVA: 0x0000B680 File Offset: 0x00009880
		internal static void EnsureTwoWayIfNotOneWay(BindingBase bindingBase)
		{
			if (bindingBase == null)
			{
				return;
			}
			Binding binding = bindingBase as Binding;
			if (binding != null)
			{
				if (binding.Mode != BindingMode.OneWay)
				{
					if (binding.Mode != BindingMode.TwoWay)
					{
						binding.Mode = BindingMode.TwoWay;
					}
					if (binding.UpdateSourceTrigger != UpdateSourceTrigger.Explicit)
					{
						binding.UpdateSourceTrigger = UpdateSourceTrigger.Explicit;
					}
				}
				return;
			}
			MultiBinding multiBinding = bindingBase as MultiBinding;
			if (multiBinding != null)
			{
				if (multiBinding.Mode != BindingMode.OneWay)
				{
					if (multiBinding.Mode != BindingMode.TwoWay)
					{
						multiBinding.Mode = BindingMode.TwoWay;
					}
					if (multiBinding.UpdateSourceTrigger != UpdateSourceTrigger.Explicit)
					{
						multiBinding.UpdateSourceTrigger = UpdateSourceTrigger.Explicit;
					}
				}
				return;
			}
			PriorityBinding priorityBinding = bindingBase as PriorityBinding;
			if (priorityBinding != null)
			{
				Collection<BindingBase> bindings = priorityBinding.Bindings;
				int count = bindings.Count;
				for (int i = 0; i < count; i++)
				{
					DataGridHelper.EnsureTwoWayIfNotOneWay(bindings[i]);
				}
			}
		}

		// Token: 0x06000309 RID: 777 RVA: 0x0000B72E File Offset: 0x0000992E
		internal static BindingExpression GetBindingExpression(FrameworkElement element, DependencyProperty dp)
		{
			if (element != null)
			{
				return element.GetBindingExpression(dp);
			}
			return null;
		}

		// Token: 0x0600030A RID: 778 RVA: 0x0000B73C File Offset: 0x0000993C
		internal static void UpdateSource(FrameworkElement element, DependencyProperty dp)
		{
			BindingExpression bindingExpression = DataGridHelper.GetBindingExpression(element, dp);
			if (bindingExpression != null)
			{
				bindingExpression.UpdateSource();
			}
		}

		// Token: 0x0600030B RID: 779 RVA: 0x0000B75C File Offset: 0x0000995C
		internal static void UpdateTarget(FrameworkElement element, DependencyProperty dp)
		{
			BindingExpression bindingExpression = DataGridHelper.GetBindingExpression(element, dp);
			if (bindingExpression != null)
			{
				bindingExpression.UpdateTarget();
			}
		}

		// Token: 0x0600030C RID: 780 RVA: 0x0000B77A File Offset: 0x0000997A
		internal static void SyncColumnProperty(DependencyObject column, DependencyObject content, DependencyProperty contentProperty, DependencyProperty columnProperty)
		{
			if (DataGridHelper.IsDefaultValue(column, columnProperty))
			{
				content.ClearValue(contentProperty);
				return;
			}
			content.SetValue(contentProperty, column.GetValue(columnProperty));
		}

		// Token: 0x0600030D RID: 781 RVA: 0x0000B79B File Offset: 0x0000999B
		internal static string GetPathFromBinding(Binding binding)
		{
			if (binding != null)
			{
				if (!string.IsNullOrEmpty(binding.XPath))
				{
					return binding.XPath;
				}
				if (binding.Path != null)
				{
					return binding.Path.Path;
				}
			}
			return null;
		}

		// Token: 0x0600030E RID: 782 RVA: 0x0000B7C9 File Offset: 0x000099C9
		public static bool AreRowHeadersVisible(DataGridHeadersVisibility headersVisibility)
		{
			return (headersVisibility & DataGridHeadersVisibility.Row) == DataGridHeadersVisibility.Row;
		}

		// Token: 0x0600030F RID: 783 RVA: 0x0000B7D1 File Offset: 0x000099D1
		public static double CoerceToMinMax(double value, double minValue, double maxValue)
		{
			value = Math.Max(value, minValue);
			value = Math.Min(value, maxValue);
			return value;
		}

		// Token: 0x06000310 RID: 784 RVA: 0x0000B7E8 File Offset: 0x000099E8
		public static bool HasNonEscapeCharacters(TextCompositionEventArgs textArgs)
		{
			if (textArgs != null)
			{
				string text = textArgs.Text;
				int i = 0;
				int length = text.Length;
				while (i < length)
				{
					if (text[i] != '\u001b')
					{
						return true;
					}
					i++;
				}
			}
			return false;
		}

		// Token: 0x040000D1 RID: 209
		private const char _escapeChar = '\u001b';

		// Token: 0x040000D2 RID: 210
		private static WeakHashtable _propertyTransferEnabledMap = new WeakHashtable();

		// Token: 0x040000D3 RID: 211
		private static readonly DependencyProperty ThemeProperty = DependencyProperty.RegisterAttached("Theme", typeof(string), typeof(DataGridHelper), new FrameworkPropertyMetadata(string.Empty));

		// Token: 0x040000D4 RID: 212
		private static ComponentResourceKey _themeKey = new ComponentResourceKey(typeof(DataGrid), "Theme");
	}
}
