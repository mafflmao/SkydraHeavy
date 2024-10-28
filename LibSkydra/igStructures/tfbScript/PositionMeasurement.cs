namespace LibSkydra
{
	public class PositionMeasurement : VectorMeasurement
	{
		[igTStaticMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_interface", 0xFFFF)]
		public static igObject _interface;
		public PositionMeasurement(IGZ igz) : base(igz) {}
	}
}