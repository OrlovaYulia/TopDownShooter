using UnityEngine;
using System.Collections;

public class WeaponWindowDestroy : MonoBehaviour {


	void OnTriggerEnter2D(Collider2D coll) {

		if (coll.gameObject.tag == "Wall" && coll.gameObject.GetComponent<Window> () != null) {
			coll.gameObject.GetComponent<Window> ().breakWindow ();
		}
	}
}
