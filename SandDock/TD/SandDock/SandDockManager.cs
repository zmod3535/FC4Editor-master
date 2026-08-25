using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Xml;
using Divelements.Util.Registration;
using TD.SandDock.Rendering;

namespace TD.SandDock
{
	// Token: 0x02000009 RID: 9
	[DefaultEvent("ActiveTabbedDocumentChanged")]
	[ToolboxBitmap(typeof(SandDockManager))]
	[Designer("TD.SandDock.Design.SandDockManagerDesigner, SandDock.Design, Version=1.0.0.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3")]
	public class SandDockManager : Component
	{
		// Token: 0x14000002 RID: 2
		// (add) Token: 0x06000068 RID: 104 RVA: 0x00007FE0 File Offset: 0x00006FE0
		// (remove) Token: 0x06000069 RID: 105 RVA: 0x00007FFC File Offset: 0x00006FFC
		public event EventHandler DockingStarted
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.xc5f1fda5242cf905 = (EventHandler)Delegate.Combine(this.xc5f1fda5242cf905, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.xc5f1fda5242cf905 = (EventHandler)Delegate.Remove(this.xc5f1fda5242cf905, value);
			}
		}

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x0600006A RID: 106 RVA: 0x00008018 File Offset: 0x00007018
		// (remove) Token: 0x0600006B RID: 107 RVA: 0x00008034 File Offset: 0x00007034
		public event EventHandler DockingFinished
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.x2556ec4d28ceecee = (EventHandler)Delegate.Combine(this.x2556ec4d28ceecee, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.x2556ec4d28ceecee = (EventHandler)Delegate.Remove(this.x2556ec4d28ceecee, value);
			}
		}

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x0600006C RID: 108 RVA: 0x00008050 File Offset: 0x00007050
		// (remove) Token: 0x0600006D RID: 109 RVA: 0x0000806C File Offset: 0x0000706C
		public event ShowControlContextMenuEventHandler ShowControlContextMenu
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.x8956f13386ebab05 = (ShowControlContextMenuEventHandler)Delegate.Combine(this.x8956f13386ebab05, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.x8956f13386ebab05 = (ShowControlContextMenuEventHandler)Delegate.Remove(this.x8956f13386ebab05, value);
			}
		}

		// Token: 0x14000005 RID: 5
		// (add) Token: 0x0600006E RID: 110 RVA: 0x00008088 File Offset: 0x00007088
		// (remove) Token: 0x0600006F RID: 111 RVA: 0x000080A4 File Offset: 0x000070A4
		public event DockControlEventHandler DockControlActivated
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.x505fd87f59cc2876 = (DockControlEventHandler)Delegate.Combine(this.x505fd87f59cc2876, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.x505fd87f59cc2876 = (DockControlEventHandler)Delegate.Remove(this.x505fd87f59cc2876, value);
			}
		}

		// Token: 0x14000006 RID: 6
		// (add) Token: 0x06000070 RID: 112 RVA: 0x000080C0 File Offset: 0x000070C0
		// (remove) Token: 0x06000071 RID: 113 RVA: 0x000080DC File Offset: 0x000070DC
		public event DockControlEventHandler DockControlAdded
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.x528e78a16a92fb41 = (DockControlEventHandler)Delegate.Combine(this.x528e78a16a92fb41, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.x528e78a16a92fb41 = (DockControlEventHandler)Delegate.Remove(this.x528e78a16a92fb41, value);
			}
		}

		// Token: 0x14000007 RID: 7
		// (add) Token: 0x06000072 RID: 114 RVA: 0x000080F8 File Offset: 0x000070F8
		// (remove) Token: 0x06000073 RID: 115 RVA: 0x00008114 File Offset: 0x00007114
		public event DockControlEventHandler DockControlRemoved
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.xbc613baf913a9f51 = (DockControlEventHandler)Delegate.Combine(this.xbc613baf913a9f51, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.xbc613baf913a9f51 = (DockControlEventHandler)Delegate.Remove(this.xbc613baf913a9f51, value);
			}
		}

		// Token: 0x14000008 RID: 8
		// (add) Token: 0x06000074 RID: 116 RVA: 0x00008130 File Offset: 0x00007130
		// (remove) Token: 0x06000075 RID: 117 RVA: 0x0000814C File Offset: 0x0000714C
		public event ResolveDockControlEventHandler ResolveDockControl
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.x745fd7b95ab555c4 = (ResolveDockControlEventHandler)Delegate.Combine(this.x745fd7b95ab555c4, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.x745fd7b95ab555c4 = (ResolveDockControlEventHandler)Delegate.Remove(this.x745fd7b95ab555c4, value);
			}
		}

		// Token: 0x14000009 RID: 9
		// (add) Token: 0x06000076 RID: 118 RVA: 0x00008168 File Offset: 0x00007168
		// (remove) Token: 0x06000077 RID: 119 RVA: 0x00008184 File Offset: 0x00007184
		public event EventHandler ActiveTabbedDocumentChanged
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.x9e34f522d048dee6 = (EventHandler)Delegate.Combine(this.x9e34f522d048dee6, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.x9e34f522d048dee6 = (EventHandler)Delegate.Remove(this.x9e34f522d048dee6, value);
			}
		}

		// Token: 0x1400000A RID: 10
		// (add) Token: 0x06000078 RID: 120 RVA: 0x000081A0 File Offset: 0x000071A0
		// (remove) Token: 0x06000079 RID: 121 RVA: 0x000081BC File Offset: 0x000071BC
		public event DockControlClosingEventHandler DockControlClosing
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.x81beccfee80d0f84 = (DockControlClosingEventHandler)Delegate.Combine(this.x81beccfee80d0f84, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.x81beccfee80d0f84 = (DockControlClosingEventHandler)Delegate.Remove(this.x81beccfee80d0f84, value);
			}
		}

		// Token: 0x1400000B RID: 11
		// (add) Token: 0x0600007A RID: 122 RVA: 0x000081D8 File Offset: 0x000071D8
		// (remove) Token: 0x0600007B RID: 123 RVA: 0x000081F4 File Offset: 0x000071F4
		public event ActiveFilesListEventHandler ShowActiveFilesList
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.x310e5e7c96407793 = (ActiveFilesListEventHandler)Delegate.Combine(this.x310e5e7c96407793, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.x310e5e7c96407793 = (ActiveFilesListEventHandler)Delegate.Remove(this.x310e5e7c96407793, value);
			}
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00008210 File Offset: 0x00007210
		public SandDockManager()
		{
			this.x38870620fd380a6b = new WhidbeyRenderer();
			this.xd27fa35d10494112 = new ArrayList();
			this.x8fb2a5bf0df0416f = new Hashtable();
			this.xa90af1bb0ada0f53 = new ArrayList();
		}

		// Token: 0x0600007D RID: 125 RVA: 0x000082A4 File Offset: 0x000072A4
		public DockControl FindMostRecentlyUsedWindow()
		{
			return this.FindMostRecentlyUsedWindow((DockSituation)(-1));
		}

		// Token: 0x0600007E RID: 126 RVA: 0x000082B0 File Offset: 0x000072B0
		public DockControl FindMostRecentlyUsedWindow(DockSituation dockSituation)
		{
			return this.FindMostRecentlyUsedWindow(dockSituation, null);
		}

		// Token: 0x0600007F RID: 127 RVA: 0x000082BC File Offset: 0x000072BC
		internal DockControl FindMostRecentlyUsedWindow(DockSituation dockSituation, DockControl notThisOne)
		{
			DateTime t = DateTime.MinValue;
			DockControl result = null;
			DockControl[] dockControls = this.GetDockControls();
			int num = 0;
			if (!false)
			{
				goto IL_100;
			}
			goto IL_1C;
			DockControl dockControl;
			for (;;)
			{
				IL_50:
				if (dockControl.MetaData.LastFocused >= t)
				{
					goto IL_63;
				}
				bool flag = (uint)num - (uint)num < 0U;
				if (!flag)
				{
					break;
				}
				if (((uint)num & 0U) != 0U)
				{
					goto IL_4E;
				}
				goto IL_6E;
				IL_0B:
				if (dockControl.DockSituation == dockSituation)
				{
					goto IL_DE;
				}
				if (!false)
				{
					break;
				}
				continue;
				IL_63:
				if (dockSituation == (DockSituation)(-1))
				{
					goto IL_C7;
				}
				if (15 != 0 && 4 != 0)
				{
					goto IL_0B;
				}
				goto IL_6E;
				IL_4E:
				goto IL_63;
				IL_6E:
				if (!false)
				{
					goto IL_0B;
				}
				goto IL_4E;
			}
			goto IL_2E;
			IL_C7:
			t = dockControl.MetaData.LastFocused;
			result = dockControl;
			if (4 != 0)
			{
				if (4 != 0)
				{
				}
				goto IL_2E;
			}
			goto IL_100;
			IL_DE:
			goto IL_C7;
			IL_1C:
			if ((uint)num < 0U)
			{
				if (2 != 0)
				{
					goto IL_50;
				}
				goto IL_78;
			}
			IL_2E:
			num++;
			IL_34:
			if (num >= dockControls.Length)
			{
				return result;
			}
			dockControl = dockControls[num];
			IL_78:
			if (dockControl != notThisOne)
			{
				goto IL_50;
			}
			goto IL_1C;
			IL_100:
			goto IL_34;
		}

		// Token: 0x06000080 RID: 128 RVA: 0x000083D4 File Offset: 0x000073D4
		protected internal virtual void OnShowActiveFilesList(ActiveFilesListEventArgs e)
		{
			if (this.x310e5e7c96407793 != null)
			{
				this.x310e5e7c96407793(this, e);
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000081 RID: 129 RVA: 0x000083EC File Offset: 0x000073EC
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public DockControl ActiveTabbedDocument
		{
			get
			{
				return this.x4daa1b665423612a;
			}
		}

		// Token: 0x06000082 RID: 130 RVA: 0x000083F4 File Offset: 0x000073F4
		private void SetActiveTabbedDocument(DockControl value)
		{
			if (value != null)
			{
				goto IL_BA;
			}
			goto IL_42;
			IL_23:
			if (!false)
			{
				return;
			}
			goto IL_42;
			IL_34:
			this.OnActiveTabbedDocumentChanged(EventArgs.Empty);
			if (!false)
			{
				goto IL_23;
			}
			IL_42:
			if (value == this.x4daa1b665423612a)
			{
				if (-2 == 0)
				{
					goto IL_23;
				}
				if (false)
				{
					goto IL_53;
				}
				if (!false)
				{
					if (-1 == 0)
					{
						goto IL_BA;
					}
					if (2147483647 == 0)
					{
						goto IL_8C;
					}
					if (3 == 0)
					{
						goto IL_BA;
					}
					return;
				}
			}
			else if (this.x4daa1b665423612a == null)
			{
				goto IL_85;
			}
			this.x4daa1b665423612a.DockSituationChanged -= this.OnActiveTabbedDocumentDockSituationChanged;
			this.x4daa1b665423612a.x7735d9a753c63a0a();
			goto IL_85;
			IL_53:
			this.x4daa1b665423612a.x7735d9a753c63a0a();
			goto IL_34;
			IL_85:
			this.x4daa1b665423612a = value;
			IL_8C:
			if (this.x4daa1b665423612a == null)
			{
				goto IL_34;
			}
			if (!false)
			{
				this.x4daa1b665423612a.DockSituationChanged += this.OnActiveTabbedDocumentDockSituationChanged;
				goto IL_53;
			}
			goto IL_23;
			IL_BA:
			if (value.DockSituation == DockSituation.Document)
			{
				goto IL_42;
			}
			if (4 != 0)
			{
				throw new ArgumentException("The specified window is not currently being displayed as a document, therefore it cannot be set as the active document.", "value");
			}
			goto IL_85;
		}

		// Token: 0x06000083 RID: 131 RVA: 0x000084F8 File Offset: 0x000074F8
		private void OnActiveTabbedDocumentDockSituationChanged(object sender, EventArgs e)
		{
			DockControl dockControl = (DockControl)sender;
			if (dockControl.DockSituation != DockSituation.Document)
			{
				this.SetActiveTabbedDocument(this.FindMostRecentlyUsedWindow(DockSituation.Document));
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000084 RID: 132 RVA: 0x00008528 File Offset: 0x00007528
		// (set) Token: 0x06000085 RID: 133 RVA: 0x00008530 File Offset: 0x00007530
		[Category("Behavior")]
		[Description("Indicates whether an empty container is left when all tabbed documents have been removed.")]
		[DefaultValue(false)]
		public bool EnableEmptyEnvironment
		{
			get
			{
				return this.xac286b48606510c1;
			}
			set
			{
				this.xac286b48606510c1 = value;
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000086 RID: 134 RVA: 0x0000853C File Offset: 0x0000753C
		// (set) Token: 0x06000087 RID: 135 RVA: 0x00008544 File Offset: 0x00007544
		[Description("The type of border to be drawn around the tabbed document area.")]
		[DefaultValue(typeof(TD.SandDock.Rendering.BorderStyle), "Flat")]
		[Category("Appearance")]
		public TD.SandDock.Rendering.BorderStyle BorderStyle
		{
			get
			{
				return this.xacfbd7a08ba56c78;
			}
			set
			{
				this.xacfbd7a08ba56c78 = value;
				if (this.DocumentContainer != null)
				{
					this.DocumentContainer.x64b4c49ed703037e = this.xacfbd7a08ba56c78;
				}
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000088 RID: 136 RVA: 0x0000856C File Offset: 0x0000756C
		[Browsable(false)]
		public DocumentContainer DocumentContainer
		{
			get
			{
				return this.x1f1a3b29d7ed7776;
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000089 RID: 137 RVA: 0x00008574 File Offset: 0x00007574
		// (set) Token: 0x0600008A RID: 138 RVA: 0x0000857C File Offset: 0x0000757C
		[Description("Determines how document tabs that overflow past the visible area are accessed.")]
		[Category("Behavior")]
		[DefaultValue(typeof(DocumentOverflowMode), "Scrollable")]
		public DocumentOverflowMode DocumentOverflow
		{
			get
			{
				return this.x8362acb4106ff84c;
			}
			set
			{
				if (value != this.x8362acb4106ff84c)
				{
					this.x8362acb4106ff84c = value;
					if (this.DocumentContainer != null || false)
					{
						this.DocumentContainer.x7d2c5325d16e569d = this.DocumentOverflow;
					}
				}
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x0600008B RID: 139 RVA: 0x000085B0 File Offset: 0x000075B0
		// (set) Token: 0x0600008C RID: 140 RVA: 0x000085B8 File Offset: 0x000075B8
		[Description("Specifies whether documents are opened at the first position or the last.")]
		[Category("Behavior")]
		[DefaultValue(typeof(DocumentContainerWindowOpenPosition), "Last")]
		public DocumentContainerWindowOpenPosition DocumentOpenPosition
		{
			get
			{
				return this.xf57f78376726d093;
			}
			set
			{
				this.xf57f78376726d093 = value;
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x0600008D RID: 141 RVA: 0x000085C4 File Offset: 0x000075C4
		// (set) Token: 0x0600008E RID: 142 RVA: 0x000085CC File Offset: 0x000075CC
		[Description("Indicates whether the close button is displayed inside the active tab.")]
		[Category("Behavior")]
		[DefaultValue(false)]
		public bool IntegralClose
		{
			get
			{
				return this.x26be2ab374407894;
			}
			set
			{
				if (value != this.x26be2ab374407894)
				{
					this.x26be2ab374407894 = value;
					if (((value ? 1U : 0U) & 0U) != 0U)
					{
						if (!true)
						{
							return;
						}
					}
					else if (this.DocumentContainer == null)
					{
						return;
					}
					this.DocumentContainer.xa957e8f86f5e6115 = this.IntegralClose;
				}
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x0600008F RID: 143 RVA: 0x00008620 File Offset: 0x00007620
		// (set) Token: 0x06000090 RID: 144 RVA: 0x00008628 File Offset: 0x00007628
		[Description("Indicates whether tabbed documents can be shown in the centre of the container.")]
		[DefaultValue(true)]
		[Category("Behavior")]
		public bool EnableTabbedDocuments
		{
			get
			{
				return this.xd76156c80fb2abda;
			}
			set
			{
				if (this.FindDockedContainer(DockStyle.Fill) != null)
				{
					throw new InvalidOperationException("This property can only be changed when there are no DockControls being shown in the centre of the container.");
				}
				this.xd76156c80fb2abda = value;
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000091 RID: 145 RVA: 0x00008648 File Offset: 0x00007648
		[Browsable(false)]
		[Obsolete("Use the GetDockControls method passing DockSituation.Document instead.")]
		public DockControl[] Documents
		{
			get
			{
				return this.GetDockControls(DockSituation.Document);
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000092 RID: 146 RVA: 0x00008654 File Offset: 0x00007654
		// (set) Token: 0x06000093 RID: 147 RVA: 0x0000865C File Offset: 0x0000765C
		[DefaultValue(false)]
		[Description("Indicates whether the user-configured window layout is automatically persisted.")]
		[Category("Behavior")]
		public bool AutoSaveLayout
		{
			get
			{
				return this.x2b7e44f0a217252e;
			}
			set
			{
				this.x2b7e44f0a217252e = value;
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x06000094 RID: 148 RVA: 0x00008668 File Offset: 0x00007668
		// (set) Token: 0x06000095 RID: 149 RVA: 0x00008670 File Offset: 0x00007670
		[Description("Indicates whether the user will be able to use the keyboard to navigate between tabbed documents and dockable windows.")]
		[DefaultValue(true)]
		[Category("Behavior")]
		public bool AllowKeyboardNavigation
		{
			get
			{
				return this.xab09a805ddd3c3a1;
			}
			set
			{
				this.xab09a805ddd3c3a1 = value;
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x06000096 RID: 150 RVA: 0x0000867C File Offset: 0x0000767C
		// (set) Token: 0x06000097 RID: 151 RVA: 0x00008684 File Offset: 0x00007684
		[Category("Behavior")]
		[Description("Indicates whether the middle mouse button can be used to close windows by their tabs.")]
		[DefaultValue(true)]
		public bool AllowMiddleButtonClosure
		{
			get
			{
				return this.x46d0951c16d6ad61;
			}
			set
			{
				this.x46d0951c16d6ad61 = value;
			}
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000098 RID: 152 RVA: 0x00008690 File Offset: 0x00007690
		// (set) Token: 0x06000099 RID: 153 RVA: 0x00008698 File Offset: 0x00007698
		[Description("Indicates whether standard validation events are fired when the user changes tabs.")]
		[Category("Behavior")]
		[DefaultValue(false)]
		public bool RaiseValidationEvents
		{
			get
			{
				return this.xcc4067ee19f6f422;
			}
			set
			{
				this.xcc4067ee19f6f422 = value;
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x0600009A RID: 154 RVA: 0x000086A4 File Offset: 0x000076A4
		// (set) Token: 0x0600009B RID: 155 RVA: 0x000086AC File Offset: 0x000076AC
		[DefaultValue(false)]
		[Category("Behavior")]
		[Description("Indicates whether window groups will respond when an OLE drag operation occurs over their tabs.")]
		public bool SelectTabsOnDrag
		{
			get
			{
				return this.xb379517eb20fde45;
			}
			set
			{
				this.xb379517eb20fde45 = value;
				foreach (object obj in this.xd27fa35d10494112)
				{
					DockContainer dockContainer = (DockContainer)obj;
					dockContainer.AllowDrop = value;
				}
				foreach (object obj2 in this.xa90af1bb0ada0f53)
				{
					x10ac79a4257c7f52 x10ac79a4257c7f = (x10ac79a4257c7f52)obj2;
					x10ac79a4257c7f.AllowDrop = value;
				}
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x0600009C RID: 156 RVA: 0x00008778 File Offset: 0x00007778
		// (set) Token: 0x0600009D RID: 157 RVA: 0x00008780 File Offset: 0x00007780
		[Description("Indicates whether tabbed document layout will be serialized alongside dockable window layout.")]
		[Category("Serialization")]
		[DefaultValue(false)]
		public bool SerializeTabbedDocuments
		{
			get
			{
				return this.x1bb166050445ea16;
			}
			set
			{
				this.x1bb166050445ea16 = value;
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x0600009E RID: 158 RVA: 0x0000878C File Offset: 0x0000778C
		// (set) Token: 0x0600009F RID: 159 RVA: 0x00008794 File Offset: 0x00007794
		[DefaultValue(true)]
		[Description("Indicates whether DockContainers can be resized by the user.")]
		[Category("Behavior")]
		public bool AllowDockContainerResize
		{
			get
			{
				return this.xf702e23ec6dfb474;
			}
			set
			{
				this.xf702e23ec6dfb474 = value;
				DockContainer[] orderedDockedDockContainerList = this.GetOrderedDockedDockContainerList();
				int num = 0;
				if (true)
				{
					goto IL_13;
				}
				IL_0F:
				num++;
				IL_13:
				if (num >= orderedDockedDockContainerList.Length)
				{
					return;
				}
				DockContainer dockContainer = orderedDockedDockContainerList[num];
				dockContainer.CalculateAllMetricsAndLayout();
				goto IL_0F;
			}
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x000087D4 File Offset: 0x000077D4
		internal x10ac79a4257c7f52 GetAutoHideBar(DockStyle dock)
		{
			if (dock != DockStyle.Fill)
			{
				while (dock != DockStyle.None)
				{
					foreach (object obj in this.xa90af1bb0ada0f53)
					{
						x10ac79a4257c7f52 x10ac79a4257c7f = (x10ac79a4257c7f52)obj;
						if (x10ac79a4257c7f.Dock == dock)
						{
							x10ac79a4257c7f52 result;
							do
							{
								result = x10ac79a4257c7f;
							}
							while (false);
							return result;
						}
					}
					this.DockSystemContainer.SuspendLayout();
					try
					{
						x10ac79a4257c7f52 x10ac79a4257c7f2 = new x10ac79a4257c7f52();
						x10ac79a4257c7f2.x460ab163f44a604d = this;
						do
						{
							x10ac79a4257c7f2.Dock = dock;
							x10ac79a4257c7f2.Parent = this.DockSystemContainer;
						}
						while (false);
						this.DockSystemContainer.Controls.SetChildIndex(x10ac79a4257c7f2, this.GetOutsideControlIndex(this.DockSystemContainer, dock));
						return x10ac79a4257c7f2;
					}
					finally
					{
						this.DockSystemContainer.ResumeLayout();
					}
				}
			}
			return null;
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x000088E0 File Offset: 0x000078E0
		protected virtual DockContainer CreateNewDockContainerCore(ContainerDockLocation dockLocation)
		{
			if (dockLocation == ContainerDockLocation.Center && this.EnableTabbedDocuments)
			{
				return new DocumentContainer();
			}
			return new DockContainer();
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x000088FC File Offset: 0x000078FC
		public DockContainer CreateNewDockContainer(ContainerDockLocation dockLocation, ContainerDockEdge edge, int contentSize)
		{
			this.EnsureDockSystemContainer();
			this.DockSystemContainer.SuspendLayout();
			DockContainer result;
			try
			{
				DockContainer dockContainer = this.CreateNewDockContainerCore(dockLocation);
				int num;
				for (;;)
				{
					IL_171:
					dockContainer.Manager = this;
					DockStyle dockStyle = LayoutUtilities.xf8330a3964a419ba(dockLocation);
					dockContainer.Dock = dockStyle;
					dockContainer.ContentSize = contentSize;
					IntPtr handle = dockContainer.Handle;
					if (dockLocation != ContainerDockLocation.Center)
					{
						bool flag = (uint)num + (uint)contentSize > uint.MaxValue;
						if (flag)
						{
							continue;
						}
						if (edge == ContainerDockEdge.Inside)
						{
							num = this.GetInsideControlIndex(this.DockSystemContainer);
							flag = ((uint)contentSize + (uint)num < 0U);
							if (flag)
							{
								goto IL_13F;
							}
						}
						else
						{
							num = this.GetOutsideControlIndex(this.DockSystemContainer, dockStyle);
						}
					}
					else
					{
						num = 0;
					}
					for (;;)
					{
						this.DockSystemContainer.Controls.Add(dockContainer);
						for (;;)
						{
							this.DockSystemContainer.Controls.SetChildIndex(dockContainer, num);
							if (false)
							{
								break;
							}
							if ((uint)num - (uint)contentSize > 4294967295U)
							{
								goto IL_171;
							}
							if (((uint)contentSize | 4294967294U) != 0U)
							{
								goto Block_5;
							}
						}
					}
				}
				Block_5:
				using (IEnumerator enumerator = this.DockSystemContainer.Controls.GetEnumerator())
				{
					IL_95:
					while (enumerator.MoveNext())
					{
						object obj = enumerator.Current;
						Control control = (Control)obj;
						x87cf4de36131799d x87cf4de36131799d = control as x87cf4de36131799d;
						while (x87cf4de36131799d == null)
						{
							bool flag = (uint)num > uint.MaxValue;
							if (flag)
							{
								goto IL_D6;
							}
							if (((uint)num | 15U) != 0U)
							{
								goto IL_95;
							}
						}
						x87cf4de36131799d.BringToFront();
						continue;
						IL_D6:
						break;
					}
				}
				result = dockContainer;
				IL_13F:;
			}
			finally
			{
				this.DockSystemContainer.ResumeLayout();
			}
			return result;
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x00008AE8 File Offset: 0x00007AE8
		private int GetInsideControlIndex(Control container)
		{
			int num = int.MaxValue;
			int num2;
			if ((uint)num2 <= 4294967295U)
			{
				num2 = container.Controls.Count - 1;
				goto IL_16;
			}
			goto IL_60;
			IL_12:
			num2--;
			IL_16:
			Control control;
			if (num2 < 0)
			{
				bool flag = (uint)num + (uint)num < 0U;
				if (!flag)
				{
					return num;
				}
			}
			else
			{
				control = container.Controls[num2];
			}
			while (control.Dock != DockStyle.Fill)
			{
				if (false || 8 != 0)
				{
					goto IL_60;
				}
			}
			goto IL_12;
			IL_60:
			if (control.Dock == DockStyle.None)
			{
				if (true)
				{
					goto IL_12;
				}
			}
			if (num2 >= num)
			{
				goto IL_12;
			}
			num = num2;
			goto IL_12;
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x00008B90 File Offset: 0x00007B90
		internal DockContainer[] GetDockContainers(DockStyle dockStyle)
		{
			int num;
			DockContainer[] array;
			if (dockStyle == DockStyle.Fill)
			{
				bool flag = (uint)num < 0U;
				if (!flag)
				{
					goto IL_10E;
				}
			}
			else
			{
				if (this.DockSystemContainer == null)
				{
					return new DockContainer[0];
				}
				array = new DockContainer[this.DockSystemContainer.Controls.Count];
				if (!false)
				{
				}
				int num2;
				if (((uint)num2 | 4U) != 0U)
				{
					num = 0;
					num2 = this.DockSystemContainer.Controls.Count - 1;
					goto IL_3F;
				}
				IL_3B:
				num2--;
				IL_3F:
				if (num2 < 0)
				{
					bool flag = (uint)num2 > uint.MaxValue;
					if (!flag)
					{
						goto IL_B2;
					}
				}
				DockContainer dockContainer = this.DockSystemContainer.Controls[num2] as DockContainer;
				if (dockContainer == null)
				{
					goto IL_3B;
				}
				if ((uint)num + (uint)num2 <= 4294967295U)
				{
					while (dockContainer.Dock == dockStyle)
					{
						array[num++] = dockContainer;
						if (!false)
						{
							break;
						}
						bool flag = (uint)num2 + (uint)num2 < 0U;
						if (flag)
						{
							goto IL_B2;
						}
					}
					goto IL_3B;
				}
				goto IL_10E;
				IL_B2:;
			}
			DockContainer[] array2 = new DockContainer[num];
			Array.Copy(array, array2, num);
			return array2;
			IL_10E:
			throw new ArgumentException("dockStyle");
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x00008CC8 File Offset: 0x00007CC8
		private int GetOutsideControlIndex(Control container, DockStyle dockStyle)
		{
			int num = container.Controls.Count;
			int num2;
			if (((uint)num & 0U) == 0U)
			{
				num2 = container.Controls.Count - 1;
				goto IL_85;
			}
			bool flag = (uint)num2 > uint.MaxValue;
			if (flag)
			{
				goto IL_AB;
			}
			goto IL_CE;
			IL_55:
			flag = ((uint)num2 < 0U);
			if (!flag)
			{
				goto IL_BD;
			}
			IL_67:
			Control control;
			if (!(control is DockContainer))
			{
				flag = ((uint)num - (uint)num2 > uint.MaxValue);
				if (flag)
				{
					goto IL_55;
				}
				goto IL_81;
			}
			IL_6F:
			if (control.Dock != dockStyle)
			{
				goto IL_55;
			}
			if (4 == 0)
			{
				goto IL_AB;
			}
			return num;
			IL_81:
			num2--;
			IL_85:
			if (num2 >= 0)
			{
				control = container.Controls[num2];
				goto IL_E3;
			}
			if (((uint)num2 | 1U) != 0U)
			{
				return num;
			}
			goto IL_81;
			IL_AB:
			if ((uint)num2 > 4294967295U)
			{
				goto IL_55;
			}
			IL_BD:
			goto IL_81;
			IL_CE:
			num = num2;
			if (!false)
			{
				if (3 != 0)
				{
					goto IL_67;
				}
				goto IL_6F;
			}
			IL_E3:
			if (control.Dock == DockStyle.Fill)
			{
				if (!(control is MdiClient))
				{
					return num;
				}
				if (false)
				{
					goto IL_CE;
				}
			}
			if (control is DockContainer)
			{
				goto IL_67;
			}
			goto IL_CE;
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x00008DF8 File Offset: 0x00007DF8
		private void EnsureDockSystemContainer()
		{
			if (this.DockSystemContainer == null)
			{
				throw new InvalidOperationException("This SandDockManager does not have its DockSystemContainer property set.");
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x060000A7 RID: 167 RVA: 0x00008E10 File Offset: 0x00007E10
		// (set) Token: 0x060000A8 RID: 168 RVA: 0x00008E18 File Offset: 0x00007E18
		[Description("The control that will act as a container for all docked windows. You should rarely, if ever, need to change this property.")]
		[Category("Advanced")]
		public Control DockSystemContainer
		{
			get
			{
				return this.x7478f4855b6bd03d;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				if (!(value is DockContainer))
				{
					if (value != this.x7478f4855b6bd03d)
					{
						ArrayList arrayList = new ArrayList();
						using (IEnumerator enumerator = this.xd27fa35d10494112.GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								object obj = enumerator.Current;
								DockContainer dockContainer = (DockContainer)obj;
								if (dockContainer.Parent != null && dockContainer.Parent != value)
								{
									arrayList.Add(dockContainer);
								}
							}
							goto IL_70;
						}
						return;
						IL_70:
						while (this.x7478f4855b6bd03d != null)
						{
							this.x7478f4855b6bd03d.Resize -= this.OnDockSystemContainerResize;
							if (-2147483648 != 0)
							{
								IL_0B:
								this.x7478f4855b6bd03d = value;
								if (this.x7478f4855b6bd03d != null)
								{
									this.x7478f4855b6bd03d.Resize += this.OnDockSystemContainerResize;
								}
								value.Controls.AddRange((Control[])arrayList.ToArray(typeof(Control)));
								return;
							}
						}
						goto IL_0B;
					}
					return;
				}
				throw new ArgumentException("A DockContainer cannot act as a host for a SandDock layout.");
			}
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x00008F88 File Offset: 0x00007F88
		protected internal virtual void OnShowControlContextMenu(ShowControlContextMenuEventArgs e)
		{
			if (this.x8956f13386ebab05 != null)
			{
				this.x8956f13386ebab05(this, e);
			}
		}

		// Token: 0x060000AA RID: 170 RVA: 0x00008FA0 File Offset: 0x00007FA0
		internal void RegisterWindow(DockControl control)
		{
			this.x8fb2a5bf0df0416f[control.Guid] = control;
			this.OnDockControlAdded(new DockControlEventArgs(control));
		}

		// Token: 0x060000AB RID: 171 RVA: 0x00008FC8 File Offset: 0x00007FC8
		internal void ReRegisterWindow(DockControl control, Guid oldGuid)
		{
			if (this.x8fb2a5bf0df0416f.Contains(oldGuid))
			{
				this.x8fb2a5bf0df0416f.Remove(oldGuid);
			}
			this.x8fb2a5bf0df0416f[control.Guid] = control;
		}

		// Token: 0x060000AC RID: 172 RVA: 0x00009008 File Offset: 0x00008008
		internal void UnregisterWindow(DockControl control)
		{
			this.x8fb2a5bf0df0416f.Remove(control.Guid);
			this.OnDockControlRemoved(new DockControlEventArgs(control));
		}

		// Token: 0x060000AD RID: 173 RVA: 0x0000902C File Offset: 0x0000802C
		protected virtual void OnDockControlAdded(DockControlEventArgs e)
		{
			if (this.x528e78a16a92fb41 != null)
			{
				this.x528e78a16a92fb41(this, e);
			}
		}

		// Token: 0x060000AE RID: 174 RVA: 0x00009044 File Offset: 0x00008044
		protected virtual void OnDockControlRemoved(DockControlEventArgs e)
		{
			if (this.xbc613baf913a9f51 != null)
			{
				this.xbc613baf913a9f51(this, e);
			}
		}

		// Token: 0x060000AF RID: 175 RVA: 0x0000905C File Offset: 0x0000805C
		protected internal virtual void OnDockControlActivated(DockControlEventArgs e)
		{
			if (this.x505fd87f59cc2876 != null)
			{
				this.x505fd87f59cc2876(this, e);
			}
			if (e.DockControl.DockSituation == DockSituation.Document)
			{
				this.SetActiveTabbedDocument(e.DockControl);
				if (4 != 0)
				{
				}
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x060000B0 RID: 176 RVA: 0x00009098 File Offset: 0x00008098
		// (set) Token: 0x060000B1 RID: 177 RVA: 0x000090A0 File Offset: 0x000080A0
		[DefaultValue(typeof(DockingHints), "TranslucentFill")]
		[Description("Indicates the type of visual artifacts drawn to the screen to indicate size and position while docking.")]
		[Category("Appearance")]
		public DockingHints DockingHints
		{
			get
			{
				return this.x48cee1d69929b4fe;
			}
			set
			{
				this.x48cee1d69929b4fe = value;
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x060000B2 RID: 178 RVA: 0x000090AC File Offset: 0x000080AC
		// (set) Token: 0x060000B3 RID: 179 RVA: 0x000090B4 File Offset: 0x000080B4
		[Category("Behavior")]
		[DefaultValue(30)]
		[Description("Indicates the minimum size of a docked strip of toolwindows.")]
		public int MinimumDockContainerSize
		{
			get
			{
				return this.xdca928fc295dbb2a;
			}
			set
			{
				this.xdca928fc295dbb2a = value;
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x060000B4 RID: 180 RVA: 0x000090C0 File Offset: 0x000080C0
		// (set) Token: 0x060000B5 RID: 181 RVA: 0x000090C8 File Offset: 0x000080C8
		[DefaultValue(500)]
		[Description("Indicates the maximum size of a docked strip of toolwindows.")]
		[Category("Behavior")]
		public int MaximumDockContainerSize
		{
			get
			{
				return this.xb3f3aa0fff672c52;
			}
			set
			{
				this.xb3f3aa0fff672c52 = value;
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x060000B6 RID: 182 RVA: 0x000090D4 File Offset: 0x000080D4
		// (set) Token: 0x060000B7 RID: 183 RVA: 0x000090DC File Offset: 0x000080DC
		[DefaultValue(typeof(DockingManager), "Whidbey")]
		[Description("Indicates the method of user interaction during a docking operation.")]
		[Category("Behavior")]
		public DockingManager DockingManager
		{
			get
			{
				return this.x531514c39973cbc6;
			}
			set
			{
				this.x531514c39973cbc6 = value;
			}
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x000090E8 File Offset: 0x000080E8
		private void EnsureHandles()
		{
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x000090EC File Offset: 0x000080EC
		public void SetLayout(string layout)
		{
			this.EnsureDockSystemContainer();
			x410f3612b9a8f9de[] floatingDockContainerList;
			ArrayList arrayList;
			int num3;
			do
			{
				this.EnsureHandles();
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.LoadXml(layout);
				this.GetLayout();
				DockContainer[] orderedDockedDockContainerList = this.GetOrderedDockedDockContainerList();
				floatingDockContainerList = this.GetFloatingDockContainerList();
				int num = 0;
				int num2 = 0;
				arrayList = new ArrayList(orderedDockedDockContainerList);
				if ((uint)num <= 4294967295U)
				{
					goto Block_4;
				}
			}
			while ((uint)num3 - (uint)num3 < 0U);
			return;
			Block_4:
			arrayList.AddRange(floatingDockContainerList);
			DocumentContainer documentContainer = null;
			if (!this.SerializeTabbedDocuments)
			{
				goto IL_5CB;
			}
			IL_5BD:
			documentContainer = (this.FindDockedContainer(DockStyle.Fill) as DocumentContainer);
			IL_5CB:
			if (documentContainer != null)
			{
				arrayList.Add(documentContainer);
			}
			try
			{
				try
				{
					using (IEnumerator enumerator = arrayList.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							object obj = enumerator.Current;
							DockContainer dockContainer = (DockContainer)obj;
							dockContainer.x272ed7848e373c56();
						}
						goto IL_4E7;
					}
					IL_98:
					IL_A4:
					int num4;
					num4++;
					IL_AA:
					DockControl[] dockControls;
					if (num4 >= dockControls.Length)
					{
						goto IL_512;
					}
					DockControl dockControl = dockControls[num4];
					int num2;
					int i;
					bool flag = (uint)num2 - (uint)i > uint.MaxValue;
					if (!flag)
					{
						if (dockControl.x1a9802d2d8708515 || dockControl.CloseAction != DockControlCloseAction.Dispose)
						{
							goto IL_A4;
						}
						dockControl.Dispose();
						goto IL_98;
					}
					IL_D2:
					dockControls = this.GetDockControls();
					num4 = 0;
					if ((uint)num2 + (uint)num2 >= 0U)
					{
						goto IL_AA;
					}
					goto IL_4E7;
					IL_119:
					goto IL_D2;
					IL_4E7:
					this.DockSystemContainer.SuspendLayout();
					XmlDocument xmlDocument;
					XmlNode xmlNode = xmlDocument.GetElementsByTagName("Layout")[0];
					IEnumerator enumerator2 = xmlNode.ChildNodes.GetEnumerator();
					DockContainer[] orderedDockedDockContainerList;
					int num;
					try
					{
						for (;;)
						{
							XmlNode xmlNode2;
							if (!enumerator2.MoveNext())
							{
								if (false)
								{
									flag = ((uint)num4 + (uint)i < 0U);
									if (flag)
									{
										goto IL_255;
									}
									goto IL_22C;
								}
								else
								{
									if (-1 == 0)
									{
										goto IL_217;
									}
									flag = ((uint)num3 > uint.MaxValue);
									if (flag)
									{
										goto IL_351;
									}
									break;
								}
							}
							else
							{
								xmlNode2 = (XmlNode)enumerator2.Current;
								if (xmlNode2.NodeType == XmlNodeType.Element)
								{
									goto IL_440;
								}
								flag = ((uint)num2 + (uint)num3 < 0U);
								if (flag)
								{
									goto IL_440;
								}
								goto IL_453;
							}
							IL_20B:
							if (xmlNode2.NodeType != XmlNodeType.Element)
							{
								continue;
							}
							goto IL_217;
							IL_22C:
							if (!xmlNode2.HasChildNodes)
							{
								continue;
							}
							x410f3612b9a8f9de container;
							for (;;)
							{
								container = null;
								if (num2 >= floatingDockContainerList.Length)
								{
									goto IL_26A;
								}
								if ((uint)i < 0U)
								{
									break;
								}
								flag = ((uint)num > uint.MaxValue);
								if (!flag)
								{
									goto IL_255;
								}
								if ((uint)i - (uint)num <= 4294967295U)
								{
									goto IL_20B;
								}
							}
							goto IL_35A;
							IL_217:
							if (!(xmlNode2.Name == "FloatingContainer"))
							{
								continue;
							}
							goto IL_22C;
							IL_26A:
							this.ReadFloatingContainerProperties(xmlNode2, container);
							continue;
							IL_255:
							if (255 != 0)
							{
								container = floatingDockContainerList[num2++];
								goto IL_26A;
							}
							goto IL_440;
							IL_36D:
							DockContainer container2;
							this.ReadContainerProperties(xmlNode2, container2);
							flag = ((uint)num - (uint)i < 0U);
							if (flag)
							{
								goto IL_392;
							}
							if ((uint)num3 - (uint)num4 <= 4294967295U)
							{
								continue;
							}
							goto IL_410;
							IL_351:
							if (documentContainer == null)
							{
								goto IL_36D;
							}
							container2 = documentContainer;
							documentContainer = null;
							goto IL_36D;
							IL_3A1:
							if (num >= orderedDockedDockContainerList.Length)
							{
								goto IL_36D;
							}
							if ((uint)i - (uint)num <= 4294967295U)
							{
								container2 = orderedDockedDockContainerList[num++];
								goto IL_36D;
							}
							goto IL_22C;
							IL_35A:
							if (!(xmlNode2.Name == "Container"))
							{
								goto IL_36D;
							}
							goto IL_3A1;
							IL_440:
							if (!(xmlNode2.Name == "Window"))
							{
								goto IL_453;
							}
							this.ReadWindowProperties(xmlNode2);
							continue;
							IL_392:
							flag = (((uint)i & 0U) == 0U);
							if (flag)
							{
								goto IL_20B;
							}
							goto IL_2F5;
							IL_339:
							if (!(xmlNode2.Name == "DocumentContainer"))
							{
								goto IL_392;
							}
							goto IL_308;
							IL_2F5:
							if (!(xmlNode2.Name == "Container"))
							{
								goto IL_339;
							}
							IL_308:
							if (!xmlNode2.HasChildNodes)
							{
								goto IL_20B;
							}
							goto IL_410;
							IL_453:
							if (xmlNode2.NodeType != XmlNodeType.Element)
							{
								goto IL_20B;
							}
							flag = ((uint)num < 0U);
							if (flag)
							{
								goto IL_339;
							}
							goto IL_2F5;
							IL_410:
							container2 = null;
							if (xmlNode2.Name == "DocumentContainer")
							{
								goto IL_351;
							}
							flag = (((uint)num | 2U) == 0U);
							if (flag)
							{
								goto IL_3A1;
							}
							goto IL_35A;
						}
					}
					finally
					{
						IDisposable disposable2 = enumerator2 as IDisposable;
						flag = ((uint)num3 + (uint)num2 < 0U);
						if (flag || disposable2 != null)
						{
							disposable2.Dispose();
						}
					}
					num3 = num;
					for (;;)
					{
						if (num3 >= orderedDockedDockContainerList.Length)
						{
							if ((uint)num3 < 0U)
							{
								goto IL_98;
							}
							for (;;)
							{
								IL_179:
								i = num2;
								while (i < floatingDockContainerList.Length)
								{
									floatingDockContainerList[i].Dispose();
									if (((uint)num2 | 2147483647U) == 0U)
									{
										goto IL_179;
									}
									flag = ((uint)num3 < 0U);
									if (!flag)
									{
										flag = (((uint)num4 & 0U) == 0U);
										if (!flag)
										{
											goto IL_4D6;
										}
										i++;
									}
								}
								goto Block_11;
							}
						}
						IL_4D6:
						orderedDockedDockContainerList[num3].Dispose();
						num3++;
						flag = ((uint)i + (uint)num2 > uint.MaxValue);
						if (flag)
						{
							goto IL_512;
						}
					}
					Block_11:
					if (documentContainer == null)
					{
						goto IL_D2;
					}
					documentContainer.Dispose();
					goto IL_119;
					IL_512:;
				}
				catch (Exception innerException)
				{
					throw new ArgumentException("The layout information provided could not be interpreted.", innerException);
				}
				return;
			}
			finally
			{
				foreach (object obj2 in arrayList)
				{
					DockContainer dockContainer2 = (DockContainer)obj2;
					if (dockContainer2 != null)
					{
						if (dockContainer2.IsDisposed)
						{
							int num2;
							bool flag = ((uint)num2 | 2U) == 0U;
							if (flag)
							{
								break;
							}
							if ((uint)num3 + (uint)num2 <= 4294967295U)
							{
							}
						}
						else
						{
							dockContainer2.xfe00f14c7d278916();
						}
					}
				}
				this.DockSystemContainer.ResumeLayout();
			}
			goto IL_5BD;
		}

		// Token: 0x060000BA RID: 186 RVA: 0x000097BC File Offset: 0x000087BC
		private bool ConvertStringToBool(string str)
		{
			return !(str == "0");
		}

		// Token: 0x060000BB RID: 187 RVA: 0x000097D0 File Offset: 0x000087D0
		private Point ConvertStringToPoint(string str)
		{
			return (Point)TypeDescriptor.GetConverter(typeof(Point)).ConvertFrom(null, CultureInfo.InvariantCulture, str);
		}

		// Token: 0x060000BC RID: 188 RVA: 0x000097F4 File Offset: 0x000087F4
		private Size ConvertStringToSize(string str)
		{
			return (Size)TypeDescriptor.GetConverter(typeof(Size)).ConvertFrom(null, CultureInfo.InvariantCulture, str);
		}

		// Token: 0x060000BD RID: 189 RVA: 0x00009818 File Offset: 0x00008818
		internal static SizeF ConvertStringToSizeF(string str)
		{
			return (SizeF)TypeDescriptor.GetConverter(typeof(SizeF)).ConvertFrom(null, CultureInfo.InvariantCulture, str);
		}

		// Token: 0x060000BE RID: 190 RVA: 0x0000983C File Offset: 0x0000883C
		private Rectangle ConvertStringToRectangle(string str)
		{
			return (Rectangle)TypeDescriptor.GetConverter(typeof(Rectangle)).ConvertFrom(null, CultureInfo.InvariantCulture, str);
		}

		// Token: 0x060000BF RID: 191 RVA: 0x00009860 File Offset: 0x00008860
		private void ReadWindowProperties(XmlNode node)
		{
			x245a5abec1c73d3a.x0a680eda7ec8bd81(this, node);
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x0000986C File Offset: 0x0000886C
		private void ReadFloatingContainerProperties(XmlNode node, x410f3612b9a8f9de container)
		{
			Rectangle xda73fcb97c77d = this.ConvertStringToRectangle(node.Attributes["Bounds"].Value);
			Guid guid = Guid.NewGuid();
			if (node.Attributes["Guid"] != null)
			{
				guid = new Guid(node.Attributes["Guid"].Value);
				if (-1 != 0)
				{
				}
			}
			if (container == null)
			{
				container = new x410f3612b9a8f9de(this, guid);
			}
			using (IEnumerator enumerator = node.ChildNodes.GetEnumerator())
			{
				while (enumerator.MoveNext() || false)
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					while (xmlNode.NodeType == XmlNodeType.Element)
					{
						if (!(xmlNode.Name == "SplitLayoutSystem"))
						{
							break;
						}
						SplitLayoutSystem splitLayoutSystem = this.ReadSplitLayoutSystem(xmlNode, container);
						if (splitLayoutSystem != null)
						{
							container.LayoutSystem = splitLayoutSystem;
							break;
						}
						if (!false)
						{
							container.Dispose();
							if (!false)
							{
								return;
							}
						}
					}
				}
			}
			container.x159713d3b60fae0c(xda73fcb97c77d, true, false);
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x000099AC File Offset: 0x000089AC
		private void ReadContainerProperties(XmlNode containerNode, DockContainer container)
		{
			DockStyle dockStyle = (DockStyle)int.Parse(containerNode.Attributes["Dock"].Value);
			int num = 0;
			for (;;)
			{
				if (containerNode.Attributes["ContentSize"] == null)
				{
					goto IL_175;
				}
				num = int.Parse(containerNode.Attributes["ContentSize"].Value);
				if ((uint)num - (uint)num < 0U)
				{
					goto IL_20;
				}
				if (((uint)num | 1U) != 0U)
				{
				}
				IL_161:
				bool flag = ((uint)num & 0U) == 0U;
				if (flag)
				{
					goto IL_175;
				}
				continue;
				IL_20:
				container.Dock = dockStyle;
				container.ContentSize = num;
				using (IEnumerator enumerator = containerNode.ChildNodes.GetEnumerator())
				{
					IL_49:
					while (enumerator.MoveNext())
					{
						SplitLayoutSystem splitLayoutSystem;
						for (;;)
						{
							IL_DA:
							XmlNode xmlNode = (XmlNode)enumerator.Current;
							IL_3D:
							while (xmlNode.NodeType == XmlNodeType.Element && xmlNode.Name == "SplitLayoutSystem")
							{
								splitLayoutSystem = this.ReadSplitLayoutSystem(xmlNode, container);
								for (;;)
								{
									IL_9E:
									if (splitLayoutSystem != null)
									{
										flag = ((uint)num < 0U);
										if (flag)
										{
											goto Block_13;
										}
										flag = ((uint)num + (uint)num > uint.MaxValue);
										if (flag)
										{
											break;
										}
									}
									else
									{
										container.Dispose();
										if ((uint)num - (uint)num >= 0U)
										{
											goto IL_D3;
										}
									}
									while (-2147483648 == 0)
									{
										if (false)
										{
											goto IL_9E;
										}
										if (3 == 0)
										{
											goto IL_3D;
										}
										if (15 == 0)
										{
											goto IL_D3;
										}
										if ((uint)num + (uint)num <= 4294967295U)
										{
											break;
										}
									}
									goto Block_9;
								}
								flag = ((uint)num - (uint)num > uint.MaxValue);
								if (flag)
								{
									goto IL_142;
								}
								continue;
								Block_13:
								goto IL_DA;
							}
							goto IL_49;
						}
						IL_72:
						container.LayoutSystem = splitLayoutSystem;
						break;
						Block_9:
						goto IL_72;
						IL_D3:
						IL_142:
						break;
					}
					break;
				}
				goto IL_161;
				IL_175:
				if (container == null)
				{
					container = this.CreateNewDockContainer(LayoutUtilities.x3650f3b579b2b4d2(dockStyle), ContainerDockEdge.Outside, num);
					goto IL_20;
				}
				goto IL_20;
			}
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x00009BD8 File Offset: 0x00008BD8
		private SplitLayoutSystem ReadSplitLayoutSystem(XmlNode splitNode, DockContainer container)
		{
			SizeF workingSize = SandDockManager.ConvertStringToSizeF(splitNode.Attributes["WorkingSize"].Value);
			workingSize.Width = Math.Max(workingSize.Width, 1f);
			workingSize.Height = Math.Max(workingSize.Height, 1f);
			Orientation splitMode = (Orientation)int.Parse(splitNode.Attributes["SplitMode"].Value);
			ArrayList arrayList = new ArrayList();
			using (IEnumerator enumerator = splitNode.ChildNodes.GetEnumerator())
			{
				IL_51:
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode;
					SplitLayoutSystem splitLayoutSystem;
					for (;;)
					{
						xmlNode = (XmlNode)enumerator.Current;
						if (!false && xmlNode.NodeType != XmlNodeType.Element)
						{
							goto IL_112;
						}
						if (xmlNode.Name == "SplitLayoutSystem")
						{
							splitLayoutSystem = this.ReadSplitLayoutSystem(xmlNode, container);
							if (255 != 0)
							{
								goto IL_79;
							}
							if (-1 == 0)
							{
								goto IL_112;
							}
							goto IL_B9;
						}
						IL_7F:
						if (xmlNode.NodeType == XmlNodeType.Element)
						{
							break;
						}
						if (!false)
						{
							if (-2 != 0)
							{
								goto IL_51;
							}
						}
						if (false)
						{
							continue;
						}
						break;
						IL_112:
						if (4 != 0)
						{
						}
						if (false)
						{
							goto Block_9;
						}
						goto IL_7F;
					}
					IL_3F:
					if (!(xmlNode.Name == "ControlLayoutSystem"))
					{
						continue;
					}
					goto IL_A1;
					IL_79:
					if (splitLayoutSystem == null)
					{
						continue;
					}
					goto IL_B9;
					IL_A1:
					ControlLayoutSystem controlLayoutSystem = this.ReadControlLayoutSystem(xmlNode, container);
					if (controlLayoutSystem != null)
					{
						if (!false)
						{
							arrayList.Add(controlLayoutSystem);
						}
					}
					continue;
					IL_B9:
					arrayList.Add(splitLayoutSystem);
					continue;
					Block_9:
					if (3 == 0)
					{
						goto IL_A1;
					}
					goto IL_3F;
				}
				goto IL_20;
			}
			goto IL_13F;
			IL_20:
			if (arrayList.Count == 0)
			{
				return null;
			}
			IL_13F:
			return new SplitLayoutSystem(workingSize, splitMode, (LayoutSystemBase[])arrayList.ToArray(typeof(LayoutSystemBase)));
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x00009DB4 File Offset: 0x00008DB4
		private ControlLayoutSystem ReadControlLayoutSystem(XmlNode controlNode, DockContainer container)
		{
			Guid empty = Guid.Empty;
			bool flag2;
			bool flag = (flag2 ? 1U : 0U) - (flag2 ? 1U : 0U) > uint.MaxValue;
			if (flag)
			{
				goto IL_2AC;
			}
			SizeF size = SandDockManager.ConvertStringToSizeF(controlNode.Attributes["WorkingSize"].Value);
			DockControl selectedControl;
			if ((flag2 ? 1U : 0U) - (flag2 ? 1U : 0U) >= 0U)
			{
				flag2 = this.ConvertStringToBool(controlNode.Attributes["Collapsed"].Value);
				selectedControl = null;
				goto IL_2AC;
			}
			IL_42:
			if ((flag2 ? 1U : 0U) + (flag2 ? 1U : 0U) < 0U)
			{
				goto IL_2D3;
			}
			if (-1 == 0)
			{
				goto IL_305;
			}
			ControlLayoutSystem controlLayoutSystem;
			controlLayoutSystem.x0217cda8370c1f17 = empty;
			return controlLayoutSystem;
			IL_2AC:
			if (controlNode.Attributes["SelectedControl"] != null)
			{
				Guid guid = new Guid(controlNode.Attributes["SelectedControl"].Value);
				if ((flag2 ? 1U : 0U) >= 0U)
				{
				}
				selectedControl = this.FindControl(guid);
			}
			if (controlNode.Attributes["Guid"] == null)
			{
				goto IL_2EF;
			}
			IL_2D3:
			empty = new Guid(controlNode.Attributes["Guid"].Value);
			IL_2EF:
			ArrayList arrayList = new ArrayList();
			IEnumerator enumerator = controlNode.ChildNodes.GetEnumerator();
			try
			{
				for (;;)
				{
					if (!enumerator.MoveNext())
					{
						goto IL_200;
					}
					IL_21E:
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					if (xmlNode.NodeType != XmlNodeType.Element)
					{
						continue;
					}
					if (!(xmlNode.Name == "Controls"))
					{
						continue;
					}
					using (IEnumerator enumerator2 = xmlNode.ChildNodes.GetEnumerator())
					{
						IL_13E:
						while (enumerator2.MoveNext())
						{
							DockControl dockControl;
							for (;;)
							{
								XmlNode xmlNode2 = (XmlNode)enumerator2.Current;
								for (;;)
								{
									if (xmlNode2.NodeType == XmlNodeType.Element)
									{
										goto IL_161;
									}
									IL_137:
									if (-1 != 0)
									{
										goto IL_13E;
									}
									if (!true)
									{
										continue;
									}
									IL_161:
									if (!(xmlNode2.Name == "Control"))
									{
										goto Block_17;
									}
									Guid guid2 = new Guid(xmlNode2.Attributes["Guid"].Value);
									dockControl = this.FindControl(guid2);
									if (dockControl == null)
									{
										goto IL_13E;
									}
									if (15 == 0)
									{
										break;
									}
									if (!true)
									{
										goto IL_137;
									}
									goto IL_17D;
								}
							}
							Block_17:
							if (-1 == 0)
							{
								break;
							}
							continue;
							IL_17D:
							arrayList.Add(dockControl);
						}
						continue;
					}
					IL_200:
					if (((flag2 ? 1U : 0U) & 0U) == 0U)
					{
						break;
					}
					if (15 != 0)
					{
						goto IL_21E;
					}
				}
				goto IL_31;
			}
			finally
			{
				IDisposable disposable2 = enumerator as IDisposable;
				flag = ((flag2 ? 1U : 0U) > uint.MaxValue);
				if (!flag)
				{
					goto IL_276;
				}
				IL_251:
				if ((flag2 ? 1U : 0U) - (flag2 ? 1U : 0U) >= 0U)
				{
					goto IL_28E;
				}
				IL_276:
				if (disposable2 != null)
				{
					disposable2.Dispose();
					goto IL_251;
				}
				flag = ((flag2 ? 1U : 0U) > uint.MaxValue);
				if (flag)
				{
					goto IL_251;
				}
				IL_28E:;
			}
			goto IL_2AC;
			IL_31:
			if (arrayList.Count != 0)
			{
				do
				{
					controlLayoutSystem = container.CreateNewLayoutSystem(size);
					controlLayoutSystem.Controls.AddRange((DockControl[])arrayList.ToArray(typeof(DockControl)));
					while (selectedControl != null)
					{
						controlLayoutSystem.SelectedControl = selectedControl;
						if (!false)
						{
							break;
						}
					}
					controlLayoutSystem.Collapsed = flag2;
					flag = ((flag2 ? 1U : 0U) + (flag2 ? 1U : 0U) > uint.MaxValue);
					if (flag)
					{
						break;
					}
					if (!(empty != Guid.Empty))
					{
						return controlLayoutSystem;
					}
				}
				while (!true);
				goto IL_42;
			}
			IL_305:
			return null;
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x0000A1A8 File Offset: 0x000091A8
		public DockControl FindControl(Guid guid)
		{
			DockControl dockControl = (DockControl)this.x8fb2a5bf0df0416f[guid];
			while (255 != 0 && dockControl == null)
			{
				ResolveDockControlEventArgs resolveDockControlEventArgs = new ResolveDockControlEventArgs(guid);
				this.OnResolveDockControl(resolveDockControlEventArgs);
				if (false || resolveDockControlEventArgs.DockControl != null)
				{
					resolveDockControlEventArgs.DockControl.Manager = this;
					if (false)
					{
						continue;
					}
					if (!false)
					{
						return resolveDockControlEventArgs.DockControl;
					}
				}
				return null;
			}
			return dockControl;
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x0000A218 File Offset: 0x00009218
		private DockContainer[] GetOrderedDockedDockContainerList()
		{
			if (this.DockSystemContainer == null)
			{
				return new DockContainer[0];
			}
			ArrayList arrayList = new ArrayList();
			int num;
			if ((uint)num < 0U)
			{
				goto IL_4B;
			}
			if (false)
			{
				goto IL_7F;
			}
			num = 0;
			IL_20:
			if (num >= this.DockSystemContainer.Controls.Count)
			{
				goto IL_7F;
			}
			Control control = this.DockSystemContainer.Controls[num];
			IL_4B:
			if (this.xd27fa35d10494112.Contains(control) && !(control is DocumentContainer))
			{
				arrayList.Add(control);
			}
			num++;
			goto IL_20;
			IL_7F:
			return (DockContainer[])arrayList.ToArray(typeof(DockContainer));
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x0000A2BC File Offset: 0x000092BC
		private x410f3612b9a8f9de[] GetFloatingDockContainerList()
		{
			ArrayList arrayList = new ArrayList();
			IEnumerator enumerator = this.xd27fa35d10494112.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					DockContainer dockContainer = (DockContainer)obj;
					if (dockContainer.IsFloating)
					{
						arrayList.Add(dockContainer);
					}
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				while (disposable != null)
				{
					do
					{
						disposable.Dispose();
					}
					while (!true);
					if (!false)
					{
						break;
					}
				}
			}
			return (x410f3612b9a8f9de[])arrayList.ToArray(typeof(x410f3612b9a8f9de));
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x0000A364 File Offset: 0x00009364
		private string ConvertBoolToString(bool b)
		{
			if (!b)
			{
				return "0";
			}
			return "1";
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x0000A374 File Offset: 0x00009374
		private string ConvertSizeToString(Size size)
		{
			return (string)TypeDescriptor.GetConverter(typeof(Size)).ConvertTo(null, CultureInfo.InvariantCulture, size, typeof(string));
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x0000A3A8 File Offset: 0x000093A8
		internal static string ConvertSizeFToString(SizeF size)
		{
			return (string)TypeDescriptor.GetConverter(typeof(SizeF)).ConvertTo(null, CultureInfo.InvariantCulture, size, typeof(string));
		}

		// Token: 0x060000CA RID: 202 RVA: 0x0000A3DC File Offset: 0x000093DC
		private string ConvertPointToString(Point point)
		{
			return (string)TypeDescriptor.GetConverter(typeof(Point)).ConvertTo(null, CultureInfo.InvariantCulture, point, typeof(string));
		}

		// Token: 0x060000CB RID: 203 RVA: 0x0000A410 File Offset: 0x00009410
		private string ConvertRectangleToString(Rectangle rectangle)
		{
			return (string)TypeDescriptor.GetConverter(typeof(Rectangle)).ConvertTo(null, CultureInfo.InvariantCulture, rectangle, typeof(string));
		}

		// Token: 0x060000CC RID: 204 RVA: 0x0000A444 File Offset: 0x00009444
		private string GetSettingsKey()
		{
			if (this.OwnerForm != null)
			{
				return this.OwnerForm.GetType().FullName;
			}
			return "default";
		}

		// Token: 0x060000CD RID: 205 RVA: 0x0000A464 File Offset: 0x00009464
		public void SaveLayout()
		{
			new LayoutSettings(this.GetSettingsKey())
			{
				LayoutXml = this.GetLayout()
			}.Save();
		}

		// Token: 0x060000CE RID: 206 RVA: 0x0000A490 File Offset: 0x00009490
		public void LoadLayout()
		{
			LayoutSettings layoutSettings = new LayoutSettings(this.GetSettingsKey());
			if (!layoutSettings.IsDefault)
			{
				if (layoutSettings.LayoutXml != null && layoutSettings.LayoutXml.Length != 0)
				{
					if (!false)
					{
						this.SetLayout(layoutSettings.LayoutXml);
					}
				}
			}
		}

		// Token: 0x060000CF RID: 207 RVA: 0x0000A4E0 File Offset: 0x000094E0
		public string GetLayout()
		{
			this.EnsureDockSystemContainer();
			StringWriter stringWriter;
			for (;;)
			{
				int num;
				if ((uint)num + (uint)num <= 4294967295U)
				{
					stringWriter = new StringWriter();
					goto IL_29B;
				}
				goto IL_0B;
				IL_1C:
				XmlTextWriter xmlTextWriter;
				xmlTextWriter.WriteEndElement();
				xmlTextWriter.WriteEndDocument();
				if ((uint)num - (uint)num > 4294967295U)
				{
					goto IL_1C1;
				}
				xmlTextWriter.Flush();
				xmlTextWriter.Close();
				if (4 == 0)
				{
					continue;
				}
				break;
				IL_0B:
				DocumentContainer documentContainer;
				if (!documentContainer.LayoutSystem.x56005f23d6948487)
				{
					goto IL_1C;
				}
				this.SaveContainerLayout(documentContainer, xmlTextWriter);
				goto IL_1C;
				IL_55:
				if (!this.SerializeTabbedDocuments)
				{
					goto IL_1C;
				}
				goto IL_0B;
				IL_A6:
				int num2;
				x410f3612b9a8f9de[] floatingDockContainerList;
				bool flag;
				DockContainer dockContainer;
				if (num2 >= floatingDockContainerList.Length)
				{
					flag = (((uint)num | 8U) == 0U);
					if (flag)
					{
						goto IL_FB;
					}
					documentContainer = (this.FindDockedContainer(DockStyle.Fill) as DocumentContainer);
					flag = ((uint)num > uint.MaxValue);
					if (flag)
					{
						goto IL_94;
					}
					if (documentContainer != null)
					{
						goto IL_55;
					}
					goto IL_61;
				}
				else
				{
					dockContainer = floatingDockContainerList[num2];
					flag = (((uint)num | 1U) == 0U);
					if (flag)
					{
						goto IL_13A;
					}
					flag = ((uint)num + (uint)num < 0U);
					if (flag)
					{
						goto IL_1B4;
					}
				}
				IL_C8:
				if (dockContainer.LayoutSystem.x56005f23d6948487)
				{
					this.SaveContainerLayout(dockContainer, xmlTextWriter);
				}
				num2++;
				flag = ((uint)num2 < 0U);
				if (flag)
				{
					goto IL_FB;
				}
				goto IL_A6;
				IL_13A:
				if ((uint)num > 4294967295U)
				{
					goto IL_263;
				}
				DockContainer dockContainer2;
				this.SaveContainerLayout(dockContainer2, xmlTextWriter);
				if ((uint)num + (uint)num2 >= 0U)
				{
					goto IL_172;
				}
				goto IL_C8;
				IL_1B4:
				if (!false)
				{
					goto IL_61;
				}
				flag = ((uint)num2 - (uint)num2 > uint.MaxValue);
				if (flag)
				{
					goto IL_1F7;
				}
				continue;
				IL_FB:
				goto IL_1B4;
				IL_61:
				goto IL_1C;
				IL_94:
				goto IL_55;
				IL_263:
				DockContainer[] orderedDockedDockContainerList = this.GetOrderedDockedDockContainerList();
				num = 0;
				if (255 != 0)
				{
					goto IL_100;
				}
				goto IL_94;
				IL_1F7:
				xmlTextWriter.WriteStartDocument();
				xmlTextWriter.WriteStartElement("Layout");
				foreach (object obj in this.x8fb2a5bf0df0416f.Values)
				{
					DockControl dockControl = (DockControl)obj;
					if (dockControl.PersistState)
					{
						this.SaveWindowLayout(dockControl, xmlTextWriter);
					}
				}
				goto IL_263;
				IL_29B:
				xmlTextWriter = new XmlTextWriter(stringWriter);
				xmlTextWriter.Formatting = Formatting.Indented;
				goto IL_1F7;
				IL_1C1:
				if (false)
				{
					goto IL_94;
				}
				if (!dockContainer2.LayoutSystem.x56005f23d6948487)
				{
					goto IL_172;
				}
				if (((uint)num2 | 4294967295U) != 0U)
				{
					goto IL_13A;
				}
				goto IL_29B;
				IL_100:
				if (num >= orderedDockedDockContainerList.Length)
				{
					floatingDockContainerList = this.GetFloatingDockContainerList();
					num2 = 0;
					goto IL_A6;
				}
				dockContainer2 = orderedDockedDockContainerList[num];
				goto IL_1C1;
				IL_172:
				num++;
				goto IL_100;
			}
			return stringWriter.ToString();
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x0000A7C8 File Offset: 0x000097C8
		private void SaveContainerLayout(DockContainer container, XmlTextWriter writer)
		{
			if (container is x410f3612b9a8f9de)
			{
				goto IL_D0;
			}
			if (container is DocumentContainer)
			{
				writer.WriteStartElement("DocumentContainer");
				goto IL_77;
			}
			IL_6C:
			writer.WriteStartElement("Container");
			IL_77:
			string localName = "Dock";
			int dock = (int)container.Dock;
			writer.WriteAttributeString(localName, dock.ToString());
			if (container.Dock != DockStyle.Fill)
			{
				if (container.Dock != DockStyle.None)
				{
					string localName2 = "ContentSize";
					int contentSize = container.ContentSize;
					writer.WriteAttributeString(localName2, contentSize.ToString());
					if ((uint)dock + (uint)contentSize > 4294967295U)
					{
						goto IL_6C;
					}
				}
			}
			this.SaveLayoutSystem(container.LayoutSystem, writer);
			IL_1A:
			writer.WriteEndElement();
			bool flag = (uint)dock + (uint)dock < 0U;
			if (!flag)
			{
				return;
			}
			IL_D0:
			x410f3612b9a8f9de x410f3612b9a8f9de = (x410f3612b9a8f9de)container;
			writer.WriteStartElement("FloatingContainer");
			writer.WriteAttributeString("Bounds", this.ConvertRectangleToString(x410f3612b9a8f9de.x5de6fa99acd93adb));
			writer.WriteAttributeString("Guid", x410f3612b9a8f9de.x0217cda8370c1f17.ToString());
			if (!false)
			{
				this.SaveLayoutSystem(container.LayoutSystem, writer);
				writer.WriteEndElement();
				return;
			}
			goto IL_1A;
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x0000A904 File Offset: 0x00009904
		private void SaveLayoutSystem(LayoutSystemBase layoutSystem, XmlTextWriter writer)
		{
			if (layoutSystem is SplitLayoutSystem)
			{
				goto IL_2C7;
			}
			goto IL_2B8;
			IL_1EB:
			writer.WriteAttributeString("WorkingSize", SandDockManager.ConvertSizeFToString(layoutSystem.WorkingSize));
			if (layoutSystem is SplitLayoutSystem)
			{
				goto IL_206;
			}
			int splitMode;
			if ((uint)splitMode < 0U)
			{
				goto IL_20D;
			}
			bool flag;
			if (2147483647 == 0 || layoutSystem is ControlLayoutSystem)
			{
				ControlLayoutSystem controlLayoutSystem = (ControlLayoutSystem)layoutSystem;
				writer.WriteAttributeString("Guid", controlLayoutSystem.x0217cda8370c1f17.ToString());
				while ((uint)splitMode >= 0U)
				{
					writer.WriteAttributeString("Collapsed", this.ConvertBoolToString(controlLayoutSystem.Collapsed));
					if (controlLayoutSystem.SelectedControl != null)
					{
						flag = ((uint)splitMode > uint.MaxValue);
						if (flag)
						{
							if (255 == 0)
							{
								goto IL_206;
							}
							flag = (((uint)splitMode | 3U) == 0U);
							if (flag)
							{
								goto IL_10;
							}
						}
						else if (!controlLayoutSystem.SelectedControl.PersistState)
						{
							goto IL_62;
						}
						writer.WriteAttributeString("SelectedControl", controlLayoutSystem.SelectedControl.Guid.ToString());
					}
					IL_62:
					writer.WriteStartElement("Controls");
					using (IEnumerator enumerator = controlLayoutSystem.Controls.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							object obj = enumerator.Current;
							DockControl dockControl = (DockControl)obj;
							if (dockControl.PersistState)
							{
								writer.WriteStartElement("Control");
								writer.WriteAttributeString("Guid", dockControl.Guid.ToString());
								writer.WriteEndElement();
							}
						}
						goto IL_10;
					}
					continue;
					IL_10:
					writer.WriteEndElement();
					goto IL_23;
				}
				return;
			}
			IL_23:
			writer.WriteEndElement();
			if (!false)
			{
				return;
			}
			flag = ((uint)splitMode - (uint)splitMode > uint.MaxValue);
			if (flag)
			{
				goto IL_2A1;
			}
			goto IL_2C7;
			IL_206:
			SplitLayoutSystem splitLayoutSystem = (SplitLayoutSystem)layoutSystem;
			IL_20D:
			string localName = "SplitMode";
			splitMode = (int)splitLayoutSystem.SplitMode;
			writer.WriteAttributeString(localName, splitMode.ToString());
			using (IEnumerator enumerator2 = splitLayoutSystem.LayoutSystems.GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					object obj2 = enumerator2.Current;
					LayoutSystemBase layoutSystemBase = (LayoutSystemBase)obj2;
					if (!layoutSystemBase.x56005f23d6948487)
					{
						flag = ((uint)splitMode + (uint)splitMode < 0U);
						if (flag)
						{
							IL_281:
							goto IL_23;
						}
					}
					else
					{
						this.SaveLayoutSystem(layoutSystemBase, writer);
					}
				}
				if (true)
				{
				}
				goto IL_281;
			}
			IL_2A1:
			IL_2B8:
			if (!(layoutSystem is ControlLayoutSystem))
			{
				return;
			}
			writer.WriteStartElement("ControlLayoutSystem");
			goto IL_1EB;
			IL_2C7:
			writer.WriteStartElement("SplitLayoutSystem");
			goto IL_1EB;
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x0000AC24 File Offset: 0x00009C24
		private void SaveWindowLayout(DockControl control, XmlTextWriter writer)
		{
			x245a5abec1c73d3a.x4229d31a884b2577(control, writer);
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x060000D3 RID: 211 RVA: 0x0000AC30 File Offset: 0x00009C30
		// (set) Token: 0x060000D4 RID: 212 RVA: 0x0000AC38 File Offset: 0x00009C38
		[Browsable(false)]
		public Form OwnerForm
		{
			get
			{
				return this.x9492ad63ba3e62cf;
			}
			set
			{
				if (this.x9492ad63ba3e62cf == null)
				{
					goto IL_105;
				}
				if (3 == 0)
				{
					goto IL_BD;
				}
				if (this.x9492ad63ba3e62cf == value)
				{
					return;
				}
				goto IL_105;
				do
				{
					IL_A9:
					this.x9492ad63ba3e62cf = value;
				}
				while (false);
				if (this.x9492ad63ba3e62cf != null)
				{
					if (!false)
					{
						this.x9492ad63ba3e62cf.Activated += this.OnOwnerFormActivated;
						this.x9492ad63ba3e62cf.Deactivate += this.OnOwnerFormDeactivated;
						this.x9492ad63ba3e62cf.Load += this.OnOwnerFormLoad;
						this.x9492ad63ba3e62cf.Closing += this.OnOwnerFormClosing;
					}
				}
				return;
				IL_BD:
				this.x9492ad63ba3e62cf.Activated -= this.OnOwnerFormActivated;
				do
				{
					this.x9492ad63ba3e62cf.Deactivate -= this.OnOwnerFormDeactivated;
				}
				while (false);
				this.x9492ad63ba3e62cf.Load -= this.OnOwnerFormLoad;
				this.x9492ad63ba3e62cf.Closing -= this.OnOwnerFormClosing;
				goto IL_A9;
				IL_105:
				if (this.x9492ad63ba3e62cf != null)
				{
					goto IL_BD;
				}
				goto IL_A9;
			}
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x0000AD54 File Offset: 0x00009D54
		private void OnOwnerFormClosing(object sender, CancelEventArgs e)
		{
			if (this.AutoSaveLayout)
			{
				this.SaveLayout();
			}
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x0000AD64 File Offset: 0x00009D64
		private void OnOwnerFormLoad(object sender, EventArgs e)
		{
			if (this.AutoSaveLayout)
			{
				this.LoadLayout();
			}
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x0000AD74 File Offset: 0x00009D74
		public DockControl[] GetDockControls()
		{
			DockControl[] array = new DockControl[this.x8fb2a5bf0df0416f.Count];
			this.x8fb2a5bf0df0416f.Values.CopyTo(array, 0);
			return array;
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x0000ADA8 File Offset: 0x00009DA8
		public DockControl[] GetDockControls(DockSituation dockSituation)
		{
			ArrayList arrayList = new ArrayList();
			using (IEnumerator enumerator = this.x8fb2a5bf0df0416f.Values.GetEnumerator())
			{
				while (enumerator.MoveNext() || !true)
				{
					DockControl dockControl = (DockControl)enumerator.Current;
					if (dockControl.DockSituation == dockSituation)
					{
						arrayList.Add(dockControl);
					}
				}
			}
			return (DockControl[])arrayList.ToArray(typeof(DockControl));
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x0000AE44 File Offset: 0x00009E44
		public DockContainer[] GetDockContainers()
		{
			return (DockContainer[])this.xd27fa35d10494112.ToArray(typeof(DockContainer));
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x060000DA RID: 218 RVA: 0x0000AE60 File Offset: 0x00009E60
		// (set) Token: 0x060000DB RID: 219 RVA: 0x0000AE68 File Offset: 0x00009E68
		[Description("The renderer used to calculate object metrics and draw contents.")]
		[Category("Appearance")]
		public RendererBase Renderer
		{
			get
			{
				return this.x38870620fd380a6b;
			}
			set
			{
				if (value == null)
				{
					if (!true)
					{
						goto IL_2B;
					}
					throw new ArgumentNullException();
				}
				else
				{
					if (this.x38870620fd380a6b == null)
					{
						goto IL_5A;
					}
					goto IL_2B;
				}
				IL_23:
				this.PropagateNewRenderer();
				return;
				IL_2B:
				this.x38870620fd380a6b.MetricsChanged -= this.OnRendererMetricsChanged;
				if (false)
				{
					goto IL_23;
				}
				this.x38870620fd380a6b.Dispose();
				IL_5A:
				this.x38870620fd380a6b = value;
				this.x38870620fd380a6b.MetricsChanged += this.OnRendererMetricsChanged;
				goto IL_23;
			}
		}

		// Token: 0x060000DC RID: 220 RVA: 0x0000AEE4 File Offset: 0x00009EE4
		private bool ShouldSerializeRenderer()
		{
			return !(this.x38870620fd380a6b is WhidbeyRenderer);
		}

		// Token: 0x060000DD RID: 221 RVA: 0x0000AEF8 File Offset: 0x00009EF8
		private void OnRendererMetricsChanged(object sender, EventArgs e)
		{
			this.PropagateNewRenderer();
		}

		// Token: 0x060000DE RID: 222 RVA: 0x0000AF00 File Offset: 0x00009F00
		private void PropagateNewRenderer()
		{
			foreach (object obj in this.xd27fa35d10494112)
			{
				DockContainer dockContainer = (DockContainer)obj;
				dockContainer.x4481febbc2e58301();
			}
			IEnumerator enumerator2 = this.xa90af1bb0ada0f53.GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					object obj2 = enumerator2.Current;
					x10ac79a4257c7f52 x10ac79a4257c7f = (x10ac79a4257c7f52)obj2;
					x10ac79a4257c7f.x4481febbc2e58301();
				}
			}
			finally
			{
				IDisposable disposable2 = enumerator2 as IDisposable;
				while (disposable2 != null)
				{
					disposable2.Dispose();
					if (2147483647 != 0 && 4 != 0)
					{
						break;
					}
				}
			}
		}

		// Token: 0x060000DF RID: 223 RVA: 0x0000AFD8 File Offset: 0x00009FD8
		internal void RegisterDockContainer(DockContainer container)
		{
			if (container is DocumentContainer)
			{
				if (-2 == 0)
				{
					goto IL_6F;
				}
				if (this.x1f1a3b29d7ed7776 != null)
				{
					throw new InvalidOperationException("Only one DocumentContainer can exist in a SandDock layout.");
				}
			}
			while (!this.xd27fa35d10494112.Contains(container))
			{
				this.xd27fa35d10494112.Add(container);
				if (2147483647 != 0)
				{
					IL_8A:
					if (this.DockSystemContainer != null || !(container.Parent is ContainerControl) || container.IsFloating)
					{
						goto IL_79;
					}
					IL_A1:
					this.DockSystemContainer = (ContainerControl)container.Parent;
					if (!false)
					{
						goto IL_6F;
					}
					goto IL_37;
				}
			}
			if (!false)
			{
				goto IL_8A;
			}
			goto IL_A1;
			IL_37:
			this.x1f1a3b29d7ed7776.x64b4c49ed703037e = this.BorderStyle;
			this.x1f1a3b29d7ed7776.x7d2c5325d16e569d = this.DocumentOverflow;
			this.x1f1a3b29d7ed7776.xa957e8f86f5e6115 = this.IntegralClose;
			if (false)
			{
			}
			IL_6D:
			return;
			IL_6F:
			IL_79:
			container.AllowDrop = this.SelectTabsOnDrag;
			if (!(container is DocumentContainer))
			{
				if (15 == 0)
				{
					goto IL_37;
				}
				if (2 != 0)
				{
					goto IL_6D;
				}
			}
			this.x1f1a3b29d7ed7776 = (DocumentContainer)container;
			goto IL_37;
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x0000B0F8 File Offset: 0x0000A0F8
		internal void UnregisterDockContainer(DockContainer container)
		{
			if (this.xd27fa35d10494112.Contains(container))
			{
				this.xd27fa35d10494112.Remove(container);
			}
			if (this.x1f1a3b29d7ed7776 == container)
			{
				this.x1f1a3b29d7ed7776 = null;
			}
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x0000B124 File Offset: 0x0000A124
		internal void RegisterAutoHideBar(x10ac79a4257c7f52 bar)
		{
			if (!this.xa90af1bb0ada0f53.Contains(bar))
			{
				this.xa90af1bb0ada0f53.Add(bar);
			}
			bar.AllowDrop = this.SelectTabsOnDrag;
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x0000B150 File Offset: 0x0000A150
		internal void UnregisterAutoHideBar(x10ac79a4257c7f52 bar)
		{
			if (this.xa90af1bb0ada0f53.Contains(bar))
			{
				this.xa90af1bb0ada0f53.Remove(bar);
			}
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x0000B16C File Offset: 0x0000A16C
		internal DockContainer FindDockedContainer(DockStyle dockStyle)
		{
			foreach (object obj in this.xd27fa35d10494112)
			{
				DockContainer dockContainer = (DockContainer)obj;
				if (dockContainer.Dock == dockStyle)
				{
					if (!dockContainer.IsFloating)
					{
						return dockContainer;
					}
				}
			}
			return null;
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x0000B1EC File Offset: 0x0000A1EC
		public DockContainer FindDockContainer(ContainerDockLocation location)
		{
			return this.FindDockedContainer(LayoutUtilities.xf8330a3964a419ba(location));
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x0000B1FC File Offset: 0x0000A1FC
		internal x410f3612b9a8f9de FindFloatingDockContainer(Guid guid)
		{
			x410f3612b9a8f9de[] floatingDockContainerList = this.GetFloatingDockContainerList();
			int i = 0;
			for (;;)
			{
				while (i < floatingDockContainerList.Length)
				{
					x410f3612b9a8f9de x410f3612b9a8f9de = floatingDockContainerList[i];
					if (!(x410f3612b9a8f9de.x0217cda8370c1f17 == guid))
					{
						i++;
					}
					else
					{
						x410f3612b9a8f9de result = x410f3612b9a8f9de;
						if (8 != 0)
						{
							return result;
						}
					}
				}
				break;
			}
			return null;
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x060000E6 RID: 230 RVA: 0x0000B27C File Offset: 0x0000A27C
		// (set) Token: 0x060000E7 RID: 231 RVA: 0x0000B284 File Offset: 0x0000A284
		public override ISite Site
		{
			get
			{
				return base.Site;
			}
			set
			{
				base.Site = value;
				if (false)
				{
					goto IL_85;
				}
				IL_60:
				if (value == null)
				{
					return;
				}
				IL_85:
				IDesignerHost designerHost = (IDesignerHost)this.GetService(typeof(IDesignerHost));
				if (designerHost != null)
				{
					if (!(designerHost.RootComponent is Form))
					{
						if (false)
						{
							return;
						}
					}
					else
					{
						this.x9492ad63ba3e62cf = (Form)designerHost.RootComponent;
					}
				}
				if (designerHost != null)
				{
					if (true)
					{
						if (!(designerHost.RootComponent is Control) && 3 != 0)
						{
							return;
						}
						if (this.DockSystemContainer != null)
						{
							if (2 == 0)
							{
								return;
							}
							return;
						}
					}
					this.DockSystemContainer = this.FindDockSystemContainer(designerHost, (Control)designerHost.RootComponent);
					if (false)
					{
						goto IL_60;
					}
				}
			}
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x0000B344 File Offset: 0x0000A344
		private Control FindDockSystemContainer(IDesignerHost designerHost, Control parent)
		{
			foreach (object obj in parent.Controls)
			{
				Control control = (Control)obj;
				if (control.Dock == DockStyle.Fill)
				{
					goto IL_0E;
				}
				if (!false)
				{
					if (false)
					{
						goto IL_0E;
					}
				}
				continue;
				IL_0E:
				if (control.Site == null)
				{
					if (15 != 0)
					{
					}
				}
				else if (control.Site.DesignMode && !control.Controls.IsReadOnly)
				{
					return this.FindDockSystemContainer(designerHost, control);
				}
			}
			return parent;
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x0000B3FC File Offset: 0x0000A3FC
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (false)
				{
					goto IL_47;
				}
				int i;
				if ((uint)i <= 4294967295U)
				{
					if (2147483647 != 0)
					{
						DockContainer[] array = new DockContainer[this.xd27fa35d10494112.Count];
						int j;
						if ((uint)i + (uint)j > 4294967295U)
						{
							goto IL_58;
						}
						this.xd27fa35d10494112.CopyTo(array);
						DockContainer[] array2 = array;
						for (i = 0; i < array2.Length; i++)
						{
							DockContainer dockContainer = array2[i];
							dockContainer.Dispose();
						}
					}
					this.xd27fa35d10494112.Clear();
					goto IL_47;
				}
				IL_39:
				x10ac79a4257c7f52[] array3;
				foreach (x10ac79a4257c7f52 x10ac79a4257c7f in array3)
				{
					x10ac79a4257c7f.Dispose();
				}
				this.xa90af1bb0ada0f53.Clear();
				goto IL_30;
				IL_47:
				x10ac79a4257c7f52[] array4 = new x10ac79a4257c7f52[this.xa90af1bb0ada0f53.Count];
				IL_58:
				this.xa90af1bb0ada0f53.CopyTo(array4);
				bool flag = ((uint)i | 2147483647U) == 0U;
				if (flag)
				{
					return;
				}
				array3 = array4;
				goto IL_39;
			}
			IL_30:
			base.Dispose(disposing);
		}

		// Token: 0x060000EA RID: 234 RVA: 0x0000B518 File Offset: 0x0000A518
		protected internal virtual void OnDockControlClosing(DockControlClosingEventArgs e)
		{
			if (this.x81beccfee80d0f84 != null)
			{
				this.x81beccfee80d0f84(this, e);
			}
		}

		// Token: 0x060000EB RID: 235 RVA: 0x0000B530 File Offset: 0x0000A530
		protected internal virtual void OnDockingStarted(EventArgs e)
		{
			if (this.xc5f1fda5242cf905 != null)
			{
				this.xc5f1fda5242cf905(this, e);
			}
		}

		// Token: 0x060000EC RID: 236 RVA: 0x0000B548 File Offset: 0x0000A548
		protected internal virtual void OnDockingFinished(EventArgs e)
		{
			if (this.x2556ec4d28ceecee != null)
			{
				this.x2556ec4d28ceecee(this, e);
			}
		}

		// Token: 0x060000ED RID: 237 RVA: 0x0000B560 File Offset: 0x0000A560
		protected virtual void OnResolveDockControl(ResolveDockControlEventArgs e)
		{
			if (this.x745fd7b95ab555c4 != null)
			{
				this.x745fd7b95ab555c4(this, e);
			}
		}

		// Token: 0x060000EE RID: 238 RVA: 0x0000B578 File Offset: 0x0000A578
		protected internal virtual void OnActiveTabbedDocumentChanged(EventArgs e)
		{
			if (this.x9e34f522d048dee6 != null)
			{
				this.x9e34f522d048dee6(this, e);
			}
		}

		// Token: 0x060000EF RID: 239 RVA: 0x0000B590 File Offset: 0x0000A590
		private void OnDockSystemContainerResize(object sender, EventArgs e)
		{
			if (this.OwnerForm != null)
			{
				goto IL_5A0;
			}
			goto IL_4F1;
			IL_442:
			return;
			IL_444:
			Form form;
			if (form.ActiveMdiChild.WindowState == FormWindowState.Maximized)
			{
				return;
			}
			int i;
			bool flag = ((uint)i & 0U) == 0U;
			if (!flag)
			{
				return;
			}
			IL_486:
			Rectangle rectangle = xedb4922162c60d3d.x41c62f474d3fb367(this.DockSystemContainer);
			i = -rectangle.Width;
			int num = -rectangle.Height;
			int j;
			int num2;
			if (this.DockSystemContainer is ToolStripContentPanel)
			{
				flag = ((uint)j > uint.MaxValue);
				if (!flag)
				{
					if (rectangle.Width <= 0)
					{
						return;
					}
				}
				if (rectangle.Height <= 0)
				{
					goto IL_442;
				}
				if ((uint)num2 < 0U)
				{
					goto IL_549;
				}
			}
			int num3;
			while (i > 0)
			{
				flag = ((uint)num2 + (uint)num3 > uint.MaxValue);
				if (flag)
				{
					goto IL_444;
				}
				ArrayList arrayList;
				if (-2147483648 != 0)
				{
					arrayList = new ArrayList();
					j = 0;
					using (IEnumerator enumerator = this.xd27fa35d10494112.GetEnumerator())
					{
						for (;;)
						{
							DockContainer dockContainer;
							if (!enumerator.MoveNext())
							{
								if (((uint)i & 0U) == 0U)
								{
									break;
								}
							}
							else
							{
								dockContainer = (DockContainer)enumerator.Current;
								flag = ((uint)num2 > uint.MaxValue);
								if (!flag)
								{
									if (dockContainer.Dock == DockStyle.Left)
									{
										goto IL_373;
									}
								}
								if (dockContainer.Dock != DockStyle.Right)
								{
									continue;
								}
							}
							IL_373:
							j += dockContainer.Width;
							arrayList.Add(dockContainer);
							continue;
							goto IL_373;
						}
						goto IL_2B2;
					}
					continue;
				}
				if (false)
				{
					flag = ((uint)num - (uint)i > uint.MaxValue);
					if (flag)
					{
						goto IL_52A;
					}
					goto IL_5A0;
				}
				else
				{
					IL_2DE:;
				}
				IL_2B2:
				while (j > 0)
				{
					using (IEnumerator enumerator2 = arrayList.GetEnumerator())
					{
						while (enumerator2.MoveNext())
						{
							object obj = enumerator2.Current;
							DockContainer dockContainer2 = (DockContainer)obj;
							num3 = Convert.ToInt32((double)dockContainer2.Width / (double)j * (double)i);
							if (!false)
							{
								if ((uint)num2 <= 4294967295U)
								{
								}
								j -= dockContainer2.Width;
								i -= num3;
								dockContainer2.ContentSize -= num3;
								if (j != 0)
								{
									continue;
								}
							}
							break;
						}
						break;
					}
				}
				break;
			}
			int num4;
			if (num > 0)
			{
				ArrayList arrayList2 = new ArrayList();
				flag = ((uint)num + (uint)num > uint.MaxValue);
				if (flag)
				{
					goto IL_2DE;
				}
				flag = ((uint)num - (uint)num4 > uint.MaxValue);
				if (flag)
				{
					goto IL_2FB;
				}
				num2 = 0;
				IEnumerator enumerator3 = this.xd27fa35d10494112.GetEnumerator();
				try
				{
					while (enumerator3.MoveNext())
					{
						object obj2 = enumerator3.Current;
						DockContainer dockContainer3 = (DockContainer)obj2;
						if (dockContainer3.Dock == DockStyle.Top)
						{
							goto IL_6F;
						}
						IL_59:
						if (dockContainer3.Dock != DockStyle.Bottom)
						{
							continue;
						}
						IL_6F:
						num2 += dockContainer3.Height;
						arrayList2.Add(dockContainer3);
						if ((uint)num4 + (uint)num2 > 4294967295U)
						{
							goto IL_59;
						}
					}
				}
				finally
				{
					IDisposable disposable3 = enumerator3 as IDisposable;
					while (disposable3 != null)
					{
						disposable3.Dispose();
						if ((uint)j + (uint)j >= 0U)
						{
							break;
						}
					}
				}
				if (num2 <= 0)
				{
					return;
				}
				IEnumerator enumerator4 = arrayList2.GetEnumerator();
				try
				{
					IL_E8:
					while (enumerator4.MoveNext())
					{
						do
						{
							DockContainer dockContainer4 = (DockContainer)enumerator4.Current;
							if ((uint)num3 <= 4294967295U)
							{
								num4 = Convert.ToInt32((double)dockContainer4.Height / (double)num2 * (double)num);
								num2 -= dockContainer4.Height;
							}
							num -= num4;
							dockContainer4.ContentSize -= num4;
							if (num2 != 0)
							{
								goto IL_E8;
							}
							flag = ((uint)num2 + (uint)num2 > uint.MaxValue);
						}
						while (flag);
						IL_175:
						return;
					}
					goto IL_175;
				}
				finally
				{
					IDisposable disposable4 = enumerator4 as IDisposable;
					while (disposable4 != null)
					{
						disposable4.Dispose();
						if ((uint)num2 + (uint)num3 >= 0U)
						{
							break;
						}
					}
				}
			}
			flag = ((uint)num2 + (uint)num < 0U);
			if (flag)
			{
				goto IL_2DE;
			}
			IL_2FB:
			flag = ((uint)num4 + (uint)num2 < 0U);
			if (flag)
			{
				goto IL_5A0;
			}
			return;
			IL_4D2:
			if (form.ActiveMdiChild != null)
			{
				goto IL_51C;
			}
			if ((uint)num2 >= 0U)
			{
				goto IL_486;
			}
			goto IL_442;
			IL_4F1:
			if (this.DockSystemContainer == null)
			{
				goto IL_486;
			}
			goto IL_590;
			IL_51C:
			Form form2;
			if (form.ActiveMdiChild != form2)
			{
				goto IL_444;
			}
			goto IL_486;
			IL_52A:
			if (form == null)
			{
				goto IL_486;
			}
			if (form.WindowState != FormWindowState.Minimized)
			{
				goto IL_4D2;
			}
			return;
			IL_549:
			form = form2.Parent.FindForm();
			goto IL_5DB;
			IL_590:
			form2 = this.DockSystemContainer.FindForm();
			if ((uint)i + (uint)num3 < 0U)
			{
				goto IL_51C;
			}
			if (form2 == null)
			{
				if ((uint)i - (uint)j <= 4294967295U)
				{
					goto IL_486;
				}
				goto IL_4D2;
			}
			else
			{
				if (form2.WindowState == FormWindowState.Minimized)
				{
					return;
				}
				if (form2.Parent != null)
				{
					goto IL_549;
				}
				goto IL_486;
			}
			IL_5A0:
			flag = ((uint)i + (uint)i < 0U);
			if (!flag && this.OwnerForm.WindowState != FormWindowState.Minimized)
			{
				if (((uint)j & 0U) != 0U)
				{
					goto IL_5DB;
				}
				flag = ((uint)num4 + (uint)i < 0U);
				if (flag)
				{
					goto IL_590;
				}
				goto IL_4F1;
			}
			return;
			IL_5DB:
			goto IL_52A;
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x0000BBE8 File Offset: 0x0000ABE8
		private void OnOwnerFormActivated(object sender, EventArgs e)
		{
			foreach (object obj in this.xd27fa35d10494112)
			{
				DockContainer dockContainer = (DockContainer)obj;
				if (false)
				{
					break;
				}
				if (!dockContainer.IsFloating)
				{
					dockContainer.xa2414c47d888068e(sender, e);
				}
			}
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x0000BC64 File Offset: 0x0000AC64
		private void OnOwnerFormDeactivated(object sender, EventArgs e)
		{
			foreach (object obj in this.xd27fa35d10494112)
			{
				DockContainer dockContainer = (DockContainer)obj;
				if (!dockContainer.IsFloating)
				{
					dockContainer.x19e788b09b195d4f(sender, e);
				}
			}
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x0000BCD8 File Offset: 0x0000ACD8
		public static void ActivateProduct(string licenseKey)
		{
			x294bd621a33dc533.ActivateProduct(licenseKey);
		}

		// Token: 0x04000025 RID: 37
		internal ArrayList xd27fa35d10494112;

		// Token: 0x04000026 RID: 38
		internal ArrayList xa90af1bb0ada0f53;

		// Token: 0x04000027 RID: 39
		private Hashtable x8fb2a5bf0df0416f;

		// Token: 0x04000028 RID: 40
		private DockControl x4daa1b665423612a;

		// Token: 0x04000029 RID: 41
		private RendererBase x38870620fd380a6b;

		// Token: 0x0400002A RID: 42
		private DockingHints x48cee1d69929b4fe = DockingHints.TranslucentFill;

		// Token: 0x0400002B RID: 43
		private DockingManager x531514c39973cbc6 = DockingManager.Whidbey;

		// Token: 0x0400002C RID: 44
		private int xdca928fc295dbb2a = 30;

		// Token: 0x0400002D RID: 45
		private int xb3f3aa0fff672c52 = 500;

		// Token: 0x0400002E RID: 46
		private bool xf702e23ec6dfb474 = true;

		// Token: 0x0400002F RID: 47
		private bool xab09a805ddd3c3a1 = true;

		// Token: 0x04000030 RID: 48
		private bool xd76156c80fb2abda = true;

		// Token: 0x04000031 RID: 49
		private bool x46d0951c16d6ad61 = true;

		// Token: 0x04000032 RID: 50
		private bool xcc4067ee19f6f422;

		// Token: 0x04000033 RID: 51
		private bool xac286b48606510c1;

		// Token: 0x04000034 RID: 52
		private bool xb379517eb20fde45;

		// Token: 0x04000035 RID: 53
		private bool x2b7e44f0a217252e;

		// Token: 0x04000036 RID: 54
		private bool x26be2ab374407894;

		// Token: 0x04000037 RID: 55
		private DocumentContainer x1f1a3b29d7ed7776;

		// Token: 0x04000038 RID: 56
		private TD.SandDock.Rendering.BorderStyle xacfbd7a08ba56c78 = TD.SandDock.Rendering.BorderStyle.Flat;

		// Token: 0x04000039 RID: 57
		private DocumentOverflowMode x8362acb4106ff84c = DocumentOverflowMode.Scrollable;

		// Token: 0x0400003A RID: 58
		private DocumentContainerWindowOpenPosition xf57f78376726d093 = DocumentContainerWindowOpenPosition.Last;

		// Token: 0x0400003B RID: 59
		private bool x1bb166050445ea16;

		// Token: 0x0400003C RID: 60
		private Form x9492ad63ba3e62cf;

		// Token: 0x0400003D RID: 61
		private Control x7478f4855b6bd03d;

		// Token: 0x0400003E RID: 62
		private EventHandler xc5f1fda5242cf905;

		// Token: 0x0400003F RID: 63
		private EventHandler x2556ec4d28ceecee;

		// Token: 0x04000040 RID: 64
		private ShowControlContextMenuEventHandler x8956f13386ebab05;

		// Token: 0x04000041 RID: 65
		private DockControlEventHandler x505fd87f59cc2876;

		// Token: 0x04000042 RID: 66
		private DockControlEventHandler x528e78a16a92fb41;

		// Token: 0x04000043 RID: 67
		private DockControlEventHandler xbc613baf913a9f51;

		// Token: 0x04000044 RID: 68
		private ResolveDockControlEventHandler x745fd7b95ab555c4;

		// Token: 0x04000045 RID: 69
		private EventHandler x9e34f522d048dee6;

		// Token: 0x04000046 RID: 70
		private DockControlClosingEventHandler x81beccfee80d0f84;

		// Token: 0x04000047 RID: 71
		private ActiveFilesListEventHandler x310e5e7c96407793;
	}
}
