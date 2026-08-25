using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;

namespace Divelements.SandGrid.Design
{
	// Token: 0x020000A0 RID: 160
	internal partial class xa99da2aabc9421ba : Form
	{
		// Token: 0x06000731 RID: 1841 RVA: 0x00023CBC File Offset: 0x00022CBC
		public xa99da2aabc9421ba(IServiceProvider serviceProvider, SandGrid grid)
		{
			if (serviceProvider == null)
			{
				throw new ArgumentNullException("serviceProvider");
			}
			if (grid == null)
			{
				throw new ArgumentNullException("grid");
			}
			this.xdc2614fb286b7e33 = serviceProvider;
			this.x3040c866fac95193 = grid;
			this.x85601834555fb7d5();
		}

		// Token: 0x06000733 RID: 1843 RVA: 0x00023D14 File Offset: 0x00022D14
		private void x85601834555fb7d5()
		{
			this.x16f702e557cc5142 = new Button();
			if (false)
			{
				goto IL_263;
			}
			this.x438ae8d7d28c23d1 = new Button();
			this.xf5622c25220a6c23 = new Label();
			this.x409009322855bbb9 = new RadioButton();
			this.x9001f8afc870fc4c = new Label();
			this.xc73b6c12a2688c94 = new RadioButton();
			this.x90baa23478571135 = new Label();
			this.x47f7f17f2bf7dde7 = new RadioButton();
			this.x3b9a6a473765907c = new Label();
			this.x67be9d86fe2a9906 = new RadioButton();
			this.xdc21fb076e1552c1 = new Label();
			this.xb785a96a941fe6e0 = new CheckBox();
			this.x0eef2386b776a2a3 = new Label();
			base.SuspendLayout();
			this.x16f702e557cc5142.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			if (-2 != 0)
			{
				this.x16f702e557cc5142.DialogResult = DialogResult.Cancel;
				this.x16f702e557cc5142.Location = new Point(343, 359);
				this.x16f702e557cc5142.Name = "btnCancel";
				this.x16f702e557cc5142.TabIndex = 5;
				this.x16f702e557cc5142.Text = "&Cancel";
				this.x438ae8d7d28c23d1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
				this.x438ae8d7d28c23d1.Enabled = false;
				this.x438ae8d7d28c23d1.Location = new Point(262, 359);
				this.x438ae8d7d28c23d1.Name = "btnOK";
				for (;;)
				{
					this.x438ae8d7d28c23d1.TabIndex = 4;
					if (3 == 0)
					{
						break;
					}
					this.x438ae8d7d28c23d1.Text = "&OK";
					this.x438ae8d7d28c23d1.Click += this.x1ab74ffda0bc2fb6;
					this.xf5622c25220a6c23.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
					this.xf5622c25220a6c23.Location = new Point(8, 8);
					this.xf5622c25220a6c23.Name = "label1";
					this.xf5622c25220a6c23.Size = new Size(411, 43);
					this.xf5622c25220a6c23.TabIndex = 2;
					this.xf5622c25220a6c23.Text = "This tool will set a batch of properties on the grid in order to make it behave in a manner similar to existing Windows controls. All the properties can also be set individually through the property grid.";
					this.x409009322855bbb9.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
					this.x409009322855bbb9.Location = new Point(30, 87);
					this.x409009322855bbb9.Name = "rdoListViewBehavior";
					this.x409009322855bbb9.Size = new Size(166, 17);
					this.x409009322855bbb9.TabIndex = 0;
					this.x409009322855bbb9.TabStop = true;
					this.x409009322855bbb9.Text = "ListView Behavior";
					if (false)
					{
						break;
					}
					for (;;)
					{
						this.x409009322855bbb9.CheckedChanged += this.x04f57c74b61ef4a1;
						this.x9001f8afc870fc4c.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
						this.x9001f8afc870fc4c.Location = new Point(47, 107);
						this.x9001f8afc870fc4c.Name = "label2";
						this.x9001f8afc870fc4c.Size = new Size(369, 35);
						this.x9001f8afc870fc4c.TabIndex = 4;
						this.x9001f8afc870fc4c.Text = "Row selection, row headers hidden, column headers visible, column headers sort, no gridlines";
						if (!false)
						{
							if (!false)
							{
								this.xc73b6c12a2688c94.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
								this.xc73b6c12a2688c94.Location = new Point(30, 145);
								this.xc73b6c12a2688c94.Name = "rdoTreeViewBehavior";
								this.xc73b6c12a2688c94.Size = new Size(166, 17);
								this.xc73b6c12a2688c94.TabIndex = 1;
								this.xc73b6c12a2688c94.TabStop = true;
								this.xc73b6c12a2688c94.Text = "TreeView Behavior";
								this.xc73b6c12a2688c94.CheckedChanged += this.x04f57c74b61ef4a1;
								this.x90baa23478571135.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
								this.x90baa23478571135.Location = new Point(47, 165);
								if (4 != 0)
								{
									this.x90baa23478571135.Name = "label3";
									this.x90baa23478571135.Size = new Size(369, 35);
									this.x90baa23478571135.TabIndex = 4;
									this.x90baa23478571135.Text = "Row selection, primary column only, row headers hidden, column headers hidden, no gridlines";
									this.x47f7f17f2bf7dde7.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
									this.x47f7f17f2bf7dde7.Location = new Point(30, 203);
									this.x47f7f17f2bf7dde7.Name = "rdoSpreadsheetBehavior";
									this.x47f7f17f2bf7dde7.Size = new Size(166, 17);
									this.x47f7f17f2bf7dde7.TabIndex = 2;
									goto IL_459;
								}
								IL_5B9:
								this.x47f7f17f2bf7dde7.Text = "Spreadsheet Behavior";
								if (!false)
								{
									this.x47f7f17f2bf7dde7.CheckedChanged += this.x04f57c74b61ef4a1;
									this.x3b9a6a473765907c.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
									this.x3b9a6a473765907c.Location = new Point(47, 223);
									this.x3b9a6a473765907c.Name = "label4";
									this.x3b9a6a473765907c.Size = new Size(369, 35);
									goto IL_325;
								}
								IL_459:
								this.x47f7f17f2bf7dde7.TabStop = true;
								goto IL_5B9;
							}
							break;
						}
						IL_325:
						this.x3b9a6a473765907c.TabIndex = 4;
						this.x3b9a6a473765907c.Text = "Cell selection, row headers visible, column headers visible, column headers select, gridlines";
						this.x67be9d86fe2a9906.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
						this.x67be9d86fe2a9906.Location = new Point(30, 261);
						this.x67be9d86fe2a9906.Name = "rdoDataGridViewBehavior";
						if (8 != 0)
						{
							goto IL_5C3;
						}
					}
				}
				IL_5C3:
				goto IL_263;
			}
			IL_4E:
			base.ShowInTaskbar = false;
			base.StartPosition = FormStartPosition.CenterParent;
			this.Text = "Configure Grid";
			base.ResumeLayout(false);
			return;
			IL_263:
			this.x67be9d86fe2a9906.Size = new Size(166, 17);
			this.x67be9d86fe2a9906.TabIndex = 3;
			this.x67be9d86fe2a9906.TabStop = true;
			this.x67be9d86fe2a9906.Text = "DataGridView Behavior";
			this.x67be9d86fe2a9906.CheckedChanged += this.x04f57c74b61ef4a1;
			this.xdc21fb076e1552c1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.xdc21fb076e1552c1.Location = new Point(47, 281);
			this.xdc21fb076e1552c1.Name = "label5";
			this.xdc21fb076e1552c1.Size = new Size(369, 35);
			this.xdc21fb076e1552c1.TabIndex = 4;
			this.xdc21fb076e1552c1.Text = "Cell selection, row headers visible, column headers visible, column headers sort, gridlines";
			this.xb785a96a941fe6e0.Location = new Point(50, 323);
			this.xb785a96a941fe6e0.Name = "chkAllowEditing";
			this.xb785a96a941fe6e0.Size = new Size(126, 17);
			this.xb785a96a941fe6e0.TabIndex = 6;
			this.xb785a96a941fe6e0.Text = "Allow Editing";
			this.x0eef2386b776a2a3.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.x0eef2386b776a2a3.Location = new Point(8, 56);
			this.x0eef2386b776a2a3.Name = "label6";
			this.x0eef2386b776a2a3.Size = new Size(411, 23);
			this.x0eef2386b776a2a3.TabIndex = 2;
			this.x0eef2386b776a2a3.Text = "Changing these properties will not affect any data you already have in the grid.";
			base.AcceptButton = this.x438ae8d7d28c23d1;
			this.AutoScaleBaseSize = new Size(5, 14);
			base.CancelButton = this.x16f702e557cc5142;
			base.ClientSize = new Size(430, 394);
			base.Controls.AddRange(new Control[]
			{
				this.xb785a96a941fe6e0,
				this.xdc21fb076e1552c1,
				this.x3b9a6a473765907c,
				this.x90baa23478571135,
				this.x9001f8afc870fc4c,
				this.x67be9d86fe2a9906,
				this.x47f7f17f2bf7dde7,
				this.xc73b6c12a2688c94,
				this.x409009322855bbb9,
				this.x0eef2386b776a2a3,
				this.xf5622c25220a6c23,
				this.x438ae8d7d28c23d1,
				this.x16f702e557cc5142
			});
			this.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "frmConfigureGrid";
			goto IL_4E;
		}

