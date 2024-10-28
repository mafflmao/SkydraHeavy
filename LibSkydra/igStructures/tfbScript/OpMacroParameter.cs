namespace LibSkydra
{
    public class OpMacroParameter : igObject
    {
        [igStringMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_name", 0x1C)]
        public string name;

        public OpMacroParameter(IGZ igz) : base(igz) { } 
    }
}
