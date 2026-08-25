using System;
using System.ComponentModel;

namespace Microsoft.Windows.Controls
{
	// Token: 0x02000064 RID: 100
	public class DataGridAutoGeneratingColumnEventArgs : EventArgs
	{
		// Token: 0x06000787 RID: 1927 RVA: 0x00022336 File Offset: 0x00020536
		public DataGridAutoGeneratingColumnEventArgs(string propertyName, Type propertyType, DataGridColumn column) : this(column, propertyName, propertyType, null)
		{
		}

		// Token: 0x06000788 RID: 1928 RVA: 0x00022342 File Offset: 0x00020542
		internal DataGridAutoGeneratingColumnEventArgs(DataGridColumn column, ItemPropertyInfo itemPropertyInfo) : this(column, itemPropertyInfo.Name, itemPropertyInfo.PropertyType, itemPropertyInfo.Descriptor)
		{
		}

		// Token: 0x06000789 RID: 1929 RVA: 0x0002235D File Offset: 0x0002055D
		internal DataGridAutoGeneratingColumnEventArgs(DataGridColumn column, string propertyName, Type propertyType, object propertyDescriptor)
		{
			this._column = column;
			this._propertyName = propertyName;
			this._propertyType = propertyType;
			this.PropertyDescriptor = propertyDescriptor;
		}

		// Token: 0x170001CB RID: 459
		// (get) Token: 0x0600078A RID: 1930 RVA: 0x00022382 File Offset: 0x00020582
		// (set) Token: 0x0600078B RID: 1931 RVA: 0x0002238A File Offset: 0x0002058A
		public DataGridColumn Column
		{
			get
			{
				return this._column;
			}
			set
			{
				this._column = value;
			}
		}

		// Token: 0x170001CC RID: 460
		// (get) Token: 0x0600078C RID: 1932 RVA: 0x00022393 File Offset: 0x00020593
		public string PropertyName
		{
			get
			{
				return this._propertyName;
			}
		}

		// Token: 0x170001CD RID: 461
		// (get) Token: 0x0600078D RID: 1933 RVA: 0x0002239B File Offset: 0x0002059B
		public Type PropertyType
		{
			get
			{
				return this._propertyType;
			}
		}

		// Token: 0x170001CE RID: 462
		// (get) Token: 0x0600078E RID: 1934 RVA: 0x000223A3 File Offset: 0x000205A3
		// (set) Token: 0x0600078F RID: 1935 RVA: 0x000223AB File Offset: 0x000205AB
		public object PropertyDescriptor
		{
			get
			{
				return this._propertyDescriptor;
			}
			private set
			{
				if (value == null)
				{
					this._propertyDescriptor = null;
					return;
				}
				this._propertyDescriptor = value;
			}
		}

		// Token: 0x170001CF RID: 463
		// (get) Token: 0x06000790 RID: 1936 RVA: 0x000223BF File Offset: 0x000205BF
		// (set) Token: 0x06000791 RID: 1937 RVA: 0x000223C7 File Offset: 0x000205C7
		public bool Cancel
		{
			get
			{
				return this._cancel;
			}
			set
			{
				this._cancel = value;
			}
		}

		// Token: 0x04000265 RID: 613
		private DataGridColumn _column;

		// Token: 0x04000266 RID: 614
		private string _propertyName;

		// Token: 0x04000267 RID: 615
		private Type _propertyType;

		// Token: 0x04000268 RID: 616
		private object _propertyDescriptor;

		// Token: 0x04000269 RID: 617
		private bool _cancel;
	}
}
