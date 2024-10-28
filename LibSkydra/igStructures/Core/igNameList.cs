namespace LibSkydra
{
	public class igNameList : igTDataList<igNameList.igName>
	{
		[igStruct(0x08)]
		public struct igName
		{
			[igStringMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "", 0x00)]
			public string name;
			[igUnsignedIntMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "", 0x04)]
			public uint hash;
		}
		public igNameList(IGZ igz) : base(igz){}
	}
}