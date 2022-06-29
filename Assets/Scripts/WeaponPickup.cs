using UnityEngine;
using System.Collections;

public class WeaponPickup : MonoBehaviour {
	public string name;
	public float fireRate;
	WeaponAttack wa;
	public bool gun,oneHanded,shotugn;
	public int ammo;
	void Start () {
		wa = GameObject.FindGameObjectWithTag ("Player").GetComponent<WeaponAttack> ();
	}
	

	void OnTriggerStay2D(Collider2D coll) {
	
		if (coll.gameObject.tag == "Player" && Input.GetMouseButtonDown(1)){

			Debug.Log("Player picked up: " + name);
			if (wa.getCur () != null) {
				wa.dropWeapon ();
			}
			wa.setWeapon (this.gameObject,name,fireRate,gun,oneHanded,shotugn);
			this.gameObject.SetActive (false);
		}
		else if(coll.gameObject.tag=="Enemy" && coll.gameObject.GetComponent<EnemyWeaponController>().GetCur()==null)
		{
			Debug.Log("Enemy picked up: " + name);

			EnemyWeaponController ewc = coll.gameObject.GetComponent<EnemyWeaponController> ();
			ewc.setWeapon (this.gameObject,name,fireRate,gun,oneHanded,shotugn);
			this.gameObject.SetActive (false);
		}
	}
}
