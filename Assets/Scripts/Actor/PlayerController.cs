using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	
	public Player m_player { get; private set; }
	
	public void Initialize() {
		m_player = Instantiate(Resources.Load<GameObject>("Actor/PF_1000") ,
			ActorManager.Instance.transform).GetComponent<Player>();
		m_player.transform.position = new Vector3(-7.5f , -2.45f , 0);
		
		m_player.Initialize();
		
	}

	public void UpdateByFrame() {
		GameManager.Phase phase = GameManager.Instance.m_status.m_currentPhase;

		switch (phase) {
			case GameManager.Phase.INTRODUCTION: break;
			case GameManager.Phase.CHARGE: Charge(); break;
			case GameManager.Phase.RUN:
				if(m_player.m_currentState == Player.State.CHARGING) {
					m_player.StateTransition(Player.State.ACCELERATING);
				}
			break;
		}

		m_player.UpdateByFrame();
	}

	public void Charge() {
		if (Input.GetKeyDown(KeyCode.Space)) {
			if(m_player.m_currentState != Player.State.CHARGING) {
				m_player.StateTransition(Player.State.CHARGING);
			}
			//TODO:
			m_player.AddPower(95f);
		}
	}
}
