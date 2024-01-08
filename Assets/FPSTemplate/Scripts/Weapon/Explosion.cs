using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

	public float radius = 5.0f;
	public float power = 10.0f;

	void Start () {
		// Applies an explosion force to all nearby rigidbodies
		Vector3 explosionPos  = transform.position;
		Collider[] colliders  = Physics.OverlapSphere (explosionPos, radius);

		foreach (Collider hit  in colliders) {
			if (!hit)
				continue;

			if (hit.GetComponent<Rigidbody>())
				hit.GetComponent<Rigidbody>().AddExplosionForce(power, explosionPos, radius, 3.0f);
		}
	}
}
