namespace LibSkydra
{
	public class igStringMetaField : igMetaField
	{
		public igStringMetaField(uint applicableVersion, IG_CORE_PLATFORM platform, string name, uint offset) : base(applicableVersion, platform, name, offset){}

		public override object ReadField(IGZ igz)
		{
			ulong raw = 0;
			if(igCore.getSizeOfPointer(igz.platform) == 4) raw = igz.sh.ReadUInt32();
			else										   raw = igz.sh.ReadUInt64();
			if(raw == 0x0000FFFF) return string.Empty;
			//nothing's ever simple in this game engine, i don't check it with ROFS since this isn't under ROFS for some reason
			Console.WriteLine($"igstringtest {(raw).ToString("X08")} : {(raw >> 0x18).ToString("X08")}");
			if((raw >> 0x18) != 0)
			{
				return igz.sh.ReadString(igz.FixOffset(raw, igz.version <= 0x06));
			}
			if(raw > 4 && igz.objects.Keys.Any(x => x == igz.FixOffset(raw)))
			{
				Console.WriteLine($"This string somehow points to an object");
				return string.Empty;
			}
			return igz.stringList.Count == 0 ? string.Empty : igz.stringList[(int)raw];
		}
	}
}