using Pools;
using UnityEngine;

namespace Spawning.Test
{
	[RequireComponent(typeof(PooledGameObject))]
	public class ReturnOnBarrierContact : MonoBehaviour
	{
		private PooledGameObject pgo;

		private void Awake()
		{
			pgo = GetComponent<PooledGameObject>();
		}

		private void OnCollisionEnter(Collision collision)
		{
			if (collision.collider.name.Equals("Barrier"))
			{
				pgo.ReturnToPool();
			}
		}
	}
}