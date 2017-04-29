using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour 
{


	// Use this for initialization
	void Start () 
	{
		/*GetComponent<PlayerCamera> ().enabled = true;
		//GetComponent<MoveTo> ().enabled = true;
		//GetComponent<HorseControl> ().enabled = false;*/

	}


	void OnTriggerEnter (Collider other) 
	{
		//If the player presses r while in the trigger box they will control the horse
		if (other.gameObject.CompareTag("Trigger") && Input.GetKeyDown ("r")) 
		{
			//Find the Horse object that is found under Carriage
			GameObject disable = GameObject.Find("Carriage/Horse");
			//GameObject hcScript = GameObject.Find("Carriage/Horse");
			//GameObject dNav = GameObject.Find ("Carriage/Horse");

			//Disable player (Jack's) controls
			GetComponent<PlayerCamera> ().enabled = false;
			//Disable the MoveTo Script that is attached to the Horse object and enable the horse controls
			disable.GetComponent<MoveTo>().enabled = false;
			disable.GetComponent<HorseControl> ().enabled = true;

			//disable the NavMeshAgent as it interferes with the player controlled horse
			disable.GetComponent <UnityEngine.AI.NavMeshAgent>().enabled = false;
		}

			
	}
}

