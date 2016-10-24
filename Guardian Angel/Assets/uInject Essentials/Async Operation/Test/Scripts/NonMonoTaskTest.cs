using Ninject;
using Ninject.Unity;
using UnityEngine;

#pragma warning disable

namespace Async.Test
{
	public sealed class NonMonoTaskTest : MonoBehaviour
	{
		public bool start;

		private void Update()
		{
			if (start)
			{
				start = false;
				Task<float> op = UnityKernel.INSTANCE.Get<NonMonoTask>().CreateTask();
				op.OnProgressChanged += OnProgressChanged;
				op.OnDone += OnDone;
			}
		}

		private void OnProgressChanged(Task op)
		{
			Debug.Log(op.Progress);
		}

		private void OnDone(Task<float> op, float results)
		{
			Debug.Log("Done");
			op.OnProgressChanged -= OnProgressChanged;
			op.OnDone -= OnDone;
			Debug.Log(results);
		}
	}
}

#pragma warning restore