using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {


	public GameObject[] enemyPrefabs;
	public float minTime = 10f;
	public float maxTime = 21f;
	float spawnTime;
	int number;

	IEnumerator Start () {


		while(true)
		{
			RandomTime();
			yield return new WaitForSeconds(spawnTime);
			Instantiate(enemyPrefabs[number],transform.position,transform.rotation);
			if(number<enemyPrefabs.Length-1)
				number++;
			else
				number = 0  ;
		}
	}

	void RandomTime()
	{
		spawnTime = Random.Range(minTime,maxTime);
	}
}
