/// <summary>
/// //////////////////////////////////////////////
/// 
/// 
/// 	   ALIyerEdon   -    Winter 2017    
/// 	Orginlly wrote for my game in 2016
/// 
/// 	Based on first unity fps tutorial and sample project (I have read that first time in 2009 adn again in 2016 :)    
/// 		 aliyeredon@gmail.com
/// 
/// 
/// //////////////////////////////////////////////
/// </summary>
using UnityEngine;
using System.Collections;


public class FPS_Weapon : MonoBehaviour {

	// Rocket model is deactivated when fired,  rocket prefab will instantiated when firing and going to forward direction and boom ...    
	public GameObject rocketModel,rocketPrefab;

	// Calculate time passed between each fire ( depend on frame rate, Calculated in update function) 
	float fireTimer;

	// Weapon firing rate (Means delay befor each fire) 
	public float fireRate = 0.1f;

	// Weapon power that is applied to hitted target's rigidbody
	public float Power = 30f;

	// Raycasting shoot spot, Instantiate rocket prefab from here (fireShootSpot)
	public Transform fireShootSpot;

	// Weapon reload time used to delay before reload animation
	// Reload speed used to delay before fill the ammo (I have used this for weapon reload time upgrade)    
	public float reloadTime  =  1f;

	// Firing muzzle flash particle (Will be activated when firing and deactivated when firing is finished)
	public ParticleSystem fireMuzzle;

	// Sound effects
	public AudioClip fireSound,reloadSound;

	// This will be played when each fire is finished ( Playback of the voice on the mountain)
	public AudioSource fireEndSound;

	// Temp
	public bool canFire = true,Reloading = false;

	// Crosshair texture (2d)
	public Texture2D crosshairImage,crosshairHited;

	// Randomize crosshair size when firing => You need to Activate for rifles and deActivate for others
	public bool crossHairRandomize;

	// This is Crosshairs temp rec
	public Rect position;

	// Weapon Crosshairs minSize,maxSize, sizeSpeed , sizeAmount
	public float crosshairMin = 0.14f,crosshairMax = 1.4f,crosshairSpeed = 3f,crosshairsAmount = 0.14f;

	// Recoiling system
	public float RecoilAmount = 1f;  // Recoiling amount

	public float RecoilSpeed = 10f; // Recoil speed

	// Camera shake values when firing
	public float cameraShakeIntensity = 0.1f,cameraShakeDecay = 0.02f;

	// Camera shake component
	CameraShake cameraShake;

	// Weapon model for recoiling    
	public GameObject weaponModel;

	// Reaload animator (Animated with unity Animation window)
	public Animator reloadAnim;

	//  private variables
	RaycastHit hit;
	int currentAmmo = 0;
	AudioSource audioSource;
	bool enemyHit;
	Camera mainCamera;
	// used to play end firing sound effect just after fired  (controlled in ImputSystem component) 
	public bool fireStarted;

	void Awake()
	{
		currentAmmo = 1;
	}
	void Start ()
	{
		// Find camera shake component
		cameraShake = GameObject.FindObjectOfType<CameraShake> ();

		// Catch audoiSource 
		audioSource = GetComponent<AudioSource> ();

		// Catch main camera
		mainCamera = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera>();

		// Setup audio sources settings on start    
		audioSource.loop = false;

		audioSource.clip = fireSound;

		// Hide audio source component
		audioSource.hideFlags = HideFlags.HideInInspector;


	}

	void Update () 
	{

		// Calculate fireTimer based on delta time
		fireTimer += Time.deltaTime;

		// Read fire inputs
		RocketInput ();

		// Recoiling is coming to his forst position in every frame
		weaponModel.transform.position = Vector3.Lerp (weaponModel.transform.position, transform.position, Time.deltaTime * RecoilSpeed);

	}

