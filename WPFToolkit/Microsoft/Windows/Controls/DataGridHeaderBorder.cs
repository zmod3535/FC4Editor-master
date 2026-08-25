using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Microsoft.Windows.Controls
{
	// Token: 0x0200005D RID: 93
	public class DataGridHeaderBorder : Border
	{
		// Token: 0x06000737 RID: 1847 RVA: 0x0001E308 File Offset: 0x0001C508
		static DataGridHeaderBorder()
		{
			DataGridHelper.HookThemeChange(typeof(DataGridHeaderBorder), new PropertyChangedCallback(DataGridHeaderBorder.OnThemeChange));
			UIElement.SnapsToDevicePixelsProperty.OverrideMetadata(typeof(DataGridHeaderBorder), new FrameworkPropertyMetadata(true));
		}

		// Token: 0x170001BB RID: 443
		// (get) Token: 0x06000738 RID: 1848 RVA: 0x0001E4F6 File Offset: 0x0001C6F6
		// (set) Token: 0x06000739 RID: 1849 RVA: 0x0001E508 File Offset: 0x0001C708
		public bool IsHovered
		{
			get
			{
				return (bool)base.GetValue(DataGridHeaderBorder.IsHoveredProperty);
			}
			set
			{
				base.SetValue(DataGridHeaderBorder.IsHoveredProperty, value);
			}
		}

		// Token: 0x170001BC RID: 444
		// (get) Token: 0x0600073A RID: 1850 RVA: 0x0001E51B File Offset: 0x0001C71B
		// (set) Token: 0x0600073B RID: 1851 RVA: 0x0001E52D File Offset: 0x0001C72D
		public bool IsPressed
		{
			get
			{
				return (bool)base.GetValue(DataGridHeaderBorder.IsPressedProperty);
			}
			set
			{
				base.SetValue(DataGridHeaderBorder.IsPressedProperty, value);
			}
		}

		// Token: 0x170001BD RID: 445
		// (get) Token: 0x0600073C RID: 1852 RVA: 0x0001E540 File Offset: 0x0001C740
		// (set) Token: 0x0600073D RID: 1853 RVA: 0x0001E552 File Offset: 0x0001C752
		public bool IsClickable
		{
			get
			{
				return (bool)base.GetValue(DataGridHeaderBorder.IsClickableProperty);
			}
			set
			{
				base.SetValue(DataGridHeaderBorder.IsClickableProperty, value);
			}
		}

		// Token: 0x170001BE RID: 446
		// (get) Token: 0x0600073E RID: 1854 RVA: 0x0001E565 File Offset: 0x0001C765
		// (set) Token: 0x0600073F RID: 1855 RVA: 0x0001E577 File Offset: 0x0001C777
		public ListSortDirection? SortDirection
		{
			get
			{
				return (ListSortDirection?)base.GetValue(DataGridHeaderBorder.SortDirectionProperty);
			}
			set
			{
				base.SetValue(DataGridHeaderBorder.SortDirectionProperty, value);
			}
		}

		// Token: 0x170001BF RID: 447
		// (get) Token: 0x06000740 RID: 1856 RVA: 0x0001E58A File Offset: 0x0001C78A
		// (set) Token: 0x06000741 RID: 1857 RVA: 0x0001E59C File Offset: 0x0001C79C
		public bool IsSelected
		{
			get
			{
				return (bool)base.GetValue(DataGridHeaderBorder.IsSelectedProperty);
			}
			set
			{
				base.SetValue(DataGridHeaderBorder.IsSelectedProperty, value);
			}
		}

		// Token: 0x170001C0 RID: 448
		// (get) Token: 0x06000742 RID: 1858 RVA: 0x0001E5AF File Offset: 0x0001C7AF
		// (set) Token: 0x06000743 RID: 1859 RVA: 0x0001E5C1 File Offset: 0x0001C7C1
		public Orientation Orientation
		{
			get
			{
				return (Orientation)base.GetValue(DataGridHeaderBorder.OrientationProperty);
			}
			set
			{
				base.SetValue(DataGridHeaderBorder.OrientationProperty, value);
			}
		}

		// Token: 0x170001C1 RID: 449
		// (get) Token: 0x06000744 RID: 1860 RVA: 0x0001E5D4 File Offset: 0x0001C7D4
		private bool UsingBorderImplementation
		{
			get
			{
				return base.Background != null || base.BorderBrush != null;
			}
		}

		// Token: 0x170001C2 RID: 450
		// (get) Token: 0x06000745 RID: 1861 RVA: 0x0001E5EC File Offset: 0x0001C7EC
		// (set) Token: 0x06000746 RID: 1862 RVA: 0x0001E5FE File Offset: 0x0001C7FE
		public Brush SeparatorBrush
		{
			get
			{
				return (Brush)base.GetValue(DataGridHeaderBorder.SeparatorBrushProperty);
			}
			set
			{
				base.SetValue(DataGridHeaderBorder.SeparatorBrushProperty, value);
			}
		}

		// Token: 0x170001C3 RID: 451
		// (get) Token: 0x06000747 RID: 1863 RVA: 0x0001E60C File Offset: 0x0001C80C
		// (set) Token: 0x06000748 RID: 1864 RVA: 0x0001E61E File Offset: 0x0001C81E
		public Visibility SeparatorVisibility
		{
			get
			{
				return (Visibility)base.GetValue(DataGridHeaderBorder.SeparatorVisibilityProperty);
			}
			set
			{
				base.SetValue(DataGridHeaderBorder.SeparatorVisibilityProperty, value);
			}
		}

		// Token: 0x170001C4 RID: 452
		// (get) Token: 0x06000749 RID: 1865 RVA: 0x0001E634 File Offset: 0x0001C834
		private string Theme
		{
			get
			{
				string text = DataGridHelper.GetTheme(this);
				if (string.IsNullOrEmpty(text))
				{
					text = "Classic";
				}
				return text;
			}
		}

		// Token: 0x0600074A RID: 1866 RVA: 0x0001E658 File Offset: 0x0001C858
		private static void OnThemeChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			DataGridHeaderBorder.ReleaseCache();
			DataGridHeaderBorder dataGridHeaderBorder = (DataGridHeaderBorder)d;
			dataGridHeaderBorder.InvalidateMeasure();
			dataGridHeaderBorder.InvalidateArrange();
			dataGridHeaderBorder.InvalidateVisual();
		}

		// Token: 0x0600074B RID: 1867 RVA: 0x0001E684 File Offset: 0x0001C884
		protected override Size MeasureOverride(Size constraint)
		{
			if (this.UsingBorderImplementation)
			{
				return base.MeasureOverride(constraint);
			}
			UIElement child = this.Child;
			if (child != null)
			{
				Thickness thickness = base.Padding;
				if (thickness.Equals(default(Thickness)))
				{
					thickness = this.DefaultPadding;
				}
				double num = constraint.Width;
				double num2 = constraint.Height;
				if (!double.IsInfinity(num))
				{
					num = Math.Max(0.0, num - thickness.Left - thickness.Right);
				}
				if (!double.IsInfinity(num2))
				{
					num2 = Math.Max(0.0, num2 - thickness.Top - thickness.Bottom);
				}
				child.Measure(new Size(num, num2));
				Size desiredSize = child.DesiredSize;
				return new Size(desiredSize.Width + thickness.Left + thickness.Right, desiredSize.Height + thickness.Top + thickness.Bottom);
			}
			return default(Size);
		}

		// Token: 0x0600074C RID: 1868 RVA: 0x0001E784 File Offset: 0x0001C984
		protected override Size ArrangeOverride(Size arrangeSize)
		{
			if (this.UsingBorderImplementation)
			{
				return base.ArrangeOverride(arrangeSize);
			}
			UIElement child = this.Child;
			if (child != null)
			{
				Thickness thickness = base.Padding;
				if (thickness.Equals(default(Thickness)))
				{
					thickness = this.DefaultPadding;
				}
				double width = Math.Max(0.0, arrangeSize.Width - thickness.Left - thickness.Right);
				double height = Math.Max(0.0, arrangeSize.Height - thickness.Top - thickness.Bottom);
				child.Arrange(new Rect(thickness.Left, thickness.Top, width, height));
			}
			return arrangeSize;
		}

		// Token: 0x0600074D RID: 1869 RVA: 0x0001E838 File Offset: 0x0001CA38
		protected override void OnRender(DrawingContext dc)
		{
			if (this.UsingBorderImplementation)
			{
				base.OnRender(dc);
				return;
			}
			string theme;
			if ((theme = this.Theme) != null)
			{
				if (theme == "Classic")
				{
					this.RenderClassic(dc);
					return;
				}
				if (theme == "Luna.NormalColor")
				{
					this.RenderLuna(dc, DataGridHeaderBorder.Luna.NormalColor);
					return;
				}
				if (theme == "Luna.HomeStead")
				{
					this.RenderLuna(dc, DataGridHeaderBorder.Luna.HomeStead);
					return;
				}
				if (theme == "Luna.Metallic")
				{
					this.RenderLuna(dc, DataGridHeaderBorder.Luna.Metallic);
					return;
				}
				if (theme == "Royale.NormalColor")
				{
					this.RenderLuna(dc, DataGridHeaderBorder.Luna.Metallic);
					return;
				}
				if (!(theme == "Aero.NormalColor"))
				{
					return;
				}
				this.RenderAeroNormalColor(dc);
			}
		}

		// Token: 0x170001C5 RID: 453
		// (get) Token: 0x0600074E RID: 1870 RVA: 0x0001E8E4 File Offset: 0x0001CAE4
		private Thickness DefaultPadding
		{
			get
			{
				Thickness result = new Thickness(3.0);
				if (this.Orientation == Orientation.Vertical)
				{
					if (this.Theme == "Aero.NormalColor")
					{
						result = new Thickness(5.0, 4.0, 5.0, 4.0);
					}
					else
					{
						result.Right = 15.0;
					}
				}
				if (this.IsPressed && this.IsClickable)
				{
					result.Left += 1.0;
					result.Top += 1.0;
					result.Right -= 1.0;
					result.Bottom -= 1.0;
				}
				return result;
			}
		}

		// Token: 0x0600074F RID: 1871 RVA: 0x0001E9C6 File Offset: 0x0001CBC6
		private static double Max0(double d)
		{
			return Math.Max(0.0, d);
		}

		// Token: 0x06000750 RID: 1872 RVA: 0x0001E9D8 File Offset: 0x0001CBD8
		private void RenderAeroNormalColor(DrawingContext dc)
		{
			Size renderSize = base.RenderSize;
			bool flag = this.Orientation == Orientation.Horizontal;
			bool flag2 = this.IsClickable && base.IsEnabled;
			bool flag3 = flag2 && this.IsHovered;
			bool flag4 = flag2 && this.IsPressed;
			ListSortDirection? sortDirection = this.SortDirection;
			bool flag5 = sortDirection != null;
			bool isSelected = this.IsSelected;
			bool flag6 = !flag3 && !flag4 && !flag5 && !isSelected;
			DataGridHeaderBorder.EnsureCache(19);
			if (flag)
			{
				Matrix trans = default(Matrix);
				trans.RotateAt(-90.0, 0.0, 0.0);
				Matrix trans2 = default(Matrix);
				trans2.Translate(0.0, renderSize.Height);
				MatrixTransform matrixTransform = new MatrixTransform(trans * trans2);
				matrixTransform.Freeze();
				dc.PushTransform(matrixTransform);
				double width = renderSize.Width;
				renderSize.Width = renderSize.Height;
				renderSize.Height = width;
			}
			if (flag6)
			{
				LinearGradientBrush linearGradientBrush = (LinearGradientBrush)DataGridHeaderBorder.GetCachedFreezable(0);
				if (linearGradientBrush == null)
				{
					linearGradientBrush = new LinearGradientBrush();
					linearGradientBrush.StartPoint = default(Point);
					linearGradientBrush.EndPoint = new Point(0.0, 1.0);
					linearGradientBrush.GradientStops.Add(new GradientStop(Color.FromArgb(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue), 0.0));
					linearGradientBrush.GradientStops.Add(new GradientStop(Color.FromArgb(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue), 0.4));
					linearGradientBrush.GradientStops.Add(new GradientStop(Color.FromArgb(byte.MaxValue, 252, 252, 253), 0.4));
					linearGradientBrush.GradientStops.Add(new GradientStop(Color.FromArgb(byte.MaxValue, 251, 252, 252), 1.0));
					linearGradientBrush.Freeze();
					DataGridHeaderBorder.CacheFreezable(linearGradientBrush, 0);
				}
				dc.DrawRectangle(linearGradientBrush, null, new Rect(0.0, 0.0, renderSize.Width, renderSize.Height));
			}
			DataGridHeaderBorder.AeroFreezables index = DataGridHeaderBorder.AeroFreezables.NormalBackground;
			if (flag4)
			{
				index = DataGridHeaderBorder.AeroFreezables.PressedBackground;
			}
			else if (flag3)
			{
				index = DataGridHeaderBorder.AeroFreezables.HoveredBackground;
			}
			else if (flag5 || isSelected)
			{
				index = DataGridHeaderBorder.AeroFreezables.SortedBackground;
			}
			LinearGradientBrush linearGradientBrush2 = (LinearGradientBrush)DataGridHeaderBorder.GetCachedFreezable((int)index);
			if (linearGradientBrush2 == null)
			{
				linearGradientBrush2 = new LinearGradientBrush();
				linearGradientBrush2.StartPoint = default(Point);
				linearGradientBrush2.EndPoint = new Point(0.0, 1.0);
				switch (index)
				{
				case DataGridHeaderBorder.AeroFreezables.NormalBackground:
					linearGradientBrush2.GradientStops.Add(new GradientStop(Color.FromArgb(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue), 0.0));
					linearGradientBrush2.GradientStops.Add(new GradientStop(Color.FromArgb(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue), 0.4));
					linearGradientBrush2.GradientStops.Add(new GradientStop(Color.FromArgb(byte.MaxValue, 247, 248, 250), 0.4));
					linearGradientBrush2.GradientStops.Add(new GradientStop(Color.FromArgb(byte.MaxValue, 241, 242, 244), 1.0));
					break;
				case DataGridHeaderBorder.AeroFreezables.PressedBackground:
					linearGradientBrush2.GradientStops.Add(new GradientStop(Color.FromArgb(byte.MaxValue, 188, 228, 249), 0.0));
					linearGradientBrush2.GradientStops.Add(new GradientStop(Color.FromArgb(byte.MaxValue, 188, 228, 249), 0.4));
					linearGradientBrush2.GradientStops.Add(new GradientStop(Color.FromArgb(byte.MaxValue, 141, 214, 247), 0.4));
					linearGradientBrush2.GradientStops.Add(new GradientStop(Color.FromArgb(byte.MaxValue, 138, 209, 245), 1.0));
					break;
				case DataGridHeaderBorder.AeroFreezables.HoveredBackground:
					linearGradientBrush2.GradientStops.Add(new GradientStop(Color.FromArgb(byte.MaxValue, 227, 247, byte.MaxValue), 0.0));
					linearGradientBrush2.GradientStops.Add(new GradientStop(Color.FromArgb(byte.MaxValue, 227, 247, byte.MaxValue), 0.4));
					linearGradientBrush2.GradientStops.Add(new GradientStop(Color.FromArgb(byte.MaxValue, 189, 237, byte.MaxValue), 0.4));
					linearGradientBrush2.GradientStops.Add(new GradientStop(Color.FromArgb(byte.MaxValue, 183, 231, 251), 1.0));
					break;
				case DataGridHeaderBorder.AeroFreezables.SortedBackground:
					linearGradientBrush2.GradientStops.Add(new GradientStop(Color.FromArgb(byte.MaxValue, 242, 249, 252), 0.0));
					linearGradientBrush2.GradientStops.Add(new GradientStop(Color.FromArgb(byte.MaxValue, 242, 249, 252), 0.4));
					linearGradientBrush2.GradientStops.Add(new GradientStop(Color.FromArgb(byte.MaxValue, 225, 241, 249), 0.4));
					linearGradientBrush2.GradientStops.Add(new GradientStop(Color.FromArgb(byte.MaxValue, 216, 236, 246), 1.0));
					break;
				}
				linearGradientBrush2.Freeze();
				DataGridHeaderBorder.CacheFreezable(linearGradientBrush2, (int)index);
			}
			dc.DrawRectangle(linearGradientBrush2, null, new Rect(0.0, 0.0, renderSize.Width, renderSize.Height));
			if (renderSize.Width >= 2.0)
			{
				DataGridHeaderBorder.AeroFreezables aeroFreezables = DataGridHeaderBorder.AeroFreezables.NormalSides;
				if (flag4)
				{
					aeroFreezables = DataGridHeaderBorder.AeroFreezables.PressedSides;
				}
				else if (flag3)
				{
					aeroFreezables = DataGridHeaderBorder.AeroFreezables.HoveredSides;
				}
				else if (flag5 || isSelected)
				{
					aeroFreezables = DataGridHeaderBorder.AeroFreezables.SortedSides;
				}
				if (this.SeparatorVisibility == Visibility.Visible)
				{
					Brush brush;
					if (this.SeparatorBrush != null)
					{
						brush = this.SeparatorBrush;
					}
					else
					{
						brush = (Brush)DataGridHeaderBorder.GetCachedFreezable((int)aeroFreezables);
						if (brush == null)
						{
							LinearGradientBrush linearGradientBrush3 = null;
							if (aeroFreezables != DataGridHeaderBorder.AeroFreezables.SortedSides)
							{
								linearGradientBrush3 = new LinearGradientBrush();
								linearGradientBrush3.StartPoint = default(Point);
								linearGradientBrush3.EndPoint = new Point(0.0, 1.0);
								brush = linearGradientBrush3;
							}
							switch (aeroFreezables)
							{
							case DataGridHeaderBorder.AeroFreezables.NormalSides:
								linearGradientBrush3.GradientStops.Add(new GradientStop(Color.FromArgb(byte.MaxValue, 242, 242, 242), 0.0));
								linearGradientBrush3.GradientStops.Add(new GradientStop(Color.FromArgb(byte.MaxValue, 239, 239, 239), 0.4));
								linearGradientBrush3.GradientStops.Add(new GradientStop(Color.FromArgb(byte.MaxValue, 231, 232, 234), 0.4));
								linearGradientBrush3.GradientStops.Add(new GradientStop(Color.FromArgb(byte.MaxValue, 222, 223, 225), 1.0));
								break;
							case DataGridHeaderBorder.AeroFreezables.PressedSides:
								linearGradientBrush3.GradientStops.Add(new GradientStop(Color.FromArgb(byte.MaxValue, 122, 158, 177), 0.0));
								linearGradientBrush3.GradientStops.Add(new GradientStop(Color.FromArgb(byte.MaxValue, 122, 158, 177), 0.4));
								linearGradientBrush3.GradientStops.Add(new GradientStop(Color.FromArgb(byte.MaxValue, 80, 145, 175), 0.4));
								linearGradientBrush3.GradientStops.Add(new GradientStop(Color.FromArgb(byte.MaxValue, 77, 141, 173), 1.0));
								break;
							case DataGridHeaderBorder.AeroFreezables.HoveredSides:
								linearGradientBrush3.GradientStops.Add(new GradientStop(Color.FromArgb(byte.MaxValue, 136, 203, 235), 0.0));
								linearGradientBrush3.GradientStops.Add(new GradientStop(Color.FromArgb(byte.MaxValue, 136, 203, 235), 0.4));
								linearGradientBrush3.GradientStops.Add(new GradientStop(Color.FromArgb(byte.MaxValue, 105, 187, 227), 0.4));
								linearGradientBrush3.GradientStops.Add(new GradientStop(Color.FromArgb(byte.MaxValue, 105, 187, 227), 1.0));
								break;
							case DataGridHeaderBorder.AeroFreezables.SortedSides:
								brush = new SolidColorBrush(Color.FromArgb(byte.MaxValue, 150, 217, 249));
								break;
							}
							brush.Freeze();
							DataGridHeaderBorder.CacheFreezable(brush, (int)aeroFreezables);
						}
					}
					dc.DrawRectangle(brush, null, new Rect(0.0, 0.0, 1.0, DataGridHeaderBorder.Max0(renderSize.Height - 0.95)));
					dc.DrawRectangle(brush, null, new Rect(renderSize.Width - 1.0, 0.0, 1.0, DataGridHeaderBorder.Max0(renderSize.Height - 0.95)));
				}
			}
			if (flag4 && renderSize.Width >= 4.0 && renderSize.Height >= 4.0)
			{
				LinearGradientBrush linearGradientBrush4 = (LinearGradientBrush)DataGridHeaderBorder.GetCachedFreezable(5);
				if (linearGradientBrush4 == null)
				{
					linearGradientBrush4 = new LinearGradientBrush();
					linearGradientBrush4.StartPoint = default(Point);
					linearGradientBrush4.EndPoint = new Point(0.0, 1.0);
					linearGradientBrush4.GradientStops.Add(new GradientStop(Color.FromArgb(byte.MaxValue, 134, 163, 178), 0.0));
					linearGradientBrush4.GradientStops.Add(new GradientStop(Color.FromArgb(byte.MaxValue, 134, 163, 178), 0.1));
					linearGradientBrush4.GradientStops.Add(new GradientStop(Color.FromArgb(byte.MaxValue, 170, 206, 225), 0.9));
					linearGradientBrush4.GradientStops.Add(new GradientStop(Color.FromArgb(byte.MaxValue, 170, 206, 225), 1.0));
					linearGradientBrush4.Freeze();
					DataGridHeaderBorder.CacheFreezable(linearGradientBrush4, 5);
				}
				dc.DrawRectangle(linearGradientBrush4, null, new Rect(0.0, 0.0, renderSize.Width, 2.0));
				LinearGradientBrush linearGradientBrush5 = (LinearGradientBrush)DataGridHeaderBorder.GetCachedFreezable(10);
				if (linearGradientBrush5 == null)
				{
					linearGradientBrush5 = new LinearGradientBrush();
					linearGradientBrush5.StartPoint = default(Point);
					linearGradientBrush5.EndPoint = new Point(0.0, 1.0);
					linearGradientBrush5.GradientStops.Add(new GradientStop(Color.FromArgb(byte.MaxValue, 162, 203, 224), 0.0));
					linearGradientBrush5.GradientStops.Add(new GradientStop(Color.FromArgb(byte.MaxValue, 162, 203, 224), 0.4));
					linearGradientBrush5.GradientStops.Add(new GradientStop(Color.FromArgb(byte.MaxValue, 114, 188, 223), 0.4));
					linearGradientBrush5.GradientStops.Add(new GradientStop(Color.FromArgb(byte.MaxValue, 110, 184, 220), 1.0));
					linearGradientBrush5.Freeze();
					DataGridHeaderBorder.CacheFreezable(linearGradientBrush5, 10);
				}
				dc.DrawRectangle(linearGradientBrush5, null, new Rect(1.0, 0.0, 1.0, renderSize.Height - 0.95));
				dc.DrawRectangle(linearGradientBrush5, null, new Rect(renderSize.Width - 2.0, 0.0, 1.0, renderSize.Height - 0.95));
			}
			if (renderSize.Height >= 2.0)
			{
				DataGridHeaderBorder.AeroFreezables index2 = DataGridHeaderBorder.AeroFreezables.NormalBottom;
				if (flag4)
				{
					index2 = DataGridHeaderBorder.AeroFreezables.PressedOrHoveredBottom;
				}
				else if (flag3)
				{
					index2 = DataGridHeaderBorder.AeroFreezables.PressedOrHoveredBottom;
				}
				else if (flag5 || isSelected)
				{
					index2 = DataGridHeaderBorder.AeroFreezables.SortedBottom;
				}
				SolidColorBrush solidColorBrush = (SolidColorBrush)DataGridHeaderBorder.GetCachedFreezable((int)index2);
				if (solidColorBrush == null)
				{
					switch (index2)
					{
					case DataGridHeaderBorder.AeroFreezables.NormalBottom:
						solidColorBrush = new SolidColorBrush(Color.FromArgb(byte.MaxValue, 213, 213, 213));
						break;
					case DataGridHeaderBorder.AeroFreezables.PressedOrHoveredBottom:
						solidColorBrush = new SolidColorBrush(Color.FromArgb(byte.MaxValue, 147, 201, 227));
						break;
					case DataGridHeaderBorder.AeroFreezables.SortedBottom:
						solidColorBrush = new SolidColorBrush(Color.FromArgb(byte.MaxValue, 150, 217, 249));
						break;
					}
					solidColorBrush.Freeze();
					DataGridHeaderBorder.CacheFreezable(solidColorBrush, (int)index2);
				}
				dc.DrawRectangle(solidColorBrush, null, new Rect(0.0, renderSize.Height - 1.0, renderSize.Width, 1.0));
			}
			if (flag5 && renderSize.Width > 14.0 && renderSize.Height > 10.0)
			{
				TranslateTransform translateTransform = new TranslateTransform((renderSize.Width - 8.0) * 0.5, 1.0);
				translateTransform.Freeze();
				dc.PushTransform(translateTransform);
				bool flag7 = sortDirection == ListSortDirection.Ascending;
				PathGeometry pathGeometry = (PathGeometry)DataGridHeaderBorder.GetCachedFreezable(flag7 ? 17 : 18);
				if (pathGeometry == null)
				{
					pathGeometry = new PathGeometry();
					PathFigure pathFigure = new PathFigure();
					if (flag7)
					{
						pathFigure.StartPoint = new Point(0.0, 4.0);
						LineSegment lineSegment = new LineSegment(new Point(4.0, 0.0), false);
						lineSegment.Freeze();
						pathFigure.Segments.Add(lineSegment);
						lineSegment = new LineSegment(new Point(8.0, 4.0), false);
						lineSegment.Freeze();
						pathFigure.Segments.Add(lineSegment);
					}
					else
					{
						pathFigure.StartPoint = new Point(0.0, 0.0);
						LineSegment lineSegment2 = new LineSegment(new Point(8.0, 0.0), false);
						lineSegment2.Freeze();
						pathFigure.Segments.Add(lineSegment2);
						lineSegment2 = new LineSegment(new Point(4.0, 4.0), false);
						lineSegment2.Freeze();
						pathFigure.Segments.Add(lineSegment2);
					}
					pathFigure.IsClosed = true;
					pathFigure.Freeze();
					pathGeometry.Figures.Add(pathFigure);
					pathGeometry.Freeze();
					DataGridHeaderBorder.CacheFreezable(pathGeometry, flag7 ? 17 : 18);
				}
				LinearGradientBrush linearGradientBrush6 = (LinearGradientBrush)DataGridHeaderBorder.GetCachedFreezable(14);
				if (linearGradientBrush6 == null)
				{
					linearGradientBrush6 = new LinearGradientBrush();
					linearGradientBrush6.StartPoint = default(Point);
					linearGradientBrush6.EndPoint = new Point(1.0, 1.0);
					linearGradientBrush6.GradientStops.Add(new GradientStop(Color.FromArgb(byte.MaxValue, 60, 94, 114), 0.0));
					linearGradientBrush6.GradientStops.Add(new GradientStop(Color.FromArgb(byte.MaxValue, 60, 94, 114), 0.1));
					linearGradientBrush6.GradientStops.Add(new GradientStop(Color.FromArgb(byte.MaxValue, 195, 228, 245), 1.0));
					linearGradientBrush6.Freeze();
					DataGridHeaderBorder.CacheFreezable(linearGradientBrush6, 14);
				}
				dc.DrawGeometry(linearGradientBrush6, null, pathGeometry);
				LinearGradientBrush linearGradientBrush7 = (LinearGradientBrush)DataGridHeaderBorder.GetCachedFreezable(15);
				if (linearGradientBrush7 == null)
				{
					linearGradientBrush7 = new LinearGradientBrush();
					linearGradientBrush7.StartPoint = default(Point);
					linearGradientBrush7.EndPoint = new Point(1.0, 1.0);
					linearGradientBrush7.GradientStops.Add(new GradientStop(Color.FromArgb(byte.MaxValue, 97, 150, 182), 0.0));
					linearGradientBrush7.GradientStops.Add(new GradientStop(Color.FromArgb(byte.MaxValue, 97, 150, 182), 0.1));
					linearGradientBrush7.GradientStops.Add(new GradientStop(Color.FromArgb(byte.MaxValue, 202, 230, 245), 1.0));
					linearGradientBrush7.Freeze();
					DataGridHeaderBorder.CacheFreezable(linearGradientBrush7, 15);
				}
				ScaleTransform scaleTransform = (ScaleTransform)DataGridHeaderBorder.GetCachedFreezable(16);
				if (scaleTransform == null)
				{
					scaleTransform = new ScaleTransform(0.75, 0.75, 3.5, 4.0);
					scaleTransform.Freeze();
					DataGridHeaderBorder.CacheFreezable(scaleTransform, 16);
				}
				dc.PushTransform(scaleTransform);
				dc.DrawGeometry(linearGradientBrush7, null, pathGeometry);
				dc.Pop();
				dc.Pop();
			}
			if (flag)
			{
				dc.Pop();
			}
		}

		// Token: 0x06000751 RID: 1873 RVA: 0x0001FCB0 File Offset: 0x0001DEB0
		private void RenderLuna(DrawingContext dc, DataGridHeaderBorder.Luna colorVariant)
		{
			Size renderSize = base.RenderSize;
			bool flag = this.Orientation == Orientation.Horizontal;
			bool flag2 = this.IsClickable && base.IsEnabled;
			bool flag3 = flag2 && this.IsHovered;
			bool flag4 = flag2 && this.IsPressed;
			ListSortDirection? sortDirection = this.SortDirection;
			bool flag5 = sortDirection != null;
			bool isSelected = this.IsSelected;
			DataGridHeaderBorder.EnsureCache(12);
			if (flag)
			{
				Matrix trans = default(Matrix);
				trans.RotateAt(-90.0, 0.0, 0.0);
				Matrix trans2 = default(Matrix);
				trans2.Translate(0.0, renderSize.Height);
				MatrixTransform matrixTransform = new MatrixTransform(trans * trans2);
				matrixTransform.Freeze();
				dc.PushTransform(matrixTransform);
				double width = renderSize.Width;
				renderSize.Width = renderSize.Height;
				renderSize.Height = width;
			}
			DataGridHeaderBorder.LunaFreezables index = flag4 ? DataGridHeaderBorder.LunaFreezables.PressedBackground : (flag3 ? DataGridHeaderBorder.LunaFreezables.HoveredBackground : DataGridHeaderBorder.LunaFreezables.NormalBackground);
			LinearGradientBrush linearGradientBrush = (LinearGradientBrush)DataGridHeaderBorder.GetCachedFreezable((int)index);
			if (linearGradientBrush == null)
			{
				linearGradientBrush = new LinearGradientBrush();
				linearGradientBrush.StartPoint = default(Point);
				linearGradientBrush.EndPoint = new Point(0.0, 1.0);
				if (flag4)
				{
					if (colorVariant == DataGridHeaderBorder.Luna.Metallic)
					{
						linearGradientBrush.GradientStops.Add(new GradientStop(Color.FromArgb(byte.MaxValue, 185, 185, 200), 0.0));
						linearGradientBrush.GradientStops.Add(new GradientStop(Color.FromArgb(byte.MaxValue, 236, 236, 243), 0.1));
						linearGradientBrush.GradientStops.Add(new GradientStop(Color.FromArgb(byte.MaxValue, 236, 236, 243), 1.0));
					}
					else
					{
						linearGradientBrush.GradientStops.Add(new GradientStop(Color.FromArgb(byte.MaxValue, 193, 194, 184), 0.0));
						linearGradientBrush.GradientStops.Add(new GradientStop(Color.FromArgb(byte.MaxValue, 222, 223, 216), 0.1));
						linearGradientBrush.GradientStops.Add(new GradientStop(Color.FromArgb(byte.MaxValue, 222, 223, 216), 1.0));
					}
				}
				else if (flag3 || isSelected)
				{
					if (colorVariant == DataGridHeaderBorder.Luna.Metallic)
					{
						linearGradientBrush.GradientStops.Add(new GradientStop(Color.FromArgb(byte.MaxValue, 254, 254, 254), 0.0));
						linearGradientBrush.GradientStops.Add(new GradientStop(Color.FromArgb(byte.MaxValue, 254, 254, 254), 0.85));
						linearGradientBrush.GradientStops.Add(new GradientStop(Color.FromArgb(byte.MaxValue, 189, 190, 206), 1.0));
					}
					else
					{
						linearGradientBrush.GradientStops.Add(new GradientStop(Color.FromArgb(byte.MaxValue, 250, 249, 244), 0.0));
						linearGradientBrush.GradientStops.Add(new GradientStop(Color.FromArgb(byte.MaxValue, 250, 249, 244), 0.85));
						linearGradientBrush.GradientStops.Add(new GradientStop(Color.FromArgb(byte.MaxValue, 236, 233, 216), 1.0));
					}
				}
				else if (colorVariant == DataGridHeaderBorder.Luna.Metallic)
				{
					linearGradientBrush.GradientStops.Add(new GradientStop(Color.FromArgb(byte.MaxValue, 249, 250, 253), 0.0));
					linearGradientBrush.GradientStops.Add(new GradientStop(Color.FromArgb(byte.MaxValue, 249, 250, 253), 0.85));
					linearGradientBrush.GradientStops.Add(new GradientStop(Color.FromArgb(byte.MaxValue, 189, 190, 206), 1.0));
				}
				else
				{
					linearGradientBrush.GradientStops.Add(new GradientStop(Color.FromArgb(byte.MaxValue, 235, 234, 219), 0.0));
					linearGradientBrush.GradientStops.Add(new GradientStop(Color.FromArgb(byte.MaxValue, 235, 234, 219), 0.85));
					linearGradientBrush.GradientStops.Add(new GradientStop(Color.FromArgb(byte.MaxValue, 203, 199, 184), 1.0));
				}
				linearGradientBrush.Freeze();
				DataGridHeaderBorder.CacheFreezable(linearGradientBrush, (int)index);
			}
			dc.DrawRectangle(linearGradientBrush, null, new Rect(0.0, 0.0, renderSize.Width, renderSize.Height));
			if (flag3 && !flag4 && renderSize.Width >= 6.0 && renderSize.Height >= 4.0)
			{
				TranslateTransform translateTransform = new TranslateTransform(0.0, renderSize.Height - 3.0);
				translateTransform.Freeze();
				dc.PushTransform(translateTransform);
				PathGeometry pathGeometry = new PathGeometry();
				PathFigure pathFigure = new PathFigure();
				pathFigure.StartPoint = new Point(0.5, 0.5);
				LineSegment lineSegment = new LineSegment(new Point(renderSize.Width - 0.5, 0.5), true);
				lineSegment.Freeze();
				pathFigure.Segments.Add(lineSegment);
				ArcSegment arcSegment = new ArcSegment(new Point(renderSize.Width - 2.5, 2.5), new Size(2.0, 2.0), 90.0, false, SweepDirection.Clockwise, true);
				arcSegment.Freeze();
				pathFigure.Segments.Add(arcSegment);
				lineSegment = new LineSegment(new Point(2.5, 2.5), true);
				lineSegment.Freeze();
				pathFigure.Segments.Add(lineSegment);
				arcSegment = new ArcSegment(new Point(0.5, 0.5), new Size(2.0, 2.0), 90.0, false, SweepDirection.Clockwise, true);
				arcSegment.Freeze();
				pathFigure.Segments.Add(arcSegment);
				pathFigure.IsClosed = true;
				pathFigure.Freeze();
				pathGeometry.Figures.Add(pathFigure);
				pathGeometry.Freeze();
				Pen pen = (Pen)DataGridHeaderBorder.GetCachedFreezable(7);
				if (pen == null)
				{
					SolidColorBrush solidColorBrush = new SolidColorBrush((colorVariant == DataGridHeaderBorder.Luna.HomeStead) ? Color.FromArgb(byte.MaxValue, 207, 114, 37) : Color.FromArgb(byte.MaxValue, 248, 169, 0));
					solidColorBrush.Freeze();
					pen = new Pen(solidColorBrush, 1.0);
					pen.Freeze();
					DataGridHeaderBorder.CacheFreezable(pen, 7);
				}
				LinearGradientBrush linearGradientBrush2 = (LinearGradientBrush)DataGridHeaderBorder.GetCachedFreezable(8);
				if (linearGradientBrush2 == null)
				{
					linearGradientBrush2 = new LinearGradientBrush();
					linearGradientBrush2.StartPoint = default(Point);
					linearGradientBrush2.EndPoint = new Point(1.0, 0.0);
					if (colorVariant == DataGridHeaderBorder.Luna.HomeStead)
					{
						linearGradientBrush2.GradientStops.Add(new GradientStop(Color.FromArgb(byte.MaxValue, 227, 145, 79), 0.0));
						linearGradientBrush2.GradientStops.Add(new GradientStop(Color.FromArgb(byte.MaxValue, 227, 145, 79), 1.0));
					}
					else
					{
						linearGradientBrush2.GradientStops.Add(new GradientStop(Color.FromArgb(byte.MaxValue, 252, 224, 166), 0.0));
						linearGradientBrush2.GradientStops.Add(new GradientStop(Color.FromArgb(byte.MaxValue, 246, 196, 86), 0.1));
						linearGradientBrush2.GradientStops.Add(new GradientStop(Color.FromArgb(byte.MaxValue, 246, 196, 86), 0.9));
						linearGradientBrush2.GradientStops.Add(new GradientStop(Color.FromArgb(byte.MaxValue, 223, 151, 0), 1.0));
					}
					linearGradientBrush2.Freeze();
					DataGridHeaderBorder.CacheFreezable(linearGradientBrush2, 8);
				}
				dc.DrawGeometry(linearGradientBrush2, pen, pathGeometry);
				dc.Pop();
			}
			if (flag4 && renderSize.Width >= 2.0 && renderSize.Height >= 2.0)
			{
				SolidColorBrush solidColorBrush2 = (SolidColorBrush)DataGridHeaderBorder.GetCachedFreezable(5);
				if (solidColorBrush2 == null)
				{
					solidColorBrush2 = new SolidColorBrush((colorVariant == DataGridHeaderBorder.Luna.Metallic) ? Color.FromArgb(byte.MaxValue, 128, 128, 153) : Color.FromArgb(byte.MaxValue, 165, 165, 151));
					solidColorBrush2.Freeze();
					DataGridHeaderBorder.CacheFreezable(solidColorBrush2, 5);
				}
				dc.DrawRectangle(solidColorBrush2, null, new Rect(0.0, 0.0, 1.0, renderSize.Height));
				dc.DrawRectangle(solidColorBrush2, null, new Rect(0.0, DataGridHeaderBorder.Max0(renderSize.Height - 1.0), renderSize.Width, 1.0));
			}
			if (!flag4 && !flag3 && renderSize.Width >= 4.0 && this.SeparatorVisibility == Visibility.Visible)
			{
				Brush brush;
				if (this.SeparatorBrush != null)
				{
					brush = this.SeparatorBrush;
				}
				else
				{
					LinearGradientBrush linearGradientBrush3 = (LinearGradientBrush)DataGridHeaderBorder.GetCachedFreezable(flag ? 3 : 4);
					if (linearGradientBrush3 == null)
					{
						linearGradientBrush3 = new LinearGradientBrush();
						linearGradientBrush3.StartPoint = default(Point);
						linearGradientBrush3.EndPoint = new Point(1.0, 0.0);
						Color color = Color.FromArgb(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
						Color color2 = Color.FromArgb(byte.MaxValue, 199, 197, 178);
						if (flag)
						{
							linearGradientBrush3.GradientStops.Add(new GradientStop(color, 0.0));
							linearGradientBrush3.GradientStops.Add(new GradientStop(color, 0.25));
							linearGradientBrush3.GradientStops.Add(new GradientStop(color2, 0.75));
							linearGradientBrush3.GradientStops.Add(new GradientStop(color2, 1.0));
						}
						else
						{
							linearGradientBrush3.GradientStops.Add(new GradientStop(color2, 0.0));
							linearGradientBrush3.GradientStops.Add(new GradientStop(color2, 0.25));
							linearGradientBrush3.GradientStops.Add(new GradientStop(color, 0.75));
							linearGradientBrush3.GradientStops.Add(new GradientStop(color, 1.0));
						}
						linearGradientBrush3.Freeze();
						DataGridHeaderBorder.CacheFreezable(linearGradientBrush3, flag ? 3 : 4);
					}
					brush = linearGradientBrush3;
				}
				dc.DrawRectangle(brush, null, new Rect(flag ? 0.0 : DataGridHeaderBorder.Max0(renderSize.Width - 2.0), 4.0, 2.0, DataGridHeaderBorder.Max0(renderSize.Height - 8.0)));
			}
			if (flag5 && renderSize.Width > 14.0 && renderSize.Height > 10.0)
			{
				TranslateTransform translateTransform2 = new TranslateTransform(renderSize.Width - 15.0, (renderSize.Height - 5.0) * 0.5);
				translateTransform2.Freeze();
				dc.PushTransform(translateTransform2);
				bool flag6 = sortDirection == ListSortDirection.Ascending;
				PathGeometry pathGeometry2 = (PathGeometry)DataGridHeaderBorder.GetCachedFreezable(flag6 ? 10 : 11);
				if (pathGeometry2 == null)
				{
					pathGeometry2 = new PathGeometry();
					PathFigure pathFigure2 = new PathFigure();
					if (flag6)
					{
						pathFigure2.StartPoint = new Point(0.0, 5.0);
						LineSegment lineSegment2 = new LineSegment(new Point(5.0, 0.0), false);
						lineSegment2.Freeze();
						pathFigure2.Segments.Add(lineSegment2);
						lineSegment2 = new LineSegment(new Point(10.0, 5.0), false);
						lineSegment2.Freeze();
						pathFigure2.Segments.Add(lineSegment2);
					}
					else
					{
						pathFigure2.StartPoint = new Point(0.0, 0.0);
						LineSegment lineSegment3 = new LineSegment(new Point(10.0, 0.0), false);
						lineSegment3.Freeze();
						pathFigure2.Segments.Add(lineSegment3);
						lineSegment3 = new LineSegment(new Point(5.0, 5.0), false);
						lineSegment3.Freeze();
						pathFigure2.Segments.Add(lineSegment3);
					}
					pathFigure2.IsClosed = true;
					pathFigure2.Freeze();
					pathGeometry2.Figures.Add(pathFigure2);
					pathGeometry2.Freeze();
					DataGridHeaderBorder.CacheFreezable(pathGeometry2, flag6 ? 10 : 11);
				}
				SolidColorBrush solidColorBrush3 = (SolidColorBrush)DataGridHeaderBorder.GetCachedFreezable(9);
				if (solidColorBrush3 == null)
				{
					solidColorBrush3 = new SolidColorBrush(Color.FromArgb(byte.MaxValue, 172, 168, 153));
					solidColorBrush3.Freeze();
					DataGridHeaderBorder.CacheFreezable(solidColorBrush3, 9);
				}
				dc.DrawGeometry(solidColorBrush3, null, pathGeometry2);
				dc.Pop();
			}
			if (flag)
			{
				dc.Pop();
			}
		}

		// Token: 0x06000752 RID: 1874 RVA: 0x00020B73 File Offset: 0x0001ED73
		private Brush EnsureControlBrush()
		{
			if (base.ReadLocalValue(DataGridHeaderBorder.ControlBrushProperty) == DependencyProperty.UnsetValue)
			{
				base.SetResourceReference(DataGridHeaderBorder.ControlBrushProperty, SystemColors.ControlBrushKey);
			}
			return (Brush)base.GetValue(DataGridHeaderBorder.ControlBrushProperty);
		}

		// Token: 0x06000753 RID: 1875 RVA: 0x00020BA8 File Offset: 0x0001EDA8
		private void RenderClassic(DrawingContext dc)
		{
			Size renderSize = base.RenderSize;
			bool flag = this.IsClickable && base.IsEnabled;
			bool flag2 = flag && this.IsPressed;
			ListSortDirection? sortDirection = this.SortDirection;
			bool flag3 = sortDirection != null;
			bool flag4 = this.Orientation == Orientation.Horizontal;
			Brush brush = this.EnsureControlBrush();
			Brush controlLightBrush = SystemColors.ControlLightBrush;
			Brush controlDarkBrush = SystemColors.ControlDarkBrush;
			bool flag5 = true;
			bool flag6 = true;
			bool flag7 = false;
			Brush brush2 = null;
			if (!flag4)
			{
				if (this.SeparatorVisibility == Visibility.Visible && this.SeparatorBrush != null)
				{
					brush2 = this.SeparatorBrush;
					flag7 = true;
				}
				else
				{
					flag5 = false;
				}
			}
			else
			{
				brush2 = SystemColors.ControlDarkDarkBrush;
			}
			Brush brush3 = null;
			if (flag4)
			{
				if (this.SeparatorVisibility == Visibility.Visible && this.SeparatorBrush != null)
				{
					brush3 = this.SeparatorBrush;
					flag7 = true;
				}
				else
				{
					flag6 = false;
				}
			}
			else
			{
				brush3 = SystemColors.ControlDarkDarkBrush;
			}
			DataGridHeaderBorder.EnsureCache(2);
			dc.DrawRectangle(brush, null, new Rect(0.0, 0.0, renderSize.Width, renderSize.Height));
			if (renderSize.Width > 3.0 && renderSize.Height > 3.0)
			{
				if (flag2)
				{
					dc.DrawRectangle(controlDarkBrush, null, new Rect(0.0, 0.0, renderSize.Width, 1.0));
					dc.DrawRectangle(controlDarkBrush, null, new Rect(0.0, 0.0, 1.0, renderSize.Height));
					dc.DrawRectangle(controlDarkBrush, null, new Rect(0.0, DataGridHeaderBorder.Max0(renderSize.Height - 1.0), renderSize.Width, 1.0));
					dc.DrawRectangle(controlDarkBrush, null, new Rect(DataGridHeaderBorder.Max0(renderSize.Width - 1.0), 0.0, 1.0, renderSize.Height));
				}
				else
				{
					dc.DrawRectangle(controlLightBrush, null, new Rect(0.0, 0.0, 1.0, DataGridHeaderBorder.Max0(renderSize.Height - 1.0)));
					dc.DrawRectangle(controlLightBrush, null, new Rect(0.0, 0.0, DataGridHeaderBorder.Max0(renderSize.Width - 1.0), 1.0));
					if (flag5)
					{
						if (!flag7)
						{
							dc.DrawRectangle(controlDarkBrush, null, new Rect(DataGridHeaderBorder.Max0(renderSize.Width - 2.0), 1.0, 1.0, DataGridHeaderBorder.Max0(renderSize.Height - 2.0)));
						}
						dc.DrawRectangle(brush2, null, new Rect(DataGridHeaderBorder.Max0(renderSize.Width - 1.0), 0.0, 1.0, renderSize.Height));
					}
					if (flag6)
					{
						if (!flag7)
						{
							dc.DrawRectangle(controlDarkBrush, null, new Rect(1.0, DataGridHeaderBorder.Max0(renderSize.Height - 2.0), DataGridHeaderBorder.Max0(renderSize.Width - 2.0), 1.0));
						}
						dc.DrawRectangle(brush3, null, new Rect(0.0, DataGridHeaderBorder.Max0(renderSize.Height - 1.0), renderSize.Width, 1.0));
					}
				}
			}
			if (flag3 && renderSize.Width > 14.0 && renderSize.Height > 10.0)
			{
				TranslateTransform translateTransform = new TranslateTransform(renderSize.Width - 15.0, (renderSize.Height - 5.0) * 0.5);
				translateTransform.Freeze();
				dc.PushTransform(translateTransform);
				bool flag8 = sortDirection == ListSortDirection.Ascending;
				PathGeometry pathGeometry = (PathGeometry)DataGridHeaderBorder.GetCachedFreezable(flag8 ? 0 : 1);
				if (pathGeometry == null)
				{
					pathGeometry = new PathGeometry();
					PathFigure pathFigure = new PathFigure();
					if (flag8)
					{
						pathFigure.StartPoint = new Point(0.0, 5.0);
						LineSegment lineSegment = new LineSegment(new Point(5.0, 0.0), false);
						lineSegment.Freeze();
						pathFigure.Segments.Add(lineSegment);
						lineSegment = new LineSegment(new Point(10.0, 5.0), false);
						lineSegment.Freeze();
						pathFigure.Segments.Add(lineSegment);
					}
					else
					{
						pathFigure.StartPoint = new Point(0.0, 0.0);
						LineSegment lineSegment2 = new LineSegment(new Point(10.0, 0.0), false);
						lineSegment2.Freeze();
						pathFigure.Segments.Add(lineSegment2);
						lineSegment2 = new LineSegment(new Point(5.0, 5.0), false);
						lineSegment2.Freeze();
						pathFigure.Segments.Add(lineSegment2);
					}
					pathFigure.IsClosed = true;
					pathFigure.Freeze();
					pathGeometry.Figures.Add(pathFigure);
					pathGeometry.Freeze();
					DataGridHeaderBorder.CacheFreezable(pathGeometry, flag8 ? 0 : 1);
				}
				dc.DrawGeometry(SystemColors.GrayTextBrush, null, pathGeometry);
				dc.Pop();
			}
		}

		// Token: 0x06000754 RID: 1876 RVA: 0x00021174 File Offset: 0x0001F374
		private static void EnsureCache(int size)
		{
			if (DataGridHeaderBorder._freezableCache == null)
			{
				lock (DataGridHeaderBorder._cacheAccess)
				{
					if (DataGridHeaderBorder._freezableCache == null)
					{
						DataGridHeaderBorder._freezableCache = new List<Freezable>(size);
						for (int i = 0; i < size; i++)
						{
							DataGridHeaderBorder._freezableCache.Add(null);
						}
					}
				}
			}
		}

		// Token: 0x06000755 RID: 1877 RVA: 0x000211D8 File Offset: 0x0001F3D8
		private static void ReleaseCache()
		{
			if (DataGridHeaderBorder._freezableCache != null)
			{
				lock (DataGridHeaderBorder._cacheAccess)
				{
					DataGridHeaderBorder._freezableCache = null;
				}
			}
		}

		// Token: 0x06000756 RID: 1878 RVA: 0x00021218 File Offset: 0x0001F418
		private static Freezable GetCachedFreezable(int index)
		{
			Freezable result;
			lock (DataGridHeaderBorder._cacheAccess)
			{
				Freezable freezable = DataGridHeaderBorder._freezableCache[index];
				result = freezable;
			}
			return result;
		}

		// Token: 0x06000757 RID: 1879 RVA: 0x0002125C File Offset: 0x0001F45C
		private static void CacheFreezable(Freezable freezable, int index)
		{
			lock (DataGridHeaderBorder._cacheAccess)
			{
				if (DataGridHeaderBorder._freezableCache[index] != null)
				{
					DataGridHeaderBorder._freezableCache[index] = freezable;
				}
			}
		}

		// Token: 0x0400021A RID: 538
		private const string ClassicThemeName = "Classic";

		// Token: 0x0400021B RID: 539
		private const string AeroNormalColorName = "Aero.NormalColor";

		// Token: 0x0400021C RID: 540
		private const string LunaNormalColorName = "Luna.NormalColor";

		// Token: 0x0400021D RID: 541
		private const string LunaHomeSteadName = "Luna.HomeStead";

		// Token: 0x0400021E RID: 542
		private const string LunaMetallicName = "Luna.Metallic";

		// Token: 0x0400021F RID: 543
		private const string RoyaleNormalColorName = "Royale.NormalColor";

		// Token: 0x04000220 RID: 544
		public static readonly DependencyProperty IsHoveredProperty = DependencyProperty.Register("IsHovered", typeof(bool), typeof(DataGridHeaderBorder), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsRender));

		// Token: 0x04000221 RID: 545
		public static readonly DependencyProperty IsPressedProperty = DependencyProperty.Register("IsPressed", typeof(bool), typeof(DataGridHeaderBorder), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsRender));

		// Token: 0x04000222 RID: 546
		public static readonly DependencyProperty IsClickableProperty = DependencyProperty.Register("IsClickable", typeof(bool), typeof(DataGridHeaderBorder), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsRender));

		// Token: 0x04000223 RID: 547
		public static readonly DependencyProperty SortDirectionProperty = DependencyProperty.Register("SortDirection", typeof(ListSortDirection?), typeof(DataGridHeaderBorder), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender));

		// Token: 0x04000224 RID: 548
		public static readonly DependencyProperty IsSelectedProperty = DependencyProperty.Register("IsSelected", typeof(bool), typeof(DataGridHeaderBorder), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsRender));

		// Token: 0x04000225 RID: 549
		public static readonly DependencyProperty OrientationProperty = DependencyProperty.Register("Orientation", typeof(Orientation), typeof(DataGridHeaderBorder), new FrameworkPropertyMetadata(Orientation.Vertical, FrameworkPropertyMetadataOptions.AffectsRender));

		// Token: 0x04000226 RID: 550
		public static readonly DependencyProperty SeparatorBrushProperty = DependencyProperty.Register("SeparatorBrush", typeof(Brush), typeof(DataGridHeaderBorder), new FrameworkPropertyMetadata(null));

		// Token: 0x04000227 RID: 551
		public static readonly DependencyProperty SeparatorVisibilityProperty = DependencyProperty.Register("SeparatorVisibility", typeof(Visibility), typeof(DataGridHeaderBorder), new FrameworkPropertyMetadata(Visibility.Visible));

		// Token: 0x04000228 RID: 552
		private static readonly DependencyProperty ControlBrushProperty = DependencyProperty.Register("ControlBrush", typeof(Brush), typeof(DataGridHeaderBorder), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender));

		// Token: 0x04000229 RID: 553
		private static List<Freezable> _freezableCache;

		// Token: 0x0400022A RID: 554
		private static object _cacheAccess = new object();

		// Token: 0x0200005E RID: 94
		private enum AeroFreezables
		{
			// Token: 0x0400022C RID: 556
			NormalBevel,
			// Token: 0x0400022D RID: 557
			NormalBackground,
			// Token: 0x0400022E RID: 558
			PressedBackground,
			// Token: 0x0400022F RID: 559
			HoveredBackground,
			// Token: 0x04000230 RID: 560
			SortedBackground,
			// Token: 0x04000231 RID: 561
			PressedTop,
			// Token: 0x04000232 RID: 562
			NormalSides,
			// Token: 0x04000233 RID: 563
			PressedSides,
			// Token: 0x04000234 RID: 564
			HoveredSides,
			// Token: 0x04000235 RID: 565
			SortedSides,
			// Token: 0x04000236 RID: 566
			PressedBevel,
			// Token: 0x04000237 RID: 567
			NormalBottom,
			// Token: 0x04000238 RID: 568
			PressedOrHoveredBottom,
			// Token: 0x04000239 RID: 569
			SortedBottom,
			// Token: 0x0400023A RID: 570
			ArrowBorder,
			// Token: 0x0400023B RID: 571
			ArrowFill,
			// Token: 0x0400023C RID: 572
			ArrowFillScale,
			// Token: 0x0400023D RID: 573
			ArrowUpGeometry,
			// Token: 0x0400023E RID: 574
			ArrowDownGeometry,
			// Token: 0x0400023F RID: 575
			NumFreezables
		}

		// Token: 0x0200005F RID: 95
		private enum Luna
		{
			// Token: 0x04000241 RID: 577
			NormalColor,
			// Token: 0x04000242 RID: 578
			HomeStead,
			// Token: 0x04000243 RID: 579
			Metallic
		}

		// Token: 0x02000060 RID: 96
		private enum LunaFreezables
		{
			// Token: 0x04000245 RID: 581
			NormalBackground,
			// Token: 0x04000246 RID: 582
			HoveredBackground,
			// Token: 0x04000247 RID: 583
			PressedBackground,
			// Token: 0x04000248 RID: 584
			HorizontalGripper,
			// Token: 0x04000249 RID: 585
			VerticalGripper,
			// Token: 0x0400024A RID: 586
			PressedBorder,
			// Token: 0x0400024B RID: 587
			TabGeometry,
			// Token: 0x0400024C RID: 588
			TabStroke,
			// Token: 0x0400024D RID: 589
			TabFill,
			// Token: 0x0400024E RID: 590
			ArrowFill,
			// Token: 0x0400024F RID: 591
			ArrowUpGeometry,
			// Token: 0x04000250 RID: 592
			ArrowDownGeometry,
			// Token: 0x04000251 RID: 593
			NumFreezables
		}

		// Token: 0x02000061 RID: 97
		private enum ClassicFreezables
		{
			// Token: 0x04000253 RID: 595
			ArrowUpGeometry,
			// Token: 0x04000254 RID: 596
			ArrowDownGeometry,
			// Token: 0x04000255 RID: 597
			NumFreezables
		}
	}
}
