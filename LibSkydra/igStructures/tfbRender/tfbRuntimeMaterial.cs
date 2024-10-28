namespace LibSkydra
{
	public class tfbRuntimeMaterial : igNamedObject
	{
		[igUnsignedIntMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_drawableListMask", 0x0C)]
		public uint drawableListMask;

		[igUnsignedIntMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_attributeMask", 0x10)]
		public uint attributeMask;

		[igUnsignedIntMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_userFxMaterialFlag", 0x14)]
		public uint userFxMaterialFlag;

		[igObjectRefMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_materialList", 0x18)]
		public igObject materialList;

		[igIntMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_vizSet", 0x1C)]
		public int vizSet;

		[igHandleMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_effectHandle", 0x20)]
		public Tuple<string, string> effectHandle;

		[igObjectRefMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_instanceAttrs", 0x24)]
		public igCachedAttrListList instanceAttrs;

		[igObjectRefMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_transforms", 0x28)]
		public igObject transforms;

		[igIntMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_sortKey", 0x2C)]
		public int sortKey;

		public tfbRuntimeMaterial(IGZ igz) : base(igz){}
	}
}