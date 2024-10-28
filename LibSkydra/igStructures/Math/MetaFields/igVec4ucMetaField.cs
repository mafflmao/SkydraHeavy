namespace LibSkydra
{
	public class igVec4ucMetaField : igMetaField
	{
		public igVec4ucMetaField(uint applicableVersion, IG_CORE_PLATFORM platform, string name, uint offset) : base(applicableVersion, platform, name, offset){}

		public override object ReadField(IGZ igz)
		{
			Vector4 vec4 = new Vector4();
			vec4.X = igz.sh.ReadByte();
			vec4.Y = igz.sh.ReadByte();
			vec4.Z = igz.sh.ReadByte();
			vec4.W = igz.sh.ReadByte();
			Console.WriteLine("WARNING: igVec4ucMetaField IS NOT PROPERLY IMPLEMENTED");
			return vec4;
		}
	}
}