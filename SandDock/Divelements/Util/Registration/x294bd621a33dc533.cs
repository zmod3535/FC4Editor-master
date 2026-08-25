using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Divelements.Util.Registration
{
	// Token: 0x02000005 RID: 5
	internal class x294bd621a33dc533 : LicenseProvider
	{
		// Token: 0x0600002F RID: 47 RVA: 0x000058D8 File Offset: 0x000048D8
		public static void ActivateProduct(string licenseKey)
		{
			if (licenseKey == null)
			{
				throw new ArgumentNullException("licenseKey");
			}
			for (;;)
			{
				licenseKey = licenseKey.Trim();
				string[] array = x294bd621a33dc533.SplitLicenseString(licenseKey);
				int num = int.Parse(array[0], CultureInfo.InvariantCulture);
				Assembly assembly = typeof(x294bd621a33dc533).Assembly;
				string assemblyProductName = x294bd621a33dc533.GetAssemblyProductName(assembly);
				Version versionFromAssembly = x294bd621a33dc533.GetVersionFromAssembly(assembly);
				string b = x294bd621a33dc533.GenerateLicenseKeyForCustomer(assemblyProductName, "buildmachine", versionFromAssembly.Major, versionFromAssembly.Minor, versionFromAssembly.Build, num);
				if ((uint)num > 4294967295U)
				{
					goto IL_0F;
				}
				if (array[1] == b)
				{
					break;
				}
				bool flag = (uint)num - (uint)num > uint.MaxValue;
				if (!flag)
				{
					goto IL_B2;
				}
			}
			x294bd621a33dc533.x0b277e20f7c1b92c = true;
			return;
			IL_0F:
			IL_B2:
			throw new ArgumentException("The supplied license key is not valid. Check you are using the correct license key for the version of the software installed.", "licenseKey");
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000030 RID: 48 RVA: 0x000059D4 File Offset: 0x000049D4
		public static bool StaticallyActivated
		{
			get
			{
				return x294bd621a33dc533.x0b277e20f7c1b92c;
			}
		}

		// Token: 0x06000031 RID: 49 RVA: 0x000059DC File Offset: 0x000049DC
		private static Version GetVersionFromAssembly(Assembly assembly)
		{
			return assembly.GetName().Version;
		}

		// Token: 0x06000032 RID: 50 RVA: 0x000059EC File Offset: 0x000049EC
		public static string[] SplitLicenseString(string s)
		{
			return new string[]
			{
				s.Substring(0, s.IndexOf('|')),
				s.Substring(s.IndexOf('|') + 1)
			};
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00005A28 File Offset: 0x00004A28
		public static string GetAssemblyProductName(Assembly assembly)
		{
			string result = null;
			AssemblyProductAttribute[] array;
			for (;;)
			{
				array = (AssemblyProductAttribute[])assembly.GetCustomAttributes(typeof(AssemblyProductAttribute), false);
				if (array.Length != 0)
				{
					break;
				}
				if (3 != 0)
				{
					return result;
				}
			}
			result = array[0].Product;
			return result;
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00005A68 File Offset: 0x00004A68
		private string GetSavedLicenseKey(LicenseContext context, Type type)
		{
			string savedLicenseKey = context.GetSavedLicenseKey(type, null);
			if (2147483647 != 0)
			{
				IL_7B:
				while (savedLicenseKey == null)
				{
					Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
					int i = 0;
					while (i < assemblies.Length)
					{
						string savedLicenseKey2;
						for (;;)
						{
							Assembly assembly = assemblies[i];
							if (!(assembly is AssemblyBuilder))
							{
								savedLicenseKey2 = context.GetSavedLicenseKey(type, assembly);
								if (savedLicenseKey2 != null)
								{
									goto IL_77;
								}
							}
							i++;
							if (((uint)i | 4294967295U) != 0U)
							{
								goto Block_3;
							}
						}
						IL_B5:
						string result;
						if (false)
						{
							return result;
						}
						continue;
						Block_3:
						if (false)
						{
							return result;
						}
						bool flag = (uint)i - (uint)i < 0U;
						if (flag)
						{
							goto IL_7B;
						}
						goto IL_B5;
						IL_77:
						result = savedLicenseKey2;
						flag = ((uint)i + (uint)i > uint.MaxValue);
						if (flag)
						{
							goto IL_B5;
						}
						return result;
					}
					return null;
				}
			}
			return savedLicenseKey;
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00005B3C File Offset: 0x00004B3C
		public override License GetLicense(LicenseContext context, Type type, object instance, bool allowExceptions)
		{
			if (x294bd621a33dc533.x0b277e20f7c1b92c)
			{
				goto IL_387;
			}
			int num;
			bool flag;
			if (context == null)
			{
				if (false)
				{
					goto IL_1E3;
				}
				if (15 != 0)
				{
					if ((allowExceptions ? 1U : 0U) > 4294967295U)
					{
						goto IL_191;
					}
					flag = ((uint)num < 0U);
					if (flag)
					{
						flag = ((allowExceptions ? 1U : 0U) < 0U);
						if (flag)
						{
							goto IL_1E3;
						}
						goto IL_245;
					}
				}
				if (false)
				{
					goto IL_A6;
				}
				goto IL_1B;
			}
			else
			{
				this.GetLicenseFileLines(type);
				flag = ((allowExceptions ? 1U : 0U) + (allowExceptions ? 1U : 0U) > uint.MaxValue);
				if (flag || x294bd621a33dc533.IsDebug)
				{
					this.WriteDebugMessage("licreq," + context.UsageMode.ToString());
				}
				if (context.UsageMode == LicenseUsageMode.Runtime)
				{
					string savedLicenseKey = this.GetSavedLicenseKey(context, type);
					if (savedLicenseKey != null && this.IsTypeKeyValid(savedLicenseKey, type))
					{
						if (true)
						{
							if (x294bd621a33dc533.IsDebug)
							{
								this.WriteDebugMessage("valid");
								flag = ((allowExceptions ? 1U : 0U) - (uint)num < 0U);
								if (flag)
								{
									goto IL_198;
								}
							}
							return new xbd7c5470fc89975b();
						}
						goto IL_239;
					}
					IL_198:
					if (!x294bd621a33dc533.x4528b3b385025289)
					{
						goto IL_1A4;
					}
				}
			}
			IL_47:
			if (context.UsageMode != LicenseUsageMode.Designtime)
			{
				goto IL_50;
			}
			goto IL_71;
			IL_1A4:
			string assemblyProductName;
			if (this.DoesValidDevelopmentLicenseExist(type.Assembly, context, out num))
			{
				if (x294bd621a33dc533.IsDebug)
				{
					this.WriteDebugMessage("devok,notembedded");
				}
				assemblyProductName = x294bd621a33dc533.GetAssemblyProductName(type.Assembly);
				goto IL_291;
			}
			IL_1B8:
			goto IL_47;
			IL_1E3:
			string text = text + Environment.NewLine + Environment.NewLine;
			text += "Press OK to read more.";
			x294bd621a33dc533.ShowMessage(text, assemblyProductName);
			Process.Start("http://www.divelements.co.uk/net/support/kb/licensing.aspx");
			x294bd621a33dc533.x4528b3b385025289 = true;
			if (!false)
			{
			}
			goto IL_1B8;
			IL_239:
			if (8 != 0)
			{
				goto IL_26B;
			}
			goto IL_1A4;
			IL_245:
			string[] array;
			array[3] = assemblyProductName;
			array[4] = " installed, the license will not be found. Normally, opening at least one form designer will ensure the licenses.licx file in your project is created and updated correctly. If you continue to see this message, ensure the following lines are present in the file.";
			flag = ((allowExceptions ? 1U : 0U) - (uint)num > uint.MaxValue);
			if (!flag)
			{
				text = string.Concat(array);
				text = text + Environment.NewLine + Environment.NewLine;
				text += this.GetLicenseFileLines(type);
				if (2147483647 != 0)
				{
					goto IL_239;
				}
				goto IL_291;
			}
			IL_26B:
			goto IL_1E3;
			IL_291:
			array = new string[5];
			array[0] = "Warning: Although your development license for ";
			if (!false)
			{
				array[1] = assemblyProductName;
				array[2] = " is valid, it has not been embedded into your application by Visual Studio. This means that on a machine without ";
				goto IL_245;
			}
			IL_1B:
			while (x294bd621a33dc533.IsDebug)
			{
				this.WriteDebugMessage("eval");
				flag = ((uint)num - (uint)num > uint.MaxValue);
				if (flag)
				{
					if (false)
					{
						goto IL_A6;
					}
				}
				else
				{
					IL_0F:
					x1d91faf71382de33 result = new x1d91faf71382de33();
					flag = ((uint)num - (uint)num < 0U);
					if (flag)
					{
						goto IL_387;
					}
					return result;
				}
			}
			goto IL_0F;
			IL_50:
			if ((uint)num <= 4294967295U)
			{
				goto IL_1B;
			}
			IL_71:
			if (!this.DoesValidDevelopmentLicenseExist(type.Assembly, context, out num))
			{
				if (-2147483648 == 0)
				{
					x1d91faf71382de33 result;
					return result;
				}
				flag = ((uint)num < 0U);
				if (!flag)
				{
					goto IL_1B;
				}
			}
			else
			{
				string key = num.ToString(CultureInfo.InvariantCulture) + "|" + this.GenerateLicenseKeyForType(type, num);
				context.SetSavedLicenseKey(type, key);
				flag = (((uint)num | 3U) == 0U);
				if (!flag && !x294bd621a33dc533.IsDebug)
				{
					goto IL_13A;
				}
				this.WriteDebugMessage("valid");
				goto IL_191;
			}
			IL_A6:
			goto IL_50;
			IL_A8:
			goto IL_71;
			IL_13A:
			return new xbd7c5470fc89975b();
			IL_191:
			goto IL_13A;
			IL_387:
			if ((allowExceptions ? 1U : 0U) <= 4294967295U)
			{
				return new xbd7c5470fc89975b();
			}
			goto IL_A8;
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00005EFC File Offset: 0x00004EFC
		private string GetLicenseFileLines(Type type)
		{
			string name = type.Assembly.GetName().Name;
			string text;
			Type[] types;
			int num;
			if (!false)
			{
				if (2147483647 != 0)
				{
					text = string.Empty;
					types = type.Assembly.GetTypes();
					num = 0;
					goto IL_1A;
				}
				goto IL_23;
			}
			IL_14:
			num++;
			IL_1A:
			if (num >= types.Length)
			{
				return text;
			}
			IL_23:
			Type type2 = types[num];
			if (type2.GetCustomAttributes(typeof(LicenseProviderAttribute), true).Length != 0)
			{
				if (text.Length != 0)
				{
					text += Environment.NewLine;
				}
				text = text + type2.FullName + "," + name;
				goto IL_14;
			}
			goto IL_14;
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00005F98 File Offset: 0x00004F98
		internal static void ShowMessage(string message, string title)
		{
			MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00005FA8 File Offset: 0x00004FA8
		private bool DoesValidDevelopmentLicenseExist(Assembly assembly, IServiceProvider serviceProvider, out int customerID)
		{
			customerID = 0;
			string assemblyProductName;
			string[] array4;
			for (;;)
			{
				assemblyProductName = x294bd621a33dc533.GetAssemblyProductName(assembly);
				RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("Software\\Wow6432Node\\Divelements Limited\\Registration", false);
				for (;;)
				{
					if (registryKey == null)
					{
						goto IL_153;
					}
					string text;
					for (;;)
					{
						text = (string)registryKey.GetValue(assemblyProductName);
						if (!false)
						{
							break;
						}
						if (15 == 0)
						{
							goto IL_165;
						}
					}
					if (false)
					{
						goto IL_2B1;
					}
					if (false)
					{
						goto IL_1B;
					}
					IL_1D0:
					string[] array;
					if (text != null)
					{
						array = x294bd621a33dc533.SplitLicenseString(text);
						customerID = int.Parse(array[0], CultureInfo.InvariantCulture);
						goto IL_2B1;
					}
					if (false)
					{
						goto IL_24B;
					}
					if (!x294bd621a33dc533.IsDebug)
					{
						goto IL_153;
					}
					this.WriteDebugMessage("novalue");
					if (!false)
					{
						goto IL_153;
					}
					if (-2147483648 == 0)
					{
						goto IL_63;
					}
					if (!false)
					{
						continue;
					}
					goto IL_206;
					IL_165:
					RegistryKey registryKey2;
					if (registryKey2 == null)
					{
						goto IL_23;
					}
					string text2 = (string)registryKey2.GetValue(assemblyProductName);
					if (text2 == null)
					{
						goto IL_63;
					}
					string[] array2 = x294bd621a33dc533.SplitLicenseString(text2);
					if (8 == 0)
					{
						goto IL_1D0;
					}
					customerID = int.Parse(array2[0], CultureInfo.InvariantCulture);
					if (!false && !(array2[1] == x294bd621a33dc533.GenerateLicenseKeyForCustomer(assembly, customerID)))
					{
						goto IL_DD;
					}
					return true;
					IL_153:
					registryKey2 = Registry.LocalMachine.OpenSubKey("Software\\\\Divelements Limited\\\\Registration", false);
					goto IL_165;
					IL_206:
					string[] array3;
					if (-2 != 0)
					{
						array3[3] = Environment.MachineName;
						array3[4] = ". A clean install of the product will solve this issue.";
						x294bd621a33dc533.ShowMessage(string.Concat(array3), assemblyProductName);
					}
					goto IL_153;
					IL_218:
					if (array[1] == x294bd621a33dc533.GenerateLicenseKeyForCustomer(assembly, customerID))
					{
						return true;
					}
					if (x294bd621a33dc533.IsDebug)
					{
						this.WriteDebugMessage("licinvalid");
					}
					array3 = new string[5];
					array3[0] = "A license key was found, but it is not valid. This usually means you are building against a different version of the assembly than the one you activated. You are building against version ";
					array3[1] = assembly.GetName().Version.ToString();
					array3[2] = " and your machine name is ";
					goto IL_206;
					IL_2B1:
					goto IL_218;
					IL_31:
					if (15 == 0)
					{
						goto IL_48;
					}
					if (false)
					{
						goto IL_F0;
					}
					if (15 == 0)
					{
						goto IL_218;
					}
					goto IL_24B;
					IL_23:
					if (!x294bd621a33dc533.IsDebug)
					{
						if (!true)
						{
							goto IL_31;
						}
						goto IL_1B;
					}
					else
					{
						this.WriteDebugMessage("nokey");
						if (!false)
						{
							goto IL_31;
						}
					}
					IL_48:
					if (x294bd621a33dc533.IsDebug)
					{
						goto IL_6A;
					}
					if (!false)
					{
						goto Block_2;
					}
					goto IL_23;
					IL_63:
					if (255 == 0)
					{
						goto IL_6A;
					}
					goto IL_48;
					IL_1B:
					if (!false)
					{
						goto Block_3;
					}
					goto IL_31;
					IL_F0:
					this.WriteDebugMessage("licinvalid");
					if (!false)
					{
						goto IL_E4;
					}
					if (false)
					{
						goto IL_48;
					}
					goto IL_D3;
					IL_DD:
					if (!x294bd621a33dc533.IsDebug)
					{
						goto IL_E4;
					}
					goto IL_F0;
					IL_D3:
					if (-2 != 0)
					{
						goto IL_DD;
					}
					return false;
					IL_BA:
					array4[2] = " and your machine name is ";
					array4[3] = Environment.MachineName;
					if (2147483647 == 0)
					{
						goto IL_D3;
					}
					goto IL_EE;
					IL_E4:
					array4 = new string[5];
					array4[0] = "A license key was found, but it is not valid. This usually means you are building against a different version of the assembly than the one you activated. You are building against version ";
					array4[1] = assembly.GetName().Version.ToString();
					goto IL_BA;
					IL_24B:
					if (-2 == 0)
					{
						break;
					}
					if (false)
					{
						return false;
					}
					if (!false)
					{
						goto Block_1;
					}
					goto IL_BA;
				}
			}
			Block_1:
			Block_2:
			Block_3:
			return false;
			IL_6A:
			this.WriteDebugMessage("novalue");
			return false;
			IL_EE:
			array4[4] = ". A clean install of the product will solve this issue.";
			x294bd621a33dc533.ShowMessage(string.Concat(array4), assemblyProductName);
			return false;
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000039 RID: 57 RVA: 0x00006274 File Offset: 0x00005274
		private static bool IsDebug
		{
			get
			{
				if (!x294bd621a33dc533.xba4ce277d393a202)
				{
					try
					{
						using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("Software\\\\Divelements Limited\\\\Registration", false))
						{
							if (registryKey != null)
							{
								object value = registryKey.GetValue("Debug");
								if (value is int)
								{
									x294bd621a33dc533.x9fb6f00276c83908 = Convert.ToBoolean((int)value);
								}
							}
						}
					}
					catch
					{
					}
					x294bd621a33dc533.xba4ce277d393a202 = true;
				}
				return x294bd621a33dc533.x9fb6f00276c83908;
			}
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00006310 File Offset: 0x00005310
		private void WriteDebugMessage(string message)
		{
			string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Divelements.Licensing.log");
			try
			{
				using (StreamWriter streamWriter = new StreamWriter(path, true))
				{
					streamWriter.WriteLine(string.Concat(new string[]
					{
						DateTime.Now.ToShortDateString(),
						" ",
						DateTime.Now.ToLongTimeString(),
						": ",
						message
					}));
				}
			}
			catch
			{
			}
		}

		// Token: 0x0600003B RID: 59 RVA: 0x000063C4 File Offset: 0x000053C4
		public static string GenerateLicenseKeyForCustomer(string productName, string computerName, int majorVersion, int minorVersion, int buildVersion, int customerID)
		{
			string s = string.Concat(new string[]
			{
				productName,
				computerName.ToUpper(CultureInfo.InvariantCulture),
				majorVersion.ToString(),
				minorVersion.ToString(),
				buildVersion.ToString(),
				customerID.ToString(CultureInfo.InvariantCulture)
			});
			byte[] inArray;
			using (SHA1 sha = SHA1.Create())
			{
				inArray = sha.ComputeHash(Encoding.ASCII.GetBytes(s));
				goto IL_17;
			}
			string result;
			return result;
			IL_17:
			result = Convert.ToBase64String(inArray);
			return result;
		}

		// Token: 0x0600003C RID: 60 RVA: 0x0000648C File Offset: 0x0000548C
		public static string GenerateLicenseKeyForCustomer(Assembly assembly, int customerID)
		{
			string assemblyProductName = x294bd621a33dc533.GetAssemblyProductName(assembly);
			string machineName = Environment.MachineName;
			Version version = assembly.GetName().Version;
			return x294bd621a33dc533.GenerateLicenseKeyForCustomer(assemblyProductName, machineName, version.Major, version.Minor, version.Build, customerID);
		}

		// Token: 0x0600003D RID: 61 RVA: 0x000064CC File Offset: 0x000054CC
		private bool IsTypeKeyValid(string key, Type type)
		{
			string[] array = x294bd621a33dc533.SplitLicenseString(key);
			int customerID = int.Parse(array[0], CultureInfo.InvariantCulture);
			return array[1] == this.GenerateLicenseKeyForType(type, customerID);
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00006500 File Offset: 0x00005500
		private string GenerateLicenseKeyForType(Type type, int customerID)
		{
			string s = type.FullName + type.Assembly.GetName().Version.ToString() + customerID.ToString(CultureInfo.InvariantCulture);
			byte[] inArray;
			using (SHA1 sha = SHA1.Create())
			{
				inArray = sha.ComputeHash(Encoding.ASCII.GetBytes(s));
			}
			return Convert.ToBase64String(inArray);
		}

		// Token: 0x04000015 RID: 21
		private const string xed11756391d61907 = "Software\\\\Divelements Limited\\\\Registration";

		// Token: 0x04000016 RID: 22
		private static bool x4528b3b385025289;

		// Token: 0x04000017 RID: 23
		private static bool x0b277e20f7c1b92c;

		// Token: 0x04000018 RID: 24
		private static bool xba4ce277d393a202;

		// Token: 0x04000019 RID: 25
		private static bool x9fb6f00276c83908;
	}
}
