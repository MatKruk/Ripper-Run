using UnityEngine;
using System.Collections;

public class DetectHit : MonoBehaviour {

	Animator anim;

    void OnTriggerEnter(Collider other)
    {
		if (Input.GetButton("Fire1"))
		{
			//Destroy(gameObject);
			anim.SetBool ("isDead", true);
		}
		if (Input.GetButton("Fire2"))
		{
			//Destroy(gameObject);
			anim.SetBool ("isDeadToo", true);
			print("THIS WORK");

		}
    }

    // Use this for initialization
    void Start ()
    {
		anim = GetComponent <Animator> ();
	}
	
	// Update is called once per frame
	void Update ()
    {
		

	}
}
