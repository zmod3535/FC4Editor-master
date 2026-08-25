using System;

namespace IGE.Nomad
{
	// Token: 0x0200011D RID: 285
	internal class GamePropertyFilter
	{
		// Token: 0x060009F3 RID: 2547 RVA: 0x00020DD5 File Offset: 0x0001EFD5
		public GamePropertyFilter(ObjectiveType objectiveType)
		{
			this.m_objectiveId = objectiveType.Id;
		}

		// Token: 0x060009F4 RID: 2548 RVA: 0x00020DE9 File Offset: 0x0001EFE9
		public bool Validate(GameProperty gameProperty)
		{
			return gameProperty.SupportedObjectives.Contains(this.m_objectiveId);
		}

		// Token: 0x040004CA RID: 1226
		private ulong m_objectiveId;
	}
}
