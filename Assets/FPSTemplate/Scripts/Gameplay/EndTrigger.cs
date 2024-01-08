// This script hase benn used to destroy enemy vehicles on end of the path
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour {

	public string enemyTag = "Enemy";

	GameManager manager;

	void Start()
	{
		manager = GameObject.FindObjectOfType<GameManager>();
	}

	void OnTriggerEnter (Collider col) 
	{

		if(col.CompareTag(enemyTag))
		{
			manager.AddEnemysEscape();
			Destroy(col.gameObject);

		}
	}
}
