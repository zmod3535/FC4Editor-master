using System;

namespace IGE.Nomad
{
	// Token: 0x020000AC RID: 172
	internal class Validation
	{
		// Token: 0x060006EC RID: 1772 RVA: 0x00019399 File Offset: 0x00017599
		public static ValidationReport ValidateObjective(ulong objectiveDescId)
		{
			return new ValidationReport(Binding.FCE_Validation_Objective(objectiveDescId));
		}

		// Token: 0x060006ED RID: 1773 RVA: 0x000193AB File Offset: 0x000175AB
		public static ValidationReport ValidateGame()
		{
			return new ValidationReport(Binding.FCE_Validation_Game());
		}
	}
}
