namespace LibSkydra
{
	//not real, exists to aid with reading/writing igTDataList<struct>
	public struct igMemory
	{
		public ulong dataOffset;
		public uint dataLength;
		public byte[] data;
	}
}