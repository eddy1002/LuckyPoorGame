using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob_Move : MonoBehaviour {
	public GameObject mobLeft;
	public GameObject mobRight;
	public GameObject mobText;
	public GameObject player;
	public GameObject[] texts;
	public GameObject[] deaths;

	public SpriteRenderer mobImage;

	public float speed;
	public float mobHP;
	public float mobHPMax;
	public float power;
	public float move;
	public float attackTime;
	public float attackTimeMax;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		AttackTimer ();
	}

	public void Setting(bool face) {
		if (face) {
			gameObject.transform.position = mobLeft.transform.position;
			gameObject.transform.localScale = new Vector2 (-Mathf.Abs (gameObject.transform.localScale.x), 1.0f);
			gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (speed, 0.0f);
		} else {
			gameObject.transform.position = mobRight.transform.position;
			gameObject.transform.localScale = new Vector2 ( Mathf.Abs (gameObject.transform.localScale.x), 1.0f);
			gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-speed, 0.0f);
		}

		move = 0.0f;
		mobHP = mobHPMax = 10.0f;
	}

	public void Attack() {
		gameObject.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;

		move = 1.0f;
	}

	public void AttackTimer() {
		if (move > 0.5f) {
			if (attackTime <= 0.0f) {
				attackTime = attackTimeMax;

				GameObject text;
				text = FindText ();

				if (text) {
					text.SetActive (true);
					text.transform.position = player.transform.position;

					text.GetComponent<Txt_Move>().Setting("-" + Mathf.Round(power * Random.Range(0.85f, 1.15f)) + "", 1);
				}
			} else {
				attackTime -= Time.deltaTime;
			}
		}
	}

	public void GetDamage(float power) {
		GameObject text;
		text = FindText ();

		if (text) {
			text.SetActive (true);
			text.transform.position = mobText.transform.position;

			text.GetComponent<Txt_Move>().Setting(Mathf.Round(power * Random.Range(0.85f, 1.15f)) + "", 0);
		}

		Death ();
	}

	public void Death() {
		GameObject death;
		death = FindDeath ();

		if (death) {
			death.SetActive (true);
			death.transform.position = gameObject.transform.position - new Vector3(0.0f, 2.5f, 0.0f);
		}

		gameObject.SetActive (false);
	}

	public GameObject FindText() {
		GameObject text;

		for (int i = 0; i < texts.Length; i++) {
			if (!texts [i].activeSelf) {
				text = texts [i];

				return text;
			}
		}

		return null;
	}

	public GameObject FindDeath() {
		GameObject death;

		for (int i = 0; i < deaths.Length; i++) {
			if (!deaths [i].activeSelf) {
				death = deaths [i];

				return death;
			}
		}

		return null;
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag.Equals ("Player")) {
			Attack ();
		}
	}
}
