using UnityEngine;
using System.Collections;

public class QuitGameState : GameState {
	public QuitGameState(GameStateMachine machine)
		: base (machine, EGameState.GS_QuitGame) {

	}

	public override void OnEnter() {
		Debug.Log("QuitGameState Enter");
	}

	public override void OnExecute() {
		
	}

	public override void OnExit() {
		Debug.Log("QuitGameState Exit");
	}
}
