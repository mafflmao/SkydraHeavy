namespace LibSkydra
{
	public class igSceneInfo : igObject
	{
		[igObjectRefMetaField(0x07, IG_CORE_PLATFORM.DEFAULT, "_sceneGraph", 0x14)]
		public igGroup sceneGraph;

		[igObjectRefMetaField(0x07, IG_CORE_PLATFORM.DEFAULT, "_texturesDeprecated", 0x18)]
		public igObject texturesDeprecated;

		[igObjectRefMetaField(0x07, IG_CORE_PLATFORM.DEFAULT, "_cameras", 0x1C)]
		public igObject cameras;

		[igLongMetaField(0x07, IG_CORE_PLATFORM.DEFAULT, "_animationBegin", 0x20)]
		public long animationBegin;

		[igLongMetaField(0x07, IG_CORE_PLATFORM.DEFAULT, "_animationEnd", 0x28)]
		public long animationEnd;

		[igVec3fMetaField(0x07, IG_CORE_PLATFORM.DEFAULT, "_upVector", 0x30)]
		public Vector3 upVector;

		[igObjectRefMetaField(0x07, IG_CORE_PLATFORM.DEFAULT, "_sceneGraphList", 0x40)]
		public igObject sceneGraphList;

		[igObjectRefMetaField(0x07, IG_CORE_PLATFORM.DEFAULT, "_textures", 0x3C)]
		public igObject textures;
		

		public igSceneInfo(IGZ igz) : base(igz){}
	}
}