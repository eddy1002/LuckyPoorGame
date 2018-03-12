using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inf_Move : MonoBehaviour {
	public GameObject infoText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ShowInfo() {
		infoText.SetActive (true);
	}

	public void HideInfo() {
		infoText.SetActive (false);
	}
}
