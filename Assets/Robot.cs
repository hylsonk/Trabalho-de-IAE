using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour {

	public float speed = 1f;
	public CharacterController controller;

	private ArrayList commands = new ArrayList();

	private bool execute = false;
	private int count = 0;

	void Start(){
		controller = GetComponent<CharacterController>();
		Debug.Log("Start");
	}

	// Update is called once per frame
	void Update () {
Debug.Log("oi");
		if (execute){
			Exec();
		}else{
			GetKey();
		}	
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
			execute = true;
		}
	}

	void Exec(){
		if (commands.Count > count)
		{
			float horizontal = GetComponent<Transform>().position.x;
			float vertical = GetComponent<Transform>().position.y;
			Vector3 mov = new Vector3(0,0,0);

			Debug.Log(commands[count]);
			string test = commands[count].ToString();
			switch(test){
				case "UP":
					vertical = vertical + speed;
					mov = new Vector3(0,0,vertical);
					break;
				case "DOWN":
					vertical = vertical - speed;
					mov = new Vector3(0,0,vertical);
					break;
				case "RIGHT":
					horizontal = horizontal + speed;
					mov = new Vector3(horizontal,0,0);
					break;
				case "LEFT":
					horizontal = horizontal - speed;
					mov = new Vector3(horizontal,0,0);
					break;
				default:
					break;
			}
			//mov = new Vector3(horizontal,0,vertical);

			controller.Move(mov);
			count++;
		}
		else{
			count = 0;
			commands = new ArrayList();
			execute = false;
		}
	}
}
