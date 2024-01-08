using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public string wayPointName = "Waypoint_0";

		// put the points from unity interface
		Waypoints wayPointList;

		public int currentWayPoint = 0; 
		Transform targetWayPoint;

		public float moveSpeed = 4f;
		public float rotateSpeed = 3f;

		void Start () 
		{
			wayPointList = GameObject.Find (wayPointName).GetComponent < Waypoints> ();
		}

		void Update () 
		{
		
			// check if we have somewere to walk
			if(currentWayPoint < wayPointList.waypoints.Count)
			{
				if(targetWayPoint == null)
					targetWayPoint = wayPointList.waypoints[currentWayPoint];
			
				
					MoveNext();
			}
		}

		void MoveNext()
		{
		
			// rotate towards the target
			transform.forward = Vector3.RotateTowards(transform.forward, targetWayPoint.position - transform.position, rotateSpeed/10*Time.deltaTime, 0.0f);

			// move towards the target
			transform.position = Vector3.MoveTowards(transform.position, targetWayPoint.position,   moveSpeed*Time.deltaTime);

			if(transform.position == targetWayPoint.position)
			{
				if (currentWayPoint < wayPointList.waypoints.Count-1)
					currentWayPoint++;

					targetWayPoint = wayPointList.waypoints[currentWayPoint];
			}
		} 
	}