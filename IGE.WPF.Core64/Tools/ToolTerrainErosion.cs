using System;
using System.Collections.Generic;
using System.Text;
using IGE.Nomad;
using IGE.Parameters;

namespace IGE.Tools
{
	// Token: 0x020000E4 RID: 228
	internal class ToolTerrainErosion : ToolPaint
	{
		// Token: 0x06000820 RID: 2080 RVA: 0x0001BF30 File Offset: 0x0001A130
		public ToolTerrainErosion() : base(Localizer.Localize("TOOL_TERRAIN_EROSION", null), "toolbar/terrain/TerrainEdit_Erosion.png")
		{
			this.m_square.Value = true;
		}

		// Token: 0x06000821 RID: 2081 RVA: 0x0001C230 File Offset: 0x0001A430
		protected override IEnumerable<Parameter> GetParameters()
		{
			foreach (Parameter param in base._GetParameters())
			{
				if (param != this.m_square)
				{
					yield return param;
				}
			}
			yield return this._density;
			yield return this._deformation;
			yield return this._channelDepth;
			yield break;
		}

		// Token: 0x06000822 RID: 2082 RVA: 0x0001C250 File Offset: 0x0001A450
		public override string GetContextHelp()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(base.GetPaintNoReverseContextHelp()).Append("\r\n");
			stringBuilder.Append(base.GetShortcutContextHelp()).Append("\r\n");
			stringBuilder.Append("\r\n");
			stringBuilder.Append(Localizer.Localize("HELP_TOOL_EROSION", null));
			return stringBuilder.ToString();
		}

		// Token: 0x06000823 RID: 2083 RVA: 0x0001C2B8 File Offset: 0x0001A4B8
		protected override void OnPaint(float dt, Vec2 pos)
		{
			base.OnPaint(dt, pos);
			TerrainManipulator.Erosion(pos, this.m_radius.Value, this._density.Value, this._deformation.Value, this._channelDepth.Value, this._randomness.Value);
		}

		// Token: 0x06000824 RID: 2084 RVA: 0x0001C30A File Offset: 0x0001A50A
		protected override void OnEndPaint()
		{
			base.OnEndPaint();
			TerrainManipulator.Erosion_End();
		}

		// Token: 0x040003F2 RID: 1010
		private readonly ParamFloat _density = new ParamFloat(Localizer.Localize("PARAM_DENSITY", null), 0.5f, 0f, 1f, 0.01f);

		// Token: 0x040003F3 RID: 1011
		private readonly ParamFloat _deformation = new ParamFloat(Localizer.Localize("PARAM_DEFORMATION", null), 0.5f, 0f, 1f, 0.01f);

		// Token: 0x040003F4 RID: 1012
		private readonly ParamFloat _channelDepth = new ParamFloat(Localizer.Localize("PARAM_LAND_SLIDE", null), 0.5f, 0f, 1f, 0.01f);

		// Token: 0x040003F5 RID: 1013
		private readonly ParamFloat _randomness = new ParamFloat("Randomness", 0f, 0f, 1f, 0.01f);
	}
}
