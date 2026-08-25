using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using TD.SandDock.Rendering;

namespace TD.SandDock.Design
{
	// Token: 0x0200000E RID: 14
	internal class DockControlDesigner : ParentControlDesigner
	{
		// Token: 0x17000065 RID: 101
		// (get) Token: 0x06000197 RID: 407 RVA: 0x0000E740 File Offset: 0x0000D740
		public override SelectionRules SelectionRules
		{
			get
			{
				return SelectionRules.None;
			}
		}

		// Token: 0x06000198 RID: 408 RVA: 0x0000E744 File Offset: 0x0000D744
		public override void Initialize(IComponent component)
		{
			base.Initialize(component);
			for (;;)
			{
				IL_D7:
				if (false || !(component is DockControl))
				{
					SandDockLanguage.ShowCachedAssemblyError(component.GetType().Assembly, base.GetType().Assembly);
				}
				this.x4cd3df9bd5e139a3 = (IComponentChangeService)this.GetService(typeof(IComponentChangeService));
				if (false)
				{
					goto IL_120;
				}
				IL_70:
				this.xff9c60b45aa37b1e = (IDesignerHost)this.GetService(typeof(IDesignerHost));
				this.x77da34c6f08140f2 = (ISelectionService)this.GetService(typeof(ISelectionService));
				this.xdeac46e41e0fbcf5 = (DockControl)component;
				this.xdeac46e41e0fbcf5.x81444a37d39a0e4a();
				this.x77da34c6f08140f2.SelectionChanged += this.x6179d221e3fa4b20;
				if (false)
				{
					continue;
				}
				IL_120:
				this.xdeac46e41e0fbcf5.ControlAdded += this.x5ba88706ad55272f;
				this.xdeac46e41e0fbcf5.ControlRemoved += this.x5ba88706ad55272f;
				if (!false)
				{
					while (this.xdeac46e41e0fbcf5.Collapsed)
					{
						this.Collapsed = true;
						if (!false)
						{
							this.xdeac46e41e0fbcf5.Collapsed = false;
							if (!false)
							{
								break;
							}
							if (false)
							{
								goto IL_70;
							}
							goto IL_D7;
						}
					}
					break;
				}
				goto IL_70;
			}
		}

		// Token: 0x06000199 RID: 409 RVA: 0x0000E878 File Offset: 0x0000D878
		protected override void Dispose(bool disposing)
		{
			this.xdeac46e41e0fbcf5.ControlAdded -= this.x5ba88706ad55272f;
			this.xdeac46e41e0fbcf5.ControlRemoved -= this.x5ba88706ad55272f;
			this.x77da34c6f08140f2.SelectionChanged -= this.x6179d221e3fa4b20;
			base.Dispose(disposing);
		}

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x0600019A RID: 410 RVA: 0x0000E8D4 File Offset: 0x0000D8D4
		// (set) Token: 0x0600019B RID: 411 RVA: 0x0000E8EC File Offset: 0x0000D8EC
		public bool Collapsed
		{
			get
			{
				return (bool)base.ShadowProperties["Collapsed"];
			}
			set
			{
				base.ShadowProperties["Collapsed"] = value;
				bool flag = (value ? 1U : 0U) - (value ? 1U : 0U) < 0U;
				if (!flag)
				{
					while (this.xdeac46e41e0fbcf5.LayoutSystem != null)
					{
						if (!DockControlDesigner.xb070ba46e7c7d3b6)
						{
							DockControlDesigner.xb070ba46e7c7d3b6 = true;
							try
							{
								foreach (object obj in this.xdeac46e41e0fbcf5.LayoutSystem.Controls)
								{
									DockControl dockControl = (DockControl)obj;
									do
									{
										if (dockControl == this.xdeac46e41e0fbcf5)
										{
											flag = (((value ? 1U : 0U) & 0U) == 0U);
											if (flag)
											{
												break;
											}
										}
										else
										{
											TypeDescriptor.GetProperties(dockControl)["Collapsed"].SetValue(dockControl, value);
										}
									}
									while ((value ? 1U : 0U) - (value ? 1U : 0U) < 0U);
								}
							}
							finally
							{
								DockControlDesigner.xb070ba46e7c7d3b6 = false;
							}
							break;
						}
						flag = ((value ? 1U : 0U) + (value ? 1U : 0U) > uint.MaxValue);
						if (flag)
						{
							break;
						}
						flag = ((value ? 1U : 0U) - (value ? 1U : 0U) < 0U);
						if (!flag)
						{
							break;
						}
					}
				}
			}
		}

