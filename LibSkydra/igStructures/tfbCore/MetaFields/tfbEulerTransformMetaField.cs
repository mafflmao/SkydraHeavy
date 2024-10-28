namespace LibSkydra
{
	public class tfbEulerTransformMetaField : igMetaField
	{
		public tfbEulerTransformMetaField(uint applicableVersion, IG_CORE_PLATFORM platform, string name, uint offset) : base(applicableVersion, platform, name, offset){}

		public override object ReadField(IGZ igz) => null;
	}
}