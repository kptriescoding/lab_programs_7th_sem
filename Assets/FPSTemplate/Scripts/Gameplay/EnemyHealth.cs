using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

	public int totalHealth = 100;
	public GameObject destroyedModel;
	GameManager manager;

	void Start()
	{
		manager = GameObject.FindObjectOfType<GameManager>();
	}

	public void ChangeHealth(int amount)
	{

		totalHealth-=amount;

		if(totalHealth<=0)
		{

			Instantiate(destroyedModel,transform.position,transform.rotation);
			manager.AddEnemysDestroyed();
			Destroy(gameObject);
		}
	}

}