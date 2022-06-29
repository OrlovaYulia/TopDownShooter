using UnityEngine;
using System.Collections;

public class ObjectManager : MonoBehaviour {
	public GameObject[] weapons;

	

	void Update () {
		weapons = GameObject.FindGameObjectsWithTag ("Weapon");
	}

	public GameObject[] getWeapons()
	{
		return weapons;
	}
}
