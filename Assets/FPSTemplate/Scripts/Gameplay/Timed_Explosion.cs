using UnityEngine;
using System.Collections;

public class Timed_Explosion : MonoBehaviour {

	public float tTime;
	public Transform[] points;

	public GameObject explostions;

	public int number;

	public AudioSource mortarSound;

	IEnumerator Start () {

		while (true) {

				mortarSound.Play ();
			yield return new WaitForSeconds (tTime);
			Instantiate (explostions, points [number].position, points [number].rotation);
			number+=1;

			if(number==points.Length)
				number = 0;
		}
	}
	



}
