namespace LibSkydra
{
	public class igHandleMetaField : igMetaField
	{
		public igHandleMetaField(uint applicableVersion, IG_CORE_PLATFORM platform, string name, uint offset) : base(applicableVersion, platform, name, offset){}

		public override object ReadField(IGZ igz)
		{
			//if(igz.exnm.count == 0) return null;
			uint raw = igz.sh.ReadUInt32();
			if((raw & 0x80000000) != 0)
			{
				//Load from EXNM
				uint handleIndex = raw & ~0x80000000;
				Console.WriteLine($"{igz.exnm.objectNames[handleIndex]}, {igz.exnm.dependancyNames[handleIndex]}");
				return new Tuple<string, string>(igz.stringList[(int)igz.exnm.objectNames[handleIndex]], igz.stringList[(int)igz.exnm.dependancyNames[handleIndex]]);
			}
			return null;
		}
	}
}