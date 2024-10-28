namespace LibSkydra
{
	//Not real, now replaced by igObjectRefMetaField cos that's what the games actually use
	public class igEXIDMetaField : igMetaField
	{
		public igEXIDMetaField(uint applicableVersion, IG_CORE_PLATFORM platform, string name, uint offset) : base(applicableVersion, platform, name, offset){}

		public override object ReadField(IGZ igz)
		{
			uint exidIndex = igz.sh.ReadUInt32() & ~0x80000000;
			return igz.exid.hashes[exidIndex];
		}
	}
}