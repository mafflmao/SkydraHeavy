namespace LibSkydra
{
    public class tfbMaterialAnimTrack : igObject
    {
        // [igFloatMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_data", 0x0C)] // I'm still not entirely sure hwo this works? i think its an igMaterialAnimData but I don't have that yet
        // public float data;
        [igFloatMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_baseTime", 0x20)]
        public float baseTime;
        [igFloatMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_curTime", 0x0C)]
        public float curTime;

        public tfbMaterialAnimTrack(IGZ parent) : base(parent) { }
    }
}
