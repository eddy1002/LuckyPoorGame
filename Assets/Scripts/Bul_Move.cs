using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bul_Move : MonoBehaviour {
	public GameObject[] effects;

	public SpriteRenderer bulletImage;
	public Sprite[] images;

	public int bulletID;

	public float lifeTime;
	public float lifeTimeMax;
	public float power;
	public float[] powerList;
	public float[] sizeX;
	public float[] sizeY;
	public float[] effSizeX;
	public float[] effSizeY;

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
		if (lifeTime > 0.0f) {
			lifeTime = 0.0f;
			PlayEffect ();

			gameObject.SetActive (false);
		}
	}

	public void Setting(int ID) {
		lifeTime = lifeTimeMax;

		bulletID = ID;
		bulletImage.sprite = images [ID];
		gameObject.transform.localScale = new Vector3 (sizeX [ID], sizeY [ID], 1.0f);
		power = powerList [ID];
	}

	public void PlayEffect() {
		GameObject effect;
		effect = FindEffect ();

		if (effect) {
			effect.transform.position = gameObject.transform.position;
			effect.SetActive (true);
			effect.GetComponent<Eff_Move> ().Setting (bulletID, power * 0.5f, effSizeX [bulletID], effSizeY [bulletID]);
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
