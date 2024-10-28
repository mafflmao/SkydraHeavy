namespace LibSkydra
{
	public class igInfo : igReferenceResolver
	{
		[igObjectRefMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_directory", 0x0C)]
		public igObject data;
		[igBoolMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_resolveState", 0x10)]
		public bool streamArchiveHash;
		public igInfo(IGZ igz) : base(igz){}
	}
}