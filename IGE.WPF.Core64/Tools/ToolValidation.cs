using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Media;
using IGE.Helpers;
using IGE.Nomad;
using IGE.Parameters;

namespace IGE.Tools
{
	// Token: 0x02000072 RID: 114
	internal class ToolValidation : Tool
	{
		// Token: 0x0600049D RID: 1181 RVA: 0x00012054 File Offset: 0x00010254
		public ToolValidation() : base(Localizer.Localize("TOOL_VALIDATION", null), "toolbar/main/Validation.png")
		{
			this._paramReport = new ParamEnumList(Localizer.Localize("PARAM_MAP_REPORT", null), null, new ParamEnumBase.ValueChangedDelegate(this.ValidationRecordSelection));
			this._paramReport.OnItemDoubleClicked += this.HintErrorSource;
		}

		// Token: 0x0600049E RID: 1182 RVA: 0x000121CC File Offset: 0x000103CC
		protected override IEnumerable<Parameter> GetParameters()
		{
			yield return this._paramReport;
			yield break;
		}

		// Token: 0x0600049F RID: 1183 RVA: 0x000121EC File Offset: 0x000103EC
		public void ValidationRecordSelection(object sender, object oldValue, object newValue)
		{
			ValidationRecord validationRecord = newValue as ValidationRecord;
			if (validationRecord == null || validationRecord.Object == null || validationRecord.Severity == ValidationRecord.Severities.Success)
			{
				return;
			}
			Camera.Focus(validationRecord.Object);
		}

		// Token: 0x060004A0 RID: 1184 RVA: 0x00012228 File Offset: 0x00010428
		private void HintErrorSource(object selection)
		{
			ParamEnumBase.Entry entry = selection as ParamEnumBase.Entry;
			ValidationRecord validationRecord = (entry != null) ? (entry.Value as ValidationRecord) : null;
			if (validationRecord == null || validationRecord.Severity == ValidationRecord.Severities.Success)
			{
				return;
			}
			bool flag = validationRecord.Object == null || validationRecord.Object.IsValid;
			if (!flag && validationRecord.ErrorCode != ValidationRecord.Code.SUCCESS)
			{
				switch (validationRecord.ErrorCode)
				{
				case ValidationRecord.Code.WAVE1_EMPTY:
					if (this.RequestWaveTool1 != null)
					{
						this.RequestWaveTool1();
						return;
					}
					break;
				case ValidationRecord.Code.WAVE2_EMPTY:
					if (this.RequestWaveTool2 != null)
					{
						this.RequestWaveTool2();
						return;
					}
					break;
				case ValidationRecord.Code.MISSING_GAMEPLAY_OBJ:
					if (this.RequestAddToolGameplayObjects != null)
					{
						this.RequestAddToolGameplayObjects();
						return;
					}
					break;
				case ValidationRecord.Code.MISSING_SNAPSHOT:
					if (this.RequestToolProperties != null)
					{
						this.RequestToolProperties();
						return;
					}
					break;
				case ValidationRecord.Code.NAVMESH_ERROR:
					EditorSettings.ShowNavmesh(Navmesh.Layer.Character);
					return;
				default:
					return;
				}
			}
			else if (flag)
			{
				Camera.Focus(validationRecord.Object);
			}
		}

		// Token: 0x060004A1 RID: 1185 RVA: 0x0001230F File Offset: 0x0001050F
		public SingleParameter GetMainParameter()
		{
			return this._paramReport;
		}

		// Token: 0x060004A2 RID: 1186 RVA: 0x00012317 File Offset: 0x00010517
		public override string GetContextHelp()
		{
			return Localizer.LocalizeCommon("HELP_TOPIC_VALIDATION");
		}

		// Token: 0x060004A3 RID: 1187 RVA: 0x00012323 File Offset: 0x00010523
		public override void Activate()
		{
			this._isValidationReady = Binding.FCE_Navmesh_IsReady();
			if (!this._isValidationReady)
			{
				Binding.FCE_WaitScreen_Show(Localizer.LocalizeCommon(348828U), false, false, false);
			}
			this.UpdateReports();
		}

		// Token: 0x060004A4 RID: 1188 RVA: 0x0001235A File Offset: 0x0001055A
		public override void Deactivate()
		{
			if (!this._isValidationReady)
			{
				Binding.FCE_Navmesh_Validate();
				Binding.FCE_WaitScreen_Hide();
			}
		}

