namespace LibSkydra
{
	[AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = true)]
	public abstract class igMetaField : Attribute
	{
		public uint ApplicableVersion;		//If set to 0xFF, then it applies to all other verions
		public uint Offset;
		public IG_CORE_PLATFORM Platform;
		public string Name;

		public igMetaField(uint applicableVersion, IG_CORE_PLATFORM platform, string name, uint offset)
		{
			this.ApplicableVersion = applicableVersion;
			this.Offset = offset;
			this.Platform = platform;
			this.Name = name;
		}

		public abstract object ReadField(IGZ igz);
	}
}