namespace LibSkydra
{
	public class tfbBodyEntityInfo : tfbEntityInfo
	{
		[igUnsignedIntMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_flagBits", 0x1C)]
		public uint flagBits;

		[igObjectRefMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_bounds", 0x20)]
		public igObject bounds;

		[igObjectRefMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_blendMatrixIndexLists", 0x24)]
		public igObject blendMatrixIndexLists;

		[igBitFieldMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_skinned", 0x1C)]
		public uint skinned;

		[igBitFieldMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_articulated", 0x1C)]
		public uint articulated;

		[igBitFieldMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_wiiCastsShadowOnActors", 0x1C)]
		public uint wiiCastsShadowOnActors;

		public tfbBodyEntityInfo(IGZ igz) : base (igz){}
	}
}