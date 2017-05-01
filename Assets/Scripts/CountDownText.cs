using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDownText : MonoBehaviour {

	private UnityEngine.UI.Text m_text;

	public void Initialize () {
		m_text = GetComponent<UnityEngine.UI.Text>();
	}

	public void SetText(string arg_text) {
		m_text.text = arg_text;
	}
}
