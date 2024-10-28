namespace LibSkydra
{
	public class igUnsignedShortArrayMetaField : igMemoryRefMetaField
	{
		public igUnsignedShortArrayMetaField(uint applicableVersion, IG_CORE_PLATFORM platform, string name, uint offset) : base(applicableVersion, platform, name, offset){}

		public override object ReadField(IGZ igz)
		{
			//TODO: Look into this
			return null;
		}
	}
}