
// This script used for game settings menu

using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Settings : MonoBehaviour
{

	public Toggle AmbientSound, imageEffect;

	public Dropdown qualityDrop;

	void Start ()
	{
		// Read starting setting values
		if (PlayerPrefs.GetInt ("AmbientSound") == 3)
			AmbientSound.isOn = true;
		else
			AmbientSound.isOn = false;

		if (PlayerPrefs.GetInt ("ImageEffect") == 3)
			imageEffect.isOn = true;
		else
			imageEffect.isOn = false;

		qualityDrop.value =PlayerPrefs.GetInt ("Quality");
	}

	// Public function for ambient sound toggle
	public void Set_AmbientSound ()
	{
		StartCoroutine (AmbiantSound_Save ());
	}

	public void Set_ImageEffect ()
	{
		StartCoroutine (ImageEffect_Save ());
	}

	public void SetQualityLevel ()
	{
		PlayerPrefs.SetInt ("Quality", qualityDrop.value);
		QualitySettings.SetQualityLevel (qualityDrop.value, false);
	}

	IEnumerator AmbiantSound_Save ()
	{
		yield return new WaitForEndOfFrame ();
		if (AmbientSound.isOn) 
			PlayerPrefs.SetInt ("AmbientSound", 3);  //3 = true;
 		else
			PlayerPrefs.SetInt ("AmbientSound", 0);//0 = false;

	}

	IEnumerator ImageEffect_Save ()
	{
		yield return new WaitForEndOfFrame ();
		if (imageEffect.isOn)
			PlayerPrefs.SetInt ("ImageEffect", 3);  //3 = true;
		else
			PlayerPrefs.SetInt ("ImageEffect", 0);//0 = false;

	}

}
