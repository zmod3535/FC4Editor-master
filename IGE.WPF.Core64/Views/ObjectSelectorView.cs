using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using IGE.Parameters;

namespace IGE.Views
{
	// Token: 0x020000EC RID: 236
	public class ObjectSelectorView : UserControl, IComponentConnector, IStyleConnector
	{
		// Token: 0x0600085D RID: 2141 RVA: 0x0001C782 File Offset: 0x0001A982
		public ObjectSelectorView()
		{
			this.InitializeComponent();
		}

		// Token: 0x170001E1 RID: 481
		// (get) Token: 0x0600085E RID: 2142 RVA: 0x0001C790 File Offset: 0x0001A990
		// (set) Token: 0x0600085F RID: 2143 RVA: 0x0001C79D File Offset: 0x0001A99D
		public double ListViewMaxHeight
		{
			get
			{
				return this.ListView.MaxHeight;
			}
			set
			{
				this.ListView.MaxHeight = value;
			}
		}

		// Token: 0x06000860 RID: 2144 RVA: 0x0001C7AC File Offset: 0x0001A9AC
		public void ObjectSelectorListView_ItemDoubleClick(object sender, MouseEventArgs e)
		{
			ObjectSelectorViewModel objectSelectorViewModel = (ObjectSelectorViewModel)base.DataContext;
			ICommand commandItemDoubleClick = objectSelectorViewModel.CommandItemDoubleClick;
			if (commandItemDoubleClick != null && commandItemDoubleClick.CanExecute(sender))
			{
				commandItemDoubleClick.Execute(sender);
			}
		}

		// Token: 0x06000861 RID: 2145 RVA: 0x0001C7E0 File Offset: 0x0001A9E0
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/IGE.WPF.Core64;component/views/parameters/advanced/objectselectorview.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000862 RID: 2146 RVA: 0x0001C810 File Offset: 0x0001AA10
		[DebuggerNonUserCode]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.ListView = (ListView)target;
				return;
			}
			this._contentLoaded = true;
		}

		// Token: 0x06000863 RID: 2147 RVA: 0x0001C838 File Offset: 0x0001AA38
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IStyleConnector.Connect(int connectionId, object target)
		{
			if (connectionId != 2)
			{
				return;
			}
			EventSetter eventSetter = new EventSetter();
			eventSetter.Event = Control.MouseDoubleClickEvent;
			eventSetter.Handler = new MouseButtonEventHandler(this.ObjectSelectorListView_ItemDoubleClick);
			((Style)target).Setters.Add(eventSetter);
		}

		// Token: 0x04000403 RID: 1027
		internal ListView ListView;

		// Token: 0x04000404 RID: 1028
		private bool _contentLoaded;
	}
}
