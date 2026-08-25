using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Threading;

namespace IGE.Nomad
{
	// Token: 0x020000F4 RID: 244
	internal static class Engine
	{
		// Token: 0x06000895 RID: 2197 RVA: 0x0001CEE3 File Offset: 0x0001B0E3
		private static void InitInternal()
		{
			Engine.BinFile = Assembly.GetExecutingAssembly().Location;
			Engine.BinDir = Path.GetDirectoryName(Engine.BinFile) + "\\";
			Binding.LoadDll();
			Engine.m_delegateMessagePumpCallback = new Binding.MessagePumpCallback(Engine.MessagePumpCallback);
		}

		// Token: 0x06000896 RID: 2198 RVA: 0x0001CF24 File Offset: 0x0001B124
		private static string FormatArgument(string argument)
		{
			string text = argument.Trim();
			if (text.Contains(" "))
			{
				text = string.Format("\"{0}\"", text);
			}
			return text;
		}

		// Token: 0x06000897 RID: 2199 RVA: 0x0001CF54 File Offset: 0x0001B154
		public static bool Init(IntPtr mainWindow, IntPtr viewport)
		{
			Engine.InitInternal();
			string[] array = Environment.GetCommandLineArgs();
			array = Array.ConvertAll<string, string>(array, new Converter<string, string>(Engine.FormatArgument));
			int num = 1;
			if (Program.GetMapArgument() != null)
			{
				num = 2;
			}
			if (!Binding.InitDuniaEngine(Process.GetCurrentProcess().MainModule.BaseAddress, mainWindow, viewport, string.Join(" ", array, num, array.Length - num) + " -editorpc ", true, true, Engine.m_delegateMessagePumpCallback))
			{
				return false;
			}
			foreach (object obj in Process.GetCurrentProcess().Modules)
			{
				ProcessModule processModule = (ProcessModule)obj;
				if (processModule.ModuleName.StartsWith("IGE.WPF.Core") || processModule.ModuleName.StartsWith("InGameEditor"))
				{
					Binding.FCE_Hack_Init(processModule.BaseAddress);
				}
			}
			Binding.FCE_Engine_AutoAcquireInput(true);
			bool flag = Editor.CreateGamerProfile();
			if (flag)
			{
				Editor.Init();
				Binding.FCE_Engine_Reset(mainWindow, viewport, Engine.m_delegateMessagePumpCallback);
				if (!Directory.Exists(Engine.PersonalPath))
				{
					Directory.CreateDirectory(Engine.PersonalPath);
				}
				Engine.m_initialized = true;
			}
			return flag;
		}

		// Token: 0x06000898 RID: 2200 RVA: 0x0001D098 File Offset: 0x0001B298
		public static void Reset(Form mainWindow, Control viewport)
		{
			Engine.InitInternal();
			Editor.Init();
			Binding.FCE_Engine_Reset(mainWindow.Handle, viewport.Handle, Engine.m_delegateMessagePumpCallback);
			Engine.m_initialized = true;
		}

		// Token: 0x06000899 RID: 2201 RVA: 0x0001D0C5 File Offset: 0x0001B2C5
		public static void Close()
		{
			Binding.UnloadDll();
			Binding.CloseDuniaEngine();
		}

		// Token: 0x0600089A RID: 2202 RVA: 0x0001D0D8 File Offset: 0x0001B2D8
		public static void Run()
		{
			Engine.TickAlways |= Program.HasArgument("-alwaysTick");
			while (System.Windows.Application.Current != null)
			{
				bool flag = Editor.IsActive || Engine.TickAlways;
				if (Engine.m_delayedCallbacks.Count > 0)
				{
					flag = true;
					lock (Engine.m_delayedCallbacks)
					{
						foreach (Engine.InvokeDelegate invokeDelegate in Engine.m_delayedCallbacks)
						{
							invokeDelegate();
						}
						Engine.m_delayedCallbacks.Clear();
					}
				}
				if (flag)
				{
					Binding.TickDuniaEngine();
				}
				else
				{
					Thread.Sleep(50);
				}
				Engine.DoEvents();
			}
		}

