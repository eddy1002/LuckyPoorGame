using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ply_Move : MonoBehaviour {
	public GameObject shootArea;
	public GameObject bullets;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Attack() {
		bullets.transform.position = shootArea.transform.position;
		bullets.GetComponent<Rigidbody2D> ().velocity = new Vector2 (Random.Range(-10.0f, 10.0f), 10.0f);

		gameObject.GetComponent<Animator> ().SetFloat ("Move", 0.0f);
	}
}
