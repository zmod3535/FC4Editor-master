using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.Win32;

namespace TD.SandBar
{
	// Token: 0x0200005D RID: 93
	[TypeConverter(typeof(x01480672935e1b10))]
	public abstract class OfficeRendererBase
	{
		// Token: 0x1400000E RID: 14
		// (add) Token: 0x060004A6 RID: 1190 RVA: 0x0001A8EC File Offset: 0x000198EC
		// (remove) Token: 0x060004A7 RID: 1191 RVA: 0x0001A908 File Offset: 0x00019908
		public event EventHandler RedrawRequired
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.xb8541309ff97daa7 = (EventHandler)Delegate.Combine(this.xb8541309ff97daa7, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.xb8541309ff97daa7 = (EventHandler)Delegate.Remove(this.xb8541309ff97daa7, value);
			}
		}

		// Token: 0x060004A8 RID: 1192 RVA: 0x0001A924 File Offset: 0x00019924
		protected OfficeRendererBase()
		{
			this.x1d7a370d81f69461 = new ArrayList();
			SystemEvents.UserPreferenceChanged += this.x985016783c040310;
		}

		// Token: 0x060004A9 RID: 1193 RVA: 0x0001A950 File Offset: 0x00019950
		public void AddConsumer(object consumer)
		{
			this.x1d7a370d81f69461.Add(consumer);
		}

		// Token: 0x060004AA RID: 1194 RVA: 0x0001A960 File Offset: 0x00019960
		public void RemoveConsumer(object consumer)
		{
			this.x1d7a370d81f69461.Remove(consumer);
			if (this.ConsumerCount == 0 && this.AutoDispose)
			{
				this.Dispose();
			}
		}

		// Token: 0x17000121 RID: 289
		// (get) Token: 0x060004AB RID: 1195 RVA: 0x0001A984 File Offset: 0x00019984
		public int ConsumerCount
		{
			get
			{
				return this.x1d7a370d81f69461.Count;
			}
		}

		// Token: 0x17000122 RID: 290
		// (get) Token: 0x060004AC RID: 1196 RVA: 0x0001A994 File Offset: 0x00019994
		// (set) Token: 0x060004AD RID: 1197 RVA: 0x0001A99C File Offset: 0x0001999C
		[Description("Indicates whether the renderer is automatically disposed when unassigned from the last consumer.")]
		[Browsable(false)]
		[DefaultValue(true)]
		[Category("Behavior")]
		public bool AutoDispose
		{
			get
			{
				return this.x41346fa6901fae28;
			}
			set
			{
				this.x41346fa6901fae28 = value;
			}
		}

		// Token: 0x060004AE RID: 1198 RVA: 0x0001A9A8 File Offset: 0x000199A8
		private void x985016783c040310(object xe0292b9ed559da7d, UserPreferenceChangedEventArgs xfbf34718e704c6bc)
		{
			if (xfbf34718e704c6bc.Category == UserPreferenceCategory.Color && !this._x106e6f99e65ccd35)
			{
				this.CalculateBaseColors();
			}
		}

		// Token: 0x17000123 RID: 291
		// (get) Token: 0x060004AF RID: 1199 RVA: 0x0001A9C4 File Offset: 0x000199C4
		// (set) Token: 0x060004B0 RID: 1200 RVA: 0x0001A9CC File Offset: 0x000199CC
		public bool CustomColors
		{
			get
			{
				return this._x106e6f99e65ccd35;
			}
			set
			{
				this._x106e6f99e65ccd35 = value;
				if (!this._x106e6f99e65ccd35)
				{
					this.CalculateBaseColors();
				}
				this.OnRedrawRequired();
			}
		}

		// Token: 0x060004B1 RID: 1201 RVA: 0x0001A9EC File Offset: 0x000199EC
		protected virtual void CalculateBaseColors()
		{
		}

		// Token: 0x060004B2 RID: 1202 RVA: 0x0001A9F0 File Offset: 0x000199F0
		protected virtual void OnRedrawRequired()
		{
			if (this.xb8541309ff97daa7 != null)
			{
				this.xb8541309ff97daa7(this, EventArgs.Empty);
			}
		}

