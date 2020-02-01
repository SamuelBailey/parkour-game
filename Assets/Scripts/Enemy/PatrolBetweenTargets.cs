using UnityEngine;
using System.Collections;

public class PatrolBetweenTargets : MonoBehaviour {

	public Transform[] patrolPoints;
	public float moveSpeed = 2.0f;

	int currentPoint = 0;

	// Use this for initialization
	void Start () 
	{
		transform.position = patrolPoints [0].position; // moves the object to the first patrol point
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		Patrol ();
	}

	void Patrol ()
	{
		if (transform.position == patrolPoints [currentPoint].position) {
			currentPoint++;
		}

		if (currentPoint >= patrolPoints.Length) {
			currentPoint = 0;
		}

		//move towards next point
		transform.position = Vector3.MoveTowards (transform.position, patrolPoints[currentPoint].position, moveSpeed * Time.deltaTime);
	}

}
