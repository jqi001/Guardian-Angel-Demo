using Async;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
	public AGameState currentState;

	public void ChangeState(AGameState state)
	{
		Task<EmptyResult> t = currentState.Exit();
		t.OnDone += T_OnDone;
		currentState = state;
	}

	private void T_OnDone(Task<EmptyResult> arg1, EmptyResult arg2)
	{
		currentState.Enter();
	}

	private void Start()
	{
		currentState.Enter();
	}
}