		// Token: 0x060004B3 RID: 1203 RVA: 0x0001AA0C File Offset: 0x00019A0C
		public virtual void Dispose()
		{
			SystemEvents.UserPreferenceChanged -= this.x985016783c040310;
		}

		// Token: 0x060004B4 RID: 1204 RVA: 0x0001AA20 File Offset: 0x00019A20
		internal void xc64a3464af8e94fb(Graphics x41347a961b838962, Rectangle xda73fcb97c77d998, ToolBarGlyphType x383e1b37456a9d37, Color x6c50a99faab7d741)
		{
			using (Pen pen = new Pen(x6c50a99faab7d741))
			{
				int num = xda73fcb97c77d998.Left + xda73fcb97c77d998.Width / 2;
				int num2;
				for (;;)
				{
					num2 = xda73fcb97c77d998.Top + xda73fcb97c77d998.Height / 2;
					switch (x383e1b37456a9d37)
					{
					case ToolBarGlyphType.Close:
						goto IL_180;
					case ToolBarGlyphType.Minimize:
						goto IL_1CE;
					case ToolBarGlyphType.Restore:
						goto IL_24;
					case ToolBarGlyphType.Actions:
						x41347a961b838962.DrawLine(pen, num - 4, num2 - 2, num + 4, num2 - 2);
						do
						{
							x41347a961b838962.DrawLine(pen, num - 3, num2 - 1, num + 3, num2 - 1);
							x41347a961b838962.DrawLine(pen, num - 2, num2, num + 2, num2);
							x41347a961b838962.DrawLine(pen, num - 1, num2 + 1, num + 1, num2 + 1);
							x41347a961b838962.DrawLine(pen, num, num2 + 2, num, num2);
						}
						while ((uint)num < 0U);
						if (4 == 0)
						{
							continue;
						}
						break;
					}
					goto Block_4;
				}
				IL_24:
				x41347a961b838962.DrawLine(pen, num - 4, num2 + 4, num + 1, num2 + 4);
				x41347a961b838962.DrawLine(pen, num - 4, num2 + 4, num - 4, num2 - 1);
				x41347a961b838962.DrawLine(pen, num + 1, num2 + 4, num + 1, num2 - 1);
				x41347a961b838962.DrawLine(pen, num - 4, num2 - 1, num + 1, num2 - 1);
				x41347a961b838962.DrawLine(pen, num - 4, num2, num + 1, num2);
				x41347a961b838962.DrawLine(pen, num - 2, num2 - 1, num - 2, num2 - 4);
				x41347a961b838962.DrawLine(pen, num - 2, num2 - 4, num + 3, num2 - 4);
				x41347a961b838962.DrawLine(pen, num - 2, num2 - 3, num + 3, num2 - 3);
				x41347a961b838962.DrawLine(pen, num + 3, num2 - 3, num + 3, num2 + 1);
				x41347a961b838962.DrawLine(pen, num + 3, num2 + 1, num + 1, num2 + 1);
				Block_4:
				goto IL_1F9;
				IL_180:
				x41347a961b838962.DrawLine(pen, num - 3, num2 - 3, num + 3, num2 + 3);
				x41347a961b838962.DrawLine(pen, num - 2, num2 - 3, num + 4, num2 + 3);
				x41347a961b838962.DrawLine(pen, num + 3, num2 - 3, num - 3, num2 + 3);
				x41347a961b838962.DrawLine(pen, num + 4, num2 - 3, num - 2, num2 + 3);
				goto IL_1F9;
				IL_1CE:
				x41347a961b838962.DrawLine(pen, num - 3, num2 + 3, num + 2, num2 + 3);
				x41347a961b838962.DrawLine(pen, num - 3, num2 + 4, num + 2, num2 + 4);
				IL_1F9:;
			}
		}

		// Token: 0x060004B5 RID: 1205
		public abstract void DrawButtonHighlight(Graphics graphics, Rectangle bounds, DrawItemState state, bool dropDown);

		// Token: 0x060004B6 RID: 1206
		public abstract void DrawImageCore(Image image, Graphics graphics, DrawItemState state, Rectangle bounds);

		// Token: 0x060004B7 RID: 1207
		public abstract void DrawImageCore(ImageList imageList, int imageIndex, Graphics graphics, DrawItemState state, Rectangle bounds);

