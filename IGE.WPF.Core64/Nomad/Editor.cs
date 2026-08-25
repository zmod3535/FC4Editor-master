using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Interop;
using IGE.UI;
using Microsoft.Win32;

namespace IGE.Nomad
{
	// Token: 0x02000121 RID: 289
	internal static class Editor
	{
		// Token: 0x06000A0D RID: 2573 RVA: 0x00021300 File Offset: 0x0001F500
		public static void Init()
		{
			Editor.m_delegateUpdateCallback = new Binding.EditorUpdateCallback(Editor.UpdateCallback);
			Binding.FCE_Editor_Update_Callback(Editor.m_delegateUpdateCallback);
			Editor.m_delegateEventCallback = new Binding.EditorEventCallback(Editor.EventCallback);
			Binding.FCE_Editor_Event_Callback(Editor.m_delegateEventCallback);
			Editor.m_delegateLoadCompletedCallback = new Binding.EditorLoadCompletedCallback(Editor.LoadCompletedCallback);
			Binding.FCE_Editor_LoadCompleted_Callback(Editor.m_delegateLoadCompletedCallback);
			Editor.m_delegateSaveCompletedCallback = new Binding.EditorSaveCompletedCallback(Editor.SaveCompletedCallback);
			Binding.FCE_Editor_SaveCompleted_Callback(Editor.m_delegateSaveCompletedCallback);
			Editor.m_delegateEnableUICallback = new Binding.EditorEnableUICallback(Editor.EnableUICallback);
			Binding.FCE_Editor_EnableUI_Callback(Editor.m_delegateEnableUICallback);
			Editor.m_delegateLoginComleteCallback = new Binding.EditorLoginCompleteCallback(Editor.LoginCompleteCallback);
			Binding.FCE_Editor_LoginComlete_Callback(Editor.m_delegateLoginComleteCallback);
			Editor.m_delegatePublishComleteCallback = new Binding.EditorPublishCompleteCallback(Editor.PublishCompleteCallback);
			Binding.FCE_Editor_PublishComlete_Callback(Editor.m_delegatePublishComleteCallback);
			System.Windows.Application.Current.Activated += delegate(object s, EventArgs e)
			{
				Editor.MuteSound(false);
			};
			System.Windows.Application.Current.Deactivated += delegate(object s, EventArgs e)
			{
				Editor.MuteSound(true);
			};
			while (!Binding.FCE_Editor_IsInitialized())
			{
				Binding.TickDuniaEngine();
			}
		}

