namespace LibSkydra
{
	//TODO: double check namespace
	public class igMatrix44fMetaField : igMetaField
	{
		public igMatrix44fMetaField(uint applicableVersion, IG_CORE_PLATFORM platform, string name, uint offset) : base(applicableVersion, platform, name, offset){}

		public override object ReadField(IGZ igz)
		{
			Matrix4x4 mat44;
			mat44.M11 = igz.sh.ReadSingle();
			mat44.M12 = igz.sh.ReadSingle();
			mat44.M13 = igz.sh.ReadSingle();
			mat44.M14 = igz.sh.ReadSingle();
			mat44.M21 = igz.sh.ReadSingle();
			mat44.M22 = igz.sh.ReadSingle();
			mat44.M23 = igz.sh.ReadSingle();
			mat44.M24 = igz.sh.ReadSingle();
			mat44.M31 = igz.sh.ReadSingle();
			mat44.M32 = igz.sh.ReadSingle();
			mat44.M33 = igz.sh.ReadSingle();
			mat44.M34 = igz.sh.ReadSingle();
			mat44.M41 = igz.sh.ReadSingle();
			mat44.M42 = igz.sh.ReadSingle();
			mat44.M43 = igz.sh.ReadSingle();
			mat44.M44 = igz.sh.ReadSingle();
			return mat44;
		}
	}
}