		// Token: 0x060004B8 RID: 1208
		public abstract void DrawIconCore(Icon icon, Graphics graphics, DrawItemState state, Rectangle bounds);

		// Token: 0x17000124 RID: 292
		// (get) Token: 0x060004B9 RID: 1209
		// (set) Token: 0x060004BA RID: 1210
		public abstract TextFormatFlags ItemTextFormatFlags { get; set; }

		// Token: 0x060004BB RID: 1211 RVA: 0x0001AC50 File Offset: 0x00019C50
		protected virtual Color GetAppropriateForeColor(ToolbarItemBase item, DrawItemState state)
		{
			return item.ForeColor;
		}

		// Token: 0x060004BC RID: 1212 RVA: 0x0001AC58 File Offset: 0x00019C58
		public virtual void DrawToolBarItem(ToolbarItemBase item, Graphics graphics, Font font, bool vertical, DrawItemState state, ToolBarTextAlign textAlign)
		{
			if (!(item is TopLevelMenuItemBase))
			{
				goto IL_138;
			}
			if (((vertical ? 1U : 0U) & 0U) == 0U)
			{
				goto IL_11C;
			}
			IL_22:
			this.ItemTextFormatFlags &= ~TextFormatFlags.HorizontalCenter;
			IL_31:
			if (!(item is ImageItemBase) || !(((ImageItemBase)item).xfe4205d5dd815113 != Rectangle.Empty))
			{
				goto IL_D2;
			}
			IL_56:
			ImageItemBase imageItemBase = (ImageItemBase)item;
			if (imageItemBase.Icon != null)
			{
				try
				{
					using (Icon icon = new Icon(imageItemBase.Icon, imageItemBase.IconSize))
					{
						this.DrawIconCore(icon, graphics, state, imageItemBase.xfe4205d5dd815113);
					}
					goto IL_D2;
				}
				catch
				{
					goto IL_D2;
				}
			}
			if (imageItemBase.Image != null)
			{
				this.DrawImageCore(imageItemBase.Image, graphics, state, imageItemBase.xfe4205d5dd815113);
			}
			else
			{
				this.DrawImageCore(imageItemBase.ImageList, imageItemBase.ImageIndex, graphics, state, imageItemBase.xfe4205d5dd815113);
			}
			IL_D2:
			if (item is ButtonItemBase)
			{
				this.DrawButtonItem((ButtonItemBase)item, graphics, font, vertical, state, textAlign);
				return;
			}
			if (!(item is StatusBarItem))
			{
				return;
			}
			this.DrawStatusBarItem((StatusBarItem)item, graphics, font, vertical, state);
			if (false)
			{
				goto IL_56;
			}
			if (4 != 0)
			{
				return;
			}
			IL_11C:
			if (((TopLevelMenuItemBase)item).x785370fd71860ecc)
			{
				this.DrawOpenDropDownItem(graphics, (TopLevelMenuItemBase)item);
				goto IL_192;
			}
			IL_138:
			if (item is ControlContainerItem || item is StatusBarItem)
			{
				if ((state & DrawItemState.HotLight) != DrawItemState.HotLight)
				{
					goto IL_192;
				}
				using (Pen pen = new Pen(SystemColors.ControlText, 2f))
				{
					graphics.DrawRectangle(pen, item.ButtonBounds);
					goto IL_192;
				}
			}
			this.DrawButtonHighlight(graphics, item.ButtonBounds, state, item is DropDownMenuItem);
			IL_192:
			if (item.Text.Length == 0)
			{
				goto IL_31;
			}
			Color appropriateForeColor = this.GetAppropriateForeColor(item, state);
			if (textAlign == ToolBarTextAlign.Underneath && item is ImageItemBase)
			{
				this.ItemTextFormatFlags |= TextFormatFlags.HorizontalCenter;
			}
			this.DrawText(item.Text, graphics, item.Font, appropriateForeColor, state, item.TextBounds, this.ItemTextFormatFlags, vertical);
			if (!false)
			{
				goto IL_22;
			}
		}

		// Token: 0x060004BD RID: 1213
		protected abstract void DrawOpenDropDownItem(Graphics graphics, TopLevelMenuItemBase item);

		// Token: 0x060004BE RID: 1214
		protected internal abstract void DrawButtonItem(ButtonItemBase item, Graphics graphics, Font font, bool vertical, DrawItemState state, ToolBarTextAlign textAlign);

