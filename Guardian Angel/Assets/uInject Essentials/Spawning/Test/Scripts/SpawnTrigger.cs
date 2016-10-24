using UnityEngine;

namespace Spawning.Test
{
	public class SpawnTrigger : MonoBehaviour
	{
		public ASpawnerMono spawner;
		public AnimationCurve spawnTimeCurve;
		private float nextSpawn = 2;

		private void Update()
		{
			if (Time.time > nextSpawn)
			{
				spawner.Spawn();
				nextSpawn = Time.time + spawnTimeCurve.Evaluate(Time.time);
			}
		}
	}
}