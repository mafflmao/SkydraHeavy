namespace LibSkydra
{
    public class RHSValueStack : tfbScriptObject
    {
        [igStringMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_name", 0x1C)]
        public string name;
        public RHSValueStack(IGZ igz) : base(igz) { } 
    }
}
