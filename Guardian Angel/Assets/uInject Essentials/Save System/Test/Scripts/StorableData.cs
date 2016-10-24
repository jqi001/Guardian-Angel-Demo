using System;
using System.Collections.Generic;
using System.Text;

namespace Saving.Test
{
	[Serializable]
	public class StorableData : Storable
	{
		public float fValue;
		public string sValue;
		public int[] intArray;

		public StorableData()
		{
		}

		public IDictionary<string, string> GetStorageData()
		{
			Dictionary<string, string> data = new Dictionary<string, string>();
			data["fValue"] = fValue.ToString();
			data["sValue"] = sValue;
			data["intArray"] = Utility.ListToString(intArray);
			return data;
		}

		public void SetData(IDictionary<string, string> data)
		{
			fValue = float.Parse(data["fValue"]);
			sValue = data["sValue"];
			intArray = Utility.ArrayFromString<int>(data["intArray"], int.Parse);
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("float=" + fValue + ", string=" + sValue + "\n");
			sb.Append("int array=");
			foreach (int i in intArray)
			{
				sb.Append(i + ";");
			}
			return sb.ToString();
		}
	}
}