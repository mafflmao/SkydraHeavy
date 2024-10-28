namespace LibSkydra
{
	public class igVectorMetaField : igMemoryRefMetaField
	{
		Type type;

		public igVectorMetaField(uint applicableVersion, IG_CORE_PLATFORM platform, string name, uint offset, Type type) : base(applicableVersion, platform, name, offset)
		{
			this.type = type;
		}

		public override object ReadField(IGZ igz)
		{
			uint count = igz.sh.ReadUInt32();
			igMemory mem = (igMemory)base.ReadField(igz);
			var vector = typeof(Util).GetMethod("InterpretDataArray").MakeGenericMethod(type).Invoke(null, new object[]{igz, mem, count});
			return vector;
		}
	}
}