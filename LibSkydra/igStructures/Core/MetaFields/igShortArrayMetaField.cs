namespace LibSkydra
{
	public class igShortArrayMetaField : igMemoryRefMetaField
	{
		public igShortArrayMetaField(uint applicableVersion, IG_CORE_PLATFORM platform, string name, uint offset) : base(applicableVersion, platform, name, offset){}

		public override object ReadField(IGZ igz)
		{
			//TODO: Look into this
			return null;
		}
	}
}