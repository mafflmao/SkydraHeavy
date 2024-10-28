namespace LibSkydra
{
	public class igFxMaterialNode : igGroup
	{
		[igHandleMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_materialInstance", 0x24)]
		public object materialInstance;

		public igFxMaterialNode(IGZ igz) : base(igz){}
	}
}