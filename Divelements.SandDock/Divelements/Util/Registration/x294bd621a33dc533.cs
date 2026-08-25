using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Interop;
using Microsoft.Win32;

namespace Divelements.Util.Registration
{
	// Token: 0x02000032 RID: 50
	internal class x294bd621a33dc533 : LicenseProvider
	{
		// Token: 0x06000329 RID: 809 RVA: 0x0003DFDC File Offset: 0x0003C3DC
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

		// Token: 0x170000BE RID: 190
		// (get) Token: 0x0600032A RID: 810 RVA: 0x0003E078 File Offset: 0x0003C478
		public static bool StaticallyActivated
		{
			get
			{
				return x294bd621a33dc533.x0b277e20f7c1b92c;
			}
		}

		// Token: 0x0600032B RID: 811 RVA: 0x0003E080 File Offset: 0x0003C480
		private static Version GetVersionFromAssembly(Assembly assembly)
		{
			if (BrowserInteropHelper.IsBrowserHosted)
			{
				Assembly entryAssembly = Assembly.GetEntryAssembly();
				AssemblyName[] referencedAssemblies = entryAssembly.GetReferencedAssemblies();
				foreach (AssemblyName assemblyName in referencedAssemblies)
				{
					if (assemblyName.FullName == assembly.FullName)
					{
						return assemblyName.Version;
					}
				}
				return new Version(0, 0, 0, 0);
			}
			return assembly.GetName().Version;
		}

		// Token: 0x0600032C RID: 812 RVA: 0x0003E0F0 File Offset: 0x0003C4F0
		public static string[] SplitLicenseString(string s)
		{
			return new string[]
			{
				s.Substring(0, s.IndexOf('|')),
				s.Substring(s.IndexOf('|') + 1)
			};
		}

		// Token: 0x0600032D RID: 813 RVA: 0x0003E12C File Offset: 0x0003C52C
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

		// Token: 0x0600032E RID: 814 RVA: 0x0003E164 File Offset: 0x0003C564
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

		// Token: 0x0600032F RID: 815 RVA: 0x0003E1C0 File Offset: 0x0003C5C0
		public override License GetLicense(LicenseContext context, Type type, object instance, bool allowExceptions)
		{
			if (!x294bd621a33dc533.x0b277e20f7c1b92c)
			{
				if (BrowserInteropHelper.IsBrowserHosted)
				{
					throw new InvalidOperationException("Normal .net licensing does not work with XBAP applications. To activate this product, call the static ActivateProduct method before any user interface objects are created.");
				}
				if (context != null)
				{
					this.GetLicenseFileLines(type);
					if (x294bd621a33dc533.IsDebug)
					{
						this.WriteDebugMessage("licreq," + context.UsageMode.ToString());
					}
					int num;
					if (context.UsageMode == LicenseUsageMode.Runtime)
					{
						string savedLicenseKey = this.GetSavedLicenseKey(context, type);
						if (savedLicenseKey != null && this.IsTypeKeyValid(savedLicenseKey, type))
						{
							if (x294bd621a33dc533.IsDebug)
							{
								this.WriteDebugMessage("valid");
							}
							return new xbd7c5470fc89975b();
						}
						if (!x294bd621a33dc533.x4528b3b385025289 && this.DoesValidDevelopmentLicenseExist(type.Assembly, context, out num))
						{
							if (((uint)num | 15U) == 0U)
							{
								goto IL_124;
							}
							if (x294bd621a33dc533.IsDebug)
							{
								this.WriteDebugMessage("devok,notembedded");
							}
							string assemblyProductName = x294bd621a33dc533.GetAssemblyProductName(type.Assembly);
							string text = string.Concat(new string[]
							{
								"Warning: Although your development license for ",
								assemblyProductName,
								" is valid, it has not been embedded into your application by Visual Studio. This means that on a machine without ",
								assemblyProductName,
								" installed, the license will not be found. Normally, opening at least one form designer will ensure the licenses.licx file in your project is created and updated correctly. If you continue to see this message, ensure the following lines are present in the file."
							});
							text = text + Environment.NewLine + Environment.NewLine;
							text += this.GetLicenseFileLines(type);
							text = text + Environment.NewLine + Environment.NewLine;
							text += "Press OK to read more.";
							x294bd621a33dc533.ShowMessage(text, assemblyProductName);
							Process.Start("http://www.divelements.co.uk/net/support/kb/licensing.aspx");
							x294bd621a33dc533.x4528b3b385025289 = true;
						}
					}
					if (context.UsageMode == LicenseUsageMode.Designtime && this.DoesValidDevelopmentLicenseExist(type.Assembly, context, out num))
					{
						string key = num.ToString(CultureInfo.InvariantCulture) + "|" + this.GenerateLicenseKeyForType(type, num);
						context.SetSavedLicenseKey(type, key);
						if (x294bd621a33dc533.IsDebug)
						{
							this.WriteDebugMessage("valid");
							bool flag = (uint)num + (allowExceptions ? 1U : 0U) < 0U;
							if (flag)
							{
								goto IL_124;
							}
						}
						return new xbd7c5470fc89975b();
					}
				}
				if (x294bd621a33dc533.IsDebug)
				{
					this.WriteDebugMessage("eval");
				}
				return new x1d91faf71382de33();
			}
			IL_124:
			return new xbd7c5470fc89975b();
		}

