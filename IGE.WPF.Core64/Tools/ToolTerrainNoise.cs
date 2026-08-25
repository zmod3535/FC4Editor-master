using System;
using System.Collections.Generic;
using IGE.Nomad;
using IGE.Parameters;

namespace IGE.Tools
{
	// Token: 0x0200004F RID: 79
	internal class ToolTerrainNoise : ToolPaint
	{
		// Token: 0x06000360 RID: 864 RVA: 0x0000A40C File Offset: 0x0000860C
		public ToolTerrainNoise() : base(Localizer.Localize("TOOL_TERRAIN_NOISE", null), "toolbar/terrain/TerrainEdit_Noise.png")
		{
			this._noiseType = new ParamEnumCombo(Localizer.Localize("PARAM_NOISE_TYPE", null), new ParamEnumText[]
			{
				new ParamEnumText(Localizer.Localize("PARAM_NOISE_RAISE", null), TerrainManipulator.NoiseType.Absolute),
				new ParamEnumText(Localizer.Localize("PARAM_NOISE_LOWER", null), TerrainManipulator.NoiseType.InverseAbsolute),
				new ParamEnumText(Localizer.Localize("PARAM_NOISE_RAISE_LOWER", null), TerrainManipulator.NoiseType.Normal)
			})
			{
				Value = TerrainManipulator.NoiseType.Absolute
			};
		}

		// Token: 0x06000361 RID: 865 RVA: 0x0000A73C File Offset: 0x0000893C
		protected override IEnumerable<Parameter> GetParameters()
		{
			foreach (Parameter param in base._GetParameters())
			{
				yield return param;
			}
			yield return this._strength;
			yield return this._roughness;
			yield return this._noiseType;
			yield return this.m_grabMode;
			yield break;
		}

		// Token: 0x06000362 RID: 866 RVA: 0x0000A75C File Offset: 0x0000895C
		public override string GetContextHelp()
		{
			return string.Concat(new string[]
			{
				base.GetPaintContextHelp(),
				"\r\n",
				base.GetShortcutContextHelp(),
				"\r\n\r\n",
				Localizer.LocalizeCommon("HELP_TOOL_NOISE")
			});
		}

		// Token: 0x06000363 RID: 867 RVA: 0x0000A7A5 File Offset: 0x000089A5
		protected override void OnBeginPaint()
		{
			base.OnBeginPaint();
			TerrainManipulator.Noise_Begin(8, 128f, this._roughness.Value, (TerrainManipulator.NoiseType)this._noiseType.Value);
		}

		// Token: 0x06000364 RID: 868 RVA: 0x0000A7D4 File Offset: 0x000089D4
		protected override void OnPaintGrab(float x, float y)
		{
			base.OnPaintGrab(x, y);
			float amount = -y * this._strength.Value * 0.3f;
			TerrainManipulator.Noise(this.m_cursorPos.XY, amount, this.m_brush);
		}

		// Token: 0x06000365 RID: 869 RVA: 0x0000A818 File Offset: 0x00008A18
		protected override void OnPaint(float dt, Vec2 pos)
		{
			base.OnPaint(dt, pos);
			float num = this._strength.Value * 40f * dt;
			TerrainManipulator.Noise(pos, (this.m_painting == ToolPaint.PaintingMode.Plus) ? num : (-num), this.m_brush);
		}

		// Token: 0x06000366 RID: 870 RVA: 0x0000A85B File Offset: 0x00008A5B
		protected override void OnEndPaint()
		{
			base.OnEndPaint();
			TerrainManipulator.Noise_End();
		}

		// Token: 0x04000168 RID: 360
		private readonly ParamFloat _strength = new ParamFloat(Localizer.Localize("PARAM_SPEED", null), 0.5f, 0f, 1f, 0.01f);

		// Token: 0x04000169 RID: 361
		private readonly ParamFloat _roughness = new ParamFloat(Localizer.Localize("PARAM_ROUGHNESS", null), 0.5f, 0f, 1f, 0.01f);

		// Token: 0x0400016A RID: 362
		private readonly ParamEnumCombo _noiseType;
	}
}
