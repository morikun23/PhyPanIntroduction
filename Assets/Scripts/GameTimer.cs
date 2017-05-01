using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer {

	public float m_limitTime { get; private set; }

	private const float CHARGE_TIME = 3f;
			
	private bool isFinished;

	public void Initialize() {
		m_limitTime = CHARGE_TIME;
		isFinished = false;
	}

	public void UpdateByFrame() {
		m_limitTime -= Time.deltaTime;

		if(m_limitTime <= 0) {
			isFinished = true;
		}
	}

	public bool ChargeIsFinished() {
		return isFinished;
	}

	public float GetCurrentTime() {
		return m_limitTime;
	}
}
