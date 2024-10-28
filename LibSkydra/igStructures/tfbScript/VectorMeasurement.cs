namespace LibSkydra
{
	public class VectorMeasurement : tfbScriptObject
	{
		[igTStaticMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_interface", 0xFFFF)]
		public static igObject _interface;
		public VectorMeasurement(IGZ igz) : base(igz) {}
	}
}