		// Token: 0x060004A5 RID: 1189 RVA: 0x00012378 File Offset: 0x00010578
		public void OnSwitchFrom(Tool prevTool)
		{
		}

		// Token: 0x060004A6 RID: 1190 RVA: 0x0001237A File Offset: 0x0001057A
		public void OnSwitchTo(Tool nextTool)
		{
		}

		// Token: 0x060004A7 RID: 1191 RVA: 0x0001237C File Offset: 0x0001057C
		private void GetReportList(ValidationReport report, ref List<ParamEnumListItem> lines, bool skipSuccess = false)
		{
			for (int i = 0; i < report.Count; i++)
			{
				ValidationRecord validationRecord = report[i];
				bool flag = (validationRecord.Severity & ValidationRecord.Severities.Success) != (ValidationRecord.Severities)0;
				if (!flag || !skipSuccess)
				{
					ImageSource image;
					if (flag)
					{
						image = this._imgValid;
					}
					else if ((validationRecord.Severity & ValidationRecord.Severities.Error) != (ValidationRecord.Severities)0)
					{
						image = this._imgError;
					}
					else
					{
						image = this._imgWarning;
					}
					lines.Add(new ParamEnumListItem(validationRecord.Message, image, validationRecord));
				}
			}
		}

		// Token: 0x060004A8 RID: 1192 RVA: 0x000123F4 File Offset: 0x000105F4
		private void UpdateReports()
		{
			if (this._isValidationReady)
			{
				ulong objectiveDescId = Binding.FCE_GameMode_GetCurrentObjectiveDescId();
				ValidationReport report = Validation.ValidateObjective(objectiveDescId);
				ValidationReport report2 = Validation.ValidateGame();
				List<ParamEnumListItem> collection = new List<ParamEnumListItem>();
				this.GetReportList(report, ref collection, false);
				this.GetReportList(report2, ref collection, true);
				this._paramReport.DisplayName = Localizer.Localize("PARAM_MAP_REPORT", null);
				this._paramReport.Values = new ObservableCollection<ParamEnumBase.Entry>(collection);
				return;
			}
			Binding.FCE_GameMode_GetCurrentObjectiveDescId();
			List<ParamEnumListItem> list = new List<ParamEnumListItem>();
			list.Add(new ParamEnumListItem(Localizer.LocalizeCommon(348828U), this._imgHourglass, null));
			this._paramReport.DisplayName = Localizer.Localize("PARAM_MAP_REPORT", null);
			this._paramReport.Values = new ObservableCollection<ParamEnumBase.Entry>(list);
		}

		// Token: 0x060004A9 RID: 1193 RVA: 0x000124BC File Offset: 0x000106BC
		public override void UpdateTool(float dt)
		{
			bool isValidationReady = this._isValidationReady;
			this._isValidationReady = Binding.FCE_Navmesh_IsReady();
			if (!this._isValidationReady)
			{
				Binding.FCE_Navmesh_Sync(16);
			}
			if (this._isValidationReady && !isValidationReady)
			{
				Binding.FCE_Navmesh_Validate();
				Binding.FCE_WaitScreen_Hide();
				this.UpdateReports();
			}
		}

		// Token: 0x04000204 RID: 516
		public Action RequestWaveTool1;

		// Token: 0x04000205 RID: 517
		public Action RequestWaveTool2;

		// Token: 0x04000206 RID: 518
		public Action RequestAddToolGameplayObjects;

		// Token: 0x04000207 RID: 519
		public Action RequestToolProperties;

		// Token: 0x04000208 RID: 520
		private readonly ImageSource _imgError = "error16.png".GetImageSource();

		// Token: 0x04000209 RID: 521
		private readonly ImageSource _imgWarning = "warning16.png".GetImageSource();

		// Token: 0x0400020A RID: 522
		private readonly ImageSource _imgValid = "valid16.png".GetImageSource();

		// Token: 0x0400020B RID: 523
		private readonly ImageSource _imgHourglass = "hourglass.png".GetImageSource();

		// Token: 0x0400020C RID: 524
		private readonly ParamEnumList _paramReport;

		// Token: 0x0400020D RID: 525
		private bool _isValidationReady;
	}
}
