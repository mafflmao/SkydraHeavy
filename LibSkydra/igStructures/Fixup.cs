//Note to all: this isn't actually an igStructure, it's just a seperate file for the sake of neatness

//Note to self: clean up this code
//Note to self: seperate the unpack ints function since it's not exclusive to RVTB

//TO BE REMOVED

namespace LibSkydra
{
	public class Fixup : IComparable<Fixup>
	{
		public uint magicNumber;
		public uint offset;
		public uint count;
		public uint length;
		public uint startOfData;
		public IGZ _parent;

		public int CompareTo(Fixup other)
		{
			return this.magicNumber.CompareTo(other.magicNumber);
		}

		public virtual void Process(StreamHelper sh, IGZ parent)
		{
			_parent = parent;
			sh.BaseStream.Seek(-4, SeekOrigin.Current);
			magicNumber = sh.ReadUInt32();
			offset      = (uint)(sh.BaseStream.Position - 4);

			if(magicNumber <= 0x10)		//Old fixups
			{
				sh.ReadUInt32();
				sh.ReadUInt32();
			}
			else						//New fixups
			{
				if(sh._endianness == StreamHelper.Endianness.Big)
				{
					magicNumber = BitConverter.ToUInt32(BitConverter.GetBytes(magicNumber).Reverse().ToArray());
				}
			}

			count 		 = sh.ReadUInt32();
			length       = sh.ReadUInt32();
			startOfData  = sh.ReadUInt32();				
			sh.BaseStream.Seek(offset + startOfData, SeekOrigin.Begin);
		}
	}

	//String List
	public class TSTR : Fixup
	{
		public string[] strings;

		public override void Process(StreamHelper sh, IGZ parent)
		{
			base.Process(sh, parent);
			strings = new string[count];

			for(uint i = 0; i < count; i++)
			{
				strings[i] = sh.ReadString();
				while(sh.ReadByte() == 0x00){}
				sh.BaseStream.Seek(-0x01, SeekOrigin.Current);
			}
		}
	}

	//Type Names
	public class TMET : Fixup
	{
		public string[] metatypes;

		public override void Process(StreamHelper sh, IGZ parent)
		{
			base.Process(sh, parent);
			metatypes = new string[count];

			for(uint i = 0; i < count; i++)
			{
				metatypes[i] = sh.ReadString();
				while(sh.ReadByte() == 0x00){}
				sh.BaseStream.Seek(-0x01, SeekOrigin.Current);
			}
		}
	}

	//Dependencies
	public class TDEP : Fixup
	{
		public Tuple<string, string>[] dependancies;

		public override void Process(StreamHelper sh, IGZ parent)
		{
			base.Process(sh, parent);
			dependancies = new Tuple<string, string>[count];

			for(uint i = 0; i < count; i++)
			{
				string igz = sh.ReadString();
				while(sh.ReadByte() == 0x00){}
				sh.BaseStream.Seek(-0x01, SeekOrigin.Current);
				string file = sh.ReadString();
				while(sh.ReadByte() == 0x00){}
				sh.BaseStream.Seek(-0x01, SeekOrigin.Current);
				dependancies[i] = new Tuple<string, string>(igz, file);
			}
		}
	}

	//Meta Sizes
	public class MTSZ : Fixup
	{
		public uint[] metaSizes;

		public override void Process(StreamHelper sh, IGZ parent)
		{
			base.Process(sh, parent);
			metaSizes = new uint[count];

			for(uint i = 0; i < count; i++)
			{
				metaSizes[i] = sh.ReadUInt32();
			}
		}
	}

	//External ID
	public class EXID : Fixup
	{
		public uint[] hashes;
		public uint[] types;

		public override void Process(StreamHelper sh, IGZ parent)
		{
			base.Process(sh, parent);
			hashes = new uint[count];
			types = new uint[count];

			for(uint i = 0; i < count; i++)
			{
				hashes[i] = sh.ReadUInt32();
				types[i]  = sh.ReadUInt32();
			}
		}
	}

	//Named Handle List
	public class EXNM : Fixup
	{
		public uint[] objectNames;
		public uint[] dependancyNames;

