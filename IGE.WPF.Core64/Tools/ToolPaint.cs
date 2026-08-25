using System;
using System.Collections.Generic;
using System.Windows.Input;
using System.Windows.Media;
using IGE.Nomad;
using IGE.Parameters;

namespace IGE.Tools
{
	// Token: 0x0200004D RID: 77
	internal abstract class ToolPaint : Tool, IInputSink
	{
		// Token: 0x06000347 RID: 839 RVA: 0x00009C68 File Offset: 0x00007E68
		protected ToolPaint(string displayName, string image) : base(displayName, image)
		{
		}

		// Token: 0x06000348 RID: 840 RVA: 0x00009EA4 File Offset: 0x000080A4
		protected IEnumerable<Parameter> _GetParameters()
		{
			yield return this.m_square;
			yield return this.m_radius;
			yield return this.m_hardness;
			yield return this.m_distortion;
			yield break;
		}

		// Token: 0x06000349 RID: 841 RVA: 0x00009EC1 File Offset: 0x000080C1
		protected override IEnumerable<Parameter> GetParameters()
		{
			return this._GetParameters();
		}

		// Token: 0x0600034A RID: 842 RVA: 0x00009EC9 File Offset: 0x000080C9
		public virtual SingleParameter GetMainParameter()
		{
			return null;
		}

		// Token: 0x0600034B RID: 843 RVA: 0x00009ECC File Offset: 0x000080CC
		protected string GetPaintContextHelp()
		{
			return Localizer.Localize("HELP_PAINT", null);
		}

		// Token: 0x0600034C RID: 844 RVA: 0x00009ED9 File Offset: 0x000080D9
		protected string GetPaintNoReverseContextHelp()
		{
			return Localizer.Localize("HELP_PAINT_NOREVERSE", null);
		}

		// Token: 0x0600034D RID: 845 RVA: 0x00009EE6 File Offset: 0x000080E6
		protected string GetShortcutContextHelp()
		{
			return Localizer.Localize("HELP_SHORTCUT", null);
		}

		// Token: 0x0600034E RID: 846 RVA: 0x00009EF3 File Offset: 0x000080F3
		public override void Activate()
		{
			base.Parent.CursorPhysics = false;
			this.m_cursorValid = Editor.RayCastTerrainFromMouse(out this.m_cursorPos);
		}

		// Token: 0x0600034F RID: 847 RVA: 0x00009F12 File Offset: 0x00008112
		public override void Deactivate()
		{
			base.Parent.CursorPhysics = true;
			if (this.m_painting != ToolPaint.PaintingMode.None)
			{
				this.FinishPainting();
			}
		}

		// Token: 0x06000350 RID: 848 RVA: 0x00009F2E File Offset: 0x0000812E
		public virtual void OnSwitchFrom(Tool prevTool)
		{
			CollectionManager.ActivatePhysics(false);
		}

		// Token: 0x06000351 RID: 849 RVA: 0x00009F36 File Offset: 0x00008136
		public virtual void OnSwitchTo(Tool nextTool)
		{
			if (!(nextTool is ToolPaint))
			{
				CollectionManager.ActivatePhysics(true);
			}
		}

		// Token: 0x06000352 RID: 850 RVA: 0x00009F46 File Offset: 0x00008146
		public virtual void OnInputAcquire()
		{
		}

		// Token: 0x06000353 RID: 851 RVA: 0x00009F48 File Offset: 0x00008148
		public virtual void OnInputRelease()
		{
		}

