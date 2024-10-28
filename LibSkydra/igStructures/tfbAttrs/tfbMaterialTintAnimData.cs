namespace LibSkydra
{
    public class tfbMaterialTintAnimData : igObject
    {
        [igIntMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_animStyle", 0x08)]
        public int animStyle; 
        [igFloatMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_rate", 0x0C)]
        public float rate;
        [igObjectRefMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_keyFrames", 0x10)]
        public igObject keyFrames;
        [igObjectRefMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_keyColors", 0x14)]
        public igObject keyColors;

        public tfbMaterialTintAnimData(IGZ parent) : base(parent) { }
    }
}
