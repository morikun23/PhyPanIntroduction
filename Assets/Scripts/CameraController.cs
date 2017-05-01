using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	
	public void Initialize() {

	}

	public void UpdateByFrame () {
		//TODO:処理の可読性を上げる。関数化

		Vector3 playerPos = ActorManager.Instance.
			m_playerController.m_player.transform.position;
		
		if (playerPos.x < 0) playerPos.x = 0;

		transform.position = new Vector3(playerPos.x,0,-10);
		
	}
}
