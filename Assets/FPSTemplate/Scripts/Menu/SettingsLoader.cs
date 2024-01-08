using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SettingsLoader : MonoBehaviour {

	public AudioSource ambientSound;
	public GameObject volume;

	void Start () 
	{
		if(PlayerPrefs.GetInt("AmbientSound") == 3)
			ambientSound.Play();
		else
			ambientSound.Stop();

		if(PlayerPrefs.GetInt("ImageEffect") == 3)
			volume.SetActive(true);
		else
			volume.SetActive(false);
	}			
}
