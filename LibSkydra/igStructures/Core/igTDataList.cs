namespace LibSkydra
{
	//Note to self, igObjectList derives from igTDataList<igObject> which derives from igDataList which derives from igObject. igObjectList does not derive directly from igObject
	public class igTDataList<T> : igDataList
	{
		public List<T> tdata;

		public igTDataList(IGZ parent) : base(parent){}

		public override async void ReadFields()
		{
			base.ReadFields();

			Console.WriteLine($"Reading igTDataList<{typeof(T).ToString()}>");

			tdata = Util.InterpretDataArray<T>(parent, data, count);
			tdata.Capacity = (int)capacity;
		}
	}
}