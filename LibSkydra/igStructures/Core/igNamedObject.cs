namespace LibSkydra
{
	public class igNamedObject : igObject
	{
		[igStringMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_name", 0x08)]
		public string name;
		public igNamedObject(IGZ parent) : base(parent){}
		public override void ReadFields()
		{
			base.ReadFields();
			Console.WriteLine($"name: {name}");
		}
	}
}