		// Token: 0x06000354 RID: 852 RVA: 0x00009F4C File Offset: 0x0000814C
		public virtual bool OnMouseEvent(Editor.MouseEvent mouseEvent, Editor.MouseEventArgs mouseEventArgs)
		{
			switch (mouseEvent)
			{
			case Editor.MouseEvent.MouseDown:
				if (!Keyboard.IsKeyDown(Key.LeftShift) && !Keyboard.IsKeyDown(Key.RightShift))
				{
					Vec3 cursorPos;
					if (Editor.RayCastTerrainFromMouse(out cursorPos))
					{
						this.m_cursorPos = cursorPos;
						this.OnBeginPaint();
					}
				}
				else
				{
					this.m_painting = ToolPaint.PaintingMode.Shortcut;
				}
				if (this.m_painting != ToolPaint.PaintingMode.None)
				{
					Editor.Viewport.CaptureMouse = true;
					Editor.Viewport.CameraEnabled = false;
				}
				break;
			case Editor.MouseEvent.MouseUp:
				if (this.m_painting != ToolPaint.PaintingMode.None)
				{
					this.FinishPainting();
				}
				break;
			case Editor.MouseEvent.MouseMove:
				switch (this.m_painting)
				{
				case ToolPaint.PaintingMode.None:
				case ToolPaint.PaintingMode.Plus:
				case ToolPaint.PaintingMode.Minus:
					this.m_cursorValid = Editor.RayCastTerrainFromMouse(out this.m_cursorPos);
					break;
				}
				break;
			case Editor.MouseEvent.MouseMoveDelta:
				switch (this.m_painting)
				{
				case ToolPaint.PaintingMode.Plus:
				case ToolPaint.PaintingMode.Minus:
					if (!this.m_grabMode.Value)
					{
						Editor.ApplyScreenDeltaToWorldPos(new Vec2((float)mouseEventArgs.X / (float)Editor.Viewport.Width, (float)mouseEventArgs.Y / (float)Editor.Viewport.Height), ref this.m_cursorPos);
						this.m_cursorPos.Z = TerrainManager.GetHeightAtWithWater(this.m_cursorPos.XY);
					}
					else
					{
						this.OnPaintGrab((float)mouseEventArgs.X, (float)mouseEventArgs.Y);
					}
					break;
				case ToolPaint.PaintingMode.Shortcut:
				{
					float delta;
					if (Math.Abs(mouseEventArgs.X) > Math.Abs(mouseEventArgs.Y))
					{
						delta = (float)mouseEventArgs.X;
					}
					else
					{
						delta = (float)(-(float)mouseEventArgs.Y);
					}
					this.OnShortcutDelta(delta);
					break;
				}
				}
				break;
			}
			return false;
		}

		// Token: 0x06000355 RID: 853 RVA: 0x0000A0E2 File Offset: 0x000082E2
		public virtual bool OnKeyEvent(Editor.KeyEvent keyEvent, Editor.KeyEventArgs keyEventArgs)
		{
			return false;
		}

		// Token: 0x06000356 RID: 854 RVA: 0x0000A0E5 File Offset: 0x000082E5
		public virtual void OnEditorEvent(uint eventType, IntPtr eventPtr)
		{
		}

		// Token: 0x06000357 RID: 855 RVA: 0x0000A0E7 File Offset: 0x000082E7
		protected virtual void OnBeginPaint()
		{
			base.Parent.EnableShortcuts = false;
			this.m_painting = ((Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)) ? ToolPaint.PaintingMode.Minus : ToolPaint.PaintingMode.Plus);
			UndoManager.RecordUndo();
			this.CreateBrush();
		}

		// Token: 0x06000358 RID: 856 RVA: 0x0000A11C File Offset: 0x0000831C
		protected virtual void OnPaint(float dt, Vec2 pos)
		{
		}

		// Token: 0x06000359 RID: 857 RVA: 0x0000A11E File Offset: 0x0000831E
		protected virtual void OnPaintGrab(float x, float y)
		{
		}

		// Token: 0x0600035A RID: 858 RVA: 0x0000A120 File Offset: 0x00008320
		protected virtual void OnEndPaint()
		{
			this.DestroyBrush();
			UndoManager.CommitUndo();
			base.Parent.EnableShortcuts = true;
		}

		// Token: 0x0600035B RID: 859 RVA: 0x0000A139 File Offset: 0x00008339
		protected virtual void OnShortcutDelta(float delta)
		{
			this.m_radius.Value += delta * 0.5f;
		}

