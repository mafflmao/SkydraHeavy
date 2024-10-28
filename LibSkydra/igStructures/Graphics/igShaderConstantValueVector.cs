namespace LibSkydra
{
	public class igShaderConstantValueVector : igShaderConstantValue
	{
		[igVec4MetaField(0x09, IG_CORE_PLATFORM.DEFAULT, "_value", 0x10)]
		public Vector4 value;

		public igShaderConstantValueVector(IGZ igz) : base(igz) {}
	}
}