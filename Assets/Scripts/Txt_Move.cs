using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Txt_Move : MonoBehaviour {
	public TextMesh text;

	public Color[] colors;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Death() {
		gameObject.SetActive (false);
	}

	public void Setting(string inText, int colorNum) {
		text.text = inText;
		text.color = colors [colorNum];
	}
}
