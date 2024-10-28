namespace LibSkydra
{
	public class igObject
	{
		public uint typeIndex;
		public uint unknown;
		public uint offset;
		public IGZ parent;
		public uint size
		{
			get
			{
				return parent.metaSizes[typeIndex];
			}
		}
		public uint fakeSize
		{
			get
			{
				ulong[] offsets = parent.objects.Keys.ToArray();
				int objIndex = Array.FindIndex<ulong>(offsets, x => x == offset);
				if(objIndex + 1 == parent.objects.Count)
				{
					byte sectionIndex = 1;
					if(parent.version <= 0x06)
					{
						sectionIndex += (byte)(parent.SerializeOffset(offset) >> 0x18);
					}
					else
					{
						sectionIndex += (byte)(parent.SerializeOffset(offset) >> 0x1B);
					}
					if(sectionIndex < parent.sections.Length)
					{
						return (uint)parent.sh.BaseStream.Length - offset;
					}
					return parent.sections[sectionIndex + 1].offset - offset;
				}
				return (ushort)(offsets[objIndex + 1] - offset);
			}
		}

		public igObject(IGZ parent)
		{
			this.offset = (uint)parent.sh.BaseStream.Position;
			Console.WriteLine($"new {GetType().ToString()} from {offset.ToString("X08")}");
			this.typeIndex = parent.sh.ReadUInt32();
			this.unknown = parent.sh.ReadUInt32();
			this.parent = parent;
		}

		public static T ReadWithoutFields<T>(IGZ igz) where T : igObject
		{
			T obj = (T)Activator.CreateInstance(typeof(T), (IGZ)igz);
			if(obj.parent == null) throw new Exception("bruh");
			return obj;
		}
		public static object? GetObjectAtOffset(IGZ igz, ulong fixedOffset)
		{
			igz.sh.Seek(fixedOffset);
			igObject temp = new igObject(igz);
			Type? type = Type.GetType($"LibSkydra.{igz.typeNames[(int)temp.typeIndex]}");
			Console.WriteLine($"Reading {igz.typeNames[(int)temp.typeIndex]}");
			if(type == null) return temp;
			igz.sh.Seek(fixedOffset);
			object val = typeof(igObject).GetMethod("ReadWithoutFields").MakeGenericMethod(type).Invoke(null, new object[] {igz});
			return val;
		}

		public virtual void ReadFields()
		{
			Console.WriteLine($"Reading fields of {GetType()} at {offset.ToString("X08")}");
			Util.ReadFields(this, parent, offset);
		}
		public void DirectSerialize(byte[] data)
		{
			parent.sh.Seek(offset);
			parent.sh.BaseStream.Write(data);
		}

		public byte[] GetRawBytes(bool useFakeSize)
		{
			parent.sh.Seek(offset);
			if(!useFakeSize)
			{
				return parent.sh.ReadBytes((int)size);
			}
			else
			{
				return parent.sh.ReadBytes((int)fakeSize);
			}
		}

		public uint GetSerializableFieldsHash()
		{
			return 0;
		}
	}
}