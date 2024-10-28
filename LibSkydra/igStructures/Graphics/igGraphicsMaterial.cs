namespace LibSkydra
{
	public class igGraphicsMaterial : igMaterial
	{
		[igUnsignedLongMetaField(0x09, IG_CORE_PLATFORM.DEFAULT, "_globalTechniqueMask", 0x10)]
		public ulong globalTechniqueMask;
		[igUnsignedIntMetaField(0x09, IG_CORE_PLATFORM.DEFAULT, "_materialBitField", 0x18)]
		public uint materialBitField;
		[igFloatMetaField(0x09, IG_CORE_PLATFORM.DEFAULT, "_sortDepthOffset", 0x1C)]
		public float sortDepthOffset;
		[igHandleMetaField(0x09, IG_CORE_PLATFORM.DEFAULT, "_effectHandle", 0x20)]
		public Tuple<string, string> effectHandle;
		[igObjectRefMetaField(0x09, IG_CORE_PLATFORM.DEFAULT, "_commonState", 0x24)]
		public igObject commonState;
		[igVectorMetaField(0x09, IG_CORE_PLATFORM.DEFAULT, "_techniques", 0x28, typeof(igObject))]
		public List<igObject> techniques;
		[igObjectRefMetaField(0x09, IG_CORE_PLATFORM.DEFAULT, "_animations", 0x34)]
		public igObject animations;
		[igObjectRefMetaField(0x09, IG_CORE_PLATFORM.DEFAULT, "_graphicsObjects", 0x38)]
		public igObject graphicsObjects;
		[igBitFieldMetaField(0x09, IG_CORE_PLATFORM.DEFAULT, "_sortKey", 0x18)]
		public uint sortKey;
		[igBitFieldMetaField(0x09, IG_CORE_PLATFORM.DEFAULT, "_drawType", 0x18)]
		public uint drawType;
		[igBitFieldMetaField(0x09, IG_CORE_PLATFORM.DEFAULT, "_timeSource", 0x18)]
		public uint timeSource;

		public igGraphicsMaterial(IGZ igz) : base(igz) {}
	}
}