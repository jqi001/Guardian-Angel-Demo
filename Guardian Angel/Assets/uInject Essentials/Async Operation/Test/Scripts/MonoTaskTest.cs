using UnityEngine;

#pragma warning disable

namespace Async.Test
{
	public class MonoTaskTest : MonoBehaviour
	{
		public bool start;

		private void Update()
		{
			if (start)
			{
				start = false;
				Task<float> op = GetComponent<MonoTask>().DoComplexCalculation();
				op.OnProgressChanged += OnProgressChanged;
				op.OnDone += OnDone;
			}
		}

		private void OnProgressChanged(Task op)
		{
			Debug.Log(op.Progress);
		}

		private void OnDone(Task<float> op, float result)
		{
			Debug.Log("Done");
			op.OnProgressChanged -= OnProgressChanged;
			op.OnDone -= OnDone;
			Debug.Log(result);
		}
	}
}

#pragma warning restore