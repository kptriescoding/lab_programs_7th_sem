using UnityEngine;
using System.Collections;

public class WeaponInput : MonoBehaviour {

	[HideInInspector]public FPS_Weapon currentWeapon;
	Aim aimHandler;

	void Awake()
	{
		currentWeapon = GameObject.FindObjectOfType<FPS_Weapon> ();

		aimHandler = GameObject.FindObjectOfType<Aim> ();

	}

	public void Fire(bool state)
	{
		currentWeapon.isFireInput = state;
		if (!state) {
			if (currentWeapon.fireStarted) {
			
				currentWeapon.FireEnd ();
			
				currentWeapon.fireStarted = false;
			}
		}
	}

	public void Aiming()
	{
		aimHandler.TouchAim();
	}

}
