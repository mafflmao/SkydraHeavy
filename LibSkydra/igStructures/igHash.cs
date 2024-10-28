using HashDepot;
using System.Text;

namespace LibSkydra
{
	public static class igHash
	{
		public static uint Hash(string input)
		{
			Console.WriteLine($"hashing {input}");
			return Fnv1a.Hash32(Encoding.ASCII.GetBytes(input));
		}
	}
}