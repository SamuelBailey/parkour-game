using UnityEngine;
using System.Collections;

public class MoveTowardsTarget : MonoBehaviour {

	public Transform[] targets;
	public float moveSpeed = 2.0f;

	int currentTarget = 0;
	bool canMove = true;

	// Use this for initialization
	void Start () 
	{
		transform.position = targets [0].position;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		Move ();
	}

	void Move ()
	{
		if (transform.position == targets [targets.Length - 1].position) {
			canMove = false;
		} else if (transform.position == targets [currentTarget].position) {
			currentTarget++;
		}

		if (canMove == true) {
			transform.position = Vector3.MoveTowards (transform.position, targets[currentTarget].position, moveSpeed * Time.deltaTime);
		}
	}

}
