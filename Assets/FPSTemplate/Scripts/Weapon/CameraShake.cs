using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {

	public bool Shaking; 
	public float ShakeDecay;
	public float ShakeIntensity;    
	private Vector3 OriginalPos;
	private Quaternion OriginalRot;
	public Transform parent;

	void Start()
	{
		Shaking = false;  
	}


	// Update is called once per frame
	void Update () 
	{
		if(ShakeIntensity > 0)
		{
			transform.position = OriginalPos + Random.insideUnitSphere * ShakeIntensity;
			transform.rotation = new Quaternion(OriginalRot.x + Random.Range(-ShakeIntensity, ShakeIntensity)*.2f,
				OriginalRot.y + Random.Range(-ShakeIntensity, ShakeIntensity)*.2f,
				OriginalRot.z + Random.Range(-ShakeIntensity, ShakeIntensity)*.2f,
				OriginalRot.w + Random.Range(-ShakeIntensity, ShakeIntensity)*.2f);

			ShakeIntensity -= ShakeDecay;
		}
		else if (Shaking)
		{
			Shaking = false;  
		}

		transform.position = Vector3.Lerp (transform.position, parent.position, Time.deltaTime * 10);
		transform.rotation = Quaternion.Lerp (transform.rotation, parent.rotation, Time.deltaTime * 10);

	}

	public void DoShake(float i,float d)
	{
		OriginalPos = transform.position;
		OriginalRot = transform.rotation;

		ShakeIntensity = i;
		ShakeDecay = d;
		Shaking = true;
	}    


}
