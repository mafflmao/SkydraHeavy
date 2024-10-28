namespace Skydra
{
	//to retrieve an asset you hash the path to the file, for example "archivename.pak:/path/to.igz", shift this left by 32 bits, and add on the hash of the object's name
	//If the object has no name (for example in the TFBTool games), you would hash the file path the same way but you would add on the offset to the object instead
	public static class AssetManager
	{
		public static Dictionary<ulong, Texture> textures = new Dictionary<ulong, Texture>();

		public static Texture LoadTexture(string ddsPath)
		{
			FileStream ddsStream = File.Open(ddsPath, FileMode.Open);

			//Parse DDS Header

			BinaryReader br = new BinaryReader(ddsStream);
			br.BaseStream.Seek(0x0C, SeekOrigin.Begin);
			uint height = br.ReadUInt32();
			uint width = br.ReadUInt32();
			uint rawSize = br.ReadUInt32();
			br.BaseStream.Seek(0x1C, SeekOrigin.Begin);
			uint mipmapCount = br.ReadUInt32();
			br.BaseStream.Seek(0x54, SeekOrigin.Begin);
			uint formatID = br.ReadUInt32();
			//Right now only dxt1 and dxt5 are supported

			Texture texture = null;			//I couldn't be bothered to finish this
			ddsStream.Close();
			return texture;
		}
		public static Texture LoadTexture(igImage2 image)
		{
			return null;
		}
		public static ulong GetObjectNameHash(igObject obj)
		{
			uint objNameHash = obj.offset;
			return (((uint)obj.parent.name.GetHashCode()) << 32) + objNameHash;
		}
	}
}