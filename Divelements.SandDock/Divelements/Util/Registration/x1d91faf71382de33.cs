using System;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Win32;

namespace Divelements.Util.Registration
{
	// Token: 0x02000003 RID: 3
	internal class x1d91faf71382de33 : xbd7c5470fc89975b
	{
		// Token: 0x06000010 RID: 16 RVA: 0x00030C0C File Offset: 0x0002F00C
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

		// Token: 0x06000011 RID: 17 RVA: 0x00030C9C File Offset: 0x0002F09C
		public x1d91faf71382de33() : this(true)
		{
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000012 RID: 18 RVA: 0x00030CA8 File Offset: 0x0002F0A8
		public override bool Evaluation
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000013 RID: 19 RVA: 0x00030CAC File Offset: 0x0002F0AC
		public override bool Locked
		{
			get
			{
				return this.xc71dae9225f5522a;
			}
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00030CB4 File Offset: 0x0002F0B4
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

		// Token: 0x04000001 RID: 1
		private static bool x5ee2d89e2d4d8414;

		// Token: 0x04000002 RID: 2
		private bool xc71dae9225f5522a;
	}
}
