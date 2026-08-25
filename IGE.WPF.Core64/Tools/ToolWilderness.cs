using System;
using System.Collections.Generic;
using IGE.Nomad;
using IGE.Parameters;
using Ubisoft.AttachedCommandBehavior;

namespace IGE.Tools
{
	// Token: 0x02000064 RID: 100
	internal class ToolWilderness : Tool
	{
		// Token: 0x06000456 RID: 1110 RVA: 0x00011164 File Offset: 0x0000F364
		public ToolWilderness() : base("<!>Wilderness", "error.png")
		{
			SimpleCommand buttonCommand = this._actionGenerate.ButtonCommand;
			buttonCommand.ExecuteDelegate = (Action<object>)Delegate.Combine(buttonCommand.ExecuteDelegate, new Action<object>(delegate(object o)
			{
				this.action_Generate();
			}));
		}

		// Token: 0x06000457 RID: 1111 RVA: 0x00011440 File Offset: 0x0000F640
		protected override IEnumerable<Parameter> GetParameters()
		{
			yield return this._wip;
			yield return this._gradientWidth;
			yield return this._gradientHeight;
			yield return this._distortion;
			yield return this._noiseAdd;
			yield return this._blurRadius;
			yield return this._actionGenerate;
			yield break;
		}

		// Token: 0x06000458 RID: 1112 RVA: 0x0001145D File Offset: 0x0000F65D
		public Parameter GetMainParameter()
		{
			return null;
		}

		// Token: 0x06000459 RID: 1113 RVA: 0x00011460 File Offset: 0x0000F660
		public override string GetContextHelp()
		{
			return "WORK IN PROGRESS!!!\n\nThis tool is currently under heavy development and should not be evaluated! You can fool around with it if you wish though. =P";
		}

		// Token: 0x0600045A RID: 1114 RVA: 0x00011467 File Offset: 0x0000F667
		private void action_Generate()
		{
			Wilderness.GenerateDesert(this._gradientWidth.Value, this._gradientHeight.Value, this._distortion.Value, this._noiseAdd.Value, this._blurRadius.Value);
		}

		// Token: 0x040001E8 RID: 488
		private readonly ParamText _wip = new ParamText("/!\\ WORK IN PROGRESS /!\\");

		// Token: 0x040001E9 RID: 489
		private readonly ParamFloat _gradientWidth = new ParamFloat("Gradient Width", 13f, 4f, 64f, 0.01f);

		// Token: 0x040001EA RID: 490
		private readonly ParamFloat _gradientHeight = new ParamFloat("Gradient Height", 4.7f, 0f, 32f, 0.01f);

		// Token: 0x040001EB RID: 491
		private readonly ParamFloat _distortion = new ParamFloat("Distortion", 3.84f, 0f, 32f, 0.01f);

		// Token: 0x040001EC RID: 492
		private readonly ParamFloat _noiseAdd = new ParamFloat("Noise height", 12.34f, 0f, 32f, 0.01f);

		// Token: 0x040001ED RID: 493
		private readonly ParamFloat _blurRadius = new ParamFloat("Blur radius", 16f, 0f, 32f, 0.01f);

		// Token: 0x040001EE RID: 494
		private readonly ParamButton _actionGenerate = new ParamButton("Generate");
	}
}
