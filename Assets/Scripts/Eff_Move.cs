﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eff_Move : MonoBehaviour {
	public SpriteRenderer effectImage;
	public Sprite[] images;

	public float power;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Death() {
		gameObject.SetActive (false);
	}

	public void Hitting(GameObject mob) {
		if (mob) {
			mob.GetComponent<Mob_Move> ().GetDamage (power);
		}
	}

	public void Setting(int imageNum, float powerSet, float sizeX, float sizeY) {
		effectImage.sprite = images [imageNum];
		power = powerSet;
		gameObject.transform.localScale = new Vector3 (sizeX, sizeY, 1.0f);
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag.Equals ("Mob")) {
			Hitting (col.gameObject);
		}
	}
}
