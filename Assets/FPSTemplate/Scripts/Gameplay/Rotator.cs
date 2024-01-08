using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {


	public Vector3 val;
	public float speed = 14f;

	void Update () 
	{
		transform.Rotate (val * Time.deltaTime * speed);
	}
}
