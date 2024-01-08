using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {


	int totalAmmo;
	public int levelID;

	[Header("Level Time")]
	public float minutes = 3;
	public float seconds = 43;
	public int enemysEscapeLimit = 3;
	public int needEnemysToDestroy = 10;

	[Header("Visuals")]
	public Text scoreText;
	public Text timeDownText;
	public GameObject finishMenu;
	public Text finishMenuText;
	public Text destroyedEnemysText;
	public Text enemysEscapeTExt;


	/*[Header("Sounds")]
	public AudioClip awardedSound;
	public AudioClip lostSound;
	AudioSource audiosSource;*/

	string FinishState;

	void Start ()
	{
		totalAmmo = PlayerPrefs.GetInt("TotalAmmo");
		destroyedEnemysText.text = enemysDestroyed.ToString() + " / " +needEnemysToDestroy;
		enemysEscapeTExt.text = enemysEscape.ToString() + " / " +enemysEscapeLimit;
	}

	void Update ()
	{
		TimeDown() ;

		if(Input.GetKeyDown(KeyCode.E))
			AddEnemysDestroyed();
		
	}

	public void AddScore(int score)
	{
		totalAmmo+=score;
		PlayerPrefs.SetInt("TotalAmmo",totalAmmo);
	}

	int enemysEscape;
	public void AddEnemysEscape()
	{
		enemysEscape++;
		PlayerPrefs.SetInt("TotalEnemyEscape",PlayerPrefs.GetInt("TotalEnemyEscape")+1);
		if(enemysEscape>enemysEscapeLimit)
		{
			finishMenu.SetActive(true);
			finishMenuText.text = "The enemy fled";
			Time.timeScale = 0;
		}
		enemysEscapeTExt.text = enemysEscape.ToString() + " / " +enemysEscapeLimit;
	}

	int enemysDestroyed;
	public void AddEnemysDestroyed()
	{
		enemysDestroyed++;
		PlayerPrefs.SetInt("TotalEnemyDestroyed",PlayerPrefs.GetInt("TotalEnemyDestroyed")+1);
		if(enemysDestroyed>=needEnemysToDestroy)
		{
			finishMenu.SetActive(true);
			finishMenuText.text = "Winner";
			PlayerPrefs.SetInt("LevelUnlock"+levelID.ToString(),3); // Unlock next level - 3 means true, 0 means false
			Debug.Log(PlayerPrefs.GetInt("LevelUnlock"+levelID.ToString()));
			Time.timeScale = 0;
		}
		destroyedEnemysText.text = enemysDestroyed.ToString() + " / " +needEnemysToDestroy;
	}

	public void TimeDown()
	{

		if (seconds <= 0) {
			seconds = 59;

			if (minutes >= 1) {
				minutes --;
			} else {
				minutes = 0;
				seconds = 0;
				timeDownText.text  = minutes.ToString ("f0") + ":0" + seconds.ToString ("f0");
			}
		} else 
		{
			seconds -= Time.deltaTime;
			string min;
			string sec;

			if (minutes < 10)
				min = "0" + minutes.ToString ();
			else
				min = minutes.ToString ();

			if (seconds < 10)
				sec = "0" +( Mathf.FloorToInt(seconds)).ToString ();
			else
				sec = (Mathf.FloorToInt(seconds)).ToString ();

			timeDownText.text = min + ":"+ sec;

		}


		if (minutes <= 0 && seconds <= 0)
			TimeFinihed();
	}

	void TimeFinihed()
	{
		finishMenuText.text = "Time is over";

		Time.timeScale= 0;
		/*audiosSource.clip = lostSound;
		audiosSource.Play();*/
		finishMenu.SetActive(true);
	}
}
