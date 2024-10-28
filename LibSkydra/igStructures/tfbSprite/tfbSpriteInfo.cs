namespace LibSkydra
{
	//TODO: Implement parents
	public class tfbSpriteInfo : AbstractPlacement
	{
		[igTStaticMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_interface", 0xFFFF)]
		public static igObject _interface;

		[igTStaticMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_configureMeta", 0xFFFF)]
		public static igObject configureMeta;

		[igUnsignedIntMetaField(0x06, IG_CORE_PLATFORM.DEFAULT, "_properties", 0xA8)]
		[igUnsignedIntMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_properties", 0xA8)]
		public uint properties;

		[igUnsignedIntMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_properties2", 0xAC)]
		public uint properties2;

		[igFloatMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_textSpacing", 0xB0)]
		public float textSpacing;

		[igIntMetaField(0x06, IG_CORE_PLATFORM.DEFAULT, "_flags", 0xA0)]
		[igIntMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_flags", 0xA0)]
		public int flags;

		[igShortArrayMetaField(0x06, IG_CORE_PLATFORM.DEFAULT, "_position", 0xA4)]
		[igShortArrayMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_position", 0xA4)]
		public short[] position;

		[igFloatMetaField(0x06, IG_CORE_PLATFORM.DEFAULT, "_zDepth", 0xAC)]
		[igFloatMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_zDepth", 0xB4)]
		public float zDepth;

		[igFloatMetaField(0x06, IG_CORE_PLATFORM.DEFAULT, "_priority", 0xB0)]
		[igFloatMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_priority", 0xB8)]
		public float priority;

		[igFloatMetaField(0x06, IG_CORE_PLATFORM.DEFAULT, "_width", 0xB4)]
		[igFloatMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_width", 0xBC)]
		public float width;

		[igFloatMetaField(0x06, IG_CORE_PLATFORM.DEFAULT, "_height", 0xB8)]
		[igFloatMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_height", 0xC0)]
		public float height;

		[igVec3fMetaField(0x06, IG_CORE_PLATFORM.DEFAULT, "_scaleVec", 0xBC)]
		[igVec3fMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_scaleVec", 0xC4)]
		public Vector3 scaleVec;

		[igVec4ucMetaField(0x06, IG_CORE_PLATFORM.DEFAULT, "_color", 0xC8)]
		[igVec4ucMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_color", 0xD0)]
		public Vector4 color;

		[igVec4ucMetaField(0x06, IG_CORE_PLATFORM.DEFAULT, "_replaceColor", 0xCC)]
		[igVec4ucMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_replaceColor", 0xD4)]
		public Vector4 replaceColor;

		[igObjectRefMetaField(0x06, IG_CORE_PLATFORM.DEFAULT, "_contextDataInfo", 0xD0)]
		[igObjectRefMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_contextDataInfo", 0xD8)]
		public igObject contextDataInfo;	//On giants this is an igObject, on trap team this is a uint

		[igTStaticMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_leftAnalogBaseSprite", 0xFFFF)]
		public static object _leftAnalogBaseSprite;

		[igTStaticMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_leftAnalogCenterSprite", 0xFFFF)]
		public static object _leftAnalogCenterSprite;

		[igTStaticMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_buttonASprite", 0xFFFF)]
		public static object _buttonASprite;

		[igTStaticMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_buttonBSprite", 0xFFFF)]
		public static object _buttonBSprite;

		[igTStaticMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_buttonXSprite", 0xFFFF)]
		public static object _buttonXSprite;

		[igTStaticMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_buttonYSprite", 0xFFFF)]
		public static object _buttonYSprite;

		[igTStaticMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_buttonContextSprite", 0xFFFF)]
		public static object _buttonContextSprite;

		[igTStaticMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_buttonSwitchSprite", 0xFFFF)]
		public static object _buttonSwitchSprite;

		[igTStaticMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_buttonStartSprite", 0xFFFF)]
		public static object _buttonStartSprite;

		[igTStaticMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_buttonSelectSprite", 0xFFFF)]
		public static object _buttonSelectSprite;

		[igTStaticMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_ignoreVirtualController", 0xFFFF)]
		public static object _ignoreVirtualController;

		[igTStaticMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_virtualControllerVisible", 0xFFFF)]
		public static object _virtualControllerVisible;

		[igTStaticMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_displayContextButton", 0xFFFF)]
		public static object _displayContextButton;

		[igTStaticMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_displaySwitchButton", 0xFFFF)]
		public static object _displaySwitchButton;

		[igObjectRefMetaField(0x06, IG_CORE_PLATFORM.DEFAULT, "_stringInfo", 0xD4)]
		[igObjectRefMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_stringInfo", 0xDC)]
		public object stringInfo;

		[igObjectRefMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_dialogController", 0xE0)]
		public object dialogController;

		[igIntMetaField(0x06, IG_CORE_PLATFORM.DEFAULT, "_numValue", 0xD8)]
		[igIntMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_numValue", 0xE4)]
		public int numValue;

		[igFloatMetaField(0x06, IG_CORE_PLATFORM.DEFAULT, "_depth", 0xDC)]
		[igFloatMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_depth", 0xE8)]
		public float depth;

		[igObjectRefMetaField(0x06, IG_CORE_PLATFORM.DEFAULT, "_gameTrans", 0xE0)]
		[igObjectRefMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_gameTrans", 0xEC)]
		public igObject gameTrans;

		[igBitFieldMetaField(0x06, IG_CORE_PLATFORM.DEFAULT, "_visualType", 0xA8)]
		[igBitFieldMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_visualType", 0xA8)]
		public uint visualType;

		[igBitFieldMetaField(0x06, IG_CORE_PLATFORM.DEFAULT, "_blendMode", 0xA8)]
		[igBitFieldMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_blendMode", 0xA8)]
		public uint blendMode;

		[igBitFieldMetaField(0x06, IG_CORE_PLATFORM.DEFAULT, "_justification", 0xA8)]
		[igBitFieldMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_justification", 0xA8)]
		public uint justification;

		[igBitFieldMetaField(0x06, IG_CORE_PLATFORM.DEFAULT, "_alignment", 0xA8)]
		[igBitFieldMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_alignment", 0xA8)]
		public uint alignment;

		[igBitFieldMetaField(0x06, IG_CORE_PLATFORM.DEFAULT, "_alignToParent", 0xA8)]
		[igBitFieldMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_alignToParent", 0xA8)]
		public uint alignToParent;

		[igBitFieldMetaField(0x06, IG_CORE_PLATFORM.DEFAULT, "_visible", 0xA8)]
		[igBitFieldMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_visible", 0xA8)]
		public uint visible;

		[igBitFieldMetaField(0x06, IG_CORE_PLATFORM.DEFAULT, "_pointSize", 0xA8)]
		[igBitFieldMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_pointSize", 0xA8)]
		public uint pointSize;

		[igBitFieldMetaField(0x06, IG_CORE_PLATFORM.DEFAULT, "_dirty", 0xA8)]
		[igBitFieldMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_dirty", 0xA8)]
		public uint dirty;

		[igBitFieldMetaField(0x06, IG_CORE_PLATFORM.DEFAULT, "_stringWidthValid", 0xA8)]
		[igBitFieldMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_stringWidthValid", 0xA8)]
		public uint stringWidthValid;

		[igBitFieldMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_textVisualType", 0xAC)]
		public uint textVisualType;
		
		[igBitFieldMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_textSpacingType", 0xAC)]
		public uint textSpacingType;

		[igBitFieldMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_target", 0xAC)]
		public uint target;

		public tfbSpriteInfo(IGZ igz) : base (igz){}

		public override void ReadFields()
		{
			base.ReadFields();

			Console.WriteLine($"_contextDataInfo is a {(contextDataInfo != null ? contextDataInfo.GetType() : "N/A")}");
		}
	}
}