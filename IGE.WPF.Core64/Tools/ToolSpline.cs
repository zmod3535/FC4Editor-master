using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using IGE.Nomad;
using IGE.Parameters;

namespace IGE.Tools
{
	// Token: 0x02000110 RID: 272
	internal abstract class ToolSpline : Tool, IInputSink
	{
		// Token: 0x0600097C RID: 2428 RVA: 0x0001F734 File Offset: 0x0001D934
		public ToolSpline(string display, string image) : base(display, image)
		{
			this._paramEditTool = new ParamEnumButton(Localizer.Localize("PARAM_SPLINE_MODE", null), new ParamEnumButtonImage[]
			{
				this._select = new ParamEnumButtonImage(Localizer.Localize("PARAM_SPLINE_MODE_SELECT", null), "tools/maplimits/select.png", ToolSpline.EditTool.Select),
				this._paint = new ParamEnumButtonImage(Localizer.Localize("PARAM_SPLINE_MODE_DRAW", null), "tools/maplimits/brush.png", ToolSpline.EditTool.Paint),
				this._add = new ParamEnumButtonImage(Localizer.Localize("PARAM_SPLINE_MODE_ADD", null), "tools/maplimits/add.png", ToolSpline.EditTool.Add),
				this._remove = new ParamEnumButtonImage(Localizer.Localize("PARAM_SPLINE_MODE_REMOVE", null), "tools/maplimits/remove.png", ToolSpline.EditTool.Remove)
			});
			this._paramEditTool.Value = ToolSpline.EditTool.Select;
		}

		// Token: 0x0600097D RID: 2429 RVA: 0x0001F81D File Offset: 0x0001DA1D
		public virtual Parameter GetMainParameter()
		{
			return null;
		}

		// Token: 0x0600097E RID: 2430 RVA: 0x0001F820 File Offset: 0x0001DA20
		public string GetSplineHelp()
		{
			return Localizer.Localize("HELP_SPLINE", null);
		}

		// Token: 0x0600097F RID: 2431 RVA: 0x0001F830 File Offset: 0x0001DA30
		protected void SetSpline(Spline spline)
		{
			this.m_spline = spline;
			this.m_splineController.SetSpline(this.m_spline);
			if (this.m_spline.IsValid)
			{
				this.m_spline.UpdateSplineHeight();
			}
			this._paramEditTool.Enabled = this.m_spline.IsValid;
		}

		// Token: 0x06000980 RID: 2432 RVA: 0x0001F883 File Offset: 0x0001DA83
		public override void Activate()
		{
			base.Parent.CursorPhysics = false;
			this.m_splineController = SplineController.Create();
		}

		// Token: 0x06000981 RID: 2433 RVA: 0x0001F89C File Offset: 0x0001DA9C
		public override void Deactivate()
		{
			base.Parent.CursorPhysics = true;
			this.m_splineController.Dispose();
			this.m_spline = Spline.Null;
			this.m_state = ToolSpline.State.None;
		}

		// Token: 0x06000982 RID: 2434 RVA: 0x0001F8C7 File Offset: 0x0001DAC7
		public override void OnSwitchFrom(ToolBase prevTool)
		{
		}

		// Token: 0x06000983 RID: 2435 RVA: 0x0001F8C9 File Offset: 0x0001DAC9
		public override void OnSwitchTo(ToolBase nextTool)
		{
		}

		// Token: 0x06000984 RID: 2436 RVA: 0x0001F8CB File Offset: 0x0001DACB
		public void OnInputAcquire()
		{
		}

		// Token: 0x06000985 RID: 2437 RVA: 0x0001F8CD File Offset: 0x0001DACD
		public void OnInputRelease()
		{
		}

		// Token: 0x06000986 RID: 2438 RVA: 0x0001F8D0 File Offset: 0x0001DAD0
		protected bool TestPoints()
		{
			bool flag = this.m_spline.HitTestPoints(Editor.Viewport.NormalizedMousePos, 0.005f, 0.015f, out this.m_hitPoint, out this.m_hitPos2);
			if (flag)
			{
				this.m_hitDelta = this.m_hitPos2 - Editor.Viewport.NormalizedMousePos;
			}
			return flag;
		}

		// Token: 0x06000987 RID: 2439 RVA: 0x0001F928 File Offset: 0x0001DB28
		protected bool TestSegments()
		{
			Vec3 vec;
			Vec3 vec2;
			Editor.GetWorldRayFromScreenPoint(Editor.Viewport.NormalizedMousePos, out vec, out vec2);
			Vec3 vec3;
			return Editor.RayCastTerrainFromScreenPoint(Editor.Viewport.NormalizedMousePos, out vec3) && this.m_spline.HitTestSegments(vec3.XY, 4f, out this.m_hitPoint, out this.m_hitPos2);
		}

