using UnityEngine;
using System.Collections;

public class Aim : MonoBehaviour {


	// View camera to change his field of view on aiming
	public Camera targetCamera;

	public FPS_Weapon weaponScript;

	public Vector3 posAimOn;

	// Lerp aiming state
	public float aimSpeed = 10f;

	// Aiming field of view
	public float aimFov = 47f;

	// Store aiming state
	bool isAim;
	float defaultFov = 60f;

	// used to change mouse look spped in aiming on
	MouseLook[] ml;
	float defaultSensitivityX,defaultSensitivityY;

	void Start()
	{

		defaultFov = targetCamera.fieldOfView;
		ml = GetComponentsInParent<MouseLook> ();

		defaultSensitivityX = ml [0].sensitivityX;
		defaultSensitivityY = ml [0].sensitivityY;

	}

	void Update () {

		if(Input.GetKeyDown(KeyCode.E))
		{
			isAim = !isAim;
			weaponScript.Aimed = isAim;
		}


		if (isAim) {
			transform.localPosition = Vector3.Lerp( transform.localPosition, posAimOn, Time.deltaTime * aimSpeed );
			targetCamera.fieldOfView = Mathf.Lerp (targetCamera.fieldOfView, aimFov, Time.deltaTime * aimSpeed);
			ml [0].sensitivityX = defaultSensitivityX / 2;
			ml [1].sensitivityX = defaultSensitivityX / 2;
			ml [0].sensitivityY = defaultSensitivityY / 2;
			ml [1].sensitivityY = defaultSensitivityY / 2;
		} else {
			transform.localPosition = Vector3.Lerp( transform.localPosition, Vector3.zero, Time.deltaTime * aimSpeed );
			targetCamera.fieldOfView = Mathf.Lerp (targetCamera.fieldOfView, defaultFov, Time.deltaTime * aimSpeed);
			ml [0].sensitivityX = defaultSensitivityX;
			ml [1].sensitivityX = defaultSensitivityX;
			ml [0].sensitivityY = defaultSensitivityY;
			ml [1].sensitivityY = defaultSensitivityY;
		}

	}

	public void TouchAim()
	{
		isAim = !isAim;
		weaponScript.Aimed = isAim;
	}

}
