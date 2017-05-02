using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour 
{
	public int num = 1;


	// Use this for initialization
	void Start () 
	{


	}


	void OnTriggerEnter (Collider other) 
	{

		//Find the Horse object that is found under Carriage
		GameObject horse = GameObject.Find ("Carriage/Horse");
		//GameObject horsePos = GameObject.Find ("Carriage/Horse").transform.position;
		//Find the HCamera Object that is found under Horse
		GameObject Hcamera = GameObject.Find ("Carriage/Horse/HCamera");
		//Find the MainCamera that is on Jack
		GameObject Pcamera = GameObject.Find ("Main Camera"); 

		//TO DO: make it switch back on same button press

		//If the player presses r while in the trigger box they will control the horse
		if (other.gameObject.CompareTag ("Trigger") && Input.GetKeyDown ("r") && num == 1) {


			//set Camera to horse
			Pcamera.GetComponent<Camera> ().enabled = false; 
			Hcamera.GetComponent<Camera> ().enabled = true;


			//Disable player (Jack's) control script
			GetComponent<PlayerCamera> ().enabled = false;
			//Disable the MoveTo Script that is attached to the Horse object and enable the horse controls
			horse.GetComponent<MoveTo> ().enabled = false;
			horse.GetComponent<HorseControl> ().enabled = true;
			//disable the NavMeshAgent as it interferes with the player controlled horse
			horse.GetComponent <UnityEngine.AI.NavMeshAgent> ().enabled = false;

			//makes Jack a child of Horse (this is a weird comment)
			transform.parent = GameObject.Find ("Carriage/Horse").transform;


			num = 2;

		} 
		//you still have to be in the triggerbox to get off because of OnTriggerEnter
		else if (Input.GetKeyDown ("r") && num == 2) 
		{

			//set camera back to Jack
			Pcamera.GetComponent<Camera> ().enabled = true; 
			Hcamera.GetComponent<Camera> ().enabled = false;		


			//Enable player (Jack's) control script
			GetComponent<PlayerCamera> ().enabled = true;
			//enable the MoveTo Script that is attached to the Horse object and disable the horse controls
			horse.GetComponent<MoveTo> ().enabled = true;
			horse.GetComponent<HorseControl> ().enabled = false;
			//enable the NavMeshAgent as it interferes with the player controlled horse
			horse.GetComponent <UnityEngine.AI.NavMeshAgent> ().enabled = true;

			//makes Jack have no Parent
			transform.parent = null;

			num = 1;


		}

			
	}
}

