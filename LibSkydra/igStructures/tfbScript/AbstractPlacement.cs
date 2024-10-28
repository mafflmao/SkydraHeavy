namespace LibSkydra
{
	public class AbstractPlacement : AbstractAttachNode
	{
        [igUnsignedIntMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_flagPool", 0x1C)]
		public uint flagPool;
        [igIntMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_ID", 0x20)]
		public int ID;
        [tfbEulerTransformMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_initMatrix", 0x24)]
		public object initMatrix;
        [tfbEulerTransformMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_currentMatrix", 0x3C)]
		public object currentMatrix;
        [igEnumMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_activityState", 0x54)]
		public uint activityState;
        [igObjectRefMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_clones", 0x58)]
		public igObject clones;
        [igObjectRefMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_parent", 0x5C)]
		public igObject parent;
        [igObjectRefMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_activator", 0x60)]
		public igObject activator;
        [igObjectRefMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_moveObject", 0x64)]
		public igObject moveObject;
        [igIntMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_moveIndex", 0x68)]
		public int moveIndex;
        [igObjectRefMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_attachNode", 0x6C)]
		public igObject attachNode;

        [igObjectRefMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_attachNodeOwner", 0x70)]
		public object attachNodeOwner;

        [igObjectRefMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_attachedObjects", 0x74)]
		public igObject attachedObjects;
        [tfbEulerTransformMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_attachXform", 0x78)]
		public object attachXform;
        [igObjectRefMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_soundList", 0x90)]
		public igObject soundList;
        [igObjectRefMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_animationList", 0x94)]
		public igObject animationList;
        [igObjectRefMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_resetTemplate", 0x98)]
		public igObject resetTemplate;
        [igUnsignedIntMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_activeTimeLayer", 0x9C)]
		public uint activeTimeLayer;
        [igTStaticMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_interface", 0xFFFF)]
		public static object _interface;
        [igBitFieldMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_explicitAttachment", 0x1C)]
		public uint explicitAttachment;

		public AbstractPlacement(IGZ igz) : base(igz) {}
	}
}