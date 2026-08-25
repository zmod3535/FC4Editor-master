using System;
using System.Collections.Generic;
using System.Windows.Input;
using System.Windows.Media;
using IGE.Nomad;
using IGE.Parameters;

namespace IGE.Tools
{
	// Token: 0x02000050 RID: 80
	internal abstract class ToolPaintStrict : Tool, IInputSink
	{
		// Token: 0x06000367 RID: 871 RVA: 0x0000A868 File Offset: 0x00008A68
		protected ToolPaintStrict(string displayName, string image) : base(displayName, image)
		{
		}

		// Token: 0x06000368 RID: 872 RVA: 0x0000A974 File Offset: 0x00008B74
		protected IEnumerable<Parameter> _GetParameters()
		{
			yield return this._radius;
			yield break;
		}

		// Token: 0x06000369 RID: 873 RVA: 0x0000A991 File Offset: 0x00008B91
		protected override IEnumerable<Parameter> GetParameters()
		{
			return this._GetParameters();
		}

		// Token: 0x0600036A RID: 874 RVA: 0x0000A999 File Offset: 0x00008B99
		public virtual SingleParameter GetMainParameter()
		{
			return null;
		}

		// Token: 0x0600036B RID: 875 RVA: 0x0000A99C File Offset: 0x00008B9C
		public override void Activate()
		{
			base.Parent.CursorPhysics = false;
			Vec3 cursorPos = default(Vec3);
			this._cursorValid = Editor.RayCastTerrainFromMouse(out cursorPos);
			this.UpdateCursorPos(cursorPos);
		}

		// Token: 0x0600036C RID: 876 RVA: 0x0000A9D1 File Offset: 0x00008BD1
		public override void Deactivate()
		{
			base.Parent.CursorPhysics = true;
		}

		// Token: 0x0600036D RID: 877 RVA: 0x0000A9DF File Offset: 0x00008BDF
		public virtual void OnSwitchFrom(Tool prevTool)
		{
		}

		// Token: 0x0600036E RID: 878 RVA: 0x0000A9E1 File Offset: 0x00008BE1
		public virtual void OnSwitchTo(Tool nextTool)
		{
		}

		// Token: 0x0600036F RID: 879 RVA: 0x0000A9E3 File Offset: 0x00008BE3
		public virtual void OnInputAcquire()
		{
		}

		// Token: 0x06000370 RID: 880 RVA: 0x0000A9E5 File Offset: 0x00008BE5
		public virtual void OnInputRelease()
		{
		}

