using System;
using System.Runtime.InteropServices;

namespace LibSkydra
{
	internal static class Util
	{
		public static void ReadPackedInts(byte[] bytes, out ulong[] offsets, uint count, IGZ parent)
		{
			offsets = new ulong[count];
			uint previousInt = 0;

			bool shiftMoveOrMask = false;

			unsafe
			{
				fixed(byte *fixedData = bytes)
				{
					byte* data = fixedData;
					for (int i = 0; i < count; i++)
					{
						uint currentByte;

						if (!shiftMoveOrMask)
						{
							currentByte = (uint)*data & 0xf;
							shiftMoveOrMask = true;
						}
						else
						{
							currentByte = (uint)(*data >> 4);
							data++;
							shiftMoveOrMask = false;
						}
						byte shiftAmount = 3;
						uint unpackedInt = currentByte & 7;
						while ((currentByte & 8) != 0)
						{
							if (!shiftMoveOrMask)
							{
								currentByte = (uint)*data & 0xf;
								shiftMoveOrMask = true;
							}
							else
							{
								currentByte = (uint)(*data >> 4);
								data++;
								shiftMoveOrMask = false;
							}
							unpackedInt = unpackedInt | (currentByte & 7) << (byte)(shiftAmount & 0x1f);
							shiftAmount += 3;
						}

						previousInt = (uint)(previousInt + (unpackedInt * 4) + (parent.version < 9 ? 4 : 0));
						offsets[i] = parent.FixOffset(previousInt);
					}
				}
			}
		}
		public static bool DoEndiannessSwap(StreamHelper sh)
		{
			return (sh._endianness == StreamHelper.Endianness.Little && BitConverter.IsLittleEndian) || (sh._endianness == StreamHelper.Endianness.Big && BitConverter.IsLittleEndian);
		}
		public static T StructFromBytes<T>(byte[] data)
		{
			GCHandle handle = GCHandle.Alloc(data, GCHandleType.Pinned);
			T read = Marshal.PtrToStructure<T>(handle.AddrOfPinnedObject());
			return read;
		}
		public static void ReadFields(object obj, IGZ parent, ulong offset)
		{
			FieldInfo[] fields = obj.GetType().GetFields();
			for(int i = 0; i < fields.Length; i++)
			{
				Attribute[] attributes = fields[i].GetCustomAttributes().ToArray();
				for(int j = 0; j < attributes.Length; j++)
				{
					if(attributes[j].GetType().IsSubclassOf(typeof(igMetaField)))
					{
						igMetaField metafield = attributes[j] as igMetaField;

						if(metafield.Offset == 0xFFFF) continue;

						if(metafield.ApplicableVersion != parent.version && metafield.ApplicableVersion != 0xFF) continue;
						if(metafield.Platform != parent.platform && metafield.Platform != IG_CORE_PLATFORM.DEFAULT) continue;

						parent.sh.Seek(offset + metafield.Offset);
						Console.WriteLine($"reading {metafield.Name} of type {attributes[j].GetType().ToString()} @ {parent.sh.BaseStream.Position.ToString("X08")}");

						Type t = attributes[j].GetType();
						
						fields[i].SetValue(obj, t.GetMethod("ReadField", new Type[]{typeof(IGZ)}).Invoke(attributes[j], new object? [] {parent}));
						break;
					}
				}
			}
		}
		public static List<T> InterpretDataArray<T>(IGZ parent, igMemory data, uint count)
		{
			List<T> tdata = new List<T>();
			int itemSize = (int)igCore.getSizeOfPointer(parent.platform);
			if(typeof(T).IsValueType)
			{
				itemSize = System.Runtime.InteropServices.Marshal.SizeOf<T>();
			}
			for(int i = 0; i < count; i++)
			{
				//TODO: clean up this code so it doesn't have repeated stuff as much
				//TODO: Add metafield support
				if(typeof(T).GetCustomAttributes().Any(x => x.GetType() == typeof(igStruct)))
				{
					uint tsize = (typeof(T).GetCustomAttributes().First(x => x.GetType() == typeof(igStruct)) as igStruct).Size;
					T tstruct = Activator.CreateInstance<T>();
					Console.WriteLine($"offset: {(data.dataOffset + (ulong)i * tsize).ToString("X08")}");
					object ostruct = (object)tstruct;
					Util.ReadFields(ostruct, parent, data.dataOffset + (ulong)i * tsize);
					tdata.Add((T)ostruct);
				}
				else if(typeof(T).IsValueType)
				{
					Console.WriteLine("Trying to read as value types");
					byte[] item = new byte[itemSize];
					Array.Copy(data.data, itemSize * i, item, 0, itemSize);
					if(Util.DoEndiannessSwap(parent.sh))
					{
						item.Reverse();
					}
					tdata.Add(Util.StructFromBytes<T>(item));
				}
				else if(typeof(igObject).IsAssignableFrom(typeof(T)))
				{
					byte[] item = new byte[itemSize];
					Array.Copy(data.data, i * itemSize, item, 0, itemSize);
					if(Util.DoEndiannessSwap(parent.sh))
					{
						Array.Reverse(item);
					}
					ulong rawOffset = 0;
					if(itemSize == 4) rawOffset = Util.StructFromBytes<uint>(item);
					else			  rawOffset = Util.StructFromBytes<ulong>(item);
					if(rawOffset == 0) continue;
					if((rawOffset & 0x80000000) != 0)
					{
						count--;
						Console.WriteLine("WARNING: SKIPPED LOADING OF igObject WITH UNNKOWN OFFSET");
						continue;
					}
					ulong objectRef = parent.FixOffset(rawOffset);
					if(typeof(T).IsAssignableFrom(parent.objects[objectRef].GetType()))
					{
						tdata.Add((T)(object)parent.objects[objectRef]);
						Console.WriteLine($"got igObject at {rawOffset.ToString("X08")} of type {parent.typeNames[(int)parent.objects[objectRef].typeIndex]}");
						((igObject)(object)tdata.Last()).ReadFields();
					}
					else
					{
						tdata.Add((T)(object)null);
					}
				}
			}
			return tdata;
		}

		static Dictionary<string, string> virtualVolumes = new Dictionary<string, string>
		{
			{"materials", "materialInstances"},
			{"textures", "textures"},
			{"shaders", "shaders"}
		};
		public static void FixDependancyName(string input, out string volume, out string file)
		{
			string correctedPath = string.Empty;
			int lastColon = input.LastIndexOf(':');
			string volumeName = input.Substring(0, lastColon);
			string fileName = input.Substring(lastColon + 1);
			if(virtualVolumes.ContainsKey(volumeName))
			{
				volumeName = virtualVolumes[volumeName];
				file = volumeName + fileName;
				volume = string.Empty;
			}
			else
			{
				if(volumeName.EndsWith(".pak"))
				{
					volume = volumeName;
					file = fileName.TrimStart('/', '\\');
				}
				else throw new Exception($"Missed virtual volume {volumeName}");
			}
		}
	}
}