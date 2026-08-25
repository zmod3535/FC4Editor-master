using System;
using System.ComponentModel;

namespace IGE.Nomad
{
	// Token: 0x020000B8 RID: 184
	public abstract class PropertyChangedClass : INotifyPropertyChanged
	{
		// Token: 0x14000006 RID: 6
		// (add) Token: 0x0600070F RID: 1807 RVA: 0x000196C4 File Offset: 0x000178C4
		// (remove) Token: 0x06000710 RID: 1808 RVA: 0x000196FC File Offset: 0x000178FC
		public event PropertyChangedEventHandler PropertyChanged;

		// Token: 0x06000711 RID: 1809 RVA: 0x00019734 File Offset: 0x00017934
		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
			if (propertyChanged != null)
			{
				propertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
