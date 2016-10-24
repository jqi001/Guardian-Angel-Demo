using Async;
using UnityEngine;

public class InGameState : AGameState
{
	public GameObject ingameUI;

	protected override Task<EmptyResult> OnEnter()
	{
		ingameUI.SetActive(true);
		return CreateEmptyTask();
	}

	protected override Task<EmptyResult> OnExit()
	{
		ingameUI.SetActive(false);
		return CreateEmptyTask();
	}
}