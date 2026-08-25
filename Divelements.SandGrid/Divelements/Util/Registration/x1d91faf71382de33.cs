using System;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Win32;

namespace Divelements.Util.Registration
{
	// Token: 0x02000006 RID: 6
	internal class x1d91faf71382de33 : xbd7c5470fc89975b
	{
		// Token: 0x0600002F RID: 47 RVA: 0x00004EAC File Offset: 0x00003EAC
		public x1d91faf71382de33(bool expires)
		{
			if (expires)
			{
				this.xc71dae9225f5522a = this.xa1d7cab22b1cb36a();
				if (this.xc71dae9225f5522a && !x1d91faf71382de33.x5ee2d89e2d4d8414)
				{
					string assemblyProductName = x294bd621a33dc533.GetAssemblyProductName(Assembly.GetExecutingAssembly());
					string text = string.Concat(new string[]
					{
						"Your evaluation period for ",
						assemblyProductName,
						" has expired. The software will therefore now be limited, but you will not lose any work.",
						Environment.NewLine,
						Environment.NewLine
					});
					text = text + "You can purchase " + assemblyProductName + " online. After installing the commercial version, full functionality will be restored.";
					x294bd621a33dc533.ShowMessage(text, assemblyProductName);
					x1d91faf71382de33.x5ee2d89e2d4d8414 = true;
				}
			}
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00004F3C File Offset: 0x00003F3C
		public x1d91faf71382de33() : this(true)
		{
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000031 RID: 49 RVA: 0x00004F48 File Offset: 0x00003F48
		public override bool Evaluation
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000032 RID: 50 RVA: 0x00004F4C File Offset: 0x00003F4C
		public override bool Locked
		{
			get
			{
				return this.xc71dae9225f5522a;
			}
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00004F54 File Offset: 0x00003F54
		private bool xa1d7cab22b1cb36a()
		{
			AssemblyName name = Assembly.GetExecutingAssembly().GetName();
			string assemblyProductName = x294bd621a33dc533.GetAssemblyProductName(Assembly.GetExecutingAssembly());
			string name2;
			using (SHA1 sha = SHA1.Create())
			{
				string s = string.Concat(new object[]
				{
					assemblyProductName,
					name.Version.Major,
					".",
					name.Version.Minor,
					".",
					name.Version.Build
				});
				byte[] inArray = sha.ComputeHash(Encoding.Default.GetBytes(s));
				name2 = Convert.ToBase64String(inArray);
			}
			RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\.NETFramework", true);
			if (registryKey == null)
			{
				try
				{
					registryKey = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\.NETFramework");
				}
				catch
				{
					return true;
				}
			}
			DateTime d = DateTime.MinValue;
			try
			{
				string text = (string)registryKey.GetValue(name2);
				if (text == null)
				{
					registryKey.SetValue(name2, DateTime.Now.ToFileTime().ToString());
					return false;
				}
				d = DateTime.FromFileTime(long.Parse(text));
			}
			finally
			{
				registryKey.Close();
			}
			return DateTime.Now > d + new TimeSpan(30, 0, 0, 0);
		}

		// Token: 0x04000006 RID: 6
		private static bool x5ee2d89e2d4d8414;

		// Token: 0x04000007 RID: 7
		private bool xc71dae9225f5522a;
	}
}