		// Token: 0x06000988 RID: 2440 RVA: 0x0001F980 File Offset: 0x0001DB80
		protected void StartDrag(SplineController.SelectMode dragMode)
		{
			this.m_state = ToolSpline.State.Dragging;
			this.m_dragStart = Editor.Viewport.NormalizedMousePos;
			this.m_dragMode = dragMode;
		}

		// Token: 0x06000989 RID: 2441 RVA: 0x0001F9A0 File Offset: 0x0001DBA0
		protected void MovePointsToMouse(bool add)
		{
			if (this.m_hitPoint >= 0)
			{
				Vec3 raySrc;
				Vec3 rayDir;
				Editor.GetWorldRayFromScreenPoint(Editor.Viewport.NormalizedMousePos + this.m_hitDelta, out raySrc, out rayDir);
				Vec3 vec;
				float num;
				if (Editor.RayCastTerrain(raySrc, rayDir, out vec, out num))
				{
					if (add && this.m_spline.IsValid && this.m_spline.Count < 100)
					{
						if (this.m_forward)
						{
							if ((vec.XY - this.m_spline[this.m_hitPoint - 1]).Length > 15f)
							{
								this.m_spline.InsertPoint(vec.XY, this.m_hitPoint);
								this.m_hitPoint++;
								if (this.m_hitPoint > 2 && this.m_spline.OptimizePoint(this.m_hitPoint - 2))
								{
									this.m_hitPoint--;
								}
							}
							this.m_splineController.ClearSelection();
							this.m_splineController.SetSelected(this.m_hitPoint, true);
						}
						else if (!this.m_forward)
						{
							if ((vec.XY - this.m_spline[this.m_hitPoint + 1]).Length > 15f)
							{
								this.m_spline.InsertPoint(vec.XY, this.m_hitPoint);
								if (this.m_hitPoint + 2 < this.m_spline.Count - 1)
								{
									this.m_spline.OptimizePoint(this.m_hitPoint + 2);
								}
							}
							this.m_splineController.ClearSelection();
							this.m_splineController.SetSelected(this.m_hitPoint, true);
						}
					}
					this.m_splineController.MoveSelection(vec.XY - this.m_spline[this.m_hitPoint]);
					this.m_spline.UpdateSpline();
				}
			}
		}

		// Token: 0x0600098A RID: 2442 RVA: 0x0001FB8C File Offset: 0x0001DD8C
		protected void RemovePointUnderMouse()
		{
			if (this.TestPoints())
			{
				this.m_splineController.ClearSelection();
				this.m_splineController.SetSelected(this.m_hitPoint, true);
				this.m_splineController.DeleteSelection();
				this.m_spline.RemoveSimilarPoints();
				this.m_spline.UpdateSpline();
			}
		}

