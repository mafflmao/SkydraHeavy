namespace LibSkydra
{
	public class AbstractAttachNode : MatrixMeasurement
	{
		[igObjectRefMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_tagList", 0x18)]
		public igObject tagList;
		[igTStaticMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_interface", 0xFFFF)]
		public static igObject _interface;
		public AbstractAttachNode(IGZ igz) : base(igz) {}
	}
}