using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Saving
{
	public static class Utility
	{
		public static string ListToString(IEnumerable list, char separator = ';')
		{
			object[] array = list.Cast<object>().ToArray();
			StringBuilder sb = new StringBuilder();
			int i = 0;
			for (; i < array.Length - 1; i++)
			{
				sb.Append(array[i].ToString() + separator);
			}
			sb.Append(array[i].ToString());
			return sb.ToString();
		}

		public static T[] ArrayFromString<T>(string s, Func<string, T> parser, char separator = ';')
		{
			List<T> list = new List<T>();
			string[] split = s.Split(separator);
			foreach (string part in split)
			{
				list.Add(parser(part));
			}
			return list.ToArray();
		}

		public static void RemoveLast<T>(this List<T> list)
		{
			if (list.Count > 0)
			{
				list.RemoveAt(list.Count - 1);
			}
		}
	}
}