namespace LibSkydra
{
	public class igAttrSet : igGroup
	{
		[igObjectRefMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_attributes", 0x24)]
		public igAttrList attributes;
		[igBoolMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_trigger", 0x28)]
		public bool trigger;
		public igAttrSet(IGZ igz) : base(igz){}
	}
}