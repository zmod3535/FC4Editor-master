using System;

namespace IGE.Nomad
{
	// Token: 0x02000014 RID: 20
	internal class EditorSettings
	{
		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000071 RID: 113 RVA: 0x00002B72 File Offset: 0x00000D72
		// (set) Token: 0x06000072 RID: 114 RVA: 0x00002B7E File Offset: 0x00000D7E
		public static bool ShowCollections
		{
			get
			{
				return Binding.FCE_EditorSettings_IsCollectionVisible();
			}
			set
			{
				Binding.FCE_EditorSettings_ShowCollections(value);
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000073 RID: 115 RVA: 0x00002B8B File Offset: 0x00000D8B
		// (set) Token: 0x06000074 RID: 116 RVA: 0x00002B97 File Offset: 0x00000D97
		public static bool ShowFog
		{
			get
			{
				return Binding.FCE_EditorSettings_IsFogVisible();
			}
			set
			{
				Binding.FCE_EditorSettings_ShowFog(value);
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000075 RID: 117 RVA: 0x00002BA4 File Offset: 0x00000DA4
		// (set) Token: 0x06000076 RID: 118 RVA: 0x00002BB0 File Offset: 0x00000DB0
		public static bool ShowExposure
		{
			get
			{
				return Binding.FCE_EditorSettings_IsExposureVisible();
			}
			set
			{
				Binding.FCE_EditorSettings_ShowExposure(value);
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000077 RID: 119 RVA: 0x00002BBD File Offset: 0x00000DBD
		// (set) Token: 0x06000078 RID: 120 RVA: 0x00002BC9 File Offset: 0x00000DC9
		public static bool ShowShadow
		{
			get
			{
				return Binding.FCE_EditorSettings_IsShadowVisible();
			}
			set
			{
				Binding.FCE_EditorSettings_ShowShadow(value);
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000079 RID: 121 RVA: 0x00002BD6 File Offset: 0x00000DD6
		// (set) Token: 0x0600007A RID: 122 RVA: 0x00002BE2 File Offset: 0x00000DE2
		public static bool ShowWater
		{
			get
			{
				return Binding.FCE_EditorSettings_IsWaterVisible();
			}
			set
			{
				Binding.FCE_EditorSettings_ShowWater(value);
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x0600007B RID: 123 RVA: 0x00002BEF File Offset: 0x00000DEF
		// (set) Token: 0x0600007C RID: 124 RVA: 0x00002BFB File Offset: 0x00000DFB
		public static bool ShowIcons
		{
			get
			{
				return Binding.FCE_EditorSettings_IsIconsVisible();
			}
			set
			{
				Binding.FCE_EditorSettings_ShowIcons(value);
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x0600007D RID: 125 RVA: 0x00002C08 File Offset: 0x00000E08
		// (set) Token: 0x0600007E RID: 126 RVA: 0x00002C14 File Offset: 0x00000E14
		public static bool SoundEnabled
		{
			get
			{
				return Binding.FCE_EditorSettings_IsSoundEnabled();
			}
			set
			{
				Binding.FCE_EditorSettings_SetSoundEnabled(value);
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x0600007F RID: 127 RVA: 0x00002C21 File Offset: 0x00000E21
		// (set) Token: 0x06000080 RID: 128 RVA: 0x00002C2D File Offset: 0x00000E2D
		public static bool ShowGrid
		{
			get
			{
				return Binding.FCE_EditorSettings_IsGridVisible();
			}
			set
			{
				Binding.FCE_EditorSettings_ShowGrid(value);
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000081 RID: 129 RVA: 0x00002C3A File Offset: 0x00000E3A
		// (set) Token: 0x06000082 RID: 130 RVA: 0x00002C46 File Offset: 0x00000E46
		public static int GridResolution
		{
			get
			{
				return Binding.FCE_EditorSettings_GetGridResolution();
			}
			set
			{
				Binding.FCE_EditorSettings_SetGridResolution(value);
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000083 RID: 131 RVA: 0x00002C53 File Offset: 0x00000E53
		// (set) Token: 0x06000084 RID: 132 RVA: 0x00002C5F File Offset: 0x00000E5F
		public static bool ShowBudgetGrid
		{
			get
			{
				return Binding.FCE_EditorSettings_IsBudgetGridVisible();
			}
			set
			{
				Binding.FCE_EditorSettings_ShowBudgetGrid(value);
				EditorSettings.m_showBudgetGridPcOverride = value;
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000085 RID: 133 RVA: 0x00002C72 File Offset: 0x00000E72
		// (set) Token: 0x06000086 RID: 134 RVA: 0x00002C79 File Offset: 0x00000E79
		public static bool ShowBudgetGridPcOverride
		{
			get
			{
				return EditorSettings.m_showBudgetGridPcOverride;
			}
			set
			{
				EditorSettings.m_showBudgetGridPcOverride = value;
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000087 RID: 135 RVA: 0x00002C81 File Offset: 0x00000E81
		public static bool IsNavmeshVisible
		{
			get
			{
				return Binding.FCE_EditorSettings_IsNavmeshVisible();
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000088 RID: 136 RVA: 0x00002C8D File Offset: 0x00000E8D
		public static Navmesh.Layer NavmeshLayer
		{
			get
			{
				return (Navmesh.Layer)Binding.FCE_EditorSettings_GetNavmeshLayer();
			}
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00002C99 File Offset: 0x00000E99
		public static void ShowNavmesh(Navmesh.Layer layer)
		{
			Binding.FCE_EditorSettings_ShowNavmesh((int)layer);
		}

		// Token: 0x0600008A RID: 138 RVA: 0x00002CA6 File Offset: 0x00000EA6
		public static void HideNavmesh()
		{
			Binding.FCE_EditorSettings_HideNavmesh();
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x0600008B RID: 139 RVA: 0x00002CB2 File Offset: 0x00000EB2
		// (set) Token: 0x0600008C RID: 140 RVA: 0x00002CBE File Offset: 0x00000EBE
		public static bool ShowCovers
		{
			get
			{
				return Binding.FCE_EditorSettings_IsCoversVisible();
			}
			set
			{
				Binding.FCE_EditorSettings_ShowCovers(value);
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x0600008D RID: 141 RVA: 0x00002CCB File Offset: 0x00000ECB
		// (set) Token: 0x0600008E RID: 142 RVA: 0x00002CD7 File Offset: 0x00000ED7
		public static bool Invincible
		{
			get
			{
				return Binding.FCE_EditorSettings_IsInvincible();
			}
			set
			{
				Binding.FCE_EditorSettings_SetInvincible(value);
			}
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x0600008F RID: 143 RVA: 0x00002CE4 File Offset: 0x00000EE4
		// (set) Token: 0x06000090 RID: 144 RVA: 0x00002CF0 File Offset: 0x00000EF0
		public static bool Invisible
		{
			get
			{
				return Binding.FCE_EditorSettings_IsInvisible();
			}
			set
			{
				Binding.FCE_EditorSettings_SetInvisible(value);
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000091 RID: 145 RVA: 0x00002CFD File Offset: 0x00000EFD
		// (set) Token: 0x06000092 RID: 146 RVA: 0x00002D09 File Offset: 0x00000F09
		public static bool SnapObjectsToTerrain
		{
			get
			{
				return Binding.FCE_EditorSettings_IsSnappingObjectsToTerrain();
			}
			set
			{
				Binding.FCE_EditorSettings_SetSnapObjectsToTerrain(value);
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000093 RID: 147 RVA: 0x00002D16 File Offset: 0x00000F16
		// (set) Token: 0x06000094 RID: 148 RVA: 0x00002D22 File Offset: 0x00000F22
		public static bool AutoSnappingObjects
		{
			get
			{
				return Binding.FCE_EditorSettings_IsAutoSnappingObjects();
			}
			set
			{
				Binding.FCE_EditorSettings_SetAutoSnappingObjects(value);
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000095 RID: 149 RVA: 0x00002D2F File Offset: 0x00000F2F
		// (set) Token: 0x06000096 RID: 150 RVA: 0x00002D3B File Offset: 0x00000F3B
		public static bool AutoSnappingObjectsRotation
		{
			get
			{
				return Binding.FCE_EditorSettings_IsAutoSnappingObjectsRotation();
			}
			set
			{
				Binding.FCE_EditorSettings_SetAutoSnappingObjectsRotation(value);
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000097 RID: 151 RVA: 0x00002D48 File Offset: 0x00000F48
		// (set) Token: 0x06000098 RID: 152 RVA: 0x00002D54 File Offset: 0x00000F54
		public static bool AutoSnappingObjectsTerrain
		{
			get
			{
				return Binding.FCE_EditorSettings_IsAutoSnappingObjectsTerrain();
			}
			set
			{
				Binding.FCE_EditorSettings_SetAutoSnappingObjectsTerrain(value);
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x06000099 RID: 153 RVA: 0x00002D61 File Offset: 0x00000F61
		// (set) Token: 0x0600009A RID: 154 RVA: 0x00002D6D File Offset: 0x00000F6D
		public static bool CameraClipTerrain
		{
			get
			{
				return Binding.FCE_EditorSettings_IsCameraClippedTerrain();
			}
			set
			{
				Binding.FCE_EditorSettings_SetCameraClipTerrain(value);
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x0600009B RID: 155 RVA: 0x00002D7A File Offset: 0x00000F7A
		// (set) Token: 0x0600009C RID: 156 RVA: 0x00002D86 File Offset: 0x00000F86
		public static bool CameraCollision
		{
			get
			{
				return Binding.FCE_EditorSettings_IsCameraCollision();
			}
			set
			{
				Binding.FCE_EditorSettings_SetCameraCollision(value);
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x0600009D RID: 157 RVA: 0x00002D93 File Offset: 0x00000F93
		// (set) Token: 0x0600009E RID: 158 RVA: 0x00002D9F File Offset: 0x00000F9F
		public static EditorSettings.QualityLevel EngineQuality
		{
			get
			{
				return (EditorSettings.QualityLevel)Binding.FCE_EditorSettings_GetEngineQuality();
			}
			set
			{
				Binding.FCE_EditorSettings_SetEngineQuality((int)value);
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x0600009F RID: 159 RVA: 0x00002DAC File Offset: 0x00000FAC
		public static bool IsNvidia
		{
			get
			{
				return Binding.IsNvidia();
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x060000A0 RID: 160 RVA: 0x00002DB8 File Offset: 0x00000FB8
		// (set) Token: 0x060000A1 RID: 161 RVA: 0x00002DBF File Offset: 0x00000FBF
		public static float ViewportQuality
		{
			get
			{
				return EditorSettings.m_viewportQuality;
			}
			set
			{
				EditorSettings.m_viewportQuality = value;
			}
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x060000A2 RID: 162 RVA: 0x00002DC7 File Offset: 0x00000FC7
		// (set) Token: 0x060000A3 RID: 163 RVA: 0x00002DD3 File Offset: 0x00000FD3
		public static bool KillDistanceOverride
		{
			get
			{
				return Binding.FCE_EditorSettings_IsKillDistanceOverride();
			}
			set
			{
				Binding.FCE_EditorSettings_SetKillDistanceOverride(value);
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x060000A4 RID: 164 RVA: 0x00002DE0 File Offset: 0x00000FE0
		// (set) Token: 0x060000A5 RID: 165 RVA: 0x00002DE7 File Offset: 0x00000FE7
		public static bool InvertMouseView
		{
			get
			{
				return EditorSettings.m_invertMouseView;
			}
			set
			{
				EditorSettings.m_invertMouseView = value;
			}
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x060000A6 RID: 166 RVA: 0x00002DEF File Offset: 0x00000FEF
		// (set) Token: 0x060000A7 RID: 167 RVA: 0x00002DF6 File Offset: 0x00000FF6
		public static bool InvertMousePan
		{
			get
			{
				return EditorSettings.m_invertMousePan;
			}
			set
			{
				EditorSettings.m_invertMousePan = value;
			}
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x060000A8 RID: 168 RVA: 0x00002DFE File Offset: 0x00000FFE
		// (set) Token: 0x060000A9 RID: 169 RVA: 0x00002E0A File Offset: 0x0000100A
		public static bool IsOcclusionVisible
		{
			get
			{
				return Binding.FCE_EditorSettings_IsOcclusionVisible();
			}
			set
			{
				Binding.FCE_EditorSettings_ShowOcclusion(value);
			}
		}

		// Token: 0x0400001F RID: 31
		private static bool m_showBudgetGridPcOverride = false;

		// Token: 0x04000020 RID: 32
		private static float m_viewportQuality = 1f;

		// Token: 0x04000021 RID: 33
		private static bool m_invertMouseView;

		// Token: 0x04000022 RID: 34
		private static bool m_invertMousePan;

		// Token: 0x02000015 RID: 21
		public enum QualityLevel
		{
			// Token: 0x04000024 RID: 36
			Low,
			// Token: 0x04000025 RID: 37
			Medium,
			// Token: 0x04000026 RID: 38
			High,
			// Token: 0x04000027 RID: 39
			VeryHigh,
			// Token: 0x04000028 RID: 40
			UltraHigh,
			// Token: 0x04000029 RID: 41
			Nvidia,
			// Token: 0x0400002A RID: 42
			Custom
		}
	}
}
