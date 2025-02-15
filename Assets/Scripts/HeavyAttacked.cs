﻿using UnityEngine;
using System.Collections;

public class HeavyAttacked : MonoBehaviour {

	public Sprite bulletWound,backUp;
	public GameObject bloodPool,bloodSpurt;
	SpriteRenderer sr;
	bool EnemyKnockedDown=false;
	GameObject player;
	ScoreController sc;

	int health = 4;
	void Start () {
		sr = this.GetComponent<SpriteRenderer> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		sc = GameObject.FindGameObjectWithTag ("GameController").GetComponent<ScoreController> ();
	}

	void Update () {
		
	}



	public void hitByBullet()
	{
		health--;
		if (health <= 0) {
			killBullet ();
		}
	}



	public void killBullet()
	{
		sc.AddScore (1000,this.transform.position);
		sc.increaseMultiplier ();

		this.GetComponent<HeavyAttack> ().enabled=false;
		sr.sprite = bulletWound;
		Instantiate (bloodPool,this.transform.position,this.transform.rotation);
		Instantiate (bloodSpurt,this.transform.position,this.transform.rotation);
		sr.sortingOrder = 2;

		this.GetComponent<HeavyAI>().enabled=false;
		this.GetComponent<CircleCollider2D>().enabled=false;
		this.GetComponent<HeavyAnimate> ().disableLegs ();
		this.GetComponent<HeavyAnimate> ().enabled =false;
		this.gameObject.tag = "Dead";
	}


}
