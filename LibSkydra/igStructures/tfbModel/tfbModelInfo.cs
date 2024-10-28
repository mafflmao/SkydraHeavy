namespace LibSkydra
{
	public class tfbModelInfo : tfbComplexDataInfo
	{
		[igObjectRefMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_tfbBody", 0x14)]
		public igObject tfbBody;
		[igObjectRefMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_modelParameters", 0x18)]
		public igObject modelParameters;
		[igObjectRefMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_animationSet", 0x1C)]
		public igObject animationSet;
		[igObjectRefMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_stateData", 0x20)]
		public igObject stateData;
		[igObjectRefMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_collision", 0x24)]
		public igObject collision;
		[igObjectRefMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_attachList", 0x28)]
		public igObject attachList;
		[igStringMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_templatePath", 0x2C)]
		public string templatePath;
		[igIntMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_numLookAtEntries", 0x30)]
		public int numLookAtEntries;

		public tfbModelInfo(IGZ igz) : base (igz){}
	}
}