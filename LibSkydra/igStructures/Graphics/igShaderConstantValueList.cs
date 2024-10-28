namespace LibSkydra
{
	public class igShaderConstantValueList : igGraphicsObject
	{
		[igVectorMetaField(0x09, IG_CORE_PLATFORM.DEFAULT, "_values", 0x08, typeof(igShaderConstantValue))]
		public List<igShaderConstantValue> constant;

		public igShaderConstantValueList(IGZ igz) : base(igz) {}
	}
}