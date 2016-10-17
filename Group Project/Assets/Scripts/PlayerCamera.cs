using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour {

    public float speed = 10.0f;
    
	// Use this for initialization
	void Start ()
    {
        Cursor.lockState = CursorLockMode.Locked;
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
        
        //Allows the mouse to be shown in order to escape gameplay.
        if (Input.GetKeyDown("escape"))
            Cursor.lockState = CursorLockMode.None;

    }
}
