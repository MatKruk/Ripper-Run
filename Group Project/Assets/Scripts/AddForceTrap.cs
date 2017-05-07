using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceTrap : MonoBehaviour {

	// In-Editor slider to adjust power of the added force
	[Range(0.0f, 100.0f)]
	public float power;

	bool playerInTrigger = false;
	bool isTriggered;

	public GameObject[] trapObj;	// Array of objects activated by the trap.
	public Rigidbody[] rBody;		// Array to store the RigidBodies of those objects.

	private GameObject player;

	// Things to do when script is first initialised.
	void Start() {
		//Debug.Log ("Test Script Started");
		isTriggered = false; // Mark trap as not triggered so when the level is reloaded the trigger function can fire.

		player = GameObject.FindGameObjectWithTag ("Player"); // Find the player character object using its "Player" tag.

		// For loop that grabs the rigid body of every GameObject
		// in the trapObj array and stores them in the rBody array.
		for (int i = 0; i < rBody.Length; i++)
		{
			rBody[i] = trapObj [i].GetComponent<Rigidbody> ();
		}
	}

	void OnTriggerEnter(Collider other)
	{
		// If statement to check if player entered the trigger.
		if (other.gameObject == player) 
		{
			//Debug.Log ("Player entered trigger.");
			playerInTrigger = true; //
		}


	}
	void Update()
	{
		trapTrigger();
	}

	// Main trigger function.
	void trapTrigger() {
		if (playerInTrigger == true) // Make sure player is in trigger to activate the trap.
		{
			if (isTriggered == false) // Prevents the script from adding force to the objects even when they are tipped over.
			{
				if (Input.GetKeyDown (KeyCode.T) || Input.GetButton("joystickY")) // Check for the right user input.
				{
					//Debug.Log ("Trap Key Pressed.");

					isTriggered = true; // Mark trap as triggered so it can't be reused.

					for (int i = 0; i < rBody.Length; i++) // For loop that iterates through every object in the trap
					{
						rBody [i].isKinematic = false; 	// set the rigid body of the object to non kinematic so that it can
														//be affected by forces.

						rBody [i].AddForce (transform.forward * power, ForceMode.Impulse); 	// add forward impulse force  
																							// to the object depending
																							// on the power selected
					}
				}
			}
		}
	}



	// OLD ------------------------------------------------------------------------------

	//void Update()
	//{
	//	if (playerInTrigger == true) {
	//		if (Input.GetKeyDown (KeyCode.E)) {
	//			Debug.Log ("E Key Pressed.");
	//
	//			for (int i = 0; i < rBody.Length; i++) {
	//				rBody [i].isKinematic = false;
	//
	//				rBody [i].AddForce (transform.forward * power, ForceMode.Impulse);
	//			}
	//		}
	//	}
	//}

	//void OnTriggerStay(Collider other)
	//{
	//	Debug.Log ("Player in trigger.");
	//	if (other.gameObject == player) {
	//		if (Input.GetKeyDown (KeyCode.E)) {
	//			Debug.Log ("E Key Pressed.");
	//
	//			for (int i = 0; i < rBody.Length; i++)
	//			{
	//				rBody[i].isKinematic = false;
	//			
	//				rBody[i].AddForce (transform.forward * power, ForceMode.Impulse);
	//			}
	//		}
	//	}
	//}



	//void OnMouseOver()
	//{
	//	Debug.Log ("Mouse over");
	//	if (Input.GetKeyDown (KeyCode.E)) {
	//		
	//		rb.AddForce (transform.forward * 150);
	//	}
	//}
}
