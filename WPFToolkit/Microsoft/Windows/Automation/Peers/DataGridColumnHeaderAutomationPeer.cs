using System;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using Microsoft.Windows.Controls;
using Microsoft.Windows.Controls.Primitives;
using MS.Internal;

namespace Microsoft.Windows.Automation.Peers
{
	// Token: 0x0200001E RID: 30
	public sealed class DataGridColumnHeaderAutomationPeer : ButtonBaseAutomationPeer, IInvokeProvider, IScrollItemProvider, ITransformProvider
	{
		// Token: 0x060001E7 RID: 487 RVA: 0x00007C0A File Offset: 0x00005E0A
		public DataGridColumnHeaderAutomationPeer(DataGridColumnHeader owner) : base(owner)
		{
		}

		// Token: 0x060001E8 RID: 488 RVA: 0x00007C13 File Offset: 0x00005E13
		protected override AutomationControlType GetAutomationControlTypeCore()
		{
			return AutomationControlType.HeaderItem;
		}

		// Token: 0x060001E9 RID: 489 RVA: 0x00007C17 File Offset: 0x00005E17
		protected override string GetClassNameCore()
		{
			return base.Owner.GetType().Name;
		}

		// Token: 0x060001EA RID: 490 RVA: 0x00007C2C File Offset: 0x00005E2C
		public override object GetPattern(PatternInterface patternInterface)
		{
			if (patternInterface != PatternInterface.Invoke)
			{
				if (patternInterface == PatternInterface.ScrollItem)
				{
					return this;
				}
				if (patternInterface == PatternInterface.Transform)
				{
					if (this.OwningHeader.Column != null && this.OwningHeader.Column.DataGridOwner.CanUserResizeColumns)
					{
						return this;
					}
				}
			}
			else if (this.OwningHeader.Column != null && this.OwningHeader.Column.CanUserSort)
			{
				return this;
			}
			return base.GetPattern(patternInterface);
		}

		// Token: 0x060001EB RID: 491 RVA: 0x00007C9A File Offset: 0x00005E9A
		protected override bool IsContentElementCore()
		{
			return false;
		}

		// Token: 0x060001EC RID: 492 RVA: 0x00007CA0 File Offset: 0x00005EA0
		protected override bool IsOffscreenCore()
		{
			if (!base.Owner.IsVisible)
			{
				return true;
			}
			Rect rect = DataGridAutomationPeer.CalculateVisibleBoundingRect(base.Owner);
			return DoubleUtil.AreClose(rect, Rect.Empty) || DoubleUtil.AreClose(rect.Height, 0.0) || DoubleUtil.AreClose(rect.Width, 0.0);
		}

		// Token: 0x060001ED RID: 493 RVA: 0x00007D03 File Offset: 0x00005F03
		void IInvokeProvider.Invoke()
		{
			this.OwningHeader.Invoke();
		}

		// Token: 0x060001EE RID: 494 RVA: 0x00007D10 File Offset: 0x00005F10
		void IScrollItemProvider.ScrollIntoView()
		{
			if (this.OwningHeader.Column != null)
			{
				DataGrid dataGridOwner = this.OwningHeader.Column.DataGridOwner;
				if (dataGridOwner != null)
				{
					dataGridOwner.ScrollIntoView(null, this.OwningHeader.Column);
				}
			}
		}

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x060001EF RID: 495 RVA: 0x00007D50 File Offset: 0x00005F50
		bool ITransformProvider.CanMove
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x060001F0 RID: 496 RVA: 0x00007D53 File Offset: 0x00005F53
		bool ITransformProvider.CanResize
		{
			get
			{
				return this.OwningHeader.Column != null && this.OwningHeader.Column.DataGridOwner.CanUserResizeColumns;
			}
		}

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x060001F1 RID: 497 RVA: 0x00007D79 File Offset: 0x00005F79
		bool ITransformProvider.CanRotate
		{
			get
			{
				return false;
			}
		}

		// Token: 0x060001F2 RID: 498 RVA: 0x00007D7C File Offset: 0x00005F7C
		void ITransformProvider.Move(double x, double y)
		{
			throw new InvalidOperationException();
		}

		// Token: 0x060001F3 RID: 499 RVA: 0x00007D84 File Offset: 0x00005F84
		void ITransformProvider.Resize(double width, double height)
		{
			if (this.OwningHeader.Column != null && this.OwningHeader.Column.DataGridOwner.CanUserResizeColumns)
			{
				this.OwningHeader.Column.Width = new DataGridLength(width);
				return;
			}
			throw new InvalidOperationException();
		}

		// Token: 0x060001F4 RID: 500 RVA: 0x00007DD1 File Offset: 0x00005FD1
		void ITransformProvider.Rotate(double degrees)
		{
			throw new InvalidOperationException();
		}

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x060001F5 RID: 501 RVA: 0x00007DD8 File Offset: 0x00005FD8
		private DataGridColumnHeader OwningHeader
		{
			get
			{
				return (DataGridColumnHeader)base.Owner;
			}
		}
	}
}
