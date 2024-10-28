namespace LibSkydra
{
	public class igNode : igNamedObject
	{
		[igObjectRefMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_bound", 0x0C)]
		public igObject bound;
		[igObjectRefMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_parentList", 0x10)]
		public igObject parentList;
		[igIntMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_flags", 0x1C)]
		public int flags;
		[igShortMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_traversalWeight", 0x14)]
		public short traversalWeight;
		[igShortMetaField(0xFF, IG_CORE_PLATFORM.PS3, "_traversalSpuWeight", 0x16)]
		public short traversalSpuWeight;
		[igIntMetaField(0xFF, IG_CORE_PLATFORM.PS3, "_handle", 0x18)]
		public int handle;
		[igTStaticMetaField(0xFF, IG_CORE_PLATFORM.PS3, "_registeredNodeCount", 0xFFFF)]
		public object registeredNodeCount;

		public igNode(IGZ igz) : base(igz){}
	}
}