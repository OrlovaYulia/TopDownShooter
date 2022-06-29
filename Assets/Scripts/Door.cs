using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
	GameObject player;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	



	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Enemy"){
			if (Vector3.Distance (player.transform.position, this.transform.position) < 1.0) {
				EnemyAttacked ea = coll.gameObject.GetComponent<EnemyAttacked> ();
				ea.knockDownEnemy ();
			}
		}
	}
}
