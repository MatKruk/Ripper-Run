using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour 
{



	// Use this for initialization
	void Start () 
	{


	}


	void OnTriggerEnter (Collider other) 
	{
		
		//If the player presses r while in the trigger box they will control the horse
		if (other.gameObject.CompareTag("Trigger") && Input.GetKeyDown ("r")) 
		{

			//make it switch back on same button press
			//move player to location i.e. GameObject Jack

			//Find the Horse object that is found under Carriage
			GameObject disable = GameObject.Find("Carriage/Horse");
			//Find the HCamera Object that is found under Horse
			GameObject Hcamera = GameObject.Find("Carriage/Horse/HCamera");
			//Find the MainCamera that is on Jack
			GameObject Pcamera = GameObject.Find("Main Camera"); 

			Pcamera.GetComponent<Camera>().enabled = false; 
			Hcamera.GetComponent<Camera> ().enabled = true;


			//Disable player (Jack's) control script
			GetComponent<PlayerCamera> ().enabled = false;
			//Disable the MoveTo Script that is attached to the Horse object and enable the horse controls
			disable.GetComponent<MoveTo>().enabled = false;
			disable.GetComponent<HorseControl> ().enabled = true;
			//disable the NavMeshAgent as it interferes with the player controlled horse
			disable.GetComponent <UnityEngine.AI.NavMeshAgent>().enabled = false;
		}

			
	}
}

