namespace LibSkydra
{
	public class igGraphicsShaderConstant : igGraphicsObject
	{
		[igStringMetaField(0x09, IG_CORE_PLATFORM.DEFAULT, "_name", 0x08)]
		public string name;
		[igUnsignedIntMetaField(0x09, IG_CORE_PLATFORM.DEFAULT, "_resource", 0x0C)]	//Is actually an igSizeTypeMetaField but that isn't yet implemented
		public uint resource;
		public igGraphicsShaderConstant(IGZ igz) : base(igz) {}
	}
}