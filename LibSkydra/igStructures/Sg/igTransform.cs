namespace LibSkydra
{
	public class igTransform : igGroup
	{
		[igMatrix44fMetaField(0x07, IG_CORE_PLATFORM.DEFAULT, "_m", 0x30)]
		public Matrix4x4 m;
		[igIntMetaField(0x07, IG_CORE_PLATFORM.DEFAULT, "_target", 0x70)]
		public int target;
		[igObjectRefMetaField(0x07, IG_CORE_PLATFORM.DEFAULT, "_transformInput", 0x74)]
		public igObject transformInput;
		[igObjectRefMetaField(0x07, IG_CORE_PLATFORM.DEFAULT, "_transformInput3", 0x78)]
		public igObject transformInput3;

		public igTransform(IGZ igz) : base(igz){}
	}
}