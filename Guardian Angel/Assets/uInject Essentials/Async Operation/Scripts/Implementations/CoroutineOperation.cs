using System.Collections;
using System.Collections.Generic;

namespace Async.Impl
{
	public sealed class CoroutineOperation : AOperationMono
	{
		public Stack<CoroutineOperation> Pool
		{
			get;
			set;
		}

		public void StartTask(IEnumerator coroutine)
		{
			enabled = true;
			StartCoroutine(Coroutine(coroutine));
		}

		public void SetProgress(float progress)
		{
			if (progress < 1)
			{
				Progress = progress;
			}
		}

		protected override void CleanupOperation()
		{
			base.CleanupOperation();
			Pool.Push(this);
		}

		private IEnumerator Coroutine(IEnumerator nestedCoroutine)
		{
			yield return StartCoroutine(nestedCoroutine);
			Progress = 1;
		}
	}
}