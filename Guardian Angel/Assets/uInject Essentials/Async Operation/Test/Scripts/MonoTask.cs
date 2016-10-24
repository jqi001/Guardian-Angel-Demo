using Ninject;
using Ninject.Unity;
using System;
using System.Collections;
using UnityEngine;

namespace Async.Test
{
	public class MonoTask : DIMono
	{
		public float result;
		private float progress;
		private Action<float> progressFunction;

		[Inject]
		private AsyncOperationFactory AOF
		{
			get;
			set;
		}

		public Task<float> DoComplexCalculation()
		{
			Task<float> op = AOF.Create<float>(Result, out progressFunction);
			progress = 0;
			StartCoroutine(MyCoroutine());
			return op;
		}

		private float Result()
		{
			return result;
		}

		private IEnumerator MyCoroutine()
		{
			yield return new WaitForEndOfFrame();
			while (progress < 1)
			{
				progress += 0.1f;
				progressFunction(progress);
				yield return new WaitForSeconds(0.5f);
			}
		}
	}
}