		// Token: 0x0600089B RID: 2203 RVA: 0x0001D1BC File Offset: 0x0001B3BC
		public static void DoEvents()
		{
			DispatcherFrame dispatcherFrame = new DispatcherFrame();
			Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Background, new DispatcherOperationCallback(Engine.ExitFrame), dispatcherFrame);
			Dispatcher.PushFrame(dispatcherFrame);
		}

		// Token: 0x0600089C RID: 2204 RVA: 0x0001D1EE File Offset: 0x0001B3EE
		public static object ExitFrame(object f)
		{
			((DispatcherFrame)f).Continue = false;
			return null;
		}

		// Token: 0x0600089D RID: 2205 RVA: 0x0001D200 File Offset: 0x0001B400
		public static void Invoke(Engine.InvokeDelegate callback)
		{
			lock (Engine.m_delayedCallbacks)
			{
				Engine.m_delayedCallbacks.Add(callback);
			}
		}

		// Token: 0x0600089E RID: 2206 RVA: 0x0001D244 File Offset: 0x0001B444
		private static void MessagePumpCallback(bool deferQuit, bool blockRenderer)
		{
		}

		// Token: 0x170001F2 RID: 498
		// (get) Token: 0x0600089F RID: 2207 RVA: 0x0001D246 File Offset: 0x0001B446
		public static string PersonalPath
		{
			get
			{
				return Marshal.PtrToStringUni(Binding.FCE_Engine_GetPersonalPath());
			}
		}

		// Token: 0x170001F3 RID: 499
		// (get) Token: 0x060008A0 RID: 2208 RVA: 0x0001D257 File Offset: 0x0001B457
		public static string GenericDataPath
		{
			get
			{
				return Marshal.PtrToStringUni(Binding.FCE_Engine_GetGenericDataPath());
			}
		}

		// Token: 0x060008A1 RID: 2209 RVA: 0x0001D268 File Offset: 0x0001B468
		public static void UpdateResolution(Size size)
		{
			if (Engine.Initialized)
			{
				Binding.FCE_Engine_UpdateViewport((int)size.Width, (int)size.Height);
			}
		}

		// Token: 0x170001F4 RID: 500
		// (get) Token: 0x060008A2 RID: 2210 RVA: 0x0001D28B File Offset: 0x0001B48B
		public static bool Initialized
		{
			get
			{
				return Engine.m_initialized;
			}
		}

		// Token: 0x170001F5 RID: 501
		// (get) Token: 0x060008A3 RID: 2211 RVA: 0x0001D292 File Offset: 0x0001B492
		public static bool ConsoleOpened
		{
			get
			{
				return Binding.FCE_Engine_IsConsoleOpen();
			}
		}

		// Token: 0x170001F6 RID: 502
		// (get) Token: 0x060008A4 RID: 2212 RVA: 0x0001D2A0 File Offset: 0x0001B4A0
		// (set) Token: 0x060008A5 RID: 2213 RVA: 0x0001D2C5 File Offset: 0x0001B4C5
		public static TimeSpan TimeOfDay
		{
			get
			{
				int hours;
				int minutes;
				int seconds;
				Binding.FCE_Engine_GetTimeOfDay(out hours, out minutes, out seconds);
				return new TimeSpan(hours, minutes, seconds);
			}
			set
			{
				Binding.FCE_Engine_SetTimeOfDay(value.Hours, value.Minutes, value.Seconds);
			}
		}

		// Token: 0x170001F7 RID: 503
		// (get) Token: 0x060008A6 RID: 2214 RVA: 0x0001D2E6 File Offset: 0x0001B4E6
		public static int CloudTypeCount
		{
			get
			{
				return Binding.FCE_Engine_GetCloudTypeCount();
			}
		}

		// Token: 0x170001F8 RID: 504
		// (get) Token: 0x060008A7 RID: 2215 RVA: 0x0001D2F2 File Offset: 0x0001B4F2
		// (set) Token: 0x060008A8 RID: 2216 RVA: 0x0001D2FE File Offset: 0x0001B4FE
		public static int CloudType
		{
			get
			{
				return Binding.FCE_Engine_GetCloudType();
			}
			set
			{
				Binding.FCE_Engine_SetCloudType(value);
			}
		}

