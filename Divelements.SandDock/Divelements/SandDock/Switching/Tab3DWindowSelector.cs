using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Media3D;

namespace Divelements.SandDock.Switching
{
	// Token: 0x0200005C RID: 92
	[TemplatePart(Name = "PART_Viewport", Type = typeof(Viewport3D))]
	public class Tab3DWindowSelector : Control
	{
		// Token: 0x0600046D RID: 1133 RVA: 0x000455B0 File Offset: 0x000439B0
		static Tab3DWindowSelector()
		{
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(Tab3DWindowSelector), new FrameworkPropertyMetadata(typeof(Tab3DWindowSelector)));
			UIElement.FocusableProperty.OverrideMetadata(typeof(Tab3DWindowSelector), new FrameworkPropertyMetadata(false));
			FrameworkElement.FocusVisualStyleProperty.OverrideMetadata(typeof(Tab3DWindowSelector), new FrameworkPropertyMetadata(null));
			Tab3DWindowSelector.TransformAdjustProperty = DependencyProperty.Register("TransformAdjust", typeof(double), typeof(Tab3DWindowSelector), new FrameworkPropertyMetadata(0.0, new PropertyChangedCallback(Tab3DWindowSelector.OnTransformAdjustChanged)));
			Tab3DWindowSelector.InitialViewAdjustProperty = DependencyProperty.Register("InitialViewAdjust", typeof(double), typeof(Tab3DWindowSelector), new FrameworkPropertyMetadata(0.0, new PropertyChangedCallback(Tab3DWindowSelector.OnInitialViewAdjustChanged)));
		}

		// Token: 0x0600046E RID: 1134 RVA: 0x000456B8 File Offset: 0x00043AB8
		internal Tab3DWindowSelector(x5b48716de9a52566 windowSwitcher, WindowPreview[] windows, Size viewportSize2D, Point screenOrigin)
		{
			if (windowSwitcher == null)
			{
				throw new ArgumentNullException("windowSwitch");
			}
			if (windows == null)
			{
				throw new ArgumentNullException("windows");
			}
			if (windows.Length < 2)
			{
				throw new ArgumentException("windows");
			}
			this.windowSwitcher = windowSwitcher;
			this.windows = windows;
			Array.Reverse(windows);
			this.viewportSize2D = viewportSize2D;
			this.screenOrigin = screenOrigin;
			this.lightModel = new ModelVisual3D();
			this.lightModel.Content = new AmbientLight();
			this.camera = this.CreateCamera(25.0);
			this.originalCameraPosition = this.camera.Position;
			this.originalCameraLookDirection = this.camera.LookDirection;
			this.CreateRootModel(windows);
		}

		// Token: 0x0600046F RID: 1135 RVA: 0x00045778 File Offset: 0x00043B78
		protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
		{
			base.OnMouseLeftButtonDown(e);
			RayMeshGeometry3DHitTestResult rayMeshGeometry3DHitTestResult = VisualTreeHelper.HitTest(this, e.GetPosition(this)) as RayMeshGeometry3DHitTestResult;
			if (rayMeshGeometry3DHitTestResult != null && rayMeshGeometry3DHitTestResult.MeshHit != null)
			{
				for (int i = 0; i < this.windowModels.Length; i++)
				{
					if (this.windowModels[i] == rayMeshGeometry3DHitTestResult.ModelHit)
					{
						this.windowSwitcher.PreviewingWindow = this.windows[i].Window;
						this.windowSwitcher.Commit();
						return;
					}
				}
			}
		}

