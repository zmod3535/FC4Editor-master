using System;
using System.Windows;
using Ubisoft;

namespace IGE.Parameters
{
	// Token: 0x02000002 RID: 2
	internal abstract class Parameter : ViewModel
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		protected Parameter()
		{
			this.Enabled = true;
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000002 RID: 2 RVA: 0x0000205F File Offset: 0x0000025F
		// (set) Token: 0x06000003 RID: 3 RVA: 0x00002067 File Offset: 0x00000267
		public bool Enabled
		{
			get
			{
				return this._enabled;
			}
			set
			{
				if (this._enabled == value)
				{
					return;
				}
				this._enabled = value;
				base.RaisePropertyChanged("Enabled");
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000004 RID: 4 RVA: 0x00002085 File Offset: 0x00000285
		// (set) Token: 0x06000005 RID: 5 RVA: 0x0000208D File Offset: 0x0000028D
		public Visibility Visible
		{
			get
			{
				return this._visible;
			}
			set
			{
				if (this._visible == value)
				{
					return;
				}
				this._visible = value;
				base.RaisePropertyChanged("Visible");
			}
		}

		// Token: 0x04000001 RID: 1
		private bool _enabled;

		// Token: 0x04000002 RID: 2
		private Visibility _visible;
	}
}
