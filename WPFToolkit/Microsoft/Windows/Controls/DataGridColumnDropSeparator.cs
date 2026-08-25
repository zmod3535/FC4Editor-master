using System;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Windows.Controls.Primitives;
using MS.Internal;

namespace Microsoft.Windows.Controls
{
	// Token: 0x0200001A RID: 26
	internal class DataGridColumnDropSeparator : Separator
	{
		// Token: 0x060001A7 RID: 423 RVA: 0x000071D0 File Offset: 0x000053D0
		static DataGridColumnDropSeparator()
		{
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(DataGridColumnDropSeparator), new FrameworkPropertyMetadata(typeof(DataGridColumnDropSeparator)));
			FrameworkElement.WidthProperty.OverrideMetadata(typeof(DataGridColumnDropSeparator), new FrameworkPropertyMetadata(null, new CoerceValueCallback(DataGridColumnDropSeparator.OnCoerceWidth)));
			FrameworkElement.HeightProperty.OverrideMetadata(typeof(DataGridColumnDropSeparator), new FrameworkPropertyMetadata(null, new CoerceValueCallback(DataGridColumnDropSeparator.OnCoerceHeight)));
		}

		// Token: 0x060001A8 RID: 424 RVA: 0x0000724C File Offset: 0x0000544C
		private static object OnCoerceWidth(DependencyObject d, object baseValue)
		{
			double value = (double)baseValue;
			if (DoubleUtil.IsNaN(value))
			{
				return 2.0;
			}
			return baseValue;
		}

		// Token: 0x060001A9 RID: 425 RVA: 0x00007278 File Offset: 0x00005478
		private static object OnCoerceHeight(DependencyObject d, object baseValue)
		{
			double value = (double)baseValue;
			DataGridColumnDropSeparator dataGridColumnDropSeparator = (DataGridColumnDropSeparator)d;
			if (dataGridColumnDropSeparator._referenceHeader != null && DoubleUtil.IsNaN(value))
			{
				return dataGridColumnDropSeparator._referenceHeader.ActualHeight;
			}
			return baseValue;
		}

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x060001AA RID: 426 RVA: 0x000072B5 File Offset: 0x000054B5
		// (set) Token: 0x060001AB RID: 427 RVA: 0x000072BD File Offset: 0x000054BD
		internal DataGridColumnHeader ReferenceHeader
		{
			get
			{
				return this._referenceHeader;
			}
			set
			{
				this._referenceHeader = value;
			}
		}

		// Token: 0x04000071 RID: 113
		private DataGridColumnHeader _referenceHeader;
	}
}
