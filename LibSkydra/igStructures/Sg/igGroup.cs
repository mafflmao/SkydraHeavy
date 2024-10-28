namespace LibSkydra
{
	public class igGroup : igNode
	{
		[igObjectRefMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_childList", 0x20)]
		public igNodeList childList;

		public igGroup(IGZ igz) : base(igz){}
	}
}