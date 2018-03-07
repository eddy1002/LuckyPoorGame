using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zen_Move : MonoBehaviour {
	public GameObject[] mobs;

	public float zenTime;
	public float zenTimeMax;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		ZenTimer ();
	}

	public void ZenTimer() {
		if (zenTime <= 0.0f) {
			MobZen ();
		} else {
			zenTime -= Time.deltaTime;
		}
	}

	public void MobZen() {
		zenTime = zenTimeMax * Random.Range (0.85f, 1.15f);

		GameObject mob;
		mob = FindMob ();

		if (mob) {
			mob.SetActive (true);
			if (Random.value > 0.5f) {
				mob.GetComponent<Mob_Move> ().Setting (true);
			} else {
				mob.GetComponent<Mob_Move> ().Setting (false);
			}
		}
	}

	public GameObject FindMob() {
		GameObject mob;

		for (int i = 0; i < mobs.Length; i++) {
			if (!mobs [i].activeSelf) {
				mob = mobs [i];

				return mob;
			}
		}

		return null;
	}
}
