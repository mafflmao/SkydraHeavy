namespace LibSkydra
{
    public class igColorAttr : igObject
    {
        [igVec4MetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_color", 0x08)]
        public Vector4 color;

        public igColorAttr(IGZ igz) : base(igz) { }
    }
}