		// Token: 0x06000734 RID: 1844 RVA: 0x00024558 File Offset: 0x00023558
		private void x04f57c74b61ef4a1(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			this.x438ae8d7d28c23d1.Enabled = true;
		}

		// Token: 0x06000735 RID: 1845 RVA: 0x00024568 File Offset: 0x00023568
		private void x1ab74ffda0bc2fb6(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			IDesignerHost designerHost = (IDesignerHost)this.xdc2614fb286b7e33.GetService(typeof(IDesignerHost));
			for (;;)
			{
				DesignerTransaction designerTransaction = designerHost.CreateTransaction("Change Grid Behavior");
				if (this.x409009322855bbb9.Checked)
				{
					if (2147483647 == 0)
					{
						goto IL_40A;
					}
					TypeDescriptor.GetProperties(this.x3040c866fac95193)["RowHighlightType"].SetValue(this.x3040c866fac95193, RowHighlightType.Partial);
					TypeDescriptor.GetProperties(this.x3040c866fac95193)["ShowRowHeaders"].SetValue(this.x3040c866fac95193, false);
					TypeDescriptor.GetProperties(this.x3040c866fac95193)["ShowColumnHeaders"].SetValue(this.x3040c866fac95193, true);
					TypeDescriptor.GetProperties(this.x3040c866fac95193)["ColumnClickBehavior"].SetValue(this.x3040c866fac95193, ColumnClickBehavior.SortAndReorder);
					TypeDescriptor.GetProperties(this.x3040c866fac95193)["MouseEditMode"].SetValue(this.x3040c866fac95193, this.xb785a96a941fe6e0.Checked ? MouseEditMode.DelayedSingleClick : MouseEditMode.None);
					TypeDescriptor.GetProperties(this.x3040c866fac95193)["KeyboardEditMode"].SetValue(this.x3040c866fac95193, this.xb785a96a941fe6e0.Checked ? KeyboardEditMode.EditOnF2 : KeyboardEditMode.None);
					if (false)
					{
						goto IL_46;
					}
					TypeDescriptor.GetProperties(this.x3040c866fac95193)["GridLines"].SetValue(this.x3040c866fac95193, GridLinesDisplayType.None);
					TypeDescriptor.GetProperties(this.x3040c866fac95193)["ImageTextSeparation"].SetValue(this.x3040c866fac95193, 1);
					TypeDescriptor.GetProperties(this.x3040c866fac95193)["SelectionGranularity"].SetValue(this.x3040c866fac95193, SelectionGranularity.Row);
					if (false)
					{
						goto IL_B76;
					}
					TypeDescriptor.GetProperties(this.x3040c866fac95193)["ShowTreeButtons"].SetValue(this.x3040c866fac95193, false);
					TypeDescriptor.GetProperties(this.x3040c866fac95193)["AllowMultipleSelection"].SetValue(this.x3040c866fac95193, false);
					TypeDescriptor.GetProperties(this.x3040c866fac95193)["RowDragBehavior"].SetValue(this.x3040c866fac95193, RowDragBehavior.InitiateDragDrop);
					TypeDescriptor.GetProperties(this.x3040c866fac95193)["HighlightImages"].SetValue(this.x3040c866fac95193, true);
					TypeDescriptor.GetProperties(this.x3040c866fac95193)["RowEditMode"].SetValue(this.x3040c866fac95193, RowEditMode.PrimaryCell);
					TypeDescriptor.GetProperties(this.x3040c866fac95193)["StretchPrimaryGrid"].SetValue(this.x3040c866fac95193, false);
					TypeDescriptor.GetProperties(this.x3040c866fac95193)["WhitespaceClickBehavior"].SetValue(this.x3040c866fac95193, WhitespaceClickBehavior.ClearSelection);
				}
				else
				{
					if (this.xc73b6c12a2688c94.Checked)
					{
						TypeDescriptor.GetProperties(this.x3040c866fac95193)["RowHighlightType"].SetValue(this.x3040c866fac95193, RowHighlightType.PrimaryColumnOnly);
						TypeDescriptor.GetProperties(this.x3040c866fac95193)["ShowRowHeaders"].SetValue(this.x3040c866fac95193, false);
						TypeDescriptor.GetProperties(this.x3040c866fac95193)["ShowColumnHeaders"].SetValue(this.x3040c866fac95193, false);
						TypeDescriptor.GetProperties(this.x3040c866fac95193)["ColumnClickBehavior"].SetValue(this.x3040c866fac95193, ColumnClickBehavior.None);
						TypeDescriptor.GetProperties(this.x3040c866fac95193)["MouseEditMode"].SetValue(this.x3040c866fac95193, this.xb785a96a941fe6e0.Checked ? MouseEditMode.DelayedSingleClick : MouseEditMode.None);
						TypeDescriptor.GetProperties(this.x3040c866fac95193)["KeyboardEditMode"].SetValue(this.x3040c866fac95193, this.xb785a96a941fe6e0.Checked ? KeyboardEditMode.EditOnF2 : KeyboardEditMode.None);
						TypeDescriptor.GetProperties(this.x3040c866fac95193)["GridLines"].SetValue(this.x3040c866fac95193, GridLinesDisplayType.None);
						TypeDescriptor.GetProperties(this.x3040c866fac95193)["ImageTextSeparation"].SetValue(this.x3040c866fac95193, 5);
						TypeDescriptor.GetProperties(this.x3040c866fac95193)["SelectionGranularity"].SetValue(this.x3040c866fac95193, SelectionGranularity.Row);
						TypeDescriptor.GetProperties(this.x3040c866fac95193)["ShowTreeButtons"].SetValue(this.x3040c866fac95193, true);
						TypeDescriptor.GetProperties(this.x3040c866fac95193)["AllowMultipleSelection"].SetValue(this.x3040c866fac95193, false);
						TypeDescriptor.GetProperties(this.x3040c866fac95193)["RowDragBehavior"].SetValue(this.x3040c866fac95193, RowDragBehavior.InitiateDragDrop);
						TypeDescriptor.GetProperties(this.x3040c866fac95193)["HighlightImages"].SetValue(this.x3040c866fac95193, false);
						goto IL_B76;
					}
					if (this.x47f7f17f2bf7dde7.Checked)
					{
						TypeDescriptor.GetProperties(this.x3040c866fac95193)["RowHighlightType"].SetValue(this.x3040c866fac95193, RowHighlightType.Full);
						TypeDescriptor.GetProperties(this.x3040c866fac95193)["ShowRowHeaders"].SetValue(this.x3040c866fac95193, true);
						TypeDescriptor.GetProperties(this.x3040c866fac95193)["ShowColumnHeaders"].SetValue(this.x3040c866fac95193, true);
						TypeDescriptor.GetProperties(this.x3040c866fac95193)["ColumnClickBehavior"].SetValue(this.x3040c866fac95193, ColumnClickBehavior.Select);
						TypeDescriptor.GetProperties(this.x3040c866fac95193)["MouseEditMode"].SetValue(this.x3040c866fac95193, this.xb785a96a941fe6e0.Checked ? MouseEditMode.DoubleClick : MouseEditMode.None);
						TypeDescriptor.GetProperties(this.x3040c866fac95193)["KeyboardEditMode"].SetValue(this.x3040c866fac95193, this.xb785a96a941fe6e0.Checked ? KeyboardEditMode.EditOnKeystrokeOrF2 : KeyboardEditMode.None);
						TypeDescriptor.GetProperties(this.x3040c866fac95193)["GridLines"].SetValue(this.x3040c866fac95193, GridLinesDisplayType.Both);
						TypeDescriptor.GetProperties(this.x3040c866fac95193)["ImageTextSeparation"].SetValue(this.x3040c866fac95193, 3);
						TypeDescriptor.GetProperties(this.x3040c866fac95193)["SelectionGranularity"].SetValue(this.x3040c866fac95193, SelectionGranularity.Cell);
						TypeDescriptor.GetProperties(this.x3040c866fac95193)["ShowTreeButtons"].SetValue(this.x3040c866fac95193, false);
						TypeDescriptor.GetProperties(this.x3040c866fac95193)["AllowMultipleSelection"].SetValue(this.x3040c866fac95193, true);
						TypeDescriptor.GetProperties(this.x3040c866fac95193)["RowDragBehavior"].SetValue(this.x3040c866fac95193, RowDragBehavior.ExtendSelection);
						TypeDescriptor.GetProperties(this.x3040c866fac95193)["HighlightImages"].SetValue(this.x3040c866fac95193, false);
						TypeDescriptor.GetProperties(this.x3040c866fac95193)["RowEditMode"].SetValue(this.x3040c866fac95193, RowEditMode.TargetCell);
						TypeDescriptor.GetProperties(this.x3040c866fac95193)["StretchPrimaryGrid"].SetValue(this.x3040c866fac95193, false);
						TypeDescriptor.GetProperties(this.x3040c866fac95193)["WhitespaceClickBehavior"].SetValue(this.x3040c866fac95193, WhitespaceClickBehavior.ClearSelection);
					}
					else if (this.x67be9d86fe2a9906.Checked)
					{
						TypeDescriptor.GetProperties(this.x3040c866fac95193)["RowHighlightType"].SetValue(this.x3040c866fac95193, RowHighlightType.Full);
						TypeDescriptor.GetProperties(this.x3040c866fac95193)["ShowRowHeaders"].SetValue(this.x3040c866fac95193, true);
						TypeDescriptor.GetProperties(this.x3040c866fac95193)["ShowColumnHeaders"].SetValue(this.x3040c866fac95193, true);
						TypeDescriptor.GetProperties(this.x3040c866fac95193)["ColumnClickBehavior"].SetValue(this.x3040c866fac95193, ColumnClickBehavior.SortAndReorder);
						if (-2 != 0)
						{
						}
						TypeDescriptor.GetProperties(this.x3040c866fac95193)["MouseEditMode"].SetValue(this.x3040c866fac95193, this.xb785a96a941fe6e0.Checked ? MouseEditMode.DoubleClick : MouseEditMode.None);
						TypeDescriptor.GetProperties(this.x3040c866fac95193)["KeyboardEditMode"].SetValue(this.x3040c866fac95193, this.xb785a96a941fe6e0.Checked ? KeyboardEditMode.EditOnKeystrokeOrF2 : KeyboardEditMode.None);
						TypeDescriptor.GetProperties(this.x3040c866fac95193)["GridLines"].SetValue(this.x3040c866fac95193, GridLinesDisplayType.Both);
						TypeDescriptor.GetProperties(this.x3040c866fac95193)["ImageTextSeparation"].SetValue(this.x3040c866fac95193, 3);
						TypeDescriptor.GetProperties(this.x3040c866fac95193)["SelectionGranularity"].SetValue(this.x3040c866fac95193, SelectionGranularity.Cell);
						TypeDescriptor.GetProperties(this.x3040c866fac95193)["ShowTreeButtons"].SetValue(this.x3040c866fac95193, false);
						TypeDescriptor.GetProperties(this.x3040c866fac95193)["AllowMultipleSelection"].SetValue(this.x3040c866fac95193, true);
						TypeDescriptor.GetProperties(this.x3040c866fac95193)["RowDragBehavior"].SetValue(this.x3040c866fac95193, RowDragBehavior.ExtendSelection);
						TypeDescriptor.GetProperties(this.x3040c866fac95193)["HighlightImages"].SetValue(this.x3040c866fac95193, true);
						goto IL_46;
					}
				}
				IL_B8:
				designerTransaction.Commit();
				base.DialogResult = DialogResult.OK;
				if (false)
				{
					goto IL_397;
				}
				if (2 == 0)
				{
					continue;
				}
				break;
				IL_46:
				TypeDescriptor.GetProperties(this.x3040c866fac95193)["RowEditMode"].SetValue(this.x3040c866fac95193, RowEditMode.TargetCell);
				TypeDescriptor.GetProperties(this.x3040c866fac95193)["StretchPrimaryGrid"].SetValue(this.x3040c866fac95193, false);
				TypeDescriptor.GetProperties(this.x3040c866fac95193)["WhitespaceClickBehavior"].SetValue(this.x3040c866fac95193, WhitespaceClickBehavior.ClearSelection);
				goto IL_B8;
				IL_397:
				TypeDescriptor.GetProperties(this.x3040c866fac95193)["WhitespaceClickBehavior"].SetValue(this.x3040c866fac95193, WhitespaceClickBehavior.None);
				IComponentChangeService componentChangeService;
				GridColumn gridColumn;
				if (this.x3040c866fac95193.Columns.Count == 0)
				{
					componentChangeService = (IComponentChangeService)this.xdc2614fb286b7e33.GetService(typeof(IComponentChangeService));
					gridColumn = (GridColumn)designerHost.CreateComponent(typeof(GridColumn));
					gridColumn.AutoSize = ColumnAutoSizeMode.Contents;
					goto IL_40A;
				}
				goto IL_B8;
				IL_B76:
				if (!false)
				{
					TypeDescriptor.GetProperties(this.x3040c866fac95193)["RowEditMode"].SetValue(this.x3040c866fac95193, RowEditMode.PrimaryCell);
					TypeDescriptor.GetProperties(this.x3040c866fac95193)["StretchPrimaryGrid"].SetValue(this.x3040c866fac95193, true);
				}
				if (255 == 0)
				{
					break;
				}
				goto IL_397;
				IL_40A:
				componentChangeService.OnComponentChanging(this.x3040c866fac95193, TypeDescriptor.GetProperties(this.x3040c866fac95193)["Columns"]);
				this.x3040c866fac95193.Columns.Add(gridColumn);
				componentChangeService.OnComponentChanged(this.x3040c866fac95193, TypeDescriptor.GetProperties(this.x3040c866fac95193)["Columns"], null, null);
				goto IL_B8;
			}
		}

