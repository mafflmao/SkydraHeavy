namespace LibSkydra
{
	public class igBoolMetaField : igMetaField
	{
		public igBoolMetaField(uint applicableVersion, IG_CORE_PLATFORM platform, string name, uint offset) : base(applicableVersion, platform, name, offset){}

		public override object ReadField(IGZ igz) => igz.sh.ReadBoolean();
	}
}