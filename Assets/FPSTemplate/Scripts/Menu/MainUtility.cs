
// This script used for main utilities used in game menus

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainUtility : MonoBehaviour
{

	public GameObject Loading;

	public int startingScore = 1400;

	public void Cheat(InputField input)
	{
		if(input.text == "Coins")
			PlayerPrefs.SetInt("Coins",PlayerPrefs.GetInt("Coins")+1000);
	}

	void Awake ()
	{
		// Is game first run?   3 => true    0 => false
		if (PlayerPrefs.GetInt ("FirstRun") != 3) 
		{
			PlayerPrefs.SetInt ("FirstRun", 3);

			// Set ambiant sound in settings true
			PlayerPrefs.SetInt ("AmbientSound", 3);

			// Unlock first level
			PlayerPrefs.SetInt ("LevelUnlock0", 3);
		}
	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.H)) {
			PlayerPrefs.DeleteAll ();
			Debug.Log ("PlayerPrefs.DeleteAll ();");
		}
		if (Input.GetKeyDown (KeyCode.E))
			PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt ("Coins") + 14000);
	}

	public void Exit ()
	{
		Application.Quit ();
	}

	public void SetTrue (GameObject target)
	{
		target.SetActive (true);
	}

	public void SetFalse (GameObject target)
	{
		target.SetActive (false);
	}

	public void ToggleObject (GameObject target)
	{
		target.SetActive (!target.activeSelf);
	}

	public void LoadLevel (string name)
	{

		Loading.SetActive (true);
		SceneManager.LoadSceneAsync (name);
	}

	public void OpenURL (string val)
	{
		Application.OpenURL (val);
	}
}