		// Token: 0x0600019C RID: 412 RVA: 0x0000EA64 File Offset: 0x0000DA64
		protected override void PreFilterProperties(IDictionary properties)
		{
			base.PreFilterProperties(properties);
			string[] array = new string[]
			{
				"Collapsed"
			};
			string[] array2 = array;
			int i = 0;
			while (i < array2.Length)
			{
				string key = array2[i];
				if (!false)
				{
					goto IL_22;
				}
				IL_2F:
				PropertyDescriptor propertyDescriptor;
				if (((uint)i | 2U) != 0U)
				{
					if (propertyDescriptor != null)
					{
						properties[key] = TypeDescriptor.CreateProperty(typeof(DockControlDesigner), propertyDescriptor, new Attribute[0]);
					}
					i++;
					continue;
				}
				IL_22:
				propertyDescriptor = (PropertyDescriptor)properties[key];
				goto IL_2F;
			}
		}

		// Token: 0x0600019D RID: 413 RVA: 0x0000EB04 File Offset: 0x0000DB04
		private void x6179d221e3fa4b20(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			bool componentSelected = this.x77da34c6f08140f2.GetComponentSelected(base.Component);
			if (componentSelected != this.x9f93ebd2ca5601a2)
			{
				this.x9f93ebd2ca5601a2 = componentSelected;
				((DockControl)base.Component).LayoutSystem.xd541e2fc281b554b();
			}
		}

		// Token: 0x0600019E RID: 414 RVA: 0x0000EB48 File Offset: 0x0000DB48
		protected override void OnPaintAdornments(PaintEventArgs pe)
		{
			base.OnPaintAdornments(pe);
			if (!false)
			{
				if (2147483647 != 0)
				{
					goto IL_CE;
				}
				if (2 != 0)
				{
					goto IL_72;
				}
				goto IL_89;
			}
			IL_0D:
			using (Pen pen = new Pen(SystemColors.ControlDark))
			{
				pen.DashStyle = DashStyle.Dot;
				Rectangle clientRectangle = this.xdeac46e41e0fbcf5.ClientRectangle;
				clientRectangle.Width--;
				clientRectangle.Height--;
				pe.Graphics.DrawRectangle(pen, clientRectangle);
				return;
			}
			IL_72:
			Rectangle clientRectangle2 = this.xdeac46e41e0fbcf5.ClientRectangle;
			clientRectangle2.Inflate(-10, -10);
			IL_89:
			using (Font font = new Font(this.xdeac46e41e0fbcf5.Font.Name, 6.75f))
			{
				TextFormatFlags flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak;
				TextRenderer.DrawText(pe.Graphics, "To redock windows, click and drag their tabs or titlebars to other locations on your form.", font, clientRectangle2, SystemColors.ControlDarkDark, flags);
				goto IL_E0;
			}
			IL_CE:
			if (this.xdeac46e41e0fbcf5.Controls.Count == 0)
			{
				goto IL_72;
			}
			IL_E0:
			if (this.xdeac46e41e0fbcf5.BorderStyle == TD.SandDock.Rendering.BorderStyle.None)
			{
				goto IL_0D;
			}
		}

		// Token: 0x0600019F RID: 415 RVA: 0x0000EC94 File Offset: 0x0000DC94
		private void x5ba88706ad55272f(object xe0292b9ed559da7d, ControlEventArgs xfbf34718e704c6bc)
		{
			if (this.xdeac46e41e0fbcf5.Controls.Count == 0 || this.xdeac46e41e0fbcf5.Controls.Count == 1)
			{
				this.xdeac46e41e0fbcf5.Invalidate();
			}
		}

		// Token: 0x0400006E RID: 110
		private static bool xb070ba46e7c7d3b6;

		// Token: 0x0400006F RID: 111
		private DockControl xdeac46e41e0fbcf5;

		// Token: 0x04000070 RID: 112
		private bool x9f93ebd2ca5601a2;

		// Token: 0x04000071 RID: 113
		private IComponentChangeService x4cd3df9bd5e139a3;

		// Token: 0x04000072 RID: 114
		private IDesignerHost xff9c60b45aa37b1e;

		// Token: 0x04000073 RID: 115
		private ISelectionService x77da34c6f08140f2;
	}
}
