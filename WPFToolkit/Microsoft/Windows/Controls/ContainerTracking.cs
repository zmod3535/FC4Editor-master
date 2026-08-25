using System;
using System.Diagnostics;

namespace Microsoft.Windows.Controls
{
	// Token: 0x02000011 RID: 17
	internal class ContainerTracking<T>
	{
		// Token: 0x06000136 RID: 310 RVA: 0x000055A1 File Offset: 0x000037A1
		internal ContainerTracking(T container)
		{
			this._container = container;
		}

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x06000137 RID: 311 RVA: 0x000055B0 File Offset: 0x000037B0
		internal T Container
		{
			get
			{
				return this._container;
			}
		}

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x06000138 RID: 312 RVA: 0x000055B8 File Offset: 0x000037B8
		internal ContainerTracking<T> Next
		{
			get
			{
				return this._next;
			}
		}

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x06000139 RID: 313 RVA: 0x000055C0 File Offset: 0x000037C0
		internal ContainerTracking<T> Previous
		{
			get
			{
				return this._previous;
			}
		}

		// Token: 0x0600013A RID: 314 RVA: 0x000055C8 File Offset: 0x000037C8
		internal void StartTracking(ref ContainerTracking<T> root)
		{
			if (root != null)
			{
				root._previous = this;
			}
			this._next = root;
			root = this;
		}

		// Token: 0x0600013B RID: 315 RVA: 0x000055E4 File Offset: 0x000037E4
		internal void StopTracking(ref ContainerTracking<T> root)
		{
			if (this._previous != null)
			{
				this._previous._next = this._next;
			}
			if (this._next != null)
			{
				this._next._previous = this._previous;
			}
			if (root == this)
			{
				root = this._next;
			}
			this._previous = null;
			this._next = null;
		}

		// Token: 0x0600013C RID: 316 RVA: 0x0000563E File Offset: 0x0000383E
		[Conditional("DEBUG")]
		internal void Debug_AssertIsInList(ContainerTracking<T> root)
		{
		}

		// Token: 0x0600013D RID: 317 RVA: 0x00005640 File Offset: 0x00003840
		[Conditional("DEBUG")]
		internal void Debug_AssertNotInList(ContainerTracking<T> root)
		{
		}

		// Token: 0x04000044 RID: 68
		private T _container;

		// Token: 0x04000045 RID: 69
		private ContainerTracking<T> _next;

		// Token: 0x04000046 RID: 70
		private ContainerTracking<T> _previous;
	}
}
