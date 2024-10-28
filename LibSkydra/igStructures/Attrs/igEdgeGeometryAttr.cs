namespace LibSkydra
{
	public class igEdgeGeometryAttr : igObject
	{
		[igObjectRefMetaField(0xFF, IG_CORE_PLATFORM.PS3, "_geometry", 0x10)]
		public igPS3EdgeGeometry geometry;

		public igEdgeGeometryAttr(IGZ igz) : base(igz){}
	}
}