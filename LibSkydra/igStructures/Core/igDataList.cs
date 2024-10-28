namespace LibSkydra
{
	//Note to self, igObjectList derives from igTDataList<igObject> which derives from igDataList which derives from igObject. igObjectList does not derive directly from igObject
	public class igDataList : igObject
	{
		[igUnsignedIntMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_count", 0x08)]
		public uint count;
		
		[igUnsignedIntMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_capacity", 0x0C)]
		public uint capacity;

		[igMemoryRefMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_data", 0x10)]
		public igMemory data;

		public igDataList(IGZ parent) : base(parent){}
	}
}