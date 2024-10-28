namespace LibSkydra
{
    public class igVertexFormat : igObject
    {
        [igIntMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_vertexSize", 0x08)]
        public int vertexSize;
        [igUnsignedShortArrayMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_elements", 0x0C)] // this is actually an igVertexElementArrayMetaField but idk how that works
        public igVertexElement[] elements;

        public igVertexFormat(IGZ igz) : base(igz) { }
    }
}
