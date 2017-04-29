using UnityEngine;
using System.Collections;

public class HorseControl : MonoBehaviour {

	//Better
	private Rigidbody rb;
	//movement speed
	public float speed = 2.0f;
	//turn speed
	public float tSpeed = 5.0f;


	// Use this for initialization
	void Start () 
	{
		rb = GetComponent <Rigidbody> ();
	}


	void FixedUpdate () 
	{
		/*float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce (movement * speed);*/

		float vert = Input.GetAxis("Vertical") * speed;
		float horiz = Input.GetAxis("Horizontal") * speed;

		//Keep movements smooth
		vert *= Time.deltaTime;
		horiz *= Time.deltaTime;

		transform.Translate(0, 0, vert * speed);
		transform.Rotate (0, horiz * tSpeed, 0);

		//rb.AddForce (0, 0, vert * speed);
		//rb.AddTorque (0, horiz * speed, 0);

	}

	/* OLD
	 
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

	}*/

}