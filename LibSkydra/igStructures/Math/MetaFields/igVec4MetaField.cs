namespace LibSkydra
{
	public class igVec4MetaField : igMetaField
	{
		public igVec4MetaField(uint applicableVersion, IG_CORE_PLATFORM platform, string name, uint offset) : base(applicableVersion, platform, name, offset){}

		public override object ReadField(IGZ igz)
		{
			Vector4 vec4 = new Vector4();
			vec4.X = igz.sh.ReadSingle();
			vec4.Y = igz.sh.ReadSingle();
			vec4.Z = igz.sh.ReadSingle();
			vec4.W = igz.sh.ReadSingle();
			return vec4;
		}
	}
}