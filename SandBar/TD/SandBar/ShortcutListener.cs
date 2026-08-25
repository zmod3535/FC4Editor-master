using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace TD.SandBar
{
	// Token: 0x02000055 RID: 85
	public class ShortcutListener : IDisposable, IMessageFilter
	{
		// Token: 0x1400000D RID: 13
		// (add) Token: 0x060003EB RID: 1003 RVA: 0x00014060 File Offset: 0x00013060
		// (remove) Token: 0x060003EC RID: 1004 RVA: 0x0001407C File Offset: 0x0001307C
		public event SecondaryShortcutEventHandler SecondaryShortcutAction
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.xcee5f6ae9f65956a = (SecondaryShortcutEventHandler)Delegate.Combine(this.xcee5f6ae9f65956a, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.xcee5f6ae9f65956a = (SecondaryShortcutEventHandler)Delegate.Remove(this.xcee5f6ae9f65956a, value);
			}
		}

		// Token: 0x060003ED RID: 1005 RVA: 0x00014098 File Offset: 0x00013098
		public ShortcutListener()
		{
			this.x80d02e0fbe15cd1d = new Hashtable();
		}

		// Token: 0x060003EE RID: 1006 RVA: 0x000140AC File Offset: 0x000130AC
		protected virtual void OnSecondaryShortcutAction(SecondaryShortcutEventArgs e)
		{
			if (this.xcee5f6ae9f65956a != null)
			{
				this.xcee5f6ae9f65956a(this, e);
			}
		}

		// Token: 0x170000FF RID: 255
		// (get) Token: 0x060003EF RID: 1007 RVA: 0x000140C4 File Offset: 0x000130C4
		// (set) Token: 0x060003F0 RID: 1008 RVA: 0x000140CC File Offset: 0x000130CC
		public Form OwnerForm
		{
			get
			{
				return this.x9492ad63ba3e62cf;
			}
			set
			{
				this.x9492ad63ba3e62cf = value;
			}
		}

		// Token: 0x17000100 RID: 256
		// (get) Token: 0x060003F1 RID: 1009 RVA: 0x000140D8 File Offset: 0x000130D8
		// (set) Token: 0x060003F2 RID: 1010 RVA: 0x000140E0 File Offset: 0x000130E0
		public bool Listening
		{
			get
			{
				return this.xb377eb567d39789a;
			}
			set
			{
				if (value && !this.xb377eb567d39789a)
				{
					Application.AddMessageFilter(this);
				}
				else if (!value && this.xb377eb567d39789a)
				{
					Application.RemoveMessageFilter(this);
				}
				this.xb377eb567d39789a = value;
			}
		}

		// Token: 0x060003F3 RID: 1011 RVA: 0x00014110 File Offset: 0x00013110
		public void Dispose()
		{
			this.Listening = false;
			this.x80d02e0fbe15cd1d.Clear();
		}

		// Token: 0x060003F4 RID: 1012 RVA: 0x00014124 File Offset: 0x00013124
		public void UpdateAcceleratorTable(TopLevelMenuItemBase[] menus)
		{
			this.x80d02e0fbe15cd1d.Clear();
			foreach (TopLevelMenuItemBase xbad297e497c37b6c in menus)
			{
				this.x9753ecdb39b2e365(xbad297e497c37b6c);
			}
		}

		// Token: 0x060003F5 RID: 1013 RVA: 0x00014158 File Offset: 0x00013158
		public void UpdateAcceleratorTable(ToolBar toolbar)
		{
			this.x80d02e0fbe15cd1d.Clear();
			foreach (object obj in toolbar.Items)
			{
				ToolbarItemBase toolbarItemBase = (ToolbarItemBase)obj;
				if (toolbarItemBase is TopLevelMenuItemBase)
				{
					this.x9753ecdb39b2e365((MenuItemBase)toolbarItemBase);
				}
			}
		}

		// Token: 0x060003F6 RID: 1014 RVA: 0x000141D8 File Offset: 0x000131D8
		private char xd5e5c9e826262df9(string xf6987a1745781d6f)
		{
			int length = xf6987a1745781d6f.Length;
			for (int i = 0; i < length; i++)
			{
				if (xf6987a1745781d6f[i] == '&' && i + 1 < length && xf6987a1745781d6f[i + 1] != '&')
				{
					return char.ToUpper(xf6987a1745781d6f[i + 1]);
				}
			}
			return '\0';
		}

		// Token: 0x060003F7 RID: 1015 RVA: 0x00014228 File Offset: 0x00013228
		private void x9753ecdb39b2e365(MenuItemBase xbad297e497c37b6c)
		{
			foreach (object obj in xbad297e497c37b6c.Items)
			{
				MenuButtonItem menuButtonItem = (MenuButtonItem)obj;
				if (menuButtonItem.PrimaryShortcut != Keys.None)
				{
					int primaryShortcut = (int)menuButtonItem.PrimaryShortcut;
					if (!this.x80d02e0fbe15cd1d.Contains(primaryShortcut))
					{
						this.x80d02e0fbe15cd1d.Add(primaryShortcut, menuButtonItem);
					}
					else if (this.x80d02e0fbe15cd1d[primaryShortcut] is ArrayList)
					{
						((ArrayList)this.x80d02e0fbe15cd1d[primaryShortcut]).Add(menuButtonItem);
					}
					else
					{
						MenuButtonItem value = (MenuButtonItem)this.x80d02e0fbe15cd1d[primaryShortcut];
						ArrayList arrayList = new ArrayList();
						arrayList.Add(value);
						arrayList.Add(menuButtonItem);
						this.x80d02e0fbe15cd1d[primaryShortcut] = arrayList;
					}
				}
				if (menuButtonItem.HasChildren)
				{
					this.x9753ecdb39b2e365(menuButtonItem);
				}
			}
		}

		// Token: 0x17000101 RID: 257
		// (get) Token: 0x060003F8 RID: 1016 RVA: 0x00014354 File Offset: 0x00013354
		protected bool IsAwaitingSecondaryShortcut
		{
			get
			{
				return this.x5297af1a9247c00b != 0;
			}
		}

		// Token: 0x060003F9 RID: 1017 RVA: 0x00014364 File Offset: 0x00013364
		public MenuItemBase[] GetItemsMatchingShortcut(Keys keys)
		{
			MenuItemBase[] array;
			if (this.x80d02e0fbe15cd1d[(int)keys] is ArrayList)
			{
				ArrayList arrayList = (ArrayList)this.x80d02e0fbe15cd1d[(int)keys];
				array = new MenuItemBase[arrayList.Count];
				arrayList.CopyTo(array);
			}
			else
			{
				array = new MenuItemBase[]
				{
					(MenuItemBase)this.x80d02e0fbe15cd1d[(int)keys]
				};
			}
			return array;
		}

		// Token: 0x060003FA RID: 1018 RVA: 0x000143DC File Offset: 0x000133DC
		public bool ShortcutActivated(Keys keys, bool primary)
		{
			int num = (int)(primary ? keys : ((Keys)this.x5297af1a9247c00b));
			if (!this.x80d02e0fbe15cd1d.Contains(num))
			{
				return false;
			}
			MenuItemBase[] itemsMatchingShortcut = this.GetItemsMatchingShortcut((Keys)num);
			if (itemsMatchingShortcut.Length == 1 && itemsMatchingShortcut[0] is TopLevelMenuItemBase)
			{
				TopLevelMenuItemBase topLevelMenuItemBase = (TopLevelMenuItemBase)itemsMatchingShortcut[0];
				if (topLevelMenuItemBase.ToolBar.Enabled && topLevelMenuItemBase.ToolBar.Visible && topLevelMenuItemBase.Enabled && topLevelMenuItemBase.Visible)
				{
					topLevelMenuItemBase.Show(true);
				}
				return true;
			}
			MenuItemBase[] array;
			if (!primary)
			{
				array = itemsMatchingShortcut;
			}
			else
			{
				int num2 = 0;
				MenuButtonItem menuButtonItem = null;
				bool flag = false;
				foreach (MenuButtonItem menuButtonItem2 in itemsMatchingShortcut)
				{
					if (menuButtonItem2.x54994c015fecc727())
					{
						menuButtonItem = menuButtonItem2;
						num2++;
						if (menuButtonItem2.SecondaryShortcut != Keys.None)
						{
							flag = true;
						}
					}
				}
				if (num2 == 1 && !flag)
				{
					menuButtonItem.OnActivate();
					return true;
				}
				if (num2 > 0 && !flag)
				{
					menuButtonItem.OnActivate();
					return true;
				}
				if (num2 > 0)
				{
					if ((uint)num < 0U)
					{
						goto IL_16E;
					}
					if (flag)
					{
						this.x5297af1a9247c00b = (int)keys;
						this.OnSecondaryShortcutAction(new SecondaryShortcutEventArgs(keys));
						return true;
					}
				}
				return false;
			}
			IL_16E:
			foreach (MenuButtonItem menuButtonItem3 in array)
			{
				if (menuButtonItem3.SecondaryShortcut == keys && menuButtonItem3.x54994c015fecc727())
				{
					this.OnSecondaryShortcutAction(new SecondaryShortcutEventArgs((Keys)this.x5297af1a9247c00b, keys, menuButtonItem3));
					menuButtonItem3.OnActivate();
					return true;
				}
			}
			this.OnSecondaryShortcutAction(new SecondaryShortcutEventArgs((Keys)this.x5297af1a9247c00b, keys, null));
			return false;
		}

		// Token: 0x060003FB RID: 1019 RVA: 0x0001459C File Offset: 0x0001359C
		bool IMessageFilter.x4bbcf05291a247a0(ref Message x6088325dec1baa2a)
		{
			if (x6088325dec1baa2a.Msg == 256 || x6088325dec1baa2a.Msg == 260)
			{
				Keys keys = (Keys)((int)x6088325dec1baa2a.WParam | (int)Control.ModifierKeys);
				if (!this.IsAwaitingSecondaryShortcut && this.x80d02e0fbe15cd1d.Contains((int)keys) && this.IsShortcutWithinScope(keys))
				{
					Control control = Control.FromChildHandle(x6088325dec1baa2a.HWnd);
					if (control != null)
					{
						Message message = Message.Create(x6088325dec1baa2a.HWnd, x6088325dec1baa2a.Msg, x6088325dec1baa2a.WParam, x6088325dec1baa2a.LParam);
						if (control.PreProcessMessage(ref message))
						{
							return true;
						}
					}
					return this.ShortcutActivated(keys, true);
				}
				if (this.IsAwaitingSecondaryShortcut && this.IsShortcutWithinScope(keys))
				{
					Keys keys2 = keys & Keys.KeyCode;
					if (keys2 != Keys.ShiftKey && keys2 != Keys.ControlKey && keys2 != Keys.Menu)
					{
						try
						{
							Control control2 = Control.FromChildHandle(x6088325dec1baa2a.HWnd);
							if (control2 != null)
							{
								Message message2 = Message.Create(x6088325dec1baa2a.HWnd, x6088325dec1baa2a.Msg, x6088325dec1baa2a.WParam, x6088325dec1baa2a.LParam);
								if (control2.PreProcessMessage(ref message2))
								{
									return true;
								}
							}
							return this.ShortcutActivated(keys, false);
						}
						finally
						{
							this.x5297af1a9247c00b = 0;
						}
						return false;
					}
				}
			}
			return false;
		}

		// Token: 0x060003FC RID: 1020 RVA: 0x000146E0 File Offset: 0x000136E0
		protected virtual bool IsShortcutWithinScope(Keys keys)
		{
			bool flag = this.x9492ad63ba3e62cf != null;
			if (flag)
			{
				IntPtr foregroundWindow = x443cc432acaadb1d.GetForegroundWindow();
				if (this.x9492ad63ba3e62cf.IsMdiChild)
				{
					flag = (this.x9492ad63ba3e62cf.MdiParent != null && foregroundWindow == this.x9492ad63ba3e62cf.MdiParent.Handle && this.x9492ad63ba3e62cf.MdiParent.ActiveMdiChild == this.x9492ad63ba3e62cf);
				}
				else
				{
					flag = (foregroundWindow == this.x9492ad63ba3e62cf.Handle);
					if (!flag)
					{
						Form form = Control.FromHandle(foregroundWindow) as Form;
						if (form != null && form.Owner == this.x9492ad63ba3e62cf && !form.Modal)
						{
							flag = true;
						}
					}
				}
			}
			return flag;
		}

		// Token: 0x040001C6 RID: 454
		private bool xb377eb567d39789a;

		// Token: 0x040001C7 RID: 455
		private int x5297af1a9247c00b;

		// Token: 0x040001C8 RID: 456
		private Form x9492ad63ba3e62cf;

		// Token: 0x040001C9 RID: 457
		private Hashtable x80d02e0fbe15cd1d;

		// Token: 0x040001CA RID: 458
		private SecondaryShortcutEventHandler xcee5f6ae9f65956a;
	}
}
