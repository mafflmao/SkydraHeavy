namespace LibSkydra
{
	public class igMemoryRefMetaField : igMetaField
	{
		public igMemoryRefMetaField(uint applicableVersion, IG_CORE_PLATFORM platform, string name, uint offset) : base(applicableVersion, platform, name, offset){}

		public override object ReadField(IGZ igz)
		{
			igMemory mem;
			mem.dataLength = igz.sh.ReadUInt32() & 0x00FFFFFF;		//Double check this
			mem.dataOffset = igz.FixOffset(igz.sh.ReadUInt32());
			igz.sh.Seek(mem.dataOffset);
			mem.data = igz.sh.ReadBytes((int)mem.dataLength);
			return mem;
		}
	}
}