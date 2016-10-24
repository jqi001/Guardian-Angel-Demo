using Async;
using Ninject;
using Ninject.Unity;
using System;

public abstract class AGameState : DIMono
{
	[Inject]
	protected AsyncOperationFactory AOF
	{
		get;
		set;
	}

	public Task Enter()
	{
		return OnEnter();
	}

	public Task<EmptyResult> Exit()
	{
		return OnExit();
	}

	protected abstract Task<EmptyResult> OnEnter();

	protected abstract Task<EmptyResult> OnExit();

	protected Task<EmptyResult> CreateEmptyTask()
	{
		return AOF.Create(new Action[] { () => {; } });
	}
}