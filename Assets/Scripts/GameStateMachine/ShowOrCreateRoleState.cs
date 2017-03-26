using UnityEngine;
using System.Collections;

public class ShowOrCreateRoleState : GameState {
	public ShowOrCreateRoleState(GameStateMachine machine) : 
		base (machine, EGameState.GS_ShowOrCreateRole) {

	}

	public override void OnEnter() {
		Debug.Log ("显角和创角状态 Start");
	}

	public override void OnExecute() {
		
	}

	public override void OnExit() {
		Debug.Log ("显角和创角状态 Exit");
	}
}
