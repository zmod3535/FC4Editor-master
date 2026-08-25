using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;

namespace IGE
{
	// Token: 0x02000002 RID: 2
	public class App : Application
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);
			Program.Run();
		}

		// Token: 0x06000002 RID: 2 RVA: 0x0000205E File Offset: 0x0000025E
		protected override void OnExit(ExitEventArgs e)
		{
			base.OnExit(e);
			Program.Stop();
		}

		// Token: 0x06000003 RID: 3 RVA: 0x0000206C File Offset: 0x0000026C
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[STAThread]
		[DebuggerNonUserCode]
		public static void Main()
		{
			App app = new App();
			app.Run();
		}
	}
}
