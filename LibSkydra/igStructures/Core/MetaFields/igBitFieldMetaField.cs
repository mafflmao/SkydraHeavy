namespace LibSkydra
{
	public class igBitFieldMetaField : igMetaField
	{
		public igBitFieldMetaField(uint applicableVersion, IG_CORE_PLATFORM platform, string name, uint offset) : base(applicableVersion, platform, name, offset){}

		public override object ReadField(IGZ igz)
		{
			Console.WriteLine("WARNING: igBitFieldMetaField IS NOT PROPERLY IMPLEMENTED");
			return igz.sh.ReadUInt32();
		}
	}
}