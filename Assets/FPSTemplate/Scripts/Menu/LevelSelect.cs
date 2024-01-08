using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour {


	public GameObject[] locks;
	public Text [] levelRecordEscape;
	public Text [] levelRecordDestroyed;
	public GameObject loading;
	public GameObject currentMenu;

	void Start () {


		for(int a = 0;a<locks.Length;a++)
		{
			if(PlayerPrefs.GetInt("LevelUnlock"+a.ToString()) == 3) // 3=>true | 0=>false
				locks[a].SetActive(false);



			levelRecordEscape[a].text = "Felt : " + PlayerPrefs.GetInt("TotalEnemyEscape"+a.ToString()).ToString();

			levelRecordDestroyed[a].text = "Destroyed : " + PlayerPrefs.GetInt("TotalEnemyDestroyed"+a.ToString()).ToString();
		}

	}
	

	public void SelectLevel (int a) {
		if(PlayerPrefs.GetInt("LevelUnlock"+a.ToString())  == 3 )
		{
			currentMenu.SetActive(false);
			loading.SetActive(true); 
			SceneManager.LoadSceneAsync("Level"+(a+1) .ToString());
		}

	}


}
