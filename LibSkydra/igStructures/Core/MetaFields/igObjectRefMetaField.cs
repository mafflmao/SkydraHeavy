namespace LibSkydra
{
	public class igObjectRefMetaField : igMetaField
	{

		public igObjectRefMetaField(uint applicableVersion, IG_CORE_PLATFORM platform, string name, uint offset) : base(applicableVersion, platform, name, offset){}

		public override object ReadField(IGZ igz)
		{
			ulong objectOffset;
			/*if(Name.Equals("_format"))
			{
				if(igz.runtimeExternals.Length != 0 && igz.runtimeExternals.Any(x => x == (ulong)igz.sh.BaseStream.Position))
				{
					uint exidIndex = igz.sh.ReadUInt32() & ~0x80000000;
					return igz.exid.hashes[exidIndex];
				}
			}*/

			ulong rawOffset = 0;
			if(igCore.getSizeOfPointer(igz.platform) == 4) rawOffset = igz.sh.ReadUInt32();
			else 										   rawOffset = igz.sh.ReadUInt64();

			if(rawOffset == 0) return null;
			if((rawOffset & 0x80000000) != 0)
			{
				Console.WriteLine("WARNING: SKIPPED LOADING OF igObject WITH UNNKOWN INDEX");
				return null;
			}
			objectOffset = igz.FixOffset(rawOffset);
			if(igz.objects.Any(x => x.Key == objectOffset))
			{
				object obj = igz.objects[objectOffset];
				Console.WriteLine($"Found and reading {igz.typeNames[(int)((igObject)obj).typeIndex]} @ {objectOffset.ToString("X08")}");
				//((igObject)obj).ReadFields();
				return obj;
			}
			else
			{
				Console.WriteLine($"igObjectRefMetaField \"{Name}\" tried to load object @ {objectOffset.ToString("X08")} and failed");
				return null;
			}
		}
	}
}