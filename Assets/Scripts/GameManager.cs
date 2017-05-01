using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	/// <summary>
	/// Singleton
	/// </summary>
	private static GameManager m_instance;

	public static GameManager Instance {
		get {
			if(m_instance == null) {
				m_instance = FindObjectOfType<GameManager>();
			}
			return m_instance;
		}
	}

	//TODO:フェーズ管理用のクラスを作成
	public enum Phase {
		INTRODUCTION,
		CHARGE,
		RUN
	}

	public class Status {
		public Phase m_currentPhase;
		public int m_score;
	}

	public ActorManager m_actorManager { get; private set; }
	public GameTimer m_timer { get; private set; }
	public Status m_status { get; private set; }

	public TextManager m_textManager { get; private set; }

	private CameraController m_cameraController;

	// Use this for initialization
	void Start () {
		//TODO:処理の分割

		m_timer = new GameTimer();
		m_timer.Initialize();

		m_actorManager = ActorManager.Instance;
		m_actorManager.Initialize();

		m_status = new Status() {
			m_currentPhase = Phase.INTRODUCTION ,
			m_score = 0
		};

		m_cameraController = FindObjectOfType<CameraController>();
		m_cameraController.Initialize();

		m_textManager = new TextManager();
		m_textManager.Initialize();
	}
	
	// Update is called once per frame
	void Update () {
		
		//TODO:フェーズの開始時、終了時の処理を追加できるようにする。

		switch (m_status.m_currentPhase) {
			case Phase.INTRODUCTION:
				if (Input.GetKeyDown(KeyCode.Space)) {
					m_status.m_currentPhase = Phase.CHARGE;
			}
			break;
			case Phase.CHARGE:
			if (m_timer.ChargeIsFinished()) {
				m_status.m_currentPhase = Phase.RUN;
			}

			break;
			case Phase.RUN: break;
		}

		m_textManager.UpdateByFrame();
		m_cameraController.UpdateByFrame();
		m_timer.UpdateByFrame();
		m_actorManager.UpdateByFrame();
	}
}
