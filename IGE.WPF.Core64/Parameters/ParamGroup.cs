using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace IGE.Parameters
{
	// Token: 0x02000379 RID: 889
	internal class ParamGroup : Parameter
	{
		// Token: 0x060013E0 RID: 5088 RVA: 0x00029CB2 File Offset: 0x00027EB2
		public ParamGroup(string groupName, IEnumerable<Parameter> parameters)
		{
			this._groupName = groupName;
			this.Parameters = ((parameters != null) ? new ObservableCollection<Parameter>(parameters) : null);
		}

		// Token: 0x1700025D RID: 605
		// (get) Token: 0x060013E1 RID: 5089 RVA: 0x00029CD3 File Offset: 0x00027ED3
		public string GroupName
		{
			get
			{
				return this._groupName;
			}
		}

		// Token: 0x1700025E RID: 606
		// (get) Token: 0x060013E2 RID: 5090 RVA: 0x00029CDB File Offset: 0x00027EDB
		// (set) Token: 0x060013E3 RID: 5091 RVA: 0x00029CE3 File Offset: 0x00027EE3
		public ObservableCollection<Parameter> Parameters
		{
			get
			{
				return this._parameters;
			}
			set
			{
				this._parameters = value;
				base.RaisePropertyChanged("Parameters");
			}
		}

		// Token: 0x04000752 RID: 1874
		private string _groupName;

		// Token: 0x04000753 RID: 1875
		private ObservableCollection<Parameter> _parameters;
	}
}
