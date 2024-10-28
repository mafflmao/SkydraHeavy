namespace LibSkydra
{
	//TODO: Actually add the fields, rn i only added this cos of the names
	public class ScriptSet : igNamedObject
	{
		[igObjectRefMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_list", 0x18)]
		public ScriptSetList _list;
		public ScriptSet(IGZ igz) : base(igz){}
	}
}