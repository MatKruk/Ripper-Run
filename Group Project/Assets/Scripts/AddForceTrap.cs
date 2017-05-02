using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceTrap : MonoBehaviour {

	[Range(0.0f, 100.0f)]
	public float power;

	bool playerInTrigger = false;
	public static bool policeInTrigger = false;
	public static bool isTriggered = false;

	public GameObject[] trapObj;	// Array of objects activated by the trap.
	public Rigidbody[] rBody;		// Array to store the RigidBodies of those objects.

	private GameObject player;
	private GameObject police;

	void Start() {
		Debug.Log ("Test Script Started");

		player = GameObject.FindGameObjectWithTag ("Player");
		police = GameObject.FindGameObjectWithTag ("Police");
		//police = GameObject.FindWithTag ("Police");
		Debug.Log(police);
		for (int i = 0; i < rBody.Length; i++)
		{
			rBody[i] = trapObj [i].GetComponent<Rigidbody> ();
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == police) {
			Debug.Log ("Police entered trigger. " + policeInTrigger);
			policeInTrigger = true;
		}
		//EnemyAi.chaseSpeed
		if (other.gameObject == player) {
			Debug.Log ("Player entered trigger.");
			playerInTrigger = true;
		}


	}
	void Update()
	{
		trapTrigger();
	}

	void OnTriggerExit(Collider other){
		
		if (other.gameObject == police) {
			Debug.Log ("Police exited trigger.");
			policeInTrigger = false;
		}
		if (other.gameObject == player) {
			Debug.Log ("Player exited trigger.");
		}
	}
		
	void trapTrigger() {
		if (playerInTrigger == true)
		{
			if (Input.GetKeyDown (KeyCode.T) || Input.GetButton("joystickY"))
			{
				Debug.Log ("T Key Pressed.");
				//isTriggered = true;
				//other.gameObject.tag == "Trap";
	
				for (int i = 0; i < rBody.Length; i++)
				{
					rBody [i].isKinematic = false;
	
					rBody [i].AddForce (transform.forward * power, ForceMode.Impulse);


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
