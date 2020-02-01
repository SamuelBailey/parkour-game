using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed = 7.5f;
	public float jumpHeight = 450.0f;
	public float jumpDelay = 0.5f;
	public float fallSpeed = 13.0f;
	public float maxSpeed = 30.0f;

	Vector3 spawnLocation;

	Vector3 movement;
	Animator anim;
	Rigidbody playerRigidbody;

	//jumping variables
	bool canJump = true;
	float jumpTimer = 0.0f;
	float lastVerticalVelocity = 0.0f;

	float resetTimer;

	// is called at the start regardless as to whether the script is active or not.
	void Awake()
	{
		//floorMask = LayerMask.GetMask ("Floor");
		anim = GetComponent <Animator> ();
		playerRigidbody = GetComponent <Rigidbody> ();
		spawnLocation = transform.position;
		resetTimer = 0.0f;
	}


	
	// Update is called once per physics update
	void FixedUpdate ()
	{
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");

		if (h != 0.0f || v != 0.0f) {
			GameController.levelStarted = true;
		}

		Move (h, v);
		Turning ();
		Animating (h, v);
		Falling ();
		Jumping ();
		Reset ();
		LimitSpeed ();
	}

	//jumping
	void OnCollisionEnter (Collision col)
	{
		if (col.collider.tag == "Floor") {
			canJump = true;
			//Debug.Log ("Can jump");
		}

		if (col.collider.tag == "Enemy") {
			Die ();
		}
	}



	void OnTriggerEnter (Collider col)
	{
		if (col.transform.tag == "Goal") {
			GameController.levelStarted = false;
			GameController.EndLevel (1);
		}
		if (col.transform.tag == "Respawn") {
			spawnLocation = col.transform.position;
		}
	}

	void Move (float h, float v)
	{
		movement.Set (h, 0f, v);

		movement = movement.normalized * speed * Time.deltaTime;

		playerRigidbody.MovePosition (movement + transform.position);
	}

	void Turning ()
	{

		Quaternion newRotation = new Quaternion (0.0f, 0.0f, 0.0f, 1.0f);
		if (movement.magnitude != 0.0f) {
			newRotation = Quaternion.LookRotation (movement);
			playerRigidbody.MoveRotation (newRotation);
		}
		//playerRigidbody.MoveRotation (newRotation);
	}

	void Animating (float h, float v)
	{
		bool running = h != 0 || v != 0;
		anim.SetBool ("IsRunning", running);
	}



	void Jumping ()
	{
		//if vertical acceleration == 0, allow the player to jump
		if ((playerRigidbody.velocity.y - lastVerticalVelocity) / Time.deltaTime == 0.0f) {
			canJump = true;
		}
		lastVerticalVelocity = playerRigidbody.velocity.y;

		if ((canJump == true) && (Input.GetAxisRaw ("Jump") != 0.0f) && ((Time.time - jumpTimer) > jumpDelay)) {
			Vector3 jumpForce = new Vector3 ();
			jumpForce.Set (0.0f, jumpHeight, 0.0f);
			playerRigidbody.AddForce (jumpForce * Time.deltaTime, ForceMode.Impulse);
			anim.SetBool ("IsJumping", true);
			jumpTimer = Time.time;
			canJump = false;
		} else {
			anim.SetBool ("IsJumping", false);
		}
	}

	void Falling()
	{
		if (playerRigidbody.velocity.y < -fallSpeed) {
			anim.SetBool ("IsFalling", true);
		} else {
			anim.SetBool ("IsFalling", false);
		}
	}



	void Die()
	{
		GameController.numberOfDeaths++;
		transform.position = spawnLocation;
	}

	void Reset()
	{
		if (Input.GetAxisRaw ("Reset") != 0.0f) {
			if (Time.time > resetTimer + 0.5f) {
				Die ();
				resetTimer = Time.time;
			}
		}
	}

	void LimitSpeed ()
	{
		if (playerRigidbody.velocity.magnitude > maxSpeed) {
			playerRigidbody.velocity = playerRigidbody.velocity.normalized * maxSpeed;
		}
	}
}
