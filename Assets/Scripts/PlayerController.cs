using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed = 10f;
	public float maxVelocityX = 3f;
	public float maxVelocityY = 5f;

	private bool grounded;
	public float flySpeed = 15f;
	public float airSpeed = 0.3f;

	private Rigidbody2D myBody;
	private Animator anim;
	private MovementController movementController;

	void Awake()
	{
		myBody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		movementController = GetComponent<MovementController> ();
	}

	void Update()
	{
		var forceX = 0f;
		var forceY = 0f;

		var absX = Mathf.Abs (myBody.velocity.x);
		var absY = Mathf.Abs (myBody.velocity.y);

		if (absY < 0.2f) {
			grounded = true;
		} else {
			grounded = false;
		}

		if (movementController.movement.x != 0) {

			if (absX < maxVelocityX) {

				if (grounded) {
					forceX = speed * movementController.movement.x;
				} else {
					forceX = speed * movementController.movement.x * airSpeed;
				}	
			}

			if (forceX > 0) {
				transform.localScale = new Vector3 (0.3f, 0.3f, 1f);
			} else if (forceX < 0) {
				transform.localScale = new Vector3 (-0.3f, 0.3f, 1);
			}

			anim.SetInteger ("State", 1);
				
		} else {
			anim.SetInteger ("State", 0);
		}

		if (movementController.movement.y != 0) {

			if (absY < maxVelocityY) {
				forceY = flySpeed * movementController.movement.y;
				anim.SetInteger ("fly", 2);
			}

		} else if(absY > 0) {
			anim.SetInteger ("fly", 3);
		}


		myBody.AddForce (new Vector2 (forceX, forceY));
	}	
}
