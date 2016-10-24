using Async;

public class ChooseDragonState : AGameState
{
	protected override Task<EmptyResult> OnEnter()
	{
		return CreateEmptyTask();
	}

	protected override Task<EmptyResult> OnExit()
	{
		return CreateEmptyTask();
	}
}