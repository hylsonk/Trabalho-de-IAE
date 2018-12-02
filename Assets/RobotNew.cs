using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotNew : MonoBehaviour {


	CharacterController characterController;
	public Vector3 endPosition;
	float moveSpeed = 1.0f;

	float distance = 2.0f;
	
	private ArrayList commands = new ArrayList();

	int count = 0;
	//Flags
	bool execution = false;
	bool inMovement = false;

	Vector3 actualPosition;
	// Use this for initialization
	void Start () {
		characterController = GetComponent<CharacterController>();
		endPosition = GetComponent<Transform>().position;
		endPosition.x = endPosition.x - distance;
	}
	
	// Update is called once per frame
	void Update () {
		if((!execution) && (!inMovement)){
			GetKey();	
		}else if(execution && (!inMovement)){
			Execute();
		}else{
			MoveTowardsTarget(endPosition);
		}
	}

	void MoveTowardsTarget(Vector3 targetPosition){
		Vector3 offset = targetPosition - transform.position;

		if(offset.magnitude > .1f){
			offset = offset.normalized * moveSpeed;

			characterController.Move(offset * Time.deltaTime);
		}

		actualPosition = GetComponent<Transform>().position;
		Vector3 diff = endPosition-actualPosition;
		if (diff.magnitude < 0.1)
		{
			count++;
			inMovement = false;
		}
		Debug.Log(actualPosition);
		Debug.Log(endPosition);
		Debug.Log(count);
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
			execution = true;
		}
	}

	void Execute(){
		if (commands.Count > count)
		{	
			endPosition = GetComponent<Transform>().position;
			Debug.Log(commands[count]);
			string test = commands[count].ToString();
			switch(test){
				case "UP":
					endPosition.z = endPosition.z + distance;
					break;
				case "DOWN":
					endPosition.z = endPosition.z - distance;
					break;
				case "RIGHT":
					endPosition.x = endPosition.x + distance;
					break;
				case "LEFT":
					endPosition.x = endPosition.x - distance;
					break;
				default:
					break;
			}
			inMovement = true;
		}
		else{
			count = 0;
			commands = new ArrayList();
			execution = false;
		}
	}
}