		// Token: 0x06000330 RID: 816 RVA: 0x0003E3EC File Offset: 0x0003C7EC
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

		// Token: 0x06000331 RID: 817 RVA: 0x0003E470 File Offset: 0x0003C870
		internal static void ShowMessage(string message, string title)
		{
			MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Asterisk);
		}

		// Token: 0x06000332 RID: 818 RVA: 0x0003E480 File Offset: 0x0003C880
		private bool DoesValidDevelopmentLicenseExist(Assembly assembly, IServiceProvider serviceProvider, out int customerID)
		{
			customerID = 0;
			string assemblyProductName;
			string[] values;
			if (!false)
			{
				assemblyProductName = x294bd621a33dc533.GetAssemblyProductName(assembly);
				RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("Software\\Wow6432Node\\Divelements Limited\\Registration", false);
				if (registryKey == null)
				{
					goto IL_117;
				}
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
					values = new string[]
					{
						"A license key was found, but it is not valid. This usually means you are building against a different version of the assembly than the one you activated. You are building against version ",
						assembly.GetName().Version.ToString(),
						" and your machine name is ",
						Environment.MachineName,
						". A clean install of the product will solve this issue."
					};
				}
				else
				{
					if (x294bd621a33dc533.IsDebug)
					{
						this.WriteDebugMessage("novalue");
						goto IL_117;
					}
					goto IL_117;
				}
			}
			IL_F6:
			x294bd621a33dc533.ShowMessage(string.Concat(values), assemblyProductName);
			IL_117:
			RegistryKey registryKey2 = Registry.LocalMachine.OpenSubKey("Software\\\\Divelements Limited\\\\Registration", false);
			if (registryKey2 != null)
			{
				string text2 = (string)registryKey2.GetValue(assemblyProductName);
				if (text2 != null)
				{
					string[] array2 = x294bd621a33dc533.SplitLicenseString(text2);
					customerID = int.Parse(array2[0], CultureInfo.InvariantCulture);
					string[] array3;
					if (!false)
					{
						if (array2[1] == x294bd621a33dc533.GenerateLicenseKeyForCustomer(assembly, customerID))
						{
							return true;
						}
						if (x294bd621a33dc533.IsDebug)
						{
							this.WriteDebugMessage("licinvalid");
						}
						array3 = new string[5];
					}
					array3[0] = "A license key was found, but it is not valid. This usually means you are building against a different version of the assembly than the one you activated. You are building against version ";
					array3[1] = assembly.GetName().Version.ToString();
					array3[2] = " and your machine name is ";
					array3[3] = Environment.MachineName;
					array3[4] = ". A clean install of the product will solve this issue.";
					x294bd621a33dc533.ShowMessage(string.Concat(array3), assemblyProductName);
				}
				else if (x294bd621a33dc533.IsDebug)
				{
					this.WriteDebugMessage("novalue");
				}
			}
			else if (x294bd621a33dc533.IsDebug)
			{
				this.WriteDebugMessage("nokey");
				if (2 == 0)
				{
					goto IL_F6;
				}
			}
			return false;
		}

		// Token: 0x170000BF RID: 191
		// (get) Token: 0x06000333 RID: 819 RVA: 0x0003E670 File Offset: 0x0003CA70
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

		// Token: 0x06000334 RID: 820 RVA: 0x0003E70C File Offset: 0x0003CB0C
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

		// Token: 0x06000335 RID: 821 RVA: 0x0003E7C0 File Offset: 0x0003CBC0
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

		// Token: 0x06000336 RID: 822 RVA: 0x0003E86C File Offset: 0x0003CC6C
		public static string GenerateLicenseKeyForCustomer(Assembly assembly, int customerID)
		{
			string assemblyProductName = x294bd621a33dc533.GetAssemblyProductName(assembly);
			string machineName = Environment.MachineName;
			Version version = assembly.GetName().Version;
			return x294bd621a33dc533.GenerateLicenseKeyForCustomer(assemblyProductName, machineName, version.Major, version.Minor, version.Build, customerID);
		}

		// Token: 0x06000337 RID: 823 RVA: 0x0003E8AC File Offset: 0x0003CCAC
		private bool IsTypeKeyValid(string key, Type type)
		{
			string[] array = x294bd621a33dc533.SplitLicenseString(key);
			int customerID = int.Parse(array[0], CultureInfo.InvariantCulture);
			return array[1] == this.GenerateLicenseKeyForType(type, customerID);
		}

		// Token: 0x06000338 RID: 824 RVA: 0x0003E8E0 File Offset: 0x0003CCE0
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

		// Token: 0x04000124 RID: 292
		private const string xed11756391d61907 = "Software\\\\Divelements Limited\\\\Registration";

		// Token: 0x04000125 RID: 293
		private static bool x4528b3b385025289;

		// Token: 0x04000126 RID: 294
		private static bool x0b277e20f7c1b92c;

		// Token: 0x04000127 RID: 295
		private static bool xba4ce277d393a202;

		// Token: 0x04000128 RID: 296
		private static bool x9fb6f00276c83908;
	}
}
