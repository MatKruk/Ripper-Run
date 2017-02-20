using UnityEngine;
using System.Collections;

public class HorseControl : MonoBehaviour {

	public float speed = 20f;
	public float turnSpeed = 5f;

	private float powerInput;
	private float turnInput;
	private Rigidbody horseRigidbody;


	// Use this for initialization
	void Awake () 
	{
		horseRigidbody = GetComponent <Rigidbody> ();
	}

	// Update is called once per frame
	void Update () 
	{
		powerInput = Input.GetAxis ("Vertical");
		turnInput = Input.GetAxis ("Horizontal");
	}

	void FixedUpdate()
	{

		horseRigidbody.AddRelativeForce (0f, 0f, powerInput * speed);
						  
		horseRigidbody.AddTorque (0f, turnInput * turnSpeed, 0f);

	}

}