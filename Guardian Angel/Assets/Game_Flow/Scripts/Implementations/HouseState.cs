using Async;

public class HouseState : AGameState
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