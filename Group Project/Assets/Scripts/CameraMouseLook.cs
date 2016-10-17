using UnityEngine;
using System.Collections;

public class CameraMouseLook : MonoBehaviour {

    Vector2 mouseLook;
    Vector2 smoothV;

    public float sens = 5.0f;
    public float smoothing = 2.0f;

    GameObject character;

	// Use this for initialization
	void Start ()
    {
        //Set to the parent of the code is attached to
        character = this.transform.parent.gameObject;
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        md = Vector2.Scale(md, new Vector2(sens * smoothing, sens * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);

        mouseLook += smoothV;

        //Stops the player from being able to look too high or low around.
        mouseLook.y = Mathf.Clamp(mouseLook.y, -90f, 90f);

        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);

	}
}
