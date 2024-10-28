namespace LibSkydra
{
	public class igUnsignedShortMetaField : igMetaField
	{
		public igUnsignedShortMetaField(uint applicableVersion, IG_CORE_PLATFORM platform, string name, uint offset) : base(applicableVersion, platform, name, offset){}

		public override object ReadField(IGZ igz) => igz.sh.ReadUInt16();
	}
}