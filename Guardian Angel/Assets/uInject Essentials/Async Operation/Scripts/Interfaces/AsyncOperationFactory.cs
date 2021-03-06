﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace Async
{
	public interface AsyncOperationFactory
	{
		int PoolSize
		{
			get;
		}

		void SetPoolSize(int size);

		/// <summary>
		/// Creates a Task that is managed by the caller. All it does is share information about the progress of the operation.
		/// </summary>
		/// <param name="progressFunction">Function that sets the current progress of the operation. Value 1 or above will be considered as "done".</param>
		/// <returns>The Task object encapsulating the operation.</returns>
		Task<EmptyResult> Create(out Action<float> progressFunction);

		/// <summary>
		/// Creates a Task that returns the result of the results function upon completion.
		/// </summary>
		/// <typeparam name="T">Type that is returned upon completion.</typeparam>
		/// <param name="results">Function that returns the results upon completion.</param>
		/// <param name="progressFunction">Function that sets the current progress of the operation. Value 1 or above will be considered as "done".</param>
		/// <returns>The Task object encapsulating the operation.</returns>
		Task<T> Create<T>(Func<T> results, out Action<float> progressFunction);

		/// <summary>
		/// Creates a Task that is run as a coroutine.
		/// </summary>
		/// <param name="coroutine">The coroutine.</param>
		/// <returns>The Task object encapsulating the operation.</returns>
		Task<EmptyResult> Create(IEnumerator coroutine);

		/// <summary>
		/// Creates a Task that is run as a coroutine.
		/// </summary>
		/// <param name="results">Function that returns the results upon completion.</param>
		/// <param name="coroutine">The coroutine.</param>
		/// <returns>The Task object encapsulating the operation.</returns>
		Task<T> Create<T>(Func<T> results, IEnumerator coroutine);

		/// <summary>
		/// Creates a Task that is run as a coroutine.
		/// </summary>
		/// <param name="results">Function that returns the results upon completion.</param>
		/// <param name="coroutine">The coroutine</param>
		/// <param name="progressFunction">Function that sets the current progress of the operation. Can't be set to 1 manually! Will be set to 1 automatically when the coroutine completes.</param>
		/// <returns>The Task object encapsulating the operation.</returns>
		Task<T> Create<T>(Func<T> results, IEnumerator coroutine, out Action<float> progressFunction);

		/// <summary>
		/// Creates a Task that is managed internally. All given actions will be called once in the given order.
		/// </summary>
		/// <param name="actions">Actions the operation will call.</param>
		/// <returns>The Task object encapsulating the operation.</returns>
		Task<EmptyResult> Create(IEnumerable<Action> actions);

		/// <summary>
		/// Creates a Task that returns the result of the results function upon completion.
		/// </summary>
		/// <typeparam name="T">Type that is returned upon completion.</typeparam>
		/// <param name="results">Function that returns the results upon completion.</param>
		/// <param name="progressFunction">Function that sets the current progress of the operation. Value 1 or above will be considered as "done".</param>
		/// <returns>The Task object encapsulating the operation.</returns>
		Task<T> Create<T>(Func<T> results, IEnumerable<Action> actions);
	}
}