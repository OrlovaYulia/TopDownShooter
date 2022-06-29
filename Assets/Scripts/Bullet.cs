using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public Vector3 direction;
    public string creator;
	EnemyAttacked attacked;
	HeavyAttacked ha;
	public GameObject bloodImpact,wallImpact;

	float timer = 10.0f;


	void Start () {
	
	}


	void Update () {
		transform.Translate (direction*17*Time.deltaTime);

		timer -= Time.deltaTime;
		if(timer<=0)
		{
			Destroy (this.gameObject);
		}
	}

	public void setVals(Vector3 dir, string name)
	{
		direction = dir;
		creator = name;
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Enemy") {
			attacked = col.gameObject.GetComponent<EnemyAttacked> ();
			attacked.killBullet ();
			Instantiate (bloodImpact, this.transform.position, this.transform.rotation);
			Destroy (this.gameObject);
		} else if (col.gameObject.tag == "Enemy" && creator == "Enemy") {

		} else if (col.gameObject.tag == "Heavy") {
			ha = col.gameObject.GetComponent<HeavyAttacked> ();
			ha.hitByBullet ();
			Instantiate (bloodImpact, this.transform.position, this.transform.rotation);
			Destroy (this.gameObject);
		} else if (col.gameObject.tag == "Player") {
			Instantiate (bloodImpact, this.transform.position, this.transform.rotation);
			PlayerHealth.dead = true;
			Destroy (this.gameObject);
		} else if (col.gameObject.tag != "Enemy" && col.gameObject.tag != "Player" && col.gameObject.tag != "Dog" && col.gameObject.tag!="Heavy") {
			
			Instantiate (wallImpact, this.transform.position, this.transform.rotation);
			Destroy (this.gameObject);
		} else if (col.gameObject.tag == "Dog") {
			Instantiate (bloodImpact, this.transform.position, this.transform.rotation);
			col.gameObject.GetComponent<DogHealth> ().killDog ();
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.GetComponent<EnemyAttacked> () == true) {
			other.gameObject.GetComponent<EnemyAttacked> ().execute ();
		}
	}
}
