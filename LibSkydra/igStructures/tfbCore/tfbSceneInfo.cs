namespace LibSkydra
{
	public class tfbSceneInfo : tfbBuildDataInfo
	{
		[igObjectRefMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_completeSceneGraph", 0x20)]
		public igObject completeSceneGraph;

		[igObjectRefMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_metadataObject", 0x24)]
		public igObject metadataObject;

		public tfbSceneInfo(IGZ igz) : base (igz){}
	}
}