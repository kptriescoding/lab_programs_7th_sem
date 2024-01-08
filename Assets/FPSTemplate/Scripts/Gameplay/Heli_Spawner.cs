using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Heli_Spawner : MonoBehaviour {


	// Soldier prefab (enemy) 
	public GameObject soldier;

	// Spawn point
	public Transform spawnPoint;

	// Helicopter rope
	public GameObject spawnRope;

	// Total spawn time
	public float spawnTime  =  10f;

	// Delay before each spawn
	public float spawnDelay;

	bool entered;


	void OnTriggerEnter(Collider col)
	{

		if (!entered) {
			

			if (col.CompareTag ("Heli_Spawner")) {
				spawnRope.SetActive (true);
				StartCoroutine ("StartSpawn");
				Debug.Log ("entered"+spawning);
			}
		}

	}


	bool spawning = true;

	IEnumerator StartSpawn()
	{
		entered = true;

		StartCoroutine ("FinishSpawn");

		while (spawning == true) 
		{
			Debug.Log ("spawning");
			yield return new WaitForSeconds (spawnDelay);

			Instantiate (soldier, spawnPoint.position, spawnPoint.rotation);

		}

	}

	IEnumerator FinishSpawn()
	{
		
		spawning = false;

		yield return new WaitForSeconds (spawnTime);

	}
}
