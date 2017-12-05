using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {

	public Vector2 movement = new Vector2 ();

	void Update () {

		movement.x = movement.y = 0;

		if (Input.GetKey ("right") || Input.GetKey ("d")) {
			movement.x = 1f;
		} else if (Input.GetKey ("left") || Input.GetKey ("a")) {
			movement.x = -1f;
		}
			
		if (Input.GetKey ("up") || Input.GetKey ("w")) {
			movement.y = 1f;
		} else if (Input.GetKey ("down") || Input.GetKey ("s")) {
			movement.y = -1f;
		}
			
	}
}
