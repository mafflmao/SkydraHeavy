namespace LibSkydra
{
	public class tfbBodyInfo : tfbSceneInfo
	{
		[igObjectRefMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_combinerPrototype", 0x28)]
		public igObject combinerPrototype;
		[igObjectRefMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_visemePoses", 0x2C)]
		public igObject visemePoses;
		[igObjectRefMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_entityInfo", 0x30)]
		public tfbEntityInfo entityInfo;

		public tfbBodyInfo(IGZ igz) : base (igz){}
	}
}