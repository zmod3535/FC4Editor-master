using System;
using System.ComponentModel;

namespace IGE.Nomad
{
	// Token: 0x0200000C RID: 12
	public abstract class PropertyChangedSingleton<T> : INotifyPropertyChanged where T : class
	{
		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000034 RID: 52 RVA: 0x0000248D File Offset: 0x0000068D
		public static T Instance
		{
			get
			{
				return PropertyChangedSingleton<T>.instance.Value;
			}
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00002499 File Offset: 0x00000699
		private static T CreateInstance()
		{
			return Activator.CreateInstance(typeof(T), true) as T;
		}

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000036 RID: 54 RVA: 0x000024B8 File Offset: 0x000006B8
		// (remove) Token: 0x06000037 RID: 55 RVA: 0x000024F0 File Offset: 0x000006F0
		public event PropertyChangedEventHandler PropertyChanged;

		// Token: 0x06000038 RID: 56 RVA: 0x00002528 File Offset: 0x00000728
		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
			if (propertyChanged != null)
			{
				propertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		// Token: 0x06000039 RID: 57
		public abstract void UpdateValues();

		// Token: 0x04000011 RID: 17
		private static readonly Lazy<T> instance = new Lazy<T>(() => PropertyChangedSingleton<T>.CreateInstance());
	}
}
