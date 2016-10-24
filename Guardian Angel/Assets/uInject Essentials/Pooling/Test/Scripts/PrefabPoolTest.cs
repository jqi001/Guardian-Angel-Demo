using Ninject;
using Ninject.Unity;
using UnityEngine;

namespace Pools.Test
{
	public class PrefabPoolTest : DIMono
	{
		public GameObject pooledPrefab;

		[Inject]
		private PoolManager PoolManager
		{
			get;
			set;
		}

		private void Start()
		{
			PoolManager.AssurePool(pooledPrefab, 10);
		}
	}
}