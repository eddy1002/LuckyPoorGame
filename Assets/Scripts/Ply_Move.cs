using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ply_Move : MonoBehaviour {
	public GameObject shootArea;
	public GameObject[] bullets;

	public Image skillImage;

	public Text skillCoolText;

	public int skillID;

	public float skillCool;
	public float skillCoolMax;
	public float attackTime;
	public float attackTimeMax;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		AttackTimer ();
		SkillCoolTimer ();
	}

	public void Attack() {
		GameObject bullet;

		bullet = FindBullet ();
		if (bullet) {
			bullet.SetActive (true);
			bullet.transform.position = shootArea.transform.position;
			bullet.GetComponent<Bul_Move> ().Setting (0);
			bullet.GetComponent<Rigidbody2D> ().velocity = new Vector2 (Random.Range(-10.0f, 10.0f), 10.0f);
		}

		if (Random.value > 0.25f) {
			Skill001 ();
		}

		gameObject.GetComponent<Animator> ().SetFloat ("Move", 0.0f);
	}
	public void Skill001() {
		if (skillCool <= 0.0f) {
			skillCool = skillCoolMax;

			GameObject bullet;

			bullet = FindBullet ();
			if (bullet) {
				bullet.SetActive (true);
				bullet.transform.position = shootArea.transform.position;
				bullet.GetComponent<Bul_Move> ().Setting (1);
				bullet.GetComponent<Rigidbody2D> ().velocity = new Vector2 (Random.Range(-10.0f, 10.0f), 10.0f);
			}
		}
	}

	public void SkillCoolTimer() {
		if (skillCool > 0.0f) {
			skillCool -= Time.deltaTime;

			skillImage.fillAmount = (skillCoolMax - skillCool) / skillCoolMax;
			skillCoolText.text = Mathf.Max (skillCool, 0.0f).ToString("N1");
		} else {
			skillCool = 0.0f;

			skillCoolText.text = "";
		}
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
