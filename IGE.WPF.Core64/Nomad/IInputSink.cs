using System;

namespace IGE.Nomad
{
	// Token: 0x0200002C RID: 44
	internal interface IInputSink
	{
		// Token: 0x06000131 RID: 305
		void OnInputAcquire();

		// Token: 0x06000132 RID: 306
		void OnInputRelease();

		// Token: 0x06000133 RID: 307
		bool OnMouseEvent(Editor.MouseEvent mouseEvent, Editor.MouseEventArgs mouseEventArgs);

		// Token: 0x06000134 RID: 308
		bool OnKeyEvent(Editor.KeyEvent keyEvent, Editor.KeyEventArgs keyEventArgs);

		// Token: 0x06000135 RID: 309
		void OnEditorEvent(uint eventType, IntPtr eventPtr);

		// Token: 0x06000136 RID: 310
		void Update(float dt);
	}
}
