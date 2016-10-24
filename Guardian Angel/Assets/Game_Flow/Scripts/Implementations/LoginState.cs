using Async;
using UnityEngine;
using UnityEngine.Events;

public class LoginState : AGameState
{
	public GameObject loginUI;

	public UnityEvent OnLoginDone;

	public void Login()
	{
		OnLoginDone.Invoke();
	}

	protected override Task<EmptyResult> OnEnter()
	{
		loginUI.SetActive(true);
		return CreateEmptyTask();
	}

	protected override Task<EmptyResult> OnExit()
	{
		loginUI.SetActive(false);
		return CreateEmptyTask();
	}
}