using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Threading;
using IGE.Nomad;
using IGE.ViewModels;
using IGE.Views;
using Ubisoft.SandControls;

namespace IGE
{
	// Token: 0x02000078 RID: 120
	public static class Program
	{
		// Token: 0x14000005 RID: 5
		// (add) Token: 0x060004E4 RID: 1252 RVA: 0x00012BD4 File Offset: 0x00010DD4
		// (remove) Token: 0x060004E5 RID: 1253 RVA: 0x00012C08 File Offset: 0x00010E08
		public static event EventHandler ExitedInGame;

		// Token: 0x060004E6 RID: 1254 RVA: 0x00012D18 File Offset: 0x00010F18
		public static void Run()
		{
			Licensing.RegisterSandDockWpf();
			Binding.LoadDll();
			string text = Marshal.PtrToStringAnsi(Binding.GetIGESteamCommandLine());
			if (text.Length != 0)
			{
				Program._arguments = Program.SplitSteamCommandLine(text);
			}
			else
			{
				Program._arguments = new List<string>(Environment.GetCommandLineArgs());
			}
			Program.AssemblyName = Assembly.GetExecutingAssembly().GetName().Name;
			Program.MainWin = new MainWindow();
			AboutWindow splash = null;
			Thread thread = new Thread(delegate()
			{
				try
				{
					splash = new AboutWindow(false);
					splash.Closed += delegate(object s, EventArgs e)
					{
						Dispatcher.CurrentDispatcher.BeginInvokeShutdown(DispatcherPriority.Background);
					};
					splash.Show();
					Dispatcher.Run();
				}
				catch (Exception ex)
				{
					Exception ex2;
					Exception ex = ex2;
					Application.Current.Dispatcher.Invoke(new Action(delegate()
					{
						throw ex;
					}), new object[0]);
				}
			});
			thread.SetApartmentState(ApartmentState.STA);
			thread.IsBackground = true;
			thread.Start();
			IntPtr intPtr = new WindowInteropHelper(Program.MainWin).EnsureHandle();
			Binding.PC_RegisterDeviceNotification(intPtr);
			if (!Engine.Init(intPtr, Program.MainWin.GameViewport.Handle))
			{
				splash.Dispatcher.BeginInvoke(new Action(delegate()
				{
					splash.Close();
				}), new object[0]);
				MessageBox.Show("An initialization error occurred.", "Error", MessageBoxButton.OK, MessageBoxImage.Hand);
				Engine.Close();
				return;
			}
			splash.Dispatcher.BeginInvoke(new Action(delegate()
			{
				splash.Close();
			}), new object[0]);
			WildernessInventory.Instance.Initialize();
			if (Program.HasArgument("-generateObjectThumbnails"))
			{
				Program.MainWinVM.IsUiEnabled = false;
				Program.MainWinVM.NoInit = true;
				Engine.TickAlways = true;
				ObjectRenderer.GenerateThumbnails();
			}
			else if (Program.HasArgument("-generateCollectionThumbnails"))
			{
				Program.MainWinVM.IsUiEnabled = false;
				Program.MainWinVM.NoInit = true;
				Engine.TickAlways = true;
				CollectionRenderer.GenerateThumbnails();
			}
			else if (Program.HasArgument("-generateWaterThumbnails"))
			{
				Program.MainWinVM.IsUiEnabled = false;
				Program.MainWinVM.NoInit = true;
				Engine.TickAlways = true;
				WaterRenderer.GenerateThumbnails();
			}
			else if (Program.GetArgument("resizeThumbnails") != null)
			{
				ObjectRenderer.ResizeThumbnails(Program.GetArgument("resizeThumbnails"));
			}
			else
			{
				ulong objectiveId;
				ulong terrainId;
				if (!Program.GetObjectiveTypeArgument(out objectiveId, out terrainId))
				{
					terrainId = (objectiveId = 0UL);
				}
				if (!Program.MainWinVM.PostLoad(objectiveId, terrainId, Program.GetMapArgument()))
				{
					return;
				}
			}
			Program.MainWin.Show();
			Engine.Run();
		}

		// Token: 0x060004E7 RID: 1255 RVA: 0x00012F47 File Offset: 0x00011147
		public static void Stop()
		{
			Engine.Close();
		}

		// Token: 0x060004E8 RID: 1256 RVA: 0x00012F4E File Offset: 0x0001114E
		public static void EnterIngame()
		{
			Program.IsIngame = true;
		}