		// Token: 0x060004BF RID: 1215
		protected internal abstract void DrawStatusBarItem(StatusBarItem item, Graphics graphics, Font font, bool vertical, DrawItemState state);

		// Token: 0x060004C0 RID: 1216 RVA: 0x0001AEA4 File Offset: 0x00019EA4
		protected void DrawText(string text, Graphics graphics, Font font, Color color, DrawItemState state, Rectangle bounds, TextFormatFlags textFormat, bool vertical)
		{
			if (vertical)
			{
				using (Bitmap bitmap = new Bitmap(bounds.Height, bounds.Width, PixelFormat.Format32bppPArgb))
				{
					using (Graphics graphics2 = Graphics.FromImage(bitmap))
					{
						graphics2.TextRenderingHint = TextRenderingHint.AntiAlias;
						this.DrawTextCore(text, graphics2, font, color, state, new Rectangle(0, 0, bounds.Height, bounds.Width), textFormat);
					}
					bitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);
					graphics.DrawImage(bitmap, bounds);
					return;
				}
			}
			this.DrawTextCore(text, graphics, font, color, state, bounds, textFormat);
		}

		// Token: 0x060004C1 RID: 1217
		protected abstract void DrawTextCore(string text, Graphics graphics, Font font, Color color, DrawItemState state, Rectangle bounds, TextFormatFlags textFormat);

		// Token: 0x060004C2 RID: 1218
		public abstract void DrawComboBox(ComboBox comboBox, Graphics graphics, Rectangle bounds, DrawItemState state, bool rightToLeft);

		// Token: 0x17000125 RID: 293
		// (get) Token: 0x060004C3 RID: 1219
		public abstract Color ShadowColor { get; }

		// Token: 0x060004C4 RID: 1220
		public abstract void DrawMenuBackground(Graphics graphics, Rectangle bounds, int marginWidth, int breakOffset, int breakSize, MenuProjection menuDirection, bool rightToLeft, bool rightAligned);

		// Token: 0x060004C5 RID: 1221
		public abstract void DrawMenuItem(Graphics graphics, MenuButtonItem item, IPopupMenuHost host, int marginWidth, DrawItemState state, bool drawSpecial);

		// Token: 0x060004C6 RID: 1222
		public abstract void DrawMenuSeparator(Graphics graphics, Rectangle bounds, int marginWidth, bool rightToLeft);

		// Token: 0x060004C7 RID: 1223
		public abstract void DrawMenuActionsButton(Graphics graphics, Rectangle bounds, int marginWidth, DrawItemState state, bool designMode);

		// Token: 0x17000126 RID: 294
		// (get) Token: 0x060004C8 RID: 1224
		public abstract TextFormatFlags MenuTextFormatFlags { get; }

		// Token: 0x060004C9 RID: 1225
		public abstract void DrawContainerBarClientBackground(Graphics graphics, Rectangle bounds);

		// Token: 0x060004CA RID: 1226
		public abstract void DrawContainerBarText(string text, Graphics graphics, Font font, Rectangle bounds);

		// Token: 0x060004CB RID: 1227
		public abstract void DrawContainerBarBackground(ContainerBar containerBar, Graphics graphics, Rectangle bounds, Rectangle clientBounds);

		// Token: 0x060004CC RID: 1228
		public abstract void LayoutContainerBar(Rectangle bounds, Size toolbarSize, out Rectangle titlebarBounds, out Rectangle toolbarBounds, out Rectangle clientBounds, out Rectangle gripperBounds);

		// Token: 0x060004CD RID: 1229
		public abstract void DrawContainerBarTitleBarBackground(Graphics graphics, Rectangle bounds, bool active);

		// Token: 0x060004CE RID: 1230
		public abstract void DrawContainerBarToolBarBackground(Graphics graphics, Rectangle bounds);

		// Token: 0x04000207 RID: 519
		private bool _x106e6f99e65ccd35;

		// Token: 0x04000208 RID: 520
		private ArrayList x1d7a370d81f69461;

		// Token: 0x04000209 RID: 521
		private bool x41346fa6901fae28 = true;

		// Token: 0x0400020A RID: 522
		private EventHandler xb8541309ff97daa7;
	}
}
