namespace LibSkydra
{
	//This isn't real, it's here to help deal with the fact we can't use the StructLayout attribute to define size
	[AttributeUsage(AttributeTargets.Struct, Inherited = false, AllowMultiple = true)]
	public class igStruct : Attribute
	{
		public uint Size;

		public igStruct(uint size)
		{
			this.Size = size;
		}
	}
}