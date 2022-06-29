using UnityEngine;
using System.Collections;

public class DogHealth : MonoBehaviour {
	public Sprite dead;
	public GameObject bloodPool;

	


	public void killDog()
	{
		this.gameObject.tag = "Dead";
		this.GetComponent<BoxCollider2D> ().enabled = false;
		this.GetComponent<DogAI> ().enabled = false;
		this.GetComponent<DogAnimate> ().enabled = false;
		this.GetComponent<SpriteRenderer> ().sprite = dead;
		this.GetComponent<AudioSource> ().enabled = false;
		this.enabled = false;
		Instantiate (bloodPool, this.transform.position, this.transform.rotation);
	}
}
