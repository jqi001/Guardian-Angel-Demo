using System.Collections.Generic;

namespace Saving
{
	public interface Storable
	{
		IDictionary<string, string> GetStorageData();

		void SetData(IDictionary<string, string> data);
	}
}