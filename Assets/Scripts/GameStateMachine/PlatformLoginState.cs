using UnityEngine;
using System.Collections;

public class PlatformLoginState : GameState {

	public PlatformLoginState(GameStateMachine machine) : base (machine, EGameState.GS_PlatformLogin) {

	}

	public override void OnEnter() {
		Debug.Log("PlatformLoginState Enter");
		//string strVideoName = Application.streamingAssetsPath + "beginMovie.mp4";
		//Handheld.PlayFullScreenMovie(strVideoName, Color.black, FullScreenMovieControlMode.CancelOnTouch);
	}

	public override void OnExecute() {
		
	}

	public override void OnExit() {
		Debug.Log("PlatformLoginState Exit");
	}
}
