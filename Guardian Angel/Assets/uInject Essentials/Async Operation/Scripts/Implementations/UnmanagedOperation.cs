using System;

namespace Async.Impl
{
	public sealed class UnmanagedOperation<T> : Task<T>
	{
		public Func<T> results;

		public float Progress
		{
			get;
			private set;
		}

		public bool IsDone
		{
			get
			{
				return Progress >= 1;
			}
		}

		public event Action<Task> OnProgressChanged = delegate { };

		public event Action<Task<T>, T> OnDone = delegate { };

		public UnmanagedOperation(Func<T> results)
		{
			this.results = results;
		}

		public void SetProgress(float progress)
		{
			if (!IsDone)
			{
				Progress = progress;
				OnProgressChanged(this);
				if (IsDone)
				{
					OnDone(this, results());
				}
			}
		}
	}
}