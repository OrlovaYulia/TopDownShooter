using UnityEngine;
using System.Collections;

using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class LevelStore : MonoBehaviour {
	public string levelName;
	public Texture2D levelIcon;
	public int highScore = 0;
	public bool unlocked = false;
	public string sceneManagerName;
	string path;

	void Start () {
		path = Application.persistentDataPath+"/"+levelName + "scoreData.dat";
		load ();
	}
	


	public void save(int newHighScore)
	{
		highScore = newHighScore;
		path = Application.persistentDataPath+"/"+levelName + "scoreData.dat";

		levelHighScore data = new levelHighScore ();
		data.highScore = highScore;

		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(path);

		bf.Serialize(file, data);
		file.Close ();
		Debug.Log ("MANAGED TO SAVE FILE TO " + path);
	}

	public void load()
	{
		path = Application.persistentDataPath+"/"+levelName + "scoreData.dat";

		if (File.Exists (path)) {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(path, FileMode.Open);

			levelHighScore data = (levelHighScore)bf.Deserialize(file);
			highScore = data.highScore;
			file.Close();
			Debug.Log ("MANAGED TO LOAD FILE FROM " + path);

		} else {
			save (highScore);
			load ();
		}
	}
}

[Serializable]
class levelHighScore
{
	public int highScore;
}
