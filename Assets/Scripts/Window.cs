﻿using UnityEngine;
using System.Collections;

public class Window : MonoBehaviour {
	public Sprite brokenWindow;

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Bullet" ){
			breakWindow ();
		}
	}

	public void breakWindow()
	{
		BoxCollider2D bc2d = this.GetComponent<BoxCollider2D> ();
		bc2d.enabled = false;
		this.GetComponent<SpriteRenderer> ().sprite = brokenWindow;
		this.GetComponent<SpriteRenderer> ().sortingOrder = 1;
	}
}
