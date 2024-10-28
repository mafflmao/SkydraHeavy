namespace LibSkydra
{
	public class igTStaticMetaField : igMetaField
	{
		public igTStaticMetaField(uint applicableVersion, IG_CORE_PLATFORM platform, string name, uint offset) : base(applicableVersion, platform, name, offset){}

		public override object ReadField(IGZ igz) => throw new NotImplementedException("igTStaticMetaField is not implemented.");
	}
}