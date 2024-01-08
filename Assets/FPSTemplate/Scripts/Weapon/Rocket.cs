using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour {

	public GameObject explosion;

	void Start()
	{
		transform.rotation = GetComponentInParent<Transform> ().rotation;
	}

	void OnCollisionEnter (Collision col)
	{

		Instantiate (explosion, transform.position, transform.rotation);
		GetComponent<Rigidbody> ().isKinematic = true;
		ParticleSystem.EmissionModule em = GetComponentInChildren<ParticleSystem>().emission;
		em.enabled = false;


		if(col.collider.CompareTag("Enemy"))
			col.collider.GetComponent<EnemyHealth>().ChangeHealth(70);
		
		Destroy(gameObject,7f);

	}
}
