using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicLure : MonoBehaviour {

	public Transform target;
	public Transform myTransform;
	Animator anim;


	void Start()
	{
		anim = GetComponent <Animator> ();

	}
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButton("L")) {
			transform.LookAt (target);
			transform.Translate (Vector3.forward * 2 * Time.deltaTime);
			anim.SetBool ("isWalking", true);
			anim.SetBool ("isTalking", false);

		} 
		else 
		{
			anim.SetBool ("isWalking", false);
			anim.SetBool ("isTalking", true);
		}

		if (anim.GetBool ("isDead") == true) 
		{
			//print("THIS WORK");
			Destroy (this);
		}

		if (anim.GetBool ("isDeadToo") == true) 
		{
			Destroy (this);
		}

	}
}
