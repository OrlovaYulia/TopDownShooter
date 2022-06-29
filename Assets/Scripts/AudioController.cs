using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour {
	AudioSource aus;
	public AudioClip pickup,smgShot,shotgunShot,melee;

	void Start () {
		aus = this.GetComponent<AudioSource> ();
		aus.volume = PauseMenu.sfxVal;
	}


	public void fireSmg()
	{
		aus.clip = smgShot;
		aus.Play ();
	}

	public void fireShotgun()
	{
		aus.clip = shotgunShot;
		aus.Play ();
	}

	public void pickupWeapon()
	{
		aus.clip = pickup;
		aus.Play();
	}

	public void meleeAttack()
	{
		aus.clip = melee;
		aus.Play ();
	}
}
