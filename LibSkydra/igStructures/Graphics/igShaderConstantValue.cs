namespace LibSkydra
{
	public class igShaderConstantValue : igObject
	{
		[igObjectRefMetaField(0x09, IG_CORE_PLATFORM.DEFAULT, "_constant", 0x08)]
		public igGraphicsShaderConstant constant;

		public igShaderConstantValue(IGZ igz) : base(igz) {}
	}
}