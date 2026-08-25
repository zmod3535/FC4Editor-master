using System;
using System.Runtime.InteropServices;

namespace IGE.Nomad
{
	// Token: 0x02000045 RID: 69
	internal class Wilderness
	{
		// Token: 0x06000314 RID: 788 RVA: 0x00009895 File Offset: 0x00007A95
		public static void GenerateDesert(float gradientWidth, float gradientHeight, float distorsion, float noiseAdd, float blurRadius)
		{
			Binding.FCE_Wilderness_Desert(gradientWidth, gradientHeight, distorsion, noiseAdd, blurRadius);
		}

		// Token: 0x06000315 RID: 789 RVA: 0x000098A7 File Offset: 0x00007AA7
		public static void RunScript(string scriptName)
		{
			Binding.FCE_Wilderness_Script(scriptName);
		}

		// Token: 0x06000316 RID: 790 RVA: 0x000098B4 File Offset: 0x00007AB4
		public static void RunScriptBuffer(string buffer, Wilderness.MapCallback mapCallback, Wilderness.ErrorCallback errorCallback)
		{
			Binding.FCE_Wilderness_ScriptBuffer(buffer, buffer.Length, new Binding.ScriptMapCallback(mapCallback.Invoke), new Binding.ScriptErrorCallback(errorCallback.Invoke));
		}

		// Token: 0x06000317 RID: 791 RVA: 0x000098DF File Offset: 0x00007ADF
		public static void RunScriptEntry(string path)
		{
			Binding.FCE_Wilderness_Script(path);
		}

		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x06000318 RID: 792 RVA: 0x000098EC File Offset: 0x00007AEC
		public static int NumFunctions
		{
			get
			{
				return Binding.FCE_Script_GetNumFunctions();
			}
		}

		// Token: 0x06000319 RID: 793 RVA: 0x000098F8 File Offset: 0x00007AF8
		public static Wilderness.FunctionDef GetFunction(int index)
		{
			return new Wilderness.FunctionDef(Binding.FCE_Script_GetFunction(index));
		}

		// Token: 0x02000046 RID: 70
		// (Invoke) Token: 0x0600031C RID: 796
		public delegate void MapCallback(int line, IntPtr map);

		// Token: 0x02000047 RID: 71
		// (Invoke) Token: 0x06000320 RID: 800
		public delegate void ErrorCallback(int line, string errorMessage);

		// Token: 0x02000048 RID: 72
		public struct FunctionDef
		{
			// Token: 0x06000323 RID: 803 RVA: 0x00009912 File Offset: 0x00007B12
			public FunctionDef(IntPtr ptr)
			{
				this.m_pointer = ptr;
			}

			// Token: 0x170000CA RID: 202
			// (get) Token: 0x06000324 RID: 804 RVA: 0x0000991B File Offset: 0x00007B1B
			public string Name
			{
				get
				{
					return Marshal.PtrToStringAnsi(Binding.FCE_ScriptFunction_GetName(this.m_pointer));
				}
			}

			// Token: 0x170000CB RID: 203
			// (get) Token: 0x06000325 RID: 805 RVA: 0x00009932 File Offset: 0x00007B32
			public string Prototype
			{
				get
				{
					return Marshal.PtrToStringAnsi(Binding.FCE_ScriptFunction_GetPrototype(this.m_pointer));
				}
			}

			// Token: 0x170000CC RID: 204
			// (get) Token: 0x06000326 RID: 806 RVA: 0x00009949 File Offset: 0x00007B49
			public string Description
			{
				get
				{
					return Marshal.PtrToStringAnsi(Binding.FCE_ScriptFunction_GetDescription(this.m_pointer));
				}
			}

			// Token: 0x0400014E RID: 334
			private IntPtr m_pointer;
		}
	}
}
