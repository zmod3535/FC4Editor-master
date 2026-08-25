using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Divelements.SandDock.Primitives
{
	// Token: 0x02000063 RID: 99
	public class DropShadow : Decorator
	{
		// Token: 0x17000105 RID: 261
		// (get) Token: 0x060004A6 RID: 1190 RVA: 0x00046DDC File Offset: 0x000451DC
		// (set) Token: 0x060004A7 RID: 1191 RVA: 0x00046DF0 File Offset: 0x000451F0
		public double Distance
		{
			get
			{
				return (double)base.GetValue(DropShadow.DistanceProperty);
			}
			set
			{
				base.SetValue(DropShadow.DistanceProperty, value);
			}
		}

		// Token: 0x17000106 RID: 262
		// (get) Token: 0x060004A8 RID: 1192 RVA: 0x00046E04 File Offset: 0x00045204
		// (set) Token: 0x060004A9 RID: 1193 RVA: 0x00046E18 File Offset: 0x00045218
		public Thickness BorderThickness
		{
			get
			{
				return (Thickness)base.GetValue(DropShadow.BorderThicknessProperty);
			}
			set
			{
				base.SetValue(DropShadow.BorderThicknessProperty, value);
			}
		}

		// Token: 0x17000107 RID: 263
		// (get) Token: 0x060004AA RID: 1194 RVA: 0x00046E2C File Offset: 0x0004522C
		// (set) Token: 0x060004AB RID: 1195 RVA: 0x00046E40 File Offset: 0x00045240
		public Color Color
		{
			get
			{
				return (Color)base.GetValue(DropShadow.ColorProperty);
			}
			set
			{
				base.SetValue(DropShadow.ColorProperty, value);
			}
		}

		// Token: 0x17000108 RID: 264
		// (get) Token: 0x060004AC RID: 1196 RVA: 0x00046E54 File Offset: 0x00045254
		// (set) Token: 0x060004AD RID: 1197 RVA: 0x00046E68 File Offset: 0x00045268
		public Point Offset
		{
			get
			{
				return (Point)base.GetValue(DropShadow.OffsetProperty);
			}
			set
			{
				base.SetValue(DropShadow.OffsetProperty, value);
			}
		}

		// Token: 0x060004AE RID: 1198 RVA: 0x00046E7C File Offset: 0x0004527C
		private GradientStopCollection CreateGradientStopCollection(Color c)
		{
			GradientStopCollection gradientStopCollection = new GradientStopCollection();
			gradientStopCollection.Add(new GradientStop(c, 0.0));
			Color color = c;
			color.A = (byte)(0.74336 * (double)c.A);
			gradientStopCollection.Add(new GradientStop(color, 0.2));
			color.A = (byte)(0.38053 * (double)c.A);
			gradientStopCollection.Add(new GradientStop(color, 0.4));
			color.A = (byte)(0.12389 * (double)c.A);
			gradientStopCollection.Add(new GradientStop(color, 0.6));
			color.A = (byte)(0.02654 * (double)c.A);
			gradientStopCollection.Add(new GradientStop(color, 0.8));
			color.A = 0;
			gradientStopCollection.Add(new GradientStop(color, 1.0));
			gradientStopCollection.Freeze();
			return gradientStopCollection;
		}

		// Token: 0x060004AF RID: 1199 RVA: 0x00046F88 File Offset: 0x00045388
		private LinearGradientBrush CreateBrush(Point startPoint, Point endPoint)
		{
			LinearGradientBrush linearGradientBrush = new LinearGradientBrush(this.CreateGradientStopCollection(this.Color), startPoint, endPoint);
			linearGradientBrush.Freeze();
			return linearGradientBrush;
		}

		// Token: 0x060004B0 RID: 1200 RVA: 0x00046FB0 File Offset: 0x000453B0
		protected override void OnRender(DrawingContext drawingContext)
		{
			if (this.Color != Colors.Transparent)
			{
				if (255 == 0)
				{
					goto IL_232;
				}
				Rect rectangle = new Rect(this.Offset, base.RenderSize);
				rectangle.Inflate(-Math.Min(this.Distance, rectangle.Width / 2.0), -Math.Min(this.Distance, rectangle.Height / 2.0));
				drawingContext.DrawRectangle(new SolidColorBrush(this.Color), null, rectangle);
				Rect rectangle2 = new Rect(rectangle.Left - this.BorderThickness.Left, rectangle.Top, this.BorderThickness.Left, rectangle.Height);
				if (rectangle2.Width >= 0.0 && rectangle2.Height >= 0.0)
				{
					drawingContext.DrawRectangle(this.CreateBrush(new Point(1.0, 0.0), new Point(0.0, 0.0)), null, rectangle2);
				}
				rectangle2 = new Rect(rectangle.Right, rectangle.Top, this.BorderThickness.Right, rectangle.Height);
				if (rectangle2.Width >= 0.0 && rectangle2.Height >= 0.0)
				{
					drawingContext.DrawRectangle(this.CreateBrush(new Point(0.0, 0.0), new Point(1.0, 0.0)), null, rectangle2);
				}
				rectangle2 = new Rect(rectangle.Left, rectangle.Top - this.BorderThickness.Top, rectangle.Width, this.BorderThickness.Top);
				if (rectangle2.Width >= 0.0 && rectangle2.Height >= 0.0)
				{
					drawingContext.DrawRectangle(this.CreateBrush(new Point(0.0, 1.0), new Point(0.0, 0.0)), null, rectangle2);
				}
				rectangle2 = new Rect(rectangle.Left, rectangle.Bottom, rectangle.Width, this.BorderThickness.Bottom);
				if (rectangle2.Width >= 0.0 && rectangle2.Height >= 0.0)
				{
					drawingContext.DrawRectangle(this.CreateBrush(new Point(0.0, 0.0), new Point(0.0, 1.0)), null, rectangle2);
				}
				rectangle2 = new Rect(rectangle.Left - this.BorderThickness.Left, rectangle.Top - this.BorderThickness.Top, this.BorderThickness.Left, this.BorderThickness.Top);
				if (-1 != 0)
				{
					if (rectangle2.Width >= 0.0 && rectangle2.Height >= 0.0)
					{
						RadialGradientBrush radialGradientBrush = new RadialGradientBrush(this.CreateGradientStopCollection(this.Color));
						radialGradientBrush.Center = new Point(1.0, 1.0);
						radialGradientBrush.GradientOrigin = new Point(1.0, 1.0);
						radialGradientBrush.RadiusX = 1.0;
						radialGradientBrush.RadiusY = 1.0;
						radialGradientBrush.Freeze();
						drawingContext.DrawRectangle(radialGradientBrush, null, rectangle2);
					}
					rectangle2 = new Rect(rectangle.Right, rectangle.Top - this.BorderThickness.Top, this.BorderThickness.Right, this.BorderThickness.Top);
					goto IL_232;
				}
				goto IL_28B;
				IL_77:
				rectangle2 = new Rect(rectangle.Left - this.BorderThickness.Left, rectangle.Bottom, this.BorderThickness.Left, this.BorderThickness.Bottom);
				if (rectangle2.Width < 0.0 || rectangle2.Height < 0.0)
				{
					goto IL_16E;
				}
				RadialGradientBrush radialGradientBrush2 = new RadialGradientBrush(this.CreateGradientStopCollection(this.Color));
				radialGradientBrush2.Center = new Point(1.0, 0.0);
				radialGradientBrush2.GradientOrigin = new Point(1.0, 0.0);
				radialGradientBrush2.RadiusX = 1.0;
				if (4 != 0)
				{
					radialGradientBrush2.RadiusY = 1.0;
					radialGradientBrush2.Freeze();
					drawingContext.DrawRectangle(radialGradientBrush2, null, rectangle2);
					goto IL_16E;
				}
				IL_34:
				RadialGradientBrush radialGradientBrush3;
				radialGradientBrush3.Freeze();
				drawingContext.DrawRectangle(radialGradientBrush3, null, rectangle2);
				goto IL_230;
				IL_16E:
				rectangle2 = new Rect(rectangle.Right, rectangle.Bottom, this.BorderThickness.Right, this.BorderThickness.Bottom);
				if (rectangle2.Width >= 0.0 && rectangle2.Height >= 0.0)
				{
					radialGradientBrush3 = new RadialGradientBrush(this.CreateGradientStopCollection(this.Color));
					radialGradientBrush3.Center = new Point(0.0, 0.0);
					radialGradientBrush3.GradientOrigin = new Point(0.0, 0.0);
					radialGradientBrush3.RadiusX = 1.0;
					if (!false)
					{
						radialGradientBrush3.RadiusY = 1.0;
						goto IL_34;
					}
				}
				IL_230:
				return;
				IL_232:
				if (rectangle2.Width < 0.0 || rectangle2.Height < 0.0)
				{
					goto IL_77;
				}
				RadialGradientBrush radialGradientBrush4 = new RadialGradientBrush(this.CreateGradientStopCollection(this.Color));
				radialGradientBrush4.Center = new Point(0.0, 1.0);
				IL_28B:
				radialGradientBrush4.GradientOrigin = new Point(0.0, 1.0);
				radialGradientBrush4.RadiusX = 1.0;
				radialGradientBrush4.RadiusY = 1.0;
				radialGradientBrush4.Freeze();
				drawingContext.DrawRectangle(radialGradientBrush4, null, rectangle2);
				goto IL_77;
			}
		}

		// Token: 0x04000208 RID: 520
		public static readonly DependencyProperty ColorProperty = DependencyProperty.Register("Color", typeof(Color), typeof(DropShadow), new FrameworkPropertyMetadata(Color.FromArgb(113, 0, 0, 0), FrameworkPropertyMetadataOptions.AffectsRender));

		// Token: 0x04000209 RID: 521
		public static readonly DependencyProperty OffsetProperty = DependencyProperty.Register("Offset", typeof(Point), typeof(DropShadow), new FrameworkPropertyMetadata(new Point(3.0, 3.0), FrameworkPropertyMetadataOptions.AffectsRender));

		// Token: 0x0400020A RID: 522
		public static readonly DependencyProperty BorderThicknessProperty = DependencyProperty.Register("BorderThickness", typeof(Thickness), typeof(DropShadow), new FrameworkPropertyMetadata(new Thickness(6.0), FrameworkPropertyMetadataOptions.AffectsRender));

		// Token: 0x0400020B RID: 523
		public static readonly DependencyProperty DistanceProperty = DependencyProperty.Register("Distance", typeof(double), typeof(DropShadow), new FrameworkPropertyMetadata(3.0, FrameworkPropertyMetadataOptions.AffectsRender));
	}
}
