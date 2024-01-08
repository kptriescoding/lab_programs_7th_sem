using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSplash : MonoBehaviour {

	public string levelname = "MainMenu";

	void Start ()
	{

		SceneManager.LoadScene(levelname);
	
	}

}
