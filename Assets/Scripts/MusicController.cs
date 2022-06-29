using UnityEngine;
using System.Collections;

public class MusicController : MonoBehaviour {
	AudioSource aus;

	void Start () {
		aus = this.GetComponent<AudioSource> ();
		aus.volume = PauseMenu.musicVal;
	}
	
	
}
