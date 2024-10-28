namespace LibSkydra
{
    public class IGZ
    {
        public uint version;
        public uint typeHash;
        public uint numFixups;
        public string name = string.Empty;
        public IG_CORE_PLATFORM platform;
        public IGZSectionHeader[] sections = new IGZSectionHeader[0x20];        //The game has a max of 0x20, bit of a waste of memory on my part tho ngl

        public List<string> typeNames = new List<string>();
        public List<string> stringList = new List<string>();
        public List<igHandle> externalList = new List<igHandle>();
        public Dictionary<ulong, igObject> objects = new Dictionary<ulong, igObject>(); //Read from RVTB, key is the offset from the RVTB, value is the igObject at said offset
        public List<igMemory> memoryHandles = new List<igMemory>();
        public ushort[] metaSizes;
        public ulong[] runtimeOffsets;
        public ulong[] runtimeStrings;
        public ulong[] runtimeExternals;
        public ulong[] runtimeMemoryHandles;
        public ulong[] runtimeHandles;
        public ulong[] root;

        public EXID exid = new EXID();
        public EXNM exnm = new EXNM();
        public TDEP tdep = new TDEP();

        public igObjectList objectList;
        public igNameList nameList;

        public StreamHelper sh;
        public igArchive? archive;

        public IGZ(Stream stream, igArchive? archive = null, bool loadDependancies = true)
        {
            if (stream is FileStream)
            {
                name = (stream as FileStream).Name;
            }
            this.archive = archive;

            sh = new StreamHelper(stream, StreamHelper.Endianness.Little);

            uint magic = sh.ReadUInt32();
            if (magic == 0x49475A01) sh._endianness = StreamHelper.Endianness.Little;
            else if (magic == 0x015A4749) sh._endianness = StreamHelper.Endianness.Big;
            else
            {
                FileStream debugfs = File.Open("invalid.igz", FileMode.Create, FileAccess.ReadWrite);
                sh.BaseStream.CopyTo(debugfs);
                debugfs.Close();
                sh.Close();
                throw new Exception("Invalid IGZ file");
            }
            version = sh.ReadUInt32();
            typeHash = sh.ReadUInt32();

            if (version >= 0x07)
            {
                ReadPlatform();
                numFixups = sh.ReadUInt32();
            }
            else
            {
                sh.Seek(0x10);
            }

            for (uint i = 0; i < 0x20; i++)
            {
                if (version >= 0x07)
                {
                    sections[i].unknown = sh.ReadUInt32();
                    sections[i].offset = sh.ReadUInt32();
                    sections[i].length = sh.ReadUInt32();
                    sections[i].alignment = sh.ReadUInt32();
                }
                else
                {
                    sections[i].offset = sh.ReadUInt32();
                    sections[i].length = sh.ReadUInt32();
                    sections[i].alignment = sh.ReadUInt32();
                    sections[i].unknown = sh.ReadUInt32();
                }

                if (sections[i].offset == 0x00) break;
            }


            ProcessFixupSections();

            if (root.Length > 1) throw new Exception("WHY MUST THIS ENGINE BE SO HORRIBLE IT HAS TWO igObjectLists WHAT THE HELL");

            objectList = (igObjectList)objects[root[0]];

            foreach (KeyValuePair<ulong, igObject> kvp in objects)
            {
                sh.Seek(kvp.Key);
                kvp.Value.ReadFields();
            }

            if (loadDependancies)
            {
                LoadDependancies();
            }
        }

        //See IG_CORE_PLATFORM.cs
        private void ReadPlatform()
        {
            uint tempPlatform = 0;

            if (version <= 0x06)
            {
                tempPlatform = sh.ReadUInt16();
            }
            else
            {
                tempPlatform = sh.ReadUInt32();
            }

            switch (version)
            {
                case 0x06:
                    switch (tempPlatform)
                    {
                        case 0x00: platform = IG_CORE_PLATFORM.DEFAULT; break;
                        case 0x01: platform = IG_CORE_PLATFORM.WIN32; break;
                        case 0x02: platform = IG_CORE_PLATFORM.WII; break;
                        case 0x03: platform = IG_CORE_PLATFORM.DEPRECATED; break;
                        case 0x04: platform = IG_CORE_PLATFORM.ASPEN; break;
                        case 0x05: platform = IG_CORE_PLATFORM.XENON; break;
                        case 0x06: platform = IG_CORE_PLATFORM.PS3; break;
                        case 0x07: platform = IG_CORE_PLATFORM.OSX; break;
                        case 0x08: platform = IG_CORE_PLATFORM.WIN64; break;
                        case 0x09: platform = IG_CORE_PLATFORM.CAFE; break;
                        case 0x0A: platform = IG_CORE_PLATFORM.NGP; break;
                        case 0x0B: platform = IG_CORE_PLATFORM.ANDROID; break;
                        case 0x0C: platform = IG_CORE_PLATFORM.MARMALADE; break;
                        case 0x0D: platform = IG_CORE_PLATFORM.MAX; break;
                    }
                    break;
                case 0x07:
                case 0x08:
                case 0x09:
                    switch (tempPlatform)
                    {
                        case 0x00: platform = IG_CORE_PLATFORM.DEFAULT; break;
                        case 0x01: platform = IG_CORE_PLATFORM.WIN32; break;
                        case 0x02: platform = IG_CORE_PLATFORM.WII; break;
                        case 0x03: platform = IG_CORE_PLATFORM.DURANGO; break;
                        case 0x04: platform = IG_CORE_PLATFORM.ASPEN; break;
                        case 0x05: platform = IG_CORE_PLATFORM.XENON; break;
                        case 0x06: platform = IG_CORE_PLATFORM.PS3; break;
                        case 0x07: platform = IG_CORE_PLATFORM.OSX; break;
                        case 0x08: platform = IG_CORE_PLATFORM.WIN64; break;
                        case 0x09: platform = IG_CORE_PLATFORM.CAFE; break;
                        case 0x0A: platform = IG_CORE_PLATFORM.RASPI; break;
                        case 0x0B: platform = IG_CORE_PLATFORM.ANDROID; break;
                        case 0x0C:
                            if (version == 0x07) platform = IG_CORE_PLATFORM.MARMALADE;
                            else if (version == 0x08) platform = IG_CORE_PLATFORM.DEPRECATED;
                            else platform = IG_CORE_PLATFORM.ASPEN64;
                            break;
                        case 0x0D: platform = IG_CORE_PLATFORM.LGTV; break;
                        case 0x0E: platform = IG_CORE_PLATFORM.PS4; break;
                        case 0x0F: platform = IG_CORE_PLATFORM.WP8; break;
                        case 0x10: platform = IG_CORE_PLATFORM.LINUX; break;
                        case 0x11: platform = IG_CORE_PLATFORM.MAX; break;
                    }
                    break;
                default:
                    platform = IG_CORE_PLATFORM.DEFAULT;
                    Console.WriteLine($"WARNING: IG_CORE_PLATFORM FOR VERSION {version} NOT IMPLEMENTED");
                    break;
            }
        }

        private async void ProcessFixupSections()
        {
            uint bytesPassed = version <= 0x06 ? 0x1Cu : 0x00u;

            if (version <= 0x06)
            {
                sh.Seek(sections[0].offset + 0x08);
                ReadPlatform();
                numFixups = sh.ReadUInt32(sections[0].offset + 0x10);
            }

            for (uint i = 0; i < numFixups; i++)
            {
                sh.Seek(sections[0].offset + bytesPassed);
                uint magic = sh.ReadUInt32();
                if (version <= 0x06) sh.Seek(0x08, SeekOrigin.Current);
                uint count = sh.ReadUInt32();
                uint length = sh.ReadUInt32();
                uint dataStart = sh.ReadUInt32();

                sh.Seek(sections[0].offset + bytesPassed + dataStart);

                ProcessFixupSection(magic, count, length, dataStart);

                bytesPassed += length;
            }
        }

        private async void ProcessFixupSection(uint magic, uint count, uint length, uint dataStart)
        {
            switch (magic)
            {
                //TMET: MetaType table
                case 0x00:
                case 0x54454D54:
                    typeNames.Capacity = (int)count;
                    for (uint i = 0; i < count; i++)
                    {
                        typeNames.Add(sh.ReadString());
                        while (sh.ReadByte() == 0x00) { }
                        sh.BaseStream.Seek(-0x01, SeekOrigin.Current);
                    }
                    break;
                //TSTR: String Table
                case 0x01:
                case 0x52545354:
                    stringList.Capacity = (int)count;
                    for (uint i = 0; i < count; i++)
                    {
                        stringList.Add(sh.ReadString());
                        while (sh.ReadByte() == 0x00) { }
                        sh.BaseStream.Seek(-0x01, SeekOrigin.Current);
                    }
                    break;
                //EXID: External Identifiers
                case 0x02:
                case 0x44495845:
                    externalList.Capacity = (int)count;
                    for (uint i = 0; i < count; i++)
                    {
                        uint hash = sh.ReadUInt32();
                        uint type = sh.ReadUInt32();
                        externalList.Add(new igHandle { hash = hash, type = type });
                    }
                    break;
                //EXNM: External Named Handles
                case 0x03:
                case 0x4D4E5845:
                    break;
                //case 0x04: (Unknown, Couldn't find any uses)
                //RVTB: Runtime Virtual Tables
                case 0x05:
                case 0x42545652:
                    Util.ReadPackedInts(sh.ReadBytes((int)(length - dataStart)), out ulong[] offsets, count, this);
                    for (uint i = 0; i < count; i++)
                    {
                        objects.Add(offsets[i], (igObject)igObject.GetObjectAtOffset(this, offsets[i]));
                    }
                    break;
                //ROFS: Runtime Offsets
                case 0x06:              //Double check
                case 0x53464F52:
                    Util.ReadPackedInts(sh.ReadBytes((int)(length - dataStart)), out runtimeOffsets, count, this);
                    break;
                //REXT: Runtime Externals (Identifiers)
                case 0x07:
                case 0x54584552:
                    Util.ReadPackedInts(sh.ReadBytes((int)(length - dataStart)), out runtimeExternals, count, this);
                    break;
                //case 0x09: (Unknown, Couldn't find any uses)
                //TMHN: Memory Handle Table
                case 0x0A:
                case 0x4E484D54:
                    memoryHandles.Capacity = (int)count;
                    uint position = (uint)sh.BaseStream.Position;
                    byte pointerSize = (byte)igCore.getSizeOfPointer(platform);
                    for (uint i = 0; i < count; i++)
                    {
                        sh.Seek(position + i * pointerSize * 2);

                        igMemory mem;
                        mem.dataLength = sh.ReadUInt32() & 0x00FFFFFF;
                        if (pointerSize == 8)
                        {
                            sh.Seek(0x04, SeekOrigin.Current);
                        }
                        mem.dataOffset = ReadOffset();

                        sh.Seek(mem.dataOffset);
                        mem.data = sh.ReadBytes((int)mem.dataLength);
                        memoryHandles.Add(mem);
                    }
                    break;
                //TDEP: Dependancy Table
                case 0x50454454:
                    break;
                //MTSZ: MetaSizes
                case 0x0C:
                case 0x5A53544D:
                    metaSizes = new ushort[count];
                    break;
                //RSTR/RSTT: Runtime Strings
                //case 0x0D: (Unknown, Couldn't find any uses)
                case 0x52545352:        //RSTR
                case 0x54545352:        //RSTT
                    Util.ReadPackedInts(sh.ReadBytes((int)(length - dataStart)), out runtimeStrings, count, this);
                    break;
                //RMHN: Runtime Memory Handles
                case 0x0B:
                case 0x4E484D52:
                    Util.ReadPackedInts(sh.ReadBytes((int)(length - dataStart)), out runtimeMemoryHandles, count, this);
                    break;
                //RHND: Runtime Handles
                //case 0x0B:
                case 0x444E4852:
                    Util.ReadPackedInts(sh.ReadBytes((int)(length - dataStart)), out runtimeHandles, count, this);
                    break;
                //ROOT: root
                case 0x08:
                case 0x544F4F52:
                    Util.ReadPackedInts(sh.ReadBytes((int)(length - dataStart)), out root, count, this);
                    break;
                //ONAM: igNameList pointer
                case 0x4D414E4F:
                    sh.Seek(FixOffset(sh.ReadUInt32()));
                    nameList = igObject.ReadWithoutFields<igNameList>(this);
                    nameList.ReadFields();
                    break;
                //case 0x0F: (Unknown, Packed Ints)
                //case 0x10: (Unknown, Packed Ints)
                default:
                    Console.WriteLine($"No case for fixup number {magic.ToString("X08")}");
                    break;
            }
        }

        public ulong FixOffset(ulong offset, bool useOld = false)
        {
            if (version <= 0x06) return (sections[(offset >> 0x18) + 1].offset + (offset & 0x00FFFFFF));
            return (sections[(offset >> 0x1B) + 1].offset + (offset & 0x07FFFFFF));
        }
        public ulong SerializeOffset(ulong offset)
        {
            int sectionIndex = Array.FindIndex<IGZSectionHeader>(sections, x => x.offset > offset) - 1;
            if (sectionIndex < 0) sectionIndex = sections.Length - 1;
            if (version <= 0x06) return (ulong)((sectionIndex - 1) << 0x18) + (offset - sections[sectionIndex].offset);
            else return (ulong)((sectionIndex - 1) << 0x1B) + (offset - sections[sectionIndex].offset);
        }

        public ulong ReadOffset()
        {
            ulong pointerSize = igCore.getSizeOfPointer(platform);
            ulong pointer = 0;
            if (pointerSize == 4)
            {
                pointer = sh.ReadUInt32();
            }
            else
            {
                pointer = sh.ReadUInt64();
            }
            return FixOffset(pointer);
        }

        public uint GetSerializableFieldsHash()
        {
            return 0;
        }
        public void LoadDependancies()
        {
            for (uint i = 0; i < tdep.count; i++)
            {
                igObjectPool.LoadIGZ(tdep.dependancies[i].Item2);
            }
        }
    }

    public struct IGZSectionHeader
    {
        public uint offset;
        public uint length;
        public uint alignment;
        public uint unknown;
    }
}