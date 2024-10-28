namespace LibSkydra
{
	public class igPS3EdgeGeometrySegment : igObject
	{
		[igMemoryRefMetaField(0xFF, IG_CORE_PLATFORM.PS3, "_spuConfigInfo", 0x08)]
		public igMemory spuConfigInfo;
		[igMemoryRefMetaField(0xFF, IG_CORE_PLATFORM.PS3, "_indexes", 0x10)]
		public igMemory indexes;
		[igUnsignedShortArrayMetaField(0xFF, IG_CORE_PLATFORM.PS3, "_indexesSizes", 0x18)]
		public ushort[] indexesSizes;
		[igMemoryRefMetaField(0xFF, IG_CORE_PLATFORM.PS3, "_spuVertexes0", 0x1C)]
		public igMemory spuVertexes0;
		[igMemoryRefMetaField(0xFF, IG_CORE_PLATFORM.PS3, "_spuVertexes1", 0x24)]
		public igMemory spuVertexes1;
		[igUnsignedShortArrayMetaField(0xFF, IG_CORE_PLATFORM.PS3, "_spuVertexesSizes", 0x2C)]
		public ushort[] spuVertexesSizes;
		[igMemoryRefMetaField(0xFF, IG_CORE_PLATFORM.PS3, "_rsxOnlyVertexes", 0x38)]
		public igMemory rsxOnlyVertexes;
		[igUnsignedIntMetaField(0xFF, IG_CORE_PLATFORM.PS3, "_rsxOnlyVertexesSizes", 0x40)]
		public uint rsxOnlyVertexesSizes;
		[igUnsignedShortArrayMetaField(0xFF, IG_CORE_PLATFORM.PS3, "_skinMatricesByteOffsets", 0x44)]
		public ushort[] skinMatricesByteOffsets;
		[igUnsignedShortArrayMetaField(0xFF, IG_CORE_PLATFORM.PS3, "_skinMatricesSizes", 0x48)]
		public ushort[] skinMatricesSizes;
		[igUnsignedShortArrayMetaField(0xFF, IG_CORE_PLATFORM.PS3, "_skinIndexesAndWeightsSizes", 0x4C)]
		public ushort[] skinIndexesAndWeightsSizes;
		[igMemoryRefMetaField(0xFF, IG_CORE_PLATFORM.PS3, "_skinIndexesAndWeights", 0x50)]
		public igMemory skinIndexesAndWeights;
		[igUnsignedIntMetaField(0xFF, IG_CORE_PLATFORM.PS3, "_ioBufferSize", 0x58)]
		public uint ioBufferSize;
		[igUnsignedIntMetaField(0xFF, IG_CORE_PLATFORM.PS3, "_scratchSize", 0x5C)]
		public uint scratchSize;
		[igMemoryRefMetaField(0xFF, IG_CORE_PLATFORM.PS3, "_spuInputStreamDescs0", 0x60)]
		public igMemory spuInputStreamDescs0;
		[igMemoryRefMetaField(0xFF, IG_CORE_PLATFORM.PS3, "_spuInputStreamDescs1", 0x68)]
		public igMemory spuInputStreamDescs1;
		[igMemoryRefMetaField(0xFF, IG_CORE_PLATFORM.PS3, "_spuOutputStreamDescs", 0x70)]
		public igMemory spuOutputStreamDescs;
		[igMemoryRefMetaField(0xFF, IG_CORE_PLATFORM.PS3, "_rsxOnlyStreamDesc", 0x78)]
		public igMemory rsxOnlyStreamDesc;
		[igUnsignedShortArrayMetaField(0xFF, IG_CORE_PLATFORM.PS3, "_spuInputStreamDescSizes", 0x80)]
		public ushort[] spuInputStreamDescSizes;
		[igUnsignedShortMetaField(0xFF, IG_CORE_PLATFORM.PS3, "_spuOutputStreamDescSize", 0x84)]
		public ushort spuOutputStreamDescSize;
		[igUnsignedShortMetaField(0xFF, IG_CORE_PLATFORM.PS3, "_rsxOnlyStreamDescSize", 0x86)]
		public ushort rsxOnlyStreamDescSize;
		[igUnsignedIntMetaField(0xFF, IG_CORE_PLATFORM.PS3, "_numBlendShapes", 0x88)]
		public uint numBlendShapes;
		[igVectorMetaField(0xFF, IG_CORE_PLATFORM.PS3, "_blendShapeSizes", 0x8C, typeof(object))]
		public object blendShapeSizes;
		[igMemoryRefMetaField(0xFF, IG_CORE_PLATFORM.PS3, "_blendShapeData", 0x98)]
		public igMemory blendShapeData;
		[igVectorMetaField(0xFF, IG_CORE_PLATFORM.PS3, "_blendShapes", 0xA0, typeof(object))]
		public object blendShapes;
		[igUnsignedIntMetaField(0xFF, IG_CORE_PLATFORM.PS3, "_enableZeroPixelCull", 0xAC)]
		public uint enableZeroPixelCull;

		public igPS3EdgeGeometrySegment(IGZ igz) : base(igz){}
	}
}