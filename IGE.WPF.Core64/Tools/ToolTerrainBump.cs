using System;
using System.Collections.Generic;
using System.Windows.Input;
using IGE.Nomad;
using IGE.Parameters;

namespace IGE.Tools
{
	// Token: 0x02000108 RID: 264
	internal class ToolTerrainBump : ToolPaint
	{
		// Token: 0x06000931 RID: 2353 RVA: 0x0001E890 File Offset: 0x0001CA90
		public ToolTerrainBump() : base(Localizer.Localize("TOOL_TERRAIN_BUMP", null), "toolbar/terrain/TerrainEdit_Bump.png")
		{
		}

		// Token: 0x06000932 RID: 2354 RVA: 0x0001EAC4 File Offset: 0x0001CCC4
		protected override IEnumerable<Parameter> GetParameters()
		{
			foreach (Parameter param in base._GetParameters())
			{
				yield return param;
			}
			yield return this._strength;
			yield return this.m_grabMode;
			yield break;
		}

		// Token: 0x06000933 RID: 2355 RVA: 0x0001EAE4 File Offset: 0x0001CCE4
		public override string GetContextHelp()
		{
			return string.Concat(new string[]
			{
				base.GetPaintContextHelp(),
				"\r\n",
				base.GetShortcutContextHelp(),
				"\r\n\r\n",
				Localizer.LocalizeCommon("HELP_TOOL_BUMP")
			});
		}

		// Token: 0x06000934 RID: 2356 RVA: 0x0001EB30 File Offset: 0x0001CD30
		protected override void OnPaintGrab(float x, float y)
		{
			base.OnPaintGrab(x, y);
			float amount = -y * this._strength.Value * 0.3f;
			TerrainManipulator.Bump(this.m_cursorPos.XY, amount, this.m_brush);
		}

		// Token: 0x06000935 RID: 2357 RVA: 0x0001EB74 File Offset: 0x0001CD74
		protected override void OnPaint(float dt, Vec2 pos)
		{
			base.OnPaint(dt, pos);
			float num = this._strength.Value * 32f * dt;
			TerrainManipulator.Bump(pos, (this.m_painting == ToolPaint.PaintingMode.Plus) ? num : (-num), this.m_brush);
		}

		// Token: 0x06000936 RID: 2358 RVA: 0x0001EBB7 File Offset: 0x0001CDB7
		protected override void OnEndPaint()
		{
			base.OnEndPaint();
			TerrainManipulator.Bump_End();
		}

		// Token: 0x06000937 RID: 2359 RVA: 0x0001EBC4 File Offset: 0x0001CDC4
		public override bool OnKeyEvent(Editor.KeyEvent keyEvent, Editor.KeyEventArgs keyEventArgs)
		{
			if (keyEvent == Editor.KeyEvent.KeyDown && keyEventArgs.KeyCode == Key.G)
			{
				this.m_grabMode.Value = !this.m_grabMode.Value;
				return true;
			}
			return false;
		}

		// Token: 0x04000475 RID: 1141
		private readonly ParamFloat _strength = new ParamFloat(Localizer.Localize("PARAM_SPEED", null), 0.5f, 0f, 1f, 0.01f);
	}
}
