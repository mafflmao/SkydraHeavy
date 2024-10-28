namespace LibSkydra
{
	public class igCachedAttrList : igObject
	{
		[igVectorMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_attrs", 0x08, typeof(igObject))]
		public List<igObject> attrs;
		[igVectorMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_cachedValues", 0x14, typeof(ushort))]
		public List<ushort> cachedValues;

		public igCachedAttrList(IGZ igz) : base(igz){}
	}
}