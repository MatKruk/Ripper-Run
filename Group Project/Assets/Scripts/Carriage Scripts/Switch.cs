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

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown ("r")/*trigger box*/) 
		{
			//Find the Horse object that is found under Carriage
			GameObject disable = GameObject.Find("Carriage/Horse");
			//GameObject hcScript = GameObject.Find("Carriage/Horse");
			//GameObject dNav = GameObject.Find ("Carriage/Horse");

			//Disable player (Jack's) controls
			GetComponent<PlayerCamera> ().enabled = false;
			//Disable the MoveTo Script that is attached to the Horse object
			disable.GetComponent<MoveTo>().enabled = false;
			disable.GetComponent<HorseControl> ().enabled = true;

			//disable the NavMeshAgent as it interferes with the player controlled horse
			disable.GetComponent <UnityEngine.AI.NavMeshAgent>().enabled = false;
		}

			
	}
}