		public override void Process(StreamHelper sh, IGZ parent)
		{
			base.Process(sh, parent);
			objectNames = new uint[count];
			dependancyNames = new uint[count];

			for(uint i = 0; i < count; i++)
			{
				dependancyNames[i] = sh.ReadUInt32() & ~0x80000000;
				objectNames[i] = sh.ReadUInt32() & ~0x80000000;
			}
		}
	}

	//Thumbnails
	public class TMHN : Fixup
	{
		public uint[] sizes;
		public uint[] offsets;

		public override void Process(StreamHelper sh, IGZ parent)
		{
			base.Process(sh, parent);
			sizes = new uint[count];
			offsets = new uint[count];

			for(uint i = 0; i < count; i++)
			{
				sizes[i]   = (uint)(sh.ReadUInt32() & 0x00FFFFFF);
				uint rawOffset = sh.ReadUInt32();
				//offsets[i] = parent.FixOffset(rawOffset, parent.version <= 0x06);
			}
		}
	}

	//Root Virtual Table, points to igObjects
	public class RVTB : Fixup
	{
		public uint[] offsets;

		public override void Process(StreamHelper sh, IGZ parent)
		{
			base.Process(sh, parent);
			//Util.ReadPackedInts(sh.ReadBytes((int)(length - startOfData)), out offsets, count, parent);
		}
	}

	//Root String Table?, points to igStringMetaFields
	public class RSTR : Fixup
	{
		public uint[] offsets;

		public override void Process(StreamHelper sh, IGZ parent)
		{
			base.Process(sh, parent);
			//Util.ReadPackedInts(sh.ReadBytes((int)(length - startOfData)), out offsets, count, parent);
		}
	}

	//Root Offsets, points to all offsets
	public class ROFS : Fixup
	{
		public uint[] offsets;

		public override void Process(StreamHelper sh, IGZ parent)
		{
			base.Process(sh, parent);
			//Util.ReadPackedInts(sh.ReadBytes((int)(length - startOfData)), out offsets, count, parent);
		}
	}

	//Root something???
	public class RPID : Fixup
	{
		public uint[] offsets;

		public override void Process(StreamHelper sh, IGZ parent)
		{
			base.Process(sh, parent);
			//Util.ReadPackedInts(sh.ReadBytes((int)(length - startOfData)), out offsets, count, parent);
		}
	}

	//Root Externals?, points to EXID meta fields (technically certain igObjectRefMetaFields but that's kinda dumb ngl)
	public class REXT : Fixup
	{
		public uint[] offsets;

		public override void Process(StreamHelper sh, IGZ parent)
		{
			base.Process(sh, parent);
			//Util.ReadPackedInts(sh.ReadBytes((int)(length - startOfData)), out offsets, count, parent);
		}
	}

	//Root Handles, points to igHandleMetaFields
	public class RHND : Fixup
	{
		public uint[] offsets;

		public override void Process(StreamHelper sh, IGZ parent)
		{
			base.Process(sh, parent);
			//Util.ReadPackedInts(sh.ReadBytes((int)(length - startOfData)), out offsets, count, parent);
		}
	}

	//No Idea
	public class RNEX : Fixup
	{
		public uint[] offsets;

		public override void Process(StreamHelper sh, IGZ parent)
		{
			base.Process(sh, parent);
			//Util.ReadPackedInts(sh.ReadBytes((int)(length - startOfData)), out offsets, count, parent);
		}
	}

	//Root Memory Handles, points to igMemoryRefHandleMetaFields
	public class RMHN : Fixup
	{
		public uint[] offsets;

		public override void Process(StreamHelper sh, IGZ parent)
		{
			base.Process(sh, parent);
			//Util.ReadPackedInts(sh.ReadBytes((int)(length - startOfData)), out offsets, count, parent);
		}
	}

	//Literally just points to the igObjectList
	public class ROOT : Fixup
	{
		public uint[] offsets;

		public override void Process(StreamHelper sh, IGZ parent)
		{
			base.Process(sh, parent);
			//Util.ReadPackedInts(sh.ReadBytes((int)(length - startOfData)), out offsets, count, parent);
		}
	}
	//points to igNameList
	public class ONAM : Fixup
	{
		public uint namesOffset;

		public override void Process(StreamHelper sh, IGZ parent)
		{
			base.Process(sh, parent);
			//namesOffset = parent.FixOffset(sh.ReadUInt32());
		}
	}

}