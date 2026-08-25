using System;
using System.Globalization;
using System.Resources;

namespace Microsoft.Windows.Controls
{
	// Token: 0x02000021 RID: 33
	internal static class SR
	{
		// Token: 0x06000215 RID: 533 RVA: 0x00008D2F File Offset: 0x00006F2F
		internal static string Get(SRID id)
		{
			return SR._resourceManager.GetString(id.String);
		}

		// Token: 0x06000216 RID: 534 RVA: 0x00008D44 File Offset: 0x00006F44
		internal static string Get(SRID id, params object[] args)
		{
			string text = SR._resourceManager.GetString(id.String);
			if (text != null && args != null && args.Length > 0)
			{
				text = string.Format(CultureInfo.CurrentCulture, text, args);
			}
			return text;
		}

		// Token: 0x04000081 RID: 129
		private static ResourceManager _resourceManager = new ResourceManager("ExceptionStringTable", typeof(SR).Assembly);
	}
}
