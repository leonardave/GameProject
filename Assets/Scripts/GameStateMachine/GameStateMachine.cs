using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum EGameState {
	GS_Invalid = 0,
	GS_PlatformLogin,				// 渠道平台登录
	GS_HotUpdate,						// 热更
	GS_Login,								// 选服务器 登录
	GS_ShowOrCreateRole,			// 显角 创角
	GS_InGame,							// 游戏中
	GS_Loading,							// 加载场景和资源
	GS_QuitGame,						// 结束游戏
	GS_Max,
}

public enum EInputEvent {
	IE_Invalid = 0,
	IE_PlatformLoginSuccess,		// 渠道平台登录成功
	IE_HotUpdateOver,				// 热更成功完成
	IE_LoginSuccess,					// 选服登录游戏成功
	IE_EnterScene,						// 进入场景成功
	IE_LoadingOver,					// 场景加载切换成功
	IE_QuitGame,						// 退出游戏成功
	IE_Max,
}

public class GameStateMachine : Singleton<GameStateMachine> {
	public Dictionary<EGameState, GameState> m_dctStateMap = new Dictionary<EGameState, GameState>();

	public GameState m_kCurState = null;

	public GameState m_kLastState = null;
	
	public void Initialize() {
		for (EGameState i = (EGameState.GS_Invalid + 1); i < EGameState.GS_Max; ++i) {
			m_dctStateMap.Add(i, CreateGameState(i));
		}

		m_kCurState = m_dctStateMap[EGameState.GS_HotUpdate];
		m_kCurState.OnEnter();
	}

	GameState CreateGameState(EGameState type) {
		GameState kRet = null;

		switch (type) {
		case EGameState.GS_PlatformLogin:
			kRet = new PlatformLoginState(this);
			break;
		case EGameState.GS_HotUpdate:
			kRet = new HotUpdateState(this);
			break;
		case EGameState.GS_ShowOrCreateRole:
			kRet = new ShowOrCreateRoleState(this);
			break;
		case EGameState.GS_Login:
			kRet = new LoginState(this);
			break;
		case EGameState.GS_InGame:
			kRet = new InGameState(this);
			break;
		case EGameState.GS_Loading:
			kRet = new LoadingState(this);
			break;
		case EGameState.GS_QuitGame:
			kRet = new QuitGameState(this);
			break;
		}

		return kRet;
	}
	
	public void FireEvent(EInputEvent eEvent, ArrayList param = null) {
		if (m_kCurState == null)
			return;

		EGameState nextState = m_kCurState.GetTransmitState(eEvent);

		if (nextState == EGameState.GS_Invalid || nextState == EGameState.GS_Max) {
			return;
		}

		GameState kNextState = m_dctStateMap[nextState];

		if (kNextState == null)
			return;

		// 判断能否进入该状态 通过外部条件
		if (kNextState.CanEnter(eEvent, m_kCurState, param)) {
			// 退出当前状态
			OnExitState(m_kCurState);

			m_kLastState = m_kCurState;

			m_kCurState = kNextState;

			// 新状态设置参数
			m_kCurState.SetParams(param);

			// 进入新状态
			OnEnterState(kNextState);
		}
	}

	public void OnExecuteState()
	{
		if (m_kCurState == null)
			return;
		
		m_kCurState.OnExecute();
	}

	void OnExitState(GameState kState)
	{
		if (kState == null)
			return;
		
		kState.OnExit();
	}

	void OnEnterState(GameState kState)
	{
		if (kState == null)
			return;
		
		kState.OnEnter();
	}

	public bool IsCurState(EGameState state)
	{
		return m_kCurState.GetState () == state;
	}
}
