namespace LibSkydra
{
	public class igMemoryRefHandleMetaField : igMetaField
	{
		public igMemoryRefHandleMetaField(uint applicableVersion, IG_CORE_PLATFORM platform, string name, uint offset) : base(applicableVersion, platform, name, offset){}

		public override object ReadField(IGZ igz)
		{
			uint tmhnIndex = igz.sh.ReadUInt32();
			return igz.memoryHandles[(int)tmhnIndex];
		}
	}
}