		// Token: 0x06000A0E RID: 2574 RVA: 0x00021454 File Offset: 0x0001F654
		public static bool CreateGamerProfile()
		{
			Binding.FCE_GamerProfile_Create();
			while (!Binding.FCE_GamerProfile_IsReady())
			{
				Binding.FCE_GamerProfile_UpdateManager();
				if (Binding.FCE_GamerProfile_HasCreationFailed())
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06000A0F RID: 2575 RVA: 0x00021487 File Offset: 0x0001F687
		private static void UpdateCallback(float dt)
		{
			Editor.OnUpdate(dt);
		}

		// Token: 0x06000A10 RID: 2576 RVA: 0x0002148F File Offset: 0x0001F68F
		private static void EventCallback(uint eventType, IntPtr eventPtr)
		{
			Editor.OnEditorEvent(eventType, eventPtr);
		}

		// Token: 0x06000A11 RID: 2577 RVA: 0x00021498 File Offset: 0x0001F698
		private static void LoadCompletedCallback(bool success)
		{
			EditorDocument.OnLoadCompleted(success);
		}

		// Token: 0x06000A12 RID: 2578 RVA: 0x000214A0 File Offset: 0x0001F6A0
		private static void SaveCompletedCallback(bool success)
		{
			EditorDocument.OnSaveCompleted(success);
		}

		// Token: 0x06000A13 RID: 2579 RVA: 0x000214A8 File Offset: 0x0001F6A8
		private static void LoginCompleteCallback(bool success)
		{
			EditorDocument.OnLoginCompleted(success);
		}

		// Token: 0x06000A14 RID: 2580 RVA: 0x000214B0 File Offset: 0x0001F6B0
		private static void PublishCompleteCallback(bool success)
		{
			EditorDocument.OnPublishCompleted(success);
		}

		// Token: 0x06000A15 RID: 2581 RVA: 0x000214B8 File Offset: 0x0001F6B8
		private static void EnableUICallback(bool enable)
		{
			Program.IsUiEnabled = enable;
		}

		// Token: 0x1700023D RID: 573
		// (get) Token: 0x06000A16 RID: 2582 RVA: 0x000214C0 File Offset: 0x0001F6C0
		public static bool IsActive
		{
			get
			{
				return Win32.GetActiveWindow() != IntPtr.Zero && Program.MainWin != null && Win32.IsWindowEnabled(new WindowInteropHelper(Program.MainWin).Handle);
			}
		}

		// Token: 0x1700023E RID: 574
		// (get) Token: 0x06000A17 RID: 2583 RVA: 0x000214F0 File Offset: 0x0001F6F0
		public static bool IsLoadPending
		{
			get
			{
				return Binding.FCE_Editor_IsLoadPending();
			}
		}

		// Token: 0x1700023F RID: 575
		// (get) Token: 0x06000A18 RID: 2584 RVA: 0x000214FC File Offset: 0x0001F6FC
		public static float FrameTime
		{
			get
			{
				return Binding.FCE_Editor_GetFrameTime();
			}
		}

		// Token: 0x06000A19 RID: 2585 RVA: 0x00021508 File Offset: 0x0001F708
		public static bool GetScreenPointFromWorldPos(Vec3 worldPos, out Vec2 screenPoint)
		{
			return Editor.GetScreenPointFromWorldPos(worldPos, out screenPoint, false);
		}

		// Token: 0x06000A1A RID: 2586 RVA: 0x00021514 File Offset: 0x0001F714
		public static bool GetScreenPointFromWorldPos(Vec3 worldPos, out Vec2 screenPoint, bool clipped)
		{
			bool flag = Binding.FCE_Editor_GetScreenPointFromWorldPos(worldPos.X, worldPos.Y, worldPos.Z, out screenPoint.X, out screenPoint.Y);
			if (flag && clipped)
			{
				screenPoint.X = Math.Min(Math.Max(0f, screenPoint.X), 1f);
				screenPoint.Y = Math.Min(Math.Max(0f, screenPoint.Y), 1f);
			}
			return flag;
		}

		// Token: 0x06000A1B RID: 2587 RVA: 0x00021594 File Offset: 0x0001F794
		public static void GetWorldRayFromScreenPoint(Vec2 screenPoint, out Vec3 raySrc, out Vec3 rayDir)
		{
			Binding.FCE_Editor_GetWorldRayFromScreenPoint(screenPoint.X, screenPoint.Y, out raySrc.X, out raySrc.Y, out raySrc.Z, out rayDir.X, out rayDir.Y, out rayDir.Z);
		}

		// Token: 0x06000A1C RID: 2588 RVA: 0x000215E0 File Offset: 0x0001F7E0
		public static bool RayCastTerrain(Vec3 raySrc, Vec3 rayDir, out Vec3 hitPos, out float hitDist)
		{
			return Binding.FCE_Editor_RayCastTerrain(raySrc.X, raySrc.Y, raySrc.Z, rayDir.X, rayDir.Y, rayDir.Z, out hitPos.X, out hitPos.Y, out hitPos.Z, out hitDist);
		}

		// Token: 0x06000A1D RID: 2589 RVA: 0x00021634 File Offset: 0x0001F834
		public static bool RayCastPhysics(Vec3 raySrc, Vec3 rayDir, EditorObject ignore, out Vec3 hitPos, out float hitDist)
		{
			Vec3 vec;
			return Editor.RayCastPhysics(raySrc, rayDir, ignore, out hitPos, out hitDist, out vec);
		}

		// Token: 0x06000A1E RID: 2590 RVA: 0x00021650 File Offset: 0x0001F850
		public static bool RayCastPhysics(Vec3 raySrc, Vec3 rayDir, EditorObject ignore, out Vec3 hitPos, out float hitDist, out Vec3 hitNormal)
		{
			return Binding.FCE_Editor_RayCastPhysics(raySrc.X, raySrc.Y, raySrc.Z, rayDir.X, rayDir.Y, rayDir.Z, ignore.Pointer, out hitPos.X, out hitPos.Y, out hitPos.Z, out hitDist, out hitNormal.X, out hitNormal.Y, out hitNormal.Z);
		}

		// Token: 0x06000A1F RID: 2591 RVA: 0x000216C0 File Offset: 0x0001F8C0
		public static bool RayCastPhysics(Vec3 raySrc, Vec3 rayDir, EditorObjectSelection ignore, out Vec3 hitPos, out float hitDist)
		{
			Vec3 vec;
			return Editor.RayCastPhysics(raySrc, rayDir, ignore, out hitPos, out hitDist, out vec);
		}

		// Token: 0x06000A20 RID: 2592 RVA: 0x000216DC File Offset: 0x0001F8DC
		public static bool RayCastPhysics(Vec3 raySrc, Vec3 rayDir, EditorObjectSelection ignore, out Vec3 hitPos, out float hitDist, out Vec3 hitNormal)
		{
			return Binding.FCE_Editor_RayCastPhysics2(raySrc.X, raySrc.Y, raySrc.Z, rayDir.X, rayDir.Y, rayDir.Z, ignore.Pointer, out hitPos.X, out hitPos.Y, out hitPos.Z, out hitDist, out hitNormal.X, out hitNormal.Y, out hitNormal.Z);
		}

		// Token: 0x17000240 RID: 576
		// (get) Token: 0x06000A21 RID: 2593 RVA: 0x0002174D File Offset: 0x0001F94D
		// (set) Token: 0x06000A22 RID: 2594 RVA: 0x00021754 File Offset: 0x0001F954
		public static Editor.PlayMode CurrentPlayMode { get; private set; }

		// Token: 0x06000A23 RID: 2595 RVA: 0x0002175C File Offset: 0x0001F95C
		public static void EnterIngame(string gameMode, Editor.PlayMode playMode)
		{
			Editor.CurrentPlayMode = playMode;
			bool flag = true;
			if (playMode == Editor.PlayMode.Play)
			{
				if (!Binding.FCE_Editor_ValidateSpawnPoints())
				{
					MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show(Program.MainWin, Localizer.LocalizeCommon("Spawner_Warning_inEditor"), Localizer.Localize("WARNING", null), MessageBoxButton.OKCancel, MessageBoxImage.Exclamation);
					flag = (messageBoxResult == MessageBoxResult.OK);
				}
				else if (!Binding.FCE_Editor_ValidateObjective(true, false))
				{
					MessageBoxResult messageBoxResult2 = System.Windows.MessageBox.Show(Program.MainWin, Localizer.LocalizeCommon("Spawner_Warning_inEditor_SpawnOK"), Localizer.Localize("WARNING", null), MessageBoxButton.OKCancel, MessageBoxImage.Exclamation);
					flag = (messageBoxResult2 == MessageBoxResult.OK);
				}
				else
				{
					if (!Binding.FCE_Navmesh_IsReady())
					{
						Binding.FCE_WaitScreen_Show("", false, false, true);
						Binding.FCE_Navmesh_Sync(-1);
						Binding.FCE_WaitScreen_Hide();
					}
					if (!Binding.FCE_Editor_ValidateObjective(false, true))
					{
						MessageBoxResult messageBoxResult3 = System.Windows.MessageBox.Show(Program.MainWin, Localizer.LocalizeCommon("Spawner_Warning_inEditor_SpawnOK"), Localizer.Localize("WARNING", null), MessageBoxButton.OKCancel, MessageBoxImage.Exclamation);
						flag = (messageBoxResult3 == MessageBoxResult.OK);
					}
				}
			}
			if (flag)
			{
				Program.IsIngame = true;
				Editor._playMode = playMode;
				GameProperties.PushToGameModeManager();
				Binding.FCE_Editor_EnterIngame(gameMode, (int)playMode);
			}
		}

		// Token: 0x06000A24 RID: 2596 RVA: 0x00021872 File Offset: 0x0001FA72
		public static void ExitIngame()
		{
			if (Program.IsIngame)
			{
				Binding.FCE_Editor_ExitIngame();
				Program.IsIngame = false;
			}
		}

		// Token: 0x17000241 RID: 577
		// (get) Token: 0x06000A25 RID: 2597 RVA: 0x0002188B File Offset: 0x0001FA8B
		public static bool IsIngame
		{
			get
			{
				return Binding.FCE_Editor_IsIngame();
			}
		}

		// Token: 0x06000A26 RID: 2598 RVA: 0x00021898 File Offset: 0x0001FA98
		public static bool RayCastTerrainFromScreenPoint(Vec2 screenPoint, out Vec3 hitPos)
		{
			Vec3 raySrc;
			Vec3 rayDir;
			Editor.GetWorldRayFromScreenPoint(screenPoint, out raySrc, out rayDir);
			float num;
			return Editor.RayCastTerrain(raySrc, rayDir, out hitPos, out num);
		}

		// Token: 0x06000A27 RID: 2599 RVA: 0x000218B9 File Offset: 0x0001FAB9
		public static bool RayCastTerrainFromMouse(out Vec3 hitPos)
		{
			return Editor.RayCastTerrainFromScreenPoint(Editor.Viewport.NormalizedMousePos, out hitPos);
		}

		// Token: 0x06000A28 RID: 2600 RVA: 0x000218CC File Offset: 0x0001FACC
		public static bool RayCastPhysicsFromScreenPoint(Vec2 screenPoint, out Vec3 hitPos)
		{
			Vec3 raySrc;
			Vec3 rayDir;
			Editor.GetWorldRayFromScreenPoint(screenPoint, out raySrc, out rayDir);
			float num;
			return Editor.RayCastPhysics(raySrc, rayDir, EditorObject.Null, out hitPos, out num);
		}

		// Token: 0x06000A29 RID: 2601 RVA: 0x000218F2 File Offset: 0x0001FAF2
		public static bool RayCastPhysicsFromMouse(out Vec3 hitPos)
		{
			return Editor.RayCastPhysicsFromScreenPoint(Editor.Viewport.NormalizedMousePos, out hitPos);
		}

		// Token: 0x06000A2A RID: 2602 RVA: 0x00021904 File Offset: 0x0001FB04
		public static void ApplyScreenDeltaToWorldPos(Vec2 screenDelta, ref Vec3 worldPos)
		{
			Vec3 vec = Camera.FrontVector;
			if ((double)Math.Abs(vec.X) < 0.001 && (double)Math.Abs(vec.Y) < 0.001)
			{
				vec = Camera.UpVector;
			}
			Vec2 vec2 = -vec.XY;
			vec2.Normalize();
			Vec2 vec3 = new Vec2(-vec2.Y, vec2.X);
			float num = (float)((double)Vec3.Dot(worldPos - Camera.Position, Camera.FrontVector) * Math.Tan((double)Camera.HalfFOV) * 2.0);
			worldPos.X += num * screenDelta.X * vec3.X + num * screenDelta.Y * vec2.X;
			worldPos.Y += num * screenDelta.X * vec3.Y + num * screenDelta.Y * vec2.Y;
		}

		// Token: 0x06000A2B RID: 2603 RVA: 0x00021A0B File Offset: 0x0001FC0B
		public static void MuteSound(bool mute)
		{
			Binding.FCE_Editor_MuteSound(mute);
		}

		// Token: 0x17000242 RID: 578
		// (get) Token: 0x06000A2C RID: 2604 RVA: 0x00021A18 File Offset: 0x0001FC18
		public static ViewportControl Viewport
		{
			get
			{
				return Program.MainWin.GameViewport;
			}
		}

		// Token: 0x06000A2D RID: 2605 RVA: 0x00021A24 File Offset: 0x0001FC24
		public static void OnMouseEvent(Editor.MouseEvent mouseEvent, Editor.MouseEventArgs mouseEventArgs)
		{
			foreach (IInputSink inputSink in Editor.GetInputs())
			{
				if (inputSink.OnMouseEvent(mouseEvent, mouseEventArgs))
				{
					break;
				}
			}
		}

		// Token: 0x06000A2E RID: 2606 RVA: 0x00021A74 File Offset: 0x0001FC74
		public static bool HandleWindowMessage(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam)
		{
			bool flag = msg == 256 || msg == 260;
			bool flag2 = msg == 257 || msg == 261;
			bool autoRepeat = (lParam.ToInt64() & 1073741824L) != 0L;
			Keys keyData = (Keys)wParam.ToInt64() | Control.ModifierKeys;
			Editor.KeyEventArgs e = new System.Windows.Forms.KeyEventArgs(keyData);
			if (!Engine.ConsoleOpened)
			{
				if (flag)
				{
					Editor.HandleKeyDown(e, autoRepeat);
				}
				else if (flag2)
				{
					Editor.HandleKeyUp(e);
				}
			}
			return flag2 || flag;
		}

		// Token: 0x06000A2F RID: 2607 RVA: 0x00021AFF File Offset: 0x0001FCFF
		public static void HandleKeyDown(Editor.KeyEventArgs e, bool autoRepeat)
		{
			if (e.Alt && e.KeyCode == Key.F4)
			{
				Program.MainWin.Close();
				return;
			}
			if (!autoRepeat)
			{
				Editor.OnKeyEvent(Editor.KeyEvent.KeyDown, e);
			}
			Editor.OnKeyEvent(Editor.KeyEvent.KeyChar, e);
		}

		// Token: 0x06000A30 RID: 2608 RVA: 0x00021B2F File Offset: 0x0001FD2F
		public static void HandleKeyUp(Editor.KeyEventArgs e)
		{
			Editor.OnKeyEvent(Editor.KeyEvent.KeyUp, e);
		}

		// Token: 0x06000A31 RID: 2609 RVA: 0x00021B38 File Offset: 0x0001FD38
		public static void OnEditorEvent(uint eventType, IntPtr eventPtr)
		{
			foreach (IInputSink inputSink in Editor.GetInputs())
			{
				inputSink.OnEditorEvent(eventType, eventPtr);
			}
		}

		// Token: 0x06000A32 RID: 2610 RVA: 0x00021B88 File Offset: 0x0001FD88
		public static void OnUpdate(float dt)
		{
			foreach (IInputSink inputSink in Editor.GetInputs())
			{
				inputSink.Update(dt);
			}
			if (!Editor.IsIngame && Program.IsIngame)
			{
				Program.IsIngame = false;
			}
		}

		// Token: 0x06000A33 RID: 2611 RVA: 0x00021BE8 File Offset: 0x0001FDE8
		public static void PushInput(IInputSink input)
		{
			Trace.Assert(!Editor.m_inputStack.Contains(input));
			if (Editor.m_inputStack.Count > 0)
			{
				Editor.m_inputStack[Editor.m_inputStack.Count - 1].OnInputRelease();
			}
			Editor.m_inputStack.Add(input);
			input.OnInputAcquire();
		}

		// Token: 0x06000A34 RID: 2612 RVA: 0x00021C44 File Offset: 0x0001FE44
		public static void PopInput(IInputSink input)
		{
			int num = Editor.m_inputStack.LastIndexOf(input);
			if (num == -1)
			{
				return;
			}
			Editor.m_inputStack[Editor.m_inputStack.Count - 1].OnInputRelease();
			Editor.m_inputStack.RemoveRange(num, Editor.m_inputStack.Count - num);
			if (Editor.m_inputStack.Count > 0)
			{
				Editor.m_inputStack[Editor.m_inputStack.Count - 1].OnInputAcquire();
			}
		}

		// Token: 0x06000A35 RID: 2613 RVA: 0x00021CBC File Offset: 0x0001FEBC
		public static bool ContainsInput(IInputSink input)
		{
			return Editor.m_inputStack.Contains(input);
		}

		// Token: 0x06000A36 RID: 2614 RVA: 0x00021DC8 File Offset: 0x0001FFC8
		private static IEnumerable<IInputSink> GetInputs()
		{
			for (int i = Editor.m_inputStack.Count - 1; i >= 0; i--)
			{
				yield return Editor.m_inputStack[i];
			}
			yield break;
		}

		// Token: 0x06000A37 RID: 2615 RVA: 0x00021DDE File Offset: 0x0001FFDE
		public static RegistryKey GetRegistrySettings()
		{
			return Registry.CurrentUser.CreateSubKey("Software\\Ubisoft\\FarCry4\\Editor");
		}

		// Token: 0x06000A38 RID: 2616 RVA: 0x00021DF0 File Offset: 0x0001FFF0
		public static int GetRegistryInt(string name, int defaultValue)
		{
			int registryInt;
			using (RegistryKey registrySettings = Editor.GetRegistrySettings())
			{
				registryInt = Editor.GetRegistryInt(registrySettings, name, defaultValue);
			}
			return registryInt;
		}

		// Token: 0x06000A39 RID: 2617 RVA: 0x00021E2C File Offset: 0x0002002C
		public static int GetRegistryInt(RegistryKey key, string name, int defaultValue)
		{
			object value = key.GetValue(name);
			if (value is int)
			{
				return (int)value;
			}
			return defaultValue;
		}

		// Token: 0x06000A3A RID: 2618 RVA: 0x00021E54 File Offset: 0x00020054
		public static double GetRegistryDouble(RegistryKey key, string name, double defaultValue)
		{
			object value = key.GetValue(name);
			if (value is double)
			{
				return (double)value;
			}
			return defaultValue;
		}

		// Token: 0x06000A3B RID: 2619 RVA: 0x00021E7C File Offset: 0x0002007C
		public static string GetRegistryString(RegistryKey key, string name, string defaultValue)
		{
			object value = key.GetValue(name);
			if (value is string)
			{
				return (string)value;
			}
			return defaultValue;
		}

		// Token: 0x06000A3C RID: 2620 RVA: 0x00021EA4 File Offset: 0x000200A4
		public static void SetRegistryInt(string name, int value)
		{
			using (RegistryKey registrySettings = Editor.GetRegistrySettings())
			{
				Editor.SetRegistryInt(registrySettings, name, value);
			}
		}

		// Token: 0x06000A3D RID: 2621 RVA: 0x00021EDC File Offset: 0x000200DC
		public static void SetRegistryInt(RegistryKey key, string name, int value)
		{
			key.SetValue(name, value);
		}

		// Token: 0x06000A3E RID: 2622 RVA: 0x00021EEC File Offset: 0x000200EC
		private static void OnKeyEvent(Editor.KeyEvent keyEvent, Editor.KeyEventArgs keyEventArgs)
		{
			if (!Editor.IsIngame)
			{
				foreach (IInputSink inputSink in Editor.GetInputs())
				{
					if (inputSink.OnKeyEvent(keyEvent, keyEventArgs))
					{
						break;
					}
				}
			}
		}

		// Token: 0x040004CE RID: 1230
		private static Binding.EditorUpdateCallback m_delegateUpdateCallback;

		// Token: 0x040004CF RID: 1231
		private static Binding.EditorEventCallback m_delegateEventCallback;

		// Token: 0x040004D0 RID: 1232
		private static Binding.EditorLoadCompletedCallback m_delegateLoadCompletedCallback;

		// Token: 0x040004D1 RID: 1233
		private static Binding.EditorSaveCompletedCallback m_delegateSaveCompletedCallback;

		// Token: 0x040004D2 RID: 1234
		private static Binding.EditorLoginCompleteCallback m_delegateLoginComleteCallback;

		// Token: 0x040004D3 RID: 1235
		private static Binding.EditorPublishCompleteCallback m_delegatePublishComleteCallback;

		// Token: 0x040004D4 RID: 1236
		private static Binding.EditorEnableUICallback m_delegateEnableUICallback;

		// Token: 0x040004D5 RID: 1237
		private static Editor.PlayMode _playMode;

		// Token: 0x040004D6 RID: 1238
		private static List<IInputSink> m_inputStack = new List<IInputSink>();

		// Token: 0x02000122 RID: 290
		public enum PlayMode
		{
			// Token: 0x040004DB RID: 1243
			Invalid,
			// Token: 0x040004DC RID: 1244
			Play,
			// Token: 0x040004DD RID: 1245
			Explore
		}

		// Token: 0x02000123 RID: 291
		public class MouseEventArgs
		{
			// Token: 0x06000A42 RID: 2626 RVA: 0x00021F50 File Offset: 0x00020150
			public static implicit operator Editor.MouseEventArgs(System.Windows.Forms.MouseEventArgs ea)
			{
				Editor.MouseEventArgs mouseEventArgs = new Editor.MouseEventArgs
				{
					Clicks = ea.Clicks,
					X = ea.X,
					Y = ea.Y,
					Delta = ea.Delta
				};
				if (ea.Button == MouseButtons.None)
				{
					mouseEventArgs.Button = MouseButton.Left;
				}
				else if ((ea.Button & MouseButtons.Left) != MouseButtons.None)
				{
					mouseEventArgs.Button = MouseButton.Left;
				}
				else if ((ea.Button & MouseButtons.Right) != MouseButtons.None)
				{
					mouseEventArgs.Button = MouseButton.Right;
				}
				else if ((ea.Button & MouseButtons.Middle) != MouseButtons.None)
				{
					mouseEventArgs.Button = MouseButton.Middle;
				}
				else if ((ea.Button & MouseButtons.XButton1) != MouseButtons.None)
				{
					mouseEventArgs.Button = MouseButton.XButton1;
				}
				else if ((ea.Button & MouseButtons.XButton2) != MouseButtons.None)
				{
					mouseEventArgs.Button = MouseButton.XButton2;
				}
				else
				{
					mouseEventArgs.Button = MouseButton.Left;
				}
				return mouseEventArgs;
			}

			// Token: 0x17000243 RID: 579
			// (get) Token: 0x06000A43 RID: 2627 RVA: 0x00022021 File Offset: 0x00020221
			// (set) Token: 0x06000A44 RID: 2628 RVA: 0x00022029 File Offset: 0x00020229
			public MouseButton Button { get; private set; }

			// Token: 0x17000244 RID: 580
			// (get) Token: 0x06000A45 RID: 2629 RVA: 0x00022032 File Offset: 0x00020232
			// (set) Token: 0x06000A46 RID: 2630 RVA: 0x0002203A File Offset: 0x0002023A
			public int Clicks { get; private set; }

			// Token: 0x17000245 RID: 581
			// (get) Token: 0x06000A47 RID: 2631 RVA: 0x00022043 File Offset: 0x00020243
			// (set) Token: 0x06000A48 RID: 2632 RVA: 0x0002204B File Offset: 0x0002024B
			public int Delta { get; private set; }

			// Token: 0x17000246 RID: 582
			// (get) Token: 0x06000A49 RID: 2633 RVA: 0x00022054 File Offset: 0x00020254
			// (set) Token: 0x06000A4A RID: 2634 RVA: 0x0002205C File Offset: 0x0002025C
			public int X { get; private set; }

			// Token: 0x17000247 RID: 583
			// (get) Token: 0x06000A4B RID: 2635 RVA: 0x00022065 File Offset: 0x00020265
			// (set) Token: 0x06000A4C RID: 2636 RVA: 0x0002206D File Offset: 0x0002026D
			public int Y { get; private set; }
		}

		// Token: 0x02000124 RID: 292
		public class KeyEventArgs
		{
			// Token: 0x06000A4E RID: 2638 RVA: 0x00022080 File Offset: 0x00020280
			public static implicit operator Editor.KeyEventArgs(System.Windows.Forms.KeyEventArgs ea)
			{
				return new Editor.KeyEventArgs
				{
					Alt = ea.Alt,
					Control = ea.Control,
					KeyCode = KeyInterop.KeyFromVirtualKey((int)ea.KeyCode),
					Shift = ea.Shift
				};
			}

			// Token: 0x17000248 RID: 584
			// (get) Token: 0x06000A4F RID: 2639 RVA: 0x000220C9 File Offset: 0x000202C9
			// (set) Token: 0x06000A50 RID: 2640 RVA: 0x000220D1 File Offset: 0x000202D1
			public virtual bool Alt { get; private set; }

			// Token: 0x17000249 RID: 585
			// (get) Token: 0x06000A51 RID: 2641 RVA: 0x000220DA File Offset: 0x000202DA
			// (set) Token: 0x06000A52 RID: 2642 RVA: 0x000220E2 File Offset: 0x000202E2
			public bool Control { get; private set; }

			// Token: 0x1700024A RID: 586
			// (get) Token: 0x06000A53 RID: 2643 RVA: 0x000220EB File Offset: 0x000202EB
			// (set) Token: 0x06000A54 RID: 2644 RVA: 0x000220F3 File Offset: 0x000202F3
			public Key KeyCode { get; private set; }

			// Token: 0x1700024B RID: 587
			// (get) Token: 0x06000A55 RID: 2645 RVA: 0x000220FC File Offset: 0x000202FC
			// (set) Token: 0x06000A56 RID: 2646 RVA: 0x00022104 File Offset: 0x00020304
			public virtual bool Shift { get; private set; }
		}

		// Token: 0x02000125 RID: 293
		public enum MouseEvent
		{
			// Token: 0x040004E8 RID: 1256
			MouseDown,
			// Token: 0x040004E9 RID: 1257
			MouseUp,
			// Token: 0x040004EA RID: 1258
			MouseMove,
			// Token: 0x040004EB RID: 1259
			MouseMoveDelta,
			// Token: 0x040004EC RID: 1260
			MouseWheel,
			// Token: 0x040004ED RID: 1261
			MouseEnter,
			// Token: 0x040004EE RID: 1262
			MouseLeave
		}

		// Token: 0x02000126 RID: 294
		public enum KeyEvent
		{
			// Token: 0x040004F0 RID: 1264
			KeyDown,
			// Token: 0x040004F1 RID: 1265
			KeyChar,
			// Token: 0x040004F2 RID: 1266
			KeyUp
		}
	}
}