		// Token: 0x0600098B RID: 2443 RVA: 0x0001FBE0 File Offset: 0x0001DDE0
		public bool OnMouseEvent(Editor.MouseEvent mouseEvent, Editor.MouseEventArgs mouseEventArgs)
		{
			switch (mouseEvent)
			{
			case Editor.MouseEvent.MouseDown:
				if (this.m_spline.IsValid)
				{
					UndoManager.RecordUndo();
					switch ((ToolSpline.EditTool)this._paramEditTool.Value)
					{
					case ToolSpline.EditTool.Select:
						if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
						{
							this.StartDrag(SplineController.SelectMode.Toggle);
						}
						else if (Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift))
						{
							this.StartDrag(SplineController.SelectMode.Add);
						}
						else if (this.TestPoints())
						{
							if (!this.m_splineController.IsSelected(this.m_hitPoint))
							{
								this.m_splineController.ClearSelection();
								this.m_splineController.SetSelected(this.m_hitPoint, true);
							}
							this.m_state = ToolSpline.State.Moving;
						}
						else
						{
							this.StartDrag(SplineController.SelectMode.Replace);
						}
						break;
					case ToolSpline.EditTool.Paint:
					case ToolSpline.EditTool.Add:
					{
						this.m_hitPoint = -1;
						this.m_hitDelta = new Vec2(0f, 0f);
						Vec3 vec;
						if (this.m_spline.Count < 100 && Editor.RayCastTerrainFromMouse(out vec))
						{
							if (this.m_spline.Count <= 1)
							{
								if (this.m_spline.Count < 1)
								{
									this.m_spline.AddPoint(vec.XY);
								}
								this.m_spline.AddPoint(vec.XY);
								this.m_hitPoint = 1;
							}
							else if (this.TestPoints())
							{
								if (this.m_hitPoint == 0)
								{
									this.m_spline.InsertPoint(vec.XY, 0);
								}
								else if (this.m_hitPoint == this.m_spline.Count - 1)
								{
									this.m_spline.InsertPoint(vec.XY, this.m_hitPoint + 1);
									this.m_hitPoint++;
								}
							}
							else if (this.TestSegments())
							{
								this.m_hitPoint++;
								this.m_spline.InsertPoint(vec.XY, this.m_hitPoint);
							}
							if (this.m_hitPoint != -1)
							{
								this.m_splineController.ClearSelection();
								this.m_splineController.SetSelected(this.m_hitPoint, true);
								this.m_spline.UpdateSpline();
								if ((ToolSpline.EditTool)this._paramEditTool.Value == ToolSpline.EditTool.Paint)
								{
									this.m_state = ToolSpline.State.Drawing;
									if (this.m_hitPoint == 0)
									{
										this.m_forward = false;
									}
									else if (this.m_hitPoint == this.m_spline.Count - 1)
									{
										this.m_forward = true;
									}
									else
									{
										this.m_state = ToolSpline.State.Moving;
									}
								}
								else
								{
									this.m_state = ToolSpline.State.Moving;
								}
							}
						}
						break;
					}
					case ToolSpline.EditTool.Remove:
						this.RemovePointUnderMouse();
						this.m_state = ToolSpline.State.Removing;
						break;
					}
					if (this.m_state != ToolSpline.State.None)
					{
						base.Parent.EnableShortcuts = false;
					}
					else
					{
						UndoManager.CommitUndo();
					}
				}
				break;
			case Editor.MouseEvent.MouseUp:
				if (this.m_spline.IsValid && this.m_state != ToolSpline.State.None)
				{
					UndoManager.CommitUndo();
					switch (this.m_state)
					{
					case ToolSpline.State.Dragging:
					{
						Rect dragRectangle = this.DragRectangle;
						this.m_splineController.SelectFromScreenRect(dragRectangle, 0.015f, this.m_dragMode);
						break;
					}
					case ToolSpline.State.Drawing:
					{
						bool flag = false;
						if (this.m_forward && this.m_hitPoint >= 1)
						{
							flag = this.m_spline.OptimizePoint(this.m_hitPoint - 1);
						}
						else if (!this.m_forward && this.m_hitPoint < this.m_spline.Count - 1)
						{
							flag = this.m_spline.OptimizePoint(this.m_hitPoint + 1);
						}
						if (flag)
						{
							this.m_spline.UpdateSpline();
						}
						break;
					}
					}
					if (this.m_spline.RemoveSimilarPoints())
					{
						this.m_spline.UpdateSpline();
						this.m_splineController.ClearSelection();
					}
					if (this.m_state != ToolSpline.State.None)
					{
						this.m_spline.FinalizeSpline();
						base.Parent.EnableShortcuts = true;
					}
					this.m_hitPoint = -1;
					this.m_state = ToolSpline.State.None;
				}
				break;
			case Editor.MouseEvent.MouseMove:
				if (this.m_spline.IsValid)
				{
					switch (this.m_state)
					{
					case ToolSpline.State.Moving:
						this.MovePointsToMouse(false);
						break;
					case ToolSpline.State.Drawing:
						this.MovePointsToMouse(true);
						break;
					case ToolSpline.State.Removing:
						this.RemovePointUnderMouse();
						break;
					}
				}
				break;
			}
			return false;
		}

		// Token: 0x0600098C RID: 2444 RVA: 0x0002001C File Offset: 0x0001E21C
		public bool OnKeyEvent(Editor.KeyEvent keyEvent, Editor.KeyEventArgs keyEventArgs)
		{
			if (keyEvent == Editor.KeyEvent.KeyUp && keyEventArgs.KeyCode == Key.Delete)
			{
				this.DeleteSelection();
				this.m_spline.RemoveSimilarPoints();
				return true;
			}
			return false;
		}

		// Token: 0x0600098D RID: 2445 RVA: 0x0002004E File Offset: 0x0001E24E
		public virtual void OnEditorEvent(uint eventType, IntPtr eventPtr)
		{
		}

