using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour {


	public float  destroyTime = 0.3f;
	void Awake () {
		Destroy (gameObject, destroyTime);
	}
}