		// Token: 0x060004E9 RID: 1257 RVA: 0x00012F56 File Offset: 0x00011156
		public static void EnableShortcuts(bool enable)
		{
			Program.MainWinVM.EnableShortcuts = enable;
		}

		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x060004EA RID: 1258 RVA: 0x00012F63 File Offset: 0x00011163
		// (set) Token: 0x060004EB RID: 1259 RVA: 0x00012F6F File Offset: 0x0001116F
		public static bool IsUiEnabled
		{
			get
			{
				return Program.MainWinVM.IsUiEnabled;
			}
			set
			{
				Program.MainWinVM.IsUiEnabled = value;
			}
		}

		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x060004EC RID: 1260 RVA: 0x00012F7C File Offset: 0x0001117C
		// (set) Token: 0x060004ED RID: 1261 RVA: 0x00012F88 File Offset: 0x00011188
		public static bool IsIngame
		{
			get
			{
				return Program.MainWinVM.IsIngameUi;
			}
			set
			{
				if (Program.MainWinVM.IsIngameUi && !value && Program.ExitedInGame != null)
				{
					Program.ExitedInGame(null, EventArgs.Empty);
				}
				Program.MainWinVM.IsIngameUi = value;
			}
		}

		// Token: 0x060004EE RID: 1262 RVA: 0x00012FBB File Offset: 0x000111BB
		public static void ClearMapPath()
		{
			Program.MainWinVM.ClearMapPath();
		}

		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x060004EF RID: 1263 RVA: 0x00012FC7 File Offset: 0x000111C7
		private static MainWindowViewModel MainWinVM
		{
			get
			{
				return Program.MainWin.DataContext as MainWindowViewModel;
			}
		}

		// Token: 0x170000FA RID: 250
		// (get) Token: 0x060004F0 RID: 1264 RVA: 0x00012FD8 File Offset: 0x000111D8
		// (set) Token: 0x060004F1 RID: 1265 RVA: 0x00012FE9 File Offset: 0x000111E9
		public static MainWindow MainWin
		{
			get
			{
				return (MainWindow)Application.Current.MainWindow;
			}
			set
			{
				Application.Current.MainWindow = value;
			}
		}

		// Token: 0x060004F2 RID: 1266 RVA: 0x00012FF6 File Offset: 0x000111F6
		public static void CloseWindow()
		{
			Program.MainWinVM.CloseSaveConfirmed = true;
			Program.MainWin.Close();
		}

		// Token: 0x060004F3 RID: 1267 RVA: 0x00013024 File Offset: 0x00011224
		public static bool HasArgument(string key)
		{
			return Program._arguments.Any((string arg) => arg == key);
		}

		// Token: 0x060004F4 RID: 1268 RVA: 0x00013054 File Offset: 0x00011254
		public static string GetMapArgument()
		{
			if (Program._arguments.Count >= 2 && !Program._arguments[1].StartsWith("-"))
			{
				return Program._arguments[1];
			}
			return null;
		}

		// Token: 0x060004F5 RID: 1269 RVA: 0x00013088 File Offset: 0x00011288
		public static bool GetObjectiveTypeArgument(out ulong objectiveTypeId, out ulong terrainId)
		{
			objectiveTypeId = 0UL;
			terrainId = 0UL;
			string argument;
			string argument2;
			return (argument = Program.GetArgument("objective")) != null && (argument2 = Program.GetArgument("terrain")) != null && ulong.TryParse(argument, out objectiveTypeId) && ulong.TryParse(argument2, out terrainId);
		}

		// Token: 0x060004F6 RID: 1270 RVA: 0x00013114 File Offset: 0x00011314
		public static string GetArgument(string arg)
		{
			return (from argument in Program._arguments
			where argument.StartsWith("-" + arg.ToLower() + "=")
			select argument.Substring(arg.Length + 2)).FirstOrDefault<string>();
		}

		// Token: 0x060004F7 RID: 1271 RVA: 0x0001315C File Offset: 0x0001135C
		private static List<string> SplitSteamCommandLine(string cmdLine)
		{
			List<string> list = new List<string>();
			StringBuilder stringBuilder = new StringBuilder();
			bool flag = false;
			foreach (char c in cmdLine)
			{
				if (c == '"')
				{
					if (stringBuilder.Length > 0)
					{
						list.Add(stringBuilder.ToString());
						stringBuilder.Clear();
					}
					flag = !flag;
				}
				else if (c == ' ' && !flag)
				{
					if (stringBuilder.Length > 0)
					{
						list.Add(stringBuilder.ToString());
						stringBuilder.Clear();
					}
				}
				else
				{
					stringBuilder.Append(c);
				}
			}
			if (stringBuilder.Length > 0)
			{
				list.Add(stringBuilder.ToString());
			}
			return list;
		}

		// Token: 0x0400021F RID: 543
		public static string AssemblyName;

		// Token: 0x04000221 RID: 545
		private static List<string> _arguments;
	}
}
