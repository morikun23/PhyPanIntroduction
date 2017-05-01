using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorBase : MonoBehaviour {
	
	public enum Direction {
		LEFT = -1,
		RIGHT = 1
	}

	public class Status {
		public float m_power;
		public Direction m_direction;

		public Status(int arg_power , Direction arg_direction) {
			m_power = arg_power; m_direction = arg_direction;
		}
	}

	public Status m_status;
	
}
