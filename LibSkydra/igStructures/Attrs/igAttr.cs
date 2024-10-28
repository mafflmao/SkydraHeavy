namespace LibSkydra
{
	public class igAttr : igObject
	{
		[igShortMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_cachedUnitID", 0x08)]
		public short cachedUnitID;
		[igShortMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_cachedAttrIndex", 0x0A)]
		public short cachedAttrIndex;
		[igBoolMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_readOnlyCopy", 0x0C)]
		public bool readOnlyCopy;
		[igTStaticMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_nextAttrIndex", 0xFFFF)]
		public object nextAttrIndex;

		public igAttr(IGZ igz) : base(igz){}
	}
}