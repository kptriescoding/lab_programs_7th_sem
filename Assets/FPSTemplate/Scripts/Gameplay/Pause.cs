//--------------------------------------------------------------
//
//                    Off-Road Truck Kit
//          Writed by AliyerEdon in fall 2016
//           Contact me : aliyeredon@gmail.com
//
//--------------------------------------------------------------

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {

	public GameObject PauseMenu;

	public Text ammoText1,ammoText2;

	public void SetPause()
	{
		PauseMenu.SetActive (true);
		Time.timeScale = 0;
		if(ammoText1)
			ammoText1.text = "Total Ammo : "+PlayerPrefs.GetInt("TotalAmmo").ToString();
		if(ammoText2)
			ammoText2.text = "Total Ammo : "+PlayerPrefs.GetInt("TotalAmmo").ToString();
	}

	public void Resume()
	{
		Time.timeScale = 1f;
		PauseMenu.SetActive (false);
	}
	public void Retry()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}
	public void Exit(string name)
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene(name);
	}
}
