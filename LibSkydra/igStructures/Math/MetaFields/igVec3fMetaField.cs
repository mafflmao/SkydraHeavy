namespace LibSkydra
{
	public class igVec3fMetaField : igMetaField
	{
		public igVec3fMetaField(uint applicableVersion, IG_CORE_PLATFORM platform, string name, uint offset) : base(applicableVersion, platform, name, offset){}

		public override object ReadField(IGZ igz)
		{
			Vector3 vec3 = new Vector3();
			vec3.X = igz.sh.ReadSingle();
			vec3.Y = igz.sh.ReadSingle();
			vec3.Z = igz.sh.ReadSingle();
			return vec3;
		}
	}
}