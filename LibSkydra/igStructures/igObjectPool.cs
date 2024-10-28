using HashDepot;

namespace LibSkydra
{
	public static class igObjectPool
	{
		static Dictionary<ulong, igObject> objects = new Dictionary<ulong, igObject>();
		static Dictionary<uint, igArchive> igas = new Dictionary<uint, igArchive>();
		static List<IGZ> igzs = new List<IGZ>();

		public static void AddObjects(IGZ igz, string path)
		{
			if(!igzs.Any(x => x == igz))
			{
				igzs.Add(igz);
				for(int i = 0; i < igz.nameList.count; i++)
				{
					objects.Add(((igHash.Hash(Path.GetFileName(igz.archive == null ? igz.name : igz.archive.GetFileName(path)))) << 0x20) + igz.nameList.tdata[i].hash, igz.objectList.tdata[i]);
				}
			}
		}
		public static IGZ? LoadIGZ(string path)
		{
			Util.FixDependancyName(path, out string volume, out string file);
			IGZ? igz = null;
			if(!string.IsNullOrEmpty(volume))
			{
				igArchive iga = LoadIGA(volume);
				MemoryStream ms = new MemoryStream();
				iga.ExtractFile(file, ms);
				igz = new IGZ(ms, iga);
			}
			else
			{
				Console.WriteLine($"Searching through {igas.Count} iga(s)");
				foreach(KeyValuePair<uint, igArchive> kvp in igas)
				{
					if(kvp.Value.HasFile(file))
					{
						Console.WriteLine("Found file in archive");
						MemoryStream ms = new MemoryStream();
						kvp.Value.ExtractFile(file, ms);
						igz = new IGZ(ms, kvp.Value);
						break;
					}
				}
			}
			Console.WriteLine($"{(igz == null ? "Failed" : "Succeeded")} in loading IGZ {path} => {volume} ; {file}");
			if(igz != null)
			{
				AddObjects(igz, file);
			}
			return igz;
		}
		public static igArchive LoadIGA(string path)
		{
			uint hash = igHash.Hash(path);
			igArchive iga;
			if(igas.ContainsKey(hash))
			{
				iga = igas[hash];
			}
			else
			{
				iga = new igArchive(path);
				igas.Add(hash, iga);
			}
			return iga;
		}
	}
}