		// Token: 0x170001F9 RID: 505
		// (get) Token: 0x060008A9 RID: 2217 RVA: 0x0001D30B File Offset: 0x0001B50B
		// (set) Token: 0x060008AA RID: 2218 RVA: 0x0001D317 File Offset: 0x0001B517
		public static bool SnowEnabled
		{
			get
			{
				return Binding.FCE_Engine_IsSnowEnabled();
			}
			set
			{
				Binding.FCE_Engine_SetSnowEnabled(value);
			}
		}

		// Token: 0x170001FA RID: 506
		// (get) Token: 0x060008AB RID: 2219 RVA: 0x0001D324 File Offset: 0x0001B524
		// (set) Token: 0x060008AC RID: 2220 RVA: 0x0001D330 File Offset: 0x0001B530
		public static bool BackdropEnabled
		{
			get
			{
				return Binding.FCE_Engine_IsBackdropEnabled();
			}
			set
			{
				Binding.FCE_Engine_SetBackdropEnabled(value);
			}
		}

		// Token: 0x170001FB RID: 507
		// (get) Token: 0x060008AD RID: 2221 RVA: 0x0001D33D File Offset: 0x0001B53D
		// (set) Token: 0x060008AE RID: 2222 RVA: 0x0001D344 File Offset: 0x0001B544
		public static string BinFile { get; private set; }

		// Token: 0x170001FC RID: 508
		// (get) Token: 0x060008AF RID: 2223 RVA: 0x0001D34C File Offset: 0x0001B54C
		// (set) Token: 0x060008B0 RID: 2224 RVA: 0x0001D353 File Offset: 0x0001B553
		public static string BinDir { get; private set; }

		// Token: 0x060008B1 RID: 2225 RVA: 0x0001D35C File Offset: 0x0001B55C
		public static void Reload(Engine.ReloadState reloadState)
		{
			if (reloadState == Engine.ReloadState.None)
			{
				return;
			}
			if (reloadState == Engine.ReloadState.Managed)
			{
				Engine.Reloading = true;
				Program.CloseWindow();
				Binding.UnloadDll();
				return;
			}
			if (reloadState == Engine.ReloadState.Native)
			{
				Engine.Reloading = true;
				Program.CloseWindow();
				Binding.FCE_Editor_Destroy();
				Binding.UnloadDll();
				Binding.UnloadIGEDll();
				File.Copy(Engine.BinDir + "output\\" + Binding.gameDll, Engine.BinDir + Binding.gameDll, true);
				string text = Path.ChangeExtension(Binding.gameDll, ".pdb");
				File.Copy(Engine.BinDir + "output\\" + text, Engine.BinDir + text, true);
				Binding.LoadIGEDll();
				Binding.LoadDll();
				Binding.FCE_Editor_Create(true);
				Binding.UnloadDll();
			}
		}

		// Token: 0x170001FD RID: 509
		// (get) Token: 0x060008B2 RID: 2226 RVA: 0x0001D426 File Offset: 0x0001B626
		// (set) Token: 0x060008B3 RID: 2227 RVA: 0x0001D42D File Offset: 0x0001B62D
		public static bool Reloading { get; set; }

		// Token: 0x0400042F RID: 1071
		public static bool TickAlways = false;

		// Token: 0x04000430 RID: 1072
		private static List<Engine.InvokeDelegate> m_delayedCallbacks = new List<Engine.InvokeDelegate>();

		// Token: 0x04000431 RID: 1073
		private static Binding.MessagePumpCallback m_delegateMessagePumpCallback;

		// Token: 0x04000432 RID: 1074
		private static bool m_initialized = false;

		// Token: 0x020000F5 RID: 245
		// (Invoke) Token: 0x060008B6 RID: 2230
		public delegate void InvokeDelegate();

		// Token: 0x020000F6 RID: 246
		public enum ReloadState
		{
			// Token: 0x04000437 RID: 1079
			None,
			// Token: 0x04000438 RID: 1080
			Managed,
			// Token: 0x04000439 RID: 1081
			Native
		}
	}
}
