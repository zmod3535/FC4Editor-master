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
		// Token: 0x0600003F RID: 63 RVA: 0x00006580 File Offset: 0x00005580
		public x1d91faf71382de33(bool expires)
		{
			string assemblyProductName;
			string[] array;
			if (!false)
			{
				if (!expires)
				{
					return;
				}
				this.xc71dae9225f5522a = this.xa1d7cab22b1cb36a();
				for (;;)
				{
					bool flag;
					for (;;)
					{
						if (!this.xc71dae9225f5522a)
						{
							goto IL_47;
						}
						goto IL_A6;
						IL_38:
						if (4 == 0)
						{
							continue;
						}
						goto IL_47;
						IL_79:
						if (-1 == 0)
						{
							goto IL_38;
						}
						if ((expires ? 1U : 0U) >= 0U)
						{
							goto Block_2;
						}
						IL_2F:
						if (4 != 0)
						{
							goto Block_3;
						}
						goto IL_79;
						IL_47:
						if ((expires ? 1U : 0U) + (expires ? 1U : 0U) <= 4294967295U)
						{
							if (!false)
							{
								goto IL_2F;
							}
							flag = (((expires ? 1U : 0U) & 0U) == 0U);
							if (flag)
							{
								goto IL_79;
							}
							break;
						}
						IL_A6:
						if (!x1d91faf71382de33.x5ee2d89e2d4d8414)
						{
							goto IL_12E;
						}
						if (!false)
						{
							goto IL_79;
						}
						if ((expires ? 1U : 0U) - (expires ? 1U : 0U) >= 0U)
						{
							goto IL_38;
						}
						goto IL_10B;
					}
					IL_139:
					flag = (((expires ? 1U : 0U) & 0U) == 0U);
					if (flag)
					{
						goto Block_11;
					}
					continue;
					IL_12E:
					assemblyProductName = x294bd621a33dc533.GetAssemblyProductName(Assembly.GetExecutingAssembly());
					goto IL_139;
				}
				Block_2:
				Block_3:
				return;
				IL_10B:
				array[2] = " has expired. The software will therefore now be limited, but you will not lose any work.";
				array[3] = Environment.NewLine;
				goto IL_BC;
				Block_11:
				array = new string[5];
				array[0] = "Your evaluation period for ";
				array[1] = assemblyProductName;
				goto IL_10B;
			}
			IL_BC:
			array[4] = Environment.NewLine;
			string text = string.Concat(array);
			text = text + "You can purchase " + assemblyProductName + " online. After installing the commercial version, full functionality will be restored.";
			x294bd621a33dc533.ShowMessage(text, assemblyProductName);
			x1d91faf71382de33.x5ee2d89e2d4d8414 = true;
		}

		// Token: 0x06000040 RID: 64 RVA: 0x000066E8 File Offset: 0x000056E8
		public x1d91faf71382de33() : this(true)
		{
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000041 RID: 65 RVA: 0x000066F4 File Offset: 0x000056F4
		public override bool Evaluation
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000042 RID: 66 RVA: 0x000066F8 File Offset: 0x000056F8
		public override bool Locked
		{
			get
			{
				return this.xc71dae9225f5522a;
			}
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00006700 File Offset: 0x00005700
		private bool xa1d7cab22b1cb36a()
		{
			AssemblyName name = Assembly.GetExecutingAssembly().GetName();
			string text;
			RegistryKey registryKey;
			if (3 != 0)
			{
				string assemblyProductName = x294bd621a33dc533.GetAssemblyProductName(Assembly.GetExecutingAssembly());
				using (SHA1 sha = SHA1.Create())
				{
					object[] array = new object[6];
					bool flag;
					do
					{
						array[0] = assemblyProductName;
						long num;
						bool flag2;
						flag = ((uint)num - (flag2 ? 1U : 0U) > uint.MaxValue);
						if (flag)
						{
							break;
						}
						do
						{
							flag = (((uint)num & 0U) == 0U);
							if (flag)
							{
								array[1] = name.Version.Major;
								array[2] = ".";
							}
							array[3] = name.Version.Minor;
							array[4] = ".";
							array[5] = name.Version.Build;
							string s = string.Concat(array);
							byte[] inArray = sha.ComputeHash(Encoding.Default.GetBytes(s));
							text = Convert.ToBase64String(inArray);
						}
						while (false);
						flag = ((flag2 ? 1U : 0U) + (flag2 ? 1U : 0U) > uint.MaxValue);
					}
					while (flag);
				}
				registryKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\.NETFramework", true);
			}
			while (registryKey == null)
			{
				try
				{
					registryKey = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\.NETFramework");
					break;
				}
				catch
				{
					return true;
				}
			}
			DateTime d = DateTime.MinValue;
			try
			{
				string text2 = (string)registryKey.GetValue(text);
				if (false)
				{
					long num;
					bool flag = ((uint)num & 0U) == 0U;
					if (flag)
					{
					}
				}
				if (text2 == null)
				{
					RegistryKey registryKey2 = registryKey;
					string name2 = text;
					long num = DateTime.Now.ToFileTime();
					registryKey2.SetValue(name2, num.ToString());
					return false;
				}
				d = DateTime.FromFileTime(long.Parse(text2));
			}
			finally
			{
				registryKey.Close();
			}
			return DateTime.Now > d + new TimeSpan(60, 0, 0, 0);
		}

		// Token: 0x0400001A RID: 26
		private static bool x5ee2d89e2d4d8414;

		// Token: 0x0400001B RID: 27
		private bool xc71dae9225f5522a;
	}
}
