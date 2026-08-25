using System;

namespace IGE.Nomad
{
	// Token: 0x0200005D RID: 93
	internal abstract class InputBase : IInputSink
	{
		// Token: 0x06000426 RID: 1062 RVA: 0x000102B9 File Offset: 0x0000E4B9
		public virtual void OnInputAcquire()
		{
		}

		// Token: 0x06000427 RID: 1063 RVA: 0x000102BB File Offset: 0x0000E4BB
		public virtual void OnInputRelease()
		{
		}

		// Token: 0x06000428 RID: 1064 RVA: 0x000102BD File Offset: 0x0000E4BD
		public virtual bool OnMouseEvent(Editor.MouseEvent mouseEvent, Editor.MouseEventArgs mouseEventArgs)
		{
			return false;
		}

		// Token: 0x06000429 RID: 1065 RVA: 0x000102C0 File Offset: 0x0000E4C0
		public virtual bool OnKeyEvent(Editor.KeyEvent keyEvent, Editor.KeyEventArgs keyEventArgs)
		{
			return false;
		}

		// Token: 0x0600042A RID: 1066 RVA: 0x000102C3 File Offset: 0x0000E4C3
		public virtual void OnEditorEvent(uint eventType, IntPtr eventPtr)
		{
		}

		// Token: 0x0600042B RID: 1067 RVA: 0x000102C5 File Offset: 0x0000E4C5
		public virtual void Update(float dt)
		{
		}

		// Token: 0x0600042C RID: 1068 RVA: 0x000102C7 File Offset: 0x0000E4C7
		protected void AcquireInput()
		{
			Editor.PushInput(this);
			Program.EnableShortcuts(false);
		}

		// Token: 0x0600042D RID: 1069 RVA: 0x000102D5 File Offset: 0x0000E4D5
		protected void ReleaseInput()
		{
			Program.EnableShortcuts(true);
			Editor.PopInput(this);
		}
	}
}
