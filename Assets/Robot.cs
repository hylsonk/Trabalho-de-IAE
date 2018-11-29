using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour {

	public float speed = 5.0f;
	public CharacterController controller;

	// Update is called once per frame
	void Update () {
		float horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
		float vertical = Input.GetAxis("Vertical") * Time.deltaTime * speed;

		Vector3 mov = new Vector3(horizontal,0,vertical);

		controller.Move(mov);
	}
}
