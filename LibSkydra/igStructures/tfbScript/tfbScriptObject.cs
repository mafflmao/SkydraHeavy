namespace LibSkydra
{
	public class tfbScriptObject : igNamedObject
	{
		[igRawRefMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_getFunc", 0x0C)]
		public object getFunc;
		[igRawRefMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_setFunc", 0x10)]
		public object setFunc;
		[igRawRefMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_resetFunc", 0x14)]
		public object resetFunc;
		[igTStaticMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_undefinedObject", 0xFFFF)]
		public static object undefinedObject;
		[igTStaticMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_emptySet", 0xFFFF)]
		public static object emptySet;
		public tfbScriptObject(IGZ igz) : base(igz) {}
	}
}