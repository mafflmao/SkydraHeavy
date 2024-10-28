namespace LibSkydra
{
	public class tfbEntityInfo : tfbInfo
	{
		[igObjectRefMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_drawables", 0x14)]
		public DrawableList drawables;

		[igObjectRefMetaField(0x08, IG_CORE_PLATFORM.DEFAULT, "_entities", 0x18)]
		public igObject entities;

		public tfbEntityInfo(IGZ igz) : base (igz){}

	}

	//It's here cos it's meant to be a nested class, but doing so would make its typename LibSkydra.tfbEntityInfo+DrawableList for some reason so yeah that can't work
	public class DrawableList : igObjectList
	{
		public DrawableList(IGZ igz) : base (igz){}
	}

	//See above
	public class Drawable : igObject
	{

		public Drawable(IGZ igz) : base(igz){}
	}

}