		// Token: 0x0600098E RID: 2446 RVA: 0x00020050 File Offset: 0x0001E250
		public void Update(float dt)
		{
			if (this.m_spline.IsValid)
			{
				this.m_spline.Draw(0.005f, this.m_splineController);
			}
			ToolSpline.State state = this.m_state;
			if (state != ToolSpline.State.Dragging)
			{
				return;
			}
			Rect dragRectangle = this.DragRectangle;
			if (this.IsDragRectangle(dragRectangle))
			{
				Render.DrawScreenRectangleOutlined(dragRectangle, 1f, 0.00125f, Colors.White);
			}
		}

		// Token: 0x0600098F RID: 2447 RVA: 0x000200B1 File Offset: 0x0001E2B1
		protected void DeleteSelection()
		{
			UndoManager.RecordUndo();
			if (this.m_spline.IsValid)
			{
				this.m_splineController.DeleteSelection();
				this.m_spline.UpdateSpline();
			}
			UndoManager.CommitUndo();
		}

		// Token: 0x1700021F RID: 543
		// (get) Token: 0x06000990 RID: 2448 RVA: 0x000200E0 File Offset: 0x0001E2E0
		protected Rect DragRectangle
		{
			get
			{
				Vec2 dragStart = this.m_dragStart;
				Vec2 normalizedMousePos = Editor.Viewport.NormalizedMousePos;
				Vec2 vec = new Vec2(Math.Min(dragStart.X, normalizedMousePos.X), Math.Min(dragStart.Y, normalizedMousePos.Y));
				Vec2 vec2 = new Vec2(Math.Max(dragStart.X, normalizedMousePos.X), Math.Max(dragStart.Y, normalizedMousePos.Y));
				return new Rect((double)vec.X, (double)vec.Y, (double)(vec2.X - vec.X), (double)(vec2.Y - vec.Y));
			}
		}

		// Token: 0x06000991 RID: 2449 RVA: 0x00020190 File Offset: 0x0001E390
		protected bool IsDragRectangle(Rect rect)
		{
			return rect.Size.Width > 0.009999999776482582 && rect.Size.Height > 0.009999999776482582;
		}

		// Token: 0x04000483 RID: 1155
		protected const float penWidth = 0.005f;

		// Token: 0x04000484 RID: 1156
		protected const float hitWidth = 0.015f;

		// Token: 0x04000485 RID: 1157
		protected const int maxSplinePoints = 100;

		// Token: 0x04000486 RID: 1158
		protected ParamEnumButtonImage _select;

		// Token: 0x04000487 RID: 1159
		protected ParamEnumButtonImage _paint;

		// Token: 0x04000488 RID: 1160
		protected ParamEnumButtonImage _add;

		// Token: 0x04000489 RID: 1161
		protected ParamEnumButtonImage _remove;

		// Token: 0x0400048A RID: 1162
		protected ParamEnumButton _paramEditTool;

		// Token: 0x0400048B RID: 1163
		protected bool m_forward;

		// Token: 0x0400048C RID: 1164
		protected ToolSpline.State m_state;

		// Token: 0x0400048D RID: 1165
		protected Vec2 m_dragStart;

		// Token: 0x0400048E RID: 1166
		protected SplineController.SelectMode m_dragMode;

		// Token: 0x0400048F RID: 1167
		protected float m_drawLastUpdate;

		// Token: 0x04000490 RID: 1168
		protected int m_hitPoint = -1;

		// Token: 0x04000491 RID: 1169
		protected Vec2 m_hitPos2;

		// Token: 0x04000492 RID: 1170
		protected Vec2 m_hitDelta;

		// Token: 0x04000493 RID: 1171
		protected Spline m_spline;

		// Token: 0x04000494 RID: 1172
		protected SplineController m_splineController;

		// Token: 0x02000111 RID: 273
		public enum EditTool
		{
			// Token: 0x04000496 RID: 1174
			Select,
			// Token: 0x04000497 RID: 1175
			Paint,
			// Token: 0x04000498 RID: 1176
			Add,
			// Token: 0x04000499 RID: 1177
			Remove
		}

		// Token: 0x02000112 RID: 274
		protected enum State
		{
			// Token: 0x0400049B RID: 1179
			None,
			// Token: 0x0400049C RID: 1180
			Dragging,
			// Token: 0x0400049D RID: 1181
			Moving,
			// Token: 0x0400049E RID: 1182
			Drawing,
			// Token: 0x0400049F RID: 1183
			Removing
		}
	}
}