		// Token: 0x06000470 RID: 1136 RVA: 0x000457F4 File Offset: 0x00043BF4
		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			Viewport3D viewport3D = this.viewport;
			this.viewport = (base.GetTemplateChild("PART_Viewport") as Viewport3D);
			if (this.viewport != null)
			{
				this.viewport.Camera = this.camera;
				this.viewport.Children.Add(this.modelVisual);
				this.viewport.Children.Add(this.lightModel);
				this.EffectStart();
			}
		}

		// Token: 0x06000471 RID: 1137 RVA: 0x00045870 File Offset: 0x00043C70
		private PerspectiveCamera CreateCamera(double fieldOfView)
		{
			Size size = this.viewportSize2D;
			double num = fieldOfView * 0.017453292519943295;
			double z = size.Width / 2.0 / Math.Tan(num / 2.0);
			return new PerspectiveCamera(new Point3D(size.Width / 2.0, size.Height / 2.0, z), new Vector3D(0.0, 0.0, -1.0), new Vector3D(0.0, 1.0, 0.0), fieldOfView);
		}

		// Token: 0x06000472 RID: 1138 RVA: 0x00045924 File Offset: 0x00043D24
		private void EffectStart()
		{
			this.TransitionAnimation = new DoubleAnimation(1.0, new Duration(TimeSpan.FromMilliseconds((double)Tab3DWindowSelector.onscreenAnimationTime)));
			base.BeginAnimation(Tab3DWindowSelector.InitialViewAdjustProperty, this.TransitionAnimation);
			double num = 4.0 * (this.viewportSize2D.Width / (this.viewportSize2D.Height * 1.7));
			if (Tab3DWindowSelector.AnimateTransition)
			{
				this.camera.BeginAnimation(ProjectionCamera.PositionProperty, new Point3DAnimation(new Point3D(this.camera.Position.X * -3.0, this.camera.Position.Y * num, this.camera.Position.Z * 4.0), new Duration(TimeSpan.FromMilliseconds((double)Tab3DWindowSelector.onscreenAnimationTime))));
				this.camera.BeginAnimation(ProjectionCamera.LookDirectionProperty, new Vector3DAnimation(new Vector3D(0.27, -0.17, -1.0), new Duration(TimeSpan.FromMilliseconds((double)Tab3DWindowSelector.onscreenAnimationTime))));
				return;
			}
			this.camera.Position = new Point3D(this.camera.Position.X * -3.0, this.camera.Position.Y * num, this.camera.Position.Z * 4.0);
			this.camera.LookDirection = new Vector3D(0.27, -0.17, -1.0);
		}

		// Token: 0x170000FA RID: 250
		// (get) Token: 0x06000473 RID: 1139 RVA: 0x00045AE8 File Offset: 0x00043EE8
		// (set) Token: 0x06000474 RID: 1140 RVA: 0x00045AF0 File Offset: 0x00043EF0
		public static bool AnimateTransition
		{
			get
			{
				return Tab3DWindowSelector.animateTransition;
			}
			set
			{
				Tab3DWindowSelector.animateTransition = value;
			}
		}

		// Token: 0x170000FB RID: 251
		// (get) Token: 0x06000475 RID: 1141 RVA: 0x00045AF8 File Offset: 0x00043EF8
		// (set) Token: 0x06000476 RID: 1142 RVA: 0x00045B00 File Offset: 0x00043F00
		public static int TransitionInTime
		{
			get
			{
				return Tab3DWindowSelector.onscreenAnimationTime;
			}
			set
			{
				if (value < 20 || value > 2000)
				{
					throw new ArgumentException("value");
				}
				Tab3DWindowSelector.onscreenAnimationTime = value;
			}
		}

		// Token: 0x170000FC RID: 252
		// (get) Token: 0x06000477 RID: 1143 RVA: 0x00045B20 File Offset: 0x00043F20
		// (set) Token: 0x06000478 RID: 1144 RVA: 0x00045B28 File Offset: 0x00043F28
		public static int TransitionOutTime
		{
			get
			{
				return Tab3DWindowSelector.offscreenAnimationTime;
			}
			set
			{
				if (value < 20 || value > 2000)
				{
					throw new ArgumentException("value");
				}
				Tab3DWindowSelector.offscreenAnimationTime = value;
			}
		}

		// Token: 0x06000479 RID: 1145 RVA: 0x00045B48 File Offset: 0x00043F48
		internal void Stop()
		{
			if (Tab3DWindowSelector.AnimateTransition)
			{
				this.stopping = true;
				double value = (double)Tab3DWindowSelector.offscreenAnimationTime * this.InitialViewAdjust;
				this.TransitionAnimation = new DoubleAnimation(0.0, new Duration(TimeSpan.FromMilliseconds(value)));
				base.BeginAnimation(Tab3DWindowSelector.InitialViewAdjustProperty, this.TransitionAnimation);
				this.camera.BeginAnimation(ProjectionCamera.PositionProperty, new Point3DAnimation(this.originalCameraPosition, new Duration(TimeSpan.FromMilliseconds(value))));
				this.camera.BeginAnimation(ProjectionCamera.LookDirectionProperty, new Vector3DAnimation(this.originalCameraLookDirection, new Duration(TimeSpan.FromMilliseconds(value))));
				return;
			}
			this.EffectStop();
		}

		// Token: 0x0600047A RID: 1146 RVA: 0x00045BF8 File Offset: 0x00043FF8
		private void OnTransitionAnimationCompleted(object sender, EventArgs e)
		{
			this.TransitionAnimation = null;
			if (this.stopping)
			{
				this.EffectStop();
			}
		}

		// Token: 0x0600047B RID: 1147 RVA: 0x00045C10 File Offset: 0x00044010
		private void EffectStop()
		{
			this.viewport.Children.Clear();
			this.stopped = true;
			((x5b48716de9a52566)this.WindowSwitcher).x06fe2f4431a29900();
		}

		// Token: 0x170000FD RID: 253
		// (get) Token: 0x0600047C RID: 1148 RVA: 0x00045C3C File Offset: 0x0004403C
		// (set) Token: 0x0600047D RID: 1149 RVA: 0x00045C44 File Offset: 0x00044044
		private AnimationTimeline TransitionAnimation
		{
			get
			{
				return this.transitionAnimation;
			}
			set
			{
				if (value != this.transitionAnimation)
				{
					if (this.transitionAnimation != null)
					{
						this.transitionAnimation.Completed -= this.OnTransitionAnimationCompleted;
					}
					this.transitionAnimation = value;
					if (this.transitionAnimation != null)
					{
						this.transitionAnimation.Completed += this.OnTransitionAnimationCompleted;
					}
				}
			}
		}

		// Token: 0x170000FE RID: 254
		// (get) Token: 0x0600047E RID: 1150 RVA: 0x00045CA0 File Offset: 0x000440A0
		// (set) Token: 0x0600047F RID: 1151 RVA: 0x00045CA8 File Offset: 0x000440A8
		private AnimationTimeline FlipAnimation
		{
			get
			{
				return this.flipAnimation;
			}
			set
			{
				if (value != this.flipAnimation)
				{
					if (this.flipAnimation != null)
					{
						this.flipAnimation.Completed -= this.OnFlipAnimationCompleted;
					}
					this.flipAnimation = value;
					if (this.flipAnimation != null)
					{
						this.flipAnimation.Completed += this.OnFlipAnimationCompleted;
					}
				}
			}
		}

		// Token: 0x06000480 RID: 1152 RVA: 0x00045D04 File Offset: 0x00044104
		private void OnFlipAnimationCompleted(object sender, EventArgs e)
		{
			this.CompleteFlip();
		}

		// Token: 0x170000FF RID: 255
		// (get) Token: 0x06000481 RID: 1153 RVA: 0x00045D0C File Offset: 0x0004410C
		private double TransformAdjust
		{
			get
			{
				return (double)base.GetValue(Tab3DWindowSelector.TransformAdjustProperty);
			}
		}

		// Token: 0x17000100 RID: 256
		// (get) Token: 0x06000482 RID: 1154 RVA: 0x00045D20 File Offset: 0x00044120
		// (set) Token: 0x06000483 RID: 1155 RVA: 0x00045D34 File Offset: 0x00044134
		private double InitialViewAdjust
		{
			get
			{
				return (double)base.GetValue(Tab3DWindowSelector.InitialViewAdjustProperty);
			}
			set
			{
				base.SetValue(Tab3DWindowSelector.InitialViewAdjustProperty, value);
			}
		}

		// Token: 0x06000484 RID: 1156 RVA: 0x00045D48 File Offset: 0x00044148
		private static void OnTransformAdjustChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
		{
			((Tab3DWindowSelector)o).ApplyWindowTransforms();
		}

		// Token: 0x06000485 RID: 1157 RVA: 0x00045D58 File Offset: 0x00044158
		private static void OnInitialViewAdjustChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
		{
			((Tab3DWindowSelector)o).ApplyWindowTransforms();
		}

		// Token: 0x06000486 RID: 1158 RVA: 0x00045D68 File Offset: 0x00044168
		private void CompleteFlip()
		{
			this.startOffset += this.flippingDirection;
			if (this.startOffset < 0)
			{
				this.startOffset = this.windows.Length - 1;
			}
			if (this.startOffset >= this.windows.Length)
			{
				this.startOffset = 0;
			}
			this.FlipAnimation = null;
			this.ApplyWindowTransforms();
		}

		// Token: 0x06000487 RID: 1159 RVA: 0x00045DC8 File Offset: 0x000441C8
		internal void BeginFlip(bool forward)
		{
			if (this.FlipAnimation != null)
			{
				this.CompleteFlip();
			}
			this.flippingDirection = (forward ? 1 : -1);
			this.FlipAnimation = new DoubleAnimation(0.0, (double)this.flippingDirection, new Duration(TimeSpan.FromMilliseconds(250.0)))
			{
				FillBehavior = FillBehavior.Stop
			};
			base.BeginAnimation(Tab3DWindowSelector.TransformAdjustProperty, this.FlipAnimation);
		}

		// Token: 0x06000488 RID: 1160 RVA: 0x00045E38 File Offset: 0x00044238
		private void ApplyWindowTransforms()
		{
			if (!this.stopped)
			{
				int num5;
				for (;;)
				{
					int num = 0;
					double num2 = -1.2566370614359172;
					double num3 = 0.39269908169872414;
					double num4 = 0.12566370614359174;
					num5 = this.startOffset;
					for (;;)
					{
						this.onscreenTransforms[num5].OffsetX = (this.windows[num5].WindowPosition.X - this.screenOrigin.X) * (1.0 - this.InitialViewAdjust);
						this.onscreenTransforms[num5].OffsetY = (this.screenOrigin.Y - this.windows[num5].WindowPosition.Y - this.windows[num5].WindowSize.Height) * (1.0 - this.InitialViewAdjust);
						double num6 = (double)num - this.TransformAdjust;
						if (num == 0 && this.TransformAdjust > 0.5)
						{
							num6 = (double)this.windows.Length - this.TransformAdjust;
						}
						else if (num == this.windows.Length - 1 && this.TransformAdjust < -0.5)
						{
							num6 = -1.0 - this.TransformAdjust;
						}
						double num7 = num6 / (double)(this.windows.Length - 1);
						double num8;
						if (num3 - num2 > (double)this.windows.Length * num4)
						{
							num8 = num3 - num6 * num4;
						}
						else
						{
							num8 = num3 - (num3 - num2) * num7;
						}
						this.wheelTransforms[num5].OffsetY = (Math.Cos(num8) - 1.0) * this.viewportSize2D.Width * this.InitialViewAdjust;
						this.wheelTransforms[num5].OffsetZ = Math.Sin(num8) * this.viewportSize2D.Width * 8.0 * this.InitialViewAdjust;
						DiffuseMaterial diffuseMaterial = (DiffuseMaterial)this.windowModels[num5].Material;
						if (this.TransformAdjust > 0.0 && num == 0)
						{
							double opacity;
							if (this.TransformAdjust < 0.5)
							{
								opacity = 1.0 - this.TransformAdjust * 2.0;
							}
							else
							{
								opacity = (this.TransformAdjust - 0.5) * 2.0;
							}
							diffuseMaterial.Brush.Opacity = opacity;
						}
						else if (this.TransformAdjust < 0.0 && num == this.windows.Length - 1)
						{
							if (((uint)num5 & 0U) != 0U)
							{
								return;
							}
							double opacity2;
							if (this.TransformAdjust > -0.5)
							{
								opacity2 = 1.0 + this.TransformAdjust * 2.0;
							}
							else
							{
								opacity2 = (-this.TransformAdjust - 0.5) * 2.0;
							}
							diffuseMaterial.Brush.Opacity = opacity2;
						}
						else
						{
							diffuseMaterial.Brush.Opacity = 1.0;
							if (-2147483648 == 0)
							{
								break;
							}
						}
						num++;
						num5++;
						if (num5 == this.windows.Length)
						{
							num5 = 0;
						}
						if (num5 == this.startOffset)
						{
							goto Block_4;
						}
					}
				}
				Block_4:
				bool flag = (uint)num5 - (uint)num5 < 0U;
				if (!flag)
				{
					return;
				}
			}
		}

		// Token: 0x06000489 RID: 1161 RVA: 0x000461A4 File Offset: 0x000445A4
		private ModelVisual3D CreateRootModel(WindowPreview[] windows)
		{
			this.windowModels = new GeometryModel3D[windows.Length];
			this.wheelTransforms = new TranslateTransform3D[windows.Length];
			this.onscreenTransforms = new TranslateTransform3D[windows.Length];
			this.modelVisual = new ModelVisual3D();
			this.windowsGroup = new Model3DGroup();
			this.modelVisual.Content = this.windowsGroup;
			int num = 0;
			for (;;)
			{
				Transform3DGroup transform3DGroup;
				if (num >= windows.Length)
				{
					this.ApplyWindowTransforms();
					if ((uint)num + (uint)num <= 4294967295U)
					{
						break;
					}
				}
				else
				{
					WindowPreview windowPreview = windows[num];
					this.windowModels[num] = this.GenerateGeometryModel(windowPreview);
					transform3DGroup = new Transform3DGroup();
					ScaleTransform3D scaleTransform3D = new ScaleTransform3D(windowPreview.WindowSize.Width, windowPreview.WindowSize.Height, 1.0, 0.0, 0.0, 0.0);
					scaleTransform3D.Freeze();
					transform3DGroup.Children.Add(scaleTransform3D);
					this.onscreenTransforms[num] = new TranslateTransform3D();
					transform3DGroup.Children.Add(this.onscreenTransforms[num]);
					this.wheelTransforms[num] = new TranslateTransform3D();
					transform3DGroup.Children.Add(this.wheelTransforms[num]);
				}
				this.windowModels[num].Transform = transform3DGroup;
				this.windowsGroup.Children.Insert(0, this.windowModels[num]);
				num++;
			}
			return this.modelVisual;
		}

		// Token: 0x0600048A RID: 1162 RVA: 0x00046314 File Offset: 0x00044714
		private GeometryModel3D GenerateGeometryModel(WindowPreview window)
		{
			if (this.planeMesh == null)
			{
				this.planeMesh = new MeshGeometry3D();
				this.planeMesh.Positions = new Point3DCollection(new Point3D[]
				{
					new Point3D(0.0, 0.0, 0.0),
					new Point3D(1.0, 0.0, 0.0),
					new Point3D(1.0, 1.0, 0.0),
					new Point3D(0.0, 1.0, 0.0)
				});
				this.planeMesh.TextureCoordinates = new PointCollection(new Point[]
				{
					new Point(0.0, 1.0),
					new Point(1.0, 1.0),
					new Point(1.0, 0.0),
					new Point(0.0, 0.0)
				});
				this.planeMesh.TriangleIndices = new Int32Collection(new int[]
				{
					0,
					1,
					2,
					0,
					2,
					3
				});
				this.planeMesh.Freeze();
			}
			VisualBrush previewBrush = window.PreviewBrush;
			previewBrush.AutoLayoutContent = false;
			previewBrush.SetValue(RenderOptions.CachingHintProperty, CachingHint.Cache);
			DiffuseMaterial material = new DiffuseMaterial(previewBrush);
			return new GeometryModel3D(this.planeMesh, material);
		}

		// Token: 0x17000101 RID: 257
		// (get) Token: 0x0600048B RID: 1163 RVA: 0x00046504 File Offset: 0x00044904
		public WindowSwitcher WindowSwitcher
		{
			get
			{
				return this.windowSwitcher;
			}
		}

		// Token: 0x040001DF RID: 479
		private const int FLIPTIME = 250;

		// Token: 0x040001E0 RID: 480
		private static readonly DependencyProperty TransformAdjustProperty;

		// Token: 0x040001E1 RID: 481
		private static readonly DependencyProperty InitialViewAdjustProperty;

		// Token: 0x040001E2 RID: 482
		private ModelVisual3D lightModel;

		// Token: 0x040001E3 RID: 483
		private ModelVisual3D modelVisual;

		// Token: 0x040001E4 RID: 484
		private Size viewportSize2D;

		// Token: 0x040001E5 RID: 485
		private Point screenOrigin;

		// Token: 0x040001E6 RID: 486
		private PerspectiveCamera camera;

		// Token: 0x040001E7 RID: 487
		private Point3D originalCameraPosition;

		// Token: 0x040001E8 RID: 488
		private Vector3D originalCameraLookDirection;

		// Token: 0x040001E9 RID: 489
		private AnimationTimeline transitionAnimation;

		// Token: 0x040001EA RID: 490
		private static int onscreenAnimationTime = 500;

		// Token: 0x040001EB RID: 491
		private static int offscreenAnimationTime = 300;

		// Token: 0x040001EC RID: 492
		private x5b48716de9a52566 windowSwitcher;

		// Token: 0x040001ED RID: 493
		private Model3DGroup windowsGroup;

		// Token: 0x040001EE RID: 494
		private WindowPreview[] windows;

		// Token: 0x040001EF RID: 495
		private GeometryModel3D[] windowModels;

		// Token: 0x040001F0 RID: 496
		private TranslateTransform3D[] wheelTransforms;

		// Token: 0x040001F1 RID: 497
		private TranslateTransform3D[] onscreenTransforms;

		// Token: 0x040001F2 RID: 498
		private int startOffset;

		// Token: 0x040001F3 RID: 499
		private Viewport3D viewport;

		// Token: 0x040001F4 RID: 500
		private MeshGeometry3D planeMesh;

		// Token: 0x040001F5 RID: 501
		private bool stopped;

		// Token: 0x040001F6 RID: 502
		private bool stopping;

		// Token: 0x040001F7 RID: 503
		private static bool animateTransition = true;

		// Token: 0x040001F8 RID: 504
		private int flippingDirection;

		// Token: 0x040001F9 RID: 505
		private AnimationTimeline flipAnimation;
	}
}
