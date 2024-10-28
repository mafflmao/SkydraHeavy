namespace LibSkydra
{
	public class tfbBuildDataInfo : tfbComplexDataInfo
	{
		[igMemoryRefMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_data", 0x14)]
		public igMemory data;
		[igIntMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_streamArchiveHash", 0x1C)]
		public int streamArchiveHash;
		public tfbBuildDataInfo(IGZ igz) : base(igz){}
	}
}