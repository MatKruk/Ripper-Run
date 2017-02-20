using UnityEngine;
using System.Collections;

public class DetectHit : MonoBehaviour {

	Animator anim;
    public bool isDead;
	float seconds = 30.0f;

    void OnTriggerEnter(Collider other)
    {
		if (Input.GetButton("Fire1"))
		{
			//Destroy(gameObject);
			anim.SetBool ("isDead", true);
            isDead = true;
			if (true) 
			{
				Destroy (gameObject, seconds);
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
			}

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
