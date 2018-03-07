using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ply_Move : MonoBehaviour {
	public GameObject shootArea;
	public GameObject[] bullets;

	public float attackTime;
	public float attackTimeMax;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		AttackTimer ();
	}

	public void Attack() {
		GameObject bullet;

		bullet = FindBullet ();
		if (bullet) {
			bullet.SetActive (true);
			bullet.transform.position = shootArea.transform.position;
			bullet.GetComponent<Bul_Move> ().Setting ();
			bullet.GetComponent<Rigidbody2D> ().velocity = new Vector2 (Random.Range(-10.0f, 10.0f), 10.0f);
		}

		gameObject.GetComponent<Animator> ().SetFloat ("Move", 0.0f);
	}

	public GameObject FindBullet() {
		GameObject bullet;

		for (int i = 0; i < bullets.Length; i++) {
			if (!bullets [i].activeSelf) {
				bullet = bullets [i];

				return bullet;
			}
		}

		return null;
	}

	public void AttackTimer() {
		if (attackTime <= 0.0f) {
			attackTime = attackTimeMax;

			gameObject.GetComponent<Animator> ().SetFloat ("Move", 1.0f);
		} else {
			attackTime -= Time.deltaTime;
		}
	}
}
