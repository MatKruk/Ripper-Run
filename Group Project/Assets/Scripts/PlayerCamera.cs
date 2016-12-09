using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour {

	public float speed = 4.0f;
    public float walkSpeed = 3.0f;
	public float runSpeed = 5.0f;
	public float crouchSpeed = 2.0f;
    Animator anim;
	CapsuleCollider capsulecollider;

	// Use this for initialization
	void Start ()
    {
  
        Cursor.lockState = CursorLockMode.Locked;
        anim = GetComponent <Animator> ();
		capsulecollider = gameObject.GetComponent<CapsuleCollider> ();

     }
	
	// Update is called once per frame
	void Update ()
    {
        
        //Move the player vertical or horizontal.
        float translation = Input.GetAxis("Vertical") * speed;
        float translate = Input.GetAxis("Horizontal") * speed;

        //Keep movements smooth
        translation *= Time.deltaTime;
        translate *= Time.deltaTime;
        
        //Move the player across the x and z. 
        transform.Translate(translate, 0, translation);

		//Attacking
        if (Input.GetButton("Fire1"))
        {
            anim.SetBool("isAttacking", true);
        }
        else
        {
            anim.SetBool("isAttacking", false);
        }

		//Different Attack
		if (Input.GetButton("Fire2"))
		{
			anim.SetBool("isAttacking1", true);
		}
		else
		{
			anim.SetBool("isAttacking1", false);
		}

		//Walking Normally
		if (translation != 0 || translate != 0)
        {
            anim.SetBool("isWalking", true);
			anim.SetBool ("isCrouchingForward", false);
            anim.SetBool("isIdle", false);
			speed = walkSpeed;

        }
        else
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isIdle", true);

        }
			
		//Crouching and Crouching Walk
		if (Input.GetButton ("Shift")) 
		{
			capsulecollider.center = new Vector3 (0.0f, 0.75f, 0.0f);
			capsulecollider.radius = 0.5f;
			capsulecollider.height = 1.0f;
			anim.SetBool ("isCrouching", true);
			anim.SetBool("isIdle", false);


			if (translation != 0 || translate != 0) 
			{
				anim.SetBool ("isCrouching", false);
				anim.SetBool("isWalking", false);
				anim.SetBool ("isCrouchingForward", true);
				speed = crouchSpeed;
			} 
			else 
			{
				anim.SetBool ("isCrouchingForward", false);
				//anim.SetBool("isIdle", true);
			}
		} 
		else
		{
			capsulecollider.center = new Vector3 (0.0f, 1.0f, 0.0f);
			capsulecollider.height = 2.0f;
			capsulecollider.radius = 0.75f;
			anim.SetBool ("isCrouching", false);
			//speed = walkSpeed;
		}

		//Running
		if (Input.GetButton ("Jump"))
		{
			if (translation != 0 || translate != 0)
			{
			anim.SetBool ("isRunning", true); 
			anim.SetBool ("isWalking", false);
			anim.SetBool ("isCrouchingForward", false);
			speed = runSpeed;
			}
		}
		else 
		{
			anim.SetBool("isRunning", false);
			//speed = walkSpeed;
		}

        //Allows the mouse to be shown in order to escape gameplay.
        if (Input.GetKeyDown("escape"))
            Cursor.lockState = CursorLockMode.None;

    }

  
}
