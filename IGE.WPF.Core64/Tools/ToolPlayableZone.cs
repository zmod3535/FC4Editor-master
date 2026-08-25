using System;
using System.Collections.Generic;
using IGE.Nomad;
using IGE.Parameters;

namespace IGE.Tools
{
	// Token: 0x02000113 RID: 275
	internal class ToolPlayableZone : ToolSpline
	{
		// Token: 0x06000992 RID: 2450 RVA: 0x000201DC File Offset: 0x0001E3DC
		public ToolPlayableZone() : base(Localizer.Localize("TOOL_PLAYABLE_ZONE", null), "toolbar/objects/PlayableZone.png")
		{
			this._actionReset.ButtonCommand.ExecuteDelegate = delegate(object o)
			{
				this.action_Reset();
			};
		}

		// Token: 0x06000993 RID: 2451 RVA: 0x00020334 File Offset: 0x0001E534
		protected override IEnumerable<Parameter> GetParameters()
		{
			yield return this._paramEditTool;
			yield return this._actionReset;
			yield break;
		}

		// Token: 0x06000994 RID: 2452 RVA: 0x00020351 File Offset: 0x0001E551
		public override string GetContextHelp()
		{
			return Localizer.LocalizeCommon("HELP_TOOL_PLAYABLEZONE") + "\r\n\r\n" + base.GetSplineHelp();
		}

		// Token: 0x06000995 RID: 2453 RVA: 0x0002036D File Offset: 0x0001E56D
		private void action_Reset()
		{
			UndoManager.RecordUndo();
			SplineManager.GetPlayableZone().Reset();
			UndoManager.CommitUndo();
		}

		// Token: 0x06000996 RID: 2454 RVA: 0x00020383 File Offset: 0x0001E583
		public override void Activate()
		{
			base.Activate();
			base.SetSpline(SplineManager.GetPlayableZone());
		}

		// Token: 0x040004A0 RID: 1184
		private readonly ParamButton _actionReset = new ParamButton(Localizer.Localize("PARAM_RESET", null));
	}
}
