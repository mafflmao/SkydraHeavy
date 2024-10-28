namespace LibSkydra
{
	public class igGraphicsObjectSet : igObject
	{
		[igVectorMetaField(0x09, IG_CORE_PLATFORM.DEFAULT, "_objects", 0x08, typeof(igGraphicsObject))]
		public List<igGraphicsObject> objects;

		public igGraphicsObjectSet(IGZ igz) : base(igz) {}
	}
}