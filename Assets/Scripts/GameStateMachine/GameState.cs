using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameState 
{
	protected GameStateMachine m_kStateMachine = null;

	protected EGameState m_eGameState = EGameState.GS_Invalid;

	Dictionary<EInputEvent, EGameState> m_dctTransMap = new Dictionary<EInputEvent, EGameState>();

	protected ArrayList m_arrParams = null;

	public GameState(GameStateMachine machine, EGameState state)
	{
		m_kStateMachine = machine;
		m_eGameState = state;

		// initialize state map
		Init();
	}

	protected virtual void Init() {
		switch (m_eGameState) {
		case EGameState.GS_PlatformLogin: {
				AddTransition(EInputEvent.IE_PlatformLoginSuccess, EGameState.GS_HotUpdate);
			}
			break;
		case EGameState.GS_HotUpdate: {
				AddTransition(EInputEvent.IE_HotUpdateOver, EGameState.GS_Login);
			}
			break;
		case EGameState.GS_Login: {
				AddTransition(EInputEvent.IE_LoginSuccess, EGameState.GS_ShowOrCreateRole);
			}
			break;
		case EGameState.GS_ShowOrCreateRole: {
				AddTransition(EInputEvent.IE_EnterScene, EGameState.GS_Loading);
			}
			break;
		case EGameState.GS_Loading: {
				AddTransition(EInputEvent.IE_LoadingOver, EGameState.GS_InGame);
			}
			break;
		case EGameState.GS_InGame: {
				AddTransition(EInputEvent.IE_EnterScene, EGameState.GS_Loading);
				AddTransition(EInputEvent.IE_QuitGame, EGameState.GS_QuitGame);
			}
			break;
		}
	}

	public virtual void OnEnter()
	{

	}

	public virtual void OnExecute()
	{

	}

	public virtual void OnExit()
	{

	}

	public void AddTransition(EInputEvent eEvent, EGameState outPutState)
	{
		if (!m_dctTransMap.ContainsKey(eEvent))
		{
			m_dctTransMap.Add(eEvent, outPutState);
		}
	}

	public void DeleteTransition(EInputEvent eEvent, EGameState outPutState)
	{
		if (m_dctTransMap.ContainsKey(eEvent))
		{
			m_dctTransMap.Remove(eEvent);
		}
	}

	public EGameState GetTransmitState(EInputEvent inputEvent)
	{
		if (inputEvent <= EInputEvent.IE_Invalid || inputEvent >= EInputEvent.IE_Max)
			return EGameState.GS_Invalid;

		if (!m_dctTransMap.ContainsKey (inputEvent))
			return EGameState.GS_Invalid;

		return m_dctTransMap [inputEvent];
	}

	public EGameState GetState()
	{
		return m_eGameState;
	}
		

	public virtual bool CanEnter(EInputEvent stateEvent, GameState state, ArrayList param) {
		return true;
	}

	public virtual void SetParams(ArrayList param) {
		m_arrParams = param;
	}
}
