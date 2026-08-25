using System;
using System.Windows;
using System.Windows.Markup;
using IGE.Nomad;

namespace IGE.Helpers
{
	// Token: 0x0200009D RID: 157
	internal class LocalizeExtension : MarkupExtension
	{
		// Token: 0x06000679 RID: 1657 RVA: 0x0001762E File Offset: 0x0001582E
		public LocalizeExtension(string id)
		{
			this._textId = id;
		}

		// Token: 0x0600067A RID: 1658 RVA: 0x0001763D File Offset: 0x0001583D
		public LocalizeExtension(string id, string section)
		{
			this._textId = id;
			this._section = section;
		}

		// Token: 0x0600067B RID: 1659 RVA: 0x00017653 File Offset: 0x00015853
		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			if (!LocalizeExtension.IsDesignMode)
			{
				return Localizer.Localize(this._textId, this._section);
			}
			return this._textId;
		}

		// Token: 0x17000187 RID: 391
		// (get) Token: 0x0600067C RID: 1660 RVA: 0x00017674 File Offset: 0x00015874
		public static bool IsDesignMode
		{
			get
			{
				return Application.Current.GetType().FullName.StartsWith("System.");
			}
		}

		// Token: 0x0400028C RID: 652
		private readonly string _textId;

		// Token: 0x0400028D RID: 653
		private readonly string _section;
	}
}
