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
		// Token: 0x0600001F RID: 31 RVA: 0x000045AC File Offset: 0x000035AC
		public static void ActivateProduct(string licenseKey)
		{
			if (licenseKey == null)
			{
				throw new ArgumentNullException("licenseKey");
			}
			licenseKey = licenseKey.Trim();
			string[] array = x294bd621a33dc533.SplitLicenseString(licenseKey);
			int customerID = int.Parse(array[0], CultureInfo.InvariantCulture);
			Assembly assembly = typeof(x294bd621a33dc533).Assembly;
			string assemblyProductName = x294bd621a33dc533.GetAssemblyProductName(assembly);
			Version versionFromAssembly = x294bd621a33dc533.GetVersionFromAssembly(assembly);
			string b = x294bd621a33dc533.GenerateLicenseKeyForCustomer(assemblyProductName, "buildmachine", versionFromAssembly.Major, versionFromAssembly.Minor, versionFromAssembly.Build, customerID);
			if (array[1] == b)
			{
				x294bd621a33dc533.x0b277e20f7c1b92c = true;
				return;
			}
			throw new ArgumentException("The supplied license key is not valid. Check you are using the correct license key for the version of the software installed.", "licenseKey");
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000020 RID: 32 RVA: 0x00004648 File Offset: 0x00003648
		public static bool StaticallyActivated
		{
			get
			{
				return x294bd621a33dc533.x0b277e20f7c1b92c;
			}
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00004650 File Offset: 0x00003650
		private static Version GetVersionFromAssembly(Assembly assembly)
		{
			return assembly.GetName().Version;
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00004660 File Offset: 0x00003660
		public static string[] SplitLicenseString(string s)
		{
			return new string[]
			{
				s.Substring(0, s.IndexOf('|')),
				s.Substring(s.IndexOf('|') + 1)
			};
		}

		// Token: 0x06000023 RID: 35 RVA: 0x0000469C File Offset: 0x0000369C
		public static string GetAssemblyProductName(Assembly assembly)
		{
			string result = null;
			AssemblyProductAttribute[] array = (AssemblyProductAttribute[])assembly.GetCustomAttributes(typeof(AssemblyProductAttribute), false);
			if (array.Length != 0)
			{
				result = array[0].Product;
			}
			return result;
		}

		// Token: 0x06000024 RID: 36 RVA: 0x000046D4 File Offset: 0x000036D4
		private string GetSavedLicenseKey(LicenseContext context, Type type)
		{
			string savedLicenseKey = context.GetSavedLicenseKey(type, null);
			if (savedLicenseKey != null)
			{
				return savedLicenseKey;
			}
			foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
			{
				if (!(assembly is AssemblyBuilder))
				{
					string savedLicenseKey2 = context.GetSavedLicenseKey(type, assembly);
					if (savedLicenseKey2 != null)
					{
						return savedLicenseKey2;
					}
				}
			}
			return null;
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00004730 File Offset: 0x00003730
		public override License GetLicense(LicenseContext context, Type type, object instance, bool allowExceptions)
		{
			int customerID;
			string assemblyProductName;
			string[] array;
			if (x294bd621a33dc533.x0b277e20f7c1b92c)
			{
				if (8 != 0)
				{
					return new xbd7c5470fc89975b();
				}
			}
			else
			{
				if (context == null)
				{
					goto IL_F6;
				}
				this.GetLicenseFileLines(type);
				if (x294bd621a33dc533.IsDebug)
				{
					this.WriteDebugMessage("licreq," + context.UsageMode.ToString());
				}
				if (context.UsageMode != LicenseUsageMode.Runtime)
				{
					goto IL_9B;
				}
				string savedLicenseKey = this.GetSavedLicenseKey(context, type);
				if (savedLicenseKey != null && this.IsTypeKeyValid(savedLicenseKey, type))
				{
					if (x294bd621a33dc533.IsDebug)
					{
						this.WriteDebugMessage("valid");
					}
					return new xbd7c5470fc89975b();
				}
				if (x294bd621a33dc533.x4528b3b385025289 || !this.DoesValidDevelopmentLicenseExist(type.Assembly, context, out customerID))
				{
					goto IL_9B;
				}
				if (x294bd621a33dc533.IsDebug)
				{
					this.WriteDebugMessage("devok,notembedded");
				}
				assemblyProductName = x294bd621a33dc533.GetAssemblyProductName(type.Assembly);
				array = new string[5];
			}
			array[0] = "Warning: Although your development license for ";
			array[1] = assemblyProductName;
			array[2] = " is valid, it has not been embedded into your application by Visual Studio. This means that on a machine without ";
			array[3] = assemblyProductName;
			x1d91faf71382de33 result;
			if (false)
			{
				return result;
			}
			array[4] = " installed, the license will not be found. Normally, opening at least one form designer will ensure the licenses.licx file in your project is created and updated correctly. If you continue to see this message, ensure the following lines are present in the file.";
			string text = string.Concat(array);
			text = text + Environment.NewLine + Environment.NewLine;
			text += this.GetLicenseFileLines(type);
			text = text + Environment.NewLine + Environment.NewLine;
			text += "Press OK to read more.";
			x294bd621a33dc533.ShowMessage(text, assemblyProductName);
			Process.Start("http://www.divelements.co.uk/net/support/kb/licensing.aspx");
			x294bd621a33dc533.x4528b3b385025289 = true;
			IL_9B:
			if (context.UsageMode == LicenseUsageMode.Designtime && this.DoesValidDevelopmentLicenseExist(type.Assembly, context, out customerID))
			{
				string key = customerID.ToString(CultureInfo.InvariantCulture) + "|" + this.GenerateLicenseKeyForType(type, customerID);
				context.SetSavedLicenseKey(type, key);
				if (x294bd621a33dc533.IsDebug)
				{
					this.WriteDebugMessage("valid");
				}
				return new xbd7c5470fc89975b();
			}
			IL_F6:
			if (x294bd621a33dc533.IsDebug)
			{
				this.WriteDebugMessage("eval");
			}
			result = new x1d91faf71382de33();
			return result;
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00004910 File Offset: 0x00003910
		private string GetLicenseFileLines(Type type)
		{
			string name = type.Assembly.GetName().Name;
			string text = string.Empty;
			foreach (Type type2 in type.Assembly.GetTypes())
			{
				if (type2.GetCustomAttributes(typeof(LicenseProviderAttribute), true).Length != 0)
				{
					if (text.Length != 0)
					{
						text += Environment.NewLine;
					}
					text = text + type2.FullName + "," + name;
				}
			}
			return text;
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00004994 File Offset: 0x00003994
		internal static void ShowMessage(string message, string title)
		{
			MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		// Token: 0x06000028 RID: 40 RVA: 0x000049A4 File Offset: 0x000039A4
		private bool DoesValidDevelopmentLicenseExist(Assembly assembly, IServiceProvider serviceProvider, out int customerID)
		{
			customerID = 0;
			string assemblyProductName;
			string text2;
			for (;;)
			{
				assemblyProductName = x294bd621a33dc533.GetAssemblyProductName(assembly);
				RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("Software\\Wow6432Node\\Divelements Limited\\Registration", false);
				if (registryKey != null)
				{
					string text = (string)registryKey.GetValue(assemblyProductName);
					if (text != null)
					{
						string[] array = x294bd621a33dc533.SplitLicenseString(text);
						customerID = int.Parse(array[0], CultureInfo.InvariantCulture);
						if (array[1] == x294bd621a33dc533.GenerateLicenseKeyForCustomer(assembly, customerID))
						{
							return true;
						}
						if (x294bd621a33dc533.IsDebug)
						{
							this.WriteDebugMessage("licinvalid");
						}
						x294bd621a33dc533.ShowMessage(string.Concat(new string[]
						{
							"A license key was found, but it is not valid. This usually means you are building against a different version of the assembly than the one you activated. You are building against version ",
							assembly.GetName().Version.ToString(),
							" and your machine name is ",
							Environment.MachineName,
							". A clean install of the product will solve this issue."
						}), assemblyProductName);
						if (2147483647 == 0)
						{
							goto IL_1F2;
						}
					}
					else if (x294bd621a33dc533.IsDebug)
					{
						this.WriteDebugMessage("novalue");
					}
				}
				RegistryKey registryKey2 = Registry.LocalMachine.OpenSubKey("Software\\\\Divelements Limited\\\\Registration", false);
				if (registryKey2 == null)
				{
					break;
				}
				text2 = (string)registryKey2.GetValue(assemblyProductName);
				while (text2 != null)
				{
					if (-2 != 0)
					{
						goto Block_9;
					}
				}
				if (!x294bd621a33dc533.IsDebug)
				{
					return false;
				}
				this.WriteDebugMessage("novalue");
				if (-1 != 0)
				{
					goto IL_201;
				}
			}
			if (x294bd621a33dc533.IsDebug)
			{
				this.WriteDebugMessage("nokey");
				return false;
			}
			return false;
			Block_9:
			string[] array2 = x294bd621a33dc533.SplitLicenseString(text2);
			IL_1F2:
			string[] array3;
			if (2147483647 != 0)
			{
				customerID = int.Parse(array2[0], CultureInfo.InvariantCulture);
				if (array2[1] == x294bd621a33dc533.GenerateLicenseKeyForCustomer(assembly, customerID))
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
			}
			array3[2] = " and your machine name is ";
			array3[3] = Environment.MachineName;
			array3[4] = ". A clean install of the product will solve this issue.";
			x294bd621a33dc533.ShowMessage(string.Concat(array3), assemblyProductName);
			return false;
			IL_201:
			if (false)
			{
			}
			return false;
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000029 RID: 41 RVA: 0x00004BBC File Offset: 0x00003BBC
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

		// Token: 0x0600002A RID: 42 RVA: 0x00004C58 File Offset: 0x00003C58
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

		// Token: 0x0600002B RID: 43 RVA: 0x00004D0C File Offset: 0x00003D0C
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
			}
			return Convert.ToBase64String(inArray);
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00004DB8 File Offset: 0x00003DB8
		public static string GenerateLicenseKeyForCustomer(Assembly assembly, int customerID)
		{
			string assemblyProductName = x294bd621a33dc533.GetAssemblyProductName(assembly);
			string machineName = Environment.MachineName;
			Version version = assembly.GetName().Version;
			return x294bd621a33dc533.GenerateLicenseKeyForCustomer(assemblyProductName, machineName, version.Major, version.Minor, version.Build, customerID);
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00004DF8 File Offset: 0x00003DF8
		private bool IsTypeKeyValid(string key, Type type)
		{
			string[] array = x294bd621a33dc533.SplitLicenseString(key);
			int customerID = int.Parse(array[0], CultureInfo.InvariantCulture);
			return array[1] == this.GenerateLicenseKeyForType(type, customerID);
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00004E2C File Offset: 0x00003E2C
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

		// Token: 0x04000001 RID: 1
		private const string xed11756391d61907 = "Software\\\\Divelements Limited\\\\Registration";

		// Token: 0x04000002 RID: 2
		private static bool x4528b3b385025289;

		// Token: 0x04000003 RID: 3
		private static bool x0b277e20f7c1b92c;

		// Token: 0x04000004 RID: 4
		private static bool xba4ce277d393a202;

		// Token: 0x04000005 RID: 5
		private static bool x9fb6f00276c83908;
	}
}