		// Token: 0x0600035C RID: 860 RVA: 0x0000A154 File Offset: 0x00008354
		public virtual void Update(float dt)
		{
			if (!this.m_grabMode.Value && (this.m_painting == ToolPaint.PaintingMode.Plus || this.m_painting == ToolPaint.PaintingMode.Minus))
			{
				this.OnPaint(dt, this.m_cursorPos.XY);
			}
			if (this.m_cursorValid && this.m_cursorEnabled)
			{
				bool flag = Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl);
				Color color = flag ? Colors.Black : Colors.White;
				Color borderColor = flag ? Colors.White : Colors.Black;
				float length = (Camera.Position - this.m_cursorPos).Length;
				if (this.m_square.Value)
				{
					Render.DrawTerrainSquare(this.m_cursorPos.XY, this.m_radius.Value, length * 0.01f, color, 0f, 0f, borderColor);
					Render.DrawTerrainSquare(this.m_cursorPos.XY, this.m_radius.Value * this.m_hardness.Value, length * 0.01f, Colors.Yellow, 0.001f, 0f);
				}
				else
				{
					Render.DrawTerrainCircle(this.m_cursorPos.XY, this.m_radius.Value, length * 0.01f, color, 0f, 0f, borderColor);
					Render.DrawTerrainCircle(this.m_cursorPos.XY, this.m_radius.Value * this.m_hardness.Value, length * 0.01f, Colors.Yellow, 0.001f, 0f);
				}
				Render.DrawTerrainCircle(this.m_cursorPos.XY, length * 0.00375f, length * 0.0075f, color, 0f, 0f, borderColor);
			}
		}

		// Token: 0x0600035D RID: 861 RVA: 0x0000A308 File Offset: 0x00008508
		protected void CreateBrush()
		{
			if (this.m_brush.IsValid)
			{
				this.DestroyBrush();
			}
			this.m_brush = PaintBrush.Create(!this.m_square.Value, this.m_radius.Value, this.m_hardness.Value, this.m_opacity.Value, this.m_distortion.Value * this.m_radius.Value * 0.7f);
		}

		// Token: 0x0600035E RID: 862 RVA: 0x0000A37F File Offset: 0x0000857F
		protected void DestroyBrush()
		{
			this.m_brush.Destroy();
		}

		// Token: 0x0600035F RID: 863 RVA: 0x0000A38C File Offset: 0x0000858C
		private void FinishPainting()
		{
			switch (this.m_painting)
			{
			case ToolPaint.PaintingMode.Plus:
			case ToolPaint.PaintingMode.Minus:
				this.OnEndPaint();
				break;
			}
			this.m_cursorPos.Z = TerrainManager.GetHeightAtWithWater(this.m_cursorPos.XY);
			Vec2 captureMousePos;
			if (Editor.GetScreenPointFromWorldPos(this.m_cursorPos, out captureMousePos, true))
			{
				Editor.Viewport.CaptureMousePos = captureMousePos;
			}
			Editor.Viewport.CaptureMouse = false;
			Editor.Viewport.CameraEnabled = true;
			this.m_painting = ToolPaint.PaintingMode.None;
		}

		// Token: 0x04000158 RID: 344
		protected ParamBool m_square = new ParamBool(Localizer.Localize("PARAM_SQUARE_BRUSH", null), false);

		// Token: 0x04000159 RID: 345
		protected ParamFloat m_radius = new ParamFloat(Localizer.Localize("PARAM_RADIUS", null), 8f, 1f, 128f, 0.5f);

		// Token: 0x0400015A RID: 346
		protected ParamFloat m_hardness = new ParamFloat(Localizer.Localize("PARAM_HARDNESS", null), 0.3f, 0f, 1f, 0.01f);

		// Token: 0x0400015B RID: 347
		protected ParamFloat m_opacity = new ParamFloat(Localizer.Localize("PARAM_SPEED", null), 0.5f, 0f, 1f, 0.01f);

		// Token: 0x0400015C RID: 348
		protected ParamFloat m_distortion = new ParamFloat(Localizer.Localize("PARAM_DISTORTION", null), 0f, 0f, 1f, 0.01f);

		// Token: 0x0400015D RID: 349
		protected ParamBool m_grabMode = new ParamBool(Localizer.Localize("PARAM_GRAB_MODE", null), false);

		// Token: 0x0400015E RID: 350
		protected ToolPaint.PaintingMode m_painting;

		// Token: 0x0400015F RID: 351
		protected Vec3 m_cursorPos;

		// Token: 0x04000160 RID: 352
		protected bool m_cursorValid;

		// Token: 0x04000161 RID: 353
		protected bool m_cursorEnabled = true;

		// Token: 0x04000162 RID: 354
		protected PaintBrush m_brush;

		// Token: 0x0200004E RID: 78
		public enum PaintingMode
		{
			// Token: 0x04000164 RID: 356
			None,
			// Token: 0x04000165 RID: 357
			Plus,
			// Token: 0x04000166 RID: 358
			Minus,
			// Token: 0x04000167 RID: 359
			Shortcut
		}
	}
}
