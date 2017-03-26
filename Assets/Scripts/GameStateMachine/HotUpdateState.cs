using UnityEngine;
using System.Collections;

public class HotUpdateState : GameState {
	public HotUpdateState(GameStateMachine stateMachine) :
		base(stateMachine, EGameState.GS_HotUpdate) {
	}


	public override void OnEnter() {
		Debug.Log("热更新以及下载资源 Enter");
	}

	public override void OnExecute() {
		// Debug.Log("热更新以及下载资源中....");
	}

	public override void OnExit() {
		Debug.Log("热更新以及下载资源 Exit");
	}
}
