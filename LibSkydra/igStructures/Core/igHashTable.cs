namespace LibSkydra
{
	public class igHashTable : igContainer
	{
		[igMemoryRefMetaField(0x07, IG_CORE_PLATFORM.DEFAULT, "_values", 0x08)]
		public igMemory values;

		[igMemoryRefMetaField(0x07, IG_CORE_PLATFORM.DEFAULT, "_keys", 0x10)]
		public igMemory keys;

		[igIntMetaField(0x07, IG_CORE_PLATFORM.DEFAULT, "_hashItemCount", 0x18)]
		public int hashItemCount;

		[igBoolMetaField(0x07, IG_CORE_PLATFORM.DEFAULT, "_autoRehash", 0x1C)]
		public bool autoRehash;

		[igFloatMetaField(0x07, IG_CORE_PLATFORM.DEFAULT, "_loadFactor", 0x20)]
		public float loadFactor;

		public igHashTable(IGZ igz) : base(igz){}

		public virtual Dictionary<uint, uint>? GetHashes() { return null; }
	}
}