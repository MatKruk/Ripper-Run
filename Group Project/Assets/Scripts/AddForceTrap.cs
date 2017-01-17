using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceTrap : MonoBehaviour {

	[Range(0.0f, 100.0f)]
	public float power;

	public GameObject TrapObj1;
	public GameObject TrapObj2;
	public GameObject TrapObj3;
	public GameObject TrapObj4;
	public GameObject TrapObj5;
	public GameObject TrapObj6;
	public Rigidbody rb1;
	public Rigidbody rb2;
	public Rigidbody rb3;
	public Rigidbody rb4;
	public Rigidbody rb5;
	public Rigidbody rb6;

	private GameObject player;

	void Start() {
		Debug.Log ("Test Script Started");

		player = GameObject.FindGameObjectWithTag ("Player");

		rb1 = TrapObj1.GetComponent<Rigidbody> ();
		rb2 = TrapObj2.GetComponent<Rigidbody> ();
		rb3 = TrapObj3.GetComponent<Rigidbody> ();
		rb4 = TrapObj4.GetComponent<Rigidbody> ();
		rb5 = TrapObj5.GetComponent<Rigidbody> ();
		rb6 = TrapObj6.GetComponent<Rigidbody> ();
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == player) {
			Debug.Log ("Trigger Entered.");

		}
	}

	void OnTriggerStay(Collider other)
	{
		Debug.Log ("Player in trigger.");
		if (other.gameObject == player) {
			if (Input.GetKeyDown (KeyCode.E)) {
				Debug.Log ("E Key Pressed.");

				rb1.isKinematic = false;
				rb2.isKinematic = false;
				rb3.isKinematic = false;
				rb4.isKinematic = false;
				rb5.isKinematic = false;
				rb6.isKinematic = false;

				rb1.AddForce (transform.forward * power, ForceMode.Impulse);
				rb2.AddForce (transform.forward * power, ForceMode.Impulse);
				rb3.AddForce (transform.forward * power, ForceMode.Impulse);
				rb4.AddForce (transform.forward * power, ForceMode.Impulse);
				rb5.AddForce (transform.forward * power, ForceMode.Impulse);
				rb6.AddForce (transform.forward * power, ForceMode.Impulse);


			}
		}
	}

	//void OnMouseOver()
	//{
	//	Debug.Log ("Mouse over");
	//	if (Input.GetKeyDown (KeyCode.E)) {
	//		
	//		rb.AddForce (transform.forward * 150);
	//	}
	//}
}
