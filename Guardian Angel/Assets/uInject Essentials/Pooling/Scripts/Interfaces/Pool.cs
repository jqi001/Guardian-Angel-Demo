using UnityEngine;

namespace Pools
{
	public interface Pool
	{
		int Size
		{
			get;
		}

		int AvailableObjects
		{
			get;
		}

		void SetSize(int size);

		GameObject GetObject();

		void ReleaseObject(GameObject gameObject);

		bool Contains(GameObject gameObject);
	}
}