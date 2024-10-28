namespace LibSkydra
{
	public class igVec2fMetaField : igMetaField
	{
		public igVec2fMetaField(uint applicableVersion, IG_CORE_PLATFORM platform, string name, uint offset) : base(applicableVersion, platform, name, offset){}

		public override object ReadField(IGZ igz)
		{
			Vector2 vec2 = new Vector2();
			vec2.X = igz.sh.ReadSingle();
			vec2.Y = igz.sh.ReadSingle();
			return vec2;
		}
	}
}