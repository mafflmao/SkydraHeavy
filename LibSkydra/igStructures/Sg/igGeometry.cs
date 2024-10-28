namespace LibSkydra
{
	public class igGeometry : igAttrSet
	{
		public igGeometry(IGZ igz) : base(igz){}

		public void ExtractGeometry(out uint[][] indices, out float[][] vertices)
		{
			throw new InvalidOperationException($"Platform {parent.platform.ToString()} is not supported");
		}
	}
}