//It's a singular igStructMetaField called _idCode but i didn't understand how to find the struct so i gave up for now

namespace LibSkydra
{
	public class tfbPhysicsModel : tfbModelInfo
	{
		[igRawRefMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_idCode", 0x34)]
		public object idCode;
		public tfbPhysicsModel(IGZ igz) : base (igz){}
	}
}