	// Reload system ( Delay before next fire, play weapon animation with finding them with his tag    )
	IEnumerator Reload()
	{

		yield return new WaitForSeconds (1f);

		// Stop firing sound when reloading
		audioSource.Stop ();

		// Play reload sound
		if (audioSource)
			audioSource.PlayOneShot (reloadSound);

		// Find weapon animated model with his tag and play his Reload animation clip (Legacy) 

		// GameObject.FindGameObjectWithTag ("WeaponGun").GetComponent<Animation> ().CrossFade ("reload");

		// Player reload animation thats attached to reload game object under player root game object
		if (reloadAnim)
			reloadAnim.SetBool ("Reload", true);
		else
			Debug.Log ("Assign Reload Animator");
		
		// Wait and resume reload animation
		yield return new WaitForSeconds (reloadTime);

		if (reloadAnim)
			reloadAnim.SetBool("Reload",false);

		// Activate rocket launcher rocket model (We need to disable on each fire)   
		rocketModel.SetActive (true);

		currentAmmo = 1;

		// Now player can fire again
		canFire = true;

		// Reloading  has been finished
		Reloading = false;

	}

	// Rocket launcher fire function
	public void RocketFire()
	{

		// Diactivate rocket model attached to rocket launcher on each fire and activate it after reloading
		rocketModel.SetActive (false);

		fireTimer = 0;

		currentAmmo -= 1;

		cameraShake.DoShake(cameraShakeIntensity,cameraShakeDecay);

		if (!Reloading) {
			if (audioSource)
				audioSource.PlayOneShot (fireSound);
		}

		GameObject clone ; //variable within a variable

		clone = (GameObject)Instantiate(rocketPrefab, fireShootSpot.position, fireShootSpot.rotation); //the clone variable holds our instantiate action

		// Add forece to rocket prefab's rigidbody
		clone.GetComponent<Rigidbody>().AddForce (fireShootSpot.forward * Power * 100);

		// recoil
		weaponModel.transform.Translate (new Vector3 (0, 0, -RecoilAmount), Space.Self);

		fireStarted = true;
	}

	// Read rocket launcher input (Controlled in InputSystem component)   
	public void RocketInput()
	{
		// When  can fire!!!
		if (isFireInput && fireTimer >= fireRate && currentAmmo > 0 && canFire)
		{
			// Player is pressed fire button (Controlled in InputSystem component)    
			RocketFire ();
			// Enable muzzle flash particle emission
			fireMuzzle.enableEmission = true;

			// Randomize crosshair texture size when firing
			if (crossHairRandomize)
				crosshairsAmount = Mathf.Lerp (crosshairMin, Random.Range (crosshairMin, crosshairMax), crosshairSpeed * Time.deltaTime);
			else
				crosshairsAmount = Mathf.Lerp (crosshairMin, crosshairMax, crosshairSpeed * Time.deltaTime);

		} 
		else 
		{
			// Return crosshair texture size to the default value
			crosshairsAmount = Mathf.Lerp (crosshairsAmount, crosshairMin, crosshairSpeed * 2 * Time.deltaTime); 
			// Disable muzzle flash emisstion
			fireMuzzle.enableEmission = false;
		}

		// Check Ammunition and reloading state
		if (currentAmmo <= 0 &&!Reloading) 
		{
			canFire = false;
			Reloading = true;
			StartCoroutine (Reload());
		}

	}

	// Used in end of the firing sound effect (is    temp)
	public bool isFireInput;

	// Stop firing sound in fireing end (controlled in inputSystem) and play fire end sound effect 
	public void FireEnd()
	{

		if (fireEndSound)
			fireEndSound.Play ();

		fireStarted = false;
		
	}

	// Internal usage
	public bool Aimed;

	// OnGUI for weapon Crosshairs
	void OnGUI()
	{
		if (!Aimed) 
		{
				position = new Rect ((Screen.width - crosshairImage.width * crosshairsAmount) / 2, (Screen.height - crosshairImage.height * crosshairsAmount) / 2, crosshairImage.width * crosshairsAmount, crosshairImage.height * crosshairsAmount);
				GUI.DrawTexture (position, crosshairImage);
		}
	}

}
