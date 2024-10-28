namespace LibSkydra
{
	public class igIntMetaField : igMetaField
	{
		public igIntMetaField(uint applicableVersion, IG_CORE_PLATFORM platform, string name, uint offset) : base(applicableVersion, platform, name, offset){}

		public override object ReadField(IGZ igz) => igz.sh.ReadInt32();
	}
}