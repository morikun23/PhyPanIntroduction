using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO:UIマネージャーを作成する
public class TextManager : MonoBehaviour {
	
	private CountDownText m_countDownText;

	public void Initialize () {
		m_countDownText = FindObjectOfType<CountDownText>();
		m_countDownText.Initialize();
	}

	public void UpdateByFrame () {
		GameManager.Phase phase = GameManager.Instance.m_status.m_currentPhase;
		GameTimer timer = GameManager.Instance.m_timer;


		switch (phase) {
			case GameManager.Phase.INTRODUCTION: break;
			case GameManager.Phase.CHARGE:
				m_countDownText.SetText(Mathf.RoundToInt(timer.GetCurrentTime()).ToString());
			break;
			case GameManager.Phase.RUN:
			foreach (UnityEngine.UI.Text text in FindObjectsOfType<UnityEngine.UI.Text>()) {
				text.enabled = false;
			}
			break;
		}

	}
}
