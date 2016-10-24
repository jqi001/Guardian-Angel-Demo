using Ninject;
using Ninject.Unity;
using System.Collections;
using UnityEngine;

namespace Async.Test
{
	public class CoroutineTest : DIMono
	{
		public bool start;
		private int id;

		[Inject]
		private AsyncOperationFactory AOF
		{
			get;
			set;
		}

		private void Update()
		{
			if (start)
			{
				start = false;
				new Worker(id, AOF);
				id++;
			}
		}

		private class Worker
		{
			private int id;

			public Worker(int id, AsyncOperationFactory AOF)
			{
				this.id = id;
				Task<EmptyResult> t = AOF.Create(Coroutine());
				t.OnDone += T_OnDone;
			}

			private void T_OnDone(Task arg1, EmptyResult arg2)
			{
				Debug.Log("task done " + id);
			}

			private IEnumerator Coroutine()
			{
				Debug.Log("coroutine start " + id);
				float f = 0;
				while (f < 1)
				{
					f += 0.1f;
					Debug.Log(f + " " + id);
					yield return new WaitForSeconds(0.5f);
				}
				Debug.Log("coroutine done " + id);
			}
		}
	}
}