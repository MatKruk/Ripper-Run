using UnityEngine;
using System.Collections;

public class DetectHit : MonoBehaviour {

	Animator anim;
    public bool isDead;
	float seconds = 30.0f;
	SphereCollider spherecollider;
	private Rigidbody rb;
	AudioSource source;

    void OnTriggerEnter(Collider other)
    {
		if (Input.GetButton("Fire1") || Input.GetAxisRaw("RightTrigger") != 0)
		{
			//Destroy(gameObject);
			anim.SetBool ("isDead", true);
            isDead = true;
			if (true) 
			{
				Destroy (gameObject, seconds);
				DestroyObject (spherecollider);
				DestroyObject (rb);

				if (isDead == true) 
				{
					source.Play ();
				}
			}
		}

		if (Input.GetButton("Fire2") || Input.GetAxisRaw("LeftTrigger") != 0)
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
		source = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetKeyDown (KeyCode.N)) 
		{
			anim.SetBool ("dance", true);
			anim.SetBool ("isTalking", false);
		} 
		else if (Input.GetKeyDown (KeyCode.B)) 
		{
			anim.SetBool ("dance", false);
			//anim.SetBool("idle", true);
		}

	}
}
