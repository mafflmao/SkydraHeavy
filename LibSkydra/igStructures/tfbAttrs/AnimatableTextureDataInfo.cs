namespace LibSkydra
{
	//Why is this under tfbAttrs?
	public class AnimatableTextureDataInfo : igNamedObject
	{
		[igIntMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_desiredWidth", 0x24)]
		public int desiredWidth;
		[igIntMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_desiredHeight", 0x28)]
		public int desiredHeight;
		[igObjectRefMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_loader", 0x20)]
		public igObject loader;
		[igIntMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_updatedCount", 0x2C)]
		public int updatedCount;
		[igObjectRefMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_texAttr", 0x30)]
		public igObject texAttr;

		public AnimatableTextureDataInfo(IGZ igz) : base(igz){}
	}
}