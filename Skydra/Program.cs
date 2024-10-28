namespace Skydra
{
	public static class Program
	{
		public static NativeWindowSettings nws = new NativeWindowSettings()
		{
			Size = new Vector2i(1280, 720),
			Title = "Skydra",
			Flags = ContextFlags.ForwardCompatible
		};

		public static GameWindowSettings gws = new GameWindowSettings()
		{
			IsMultiThreaded = false
		};

		public static void Main(string[] args)
		{
			using(Window wnd = new Window(gws, nws, args[0]))
			{
				wnd.Run();
			}
		}
	}
}