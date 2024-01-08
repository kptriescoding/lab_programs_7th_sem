using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[ExecuteInEditMode]
public class Waypoints : MonoBehaviour {


	public List<Transform> waypoints =new List<Transform>();

	void OnDrawGizmos () 
	{

				
		Transform[] tn = GetComponentsInChildren<Transform> ();

		if (tn.Length > 0) 
		{
			waypoints.Clear ();

			foreach (Transform t in tn) {
				if (t != transform) 
				{
					waypoints.Add (t);
					Gizmos.color = new Color32(0,210,255,255);

					Gizmos.DrawSphere (t.position, 1f);
				}
			}

			for(int a = 0;a<tn.Length;a++)
			{
				
				if(a<tn.Length-2)
					Debug.DrawLine (tn [a+1].position, tn [a + 2].position, Color.green);
			}
		}
	}
}
