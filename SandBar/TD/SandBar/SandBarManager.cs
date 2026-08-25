using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace TD.SandBar
{
	// Token: 0x02000037 RID: 55
	[Designer("TD.SandBar.Design.SandBarManagerDesigner, SandBar.Design, Version=1.0.0.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3")]
	[ToolboxBitmap(typeof(SandBarManager))]
	public class SandBarManager : Component
	{
		// Token: 0x060002B7 RID: 695 RVA: 0x0000D658 File Offset: 0x0000C658
		public SandBarManager()
		{
			this.xbc5b8cb591c2f262 = new ArrayList();
			this.xd27fa35d10494112 = new ArrayList();
			this.Renderer = new Office2003Renderer();
		}

		// Token: 0x060002B8 RID: 696 RVA: 0x0000D698 File Offset: 0x0000C698
		public SandBarManager(IContainer container) : this()
		{
			container.Add(this);
		}

		// Token: 0x170000CB RID: 203
		// (get) Token: 0x060002B9 RID: 697 RVA: 0x0000D6A8 File Offset: 0x0000C6A8
		[Browsable(false)]
		public MenuBar MenuBar
		{
			get
			{
				return this._x49a2aa22606cd919;
			}
		}

		// Token: 0x060002BA RID: 698 RVA: 0x0000D6B0 File Offset: 0x0000C6B0
		internal void RegisterToolBarContainer(ToolBarContainer container)
		{
			if (!this.xd27fa35d10494112.Contains(container))
			{
				this.xd27fa35d10494112.Add(container);
			}
		}

		// Token: 0x060002BB RID: 699 RVA: 0x0000D6D0 File Offset: 0x0000C6D0
		internal void UnregisterToolBarContainer(ToolBarContainer container)
		{
			if (this.xd27fa35d10494112.Contains(container))
			{
				this.xd27fa35d10494112.Remove(container);
			}
		}

		// Token: 0x060002BC RID: 700 RVA: 0x0000D6EC File Offset: 0x0000C6EC
		public ToolBarContainer FindSuitableContainer(DockStyle dockStyle)
		{
			foreach (object obj in this.xd27fa35d10494112)
			{
				ToolBarContainer toolBarContainer = (ToolBarContainer)obj;
				if (toolBarContainer.Dock == dockStyle)
				{
					return toolBarContainer;
				}
			}
			return null;
		}

		// Token: 0x060002BD RID: 701 RVA: 0x0000D75C File Offset: 0x0000C75C
		public ToolBar[] GetToolBars()
		{
			ToolBar[] array = new ToolBar[this.xbc5b8cb591c2f262.Count];
			this.xbc5b8cb591c2f262.CopyTo(array);
			return array;
		}

		// Token: 0x060002BE RID: 702 RVA: 0x0000D788 File Offset: 0x0000C788
		public ToolBarContainer[] GetContainers()
		{
			ToolBarContainer[] array = new ToolBarContainer[this.xd27fa35d10494112.Count];
			this.xd27fa35d10494112.CopyTo(array);
			return array;
		}

		// Token: 0x060002BF RID: 703 RVA: 0x0000D7B4 File Offset: 0x0000C7B4
		internal void ShowContextMenu(ToolBar toolbar, Control control, Point position)
		{
			if (!this._x0334f6f14b690e27)
			{
				return;
			}
			MenuBarItem menuBarItem = new MenuBarItem();
			foreach (object obj in this.xbc5b8cb591c2f262)
			{
				ToolBar toolBar = (ToolBar)obj;
				if (toolBar.Closable)
				{
					SandBarManager.x63ef418b06d30c38 x63ef418b06d30c = new SandBarManager.x63ef418b06d30c38(toolBar);
					x63ef418b06d30c.Text = toolBar.Text;
					x63ef418b06d30c.Checked = toolBar.IsOpen;
					menuBarItem.Items.Add(x63ef418b06d30c);
				}
			}
			if (menuBarItem.HasChildren)
			{
				menuBarItem.SetToolbar(toolbar);
				SandBarManager.x63ef418b06d30c38 x63ef418b06d30c2 = (SandBarManager.x63ef418b06d30c38)menuBarItem.Show(control, position);
				menuBarItem.SetToolbar(null);
				if (x63ef418b06d30c2 != null)
				{
					if (x63ef418b06d30c2.x8c3ddcee83adfc9a.IsOpen)
					{
						x63ef418b06d30c2.x8c3ddcee83adfc9a.Visible = false;
					}
					else
					{
						x63ef418b06d30c2.x8c3ddcee83adfc9a.Visible = true;
					}
				}
			}
			menuBarItem.Dispose();
		}

		// Token: 0x170000CC RID: 204
		// (get) Token: 0x060002C0 RID: 704 RVA: 0x0000D8B0 File Offset: 0x0000C8B0
		internal bool FormHasFocus
		{
			get
			{
				if (this.OwnerForm == null || this.OwnerForm.IsMdiChild)
				{
					return true;
				}
				Form activeForm = Form.ActiveForm;
				return activeForm != null && (activeForm == this.OwnerForm || activeForm.Owner == this.OwnerForm);
			}
		}

		// Token: 0x170000CD RID: 205
		// (get) Token: 0x060002C1 RID: 705 RVA: 0x0000D8F8 File Offset: 0x0000C8F8
		// (set) Token: 0x060002C2 RID: 706 RVA: 0x0000D900 File Offset: 0x0000C900
		[Description("Indicates whether the manager will display a context menu allowing the user to show and hide toolbars.")]
		[DefaultValue(true)]
		[Category("Behavior")]
		public bool EnableContextMenu
		{
			get
			{
				return this._x0334f6f14b690e27;
			}
			set
			{
				this._x0334f6f14b690e27 = value;
			}
		}

		// Token: 0x170000CE RID: 206
		// (get) Token: 0x060002C3 RID: 707 RVA: 0x0000D90C File Offset: 0x0000C90C
		// (set) Token: 0x060002C4 RID: 708 RVA: 0x0000D914 File Offset: 0x0000C914
		[Category("Behavior")]
		[DefaultValue(true)]
		[Description("Indicates whether low importance menu items are enabled on a manager-wide basis.")]
		public bool AllowLowImportanceMenuItems
		{
			get
			{
				return this.x791fbd83747d651b;
			}
			set
			{
				this.x791fbd83747d651b = value;
			}
		}

		// Token: 0x060002C5 RID: 709 RVA: 0x0000D920 File Offset: 0x0000C920
		public void AddToolbar(ToolBar toolbar)
		{
			if (this.xbc5b8cb591c2f262.Contains(toolbar))
			{
				return;
			}
			if (toolbar is MenuBar && this._x49a2aa22606cd919 != null)
			{
				throw new InvalidOperationException("Only one MenuBar should be added to each toolbar layout.");
			}
			this.xbc5b8cb591c2f262.Add(toolbar);
			toolbar.Disposed += this.OnToolBarDisposed;
			if (toolbar is MenuBar)
			{
				this._x49a2aa22606cd919 = (MenuBar)toolbar;
			}
		}

		// Token: 0x060002C6 RID: 710 RVA: 0x0000D98C File Offset: 0x0000C98C
		public void RemoveToolbar(ToolBar toolbar)
		{
			if (this.xbc5b8cb591c2f262.Contains(toolbar))
			{
				this.xbc5b8cb591c2f262.Remove(toolbar);
				if (toolbar == this._x49a2aa22606cd919)
				{
					this._x49a2aa22606cd919 = null;
				}
				toolbar.Disposed -= this.OnToolBarDisposed;
			}
		}

		// Token: 0x170000CF RID: 207
		// (get) Token: 0x060002C7 RID: 711 RVA: 0x0000D9CC File Offset: 0x0000C9CC
		// (set) Token: 0x060002C8 RID: 712 RVA: 0x0000D9D4 File Offset: 0x0000C9D4
		[DefaultValue(typeof(MenuActivationType), "DoEvents")]
		[Category("Behavior")]
		[Description("Specifies how menu items are activated after they are picked by the user.")]
		public MenuActivationType MenuActivation
		{
			get
			{
				return this.xba5782505b53eac1;
			}
			set
			{
				this.xba5782505b53eac1 = value;
			}
		}

		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x060002C9 RID: 713 RVA: 0x0000D9E0 File Offset: 0x0000C9E0
		// (set) Token: 0x060002CA RID: 714 RVA: 0x0000D9E8 File Offset: 0x0000C9E8
		[Browsable(false)]
		public Form OwnerForm
		{
			get
			{
				return this._x9492ad63ba3e62cf;
			}
			set
			{
				if (this._x9492ad63ba3e62cf != null)
				{
					this._x9492ad63ba3e62cf.Activated -= this.OnOwnerFormActivated;
					this._x9492ad63ba3e62cf.Deactivate -= this.OnOwnerFormDeactivated;
					this._x9492ad63ba3e62cf.VisibleChanged -= this.OnOwnerFormVisibleChanged;
					this._x9492ad63ba3e62cf.Resize -= this.OnOwnerFormResize;
				}
				this._x9492ad63ba3e62cf = value;
				if (this._x9492ad63ba3e62cf != null)
				{
					this._x9492ad63ba3e62cf.Activated += this.OnOwnerFormActivated;
					this._x9492ad63ba3e62cf.Deactivate += this.OnOwnerFormDeactivated;
					this._x9492ad63ba3e62cf.VisibleChanged += this.OnOwnerFormVisibleChanged;
					this._x9492ad63ba3e62cf.Resize += this.OnOwnerFormResize;
				}
				foreach (object obj in this.xbc5b8cb591c2f262)
				{
					ToolBar toolBar = (ToolBar)obj;
					if (toolBar is MenuBar)
					{
						((MenuBar)toolBar).OwnerForm = this._x9492ad63ba3e62cf;
					}
				}
			}
		}

		// Token: 0x060002CB RID: 715 RVA: 0x0000DB30 File Offset: 0x0000CB30
		private void OnOwnerFormResize(object sender, EventArgs e)
		{
			this.OnApplyToolBarVisibility(null, null);
		}

		// Token: 0x060002CC RID: 716 RVA: 0x0000DB3C File Offset: 0x0000CB3C
		private void OnOwnerFormVisibleChanged(object sender, EventArgs e)
		{
			this.UpdateFocusVisibility();
		}

		// Token: 0x060002CD RID: 717 RVA: 0x0000DB44 File Offset: 0x0000CB44
		public void SetLayout(string layout)
		{
			if (layout == null)
			{
				throw new ArgumentNullException();
			}
			foreach (object obj in this.xd27fa35d10494112)
			{
				ToolBarContainer toolBarContainer = (ToolBarContainer)obj;
				toolBarContainer.SuspendLayout();
			}
			try
			{
				XmlTextReader xmlTextReader = new XmlTextReader(new StringReader(layout));
				while (xmlTextReader.Read())
				{
					if (xmlTextReader.NodeType == XmlNodeType.Element && xmlTextReader.Name == "Layout")
					{
						this.RestoreToolbarLayout(xmlTextReader);
					}
				}
				xmlTextReader.Close();
			}
			catch
			{
				throw new ArgumentException();
			}
			foreach (object obj2 in this.xd27fa35d10494112)
			{
				ToolBarContainer toolBarContainer2 = (ToolBarContainer)obj2;
				toolBarContainer2.ResumeLayout();
			}
		}

		// Token: 0x060002CE RID: 718 RVA: 0x0000DC70 File Offset: 0x0000CC70
		private void RestoreToolbarLayout(XmlTextReader xml)
		{
			for (;;)
			{
				if (!xml.Read())
				{
					int num;
					int num2;
					bool flag = (uint)num + (uint)num2 < 0U;
					if (!flag)
					{
						break;
					}
				}
				if (xml.NodeType == XmlNodeType.Element && xml.Name == "Toolbar")
				{
					Guid guid = new Guid(xml.GetAttribute("Guid"));
					int dockLine = int.Parse(xml.GetAttribute("DockLine"));
					int dockOffset = int.Parse(xml.GetAttribute("DockOffset"));
					bool visible = bool.Parse(xml.GetAttribute("Visible"));
					ToolBar toolBar = this.FindToolbar(guid);
					if (toolBar != null)
					{
						toolBar.DockLine = dockLine;
						toolBar.DockOffset = dockOffset;
						string text = (xml.GetAttribute("DockMode") != null) ? xml.GetAttribute("DockMode") : "";
						Guid guid2 = (xml.GetAttribute("Container") != null) ? new Guid(xml.GetAttribute("Container")) : Guid.Empty;
						if (!(text == "Floating"))
						{
							ToolBarContainer container;
							if (text.Length != 0)
							{
								DockStyle dockStyle = (DockStyle)Enum.Parse(typeof(DockStyle), text);
								container = this.FindSuitableContainer(dockStyle);
							}
							else
							{
								container = this.FindContainer(guid2);
							}
							toolBar.Redock(container);
							goto IL_16B;
						}
						int x = int.Parse(xml.GetAttribute("FloatingX"));
						int num = int.Parse(xml.GetAttribute("FloatingY"));
						string attribute = xml.GetAttribute("FloatingWidth");
						string attribute2 = xml.GetAttribute("FloatingHeight");
						toolBar.x5d1aeeb0b6ebccac(this, new Point(x, num), true);
						if (!true)
						{
							goto IL_FA;
						}
						if (attribute != null)
						{
							toolBar.Parent.Size = new Size(int.Parse(attribute), int.Parse(attribute2));
							goto IL_16B;
						}
						goto IL_16B;
						IL_10E:
						int num3;
						while (xml.Read() && (xml.NodeType != XmlNodeType.EndElement || !(xml.Name == "Items")))
						{
							if (xml.NodeType == XmlNodeType.Element && xml.Name == "Item")
							{
								num3 = int.Parse(xml.GetAttribute("Offset"));
								visible = bool.Parse(xml.GetAttribute("Visible"));
								if (num3 >= 0 && num3 < toolBar.Items.Count)
								{
									goto IL_FA;
								}
							}
						}
						continue;
						IL_16B:
						toolBar.Visible = visible;
						if (toolBar is ContainerBar)
						{
							ContainerBar containerBar = (ContainerBar)toolBar;
							string attribute3 = xml.GetAttribute("Width");
							int num2 = (attribute3 == null) ? containerBar.MinimumSize.Width : int.Parse(attribute3);
							string attribute4 = xml.GetAttribute("Height");
							int height = (attribute4 == null) ? containerBar.MinimumSize.Height : int.Parse(attribute4);
							containerBar.MinimumSize = new Size(num2, height);
						}
						if (xml.IsEmptyElement)
						{
							continue;
						}
						xml.Read();
						xml.Read();
						if (xml.NodeType == XmlNodeType.Element && xml.Name == "Items" && !xml.IsEmptyElement)
						{
							goto IL_10E;
						}
						continue;
						IL_FA:
						toolBar.Items[num3].Visible = visible;
						goto IL_10E;
					}
				}
			}
		}

		// Token: 0x060002CF RID: 719 RVA: 0x0000DFB4 File Offset: 0x0000CFB4
		public ToolBar FindToolbar(Guid guid)
		{
			foreach (object obj in this.xbc5b8cb591c2f262)
			{
				ToolBar toolBar = (ToolBar)obj;
				if (toolBar.Guid == guid)
				{
					return toolBar;
				}
			}
			return null;
		}

		// Token: 0x060002D0 RID: 720 RVA: 0x0000E028 File Offset: 0x0000D028
		public ToolBarContainer FindContainer(Guid guid)
		{
			foreach (object obj in this.xd27fa35d10494112)
			{
				ToolBarContainer toolBarContainer = (ToolBarContainer)obj;
				if (toolBarContainer.Guid == guid)
				{
					return toolBarContainer;
				}
			}
			return null;
		}

		// Token: 0x060002D1 RID: 721 RVA: 0x0000E09C File Offset: 0x0000D09C
		public string GetLayout()
		{
			return this.GetLayout(false);
		}

		// Token: 0x060002D2 RID: 722 RVA: 0x0000E0A8 File Offset: 0x0000D0A8
		public string GetLayout(bool includeItemVisibility)
		{
			StringWriter stringWriter = new StringWriter();
			XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);
			xmlTextWriter.Formatting = Formatting.Indented;
			xmlTextWriter.WriteStartDocument();
			xmlTextWriter.WriteStartElement("Layout");
			foreach (object obj in this.xbc5b8cb591c2f262)
			{
				ToolBar toolbar = (ToolBar)obj;
				this.SaveToolbarLayout(toolbar, xmlTextWriter, includeItemVisibility);
			}
			xmlTextWriter.WriteEndElement();
			xmlTextWriter.WriteEndDocument();
			xmlTextWriter.Flush();
			xmlTextWriter.Close();
			return stringWriter.ToString();
		}

		// Token: 0x060002D3 RID: 723 RVA: 0x0000E158 File Offset: 0x0000D158
		private void SaveToolbarLayout(ToolBar toolbar, XmlTextWriter xml, bool includeItemVisibility)
		{
			xml.WriteStartElement("Toolbar");
			xml.WriteAttributeString("Guid", toolbar.Guid.ToString());
			int top;
			int height;
			do
			{
				xml.WriteAttributeString("DockLine", toolbar.DockLine.ToString());
				xml.WriteAttributeString("DockOffset", toolbar.DockOffset.ToString());
				xml.WriteAttributeString("Visible", toolbar.IsOpen.ToString());
				if (toolbar.Situation != ToolBarSituation.Floating)
				{
					goto IL_164;
				}
				xml.WriteAttributeString("DockMode", "Floating");
				xml.WriteAttributeString("FloatingX", toolbar.Parent.Left.ToString());
				string localName = "FloatingY";
				top = toolbar.Parent.Top;
				xml.WriteAttributeString(localName, top.ToString());
			}
			while ((uint)height < 0U);
			xml.WriteAttributeString("FloatingWidth", toolbar.Parent.Width.ToString());
			string localName2 = "FloatingHeight";
			height = toolbar.Parent.Height;
			xml.WriteAttributeString(localName2, height.ToString());
			goto IL_197;
			IL_164:
			if (toolbar.Situation == ToolBarSituation.Contained)
			{
				xml.WriteAttributeString("Container", ((ToolBarContainer)toolbar.Parent).Guid.ToString());
			}
			IL_197:
			if (toolbar is ContainerBar)
			{
				xml.WriteAttributeString("Width", ((ContainerBar)toolbar).MinimumSize.Width.ToString());
				xml.WriteAttributeString("Height", ((ContainerBar)toolbar).MinimumSize.Height.ToString());
			}
			if (includeItemVisibility && !(toolbar is MenuBar))
			{
				xml.WriteStartElement("Items");
				int num = 0;
				bool flag = (uint)top > uint.MaxValue;
				if (flag)
				{
				}
				IL_10:
				if (num >= toolbar.Items.Count)
				{
					xml.WriteEndElement();
					goto IL_24;
				}
				xml.WriteStartElement("Item");
				xml.WriteAttributeString("Offset", num.ToString());
				xml.WriteAttributeString("Visible", toolbar.Items[num].Visible.ToString());
				xml.WriteEndElement();
				num++;
				goto IL_10;
			}
			IL_24:
			xml.WriteEndElement();
		}

		// Token: 0x060002D4 RID: 724 RVA: 0x0000E3CC File Offset: 0x0000D3CC
		public Rectangle GetScreenBounds()
		{
			if (this._x9492ad63ba3e62cf != null)
			{
				Rectangle result = new Rectangle(this._x9492ad63ba3e62cf.PointToScreen(new Point(0, 0)), this._x9492ad63ba3e62cf.ClientRectangle.Size);
				return result;
			}
			return Screen.PrimaryScreen.Bounds;
		}

		// Token: 0x060002D5 RID: 725 RVA: 0x0000E41C File Offset: 0x0000D41C
		private bool ShouldSerializeRenderer()
		{
			return this.Renderer.GetType() != typeof(Office2003Renderer);
		}

		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x060002D6 RID: 726 RVA: 0x0000E438 File Offset: 0x0000D438
		// (set) Token: 0x060002D7 RID: 727 RVA: 0x0000E440 File Offset: 0x0000D440
		[Category("Appearance")]
		[Description("The renderer currently in use by the toolbar layout.")]
		[TypeConverter(typeof(x01480672935e1b10))]
		public IToolBarRenderer Renderer
		{
			get
			{
				return this.x38870620fd380a6b;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException();
				}
				if (value == this.x38870620fd380a6b)
				{
					return;
				}
				if (this.x38870620fd380a6b != null)
				{
					this.x38870620fd380a6b.RedrawRequired -= this.OnRedrawRequired;
					this.x38870620fd380a6b.RemoveConsumer(this);
				}
				this.x38870620fd380a6b = value;
				if (this.x38870620fd380a6b != null)
				{
					this.x38870620fd380a6b.AddConsumer(this);
					this.x38870620fd380a6b.RedrawRequired += this.OnRedrawRequired;
				}
				this.OnRendererChanged();
			}
		}

		// Token: 0x060002D8 RID: 728 RVA: 0x0000E4C4 File Offset: 0x0000D4C4
		private void OnRedrawRequired(object sender, EventArgs e)
		{
			this.OnRendererChanged();
		}

		// Token: 0x060002D9 RID: 729 RVA: 0x0000E4CC File Offset: 0x0000D4CC
		internal void OnRendererChanged()
		{
			foreach (object obj in this.xd27fa35d10494112)
			{
				ToolBarContainer toolBarContainer = (ToolBarContainer)obj;
				toolBarContainer.xebe668a62443b65f();
			}
			foreach (object obj2 in this.xbc5b8cb591c2f262)
			{
				ToolBar toolBar = (ToolBar)obj2;
				if (toolBar.Situation == ToolBarSituation.Floating)
				{
					toolBar.OnRendererChanged();
				}
			}
		}

		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x060002DA RID: 730 RVA: 0x0000E594 File Offset: 0x0000D594
		// (set) Token: 0x060002DB RID: 731 RVA: 0x0000E59C File Offset: 0x0000D59C
		public override ISite Site
		{
			get
			{
				return base.Site;
			}
			set
			{
				base.Site = value;
				if (value != null)
				{
					IDesignerHost designerHost = (IDesignerHost)this.GetService(typeof(IDesignerHost));
					if (designerHost != null && designerHost.RootComponent is Form)
					{
						this._x9492ad63ba3e62cf = (Form)designerHost.RootComponent;
					}
				}
			}
		}

		// Token: 0x060002DC RID: 732 RVA: 0x0000E5EC File Offset: 0x0000D5EC
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				ToolBarContainer[] array = new ToolBarContainer[this.xd27fa35d10494112.Count];
				this.xd27fa35d10494112.CopyTo(array);
				foreach (ToolBarContainer toolBarContainer in array)
				{
					toolBarContainer.Dispose();
				}
				this.xd27fa35d10494112.Clear();
				this.x38870620fd380a6b.RedrawRequired -= this.OnRedrawRequired;
				this.x38870620fd380a6b.RemoveConsumer(this);
			}
			base.Dispose(disposing);
		}

		// Token: 0x060002DD RID: 733 RVA: 0x0000E668 File Offset: 0x0000D668
		private void OnOwnerFormActivated(object sender, EventArgs e)
		{
			foreach (object obj in this.xd27fa35d10494112)
			{
				ToolBarContainer toolBarContainer = (ToolBarContainer)obj;
				toolBarContainer.xa2414c47d888068e();
			}
			this.UpdateFocusVisibility();
		}

		// Token: 0x060002DE RID: 734 RVA: 0x0000E6D4 File Offset: 0x0000D6D4
		private void OnOwnerFormDeactivated(object sender, EventArgs e)
		{
			foreach (object obj in this.xd27fa35d10494112)
			{
				ToolBarContainer toolBarContainer = (ToolBarContainer)obj;
				toolBarContainer.x19e788b09b195d4f();
			}
			this.UpdateFocusVisibility();
		}

		// Token: 0x060002DF RID: 735 RVA: 0x0000E740 File Offset: 0x0000D740
		public static void Merge(ToolBar source, ToolBar target)
		{
			if (source == null || target == null)
			{
				throw new ArgumentNullException();
			}
			if (source == target)
			{
				throw new ArgumentException("A toolbar cannot merge with itself.");
			}
			if (!source.AllowMerge || !target.AllowMerge)
			{
				return;
			}
			xf92605a24a69622a.x54516ceea3116eb1();
			if (source.MergedToolBar != null)
			{
				SandBarManager.UndoMerge(source);
			}
			if (target.MergedToolBar != null)
			{
				SandBarManager.UndoMerge(target);
			}
			source.x4fd1b19af748ed20 = xf00666a2552f1592.xf97071ef9bf45fdf(source);
			target.x4fd1b19af748ed20 = xf00666a2552f1592.xf97071ef9bf45fdf(target);
			source.x73be6e650087b30e = true;
			target.x73be6e650087b30e = true;
			try
			{
				SandBarManager.RecursiveMerge(source.Items, target.Items);
				source.x5937e70b1b3ec5d7(target);
				target.x5937e70b1b3ec5d7(source);
			}
			finally
			{
				source.x73be6e650087b30e = false;
				target.x73be6e650087b30e = false;
				source.xcf42ad4a4f3fcbf6();
				target.xcf42ad4a4f3fcbf6();
			}
		}

		// Token: 0x060002E0 RID: 736 RVA: 0x0000E818 File Offset: 0x0000D818
		private static void RecursiveMerge(ToolbarItemBaseCollection sourceItems, ToolbarItemBaseCollection destinationItems)
		{
			using (IEnumerator enumerator = sourceItems.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					ToolbarItemBase toolbarItemBase = (ToolbarItemBase)obj;
					toolbarItemBase.x90db551379a5ba1c = toolbarItemBase.MergeIndex;
				}
				goto IL_171;
			}
			IL_66:
			ToolbarItemBase toolbarItemBase2;
			ToolbarItemBase toolbarItemBase3;
			SandBarManager.RecursiveMerge(((MenuItemBase)toolbarItemBase2).Items, ((MenuItemBase)toolbarItemBase3).Items);
			IL_138:
			int num;
			num--;
			IL_13C:
			int count;
			if (num >= 0)
			{
				toolbarItemBase2 = sourceItems[num];
				toolbarItemBase3 = null;
				if (toolbarItemBase2.MergeAction != ItemMergeAction.Add)
				{
					toolbarItemBase3 = toolbarItemBase2.FindMergeTarget(destinationItems);
				}
				int num2;
				int i;
				switch (toolbarItemBase2.MergeAction)
				{
				case ItemMergeAction.Add:
					destinationItems.Insert(count, toolbarItemBase2);
					goto IL_138;
				case ItemMergeAction.Insert:
					if (toolbarItemBase3 == null)
					{
						goto IL_138;
					}
					num2 = destinationItems.IndexOf(toolbarItemBase3);
					destinationItems.Insert(num2, toolbarItemBase2);
					i = 0;
					break;
				case ItemMergeAction.MergeChildren:
					if (toolbarItemBase3 == null || !(toolbarItemBase2 is MenuItemBase) || !(toolbarItemBase3 is MenuItemBase))
					{
						goto IL_138;
					}
					if (false)
					{
						return;
					}
					goto IL_66;
				case ItemMergeAction.Remove:
				{
					if (toolbarItemBase3 == null)
					{
						goto IL_138;
					}
					int num3 = destinationItems.IndexOf(toolbarItemBase3);
					destinationItems.Remove(toolbarItemBase3);
					if ((uint)num3 + (uint)count <= 4294967295U)
					{
						for (int j = 0; j < sourceItems.Count; j++)
						{
							if (sourceItems[j].x90db551379a5ba1c > num3)
							{
								sourceItems[j].x90db551379a5ba1c--;
							}
							else if (sourceItems[j].x90db551379a5ba1c == num3)
							{
								sourceItems[j].x90db551379a5ba1c = -1;
							}
						}
						goto IL_138;
					}
					break;
				}
				case ItemMergeAction.Replace:
					if (toolbarItemBase3 != null)
					{
						int index = destinationItems.IndexOf(toolbarItemBase3);
						destinationItems.Remove(toolbarItemBase3);
						destinationItems.Insert(index, toolbarItemBase2);
						goto IL_138;
					}
					goto IL_138;
				default:
					goto IL_138;
				}
				while (i < sourceItems.Count)
				{
					if (sourceItems[i].x90db551379a5ba1c > num2)
					{
						sourceItems[i].x90db551379a5ba1c++;
					}
					i++;
				}
				goto IL_138;
			}
			return;
			IL_171:
			count = destinationItems.Count;
			num = sourceItems.Count - 1;
			goto IL_13C;
		}

		// Token: 0x060002E1 RID: 737 RVA: 0x0000EA68 File Offset: 0x0000DA68
		public static void UndoMerge(ToolBar toolbar)
		{
			SandBarManager.ExitMenuLoop();
			if (toolbar.MergedToolBar != null)
			{
				toolbar.MergedToolBar.x73be6e650087b30e = true;
				toolbar.MergedToolBar.x4fd1b19af748ed20.xbe2cb8264b39a622(toolbar.MergedToolBar.Items);
				toolbar.MergedToolBar.x5937e70b1b3ec5d7(null);
				toolbar.MergedToolBar.x4fd1b19af748ed20 = null;
				toolbar.MergedToolBar.x73be6e650087b30e = false;
				toolbar.MergedToolBar.xcf42ad4a4f3fcbf6();
				toolbar.x73be6e650087b30e = true;
				toolbar.x4fd1b19af748ed20.xbe2cb8264b39a622(toolbar.Items);
				toolbar.x5937e70b1b3ec5d7(null);
				toolbar.x4fd1b19af748ed20 = null;
				toolbar.x73be6e650087b30e = false;
				toolbar.xcf42ad4a4f3fcbf6();
			}
		}

		// Token: 0x060002E2 RID: 738 RVA: 0x0000EB10 File Offset: 0x0000DB10
		public static void ExitMenuLoop()
		{
			xf92605a24a69622a.x54516ceea3116eb1();
		}

		// Token: 0x060002E3 RID: 739 RVA: 0x0000EB18 File Offset: 0x0000DB18
		private void UpdateFocusVisibility()
		{
			if (this.OwnerForm != null && this.OwnerForm.IsHandleCreated)
			{
				this.OwnerForm.BeginInvoke(new EventHandler(this.OnApplyToolBarVisibility));
			}
		}

		// Token: 0x060002E4 RID: 740 RVA: 0x0000EB48 File Offset: 0x0000DB48
		private void OnApplyToolBarVisibility(object sender, EventArgs e)
		{
			bool formHasFocus = this.FormHasFocus;
			foreach (object obj in this.xbc5b8cb591c2f262)
			{
				ToolBar toolBar = (ToolBar)obj;
				if (toolBar.Situation == ToolBarSituation.Floating)
				{
					if (formHasFocus)
					{
						((x502bf86f15e12152)toolBar.Parent).x4fc163dd620d4398();
					}
					else
					{
						((x502bf86f15e12152)toolBar.Parent).xbf87530143e7a46c();
					}
				}
			}
			Form activeForm = Form.ActiveForm;
			if (this.OwnerForm != null && activeForm != null && activeForm != this.OwnerForm && !this.OwnerForm.IsMdiChild)
			{
				if (this.x72429a840869020c != null)
				{
					this.x72429a840869020c.Deactivate -= this.OnFocusedFormDeactivate;
				}
				this.x72429a840869020c = activeForm;
				this.x72429a840869020c.Deactivate += this.OnFocusedFormDeactivate;
			}
		}

		// Token: 0x060002E5 RID: 741 RVA: 0x0000EC44 File Offset: 0x0000DC44
		private void OnFocusedFormDeactivate(object sender, EventArgs e)
		{
			this.x72429a840869020c.Deactivate -= this.OnFocusedFormDeactivate;
			this.x72429a840869020c = null;
			this.UpdateFocusVisibility();
		}

		// Token: 0x060002E6 RID: 742 RVA: 0x0000EC6C File Offset: 0x0000DC6C
		private void OnToolBarDisposed(object sender, EventArgs e)
		{
			this.RemoveToolbar((ToolBar)sender);
		}

		// Token: 0x04000112 RID: 274
		private ArrayList xbc5b8cb591c2f262;

		// Token: 0x04000113 RID: 275
		internal ArrayList xd27fa35d10494112;

		// Token: 0x04000114 RID: 276
		private MenuBar _x49a2aa22606cd919;

		// Token: 0x04000115 RID: 277
		private IToolBarRenderer x38870620fd380a6b;

		// Token: 0x04000116 RID: 278
		private Form _x9492ad63ba3e62cf;

		// Token: 0x04000117 RID: 279
		private bool _x0334f6f14b690e27 = true;

		// Token: 0x04000118 RID: 280
		private bool x791fbd83747d651b = true;

		// Token: 0x04000119 RID: 281
		private Form x72429a840869020c;

		// Token: 0x0400011A RID: 282
		private MenuActivationType xba5782505b53eac1 = MenuActivationType.DoEvents;

		// Token: 0x02000051 RID: 81
		private class x63ef418b06d30c38 : MenuButtonItem
		{
			// Token: 0x060003D6 RID: 982 RVA: 0x00013CB8 File Offset: 0x00012CB8
			public x63ef418b06d30c38(ToolBar toolbar)
			{
				this._x169279a87b6b72b2 = toolbar;
			}

			// Token: 0x170000FD RID: 253
			// (get) Token: 0x060003D7 RID: 983 RVA: 0x00013CC8 File Offset: 0x00012CC8
			public ToolBar x8c3ddcee83adfc9a
			{
				get
				{
					return this._x169279a87b6b72b2;
				}
			}

			// Token: 0x040001B8 RID: 440
			private ToolBar _x169279a87b6b72b2;
		}
	}
}
