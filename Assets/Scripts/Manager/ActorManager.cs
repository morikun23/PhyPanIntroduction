using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorManager : MonoBehaviour {

	/// <summary>
	/// Singleton
	/// </summary>
	private static ActorManager m_instance;

	public static ActorManager Instance {
		get {
			if (m_instance == null) {
				m_instance = new GameObject("Actors").AddComponent<ActorManager>();
			}
			return m_instance;
		}
	}

	private ActorManager(){ }

	
	public PlayerController m_playerController { get; private set; }

	public void Initialize() {
		m_playerController = new PlayerController();
		m_playerController.Initialize();
	}
	
	public void UpdateByFrame() {
		m_playerController.UpdateByFrame();
	}
}
