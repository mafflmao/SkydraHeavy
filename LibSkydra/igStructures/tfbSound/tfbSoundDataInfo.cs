namespace LibSkydra
{
	public class tfbSoundDataInfo : tfbBuildDataInfo
	{
		[igFloatMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_rawDuration", 0x20)]
		public float duration;
		[igObjectRefMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_visemeStream", 0x24)]
		public igObject visemeStream;
		public tfbSoundDataInfo(IGZ igz) : base(igz){}
	}
}