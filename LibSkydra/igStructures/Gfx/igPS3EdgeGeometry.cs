namespace LibSkydra
{
	public class igPS3EdgeGeometry : igPS3EdgeGeometrySegmentList
	{
		[igBoolMetaField(0xFF, IG_CORE_PLATFORM.PS3, "_isMorphed", 0x18)]
		public bool isMorphed;

		[igBoolMetaField(0xFF, IG_CORE_PLATFORM.PS3, "_isSkinned", 0x19)]
		public bool isSkinned;

		[igUnsignedIntMetaField(0xFF, IG_CORE_PLATFORM.PS3, "_hashCode", 0x1C)]
		public uint hashCode;

		public igPS3EdgeGeometry(IGZ igz) : base(igz){}

		public void ExtractGeometry(out uint[][] indices, out float[][] vertices)
		{
			indices = new uint[count][];
			vertices = new float[count][];

			for(int i = 0; i < count; i++)
			{
				igPS3EdgeGeometrySegment segment = tdata[i] as igPS3EdgeGeometrySegment;

				//use spuConfigInfo

				parent.sh.Seek(segment.spuConfigInfo.dataOffset + 0x08);
				Console.WriteLine($"EDGE Header at {segment.spuConfigInfo.dataOffset.ToString("X08")}");
				uint vertexCount = parent.sh.ReadUInt16();
				uint indexCount = parent.sh.ReadUInt16();

				vertices[i] = new float[vertexCount * 8];

				//Decompress Indices
				//use indexes
				
				DecompressIndices(segment, indexCount, out indices[i]);

				//Read Vertices
				//use spuVertexes0

				Console.WriteLine($"{vertexCount.ToString("X08")} vertices");
				Console.WriteLine($"{indexCount.ToString("X08")} indices");

				uint stride = segment.spuVertexes0.dataLength / vertexCount;

				Console.WriteLine($"_spuVertexes0    at {segment.spuVertexes0.dataOffset.ToString("X08")}, Length {segment.spuVertexes0.dataLength.ToString("X08")}, stride {(segment.spuVertexes0.dataLength / vertexCount).ToString("X08")}");
				Console.WriteLine($"_spuVertexes1    at {segment.spuVertexes1.dataOffset.ToString("X08")}, Length {segment.spuVertexes1.dataLength.ToString("X08")}, stride {(segment.spuVertexes1.dataLength / vertexCount).ToString("X08")}");
				Console.WriteLine($"_rsxOnlyVertexes at {segment.rsxOnlyVertexes.dataOffset.ToString("X08")}, Length {segment.rsxOnlyVertexes.dataLength.ToString("X08")}, stride {(segment.rsxOnlyVertexes.dataLength / vertexCount).ToString("X08")}");

				StreamHelper posvertexsh = null;
				posvertexsh = new StreamHelper(new MemoryStream(segment.spuVertexes0.data), StreamHelper.Endianness.Big);
				StreamHelper uvvertexsh = new StreamHelper(new MemoryStream(segment.rsxOnlyVertexes.data), StreamHelper.Endianness.Big);
				StreamHelper normalvertexsh = new StreamHelper(new MemoryStream(segment.spuVertexes1.data), StreamHelper.Endianness.Big);

				string vertext = string.Empty;	//I like to think i'm funny by naming this vertext
				string faceText = string.Empty;

				bool useNormals = false;
				if(segment.spuVertexes1.dataLength / vertexCount < 0x06)
				{
					useNormals = false;
					Console.WriteLine("WARNING, UNIMPLEMENTED NORMALS, SKIPPING NORMALS");
				}
				for(uint j = 0; j < vertexCount; j++)
				{
					//Console.WriteLine($"Reading verts, at {vertexsh.BaseStream.Position.ToString("X08")} / {segment.rsxOnlyVertexes.dataLength.ToString("X08")}");
					posvertexsh.Seek(stride * j);
					vertices[i][j * 8 + 0] = posvertexsh.ReadSingle();
					vertices[i][j * 8 + 1] = posvertexsh.ReadSingle();
					vertices[i][j * 8 + 2] = posvertexsh.ReadSingle();

					vertext += $"v {vertices[i][j * 8 + 0].ToString("F6")} {vertices[i][j * 8 + 1].ToString("F6")} {vertices[i][j * 8 + 2].ToString("F6")}\n";

					if(parent.version == 0x07)
					{
						//DKDave on the xentax discord helped me out with uvs
						uvvertexsh.Seek(0x0C * j + 0x08);

						vertices[i][j * 8 + 3] = (float)uvvertexsh.ReadHalf();
						vertices[i][j * 8 + 4] = (float)uvvertexsh.ReadHalf();

					}
					else if (parent.version == 0x08)
					{
						uvvertexsh.Seek((segment.rsxOnlyVertexes.dataLength / vertexCount) * j);
						vertices[i][j * 8 + 3] = (float)uvvertexsh.ReadHalf();
						vertices[i][j * 8 + 4] = (float)uvvertexsh.ReadHalf();
					}
					vertext += $"vt {vertices[i][j * 8 + 3].ToString("F6")} {vertices[i][j * 8 + 4].ToString("F6")}\n";

					if(useNormals)
					{
						if(parent.version == 0x08)
						{
							normalvertexsh.Seek((segment.spuVertexes1.dataLength / vertexCount) * j);
							vertices[i][j * 8 + 5] = (float)normalvertexsh.ReadInt16();
							vertices[i][j * 8 + 6] = (float)normalvertexsh.ReadInt16();
							vertices[i][j * 8 + 7] = (float)normalvertexsh.ReadInt16();
						}

						vertext += $"vn {vertices[i][j * 8 + 5].ToString("F6")} {vertices[i][j * 8 + 6].ToString("F6")} {vertices[i][j * 8 + 7].ToString("F6")}\n";
					}
				}

				for(uint j = 0; j < indexCount; j += 3)
				{
					if(useNormals)
					{
						faceText += $"f {indices[i][j] + 1}/{indices[i][j] + 1}/{indices[i][j] + 1} {indices[i][j + 1] + 1}/{indices[i][j + 1] + 1}/{indices[i][j + 1] + 1} {indices[i][j + 2] + 1}/{indices[i][j + 2] + 1}/{indices[i][j + 2] + 1}\n";
					}
					else
					{
						faceText += $"f {indices[i][j] + 1}/{indices[i][j] + 1} {indices[i][j + 1] + 1}/{indices[i][j + 1] + 1} {indices[i][j + 2] + 1}/{indices[i][j + 2] + 1}\n";
					}
					//faceText += $"f {indices[i][j] + 1} {indices[i][j + 1] + 1} {indices[i][j + 2] + 1}\n";
				}

				File.WriteAllText($"{offset.ToString("X08")}_{i.ToString("X04")}.obj", vertext + faceText);

				posvertexsh.Close();
				posvertexsh.Dispose();
			}
		}
		//Thanks to chroxx for reverse engineering this. (https://github.com/Danilodum/noesis-plugins-official/blob/master/chrrox/import/beta/psa.py)
		private void DecompressIndices(igPS3EdgeGeometrySegment segment, uint indexCount, out uint[] indexBuffer)
		{
			parent.sh.Seek(segment.indexes.dataOffset);
			uint numIndices = parent.sh.ReadUInt16();
			int indexBase = (int)parent.sh.ReadUInt16();
			uint sequenceSize = parent.sh.ReadUInt16();
			byte indexBitSize = parent.sh.ReadByte();

			parent.sh.Seek(segment.indexes.dataOffset + 0x08);

			uint sequenceCount = sequenceSize * 8;
			byte[] sequenceBytes = parent.sh.ReadBytes((int)sequenceSize);	//array of 1 bit values
			StreamHelper sequenceStream = new StreamHelper(new MemoryStream(sequenceBytes), StreamHelper.Endianness.Big);

			uint triangleCount = indexCount / 3;
			uint triangleSize = ((triangleCount * 2) + 7) / 8;
			byte[] triangleBytes = parent.sh.ReadBytes((int)triangleSize);	//array of 2 bit values
			StreamHelper triangleStream = new StreamHelper(new MemoryStream(triangleBytes), StreamHelper.Endianness.Big);

			uint indicesSize = (numIndices * indexBitSize) + 7 / 8;
			byte[] indicesBytes = parent.sh.ReadBytes((int)indicesSize);	//array of indexBitSize bit values
			StreamHelper indicesStream = new StreamHelper(new MemoryStream(indicesBytes), StreamHelper.Endianness.Big);

			int[] deltaIndices = new int[numIndices];
			for(uint i = 0; i < numIndices; i++)
			{
				int value = (int)indicesStream.ReadUIntN(indexBitSize);
				value -= indexBase;
				if(i > 7)
				{
					value += deltaIndices[i - 8];
				}
				deltaIndices[i] = value;
			}

			//create sequence indices

			uint[] inputIndices = new uint[sequenceCount];
			uint sequencedIndex = 0;
			uint unorderedIndex = 0;
			for(int i = 0; i < sequenceCount; i++)
			{
				bool value = sequenceStream.ReadBit();
				if(!value)
				{
					inputIndices[i] = sequencedIndex;
					sequencedIndex++;
				}
				else
				{
					inputIndices[i] = (uint)deltaIndices[unorderedIndex];
					unorderedIndex++;
				}
			}

			//create triangle indices

			uint[] outputIndices = new uint[triangleCount * 3];
			uint currentIndex = 0;
			uint[] triangleIndices = new uint[3];
			for(int i = 0; i < triangleCount; i++)
			{
				uint value = (uint)triangleStream.ReadUIntN(2);

				switch(value)
				{
					case 0:
					case 1:
						triangleIndices[1 - value] = triangleIndices[2];
						triangleIndices[2] = inputIndices[currentIndex];
						currentIndex++;
						break;
					case 2:
						uint tempIndex = triangleIndices[0];
						triangleIndices[0] = triangleIndices[1];
						triangleIndices[1] = tempIndex;
						triangleIndices[2] = inputIndices[currentIndex];
						currentIndex++;
						break;
					case 3:
						triangleIndices[0] = inputIndices[currentIndex];
						currentIndex++;
						triangleIndices[1] = inputIndices[currentIndex];
						currentIndex++;
						triangleIndices[2] = inputIndices[currentIndex];
						currentIndex++;
						break;
				}

				outputIndices[i * 3 + 0] = triangleIndices[0];
				outputIndices[i * 3 + 1] = triangleIndices[1];
				outputIndices[i * 3 + 2] = triangleIndices[2];
			}
			indexBuffer = outputIndices;

			//Debug stuff
			byte[] ints = new byte[outputIndices.Length * 4];
			Buffer.BlockCopy(outputIndices, 0, ints, 0, ints.Length);
			for(int i = 0; i < ints.Length; i += 4)
			{
				Array.Reverse(ints, i, 4);
			}
			File.WriteAllBytes($"{segment.offset.ToString("X08")}_indices.dat", ints);
		}
	}
}