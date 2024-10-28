using System.ComponentModel;

namespace SkydraLite
{
	//Thank you StackOverflow, https://stackoverflow.com/questions/39589176/disable-the-selection-highlight-in-richtextbox-or-textbox

	public class ExRichTextBox : RichTextBox
	{
		public ExRichTextBox()
		{
			Selectable = false;
		}
		const int WM_SETFOCUS = 0x0007;
		const int WM_KILLFOCUS = 0x0008;

		///<summary>
		/// Enables or disables selection highlight. 
		/// If you set `Selectable` to `false` then the selection highlight
		/// will be disabled. 
		/// It's enabled by default.
		///</summary>
		[DefaultValue(true)]
		public bool Selectable { get; set; }
		protected override void WndProc(ref Message m)
		{
			if (m.Msg == WM_SETFOCUS && !Selectable)
				m.Msg = WM_KILLFOCUS;

			base.WndProc(ref m);
		}
	}
}