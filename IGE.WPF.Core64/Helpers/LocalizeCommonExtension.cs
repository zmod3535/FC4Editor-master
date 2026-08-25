using System;
using System.Windows;
using System.Windows.Markup;
using IGE.Nomad;

namespace IGE.Helpers
{
	// Token: 0x0200009E RID: 158
	internal class LocalizeCommonExtension : MarkupExtension
	{
		// Token: 0x0600067D RID: 1661 RVA: 0x0001768F File Offset: 0x0001588F
		public LocalizeCommonExtension(string id)
		{
			this._textId = id;
		}

		// Token: 0x0600067E RID: 1662 RVA: 0x0001769E File Offset: 0x0001589E
		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			if (!LocalizeCommonExtension.IsDesignMode)
			{
				return Localizer.LocalizeCommon(this._textId);
			}
			return this._textId;
		}

		// Token: 0x17000188 RID: 392
		// (get) Token: 0x0600067F RID: 1663 RVA: 0x000176B9 File Offset: 0x000158B9
		public static bool IsDesignMode
		{
			get
			{
				return Application.Current.GetType().FullName.StartsWith("System.");
			}
		}

		// Token: 0x0400028E RID: 654
		private readonly string _textId;
	}
}
