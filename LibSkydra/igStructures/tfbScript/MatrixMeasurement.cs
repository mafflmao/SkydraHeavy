namespace LibSkydra
{
	public class MatrixMeasurement : PositionMeasurement
	{
		[igTStaticMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_interface", 0xFFFF)]
		public static igObject _interface;
		public MatrixMeasurement(IGZ igz) : base(igz) {}
	}
}