		// Token: 0x06000371 RID: 881 RVA: 0x0000A9E8 File Offset: 0x00008BE8
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
						this.UpdateCursorPos(cursorPos);
						this.OnBeginPaint();
					}
				}
				else
				{
					this._painting = ToolPaintStrict.PaintingMode.Shortcut;
				}
				if (this._painting != ToolPaintStrict.PaintingMode.None)
				{
					Editor.Viewport.CaptureMouse = true;
					Editor.Viewport.CameraEnabled = false;
				}
				break;
			case Editor.MouseEvent.MouseUp:
				if (this._painting != ToolPaintStrict.PaintingMode.None)
				{
					switch (this._painting)
					{
					case ToolPaintStrict.PaintingMode.Plus:
					case ToolPaintStrict.PaintingMode.Minus:
						this.OnEndPaint();
						break;
					}
					this._cursorPos.Z = TerrainManager.GetHeightAtWithWater(this._cursorPos.XY);
					Vec2 captureMousePos;
					if (Editor.GetScreenPointFromWorldPos(this._cursorPos, out captureMousePos, true))
					{
						Editor.Viewport.CaptureMousePos = captureMousePos;
					}
					Editor.Viewport.CaptureMouse = false;
					Editor.Viewport.CameraEnabled = true;
					this._painting = ToolPaintStrict.PaintingMode.None;
				}
				break;
			case Editor.MouseEvent.MouseMove:
				switch (this._painting)
				{
				case ToolPaintStrict.PaintingMode.None:
				case ToolPaintStrict.PaintingMode.Plus:
				case ToolPaintStrict.PaintingMode.Minus:
				{
					Vec3 cursorPos2;
					this._cursorValid = Editor.RayCastTerrainFromMouse(out cursorPos2);
					this.UpdateCursorPos(cursorPos2);
					break;
				}
				}
				break;
			case Editor.MouseEvent.MouseMoveDelta:
				switch (this._painting)
				{
				case ToolPaintStrict.PaintingMode.Plus:
				case ToolPaintStrict.PaintingMode.Minus:
				{
					Vec3 cursorPos3 = this._cursorPos;
					Editor.ApplyScreenDeltaToWorldPos(new Vec2((float)mouseEventArgs.X / (float)Editor.Viewport.Width, (float)mouseEventArgs.Y / (float)Editor.Viewport.Height), ref cursorPos3);
					cursorPos3.Z = TerrainManager.GetHeightAtWithWater(cursorPos3.XY);
					this.UpdateCursorPos(cursorPos3);
					break;
				}
				case ToolPaintStrict.PaintingMode.Shortcut:
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

		// Token: 0x06000372 RID: 882 RVA: 0x0000ABD5 File Offset: 0x00008DD5
		public virtual bool OnKeyEvent(Editor.KeyEvent keyEvent, Editor.KeyEventArgs keyEventArgs)
		{
			return false;
		}

		// Token: 0x06000373 RID: 883 RVA: 0x0000ABD8 File Offset: 0x00008DD8
		public virtual void OnEditorEvent(uint eventType, IntPtr eventPtr)
		{
		}

		// Token: 0x06000374 RID: 884 RVA: 0x0000ABDC File Offset: 0x00008DDC
		protected void UpdateCursorPos(Vec3 cursorPos)
		{
			this._cursorPos = cursorPos;
			int num = (int)Math.Round((double)this._radius.Value);
			float num2 = (float)(num % 2) * 0.5f;
			this._snappedPos.X = (float)Math.Round((double)(cursorPos.X + num2)) - num2;
			this._snappedPos.Y = (float)Math.Round((double)(cursorPos.Y + num2)) - num2;
			this._snappedPos.Z = cursorPos.Z;
			float num3 = (float)num / 2f;
			this._snappedRect = new Win32.Rect((int)Math.Round((double)(this._snappedPos.X - num3)), (int)Math.Round((double)(this._snappedPos.Y - num3)), num, num);
			this._snappedPos.X = (float)(this._snappedRect.left + this._snappedRect.right) / 2f;
			this._snappedPos.Y = (float)(this._snappedRect.top + this._snappedRect.bottom) / 2f;
		}

		// Token: 0x06000375 RID: 885 RVA: 0x0000ACEA File Offset: 0x00008EEA
		protected virtual void OnBeginPaint()
		{
			base.Parent.EnableShortcuts = false;
			this._painting = ((Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)) ? ToolPaintStrict.PaintingMode.Minus : ToolPaintStrict.PaintingMode.Plus);
			UndoManager.RecordUndo();
		}

		// Token: 0x06000376 RID: 886 RVA: 0x0000AD19 File Offset: 0x00008F19
		protected virtual void OnPaint()
		{
		}

		// Token: 0x06000377 RID: 887 RVA: 0x0000AD1B File Offset: 0x00008F1B
		protected virtual void OnEndPaint()
		{
			UndoManager.CommitUndo();
			base.Parent.EnableShortcuts = true;
			TerrainManipulator.Hole_End();
		}

		// Token: 0x06000378 RID: 888 RVA: 0x0000AD33 File Offset: 0x00008F33
		protected virtual void OnShortcutDelta(float delta)
		{
			this._radius.Value += delta * 0.05f;
		}

		// Token: 0x06000379 RID: 889 RVA: 0x0000AD50 File Offset: 0x00008F50
		public virtual void Update(float dt)
		{
			this.UpdateCursorPos(this._cursorPos);
			if (this._painting == ToolPaintStrict.PaintingMode.Plus || this._painting == ToolPaintStrict.PaintingMode.Minus)
			{
				this.OnPaint();
			}
			if (this._cursorValid)
			{
				bool flag = Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl);
				Color color = flag ? Colors.Black : Colors.White;
				Color borderColor = flag ? Colors.White : Colors.Black;
				float length = (Camera.Position - this._snappedPos).Length;
				Render.DrawTerrainSquare(this._snappedPos.XY, (float)this._snappedRect.Width / 2f, length * 0.01f, color, 0f, 0f, borderColor);
				Render.DrawTerrainCircle(this._cursorPos.XY, length * 0.00375f, length * 0.0075f, color, 0f, 0f, borderColor);
			}
		}

		// Token: 0x0400016B RID: 363
		protected ToolPaintStrict.PaintingMode _painting;

		// Token: 0x0400016C RID: 364
		protected Vec3 _cursorPos;

		// Token: 0x0400016D RID: 365
		protected Vec3 _snappedPos;

		// Token: 0x0400016E RID: 366
		protected Win32.Rect _snappedRect;

		// Token: 0x0400016F RID: 367
		protected bool _cursorValid;

		// Token: 0x04000170 RID: 368
		protected ParamFloat _radius = new ParamFloat(Localizer.Localize("PARAM_RADIUS", null), 8f, 1f, 128f, 1f);

		// Token: 0x02000051 RID: 81
		public enum PaintingMode
		{
			// Token: 0x04000172 RID: 370
			None,
			// Token: 0x04000173 RID: 371
			Plus,
			// Token: 0x04000174 RID: 372
			Minus,
			// Token: 0x04000175 RID: 373
			Shortcut
		}
	}
}
