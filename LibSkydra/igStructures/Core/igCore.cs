namespace LibSkydra
{
	public static class igCore
	{
		public static ulong getSizeOfPointer(IG_CORE_PLATFORM platform)
		{
			switch(platform)
			{
				case IG_CORE_PLATFORM.DEFAULT:
				case IG_CORE_PLATFORM.WIN32:
				case IG_CORE_PLATFORM.WII:
				case IG_CORE_PLATFORM.ASPEN:
				case IG_CORE_PLATFORM.XENON:
				case IG_CORE_PLATFORM.PS3:
				case IG_CORE_PLATFORM.OSX:
				case IG_CORE_PLATFORM.CAFE:
				case IG_CORE_PLATFORM.RASPI:
				case IG_CORE_PLATFORM.ANDROID:
				case IG_CORE_PLATFORM.DEPRECATED:
				case IG_CORE_PLATFORM.LGTV:
				case IG_CORE_PLATFORM.WP8:
				case IG_CORE_PLATFORM.LINUX:
				case IG_CORE_PLATFORM.MAX:
				case IG_CORE_PLATFORM.NGP:
				case IG_CORE_PLATFORM.MARMALADE:	//unsure about this
					return 4;
				case IG_CORE_PLATFORM.DURANGO:
				case IG_CORE_PLATFORM.WIN64:
				case IG_CORE_PLATFORM.ASPEN64:
				case IG_CORE_PLATFORM.PS4:
					return 8;
				default:
					Console.WriteLine($"Missed platform IG_CORE_PLATFORM.{platform.ToString()}");
					return 4;
			}
		}
	}
}