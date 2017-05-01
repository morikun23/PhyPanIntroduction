using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : ActorBase {

	///TODO:クラス化
	public enum State {
		IDLING,
		CHARGING,
		ACCELERATING,
		BRAKING
	}

	public State m_currentState { get; private set; }

	public void Initialize() {
		m_status = new Status(0 ,Direction.RIGHT);
		
	}

	public void UpdateByFrame() {
		///TODO:クラス分けして処理を行う
		switch (m_currentState) {
			case State.IDLING:			Idle();		break;
			case State.CHARGING:		Charge();	break;
			case State.ACCELERATING:	Accelerate();	break;
			case State.BRAKING:			Brake();	break;
		}
	}

	public void StateTransition(State arg_nextState) {
		m_currentState = arg_nextState;
	}

	public void AddPower(float arg_value) {
		m_status.m_power += arg_value;
	}

	private void Idle() {
		
	}

	private void Charge() {
		
	}
	
	private void Accelerate() {
		GetComponent<Rigidbody2D>().AddForce(new Vector2(m_status.m_power , 0));
		StateTransition(State.BRAKING);
	}

	private void Brake() {
		///TODO:加速、減速は別のロジックにする
		StateTransition(State.IDLING);
	}
}
