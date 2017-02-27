﻿using UnityEngine;
using System.Collections;

public class DetectHit : MonoBehaviour {

	Animator anim;
    public bool isDead;
	float seconds = 30.0f;
	SphereCollider spherecollider;
	private Rigidbody rb;

    void OnTriggerStay(Collider other)
    {
		if (Input.GetButton("Fire1"))
		{
			//Destroy(gameObject);
			anim.SetBool ("isDead", true);
            isDead = true;
			if (true) 
			{
				Destroy (gameObject, seconds);
				DestroyObject (spherecollider);
				DestroyObject (rb);
			}
		}
		if (Input.GetButton("Fire2"))
		{
			anim.SetBool ("isDeadToo", true);
            isDead = true;
			//print("THIS WORK");
			if (true) 
			{
				Destroy (gameObject, seconds);
				DestroyObject (spherecollider);
				DestroyObject (rb);
			}

		}
    }

    // Use this for initialization
    void Start ()
    {
		anim = GetComponent <Animator> ();
		spherecollider = gameObject.GetComponent<SphereCollider> ();
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

}
