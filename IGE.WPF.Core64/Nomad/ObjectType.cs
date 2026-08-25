using System;

namespace IGE.Nomad
{
	// Token: 0x020000EF RID: 239
	[Flags]
	public enum ObjectType
	{
		// Token: 0x04000408 RID: 1032
		eEnemy = 1,
		// Token: 0x04000409 RID: 1033
		eAlly = 2,
		// Token: 0x0400040A RID: 1034
		eAnimal = 4,
		// Token: 0x0400040B RID: 1035
		eSpawner = 8,
		// Token: 0x0400040C RID: 1036
		eSTP = 16,
		// Token: 0x0400040D RID: 1037
		eWeapon = 32,
		// Token: 0x0400040E RID: 1038
		eVehicle = 64,
		// Token: 0x0400040F RID: 1039
		eLight = 128,
		// Token: 0x04000410 RID: 1040
		ePhysics = 256,
		// Token: 0x04000411 RID: 1041
		eGameplay = 512,
		// Token: 0x04000412 RID: 1042
		eAlarm = 1024,
		// Token: 0x04000413 RID: 1043
		eSpawnPoint = 2048,
		// Token: 0x04000414 RID: 1044
		eToolsOnly = 4096,
		// Token: 0x04000415 RID: 1045
		eSTPNoHeavy = 8192,
		// Token: 0x04000416 RID: 1046
		eSTPNoHunter = 16384,
		// Token: 0x04000417 RID: 1047
		eSTPAnimals = 32768,
		// Token: 0x04000418 RID: 1048
		eSTPHumanoids = 65536,
		// Token: 0x04000419 RID: 1049
		eAmmo = 131072,
		// Token: 0x0400041A RID: 1050
		eVehicleMobile = 262144,
		// Token: 0x0400041B RID: 1051
		eAmbientOnly = 524288,
		// Token: 0x0400041C RID: 1052
		eTrees = 1048576,
		// Token: 0x0400041D RID: 1053
		ePlants = 2097152,
		// Token: 0x0400041E RID: 1054
		eOther = 0
	}
}
