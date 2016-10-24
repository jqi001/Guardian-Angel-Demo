using Async;
using UnityEngine;
using UnityEngine.Events;

public class SplashScreenState : AGameState
{
	public GameObject splashUI;

	public UnityEvent OnSplashDone;

	public void SplashDone()
	{
		OnSplashDone.Invoke();
	}

	protected override Task<EmptyResult> OnEnter()
	{
		splashUI.SetActive(true);
		return CreateEmptyTask();
	}

	protected override Task<EmptyResult> OnExit()
	{
		splashUI.SetActive(false);
		return CreateEmptyTask();
	}
}