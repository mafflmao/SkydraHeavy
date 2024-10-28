namespace LibSkydra
{
    public class OpCreateVariable : igObject
    {
        [igStringMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_name", 0x1C)]
        public string name;
        public OpCreateVariable(IGZ igz) : base(igz) { } 
    }
}
