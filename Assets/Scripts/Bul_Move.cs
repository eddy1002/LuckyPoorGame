using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bul_Move : MonoBehaviour {
	public GameObject[] effects;

	public float lifeTime;
	public float lifeTimeMax;
	public float power;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		LifeTimer ();
	}

	public void LifeTimer() {
		if (lifeTime <= 0.0f) {
			Death ();
		} else {
			lifeTime -= Time.deltaTime;
		}
	}

	public void Death() {
		lifeTime = 0.0f;
		PlayEffect ();

		gameObject.SetActive (false);
	}

	public void Setting() {
		lifeTime = lifeTimeMax;
	}

	public void PlayEffect() {
		GameObject effect;
		effect = FindEffect ();

		if (effect) {
			effect.transform.position = gameObject.transform.position;
			effect.SetActive (true);
		}
	}

	public GameObject FindEffect() {
		GameObject effect;

		for (int i = 0; i < effects.Length; i++) {
			if (!effects [i].activeSelf) {
				effect = effects [i];

				return effect;
			}
		}

		return null;
	}

	public void Hitting(GameObject mob) {
		if (mob) {
			mob.GetComponent<Mob_Move> ().GetDamage (power);
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag.Equals ("Ground")) {
			Death ();
		} else if (col.gameObject.tag.Equals ("Mob")) {
			Hitting (col.gameObject);
			Death ();
		}
	}
}
