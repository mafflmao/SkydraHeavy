namespace LibSkydra
{
    public class igVertexElement : igObject
    {
        [igIntMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_type", 0x08)] // this is mainly a placeholder, i honestly don't understand how this works
        public int type;

        public igVertexElement(IGZ igz) : base(igz) { }
    }
}