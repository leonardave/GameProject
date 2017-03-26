using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class InGameState : GameState {

	public InGameState(GameStateMachine machine) : base (machine, EGameState.GS_InGame) {

	}

	public override void OnEnter() {
		Debug.Log ("游戏状态开始");
	}

	public override void OnExecute() {
		
	}

	public override void OnExit() {
		Debug.Log ("游戏状态退出");
	}
}
