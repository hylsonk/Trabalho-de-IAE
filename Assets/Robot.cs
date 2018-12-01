using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour {

	public float speed = 5.0f;
	public CharacterController controller;

	private ArrayList commands = new ArrayList();

	void Start(){
		controller = GetComponent<CharacterController>();
	}

	// Update is called once per frame
	void Update () {
		float horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
		float vertical = Input.GetAxis("Vertical") * Time.deltaTime * speed;

		Vector3 mov = new Vector3(horizontal,0,vertical);

		controller.Move(mov);

		GetKey();
	}

	void GetKey(){
		if(Input.GetKeyDown(KeyCode.UpArrow)){
			Debug.Log("UP");
			commands.Add("UP");
		}
		if(Input.GetKeyDown(KeyCode.DownArrow)){
			Debug.Log("DOWN");
			commands.Add("DOWN");
		}
		if(Input.GetKeyDown(KeyCode.RightArrow)){
			Debug.Log("RIGHT");
			commands.Add("RIGHT");
		}
		if(Input.GetKeyDown(KeyCode.LeftArrow)){
			Debug.Log("LEFT");
			commands.Add("LEFT");
		}
		if(Input.GetKeyDown(KeyCode.E)){
			Debug.Log("EXECUTE");
			Execute();
		}
	}

	void Execute(){
		foreach (string item in commands)
		{
			Debug.Log(item);
		}
	}
}