		// Token: 0x040002C1 RID: 705
		private IServiceProvider xdc2614fb286b7e33;

		// Token: 0x040002C2 RID: 706
		private Label x0eef2386b776a2a3;

		// Token: 0x040002C3 RID: 707
		private SandGrid x3040c866fac95193;

		// Token: 0x040002C5 RID: 709
		private Button x16f702e557cc5142;

		// Token: 0x040002C6 RID: 710
		private Button x438ae8d7d28c23d1;

		// Token: 0x040002C7 RID: 711
		private Label xf5622c25220a6c23;

		// Token: 0x040002C8 RID: 712
		private RadioButton x409009322855bbb9;

		// Token: 0x040002C9 RID: 713
		private Label x9001f8afc870fc4c;

		// Token: 0x040002CA RID: 714
		private RadioButton xc73b6c12a2688c94;

		// Token: 0x040002CB RID: 715
		private Label x90baa23478571135;

		// Token: 0x040002CC RID: 716
		private RadioButton x47f7f17f2bf7dde7;

		// Token: 0x040002CD RID: 717
		private Label x3b9a6a473765907c;

		// Token: 0x040002CE RID: 718
		private RadioButton x67be9d86fe2a9906;

		// Token: 0x040002CF RID: 719
		private Label xdc21fb076e1552c1;

		// Token: 0x040002D0 RID: 720
		private CheckBox xb785a96a941fe6e0;
	}
}
