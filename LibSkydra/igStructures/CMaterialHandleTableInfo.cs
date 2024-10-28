namespace LibSkydra
{
	public class CMaterialHandleTableInfo : igInfo
	{
		[igObjectRefMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_handleTable", 0x14)]
		public igObject handleTable;

		public CMaterialHandleTableInfo(IGZ igz) : base(igz){}
	}
}