namespace LibSkydra
{
	//This isn't real, it's here to help deal with the fact that classes may be able to inherit from others
	[AttributeUsage(AttributeTargets.Struct, Inherited = false, AllowMultiple = true)]
	public class igImplicitInheritance : Attribute
	{
		public igImplicitInheritance(uint size)
		{
		}
	}
}